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

namespace Cureos.Measures.Quantities
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class WaveNumberTests
    {
        #region Unit tests

        [Test]
        public void StandardMeasureIndexer_ReciprocalCentiMeter_ReturnsHundredthValue()
        {
            var expected = new InUnitMeasure<WaveNumber>(1.0, WaveNumber.ReciprocalCentiMeter);
            var actual = new WaveNumber(100.0)[WaveNumber.ReciprocalCentiMeter];
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void SymbolGetter_ReciprocalCentiMeter_ShouldDisplayWithSuperscriptMinus()
        {
            var expected = "cm\u207b¹";
            var actual = WaveNumber.ReciprocalCentiMeter.Symbol;
            Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
