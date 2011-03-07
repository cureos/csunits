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
    public interface IMeasureArray
    {
        /// <summary>
        /// Gets the array of measured amounts in the <see cref="IMeasureArray{Q}.Unit">current unit of measure</see>
        /// </summary>
        AmountType[] Amounts { get; }
    }

    public interface IMeasureArray<Q> : IMeasureArray where Q : struct, IQuantity<Q>
    {
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
    }
}