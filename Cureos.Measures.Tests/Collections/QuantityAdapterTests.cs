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
    public class QuantityAdapterTests
    {
        #region Fields

        private QuantityAdapter _instance;

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void Setup()
        {
            _instance = new QuantityAdapter(default(Force), new[] { Force.Newton, Force.KiloNewton });
        }

        [TearDown]
        public void Teardown()
        {
            _instance = null;
        }

        #endregion

        #region Unit tests

        [Test]
        public void QuantityGetter_CompareWithQuantityUsedInConstructor_AreEqual()
        {
            var actual = _instance.Quantity;
            Assert.IsInstanceOf<Force>(actual);
        }

        [Test]
        public void UnitsGetter_CheckContainsKiloNewton_ReturnsTrue()
        {
            var expected = true;
            var actual = _instance.Units.Contains(Force.KiloNewton);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnitsGetter_CheckContainsKiloJoule_ReturnsFalse()
        {
            var expected = false;
            var actual = _instance.Units.Contains(Energy.KiloJoule);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
