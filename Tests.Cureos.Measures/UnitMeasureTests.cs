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
    public class MeasureQUTests
    {
        #region Test Methods

        [Test]
        public void GetAmount_UsingIUnit_ValidConversion()
        {
            var expected = AmountConverter.ToAmountType(500.0);
            var instance = new SpecificMeasure<Length>(5.0, Units.Meter);
            var actual = instance.GetAmount(Units.CentiMeter);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
