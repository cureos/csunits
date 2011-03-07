// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures.Quantities;

namespace Cureos.Measures.Units
{
	public partial struct Meter : IUnit<Length>
	{
		public EnumUnit EnumeratedUnit
		{
			get { throw new NotImplementedException(); }
		}

		public string Symbol
		{
			get { return "m"; }
		}

		public IQuantity<Length> ReferencedQuantity
		{
			get { return Quantity.Length; }
		}
	}
}

