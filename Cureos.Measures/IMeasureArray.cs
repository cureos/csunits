// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System.Collections.Generic;

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
    /// Interface resenting a collection of measures of a specific quantity
    /// </summary>
    /// <typeparam name="Q">Measured quantity</typeparam>
    public interface IMeasureArray<Q> : IEnumerable<IMeasure<Q>> where Q : struct, IQuantity<Q>
    {
        /// <summary>
        /// Gets the array of measured amounts in the <see cref="Unit">current unit of measure</see>
        /// </summary>
        IEnumerable<AmountType> Amounts { get; }

        /// <summary>
        /// Gets the unit of measure
        /// </summary>
        IUnit<Q> Unit { get; }

        /// <summary>
        /// Gets the array of measured amounts in the <paramref name="iUnit">specified unit</paramref>
        /// </summary>
        /// <param name="iUnit">Unit in which the array of measured amounts should be returned</param>
        /// <returns>Array of measured amounts, given in the <paramref name="iUnit">specified unit</paramref></returns>
        IEnumerable<AmountType> GetAmounts(IUnit<Q> iUnit);

        /// <summary>
        /// Gets the <paramref name="i">ith</paramref> measure component of the measure array
        /// </summary>
        /// <param name="i">Zero-based index of the measure array</param>
        /// <returns>The <paramref name="i">ith</paramref> component of the measure array</returns>
        IMeasure<Q> this[int i] { get; }
    }

    /// <summary>
    /// Interface representing an array of 
    /// </summary>
    /// <typeparam name="Q1">Quantity type of the first measure</typeparam>
    /// <typeparam name="Q2">Quantity type of the second measure</typeparam>
    public interface IMeasureArray<Q1, Q2> : IEnumerable<IMeasure<Q1, Q2>>
        where Q1 : struct, IQuantity<Q1>
        where Q2 : struct, IQuantity<Q2>
    {
        /// <summary>
        /// Gets the array of first measures
        /// </summary>
        IMeasureArray<Q1> Measures1 { get; }

        /// <summary>
        /// Gets the array of second measures
        /// </summary>
        IMeasureArray<Q2> Measures2 { get; }
    }
}