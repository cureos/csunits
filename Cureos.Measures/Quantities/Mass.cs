// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html


namespace Cureos.Measures.Quantities
{
    public struct Mass : IQuantity<Mass>
    {
        public static readonly QuantityDimension BaseDimension = new QuantityDimension(0, 1, 0, 0, 0, 0, 0);

        public static readonly Unit<Mass> KiloGram = new Unit<Mass>("kg");
        public static readonly Unit<Mass> Tonne = new Unit<Mass>("t", Factors.Kilo);
        public static readonly Unit<Mass> HectoGram = new Unit<Mass>("hg", Factors.Deci);
        public static readonly Unit<Mass> Gram = new Unit<Mass>("g", Factors.Milli);

        public QuantityDimension Dimension
        {
            get { return BaseDimension; }
        }

        public IUnit<Mass> StandardUnit
        {
            get { return KiloGram; }
        }
    }
}
