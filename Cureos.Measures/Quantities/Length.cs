// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the length quantity
	/// </summary>
	public struct Length : IQuantity<Length>
	{
		#region FIELDS

		public static readonly Unit<Length> Meter = new Unit<Length>("m");
		public static readonly Unit<Length> DeciMeter = new Unit<Length>("dm", Factors.Deci);
		public static readonly Unit<Length> CentiMeter = new Unit<Length>("cm", Factors.Centi);
		public static readonly Unit<Length> MilliMeter = new Unit<Length>("mm", Factors.Milli);

		#endregion

		#region Implementation of IQuantity<Q>

		/// <summary>
		/// Gets the physical dimension of the quantity in terms of SI units
		/// </summary>
		public QuantityDimension Dimension
		{
			get { return QuantityDimension.Length; }
		}

		/// <summary>
		/// Gets the standard unit associated with the quantity
		/// </summary>
		public IUnit<Length> StandardUnit
		{
			get { return Meter; }
		}

		#endregion
	}
}

