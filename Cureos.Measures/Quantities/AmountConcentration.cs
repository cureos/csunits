// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the amount concentration quantity
	/// </summary>
	public struct AmountConcentration : IQuantity<AmountConcentration>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = (QuantityDimension.Length ^ -3) *
	                                                           QuantityDimension.AmountOfSubstance;

		public static readonly Unit<AmountConcentration> MolePerCubicMeter = new Unit<AmountConcentration>("mol m\u207b³");
	    public static readonly Unit<AmountConcentration> KiloMolePerCubicMeter = new Unit<AmountConcentration>(UnitPrefix.Kilo);
	    public static readonly Unit<AmountConcentration> MegaMolePerCubicMeter = new Unit<AmountConcentration>(UnitPrefix.Mega);
	    public static readonly Unit<AmountConcentration> GigaMolePerCubicMeter = new Unit<AmountConcentration>(UnitPrefix.Giga);
	    public static readonly Unit<AmountConcentration> MilliMolePerCubicMeter = new Unit<AmountConcentration>(UnitPrefix.Milli);
	    public static readonly Unit<AmountConcentration> MicroMolePerCubicMeter = new Unit<AmountConcentration>(UnitPrefix.Micro);
	    public static readonly Unit<AmountConcentration> NanoMolePerCubicMeter = new Unit<AmountConcentration>(UnitPrefix.Nano);

		#endregion

		#region Implementation of IQuantity<AmountConcentration>

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
		public IUnit<AmountConcentration> StandardUnit
		{
			get { return MolePerCubicMeter; }
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
