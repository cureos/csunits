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

#if SINGLE
    using AmountType = System.Single;
#elif DECIMAL
    using AmountType = System.Decimal;
#elif DOUBLE
    using AmountType = System.Double;
#endif

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
        /// <param name="amounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <returns>Collection of standard measures</returns>
        public static IEnumerable<Q> Cast<Q>(this IEnumerable<double> amounts)
            where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return amounts.Select(val => quantity.Create(val));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding measure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="amounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <param name="unit">Unit in which the amounts are specified</param>
        /// <returns>Collection of standard measures, converted from specified unit into quantity's standard unit</returns>
        public static IEnumerable<Q> Cast<Q>(this IEnumerable<double> amounts, IUnit<Q> unit)
            where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return amounts.Select(val => quantity.Create(val, unit));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="amounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <returns>Collection of standard measures</returns>
        public static IEnumerable<Q> Cast<Q>(this IEnumerable<float> amounts) where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return amounts.Select(val => quantity.Create(val));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="amounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <param name="unit">Unit in which the amounts are specified</param>
        /// <returns>Collection of standard measures, converted from specified unit into quantity's standard unit</returns>
        public static IEnumerable<Q> Cast<Q>(this IEnumerable<float> amounts, IUnit<Q> unit)
            where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return amounts.Select(val => quantity.Create(val, unit));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="amounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <returns>Collection of standard measures</returns>
        public static IEnumerable<Q> Cast<Q>(this IEnumerable<decimal> amounts)
            where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return amounts.Select(val => quantity.Create(val));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="amounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <param name="unit">Unit in which the amounts are specified</param>
        /// <returns>Collection of standard measures, converted from specified unit into quantity's standard unit</returns>
        public static IEnumerable<Q> Cast<Q>(this IEnumerable<decimal> amounts, IUnit<Q> unit)
            where Q : struct, IQuantity<Q>, IMeasureFactory<Q>
        {
            var quantity = default(Q);
            return amounts.Select(val => quantity.Create(val, unit));
        }

        /// <summary>
        /// Get enumerable of amounts in standard unit from collection of measures.
        /// </summary>
        /// <typeparam name="Q">Quantity of measures.</typeparam>
        /// <param name="measures">Collection of measures.</param>
        /// <returns>Enumerable of amounts in standard unit.</returns>
        public static IEnumerable<AmountType> Cast<Q>(this IEnumerable<IMeasure<Q>> measures)
            where Q : struct, IQuantity<Q>
        {
            return measures.Select(measure => measure.StandardAmount);
        }

        /// <summary>
        /// Get enumerable of amounts in specified <paramref name="unitOfAmounts">unit of amounts</paramref>.
        /// </summary>
        /// <typeparam name="Q">Quantity of measures.</typeparam>
        /// <param name="measures">Collection of measures.</param>
        /// <param name="unitOfAmounts">Unit in which the amounts should be given.</param>
        /// <returns>Enumerable of amounts in specified <paramref name="unitOfAmounts">unit of amounts</paramref>.</returns>
        public static IEnumerable<AmountType> Cast<Q>(this IEnumerable<IMeasure<Q>> measures, IUnit<Q> unitOfAmounts)
            where Q : struct, IQuantity<Q>
        {
            return measures.Select(measure => measure.GetAmount(unitOfAmounts));
        }

        #endregion
    }
}
