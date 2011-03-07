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
using Cureos.Measures.Quantities;
using AmountType = System.Double;
#endif

namespace Cureos.Measures.Units
{
    internal static class Units
    {
        internal static Func<AmountType, AmountType> ToConverter(AmountType iFactor)
        {
            return a => a * iFactor;
        }

        internal static Func<AmountType, AmountType> FromConverter(AmountType iFactor)
        {
            return a => a / iFactor;
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

    #region Length units

    public struct Meter : IUnit<Length>
    {
        #region Implementation of IUnit<Length>

        public IQuantity<Length> ReferencedQuantity
        {
            get { return Quantity.Length; }
        }

        public string Symbol
        {
            get { return "m"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        #endregion
    }

    public struct CentiMeter : IUnit<Length>
    {
        #region Implementation of IUnit<Length>

        public IQuantity<Length> ReferencedQuantity
        {
            get { return Quantity.Length; }
        }

        public string Symbol
        {
            get { return "cm"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.CentiToConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.CentiFromConverter; }
        }

        #endregion
    }

    #endregion

    #region Area units

    public struct SquareMeter : IUnit<Area>
    {
        #region Implementation of IUnit<Area>

        public IQuantity<Area> ReferencedQuantity
        {
            get { return Quantity.Area; }
        }

        public string Symbol
        {
            get { return "m²"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        #endregion
    }

    public struct SquareDeciMeter : IUnit<Area>
    {
        #region Implementation of IUnit<Area>

        public IQuantity<Area> ReferencedQuantity
        {
            get { return Quantity.Area; }
        }

        public string Symbol
        {
            get { return "dm²"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.ToConverter(Scales.Square(Scales.Deci)); }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.FromConverter(Scales.Square(Scales.Deci)); }
        }

        #endregion
    }

    public struct SquareCentiMeter : IUnit<Area>
    {
        #region Implementation of IUnit<Area>

        public IQuantity<Area> ReferencedQuantity
        {
            get { return Quantity.Area; }
        }

        public string Symbol
        {
            get { return "cm²"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.ToConverter(Scales.Square(Scales.Centi)); }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.FromConverter(Scales.Square(Scales.Centi)); }
        }

        #endregion
    }

    #endregion

    #region Volume units

    public struct CubicMeter : IUnit<Volume>
    {
        #region Implementation of IUnit<Volume>

        public IQuantity<Volume> ReferencedQuantity
        {
            get { return Quantity.Volume; }
        }

        public string Symbol
        {
            get { return "m³"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        #endregion
    }

    public struct Liter : IUnit<Volume>
    {
        #region Implementation of IUnit<Volume>

        public IQuantity<Volume> ReferencedQuantity
        {
            get { return Quantity.Volume; }
        }

        public string Symbol
        {
            get { return "l"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.ToConverter(Scales.Cube(Scales.Deci)); }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.FromConverter(Scales.Cube(Scales.Deci)); }
        }

        #endregion
    }

    #endregion

    #region Mass units

    public struct KiloGram : IUnit<Mass>
    {
        #region Implementation of IUnit<Mass>

        public IQuantity<Mass> ReferencedQuantity
        {
            get { return Quantity.Mass; }
        }

        public string Symbol
        {
            get { return "kg"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        #endregion
    }

    public struct HectoGram : IUnit<Mass>
    {
        #region Implementation of IUnit<Mass>

        public IQuantity<Mass> ReferencedQuantity
        {
            get { return Quantity.Mass; }
        }

        public string Symbol
        {
            get { return "hg"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.DeciToConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.DeciFromConverter; }
        }

        #endregion
    }

    #endregion

    #region Time units

    public struct Second : IUnit<Time>
    {
        #region Implementation of IUnit<Time>

        public IQuantity<Time> ReferencedQuantity
        {
            get { return Quantity.Time; }
        }

        public string Symbol
        {
            get { return "s"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        #endregion
    }

    public struct Minute : IUnit<Time>
    {
        #region Implementation of IUnit<Time>

        public IQuantity<Time> ReferencedQuantity
        {
            get { return Quantity.Time; }
        }

        public string Symbol
        {
            get { return "min"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return a => a * Scales.SecondsPerMinute; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return a => a / Scales.SecondsPerMinute; }
        }

        #endregion
    }

    public struct Hour : IUnit<Time>
    {
        #region Implementation of IUnit<Time>

        public IQuantity<Time> ReferencedQuantity
        {
            get { return Quantity.Time; }
        }

        public string Symbol
        {
            get { return "h"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return a => a * Scales.SecondsPerHour; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return a => a / Scales.SecondsPerHour; }
        }

        #endregion
    }

    public struct Day : IUnit<Time>
    {
        #region Implementation of IUnit<Time>

        public IQuantity<Time> ReferencedQuantity
        {
            get { return Quantity.Time; }
        }

        public string Symbol
        {
            get { return "dy"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return a => a * Scales.SecondsPerDay; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return a => a / Scales.SecondsPerDay; }
        }

        #endregion
    }

    public struct Week : IUnit<Time>
    {
        #region Implementation of IUnit<Time>

        public IQuantity<Time> ReferencedQuantity
        {
            get { return Quantity.Time; }
        }

        public string Symbol
        {
            get { return "wk"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return a => a * Scales.SecondsPerWeek; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return a => a / Scales.SecondsPerWeek; }
        }

        #endregion
    }

    #endregion

    #region Temperature units

    public struct Kelvin : IUnit<Temperature>
    {
        #region Implementation of IUnit<Temperature>

        public IQuantity<Temperature> ReferencedQuantity
        {
            get { return Quantity.Temperature; }
        }

        public string Symbol
        {
            get { return "K"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        #endregion
    }

    #endregion

    #region Energy units

    public struct Joule : IUnit<Energy>
    {
        #region Implementation of IUnit<Energy>

        public IQuantity<Energy> ReferencedQuantity
        {
            get { return Quantity.Energy; }
        }

        public string Symbol
        {
            get { return "J"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        #endregion
    }

    #endregion

    #region AbsorbedDose units

    public struct Gray :  IUnit<AbsorbedDose>
    {
        #region Implementation of IUnit<AbsorbedDose>

        public IQuantity<AbsorbedDose> ReferencedQuantity
        {
            get { return Quantity.AbsorbedDose; }
        }

        public string Symbol
        {
            get { return "Gy"; }
        }

        public Func<AmountType, AmountType> AmountToReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        public Func<AmountType, AmountType> AmountFromReferenceUnitConverter
        {
            get { return Units.UnityConverter; }
        }

        #endregion
    }

    #endregion
}