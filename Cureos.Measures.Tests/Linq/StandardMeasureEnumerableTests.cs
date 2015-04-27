// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System.Linq;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Cureos.Measures.Linq
{
    [TestFixture]
    public class StandardMeasureEnumerableTests
    {
        #region Unit tests

        [Test]
        public void ToStandardMeasures_DoubleNoUnitConversion_ReturningNonConvertedStandardMeasures()
        {
            var measures = new[] { 1.0, 2.0, 3.0, -2.0 }.ToMeasures<Length>();
            var expected = new Measure<Length>(3.0);
            var actual = measures.ElementAt(2);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        [Test]
        public void ToStandardMeasures_DecimalWithUnitConversion_ReturningConvertedStandardMeasures()
        {
            var measures = new[] { 1.0m, 2.0m, 3.0m, -2.0m }.ToMeasures(ElectricCurrent.MilliAmpere);
            var expected = new Measure<ElectricCurrent>(0.002m);
            var actual = measures.ElementAt(1);
            MeasureAssert.MeasuresAreEqual(expected, actual);
        }

        #endregion
    }
}
