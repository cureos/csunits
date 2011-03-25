// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the magnetic field strength quantity
	/// </summary>
	public struct MagneticFieldStrength : IQuantity<MagneticFieldStrength>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = QuantityDimension.ElectricCurrent / QuantityDimension.Length;

		public static readonly Unit<MagneticFieldStrength> AmperePerMeter = new Unit<MagneticFieldStrength>("A m\u207b¹");
	    public static readonly Unit<MagneticFieldStrength> KiloAmperePerMeter = new Unit<MagneticFieldStrength>(UnitPrefix.Kilo);
	    public static readonly Unit<MagneticFieldStrength> MegaAmperePerMeter = new Unit<MagneticFieldStrength>(UnitPrefix.Mega);
	    public static readonly Unit<MagneticFieldStrength> GigaAmperePerMeter = new Unit<MagneticFieldStrength>(UnitPrefix.Giga);
	    public static readonly Unit<MagneticFieldStrength> MilliAmperePerMeter = new Unit<MagneticFieldStrength>(UnitPrefix.Milli);
	    public static readonly Unit<MagneticFieldStrength> MicroAmperePerMeter = new Unit<MagneticFieldStrength>(UnitPrefix.Micro);
	    public static readonly Unit<MagneticFieldStrength> NanoAmperePerMeter = new Unit<MagneticFieldStrength>(UnitPrefix.Nano);

		#endregion

		#region Implementation of IQuantity<MagneticFieldStrength>

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
		public IUnit<MagneticFieldStrength> StandardUnit
		{
			get { return AmperePerMeter; }
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
