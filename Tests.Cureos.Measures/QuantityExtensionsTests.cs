// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class QuantityExtensionsTests
    {
        #region Unit tests

        [Test]
        public void GetSupportedUnits_QuantityLength_ContainsMeterAndMilliMeter()
        {
            var lengthUnits = Quantity.Length.GetSupportedUnits();
            CollectionAssert.Contains(lengthUnits, Unit.Meter);
            CollectionAssert.Contains(lengthUnits, Unit.MilliMeter);
        }

        [Test]
        public void GetSupportedUnits_QuantityArea_DoesNotContainCentiMeter()
        {
            var areaUnits = Quantity.Area.GetSupportedUnits();
            CollectionAssert.DoesNotContain(areaUnits, Unit.CentiMeter);
        }

        [Test]
        public void IsUnitSupported_GramOfMass_ReturnsTrue()
        {
            var expected = true;
            var actual = Quantity.Mass.IsUnitSupported(Unit.Gram);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IsUnitSupported_GrayOfMass_ReturnsFalse()
        {
            var expected = false;
            var actual = Quantity.Mass.IsUnitSupported(Unit.Gray);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
