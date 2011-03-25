// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the moment of force quantity
    /// </summary>
    public struct MomentOfForce : IQuantity<MomentOfForce>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension =
            (QuantityDimension.Length ^ 2) * QuantityDimension.Mass * (QuantityDimension.Time ^ -2);

        public static readonly Unit<MomentOfForce> NewtonMeter = new Unit<MomentOfForce>("Nm");
        public static readonly Unit<MomentOfForce> KiloNewtonMeter = new Unit<MomentOfForce>(UnitPrefix.Kilo);
        public static readonly Unit<MomentOfForce> MegaNewtonMeter = new Unit<MomentOfForce>(UnitPrefix.Mega);
        public static readonly Unit<MomentOfForce> GigaNewtonMeter = new Unit<MomentOfForce>(UnitPrefix.Giga);
        public static readonly Unit<MomentOfForce> MilliNewtonMeter = new Unit<MomentOfForce>(UnitPrefix.Milli);
        public static readonly Unit<MomentOfForce> MicroNewtonMeter = new Unit<MomentOfForce>(UnitPrefix.Micro);
        public static readonly Unit<MomentOfForce> NanoNewtonMeter = new Unit<MomentOfForce>(UnitPrefix.Nano);

        #endregion

        #region Implementation of IQuantity<MomentOfForce>

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
        public IUnit<MomentOfForce> StandardUnit
        {
            get { return NewtonMeter; }
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
