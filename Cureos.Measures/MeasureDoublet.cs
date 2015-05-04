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
    using Cureos.Measures.Quantities;

#if SINGLE
    using AmountType = System.Single;
#elif DECIMAL
    using AmountType = System.Decimal;
#elif DOUBLE
    using AmountType = System.Double;
#endif

    /// <summary>
    /// Representation of a pair of measures, given in the standard units of the respective quantities
    /// </summary>
    /// <typeparam name="Q1">Quantity type of the first measure</typeparam>
    /// <typeparam name="Q2">Quantity type of the second measure</typeparam>
    public struct MeasureDoublet<Q1, Q2> : IMeasureDoublet<Q1, Q2> where Q1 : struct, IQuantity<Q1> where Q2 : struct, IQuantity<Q2>
    {
        #region MEMBER VARIABLES

        private readonly Measure<Q1> mX;
        private readonly Measure<Q2> mY;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a pair of standard measures
        /// </summary>
        /// <param name="iMeasureDoublet">Pair of measures in arbitrary unit</param>
        public MeasureDoublet(IMeasureDoublet<Q1, Q2> iMeasureDoublet)
            : this(iMeasureDoublet.X, iMeasureDoublet.Y)
        {
        }

        /// <summary>
        /// Initializes a pair of standard measures from two standard measure objects
        /// </summary>
        /// <param name="iX">First measure object</param>
        /// <param name="iY">Second measure object</param>
        public MeasureDoublet(Measure<Q1> iX, Measure<Q2> iY)
        {
            mX = iX;
            mY = iY;
        }

        /// <summary>
        /// Initializes a pair of standard measures
        /// </summary>
        /// <param name="iMeasure1">First measure object</param>
        /// <param name="iMeasure2">Second measure object</param>
        public MeasureDoublet(IMeasure<Q1> iMeasure1, IMeasure<Q2> iMeasure2)
        {
            mX = new Measure<Q1>(iMeasure1);
            mY = new Measure<Q2>(iMeasure2);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        public MeasureDoublet(double iAmount1, double iAmount2)
        {
            mX = new Measure<Q1>(iAmount1);
            mY = new Measure<Q2>(iAmount2);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        public MeasureDoublet(float iAmount1, float iAmount2)
        {
            mX = new Measure<Q1>(iAmount1);
            mY = new Measure<Q2>(iAmount2);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        public MeasureDoublet(decimal iAmount1, decimal iAmount2)
        {
            mX = new Measure<Q1>(iAmount1);
            mY = new Measure<Q2>(iAmount2);
        }

        #endregion

        #region Implementation of IMeasure<Q1,Q2>

        /// <summary>
        /// Gets the first measure in the measure pair
        /// </summary>
        public IMeasure<Q1> X
        {
            get { return mX; }
        }

        /// <summary>
        /// Gets the second measure in the measure pair
        /// </summary>
        public IMeasure<Q2> Y
        {
            get { return mY; }
        }

        #endregion

        #region OPERATORS

        /// <summary>
        /// Adds two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Sum of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator+ (MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.mX + iRhs.mX, iLhs.mY + iRhs.mY);
        }

        /// <summary>
        /// Adds two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Sum of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator +(MeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.mX.Amount + iRhs.X.StandardAmount,
                                                      iLhs.mY.Amount + iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Subtracts two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Difference of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator -(MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.mX - iRhs.mX, iLhs.mY - iRhs.mY);
        }

        /// <summary>
        /// Subtracts two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Difference of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator -(MeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.mX.Amount - iRhs.X.StandardAmount,
                                                      iLhs.mY.Amount - iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Multiplies one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Product of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator *(MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Number, Number> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.mX.Amount * iRhs.mX.Amount, iLhs.mY.Amount * iRhs.mY.Amount);
        }

        /// <summary>
        /// Multiplies one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Product of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator *(MeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Number, Number> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.mX.Amount * iRhs.X.StandardAmount, iLhs.mY.Amount * iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Divides one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Quotient of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator /(MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Number, Number> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.mX.Amount / iRhs.mX.Amount, iLhs.mY.Amount / iRhs.mY.Amount);
        }

        /// <summary>
        /// Divides one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Quotient of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator /(MeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Number, Number> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.mX.Amount / iRhs.X.StandardAmount, iLhs.mY.Amount / iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Divides one measure doublet with another measure doublet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure doublet</param>
        /// <param name="iRhs">Denominator measure doublet</param>
        /// <returns>Quotient of the measure doublets as a number doublet</returns>
        public static MeasureDoublet<Number, Number> operator /(MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Number, Number>(iLhs.mX / iRhs.mX, iLhs.mY / iRhs.mY);
        }

        /// <summary>
        /// Divides one measure doublet with another measure doublet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure doublet</param>
        /// <param name="iRhs">Denominator measure doublet</param>
        /// <returns>Quotient of the measure doublets as a number doublet</returns>
        public static MeasureDoublet<Number, Number> operator /(MeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Number, Number>(iLhs.mX.Amount / iRhs.X.StandardAmount,
                                                              iLhs.mY.Amount / iRhs.Y.StandardAmount);
        }

        #endregion
    }
}