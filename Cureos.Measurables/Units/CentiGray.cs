// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measurables.Units
{
    public sealed class CentiGray : GenericUnit
    {
        #region FIELDS

        public static readonly CentiGray Instance = new CentiGray();

        #endregion

        #region CONSTRUCTORS

        private CentiGray()
            : base(UnitPrefix.Centi, "Gy", Gray.Instance)
        {
        }

        #endregion
    }
}