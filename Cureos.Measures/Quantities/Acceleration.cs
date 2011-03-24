// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the acceleration quantity
    /// </summary>
    public struct Acceleration : IQuantity<Acceleration>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension = QuantityDimension.Length * (QuantityDimension.Time ^ -2);

        public static readonly Unit<Acceleration> MeterPerSecondSquared = new Unit<Acceleration>("m s\u207b²");
        public static readonly Unit<Acceleration> CentiMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Centi);
        public static readonly Unit<Acceleration> MilliMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Milli);

        #endregion
        
        #region Implementation of IQuantity<Acceleration>

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
        public IUnit<Acceleration> StandardUnit
        {
            get { return MeterPerSecondSquared; }
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