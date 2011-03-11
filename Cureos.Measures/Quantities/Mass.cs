// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html


namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the mass quantity
    /// </summary>
    public struct Mass : IQuantity<Mass>
    {
        #region FIELDS

        public static readonly Unit<Mass> KiloGram = new Unit<Mass>("kg");
        public static readonly Unit<Mass> Tonne = new Unit<Mass>("t", Factors.Kilo);
        public static readonly Unit<Mass> HectoGram = new Unit<Mass>("hg", Factors.Deci);
        public static readonly Unit<Mass> Gram = new Unit<Mass>("g", Factors.Milli);

        #endregion

        #region Implementation of IQuantity<Q>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return QuantityDimension.Mass; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        public IUnit<Mass> StandardUnit
        {
            get { return KiloGram; }
        }

        #endregion
    }
}
