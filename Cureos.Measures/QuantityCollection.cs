// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

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
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the quantities available in this class library
        /// </summary>
        public static IEnumerable<QuantityAdapter> Quantities { get; private set; }

        #endregion
    }
}