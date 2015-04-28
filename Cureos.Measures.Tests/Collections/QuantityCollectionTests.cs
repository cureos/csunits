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

namespace Cureos.Measures.Collections
{
    using System.Linq;

    using Cureos.Measures.Quantities;

    using NUnit.Framework;

    [TestFixture]
    public class QuantityCollectionTests
    {
        #region Unit tests

        [Test]
        public void QuantitiesGetter_CheckContainsLuminance_ReturnsTrue()
        {
            var expected = true;
            var actual = QuantityCollection.Quantities.Any(qa => qa.Quantity is Luminance);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QuantitiesGetter_CheckTimeItemContainsHourUnit_ReturnsTrue()
        {
            var expected = true;
            var actual = QuantityCollection.Quantities.Single(qa => qa.Quantity is Time).Units.Contains(Time.Hour);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void QuantitiesGetter_CheckLengthItemNotContainsMeterPerSecondUnit_ReturnsFalse()
        {
            var expected = false;
            var actual =
                QuantityCollection.Quantities.Single(qa => qa.Quantity is Length).Units.Contains(
                    Velocity.MeterPerSecond);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DisplayName_OfUnit_EqualsFieldNamePlusSymbol()
        {
            var dummy = QuantityCollection.Quantities;
            var expected = "Hectare | ha";
            var actual = Area.Hectare.DisplayName;
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
        #endregion
    }
}
