// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the capacitance quantity
	/// </summary>
	public struct Capacitance : IQuantity<Capacitance>
	{
		#region FIELDS

	    private static readonly QuantityDimension _dimension = (QuantityDimension.Length ^ -2) *
	                                                           (QuantityDimension.Mass ^ -1) *
	                                                           (QuantityDimension.Time ^ 4) *
	                                                           (QuantityDimension.ElectricCurrent ^ 2);

		public static readonly Unit<Capacitance> Farad = new Unit<Capacitance>("F");

		#endregion

		#region Implementation of IQuantity<Capacitance>

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
		public IUnit<Capacitance> StandardUnit
		{
			get { return Farad; }
		}

		#endregion
	}
}
