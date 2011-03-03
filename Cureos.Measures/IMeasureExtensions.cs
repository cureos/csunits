// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
    /// <summary>
    /// Static class containing extension methods for classes implementing the IMeasure interface
    /// </summary>
    public static class IMeasureExtensions
    {
        /// <summary>
        /// Gets the quantity associated with the specified measure
        /// </summary>
        /// <param name="iMeasure">Measure for which the quantity is requested</param>
        /// <returns>Quantity associated with the measure</returns>
        public static Quantity GetQuantity(this IMeasure iMeasure)
        {
            return iMeasure.Unit.GetQuantity();
        }

        /// <summary>
        /// Gets the reference unit for the measured quantity
        /// </summary>
        /// <param name="iMeasure">Measure for which the reference unit is requested</param>
        /// <returns>Reference unit of the measured quantity</returns>
        public static Unit GetReferenceUnit(this IMeasure iMeasure)
        {
            return iMeasure.Unit.GetReferenceUnit();
        }

        /// <summary>
        /// Gets the amount in terms of the reference unit of the measured quantity
        /// </summary>
        /// <param name="iMeasure">Measure for which the reference unit amount is requested</param>
        /// <returns>Amount in terms of the reference unit of the measured quantity</returns>
        public static AmountType GetReferenceUnitAmount(this IMeasure iMeasure)
        {
            return iMeasure.Unit.ConvertAmountToReferenceUnit(iMeasure.Amount);
        }

        /// <summary>
        /// Gets the amount of the <paramref name="iMeasure">specified measure</paramref> in the requested unit
        /// </summary>
        /// <param name="iMeasure">Measure for which the amount should be converted into the requested unit</param>
        /// <param name="iUnit">Unit to which the measured amount should be converted</param>
        /// <returns>Measured amount converted into <paramref name="iUnit">specified unit</paramref></returns>
        /// <exception cref="InvalidOperationException">is thrown if the quantity of the specified unit is different
        /// from the measured quantity</exception>
        public static AmountType GetAmount(this IMeasure iMeasure, Unit iUnit)
        {
            if (GetQuantity(iMeasure).IsUnitSupported(iUnit))
            {
                return iUnit.ConvertAmountFromReferenceUnit(GetReferenceUnitAmount(iMeasure));
            }
            throw new InvalidOperationException(
                String.Format("Quantity of unit {0} is not equal to measured quantity {1}",
                iUnit, GetQuantity(iMeasure)));
        }

        /// <summary>
        /// Gets the measure as a string, with amount converted to the requested unit
        /// </summary>
        /// <param name="iMeasure">Measure for which the description string should be generated</param>
        /// <param name="iUnit">Unit in which the measure should be presented</param>
        /// <returns>Measure as a string in the <paramref name="iUnit">specified unit</paramref></returns>
        /// <exception cref="InvalidOperationException">if the <paramref name="iUnit">specified unit</paramref> is of
        /// a different quantity than the <see cref="Unit">measured unit </see></exception>
        public static string ToString(this IMeasure iMeasure, Unit iUnit)
        {
            return string.Format("{0} {1}", GetAmount(iMeasure, iUnit), iUnit).Trim();
        }
    }
}