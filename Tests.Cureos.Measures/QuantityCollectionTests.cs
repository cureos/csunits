// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Linq;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class QuantityCollectionTests
    {
        #region Unit tests

        [Test]
        public void QuantitiesGetter_CheckContainsLuminance_ReturnsTrue()
        {
            var expected = true;
            var actual = QuantityCollection.Quantities.Any(qa => qa.Quantity.Equals(default(Luminance)));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QuantitiesGetter_CheckTimeItemContainsHourUnit_ReturnsTrue()
        {
            var expected = true;
            var actual = QuantityCollection.Quantities.Single(qa => qa.Quantity.Equals(default(Time))).Units.Contains(Time.Hour);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QuantitiesGetter_CheckLengthItemNotContainsMeterPerSecondUnit_ReturnsFalse()
        {
            var expected = false;
            var actual =
                QuantityCollection.Quantities.Single(qa => qa.Quantity.Equals(default(Length))).Units.Contains(
                    Velocity.MeterPerSecond);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
