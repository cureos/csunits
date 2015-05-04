/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

namespace Cureos.Measures
{
    /// <summary>
    /// Interface representing a pair of measures given in two (potentially different) quantities
    /// </summary>
    /// <typeparam name="Q1">Quantity type of the first measure</typeparam>
    /// <typeparam name="Q2">Quantity type of the second measure</typeparam>
    public interface IMeasureDoublet<Q1, Q2> where Q1 : struct, IQuantity<Q1> where Q2 : struct, IQuantity<Q2>
    {
        /// <summary>
        /// Gets the first measure in the measure pair
        /// </summary>
        IMeasure<Q1> X { get; }

        /// <summary>
        /// Gets the second measure in the measure pair
        /// </summary>
        IMeasure<Q2> Y { get; }
    }
}