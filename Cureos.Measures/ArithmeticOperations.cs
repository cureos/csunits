// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

namespace Cureos.Measures
{
    /// <summary>
    /// Methods representing arithmetic operations on IMeausre objects
    /// </summary>
    public static class ArithmeticOperations
    {
        public static void Times<Q, Q1, Q2>(IMeasure<Q1> iFirst, IMeasure<Q2> iSecond, out StandardMeasure<Q> oResult)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            AssertMatchingQuantities<Q, Q1, Q2>(1, 1);
            oResult = new StandardMeasure<Q>(iFirst.StandardAmount * iSecond.StandardAmount);
        }

        public static void Divide<Q, Q1, Q2>(IMeasure<Q1> iFirst, IMeasure<Q2> iSecond, out StandardMeasure<Q> oResult)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            AssertMatchingQuantities<Q, Q1, Q2>(1, -1);
            oResult = new StandardMeasure<Q>(iFirst.StandardAmount / iSecond.StandardAmount);
        }

        public static void Power<Q, Q1>(IMeasure<Q1> iBase, int iExponent, out StandardMeasure<Q> oResult)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
        {
            AssertMatchingQuantities<Q, Q1>(iExponent);
#if DOUBLE
            oResult = new StandardMeasure<Q>(Math.Pow(iBase.StandardAmount, iExponent));
#else
            oResult = new StandardMeasure<Q>(Math.Pow((double)iBase.StandardAmount, iExponent));
#endif
        }

        public static void Product<Q, Q1, Q2>(IMeasure<Q1> iFirst, int iFirstExponent, IMeasure<Q2> iSecond, 
            int iSecondExponent, out StandardMeasure<Q> oResult)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            AssertMatchingQuantities<Q, Q1, Q2>(iFirstExponent, iSecondExponent);
#if DOUBLE
            oResult =
                new StandardMeasure<Q>(Math.Pow(iFirst.StandardAmount, iFirstExponent) *
                                       Math.Pow(iSecond.StandardAmount, iSecondExponent));
#else
            iResult =
                new StandardMeasure<Q>(Math.Pow((double)iFirst.StandardAmount, iFirstExponent) *
                                       Math.Pow((double)iSecond.StandardAmount, iSecondExponent));
#endif
        }

        public static void Product<Q, Q1, Q2, Q3>(IMeasure<Q1> iFirst, int iFirstExponent, IMeasure<Q2> iSecond, 
            int iSecondExponent, IMeasure<Q2> iThird, int iThirdExponent, out StandardMeasure<Q> oResult)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
            where Q3 : struct, IQuantity<Q3>
        {
            AssertMatchingQuantities<Q, Q1, Q2, Q3>(iFirstExponent, iSecondExponent, iThirdExponent);
#if DOUBLE
            oResult =
                new StandardMeasure<Q>(Math.Pow(iFirst.StandardAmount, iFirstExponent) *
                                       Math.Pow(iSecond.StandardAmount, iSecondExponent) *
                                       Math.Pow(iThird.StandardAmount, iThirdExponent));
#else
            iResult =
                new StandardMeasure<Q>(Math.Pow((double)iFirst.StandardAmount, iFirstExponent) *
                                       Math.Pow((double)iSecond.StandardAmount, iSecondExponent) *
                                       Math.Pow((double)iThird.StandardAmount, iThirdExponent));
#endif
        }

        #region PRIVATE SUPPORT METHODS

        private static void AssertMatchingQuantities<Q, Q1>(int iQ1Exponent)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
        {
            AssertMatchingQuantityDimensions<Q>(default(Q1).Dimension ^ iQ1Exponent);
        }

        private static void AssertMatchingQuantities<Q, Q1, Q2>(int iQ1Exponent, int iQ2Exponent)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
        {
            AssertMatchingQuantityDimensions<Q>((default(Q1).Dimension ^ iQ1Exponent)*
                                                (default(Q2).Dimension ^ iQ2Exponent));
        }

        private static void AssertMatchingQuantities<Q, Q1, Q2, Q3>(int iQ1Exponent, int iQ2Exponent, int iQ3Exponent)
            where Q : struct, IQuantity<Q>
            where Q1 : struct, IQuantity<Q1>
            where Q2 : struct, IQuantity<Q2>
            where Q3 : struct, IQuantity<Q3>
        {
            AssertMatchingQuantityDimensions<Q>((default(Q1).Dimension ^ iQ1Exponent) *
                                                (default(Q2).Dimension ^ iQ2Exponent) *
                                                (default(Q3).Dimension ^ iQ3Exponent));
        }

        private static void AssertMatchingQuantityDimensions<Q>(QuantityDimension iActualDimension) where Q : struct, IQuantity<Q>
        {
            if (default(Q).Dimension.Equals(iActualDimension)) return;
            throw new InvalidOperationException(
                String.Format("Actual quantity dimension: {0}, expected {1} for quantity {2}",
                              iActualDimension, default(Q).Dimension, default(Q).GetType().Name));
        }

        #endregion
    }
}