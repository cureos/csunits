/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

namespace Cureos.Measures
{
    using System;

    using NUnit.Framework;

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
