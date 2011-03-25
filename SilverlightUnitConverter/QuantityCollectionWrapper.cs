// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System.Collections.Generic;
using System.Linq;
using Cureos.Measures;

namespace SilverlightUnitConverter
{
    /// <summary>
    /// Non-static wrapper class for accessing properties of the static QuantityCollection class
    /// </summary>
    public class QuantityCollectionWrapper
    {
        /// <summary>
        /// Gets the quantities contained in the quantities class library
        /// </summary>
        public IEnumerable<QuantityAdapter> Quantities
        {
            get { return QuantityCollection.Quantities.OrderBy(qa => qa.Quantity.ToString()); }
        }
    }
}