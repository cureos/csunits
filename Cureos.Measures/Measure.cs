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
	public struct Measure<Q> : IMeasure<Q>, IEquatable<Measure<Q>>, IComparable<Measure<Q>> where Q : struct, IQuantity<Q>
	{
		#region MEMBER VARIABLES

		private readonly AmountType mAmount;

		#endregion

		#region CONSTRUCTORS

#if !MONO
		/// <summary>
		/// Static constructor for defining static class properties
		/// </summary>
		static Measure()
		{
			Zero = new Measure<Q>(Constants.Zero);
			Epsilon = new Measure<Q>(Constants.MachineEpsilon);
		}
#endif
		
		/// <summary>
		/// Initializes a measure object of the specified quantity
		/// </summary>
		/// <param name="iAmount">Measured amount in reference unit, double precision</param>
		public Measure(double iAmount)
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
		public Measure(float iAmount)
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
		public Measure(decimal iAmount)
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
		public Measure(double iAmount, IUnit<Q> iUnit)
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
		public Measure(float iAmount, IUnit<Q> iUnit)
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
		public Measure(decimal iAmount, IUnit<Q> iUnit)
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
		public Measure(IMeasure<Q> iMeasure)
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
		public UnitPreservingMeasure<Q> this[IUnit<Q> iUnit]
		{
			get
			{
				if (iUnit == null) throw new ArgumentNullException("iUnit");
				return new UnitPreservingMeasure<Q>(GetAmount(iUnit), iUnit);
			}
		}

		#endregion

#if !MONO
		#region PROPERTIES
		
		public static Measure<Q> Zero { get; private set; }

		public static Measure<Q> Epsilon { get; private set; }

		#endregion
#endif
		
		#region METHODS

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
		/// Indicates whether the current measure is equal to another measure of the same quantity within a given tolerance
		/// </summary>
		/// <param name="other">A measure to compare with this measure</param>
		/// <param name="tol">The tolerance with which the compared measures may differ</param>
		/// <returns>true if this and other are equal within the given tolerance, false otherwise</returns>
		public bool Equals(Measure<Q> other, Measure<Q> tol)
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
		public int CompareTo(Measure<Q> other)
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
			return obj is Measure<Q> && Equals((Measure<Q>)obj);
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
		public Measure<Qout> Cast<Qout>() where Qout :  struct, IQuantity<Qout>
		{
			if (!default(Qout).Dimension.ExponentsEqual(default(Q).Dimension))
				throw new InvalidCastException("Cannot cast measure to quantity with different dimensions");

			return new Measure<Qout>(mAmount);
		}

		#endregion

		#region OPERATORS

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
		/// Adds two measure objects
		/// </summary>
		/// <param name="iLhs">First measure term</param>
		/// <param name="iRhs">Second measure term, any object implementing the IMeasure interface</param>
		/// <returns>Measure object representing the sum of the two operands</returns>
		public static Measure<Q> operator +(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount + iRhs.StandardAmount);
		}

		/// <summary>
		/// Subtract two measure objects
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object</param>
		/// <returns>Difference of the measure objects</returns>
		public static Measure<Q> operator -(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount - iRhs.mAmount);
		}

		/// <summary>
		/// Subtract two measure objects
		/// </summary>
		/// <param name="iLhs">First measure object</param>
		/// <param name="iRhs">Second measure object, any object implementing the IMeasure interface</param>
		/// <returns>Difference of the measure objects</returns>
		public static Measure<Q> operator -(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount - iRhs.StandardAmount);
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
		/// Multiply a (dimensionless) number and a measure object
		/// </summary>
		/// <param name="iNumber">Floating-point number</param>
		/// <param name="iMeasure">Measure object</param>
		/// <returns>Product of the number and the measure object</returns>
		public static Measure<Q> operator *(Measure<Number> iNumber, Measure<Q> iMeasure)
		{
			return new Measure<Q>(iNumber.mAmount * iMeasure.mAmount);
		}

		/// <summary>
		/// Multiply a measure object and a (dimensionless)
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iNumber">Floating-point number</param>
		/// <returns>Product of the measure object and the number</returns>
		public static Measure<Q> operator *(Measure<Q> iMeasure, Measure<Number> iNumber)
		{
			return new Measure<Q>(iMeasure.mAmount * iNumber.mAmount);
		}

		/// <summary>
		/// Divide a measure object with a (dimensionless) number
		/// </summary>
		/// <param name="iMeasure">measure object</param>
		/// <param name="iNumber">Floating-point number</param>
		/// <returns>Quotient of the measure object and the number</returns>
		public static Measure<Q> operator /(Measure<Q> iMeasure, Measure<Number> iNumber)
		{
			checked
			{
				return new Measure<Q>(iMeasure.mAmount / iNumber.mAmount);
			}
		}

		/// <summary>
		/// Divide two measure objects of the same quantity
		/// </summary>
		/// <param name="iNumerator">Numerator measure</param>
		/// <param name="iDenominator">Denominator measure</param>
		/// <returns>Scalar quotient of the two measure objects</returns>
		public static AmountType operator /(Measure<Q> iNumerator, Measure<Q> iDenominator)
		{
			return iNumerator.mAmount / iDenominator.mAmount;
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
		/// Less than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if first measure object is less than second measure object; false otherwise</returns>
		public static bool operator <(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount < iRhs.StandardAmount;
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
		/// Greater than operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
		public static bool operator >(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount > iRhs.StandardAmount;
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
		/// Less than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
		public static bool operator <=(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount <= iRhs.StandardAmount;
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
		/// Greater than or equal to operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
		public static bool operator >=(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount >= iRhs.StandardAmount;
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
		/// Equality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if the two measure objects are equal; false otherwise</returns>
		public static bool operator ==(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount == iRhs.StandardAmount;
		}

		/// <summary>
		/// Inequality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return iLhs.mAmount != iRhs.mAmount;
		}

		/// <summary>
		/// Inequality operator for measure objects
		/// </summary>
		/// <param name="iLhs">First object</param>
		/// <param name="iRhs">Second object, any object implementing the IMeasure interface</param>
		/// <returns>true if the two measure objects are not equal; false if they are equal</returns>
		public static bool operator !=(Measure<Q> iLhs, IMeasure<Q> iRhs)
		{
			return iLhs.mAmount != iRhs.StandardAmount;
		}

		#endregion
	}

	/// <summary>
	/// Utility class for operations on StandardMeasure objects
	/// </summary>
	public static class Measure
	{
		/// <summary>
		/// Compare two nullable standard measures for approximate equivalence
		/// </summary>
		/// <typeparam name="Q">Struct type implementing the IQuantity{Q} interface</typeparam>
		/// <param name="iLhs">First nullable standard measure subject to comparison</param>
		/// <param name="iRhs">Second nullable standard measure subject to comparison</param>
		/// <param name="iTol">Tolerance of the difference between the two measures</param>
		/// <returns>true if both objects have values and the difference is less than the specified tolerance, false otherwise</returns>
		public static bool AreEqual<Q>(Measure<Q>? iLhs, Measure<Q>? iRhs, Measure<Q> iTol) where Q : struct, IQuantity<Q>
		{
			return iLhs.HasValue && iRhs.HasValue && iLhs.Value.Equals(iRhs.Value, iTol);
		}
	}
}