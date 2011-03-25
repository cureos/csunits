// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the frequency quantity
    /// </summary>
    public struct Frequency : IQuantity<Frequency>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension = QuantityDimension.Time ^ -1;

        public static readonly Unit<Frequency> Hertz = new Unit<Frequency>("Hz");
        public static readonly Unit<Frequency> KiloHertz = new Unit<Frequency>(UnitPrefix.Kilo);
        public static readonly Unit<Frequency> MegaHertz = new Unit<Frequency>(UnitPrefix.Mega);
        public static readonly Unit<Frequency> GigaHertz = new Unit<Frequency>(UnitPrefix.Giga);
        public static readonly Unit<Frequency> MilliHertz = new Unit<Frequency>(UnitPrefix.Milli);
        public static readonly Unit<Frequency> MicroHertz = new Unit<Frequency>(UnitPrefix.Micro);
        public static readonly Unit<Frequency> NanoHertz = new Unit<Frequency>(UnitPrefix.Nano);

        #endregion
        
        #region Implementation of IQuantity<Frequency>

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
        public IUnit<Frequency> StandardUnit
        {
            get { return Hertz; }
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