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
    /// Implementation of the absorbed dose quantity
    /// </summary>
    public partial struct AbsorbedDose : IQuantity<AbsorbedDose>
    {
        #region FIELDS

        private static readonly QuantityDimension dimension = new QuantityDimension(2, 0, 2, 0, 0, 0, 0);

        public static readonly Unit<AbsorbedDose> Gray = new Unit<AbsorbedDose>("Gy");

        public static readonly Unit<AbsorbedDose> MicroGray = new Unit<AbsorbedDose>(UnitPrefix.Micro);
        public static readonly Unit<AbsorbedDose> MilliGray = new Unit<AbsorbedDose>(UnitPrefix.Milli);
        public static readonly Unit<AbsorbedDose> CentiGray = new Unit<AbsorbedDose>(UnitPrefix.Centi);
        public static readonly Unit<AbsorbedDose> DeciGray = new Unit<AbsorbedDose>(UnitPrefix.Deci);
        public static readonly Unit<AbsorbedDose> DekaGray = new Unit<AbsorbedDose>(UnitPrefix.Deka);
        public static readonly Unit<AbsorbedDose> HectoGray = new Unit<AbsorbedDose>(UnitPrefix.Hecto);
        public static readonly Unit<AbsorbedDose> KiloGray = new Unit<AbsorbedDose>(UnitPrefix.Kilo);

        public static readonly Unit<AbsorbedDose> Rad = new Unit<AbsorbedDose>("rad", Factors.Centi);

        #endregion

        #region Implementation of IQuantity<AbsorbedDose>

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
        public IUnit<AbsorbedDose> StandardUnit
        {
            get { return Gray; }
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
            return "Absorbed dose";
        }

        #endregion
    }
}
