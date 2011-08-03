// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using NUnit.Framework;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
    public static class MeasureAssert
    {
        private const AmountType smkEqualityTolerance = (AmountType)1.0e-7;

        internal static void MeasuresAreEqual(IMeasure expected, IMeasure actual)
        {
            if (actual.Unit.Equals(expected.Unit))
            {
                Assert.IsTrue(Math.Abs(actual.Amount - expected.Amount) < smkEqualityTolerance,
                              "Expected {0}, actual value {1}", expected, actual);
            }
            else
            {
                Assert.Fail("Expected measure {0} and actual measure {1} are of different units", expected, actual);
            }
        }

        internal static void AmountsAreEqual<Q1, Q2>(IMeasure<Q1> expected, IMeasure<Q2> actual)
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            if (typeof(Q1).Equals(typeof(Q2)))
            {
                Assert.IsTrue(
                    Math.Abs(actual.StandardAmount - expected.StandardAmount) <
                    smkEqualityTolerance,
                    "Expected {0}, actual value {1}", expected, actual);
            }
            else
            {
                Assert.Fail("Expected measure {0} and actual measure {1} are of different quantities", expected, actual);
            }
        }
    }
}
