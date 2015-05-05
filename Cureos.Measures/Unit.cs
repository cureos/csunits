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

namespace Cureos.Measures
{
#if SINGLE
    using AmountType = System.Single;
#elif DECIMAL
    using AmountType = System.Decimal;
#elif DOUBLE
    using AmountType = System.Double;
#endif

    /// <summary>
    /// Representation of a physical unit of a specific quanity
    /// </summary>
    /// <typeparam name="Q">Quantity type with which the unit is associated</typeparam>
    public abstract class Unit<Q> : IUnit<Q> where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
    {
        #region FIELDS

        // ReSharper disable once InconsistentNaming
        private static readonly Q quantity = new Q();

        private readonly bool isStandardUnit;

        private readonly string symbol;

        private string displayName;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a physical unit object that is the standard unit of the specific quantity
        /// </summary>
        /// <param name="isStandardUnit">Indicates whether this is a standard unit.</param>
        /// <param name="symbol">Unit display symbol.</param>
        protected Unit(bool isStandardUnit, string symbol)
        {
            this.isStandardUnit = isStandardUnit;
            this.symbol = symbol;
            this.displayName = null;
        }

        #endregion

        #region Implementation of IUnit<Q>

        /// <summary>
        /// Gets the quantity associated with the unit
        /// </summary>
        IQuantity IUnit.Quantity
        {
            get { return quantity; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the unit is a standard unit of the associated quantity
        /// </summary>
        public bool IsStandardUnit
        {
            get
            {
                return this.isStandardUnit;
            }
        }

        /// <summary>
        /// Gets the typed quantity associated with the unit
        /// </summary>
        public IQuantity<Q> Quantity
        {
            get { return quantity; }
        }

        /// <summary>
        /// Gets the display symbol of the unit
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// Gets the fully qualified display name of the unit
        /// </summary>
        public string DisplayName
        {
            get
            {
                return this.displayName ?? (this.displayName = UnitHelpers.CreateUnitDisplayName(this));
            }
        }

        /// <summary>
        /// Convert the amount from the current unit to the standard unit of the specified quantity
        /// </summary>
        /// <param name="amount">Amount in this unit</param>
        /// <returns>Amount converted to standard unit</returns>
        public abstract double ConvertAmountToStandardUnit(double amount);

        /// <summary>
        /// Convert a standard amount to this unit of the specified quantity
        /// to the current unit
        /// </summary>
        /// <param name="standardAmount">Standard amount of the current <see cref="IUnit.Quantity"/>.</param>
        /// <returns>Amount in this unit.</returns>
        public abstract double ConvertStandardAmountToUnit(double standardAmount);

        #endregion

        #region METHODS

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="Symbol">unit symbol</see>
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return this.DisplayName;
        }

        #endregion

        #region OPERATORS

        /// <summary>
        /// Creates a new measure object of the specified quantity.
        /// </summary>
        /// <param name="amount">The quantity amount.</param>
        /// <param name="unit">The quantity unit.</param>
        /// <returns>A new measure object of the specified quantity.</returns>
        public static Q operator *(double amount, Unit<Q> unit)
        {
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            return quantity.New(amount, unit);
        }

        /// <summary>
        /// Creates a new measure object of the specified quantity.
        /// </summary>
        /// <param name="amount">The quantity amount.</param>
        /// <param name="unit">The quantity unit.</param>
        /// <returns>A new measure object of the specified quantity.</returns>
        public static Q operator *(float amount, Unit<Q> unit)
        {
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            return quantity.New(amount, unit);
        }

        /// <summary>
        /// Creates a new measure object of the specified quantity.
        /// </summary>
        /// <param name="amount">The quantity amount.</param>
        /// <param name="unit">The quantity unit.</param>
        /// <returns>A new measure object of the specified quantity.</returns>
        public static Q operator *(decimal amount, Unit<Q> unit)
        {
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            return quantity.New(amount, unit);
        }

        #endregion
    }
}