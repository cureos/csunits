using System;
using NUnit.Framework;

namespace Tests.Cureos.Measurables
{
    [TestFixture]
    public class TimingTests
    {
        private const int no = 1000000;

        [Test]
        public void TimeDoubleAdditions()
        {
            DateTime start = DateTime.Now;
            double val = 0.0;
            for (int i = 0; i < no; ++i)
            {
                val += (double) i;
            }
            DateTime stop = DateTime.Now;
            
            Assert.Inconclusive("Sum: {0}, timing {1} ms", val, stop.Ticks - start.Ticks);
        }
    }
}