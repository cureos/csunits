// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measures.Quantities;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
	/// <summary>
	/// Representation of a pair of measures, given in the standard units of the respective quantities
	/// </summary>
	/// <typeparam name="Q1">Quantity type of the first measure</typeparam>
	/// <typeparam name="Q2">Quantity type of the second measure</typeparam>
	public struct StandardMeasureDoublet<Q1, Q2> : IMeasureDoublet<Q1, Q2> where Q1 : struct, IQuantity<Q1> where Q2 : struct, IQuantity<Q2>
	{
		#region MEMBER VARIABLES

		private readonly StandardMeasure<Q1> mX;
		private readonly StandardMeasure<Q2> mY;

		#endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Initializes a pair of standard measures
		/// </summary>
		/// <param name="iMeasureDoublet">Pair of measures in arbitrary unit</param>
		public StandardMeasureDoublet(IMeasureDoublet<Q1, Q2> iMeasureDoublet)
			: this(iMeasureDoublet.X, iMeasureDoublet.Y)
		{
		}

		/// <summary>
		/// Initializes a pair of standard measures from two standard measure objects
		/// </summary>
		/// <param name="iX">First measure object</param>
		/// <param name="iY">Second measure object</param>
		public StandardMeasureDoublet(StandardMeasure<Q1> iX, StandardMeasure<Q2> iY)
		{
			mX = iX;
			mY = iY;
		}

		/// <summary>
		/// Initializes a pair of standard measures
		/// </summary>
		/// <param name="iMeasure1">First measure object</param>
		/// <param name="iMeasure2">Second measure object</param>
		public StandardMeasureDoublet(IMeasure<Q1> iMeasure1, IMeasure<Q2> iMeasure2)
		{
			mX = new StandardMeasure<Q1>(iMeasure1);
			mY = new StandardMeasure<Q2>(iMeasure2);
		}

		/// <summary>
		/// Initializes a pair of standard measures from a pair of standard unit amounts
		/// </summary>
		/// <param name="iAmount1">Amount in standard units of the first measure object</param>
		/// <param name="iAmount2">Amount in standard units of the second measure object</param>
		public StandardMeasureDoublet(double iAmount1, double iAmount2)
		{
#if DOUBLE
			mX = new StandardMeasure<Q1>(iAmount1);
			mY = new StandardMeasure<Q2>(iAmount2);
#else
			mX = new StandardMeasure<Q1>((AmountType)iAmount1);
			mY = new StandardMeasure<Q2>((AmountType)iAmount2);
#endif
		}

		/// <summary>
		/// Initializes a pair of standard measures from a pair of standard unit amounts
		/// </summary>
		/// <param name="iAmount1">Amount in standard units of the first measure object</param>
		/// <param name="iAmount2">Amount in standard units of the second measure object</param>
		public StandardMeasureDoublet(float iAmount1, float iAmount2)
		{
#if !DECIMAL
			mX = new StandardMeasure<Q1>(iAmount1);
			mY = new StandardMeasure<Q2>(iAmount2);
#else
			mX = new StandardMeasure<Q1>((AmountType)iAmount1);
			mY = new StandardMeasure<Q2>((AmountType)iAmount2);
#endif
		}

		/// <summary>
		/// Initializes a pair of standard measures from a pair of standard unit amounts
		/// </summary>
		/// <param name="iAmount1">Amount in standard units of the first measure object</param>
		/// <param name="iAmount2">Amount in standard units of the second measure object</param>
		public StandardMeasureDoublet(decimal iAmount1, decimal iAmount2)
		{
#if DECIMAL
			mX = new StandardMeasure<Q1>(iAmount1);
			mY = new StandardMeasure<Q2>(iAmount2);
#else
			mX = new StandardMeasure<Q1>((AmountType)iAmount1);
			mY = new StandardMeasure<Q2>((AmountType)iAmount2);
#endif
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
        public static StandardMeasureDoublet<Q1, Q2> operator+ (StandardMeasureDoublet<Q1, Q2> iLhs, StandardMeasureDoublet<Q1, Q2> iRhs)
        {
            return new StandardMeasureDoublet<Q1, Q2>(iLhs.mX + iRhs.mX, iLhs.mY + iRhs.mY);
        }

        /// <summary>
        /// Adds two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Sum of the specified measure doublets</returns>
        public static StandardMeasureDoublet<Q1, Q2> operator +(StandardMeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Q1, Q2> iRhs)
        {
            return new StandardMeasureDoublet<Q1, Q2>(iLhs.mX.Amount + iRhs.X.StandardAmount,
                                                      iLhs.mY.Amount + iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Subtracts two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Difference of the specified measure doublets</returns>
        public static StandardMeasureDoublet<Q1, Q2> operator -(StandardMeasureDoublet<Q1, Q2> iLhs, StandardMeasureDoublet<Q1, Q2> iRhs)
        {
            return new StandardMeasureDoublet<Q1, Q2>(iLhs.mX - iRhs.mX, iLhs.mY - iRhs.mY);
        }

        /// <summary>
        /// Subtracts two measure doublets
        /// </summary>
        /// <param name="iLhs">First measure doublet</param>
        /// <param name="iRhs">Second measure doublet</param>
        /// <returns>Difference of the specified measure doublets</returns>
        public static StandardMeasureDoublet<Q1, Q2> operator -(StandardMeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Q1, Q2> iRhs)
        {
            return new StandardMeasureDoublet<Q1, Q2>(iLhs.mX.Amount - iRhs.X.StandardAmount,
                                                      iLhs.mY.Amount - iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Multiplies one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Product of the measure and number doublets</returns>
        public static StandardMeasureDoublet<Q1, Q2> operator *(StandardMeasureDoublet<Q1, Q2> iLhs, StandardMeasureDoublet<Number, Number> iRhs)
        {
            return new StandardMeasureDoublet<Q1, Q2>(iLhs.mX.Amount * iRhs.mX.Amount, iLhs.mY.Amount * iRhs.mY.Amount);
        }

        /// <summary>
        /// Multiplies one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Product of the measure and number doublets</returns>
        public static StandardMeasureDoublet<Q1, Q2> operator *(StandardMeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Number, Number> iRhs)
        {
            return new StandardMeasureDoublet<Q1, Q2>(iLhs.mX.Amount * iRhs.X.StandardAmount, iLhs.mY.Amount * iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Divides one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Quotient of the measure and number doublets</returns>
        public static StandardMeasureDoublet<Q1, Q2> operator /(StandardMeasureDoublet<Q1, Q2> iLhs, StandardMeasureDoublet<Number, Number> iRhs)
        {
            return new StandardMeasureDoublet<Q1, Q2>(iLhs.mX.Amount / iRhs.mX.Amount, iLhs.mY.Amount / iRhs.mY.Amount);
        }

        /// <summary>
        /// Divides one measure doublet with a number doublet
        /// </summary>
        /// <param name="iLhs">Measure doublet</param>
        /// <param name="iRhs">Number doublet</param>
        /// <returns>Quotient of the measure and number doublets</returns>
        public static StandardMeasureDoublet<Q1, Q2> operator /(StandardMeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Number, Number> iRhs)
        {
            return new StandardMeasureDoublet<Q1, Q2>(iLhs.mX.Amount / iRhs.X.StandardAmount, iLhs.mY.Amount / iRhs.Y.StandardAmount);
        }

        /// <summary>
        /// Divides one measure doublet with another measure doublet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure doublet</param>
        /// <param name="iRhs">Denominator measure doublet</param>
        /// <returns>Quotient of the measure doublets as a number doublet</returns>
        public static StandardMeasureDoublet<Number, Number> operator /(StandardMeasureDoublet<Q1, Q2> iLhs, StandardMeasureDoublet<Q1, Q2> iRhs)
        {
            return new StandardMeasureDoublet<Number, Number>(iLhs.mX / iRhs.mX, iLhs.mY / iRhs.mY);
        }

        /// <summary>
        /// Divides one measure doublet with another measure doublet of the same quantities
        /// </summary>
        /// <param name="iLhs">Numerator measure doublet</param>
        /// <param name="iRhs">Denominator measure doublet</param>
        /// <returns>Quotient of the measure doublets as a number doublet</returns>
        public static StandardMeasureDoublet<Number, Number> operator /(StandardMeasureDoublet<Q1, Q2> iLhs, IMeasureDoublet<Q1, Q2> iRhs)
        {
            return new StandardMeasureDoublet<Number, Number>(iLhs.mX.Amount / iRhs.X.StandardAmount,
                                                              iLhs.mY.Amount / iRhs.Y.StandardAmount);
        }

        #endregion
    }
}