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
    using System.Globalization;
    using System.Runtime.Serialization;

#if SINGLE
    using AmountType = System.Single;
#elif DECIMAL
    using AmountType = System.Decimal;
#elif DOUBLE
    using AmountType = System.Double;
#endif

    /// <summary>
    /// Implementation of the plane angle quantity
    /// </summary>
    [DataContract]
    public partial struct PlaneAngle : IQuantity<PlaneAngle>, IMeasure<PlaneAngle>, IEquatable<PlaneAngle>, IComparable<PlaneAngle>
    {
        #region FIELDS

        // ReSharper disable once InconsistentNaming
        private static readonly IMeasureFactory<PlaneAngle> factory = new MeasureFactory();

        // ReSharper disable once InconsistentNaming
        private static readonly QuantityDimension dimension = QuantityDimension.Radian;

        public static readonly Unit<PlaneAngle> Radian = new ConstantConverterUnit<PlaneAngle>("rad");

        public static readonly Unit<PlaneAngle> Degree = new ConstantConverterUnit<PlaneAngle>("°", Factors.RadiansPerDegree);
        public static readonly Unit<PlaneAngle> Minute = new ConstantConverterUnit<PlaneAngle>("'", Factors.RadiansPerMinute);
        public static readonly Unit<PlaneAngle> Second = new ConstantConverterUnit<PlaneAngle>("\"", Factors.RadiansPerSecond);

        [DataMember]
        private readonly AmountType amount;

        #endregion

        #region CONSTRUCTORS

#if !MONO
        /// <summary>
        /// Static constructor for defining static class properties
        /// </summary>
        static PlaneAngle()
        {
            Zero = new PlaneAngle(Constants.Zero);
            Epsilon = new PlaneAngle(Constants.MachineEpsilon);
        }
#endif
        
        /// <summary>
        /// Initializes a plane angle object from an object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="other">Object implemeting the IMeasure&lt;PlaneAngle&gt; interface</param>
        public PlaneAngle(IMeasure<PlaneAngle> other)
            : this(other.StandardAmount)
        {
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public PlaneAngle(double amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public PlaneAngle(float amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public PlaneAngle(decimal amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public PlaneAngle(double amount, IUnit<PlaneAngle> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            this.amount = unit.ConvertAmountToStandardUnit((AmountType)amount);
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public PlaneAngle(float amount, IUnit<PlaneAngle> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            this.amount = unit.ConvertAmountToStandardUnit((AmountType)amount);
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public PlaneAngle(decimal amount, IUnit<PlaneAngle> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            this.amount = unit.ConvertAmountToStandardUnit((AmountType)amount);
        }

        #endregion

        #region Implementation of IQuantity<PlaneAngle>

        /// <summary>
        /// Gets the display name of the quantity
        /// </summary>
        public string DisplayName 
        { 
            get { return "Plane Angle"; } 
        }

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
        public IUnit<PlaneAngle> StandardUnit
        {
            get { return Radian; }
        }

        /// <summary>
        /// Gets the measure factory associated with the quantity.
        /// </summary>
        public IMeasureFactory<PlaneAngle> Factory
        { 
            get { return factory; }
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        bool IEquatable<IQuantity>.Equals(IQuantity other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            return other is PlaneAngle;
        }

        #endregion

        #region Implementation of IMeasure<PlaneAngle>

        /// <summary>
        /// Gets the measured amount in the <see cref="StandardUnit">standard unit of measure</see>
        /// </summary>
        public AmountType Amount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the measured amount in the standard unit of measure for the plane angle quantity
        /// </summary>
        public AmountType StandardAmount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the unit of measure
        /// </summary>
        /// <remarks>Always return the standard unit of measure</remarks>
        IUnit IMeasure.Unit
        {
            get { return this.StandardUnit; }
        }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="unit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="unit">specified unit</paramref></returns>
        AmountType IMeasure.GetAmount(IUnit unit)
        {
            return this.GetAmount(unit as IUnit<PlaneAngle>);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        /// <exception cref="ArgumentNullException">if specified unit is null or if specified unit is not of the PlaneAngle quantity.</exception>
        IMeasure IMeasure.this[IUnit unit]
        {
            get { return this[unit as IUnit<PlaneAngle>]; }
        }

        /// <summary>
        /// Gets the quantity-typed unit of measure
        /// </summary>
        /// <remarks>Always return the standard unit of measure</remarks>
        public IUnit<PlaneAngle> Unit
        {
            get { return this.StandardUnit; }
        }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="unit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="unit">specified unit</paramref></returns>
        public AmountType GetAmount(IUnit<PlaneAngle> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            return unit.ConvertStandardAmountToUnit(this.amount);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        IMeasure<PlaneAngle> IMeasure<PlaneAngle>.this[IUnit<PlaneAngle> unit]
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
        bool IEquatable<IMeasure<PlaneAngle>>.Equals(IMeasure<PlaneAngle> other)
        {
            if (ReferenceEquals(null, other)) return false;
            return this.amount.Equals(other.StandardAmount);
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
            return this.Equals(other as IMeasure<PlaneAngle>);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings:  
        ///    Value              Meaning 
        ///    Less than zero     This object is less than the <paramref name="other"/> parameter.
        ///    Zero               This object is equal to <paramref name="other"/>. 
        ///    Greater than zero  This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        int IComparable<IMeasure<PlaneAngle>>.CompareTo(IMeasure<PlaneAngle> other)
        {
            if (other == null) throw new ArgumentNullException("other");
            return this.amount.CompareTo(other.StandardAmount);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings:  
        ///    Value              Meaning 
        ///    Less than zero     This object is less than the <paramref name="other"/> parameter.
        ///    Zero               This object is equal to <paramref name="other"/>. 
        ///    Greater than zero  This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        int IComparable<IMeasure>.CompareTo(IMeasure other)
        {
            if (other == null) throw new ArgumentNullException("other");
            if (!(other.Unit.Quantity is IMeasure<PlaneAngle>)) throw new ArgumentException("Measures are of different quantities");
            return this.amount.CompareTo(other.StandardAmount);
        }

        #endregion

        #region Implementation of IEquatable<PlaneAngle>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(PlaneAngle other)
        {
            return this.amount.Equals(other.amount);
        }

        #endregion

        #region Implementation of IComparable<PlaneAngle>

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings:  
        ///    Value              Meaning 
        ///    Less than zero     This object is less than the <paramref name="other"/> parameter.
        ///    Zero               This object is equal to <paramref name="other"/>. 
        ///    Greater than zero  This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(PlaneAngle other)
        {
            return this.amount.CompareTo(other.amount);
        }

        #endregion

        #region INDEXERS

        /// <summary>
        /// Gets a new unit preserving measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        public Measure<PlaneAngle> this[IUnit<PlaneAngle> unit]
        {
            get
            {
                if (unit == null) throw new ArgumentNullException("unit");
                return new Measure<PlaneAngle>(this.GetAmount(unit), unit);
            }
        }

        #endregion

#if !MONO
        #region PROPERTIES
        
        public static PlaneAngle Zero { get; private set; }

        public static PlaneAngle Epsilon { get; private set; }

        #endregion
#endif
        
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
            return obj is IMeasure<PlaneAngle> && this.Equals((IMeasure<PlaneAngle>)obj);
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
            return this.amount.GetHashCode();
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
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="format">Format string to display the value with</param>
        /// <returns>A <see cref="T:System.String"/> containing a the actual value in formatted form with the quantity symbol appended</returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }
        
        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="provider">Formatting provider to format the value with</param>
        /// <returns></returns>
        public string ToString(IFormatProvider provider)
        {
            return this.ToString("G", provider);
        }
        
        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="format">Format string to display the value with</param>
        /// <param name="provider">Formatting provider to format the value with</param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider provider)
        {
            return String.Format("({0}) {1} {2}", this.DisplayName, this.amount.ToString(format, provider), this.Unit.Symbol).TrimEnd();
        }
        
        #endregion

        #region OPERATORS

        /// <summary>
        /// Casts a float value to a PlaneAngle object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>PlaneAngle representation of <paramref name="standardAmount"/> in unit Radian</returns>
        public static explicit operator PlaneAngle(float standardAmount)
        {
            return new PlaneAngle(standardAmount);
        }

        /// <summary>
        /// Casts a double value to a PlaneAngle object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>PlaneAngle representation of <paramref name="standardAmount"/> in unit Radian</returns>
        public static explicit operator PlaneAngle(double standardAmount)
        {
            return new PlaneAngle(standardAmount);
        }

        /// <summary>
        /// Casts a decimal value to a PlaneAngle object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>PlaneAngle representation of <paramref name="standardAmount"/> in unit Radian</returns>
        public static explicit operator PlaneAngle(decimal standardAmount)
        {
            return new PlaneAngle(standardAmount);
        }
        
        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static PlaneAngle operator +(PlaneAngle lhs,  PlaneAngle rhs)
        {
            return new PlaneAngle(lhs.amount + rhs.amount);
        }

        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term (any object implementing the IMeasure interface)</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static PlaneAngle operator +(PlaneAngle lhs, IMeasure<PlaneAngle> rhs)
        {
            return new PlaneAngle(lhs.amount + rhs.StandardAmount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object</param>
        /// <returns>Difference of the measure objects</returns>
        public static PlaneAngle operator -(PlaneAngle lhs, PlaneAngle rhs)
        {
            return new PlaneAngle(lhs.amount - rhs.amount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object (any object implementing the IMeasure interface)</param>
        /// <returns>Difference of the measure objects</returns>
        public static PlaneAngle operator -(PlaneAngle lhs, IMeasure<PlaneAngle> rhs)
        {
            return new PlaneAngle(lhs.amount - rhs.StandardAmount);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static PlaneAngle operator *(AmountType scalar, PlaneAngle measure)
        {
            return new PlaneAngle(scalar * measure.amount);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static PlaneAngle operator *(PlaneAngle measure, AmountType scalar)
        {
            return new PlaneAngle(measure.amount * scalar);
        }

        /// <summary>
        /// Multiply a number and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point number</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the number and the measure object</returns>
        public static PlaneAngle operator *(IMeasure<Number> scalar, PlaneAngle measure)
        {
            return new PlaneAngle(scalar.StandardAmount * measure.amount);
        }

        /// <summary>
        /// Multiply a measure object and a number
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point number</param>
        /// <returns>Product of the measure object and the number</returns>
        public static PlaneAngle operator *(PlaneAngle measure, IMeasure<Number> scalar)
        {
            return new PlaneAngle(measure.amount * scalar.StandardAmount);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static PlaneAngle operator /(PlaneAngle measure, AmountType scalar)
        {
            return new PlaneAngle(measure.amount / scalar);
        }

        /// <summary>
        /// Divide a measure object with a number
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point number</param>
        /// <returns>Quotient of the measure object and the number</returns>
        public static PlaneAngle operator /(PlaneAngle measure, IMeasure<Number> scalar)
        {
            return new PlaneAngle(measure.amount / scalar.StandardAmount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(PlaneAngle dividend, PlaneAngle divisor)
        {
            return new Number(dividend.amount / divisor.amount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(IMeasure<PlaneAngle> dividend, PlaneAngle divisor)
        {
            return new Number(dividend.StandardAmount / divisor.amount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(PlaneAngle dividend, IMeasure<PlaneAngle> divisor)
        {
            return new Number(dividend.amount / divisor.StandardAmount);
        }

        /// <summary>
        /// Less than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(PlaneAngle lhs, PlaneAngle rhs)
        {
            return lhs.amount < rhs.amount;
        }

        /// <summary>
        /// Less than operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(PlaneAngle lhs, IMeasure<PlaneAngle> rhs)
        {
            return lhs.amount < rhs.StandardAmount;
        }

        /// <summary>
        /// Less than operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(IMeasure<PlaneAngle> lhs, PlaneAngle rhs)
        {
            return lhs.StandardAmount < rhs.amount;
        }

        /// <summary>
        /// Greater than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(PlaneAngle lhs, PlaneAngle rhs)
        {
            return lhs.amount > rhs.amount;
        }

        /// <summary>
        /// Greater than operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(PlaneAngle lhs, IMeasure<PlaneAngle> rhs)
        {
            return lhs.amount > rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(IMeasure<PlaneAngle> lhs, PlaneAngle rhs)
        {
            return lhs.StandardAmount > rhs.amount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(PlaneAngle lhs, PlaneAngle rhs)
        {
            return lhs.amount <= rhs.amount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(PlaneAngle lhs, IMeasure<PlaneAngle> rhs)
        {
            return lhs.amount <= rhs.StandardAmount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(IMeasure<PlaneAngle> lhs, PlaneAngle rhs)
        {
            return lhs.StandardAmount <= rhs.amount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(PlaneAngle lhs, PlaneAngle rhs)
        {
            return lhs.amount >= rhs.amount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(PlaneAngle lhs, IMeasure<PlaneAngle> rhs)
        {
            return lhs.amount >= rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(IMeasure<PlaneAngle> lhs, PlaneAngle rhs)
        {
            return lhs.StandardAmount >= rhs.amount;
        }

        /// <summary>
        /// Equality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(PlaneAngle lhs, PlaneAngle rhs)
        {
            return lhs.amount == rhs.amount;
        }

        /// <summary>
        /// Equality operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(PlaneAngle lhs, IMeasure<PlaneAngle> rhs)
        {
            return lhs.amount == rhs.StandardAmount;
        }

        /// <summary>
        /// Equality operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(IMeasure<PlaneAngle> lhs, PlaneAngle rhs)
        {
            return lhs.StandardAmount == rhs.amount;
        }

        /// <summary>
        /// Inequality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(PlaneAngle lhs, PlaneAngle rhs)
        {
            return lhs.amount != rhs.amount;
        }

        /// <summary>
        /// Inequality operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(PlaneAngle lhs, IMeasure<PlaneAngle> rhs)
        {
            return lhs.amount != rhs.StandardAmount;
        }

        /// <summary>
        /// Inequality operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;PlaneAngle&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;PlaneAngle&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(IMeasure<PlaneAngle> lhs, PlaneAngle rhs)
        {
            return lhs.StandardAmount != rhs.amount;
        }

        #endregion

        #region Private class implementation of IMeasureFactory<PlaneAngle>

        private class MeasureFactory : IMeasureFactory<PlaneAngle>
        {
            /// <summary>
            /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
            public PlaneAngle New(double amount)
            {
                return new PlaneAngle(amount);
            }

            /// <summary>
            /// Creates a new standard unit measure.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Standard unit measure.</returns>
            public PlaneAngle New(double amount, IUnit<PlaneAngle> unit)
            {
                return new PlaneAngle(amount, unit);
            }

            /// <summary>
            /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
            public PlaneAngle New(float amount)
            {
                return new PlaneAngle(amount);
            }

            /// <summary>
            /// Creates a new standard unit measure.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Standard unit measure.</returns>
            public PlaneAngle New(float amount, IUnit<PlaneAngle> unit)
            {
                return new PlaneAngle(amount, unit);
            }

            /// <summary>
            /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
            public PlaneAngle New(decimal amount)
            {
                return new PlaneAngle(amount);
            }

            /// <summary>
            /// Creates a new standard unit measure.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Standard unit measure.</returns>
            public PlaneAngle New(decimal amount, IUnit<PlaneAngle> unit)
            {
                return new PlaneAngle(amount, unit);
            }

            /// <summary>
            /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
            public IMeasure<PlaneAngle> NewPreserveUnit(double amount, IUnit<PlaneAngle> unit)
            {
                return new Measure<PlaneAngle>(amount, unit);
            }

            /// <summary>
            /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
            public IMeasure<PlaneAngle> NewPreserveUnit(float amount, IUnit<PlaneAngle> unit)
            {
                return new Measure<PlaneAngle>(amount, unit);
            }

            /// <summary>
            /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
            public IMeasure<PlaneAngle> NewPreserveUnit(decimal amount, IUnit<PlaneAngle> unit)
            {
                return new Measure<PlaneAngle>(amount, unit);
            }
        }

        #endregion
    }
}
