// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
	public struct Measure : IMeasure
	{
		#region MEMBER VARIABLES

		private readonly AmountType mAmount;
		private readonly Unit mUnit;

		#endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Initializes a measure object
		/// </summary>
		/// <param name="iAmount">Measured amount in double precision</param>
		/// <param name="iUnit">Unit of measure</param>
		public Measure(double iAmount, Unit iUnit)
		{
			mAmount =
#if !DOUBLE
				(AmountType)
#endif
				iAmount;
			mUnit = iUnit;
		}

		/// <summary>
		/// Initializes a measure object
		/// </summary>
		/// <param name="iAmount">Measured amount in single precision</param>
		/// <param name="iUnit">Unit of measure</param>
		public Measure(float iAmount, Unit iUnit)
		{
			mAmount =
#if !SINGLE
				(AmountType)
#endif
				iAmount;
			mUnit = iUnit;
		}

		/// <summary>
		/// Initializes a measure object
		/// </summary>
		/// <param name="iAmount">Measured amount in decimal format</param>
		/// <param name="iUnit">Unit of measure</param>
		public Measure(decimal iAmount, Unit iUnit)
		{
			mAmount =
#if !DECIMAL
				(AmountType)
#endif
				iAmount;
			mUnit = iUnit;
		}

		#endregion

		#region PROPERTIES

		/// <summary>
		/// Gets the measured amount in the <paramref name="MeasuredUnit">current unit of measure</paramref>
		/// </summary>
		public AmountType Amount
		{
			get { return mAmount; }
		}

		/// <summary>
		/// Gets the measured amount in the <paramref name="ReferenceUnit">reference unit of measure</paramref>
		/// </summary>
		public AmountType ReferenceUnitAmount
		{
			get { return mUnit.GetReferenceUnitAmount(mAmount); }
		}

		/// <summary>
		/// Gets the measured quantity
		/// </summary>
		public Quantity MeasuredQuantity
		{
			get { return mUnit.GetQuantity(); }
		}

		/// <summary>
		/// Gets the unit of measure
		/// </summary>
		public Unit MeasuredUnit
		{
			get { return mUnit; }
		}

		/// <summary>
		/// Gets the reference unit of measure for the <paramref name="MeasuredQuantity">measured quantity</paramref>
		/// </summary>
		public Unit ReferenceUnit
		{
			get { return MeasuredQuantity.GetReferenceUnit(); }
		}
		#endregion

		#region METHODS

		/// <summary>
		/// Gets the amount of the measure in the <paramref name="iUnit">requested unit</paramref> of the same quantity
		/// </summary>
		/// <param name="iUnit">Unit in which the measured amount should be specified</param>
		/// <returns>The measured amount in the <paramref name="iUnit">requested unit</paramref></returns>
		/// <exception cref="InvalidOperationException">Is thrown if the specified unit is of another quantity</exception>
		public AmountType GetAmount(Unit iUnit)
		{
			return iUnit.GetAmount(this);
		}
		
		/// <summary>
		/// Gets a new measure object with the amount converted to the <paramref name="iUnit">specified unit</paramref>
		/// </summary>
		/// <param name="iUnit">Unit in which the new measure should be specified</param>
		/// <returns>New measure object with the amount converted to the <paramref name="iUnit">specified unit</paramref></returns>
		public Measure GetMeasure(Unit iUnit)
		{
			return new Measure(GetAmount(iUnit), iUnit);
		}

		/// <summary>
		/// Gets the measure represented as a string
		/// </summary>
		/// <returns>The measure description</returns>
		public override string ToString()
		{
			return String.Format("{0} {1}", mAmount, mUnit.GetSymbol()).Trim();
		}

		#endregion
		
		#region OPERATORS

		/// <summary>
		/// Adds two measure objects provided the measured quantities are equal
		/// </summary>
		/// <param name="iLhs">First measure term</param>
		/// <param name="iRhs">Second measure term</param>
		/// <returns>Sum of the two measure objects in the unit of the <paramref name="iLhs">left-hand side measure</paramref></returns>
		/// <exception cref="InvalidOperationException">Is thrown if the measured quanitites are not equal</exception>
		public static Measure operator +(Measure iLhs, Measure iRhs)
		{
			return iLhs.mUnit == iRhs.mUnit ?
				new Measure(iLhs.mAmount + iRhs.mAmount, iLhs.mUnit) :
				new Measure(iLhs.mAmount + iLhs.mUnit.GetAmount(iRhs), iLhs.mUnit);
		}

		/// <summary>
		/// Subtract two measure objects of the same unit
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object</param>
		/// <returns>Difference of the measure objects</returns>
		public static Measure operator -(Measure iLhs, Measure iRhs)
		{
			return iLhs.mUnit == iRhs.mUnit ?
				new Measure(iLhs.mAmount - iRhs.mAmount, iLhs.mUnit) :
				new Measure(iLhs.mAmount - iLhs.mUnit.GetAmount(iRhs), iLhs.mUnit);
		}

		/// <summary>
		/// Multiply a scalar and a measure object
		/// </summary>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <param name="iMeasure">Measure object</param>
		/// <returns>Product of the scalar and the measure object</returns>
		public static Measure operator *(AmountType iScalar, Measure iMeasure)
		{
			return new Measure(iScalar * iMeasure.mAmount, iMeasure.mUnit);
		}

		/// <summary>
		/// Multiply a measure object and a scalar
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Product of the measure object and the scalar</returns>
		public static Measure operator *(Measure iMeasure, AmountType iScalar)
		{
			return new Measure(iMeasure.mAmount * iScalar, iMeasure.mUnit);
		}

		/// <summary>
		/// Divide a measure object with a scalar
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Quotient of the measure object and the scalar</returns>
		public static Measure operator /(Measure iMeasure, AmountType iScalar)
		{
			checked
			{
				return new Measure(iMeasure.mAmount / iScalar, iMeasure.mUnit);
			}
		}

		/// <summary>
		/// Divide two measure objects of the same unit
		/// </summary>
		/// <param name="iNumerator">Numerator measure</param>
		/// <param name="iDenominator">Denominator measure</param>
		/// <returns>Scalar quotient of the two measure objects</returns>
		public static AmountType operator /(Measure iNumerator, Measure iDenominator)
		{
			checked
			{
				return iNumerator.mUnit == iDenominator.mUnit ?
					iNumerator.mAmount / iDenominator.mAmount :
					iNumerator.mAmount / iNumerator.mUnit.GetAmount(iDenominator);
			}
		}

		/// <summary>
		/// Less than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(Measure iLhs, Measure iRhs)
		{
			return iLhs.mUnit == iRhs.mUnit ?
				iLhs.mAmount < iRhs.mAmount :
				iLhs.mAmount < iLhs.mUnit.GetAmount(iRhs);
		}

		/// <summary>
		/// Greater than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(Measure iLhs, Measure iRhs)
		{
			return iLhs.mUnit == iRhs.mUnit ?
				iLhs.mAmount > iRhs.mAmount :
				iLhs.mAmount > iLhs.mUnit.GetAmount(iRhs);
		}

		/// <summary>
		/// Less than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(Measure iLhs, Measure iRhs)
		{
			return iLhs.mUnit == iRhs.mUnit ?
				iLhs.mAmount <= iRhs.mAmount :
				iLhs.mAmount <= iLhs.mUnit.GetAmount(iRhs);
		}

		/// <summary>
		/// Greater than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(Measure iLhs, Measure iRhs)
		{
			return iLhs.mUnit == iRhs.mUnit ?
				iLhs.mAmount >= iRhs.mAmount :
				iLhs.mAmount >= iLhs.mUnit.GetAmount(iRhs);
		}

		/// <summary>
		/// Equality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(Measure iLhs, Measure iRhs)
		{
			return iLhs.mUnit == iRhs.mUnit ?
				iLhs.mAmount == iRhs.mAmount :
				iLhs.mAmount == iLhs.mUnit.GetAmount(iRhs);
		}

		/// <summary>
		/// Inquality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(Measure iLhs, Measure iRhs)
		{
			return iLhs.mUnit == iRhs.mUnit ?
				iLhs.mAmount != iRhs.mAmount :
				iLhs.mAmount != iLhs.mUnit.GetAmount(iRhs);
		}

		#endregion
	}
}