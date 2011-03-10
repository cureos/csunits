// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	public struct Length : IQuantity<Length>
	{
        public static readonly Unit<Length> Meter = new Unit<Length>("m");
        public static readonly Unit<Length> DeciMeter = new Unit<Length>("dm", Factors.Deci);
        public static readonly Unit<Length> CentiMeter = new Unit<Length>("cm", Factors.Centi);
        public static readonly Unit<Length> MilliMeter = new Unit<Length>("mm", Factors.Milli);

        internal static readonly QuantityDimensions Base = new QuantityDimensions(1, 0, 0, 0, 0, 0, 0);

	    public QuantityDimensions Dimensions
	    {
	        get { return Base; }
	    }

	    public IUnit<Length> StandardUnit
	    {
	        get { return Meter; }
	    }
	}
}

