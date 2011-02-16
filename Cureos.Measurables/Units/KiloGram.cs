// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measurables.Dimensions;

namespace Cureos.Measurables.Units
{
    public sealed class KiloGram : GenericUnit
    {
        #region FIELDS

        public static readonly KiloGram Instance;

        #endregion

        #region CONSTRUCTORS

        static KiloGram()
        {
            Instance = new KiloGram();
        }

        private KiloGram() : base(UnitPrefix.Kilo, "g", Mass.Dimension)
        {
            
        }

        #endregion
    }
}