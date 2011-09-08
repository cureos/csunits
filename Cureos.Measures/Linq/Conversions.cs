// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures.Linq
{
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
        public static Measure<Q> To<Q>(this double iAmount, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return new Measure<Q>(iAmount, iUnit);
        }

        /// <summary>
        /// Convert floating-point value into measure of specified amount and unit
        /// </summary>
        /// <typeparam name="Q">Quantity</typeparam>
        /// <param name="iAmount">Floating-point value representing the measure amount</param>
        /// <param name="iUnit">Requested unit of measure</param>
        /// <returns>Measure in the specified amount and unit</returns>
        public static Measure<Q> To<Q>(this float iAmount, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return new Measure<Q>(iAmount, iUnit);
        }

        /// <summary>
        /// Convert floating-point value into measure of specified amount and unit
        /// </summary>
        /// <typeparam name="Q">Quantity</typeparam>
        /// <param name="iAmount">Floating-point value representing the measure amount</param>
        /// <param name="iUnit">Requested unit of measure</param>
        /// <returns>Measure in the specified amount and unit</returns>
        public static Measure<Q> To<Q>(this decimal iAmount, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return new Measure<Q>(iAmount, iUnit);
        }

        /// <summary>
        /// Convert floating-point value into standard measure, based on the specified amount and unit
        /// </summary>
        /// <typeparam name="Q">Quantity</typeparam>
        /// <param name="iAmount">Floating-point value representing the amount in the specified unit</param>
        /// <param name="iUnit">Observed unit of measure</param>
        /// <returns>Standard measure corresponding to the specified amount and unit</returns>
        public static StandardMeasure<Q> From<Q>(this double iAmount, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return new StandardMeasure<Q>(iAmount, iUnit);
        }

        /// <summary>
        /// Convert floating-point value into standard measure, based on the specified amount and unit
        /// </summary>
        /// <typeparam name="Q">Quantity</typeparam>
        /// <param name="iAmount">Floating-point value representing the amount in the specified unit</param>
        /// <param name="iUnit">Observed unit of measure</param>
        /// <returns>Standard measure corresponding to the specified amount and unit</returns>
        public static StandardMeasure<Q> From<Q>(this float iAmount, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return new StandardMeasure<Q>(iAmount, iUnit);
        }

        /// <summary>
        /// Convert floating-point value into standard measure, based on the specified amount and unit
        /// </summary>
        /// <typeparam name="Q">Quantity</typeparam>
        /// <param name="iAmount">Floating-point value representing the amount in the specified unit</param>
        /// <param name="iUnit">Observed unit of measure</param>
        /// <returns>Standard measure corresponding to the specified amount and unit</returns>
        public static StandardMeasure<Q> From<Q>(this decimal iAmount, IUnit<Q> iUnit) where Q : struct, IQuantity<Q>
        {
            return new StandardMeasure<Q>(iAmount, iUnit);
        }
    }
}