// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Units
{
    public sealed class SquareMeter : GenericUnit
    {
        #region FIELDS

        public static readonly SquareMeter Instance = new SquareMeter();

        #endregion

        #region CONSTRUCTORS

        private SquareMeter()
            : base("m²", Area.Dimension)
        {
        }

        #endregion
    }
}