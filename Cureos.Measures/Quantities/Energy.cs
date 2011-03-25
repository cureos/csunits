// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html


namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Implementation of the energy quantity
    /// </summary>
    public struct Energy : IQuantity<Energy>
    {
        #region FIELDS

        private static readonly QuantityDimension _dimension =
            (QuantityDimension.Length ^ 2) * QuantityDimension.Mass * (QuantityDimension.Time ^ -2);

        public static readonly Unit<Energy> Joule = new Unit<Energy>("J");
        public static readonly Unit<Energy> KiloJoule = new Unit<Energy>(UnitPrefix.Kilo);
        public static readonly Unit<Energy> MegaJoule = new Unit<Energy>(UnitPrefix.Mega);
        public static readonly Unit<Energy> GigaJoule = new Unit<Energy>(UnitPrefix.Giga);
        public static readonly Unit<Energy> MilliJoule = new Unit<Energy>(UnitPrefix.Milli);
        public static readonly Unit<Energy> MicroJoule = new Unit<Energy>(UnitPrefix.Micro);
        public static readonly Unit<Energy> WattHour = new Unit<Energy>("Wh", Factors.SecondsPerHour);
        public static readonly Unit<Energy> KiloWattHour = new Unit<Energy>("kWh", Factors.Kilo * Factors.SecondsPerHour);
        public static readonly Unit<Energy> MegaWattHour = new Unit<Energy>("MWh", Factors.Mega * Factors.SecondsPerHour);
        public static readonly Unit<Energy> GigaWattHour = new Unit<Energy>("GWh", Factors.Giga * Factors.SecondsPerHour);
        public static readonly Unit<Energy> TeraWattHour = new Unit<Energy>("TWh", Factors.Tera * Factors.SecondsPerHour);
        public static readonly Unit<Energy> ElectronVolt = new Unit<Energy>("eV", Factors.JoulesPerElectronVolt);
        public static readonly Unit<Energy> KiloElectronVolt = new Unit<Energy>("keV", Factors.Kilo * Factors.JoulesPerElectronVolt);
        public static readonly Unit<Energy> MegaElectronVolt = new Unit<Energy>("MeV", Factors.Mega * Factors.JoulesPerElectronVolt);
        public static readonly Unit<Energy> GigaElectronVolt = new Unit<Energy>("GeV", Factors.Giga * Factors.JoulesPerElectronVolt);
        public static readonly Unit<Energy> TeraElectronVolt = new Unit<Energy>("TeV", Factors.Tera * Factors.JoulesPerElectronVolt);

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
        public IUnit<Energy> StandardUnit
        {
            get { return Joule; }
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