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

namespace Cureos.Measures
{
    /// <summary>
    /// Representation of an array of a pair of measures, given in the standard unit of the respective quantity type
    /// </summary>
    /// <typeparam name="Q1">Quantity type of the first measure</typeparam>
    /// <typeparam name="Q2">Quantity type of the second measure</typeparam>
    public class StandardMeasureDoubletArray<Q1, Q2> : IMeasureDoubletArray<Q1, Q2>
        where Q1 : struct, IQuantity<Q1>
        where Q2 : struct, IQuantity<Q2>
    {
        #region MEMBER VARIABLES

        private readonly StandardMeasureDoublet<Q1, Q2>[] mMeasureDoublets;

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iAmountDoublets">Collection of pairs of amounts</param>
        public StandardMeasureDoubletArray(IEnumerable<KeyValuePair<double, double>> iAmountDoublets)
        {
            if (iAmountDoublets == null) throw new ArgumentNullException("iAmountDoublets");
            mMeasureDoublets = iAmountDoublets.Select(kv => new StandardMeasureDoublet<Q1, Q2>(kv.Key, kv.Value)).ToArray();
        }

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iMeasureDoublets">Collection of pairs of measures</param>
        public StandardMeasureDoubletArray(IEnumerable<KeyValuePair<IMeasure<Q1>, IMeasure<Q2>>> iMeasureDoublets)
        {
            if (iMeasureDoublets == null) throw new ArgumentNullException("iMeasureDoublets");
            mMeasureDoublets = iMeasureDoublets.Select(kv => new StandardMeasureDoublet<Q1, Q2>(kv.Key, kv.Value)).ToArray();
        }

#if !NET35
        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iAmountDoublets">Collection of pairs of amounts</param>
        public StandardMeasureDoubletArray(IEnumerable<Tuple<double, double>> iAmountDoublets)
        {
            if (iAmountDoublets == null) throw new ArgumentNullException("iAmountDoublets");
            mMeasureDoublets = iAmountDoublets.Select(pair => new StandardMeasureDoublet<Q1, Q2>(pair.Item1, pair.Item2)).ToArray();
        }

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iMeasureDoublets">Collection of pairs of measures</param>
        public StandardMeasureDoubletArray(IEnumerable<Tuple<IMeasure<Q1>, IMeasure<Q2>>> iMeasureDoublets)
        {
            if (iMeasureDoublets == null) throw new ArgumentNullException("iMeasureDoublets");
            mMeasureDoublets = iMeasureDoublets.Select(pair => new StandardMeasureDoublet<Q1, Q2>(pair.Item1, pair.Item2)).ToArray();
        }
#endif

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iAmounts1">Collection of amounts in the standard unit of first measure type</param>
        /// <param name="iAmounts2">Collection of amounts in the standard unit of second measure type</param>
        /// <exception cref="ArgumentException">is thrown if the collections are of different length</exception>
        public StandardMeasureDoubletArray(IEnumerable<double> iAmounts1, IEnumerable<double> iAmounts2)
        {
            if (iAmounts1 == null) throw new ArgumentNullException("iAmounts1");
            if (iAmounts2 == null) throw new ArgumentNullException("iAmounts2");
            if (iAmounts1.Count() != iAmounts2.Count())
                throw new ArgumentException("Collection length is not the same as the first collection", "iAmounts2");
            mMeasureDoublets = iAmounts1.Zip(iAmounts2, (a1, a2) => new StandardMeasureDoublet<Q1, Q2>(a1, a2)).ToArray();
        }

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iMeasureDoublets">Collection of standard unit measure pairs</param>
        public StandardMeasureDoubletArray(IEnumerable<StandardMeasureDoublet<Q1, Q2>> iMeasureDoublets)
        {
            if (iMeasureDoublets == null) throw new ArgumentNullException("iMeasureDoublets");
            mMeasureDoublets = iMeasureDoublets.Select(pair => pair).ToArray();
        }

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iMeasureDoublets">Collection of measure pairs of arbitrary unit</param>
        public StandardMeasureDoubletArray(IEnumerable<IMeasureDoublet<Q1, Q2>> iMeasureDoublets)
        {
            if (iMeasureDoublets == null) throw new ArgumentNullException("iMeasureDoublets");
            mMeasureDoublets = iMeasureDoublets.Select(pair => new StandardMeasureDoublet<Q1, Q2>(pair)).ToArray();
        }

        /// <summary>
        /// Initializes an instance of an array of standard unit measure pairs
        /// </summary>
        /// <param name="iMeasures1">Collection of standard unit measures of the first quantity type</param>
        /// <param name="iMeasures2">Collection of standard unit measures of the second quantity type</param>
        public StandardMeasureDoubletArray(IEnumerable<StandardMeasure<Q1>> iMeasures1, IEnumerable<StandardMeasure<Q2>> iMeasures2)
        {
            if (iMeasures1 == null) throw new ArgumentNullException("iMeasures1");
            if (iMeasures2 == null) throw new ArgumentNullException("iMeasures2");
            if (iMeasures1.Count() != iMeasures2.Count())
                throw new ArgumentException("Collection length is not the same as the first collection", "iMeasures2");
            mMeasureDoublets = iMeasures1.Zip(iMeasures2, (m1, m2) => new StandardMeasureDoublet<Q1, Q2>(m1, m2)).ToArray();
        }

        #endregion
        
        #region Implementation of IMeasureArray<Q1,Q2>

        /// <summary>
        /// Gets the array of first measures
        /// </summary>
        public IMeasureArray<Q1> First
        {
            get { return new StandardMeasureArray<Q1>(mMeasureDoublets.Select(pair => pair.First)); }
        }

        /// <summary>
        /// Gets the array of second measures
        /// </summary>
        public IMeasureArray<Q2> Second
        {
            get { return new StandardMeasureArray<Q2>(mMeasureDoublets.Select(pair => pair.Second)); }
        }

        /// <summary>
        /// Gets the <paramref name="i">ith</paramref> element of the array of measure pairs
        /// </summary>
        /// <param name="i">Requested element index</param>
        /// <returns>The <paramref name="i">ith</paramref> element of the array of measure pairs</returns>
        IMeasureDoublet<Q1, Q2> IMeasureDoubletArray<Q1, Q2>.this[int i]
        {
            get { return mMeasureDoublets[i]; }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the <paramref name="i">ith</paramref> element of the array of measure pairs
        /// </summary>
        /// <param name="i">Requested element index</param>
        /// <returns>The <paramref name="i">ith</paramref> element of the array of measure pairs</returns>
        public StandardMeasureDoublet<Q1, Q2> this[int i]
        {
            get { return mMeasureDoublets[i]; }
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
        public IEnumerator<IMeasureDoublet<Q1, Q2>> GetEnumerator()
        {
            return mMeasureDoublets.Cast<IMeasureDoublet<Q1, Q2>>().GetEnumerator();
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