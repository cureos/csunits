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
        public void ConvertTo_KiloGramToGram_Amount1000TimesGreater()
        {
            var expected = 1000.0 * _instance.Amount;
            var actual = _instance.ConvertTo<Gram>().Amount;
            Assert.AreEqual(expected, actual, AmountHelper.EqualityTolerance);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConvertTo_KiloGramToMeter_Throws()
        {
            var throws = _instance.ConvertTo<Meter>();
        }

        #endregion
    }
}
