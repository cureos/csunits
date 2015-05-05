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
    /// Representation of a triplet of measures, given in the standard units of the respective quantities
    /// </summary>
    /// <typeparam name="Q1">Quantity type of the first measure</typeparam>
    /// <typeparam name="Q2">Quantity type of the second measure</typeparam>
    /// <typeparam name="Q3">Quantity type of the third measure</typeparam>
    public struct MeasureTriplet<Q1, Q2, Q3> : IMeasureTriplet<Q1, Q2, Q3>
        where Q1 : struct, IQuantity<Q1>, IMeasure<Q1>
        where Q2 : struct, IQuantity<Q2>, IMeasure<Q2>
        where Q3 : struct, IQuantity<Q3>, IMeasure<Q3>
    {
        #region MEMBER VARIABLES

        private static readonly IMeasureFactory<Q1> Q1Factory = new Q1().Factory;

        private static readonly IMeasureFactory<Q2> Q2Factory = new Q2().Factory;

        private static readonly IMeasureFactory<Q3> Q3Factory = new Q3().Factory;

        private readonly Q1 x;

        private readonly Q2 y;

        private readonly Q3 z;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a triplet of standard measures
        /// </summary>
        /// <param name="iMeasureTriplet">Triplet of measures in arbitrary unit</param>
        public MeasureTriplet(IMeasureTriplet<Q1, Q2, Q3> iMeasureTriplet)
            : this(iMeasureTriplet.X, iMeasureTriplet.Y, iMeasureTriplet.Z)
        {
        }

        /// <summary>
        /// Initializes a triplet of standard measures
        /// </summary>
        /// <param name="iMeasure1">First measure object</param>
        /// <param name="iMeasure2">Second measure object</param>
        /// <param name="iMeasure3">Third measure object</param>
        public MeasureTriplet(IMeasure<Q1> iMeasure1, IMeasure<Q2> iMeasure2, IMeasure<Q3> iMeasure3)
        {
            this.x = Q1Factory.New(iMeasure1);
            this.y = Q2Factory.New(iMeasure2);
            this.z = Q3Factory.New(iMeasure3);
        }

        /// <summary>
        /// Initializes a triplet of standard measures from a triplet of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        /// <param name="iAmount3">Amount in standard units of the third measure object</param>
        public MeasureTriplet(double iAmount1, double iAmount2, double iAmount3)
        {
            this.x = Q1Factory.New(iAmount1);
            this.y = Q2Factory.New(iAmount2);
            this.z = Q3Factory.New(iAmount3);
        }

        /// <summary>
        /// Initializes a triplet of standard measures from a triplet of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        /// <param name="iAmount3">Amount in standard units of the third measure object</param>
        public MeasureTriplet(float iAmount1, float iAmount2, float iAmount3)
        {
            this.x = Q1Factory.New(iAmount1);
            this.y = Q2Factory.New(iAmount2);
            this.z = Q3Factory.New(iAmount3);
        }

        /// <summary>
        /// Initializes a pair of standard measures from a pair of standard unit amounts
        /// </summary>
        /// <param name="iAmount1">Amount in standard units of the first measure object</param>
        /// <param name="iAmount2">Amount in standard units of the second measure object</param>
        /// <param name="iAmount3">Amount in standard units of the third measure object</param>
        public MeasureTriplet(decimal iAmount1, decimal iAmount2, decimal iAmount3)
        {
            this.x = Q1Factory.New(iAmount1);
            this.y = Q2Factory.New(iAmount2);
            this.z = Q3Factory.New(iAmount3);
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the first measure in the measure triplet
        /// </summary>
        public Q1 X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets the second measure in the measure triplet
        /// </summary>
        public Q2 Y
        {
            get
            {
                return this.y;
            }
        }

        /// <summary>
        /// Gets the third measure in the measure triplet
        /// </summary>
        public Q3 Z
        {
            get
            {
                return this.z;
            }
        }

        #endregion

        #region Implementation of IMeasure<Q1,Q2,Q3>

        /// <summary>
        /// Gets the first measure in the measure triplet
        /// </summary>
        IMeasure<Q1> IMeasureTriplet<Q1, Q2, Q3>.X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Gets the second measure in the measure triplet
        /// </summary>
        IMeasure<Q2> IMeasureTriplet<Q1, Q2, Q3>.Y
        {
            get
            {
                return this.y;
            }
        }

        /// <summary>
        /// Gets the third measure in the measure triplet
        /// </summary>
        IMeasure<Q3> IMeasureTriplet<Q1, Q2, Q3>.Z
        {
            get
            {
                return this.z;
            }
        }

        #endregion

        #region OPERATORS

        /// <summary>
        /// Adds two measure triplets
        /// </summary>
        /// <param name="iLhs">First measure triplet</param>
        /// <param name="iRhs">Second measure triplet</param>
        /// <returns>Sum of the specified measure triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator +(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.x.StandardAmount + iRhs.x.StandardAmount,
                iLhs.y.StandardAmount + iRhs.y.StandardAmount,
                iLhs.z.StandardAmount + iRhs.z.StandardAmount);
        }

        /// <summary>
        /// Adds two measure triplets
        /// </summary>
        /// <param name="iLhs">First measure triplet</param>
        /// <param name="iRhs">Second measure triplet</param>
        /// <returns>Sum of the specified measure triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator +(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            IMeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.x.Amount + iRhs.X.StandardAmount,
                iLhs.y.Amount + iRhs.Y.StandardAmount,
                iLhs.z.Amount + iRhs.Z.StandardAmount);
        }

        /// <summary>
        /// Subtracts two measure triplets
        /// </summary>
        /// <param name="iLhs">First measure triplet</param>
        /// <param name="iRhs">Second measure triplet</param>
        /// <returns>Difference of the specified measure triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator -(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.x.StandardAmount - iRhs.x.StandardAmount,
                iLhs.y.StandardAmount - iRhs.y.StandardAmount,
                iLhs.z.StandardAmount - iRhs.z.StandardAmount);
        }

        /// <summary>
        /// Subtracts two measure triplets
        /// </summary>
        /// <param name="iLhs">First measure triplet</param>
        /// <param name="iRhs">Second measure triplet</param>
        /// <returns>Difference of the specified measure triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator -(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            IMeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.x.Amount - iRhs.X.StandardAmount,
                iLhs.y.Amount - iRhs.Y.StandardAmount,
                iLhs.z.Amount - iRhs.Z.StandardAmount);
        }

        /// <summary>
        /// Apply multiplicative factor on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Multiplicative factor</param>
        /// <param name="iRhs">Measure triplet</param>
        /// <returns>Product of the measure triplet and the multiplicative factor</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(AmountType iLhs, MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs * iRhs.x.Amount, iLhs * iRhs.y.Amount, iLhs * iRhs.z.Amount);
        }

        /// <summary>
        /// Apply multiplicative factor on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Multiplicative factor</param>
        /// <param name="iRhs">Measure triplet</param>
        /// <returns>Product of the measure triplet and the multiplicative factor</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(Number iLhs, MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.Amount * iRhs.x.Amount,
                iLhs.Amount * iRhs.y.Amount,
                iLhs.Amount * iRhs.z.Amount);
        }

        /// <summary>
        /// Apply multiplicative factor on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Multiplicative factor</param>
        /// <returns>Product of the measure triplet and the multiplicative factor</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(MeasureTriplet<Q1, Q2, Q3> iLhs, AmountType iRhs)
        {
            return iRhs * iLhs;
        }

        /// <summary>
        /// Apply multiplicative factor on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Multiplicative factor</param>
        /// <returns>Product of the measure triplet and the multiplicative factor</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(MeasureTriplet<Q1, Q2, Q3> iLhs, Number iRhs)
        {
            return iRhs * iLhs;
        }

        /// <summary>
        /// Multiplies one measure triplet with a number triplet
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Number triplet</param>
        /// <returns>Product of the measure and number triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            MeasureTriplet<Number, Number, Number> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.x.Amount * iRhs.x.Amount,
                iLhs.y.Amount * iRhs.y.Amount,
                iLhs.z.Amount * iRhs.z.Amount);
        }

        /// <summary>
        /// Multiplies one measure triplet with a number triplet
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Number triplet</param>
        /// <returns>Product of the measure and number triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator *(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            IMeasureTriplet<Number, Number, Number> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.x.Amount * iRhs.X.StandardAmount,
                iLhs.y.Amount * iRhs.Y.StandardAmount,
                iLhs.z.Amount * iRhs.Z.StandardAmount);
        }

        /// <summary>
        /// Apply scalar denominator on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Scalar denominator</param>
        /// <returns>Quotient of the measure triplet and the scalar denominator</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator /(MeasureTriplet<Q1, Q2, Q3> iLhs, AmountType iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(iLhs.x.Amount / iRhs, iLhs.y.Amount / iRhs, iLhs.z.Amount / iRhs);
        }

        /// <summary>
        /// Apply scalar denominator on the measure triplet 
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Scalar denominator</param>
        /// <returns>Quotient of the measure triplet and the scalar denominator</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator /(MeasureTriplet<Q1, Q2, Q3> iLhs, Number iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.x.Amount / iRhs.Amount,
                iLhs.y.Amount / iRhs.Amount,
                iLhs.z.Amount / iRhs.Amount);
        }

        /// <summary>
        /// Divides one measure triplet with a number triplet
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Number triplet</param>
        /// <returns>Quotient of the measure and number triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator /(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            MeasureTriplet<Number, Number, Number> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.x.Amount / iRhs.x.Amount,
                iLhs.y.Amount / iRhs.y.Amount,
                iLhs.z.Amount / iRhs.z.Amount);
        }

        /// <summary>
        /// Divides one measure triplet with a number triplet
        /// </summary>
        /// <param name="iLhs">Measure triplet</param>
        /// <param name="iRhs">Number triplet</param>
        /// <returns>Quotient of the measure and number triplets</returns>
        public static MeasureTriplet<Q1, Q2, Q3> operator /(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            IMeasureTriplet<Number, Number, Number> iRhs)
        {
            return new MeasureTriplet<Q1, Q2, Q3>(
                iLhs.x.Amount / iRhs.X.StandardAmount,
                iLhs.y.Amount / iRhs.Y.StandardAmount,
                iLhs.z.Amount / iRhs.Z.StandardAmount);
        }

        /// <summary>
        /// Divides one measure triplet with another measure triplet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure triplet</param>
        /// <param name="iRhs">Denominator measure triplet</param>
        /// <returns>Quotient of the measure triplets as a number triplet</returns>
        public static MeasureTriplet<Number, Number, Number> operator /(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            MeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Number, Number, Number>(
                iLhs.x.StandardAmount / iRhs.x.StandardAmount,
                iLhs.y.StandardAmount / iRhs.y.StandardAmount,
                iLhs.z.StandardAmount / iRhs.z.StandardAmount);
        }

        /// <summary>
        /// Divides one measure triplet with another measure triplet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure triplet</param>
        /// <param name="iRhs">Denominator measure triplet</param>
        /// <returns>Quotient of the measure triplets as a number triplet</returns>
        public static MeasureTriplet<Number, Number, Number> operator /(
            MeasureTriplet<Q1, Q2, Q3> iLhs,
            IMeasureTriplet<Q1, Q2, Q3> iRhs)
        {
            return new MeasureTriplet<Number, Number, Number>(
                iLhs.x.Amount / iRhs.X.StandardAmount,
                iLhs.y.Amount / iRhs.Y.StandardAmount,
                iLhs.z.Amount / iRhs.Z.StandardAmount);
        }

        #endregion
    }
}