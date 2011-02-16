using System;
using Cureos.Measurables;
using Cureos.Measurables.Units;
using NUnit.Framework;

namespace Tests.Cureos.Measurables.Units
{
    [TestFixture]
    public class LiterTests
    {
        #region Unit tests

        [Test]
        public void Times_MultiplyCentiMeterAndSquareMeter_ReturnCorrectlyScaledAmount()
        {
            var length = new Measurable<CentiMeter>(15.0);
            var area = new Measurable<SquareMeter>(0.02);
            var expected = 3.0;
            var actual = length.Times<SquareMeter, Liter>(area).Amount;
            Assert.AreEqual(expected, actual, AmountHelper.EqualityTolerance);
        }

        #endregion
    }
}
