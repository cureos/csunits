// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measurables.Units
{
    public sealed class Gram : GenericUnit
    {
        #region FIELDS

        public static readonly Gram Instance = new Gram();

        #endregion

        #region CONSTRUCTORS

        private Gram()
            : base("g", KiloGram.Instance, (AmountType)0.001)
        {
        }

        #endregion
    }
}