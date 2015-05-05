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
    /// Implementation of the magnetic flux density quantity
    /// </summary>
    [DataContract]
    public partial struct MagneticFluxDensity : IQuantity<MagneticFluxDensity>, IMeasure<MagneticFluxDensity>, 
        IMeasureFactory<MagneticFluxDensity>, IEquatable<MagneticFluxDensity>, IComparable<MagneticFluxDensity>
    {
        #region FIELDS

        private static readonly IMeasureFactory<MagneticFluxDensity> factory = new MagneticFluxDensity();

        // ReSharper disable once InconsistentNaming
        private static readonly QuantityDimension dimension = new QuantityDimension(0, 1, -2, -1, 0, 0, 0);

        public static readonly Unit<MagneticFluxDensity> Tesla = new ConstantConverterUnit<MagneticFluxDensity>("T");

        public static readonly Unit<MagneticFluxDensity> NanoTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Nano);
        public static readonly Unit<MagneticFluxDensity> MicroTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Micro);
        public static readonly Unit<MagneticFluxDensity> MilliTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Milli);
        public static readonly Unit<MagneticFluxDensity> CentiTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Centi);
        public static readonly Unit<MagneticFluxDensity> DeciTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Deci);
        public static readonly Unit<MagneticFluxDensity> DekaTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Deka);
        public static readonly Unit<MagneticFluxDensity> HectoTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Hecto);
        public static readonly Unit<MagneticFluxDensity> KiloTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Kilo);
        public static readonly Unit<MagneticFluxDensity> MegaTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Mega);
        public static readonly Unit<MagneticFluxDensity> GigaTesla = new ConstantConverterUnit<MagneticFluxDensity>(UnitPrefix.Giga);

        [DataMember]
        private readonly AmountType amount;

        #endregion

        #region CONSTRUCTORS

#if !MONO
        /// <summary>
        /// Static constructor for defining static class properties
        /// </summary>
        static MagneticFluxDensity()
        {
            Zero = new MagneticFluxDensity(Constants.Zero);
            Epsilon = new MagneticFluxDensity(Constants.MachineEpsilon);
        }
#endif
        
        /// <summary>
        /// Initializes a magnetic flux density object from an object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="other">Object implemeting the IMeasure&lt;MagneticFluxDensity&gt; interface</param>
        public MagneticFluxDensity(IMeasure<MagneticFluxDensity> other)
            : this(other.StandardAmount)
        {
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public MagneticFluxDensity(double amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public MagneticFluxDensity(float amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public MagneticFluxDensity(decimal amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public MagneticFluxDensity(double amount, IUnit<MagneticFluxDensity> unit)
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
        public MagneticFluxDensity(float amount, IUnit<MagneticFluxDensity> unit)
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
        public MagneticFluxDensity(decimal amount, IUnit<MagneticFluxDensity> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            this.amount = unit.ConvertAmountToStandardUnit((AmountType)amount);
        }

        #endregion

        #region Implementation of IQuantity<MagneticFluxDensity>

        /// <summary>
        /// Gets the display name of the quantity
        /// </summary>
        public string DisplayName 
        { 
            get { return "Magnetic Flux Density"; } 
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
        public IUnit<MagneticFluxDensity> StandardUnit
        {
            get { return Tesla; }
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
            return other is MagneticFluxDensity;
        }

        #endregion

        #region Implementation of IMeasure<MagneticFluxDensity>

        /// <summary>
        /// Gets the measured amount in the <see cref="StandardUnit">standard unit of measure</see>
        /// </summary>
        public AmountType Amount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the measured amount in the standard unit of measure for the magnetic flux density quantity
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
            return this.GetAmount(unit as IUnit<MagneticFluxDensity>);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        /// <exception cref="ArgumentNullException">if specified unit is null or if specified unit is not of the MagneticFluxDensity quantity.</exception>
        IMeasure IMeasure.this[IUnit unit]
        {
            get { return this[unit as IUnit<MagneticFluxDensity>]; }
        }

        /// <summary>
        /// Gets the quantity-typed unit of measure
        /// </summary>
        /// <remarks>Always return the standard unit of measure</remarks>
        public IUnit<MagneticFluxDensity> Unit
        {
            get { return this.StandardUnit; }
        }

        /// <summary>
        /// Gets the measure factory associated with the quantity.
        /// </summary>
        public IMeasureFactory<MagneticFluxDensity> Factory
        { 
            get { return factory; }
        }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="unit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="unit">specified unit</paramref></returns>
        public AmountType GetAmount(IUnit<MagneticFluxDensity> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            return unit.ConvertStandardAmountToUnit(this.amount);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        IMeasure<MagneticFluxDensity> IMeasure<MagneticFluxDensity>.this[IUnit<MagneticFluxDensity> unit]
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
        bool IEquatable<IMeasure<MagneticFluxDensity>>.Equals(IMeasure<MagneticFluxDensity> other)
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
            return this.Equals(other as IMeasure<MagneticFluxDensity>);
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
        int IComparable<IMeasure<MagneticFluxDensity>>.CompareTo(IMeasure<MagneticFluxDensity> other)
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
            if (!(other.Unit.Quantity is IMeasure<MagneticFluxDensity>)) throw new ArgumentException("Measures are of different quantities");
            return this.amount.CompareTo(other.StandardAmount);
        }

        #endregion

        #region Implementation of IMeasureFactory<MagneticFluxDensity>

        /// <summary>
        /// Creates a new standard unit measure from the specified <paramref name="measure"/>.
        /// </summary>
        /// <param name="measure">Measure.</param>
        /// <returns>Standard unit measure from the specified <paramref name="measure"/>.</returns>
        MagneticFluxDensity IMeasureFactory<MagneticFluxDensity>.New(IMeasure<MagneticFluxDensity> measure)
        {
            return new MagneticFluxDensity(measure.StandardAmount);
        }

        /// <summary>
        /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
        /// </summary>
        /// <param name="amount">Amount.</param>
        /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
        public MagneticFluxDensity New(double amount)
        {
            return new MagneticFluxDensity(amount);
        }

        /// <summary>
        /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
        /// </summary>
        /// <param name="amount">Amount.</param>
        /// <param name="unit">Unit.</param>
        /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
        public MagneticFluxDensity New(double amount, IUnit<MagneticFluxDensity> unit)
        {
            return new MagneticFluxDensity(amount, unit);
        }

        /// <summary>
        /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
        /// </summary>
        /// <param name="amount">Amount.</param>
        /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
        public MagneticFluxDensity New(float amount)
        {
            return new MagneticFluxDensity(amount);
        }

        /// <summary>
        /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
        /// </summary>
        /// <param name="amount">Amount.</param>
        /// <param name="unit">Unit.</param>
        /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
        public MagneticFluxDensity New(float amount, IUnit<MagneticFluxDensity> unit)
        {
            return new MagneticFluxDensity(amount, unit);
        }

        /// <summary>
        /// Creates a new standard unit measure at the specified <paramref name="amount"/>.
        /// </summary>
        /// <param name="amount">Amount.</param>
        /// <returns>Standard unit measure at the specified <paramref name="amount"/>.</returns>
        public MagneticFluxDensity New(decimal amount)
        {
            return new MagneticFluxDensity(amount);
        }

        /// <summary>
        /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
        /// </summary>
        /// <param name="amount">Amount.</param>
        /// <param name="unit">Unit.</param>
        /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
        public MagneticFluxDensity New(decimal amount, IUnit<MagneticFluxDensity> unit)
        {
            return new MagneticFluxDensity(amount, unit);
        }

        #endregion

        #region Implementation of IEquatable<MagneticFluxDensity>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(MagneticFluxDensity other)
        {
            return this.amount.Equals(other.amount);
        }

        #endregion

        #region Implementation of IComparable<MagneticFluxDensity>

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
        public int CompareTo(MagneticFluxDensity other)
        {
            return this.amount.CompareTo(other.amount);
        }

        #endregion

        #region INDEXERS

        /// <summary>
        /// Gets a new unit preserving measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        public IMeasure<MagneticFluxDensity> this[IUnit<MagneticFluxDensity> unit]
        {
            get
            {
                if (unit == null) throw new ArgumentNullException("unit");
                return unit.IsStandardUnit
                    ? (IMeasure<MagneticFluxDensity>)this
                    : new InUnitMeasure<MagneticFluxDensity>(this.GetAmount(unit), unit);
            }
        }

        #endregion

#if !MONO
        #region PROPERTIES
        
        public static MagneticFluxDensity Zero { get; private set; }

        public static MagneticFluxDensity Epsilon { get; private set; }

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
            return obj is IMeasure<MagneticFluxDensity> && this.Equals((IMeasure<MagneticFluxDensity>)obj);
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
        /// Casts a float value to a MagneticFluxDensity object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>MagneticFluxDensity representation of <paramref name="standardAmount"/> in unit Tesla</returns>
        public static explicit operator MagneticFluxDensity(float standardAmount)
        {
            return new MagneticFluxDensity(standardAmount);
        }

        /// <summary>
        /// Casts a double value to a MagneticFluxDensity object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>MagneticFluxDensity representation of <paramref name="standardAmount"/> in unit Tesla</returns>
        public static explicit operator MagneticFluxDensity(double standardAmount)
        {
            return new MagneticFluxDensity(standardAmount);
        }

        /// <summary>
        /// Casts a decimal value to a MagneticFluxDensity object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>MagneticFluxDensity representation of <paramref name="standardAmount"/> in unit Tesla</returns>
        public static explicit operator MagneticFluxDensity(decimal standardAmount)
        {
            return new MagneticFluxDensity(standardAmount);
        }
        
        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static MagneticFluxDensity operator +(MagneticFluxDensity lhs,  MagneticFluxDensity rhs)
        {
            return new MagneticFluxDensity(lhs.amount + rhs.amount);
        }

        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term (any object implementing the IMeasure interface)</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static MagneticFluxDensity operator +(MagneticFluxDensity lhs, IMeasure<MagneticFluxDensity> rhs)
        {
            return new MagneticFluxDensity(lhs.amount + rhs.StandardAmount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object</param>
        /// <returns>Difference of the measure objects</returns>
        public static MagneticFluxDensity operator -(MagneticFluxDensity lhs, MagneticFluxDensity rhs)
        {
            return new MagneticFluxDensity(lhs.amount - rhs.amount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object (any object implementing the IMeasure interface)</param>
        /// <returns>Difference of the measure objects</returns>
        public static MagneticFluxDensity operator -(MagneticFluxDensity lhs, IMeasure<MagneticFluxDensity> rhs)
        {
            return new MagneticFluxDensity(lhs.amount - rhs.StandardAmount);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static MagneticFluxDensity operator *(AmountType scalar, MagneticFluxDensity measure)
        {
            return new MagneticFluxDensity(scalar * measure.amount);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static MagneticFluxDensity operator *(MagneticFluxDensity measure, AmountType scalar)
        {
            return new MagneticFluxDensity(measure.amount * scalar);
        }

        /// <summary>
        /// Multiply a number and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point number</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the number and the measure object</returns>
        public static MagneticFluxDensity operator *(IMeasure<Number> scalar, MagneticFluxDensity measure)
        {
            return new MagneticFluxDensity(scalar.StandardAmount * measure.amount);
        }

        /// <summary>
        /// Multiply a measure object and a number
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point number</param>
        /// <returns>Product of the measure object and the number</returns>
        public static MagneticFluxDensity operator *(MagneticFluxDensity measure, IMeasure<Number> scalar)
        {
            return new MagneticFluxDensity(measure.amount * scalar.StandardAmount);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static MagneticFluxDensity operator /(MagneticFluxDensity measure, AmountType scalar)
        {
            return new MagneticFluxDensity(measure.amount / scalar);
        }

        /// <summary>
        /// Divide a measure object with a number
        /// </summary>
        /// <param name="measure">measure object</param>
        /// <param name="scalar">Floating-point number</param>
        /// <returns>Quotient of the measure object and the number</returns>
        public static MagneticFluxDensity operator /(MagneticFluxDensity measure, IMeasure<Number> scalar)
        {
            return new MagneticFluxDensity(measure.amount / scalar.StandardAmount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(MagneticFluxDensity dividend, MagneticFluxDensity divisor)
        {
            return new Number(dividend.amount / divisor.amount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(IMeasure<MagneticFluxDensity> dividend, MagneticFluxDensity divisor)
        {
            return new Number(dividend.StandardAmount / divisor.amount);
        }

        /// <summary>
        /// Divide a measure object with a measure object of the same quantity
        /// </summary>
        /// <param name="dividend">Dividend of specific quantity</param>
        /// <param name="divisor">Divisor of same quantity as dividend</param>
        /// <returns>Quotient of the two measure objects</returns>
        public static Number operator /(MagneticFluxDensity dividend, IMeasure<MagneticFluxDensity> divisor)
        {
            return new Number(dividend.amount / divisor.StandardAmount);
        }

        /// <summary>
        /// Less than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(MagneticFluxDensity lhs, MagneticFluxDensity rhs)
        {
            return lhs.amount < rhs.amount;
        }

        /// <summary>
        /// Less than operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(MagneticFluxDensity lhs, IMeasure<MagneticFluxDensity> rhs)
        {
            return lhs.amount < rhs.StandardAmount;
        }

        /// <summary>
        /// Less than operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(IMeasure<MagneticFluxDensity> lhs, MagneticFluxDensity rhs)
        {
            return lhs.StandardAmount < rhs.amount;
        }

        /// <summary>
        /// Greater than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(MagneticFluxDensity lhs, MagneticFluxDensity rhs)
        {
            return lhs.amount > rhs.amount;
        }

        /// <summary>
        /// Greater than operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(MagneticFluxDensity lhs, IMeasure<MagneticFluxDensity> rhs)
        {
            return lhs.amount > rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(IMeasure<MagneticFluxDensity> lhs, MagneticFluxDensity rhs)
        {
            return lhs.StandardAmount > rhs.amount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(MagneticFluxDensity lhs, MagneticFluxDensity rhs)
        {
            return lhs.amount <= rhs.amount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(MagneticFluxDensity lhs, IMeasure<MagneticFluxDensity> rhs)
        {
            return lhs.amount <= rhs.StandardAmount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(IMeasure<MagneticFluxDensity> lhs, MagneticFluxDensity rhs)
        {
            return lhs.StandardAmount <= rhs.amount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(MagneticFluxDensity lhs, MagneticFluxDensity rhs)
        {
            return lhs.amount >= rhs.amount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(MagneticFluxDensity lhs, IMeasure<MagneticFluxDensity> rhs)
        {
            return lhs.amount >= rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(IMeasure<MagneticFluxDensity> lhs, MagneticFluxDensity rhs)
        {
            return lhs.StandardAmount >= rhs.amount;
        }

        /// <summary>
        /// Equality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(MagneticFluxDensity lhs, MagneticFluxDensity rhs)
        {
            return lhs.amount == rhs.amount;
        }

        /// <summary>
        /// Equality operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(MagneticFluxDensity lhs, IMeasure<MagneticFluxDensity> rhs)
        {
            return lhs.amount == rhs.StandardAmount;
        }

        /// <summary>
        /// Equality operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(IMeasure<MagneticFluxDensity> lhs, MagneticFluxDensity rhs)
        {
            return lhs.StandardAmount == rhs.amount;
        }

        /// <summary>
        /// Inequality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(MagneticFluxDensity lhs, MagneticFluxDensity rhs)
        {
            return lhs.amount != rhs.amount;
        }

        /// <summary>
        /// Inequality operator for measure objects, where right-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(MagneticFluxDensity lhs, IMeasure<MagneticFluxDensity> rhs)
        {
            return lhs.amount != rhs.StandardAmount;
        }

        /// <summary>
        /// Inequality operator for measure objects, where left-hand side may be any object implementing the IMeasure&lt;MagneticFluxDensity&gt; interface
        /// </summary>
        /// <param name="lhs">First object (any object implementing IMeasure&lt;MagneticFluxDensity&gt; interface)</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(IMeasure<MagneticFluxDensity> lhs, MagneticFluxDensity rhs)
        {
            return lhs.StandardAmount != rhs.amount;
        }

        #endregion
    }
}
