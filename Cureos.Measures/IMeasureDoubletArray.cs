// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System.Collections.Generic;

namespace Cureos.Measures
{
    /// <summary>
    /// Interface representing an array of pairs of measures
    /// </summary>
    /// <typeparam name="Q1">Quantity type of the first measure</typeparam>
    /// <typeparam name="Q2">Quantity type of the second measure</typeparam>
    public interface IMeasureDoubletArray<Q1, Q2> : IEnumerable<IMeasureDoublet<Q1, Q2>>
        where Q1 : struct, IQuantity<Q1>
        where Q2 : struct, IQuantity<Q2>
    {
        /// <summary>
        /// Gets the array of first measures
        /// </summary>
        IMeasureArray<Q1> First { get; }

        /// <summary>
        /// Gets the array of second measures
        /// </summary>
        IMeasureArray<Q2> Second { get; }

        /// <summary>
        /// Gets the <paramref name="i">ith</paramref> element of the array of measure pairs
        /// </summary>
        /// <param name="i">Requested element index</param>
        /// <returns>The <paramref name="i">ith</paramref> element of the array of measure pairs</returns>
        IMeasureDoublet<Q1, Q2> this[int i] { get; }
    }
}