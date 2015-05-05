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
    public struct MeasureDoublet<Q1, Q2> : IMeasureDoublet<Q1, Q2>
        where Q1 : struct, IQuantity<Q1>, IMeasure<Q1> where Q2 : struct, IQuantity<Q2>, IMeasure<Q2>
    {
        #region MEMBER VARIABLES

        private static readonly IMeasureFactory<Q1> Q1Factory = new Q1().Factory;

        private static readonly IMeasureFactory<Q2> Q2Factory = new Q2().Factory;

        private readonly Q1 x;

        private readonly Q2 y;

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
        /// Initializes a pair of standard measures
        /// </summary>
        /// <param name="iMeasure1">First measure object</param>
        /// <param name="iMeasure2">Second measure object</param>
        public MeasureDoublet(IMeasure<Q1> iMeasure1, IMeasure<Q2> iMeasure2)
        {
            this.x = Q1Factory.New(iMeasure1);
            this.y = Q2Factory.New(iMeasure2);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        public MeasureDoublet(double iAmount1, double iAmount2)
        {
            this.x = Q1Factory.New(iAmount1);
            this.y = Q2Factory.New(iAmount2);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        public MeasureDoublet(float iAmount1, float iAmount2)
        {
            this.x = Q1Factory.New(iAmount1);
            this.y = Q2Factory.New(iAmount2);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        public MeasureDoublet(decimal iAmount1, decimal iAmount2)
        {
            this.x = Q1Factory.New(iAmount1);
            this.y = Q2Factory.New(iAmount2);
        }

        #endregion

        #region Implementation of IMeasure<Q1,Q2>

        /// <summary>
        /// Gets the first measure in the measure pair
        /// </summary>
        public IMeasure<Q1> X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets the second measure in the measure pair
        /// </summary>
        public IMeasure<Q2> Y
        {
            get
            {
                return this.y;
            }
        }

        #endregion

        #region OPERATORS

        /// <summary>
        /// Adds two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Sum of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator +(MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.x.Amount + iRhs.x.Amount, iLhs.y.Amount + iRhs.y.Amount);
        }

        /// <summary>
        /// Adds two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Sum of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator +(MeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(
                iLhs.x.Amount + iRhs.X.StandardAmount,
                iLhs.y.Amount + iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Subtracts two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Difference of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator -(MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.x.Amount - iRhs.x.Amount, iLhs.y.Amount - iRhs.y.Amount);
        }

        /// <summary>
        /// Subtracts two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Difference of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator -(MeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(
                iLhs.x.Amount - iRhs.X.StandardAmount,
                iLhs.y.Amount - iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Multiplies one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Product of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator *(MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Number, Number> iRhs
            )
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.x.Amount * iRhs.x.Amount, iLhs.y.Amount * iRhs.y.Amount);
        }

        /// <summary>
        /// Multiplies one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Product of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator *(
            MeasureDoublet<Q1, Q2> iLhs,
            IMeasureDoublet<Number, Number> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(
                iLhs.x.Amount * iRhs.X.StandardAmount,
                iLhs.y.Amount * iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Divides one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Quotient of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator /(MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Number, Number> iRhs
            )
        {
            return new MeasureDoublet<Q1, Q2>(iLhs.x.Amount / iRhs.x.Amount, iLhs.y.Amount / iRhs.y.Amount);
        }

        /// <summary>
        /// Divides one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Quotient of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator /(
            MeasureDoublet<Q1, Q2> iLhs,
            IMeasureDoublet<Number, Number> iRhs)
        {
            return new MeasureDoublet<Q1, Q2>(
                iLhs.x.Amount / iRhs.X.StandardAmount,
                iLhs.y.Amount / iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Divides one measure doublet with another measure doublet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure doublet</param>
        /// <param name="iRhs">Denominator measure doublet</param>
        /// <returns>Quotient of the measure doublets as a number doublet</returns>
        public static MeasureDoublet<Number, Number> operator /(MeasureDoublet<Q1, Q2> iLhs, MeasureDoublet<Q1, Q2> iRhs
            )
        {
            return new MeasureDoublet<Number, Number>(iLhs.x.Amount / iRhs.x.Amount, iLhs.y.Amount / iRhs.y.Amount);
        }

        /// <summary>
        /// Divides one measure doublet with another measure doublet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure doublet</param>
        /// <param name="iRhs">Denominator measure doublet</param>
        /// <returns>Quotient of the measure doublets as a number doublet</returns>
        public static MeasureDoublet<Number, Number> operator /(
            MeasureDoublet<Q1, Q2> iLhs,
            IMeasureDoublet<Q1, Q2> iRhs)
        {
            return new MeasureDoublet<Number, Number>(
                iLhs.x.Amount / iRhs.X.StandardAmount,
                iLhs.y.Amount / iRhs.Y.StandardAmount);
        }

        #endregion
    }
}