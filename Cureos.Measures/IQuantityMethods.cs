// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures
{
    /// <summary>
    /// Extension methods associated with objects implementing the IQuantity interface
    /// </summary>
    public static class IQuantityMethods
    {
        /// <summary>
        /// Gets the name of the quantity
        /// </summary>
        /// <param name="iQuantity">Quantity for which the name is requested</param>
        /// <returns>Name of the quantity, based on the short name of the associated type</returns>
        public static string GetName(this IQuantity iQuantity)
        {
            return iQuantity.GetType().Name;
        }
    }
}