// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the dose equivalent quantity
	/// </summary>
	public struct DoseEquivalent : IQuantity<DoseEquivalent>
	{
		#region FIELDS
		
		private static readonly QuantityDimension _dimension = new QuantityDimension(2, 0, -2, 0, 0, 0, 0);

		public static readonly Unit<DoseEquivalent> Sievert = new Unit<DoseEquivalent>("Sv");

		#endregion

		#region Implementation of IQuantity<DoseEquivalent>

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
		public IUnit<DoseEquivalent> StandardUnit
		{
			get { return Sievert; }
		}

		#endregion
	}
}
