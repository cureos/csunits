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
    /// Interface for an array of  measurable objects
    /// </summary>
    /// <typeparam name="U">Unit specific to all measurable objects in the array</typeparam>
    public interface IMeasurableArray<out U> where U : IUnit
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the amount array
        /// </summary>
        AmountType[] Amounts { get; }

        /// <summary>
        /// Gets the unit specific to the measurable array
        /// </summary>
        U Unit { get; }

        /// <summary>
        /// Converts the measurable array into another specified unit of the same unit dimension
        /// </summary>
        /// <typeparam name="V">Unit to convert the measurable array to</typeparam>
        /// <returns>A new measurable array in the requested unit</returns>
        IMeasurableArray<V> InUnit<V>() where V : IUnit;

        #endregion
    }
}