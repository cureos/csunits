using System;
using Cureos.Measurables.Double;
using Cureos.Measurables.Double.Units;
using NUnit.Framework;

namespace Tests.Cureos.Measurables.Double
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

        #endregion
    }
}
