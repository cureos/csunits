// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures
{
	/// <summary>
	/// Interface representing a physical quantity
	/// </summary>
	public interface IQuantity
	{
		/// <summary>
		/// Gets the physical dimension of the quantity in terms of SI units
		/// </summary>
		QuantityDimension Dimension { get; }

		/// <summary>
		/// Gets the standard unit associated with the quantity
		/// </summary>
		IUnit StandardUnit { get; }
	}

	/// <summary>
	/// Typed interface representing a physical quantity
	/// </summary>
	/// <typeparam name="Q"></typeparam>
	public interface IQuantity<Q> : IQuantity where Q : struct, IQuantity<Q>
	{
		/// <summary>
		/// Gets the standard unit associated with the quantity
		/// </summary>
		new IUnit<Q> StandardUnit { get; }
	}
}

