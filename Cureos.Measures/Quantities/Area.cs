// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the area quantity
    /// </summary>
    public struct Area : IQuantity<Area>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension = QuantityDimension.Length ^ 2;

        public static readonly Unit<Area> SquareMeter = new Unit<Area>("m²");
        public static readonly Unit<Area> SquareKiloMeter = new Unit<Area>("km²", Factors.Square(Factors.Kilo));
        public static readonly Unit<Area> SquareDeciMeter = new Unit<Area>("dm²", Factors.Square(Factors.Deci));
        public static readonly Unit<Area> SquareCentiMeter = new Unit<Area>("cm²", Factors.Square(Factors.Centi));
        public static readonly Unit<Area> SquareMilliMeter = new Unit<Area>("mm²", Factors.Square(Factors.Milli));
        public static readonly Unit<Area> Barn = new Unit<Area>("b", Factors.SquareMetersPerBarn);

        #endregion

        #region Implementation of IQuantity<Q>

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
        public IUnit<Area> StandardUnit
        {
            get { return SquareMeter; }
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
