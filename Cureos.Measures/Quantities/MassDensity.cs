// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the mass density quantity
    /// </summary>
    public struct MassDensity : IQuantity<MassDensity>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension = QuantityDimension.Mass * (QuantityDimension.Length ^ -3);

        public static readonly Unit<MassDensity> KiloGramPerCubicMeter = new Unit<MassDensity>("kg m\u207b³");
        public static readonly Unit<MassDensity> KiloGramPerLiter = new Unit<MassDensity>("kg l\u207b¹", Factors.Kilo);
        public static readonly Unit<MassDensity> GramPerCubicCentiMeter = new Unit<MassDensity>("g cm\u207b³", Factors.Kilo);

        #endregion

        #region Implementation of IQuantity<MassDensity>

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
        public IUnit<MassDensity> StandardUnit
        {
            get { return KiloGramPerCubicMeter; }
        }

        #endregion
    }
}