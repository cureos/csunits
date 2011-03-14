// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
	/// <summary>
	/// Interface representing a scalar measure of a specific quantity
	/// </summary>
	/// <typeparam name="Q">Measured quantity</typeparam>
	public interface IMeasure<Q> : IComparable<IMeasure<Q>>, IEquatable<IMeasure<Q>> where Q : struct, IQuantity<Q>
	{
		/// <summary>
		/// Gets the measured amount in the <see cref="Unit">current unit of measure</see>
		/// </summary>
		AmountType Amount
		{
			get;
		}

		/// <summary>
		/// Gets the unit of measure
		/// </summary>
		IUnit<Q> Unit { get; }

		/// <summary>
		/// Gets the amount of this measure in the requested unit
		/// </summary>
		/// <param name="iUnit">Unit to which the measured amount should be converted</param>
		/// <returns>Measured amount converted into <paramref name="iUnit">specified unit</paramref></returns>
		AmountType GetAmount(IUnit<Q> iUnit);

		/// <summary>
		/// Gets a new unit specific measure based on this measure but in the <paramref name="iUnit">specified unit</paramref>
		/// </summary>
		/// <param name="iUnit">Unit in which the new measure should be specified</param>
		IMeasure<Q> this[IUnit<Q> iUnit] { get; }
	}

	/// <summary>
	/// Interface representing a pair of measures given in two (potentially different) quantities
	/// </summary>
	/// <typeparam name="Q1">Quantity type of the first measure</typeparam>
	/// <typeparam name="Q2">Quantity type of the second measure</typeparam>
	public interface IMeasure<Q1, Q2> where Q1 : struct, IQuantity<Q1> where Q2 : struct, IQuantity<Q2>
	{
		/// <summary>
		/// Gets the first measure in the measure pair
		/// </summary>
		IMeasure<Q1> Measure1 { get; }

		/// <summary>
		/// Gets the second measure in the measure pair
		/// </summary>
		IMeasure<Q2> Measure2 { get; }
	}
}

