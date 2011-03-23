// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the luminous intensity quantity
    /// </summary>
    public struct LuminousIntensity : IQuantity<LuminousIntensity>
    {
        #region FIELDS

        public static readonly Unit<LuminousIntensity> Candela = new Unit<LuminousIntensity>("cd");

        #endregion

        #region Implementation of IQuantity<LuminousIntensity>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return QuantityDimension.LuminousIntensity; }
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
        public IUnit<LuminousIntensity> StandardUnit
        {
            get { return Candela; }
        }

        #endregion
    }
}