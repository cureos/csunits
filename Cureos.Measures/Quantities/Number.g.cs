/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

/*
 * This file is auto-generated.
 */

namespace Cureos.Measures.Quantities
{
    using System;

#if SINGLE
    using AmountType = System.Single;
#elif DECIMAL
    using AmountType = System.Decimal;
#elif DOUBLE
    using AmountType = System.Double;
#endif

    /// <summary>
    /// Implementation of the number quantity
    /// </summary>
    public partial struct Number : IQuantity<Number>, IMeasure<Number>
    {
        #region FIELDS

        private static readonly QuantityDimension dimension = QuantityDimension.Number;

        public static readonly Unit<Number> One = new Unit<Number>("");


        public static readonly Unit<Number> Percent = new Unit<Number>("%", Factors.Centi);
        public static readonly Unit<Number> Permille = new Unit<Number>("\u2030", Factors.Milli);
        public static readonly Unit<Number> PartsPerMillion = new Unit<Number>("ppm", Factors.Micro);

        private readonly AmountType amount;
        private readonly IUnit<Number> unit;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a Number object from an object implementing the IMeasure&lt;Number&gt; interface
        /// </summary>
        /// <param name="other">Object implemeting the IMeasure&lt;Number&gt; interface</param>
        public Number(IMeasure<Number> other)
            : this(other.Amount, other.Unit)
        {
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public Number(double amount)
            : this(amount, default(Number).StandardUnit)
        {
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public Number(float amount)
            : this(amount, default(Number).StandardUnit)
        {
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public Number(decimal amount)
            : this(amount, default(Number).StandardUnit)
        {
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public Number(double amount, IUnit<Number> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");

            this.amount = (AmountType)amount;
            this.unit = unit;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public Number(float amount, IUnit<Number> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");

            this.amount = (AmountType)amount;
            this.unit = unit;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public Number(decimal amount, IUnit<Number> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");

            this.amount = (AmountType)amount;
            this.unit = unit;
        }

        #endregion

        #region Implementation of IQuantity<Number>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return dimension; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        IUnit IQuantity.StandardUnit
        {
            get { return this.StandardUnit; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        public IUnit<Number> StandardUnit
        {
            get { return One; }
        }

        #endregion

        #region Implementation of IMeasure<Number>

        /// <summary>
        /// Gets the measured amount in the <see cref="Unit">current unit of measure</see>
        /// </summary>
        public AmountType Amount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the measured amount in the standard unit of measure for the number quantity</typeparam>
        /// </summary
        public AmountType StandardAmount
        {
            get { return this.unit.AmountToStandardUnitConverter(this.amount); }
        }

        /// <summary>
        /// Gets the unit of measure
        /// </summary>
        IUnit IMeasure.Unit
        {
            get { return this.Unit; }
        }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="unit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="unit">specified unit</paramref></returns>
        AmountType IMeasure.GetAmount(IUnit unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            if (!unit.Quantity.Equals(default(Number))) throw new ArgumentException("Unit is not the same quantity as measure");
            return unit.AmountFromStandardUnitConverter(this.StandardAmount);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        /// <exception cref="ArgumentNullException">if specified unit is null or if specified unit is not of the 
        /// <typeparamref name="Q">valid quantity</typeparamref></exception>
        IMeasure IMeasure.this[IUnit unit]
        {
            get { return this[unit as IUnit<Number>]; }
        }

        /// <summary>
        /// Gets the quantity-typed unit of measure
        /// </summary>
        public IUnit<Number> Unit
        {
            get { return this.unit; }
        }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="unit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="unit">specified unit</paramref></returns>
        public AmountType GetAmount(IUnit<Number> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            return unit.AmountFromStandardUnitConverter(this.StandardAmount);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        IMeasure<Number> IMeasure<Number>.this[IUnit<Number> unit]
        {
            get { return this[unit]; }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(IMeasure<Number> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.amount.Equals(other.GetAmount(this.unit));
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
            if (!other.Unit.Quantity.Equals(default(Number))) throw new ArgumentException("Measures are of different quantities");
            return this.amount.Equals(other.GetAmount(this.unit));
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
        public int CompareTo(IMeasure<Number> other)
        {
            if (other == null) throw new ArgumentNullException("other");
            return this.amount.CompareTo(other.GetAmount(this.unit));
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
            if (!other.Unit.Quantity.Equals(default(Number))) throw new ArgumentException("Measures are of different quantities");
            return this.amount.CompareTo(other.GetAmount(this.unit));
        }

        #endregion

        #region INDEXERS

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        public Number this[IUnit<Number> unit]
        {
            get
            {
                if (unit == null) throw new ArgumentNullException("unit");
                return new Number(this.GetAmount(unit), unit);
            }
        }

        #endregion

        #region METHODS

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
            if (obj.GetType() != typeof(IMeasure<Number>)) return false;
            return this.Equals((IMeasure<Number>)obj);
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
            return this.StandardAmount.GetHashCode();
        }

        /// <summary>
        /// Returns the actual value with the quantity suffixed
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a the actual value with the quantity symbol appended
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return String.Format("{0} {1} (number)", this.amount, this.unit.Symbol).Trim();
        }

        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="format">Format string to display the value with</param>
        /// <returns>A <see cref="T:System.String"/> containing a the actual value in formatted form with the quantity symbol appended</returns>
        public string ToString(string format)
        {
            return String.Format("{0} {1} (number)", this.amount.ToString(format), this.unit.Symbol).Trim();
        }
        
        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="provider">Formatting provider to format the value with</param>
        /// <returns></returns>
        public string ToString(IFormatProvider provider)
        {
            return String.Format("{0} {1} (number)", this.amount.ToString(provider), this.unit.Symbol).Trim();
        }
        
        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="format">Format string to display the value with</param>
        /// <param name="provider">Formatting provider to format the value with</param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider provider)
        {
            return String.Format("{0} {1} (number)", this.amount.ToString(format, provider), this.unit.Symbol).Trim();
        }
        
        #endregion

        #region OPERATORS

        /// <summary>
        /// Casts a float value to a Number object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>Number representation of <paramref name="standardAmount"/> in unit One</returns>
        public static explicit operator Number(float standardAmount)
        {
            return new Number(standardAmount);
        }

        /// <summary>
        /// Casts a double value to a Number object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>Number representation of <paramref name="standardAmount"/> in unit One</returns>
        public static explicit operator Number(double standardAmount)
        {
            return new Number(standardAmount);
        }

        /// <summary>
        /// Casts a decimal value to a Number object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>Number representation of <paramref name="standardAmount"/> in unit One</returns>
        public static explicit operator Number(decimal standardAmount)
        {
            return new Number(standardAmount);
        }
        
        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static Number operator +(Number lhs,  Number rhs)
        {
            return new Number(lhs.amount + rhs.GetAmount(lhs.unit), lhs.unit);
        }

        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term (any object implementing the IMeasure interface)</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static Number operator +(Number lhs, IMeasure<Number> rhs)
        {
            return new Number(lhs.amount + rhs.GetAmount(lhs.unit), lhs.unit);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object</param>
        /// <returns>Difference of the measure objects</returns>
        public static Number operator -(Number lhs, Number rhs)
        {
            return new Number(lhs.amount - rhs.GetAmount(lhs.unit), lhs.unit);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object (any object implementing the IMeasure interface)</param>
        /// <returns>Difference of the measure objects</returns>
        public static Number operator -(Number lhs, IMeasure<Number> rhs)
        {
            return new Number(lhs.amount - rhs.GetAmount(lhs.unit), lhs.unit);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="iMeasure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static Number operator *(AmountType scalar, Number iMeasure)
        {
            return new Number(scalar * iMeasure.amount, iMeasure.unit);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="iMeasure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static Number operator *(Number iMeasure, AmountType scalar)
        {
            return new Number(iMeasure.amount * scalar, iMeasure.unit);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="iMeasure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static Number operator /(Number iMeasure, AmountType scalar)
        {
            return new Number(iMeasure.amount / scalar, iMeasure.unit);
        }

        /// <summary>
        /// Less than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(Number lhs, Number rhs)
        {
            return lhs.amount < rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Less than operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(Number lhs, IMeasure<Number> rhs)
        {
            return lhs.amount < rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Greater than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(Number lhs, Number rhs)
        {
            return lhs.amount > rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Greater than operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(Number lhs, IMeasure<Number> rhs)
        {
            return lhs.amount > rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Less than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(Number lhs, Number rhs)
        {
            return lhs.amount <= rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Less than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(Number lhs, IMeasure<Number> rhs)
        {
            return lhs.amount <= rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(Number lhs, Number rhs)
        {
            return lhs.amount >= rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(Number lhs, IMeasure<Number> rhs)
        {
            return lhs.amount >= rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Equality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(Number lhs, Number rhs)
        {
            return lhs.amount == rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Equality operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(Number lhs, IMeasure<Number> rhs)
        {
            return lhs.amount == rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Inequality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(Number lhs, Number rhs)
        {
            return lhs.amount != rhs.GetAmount(lhs.unit);
        }

        /// <summary>
        /// Inequality operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(Number lhs, IMeasure<Number> rhs)
        {
            return lhs.amount != rhs.GetAmount(lhs.unit);
        }

        #endregion
    }
}
