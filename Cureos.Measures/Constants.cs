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
#if SINGLE
    using AmountType = System.Single;
#elif DECIMAL
    using AmountType = System.Decimal;
#elif DOUBLE
    using AmountType = System.Double;
#endif

    /// <summary>
    /// Utility class providing specific constants for the current floating-point type
    /// </summary>
    public static class Constants
    {
        #region FIELDS
#if SINGLE
        public const float Zero = 0.0f;
        public const float One = 1.0f;
        public const float Two = 2.0f;
        public const float Half = 0.5f;
#elif DECIMAL
        public const decimal Zero = 0.0m;
        public const decimal One = 1.0m;
        public const decimal Two = 2.0m;
        public const decimal Half = 0.5m;
#elif DOUBLE
        public const double Zero = 0.0;
        public const double One = 1.0;
        public const double Two = 2.0;
        public const double Half = 0.5;
#endif
        public static readonly AmountType MachineEpsilon;

        #endregion

        #region CONSTRUCTORS

        static Constants()
        {
            var machEps = One;

            do
            {
                machEps *= Half;
            }
            while (One + Half * machEps != One);

            MachineEpsilon = machEps;
        }

        #endregion
    }
}