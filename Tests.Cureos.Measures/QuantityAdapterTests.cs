// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System.Linq;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
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
            var expected = default(Force);
            var actual = _instance.Quantity;
            Assert.AreEqual(expected, actual);
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
