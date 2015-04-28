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

namespace SilverlightUnitConverter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Cureos.Measures;

    /// <summary>
    /// Conversion of amount given in one physical unit to another specified physical unit
    /// </summary>
    /// <remarks>
    /// MultiBinding support is not provided out-of-the-box in Silverlight 4 and earlier. This implementation
    /// is using support code developed by Colin Eberhart, and the implementation and usage is displayed in 
    /// detail on the following web page:
    /// http://www.scottlogic.co.uk/blog/colin/2010/08/silverlight-multibinding-updated-adding-support-for-elementname-and-twoway-binding/
    /// </remarks>
    public class UnitConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        /// <summary>
        /// Converts the elements in the multiple binding into a new measure amount
        /// </summary>
        /// <param name="values">Bound elements; it is required that the elements appear in the order from-amount, 
        /// from-unit, to-unit</param>
        /// <param name="targetType">Ignored</param>
        /// <param name="parameter">Ignored</param>
        /// <param name="culture">Culture info, applied in parsing of specified amount</param>
        /// <returns>amount converted to the specified to-unit, or null if array of <paramref name="values"/> did
        /// not meet the type requirements</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double fromAmount;
            IUnit fromUnit, toUnit;
            if (values.Length == 3 && Double.TryParse(values[0].ToString(), NumberStyles.Number, culture, out fromAmount) &&
                (fromUnit = values[1] as IUnit) != null && (toUnit = values[2] as IUnit) != null)
            {
                return toUnit.ConvertStandardAmountToUnit(fromUnit.ConvertAmountToStandardUnit(fromAmount));
            }
            return null;
        }

        /// <summary>
        /// Back converter; not supported
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}