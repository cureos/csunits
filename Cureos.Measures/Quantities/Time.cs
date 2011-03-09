// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    public struct Time : IQuantity<Time>
    {
        private static readonly QuantityDimensions smkDimensions = new QuantityDimensions(0, 0, 1, 0, 0, 0, 0);

        public QuantityDimensions Dimensions
        {
            get { return smkDimensions; }
        }

        public IUnit<Time> StandardUnit
        {
            get { return Units.Second; }
        }
    }
}
