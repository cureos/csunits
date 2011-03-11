// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class QuantityTests
    {
        #region Unit tests

        [Test]
        public void Name_OfQuantity_ReturnsShortName()
        {
            var expected = "AbsorbedDose";
            var actual = default(AbsorbedDose).Name();
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
