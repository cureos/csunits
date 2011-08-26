// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
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
	/// Quantity-typed representation of a single measure
	/// </summary>
	/// <typeparam name="Q">Struct type implementing the IQuantity interface</typeparam>
	public struct StandardMeasure<Q> : IMeasure<Q>, IEquatable<StandardMeasure<Q>>, IComparable<StandardMeasure<Q>> where Q : struct, IQuantity<Q>
	{
		#region MEMBER VARIABLES

		private readonly AmountType mAmount;

		#endregion

		#region CONSTRUCTORS

#if !MONO
		/// <summary>
		/// Static constructor for defining static class properties
		/// </summary>
		static StandardMeasure()
		{
			Zero = new StandardMeasure<Q>(Constants.Zero);
			Epsilon = new StandardMeasure<Q>(Constants.MachineEpsilon);
		}
#endif
		
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
			mAmount = iUnit.AmountToStandardUnitConverter((AmountType)iAmount);
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
			mAmount = iUnit.AmountToStandardUnitConverter((AmountType)iAmount);
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
			mAmount = iUnit.AmountToStandardUnitConverter(iAmount);
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
		public AmountType StandardAmount
		{
			get { return mAmount; }
		}

		/// <summary>
		/// Gets the unit of measure
		/// </summary>
		IUnit IMeasure.Unit
		{
			get { return Unit; }
		}

		/// <summary>
		/// Gets the amount of this measure in the requested unit
		/// </summary>
		/// <param name="iUnit">Unit to which the measured amount should be converted</param>
		/// <returns>Measured amount converted into <paramref name="iUnit">specified unit</paramref></returns>
		AmountType IMeasure.GetAmount(IUnit iUnit)
		{
			if (iUnit == null) throw new ArgumentNullException("iUnit");
			if (!iUnit.Quantity.Equals(default(Q))) throw new ArgumentException("Unit is not the same quantity as measure");
			return iUnit.AmountFromStandardUnitConverter(mAmount);
		}

		/// <summary>
		/// Gets a new unit specific measure based on this measure but in the <paramref name="iUnit">specified unit</paramref>
		/// </summary>
		/// <param name="iUnit">Unit in which the new measure should be specified</param>
		/// <exception cref="ArgumentNullException">if specified unit is null or if specified unit is not of the 
		/// <typeparamref name="Q">valid quantity</typeparamref></exception>
		IMeasure IMeasure.this[IUnit iUnit]
		{
			get { return this[iUnit as IUnit<Q>]; }
		}

		/// <summary>
		/// Gets the quantity-typed unit of measure
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

		#region INDEXERS

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

#if !MONO
		#region PROPERTIES
		
		public static StandardMeasure<Q> Zero { get; private set; }

		public static StandardMeasure<Q> Epsilon { get; private set; }

		#endregion
#endif
		
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
		/// Indicates whether the current measure is equal to another measure of the same quantity within a given tolerance
		/// </summary>
		/// <param name="other">A measure to compare with this measure</param>
		/// <param name="tol">The tolerance with which the compared measures may differ</param>
		/// <returns>true if this and other are equal within the given tolerance, false otherwise</returns>
		public bool Equals(StandardMeasure<Q> other, StandardMeasure<Q> tol)
		{
			return Math.Abs(mAmount - other.mAmount) <= tol.mAmount;
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
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		bool IEquatable<IMeasure>.Equals(IMeasure other)
		{
			if (other == null) throw new ArgumentNullException("other");
			if (!other.Unit.Quantity.Equals(default(Q))) throw new ArgumentException("Measures are of different quantities");
			return mAmount.Equals(other.StandardAmount);
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
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		int IComparable<IMeasure>.CompareTo(IMeasure other)
		{
			if (other == null) throw new ArgumentNullException("other");
			if (!other.Unit.Quantity.Equals(default(Q))) throw new ArgumentException("Measures are of different quantities");
			return mAmount.CompareTo(other.StandardAmount);
		}

		/// <summary>
		/// Compares another object with this measure object
		/// </summary>
		/// <param name="obj">Object to compare with this object</param>
		/// <returns>true if <paramref name="obj"/> is a quantity-specific Measure object that is equivalent with this object, 
		/// false otherwise</returns>
		public override bool Equals(object obj)
		{
			return obj is StandardMeasure<Q> && Equals((StandardMeasure<Q>)obj);
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

		/// <summary>
		/// Cast standard measure to specified quantity when SI quantity dimensions are equal
		/// </summary>
		/// <typeparam name="Qout">Quantity to which the standard measure should be cast</typeparam>
		/// <returns>Standard measure in the requested quantity</returns>
		/// <exception cref="InvalidCastException">Thrown if the SI quantity dimensions of this quantity and the
		/// requested quantity differs (only the dimensionless differntiator is allowed to differ)</exception>
		public StandardMeasure<Qout> Cast<Qout>() where Qout :  struct, IQuantity<Qout>
		{
			if (!default(Qout).Dimension.ExponentsEquals(default(Q).Dimension))
				throw new InvalidCastException("Cannot cast measure to quantity with different dimensions");

			return new StandardMeasure<Qout>(mAmount);
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
		/// Multiply a (dimensionless) number and a measure object
		/// </summary>
		/// <param name="iNumber">Floating-point number</param>
		/// <param name="iMeasure">Measure object</param>
		/// <returns>Product of the number and the measure object</returns>
		public static StandardMeasure<Q> operator *(StandardMeasure<Number> iNumber, StandardMeasure<Q> iMeasure)
		{
			return new StandardMeasure<Q>(iNumber.mAmount * iMeasure.mAmount);
		}

		/// <summary>
		/// Multiply a measure object and a (dimensionless)
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iNumber">Floating-point number</param>
		/// <returns>Product of the measure object and the number</returns>
		public static StandardMeasure<Q> operator *(StandardMeasure<Q> iMeasure, StandardMeasure<Number> iNumber)
		{
			return new StandardMeasure<Q>(iMeasure.mAmount * iNumber.mAmount);
		}

		/// <summary>
		/// Divide a measure object with a (dimensionless) number
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iNumber">Floating-point number</param>
		/// <returns>Quotient of the measure object and the number</returns>
		public static StandardMeasure<Q> operator /(StandardMeasure<Q> iMeasure, StandardMeasure<Number> iNumber)
		{
			checked
			{
				return new StandardMeasure<Q>(iMeasure.mAmount / iNumber.mAmount);
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
	/// Utility class for operations on StandardMeasure objects
	/// </summary>
	public static class StandardMeasure
	{
		/// <summary>
		/// Compare two nullable standard measures for approximate equivalence
		/// </summary>
		/// <typeparam name="Q">Struct type implementing the IQuantity{Q} interface</typeparam>
		/// <param name="iLhs">First nullable standard measure subject to comparison</param>
		/// <param name="iRhs">Second nullable standard measure subject to comparison</param>
		/// <param name="iTol">Tolerance of the difference between the two measures</param>
		/// <returns>true if both objects have values and the difference is less than the specified tolerance, false otherwise</returns>
		public static bool AreEqual<Q>(StandardMeasure<Q>? iLhs, StandardMeasure<Q>? iRhs, StandardMeasure<Q> iTol) where Q : struct, IQuantity<Q>
		{
			return iLhs.HasValue && iRhs.HasValue && iLhs.Value.Equals(iRhs.Value, iTol);
		}
	}
}