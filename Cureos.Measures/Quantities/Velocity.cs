// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the velocity quantity
    /// </summary>
    public struct Velocity : IQuantity<Velocity>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension = QuantityDimension.Length / QuantityDimension.Time;

        public static readonly Unit<Velocity> MeterPerSecond = new Unit<Velocity>("m/s");
        public static readonly Unit<Velocity> CentiMeterPerSecond = new Unit<Velocity>("cm/s", Factors.Centi);
        public static readonly Unit<Velocity> MilliMeterPerSecond = new Unit<Velocity>("mm/s", Factors.Milli);
        public static readonly Unit<Velocity> KiloMeterPerHour = new Unit<Velocity>("km/h", Factors.Kilo / Factors.SecondsPerHour);

        #endregion
        
        #region Implementation of IQuantity<Velocity>

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
        public IUnit<Velocity> StandardUnit
        {
            get { return MeterPerSecond; }
        }

        #endregion
    }
}