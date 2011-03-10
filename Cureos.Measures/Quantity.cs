// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures
{
    /// <summary>
    /// Class of extension methods related to physical quantities
    /// </summary>
    public static class Quantity
    {
        public static bool IsProductOf<Q, Q1, Q2>(this Q iQuantity, Q1 iLhs, Q2 iRhs)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            return iQuantity.Dimension.Equals(iLhs.Dimension + iRhs.Dimension);
        }

        public static bool IsQuotientOf<Q, Q1, Q2>(this Q iQuantity, Q1 iNumerator, Q2 iDenominator)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            return iQuantity.Dimension.Equals(iNumerator.Dimension - iDenominator.Dimension);
        }

        public static string Name<Q>(this Q iQuantity) where Q : struct, IQuantity<Q>
        {
            return iQuantity.GetType().Name;
        }
    }
}