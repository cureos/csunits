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

/*
 * This file is auto-generated.
 */

namespace Cureos.Measures.Quantities
{
    /// <summary>
    /// Multiplicative operators for the volume quantity
    /// </summary>
    public partial struct Volume
    {
        #region OPERATORS

        /// <summary>
        /// A division operator for Volume and Length objects.
        /// </summary>
        /// <param name="lhs">Left-hand side Volume object.</param>
        /// <param name="rhs">Right-hand side Length object.</param>
        /// <returns>Result of division between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity Area.</returns>
        public static Area operator /(Volume lhs, Length rhs)
        {
            return new Area(lhs.Amount / rhs.Amount);
        }

        /// <summary>
        /// A division operator for Volume and Length objects.
        /// </summary>
        /// <param name="lhs">Left-hand side Volume object.</param>
        /// <param name="rhs">Right-hand side Length object (any object implementing IMeasure&lt;Length&gt; interface).</param>
        /// <returns>Result of division between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity Area.</returns>
        public static Area operator /(Volume lhs, IMeasure<Length> rhs)
        {
            return new Area(lhs.Amount / rhs.StandardAmount);
        }

        #endregion
    }
}
