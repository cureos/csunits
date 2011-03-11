// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the absorbed dose quantity
    /// </summary>
    public struct AbsorbedDose : IQuantity<AbsorbedDose>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension = (QuantityDimension.Length ^ 2) * (QuantityDimension.Time ^ 2);

        public static readonly Unit<AbsorbedDose> Gray = new Unit<AbsorbedDose>("Gy");
        public static readonly Unit<AbsorbedDose> CentiGray = new Unit<AbsorbedDose>("cGy", Factors.Centi);

        #endregion

        #region Implementation of IQuantity<Q>

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
        public IUnit<AbsorbedDose> StandardUnit
        {
            get { return Gray; }
        }

        #endregion
    }
}
