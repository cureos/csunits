// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the power quantity
	/// </summary>
	public struct Power : IQuantity<Power>
	{
		#region FIELDS
		
		private static readonly QuantityDimension _dimension = new QuantityDimension(2, 1, -3, 0, 0, 0, 0);

		public static readonly Unit<Power> Watt = new Unit<Power>("W");
		public static readonly Unit<Power> KiloWatt = new Unit<Power>("kW", Factors.Kilo);
		public static readonly Unit<Power> MegaWatt = new Unit<Power>("MW", Factors.Mega);
		public static readonly Unit<Power> GigaWatt = new Unit<Power>("GW", Factors.Giga);
		public static readonly Unit<Power> TeraWatt = new Unit<Power>("TW", Factors.Tera);
		public static readonly Unit<Power> MilliWatt = new Unit<Power>("mW", Factors.Milli);
		public static readonly Unit<Power> MicroWatt = new Unit<Power>("µW", Factors.Micro);

		#endregion

		#region Implementation of IQuantity<Power>

		/// <summary>
		/// Gets the physical dimension of the quantity in terms of SI units
		/// </summary>
		public QuantityDimension Dimension
		{
			get { return _dimension; }
		}

		/// <summary>
		/// Gets the standard unit associated with the quantity
		/// </summary>
		public IUnit<Power> StandardUnit
		{
			get { return Watt; }
		}

		#endregion
	}
}
