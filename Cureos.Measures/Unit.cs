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
    using System;

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
    public sealed class Unit<Q> : IUnit<Q> where Q : struct, IQuantity<Q>
    {
        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a physical unit object that is the standard unit of the specific quantity
        /// </summary>
        /// <param name="iSymbol">Unit display symbol</param>
        public Unit(string iSymbol) :
            this(true, iSymbol, a => a, a => a)
        {
        }

        /// <summary>
        /// Convenience constructor for initializing prefixed non-standard unit
        /// </summary>
        /// <param name="iPrefix">Prefix to use in unit naming and scaling vis-a-vis standard unit</param>
        public Unit(UnitPrefix iPrefix)
            : this(String.Format("{0}{1}", iPrefix.GetSymbol(), default(Q).StandardUnit), iPrefix.GetFactor())
        {
        }

        /// <summary>
        /// Initialize a physical unit object
        /// </summary>
        /// <param name="iSymbol">Unit display symbol</param>
        /// <param name="iToStandardUnitFactor">Amount converter factor from this unit to quantity's standard unit</param>
        public Unit(string iSymbol, AmountType iToStandardUnitFactor)
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            : this(iToStandardUnitFactor == Constants.One, iSymbol, a => a * iToStandardUnitFactor, a => a / iToStandardUnitFactor)
        {
        }

        /// <summary>
        /// Initializes a physical unit object
        /// </summary>
        /// <param name="iSymbol">Unit display symbol</param>
        /// <param name="iAmountToStandardUnitConverter">Amount converter function from this unit to quantity's standard unit</param>
        /// <param name="iAmountFromStandardUnitConverter">Amount converter function from quantity's standard unit to this unit</param>
        public Unit(
            string iSymbol,
            Func<AmountType, AmountType> iAmountToStandardUnitConverter,
            Func<AmountType, AmountType> iAmountFromStandardUnitConverter)
            : this(false, iSymbol, iAmountToStandardUnitConverter, iAmountFromStandardUnitConverter)
        {
        }

        /// <summary>
        /// Initializes a physical unit object
        /// </summary>
        /// <param name="isStandardUnit">True if the unit is a standard unit of the associated quantity, false otherwise</param>
        /// <param name="iSymbol">Unit display symbol</param>
        /// <param name="iConvertAmountToStandardUnit">Amount converter function from this unit to quantity's standard unit</param>
        /// <param name="iConvertStandardAmountToUnit">Amount converter function from quantity's standard unit to this unit</param>
        private Unit(
            bool isStandardUnit,
            string iSymbol,
            Func<AmountType, AmountType> iConvertAmountToStandardUnit,
            Func<AmountType, AmountType> iConvertStandardAmountToUnit)
        {
            this.IsStandardUnit = isStandardUnit;
            this.Symbol = iSymbol;
            this.DisplayName = String.Empty;
            this.ConvertAmountToStandardUnit = iConvertAmountToStandardUnit;
            this.ConvertStandardAmountToUnit = iConvertStandardAmountToUnit;
        }

        #endregion

        #region Implementation of IUnit<Q>

        /// <summary>
        /// Gets the quantity associated with the unit
        /// </summary>
        IQuantity IUnit.Quantity
        {
            get { return this.Quantity; }
        }

        /// <summary>
        /// Gets true if the unit is a standard unit of the associated quantity, false otherwise
        /// </summary>
        public bool IsStandardUnit { get; private set; }

        /// <summary>
        /// Gets the typed quantity associated with the unit
        /// </summary>
        public IQuantity<Q> Quantity
        {
            get { return default(Q); }
        }

        /// <summary>
        /// Gets the display symbol of the unit
        /// </summary>
        public string Symbol { get; private set; }

        /// <summary>
        /// Gets or sets the fully qualified display name of the unit
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets the amount converter function from the current unit to the standard unit 
        /// of the specified quantity
        /// </summary>
        public Func<AmountType, AmountType> ConvertAmountToStandardUnit { get; private set; }

        /// <summary>
        /// Gets the amount converter function from the standard unit of the specified quantity
        /// to the current unit
        /// </summary>
        public Func<AmountType, AmountType> ConvertStandardAmountToUnit { get; private set; }

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
            return this.Symbol;
        }

        #endregion
    }
}