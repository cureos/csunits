// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

namespace Cureos.Measures
{
	public interface IQuantity
	{
		EnumQuantity EnumeratedValue { get; }

		QuantityDimensions Dimensions { get; }
	}

	public interface IQuantity<Q> : IQuantity where Q : struct, IQuantity<Q>
	{
		IUnit<Q> ReferenceUnit { get; }
	}
}

