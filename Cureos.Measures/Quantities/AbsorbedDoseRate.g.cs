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
    /// Implementation of the absorbed dose rate quantity
    /// </summary>
    [DataContract]
    public partial struct AbsorbedDoseRate : IQuantity<AbsorbedDoseRate>, IMeasure<AbsorbedDoseRate>, IEquatable<AbsorbedDoseRate>, IComparable<AbsorbedDoseRate>
    {
        #region FIELDS

        // ReSharper disable once InconsistentNaming
        private static readonly IMeasureFactory<AbsorbedDoseRate> factory = new MeasureFactory();

        // ReSharper disable once InconsistentNaming
        private static readonly QuantityDimension dimension = new QuantityDimension(2, 0, -3, 0, 0, 0, 0);

        public static readonly Unit<AbsorbedDoseRate> GrayPerSecond = new ConstantConverterUnit<AbsorbedDoseRate>("Gy s\u207b¹");

        public static readonly Unit<AbsorbedDoseRate> NanoGrayPerSecond = new ConstantConverterUnit<AbsorbedDoseRate>(UnitPrefix.Nano);
        public static readonly Unit<AbsorbedDoseRate> MicroGrayPerSecond = new ConstantConverterUnit<AbsorbedDoseRate>(UnitPrefix.Micro);
        public static readonly Unit<AbsorbedDoseRate> MilliGrayPerSecond = new ConstantConverterUnit<AbsorbedDoseRate>(UnitPrefix.Milli);
        public static readonly Unit<AbsorbedDoseRate> CentiGrayPerSecond = new ConstantConverterUnit<AbsorbedDoseRate>(UnitPrefix.Centi);
        public static readonly Unit<AbsorbedDoseRate> DeciGrayPerSecond = new ConstantConverterUnit<AbsorbedDoseRate>(UnitPrefix.Deci);
        public static readonly Unit<AbsorbedDoseRate> DekaGrayPerSecond = new ConstantConverterUnit<AbsorbedDoseRate>(UnitPrefix.Deka);
        public static readonly Unit<AbsorbedDoseRate> HectoGrayPerSecond = new ConstantConverterUnit<AbsorbedDoseRate>(UnitPrefix.Hecto);
        public static readonly Unit<AbsorbedDoseRate> KiloGrayPerSecond = new ConstantConverterUnit<AbsorbedDoseRate>(UnitPrefix.Kilo);

        public static readonly Unit<AbsorbedDoseRate> GrayPerMinute = new ConstantConverterUnit<AbsorbedDoseRate>("Gy min\u207b¹", Factors.One / Factors.SecondsPerMinute);
        public static readonly Unit<AbsorbedDoseRate> CentiGrayPerMinute = new ConstantConverterUnit<AbsorbedDoseRate>("cGy min\u207b¹", Factors.Centi / Factors.SecondsPerMinute);

        [DataMember]
        private readonly AmountType amount;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Static constructor for defining static class properties
        /// </summary>
        static AbsorbedDoseRate()
        {
            Zero = new AbsorbedDoseRate(Constants.Zero);
            Epsilon = new AbsorbedDoseRate(Constants.MachineEpsilon);
        }
        
        /// <summary>
        /// Initializes a absorbed dose rate object from an object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="other">Object implemeting the IMeasure&lt;AbsorbedDoseRate&gt; interface</param>
        public AbsorbedDoseRate(IMeasure<AbsorbedDoseRate> other)
            : this(other.StandardAmount)
        {
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public AbsorbedDoseRate(double amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public AbsorbedDoseRate(float amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public AbsorbedDoseRate(decimal amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public AbsorbedDoseRate(double amount, IUnit<AbsorbedDoseRate> unit)
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
        public AbsorbedDoseRate(float amount, IUnit<AbsorbedDoseRate> unit)
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
        public AbsorbedDoseRate(decimal amount, IUnit<AbsorbedDoseRate> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            this.amount = unit.ConvertAmountToStandardUnit((AmountType)amount);
        }

        #endregion

        #region Implementation of IQuantity<AbsorbedDoseRate>

        /// <summary>
        /// Gets the display name of the quantity
        /// </summary>
        public string DisplayName 
        { 
            get { return "Absorbed Dose Rate"; } 
        }

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        QuantityDimension IQuantity.Dimension
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
        public IUnit<AbsorbedDoseRate> StandardUnit
        {
            get { return GrayPerSecond; }
        }

        /// <summary>
        /// Gets the measure factory associated with the quantity.
        /// </summary>
        IMeasureFactory<AbsorbedDoseRate> IQuantity<AbsorbedDoseRate>.Factory
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
            return other is AbsorbedDoseRate;
        }

        #endregion

        #region Implementation of IMeasure<AbsorbedDoseRate>

        /// <summary>
        /// Gets the measured amount in the <see cref="StandardUnit">standard unit of measure</see>
        /// </summary>
        public AmountType Amount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the measured amount in the standard unit of measure for the absorbed dose rate quantity
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
            return this.GetAmount(unit as IUnit<AbsorbedDoseRate>);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        /// <exception cref="ArgumentNullException">if specified unit is null or if specified unit is not of the AbsorbedDoseRate quantity.</exception>
        IMeasure IMeasure.this[IUnit unit]
        {
            get { return this[unit as IUnit<AbsorbedDoseRate>]; }
        }

        /// <summary>
        /// Gets the quantity-typed unit of measure
        /// </summary>
        /// <remarks>Always return the standard unit of measure</remarks>
        public IUnit<AbsorbedDoseRate> Unit
        {
            get { return this.StandardUnit; }
        }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="unit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="unit">specified unit</paramref></returns>
        public AmountType GetAmount(IUnit<AbsorbedDoseRate> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            return unit.ConvertStandardAmountToUnit(this.amount);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        IMeasure<AbsorbedDoseRate> IMeasure<AbsorbedDoseRate>.this[IUnit<AbsorbedDoseRate> unit]
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
        bool IEquatable<IMeasure<AbsorbedDoseRate>>.Equals(IMeasure<AbsorbedDoseRate> other)
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
            return this.Equals(other as IMeasure<AbsorbedDoseRate>);
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
        int IComparable<IMeasure<AbsorbedDoseRate>>.CompareTo(IMeasure<AbsorbedDoseRate> other)
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
            if (!(other.Unit.Quantity is IMeasure<AbsorbedDoseRate>)) throw new ArgumentException("Measures are of different quantities");
            return this.amount.CompareTo(other.StandardAmount);
        }

        #endregion

        #region Implementation of IEquatable<AbsorbedDoseRate>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(AbsorbedDoseRate other)
        {
            return this.amount.Equals(other.amount);
        }

        #endregion

        #region Implementation of IComparable<AbsorbedDoseRate>

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
        public int CompareTo(AbsorbedDoseRate other)
        {
            return this.amount.CompareTo(other.amount);
        }

        #endregion

        #region INDEXERS

        /// <summary>
        /// Gets a new unit preserving measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        public Measure<AbsorbedDoseRate> this[IUnit<AbsorbedDoseRate> unit]
        {
            get
            {
                if (unit == null) throw new ArgumentNullException("unit");
                return new Measure<AbsorbedDoseRate>(this.GetAmount(unit), unit);
            }
        }

        #endregion

        #region PROPERTIES
        
        public static AbsorbedDoseRate Zero { get; private set; }

        public static AbsorbedDoseRate Epsilon { get; private set; }

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
            return obj is IMeasure<AbsorbedDoseRate> && this.Equals((IMeasure<AbsorbedDoseRate>)obj);
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
        /// A <see cref="T:System.String"/> containing the actual value and unit
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
        /// <returns>A <see cref="T:System.String"/> containing the actual value in formatted form and unit</returns>
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }
        
        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="provider">Formatting provider to format the value with</param>
        /// <returns>A <see cref="T:System.String"/> containing the actual value and unit</returns>
        public string ToString(IFormatProvider provider)
        {
            return this.ToString("G", provider);
        }
        
        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="format">Format string to display the value with</param>
        /// <param name="provider">Formatting provider to format the value with</param>
        /// <returns>A <see cref="T:System.String"/> containing the actual value in formatted form and unit</returns>
        public string ToString(string format, IFormatProvider provider)
        {
            return String.Format("{0} {1}", this.amount.ToString(format, provider), this.Unit.Symbol).TrimEnd();
        }
        
        #endregion

        #region OPERATORS

        /// <summary>
        /// Casts a double value to a AbsorbedDoseRate object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>AbsorbedDoseRate representation of <paramref name="standardAmount"/> in unit GrayPerSecond</returns>
        public static explicit operator AbsorbedDoseRate(double standardAmount)
        {
            return new AbsorbedDoseRate(standardAmount);
        }

        /// <summary>
        /// Casts a float value to a AbsorbedDoseRate object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>AbsorbedDoseRate representation of <paramref name="standardAmount"/> in unit GrayPerSecond</returns>
        public static explicit operator AbsorbedDoseRate(float standardAmount)
        {
            return new AbsorbedDoseRate(standardAmount);
        }

        /// <summary>
        /// Casts a decimal value to a AbsorbedDoseRate object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>AbsorbedDoseRate representation of <paramref name="standardAmount"/> in unit GrayPerSecond</returns>
        public static explicit operator AbsorbedDoseRate(decimal standardAmount)
        {
            return new AbsorbedDoseRate(standardAmount);
        }
        
        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static AbsorbedDoseRate operator +(AbsorbedDoseRate lhs,  AbsorbedDoseRate rhs)
        {
            return new AbsorbedDoseRate(lhs.amount + rhs.amount);
        }

        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term (any object implementing the IMeasure interface)</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static AbsorbedDoseRate operator +(AbsorbedDoseRate lhs, IMeasure<AbsorbedDoseRate> rhs)
        {
            return new AbsorbedDoseRate(lhs.amount + rhs.StandardAmount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object</param>
        /// <returns>Difference of the measure objects</returns>
        public static AbsorbedDoseRate operator -(AbsorbedDoseRate lhs, AbsorbedDoseRate rhs)
        {
            return new AbsorbedDoseRate(lhs.amount - rhs.amount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object (any object implementing the IMeasure interface)</param>
        /// <returns>Difference of the measure objects</returns>
        public static AbsorbedDoseRate operator -(AbsorbedDoseRate lhs, IMeasure<AbsorbedDoseRate> rhs)
        {
            return new AbsorbedDoseRate(lhs.amount - rhs.StandardAmount);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static AbsorbedDoseRate operator *(double scalar, AbsorbedDoseRate measure)
        {
            return new AbsorbedDoseRate((AmountType)scalar * measure.amount);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static AbsorbedDoseRate operator *(float scalar, AbsorbedDoseRate measure)
        {
            return new AbsorbedDoseRate((AmountType)scalar * measure.amount);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static AbsorbedDoseRate operator *(decimal scalar, AbsorbedDoseRate measure)
        {
            return new AbsorbedDoseRate((AmountType)scalar * measure.amount);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static AbsorbedDoseRate operator *(AbsorbedDoseRate measure, double scalar)
        {
            return new AbsorbedDoseRate(measure.amount * (AmountType)scalar);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static AbsorbedDoseRate operator *(AbsorbedDoseRate measure, float scalar)
        {
            return new AbsorbedDoseRate(measure.amount * (AmountType)scalar);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static AbsorbedDoseRate operator *(AbsorbedDoseRate measure, decimal scalar)
        {
            return new AbsorbedDoseRate(measure.amount * (AmountType)scalar);
        }

        /// <summary>
        /// Multiply a measure object and a number
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point number</param>
        /// <returns>Product of the measure object and the number</returns>
        public static AbsorbedDoseRate operator *(AbsorbedDoseRate measure, IMeasure<Number> scalar)
        {
            return new AbsorbedDoseRate(measure.amount * scalar.StandardAmount);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static AbsorbedDoseRate operator /(AbsorbedDoseRate measure, double scalar)
        {
            return new AbsorbedDoseRate(measure.amount / (AmountType)scalar);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static AbsorbedDoseRate operator /(AbsorbedDoseRate measure, float scalar)
        {
            return new AbsorbedDoseRate(measure.amount / (AmountType)scalar);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static AbsorbedDoseRate operator /(AbsorbedDoseRate measure, decimal scalar)
        {
            return new AbsorbedDoseRate(measure.amount / (AmountType)scalar);
        }

        /// <summary>
        /// Divide a measure object with a number
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point number</param>
        /// <returns>Quotient of the measure object and the number</returns>
        public static AbsorbedDoseRate operator /(AbsorbedDoseRate measure, IMeasure<Number> scalar)
        {
            return new AbsorbedDoseRate(measure.amount / scalar.StandardAmount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(AbsorbedDoseRate dividend, AbsorbedDoseRate divisor)
        {
            return new Number(dividend.amount / divisor.amount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(AbsorbedDoseRate dividend, IMeasure<AbsorbedDoseRate> divisor)
        {
            return new Number(dividend.amount / divisor.StandardAmount);
        }

        /// <summary>
        /// Less than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(AbsorbedDoseRate lhs, AbsorbedDoseRate rhs)
        {
            return lhs.amount < rhs.amount;
        }

        /// <summary>
        /// Less than operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(AbsorbedDoseRate lhs, IMeasure<AbsorbedDoseRate> rhs)
        {
            return lhs.amount < rhs.StandardAmount;
        }

        /// <summary>
        /// Less than operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(IMeasure<AbsorbedDoseRate> lhs, AbsorbedDoseRate rhs)
        {
            return lhs.StandardAmount < rhs.amount;
        }

        /// <summary>
        /// Greater than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(AbsorbedDoseRate lhs, AbsorbedDoseRate rhs)
        {
            return lhs.amount > rhs.amount;
        }

        /// <summary>
        /// Greater than operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(AbsorbedDoseRate lhs, IMeasure<AbsorbedDoseRate> rhs)
        {
            return lhs.amount > rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(IMeasure<AbsorbedDoseRate> lhs, AbsorbedDoseRate rhs)
        {
            return lhs.StandardAmount > rhs.amount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(AbsorbedDoseRate lhs, AbsorbedDoseRate rhs)
        {
            return lhs.amount <= rhs.amount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(AbsorbedDoseRate lhs, IMeasure<AbsorbedDoseRate> rhs)
        {
            return lhs.amount <= rhs.StandardAmount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(IMeasure<AbsorbedDoseRate> lhs, AbsorbedDoseRate rhs)
        {
            return lhs.StandardAmount <= rhs.amount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(AbsorbedDoseRate lhs, AbsorbedDoseRate rhs)
        {
            return lhs.amount >= rhs.amount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(AbsorbedDoseRate lhs, IMeasure<AbsorbedDoseRate> rhs)
        {
            return lhs.amount >= rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(IMeasure<AbsorbedDoseRate> lhs, AbsorbedDoseRate rhs)
        {
            return lhs.StandardAmount >= rhs.amount;
        }

        /// <summary>
        /// Equality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(AbsorbedDoseRate lhs, AbsorbedDoseRate rhs)
        {
            return lhs.amount == rhs.amount;
        }

        /// <summary>
        /// Equality operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(AbsorbedDoseRate lhs, IMeasure<AbsorbedDoseRate> rhs)
        {
            return lhs.amount == rhs.StandardAmount;
        }

        /// <summary>
        /// Equality operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(IMeasure<AbsorbedDoseRate> lhs, AbsorbedDoseRate rhs)
        {
            return lhs.StandardAmount == rhs.amount;
        }

        /// <summary>
        /// Inequality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(AbsorbedDoseRate lhs, AbsorbedDoseRate rhs)
        {
            return lhs.amount != rhs.amount;
        }

        /// <summary>
        /// Inequality operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(AbsorbedDoseRate lhs, IMeasure<AbsorbedDoseRate> rhs)
        {
            return lhs.amount != rhs.StandardAmount;
        }

        /// <summary>
        /// Inequality operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;AbsorbedDoseRate&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(IMeasure<AbsorbedDoseRate> lhs, AbsorbedDoseRate rhs)
        {
            return lhs.StandardAmount != rhs.amount;
        }

        #endregion

        #region Private class implementation of IMeasureFactory<AbsorbedDoseRate>

        private class MeasureFactory : IMeasureFactory<AbsorbedDoseRate>
        {
            /// <summary>
            /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
            public AbsorbedDoseRate New(double amount)
            {
                return new AbsorbedDoseRate(amount);
            }

            /// <summary>
            /// Creates a new standard unit measure.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Standard unit measure.</returns>
            public AbsorbedDoseRate New(double amount, IUnit<AbsorbedDoseRate> unit)
            {
                return new AbsorbedDoseRate(amount, unit);
            }

            /// <summary>
            /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
            public AbsorbedDoseRate New(float amount)
            {
                return new AbsorbedDoseRate(amount);
            }

            /// <summary>
            /// Creates a new standard unit measure.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Standard unit measure.</returns>
            public AbsorbedDoseRate New(float amount, IUnit<AbsorbedDoseRate> unit)
            {
                return new AbsorbedDoseRate(amount, unit);
            }

            /// <summary>
            /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
            public AbsorbedDoseRate New(decimal amount)
            {
                return new AbsorbedDoseRate(amount);
            }

            /// <summary>
            /// Creates a new standard unit measure.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Standard unit measure.</returns>
            public AbsorbedDoseRate New(decimal amount, IUnit<AbsorbedDoseRate> unit)
            {
                return new AbsorbedDoseRate(amount, unit);
            }

            /// <summary>
            /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
            public IMeasure<AbsorbedDoseRate> NewPreserveUnit(double amount, IUnit<AbsorbedDoseRate> unit)
            {
                return new Measure<AbsorbedDoseRate>(amount, unit);
            }

            /// <summary>
            /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
            public IMeasure<AbsorbedDoseRate> NewPreserveUnit(float amount, IUnit<AbsorbedDoseRate> unit)
            {
                return new Measure<AbsorbedDoseRate>(amount, unit);
            }

            /// <summary>
            /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
            public IMeasure<AbsorbedDoseRate> NewPreserveUnit(decimal amount, IUnit<AbsorbedDoseRate> unit)
            {
                return new Measure<AbsorbedDoseRate>(amount, unit);
            }
        }

        #endregion
    }
}
