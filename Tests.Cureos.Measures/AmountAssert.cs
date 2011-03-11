// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using NUnit.Framework;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Tests.Cureos.Measures
{
    public static class AmountAssert
    {
        public static void AreEqual(AmountType expected, AmountType actual)
        {
            Assert.AreEqual(0, AmountComparer.Instance.Compare(expected, actual));
        }
    }
}