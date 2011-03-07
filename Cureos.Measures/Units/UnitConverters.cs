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
using System;
using AmountType = System.Double;
#endif

namespace Cureos.Measures.Units
{
    internal static class UnitConverters
    {
        internal static Func<AmountType, AmountType> GetAmountToReferenceUnitConverter(AmountType iTimesFactor)
        {
            return a => a * iTimesFactor;
        }

        internal static Func<AmountType, AmountType> GetAmountFromReferenceUnitConverter(AmountType iDivideFactor)
        {
            return a => a / iDivideFactor;
        }

        internal static readonly Func<AmountType, AmountType> UnityConverter = a => a;
        internal static readonly Func<AmountType, AmountType> KiloToConverter = a => a * Scales.Kilo;
        internal static readonly Func<AmountType, AmountType> KiloFromConverter = a => a / Scales.Kilo;
        internal static readonly Func<AmountType, AmountType> DeciToConverter = a => a * Scales.Deci;
        internal static readonly Func<AmountType, AmountType> DeciFromConverter = a => a / Scales.Deci;
        internal static readonly Func<AmountType, AmountType> CentiToConverter = a => a * Scales.Centi;
        internal static readonly Func<AmountType, AmountType> CentiFromConverter = a => a / Scales.Centi;
        internal static readonly Func<AmountType, AmountType> MilliToConverter = a => a * Scales.Milli;
        internal static readonly Func<AmountType, AmountType> MilliFromConverter = a => a / Scales.Milli;
    }

    public partial struct Meter
    {
        #region Implementation of IUnit

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        #endregion
    }

    public partial struct CentiMeter
    {
        #region Implementation of IUnit

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return UnitConverters.CentiToConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return UnitConverters.CentiFromConverter; }
        }

        #endregion
    }

    public partial struct SquareMeter
    {
        #region Implementation of IUnit

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        #endregion
    }

    public partial struct CubicMeter
    {
        #region Implementation of IUnit

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        #endregion
    }

    public partial struct KiloGram
    {
        #region Implementation of IUnit

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        #endregion
    }

    public partial struct Second
    {
        #region Implementation of IUnit

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        #endregion
    }

    public partial struct Kelvin
    {
        #region Implementation of IUnit

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        #endregion
    }

    public partial struct Joule
    {
        #region Implementation of IUnit

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        #endregion
    }

    public partial struct Gray
    {
        #region Implementation of IUnit

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return UnitConverters.UnityConverter; }
        }

        #endregion
    }
}