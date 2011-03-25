// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the magnetic flux quantity
	/// </summary>
	public struct MagneticFlux : IQuantity<MagneticFlux>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = (QuantityDimension.Length ^ 2) * QuantityDimension.Mass *
	                                                           (QuantityDimension.Time ^ -2) *
	                                                           (QuantityDimension.ElectricCurrent ^ -1);

		public static readonly Unit<MagneticFlux> Weber = new Unit<MagneticFlux>("Wb");
	    public static readonly Unit<MagneticFlux> KiloWeber = new Unit<MagneticFlux>(UnitPrefix.Kilo);
	    public static readonly Unit<MagneticFlux> MegaWeber = new Unit<MagneticFlux>(UnitPrefix.Mega);
	    public static readonly Unit<MagneticFlux> GigaWeber = new Unit<MagneticFlux>(UnitPrefix.Giga);
	    public static readonly Unit<MagneticFlux> MilliWeber = new Unit<MagneticFlux>(UnitPrefix.Milli);
	    public static readonly Unit<MagneticFlux> MicroWeber = new Unit<MagneticFlux>(UnitPrefix.Micro);
	    public static readonly Unit<MagneticFlux> NanoWeber = new Unit<MagneticFlux>(UnitPrefix.Nano);

		#endregion

		#region Implementation of IQuantity<MagneticFlux>

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
		public IUnit<MagneticFlux> StandardUnit
		{
			get { return Weber; }
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
