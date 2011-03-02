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
        public static Quantity GetQuantity(this IMeasure iMeasure)
        {
            return iMeasure.Unit.GetQuantity();
        }

        public static Unit GetReferenceUnit(this IMeasure iMeasure)
        {
            return iMeasure.Unit.GetReferenceUnit();
        }

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

        public static string ToString(this IMeasure iMeasure, Unit iUnit)
        {
            return string.Format("{0} {1}", GetAmount(iMeasure, iUnit), iUnit).Trim();
        }
    }
}