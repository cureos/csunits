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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cureos.Measures
{
    /// <summary>
    /// Overview of quantities and units available in the class library.
    /// </summary>
    public static class QuantityCollection
    {
        #region CONSTRUCTORS

        static QuantityCollection()
        {
            IEnumerable<IUnit> units =
                Assembly.GetExecutingAssembly().GetTypes().
                    Where(type => type.GetInterfaces().Contains(typeof(IQuantity))).
                    SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static)).
                    Select(fieldInfo => fieldInfo.GetValue(null) as IUnit).
                    Where(obj => !ReferenceEquals(obj, null));

            Quantities = units.Select(unit => unit.Quantity).Distinct().
                Select(quantity => new QuantityAdapter(quantity, units.Where(unit => unit.Quantity.Equals(quantity))));

            Assembly.GetExecutingAssembly().GetTypes().
                SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static)).
                Where(fieldInfo => fieldInfo.FieldType.GetInterfaces().Contains(typeof(IUnit))).
                Any(fieldInfo =>
                        {
                            var unit = (IUnit) fieldInfo.GetValue(null);
                            unit.DisplayName = String.Format("{0} | {1}", 
                                fieldInfo.Name, String.IsNullOrEmpty(unit.Symbol) ? "<none>" : unit.Symbol);
                            return false;
                        });
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the quantities available in this class library
        /// </summary>
        public static IEnumerable<QuantityAdapter> Quantities { get; private set; }

        #endregion
        
        #region INDEXERS
        
        public static QuantityAdapter GetQuantity(string label)
        {
            return Quantities.Single(qa => qa.Quantity.DisplayName.Equals(label));
        }
        
        #endregion
    }
}