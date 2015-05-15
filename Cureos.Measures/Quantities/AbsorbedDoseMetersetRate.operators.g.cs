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
    /// Multiplicative operators for the absorbed dose meterset rate quantity
    /// </summary>
    public partial struct AbsorbedDoseMetersetRate
    {
        #region OPERATORS

        /// <summary>
        /// A multiplication operator for AbsorbedDoseMetersetRate and Meterset objects.
        /// </summary>
        /// <param name="lhs">Left-hand side AbsorbedDoseMetersetRate object.</param>
        /// <param name="rhs">Right-hand side Meterset object.</param>
        /// <returns>Result of multiplication between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity AbsorbedDose.</returns>
        public static AbsorbedDose operator *(AbsorbedDoseMetersetRate lhs, Meterset rhs)
        {
            return new AbsorbedDose(lhs.Amount * rhs.Amount);
        }

        /// <summary>
        /// A multiplication operator for AbsorbedDoseMetersetRate and Meterset objects.
        /// </summary>
        /// <param name="lhs">Left-hand side AbsorbedDoseMetersetRate object.</param>
        /// <param name="rhs">Right-hand side Meterset object (any object implementing IMeasure&lt;Meterset&gt; interface).</param>
        /// <returns>Result of multiplication between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity AbsorbedDose.</returns>
        public static AbsorbedDose operator *(AbsorbedDoseMetersetRate lhs, IMeasure<Meterset> rhs)
        {
            return new AbsorbedDose(lhs.Amount * rhs.StandardAmount);
        }

        #endregion
    }
}
