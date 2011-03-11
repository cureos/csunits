// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    public struct Volume : IQuantity<Volume>
    {
        private static readonly QuantityDimension _dimension = Length.BaseDimension ^ 3;

        public static readonly Unit<Volume> CubicMeter = new Unit<Volume>("m³");
        public static readonly Unit<Volume> Liter = new Unit<Volume>("l", Factors.Cube(Factors.Deci));
        public static readonly Unit<Volume> CubicDeciMeter = new Unit<Volume>("dm³", Factors.Cube(Factors.Deci));
        public static readonly Unit<Volume> CubicCentiMeter = new Unit<Volume>("cm³", Factors.Cube(Factors.Centi));

        public QuantityDimension Dimension
        {
            get { return _dimension; }
        }

        public IUnit<Volume> StandardUnit
        {
            get { return CubicMeter; }
        }
    }
}
