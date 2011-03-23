// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the electric potential difference quantity
	/// </summary>
	public struct ElectricPotential : IQuantity<ElectricPotential>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = (QuantityDimension.Length ^ 2) *
	                                                           QuantityDimension.Mass * (QuantityDimension.Time ^ -3) *
	                                                           (QuantityDimension.ElectricCurrent ^ -1);

		public static readonly Unit<ElectricPotential> Volt = new Unit<ElectricPotential>("V");

		#endregion

		#region Implementation of IQuantity<ElectricPotential>

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
		public IUnit<ElectricPotential> StandardUnit
		{
			get { return Volt; }
		}

		#endregion
	}
}
