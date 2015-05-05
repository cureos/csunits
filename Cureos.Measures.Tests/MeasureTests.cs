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

    using Cureos.Measures.Quantities;

    using NUnit.Framework;

    [TestFixture]
    public class MeasureTests
    {
        #region Test Methods

        [Test]
        public void Constructor_WithNonReferenceUnit_InitializesMeasureInReferenceUnit()
        {
            var expected = new Measure<Time>(180.0, Time.Second);
            var actual = new Time(3.0, Time.Minute);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void DivisionOperator_DivideGenericSameQuantity_ReturnsScalar()
        {
            var expected = 1.0;
            var numerator = new Area(500.0, Area.SquareCentiMeter);
            var denominator = new Area(5.0, Area.SquareDeciMeter);
            var actual = (double)(numerator / denominator);
            Assert.AreEqual(expected, actual, 1.0e-6);
        }

        [Test]
        public void GetAmount_UsingIUnit_ValidConversion()
        {
            var expected = AmountConverter.ToAmountType(500.0);
            var instance = new Length(5.0);
            var actual = instance.GetAmount(Length.CentiMeter);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_BothArgumentsHaveValuesValuesWithinTolerance_ReturnsTrue()
        {
            AmountConcentration? lhs = new AmountConcentration(5.0);
            AmountConcentration? rhs = new AmountConcentration(5.0001);
            AmountConcentration tol = new AmountConcentration(0.001);

            var expected = true;
            var actual = AreApproximatelyEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_BothArgumentsHaveValuesValuesNotWithinTolerance_ReturnsFalse()
        {
            AmountConcentration? lhs = new AmountConcentration(5.0);
            AmountConcentration? rhs = new AmountConcentration(5.001);
            AmountConcentration tol = new AmountConcentration(0.0001);

            var expected = false;
            var actual = AreApproximatelyEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_LhsArgumentHasValue_ReturnsFalse()
        {
            AmountConcentration? lhs = new AmountConcentration(5.0);
            AmountConcentration? rhs = null;
            AmountConcentration tol = AmountConcentration.Zero;

            var expected = false;
            var actual = AreApproximatelyEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_RhsArgumentHasValue_ReturnsFalse()
        {
            AmountConcentration? lhs = null;
            AmountConcentration? rhs = new AmountConcentration(5.0);
            AmountConcentration tol = AmountConcentration.Zero;

            var expected = false;
            var actual = AreApproximatelyEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_NoArgumentHasValue_ReturnsFalse()
        {
            AmountConcentration? lhs = null;
            AmountConcentration? rhs = null;
            AmountConcentration tol = AmountConcentration.Zero;

            var expected = false;
            var actual = AreApproximatelyEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Private support methods

        private static bool AreApproximatelyEqual<Q>(Q? lhs, Q? rhs, Q tol) where Q : struct, IQuantity<Q>, IMeasure<Q>
        {
            return lhs.HasValue && rhs.HasValue && Math.Abs(lhs.Value.Amount - rhs.Value.Amount) < tol.Amount;
        }

        #endregion
    }
}
