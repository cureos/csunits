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
    public class SquareMeterTests
    {
        #region Unit tests

        [Test]
        public void DivisionOperator_DivideVolumeAndLength_YieldsArea()
        {
            var volume = new Measurable<Liter>(4.0);
            var height = new Measurable<MilliMeter>(2.0);
            var expected = new Measurable<SquareMeter>(2.0);
            Measurable<SquareMeter> actual;
            Measurable.Divide(volume, height, out actual);
            AmountAssert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DivisionOperator_DivideVolumeAndAreaToYieldArea_Throws()
        {
            var volume = new Measurable<Liter>(4.0);
            var area = new Measurable<SquareMeter>(2.0);
            Measurable<SquareMeter> result;
            Measurable.Divide(volume, area, out result);
        }

        #endregion
    }
}
