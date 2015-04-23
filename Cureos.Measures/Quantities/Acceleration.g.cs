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
    /// Implementation of the acceleration quantity
    /// </summary>
    public partial struct Acceleration : IQuantity<Acceleration>, IMeasure<Acceleration>
    {
        #region FIELDS

        private static readonly QuantityDimension dimension = new QuantityDimension(1, 0, -2, 0, 0, 0, 0);

        public static readonly Unit<Acceleration> MeterPerSecondSquared = new Unit<Acceleration>("m s\u207b²");

        public static readonly Unit<Acceleration> MilliMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Milli);
        public static readonly Unit<Acceleration> CentiMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Centi);
        public static readonly Unit<Acceleration> DeciMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Deci);
        public static readonly Unit<Acceleration> DekaMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Deka);
        public static readonly Unit<Acceleration> HectoMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Hecto);
        public static readonly Unit<Acceleration> KiloMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Kilo);


		private readonly AmountType amount;
		private readonly IUnit<Acceleration> unit;

        #endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Initializes a measure to the specified amount and standard unit of the measured quantity
		/// </summary>
		/// <param name="amount">Measured amount in standard unit of the specified quantity</param>
		public Acceleration(double amount)
			: this(amount, default(Acceleration).StandardUnit)
		{
		}

		/// <summary>
		/// Initializes a measure to the specified amount and standard unit of the measured quantity
		/// </summary>
		/// <param name="amount">Measured amount in standard unit of the specified quantity</param>
		public Acceleration(float amount)
			: this(amount, default(Acceleration).StandardUnit)
		{
		}

		/// <summary>
		/// Initializes a measure to the specified amount and standard unit of the measured quantity
		/// </summary>
		/// <param name="amount">Measured amount in standard unit of the specified quantity</param>
		public Acceleration(decimal amount)
			: this(amount, default(Acceleration).StandardUnit)
		{
		}

		/// <summary>
		/// Initializes a measure to the specified amount and unit
		/// </summary>
		/// <param name="amount">Measured amount</param>
		/// <param name="iUnit">Unit of measure</param>
		/// <exception cref="ArgumentNullException">if the specified unit is null</exception>
		public Acceleration(double amount, IUnit<Acceleration> unit)
		{
			if (unit == null) throw new ArgumentNullException("unit");
#if DOUBLE
			this.amount = amount;
#else
			this.amount = (AmountType)amount;
#endif
			this.unit = unit;
		}

		/// <summary>
		/// Initializes a measure to the specified amount and unit
		/// </summary>
		/// <param name="iAmount">Measured amount</param>
		/// <param name="iUnit">Unit of measure</param>
		/// <exception cref="ArgumentNullException">if the specified unit is null</exception>
		public Acceleration(float amount, IUnit<Acceleration> unit)
		{
			if (unit == null) throw new ArgumentNullException("unit");
#if !DECIMAL
			this.amount = amount;
#else
			this.amount = (AmountType)amount;
#endif
			this.unit = unit;
		}

		/// <summary>
		/// Initializes a measure to the specified amount and unit
		/// </summary>
		/// <param name="iAmount">Measured amount</param>
		/// <param name="iUnit">Unit of measure</param>
		/// <exception cref="ArgumentNullException">if the specified unit is null</exception>
		public Acceleration(decimal amount, IUnit<Acceleration> unit)
		{
			if (unit == null) throw new ArgumentNullException("unit");
#if DECIMAL
			this.amount = amount;
#else
			this.amount = (AmountType)amount;
#endif
			this.unit = unit;
		}

        #endregion

        #region Implementation of IQuantity<Acceleration>

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
        public IUnit<Acceleration> StandardUnit
        {
            get { return MeterPerSecondSquared; }
        }

        #endregion

		#region Implementation of IMeasure<Acceleration>

		/// <summary>
		/// Gets the measured amount in the <see cref="Unit">current unit of measure</see>
		/// </summary>
		public AmountType Amount
		{
			get { return this.amount; }
		}

	    /// <summary>
	    /// Gets the measured amount in the standard unit of measure for the acceleration specified quantity</typeparam>
	    /// </summary>
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
	    /// <returns>Measured amount converted into <paramref name="iUnit">specified unit</paramref></returns>
	    AmountType IMeasure.GetAmount(IUnit unit)
	    {
	        if (unit == null) throw new ArgumentNullException("unit");
            if (!unit.Quantity.Equals(default(Acceleration))) throw new ArgumentException("Unit is not the same quantity as measure");
	        return unit.AmountFromStandardUnitConverter(this.StandardAmount);
	    }

	    /// <summary>
	    /// Gets a new unit specific measure based on this measure but in the <paramref name="iUnit">specified unit</paramref>
	    /// </summary>
	    /// <param name="unit">Unit in which the new measure should be specified</param>
	    /// <exception cref="ArgumentNullException">if specified unit is null or if specified unit is not of the 
	    /// <typeparamref name="Q">valid quantity</typeparamref></exception>
	    IMeasure IMeasure.this[IUnit unit]
	    {
	        get { return this[unit as IUnit<Acceleration>]; }
	    }

	    /// <summary>
		/// Gets the quantity-typed unit of measure
		/// </summary>
		public IUnit<Acceleration> Unit
		{
			get { return this.unit; }
		}

		/// <summary>
		/// Gets the amount of this measure in the requested unit
		/// </summary>
		/// <param name="unit">Unit to which the measured amount should be converted</param>
		/// <returns>Measured amount converted into <paramref name="unit">specified unit</paramref></returns>
		public AmountType GetAmount(IUnit<Acceleration> unit)
		{
			if (unit == null) throw new ArgumentNullException("unit");
			return unit.AmountFromStandardUnitConverter(this.StandardAmount);
		}

		/// <summary>
		/// Gets a new unit specific measure based on this measure but in the <paramref name="iUnit">specified unit</paramref>
		/// </summary>
		/// <param name="unit">Unit in which the new measure should be specified</param>
		IMeasure<Acceleration> IMeasure<Acceleration>.this[IUnit<Acceleration> unit]
		{
			get { return this[unit]; }
		}

		/// <summary>
		/// Gets a new unit specific measure based on this measure but in the <paramref name="unit">specified unit</paramref>
		/// </summary>
		/// <param name="unit">Unit in which the new measure should be specified</param>
		public Acceleration this[IUnit<Acceleration> unit]
		{
			get
			{
				if (unit == null) throw new ArgumentNullException("unit");
				return new Acceleration(this.GetAmount(unit), unit);
			}
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(IMeasure<Acceleration> other)
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
            if (!other.Unit.Quantity.Equals(default(Acceleration))) throw new ArgumentException("Measures are of different quantities");
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
		public int CompareTo(IMeasure<Acceleration> other)
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
            if (!other.Unit.Quantity.Equals(default(Acceleration))) throw new ArgumentException("Measures are of different quantities");
            return this.amount.CompareTo(other.GetAmount(this.unit));
        }

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
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Measure<Acceleration>)) return false;
			return Equals((Measure<Acceleration>)obj);
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

		#endregion

        #region METHODS

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return "Acceleration";
        }

        #endregion
    }
}
