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
    public class StandardMeasureTests
    {
        #region Test Methods

        [Test]
        public void Constructor_WithNonReferenceUnit_InitializesMeasureInReferenceUnit()
        {
            var expected = new Measure<Time>(180.0, Units.Second);
            var actual = new StandardMeasure<Time>(3.0, Units.Minute);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void DivisionOperator_DivideGenericSameQuantity_ReturnsScalar()
        {
            var expected = 1.0;
            var numerator = new StandardMeasure<Area>(500.0, Units.SquareCentiMeter);
            var denominator = new StandardMeasure<Area>(5.0, Units.SquareDeciMeter);
            var actual = (double)(numerator / denominator);
            Assert.AreEqual(expected, actual, 1.0e-6);
        }

        [Test]
        public void Times_MultiplyAreaAndLength_ReturnsVolume()
        {
            var expected = new StandardMeasure<Volume>(6.0);
            var lhs = new StandardMeasure<Area>(2.0);
            var rhs = new StandardMeasure<Length>(3.0);
            var actual = StandardMeasure<Volume>.Times(lhs, rhs);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Times_MultiplyAreaAndAreaToVolume_Throws()
        {
            var lhs = new StandardMeasure<Area>(2.0);
            var rhs = new StandardMeasure<Area>(3.0);
            var throws = StandardMeasure<Volume>.Times(lhs, rhs);
        }

        [Test]
        public void Divide_DivideVolumeAndLength_ReturnsArea()
        {
            var expected = new StandardMeasure<Area>(4.0);
            var numerator = new StandardMeasure<Volume>(8.0);
            var denominator = new StandardMeasure<Length>(200.0, Units.CentiMeter);
            var actual = StandardMeasure<Area>.Divide(numerator, denominator);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Divide_DivideAreaAndAreaToLength_Throws()
        {
            var numerator = new StandardMeasure<Area>(8.0);
            var denominator = new StandardMeasure<Area>(200.0, Units.SquareDeciMeter);
            var throws = StandardMeasure<Length>.Divide(numerator, denominator);
        }

        [Test]
        public void GetAmount_UsingIUnit_ValidConversion()
        {
            var expected = AmountConverter.ToAmountType(500.0);
            var instance = new StandardMeasure<Length>(5.0);
            var actual = instance.GetAmount(Units.CentiMeter);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
