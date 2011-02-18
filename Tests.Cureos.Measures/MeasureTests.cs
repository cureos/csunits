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
    public class MeasureTests
    {
        #region Unit tests

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PlusOperator_AddDifferentQuanities_Throws()
        {
            var lhs = new Measure(1.0, Unit.Minute);
            var rhs = new Measure(2.0, Unit.Meter);
            var throws = lhs + rhs;
        }

        #endregion
    }
}
