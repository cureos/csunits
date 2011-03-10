// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html


namespace Cureos.Measures.Quantities
{
    public struct Energy : IQuantity<Energy>
    {
        private static readonly QuantityDimension _dimension = 2 * Length.BaseDimension + Mass.BaseDimension - 2 * Time.BaseDimension;

        public static readonly Unit<Energy> Joule = new Unit<Energy>("J");
        public static readonly Unit<Energy> KiloJoule = new Unit<Energy>("kJ", Factors.Kilo);

        #region Implementation of IQuantity

        public QuantityDimension Dimension
        {
            get { return _dimension; }
        }

        public IUnit<Energy> StandardUnit
        {
            get { return Joule; }
        }

        #endregion
    }
}