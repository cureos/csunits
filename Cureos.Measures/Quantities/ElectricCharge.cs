// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the electric charge quantity
	/// </summary>
	public struct ElectricCharge : IQuantity<ElectricCharge>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = QuantityDimension.Time * QuantityDimension.ElectricCurrent;

		public static readonly Unit<ElectricCharge> Coulomb = new Unit<ElectricCharge>("C");
        public static readonly Unit<ElectricCharge> MilliCoulomb = new Unit<ElectricCharge>(UnitPrefix.Milli);
        public static readonly Unit<ElectricCharge> MicroCoulomb = new Unit<ElectricCharge>(UnitPrefix.Micro);
        public static readonly Unit<ElectricCharge> NanoCoulomb = new Unit<ElectricCharge>(UnitPrefix.Nano);
        public static readonly Unit<ElectricCharge> PicoCoulomb = new Unit<ElectricCharge>(UnitPrefix.Pico);
        public static readonly Unit<ElectricCharge> ElementaryCharge = new Unit<ElectricCharge>("e", Factors.CoulombsPerElementaryCharge);

		#endregion

		#region Implementation of IQuantity<ElectricCharge>

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
		public IUnit<ElectricCharge> StandardUnit
		{
			get { return Coulomb; }
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
