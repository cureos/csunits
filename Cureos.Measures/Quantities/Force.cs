// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

namespace Cureos.Measures.Quantities
{
	/// <summary>
	/// Implementation of the force quantity
	/// </summary>
	public struct Force : IQuantity<Force>
	{
		#region FIELDS
		
		private static readonly QuantityDimension _dimension = 
			QuantityDimension.Length * QuantityDimension.Mass * (QuantityDimension.Time ^ -2);

		public static readonly Unit<Force> Newton = new Unit<Force>("N");
		public static readonly Unit<Force> KiloNewton = new Unit<Force>(UnitPrefix.Kilo);

		#endregion

		#region Implementation of IQuantity<Force>

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
		public IUnit<Force> StandardUnit
		{
			get { return Newton; }
		}

		#endregion
	}
}
