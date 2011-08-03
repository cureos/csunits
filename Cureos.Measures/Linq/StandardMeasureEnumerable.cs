// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System.Collections.Generic;
using System.Linq;

namespace Cureos.Measures.Linq
{
    public static class StandardMeasureEnumerable
    {
        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <returns>Collection of standard measures</returns>
        public static IEnumerable<StandardMeasure<Q>> ToStandardMeasures<Q>(this IEnumerable<double> iAmounts) where Q : struct, IQuantity<Q>
        {
            return iAmounts.Select(val => new StandardMeasure<Q>(val));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <param name="iUnit">Unit in which the amounts are specified</param>
        /// <returns>Collection of standard measures, converted from specified unit into quantity's standard unit</returns>
        public static IEnumerable<StandardMeasure<Q>> ToStandardMeasures<Q>(this IEnumerable<double> iAmounts, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return iAmounts.Select(val => new StandardMeasure<Q>(val, iUnit));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <returns>Collection of standard measures</returns>
        public static IEnumerable<StandardMeasure<Q>> ToStandardMeasures<Q>(this IEnumerable<float> iAmounts) where Q : struct, IQuantity<Q>
        {
            return iAmounts.Select(val => new StandardMeasure<Q>(val));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <param name="iUnit">Unit in which the amounts are specified</param>
        /// <returns>Collection of standard measures, converted from specified unit into quantity's standard unit</returns>
        public static IEnumerable<StandardMeasure<Q>> ToStandardMeasures<Q>(this IEnumerable<float> iAmounts, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return iAmounts.Select(val => new StandardMeasure<Q>(val, iUnit));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <returns>Collection of standard measures</returns>
        public static IEnumerable<StandardMeasure<Q>> ToStandardMeasures<Q>(this IEnumerable<decimal> iAmounts) where Q : struct, IQuantity<Q>
        {
            return iAmounts.Select(val => new StandardMeasure<Q>(val));
        }

        /// <summary>
        /// Cast collection of amounts into corresponding StandardMeasure enumerable
        /// </summary>
        /// <typeparam name="Q">Quantity of measurements</typeparam>
        /// <param name="iAmounts">Collection of amounts to be cast into a collection of standard measures</param>
        /// <param name="iUnit">Unit in which the amounts are specified</param>
        /// <returns>Collection of standard measures, converted from specified unit into quantity's standard unit</returns>
        public static IEnumerable<StandardMeasure<Q>> ToStandardMeasures<Q>(this IEnumerable<decimal> iAmounts, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return iAmounts.Select(val => new StandardMeasure<Q>(val, iUnit));
        }
    }
}