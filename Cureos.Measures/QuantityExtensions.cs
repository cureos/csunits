// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cureos.Measures
{
	public static class QuantityExtensions
	{
		#region STATIC MEMBERS

		private static Dictionary<Quantity, QuantityDetails> smDetailsMap;

		#endregion

		#region CONSTRUCTORS

		static QuantityExtensions()
		{
			smDetailsMap = new List<QuantityDetails>
							   {
								   new QuantityDetails(Quantity.Length, new QuantityDimensions(1, 0, 0, 0, 0, 0, 0)),
								   new QuantityDetails(Quantity.Area, new QuantityDimensions(2, 0, 0, 0, 0, 0, 0)),
								   new QuantityDetails(Quantity.Volume, new QuantityDimensions(3, 0, 0, 0, 0, 0, 0)),
								   new QuantityDetails(Quantity.Mass, new QuantityDimensions(0, 1, 0, 0, 0, 0, 0)),
								   new QuantityDetails(Quantity.Time, new QuantityDimensions(0, 0, 1, 0, 0, 0, 0)),
								   new QuantityDetails(Quantity.Temperature, new QuantityDimensions(0, 0, 0, 0, 1, 0, 0)),
								   new QuantityDetails(Quantity.AbsorbedDose, new QuantityDimensions(2, 0, -2, 0, 0, 0, 0))
							   }.ToDictionary(qd => qd.Quantity);
		}

		#endregion

		#region EXTENSION METHODS

		public static void SetReferenceUnit(this Quantity iQuantity, Unit iReferenceUnit)
		{
			smDetailsMap[iQuantity].ReferenceUnit = iReferenceUnit;
		}

		public static Unit GetReferenceUnit(this Quantity iQuantity)
		{
			return smDetailsMap[iQuantity].ReferenceUnit;
		}

		#endregion
		
		#region INNER SUPPORT CLASSES

		private sealed class QuantityDetails
		{
			#region MEMBER VARIABLES

			private Unit mReferenceUnit;

			#endregion
			
			#region CONSTRUCTORS

			internal QuantityDetails(Quantity iQuantity, QuantityDimensions iDimensions)
			{
				Quantity = iQuantity;
				Dimensions = iDimensions;
				mReferenceUnit = Unit.None;
			}

			#endregion

			#region AUTO-IMPLEMENTED PROPERTIES
			
			internal Quantity Quantity { get; private set; }
			
			internal QuantityDimensions Dimensions { get; private set; }

			#endregion

			#region PROPERTIES

			internal Unit ReferenceUnit
			{
				get
				{
					return mReferenceUnit;
				}
				set
				{
					if (mReferenceUnit != Unit.None) throw new InvalidOperationException("Attempt to set already defined ReferenceUnit");
					mReferenceUnit = value;
				}
			}

			#endregion
		}

		#endregion
	}
}