// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measurables;
using Cureos.Measurables.Units;
using NUnit.Framework;

namespace Tests.Cureos.Measurables.Units
{
    [TestFixture]
    public class CelsiusTests
    {
        #region Fields

        private Measurable<Celsius> _instance;

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void Setup()
        {
            _instance = new Measurable<Celsius>(20.0);
        }

        [TearDown]
        public void Teardown()
        {
        }

        #endregion

        #region Unit tests

        [Test]
        public void InUnit_CelsiusToKelvin_AmountIncremented273()
        {
            var expected = new Measurable<Kelvin>(293.15);
            var actual = _instance.InUnit<Kelvin>();
            AmountAssert.AreEqual(expected, actual);
        }

        [Test]
        public void InUnit_KelvinToCelsius_AmountDecremented273()
        {
            var tempKelvin = new Measurable<Kelvin>(288.65);
            var expected = new Measurable<Celsius>(15.5);
            var actual = tempKelvin.InUnit<Celsius>();
            AmountAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}
