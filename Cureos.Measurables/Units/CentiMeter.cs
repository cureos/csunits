// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measurables.Units
{
    public sealed class CentiMeter : GenericUnit
    {
        #region FIELDS

        public static readonly CentiMeter Instance = new CentiMeter();

        #endregion

        #region CONSTRUCTORS

        private CentiMeter()
            : base(UnitPrefix.Centi, "m", Meter.Instance)
        {
        }

        #endregion
    }
}