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
    public sealed class ConstantConverterUnit<Q> : Unit<Q> where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
    {
        #region FIELDS

        private readonly AmountType amountToStandardUnitFactor;

        private readonly AmountType standardAmountToUnitFactor;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a physical unit object that is the standard unit of the specific quantity
        /// </summary>
        /// <param name="symbol">Unit display symbol</param>
        public ConstantConverterUnit(string symbol) : base(true, symbol)
        {
            this.amountToStandardUnitFactor = 1.0;
            this.standardAmountToUnitFactor = 1.0;
        }

        /// <summary>
        /// Convenience constructor for initializing prefixed non-standard unit
        /// </summary>
        /// <param name="prefix">Prefix to use in unit naming and scaling vis-a-vis standard unit</param>
        public ConstantConverterUnit(UnitPrefix prefix)
            : this(string.Format("{0}{1}", prefix.GetSymbol(), default(Q).StandardUnit), prefix.GetFactor())
        {
        }

        /// <summary>
        /// Initialize a physical unit object
        /// </summary>
        /// <param name="symbol">Unit display symbol</param>
        /// <param name="toStandardUnitFactor">Amount converter factor from this unit to quantity's standard unit</param>
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        public ConstantConverterUnit(string symbol, AmountType toStandardUnitFactor)
            : base(toStandardUnitFactor == Constants.One, symbol)
        {
            this.amountToStandardUnitFactor = toStandardUnitFactor;
            this.standardAmountToUnitFactor = 1.0 / toStandardUnitFactor;
        }

        #endregion

        #region Implementation of IUnit<Q>

        /// <summary>
        /// Convert the amount from the current unit to the standard unit of the specified quantity
        /// </summary>
        /// <param name="amount">Amount in this unit</param>
        /// <returns>Amount converted to standard unit</returns>
        public override double ConvertAmountToStandardUnit(double amount)
        {
            return this.amountToStandardUnitFactor * amount;
        }

        /// <summary>
        /// Convert a standard amount to this unit of the specified quantity
        /// to the current unit
        /// </summary>
        /// <param name="standardAmount">Standard amount of the current <see cref="IUnit.Quantity"/>.</param>
        /// <returns>Amount in this unit.</returns>
        public override double ConvertStandardAmountToUnit(double standardAmount)
        {
            return this.standardAmountToUnitFactor * standardAmount;
        }

        #endregion
    }
}