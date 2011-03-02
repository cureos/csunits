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
	public struct Measure : IMeasure, IEquatable<Measure>, IComparable<Measure>
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
		/// Gets the measured amount in the <see cref="MeasuredUnit">current unit of measure</see>
		/// </summary>
		public AmountType MeasuredAmount
		{
			get { return mAmount; }
		}

		/// <summary>
		/// Gets the measured amount in the <see cref="ReferenceUnit">reference unit of measure</see>
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
		/// Gets the reference unit of measure for the <see cref="MeasuredQuantity">measured quantity</see>
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
		/// Returns a string description of the measure in the given <paramref name="iUnit">physical unit</paramref>
		/// </summary>
		/// <param name="iUnit">Unit in which the measure should be presented</param>
		/// <returns>String representation of the measure in the given <paramref name="iUnit">physical unit</paramref></returns>
		/// <exception cref="InvalidOperationException">if the <paramref name="iUnit">specified unit</paramref> is of
		/// a different quantity than the <see cref="MeasuredUnit">measured unit </see></exception>
		public string ToString(Unit iUnit)
		{
			return String.Format("{0} {1}", GetAmount(iUnit), iUnit.GetSymbol()).Trim();
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
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(Measure other)
		{
			return this == other;
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: 
		/// Value               Meaning 
		/// Less than zero      This object is less than the <paramref name="other"/> parameter.
		/// Zero                This object is equal to <paramref name="other"/>. 
		/// Greater than zero   This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <exception cref="InvalidOperationException">if the quantity of the other measure is not the same as the quantity
		/// of this object</exception>
		public int CompareTo(Measure other)
		{
			return MeasuredUnit == other.MeasuredUnit ?
				MeasuredAmount.CompareTo(other.MeasuredAmount) :
				MeasuredAmount.CompareTo(MeasuredUnit.GetAmount(other));
		}

		/// <summary>
		/// Compares whether this measure object is equal to the specified object
		/// </summary>
		/// <param name="obj">Object to compare with this measure object</param>
		/// <returns>true if <paramref name="obj"/> is a Measure object and the amount in common units is equivalent</returns>
		public override bool Equals(object obj)
		{
			return obj is IMeasure ? this == (IMeasure)obj : false;
		}

		/// <summary>
		/// Gets a hash code for the measure object
		/// </summary>
		/// <returns>Measure object hash code</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				return (ReferenceUnitAmount.GetHashCode() * 397) ^ ReferenceUnit.GetHashCode();
			}
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
			return Plus(iLhs, iRhs);
		}

		/// <summary>
		/// Adds two measure objects provided the measured quantities are equal
		/// </summary>
		/// <param name="iLhs">First measure term</param>
		/// <param name="iRhs">Second measure term (any object implementing the IMeasure interface)</param>
		/// <returns>Sum of the two measure objects in the unit of the <paramref name="iLhs">left-hand side measure</paramref></returns>
		/// <exception cref="InvalidOperationException">Is thrown if the measured quanitites are not equal</exception>
		public static Measure operator +(Measure iLhs, IMeasure iRhs)
		{
			return Plus(iLhs, iRhs);
		}

		/// <summary>
		/// Adds two measure objects provided the measured quantities are equal
		/// </summary>
		/// <param name="iLhs">First measure term (any object implementing the IMeasure interface)</param>
		/// <param name="iRhs">Second measure term</param>
		/// <returns>Sum of the two measure objects in the unit of the <paramref name="iLhs">left-hand side measure</paramref></returns>
		/// <exception cref="InvalidOperationException">Is thrown if the measured quanitites are not equal</exception>
		public static Measure operator +(IMeasure iLhs, Measure iRhs)
		{
			return Plus(iLhs, iRhs);
		}

		/// <summary>
		/// Subtract two measure objects of the same quantity
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object</param>
		/// <returns>Difference of the measure objects</returns>
		public static Measure operator -(Measure iLhs, Measure iRhs)
		{
			return Minus(iLhs, iRhs);
		}

		/// <summary>
		/// Subtract two measure objects of the same quantity
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object (any object implementing the IMeasure interface)</param>
		/// <returns>Difference of the measure objects</returns>
		public static Measure operator -(Measure iLhs, IMeasure iRhs)
		{
			return Minus(iLhs, iRhs);
		}

		/// <summary>
		/// Subtract two measure objects of the same quantity
		/// </summary>
		/// <param name="iLhs">First measure object (any object implementing the IMeasure interface)</param>
		/// <param name="iRhs">Second measure object</param>
		/// <returns>Difference of the measure objects</returns>
		public static Measure operator -(IMeasure iLhs, Measure iRhs)
		{
			return Minus(iLhs, iRhs);
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
		/// <param name="iMeasure">Measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Product of the measure object and the scalar</returns>
		public static Measure operator *(Measure iMeasure, AmountType iScalar)
		{
			return new Measure(iMeasure.mAmount * iScalar, iMeasure.mUnit);
		}

		/// <summary>
		/// Multiply two measure objects
		/// </summary>
		/// <param name="iLhs">Left-hand side measure</param>
		/// <param name="iRhs">Right-hand side measure</param>
		/// <returns>Product of the two measure objects, given in the reference unit of the resulting quantity</returns>
		/// <exception cref="InvalidOperationException">if a unique product quantity cannot be identified</exception>
		public static Measure operator *(Measure iLhs, Measure iRhs)
		{
			return Times(iLhs, iRhs);
		}

		/// <summary>
		/// Multiply two measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">Left-hand side measure</param>
		/// <param name="iRhs">Right-hand side measure (may be any object implementing the IMeasure interface)</param>
		/// <returns>Product of the two measure objects, given in the reference unit of the resulting quantity</returns>
		/// <exception cref="InvalidOperationException">if a unique product quantity cannot be identified</exception>
		public static Measure operator *(Measure iLhs, IMeasure iRhs)
		{
			return Times(iLhs, iRhs);
		}

		/// <summary>
		/// Multiply two measure objects, where left-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">Left-hand side measure (may be any object implementing the IMeasure interface)</param>
		/// <param name="iRhs">Right-hand side measure</param>
		/// <returns>Product of the two measure objects, given in the reference unit of the resulting quantity</returns>
		/// <exception cref="InvalidOperationException">if a unique product quantity cannot be identified</exception>
		public static Measure operator *(IMeasure iLhs, Measure iRhs)
		{
			return Times(iLhs, iRhs);
		}

		/// <summary>
		/// Divide a measure object with a scalar
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Quotient of the measure object and the scalar</returns>
		public static Measure operator /(Measure iMeasure, AmountType iScalar)
		{
			return new Measure(iMeasure.mAmount/iScalar, iMeasure.mUnit);
		}

		/// <summary>
		/// Divide two measure objects
		/// </summary>
		/// <param name="iNumerator">Numerator measure</param>
		/// <param name="iDenominator">Denominator measure</param>
		/// <returns>Quotient of the two measure objects, given in the reference unit of the resulting quantity</returns>
		/// <exception cref="InvalidOperationException">if a unique quotient quantity cannot be identified</exception>
		public static Measure operator /(Measure iNumerator, Measure iDenominator)
		{
			return Divide(iNumerator, iDenominator);
		}

		/// <summary>
		/// Divide two measure objects, where denominator may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iNumerator">Numerator measure</param>
		/// <param name="iDenominator">Denominator measure (any object implementing the IMeasure interface)</param>
		/// <returns>Quotient of the two measure objects, given in the reference unit of the resulting quantity</returns>
		/// <exception cref="InvalidOperationException">if a unique quotient quantity cannot be identified</exception>
		public static Measure operator /(Measure iNumerator, IMeasure iDenominator)
		{
			return Divide(iNumerator, iDenominator);
		}

		/// <summary>
		/// Divide two measure objects, where numerator may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iNumerator">Numerator measure (any object implementing the IMeasure interface)</param>
		/// <param name="iDenominator">Denominator measure</param>
		/// <returns>Quotient of the two measure objects, given in the reference unit of the resulting quantity</returns>
		/// <exception cref="InvalidOperationException">if a unique quotient quantity cannot be identified</exception>
		public static Measure operator /(IMeasure iNumerator, Measure iDenominator)
		{
			return Divide(iNumerator, iDenominator);
		}

		/// <summary>
		/// Less than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(Measure iLhs, Measure iRhs)
		{
			return LessThan(iLhs, iRhs);
		}

		/// <summary>
		/// Less than operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(Measure iLhs, IMeasure iRhs)
		{
			return LessThan(iLhs, iRhs);
		}

		/// <summary>
		/// Less than operator for measure objects, where left-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object (any object implementing IMeasure interface)</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(IMeasure iLhs, Measure iRhs)
		{
			return LessThan(iLhs, iRhs);
		}

		/// <summary>
		/// Greater than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(Measure iLhs, Measure iRhs)
		{
			return GreaterThan(iLhs, iRhs);
		}

		/// <summary>
		/// Greater than operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(Measure iLhs, IMeasure iRhs)
		{
			return GreaterThan(iLhs, iRhs);
		}

		/// <summary>
		/// Greater than operator for measure objects, where left-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object (any object implementing IMeasure interface)</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(IMeasure iLhs, Measure iRhs)
		{
			return GreaterThan(iLhs, iRhs);
		}

		/// <summary>
		/// Less than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(Measure iLhs, Measure iRhs)
		{
			return LessThanOrEqualTo(iLhs, iRhs);
		}

		/// <summary>
		/// Less than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(Measure iLhs, IMeasure iRhs)
		{
			return LessThanOrEqualTo(iLhs, iRhs);
		}

		/// <summary>
		/// Less than or equal to operator for measure objects, where left-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object (any object implementing IMeasure interface)</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(IMeasure iLhs, Measure iRhs)
		{
			return LessThanOrEqualTo(iLhs, iRhs);
		}

		/// <summary>
		/// Greater than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(Measure iLhs, Measure iRhs)
		{
			return GreaterThanOrEqualTo(iLhs, iRhs);
		}

		/// <summary>
		/// Greater than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(Measure iLhs, IMeasure iRhs)
		{
			return GreaterThanOrEqualTo(iLhs, iRhs);
		}

		/// <summary>
		/// Greater than or equal to operator for measure objects, where left-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object (any object implementing IMeasure interface)</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(IMeasure iLhs, Measure iRhs)
		{
			return GreaterThanOrEqualTo(iLhs, iRhs);
		}

		/// <summary>
		/// Equality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(Measure iLhs, Measure iRhs)
		{
			return AreEqual(iLhs, iRhs);
		}

		/// <summary>
		/// Equality operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(Measure iLhs, IMeasure iRhs)
		{
			return AreEqual(iLhs, iRhs);
		}

		/// <summary>
		/// Equality operator for measure objects, where left-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object (any object implementing IMeasure interface)</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(IMeasure iLhs, Measure iRhs)
		{
			return AreEqual(iLhs, iRhs);
		}

		/// <summary>
		/// Inquality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(Measure iLhs, Measure iRhs)
		{
			return AreNotEqual(iLhs, iRhs);
		}

		/// <summary>
		/// Inquality operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(Measure iLhs, IMeasure iRhs)
		{
			return AreNotEqual(iLhs, iRhs);
		}

		/// <summary>
		/// Inquality operator for measure objects, where left-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object (any object implementing IMeasure interface)</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(IMeasure iLhs, Measure iRhs)
		{
			return AreNotEqual(iLhs, iRhs);
		}

		#endregion

		#region OPERATOR SUPPORT METHODS

		public static Measure Plus(IMeasure iLhs, IMeasure iRhs)
		{
			return iLhs.MeasuredUnit == iRhs.MeasuredUnit ?
				new Measure(iLhs.MeasuredAmount + iRhs.MeasuredAmount, iLhs.MeasuredUnit) :
				new Measure(iLhs.MeasuredAmount + iLhs.MeasuredUnit.GetAmount(iRhs), iLhs.MeasuredUnit);
		}

		public static Measure Minus(IMeasure iLhs, IMeasure iRhs)
		{
			return iLhs.MeasuredUnit == iRhs.MeasuredUnit ?
				new Measure(iLhs.MeasuredAmount - iRhs.MeasuredAmount, iLhs.MeasuredUnit) :
				new Measure(iLhs.MeasuredAmount - iLhs.MeasuredUnit.GetAmount(iRhs), iLhs.MeasuredUnit);
		}

		private static Measure Times(IMeasure iLhs, IMeasure iRhs)
		{
			Quantity productQuantity = QuantityExtensions.Times(iLhs.MeasuredQuantity,
																  iRhs.MeasuredQuantity);
			return new Measure(iLhs.ReferenceUnitAmount * iRhs.ReferenceUnitAmount,
							   productQuantity.GetReferenceUnit());
		}

		private static Measure Divide(IMeasure iNumerator, IMeasure iDenominator)
		{
			Quantity quotientQuantity = QuantityExtensions.Divide(iNumerator.MeasuredQuantity,
																  iDenominator.MeasuredQuantity);
			return new Measure(iNumerator.ReferenceUnitAmount/iDenominator.ReferenceUnitAmount,
							   quotientQuantity.GetReferenceUnit());
		}

		private static bool LessThan(IMeasure iLhs, IMeasure iRhs)
		{
			return iLhs.MeasuredUnit == iRhs.MeasuredUnit
					   ? iLhs.MeasuredAmount < iRhs.MeasuredAmount
					   : iLhs.MeasuredAmount < iLhs.MeasuredUnit.GetAmount(iRhs);
		}

		private static bool GreaterThan(IMeasure iLhs, IMeasure iRhs)
		{
			return iLhs.MeasuredUnit == iRhs.MeasuredUnit
					   ? iLhs.MeasuredAmount > iRhs.MeasuredAmount
					   : iLhs.MeasuredAmount > iLhs.MeasuredUnit.GetAmount(iRhs);
		}

		private static bool LessThanOrEqualTo(IMeasure iLhs, IMeasure iRhs)
		{
			return iLhs.MeasuredUnit == iRhs.MeasuredUnit
					   ? iLhs.MeasuredAmount <= iRhs.MeasuredAmount
					   : iLhs.MeasuredAmount <= iLhs.MeasuredUnit.GetAmount(iRhs);
		}

		private static bool GreaterThanOrEqualTo(IMeasure iLhs, IMeasure iRhs)
		{
			return iLhs.MeasuredUnit == iRhs.MeasuredUnit
					   ? iLhs.MeasuredAmount >= iRhs.MeasuredAmount
					   : iLhs.MeasuredAmount >= iLhs.MeasuredUnit.GetAmount(iRhs);
		}

		private static bool AreEqual(IMeasure iLhs, IMeasure iRhs)
		{
			return iLhs.MeasuredUnit == iRhs.MeasuredUnit
					   ? iLhs.MeasuredAmount == iRhs.MeasuredAmount
					   : iLhs.MeasuredAmount == iLhs.MeasuredUnit.GetAmount(iRhs);
		}

		private static bool AreNotEqual(IMeasure iLhs, IMeasure iRhs)
		{
			return iLhs.MeasuredUnit == iRhs.MeasuredUnit
					   ? iLhs.MeasuredAmount != iRhs.MeasuredAmount
					   : iLhs.MeasuredAmount != iLhs.MeasuredUnit.GetAmount(iRhs);
		}

		#endregion
	}

	public struct Measure<Q> : IMeasure, IEquatable<Measure<Q>>, IComparable<Measure<Q>> where Q : struct, IQuantity
	{
		#region MEMBER VARIABLES

		private readonly AmountType mAmount;

		#endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Initializes a measure object of the specified quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in reference unit, double precision</param>
		public Measure(double iAmount)
		{
			mAmount =
#if !DOUBLE
				(AmountType)
#endif
 iAmount;
		}

		/// <summary>
		/// Initializes a measure object of the specified quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in reference unit, single precision</param>
		public Measure(float iAmount)
		{
			mAmount =
#if !SINGLE
 (AmountType)
#endif
iAmount;
		}

		/// <summary>
		/// Initializes a measure object of the specified quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in reference unit, decimal precision</param>
		public Measure(decimal iAmount)
		{
			mAmount =
#if !DECIMAL
 (AmountType)
#endif
iAmount;
		}

		/// <summary>
		/// Initializes a measure object of a specified unit
		/// </summary>
		/// <param name="iAmount">Measured amount in double precision</param>
		/// <param name="iUnit">Unit of measure</param>
		/// <exception cref="InvalidOperationException">is thrown if the quantity of the specified unit
		/// is not the same as the type-specified quantity</exception>
		public Measure(double iAmount, Unit iUnit)
		{
			AssertValidUnit(iUnit);
			mAmount = iUnit.GetReferenceUnitAmount(
#if !DOUBLE
				(AmountType)
#endif
iAmount);
		}

		/// <summary>
		/// Initializes a measure object of a specified unit
		/// </summary>
		/// <param name="iAmount">Measured amount in single precision</param>
		/// <param name="iUnit">Unit of measure</param>
		/// <exception cref="InvalidOperationException">is thrown if the quantity of the specified unit
		/// is not the same as the type-specified quantity</exception>
		public Measure(float iAmount, Unit iUnit)
		{
			AssertValidUnit(iUnit);
			mAmount = iUnit.GetReferenceUnitAmount(
#if !SINGLE
(AmountType)
#endif
iAmount);
		}

		/// <summary>
		/// Initializes a measure object of a specified unit
		/// </summary>
		/// <param name="iAmount">Measured amount in decimal format</param>
		/// <param name="iUnit">Unit of measure</param>
		/// <exception cref="InvalidOperationException">is thrown if the quantity of the specified unit
		/// is not the same as the type-specified quantity</exception>
		public Measure(decimal iAmount, Unit iUnit)
		{
			AssertValidUnit(iUnit);
			mAmount = iUnit.GetReferenceUnitAmount(
#if !DECIMAL
(AmountType)
#endif
iAmount);
		}

		#endregion

		#region PROPERTIES

		/// <summary>
		/// Gets the measured amount in the <see cref="MeasuredUnit">current unit of measure</see>
		/// </summary>
		public AmountType MeasuredAmount
		{
			get { return mAmount; }
		}

		/// <summary>
		/// Gets the measured amount in the <see cref="ReferenceUnit">reference unit of measure</see>
		/// </summary>
		public AmountType ReferenceUnitAmount
		{
			get { return mAmount; }
		}

		/// <summary>
		/// Gets the measured quantity
		/// </summary>
		public Quantity MeasuredQuantity
		{
			get { return default(Q).EnumeratedValue; }
		}

		/// <summary>
		/// Gets the unit of measure
		/// </summary>
		public Unit MeasuredUnit
		{
			get { return ReferenceUnit; }
		}

		/// <summary>
		/// Gets the reference unit of measure for the <see cref="MeasuredQuantity">measured quantity</see>
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
		/// Returns a string description of the measure in the given <paramref name="iUnit">physical unit</paramref>
		/// </summary>
		/// <param name="iUnit">Unit in which the measure should be presented</param>
		/// <returns>String representation of the measure in the given <paramref name="iUnit">physical unit</paramref></returns>
		/// <exception cref="InvalidOperationException">if the <paramref name="iUnit">specified unit</paramref> is of
		/// a different quantity than the <see cref="MeasuredUnit">measured unit </see></exception>
		public string ToString(Unit iUnit)
		{
			return String.Format("{0} {1}", GetAmount(iUnit), iUnit.GetSymbol()).Trim();
		}

		/// <summary>
		/// Multiply two measure objects
		/// </summary>
		/// <typeparam name="Q1">Quantity type of the left-hand side measure</typeparam>
		/// <typeparam name="Q2">Quantity type of the right-hand side measure</typeparam>
		/// <param name="iLhs">Left-hand side measure object</param>
		/// <param name="iRhs">Right-hand side measure object</param>
		/// <returns>Product of the two measure factors as a measure of the <typeparamref name="Q"/> quantity type</returns>
		public static Measure<Q> Times<Q1, Q2>(Measure<Q1> iLhs, Measure<Q2> iRhs)
			where Q1 : struct, IQuantity
			where Q2 : struct, IQuantity
		{
			if (default(Q).EnumeratedValue.IsQuantityOfProduct(iLhs.MeasuredQuantity, iRhs.MeasuredQuantity))
			{
				return new Measure<Q>(iLhs.mAmount * iRhs.mAmount);
			}
			throw new InvalidOperationException(String.Format("Cannot multiply {0} and {1} to measure of quantity {2}",
															  iLhs, iRhs, default(Q).EnumeratedValue));
		}

		/// <summary>
		/// Divide two measure objects
		/// </summary>
		/// <typeparam name="Q1">Quantity type of the numerator measure</typeparam>
		/// <typeparam name="Q2">Quantity type of the denominator measure</typeparam>
		/// <param name="iNumerator">Numerator measure object</param>
		/// <param name="iDenominator">Denominator measure object</param>
		/// <returns>Quotient of the two measure factors as a measure of the <typeparamref name="Q"/> quantity type</returns>
		public static Measure<Q> Divide<Q1, Q2>(Measure<Q1> iNumerator, Measure<Q2> iDenominator)
			where Q1 : struct, IQuantity
			where Q2 : struct, IQuantity
		{
			if (default(Q).EnumeratedValue.IsQuantityOfQuotient(iNumerator.MeasuredQuantity, iDenominator.MeasuredQuantity))
			{
				return new Measure<Q>(iNumerator.mAmount / iDenominator.mAmount);
			}
			throw new InvalidOperationException(String.Format("Cannot divide {0} and {1} to measure of quantity {2}",
															  iNumerator, iDenominator, default(Q).EnumeratedValue));
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(Measure<Q> other)
		{
			return mAmount.Equals(other.mAmount);
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: 
		/// Value               Meaning 
		/// Less than zero      This object is less than the <paramref name="other"/> parameter.
		/// Zero                This object is equal to <paramref name="other"/>. 
		/// Greater than zero   This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <exception cref="InvalidOperationException">if the quantity of the other measure is not the same as the quantity
		/// of this object</exception>
		public int CompareTo(Measure<Q> other)
		{
			return mAmount.CompareTo(other.mAmount);
		}

		/// <summary>
		/// Compares another object with this measure object
		/// </summary>
		/// <param name="obj">Object to compare with this object</param>
		/// <returns>true if <paramref name="obj"/> is a quantity-specific Measure object that is equivalent with this object, 
		/// false otherwise</returns>
		public override bool Equals(object obj)
		{
			return obj is Measure<Q> ? Equals((Measure<Q>)obj) : false;
		}

		/// <summary>
		/// Gets the Measure object hash code
		/// </summary>
		/// <returns>Hash code of this object</returns>
		public override int GetHashCode()
		{
			return mAmount.GetHashCode();
		}

		/// <summary>
		/// Gets the measure represented as a string
		/// </summary>
		/// <returns>The measure description</returns>
		public override string ToString()
		{
			return String.Format("{0} {1}", mAmount, ReferenceUnit.GetSymbol()).Trim();
		}

		private static void AssertValidUnit(Unit iUnit)
		{
			if (!default(Q).EnumeratedValue.IsUnitSupported(iUnit))
				throw new InvalidOperationException(String.Format("Unit {0} is not of quantity {1}", iUnit, default(Q).EnumeratedValue));
		}

		private static void AssertValidMeasure(Measure iMeasure)
		{
			if (iMeasure.MeasuredQuantity != default(Q).EnumeratedValue)
			{
				throw new InvalidOperationException(String.Format("Measure {0} is not of quantity {1}", iMeasure, default(Q).EnumeratedValue));
			}
		}

		#endregion

		#region OPERATORS

		/// <summary>
		/// Converts a generic Measure object into a non-generic equivalent
		/// </summary>
		/// <param name="iMeasure">Generic measure object subject to conversion</param>
		/// <returns>Non-generic equivalent of the generic measure object</returns>
		public static explicit operator Measure(Measure<Q> iMeasure)
		{
			return new Measure(iMeasure.mAmount, iMeasure.MeasuredUnit);
		}

		/// <summary>
		/// Converts a non-generic measure object into a generic equivalent
		/// </summary>
		/// <param name="iMeasure">Non-generic measure object</param>
		/// <returns>Generic equivalent of the specified non-generic measure object</returns>
		public static explicit operator Measure<Q>(Measure iMeasure)
		{
			AssertValidMeasure(iMeasure);
			return new Measure<Q>(iMeasure.ReferenceUnitAmount);
		}

		/// <summary>
		/// Double cast operator
		/// </summary>
		/// <param name="iAmount">Amount in double precision</param>
		/// <returns>Measure object with specified amount</returns>
		public static explicit operator Measure<Q>(double iAmount)
		{
			return new Measure<Q>(iAmount);
		}

		/// <summary>
		/// Float cast operator
		/// </summary>
		/// <param name="iAmount">Amount in single precision</param>
		/// <returns>Measure object with specified amount</returns>
		public static explicit operator Measure<Q>(float iAmount)
		{
			return new Measure<Q>(iAmount);
		}

		/// <summary>
		/// Decimal cast operator
		/// </summary>
		/// <param name="iAmount">Amount in decimal precision</param>
		/// <returns>Measure object with specified amount</returns>
		public static explicit operator Measure<Q>(decimal iAmount)
		{
			return new Measure<Q>(iAmount);
		}

		/// <summary>
		/// Adds two measure objects
		/// </summary>
		/// <param name="iLhs">First measure term</param>
		/// <param name="iRhs">Second measure term</param>
		/// <returns>Measure object representing the sum of the two operands</returns>
		public static Measure<Q> operator +(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount + iRhs.mAmount);
		}

		/// <summary>
		/// Subtract two measure objects of the same unit
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object</param>
		/// <returns>Difference of the measure objects</returns>
		public static Measure<Q> operator -(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount - iRhs.mAmount);
		}

		/// <summary>
		/// Multiply a scalar and a measure object
		/// </summary>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <param name="iMeasure">Measure object</param>
		/// <returns>Product of the scalar and the measure object</returns>
		public static Measure<Q> operator *(AmountType iScalar, Measure<Q> iMeasure)
		{
			return new Measure<Q>(iScalar * iMeasure.mAmount);
		}

		/// <summary>
		/// Multiply a measure object and a scalar
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Product of the measure object and the scalar</returns>
		public static Measure<Q> operator *(Measure<Q> iMeasure, AmountType iScalar)
		{
			return new Measure<Q>(iMeasure.mAmount * iScalar);
		}

		/// <summary>
		/// Divide a measure object with a scalar
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Quotient of the measure object and the scalar</returns>
		public static Measure<Q> operator /(Measure<Q> iMeasure, AmountType iScalar)
		{
			checked
			{
				return new Measure<Q>(iMeasure.mAmount / iScalar);
			}
		}

		/// <summary>
		/// Divide two measure objects of the same unit
		/// </summary>
		/// <param name="iNumerator">Numerator measure</param>
		/// <param name="iDenominator">Denominator measure</param>
		/// <returns>Scalar quotient of the two measure objects</returns>
		public static AmountType operator /(Measure<Q> iNumerator, Measure<Q> iDenominator)
		{
			checked
			{
				return iNumerator.mAmount / iDenominator.mAmount;
			}
		}

		/// <summary>
		/// Less than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount < iRhs.mAmount;
		}

		/// <summary>
		/// Greater than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount > iRhs.mAmount;
		}

		/// <summary>
		/// Less than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount <= iRhs.mAmount;
		}

		/// <summary>
		/// Greater than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount >= iRhs.mAmount;
		}

		/// <summary>
		/// Equality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount == iRhs.mAmount;
		}

		/// <summary>
		/// Inquality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount != iRhs.mAmount;
		}

		#endregion
	}
}