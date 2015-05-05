/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

namespace Cureos.Measures
{
    using System;
    using System.Diagnostics;

    using Cureos.Measures.Quantities;

    using NUnit.Framework;

    [TestFixture]
    [Category("Timing")]
    public class TimingTests
    {
        private const double no = 1000000;

        [Test]
        public void TimeEmptyLoop()
        {
            PerformTiming(
                () =>
                    {
                        const double val = 0.0;
                        for (var i = 0.0; i < no; ++i)
                        {
                        }
                        return val;
                    },
                0.0);
        }

        [Test]
        public void TimeDoubleAdditions()
        {
            PerformTiming(
                () =>
                    {
                        double val = 0.0;
                        for (var i = 0.0; i < no; ++i)
                        {
                            val += i;
                        }
                        return val;
                    },
                0.0);
        }

        [Test]
        public void TimeMeasureAdditionsStandardUnitWithStandardMeasure()
        {
            PerformTiming(
                () =>
                    {
                        var val = new Measure<Mass>(0.0, Mass.KiloGram);
                        for (var i = 0.0; i < no; ++i)
                        {
                            val += new Mass(i);
                        }
                        return val;
                    },
                0.5 * no * (no - 1.0));
        }

        [Test]
        public void TimeMeasureAdditionsWithDifferentUnit()
        {
            PerformTiming(
                () =>
                    {
                        var val = new Measure<Mass>(0.0, Mass.KiloGram);
                        for (var i = 0.0; i < no; ++i)
                        {
                            val += new Measure<Mass>(i, Mass.Gram);
                        }
                        return val;
                    },
                0.5 * no * (no - 1.0) / 1000.0);
        }

        [Test]
        public void TimeStandardMeasureAdditions()
        {
            PerformTiming(
                () =>
                    {
                        var val = new Length(0.0);
                        for (var i = 0.0; i < no; ++i)
                        {
                            val += new Length(i);
                        }
                        return val;
                    },
                0.5 * no * (no - 1.0));
        }

        [Test]
        public void TimeMeasureAdditionsNonStandardUnitWithStandardMeasure()
        {
            PerformTiming(
                () =>
                    {
                        var val = new Measure<Length>(0.0, Length.CentiMeter);
                        for (var i = 0.0; i < no; ++i)
                        {
                            val += new Length(i);
                        }
                        return val;
                    },
                0.5 * no * (no - 1.0) * 100.0);
        }

        private static void PerformTiming(Func<object> a, double expected)
        {
            var timer = new Stopwatch();
            timer.Restart();
            var val = a.Invoke();
            timer.Stop();

            var measure = val as IMeasure;
            if (measure != null)
            {
                Assert.AreEqual(expected, measure.Amount, 1.0e-7);
            }

#if NUNIT24
            Assert.Ignore
#else
            Assert.Pass
#endif
                ("Sum: {0}, timing {1} ms", val, timer.ElapsedMilliseconds);
        }
    }
}