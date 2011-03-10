// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    public struct Temperature : IQuantity<Temperature>
    {
        internal static readonly QuantityDimension BaseDimension = new QuantityDimension(0, 0, 0, 0, 1, 0, 0);

        public static readonly Unit<Temperature> Kelvin = new Unit<Temperature>("K");
        public static readonly Unit<Temperature> Celsius = new Unit<Temperature>("°C",
                        a => a + Factors.CelsiusKelvinDifference, a => a - Factors.CelsiusKelvinDifference);

        public QuantityDimension Dimension
        {
            get { return BaseDimension; }
        }

        public IUnit<Temperature> StandardUnit
        {
            get { return Kelvin; }
        }
    }
}
