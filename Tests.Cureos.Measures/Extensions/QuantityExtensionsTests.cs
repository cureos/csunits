// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measures;
using Cureos.Measures.Extensions;
using NUnit.Framework;

namespace Tests.Cureos.Measures.Extensions
{
    [TestFixture]
    public class QuantityExtensionsTests
    {
        #region Unit tests

        [Test]
        public void GetSupportedUnits_QuantityLength_ContainsMeterAndMilliMeter()
        {
            var lengthUnits = EnumQuantity.Length.GetSupportedUnits();
            CollectionAssert.Contains(lengthUnits, EnumUnit.Meter);
            CollectionAssert.Contains(lengthUnits, EnumUnit.MilliMeter);
        }

        [Test]
        public void GetSupportedUnits_QuantityArea_DoesNotContainCentiMeter()
        {
            var areaUnits = EnumQuantity.Area.GetSupportedUnits();
            CollectionAssert.DoesNotContain(areaUnits, EnumUnit.CentiMeter);
        }

        #endregion
    }
}
