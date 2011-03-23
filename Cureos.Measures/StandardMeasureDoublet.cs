// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

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

		private readonly StandardMeasure<Q1> mFirst;
		private readonly StandardMeasure<Q2> mSecond;

		#endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Initializes a pair of standard measures
		/// </summary>
		/// <param name="iMeasureDoublet">Pair of measures in arbitrary unit</param>
		public StandardMeasureDoublet(IMeasureDoublet<Q1, Q2> iMeasureDoublet)
			: this(iMeasureDoublet.First, iMeasureDoublet.Second)
		{
		}

		/// <summary>
		/// Initializes a pair of standard measures from two standard measure objects
		/// </summary>
		/// <param name="iFirst">First measure object</param>
		/// <param name="iSecond">Second measure object</param>
		public StandardMeasureDoublet(StandardMeasure<Q1> iFirst, StandardMeasure<Q2> iSecond)
		{
			mFirst = iFirst;
			mSecond = iSecond;
		}

		/// <summary>
		/// Initializes a pair of standard measures
		/// </summary>
		/// <param name="iMeasure1">First measure object</param>
		/// <param name="iMeasure2">Second measure object</param>
		public StandardMeasureDoublet(IMeasure<Q1> iMeasure1, IMeasure<Q2> iMeasure2)
		{
			mFirst = new StandardMeasure<Q1>(iMeasure1);
			mSecond = new StandardMeasure<Q2>(iMeasure2);
		}

		/// <summary>
		/// Initializes a pair of standard measures from a pair of standard unit amounts
		/// </summary>
		/// <param name="iAmount1">Amount in standard units of the first measure object</param>
		/// <param name="iAmount2">Amount in standard units of the second measure object</param>
		public StandardMeasureDoublet(double iAmount1, double iAmount2)
		{
#if DOUBLE
			mFirst = new StandardMeasure<Q1>(iAmount1);
			mSecond = new StandardMeasure<Q2>(iAmount2);
#else
			mMeasure1 = new StandardMeasure<Q1>((AmountType)iAmount1);
			mMeasure2 = new StandardMeasure<Q2>((AmountType)iAmount2);
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
			mFirst = new StandardMeasure<Q1>(iAmount1);
			mSecond = new StandardMeasure<Q2>(iAmount2);
#else
			mMeasure1 = new StandardMeasure<Q1>((AmountType)iAmount1);
			mMeasure2 = new StandardMeasure<Q2>((AmountType)iAmount2);
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
			mMeasure1 = new StandardMeasure<Q1>(iAmount1);
			mMeasure2 = new StandardMeasure<Q2>(iAmount2);
#else
			mFirst = new StandardMeasure<Q1>((Double)iAmount1);
			mSecond = new StandardMeasure<Q2>((Double)iAmount2);
#endif
		}

		#endregion

		#region Implementation of IMeasure<Q1,Q2>

		/// <summary>
		/// Gets the first measure in the measure pair
		/// </summary>
		public IMeasure<Q1> First
		{
			get { return mFirst; }
		}

		/// <summary>
		/// Gets the second measure in the measure pair
		/// </summary>
		public IMeasure<Q2> Second
		{
			get { return mSecond; }
		}

		#endregion
	}
}