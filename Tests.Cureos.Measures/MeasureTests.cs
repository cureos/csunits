// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using NUnit.Framework;
using Cureos.Measures.Quantities;

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
        public void DivisionOperator_DivideNonGenericSameQuantity_ReturnsScalarAccountingForUnitConversion()
        {
            var expected = 1.0;
            var numerator = new Measure(500.0, Unit.SquareCentiMeter);
            var denominator = new Measure(5.0, Unit.SquareDeciMeter);
            var actual = (double)(numerator / denominator);
            Assert.AreEqual(expected, actual, 1.0e-7);
        }

        [Test]
        public void DivisionOperator_DivideNonGenericSameUnit_ReturnsScalar()
        {
            var expected = 1.0;
            var numerator = new Measure(5.0, Unit.SquareDeciMeter);
            var denominator = new Measure(5.0, Unit.SquareDeciMeter);
            var actual = (double)(numerator / denominator);
            Assert.AreEqual(expected, actual, 1.0e-7);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DivisionOperator_DivideNonGenericsToNonExistingResultingQuantity_Throws()
        {
           var numerator = new Measure(5.0, Unit.SquareDeciMeter);
            var denominator = new Measure(5.0, Unit.CubicDeciMeter);
            var throws = numerator / denominator;
        }

        #endregion
    }
}
