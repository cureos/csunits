// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measures;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
    public static class IMeasureDoubletAssert
    {
        public static void AreEqual<Q1, Q2>(IMeasureDoublet<Q1, Q2> expected, IMeasureDoublet<Q1, Q2> actual)
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            Assert.AreEqual(expected.X.Unit, actual.X.Unit);
            Assert.AreEqual(expected.Y.Unit, actual.Y.Unit);
            AmountAssert.AreEqual(expected.X.Amount, actual.X.Amount);
            AmountAssert.AreEqual(expected.Y.Amount, actual.Y.Amount);
        }
    }
}