// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Linq;
using Cureos.Measures;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class UnitExtensionsTests
    {
        #region Unit tests

        [Test]
        public void GetUnitsOf_QuantityVolume_ContainsLiterAndCubicDeciMeter()
        {
            var volumeUnits = UnitExtensions.GetUnitsOf(Quantity.Volume);
            Assert.IsTrue(volumeUnits.Contains(Unit.Liter));
            Assert.IsTrue(volumeUnits.Contains(Unit.CubicDeciMeter));
        }

        #endregion
    }
}
