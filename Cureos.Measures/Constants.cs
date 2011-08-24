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

namespace Cureos.Measures
{
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