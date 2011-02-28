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
		/// Gets the measured amount in the <paramref name="MeasuredUnit">current unit of measure</paramref>
		/// </summary>
		AmountType MeasuredAmount
		{
			get;
		}

		/// <summary>
		/// Gets the measured amount in the <paramref name="ReferenceUnit">reference unit of measure</paramref>
		/// </summary>
		AmountType ReferenceUnitAmount
		{
			get;
		}

		/// <summary>
		/// Gets the measured quantity
		/// </summary>
		Quantity MeasuredQuantity
		{
			get;
		}
		
		/// <summary>
		/// Gets the unit of measure
		/// </summary>
		Unit MeasuredUnit
		{
			get;
		}

		/// <summary>
		/// Gets the reference unit of measure for the <paramref name="MeasuredQuantity">measured quantity</paramref>
		/// </summary>
		Unit ReferenceUnit
		{
			get;
		}

		/// <summary>
		/// Gets the amount of the measure in the <paramref name="iUnit">requested unit</paramref> of the same quantity
		/// </summary>
		/// <param name="iUnit">Unit in which the measured amount should be specified</param>
		/// <returns>The measured amount in the <paramref name="iUnit">requested unit</paramref></returns>
		AmountType GetAmount(Unit iUnit);
	}
}

