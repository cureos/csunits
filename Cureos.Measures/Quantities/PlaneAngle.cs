// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the plane angle quantity
    /// </summary>
    public struct PlaneAngle : IQuantity<PlaneAngle>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension = new QuantityDimension(DimensionlessDifferentiators.Radian);

        public static readonly Unit<PlaneAngle> Radian = new Unit<PlaneAngle>("rad");
        public static readonly Unit<PlaneAngle> Degree = new Unit<PlaneAngle>("°", Factors.RadiansPerDegree);

        #endregion
        
        #region Implementation of IQuantity<PlaneAngle>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return _dimension; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        IUnit IQuantity.StandardUnit
        {
            get { return StandardUnit; }
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