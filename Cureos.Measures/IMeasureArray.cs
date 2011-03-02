// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

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
        /// Gets the array of measured amounts in the <see cref="MeasuredUnit">current unit of measure</see>
        /// </summary>
        AmountType[] MeasuredAmounts { get; }

        /// <summary>
        /// Gets the array of measured amounts in the <see cref="ReferenceUnit">reference unit of measure</see>
        /// </summary>
        AmountType[] ReferenceUnitAmounts { get; }

        /// <summary>
        /// Gets the measured quantity
        /// </summary>
        Quantity MeasuredQuantity { get; }

        /// <summary>
        /// Gets the unit of measure
        /// </summary>
        Unit MeasuredUnit { get; }

        /// <summary>
        /// Gets the reference unit of measure for the <see cref="MeasuredQuantity">measured quantity</see>
        /// </summary>
        Unit ReferenceUnit { get; }

        /// <summary>
        /// Gets the array of measured amounts in the <paramref name="iUnit">requested unit</paramref> of the same quantity
        /// </summary>
        /// <param name="iUnit">Unit in which the measured amounts should be specified</param>
        /// <returns>The array of measured amounts in the <paramref name="iUnit">requested unit</paramref></returns>
        AmountType[] GetAmounts(Unit iUnit);

        /// <summary>
        /// Returns a string description of the measure array in the given <paramref name="iUnit">physical unit</paramref>
        /// </summary>
        /// <param name="iUnit">Unit in which the measure array should be presented</param>
        /// <returns>String representation of the measure array in the given <paramref name="iUnit">physical unit</paramref></returns>
        string ToString(Unit iUnit);
    }
}