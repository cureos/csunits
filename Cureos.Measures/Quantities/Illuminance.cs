// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the illuminance quantity
	/// </summary>
	public struct Illuminance : IQuantity<Illuminance>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension =
	        QuantityDimension.Steradian * (QuantityDimension.Length ^ -2) * QuantityDimension.LuminousIntensity;

		public static readonly Unit<Illuminance> Lux = new Unit<Illuminance>("lx");
	    public static readonly Unit<Illuminance> KiloLux = new Unit<Illuminance>(UnitPrefix.Kilo);
	    public static readonly Unit<Illuminance> MegaLux = new Unit<Illuminance>(UnitPrefix.Mega);
	    public static readonly Unit<Illuminance> GigaLux = new Unit<Illuminance>(UnitPrefix.Giga);
	    public static readonly Unit<Illuminance> MilliLux = new Unit<Illuminance>(UnitPrefix.Milli);
	    public static readonly Unit<Illuminance> MicroLux = new Unit<Illuminance>(UnitPrefix.Micro);
	    public static readonly Unit<Illuminance> NanoLux = new Unit<Illuminance>(UnitPrefix.Nano);

		#endregion

		#region Implementation of IQuantity<Illuminance>

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
	    IUnit IQuantity.StandardUnit
	    {
	        get { return StandardUnit; }
	    }

	    /// <summary>
		/// Gets the standard unit associated with the quantity
		/// </summary>
		public IUnit<Illuminance> StandardUnit
		{
			get { return Lux; }
		}

		#endregion

        #region METHODS

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return GetType().Name;
        }

        #endregion
    }
}
