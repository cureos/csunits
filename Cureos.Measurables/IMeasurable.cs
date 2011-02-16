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

namespace Cureos.Measurables
{
    /// <summary>
    /// Interface for a single measurable object
    /// </summary>
    /// <typeparam name="U">Unit specific to the measurable object</typeparam>
    public interface IMeasurable<out U> where U : IUnit
    {
        /// <summary>
        /// Gets the amount of the measurable
        /// </summary>
        AmountType Amount { get; }

        /// <summary>
        /// Gets the unit specific to the measurable object
        /// </summary>
        U Unit { get; }

        /// <summary>
        /// Converts the measurable object into another specified unit of the same unit dimension
        /// </summary>
        /// <typeparam name="V">Unit to convert the measurable to</typeparam>
        /// <returns>A new measurable object in the requested unit</returns>
        IMeasurable<V> InUnit<V>() where V : IUnit;
    }
}