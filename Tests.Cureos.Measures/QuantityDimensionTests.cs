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
    public class QuantityDimensionTests
    {
        #region Unit tests

        [Test]
        public void ToString_ContainingUnityValues_ExponentNotDisplayed()
        {
            var expected = "m^-2 s";
            var actual = ((QuantityDimension.Length ^ -2) * QuantityDimension.Time).ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_DimensionlessQuantity_ReturnsEmptyString()
        {
            var expected = String.Empty;
            var actual = QuantityDimension.Pi.ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Steradian_CompareToRadian_ShouldEqualSquareOfRadian()
        {
            var expected = QuantityDimension.Radian * QuantityDimension.Radian;
            var actual = QuantityDimension.Steradian;
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
