// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the magnetic flux density quantity
	/// </summary>
	public struct MagneticFluxDensity : IQuantity<MagneticFluxDensity>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = QuantityDimension.Mass *
	                                                           (QuantityDimension.Time ^ -2) *
	                                                           (QuantityDimension.ElectricCurrent ^ -1);

		public static readonly Unit<MagneticFluxDensity> Tesla = new Unit<MagneticFluxDensity>("T");
	    public static readonly Unit<MagneticFluxDensity> KiloTesla = new Unit<MagneticFluxDensity>(UnitPrefix.Kilo);
	    public static readonly Unit<MagneticFluxDensity> MegaTesla = new Unit<MagneticFluxDensity>(UnitPrefix.Mega);
	    public static readonly Unit<MagneticFluxDensity> GigaTesla = new Unit<MagneticFluxDensity>(UnitPrefix.Giga);
	    public static readonly Unit<MagneticFluxDensity> MilliTesla = new Unit<MagneticFluxDensity>(UnitPrefix.Milli);
	    public static readonly Unit<MagneticFluxDensity> MicroTesla = new Unit<MagneticFluxDensity>(UnitPrefix.Micro);
	    public static readonly Unit<MagneticFluxDensity> NanoTesla = new Unit<MagneticFluxDensity>(UnitPrefix.Nano);

		#endregion

		#region Implementation of IQuantity<MagneticFluxDensity>

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
		public IUnit<MagneticFluxDensity> StandardUnit
		{
			get { return Tesla; }
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
