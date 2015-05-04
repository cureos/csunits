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
    public class MeasureDoubletTests
    {
        #region Fields

        private MeasureDoublet<Time, Power> _instance;

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void Setup()
        {
            _instance = new MeasureDoublet<Time, Power>(5.0, 0.12);
        }

        [TearDown]
        public void Teardown()
        {
        }

        #endregion

        #region Unit tests

        [Test]
        public void PlusOperator_AddInstanceWithItself_ReturnsDoubleInstance()
        {
            var expected = new MeasureDoublet<Time, Power>(10.0, 0.24);
            var actual = _instance + _instance;
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void MinusOperator_SubtractInstanceWithItself_ReturnsZero()
        {
            var expected = new MeasureDoublet<Time, Power>(0.0, 0.0);
            var actual = _instance - _instance;
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TimesOperator_MultiplyBy2And3_ReturnsDoubleTimeThreeTimesPower()
        {
            var expected = new MeasureDoublet<Time, Power>(10.0, 0.36);
            var actual = _instance * new MeasureDoublet<Number, Number>(2.0, 3.0);
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DivideOperator_DivideBy2And3_ReturnsHalfTimeOneThirdPower()
        {
            var expected = new MeasureDoublet<Time, Power>(2.5, 0.04);
            var actual = _instance / new MeasureDoublet<Number, Number>(2.0, 3.0);
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DivideOperator_DivideByItself_ReturnsUnityDoublet()
        {
            var expected = new MeasureDoublet<Number, Number>(1.0, 1.0);
            var actual = _instance / _instance;
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}
