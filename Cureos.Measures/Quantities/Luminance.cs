// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the luminance quantity
	/// </summary>
	public struct Luminance : IQuantity<Luminance>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = (QuantityDimension.Length ^ -2) *
	                                                           QuantityDimension.LuminousIntensity;

		public static readonly Unit<Luminance> CandelaPerSquareMeter = new Unit<Luminance>("cd m\u207b²");
	    public static readonly Unit<Luminance> KiloCandelaPerSquareMeter = new Unit<Luminance>(UnitPrefix.Kilo);
	    public static readonly Unit<Luminance> MegaCandelaPerSquareMeter = new Unit<Luminance>(UnitPrefix.Mega);
	    public static readonly Unit<Luminance> GigaCandelaPerSquareMeter = new Unit<Luminance>(UnitPrefix.Giga);
	    public static readonly Unit<Luminance> MilliCandelaPerSquareMeter = new Unit<Luminance>(UnitPrefix.Milli);
	    public static readonly Unit<Luminance> MicroCandelaPerSquareMeter = new Unit<Luminance>(UnitPrefix.Micro);
	    public static readonly Unit<Luminance> NanoCandelaPerSquareMeter = new Unit<Luminance>(UnitPrefix.Nano);

		#endregion

		#region Implementation of IQuantity<Luminance>

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
		public IUnit<Luminance> StandardUnit
		{
			get { return CandelaPerSquareMeter; }
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
