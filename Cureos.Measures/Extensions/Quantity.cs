// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Extensions
{
    /// <summary>
    /// Support methods and properties for efficiently handling struct types implementing the IQuantity interface
    /// </summary>
    /// <typeparam name="Q">Struct type representing a specific quantity, implementing the IQuantity interface</typeparam>
    internal static class Quantity<Q> where Q : struct, IQuantity
    {
        /// <summary>
        /// Gets the enumerated value corresponding to the specified IQuantity type
        /// </summary>
        internal static EnumQuantity Value
        {
            get { return default(Q).EnumeratedValue; }
        }

        /// <summary>
        /// Gets the reference unit associated with the specified IQuantity type
        /// </summary>
        internal static EnumUnit ReferenceUnit
        {
            get { return Value.GetReferenceUnit(); }
        }

        /// <summary>
        /// Checks whether the <paramref name="iUnit">specified unit</paramref> is of the specified IQuantity type
        /// </summary>
        /// <param name="iUnit">Unit for which quantity should be checked</param>
        /// <returns>true if the <paramref name="iUnit">specified unit</paramref> is of the specified IQuantity type,
        /// false otherwise</returns>
        internal static bool IsQuantityOf(EnumUnit iUnit)
        {
            return iUnit.GetQuantity() == Value;
        }

        /// <summary>
        /// Checks whether the <paramref name="iMeasure">specified measure</paramref> is of the specified IQuantity type
        /// </summary>
        /// <param name="iMeasure">Measure for which quantity should be checked</param>
        /// <returns>true if the <paramref name="iMeasure">specified measure</paramref> is of the specified IQuantity type,
        /// false otherwise</returns>
        internal static bool IsQuantityOf(IMeasure iMeasure)
        {
            return iMeasure.GetQuantity() == Value;
        }

        /// <summary>
        /// Checks whether the "product" of two quantities has the same quantity dimensions as the quantity given by the 
        /// IQuantity type
        /// </summary>
        /// <param name="iLhs">First quantity in multiplication</param>
        /// <param name="iRhs">Second quantity in multiplication</param>
        /// <returns>true if the quantity "product" matches the dimensions of the given IQuantity type, false otherwise</returns>
        internal static bool IsProductOf(EnumQuantity iLhs, EnumQuantity iRhs)
        {
            return Value.IsProductOf(iLhs, iRhs);
        }

        /// <summary>
        /// Checks whether the "quotient" of two quantities has the same quantity dimensions as the quantity given
        /// by the specified IQuantity type
        /// </summary>
        /// <param name="iNumerator">Numerator quantity in division</param>
        /// <param name="iDenominator">Denominator quantity in division</param>
        /// <returns>true if the quantity "quotient" matches the dimensions of the quantity given by the specified
        /// IQuantity type, false otherwise</returns>
        internal static bool IsQuotientOf(EnumQuantity iNumerator, EnumQuantity iDenominator)
        {
            return Value.IsQuotientOf(iNumerator, iDenominator);
        }
    }
}