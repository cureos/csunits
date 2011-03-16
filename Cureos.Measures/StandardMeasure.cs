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
	/// <summary>
	/// Quantity-typed representation of a single measure
	/// </summary>
	/// <typeparam name="Q">Struct type implementing the IQuantity interface</typeparam>
	public struct StandardMeasure<Q> : IMeasure<Q>, IEquatable<StandardMeasure<Q>>, IComparable<StandardMeasure<Q>> where Q : struct, IQuantity<Q>
	{
		#region MEMBER VARIABLES

		private readonly AmountType mAmount;

		#endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Initializes a measure object of the specified quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in reference unit, double precision</param>
		public StandardMeasure(double iAmount)
		{
#if DOUBLE
			mAmount = iAmount;
#else
			mAmount = (AmountType)iAmount;
#endif
		}

		/// <summary>
		/// Initializes a measure object of the specified quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in reference unit, single precision</param>
		public StandardMeasure(float iAmount)
		{
#if !DECIMAL
			mAmount = iAmount;
#else
			mAmount = (AmountType)iAmount;
#endif
		}

		/// <summary>
		/// Initializes a measure object of the specified quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in reference unit, decimal precision</param>
		public StandardMeasure(decimal iAmount)
		{
#if DECIMAL
			mAmount = iAmount;
#else
			mAmount = (AmountType)iAmount;
#endif
		}

		/// <summary>
		/// Initializes a measure object of a specified unit
		/// </summary>
		/// <param name="iAmount">Measured amount in double precision</param>
		/// <param name="iUnit">Unit of measure</param>
		public StandardMeasure(double iAmount, IUnit<Q> iUnit)
		{
			if (iUnit == null) throw new ArgumentNullException("iUnit");
#if DOUBLE
			mAmount = iUnit.AmountToStandardUnitConverter(iAmount);
#else
			mAmount = iUnit.AmountToReferenceUnitConverter((AmountType)iAmount);
#endif
		}

		/// <summary>
		/// Initializes a measure object of a specified unit
		/// </summary>
		/// <param name="iAmount">Measured amount in single precision</param>
		/// <param name="iUnit">Unit of measure</param>
		public StandardMeasure(float iAmount, IUnit<Q> iUnit)
		{
			if (iUnit == null) throw new ArgumentNullException("iUnit");
#if !DECIMAL
			mAmount = iUnit.AmountToStandardUnitConverter(iAmount);
#else
			mAmount = iUnit.AmountToReferenceUnitConverter((AmountType)iAmount);
#endif
		}

		/// <summary>
		/// Initializes a measure object of a specified unit
		/// </summary>
		/// <param name="iAmount">Measured amount in decimal format</param>
		/// <param name="iUnit">Unit of measure</param>
		public StandardMeasure(decimal iAmount, IUnit<Q> iUnit)
		{
			if (iUnit == null) throw new ArgumentNullException("iUnit");
#if DECIMAL
			mAmount = iUnit.AmountToReferenceUnitConverter(iAmount);
#else
			mAmount = iUnit.AmountToStandardUnitConverter((AmountType)iAmount);
#endif
		}

		/// <summary>
		/// Copy constructor to standard unit measure
		/// </summary>
		/// <param name="iMeasure">Measure object to be copied</param>
		public StandardMeasure(IMeasure<Q> iMeasure)
		{
			mAmount = iMeasure.StandardAmount;
		}

		#endregion

		#region Implementation of IMeasure<Q>

		/// <summary>
		/// Gets the measured amount in the <see cref="Unit">current unit of measure</see>
		/// </summary>
		public AmountType Amount
		{
			get { return mAmount; }
		}

		/// <summary>
		/// Gets the measured amount in the standard unit of measure for the <typeparam name="Q">specified quantity</typeparam>
		/// </summary>
		public double StandardAmount
		{
			get { return mAmount; }
		}

		/// <summary>
		/// Gets the unit of measure
		/// </summary>
		public IUnit<Q> Unit
		{
			get { return default(Q).StandardUnit; }
		}

		/// <summary>
		/// Gets the amount of this measure in the requested unit
		/// </summary>
		/// <param name="iUnit">Unit to which the measured amount should be converted</param>
		/// <returns>Measured amount converted into <paramref name="iUnit">specified unit</paramref></returns>
		public AmountType GetAmount(IUnit<Q> iUnit)
		{
			if (iUnit == null) throw new ArgumentNullException("iUnit");
			return iUnit.AmountFromStandardUnitConverter(mAmount);
		}

		/// <summary>
		/// Gets a new unit specific measure based on this measure but in the <paramref name="iUnit">specified unit</paramref>
		/// </summary>
		/// <param name="iUnit">Unit in which the new measure should be specified</param>
		IMeasure<Q> IMeasure<Q>.this[IUnit<Q> iUnit]
		{
			get { return this[iUnit]; }
		}

		#endregion

		#region PROPERTIES

		/// <summary>
		/// Gets a new unit specific measure based on this measure but in the <paramref name="iUnit">specified unit</paramref>
		/// </summary>
		/// <param name="iUnit">Unit in which the new measure should be specified</param>
		public Measure<Q> this[IUnit<Q> iUnit]
		{
			get
			{
				if (iUnit == null) throw new ArgumentNullException("iUnit");
				return new Measure<Q>(GetAmount(iUnit), iUnit);
			}
		}

		#endregion

		#region METHODS

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(StandardMeasure<Q> other)
		{
			return mAmount.Equals(other.mAmount);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(IMeasure<Q> other)
		{
			return GetAmount(other.Unit).Equals(other.Amount);
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
		public int CompareTo(StandardMeasure<Q> other)
		{
			return mAmount.CompareTo(other.mAmount);
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
		public int CompareTo(IMeasure<Q> other)
		{
			return GetAmount(other.Unit).CompareTo(other.Amount);
		}

		/// <summary>
		/// Compares another object with this measure object
		/// </summary>
		/// <param name="obj">Object to compare with this object</param>
		/// <returns>true if <paramref name="obj"/> is a quantity-specific Measure object that is equivalent with this object, 
		/// false otherwise</returns>
		public override bool Equals(object obj)
		{
			return obj is StandardMeasure<Q> ? Equals((StandardMeasure<Q>)obj) : false;
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
			return String.Format("{0} {1}", mAmount, Unit.Symbol).Trim();
		}

		#endregion

		#region OPERATORS

		/// <summary>
		/// Double cast operator
		/// </summary>
		/// <param name="iAmount">Amount in double precision</param>
		/// <returns>Measure object with specified amount</returns>
		public static explicit operator StandardMeasure<Q>(double iAmount)
		{
			return new StandardMeasure<Q>(iAmount);
		}

		/// <summary>
		/// Float cast operator
		/// </summary>
		/// <param name="iAmount">Amount in single precision</param>
		/// <returns>Measure object with specified amount</returns>
		public static explicit operator StandardMeasure<Q>(float iAmount)
		{
			return new StandardMeasure<Q>(iAmount);
		}

		/// <summary>
		/// Decimal cast operator
		/// </summary>
		/// <param name="iAmount">Amount in decimal precision</param>
		/// <returns>Measure object with specified amount</returns>
		public static explicit operator StandardMeasure<Q>(decimal iAmount)
		{
			return new StandardMeasure<Q>(iAmount);
		}

		/// <summary>
		/// Adds two measure objects
		/// </summary>
		/// <param name="iLhs">First measure term</param>
		/// <param name="iRhs">Second measure term</param>
		/// <returns>Measure object representing the sum of the two operands</returns>
		public static StandardMeasure<Q> operator +(StandardMeasure<Q> iLhs, StandardMeasure<Q> iRhs)
		{
			return new StandardMeasure<Q>(iLhs.mAmount + iRhs.mAmount);
		}

		/// <summary>
		/// Adds two measure objects
		/// </summary>
		/// <param name="iLhs">First measure term</param>
		/// <param name="iRhs">Second measure term, any object implementing the IMeasure interface</param>
		/// <returns>Measure object representing the sum of the two operands</returns>
		public static StandardMeasure<Q> operator +(StandardMeasure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return new StandardMeasure<Q>(iLhs.mAmount + iRhs.StandardAmount);
		}

		/// <summary>
		/// Subtract two measure objects
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object</param>
		/// <returns>Difference of the measure objects</returns>
		public static StandardMeasure<Q> operator -(StandardMeasure<Q> iLhs, StandardMeasure<Q> iRhs)
		{
			return new StandardMeasure<Q>(iLhs.mAmount - iRhs.mAmount);
		}

		/// <summary>
		/// Subtract two measure objects
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object, any object implementing the IMeasure interface</param>
		/// <returns>Difference of the measure objects</returns>
		public static StandardMeasure<Q> operator -(StandardMeasure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return new StandardMeasure<Q>(iLhs.mAmount - iRhs.StandardAmount);
		}

		/// <summary>
		/// Multiply a scalar and a measure object
		/// </summary>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <param name="iMeasure">Measure object</param>
		/// <returns>Product of the scalar and the measure object</returns>
		public static StandardMeasure<Q> operator *(AmountType iScalar, StandardMeasure<Q> iMeasure)
		{
			return new StandardMeasure<Q>(iScalar * iMeasure.mAmount);
		}

		/// <summary>
		/// Multiply a measure object and a scalar
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Product of the measure object and the scalar</returns>
		public static StandardMeasure<Q> operator *(StandardMeasure<Q> iMeasure, AmountType iScalar)
		{
			return new StandardMeasure<Q>(iMeasure.mAmount * iScalar);
		}

		/// <summary>
		/// Divide a measure object with a scalar
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Quotient of the measure object and the scalar</returns>
		public static StandardMeasure<Q> operator /(StandardMeasure<Q> iMeasure, AmountType iScalar)
		{
			checked
			{
				return new StandardMeasure<Q>(iMeasure.mAmount / iScalar);
			}
		}

		/// <summary>
		/// Divide two measure objects of the same quantity
		/// </summary>
		/// <param name="iNumerator">Numerator measure</param>
		/// <param name="iDenominator">Denominator measure</param>
		/// <returns>Scalar quotient of the two measure objects</returns>
		public static AmountType operator /(StandardMeasure<Q> iNumerator, StandardMeasure<Q> iDenominator)
		{
			return iNumerator.mAmount / iDenominator.mAmount;
		}

		/// <summary>
		/// Less than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(StandardMeasure<Q> iLhs, StandardMeasure<Q> iRhs)
		{
			return iLhs.mAmount < iRhs.mAmount;
		}

		/// <summary>
		/// Less than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(StandardMeasure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount < iRhs.StandardAmount;
		}

		/// <summary>
		/// Greater than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(StandardMeasure<Q> iLhs, StandardMeasure<Q> iRhs)
		{
			return iLhs.mAmount > iRhs.mAmount;
		}

		/// <summary>
		/// Greater than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(StandardMeasure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount > iRhs.StandardAmount;
		}

		/// <summary>
		/// Less than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(StandardMeasure<Q> iLhs, StandardMeasure<Q> iRhs)
		{
			return iLhs.mAmount <= iRhs.mAmount;
		}

		/// <summary>
		/// Less than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(StandardMeasure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount <= iRhs.StandardAmount;
		}

		/// <summary>
		/// Greater than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(StandardMeasure<Q> iLhs, StandardMeasure<Q> iRhs)
		{
			return iLhs.mAmount >= iRhs.mAmount;
		}

		/// <summary>
		/// Greater than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(StandardMeasure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount >= iRhs.StandardAmount;
		}

		/// <summary>
		/// Equality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(StandardMeasure<Q> iLhs, StandardMeasure<Q> iRhs)
		{
			return iLhs.mAmount == iRhs.mAmount;
		}

		/// <summary>
		/// Equality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(StandardMeasure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount == iRhs.StandardAmount;
		}

		/// <summary>
		/// Inequality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(StandardMeasure<Q> iLhs, StandardMeasure<Q> iRhs)
		{
			return iLhs.mAmount != iRhs.mAmount;
		}

		/// <summary>
		/// Inequality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(StandardMeasure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount != iRhs.StandardAmount;
		}

		#endregion
	}

	/// <summary>
	/// Representation of a pair of measures, given in the standard units of the respective quantities
	/// </summary>
	/// <typeparam name="Q1">Quantity type of the first measure</typeparam>
	/// <typeparam name="Q2">Quantity type of the second measure</typeparam>
	public struct StandardMeasure<Q1, Q2> : IMeasure<Q1, Q2> where Q1 : struct, IQuantity<Q1> where Q2 : struct, IQuantity<Q2>
	{
		#region MEMBER VARIABLES

		private readonly StandardMeasure<Q1> mMeasure1;
		private readonly StandardMeasure<Q2> mMeasure2;

		#endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Initializes a pair of standard measures
		/// </summary>
		/// <param name="iMeasurePair">Pair of measures in arbitrary unit</param>
		public StandardMeasure(IMeasure<Q1, Q2> iMeasurePair)
			: this(iMeasurePair.Measure1, iMeasurePair.Measure2)
		{
		}

		/// <summary>
		/// Initializes a pair of standard measures from two standard measure objects
		/// </summary>
		/// <param name="iMeasure1">First measure object</param>
		/// <param name="iMeasure2">Second measure object</param>
		public StandardMeasure(StandardMeasure<Q1> iMeasure1, StandardMeasure<Q2> iMeasure2)
		{
			mMeasure1 = iMeasure1;
			mMeasure2 = iMeasure2;
		}

		/// <summary>
		/// Initializes a pair of standard measures
		/// </summary>
		/// <param name="iMeasure1">First measure object</param>
		/// <param name="iMeasure2">Second measure object</param>
		public StandardMeasure(IMeasure<Q1> iMeasure1, IMeasure<Q2> iMeasure2)
		{
			mMeasure1 = new StandardMeasure<Q1>(iMeasure1);
			mMeasure2 = new StandardMeasure<Q2>(iMeasure2);
		}

		/// <summary>
		/// Initializes a pair of standard measures from a pair of standard unit amounts
		/// </summary>
		/// <param name="iAmount1">Amount in standard units of the first measure object</param>
		/// <param name="iAmount2">Amount in standard units of the second measure object</param>
		public StandardMeasure(double iAmount1, double iAmount2)
		{
#if DOUBLE
			mMeasure1 = new StandardMeasure<Q1>(iAmount1);
			mMeasure2 = new StandardMeasure<Q2>(iAmount2);
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
		public StandardMeasure(float iAmount1, float iAmount2)
		{
#if !DECIMAL
			mMeasure1 = new StandardMeasure<Q1>(iAmount1);
			mMeasure2 = new StandardMeasure<Q2>(iAmount2);
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
		public StandardMeasure(decimal iAmount1, decimal iAmount2)
		{
#if DECIMAL
			mMeasure1 = new StandardMeasure<Q1>(iAmount1);
			mMeasure2 = new StandardMeasure<Q2>(iAmount2);
#else
			mMeasure1 = new StandardMeasure<Q1>((AmountType)iAmount1);
			mMeasure2 = new StandardMeasure<Q2>((AmountType)iAmount2);
#endif
		}

		#endregion

		#region Implementation of IMeasure<Q1,Q2>

		/// <summary>
		/// Gets the first measure in the measure pair
		/// </summary>
		public IMeasure<Q1> Measure1
		{
			get { return mMeasure1; }
		}

		/// <summary>
		/// Gets the second measure in the measure pair
		/// </summary>
		public IMeasure<Q2> Measure2
		{
			get { return mMeasure2; }
		}

		#endregion
	}
}