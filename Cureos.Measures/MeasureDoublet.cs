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
        /// <param name="measureDoublet">Pair of measures in arbitrary unit</param>
        public MeasureDoublet(IMeasureDoublet<Q1, Q2> measureDoublet)
            : this(measureDoublet.X, measureDoublet.Y)
        {
        }

        /// <summary>
        /// Initializes a pair of standard measures
        /// </summary>
        /// <param name="measure1">First measure object</param>
        /// <param name="measure2">Second measure object</param>
        public MeasureDoublet(IMeasure<Q1> measure1, IMeasure<Q2> measure2)
        {
            this.x = Q1Factory.New(measure1.StandardAmount);
            this.y = Q2Factory.New(measure2.StandardAmount);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="amount1">Amount in standard units of the first measure object</param>
        /// <param name="amount2">Amount in standard units of the second measure object</param>
        public MeasureDoublet(double amount1, double amount2)
        {
            this.x = Q1Factory.New(amount1);
            this.y = Q2Factory.New(amount2);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="amount1">Amount in standard units of the first measure object</param>
        /// <param name="amount2">Amount in standard units of the second measure object</param>
        public MeasureDoublet(float amount1, float amount2)
        {
            this.x = Q1Factory.New(amount1);
            this.y = Q2Factory.New(amount2);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="amount1">Amount in standard units of the first measure object</param>
        /// <param name="amount2">Amount in standard units of the second measure object</param>
        public MeasureDoublet(decimal amount1, decimal amount2)
        {
            this.x = Q1Factory.New(amount1);
            this.y = Q2Factory.New(amount2);
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the first measure in the measure pair
        /// </summary>
        public Q1 X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets the second measure in the measure pair
        /// </summary>
        public Q2 Y
        {
            get
            {
                return this.y;
            }
        }

        #endregion

        #region Implementation of IMeasure<Q1,Q2>

        /// <summary>
        /// Gets the first measure in the measure pair
        /// </summary>
        IMeasure<Q1> IMeasureDoublet<Q1, Q2>.X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets the second measure in the measure pair
        /// </summary>
        IMeasure<Q2> IMeasureDoublet<Q1, Q2>.Y
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
        /// <param name="lhs">First measure doublet</param>
        /// <param name="rhs">Second measure doublet</param>
        /// <returns>Sum of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator +(MeasureDoublet<Q1, Q2> lhs, MeasureDoublet<Q1, Q2> rhs)
        {
            return new MeasureDoublet<Q1, Q2>(lhs.x.Amount + rhs.x.Amount, lhs.y.Amount + rhs.y.Amount);
        }

        /// <summary>
        /// Adds two measure doublets
        /// </summary>
        /// <param name="lhs">First measure doublet</param>
        /// <param name="rhs">Second measure doublet</param>
        /// <returns>Sum of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator +(MeasureDoublet<Q1, Q2> lhs, IMeasureDoublet<Q1, Q2> rhs)
        {
            return new MeasureDoublet<Q1, Q2>(
                lhs.x.Amount + rhs.X.StandardAmount,
                lhs.y.Amount + rhs.Y.StandardAmount);
        }

        /// <summary>
        /// Subtracts two measure doublets
        /// </summary>
        /// <param name="lhs">First measure doublet</param>
        /// <param name="rhs">Second measure doublet</param>
        /// <returns>Difference of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator -(MeasureDoublet<Q1, Q2> lhs, MeasureDoublet<Q1, Q2> rhs)
        {
            return new MeasureDoublet<Q1, Q2>(lhs.x.Amount - rhs.x.Amount, lhs.y.Amount - rhs.y.Amount);
        }

        /// <summary>
        /// Subtracts two measure doublets
        /// </summary>
        /// <param name="lhs">First measure doublet</param>
        /// <param name="rhs">Second measure doublet</param>
        /// <returns>Difference of the specified measure doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator -(MeasureDoublet<Q1, Q2> lhs, IMeasureDoublet<Q1, Q2> rhs)
        {
            return new MeasureDoublet<Q1, Q2>(
                lhs.x.Amount - rhs.X.StandardAmount,
                lhs.y.Amount - rhs.Y.StandardAmount);
        }

        /// <summary>
        /// Multiplies one measure doublet with a number doublet
        /// </summary>
        /// <param name="lhs">Measure doublet</param>
        /// <param name="rhs">Number doublet</param>
        /// <returns>Product of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator *(MeasureDoublet<Q1, Q2> lhs, MeasureDoublet<Number, Number> rhs
            )
        {
            return new MeasureDoublet<Q1, Q2>(lhs.x.Amount * rhs.x.Amount, lhs.y.Amount * rhs.y.Amount);
        }

        /// <summary>
        /// Multiplies one measure doublet with a number doublet
        /// </summary>
        /// <param name="lhs">Measure doublet</param>
        /// <param name="rhs">Number doublet</param>
        /// <returns>Product of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator *(
            MeasureDoublet<Q1, Q2> lhs,
            IMeasureDoublet<Number, Number> rhs)
        {
            return new MeasureDoublet<Q1, Q2>(
                lhs.x.Amount * rhs.X.StandardAmount,
                lhs.y.Amount * rhs.Y.StandardAmount);
        }

        /// <summary>
        /// Divides one measure doublet with a number doublet
        /// </summary>
        /// <param name="lhs">Measure doublet</param>
        /// <param name="rhs">Number doublet</param>
        /// <returns>Quotient of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator /(MeasureDoublet<Q1, Q2> lhs, MeasureDoublet<Number, Number> rhs
            )
        {
            return new MeasureDoublet<Q1, Q2>(lhs.x.Amount / rhs.x.Amount, lhs.y.Amount / rhs.y.Amount);
        }

        /// <summary>
        /// Divides one measure doublet with a number doublet
        /// </summary>
        /// <param name="lhs">Measure doublet</param>
        /// <param name="rhs">Number doublet</param>
        /// <returns>Quotient of the measure and number doublets</returns>
        public static MeasureDoublet<Q1, Q2> operator /(
            MeasureDoublet<Q1, Q2> lhs,
            IMeasureDoublet<Number, Number> rhs)
        {
            return new MeasureDoublet<Q1, Q2>(
                lhs.x.Amount / rhs.X.StandardAmount,
                lhs.y.Amount / rhs.Y.StandardAmount);
        }

        /// <summary>
        /// Divides one measure doublet with another measure doublet of the same quantities
        /// </summary>
        /// <param name="lhs">Numerator measure doublet</param>
        /// <param name="rhs">Denominator measure doublet</param>
        /// <returns>Quotient of the measure doublets as a number doublet</returns>
        public static MeasureDoublet<Number, Number> operator /(MeasureDoublet<Q1, Q2> lhs, MeasureDoublet<Q1, Q2> rhs
            )
        {
            return new MeasureDoublet<Number, Number>(lhs.x.Amount / rhs.x.Amount, lhs.y.Amount / rhs.y.Amount);
        }

        /// <summary>
        /// Divides one measure doublet with another measure doublet of the same quantities
        /// </summary>
        /// <param name="lhs">Numerator measure doublet</param>
        /// <param name="rhs">Denominator measure doublet</param>
        /// <returns>Quotient of the measure doublets as a number doublet</returns>
        public static MeasureDoublet<Number, Number> operator /(
            MeasureDoublet<Q1, Q2> lhs,
            IMeasureDoublet<Q1, Q2> rhs)
        {
            return new MeasureDoublet<Number, Number>(
                lhs.x.Amount / rhs.X.StandardAmount,
                lhs.y.Amount / rhs.Y.StandardAmount);
        }

        #endregion
    }
}