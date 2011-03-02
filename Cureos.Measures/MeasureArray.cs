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
            mAmounts =
#if DOUBLE
                mAmounts = iAmounts.ToArray();
#else
                mAmounts = iAmounts.Select(a => Convert.ToDouble())
#endif
        }

        #endregion
        
        #region Implementation of IMeasureArray

        /// <summary>
        /// Gets the array of measured amounts in the <see cref="IMeasureArray.MeasuredUnit">current unit of measure</see>
        /// </summary>
        public AmountType[] MeasuredAmounts
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the array of measured amounts in the <see cref="IMeasureArray.ReferenceUnit">reference unit of measure</see>
        /// </summary>
        public AmountType[] ReferenceUnitAmounts
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the measured quantity
        /// </summary>
        public Quantity MeasuredQuantity
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the unit of measure
        /// </summary>
        public Unit MeasuredUnit
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the reference unit of measure for the <see cref="IMeasureArray.MeasuredQuantity">measured quantity</see>
        /// </summary>
        public Unit ReferenceUnit
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets the array of measured amounts in the <paramref name="iUnit">requested unit</paramref> of the same quantity
        /// </summary>
        /// <param name="iUnit">Unit in which the measured amounts should be specified</param>
        /// <returns>The array of measured amounts in the <paramref name="iUnit">requested unit</paramref></returns>
        public AmountType[] GetAmounts(Unit iUnit)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a string description of the measure array in the given <paramref name="iUnit">physical unit</paramref>
        /// </summary>
        /// <param name="iUnit">Unit in which the measure array should be presented</param>
        /// <returns>String representation of the measure array in the given <paramref name="iUnit">physical unit</paramref></returns>
        public string ToString(Unit iUnit)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}