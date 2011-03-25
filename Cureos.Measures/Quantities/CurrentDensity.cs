// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the current density quantity
	/// </summary>
	public struct CurrentDensity : IQuantity<CurrentDensity>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = (QuantityDimension.Length ^ -2) *
	                                                           QuantityDimension.ElectricCurrent;

		public static readonly Unit<CurrentDensity> AmperePerSquareMeter = new Unit<CurrentDensity>("A m\u207b²");
	    public static readonly Unit<CurrentDensity> KiloAmperePerSquareMeter = new Unit<CurrentDensity>(UnitPrefix.Kilo);
	    public static readonly Unit<CurrentDensity> MilliAmperePerSquareMeter = new Unit<CurrentDensity>(UnitPrefix.Milli);
	    public static readonly Unit<CurrentDensity> MicroAmperePerSquareMeter = new Unit<CurrentDensity>(UnitPrefix.Micro);
	    public static readonly Unit<CurrentDensity> NanoAmperePerSquareMeter = new Unit<CurrentDensity>(UnitPrefix.Nano);

		#endregion

		#region Implementation of IQuantity<CurrentDensity>

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
		public IUnit<CurrentDensity> StandardUnit
		{
			get { return AmperePerSquareMeter; }
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
