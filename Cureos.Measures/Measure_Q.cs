// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
	public struct Measure<Q> : IMeasure where Q : struct, IQuantity
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
			get { return mAmount; }
		}

		/// <summary>
		/// Gets the measured quantity
		/// </summary>
		public Quantity MeasuredQuantity
		{
			get { return default(Q).Value; }
		}

		/// <summary>
		/// Gets the unit of measure
		/// </summary>
		public Unit MeasuredUnit
		{
			get { return ReferenceUnit; }
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
		/// Gets the measure represented as a string
		/// </summary>
		/// <returns>The measure description</returns>
		public override string ToString()
		{
			return String.Format("{0} {1}", mAmount, ReferenceUnit.GetSymbol()).Trim();
		}

		private static void AssertValidUnit(Unit iUnit)
		{
			if (iUnit.GetQuantity() != default(Q).Value)
				throw new InvalidOperationException(String.Format("Unit {0} is not of quantity {1}", iUnit, default(Q).Value));
		}

		private static void AssertValidMeasure(Measure iMeasure)
		{
			if (iMeasure.MeasuredQuantity != default(Q).Value)
			{
				throw new InvalidOperationException(String.Format("Measure {0} is not of quantity {1}", iMeasure, default(Q).Value));
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
		/// Adds two measure objects
		/// </summary>
		/// <param name="iLhs">First measure term</param>
		/// <param name="iRhs">Second measure term</param>
		/// <returns>Measure object representing the sum of the two operands</returns>
		public static Measure<Q> operator+(Measure<Q> iLhs, Measure<Q> iRhs)
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
