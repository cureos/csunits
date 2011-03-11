// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    public struct Time : IQuantity<Time>
    {
        public static readonly QuantityDimension BaseDimension = new QuantityDimension(0, 0, 1, 0, 0, 0, 0);

        public static readonly Unit<Time> Second = new Unit<Time>("s");
        public static readonly Unit<Time> Minute = new Unit<Time>("min", Factors.SecondsPerMinute);
        public static readonly Unit<Time> Hour = new Unit<Time>("h", Factors.SecondsPerHour);
        public static readonly Unit<Time> Day = new Unit<Time>("dy", Factors.SecondsPerDay);
        public static readonly Unit<Time> Week = new Unit<Time>("wk", Factors.SecondsPerWeek);

        public QuantityDimension Dimension
        {
            get { return BaseDimension; }
        }

        public IUnit<Time> StandardUnit
        {
            get { return Second; }
        }
    }
}
