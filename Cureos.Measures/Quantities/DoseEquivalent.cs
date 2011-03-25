// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the dose equivalent quantity
	/// </summary>
	public struct DoseEquivalent : IQuantity<DoseEquivalent>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = (QuantityDimension.Length ^ 2) *
	                                                           (QuantityDimension.Time ^ -2);

		public static readonly Unit<DoseEquivalent> Sievert = new Unit<DoseEquivalent>("Sv");
	    public static readonly Unit<DoseEquivalent> KiloSievert = new Unit<DoseEquivalent>(UnitPrefix.Kilo);
	    public static readonly Unit<DoseEquivalent> MilliSievert = new Unit<DoseEquivalent>(UnitPrefix.Milli);
	    public static readonly Unit<DoseEquivalent> MicroSievert = new Unit<DoseEquivalent>(UnitPrefix.Micro);
	    public static readonly Unit<DoseEquivalent> NanoSievert = new Unit<DoseEquivalent>(UnitPrefix.Nano);

		#endregion

		#region Implementation of IQuantity<DoseEquivalent>

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
		public IUnit<DoseEquivalent> StandardUnit
		{
			get { return Sievert; }
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
