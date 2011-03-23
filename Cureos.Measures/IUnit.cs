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
	/// Interface representing a physical unit
	/// </summary>
	public interface IUnit
	{
		/// <summary>
		/// Gets the display symbol of the unit
		/// </summary>
		string Symbol { get; }

		/// <summary>
		/// Gets the amount converter function from the current unit to the standard unit 
		/// of the specified quantity
		/// </summary>
		Func<AmountType, AmountType> AmountToStandardUnitConverter { get; }

		/// <summary>
		/// Gets the amount converter function from the standard unit of the specified quantity
		/// to the current unit
		/// </summary>
		Func<AmountType, AmountType> AmountFromStandardUnitConverter { get; }
	}

	/// <summary>
	/// Interface representing a physical unit confined to a specific quantity
	/// </summary>
	/// <typeparam name="Q">Unit quantity</typeparam>
	public interface IUnit<Q> : IUnit where Q : struct, IQuantity<Q>
	{
	}
}

