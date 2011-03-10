// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    public struct AbsorbedDose : IQuantity<AbsorbedDose>
    {
        private static readonly QuantityDimension _dimension = 2 * Length.BaseDimension + 2 * Time.BaseDimension;

        public static readonly Unit<AbsorbedDose> Gray = new Unit<AbsorbedDose>("Gy");
        public static readonly Unit<AbsorbedDose> CentiGray = new Unit<AbsorbedDose>("cGy", Factors.Centi);

        public QuantityDimension Dimension
        {
            get { return _dimension; }
        }

        public IUnit<AbsorbedDose> StandardUnit
        {
            get { return Gray; }
        }
    }
}
