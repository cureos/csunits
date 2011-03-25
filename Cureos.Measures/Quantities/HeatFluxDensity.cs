// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the heat flux density quantity
	/// </summary>
	public struct HeatFluxDensity : IQuantity<HeatFluxDensity>
	{
		#region FIELDS
		
		private static readonly QuantityDimension _dimension = 
			QuantityDimension.Mass * (QuantityDimension.Time ^ -3);

		public static readonly Unit<HeatFluxDensity> WattPerSquareMeter = new Unit<HeatFluxDensity>("W m\u207b²");
		public static readonly Unit<HeatFluxDensity> KiloWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Kilo);
		public static readonly Unit<HeatFluxDensity> MegaWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Mega);
		public static readonly Unit<HeatFluxDensity> GigaWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Giga);
		public static readonly Unit<HeatFluxDensity> MilliWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Milli);
		public static readonly Unit<HeatFluxDensity> MicroWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Micro);
		public static readonly Unit<HeatFluxDensity> NanoWattPerSquareMeter = new Unit<HeatFluxDensity>(UnitPrefix.Nano);

		#endregion

		#region Implementation of IQuantity<HeatFluxDensity>

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
		public IUnit<HeatFluxDensity> StandardUnit
		{
			get { return WattPerSquareMeter; }
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