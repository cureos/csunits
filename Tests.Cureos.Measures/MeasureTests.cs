// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class MeasureTests
    {
        #region Unit tests

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlusOperator_AddDifferentQuantities_Throws()
        {
            var lhs = new Measure(1.0, Unit.Minute);
            var rhs = new Measure(2.0, Unit.Meter);
            var throws = lhs + rhs;
        }

        [Test]
        public void PlusOperator_AddDifferentUnits_ReturnsAmountInLhsUnit()
        {
            var expected = new Measure(5.05, Unit.Meter);
            var lhs = new Measure(5.0, Unit.Meter);
            var rhs = new Measure(5.0, Unit.CentiMeter);
            var actual = lhs + rhs;
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void PlusOperator_AddNonGenericAndGeneric_ReturnsAmountInNonGenericUnit()
        {
            var expected = new Measure(5005.0, Unit.Gram);
            var lhs = new Measure(5.0, Unit.Gram);
            var rhs = new Measure<Mass>(5.0);
            var actual = lhs + rhs;
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void PlusOperator_AddGenericAndNonGeneric_ReturnsAmountInReferenceUnit()
        {
            var expected = new Measure(5400.0, Unit.Second);
            var lhs = new Measure<Time>(1.0, Unit.Hour);
            var rhs = new Measure(0.5, Unit.Hour);
            var actual = lhs + rhs;
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void LessThanOperator_CompareEquivalentMeasuresDifferentUnits_ReturnsFalse()
        {
            var expected = false;
            var lhs = new Measure(293.15, Unit.Kelvin);
            var rhs = new Measure(20.0, Unit.Celsius);
            var actual = lhs < rhs;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LessThanEqualToOperator_CompareEquivalentMeasuresDifferentUnits_ReturnsTrue()
        {
            var expected = true;
            var lhs = new Measure(293.15, Unit.Kelvin);
            var rhs = new Measure(20.0, Unit.Celsius);
            var actual = lhs <= rhs;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GreaterThanOperator_CompareEquivalentMeasuresDifferentUnits_ReturnsFalse()
        {
            var expected = false;
            var lhs = new Measure(293.15, Unit.Kelvin);
            var rhs = new Measure(20.0, Unit.Celsius);
            var actual = lhs > rhs;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GreaterThanEqualToOperator_CompareEquivalentMeasuresDifferentUnits_ReturnsTrue()
        {
            var expected = true;
            var lhs = new Measure(293.15, Unit.Kelvin);
            var rhs = new Measure(20.0, Unit.Celsius);
            var actual = lhs >= rhs;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EqualToOperator_CompareEquivalentMeasuresDifferentUnits_ReturnsTrue()
        {
            var expected = true;
            var lhs = new Measure(293.15, Unit.Kelvin);
            var rhs = new Measure(20.0, Unit.Celsius);
            var actual = lhs == rhs;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NotEqualToOperator_CompareEquivalentMeasuresDifferentUnits_ReturnsFalse()
        {
            var expected = false;
            var lhs = new Measure(293.15, Unit.Kelvin);
            var rhs = new Measure(20.0, Unit.Celsius);
            var actual = lhs != rhs;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LessThanOperator_CompareDifferentQuantities_Throws()
        {
            var lhs = new Measure(1.0, Unit.CubicCentiMeter);
            var rhs = new Measure(1.0, Unit.SquareCentiMeter);
            var throws = lhs < rhs;
        }

        [Test]
        public void LessThanOperator_CompareGenericSmallWithNonGenericLarge_ReturnsTrue()
        {
            var expected = true;
            var lhs = new Measure<Volume>(1e-6);
            var rhs = new Measure(1.0, Unit.Liter);
            var actual = lhs < rhs;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LessThanOperator_CompareNonGenericLargeWithGenericSmall_ReturnsFalse()
        {
            var expected = false;
            var lhs = new Measure(1.0, Unit.CubicDeciMeter);
            var rhs = new Measure<Volume>(1e-6);
            var actual = lhs < rhs;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TimesOperator_MultiplyScalarAndMeasure_ReturnsProductWithSameUnit()
        {
            var expected = new Measure(25.0, Unit.CentiGray);
            var actual = AmountConverter.ToAmountType(5.0) * new Measure(5.0, Unit.CentiGray);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void TimesOperator_MultiplyMeasureAndScalar_ReturnsProductWithSameUnit()
        {
            var expected = new Measure(25.0, Unit.CentiGray);
            var actual = new Measure(5.0, Unit.CentiGray) * AmountConverter.ToAmountType(5.0);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void DivisionOperator_DivideVolumeAndLength_ReturnsArea()
        {
            var expected = new Measure(0.1, Unit.SquareMeter);
            var numerator = new Measure(1.0, Unit.Liter);
            var denominator = new Measure(1.0, Unit.CentiMeter);
            var actual = numerator / denominator;
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void DivisionOperator_DivideVolumeAndGenericLengthMeasure_ReturnsNonGenericArea()
        {
            var expected = new Measure(0.1, Unit.SquareMeter);
            var numerator = new Measure(1.0, Unit.Liter);
            var denominator = new Measure<Length>(1.0, Unit.CentiMeter);
            var actual = numerator / denominator;
#if NUNIT24
            Assert.IsInstanceOfType(typeof(Measure), actual);
#else
            Assert.IsInstanceOf(typeof(Measure), actual);
#endif
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void DivisionOperator_DivideGenericVolumeAndLength_ReturnsNonGenericArea()
        {
            var expected = new Measure(0.1, Unit.SquareMeter);
            var numerator = new Measure<Volume>(1.0, Unit.Liter);
            var denominator = new Measure(1.0, Unit.CentiMeter);
            var actual = numerator / denominator;
#if NUNIT24
            Assert.IsInstanceOfType(typeof(Measure), actual);
#else
            Assert.IsInstanceOf(typeof(Measure), actual);
#endif
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DivisionOperator_DivideLengthAndVolumeWhenNoInverseAreaQuantityExists_Throws()
        {
            var numerator = new Measure(1.0, Unit.Meter);
            var denominator = new Measure(1.0, Unit.CubicMeter);
            var throws = numerator / denominator;
        }

        [Test, Explicit]
        public void DivisionOperator_DivideVolumeAndZeroLength_ReturnsInfinityAmount()
        {
            var expected = AmountConverter.ToAmountType(Double.PositiveInfinity);
            var numerator = new Measure(1.0, Unit.CubicMeter);
            var denominator = new Measure(0.0, Unit.Meter);
            var actual = (numerator / denominator).Amount;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultiplicationOperator_MultiplyAreaAndLength_ReturnsVolume()
        {
            var expected = new Measure(0.006, Unit.CubicMeter);
            var lhs = new Measure(2.0, Unit.DeciMeter);
            var rhs = new Measure(3.0, Unit.SquareDeciMeter);
            var actual = lhs * rhs;
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }
        #endregion
    }
    [TestFixture]
    public class MeasureQTests
    {
        #region Test Methods

        [Test]
        public void Constructor_WithNonReferenceUnit_InitializesMeasureInReferenceUnit()
        {
            var expected = new Measure(180.0, Unit.Second);
            var actual = new Measure<Time>(3.0, Unit.Minute);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Constructor_WithUnitOfDifferentQuantity_Throws()
        {
            var throws = new Measure<AbsorbedDose>(1.0, Unit.Minute);
        }

        [Test]
        public void DivisionOperator_DivideGenericSameQuantity_ReturnsScalar()
        {
            var expected = 1.0;
            var numerator = new Measure<Area>(500.0, Unit.SquareCentiMeter);
            var denominator = new Measure<Area>(5.0, Unit.SquareDeciMeter);
            var actual = (double)(numerator / denominator);
            Assert.AreEqual(expected, actual, 1.0e-7);
        }

        [Test]
        public void Times_MultiplyAreaAndLength_ReturnsVolume()
        {
            var expected = new Measure<Volume>(6.0);
            var lhs = new Measure<Area>(2.0);
            var rhs = new Measure<Length>(3.0);
            var actual = Measure<Volume>.Times(lhs, rhs);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Times_MultiplyAreaAndAreaToVolume_Throws()
        {
            var lhs = new Measure<Area>(2.0);
            var rhs = new Measure<Area>(3.0);
            var throws = Measure<Volume>.Times(lhs, rhs);
        }

        [Test]
        public void Divide_DivideVolumeAndLength_ReturnsArea()
        {
            var expected = new Measure<Area>(4.0);
            var numerator = new Measure<Volume>(8.0);
            var denominator = new Measure<Length>(200.0, Unit.CentiMeter);
            var actual = Measure<Area>.Divide(numerator, denominator);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Divide_DivideAreaAndAreaToLength_Throws()
        {
            var numerator = new Measure<Area>(8.0);
            var denominator = new Measure<Area>(200.0, Unit.SquareDeciMeter);
            var throws = Measure<Length>.Divide(numerator, denominator);
        }

        #endregion
    }
}
