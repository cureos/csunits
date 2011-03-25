// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the angular velocity quantity
    /// </summary>
    public struct AngularVelocity : IQuantity<AngularVelocity>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension =
            new QuantityDimension(DimensionlessDifferentiators.Radian) * (QuantityDimension.Time ^ -1);

        public static readonly Unit<AngularVelocity> RadianPerSecond = new Unit<AngularVelocity>("rad s\u207b¹");
        public static readonly Unit<AngularVelocity> KiloRadianPerSecond = new Unit<AngularVelocity>(UnitPrefix.Kilo);
        public static readonly Unit<AngularVelocity> MegaRadianPerSecond = new Unit<AngularVelocity>(UnitPrefix.Mega);
        public static readonly Unit<AngularVelocity> GigaRadianPerSecond = new Unit<AngularVelocity>(UnitPrefix.Giga);
        public static readonly Unit<AngularVelocity> MilliRadianPerSecond = new Unit<AngularVelocity>(UnitPrefix.Milli);
        public static readonly Unit<AngularVelocity> MicroRadianPerSecond = new Unit<AngularVelocity>(UnitPrefix.Micro);
        public static readonly Unit<AngularVelocity> NanoRadianPerSecond = new Unit<AngularVelocity>(UnitPrefix.Nano);

        #endregion

        #region Implementation of IQuantity<AngularVelocity>

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
        public IUnit<AngularVelocity> StandardUnit
        {
            get { return RadianPerSecond; }
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
