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
    public class StandardMeasureArray<Q> : IEnumerable<StandardMeasure<Q>>, IMeasureArray<Q> where Q : struct, IQuantity<Q>
    {
        #region MEMBER VARIABLES

        private readonly IEnumerable<AmountType> mAmounts;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes an array of amounts in the reference unit of the IQuantity type
        /// </summary>
        /// <param name="iAmounts">Array of amounts, given in the reference unit</param>
        public StandardMeasureArray(IEnumerable<double> iAmounts)
        {
            if (iAmounts == null) throw new ArgumentNullException("iAmounts");
#if DOUBLE
            mAmounts = iAmounts.Select(a => a);
#else
            mAmounts = iAmounts.Select(a => (AmountType)a);
#endif
        }

        /// <summary>
        /// Initializes an array of amounts in the reference unit of the IQuantity type
        /// </summary>
        /// <param name="iAmounts">Array of amounts, given in the reference unit</param>
        public StandardMeasureArray(IEnumerable<float> iAmounts)
        {
            if (iAmounts == null) throw new ArgumentNullException("iAmounts");
#if SINGLE
            mAmounts = iAmounts.Select(a => a);
#else
            mAmounts = iAmounts.Select(a => (AmountType)a);
#endif
        }

        /// <summary>
        /// Initializes an array of amounts in the reference unit of the IQuantity type
        /// </summary>
        /// <param name="iAmounts">Array of amounts, given in the reference unit</param>
        public StandardMeasureArray(IEnumerable<decimal> iAmounts)
        {
            if (iAmounts == null) throw new ArgumentNullException("iAmounts");
#if DECIMAL
            mAmounts = iAmounts.Select(a => a);
#else
            mAmounts = iAmounts.Select(a => (AmountType)a);
#endif
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
#if DOUBLE
            mAmounts = iAmounts.Select(iUnit.AmountToStandardUnitConverter);
#else
            mAmounts = iAmounts.Select(a => iUnit.AmountToReferenceUnitConverter((AmountType)a));
#endif
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
#if SINGLE
            mAmounts = iAmounts.Select(iUnit.AmountToReferenceUnitConverter);
#elif DOUBLE
            mAmounts = iAmounts.Select(a => iUnit.AmountToStandardUnitConverter(a));
#elif DECIMAL
            mAmounts = iAmounts.Select(a => iUnit.AmountToReferenceUnitConverter((AmountType)a));
#endif
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
#if DECIMAL
            mAmounts = iAmounts.Select(iUnit.AmountToReferenceUnitConverter);
#else
            mAmounts = iAmounts.Select(a => iUnit.AmountToStandardUnitConverter((AmountType)a));
#endif
        }

        /// <summary>
        /// Initializes an array of measures, where the amounts are all given in the standard unit of the quantity
        /// </summary>
        /// <param name="iMeasures">Collection of measures, potentially in different units of same quantity</param>
        public StandardMeasureArray(IEnumerable<IMeasure<Q>> iMeasures)
        {
            if (iMeasures == null) throw new ArgumentNullException("iMeasures");
            IUnit<Q> unit = default(Q).StandardUnit;
            mAmounts = iMeasures.Select(m => m.GetAmount(unit));
        }

        #endregion
        
        #region Implementation of IMeasureArray<Q>

        /// <summary>
        /// Gets the array of measured amounts in the <see cref="Unit">current unit of measure</see>
        /// </summary>
        public IEnumerable<AmountType> Amounts
        {
            get { return mAmounts; }
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
                return mAmounts.Select(iUnit.AmountFromStandardUnitConverter);
        }

        /// <summary>
        /// Gets the <paramref name="i">ith</paramref> measure component of the measure array
        /// </summary>
        /// <param name="i">Zero-based index of the measure array</param>
        /// <returns>The <paramref name="i">ith</paramref> component of the measure array</returns>
        IMeasure<Q> IMeasureArray<Q>.this[int i]
        {
            get { return this[i]; }
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
            get { return this[(int) i]; }
        }

        /// <summary>
        /// Gets the <paramref name="i">ith</paramref> measure component of the measure array
        /// </summary>
        /// <param name="i">Zero-based index of the measure array</param>
        /// <returns>The <paramref name="i">ith</paramref> component of the measure array</returns>
        public StandardMeasure<Q> this[int i]
        {
            get
            {
                try
                {
                    return this.ElementAt<StandardMeasure<Q>>(i);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    throw new IndexOutOfRangeException("Index out of range", e);
                }
            }
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
        public IEnumerator<StandardMeasure<Q>> GetEnumerator()
        {
            foreach (var amount in mAmounts)
            {
                yield return new StandardMeasure<Q>(amount);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        IEnumerator<IMeasure<Q>> IEnumerable<IMeasure<Q>>.GetEnumerator()
        {
            foreach (var amount in mAmounts)
            {
                yield return new StandardMeasure<Q>(amount);
            }
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

    /// <summary>
    /// Representation of an array of a pair of measures, given in the standard unit of the respective quantity type
    /// </summary>
    /// <typeparam name="Q1">Quantity type of the first measure</typeparam>
    /// <typeparam name="Q2">Quantity type of the second measure</typeparam>
    public class StandardMeasureArray<Q1, Q2> : IMeasureArray<Q1, Q2>, IEnumerable<StandardMeasure<Q1, Q2>>
        where Q1 : struct, IQuantity<Q1>
        where Q2 : struct, IQuantity<Q2>
    {
        #region MEMBER VARIABLES

        private readonly IEnumerable<KeyValuePair<AmountType, AmountType>> mAmountPairs;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iAmountPairs">Collection of pairs of amounts</param>
        public StandardMeasureArray(IEnumerable<KeyValuePair<AmountType, AmountType>> iAmountPairs)
        {
            if (iAmountPairs == null) throw new ArgumentNullException("iAmountPairs");
            mAmountPairs = iAmountPairs.Where(kv => true);
        }

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iAmounts1">Collection of amounts in the standard unit of first measure type</param>
        /// <param name="iAmounts2">Collection of amounts in the standard unit of second measure type</param>
        /// <exception cref="ArgumentException">is thrown if the collections are of different length</exception>
        public StandardMeasureArray(IEnumerable<AmountType> iAmounts1, IEnumerable<AmountType> iAmounts2)
        {
            if (iAmounts1 == null) throw new ArgumentNullException("iAmounts1");
            if (iAmounts2 == null) throw new ArgumentNullException("iAmounts2");
            if (iAmounts1.Count() != iAmounts2.Count())
                throw new ArgumentException("Collection length is not the same as the first collection", "iAmounts2");
            mAmountPairs = iAmounts1.Zip(iAmounts2, (a1, a2) => new KeyValuePair<AmountType, AmountType>(a1, a2));
        }

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iMeasurePairs">Collection of standard unit measure pairs</param>
        public StandardMeasureArray(IEnumerable<StandardMeasure<Q1, Q2>> iMeasurePairs)
        {
            if (iMeasurePairs == null) throw new ArgumentNullException("iMeasurePairs");
            mAmountPairs =
                iMeasurePairs.Select(
                    pair => new KeyValuePair<AmountType, AmountType>(pair.Measure1.Amount, pair.Measure2.Amount));
        }

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iMeasures1">Collection of standard unit measures of the first quantity type</param>
        /// <param name="iMeasures2">Collection of standard unit measures of the second quantity type</param>
        public StandardMeasureArray(IEnumerable<StandardMeasure<Q1>> iMeasures1, IEnumerable<StandardMeasure<Q2>> iMeasures2)
        {
            if (iMeasures1 == null) throw new ArgumentNullException("iMeasures1");
            if (iMeasures2 == null) throw new ArgumentNullException("iMeasures2");
            if (iMeasures1.Count() != iMeasures2.Count())
                throw new ArgumentException("Collection length is not the same as the first collection", "iMeasures2");
            mAmountPairs = iMeasures1.Zip(iMeasures2, (m1, m2) => new KeyValuePair<AmountType, AmountType>(m1.Amount, m2.Amount));
        }

        #endregion
        
        #region Implementation of IMeasureArray<Q1,Q2>

        /// <summary>
        /// Gets the array of first measures
        /// </summary>
        public IMeasureArray<Q1> Measures1
        {
            get { return new StandardMeasureArray<Q1>(mAmountPairs.Select(kv => kv.Key)); }
        }

        /// <summary>
        /// Gets the array of second measures
        /// </summary>
        public IMeasureArray<Q2> Measures2
        {
            get { return new StandardMeasureArray<Q2>(mAmountPairs.Select(kv => kv.Value)); }
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
        public IEnumerator<StandardMeasure<Q1, Q2>> GetEnumerator()
        {
            foreach (var amountPair in mAmountPairs)
            {
                yield return new StandardMeasure<Q1, Q2>(amountPair.Key, amountPair.Value);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        IEnumerator<IMeasure<Q1, Q2>> IEnumerable<IMeasure<Q1, Q2>>.GetEnumerator()
        {
            foreach (var amountPair in mAmountPairs)
            {
                yield return new StandardMeasure<Q1, Q2>(amountPair.Key, amountPair.Value);
            }
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