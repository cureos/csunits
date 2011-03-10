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
        #region Test Methods

        [Test]
        public void GetAmount_UsingIUnit_ValidConversion()
        {
            var expected = AmountConverter.ToAmountType(500.0);
            var instance = new Measure<Length>(5.0, Length.Meter);
            var actual = instance.GetAmount(Length.CentiMeter);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DefaultConstructor_Apply_YieldsZeroAmountStandardUnit()
        {
            var expected = new Measure<Temperature>(0.0, Temperature.Kelvin);
            var actual = new Measure<Temperature>();
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }
        #endregion
    }
}
