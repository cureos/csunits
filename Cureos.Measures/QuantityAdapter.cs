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


namespace Cureos.Measures
{
    using System.Collections.Generic;

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
            this.Quantity = iQuantity;
            this.Units = iUnits;
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
        
        #region OVERRIDDEN METHODS

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString ()
        {
            return this.Quantity.DisplayName;
        }
        
        #endregion
    }
}