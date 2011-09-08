// Copyright (c) 2010-2011 Anders Gustafsson, Cureos AB.
// All rights reserved. Any unauthorised reproduction of this 
// material will constitute an infringement of copyright.

using System;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Cureos.Measures.Linq
{
    [TestFixture]
    public class ConversionsTests
    {
        #region Unit tests

        [Test]
        public void To_DecimalAndLengthUnit_ReturnsMeasureInSpecifiedAmountAndUnit()
        {
            var expected = new Measure<Length>(3.0m, Length.MilliMeter);
            var actual = 3.0m.To(Length.MilliMeter);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void From_FloatAndVolumeUnit_ReturnsStandardVolumeMeasure()
        {
            var expected = new Measure<Volume>(0.002f, Volume.CubicMeter);
            var actual = 2.0f.From(Volume.Liter);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        #endregion
    }
}
