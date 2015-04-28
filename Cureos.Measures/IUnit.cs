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
    /// Interface representing a physical unit
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Gets the quantity associated with the unit
        /// </summary>
        IQuantity Quantity { get; }

        /// <summary>
        /// Gets true if the unit is a standard unit of the associated quantity, false otherwise
        /// </summary>
        bool IsStandardUnit { get; }

        /// <summary>
        /// Gets the display symbol of the unit
        /// </summary>
        string Symbol { get; }

        /// <summary>
        /// Gets or sets the fully qualified display name of the unit
        /// </summary>
        string DisplayName { get; set; }

        /// <summary>
        /// Gets the amount converter function from the current unit to the standard unit 
        /// of the specified quantity
        /// </summary>
        Func<AmountType, AmountType> ConvertAmountToStandardUnit { get; }

        /// <summary>
        /// Gets the amount converter function from the standard unit of the specified quantity
        /// to the current unit
        /// </summary>
        Func<AmountType, AmountType> ConvertStandardAmountToUnit { get; }
    }

    /// <summary>
    /// Interface representing a physical unit confined to a specific quantity
    /// </summary>
    /// <typeparam name="Q">Unit quantity</typeparam>
    public interface IUnit<Q> : IUnit where Q : struct, IQuantity<Q>
    {
        /// <summary>
        /// Gets the typed quantity associated with the unit
        /// </summary>
        new IQuantity<Q> Quantity { get; }
    }
}

