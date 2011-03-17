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
	/// Representation of a unit specific measure of a specific quantity
	/// </summary>
	/// <typeparam name="Q">Measured quantity</typeparam>
	public class Measure<Q> : IMeasure<Q> where Q : struct, IQuantity<Q>
	{
		#region MEMBER VARIABLES

		private readonly AmountType mAmount;
		private readonly IUnit<Q> mUnit;

		#endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Default constructor, initializes the amount to zero, unit set to standard unit of the measured quantity
		/// </summary>
		public Measure()
			: this(0.0)
		{
		}

		/// <summary>
		/// Initializes a measure to the specified amount and standard unit of the measured quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in standard unit of the specified quantity</param>
		public Measure(double iAmount)
			: this(iAmount, default(Q).StandardUnit)
		{
		}

		/// <summary>
		/// Initializes a measure to the specified amount and standard unit of the measured quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in standard unit of the specified quantity</param>
		public Measure(float iAmount)
			: this(iAmount, default(Q).StandardUnit)
		{
		}

		/// <summary>
		/// Initializes a measure to the specified amount and standard unit of the measured quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in standard unit of the specified quantity</param>
		public Measure(decimal iAmount)
			: this(iAmount, default(Q).StandardUnit)
		{
		}

		/// <summary>
		/// Initializes a measure to the specified amount and unit
		/// </summary>
		/// <param name="iAmount">Measured amount</param>
		/// <param name="iUnit">Unit of measure</param>
		/// <exception cref="ArgumentNullException">if the specified unit is null</exception>
		public Measure(double iAmount, IUnit<Q> iUnit)
		{
			if (iUnit == null) throw new ArgumentNullException("iUnit");
#if DOUBLE
			mAmount = iAmount;
#else
			mAmount = (AmountType)iAmount;
#endif
			mUnit = iUnit;
		}

		/// <summary>
		/// Initializes a measure to the specified amount and unit
		/// </summary>
		/// <param name="iAmount">Measured amount</param>
		/// <param name="iUnit">Unit of measure</param>
		/// <exception cref="ArgumentNullException">if the specified unit is null</exception>
		public Measure(float iAmount, IUnit<Q> iUnit)
		{
			if (iUnit == null) throw new ArgumentNullException("iUnit");
#if !DECIMAL
			mAmount = iAmount;
#else
			mAmount = (AmountType)iAmount;
#endif
			mUnit = iUnit;
		}

		/// <summary>
		/// Initializes a measure to the specified amount and unit
		/// </summary>
		/// <param name="iAmount">Measured amount</param>
		/// <param name="iUnit">Unit of measure</param>
		/// <exception cref="ArgumentNullException">if the specified unit is null</exception>
		public Measure(decimal iAmount, IUnit<Q> iUnit)
		{
			if (iUnit == null) throw new ArgumentNullException("iUnit");
#if DECIMAL
			mAmount = iAmount;
#else
			mAmount = (AmountType)iAmount;
#endif
			mUnit = iUnit;
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
	    public AmountType StandardAmount
	    {
	        get { return GetAmount(default(Q).StandardUnit); }
	    }

	    /// <summary>
		/// Gets the unit of measure
		/// </summary>
		public IUnit<Q> Unit
		{
			get { return mUnit; }
		}

		/// <summary>
		/// Gets the amount of this measure in the requested unit
		/// </summary>
		/// <param name="iUnit">Unit to which the measured amount should be converted</param>
		/// <returns>Measured amount converted into <paramref name="iUnit">specified unit</paramref></returns>
		public AmountType GetAmount(IUnit<Q> iUnit)
		{
			if (iUnit == null) throw new ArgumentNullException("iUnit");
			return iUnit.AmountFromStandardUnitConverter(mUnit.AmountToStandardUnitConverter(mAmount));
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
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(IMeasure<Q> other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return mAmount.Equals(other.GetAmount(mUnit));
		}

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: 
		///                     Value 
		///                     Meaning 
		///                     Less than zero 
		///                     This object is less than the <paramref name="other"/> parameter.
		///                     Zero 
		///                     This object is equal to <paramref name="other"/>. 
		///                     Greater than zero 
		///                     This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public int CompareTo(IMeasure<Q> other)
		{
			if (other == null) throw new ArgumentNullException("other");
			return mAmount.CompareTo(other.GetAmount(mUnit));
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
		/// </summary>
		/// <returns>
		/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
		/// </returns>
		/// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
		/// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
		/// <filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Measure<Q>)) return false;
			return Equals((Measure<Q>)obj);
		}

		/// <summary>
		/// Serves as a hash function for a particular type. 
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			return StandardAmount.GetHashCode();
		}

		/// <summary>
		/// Returns the fully qualified type name of this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"/> containing a fully qualified type name.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override string ToString()
		{
			return String.Format("{0} {1}", mAmount, mUnit.Symbol).Trim();
		}

		#endregion

		#region OPERATORS

		/// <summary>
		/// Adds two measure objects provided the measured quantities are equal
		/// </summary>
		/// <param name="iLhs">First measure term</param>
		/// <param name="iRhs">Second measure term</param>
		/// <returns>Sum of the two measure objects in the unit of the <paramref name="iLhs">left-hand side measure</paramref></returns>
		public static Measure<Q> operator +(Measure<Q> iLhs,  Measure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount + iRhs.GetAmount(iLhs.mUnit), iLhs.mUnit);
		}

		/// <summary>
		/// Adds two measure objects provided the measured quantities are equal
		/// </summary>
		/// <param name="iLhs">First measure term</param>
		/// <param name="iRhs">Second measure term (any object implementing the IMeasure interface)</param>
		/// <returns>Sum of the two measure objects in the unit of the <paramref name="iLhs">left-hand side measure</paramref></returns>
		public static Measure<Q> operator +(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount + iRhs.GetAmount(iLhs.mUnit), iLhs.mUnit);
		}

		/// <summary>
		/// Subtract two measure objects of the same quantity
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object</param>
		/// <returns>Difference of the measure objects</returns>
		public static Measure<Q> operator -(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount - iRhs.GetAmount(iLhs.mUnit), iLhs.mUnit);
		}

		/// <summary>
		/// Subtract two measure objects of the same quantity
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object (any object implementing the IMeasure interface)</param>
		/// <returns>Difference of the measure objects</returns>
		public static Measure<Q> operator -(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount - iRhs.GetAmount(iLhs.mUnit), iLhs.mUnit);
		}

		/// <summary>
		/// Multiply a scalar and a measure object
		/// </summary>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <param name="iMeasure">Measure object</param>
		/// <returns>Product of the scalar and the measure object</returns>
		public static Measure<Q> operator *(AmountType iScalar, Measure<Q> iMeasure)
		{
			return new Measure<Q>(iScalar * iMeasure.mAmount, iMeasure.mUnit);
		}

		/// <summary>
		/// Multiply a measure object and a scalar
		/// </summary>
		/// <param name="iMeasure">Measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Product of the measure object and the scalar</returns>
		public static Measure<Q> operator *(Measure<Q> iMeasure, AmountType iScalar)
		{
			return new Measure<Q>(iMeasure.mAmount * iScalar, iMeasure.mUnit);
		}

		/// <summary>
		/// Divide a measure object with a scalar
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iScalar">Floating-point scalar</param>
		/// <returns>Quotient of the measure object and the scalar</returns>
		public static Measure<Q> operator /(Measure<Q> iMeasure, AmountType iScalar)
		{
			return new Measure<Q>(iMeasure.mAmount / iScalar, iMeasure.mUnit);
		}

		/// <summary>
		/// Less than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount < iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Less than operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount < iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Greater than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount > iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Greater than operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount > iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Less than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount <= iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Less than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount <= iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Greater than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount >= iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Greater than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount >= iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Equality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount == iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Equality operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount == iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Inequality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount != iRhs.GetAmount(iLhs.mUnit);
		}

		/// <summary>
		/// Inequality operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object (any object implementing IMeasure interface)</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount != iRhs.GetAmount(iLhs.mUnit);
		}

		#endregion
	}
}