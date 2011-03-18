// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the wave number quantity
	/// </summary>
	public struct WaveNumber : IQuantity<WaveNumber>
	{
		#region FIELDS
		
		private static readonly QuantityDimension _dimension = new QuantityDimension(-1, 0, 0, 0, 0, 0, 0);

		public static readonly Unit<WaveNumber> ReciprocalMeter = new Unit<WaveNumber>("1/m");
		public static readonly Unit<WaveNumber> ReciprocalCentiMeter = new Unit<WaveNumber>("1/cm", Factors.Hecto);

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
		public IUnit<WaveNumber> StandardUnit
		{
			get { return ReciprocalMeter; }
		}

		#endregion
	}
}
