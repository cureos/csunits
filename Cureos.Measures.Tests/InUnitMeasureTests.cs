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
    public class InUnitMeasureTests
    {
        #region Test Methods

        [Test]
        public void GetAmount_UsingIUnit_ValidConversion()
        {
            var expected = AmountConverter.ToAmountType(500.0);
            var instance = new InUnitMeasure<Length>(5.0, Length.Meter);
            var actual = instance.GetAmount(Length.CentiMeter);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DefaultConstructor_Apply_YieldsZeroAmountStandardUnit()
        {
            var expected = new InUnitMeasure<Temperature>(0.0, Temperature.Kelvin);
            var actual = new InUnitMeasure<Temperature>();
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void Indexer_SameQuantityNonGenericInterface_YieldsValidMeasureOBject()
        {
            var expected = new InUnitMeasure<Volume>(5000.0, Volume.Liter);
            IMeasure meas = new Volume(5.0);
            var actual = meas[Volume.Liter];
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Indexer_DifferentQuantitiesNonGenericInterface_Throws()
        {
            IMeasure meas = new SpecificVolume(1.0);
            var throws = meas[Volume.CubicMeter];
        }

        #endregion
    }
}
