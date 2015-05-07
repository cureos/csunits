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

namespace Cureos.Measures.Quantities
{
    public partial struct Length
    {
        #region OPERATORS

        public static Area operator *(Length lhs, Length rhs)
        {
            return new Area(lhs.amount * rhs.amount);
        }

        public static Area operator *(Length lhs, IMeasure<Length> rhs)
        {
            return new Area(lhs.amount * rhs.StandardAmount);
        }

        public static Volume operator *(Length lhs, Area rhs)
        {
            return new Volume(lhs.amount * rhs.Amount);
        }

        public static Volume operator *(Length lhs, IMeasure<Area> rhs)
        {
            return new Volume(lhs.amount * rhs.StandardAmount);
        }

        public static Velocity operator /(Length lhs, Time rhs)
        {
            return new Velocity(lhs.amount / rhs.Amount);
        }

        public static Velocity operator /(Length lhs, IMeasure<Time> rhs)
        {
            return new Velocity(lhs.amount / rhs.StandardAmount);
        }

        #endregion
    }
}