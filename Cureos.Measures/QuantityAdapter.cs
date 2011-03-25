// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;

namespace Cureos.Measures
{
    /// <summary>
    /// Convenience class for accessing a quantity and its associated units
    /// </summary>
    public class QuantityAdapter
    {
        #region CONSTRUCTORS

        /// <summary>
        /// Initializes an instance of a wrapper object containing a quantity and its associated units
        /// </summary>
        /// <param name="iQuantity">Quantity</param>
        /// <param name="iUnits">Units associated with the quantity</param>
        public QuantityAdapter(IQuantity iQuantity, IEnumerable<IUnit> iUnits)
        {
            Quantity = iQuantity;
            Units = iUnits;
        }

        #endregion

        #region AUTO-IMPLEMENTED PROPERTIES

        /// <summary>
        /// Gets the contained quantity
        /// </summary>
        public IQuantity Quantity { get; private set; }

        /// <summary>
        /// Gets the units associated with the quantity
        /// </summary>
        public IEnumerable<IUnit> Units { get; private set; }

        #endregion
    }
}