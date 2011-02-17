// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measurables;
using NUnit.Framework;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Tests.Cureos.Measurables
{
    internal static class AmountAssert
    {
        #region FIELDS

        private const double mkEqualityTolerance = 1.0e-6;

        #endregion

        #region METHODS

        internal static void AreEqual<U>(IMeasurable<U> iLhs, IMeasurable<U> iRhs) where U : IUnit
        {
            double delta =
                (double) Math.Abs((iRhs.Amount - iLhs.Amount)/Math.Max(Math.Abs(iLhs.Amount), Math.Abs(iRhs.Amount)));
            Assert.IsTrue(delta < mkEqualityTolerance);
        }

        #endregion
    }
}