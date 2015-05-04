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
    using Cureos.Measures.Quantities;

    using NUnit.Framework;

    [TestFixture]
    public class ConversionsTests
    {
        #region Unit tests

        [Test]
        public void To_DecimalAndLengthUnit_ReturnsMeasureInSpecifiedAmountAndUnit()
        {
            var expected = new InUnitMeasure<Length>(3.0m, Length.MilliMeter);
            var actual = 3.0m.To(Length.MilliMeter);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void From_FloatAndVolumeUnit_ReturnsStandardVolumeMeasure()
        {
            var expected = new InUnitMeasure<Volume>(0.002f, Volume.CubicMeter);
            var actual = 2.0f * Volume.Liter;
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        #endregion
    }
}
