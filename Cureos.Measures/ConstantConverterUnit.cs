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
    using System.Runtime.Serialization;

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
    [DataContract]
    public sealed class ConstantConverterUnit<Q> : IUnit<Q> where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
    {
        #region FIELDS

        private readonly Q quantity = default(Q);

        [DataMember]
        private readonly bool isStandardUnit;

        [DataMember]
        private readonly string symbol;

        private string displayName;

        [DataMember]
        private readonly AmountType amountToStandardUnitFactor;

        [DataMember]
        private readonly AmountType standardAmountToUnitFactor;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a physical unit object that is the standard unit of the specific quantity
        /// </summary>
        /// <param name="symbol">Unit display symbol</param>
        public ConstantConverterUnit(string symbol)
        {
            this.isStandardUnit = true;
            this.symbol = symbol;
            this.displayName = null;
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
        public ConstantConverterUnit(string symbol, AmountType toStandardUnitFactor)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            this.isStandardUnit = toStandardUnitFactor == Constants.One;
            this.symbol = symbol;
            this.displayName = null;
            this.amountToStandardUnitFactor = toStandardUnitFactor;
            this.standardAmountToUnitFactor = 1.0 / toStandardUnitFactor;
        }
        #endregion

        #region Implementation of IUnit<Q>

        /// <summary>
        /// Gets the quantity associated with the unit
        /// </summary>
        IQuantity IUnit.Quantity
        {
            get { return this.quantity; }
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
            get { return this.quantity; }
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
        /// Gets or sets the fully qualified display name of the unit
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
        public double ConvertAmountToStandardUnit(double amount)
        {
            return this.amountToStandardUnitFactor * amount;
        }

        /// <summary>
        /// Convert a standard amount to this unit of the specified quantity
        /// to the current unit
        /// </summary>
        /// <param name="standardAmount">Standard amount of the current <see cref="IUnit.Quantity"/>.</param>
        /// <returns>Amount in this unit.</returns>
        public double ConvertStandardAmountToUnit(double standardAmount)
        {
            return this.standardAmountToUnitFactor * standardAmount;
        }

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

        #region OPERATORS

        /// <summary>
        /// Creates a new measure object of the specified quantity.
        /// </summary>
        /// <param name="amount">The quantity amount.</param>
        /// <param name="unit">The quantity unit.</param>
        /// <returns>A new measure object of the specified quantity.</returns>
        public static Q operator *(AmountType amount, ConstantConverterUnit<Q> unit)
        {
            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            return unit.quantity.Create(amount, unit);
        }

        #endregion
    }
}