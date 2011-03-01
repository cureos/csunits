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
	/// <summary>
	/// Support class providing extension methods for the <see cref="Quantity">Quantity enumeration</see>
	/// </summary>
	public static class QuantityExtensions
	{
		#region STATIC MEMBERS

		private static readonly Dictionary<Quantity, QuantityDetails> smDetailsMap;

		#endregion

		#region CONSTRUCTORS

		/// <summary>
		/// Initialize the quantity details map by specifiying the quantity dimensions in SI base units of each respective quantity
		/// </summary>
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

		/// <summary>
		/// Sets the reference unit of the specific quantity
		/// </summary>
		/// <param name="iQuantity">Quantity for which the reference unit should be defined</param>
		/// <param name="iReferenceUnit">Reference unit</param>
		/// <remarks>The reference unit can only be set once for each quantity; if an attempt is made to set the reference unit
		/// of one quantity multiple times, the underlying property setter will throw</remarks>
		public static void SetReferenceUnit(this Quantity iQuantity, Unit iReferenceUnit)
		{
			smDetailsMap[iQuantity].ReferenceUnit = iReferenceUnit;
		}

		/// <summary>
		/// Gets the reference unit of the specified quantity
		/// </summary>
		/// <param name="iQuantity">Quantity for which the reference unit is requested</param>
		/// <returns>Reference unit of the specified quantity</returns>
		/// <remarks>If the reference unit has not been defined for the specified quantity, the underlying property getter
		/// will throw</remarks>
		public static Unit GetReferenceUnit(this Quantity iQuantity)
		{
			return smDetailsMap[iQuantity].ReferenceUnit;
		}

		public static bool IsQuantityOfProduct(this Quantity iQuantity, Quantity iLhs, Quantity iRhs)
		{
			return smDetailsMap[iQuantity].Dimensions.Equals(smDetailsMap[iLhs].Dimensions +
															 smDetailsMap[iRhs].Dimensions);
		}

		public static bool IsQuantityOfQuotient(this Quantity iQuantity, Quantity iNumerator, Quantity iDenominator)
		{
			return smDetailsMap[iQuantity].Dimensions.Equals(smDetailsMap[iNumerator].Dimensions -
															 smDetailsMap[iDenominator].Dimensions);
		}

		#endregion

		#region METHODS

		/// <summary>
		/// Perform "multiplication" of two quantities, and identify the resulting product quantity
		/// </summary>
		/// <param name="iLhs">Left-hand side quantity</param>
		/// <param name="iRhs">Right-hand side quantity</param>
		/// <returns>The single listed quantity representing the product of the specified quantities</returns>
		/// <exception cref="InvalidOperationException">if no resulting quantity could be identified,
		/// or if there is more than one quantity matching the resulting quantity dimensions</exception>
		internal static Quantity Times(Quantity iLhs, Quantity iRhs)
		{
			QuantityDimensions productDimensions = smDetailsMap[iLhs].Dimensions +
													smDetailsMap[iRhs].Dimensions;
			return smDetailsMap.Single(kv => kv.Value.Dimensions.Equals(productDimensions)).Key;
		}

		/// <summary>
		/// Perform "division" of two quantities, and identify the resulting qoutient quantity
		/// </summary>
		/// <param name="iNumerator">Numerator quantity</param>
		/// <param name="iDenominator">Denominator quantity</param>
		/// <returns>The single listed quantity representing the quotient of the numerator and denominator quantities</returns>
		/// <exception cref="InvalidOperationException">if no resulting quantity could be identified,
		/// or if there is more than one quantity matching the resulting quantity dimensions</exception>
		internal static Quantity Divide(Quantity iNumerator, Quantity iDenominator)
		{
			QuantityDimensions quotientDimensions = smDetailsMap[iNumerator].Dimensions -
													smDetailsMap[iDenominator].Dimensions;
			return smDetailsMap.Single(kv => kv.Value.Dimensions.Equals(quotientDimensions)).Key;
		}

		#endregion
		
		#region INNER SUPPORT CLASSES

		/// <summary>
		/// Helper class representing the characteristics of a single quantity
		/// </summary>
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
					if (mReferenceUnit == Unit.None) throw new InvalidOperationException("ReferenceUnit is not defined for this quantity");
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