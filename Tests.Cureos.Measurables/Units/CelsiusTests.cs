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
            var expected = 293.15;
            var actual = _instance.InUnit<Kelvin>().Amount;
            Assert.AreEqual(expected, actual, AmountHelper.EqualityTolerance);
        }

        [Test]
        public void InUnit_KelvinToCelsius_AmountDecremented273()
        {
            var tempKelvin = new Measurable<Kelvin>(288.65);
            var expected = 15.5;
            var actual = tempKelvin.InUnit<Celsius>().Amount;
            Assert.AreEqual(expected, actual, AmountHelper.EqualityTolerance);
        }

        #endregion
    }
}
