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
    public
#if !SILVERLIGHT
        static 
#endif
        class Registry
    {
        #region CONSTRUCTORS

        static Registry()
        {
            Units =
                Assembly.GetExecutingAssembly().GetTypes().
                    Where(type => type.GetInterfaces().Contains(typeof(IQuantity))).
                    SelectMany(type => type.GetFields(BindingFlags.Public | BindingFlags.Static)).
                    Select(fieldInfo => fieldInfo.GetValue(null) as IUnit).
                    Where(obj => !ReferenceEquals(obj, null));

            Quantities = Units.Select(u => u.Quantity).Distinct();
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the quantities available in this class library
        /// </summary>
        public static IEnumerable<IQuantity> Quantities { get; private set; }

        /// <summary>
        /// Gets the physical units available in this class library
        /// </summary>
        public static IEnumerable<IUnit> Units { get; private set; }

        #endregion

        #region METHODS

        /// <summary>
        /// Gets the defined units associated with a specific quantity
        /// </summary>
        /// <param name="iQuantity">Quantity for which the collection of defined units is requested</param>
        /// <returns>Enumerable collection of defined units associated with <paramref name="iQuantity"/></returns>
        public static IEnumerable<IUnit> GetUnits(IQuantity iQuantity)
        {
            return Units.Where(u => u.Quantity.Equals(iQuantity));
        }

        #endregion
    }
}