// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures.Units;

namespace Cureos.Measures.Quantities
{
	public struct Length : IQuantity<Length>
	{
	    private static readonly QuantityDimensions smkDimensions = new QuantityDimensions(1, 0, 0, 0, 0, 0, 0);

		public EnumQuantity EnumeratedValue
		{
			get { throw new NotImplementedException(); }
		}

	    public QuantityDimensions Dimensions
	    {
	        get { return smkDimensions; }
	    }

	    public IUnit<Length> ReferenceUnit
	    {
	        get { return Unit.Meter; }
	    }
	}
}

