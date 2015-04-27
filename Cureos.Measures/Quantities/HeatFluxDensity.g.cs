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
    /// Implementation of the heat flux density quantity
    /// </summary>
    public partial struct HeatFluxDensity : IQuantity<HeatFluxDensity>, IMeasure<HeatFluxDensity>
    {
        #region FIELDS

        private static readonly QuantityDimension dimension = new QuantityDimension(0, 1, -3, 0, 0, 0, 0);

        public static readonly Unit<HeatFluxDensity> WattPerSquareMeter = new Unit<HeatFluxDensity>("W m\u207b²");

        public static readonly Unit<HeatFluxDensity> NanoWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Nano);
        public static readonly Unit<HeatFluxDensity> MicroWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Micro);
        public static readonly Unit<HeatFluxDensity> MilliWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Milli);
        public static readonly Unit<HeatFluxDensity> CentiWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Centi);
        public static readonly Unit<HeatFluxDensity> DeciWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Deci);
        public static readonly Unit<HeatFluxDensity> DekaWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Deka);
        public static readonly Unit<HeatFluxDensity> HectoWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Hecto);
        public static readonly Unit<HeatFluxDensity> KiloWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Kilo);
        public static readonly Unit<HeatFluxDensity> MegaWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Mega);
        public static readonly Unit<HeatFluxDensity> GigaWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Giga);


        private readonly AmountType amount;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes a HeatFluxDensity object from an object implementing the IMeasure&lt;HeatFluxDensity&gt; interface
        /// </summary>
        /// <param name="other">Object implemeting the IMeasure&lt;HeatFluxDensity&gt; interface</param>
        public HeatFluxDensity(IMeasure<HeatFluxDensity> other)
            : this(other.Amount, other.Unit)
        {
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public HeatFluxDensity(double amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public HeatFluxDensity(float amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and standard unit of the measured quantity
        /// </summary>
        /// <param name="amount">Measured amount in standard unit of the specified quantity</param>
        public HeatFluxDensity(decimal amount)
        {
            this.amount = (AmountType)amount;
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public HeatFluxDensity(double amount, IUnit<HeatFluxDensity> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            this.amount = unit.AmountToStandardUnitConverter((AmountType)amount);
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public HeatFluxDensity(float amount, IUnit<HeatFluxDensity> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            this.amount = unit.AmountToStandardUnitConverter((AmountType)amount);
        }

        /// <summary>
        /// Initializes a measure to the specified amount and unit
        /// </summary>
        /// <param name="amount">Measured amount</param>
        /// <param name="unit">Unit of measure</param>
        /// <exception cref="ArgumentNullException">if the specified unit is null</exception>
        public HeatFluxDensity(decimal amount, IUnit<HeatFluxDensity> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            this.amount = unit.AmountToStandardUnitConverter((AmountType)amount);
        }

        #endregion

        #region Implementation of IQuantity<HeatFluxDensity>

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
        public IUnit<HeatFluxDensity> StandardUnit
        {
            get { return WattPerSquareMeter; }
        }

        #endregion

        #region Implementation of IMeasure<HeatFluxDensity>

        /// <summary>
        /// Gets the measured amount in the <see cref="Unit">current unit of measure</see>
        /// </summary>
        public AmountType Amount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the measured amount in the standard unit of measure for the heat flux density quantity</typeparam>
        /// </summary
        public AmountType StandardAmount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the unit of measure
        /// </summary>
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
            if (unit == null) throw new ArgumentNullException("unit");
            if (!unit.Quantity.Equals(default(HeatFluxDensity))) throw new ArgumentException("Unit is not the same quantity as measure");
            return unit.AmountFromStandardUnitConverter(this.amount);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        /// <exception cref="ArgumentNullException">if specified unit is null or if specified unit is not of the 
        /// <typeparamref name="Q">valid quantity</typeparamref></exception>
        IMeasure IMeasure.this[IUnit unit]
        {
            get { return this[unit as IUnit<HeatFluxDensity>]; }
        }

        /// <summary>
        /// Gets the quantity-typed unit of measure
        /// </summary>
        public IUnit<HeatFluxDensity> Unit
        {
            get { return this.StandardUnit; }
        }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="unit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="unit">specified unit</paramref></returns>
        public AmountType GetAmount(IUnit<HeatFluxDensity> unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            return unit.AmountFromStandardUnitConverter(this.amount);
        }

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        IMeasure<HeatFluxDensity> IMeasure<HeatFluxDensity>.this[IUnit<HeatFluxDensity> unit]
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
        public bool Equals(IMeasure<HeatFluxDensity> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this.amount.Equals(other.GetAmount(this.Unit));
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
            if (!other.Unit.Quantity.Equals(default(HeatFluxDensity))) throw new ArgumentException("Measures are of different quantities");
            return this.amount.Equals(other.GetAmount(this.Unit));
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
        public int CompareTo(IMeasure<HeatFluxDensity> other)
        {
            if (other == null) throw new ArgumentNullException("other");
            return this.amount.CompareTo(other.GetAmount(this.Unit));
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
            if (!other.Unit.Quantity.Equals(default(HeatFluxDensity))) throw new ArgumentException("Measures are of different quantities");
            return this.amount.CompareTo(other.GetAmount(this.Unit));
        }

        #endregion

        #region INDEXERS

        /// <summary>
        /// Gets a new unit preserving measure based on this measure but in the <paramref name="unit">specified unit</paramref>
        /// </summary>
        /// <param name="unit">Unit in which the new measure should be specified</param>
        public UnitPreservingMeasure<HeatFluxDensity> this[IUnit<HeatFluxDensity> unit]
        {
            get
            {
                if (unit == null) throw new ArgumentNullException("unit");
                return new UnitPreservingMeasure<HeatFluxDensity>(this.GetAmount(unit), unit);
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
            if (obj.GetType() != typeof(IMeasure<HeatFluxDensity>)) return false;
            return this.Equals((IMeasure<HeatFluxDensity>)obj);
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
            return String.Format("{0} {1} (heat flux density)", this.amount, this.Unit.Symbol).Trim();
        }

        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="format">Format string to display the value with</param>
        /// <returns>A <see cref="T:System.String"/> containing a the actual value in formatted form with the quantity symbol appended</returns>
        public string ToString(string format)
        {
            return String.Format("{0} {1} (heat flux density)", this.amount.ToString(format), this.Unit.Symbol).Trim();
        }
        
        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="provider">Formatting provider to format the value with</param>
        /// <returns></returns>
        public string ToString(IFormatProvider provider)
        {
            return String.Format("{0} {1} (heat flux density)", this.amount.ToString(provider), this.Unit.Symbol).Trim();
        }
        
        /// <summary>
        /// Returns the actual value in formatted form with the quantity suffixed
        /// </summary>
        /// <param name="format">Format string to display the value with</param>
        /// <param name="provider">Formatting provider to format the value with</param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider provider)
        {
            return String.Format("{0} {1} (heat flux density)", this.amount.ToString(format, provider), this.Unit.Symbol).Trim();
        }
        
        #endregion

        #region OPERATORS

        /// <summary>
        /// Casts a float value to a HeatFluxDensity object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>HeatFluxDensity representation of <paramref name="standardAmount"/> in unit WattPerSquareMeter</returns>
        public static explicit operator HeatFluxDensity(float standardAmount)
        {
            return new HeatFluxDensity(standardAmount);
        }

        /// <summary>
        /// Casts a double value to a HeatFluxDensity object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>HeatFluxDensity representation of <paramref name="standardAmount"/> in unit WattPerSquareMeter</returns>
        public static explicit operator HeatFluxDensity(double standardAmount)
        {
            return new HeatFluxDensity(standardAmount);
        }

        /// <summary>
        /// Casts a decimal value to a HeatFluxDensity object
        /// </summary>
        /// <param name="standardAmount">Standard amount</param>
        /// <returns>HeatFluxDensity representation of <paramref name="standardAmount"/> in unit WattPerSquareMeter</returns>
        public static explicit operator HeatFluxDensity(decimal standardAmount)
        {
            return new HeatFluxDensity(standardAmount);
        }
        
        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static HeatFluxDensity operator +(HeatFluxDensity lhs,  HeatFluxDensity rhs)
        {
            return new HeatFluxDensity(lhs.amount + rhs.amount);
        }

        /// <summary>
        /// Adds two measure objects provided the measured quantities are equal
        /// </summary>
        /// <param name="lhs">First measure term</param>
        /// <param name="rhs">Second measure term (any object implementing the IMeasure interface)</param>
        /// <returns>Sum of the two measure objects in the unit of the <paramref name="lhs">left-hand side measure</paramref></returns>
        public static HeatFluxDensity operator +(HeatFluxDensity lhs, IMeasure<HeatFluxDensity> rhs)
        {
            return new HeatFluxDensity(lhs.amount + rhs.StandardAmount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object</param>
        /// <returns>Difference of the measure objects</returns>
        public static HeatFluxDensity operator -(HeatFluxDensity lhs, HeatFluxDensity rhs)
        {
            return new HeatFluxDensity(lhs.amount - rhs.amount);
        }

        /// <summary>
        /// Subtract two measure objects of the same quantity
        /// </summary>
        /// <param name="lhs">First measure object</param>
        /// <param name="rhs">Second measure object (any object implementing the IMeasure interface)</param>
        /// <returns>Difference of the measure objects</returns>
        public static HeatFluxDensity operator -(HeatFluxDensity lhs, IMeasure<HeatFluxDensity> rhs)
        {
            return new HeatFluxDensity(lhs.amount - rhs.StandardAmount);
        }

        /// <summary>
        /// Multiply a scalar and a measure object
        /// </summary>
        /// <param name="scalar">Floating-point scalar</param>
        /// <param name="measure">Measure object</param>
        /// <returns>Product of the scalar and the measure object</returns>
        public static HeatFluxDensity operator *(AmountType scalar, HeatFluxDensity measure)
        {
            return new HeatFluxDensity(scalar * measure.amount);
        }

        /// <summary>
        /// Multiply a measure object and a scalar
        /// </summary>
        /// <param name="measure">Measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Product of the measure object and the scalar</returns>
        public static HeatFluxDensity operator *(HeatFluxDensity measure, AmountType scalar)
        {
            return new HeatFluxDensity(measure.amount * scalar);
        }

        /// <summary>
        /// Divide a measure object with a scalar
        /// </summary>
        /// <param name="iMeasure">measure object</param>
        /// <param name="scalar">Floating-point scalar</param>
        /// <returns>Quotient of the measure object and the scalar</returns>
        public static HeatFluxDensity operator /(HeatFluxDensity measure, AmountType scalar)
        {
            return new HeatFluxDensity(measure.amount / scalar);
        }

        /// <summary>
        /// Less than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(HeatFluxDensity lhs, HeatFluxDensity rhs)
        {
            return lhs.amount < rhs.amount;
        }

        /// <summary>
        /// Less than operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if first measure object is less than second measure object; false otherwise</returns>
        public static bool operator <(HeatFluxDensity lhs, IMeasure<HeatFluxDensity> rhs)
        {
            return lhs.amount < rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(HeatFluxDensity lhs, HeatFluxDensity rhs)
        {
            return lhs.amount > rhs.amount;
        }

        /// <summary>
        /// Greater than operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if first measure object is greater than second measure object; false otherwise</returns>
        public static bool operator >(HeatFluxDensity lhs, IMeasure<HeatFluxDensity> rhs)
        {
            return lhs.amount > rhs.StandardAmount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(HeatFluxDensity lhs, HeatFluxDensity rhs)
        {
            return lhs.amount <= rhs.amount;
        }

        /// <summary>
        /// Less than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if first measure object is less than or equal to second measure object; false otherwise</returns>
        public static bool operator <=(HeatFluxDensity lhs, IMeasure<HeatFluxDensity> rhs)
        {
            return lhs.amount <= rhs.StandardAmount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(HeatFluxDensity lhs, HeatFluxDensity rhs)
        {
            return lhs.amount >= rhs.amount;
        }

        /// <summary>
        /// Greater than or equal to operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if first measure object is greater than or equal to second measure object; false otherwise</returns>
        public static bool operator >=(HeatFluxDensity lhs, IMeasure<HeatFluxDensity> rhs)
        {
            return lhs.amount >= rhs.StandardAmount;
        }

        /// <summary>
        /// Equality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(HeatFluxDensity lhs, HeatFluxDensity rhs)
        {
            return lhs.amount == rhs.amount;
        }

        /// <summary>
        /// Equality operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if the two measure objects are equal; false otherwise</returns>
        public static bool operator ==(HeatFluxDensity lhs, IMeasure<HeatFluxDensity> rhs)
        {
            return lhs.amount == rhs.StandardAmount;
        }

        /// <summary>
        /// Inequality operator for measure objects
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(HeatFluxDensity lhs, HeatFluxDensity rhs)
        {
            return lhs.amount != rhs.amount;
        }

        /// <summary>
        /// Inequality operator for measure objects, where right-hand side may be any object implementing the IMeasure interface
        /// </summary>
        /// <param name="lhs">First object</param>
        /// <param name="rhs">Second object (any object implementing IMeasure interface)</param>
        /// <returns>true if the two measure objects are not equal; false if they are equal</returns>
        public static bool operator !=(HeatFluxDensity lhs, IMeasure<HeatFluxDensity> rhs)
        {
            return lhs.amount != rhs.StandardAmount;
        }

        #endregion
    }
}
