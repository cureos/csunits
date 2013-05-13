using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Cureos.Measures
{
	public class Measure
	{
		private static readonly IDictionary<IUnit, Func<double, IUnit, IMeasure>> _creationsByUnit;
		static Measure()
		{
			_creationsByUnit = QuantityCollection.Quantities
				.SelectMany(qa => qa.Units)
				.ToDictionary(u => u, generate);
		}

		private static Func<double, IUnit, IMeasure> generate(IUnit unit)
		{
			Type measure = typeof(Measure<>).MakeGenericType(unit.Quantity.GetType());

			// would like to generate delegate from expression, but WinPho does not support .Compile()
			// .Create instance is not the fastest way to create instances
			return (a, u) => (IMeasure)Activator.CreateInstance(measure, a, u);
			
			/* 
			Type unitType = unit.GetType();
			ConstructorInfo ctor = measure
				.GetConstructor(new[] { typeof(double), unitType });
			
			ParameterExpression
				param1 = Expression.Parameter(typeof(double), "arg1"),
				param2 = Expression.Parameter(unitType, "arg2");

			return Expression.Lambda(
				Expression.New(ctor, param1, param2), param1, param2)
				.Compile();
			 */

		}

		public static IMeasure From(double amount, string unit)
		{
			IUnit parsed = Unit.Parse(unit);

			Func<double, IUnit, IMeasure> creation = _creationsByUnit[parsed];

			return creation(amount, parsed);
		}

		public static IMeasure<Q> From<Q>(double amount, string unit) where Q : struct, IQuantity<Q>
		{
			IUnit parsed = Unit.Parse(unit);

			Func<double, IUnit, IMeasure> creation = _creationsByUnit[parsed];

			IMeasure created = creation(amount, parsed);

			return (IMeasure<Q>) created;
		}
	}
}
