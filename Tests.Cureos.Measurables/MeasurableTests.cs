// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measurables;
using Cureos.Measurables.Units;
using NUnit.Framework;

namespace Tests.Cureos.Measurables
{
    [TestFixture]
    public class MeasurableTests
    {
        #region Fields

        private Measurable<KiloGram> _instance;

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void Setup()
        {
            _instance = new Measurable<KiloGram>(3.5);
        }

        [TearDown]
        public void Teardown()
        {
        }

        #endregion

        #region Unit tests

        [Test]
        public void ToString_OfMeasurableInstance_UnitSymbolIncluded()
        {
            const string expected = "3.5 kg";
            var actual = _instance.ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InUnit_KiloGramToGram_Amount1000TimesGreater()
        {
            var expected = new Measurable<Gram>(3500.0);
            var actual = _instance.InUnit<Gram>();
            AmountAssert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InUnit_KiloGramToMeter_Throws()
        {
            var throws = _instance.InUnit<Meter>();
        }

        #endregion
    }
}
