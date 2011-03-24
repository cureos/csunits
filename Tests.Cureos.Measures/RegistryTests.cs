// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Linq;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class RegistryTests
    {
        #region Unit tests

        [Test]
        public void QuantitiesGetter_CheckContainsLuminance_ReturnsTrue()
        {
            var expected = true;
            var actual = Registry.Quantities.Contains(default(Luminance));
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetUnits_ForEnergy_ContainsMegaJoule()
        {
            var expected = true;
            var actual = Registry.GetUnits(default(Energy)).Contains(Energy.MegaJoule);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetUnits_ForForce_DoesNotContainPascal()
        {
            var expected = false;
            var actual = Registry.GetUnits(default(Force)).Contains(Pressure.Pascal);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnitsGetter_CheckIfLumenIsContained_ReturnsTrue()
        {
            var expected = true;
            var actual = Registry.Units.Contains(LuminousFlux.Lumen);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnitsGetter_CheckIfLocallyDefinedUnitIsContained_ReturnsFalse()
        {
            var expected = false;
            var actual =
                Registry.Units.Contains(new Unit<Length>("beard-second", AmountConverter.ToAmountType(1.0e-8)));
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
