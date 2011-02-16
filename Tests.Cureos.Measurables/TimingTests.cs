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
            
            Assert.Pass("Sum: {0}, timing {1} ms", val, (stop.Ticks - start.Ticks) / 10000);
        }

        [Test]
        public void TimeMeasurableAdditions()
        {
            DateTime start = DateTime.Now;
            var val = (Measurable<KiloGram>)0.0;
            for (int i = 0; i < no; ++i)
            {
                val += (Measurable<KiloGram>)i;
            }
            DateTime stop = DateTime.Now;

            Assert.Pass("Sum: {0}, timing {1} ms", val, (stop.Ticks - start.Ticks) / 10000);
        }
    }
}