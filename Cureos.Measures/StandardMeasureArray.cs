// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#if NET35
using Cureos.Measures.Extensions;
#endif

#if SINGLE
using AmountType = System.Single;
#elif DECIMAL
using AmountType = System.Decimal;
#elif DOUBLE
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
    /// <summary>
    /// Representation of an array of measures, given in the standard unit of the specified quantity
    /// </summary>
    /// <typeparam name="Q">Measured quantity type</typeparam>
    public class StandardMeasureArray<Q> : IMeasureArray<Q> where Q : struct, IQuantity<Q>
    {
        #region MEMBER VARIABLES

        private readonly StandardMeasure<Q>[] mMeasures;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes an array of amounts in the reference unit of the IQuantity type
        /// </summary>
        /// <param name="iAmounts">Array of amounts, given in the reference unit</param>
        public StandardMeasureArray(IEnumerable<double> iAmounts)
        {
            if (iAmounts == null) throw new ArgumentNullException("iAmounts");
            mMeasures = iAmounts.Select(a => new StandardMeasure<Q>(a)).ToArray();
        }

        /// <summary>
        /// Initializes an array of amounts in the reference unit of the IQuantity type
        /// </summary>
        /// <param name="iAmounts">Array of amounts, given in the reference unit</param>
        public StandardMeasureArray(IEnumerable<float> iAmounts)
        {
            if (iAmounts == null) throw new ArgumentNullException("iAmounts");
            mMeasures = iAmounts.Select(a => new StandardMeasure<Q>(a)).ToArray();
        }

        /// <summary>
        /// Initializes an array of amounts in the reference unit of the IQuantity type
        /// </summary>
        /// <param name="iAmounts">Array of amounts, given in the reference unit</param>
        public StandardMeasureArray(IEnumerable<decimal> iAmounts)
        {
            if (iAmounts == null) throw new ArgumentNullException("iAmounts");
            mMeasures = iAmounts.Select(a => new StandardMeasure<Q>(a)).ToArray();
        }

        /// <summary>
        /// Initializes an array of amounts in the reference unit of the IQuantity type
        /// </summary>
        /// <param name="iAmounts">Array of amounts, given in the <paramref name="iUnit">specified unit</paramref></param>
        /// <param name="iUnit">Unit in which the amount array is originally specified</param>
        public StandardMeasureArray(IEnumerable<double> iAmounts, IUnit<Q> iUnit)
        {
            if (iAmounts == null) throw new ArgumentNullException("iAmounts");
            if (iUnit == null) throw new ArgumentNullException("iUnit");
            mMeasures = iAmounts.Select(a => new StandardMeasure<Q>(a, iUnit)).ToArray();
        }

        /// <summary>
        /// Initializes an array of amounts in the reference unit of the IQuantity type
        /// </summary>
        /// <param name="iAmounts">Array of amounts, given in the <paramref name="iUnit">specified unit</paramref></param>
        /// <param name="iUnit">Unit in which the amount array is originally specified</param>
        public StandardMeasureArray(IEnumerable<float> iAmounts, IUnit<Q> iUnit)
        {
            if (iAmounts == null) throw new ArgumentNullException("iAmounts");
            if (iUnit == null) throw new ArgumentNullException("iUnit");
            mMeasures = iAmounts.Select(a => new StandardMeasure<Q>(a, iUnit)).ToArray();
        }

        /// <summary>
        /// Initializes an array of amounts in the reference unit of the IQuantity type
        /// </summary>
        /// <param name="iAmounts">Array of amounts, given in the <paramref name="iUnit">specified unit</paramref></param>
        /// <param name="iUnit">Unit in which the amount array is originally specified</param>
        public StandardMeasureArray(IEnumerable<decimal> iAmounts, IUnit<Q> iUnit)
        {
            if (iAmounts == null) throw new ArgumentNullException("iAmounts");
            if (iUnit == null) throw new ArgumentNullException("iUnit");
            mMeasures = iAmounts.Select(a => new StandardMeasure<Q>(a, iUnit)).ToArray();
        }

        /// <summary>
        /// Initializes an array of measures, where the amounts are all given in the standard unit of the quantity
        /// </summary>
        /// <param name="iMeasures">Collection of standard measures</param>
        public StandardMeasureArray(IEnumerable<StandardMeasure<Q>> iMeasures)
        {
            if (iMeasures == null) throw new ArgumentNullException("iMeasures");
            mMeasures = iMeasures.Select(m => m).ToArray();
        }

        /// <summary>
        /// Initializes an array of measures, where the amounts are all given in the standard unit of the quantity
        /// </summary>
        /// <param name="iMeasures">Collection of measures, potentially in different units of same quantity</param>
        public StandardMeasureArray(IEnumerable<IMeasure<Q>> iMeasures)
        {
            if (iMeasures == null) throw new ArgumentNullException("iMeasures");
            mMeasures = iMeasures.Select(m => new StandardMeasure<Q>(m)).ToArray();
        }

        #endregion
        
        #region Implementation of IMeasureArray<Q>

        /// <summary>
        /// Gets the array of measured amounts in the <see cref="Unit">current unit of measure</see>
        /// </summary>
        public IEnumerable<AmountType> Amounts
        {
            get { return mMeasures.Select(m => m.Amount); }
        }

        /// <summary>
        /// Gets the unit of measure
        /// </summary>
        public IUnit<Q> Unit
        {
            get { return default(Q).StandardUnit; }
        }

        /// <summary>
        /// Gets the collection of measured amounts in the <paramref name="iUnit">specified unit</paramref>
        /// </summary>
        /// <param name="iUnit">Unit in which the array of measured amounts should be returned</param>
        /// <returns>Collection of measured amounts, given in the <paramref name="iUnit">specified unit</paramref></returns>
        /// <exception cref="InvalidOperationException">if the specified unit is not of the same quantity as the measure</exception>
        public IEnumerable<AmountType> GetAmounts(IUnit<Q> iUnit)
        {
                return mMeasures.Select(m => m.GetAmount(iUnit));
        }

        /// <summary>
        /// Gets the <paramref name="i">ith</paramref> measure component of the measure array
        /// </summary>
        /// <param name="i">Zero-based index of the measure array</param>
        /// <returns>The <paramref name="i">ith</paramref> component of the measure array</returns>
        IMeasure<Q> IMeasureArray<Q>.this[int i]
        {
            get { return mMeasures[i]; }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the <paramref name="i">ith</paramref> measure component of the measure array
        /// </summary>
        /// <param name="i">Zero-based index of the measure array</param>
        /// <returns>The <paramref name="i">ith</paramref> component of the measure array</returns>
        public StandardMeasure<Q> this[uint i]
        {
            get { return mMeasures[i]; }
        }

        /// <summary>
        /// Gets the <paramref name="i">ith</paramref> measure component of the measure array
        /// </summary>
        /// <param name="i">Zero-based index of the measure array</param>
        /// <returns>The <paramref name="i">ith</paramref> component of the measure array</returns>
        public StandardMeasure<Q> this[int i]
        {
            get { return mMeasures[i]; }
        }

        #endregion

        #region Implementation of IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<IMeasure<Q>> GetEnumerator()
        {
            return mMeasures.Cast<IMeasure<Q>>().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}