/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

/*
 * This file is auto-generated.
 */

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the acceleration quantity
    /// </summary>
    public partial struct Acceleration : IQuantity<Acceleration>
    {
        #region FIELDS

        private static readonly QuantityDimension dimension = new QuantityDimension(1, 0, -2, 0, 0, 0, 0);

        public static readonly Unit<Acceleration> MeterPerSecondSquared = new Unit<Acceleration>("m s\u207b²");

        public static readonly Unit<Acceleration> MilliMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Milli);
        public static readonly Unit<Acceleration> CentiMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Centi);
        public static readonly Unit<Acceleration> DeciMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Deci);
        public static readonly Unit<Acceleration> DekaMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Deka);
        public static readonly Unit<Acceleration> HectoMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Hecto);
        public static readonly Unit<Acceleration> KiloMeterPerSecondSquared = new Unit<Acceleration>(UnitPrefix.Kilo);


        #endregion

        #region Implementation of IQuantity<Acceleration>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return dimension; }
        }

        /// <summary>
        /// Gets the standard unit associated with the quantity
        /// </summary>
        IUnit IQuantity.StandardUnit
        {
            get { return this.StandardUnit; }
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
            return "Acceleration";
        }

        #endregion
    }
}
