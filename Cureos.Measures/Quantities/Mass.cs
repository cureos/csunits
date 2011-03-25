// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html


namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the mass quantity
    /// </summary>
    public struct Mass : IQuantity<Mass>
    {
        #region FIELDS

        public static readonly Unit<Mass> KiloGram = new Unit<Mass>("kg");
        public static readonly Unit<Mass> MetricTon = new Unit<Mass>("t", Factors.Kilo);
        public static readonly Unit<Mass> HectoGram = new Unit<Mass>("hg", Factors.Deci);
        public static readonly Unit<Mass> Gram = new Unit<Mass>("g", Factors.Milli);
        public static readonly Unit<Mass> MilliGram = new Unit<Mass>("mg", Factors.Micro);
        public static readonly Unit<Mass> MicroGram = new Unit<Mass>("µg", Factors.Nano);
        public static readonly Unit<Mass> NanoGram = new Unit<Mass>("µg", Factors.Pico);
        public static readonly Unit<Mass> PicoGram = new Unit<Mass>("µg", Factors.Femto);
        public static readonly Unit<Mass> ElectronMass = new Unit<Mass>("m\u2091", Factors.KiloGramsPerElectronMass);
        public static readonly Unit<Mass> AtomicMassUnit = new Unit<Mass>("u", Factors.KiloGramsPerAtomicMassUnit);
        public static readonly Unit<Mass> Dalton = new Unit<Mass>("Da", Factors.KiloGramsPerAtomicMassUnit);
        public static readonly Unit<Mass> KiloDalton = new Unit<Mass>("kDa", Factors.Kilo * Factors.KiloGramsPerAtomicMassUnit);
        public static readonly Unit<Mass> MegaDalton = new Unit<Mass>("MDa", Factors.Mega * Factors.KiloGramsPerAtomicMassUnit);
        public static readonly Unit<Mass> MilliDalton = new Unit<Mass>("mDa", Factors.Milli * Factors.KiloGramsPerAtomicMassUnit);
        public static readonly Unit<Mass> MicroDalton = new Unit<Mass>("µDa", Factors.Micro * Factors.KiloGramsPerAtomicMassUnit);
        public static readonly Unit<Mass> NanoDalton = new Unit<Mass>("nDa", Factors.Nano * Factors.KiloGramsPerAtomicMassUnit);
        public static readonly Unit<Mass> PicoDalton = new Unit<Mass>("pDa", Factors.Pico * Factors.KiloGramsPerAtomicMassUnit);

        #endregion

        #region Implementation of IQuantity<Q>

        /// <summary>
        /// Gets the physical dimension of the quantity in terms of SI units
        /// </summary>
        public QuantityDimension Dimension
        {
            get { return QuantityDimension.Mass; }
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
        public IUnit<Mass> StandardUnit
        {
            get { return KiloGram; }
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
