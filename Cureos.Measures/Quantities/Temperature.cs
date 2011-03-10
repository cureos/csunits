// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    public struct Temperature : IQuantity<Temperature>
    {
        public static readonly Unit<Temperature> Kelvin = new Unit<Temperature>("K");
        public static readonly Unit<Temperature> Celsius = new Unit<Temperature>("°C",
                        a => a + Factors.CelsiusKelvinDifference, a => a - Factors.CelsiusKelvinDifference);

        internal static readonly QuantityDimensions Base = new QuantityDimensions(0, 0, 0, 0, 1, 0, 0);

        public QuantityDimensions Dimensions
        {
            get { return Base; }
        }

        public IUnit<Temperature> StandardUnit
        {
            get { return Kelvin; }
        }
    }
}
