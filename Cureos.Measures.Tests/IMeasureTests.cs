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
    using Cureos.Measures.Quantities;

    using NUnit.Framework;

    [TestFixture]
    public class IMeasureTests
    {
        #region Fields

        private IMeasure _instance;

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void Setup()
        {
            _instance = new Measure<Mass>(0.01, Mass.MetricTon);
        }

        [TearDown]
        public void Teardown()
        {
            _instance = null;
        }

        #endregion

        #region Unit tests

        [Test]
        public void UnitGetter_ValidateReturnType_SupportsNonGeneric()
        {
            var expected = typeof (IUnit);
            var actual = _instance.Unit;
            Assert.IsInstanceOf(expected, actual);
        }

        [Test]
        public void UnitGetter_ValidateReturnType_EqualsInstantiationUnit()
        {
            var expected = Mass.MetricTon;
            var actual = _instance.Unit;
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
