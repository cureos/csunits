// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures.Quantities
{
    [TestFixture]
    public class WaveNumberTests
    {
        #region Unit tests

        [Test]
        public void StandardMeasureIndexer_ReciprocalCentiMeter_ReturnsHundredthValue()
        {
            var expected = new Measure<WaveNumber>(1.0, WaveNumber.ReciprocalCentiMeter);
            var actual = new StandardMeasure<WaveNumber>(100.0)[WaveNumber.ReciprocalCentiMeter];
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
