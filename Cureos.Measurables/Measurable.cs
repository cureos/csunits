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

namespace Cureos.Measurables
{
    /// <summary>
    /// Implementation struct of a measurable object
    /// </summary>
    /// <typeparam name="U">Unit in which the measurable object is specified</typeparam>
    public struct Measurable<U> : IMeasurable<U>, IComparable<Measurable<U>>, IEquatable<Measurable<U>> where U : IUnit
    {
        #region INSTANCE MEMBERS

        private readonly AmountType mAmount;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes an instance of the measurable object
        /// </summary>
        /// <param name="iAmount">Double-precision amount in the unit of the measurable object</param>
        public Measurable(double iAmount)
        {
            mAmount = (AmountType)iAmount;
        }

        /// <summary>
        /// Initializes an instance of the measurable object
        /// </summary>
        /// <param name="iAmount">Single precision amount in the unit of the measurable object</param>
        public Measurable(float iAmount)
        {
            mAmount = (AmountType)iAmount;
        }

        /// <summary>
        /// Initializes an instance of the measurable object
        /// </summary>
        /// <param name="iAmount">Decimal amount in the unit of the measurable object</param>
        public Measurable(decimal iAmount)
        {
            mAmount = (AmountType)iAmount;
        }

        #endregion

        #region Implementation of IMeasurable<out U>

        /// <summary>
        /// Gets the amount of the measurable
        /// </summary>
        public AmountType Amount
        {
            get { return mAmount; }
        }

        /// <summary>
        /// Gets the unit specific to the measurable object
        /// </summary>
        public U Unit
        {
            get { return UnitReflection.GetUnitInstance<U>(); }
        }

        /// <summary>
        /// Converts the measurable object into another specified unit of the same unit dimension
        /// </summary>
        /// <typeparam name="V">Unit to convert the measurable to</typeparam>
        /// <returns>A new measurable object in the requested unit</returns>
        /// <exception cref="InvalidOperationException">is thrown if the dimensions of the specified unit are not the
        /// same as the dimensions of the unit of this measurable object</exception>
        public IMeasurable<V> InUnit<V>() where V : IUnit
        {
            V toUnit = UnitReflection.GetUnitInstance<V>();
            if (Unit.Dimension.Equals(toUnit.Dimension))
            {
                return new Measurable<V>(toUnit.AmountFromReferenceUnitConverter(Unit.AmountToReferenceUnitConverter(mAmount)));
            }
            throw new InvalidOperationException("Unit dimensions are not equal");
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
        public bool Equals(Measurable<U> other)
        {
            return mAmount.Equals(other.mAmount);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        /// <param name="obj">Another object to compare to. </param>
        /// <filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            return (obj is Measurable<U>) ? Equals((Measurable<U>)obj) : false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return mAmount.GetHashCode();
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Measurable<U> other)
        {
            return mAmount.CompareTo(other.mAmount);
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
            return string.Format("{0} {1}", mAmount, Unit).Trim();
        }

        /// <summary>
        /// Add this object with a measurable object of (potentially) another unit, and return
        /// a summed measurable in the unit of this object
        /// </summary>
        /// <typeparam name="V">Unit of the measurable object to be added</typeparam>
        /// <param name="iOther">Measurable object to add</param>
        /// <returns>Sum of this and other measurable object, in the unit of this object</returns>
        /// <exception cref="InvalidOperationException">is thrown if the dimensions of the specified unit are not the
        /// same as the dimensions of the unit of this measurable object</exception>
        public Measurable<U> Plus<V>(Measurable<V> iOther) where V : IUnit
        {
            return new Measurable<U>(mAmount + iOther.InUnit<U>().Amount);
        }

        /// <summary>
        /// Subtract this object with a measurable object of (potentially) another unit, and return
        /// the difference measurable in the unit of this object
        /// </summary>
        /// <typeparam name="V">Unit of the measurable object to be subtracted</typeparam>
        /// <param name="iOther">Measurable object to subtract</param>
        /// <returns>Difference of this and other measurable object, in the unit of this object</returns>
        /// <exception cref="InvalidOperationException">is thrown if the dimensions of the specified unit are not the
        /// same as the dimensions of the unit of this measurable object</exception>
        public Measurable<U> Minus<V>(Measurable<V> iOther) where V : IUnit
        {
            return new Measurable<U>(mAmount - iOther.InUnit<U>().Amount);
        }

        /// <summary>
        /// Multiply this measurable object with another measurable of a different unit, and return a measurable object
        /// in the specified out unit
        /// </summary>
        /// <typeparam name="VIn">Unit of the measurable object to multiply</typeparam>
        /// <typeparam name="VOut">Requested unit of the resulting measurable object</typeparam>
        /// <param name="iOther">Measurable object to multiply to this object</param>
        /// <returns>Product of this and the other measurable object as a measurable in the requested out unit</returns>
        /// <exception cref="InvalidOperationException">is thrown if the requested out unit does not have the same dimensions
        /// as the unit dimension product of the multiplied measurable objects</exception>
        public Measurable<VOut> Times<VIn, VOut>(Measurable<VIn> iOther) where VIn : IUnit where VOut : IUnit
        {
            VIn rhsUnit = UnitReflection.GetUnitInstance<VIn>();
            VOut toUnit = UnitReflection.GetUnitInstance<VOut>();
            GenericUnit multUnit = GenericUnit.Multiply(Unit, rhsUnit);

            if (!toUnit.Dimension.Equals(multUnit.Dimension))
            {
                throw new InvalidOperationException(
                    "Dimension of requested out unit is not equal to unit dimension of multiplication");
            }

            return new Measurable<VOut>(toUnit.AmountFromReferenceUnitConverter(Unit.AmountToReferenceUnitConverter(mAmount) * rhsUnit.AmountToReferenceUnitConverter(iOther.Amount)));
        }

        /// <summary>
        /// Divide this measurable object with another measurable of a different unit, and return a measurable object
        /// in the specified out unit
        /// </summary>
        /// <typeparam name="VIn">Unit of the measurable object to divide</typeparam>
        /// <typeparam name="VOut">Requested unit of the resulting measurable object</typeparam>
        /// <param name="iOther">Measurable object to divide from this object</param>
        /// <returns>Quotient of this and the other measurable object as a measurable in the requested out unit</returns>
        /// <exception cref="InvalidOperationException">is thrown if the requested out unit does not have the same dimensions
        /// as the unit dimension quotient of the divided measurable objects</exception>
        public Measurable<VOut> Divide<VIn, VOut>(Measurable<VIn> iOther)
            where VIn : IUnit
            where VOut : IUnit
        {
            VIn rhsUnit = UnitReflection.GetUnitInstance<VIn>();
            VOut toUnit = UnitReflection.GetUnitInstance<VOut>();
            GenericUnit divideUnit = GenericUnit.Divide(Unit, rhsUnit);

            if (!toUnit.Dimension.Equals(divideUnit.Dimension))
            {
                throw new InvalidOperationException(
                    "Dimension of requested out unit is not equal to unit dimension of division");
            }

            checked
            {
                return new Measurable<VOut>(toUnit.AmountFromReferenceUnitConverter(Unit.AmountToReferenceUnitConverter(mAmount) / rhsUnit.AmountToReferenceUnitConverter(iOther.Amount)));
            }
        }

        #endregion

        #region OPERATORS

        /// <summary>
        /// Cast operator for floating-point values
        /// </summary>
        /// <param name="iAmount">Floating-point amount</param>
        /// <returns>Measurable object with the specified amount</returns>
        public static explicit operator Measurable<U>(AmountType iAmount)
        {
            return new Measurable<U>(iAmount);
        }

        /// <summary>
        /// Sum two measurable objects of the same unit
        /// </summary>
        /// <param name="iLhs">First measurable object</param>
        /// <param name="iRhs">Second measurable object</param>
        /// <returns>Sum of the measurable objects</returns>
        public static Measurable<U> operator+(Measurable<U> iLhs, Measurable<U> iRhs)
        {
            return new Measurable<U>(iLhs.mAmount + iRhs.mAmount);
        }

        /// <summary>
        /// Subtract two measurable objects of the same unit
        /// </summary>
        /// <param name="iLhs">First measurable object</param>
        /// <param name="iRhs">Second measuable object</param>
        /// <returns>Difference of the measurable objects</returns>
        public static Measurable<U> operator-(Measurable<U> iLhs, Measurable<U> iRhs)
        {
            return new Measurable<U>(iLhs.mAmount - iRhs.mAmount);
        }

        /// <summary>
        /// Multiply a scalar and a measurable object
        /// </summary>
        /// <param name="iScalar">Floating-point scalar</param>
        /// <param name="iMeasurable">Measurable object</param>
        /// <returns>Product of the scalar and the measurable object</returns>
        public static Measurable<U> operator*(AmountType iScalar, Measurable<U> iMeasurable)
        {
            return new Measurable<U>(iScalar * iMeasurable.mAmount);
        }

        /// <summary>
        /// Multiply a measurable object and a scalar
        /// </summary>
        /// <param name="iMeasurable">Measurable object</param>
        /// <param name="iScalar">Floating-point scalar</param>
        /// <returns>Product of the measurable object and the scalar</returns>
        public static Measurable<U> operator *(Measurable<U> iMeasurable, AmountType iScalar)
        {
            return new Measurable<U>(iMeasurable.mAmount * iScalar);
        }

        /// <summary>
        /// Divide a measurable object with a scalar
        /// </summary>
        /// <param name="iMeasurable">Measurable object</param>
        /// <param name="iScalar">Floating-point scalar</param>
        /// <returns>Quotient of the measurable object and the scalar</returns>
        public static Measurable<U> operator /(Measurable<U> iMeasurable, AmountType iScalar)
        {
            checked
            {
                return new Measurable<U>(iMeasurable.mAmount/iScalar);
            }
        }

        /// <summary>
        /// Divide two measurable objects of the same unit
        /// </summary>
        /// <param name="iNumerator">Numerator measurable</param>
        /// <param name="iDenominator">Denominator measurable</param>
        /// <returns>Scalar quotient of the two measurable objects</returns>
        public static AmountType operator /(Measurable<U> iNumerator, Measurable<U> iDenominator)
        {
            checked
            {
                return iNumerator.mAmount / iDenominator.mAmount;
            }
        }

        /// <summary>
        /// Less than operator for Measurable objects
        /// </summary>
        /// <param name="iLhs">First object</param>
        /// <param name="iRhs">Second object</param>
        /// <returns>true if first Measurable object is less than second Measurable object; false otherwise</returns>
        public static bool operator <(Measurable<U> iLhs, Measurable<U> iRhs)
        {
            return iLhs.mAmount < iRhs.mAmount;
        }

        /// <summary>
        /// Greater than operator for Measurable objects
        /// </summary>
        /// <param name="iLhs">First object</param>
        /// <param name="iRhs">Second object</param>
        /// <returns>true if first Measurable object is greater than second Measurable object; false otherwise</returns>
        public static bool operator >(Measurable<U> iLhs, Measurable<U> iRhs)
        {
            return iLhs.mAmount > iRhs.mAmount;
        }

        /// <summary>
        /// Less than or equal to operator for Measurable objects
        /// </summary>
        /// <param name="iLhs">First object</param>
        /// <param name="iRhs">Second object</param>
        /// <returns>true if first Measurable object is less than or equal to second Measurable object; false otherwise</returns>
        public static bool operator <=(Measurable<U> iLhs, Measurable<U> iRhs)
        {
            return iLhs.mAmount <= iRhs.mAmount;
        }

        /// <summary>
        /// Greater than or equal to operator for Measurable objects
        /// </summary>
        /// <param name="iLhs">First object</param>
        /// <param name="iRhs">Second object</param>
        /// <returns>true if first Measurable object is greater than or equal to second Measurable object; false otherwise</returns>
        public static bool operator >=(Measurable<U> iLhs, Measurable<U> iRhs)
        {
            return iLhs.mAmount >= iRhs.mAmount;
        }

        /// <summary>
        /// Equality operator for Measurable objects
        /// </summary>
        /// <param name="iLhs">First object</param>
        /// <param name="iRhs">Second object</param>
        /// <returns>true if the two Measurable objects are equal; false otherwise</returns>
        public static bool operator ==(Measurable<U> iLhs, Measurable<U> iRhs)
        {
            return iLhs.mAmount == iRhs.mAmount;
        }

        /// <summary>
        /// Inquality operator for Measurable objects
        /// </summary>
        /// <param name="iLhs">First object</param>
        /// <param name="iRhs">Second object</param>
        /// <returns>true if the two Measurable objects are not equal; false if they are equal</returns>
        public static bool operator !=(Measurable<U> iLhs, Measurable<U> iRhs)
        {
            return iLhs.mAmount != iRhs.mAmount;
        }

        #endregion
    }
}