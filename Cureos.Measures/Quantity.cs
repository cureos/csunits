// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures
{
    /// <summary>
    /// Extension methods related to physical quantities
    /// </summary>
    public static class Quantity
    {
        /// <summary>
        /// Checks whether two quantities can be multiplied into a third quantity
        /// </summary>
        /// <typeparam name="Q">Assumed product type of the two multiplied quantity types</typeparam>
        /// <typeparam name="Q1">First quantity factor type</typeparam>
        /// <typeparam name="Q2">Second quantity factor type</typeparam>
        /// <param name="iQuantity">Assumed product quantity</param>
        /// <param name="iLhs">First quantity to be multiplied</param>
        /// <param name="iRhs">Second quantity to be multiplied</param>
        /// <returns>true if product of <paramref name="iLhs"/> and <paramref name="iRhs"/> equals <paramref name="iQuantity"/>,
        /// false otherwise</returns>
        public static bool IsProductOf<Q, Q1, Q2>(this Q iQuantity, Q1 iLhs, Q2 iRhs)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            return iQuantity.Dimension.Equals(iLhs.Dimension * iRhs.Dimension);
        }

        /// <summary>
        /// Checks whether two quantities can be divided into a third quantity
        /// </summary>
        /// <typeparam name="Q">Assumed quotient type of the two divided quantity types</typeparam>
        /// <typeparam name="Q1">Numerator quantity type</typeparam>
        /// <typeparam name="Q2">Denominator quantity type</typeparam>
        /// <param name="iQuantity">Assumed quotient quantity</param>
        /// <param name="iNumerator">Numerator quantity</param>
        /// <param name="iDenominator">Denominator quantity</param>
        /// <returns>true if quotient of <paramref name="iNumerator"/> and <paramref name="iDenominator"/> equals 
        /// <paramref name="iQuantity"/>, false otherwise</returns>
        public static bool IsQuotientOf<Q, Q1, Q2>(this Q iQuantity, Q1 iNumerator, Q2 iDenominator)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            return iQuantity.Dimension.Equals(iNumerator.Dimension / iDenominator.Dimension);
        }

        /// <summary>
        /// Gets the short type name (namespacxe omitted) of the specified quantity
        /// </summary>
        /// <typeparam name="Q">Specified quantity type</typeparam>
        /// <param name="iQuantity">Specified quantity</param>
        /// <returns>Short type name of the specified quantity</returns>
        public static string Name<Q>(this Q iQuantity) where Q : struct, IQuantity<Q>
        {
            return iQuantity.GetType().Name;
        }
    }
}