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

namespace Cureos.Measures.Linq
{
    using System.Linq;

    using Cureos.Measures.Quantities;

    using NUnit.Framework;

    [TestFixture]
    public class MeasureEnumerableTests
    {
        #region Unit tests

        [Test]
        public void ToStandardMeasures_DoubleNoUnitConversion_ReturningNonConvertedStandardMeasures()
        {
            var measures = new[] { 1.0, 2.0, 3.0, -2.0 }.Cast<Length>();
            var expected = new Length(3.0);
            var actual = measures.ElementAt(2);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void ToStandardMeasures_DecimalWithUnitConversion_ReturningConvertedStandardMeasures()
        {
            var measures = new[] { 1.0m, 2.0m, 3.0m, -2.0m }.Cast(ElectricCurrent.MilliAmpere);
            var expected = new ElectricCurrent(0.002m);
            var actual = measures.ElementAt(1);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        #endregion
    }
}
