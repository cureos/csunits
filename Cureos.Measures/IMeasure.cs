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
    /// Interface representing a scalar measure of an arbitrary quantity
    /// </summary>
    public interface IMeasure : IComparable<IMeasure>, IEquatable<IMeasure>
    {
        /// <summary>
        /// Gets the measured amount in the <see cref="Unit">current unit of measure</see>
        /// </summary>
        AmountType Amount { get; }

        /// <summary>
        /// Gets the measured amount in the standard unit of measure for the inherent quantity
        /// </summary>
        AmountType StandardAmount { get; }

        /// <summary>
        /// Gets the unit of measure
        /// </summary>
        IUnit Unit { get; }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="iUnit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="iUnit">specified unit</paramref></returns>
        AmountType GetAmount(IUnit iUnit);

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="iUnit">specified unit</paramref>
        /// </summary>
        /// <param name="iUnit">Unit in which the new measure should be specified</param>
        IMeasure this[IUnit iUnit] { get; }
    }

    /// <summary>
    /// Interface representing a scalar measure of a specific quantity
    /// </summary>
    /// <typeparam name="Q">Measured quantity</typeparam>
    public interface IMeasure<Q> : IMeasure, IComparable<IMeasure<Q>>, IEquatable<IMeasure<Q>> where Q : struct, IQuantity<Q>
    {
        /// <summary>
        /// Gets the quantity-typed unit of measure
        /// </summary>
        new IUnit<Q> Unit { get; }

        /// <summary>
        /// Gets the measure factory associated with the quantity.
        /// </summary>
        IMeasureFactory<Q> Factory { get; }

        /// <summary>
        /// Gets the amount of this measure in the requested unit
        /// </summary>
        /// <param name="iUnit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="iUnit">specified unit</paramref></returns>
        AmountType GetAmount(IUnit<Q> iUnit);

        /// <summary>
        /// Gets a new unit specific measure based on this measure but in the <paramref name="iUnit">specified unit</paramref>
        /// </summary>
        /// <param name="iUnit">Unit in which the new measure should be specified</param>
        IMeasure<Q> this[IUnit<Q> iUnit] { get; }
    }
}

