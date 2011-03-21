// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the catalytic activity quantity
	/// </summary>
	public struct CatalyticActivity : IQuantity<CatalyticActivity>
	{
		#region FIELDS
		
		private static readonly QuantityDimension _dimension = new QuantityDimension(0, 0, -1, 0, 0, 0, 1);

		public static readonly Unit<CatalyticActivity> Katal = new Unit<CatalyticActivity>("kat");

		#endregion

		#region Implementation of IQuantity<CatalyticActivity>

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
		public IUnit<CatalyticActivity> StandardUnit
		{
			get { return Katal; }
		}

		#endregion
	}
}
