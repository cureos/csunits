// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the time quantity
    /// </summary>
    public struct Time : IQuantity<Time>
    {
        #region FIELDS

        public static readonly Unit<Time> Second = new Unit<Time>("s");
        public static readonly Unit<Time> Minute = new Unit<Time>("min", Factors.SecondsPerMinute);
        public static readonly Unit<Time> Hour = new Unit<Time>("h", Factors.SecondsPerHour);
        public static readonly Unit<Time> Day = new Unit<Time>("dy", Factors.SecondsPerDay);
        public static readonly Unit<Time> Week = new Unit<Time>("wk", Factors.SecondsPerWeek);

        #endregion

        #region Implementation of IQuantity<Q>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return QuantityDimension.Time; }
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
        public IUnit<Time> StandardUnit
        {
            get { return Second; }
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
