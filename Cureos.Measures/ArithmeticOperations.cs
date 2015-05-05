/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

namespace Cureos.Measures
{
    using System;

    /// <summary>
    /// Methods representing arithmetic operations on IMeausre objects
    /// </summary>
    public static class ArithmeticOperations
    {
        /// <summary>
        /// Multiply two measures to return a resulting measure of a specified quantity
        /// </summary>
        /// <typeparam name="Q">Quantity type of resulting measure</typeparam>
        /// <typeparam name="Q1">Quantity type of first factor</typeparam>
        /// <typeparam name="Q2">Quantity type of second factor</typeparam>
        /// <param name="iFirst">First measure to multiply</param>
        /// <param name="iSecond">Second measure to multiply</param>
        /// <param name="oResult">Measure resulting from multiplication, given in standard unit of quantity</param>
        public static void Times<Q, Q1, Q2>(IMeasure<Q1> iFirst, IMeasure<Q2> iSecond, out Q oResult)
            where Q : struct, IQuantity<Q>, IMeasureFactory<Q> where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            AssertMatchingQuantities<Q, Q1, Q2>(1, 1);
            oResult = new Q().Create(iFirst.StandardAmount * iSecond.StandardAmount);
        }

        /// <summary>
        /// Divide two measures to return a resulting measure of a specified quantity
        /// </summary>
        /// <typeparam name="Q">Quantity type of resulting measure</typeparam>
        /// <typeparam name="Q1">Quantity type of numerator</typeparam>
        /// <typeparam name="Q2">Quantity type of denominator</typeparam>
        /// <param name="iNumerator">Numerator measure</param>
        /// <param name="iDenominator">Denominator measure</param>
        /// <param name="oResult">Resulting measure quotient, given in standard unit of quantity</param>
        public static void Divide<Q, Q1, Q2>(IMeasure<Q1> iNumerator, IMeasure<Q2> iDenominator, out Q oResult)
            where Q : struct, IQuantity<Q>, IMeasureFactory<Q> where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            AssertMatchingQuantities<Q, Q1, Q2>(1, -1);
            oResult = new Q().Create(iNumerator.StandardAmount / iDenominator.StandardAmount);
        }

        /// <summary>
        /// Raise the specified measure to the specified integer power
        /// </summary>
        /// <typeparam name="Q">Quantity type of the resulting measure</typeparam>
        /// <typeparam name="Q1">Quantity type of the base measure</typeparam>
        /// <param name="iBase">Base measure</param>
        /// <param name="iExponent">Exponent</param>
        /// <param name="oResult">Resulting measure, given in standard unit of the specified quantity</param>
        public static void Power<Q, Q1>(IMeasure<Q1> iBase, int iExponent, out Q oResult)
            where Q : struct, IQuantity<Q>, IMeasureFactory<Q> where Q1 : struct, IQuantity<Q1>
        {
            AssertMatchingQuantities<Q, Q1>(iExponent);
            oResult = new Q().Create(Math.Pow((double)iBase.StandardAmount, iExponent));
        }

        /// <summary>
        /// Multiply two measures, each raised to a specific power, to return a resulting measure of a specified quantity
        /// </summary>
        /// <typeparam name="Q">Quantity type of resulting measure</typeparam>
        /// <typeparam name="Q1">Quantity type of first factor</typeparam>
        /// <typeparam name="Q2">Quantity type of second factor</typeparam>
        /// <param name="iFirst">First measure to raise and multiply</param>
        /// <param name="iFirstExponent">Exponent to which the first measure should be raised</param>
        /// <param name="iSecond">Second measure to raise and multiply</param>
        /// <param name="iSecondExponent">Exponent to which the second measure should be raised</param>
        /// <param name="oResult">Measure resulting from multiplication, given in standard unit of quantity</param>
        public static void Product<Q, Q1, Q2>(
            IMeasure<Q1> iFirst,
            int iFirstExponent,
            IMeasure<Q2> iSecond,
            int iSecondExponent,
            out Q oResult) where Q : struct, IQuantity<Q>, IMeasureFactory<Q> where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            AssertMatchingQuantities<Q, Q1, Q2>(iFirstExponent, iSecondExponent);
            oResult =
                new Q().Create(
                    Math.Pow((double)iFirst.StandardAmount, iFirstExponent)
                    * Math.Pow((double)iSecond.StandardAmount, iSecondExponent));
        }

        /// <summary>
        /// Multiply three measures, each raised to a specific power, to return a resulting measure of a specified quantity
        /// </summary>
        /// <typeparam name="Q">Quantity type of resulting measure</typeparam>
        /// <typeparam name="Q1">Quantity type of first factor</typeparam>
        /// <typeparam name="Q2">Quantity type of second factor</typeparam>
        /// <typeparam name="Q3">Quantity type of the third factor</typeparam>
        /// <param name="iFirst">First measure to raise and multiply</param>
        /// <param name="iFirstExponent">Exponent to which the first measure should be raised</param>
        /// <param name="iSecond">Second measure to raise and multiply</param>
        /// <param name="iSecondExponent">Exponent to which the second measure should be raised</param>
        /// <param name="iThird">Third measure to raise and multiply</param>
        /// <param name="iThirdExponent">Exponent to which the third measure should be raised</param>
        /// <param name="oResult">Measure resulting from multiplication, given in standard unit of quantity</param>
        public static void Product<Q, Q1, Q2, Q3>(
            IMeasure<Q1> iFirst,
            int iFirstExponent,
            IMeasure<Q2> iSecond,
            int iSecondExponent,
            IMeasure<Q3> iThird,
            int iThirdExponent,
            out Q oResult) where Q : struct, IQuantity<Q>, IMeasureFactory<Q> where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2> where Q3 : struct, IQuantity<Q3>
        {
            AssertMatchingQuantities<Q, Q1, Q2, Q3>(iFirstExponent, iSecondExponent, iThirdExponent);
            oResult =
                new Q().Create(
                    Math.Pow((double)iFirst.StandardAmount, iFirstExponent)
                    * Math.Pow((double)iSecond.StandardAmount, iSecondExponent)
                    * Math.Pow((double)iThird.StandardAmount, iThirdExponent));
        }

        /// <summary>
        /// Multiply four measures, each raised to a specific power, to return a resulting measure of a specified quantity
        /// </summary>
        /// <typeparam name="Q">Quantity type of resulting measure</typeparam>
        /// <typeparam name="Q1">Quantity type of first factor</typeparam>
        /// <typeparam name="Q2">Quantity type of second factor</typeparam>
        /// <typeparam name="Q3">Quantity type of the third factor</typeparam>
        /// <typeparam name="Q4">Quantity type of the fourth factor</typeparam>
        /// <param name="iFirst">First measure to raise and multiply</param>
        /// <param name="iFirstExponent">Exponent to which the first measure should be raised</param>
        /// <param name="iSecond">Second measure to raise and multiply</param>
        /// <param name="iSecondExponent">Exponent to which the second measure should be raised</param>
        /// <param name="iThird">Third measure to raise and multiply</param>
        /// <param name="iThirdExponent">Exponent to which the third measure should be raised</param>
        /// <param name="iFourth">Fourth measure to raise and multiply</param>
        /// <param name="iFourthExponent">Exponent to which the fourth measure should be raised</param>
        /// <param name="oResult">Measure resulting from multiplication, given in standard unit of quantity</param>
        public static void Product<Q, Q1, Q2, Q3, Q4>(
            IMeasure<Q1> iFirst,
            int iFirstExponent,
            IMeasure<Q2> iSecond,
            int iSecondExponent,
            IMeasure<Q3> iThird,
            int iThirdExponent,
            IMeasure<Q4> iFourth,
            int iFourthExponent,
            out Q oResult) where Q : struct, IQuantity<Q>, IMeasureFactory<Q> where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2> where Q3 : struct, IQuantity<Q3> where Q4 : struct, IQuantity<Q4>
        {
            AssertMatchingQuantities<Q, Q1, Q2, Q3, Q4>(
                iFirstExponent,
                iSecondExponent,
                iThirdExponent,
                iFourthExponent);
            oResult =
                new Q().Create(
                    Math.Pow((double)iFirst.StandardAmount, iFirstExponent)
                    * Math.Pow((double)iSecond.StandardAmount, iSecondExponent)
                    * Math.Pow((double)iThird.StandardAmount, iThirdExponent)
                    * Math.Pow((double)iFourth.StandardAmount, iFourthExponent));
        }

        #region PRIVATE SUPPORT METHODS

        private static void AssertMatchingQuantities<Q, Q1>(int iQ1Exponent) where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
        {
            AssertMatchingQuantityDimensions<Q>(default(Q1).Dimension ^ iQ1Exponent);
        }

        private static void AssertMatchingQuantities<Q, Q1, Q2>(int iQ1Exponent, int iQ2Exponent)
            where Q : struct, IQuantity<Q> where Q1 : struct, IQuantity<Q1> where Q2 : struct, IQuantity<Q2>
        {
            AssertMatchingQuantityDimensions<Q>(
                (default(Q1).Dimension ^ iQ1Exponent) * (default(Q2).Dimension ^ iQ2Exponent));
        }

        private static void AssertMatchingQuantities<Q, Q1, Q2, Q3>(int iQ1Exponent, int iQ2Exponent, int iQ3Exponent)
            where Q : struct, IQuantity<Q> where Q1 : struct, IQuantity<Q1> where Q2 : struct, IQuantity<Q2>
            where Q3 : struct, IQuantity<Q3>
        {
            AssertMatchingQuantityDimensions<Q>(
                (default(Q1).Dimension ^ iQ1Exponent) * (default(Q2).Dimension ^ iQ2Exponent)
                * (default(Q3).Dimension ^ iQ3Exponent));
        }

        private static void AssertMatchingQuantities<Q, Q1, Q2, Q3, Q4>(
            int iQ1Exponent,
            int iQ2Exponent,
            int iQ3Exponent,
            int iQ4Exponent) where Q : struct, IQuantity<Q> where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2> where Q3 : struct, IQuantity<Q3> where Q4 : struct, IQuantity<Q4>
        {
            AssertMatchingQuantityDimensions<Q>(
                (default(Q1).Dimension ^ iQ1Exponent) * (default(Q2).Dimension ^ iQ2Exponent)
                * (default(Q3).Dimension ^ iQ3Exponent) * (default(Q4).Dimension ^ iQ4Exponent));
        }

        private static void AssertMatchingQuantityDimensions<Q>(QuantityDimension iActualDimension)
            where Q : struct, IQuantity<Q>
        {
            if (default(Q).Dimension.Equals(iActualDimension)) return;
            throw new InvalidOperationException(
                String.Format(
                    "Actual quantity dimension: {0}, expected {1} for quantity {2}",
                    iActualDimension,
                    default(Q).Dimension,
                    default(Q).GetType().Name));
        }

        #endregion
    }
}