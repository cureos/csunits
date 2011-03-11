// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the temperature quantity
    /// </summary>
    public struct Temperature : IQuantity<Temperature>
    {
        #region FIELDS

        public static readonly Unit<Temperature> Kelvin = new Unit<Temperature>("K");
        public static readonly Unit<Temperature> Celsius = new Unit<Temperature>("°C",
                        a => a + Factors.CelsiusKelvinDifference, a => a - Factors.CelsiusKelvinDifference);

        #endregion

        #region Implementation of IQuantity<Q>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return QuantityDimension.Temperature; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        public IUnit<Temperature> StandardUnit
        {
            get { return Kelvin; }
        }

        #endregion
    }
}
