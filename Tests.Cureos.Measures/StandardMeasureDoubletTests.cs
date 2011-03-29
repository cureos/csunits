// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class StandardMeasureDoubletTests
    {
        #region Fields

        private StandardMeasureDoublet<Time, Power> _instance;

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void Setup()
        {
            _instance = new StandardMeasureDoublet<Time, Power>(5.0, 0.12);
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
            var expected = new StandardMeasureDoublet<Time, Power>(10.0, 0.24);
            var actual = _instance + _instance;
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void MinusOperator_SubtractInstanceWithItself_ReturnsZero()
        {
            var expected = new StandardMeasureDoublet<Time, Power>(0.0, 0.0);
            var actual = _instance - _instance;
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TimesOperator_MultiplyBy2And3_ReturnsDoubleTimeThreeTimesPower()
        {
            var expected = new StandardMeasureDoublet<Time, Power>(10.0, 0.36);
            var actual = _instance * new StandardMeasureDoublet<Number, Number>(2.0, 3.0);
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DivideOperator_DivideBy2And3_ReturnsHalfTimeOneThirdPower()
        {
            var expected = new StandardMeasureDoublet<Time, Power>(2.5, 0.04);
            var actual = _instance / new StandardMeasureDoublet<Number, Number>(2.0, 3.0);
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DivideOperator_DivideByItself_ReturnsUnityDoublet()
        {
            var expected = new StandardMeasureDoublet<Number, Number>(1.0, 1.0);
            var actual = _instance / _instance;
            IMeasureDoubletAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}
