// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the refractive index dimensionless quantity
	/// </summary>
	public struct RefractiveIndex : IQuantity<RefractiveIndex>
	{
		#region FIELDS
		
		private static readonly QuantityDimension _dimension = new QuantityDimension(DimensionlessDifferentiators.RefractiveIndex);

		public static readonly Unit<RefractiveIndex> Unity = new Unit<RefractiveIndex>("");

		#endregion

		#region Implementation of IQuantity<RefractiveIndex>

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
		public IUnit<RefractiveIndex> StandardUnit
		{
			get { return Unity; }
		}

		#endregion
	}
}
