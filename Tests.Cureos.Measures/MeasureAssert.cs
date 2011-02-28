// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cureos.Measures;
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
    public static class MeasureAssert
    {
        private const AmountType smkEqualityTolerance = (AmountType)1.0e-7;

        internal static void MeasuresAreEqual(IMeasure expected, IMeasure actual)
        {
            if (actual.MeasuredUnit == expected.MeasuredUnit)
            {
                Assert.IsTrue(Math.Abs(actual.MeasuredAmount - expected.MeasuredAmount) < smkEqualityTolerance,
                    "Expected {0}, actual value {1}", expected, actual);
            }
            else
            {
                Assert.Fail("Expected measure {0} and actual measure {1} are of different units", expected, actual);
            }
        }

        internal static void AmountsAreEqual(IMeasure expected, IMeasure actual)
        {
            if (actual.MeasuredUnit == expected.MeasuredUnit)
            {
                Assert.IsTrue(Math.Abs(actual.MeasuredAmount - expected.MeasuredAmount) < smkEqualityTolerance,
                    "Expected {0}, actual value {1}", expected, actual);
            }
            else if (actual.MeasuredQuantity == expected.MeasuredQuantity)
            {
                Assert.IsTrue(Math.Abs(actual.ReferenceUnitAmount - expected.ReferenceUnitAmount) < smkEqualityTolerance,
                    "Expected {0}, actual value {1}", expected, actual);
            }
            else
            {
                Assert.Fail("Expected measure {0} and actual measure {1} are of different quantities", expected, actual);
            }
        }
    }
}
