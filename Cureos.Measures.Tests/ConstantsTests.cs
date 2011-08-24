// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using NUnit.Framework;

namespace Cureos.Measures
{
    [TestFixture]
    public class ConstantsTests
    {
        #region Unit tests

        [Test]
        public void MachineEpsilon_CompareOneAndOnePlusMachineEpsilon_ValuesAreDifferent()
        {
            Assert.IsFalse(Constants.One == Constants.One + Constants.MachineEpsilon);
        }

        [Test]
        public void MachineEpsilon_CompareOneAndOnePlusHalfMachineEpsilon_ValuesAreEqual()
        {
            Assert.IsTrue(Constants.One == Constants.One + Constants.Half * Constants.MachineEpsilon);
        }

        #endregion
    }
}
