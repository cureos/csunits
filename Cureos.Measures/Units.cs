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
using Cureos.Measures.Quantities;
using AmountType = System.Double;
#endif

namespace Cureos.Measures
{
    public static class Units
    {
        public static readonly Unit<Length> Meter = new Unit<Length>("m");
        public static readonly Unit<Length> DeciMeter = new Unit<Length>("dm", Scales.Deci);
        public static readonly Unit<Length> CentiMeter = new Unit<Length>("cm", Scales.Centi);
        public static readonly Unit<Length> MilliMeter = new Unit<Length>("mm", Scales.Milli);

        public static readonly Unit<Area> SquareMeter = new Unit<Area>("m²");
        public static readonly Unit<Area> SquareDeciMeter = new Unit<Area>("dm²", Scales.Square(Scales.Deci));
        public static readonly Unit<Area> SquareCentiMeter = new Unit<Area>("cm²", Scales.Square(Scales.Centi));

        public static readonly Unit<Volume> CubicMeter = new Unit<Volume>("m³");
        public static readonly Unit<Volume> Liter = new Unit<Volume>("l", Scales.Cube(Scales.Deci));
        public static readonly Unit<Volume> CubicDeciMeter = new Unit<Volume>("dm³", Scales.Cube(Scales.Deci));
        public static readonly Unit<Volume> CubicCentiMeter = new Unit<Volume>("cm³", Scales.Cube(Scales.Centi));

        public static readonly Unit<Mass> KiloGram = new Unit<Mass>("kg");
        public static readonly Unit<Mass> Tonne = new Unit<Mass>("t", Scales.Kilo);
        public static readonly Unit<Mass> HectoGram = new Unit<Mass>("hg", Scales.Deci);
        public static readonly Unit<Mass> Gram = new Unit<Mass>("g", Scales.Milli);

        public static readonly Unit<Time> Second = new Unit<Time>("s");
        public static readonly Unit<Time> Minute = new Unit<Time>("min", Scales.SecondsPerMinute);
        public static readonly Unit<Time> Hour = new Unit<Time>("h", Scales.SecondsPerHour);
        public static readonly Unit<Time> Day = new Unit<Time>("dy", Scales.SecondsPerDay);
        public static readonly Unit<Time> Week = new Unit<Time>("wk", Scales.SecondsPerWeek);

        public static readonly Unit<Temperature> Kelvin = new Unit<Temperature>("K");
        public static readonly Unit<Temperature> Celsius = new Unit<Temperature>("°C",
                        a => a + Scales.CelsiusKelvinDifference, a => a - Scales.CelsiusKelvinDifference);

        public static readonly Unit<Energy> Joule = new Unit<Energy>("J");
        public static readonly Unit<Energy> KiloJoule = new Unit<Energy>("kJ", Scales.Kilo);

        public static readonly Unit<AbsorbedDose> Gray = new Unit<AbsorbedDose>("Gy");
        public static readonly Unit<AbsorbedDose> CentiGray = new Unit<AbsorbedDose>("cGy", Scales.Centi);
    }
}