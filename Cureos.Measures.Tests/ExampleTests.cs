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

    using Cureos.Measures.Quantities;

    using NUnit.Framework;

    [TestFixture]
    public class ExampleTests
    {
        [Test]
        public void Example1()
        {
            Mass initialWgt = new Mass(75.0);
            Mass gainedWgt = new Mass(2.5, Mass.HectoGram);
            Mass newWgt = initialWgt + gainedWgt;

            Measure<Mass> newWgtInGram = newWgt[Mass.Gram];
            Measure<Mass> initialWgtInGram = newWgtInGram - gainedWgt;

            Console.WriteLine("Initial weight: {0}", initialWgtInGram);

            Length height = 30.0 * Length.CentiMeter;
            Area area = (Area)0.02;

            Volume vol = height * area;
            var maxVol = new Volume(10.0, Volume.Liter);

            if (vol < maxVol)
            {
                Console.WriteLine("Calculated volume is within limits, actual volume: {0}", vol[Volume.Liter]);
            }

#if NUNIT24
            Assert.Ignore();
#else
            Assert.Pass();
#endif
        }

        [Test]
        public void ExtendedExample()
        {
            Force f01 = new Force(1000.0);                  // 1000 N
            Force f02 = new Force(1.0m, Force.KiloNewton);  // 1000 N
            Force f03 = (Force)1000.0m;                     // 1000 N
            Force f04 = 0.001f * Force.MegaNewton;          // ~1000 N
            Force f05 = +Force.KiloNewton;                  // 1000 N

            Measure<Force> f11 = new Measure<Force>(f01);                       // 1000 N
            Measure<Force> f12 = new Measure<Force>(0.001f, Force.MegaNewton);  // ~0.001 MN
            IMeasure<Force> f13 = 1.0 | Force.KiloNewton;                       // 1 kN
            Measure<Force> f14 = (Measure<Force>)f13;                           // 1 kN

            Assert.IsTrue(f01 == f05);
            Assert.IsTrue(f01 == f14);

            Force f21 = f02 + f03 - 0.99 * f04;             // 1010 N
            Assert.IsTrue(f21 > f01);

            Measure<Force> f31 = f14 / 2.0;                 // 0.5 kN
            Force f32 = (Force)f31;                         // 500 N

            Assert.IsTrue(f31 == f32);
            Assert.AreEqual(Force.KiloNewton, f31.Unit);
            Assert.AreEqual(Force.Newton, f32.Unit);
        }
    }
}