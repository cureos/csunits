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
    /// Interface representing a physical quantity
    /// </summary>
    public interface IQuantity : IEquatable<IQuantity>
    {
        /// <summary>
        /// Gets the display name of the quantity
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        QuantityDimension Dimension { get; }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        IUnit StandardUnit { get; }
    }

    /// <summary>
    /// Typed interface representing a physical quantity
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    public interface IQuantity<Q> : IQuantity where Q : struct, IQuantity<Q>
    {
        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        new IUnit<Q> StandardUnit { get; }

        /// <summary>
        /// Creates a new measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.
        /// </summary>
        /// <param name="amount">Amount.</param>
        /// <param name="unit">Unit.</param>
        /// <returns>Measure from the specified <paramref name="amount"/> and <paramref name="unit"/>.</returns>
        Q New(AmountType amount, IUnit<Q> unit);
    }
}

