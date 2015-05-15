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
        public void InitializationExample()
        {
            Force f01 = new Force(1000.0);                  // 1000 N
            Force f02 = new Force(1.0m, Force.KiloNewton);  // 1000 N
            Force f03 = (Force)1000.0m;                     // 1000 N
            Force f04 = 0.001f * Force.MegaNewton;          // ~1000 N
            Force f05 = Force.KiloNewton;                   // 1000 N

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

        [Test]
        public void ComparisonExample()
        {
	        Length l1 = new Length(0.02);										// 0.02 m
	        Length l2 = Length.CentiMeter;										// 0.01 m
	        Measure<Length> l3 = new Measure<Length>(15.0, Length.MilliMeter);	// 15 mm

	        Assert.IsTrue(l1 > l2);		// true
	        Assert.IsFalse(l2 >= l1);	// false
	        Assert.IsTrue(l3 < l1);		// true
	        Assert.IsFalse(l3 <= l2);	// false
	        Assert.IsFalse(l1 == l3);	// false
	        Assert.IsTrue(l2 != l1);	// true
        }

        [Test]
        public void UnitConversionExample()
        {
	        Length s = new Length(180.0, Length.KiloMeter);
	        Time t = new Time(2.0, Time.Hour);
	        Velocity v1 = s / t;

            Assert.AreEqual(25.0, v1.Amount, 1.0e-7);
            Assert.AreEqual(Velocity.MeterPerSecond, v1.Unit);

            IMeasure<Velocity> v2 = v1[Velocity.KiloMeterPerHour]; // 90 km/h

            Assert.AreEqual(90.0, v2.Amount, 1.0e-7);
            Assert.AreEqual(Velocity.KiloMeterPerHour, v2.Unit);
        }
    }
}