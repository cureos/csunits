// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the heat capacity quantity
    /// </summary>
    public struct HeatCapacity : IQuantity<HeatCapacity>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension =
            (QuantityDimension.Length ^ 2) * QuantityDimension.Mass * (QuantityDimension.Time ^ -2) *
            (QuantityDimension.Temperature ^ -1);

        public static readonly Unit<HeatCapacity> JoulePerKelvin = new Unit<HeatCapacity>("J K\u207b¹");
        public static readonly Unit<HeatCapacity> KiloJoulePerKelvin = new Unit<HeatCapacity>(UnitPrefix.Kilo);
        public static readonly Unit<HeatCapacity> MegaJoulePerKelvin = new Unit<HeatCapacity>(UnitPrefix.Mega);
        public static readonly Unit<HeatCapacity> GigaJoulePerKelvin = new Unit<HeatCapacity>(UnitPrefix.Giga);
        public static readonly Unit<HeatCapacity> MilliJoulePerKelvin = new Unit<HeatCapacity>(UnitPrefix.Milli);
        public static readonly Unit<HeatCapacity> MicroJoulePerKelvin = new Unit<HeatCapacity>(UnitPrefix.Micro);
        public static readonly Unit<HeatCapacity> NanoJoulePerKelvin = new Unit<HeatCapacity>(UnitPrefix.Nano);

        #endregion

        #region Implementation of IQuantity<HeatCapacity>

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
        public IUnit<HeatCapacity> StandardUnit
        {
            get { return JoulePerKelvin; }
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