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
            var expected = new Measure<Time>(180.0, Time.Second);
            var actual = new StandardMeasure<Time>(3.0, Time.Minute);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void DivisionOperator_DivideGenericSameQuantity_ReturnsScalar()
        {
            var expected = 1.0;
            var numerator = new StandardMeasure<Area>(500.0, Area.SquareCentiMeter);
            var denominator = new StandardMeasure<Area>(5.0, Area.SquareDeciMeter);
            var actual = (double)(numerator / denominator);
            Assert.AreEqual(expected, actual, 1.0e-6);
        }

        [Test]
        public void GetAmount_UsingIUnit_ValidConversion()
        {
            var expected = AmountConverter.ToAmountType(500.0);
            var instance = new StandardMeasure<Length>(5.0);
            var actual = instance.GetAmount(Length.CentiMeter);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
