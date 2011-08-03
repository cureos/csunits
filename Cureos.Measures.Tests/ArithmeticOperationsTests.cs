// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Cureos.Measures
{
    [TestFixture]
    public class ArithmeticOperationsTests
    {
        #region Unit tests

        [Test]
        public void Times_MultiplyAreaAndLength_ReturnsVolume()
        {
            var expected = new StandardMeasure<Volume>(6.0);
            var lhs = new StandardMeasure<Area>(2.0);
            var rhs = new StandardMeasure<Length>(3.0);
            StandardMeasure<Volume> actual; ArithmeticOperations.Times(lhs, rhs, out actual);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Times_MultiplyAreaAndAreaToVolume_Throws()
        {
            var lhs = new StandardMeasure<Area>(2.0);
            var rhs = new StandardMeasure<Area>(3.0);
            StandardMeasure<Volume> throws; ArithmeticOperations.Times(lhs, rhs, out throws);
        }

        [Test]
        public void Divide_DivideVolumeAndLength_ReturnsArea()
        {
            var expected = new StandardMeasure<Area>(4.0);
            var numerator = new StandardMeasure<Volume>(8.0);
            var denominator = new StandardMeasure<Length>(200.0, Length.CentiMeter);
            StandardMeasure<Area> actual; ArithmeticOperations.Divide(numerator, denominator, out actual);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Divide_DivideAreaAndAreaToLength_Throws()
        {
            var numerator = new StandardMeasure<Area>(8.0);
            var denominator = new StandardMeasure<Area>(200.0, Area.SquareDeciMeter);
            StandardMeasure<Length> throws; ArithmeticOperations.Divide(numerator, denominator, out throws);
        }

        [Test]
        public void Power_LengthRaisedWith3_ReturnsVolume()
        {
            var expected = new Measure<Volume>(1.0, Volume.CubicDeciMeter);
            var len = new Measure<Length>(1.0, Length.DeciMeter);
            StandardMeasure<Volume> actual; ArithmeticOperations.Power(len, 3, out actual);
            MeasureAssert.AmountsAreEqual(expected, actual);
        }

        #endregion
    }
}
