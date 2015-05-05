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

            InUnitMeasure<Mass> newWgtInGram = (InUnitMeasure<Mass>)newWgt[Mass.Gram];
            InUnitMeasure<Mass> initialWgtInGram = newWgtInGram - gainedWgt;

            Console.WriteLine("Initial weight: {0}", initialWgtInGram);

            Length height = new Length(30.0, Length.CentiMeter);
            Area area = (Area)0.02;

            Volume vol;
            ArithmeticOperations.Times(height, area, out vol);
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
    }
}