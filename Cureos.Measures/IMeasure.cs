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
	public interface IMeasure
	{
		/// <summary>
		/// Gets the measured amount in the <see cref="EnumeratedUnit">current unit of measure</see>
		/// </summary>
		AmountType Amount
		{
			get;
		}

		/// <summary>
		/// Gets the unit of measure
		/// </summary>
		EnumUnit EnumeratedUnit
		{
			get;
		}

		/// <summary>
		/// Gets the amount of this measure in the requested unit
		/// </summary>
		/// <param name="iUnit">Unit to which the measured amount should be converted</param>
		/// <returns>Measured amount converted into <paramref name="iUnit">specified unit</paramref></returns>
		/// <exception cref="InvalidOperationException">is thrown if the quantity of the specified unit is different
		/// from the measured quantity</exception>
		AmountType GetAmount(EnumUnit iUnit);
	}

	public interface IMeasure<Q> : IMeasure where Q : struct, IQuantity<Q>
	{
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
	}
}

