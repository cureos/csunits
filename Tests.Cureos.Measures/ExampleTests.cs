// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class ExampleTests
    {
        [Test]
        public void Example1()
        {
            Measure<Mass> initialWgt = new Measure<Mass>(75.0);
            Measure<Mass> gainedWgt = new Measure<Mass>(2.5, EnumUnit.HectoGram);
            Measure<Mass> newWgt = initialWgt + gainedWgt;

            Measure newWgtInGram = newWgt[EnumUnit.Gram];
            Measure initialWgtInGram = newWgtInGram - gainedWgt;

            Console.WriteLine("Initial weight: {0}", initialWgtInGram);

            Measure<Length> height = new Measure<Length>(30.0, EnumUnit.CentiMeter);
            Measure<Area> area = (Measure<Area>)0.02;

            var vol = Measure<Volume>.Times(height, area);
            var maxVol = new Measure<Volume>(10.0, EnumUnit.Liter);
            if (vol < maxVol)
            {
                Console.WriteLine("Calculated volume is within limits, actual volume: {0}", vol[EnumUnit.Liter]);
            }
#if NUNIT24
			Assert.Ignore();
#else
            Assert.Pass();
#endif
        }
    }
}