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

namespace Cureos.Measures.Linq
{
#if SINGLE
    using AmountType = System.Single;
#elif DECIMAL
    using AmountType = System.Decimal;
#elif DOUBLE
    using AmountType = System.Double;
#endif

    /// <summary>
    /// Convenience class for "converting" floating-point values into corresponding measures
    /// </summary>
    public static class Conversions
    {
        /// <summary>
        /// Convert floating-point value into measure of specified amount and unit
        /// </summary>
        /// <typeparam name="Q">Quantity</typeparam>
        /// <param name="iAmount">Floating-point value representing the measure amount</param>
        /// <param name="iUnit">Requested unit of measure</param>
        /// <returns>Measure in the specified amount and unit</returns>
        public static InUnitMeasure<Q> To<Q>(this double iAmount, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return new InUnitMeasure<Q>(iAmount, iUnit);
        }

        /// <summary>
        /// Convert floating-point value into measure of specified amount and unit
        /// </summary>
        /// <typeparam name="Q">Quantity</typeparam>
        /// <param name="iAmount">Floating-point value representing the measure amount</param>
        /// <param name="iUnit">Requested unit of measure</param>
        /// <returns>Measure in the specified amount and unit</returns>
        public static InUnitMeasure<Q> To<Q>(this float iAmount, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return new InUnitMeasure<Q>(iAmount, iUnit);
        }

        /// <summary>
        /// Convert floating-point value into measure of specified amount and unit
        /// </summary>
        /// <typeparam name="Q">Quantity</typeparam>
        /// <param name="iAmount">Floating-point value representing the measure amount</param>
        /// <param name="iUnit">Requested unit of measure</param>
        /// <returns>Measure in the specified amount and unit</returns>
        public static InUnitMeasure<Q> To<Q>(this decimal iAmount, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return new InUnitMeasure<Q>(iAmount, iUnit);
        }
    }
}