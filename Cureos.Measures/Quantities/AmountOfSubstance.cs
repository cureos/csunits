// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the amount of substance quantity
    /// </summary>
    public struct AmountOfSubstance : IQuantity<AmountOfSubstance>
    {
        #region FIELDS

        public static readonly Unit<AmountOfSubstance> Mole = new Unit<AmountOfSubstance>("mol");
        public static readonly Unit<AmountOfSubstance> MilliMole = new Unit<AmountOfSubstance>(UnitPrefix.Milli);
        public static readonly Unit<AmountOfSubstance> MicroMole = new Unit<AmountOfSubstance>(UnitPrefix.Micro);

        #endregion
        
        #region Implementation of IQuantity<AmountOfSubstance>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return QuantityDimension.AmountOfSubstance; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        public IUnit<AmountOfSubstance> StandardUnit
        {
            get { return Mole; }
        }

        #endregion
    }
}