// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the luminous intensity quantity
    /// </summary>
    public struct LuminousIntensity : IQuantity<LuminousIntensity>
    {
        #region FIELDS

        public static readonly Unit<LuminousIntensity> Candela = new Unit<LuminousIntensity>("cd");
        public static readonly Unit<LuminousIntensity> KiloCandela = new Unit<LuminousIntensity>(UnitPrefix.Kilo);
        public static readonly Unit<LuminousIntensity> MegaCandela = new Unit<LuminousIntensity>(UnitPrefix.Mega);
        public static readonly Unit<LuminousIntensity> GigaCandela = new Unit<LuminousIntensity>(UnitPrefix.Giga);
        public static readonly Unit<LuminousIntensity> MilliCandela = new Unit<LuminousIntensity>(UnitPrefix.Milli);
        public static readonly Unit<LuminousIntensity> MicroCandela = new Unit<LuminousIntensity>(UnitPrefix.Micro);
        public static readonly Unit<LuminousIntensity> NanoCandela = new Unit<LuminousIntensity>(UnitPrefix.Nano);

        #endregion

        #region Implementation of IQuantity<LuminousIntensity>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return QuantityDimension.LuminousIntensity; }
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
        public IUnit<LuminousIntensity> StandardUnit
        {
            get { return Candela; }
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