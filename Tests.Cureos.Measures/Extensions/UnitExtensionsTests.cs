// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System.Linq;
using Cureos.Measures;
using Cureos.Measures.Extensions;
using NUnit.Framework;

namespace Tests.Cureos.Measures.Extensions
{
    [TestFixture]
    public class UnitExtensionsTests
    {
        #region Unit tests

        [Test]
        public void GetUnitsOf_QuantityVolume_ContainsLiterAndCubicDeciMeter()
        {
            var volumeUnits = UnitExtensions.GetUnits(Quantity.Volume);
            Assert.IsTrue(volumeUnits.Contains(Unit.Liter));
            Assert.IsTrue(volumeUnits.Contains(Unit.CubicDeciMeter));
        }

        #endregion
    }
}
