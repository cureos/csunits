// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;

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
    /// Common interface for physical units
    /// </summary>
    public interface IUnit
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the unit symbol
        /// </summary>
        string Symbol { get; }

        /// <summary>
        /// Gets the reference unit
        /// </summary>
        IUnit ReferenceUnit { get; }

        /// <summary>
        /// Gets the unit dimension
        /// </summary>
        UnitDimension Dimension { get; }

        /// <summary>
        /// Gets the function used for converting an amount from this unit to the reference unit of the same dimension
        /// </summary>
        Func<AmountType, AmountType> AmountToReferenceUnitConverter { get; }

        /// <summary>
        /// Gets the function used for converting an amount to this unit from the reference unit of the same dimension
        /// </summary>
        Func<AmountType, AmountType> AmountFromReferenceUnitConverter { get; }

        #endregion
    }
}
