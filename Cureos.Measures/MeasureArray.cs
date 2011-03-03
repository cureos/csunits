// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
    public class MeasureArray<Q> : IMeasureArray where Q : struct, IQuantity
    {
        #region MEMBER VARIABLES

        private readonly AmountType[] mAmounts;

        #endregion

        #region CONSTRUCTORS

        public MeasureArray(IEnumerable<double> iAmounts)
        {
#if DOUBLE
            mAmounts = iAmounts.ToArray();
#elif SINGLE
            mAmounts = iAmounts.Cast<float>().ToArray();
#elif DECIMAL
            mAmounts = iAmounts.Cast<decimal>().ToArray();
#endif
        }

        public MeasureArray(IEnumerable<float> iAmounts)
        {
#if DOUBLE
            mAmounts = iAmounts.Cast<double>().ToArray();
#elif SINGLE
            mAmounts = iAmounts.ToArray();
#elif DECIMAL
            mAmounts = iAmounts.Cast<decimal>().ToArray();
#endif
        }


        public MeasureArray(IEnumerable<decimal> iAmounts)
        {
#if DOUBLE
            mAmounts = iAmounts.Cast<double>().ToArray();
#elif SINGLE
            mAmounts = iAmounts.Cast<float>().ToArray();
#elif DECIMAL
            mAmounts = iAmounts.ToArray();
#endif
        }

        public MeasureArray(IEnumerable<double> iAmounts, Unit iUnit)
        {
#if DOUBLE
            mAmounts = iAmounts.ToArray();
#elif SINGLE
            mAmounts = iAmounts.Cast<float>().ToArray();
#elif DECIMAL
            mAmounts = iAmounts.Cast<decimal>().ToArray();
#endif
        }

        public MeasureArray(IEnumerable<float> iAmounts, Unit iUnit)
        {
#if DOUBLE
            mAmounts = iAmounts.Cast<double>().ToArray();
#elif SINGLE
            mAmounts = iAmounts.ToArray();
#elif DECIMAL
            mAmounts = iAmounts.Cast<decimal>().ToArray();
#endif
        }


        public MeasureArray(IEnumerable<decimal> iAmounts, Unit iUnit)
        {
#if DOUBLE
            mAmounts = iAmounts.Cast<double>().ToArray();
#elif SINGLE
            mAmounts = iAmounts.Cast<float>().ToArray();
#elif DECIMAL
            mAmounts = iAmounts.ToArray();
#endif
        }

        #endregion
        
        #region Implementation of IMeasureArray

        /// <summary>
        /// Gets the array of measured amounts in the <see cref="IMeasureArray.Unit">current unit of measure</see>
        /// </summary>
        public AmountType[] Amounts
        {
            get { return mAmounts; }
        }

        /// <summary>
        /// Gets the unit of measure
        /// </summary>
        public Unit Unit
        {
            get { return default(Q).EnumeratedValue.GetReferenceUnit(); }
        }

        #endregion
    }
}