// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Cureos.Measures
{
    [TestFixture]
    public class StandardMeasureTests
    {
        #region Test Methods

        [Test]
        public void Constructor_WithNonReferenceUnit_InitializesMeasureInReferenceUnit()
        {
            var expected = new UnitPreservingMeasure<Time>(180.0, Time.Second);
            var actual = new Measure<Time>(3.0, Time.Minute);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void DivisionOperator_DivideGenericSameQuantity_ReturnsScalar()
        {
            var expected = 1.0;
            var numerator = new Measure<Area>(500.0, Area.SquareCentiMeter);
            var denominator = new Measure<Area>(5.0, Area.SquareDeciMeter);
            var actual = (double)(numerator / denominator);
            Assert.AreEqual(expected, actual, 1.0e-6);
        }

        [Test]
        public void GetAmount_UsingIUnit_ValidConversion()
        {
            var expected = AmountConverter.ToAmountType(500.0);
            var instance = new Measure<Length>(5.0);
            var actual = instance.GetAmount(Length.CentiMeter);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_BothArgumentsHaveValuesValuesWithinTolerance_ReturnsTrue()
        {
            Measure<AmountConcentration>? lhs = new Measure<AmountConcentration>(5.0);
            Measure<AmountConcentration>? rhs = new Measure<AmountConcentration>(5.0001);
            Measure<AmountConcentration> tol = new Measure<AmountConcentration>(0.001);

            var expected = true;
            var actual = Measure.AreEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_BothArgumentsHaveValuesValuesNotWithinTolerance_ReturnsFalse()
        {
            Measure<AmountConcentration>? lhs = new Measure<AmountConcentration>(5.0);
            Measure<AmountConcentration>? rhs = new Measure<AmountConcentration>(5.001);
            Measure<AmountConcentration> tol = new Measure<AmountConcentration>(0.0001);

            var expected = false;
            var actual = Measure.AreEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_LhsArgumentHasValue_ReturnsFalse()
        {
            Measure<AmountConcentration>? lhs = new Measure<AmountConcentration>(5.0);
            Measure<AmountConcentration>? rhs = null;
            Measure<AmountConcentration> tol = Measure<AmountConcentration>.Zero;

            var expected = false;
            var actual = Measure.AreEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_RhsArgumentHasValue_ReturnsFalse()
        {
            Measure<AmountConcentration>? lhs = null;
            Measure<AmountConcentration>? rhs = new Measure<AmountConcentration>(5.0);
            Measure<AmountConcentration> tol = Measure<AmountConcentration>.Zero;

            var expected = false;
            var actual = Measure.AreEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AreEqual_NoArgumentHasValue_ReturnsFalse()
        {
            Measure<AmountConcentration>? lhs = null;
            Measure<AmountConcentration>? rhs = null;
            Measure<AmountConcentration> tol = Measure<AmountConcentration>.Zero;

            var expected = false;
            var actual = Measure.AreEqual(lhs, rhs, tol);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
