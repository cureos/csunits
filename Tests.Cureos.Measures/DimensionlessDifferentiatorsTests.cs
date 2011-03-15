// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    [TestFixture]
    public class DimensionlessDifferentiatorsTests
    {
        #region Unit tests

        [Test]
        public void Steradian_CompareToRadian_ShouldEqualSquareOfRadian()
        {
            var expected = DimensionlessDifferentiators.Radian * DimensionlessDifferentiators.Radian;
            var actual = DimensionlessDifferentiators.Steradian;
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
