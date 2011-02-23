// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
    public struct Measure : IMeasure
    {
        #region MEMBER VARIABLES

        private readonly AmountType mAmount;
        private readonly Unit mUnit;

        #endregion

        #region CONSTRUCTORS

        public Measure(double iAmount, Unit iUnit)
        {
            mAmount =
#if DECIMAL
                (AmountType)
#endif
                iAmount;
            mUnit = iUnit;
        }

        public Measure(float iAmount, Unit iUnit)
        {
            mAmount =
#if DECIMAL
                (AmountType)
#endif
                iAmount;
            mUnit = iUnit;
        }

        public Measure(decimal iAmount, Unit iUnit)
        {
            mAmount =
#if !DECIMAL
                (AmountType)
#endif
                iAmount;
            mUnit = iUnit;
        }

        #endregion

        #region PROPERTIES

        public AmountType Amount
        {
            get { return mAmount; }
        }

        public Unit Unit
        {
            get { return mUnit; }
        }

        public Quantity Quantity
        {
            get { return mUnit.GetQuantity(); }
        }
		
        #endregion

        #region METHODS
		
		public AmountType GetAmount(Unit iUnit)
		{
			if (iUnit.GetQuantity() == Quantity)
			{
				return iUnit.ConvertAmountTo(mUnit.GetReferenceUnitAmount(mAmount), iUnit);
			}
			throw new InvalidOperationException("Not possible to convert amount to unit of different quantity");
		}
		
		public IMeasure ConvertTo(Unit iUnit)
		{
			return new Measure(GetAmount(iUnit), iUnit);
		}

        public override string ToString()
        {
            return String.Format("{0} {1}", mAmount, mUnit.GetSymbol());
        }

        #endregion
        
        #region OPERATORS

        public static Measure operator +(Measure iLhs, Measure iRhs)
        {
            if (iLhs.mUnit == iRhs.mUnit)
            {
                return new Measure(iLhs.mAmount + iRhs.mAmount, iLhs.mUnit);
            }
            if (iLhs.Quantity == iRhs.Quantity)
            {
                return new Measure(iLhs.mAmount + iRhs.mUnit.ConvertAmountTo(iRhs.mAmount, iLhs.mUnit), iLhs.Unit);
            }
            throw new InvalidOperationException("Not possible to add measures of different quantities");
        }

        #endregion
    }
}