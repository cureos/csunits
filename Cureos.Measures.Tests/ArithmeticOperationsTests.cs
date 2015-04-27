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
            var expected = new Measure<Volume>(6.0);
            var lhs = new Measure<Area>(2.0);
            var rhs = new Measure<Length>(3.0);
            Measure<Volume> actual; ArithmeticOperations.Times(lhs, rhs, out actual);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Times_MultiplyAreaAndAreaToVolume_Throws()
        {
            var lhs = new Measure<Area>(2.0);
            var rhs = new Measure<Area>(3.0);
            Measure<Volume> throws; ArithmeticOperations.Times(lhs, rhs, out throws);
        }

        [Test]
        public void Divide_DivideVolumeAndLength_ReturnsArea()
        {
            var expected = new Measure<Area>(4.0);
            var numerator = new Measure<Volume>(8.0);
            var denominator = new Measure<Length>(200.0, Length.CentiMeter);
            Measure<Area> actual; ArithmeticOperations.Divide(numerator, denominator, out actual);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Divide_DivideAreaAndAreaToLength_Throws()
        {
            var numerator = new Measure<Area>(8.0);
            var denominator = new Measure<Area>(200.0, Area.SquareDeciMeter);
            Measure<Length> throws; ArithmeticOperations.Divide(numerator, denominator, out throws);
        }

        [Test]
        public void Power_LengthRaisedWith3_ReturnsVolume()
        {
            var expected = new UnitPreservingMeasure<Volume>(1.0, Volume.CubicDeciMeter);
            var len = new UnitPreservingMeasure<Length>(1.0, Length.DeciMeter);
            Measure<Volume> actual; ArithmeticOperations.Power(len, 3, out actual);
            MeasureAssert.AmountsAreEqual(expected, actual);
        }

        #endregion
    }
}
