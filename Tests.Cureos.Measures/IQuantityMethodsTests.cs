// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class IQuantityMethodsTests
    {
        #region Unit tests

        [Test]
        public void GetName_OfMomentOfForceQuantity_ReturnsMomentOfForce()
        {
            var expected = "MomentOfForce";
            var actual = default(MomentOfForce).GetName();
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
