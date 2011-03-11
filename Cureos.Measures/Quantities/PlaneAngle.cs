// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the plane angle quantity
    /// </summary>
    public struct PlaneAngle : IQuantity<PlaneAngle>
    {
        #region FIELDS

        public static readonly Unit<PlaneAngle> Radian = new Unit<PlaneAngle>("rad");
        public static readonly Unit<PlaneAngle> Degree = new Unit<PlaneAngle>("°", Factors.DegreesPerRadian);

        #endregion
        
        #region Implementation of IQuantity<PlaneAngle>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return QuantityDimension.PlaneAngle; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        public IUnit<PlaneAngle> StandardUnit
        {
            get { return Radian; }
        }

        #endregion
    }
}