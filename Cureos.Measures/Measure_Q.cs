// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
	public struct Measure<Q> : IMeasure where Q : IQuantity
	{
		#region MEMBER VARIABLES

		private readonly AmountType mAmount;

		#endregion

		#region CONSTRUCTORS


		public Measure(double iAmount)
		{
			mAmount =
#if !DOUBLE
				(AmountType)
#endif
				iAmount;
		}

		public Measure(float iAmount)
		{
			mAmount =
#if !SINGLE
				(AmountType)
#endif
				iAmount;
		}

		public Measure(decimal iAmount)
		{
			mAmount =
#if !DECIMAL
				(AmountType)
#endif
				iAmount;
		}

		#endregion

		#region PROPERTIES

		public AmountType Amount
		{
			get { return mAmount; }
		}

		public Unit Unit
		{
			get { return Quantity.GetReferenceUnit(); }
		}

		public Quantity Quantity
		{
			get { return default(Q).Quantity; }
		}

		#endregion

		#region METHODS

		public AmountType GetAmount(Unit iUnit)
		{
			if (iUnit.GetQuantity() == Quantity)
			{
				return iUnit.ConvertAmountTo(mAmount, iUnit);
			}
			throw new InvalidOperationException("Not possible to convert amount to unit of different quantity");
		}

		public IMeasure ConvertTo(Unit iUnit)
		{
			return new Measure(GetAmount(iUnit), iUnit);
		}

		public override string ToString()
		{
			return String.Format("{0} {1}", mAmount, Unit.GetSymbol());
		}

		#endregion

		#region OPERATORS

		public static explicit operator Measure(Measure<Q> iMeasure)
		{
			return new Measure(iMeasure.mAmount, iMeasure.Unit);
		}

		public static explicit operator Measure<Q>(Measure iMeasure)
		{
			if (iMeasure.Quantity.Equals(default(Q).Quantity)) 
			{
				return new Measure<Q>(iMeasure.GetReferenceUnitAmount());
			}
			throw new InvalidOperationException("Not possible to convert measure to different quantity");
		}

		public static Measure<Q> operator+(Measure<Q> iLhs, Measure<Q> iRhs)
		{
			return new Measure<Q>(iLhs.mAmount + iRhs.mAmount);
		}

		#endregion
	}
}
