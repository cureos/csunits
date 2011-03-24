// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the electric current quantity
    /// </summary>
    public struct ElectricCurrent : IQuantity<ElectricCurrent>
    {
        #region FIELDS

        public static readonly Unit<ElectricCurrent> Ampere = new Unit<ElectricCurrent>("A");
        public static readonly Unit<ElectricCurrent> MilliAmpere = new Unit<ElectricCurrent>(UnitPrefix.Milli);
        public static readonly Unit<ElectricCurrent> MicroAmpere = new Unit<ElectricCurrent>(UnitPrefix.Micro);

        #endregion

        #region Implementation of IQuantity<ElectricCurrent>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return QuantityDimension.ElectricCurrent; }
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
        public IUnit<ElectricCurrent> StandardUnit
        {
            get { return Ampere; }
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