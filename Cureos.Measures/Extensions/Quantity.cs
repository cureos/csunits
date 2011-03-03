// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Extensions
{
    internal static class Quantity<Q> where Q : struct, IQuantity
    {
        internal static Quantity Value
        {
            get { return default(Q).EnumeratedValue; }
        }

        public static Unit ReferenceUnit
        {
            get { return Value.GetReferenceUnit(); }
        }

        internal static bool Supports(Unit iUnit)
        {
            return iUnit.GetQuantity() == Value;
        }

        internal static bool Supports(IMeasure iMeasure)
        {
            return iMeasure.GetQuantity() == Value;
        }
    }
}