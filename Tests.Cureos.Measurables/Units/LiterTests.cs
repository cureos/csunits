// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measurables;
using Cureos.Measurables.Units;
using NUnit.Framework;

namespace Tests.Cureos.Measurables.Units
{
    [TestFixture]
    public class LiterTests
    {
        #region Unit tests

        [Test]
        public void Times_MultiplyCentiMeterAndSquareMeter_ReturnCorrectlyScaledAmount()
        {
            var length = new Measurable<CentiMeter>(15.0);
            var area = new Measurable<SquareMeter>(0.02);
            var expected = new Measurable<Liter>(3.0);
            var actual = length.Times<SquareMeter, Liter>(area);
            AmountAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}
