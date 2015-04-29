// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Cureos.Measures
{
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
            _instance = new InUnitMeasure<Mass>(0.01, Mass.MetricTon);
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
