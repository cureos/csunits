// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measurables.Dimensions
{
    internal static class AbsorbedDose
    {
        #region FIELDS

        internal static readonly UnitDimension Dimension;

        #endregion

        #region CONSTRUCTORS

        static AbsorbedDose()
        {
            Dimension = new UnitDimension(2, 0, -2, 0, 0, 0, 0);
        }

        #endregion
    }
}