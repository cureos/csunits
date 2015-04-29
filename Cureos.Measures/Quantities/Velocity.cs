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
    public partial struct Velocity
    {
        public static Length operator *(Velocity velocity, Time time)
        {
            return new Length(velocity.Amount * time.Amount);
        }

        public static Length operator *(Time time, Velocity velocity)
        {
            return new Length(time.Amount * velocity.Amount);
        }

        public static Time operator /(Length length, Velocity velocity)
        {
            return new Time(length.Amount / velocity.Amount);
        }
    }
}