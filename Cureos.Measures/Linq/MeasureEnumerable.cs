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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Convenience class for creating collections of specific quantities from collections of amounts.
    /// </summary>
    public static class MeasureEnumerable
    {
        #region METHODS

        /// <summary>
        /// Cast collection of amounts into corresponding measure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <returns>Collection of standard measures</returns>
        public static IEnumerable<Q> ToMeasures<Q>(this IEnumerable<double> iAmounts) where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return iAmounts.Select(val => quantity.Create(val));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding measure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <param name="iUnit">Unit in which the amounts are specified</param>
        /// <returns>Collection of standard measures, converted from specified unit into quantity's standard unit</returns>
        public static IEnumerable<Q> ToMeasures<Q>(this IEnumerable<double> iAmounts, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return iAmounts.Select(val => quantity.Create(val, iUnit));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <returns>Collection of standard measures</returns>
        public static IEnumerable<Q> ToMeasures<Q>(this IEnumerable<float> iAmounts) where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return iAmounts.Select(val => quantity.Create(val));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <param name="iUnit">Unit in which the amounts are specified</param>
        /// <returns>Collection of standard measures, converted from specified unit into quantity's standard unit</returns>
        public static IEnumerable<Q> ToMeasures<Q>(this IEnumerable<float> iAmounts, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return iAmounts.Select(val => quantity.Create(val, iUnit));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <returns>Collection of standard measures</returns>
        public static IEnumerable<Q> ToMeasures<Q>(this IEnumerable<decimal> iAmounts) where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return iAmounts.Select(val => quantity.Create(val));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <param name="iUnit">Unit in which the amounts are specified</param>
        /// <returns>Collection of standard measures, converted from specified unit into quantity's standard unit</returns>
        public static IEnumerable<Q> ToMeasures<Q>(this IEnumerable<decimal> iAmounts, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return iAmounts.Select(val => quantity.Create(val, iUnit));
        }

        #endregion
    }
}
