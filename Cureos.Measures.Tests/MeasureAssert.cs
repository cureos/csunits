/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

namespace Cureos.Measures
{
    using System;

    using NUnit.Framework;

#if SINGLE
    using AmountType = System.Single;
#elif DECIMAL
    using AmountType = System.Decimal;
#elif DOUBLE
    using AmountType = System.Double;
#endif

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
