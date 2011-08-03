// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using NUnit.Framework;

namespace Cureos.Measures.Quantities
{
    [TestFixture]
    public class VelocityTests
    {
        #region Unit tests

        [Test]
        public void GetAmount_StandardMeasureToKmph_Factor3point6Larger()
        {
            var expected = AmountConverter.ToAmountType(90.0);
            var velocity = new StandardMeasure<Velocity>(25.0);
            var actual = velocity.GetAmount(Velocity.KiloMeterPerHour);
            AmountAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}
