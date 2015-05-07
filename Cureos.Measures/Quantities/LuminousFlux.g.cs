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
    /// Implementation of the luminous flux quantity
    /// </summary>
    [DataContract]
    public partial struct LuminousFlux : IQuantity<LuminousFlux>, IMeasure<LuminousFlux>, IEquatable<LuminousFlux>, IComparable<LuminousFlux>
    {
        #region FIELDS

        // ReSharper disable once InconsistentNaming
        private static readonly IMeasureFactory<LuminousFlux> factory = new MeasureFactory();

        // ReSharper disable once InconsistentNaming
        private static readonly QuantityDimension dimension = QuantityDimension.Steradian * new QuantityDimension(0, 0, 0, 0, 0, 1, 0);

        public static readonly Unit<LuminousFlux> Lumen = new ConstantConverterUnit<LuminousFlux>("lm");

        public static readonly Unit<LuminousFlux> NanoLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Nano);
        public static readonly Unit<LuminousFlux> MicroLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Micro);
        public static readonly Unit<LuminousFlux> MilliLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Milli);
        public static readonly Unit<LuminousFlux> CentiLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Centi);
        public static readonly Unit<LuminousFlux> DeciLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Deci);
        public static readonly Unit<LuminousFlux> DekaLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Deka);
        public static readonly Unit<LuminousFlux> HectoLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Hecto);
        public static readonly Unit<LuminousFlux> KiloLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Kilo);
        public static readonly Unit<LuminousFlux> MegaLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Mega);
        public static readonly Unit<LuminousFlux> GigaLumen = new ConstantConverterUnit<LuminousFlux>(UnitPrefix.Giga);

        [DataMember]
        private readonly AmountType amount;

        #endregion

        #region CONSTRUCTORS

#if !MONO
        /// <summary>
        /// Static constructor for defining static class properties
        /// </summary>
        static LuminousFlux()
        {
            Zero = new LuminousFlux(Constants.Zero);
            Epsilon = new LuminousFlux(Constants.MachineEpsilon);
        }
#endif
        
        /// <summary>
        /// Initializes a luminous flux object from an object implementing the IMeasure&lt;LuminousFlux&gt; interface
        /// </summary>
        /// <param name="other">Object implemeting the IMeasure&lt;LuminousFlux&gt; interface</param>
        public LuminousFlux(IMeasure<LuminousFlux> other)
            : this(other.StandardAmount)
        {
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public LuminousFlux(double amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public LuminousFlux(float amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public LuminousFlux(decimal amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public LuminousFlux(double amount, IUnit<LuminousFlux> unit)
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
        public LuminousFlux(float amount, IUnit<LuminousFlux> unit)
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
        public LuminousFlux(decimal amount, IUnit<LuminousFlux> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            this.amount = unit.ConvertAmountToStandardUnit((AmountType)amount);
        }

        #endregion

        #region Implementation of IQuantity<LuminousFlux>

        /// <summary>
        /// Gets the display name of the quantity
        /// </summary>
        public string DisplayName 
        { 
            get { return "Luminous Flux"; } 
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
        public IUnit<LuminousFlux> StandardUnit
        {
            get { return Lumen; }
        }

        /// <summary>
        /// Gets the measure factory associated with the quantity.
        /// </summary>
        IMeasureFactory<LuminousFlux> IQuantity<LuminousFlux>.Factory
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
            return other is LuminousFlux;
        }

        #endregion

        #region Implementation of IMeasure<LuminousFlux>

        /// <summary>
        /// Gets the measured amount in the <see cref="StandardUnit">standard unit of measure</see>
        /// </summary>
        public AmountType Amount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the measured amount in the standard unit of measure for the luminous flux quantity
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
            return this.GetAmount(unit as IUnit<LuminousFlux>);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        /// <exception cref="ArgumentNullException">if specified unit is null or if specified unit is not of the LuminousFlux quantity.</exception>
        IMeasure IMeasure.this[IUnit unit]
        {
            get { return this[unit as IUnit<LuminousFlux>]; }
        }

        /// <summary>
        /// Gets the quantity-typed unit of measure
        /// </summary>
        /// <remarks>Always return the standard unit of measure</remarks>
        public IUnit<LuminousFlux> Unit
        {
            get { return this.StandardUnit; }
        }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="unit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="unit">specified unit</paramref></returns>
        public AmountType GetAmount(IUnit<LuminousFlux> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            return unit.ConvertStandardAmountToUnit(this.amount);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        IMeasure<LuminousFlux> IMeasure<LuminousFlux>.this[IUnit<LuminousFlux> unit]
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
        bool IEquatable<IMeasure<LuminousFlux>>.Equals(IMeasure<LuminousFlux> other)
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
            return this.Equals(other as IMeasure<LuminousFlux>);
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
        int IComparable<IMeasure<LuminousFlux>>.CompareTo(IMeasure<LuminousFlux> other)
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
            if (!(other.Unit.Quantity is IMeasure<LuminousFlux>)) throw new ArgumentException("Measures are of different quantities");
            return this.amount.CompareTo(other.StandardAmount);
        }

        #endregion

        #region Implementation of IEquatable<LuminousFlux>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(LuminousFlux other)
        {
            return this.amount.Equals(other.amount);
        }

        #endregion

        #region Implementation of IComparable<LuminousFlux>

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
        public int CompareTo(LuminousFlux other)
        {
            return this.amount.CompareTo(other.amount);
        }

        #endregion

        #region INDEXERS

        /// <summary>
        /// Gets a new unit preserving measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        public Measure<LuminousFlux> this[IUnit<LuminousFlux> unit]
        {
            get
            {
                if (unit == null) throw new ArgumentNullException("unit");
                return new Measure<LuminousFlux>(this.GetAmount(unit), unit);
            }
        }

        #endregion

#if !MONO
        #region PROPERTIES
        
        public static LuminousFlux Zero { get; private set; }

        public static LuminousFlux Epsilon { get; private set; }

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
            return obj is IMeasure<LuminousFlux> && this.Equals((IMeasure<LuminousFlux>)obj);
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
        /// Casts a double value to a LuminousFlux object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>LuminousFlux representation of <paramref name="standardAmount"/> in unit Lumen</returns>
        public static explicit operator LuminousFlux(double standardAmount)
        {
            return new LuminousFlux(standardAmount);
        }

        /// <summary>
        /// Casts a float value to a LuminousFlux object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>LuminousFlux representation of <paramref name="standardAmount"/> in unit Lumen</returns>
        public static explicit operator LuminousFlux(float standardAmount)
        {
            return new LuminousFlux(standardAmount);
        }

        /// <summary>
        /// Casts a decimal value to a LuminousFlux object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>LuminousFlux representation of <paramref name="standardAmount"/> in unit Lumen</returns>
        public static explicit operator LuminousFlux(decimal standardAmount)
        {
            return new LuminousFlux(standardAmount);
        }
        
        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static LuminousFlux operator +(LuminousFlux lhs,  LuminousFlux rhs)
        {
            return new LuminousFlux(lhs.amount + rhs.amount);
        }

        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term (any object implementing the IMeasure interface)</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static LuminousFlux operator +(LuminousFlux lhs, IMeasure<LuminousFlux> rhs)
        {
            return new LuminousFlux(lhs.amount + rhs.StandardAmount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object</param>
        /// <returns>Difference of the measure objects</returns>
        public static LuminousFlux operator -(LuminousFlux lhs, LuminousFlux rhs)
        {
            return new LuminousFlux(lhs.amount - rhs.amount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object (any object implementing the IMeasure interface)</param>
        /// <returns>Difference of the measure objects</returns>
        public static LuminousFlux operator -(LuminousFlux lhs, IMeasure<LuminousFlux> rhs)
        {
            return new LuminousFlux(lhs.amount - rhs.StandardAmount);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static LuminousFlux operator *(double scalar, LuminousFlux measure)
        {
            return new LuminousFlux((AmountType)scalar * measure.amount);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static LuminousFlux operator *(float scalar, LuminousFlux measure)
        {
            return new LuminousFlux((AmountType)scalar * measure.amount);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static LuminousFlux operator *(decimal scalar, LuminousFlux measure)
        {
            return new LuminousFlux((AmountType)scalar * measure.amount);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static LuminousFlux operator *(LuminousFlux measure, double scalar)
        {
            return new LuminousFlux(measure.amount * (AmountType)scalar);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static LuminousFlux operator *(LuminousFlux measure, float scalar)
        {
            return new LuminousFlux(measure.amount * (AmountType)scalar);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static LuminousFlux operator *(LuminousFlux measure, decimal scalar)
        {
            return new LuminousFlux(measure.amount * (AmountType)scalar);
        }

        /// <summary>
        /// Multiply a measure object and a number
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point number</param>
        /// <returns>Product of the measure object and the number</returns>
        public static LuminousFlux operator *(LuminousFlux measure, IMeasure<Number> scalar)
        {
            return new LuminousFlux(measure.amount * scalar.StandardAmount);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static LuminousFlux operator /(LuminousFlux measure, double scalar)
        {
            return new LuminousFlux(measure.amount / (AmountType)scalar);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static LuminousFlux operator /(LuminousFlux measure, float scalar)
        {
            return new LuminousFlux(measure.amount / (AmountType)scalar);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static LuminousFlux operator /(LuminousFlux measure, decimal scalar)
        {
            return new LuminousFlux(measure.amount / (AmountType)scalar);
        }

        /// <summary>
        /// Divide a measure object with a number
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point number</param>
        /// <returns>Quotient of the measure object and the number</returns>
        public static LuminousFlux operator /(LuminousFlux measure, IMeasure<Number> scalar)
        {
            return new LuminousFlux(measure.amount / scalar.StandardAmount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(LuminousFlux dividend, LuminousFlux divisor)
        {
            return new Number(dividend.amount / divisor.amount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(LuminousFlux dividend, IMeasure<LuminousFlux> divisor)
        {
            return new Number(dividend.amount / divisor.StandardAmount);
        }

        /// <summary>
        /// Less than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(LuminousFlux lhs, LuminousFlux rhs)
        {
            return lhs.amount < rhs.amount;
        }

        /// <summary>
        /// Less than operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;LuminousFlux&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;LuminousFlux&gt; interface)</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(LuminousFlux lhs, IMeasure<LuminousFlux> rhs)
        {
            return lhs.amount < rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(LuminousFlux lhs, LuminousFlux rhs)
        {
            return lhs.amount > rhs.amount;
        }

        /// <summary>
        /// Greater than operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;LuminousFlux&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;LuminousFlux&gt; interface)</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(LuminousFlux lhs, IMeasure<LuminousFlux> rhs)
        {
            return lhs.amount > rhs.StandardAmount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(LuminousFlux lhs, LuminousFlux rhs)
        {
            return lhs.amount <= rhs.amount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;LuminousFlux&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;LuminousFlux&gt; interface)</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(LuminousFlux lhs, IMeasure<LuminousFlux> rhs)
        {
            return lhs.amount <= rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(LuminousFlux lhs, LuminousFlux rhs)
        {
            return lhs.amount >= rhs.amount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;LuminousFlux&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;LuminousFlux&gt; interface)</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(LuminousFlux lhs, IMeasure<LuminousFlux> rhs)
        {
            return lhs.amount >= rhs.StandardAmount;
        }

        /// <summary>
        /// Equality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(LuminousFlux lhs, LuminousFlux rhs)
        {
            return lhs.amount == rhs.amount;
        }

        /// <summary>
        /// Equality operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;LuminousFlux&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;LuminousFlux&gt; interface)</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(LuminousFlux lhs, IMeasure<LuminousFlux> rhs)
        {
            return lhs.amount == rhs.StandardAmount;
        }

        /// <summary>
        /// Inequality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(LuminousFlux lhs, LuminousFlux rhs)
        {
            return lhs.amount != rhs.amount;
        }

        /// <summary>
        /// Inequality operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;LuminousFlux&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;LuminousFlux&gt; interface)</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(LuminousFlux lhs, IMeasure<LuminousFlux> rhs)
        {
            return lhs.amount != rhs.StandardAmount;
        }

        #endregion

        #region Private class implementation of IMeasureFactory<LuminousFlux>

        private class MeasureFactory : IMeasureFactory<LuminousFlux>
        {
            /// <summary>
            /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
            public LuminousFlux New(double amount)
            {
                return new LuminousFlux(amount);
            }

            /// <summary>
            /// Creates a new standard unit measure.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Standard unit measure.</returns>
            public LuminousFlux New(double amount, IUnit<LuminousFlux> unit)
            {
                return new LuminousFlux(amount, unit);
            }

            /// <summary>
            /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
            public LuminousFlux New(float amount)
            {
                return new LuminousFlux(amount);
            }

            /// <summary>
            /// Creates a new standard unit measure.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Standard unit measure.</returns>
            public LuminousFlux New(float amount, IUnit<LuminousFlux> unit)
            {
                return new LuminousFlux(amount, unit);
            }

            /// <summary>
            /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
            public LuminousFlux New(decimal amount)
            {
                return new LuminousFlux(amount);
            }

            /// <summary>
            /// Creates a new standard unit measure.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Standard unit measure.</returns>
            public LuminousFlux New(decimal amount, IUnit<LuminousFlux> unit)
            {
                return new LuminousFlux(amount, unit);
            }

            /// <summary>
            /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
            public IMeasure<LuminousFlux> NewPreserveUnit(double amount, IUnit<LuminousFlux> unit)
            {
                return new Measure<LuminousFlux>(amount, unit);
            }

            /// <summary>
            /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
            public IMeasure<LuminousFlux> NewPreserveUnit(float amount, IUnit<LuminousFlux> unit)
            {
                return new Measure<LuminousFlux>(amount, unit);
            }

            /// <summary>
            /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
            /// </summary>
            /// <param name="amount">Amount.</param>
            /// <param name="unit">Unit.</param>
            /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
            public IMeasure<LuminousFlux> NewPreserveUnit(decimal amount, IUnit<LuminousFlux> unit)
            {
                return new Measure<LuminousFlux>(amount, unit);
            }
        }

        #endregion
    }
}
