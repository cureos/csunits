// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures.Quantities;

namespace Cureos.Measures.Units
{
    public struct CentiMeter : IUnit<Length>
    {
        #region Implementation of IUnit<Length>

        public Unit EnumeratedUnit
        {
            get { return Unit.CentiMeter; }
        }

        #endregion

        public Length Quantity
        {
            get { return default(Length); }
        }
    }
}