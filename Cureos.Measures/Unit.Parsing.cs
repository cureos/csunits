using System;
using System.Collections.Generic;
using System.Linq;

namespace Cureos.Measures
{
	public class Unit
	{
		private static readonly IDictionary<string, IUnit> _unitsBySymbol;

		class UnitSymbolComparer : IEqualityComparer<IUnit>
		{
			public bool Equals(IUnit x, IUnit y)
			{
				return StringComparer.OrdinalIgnoreCase.Equals(x.Symbol, y.Symbol);
			}

			public int GetHashCode(IUnit obj)
			{
				return StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Symbol);
			}
		}

		static Unit()
		{
			_unitsBySymbol = QuantityCollection.Quantities
				.SelectMany(qa => qa.Units)
				.Distinct(new UnitSymbolComparer())
				.ToDictionary(u => u.Symbol, u => u, StringComparer.OrdinalIgnoreCase);
		}

		public static IUnit Parse(string s)
		{
			try
			{
				return _unitsBySymbol[s];
			}
			catch (KeyNotFoundException)
			{
				throw UnitNotFoundException.Default(s, "s");
			}
		}

		public static bool TryParse(string s, out IUnit unit)
		{
			return _unitsBySymbol.TryGetValue(s, out unit);
		}

		public static IUnit<Q> Parse<Q>(string s) where Q : struct, IQuantity<Q>
		{
			IUnit parsed = Parse(s);
			return (IUnit<Q>)parsed;
		}
	}
}