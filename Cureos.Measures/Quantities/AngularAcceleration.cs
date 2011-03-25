// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the angular acceleration quantity
    /// </summary>
    public struct AngularAcceleration : IQuantity<AngularAcceleration>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension =
            new QuantityDimension(DimensionlessDifferentiators.Radian) * (QuantityDimension.Time ^ -2);

        public static readonly Unit<AngularAcceleration> RadianPerSecondSquared = new Unit<AngularAcceleration>("rad s\u207b²");
        public static readonly Unit<AngularAcceleration> KiloRadianPerSecondSquared = new Unit<AngularAcceleration>(UnitPrefix.Kilo);
        public static readonly Unit<AngularAcceleration> MegaRadianPerSecondSquared = new Unit<AngularAcceleration>(UnitPrefix.Mega);
        public static readonly Unit<AngularAcceleration> GigaRadianPerSecondSquared = new Unit<AngularAcceleration>(UnitPrefix.Giga);
        public static readonly Unit<AngularAcceleration> MilliRadianPerSecondSquared = new Unit<AngularAcceleration>(UnitPrefix.Milli);
        public static readonly Unit<AngularAcceleration> MicroRadianPerSecondSquared = new Unit<AngularAcceleration>(UnitPrefix.Micro);
        public static readonly Unit<AngularAcceleration> NanoRadianPerSecondSquared = new Unit<AngularAcceleration>(UnitPrefix.Nano);

        #endregion

        #region Implementation of IQuantity<AngularAcceleration>

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
        public IUnit<AngularAcceleration> StandardUnit
        {
            get { return RadianPerSecondSquared; }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return GetType().Name;
        }

        #endregion
    }
}
