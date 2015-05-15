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
    /// Multiplicative operators for the time quantity
    /// </summary>
    public partial struct Time
    {
        #region OPERATORS

        /// <summary>
        /// A multiplication operator for Time and Acceleration objects.
        /// </summary>
        /// <param name="lhs">Left-hand side Time object.</param>
        /// <param name="rhs">Right-hand side Acceleration object.</param>
        /// <returns>Result of multiplication between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity Velocity.</returns>
        public static Velocity operator *(Time lhs, Acceleration rhs)
        {
            return new Velocity(lhs.Amount * rhs.Amount);
        }

        /// <summary>
        /// A multiplication operator for Time and Acceleration objects.
        /// </summary>
        /// <param name="lhs">Left-hand side Time object.</param>
        /// <param name="rhs">Right-hand side Acceleration object (any object implementing IMeasure&lt;Acceleration&gt; interface).</param>
        /// <returns>Result of multiplication between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity Velocity.</returns>
        public static Velocity operator *(Time lhs, IMeasure<Acceleration> rhs)
        {
            return new Velocity(lhs.Amount * rhs.StandardAmount);
        }

        /// <summary>
        /// A multiplication operator for Time and Velocity objects.
        /// </summary>
        /// <param name="lhs">Left-hand side Time object.</param>
        /// <param name="rhs">Right-hand side Velocity object.</param>
        /// <returns>Result of multiplication between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity Length.</returns>
        public static Length operator *(Time lhs, Velocity rhs)
        {
            return new Length(lhs.Amount * rhs.Amount);
        }

        /// <summary>
        /// A multiplication operator for Time and Velocity objects.
        /// </summary>
        /// <param name="lhs">Left-hand side Time object.</param>
        /// <param name="rhs">Right-hand side Velocity object (any object implementing IMeasure&lt;Velocity&gt; interface).</param>
        /// <returns>Result of multiplication between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity Length.</returns>
        public static Length operator *(Time lhs, IMeasure<Velocity> rhs)
        {
            return new Length(lhs.Amount * rhs.StandardAmount);
        }

        /// <summary>
        /// A multiplication operator for Time and AbsorbedDoseRate objects.
        /// </summary>
        /// <param name="lhs">Left-hand side Time object.</param>
        /// <param name="rhs">Right-hand side AbsorbedDoseRate object.</param>
        /// <returns>Result of multiplication between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity AbsorbedDose.</returns>
        public static AbsorbedDose operator *(Time lhs, AbsorbedDoseRate rhs)
        {
            return new AbsorbedDose(lhs.Amount * rhs.Amount);
        }

        /// <summary>
        /// A multiplication operator for Time and AbsorbedDoseRate objects.
        /// </summary>
        /// <param name="lhs">Left-hand side Time object.</param>
        /// <param name="rhs">Right-hand side AbsorbedDoseRate object (any object implementing IMeasure&lt;AbsorbedDoseRate&gt; interface).</param>
        /// <returns>Result of multiplication between <paramref name="lhs"/> and <paramref name="rhs"/>, returned in quantity AbsorbedDose.</returns>
        public static AbsorbedDose operator *(Time lhs, IMeasure<AbsorbedDoseRate> rhs)
        {
            return new AbsorbedDose(lhs.Amount * rhs.StandardAmount);
        }

        #endregion
    }
}
