// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Collections.Generic;
using System.Linq;

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
    /// Convenience class providing factors and support methods for applying amount conversion factors in e.g.
    /// physical unit definition
    /// </summary>
    public static class Factors
    {
    	#region STATIC MEMBER VARIABLES

    	private static readonly Dictionary<string, AmountType> smkPrefixSymbolsMap;
    	
    	#endregion

    	#region CONSTRUCTORS
    	
    	static Factors()
    	{
    		smkPrefixSymbolsMap = new Dictionary<string, AmountType>()
    		{
    			{"Y",Yotta},
    			{"Z", Zetta},
    			{"E", Exa},
    			{"P", Peta},
    			{"T", Tera},
    			{"G", Giga},
    			{"M", Mega},
    			{"k", Kilo},
    			{"h", Hecto},
    			{"da", Deka},
    			{"d", Deci},
    			{"c", Centi},
    			{"m", Milli},
    			{"µ", Micro},
    			{"n", Nano},
    			{"p", Pico},
    			{"f", Femto},
    			{"a", Atto},
    			{"z", Zepto},
    			{"y", Yocto}
    		};
    	}
    	
    	#endregion
    	
#if DOUBLE
        public const double Yotta = 1.0e24;
        public const double Zetta = 1.0e21;
        public const double Exa = 1.0e18;
        public const double Peta = 1.0e15;
        public const double Tera = 1.0e12;
        public const double Giga = 1.0e9;
        public const double Mega = 1.0e6;
        public const double Kilo = 1.0e3;
        public const double Hecto = 1.0e2;
        public const double Deka = 1.0e1;
        public const double Deci = 1.0e-1;
        public const double Centi = 1.0e-2;
        public const double Milli = 1.0e-3;
        public const double Micro = 1.0e-6;
        public const double Nano = 1.0e-9;
        public const double Pico = 1.0e-12;
        public const double Femto = 1.0e-15;
        public const double Atto = 1.0e-18;
        public const double Zepto = 1.0e-21;
        public const double Yocto = 1.0e-24;
        public const double SecondsPerMinute = 60.0;
        public const double SecondsPerHour = SecondsPerMinute * 60.0;
        public const double SecondsPerDay = SecondsPerHour * 24.0;
        public const double SecondsPerWeek = SecondsPerDay * 7.0;
        public const double CelsiusKelvinDifference = 273.15;
        public const double JoulesPerElectronVolt = 1.602e-19;
        public const double MetersPerAngstrom = 1.0e-10;
        public const double MetersPerInch = 1.0 / 0.0254;
        public const double MetersPerFoot = MetersPerInch / 12.0;
        public const double MetersPerYard = MetersPerFoot / 3.0;
        public const double MetersPerMile = MetersPerYard / 1760.0;
        public const double MetersPerNauticalMile = 1.0 / 1852.0;
        public const double SquareMetersPerBarn = 1.0e-28;
        public static readonly double DegreesPerRadian = 180.0 / Math.PI;

        public static double Square(double a) { return a * a; }
        public static double Cube(double a) { return a * a * a; }
#elif SINGLE
        public const float Yotta = 1.0e24f;
        public const float Zetta = 1.0e21f;
        public const float Exa = 1.0e18f;
        public const float Peta = 1.0e15f;
        public const float Tera = 1.0e12f;
        public const float Giga = 1.0e9f;
        public const float Mega = 1.0e6f;
        public const float Kilo = 1.0e3f;
        public const float Hecto = 1.0e2f;
        public const float Deka = 1.0e1f;
        public const float Deci = 1.0e-1f;
        public const float Centi = 1.0e-2f;
        public const float Milli = 1.0e-3f;
        public const float Micro = 1.0e-6f;
        public const float Nano = 1.0e-9f;
        public const float Pico = 1.0e-12f;
        public const float Femto = 1.0e-15f;
        public const float Atto = 1.0e-18f;
        public const float Zepto = 1.0e-21f;
        public const float Yocto = 1.0e-24f;
        public const float SecondsPerMinute = 60.0f;
        public const float SecondsPerHour = SecondsPerMinute * 60.0f;
        public const float SecondsPerDay = SecondsPerHour * 24.0f;
        public const float SecondsPerWeek = SecondsPerDay * 7.0f;
        public const float CelsiusKelvinDifference = 273.15f;
        public const float JoulesPerElectronVolt = 1.602e-19f;
        public const float MetersPerAngstrom = 1.0e-10f;
        public const float MetersPerInch = 1.0f / 0.0254f;
        public const float MetersPerFoot = MetersPerInch / 12.0f;
        public const float MetersPerYard = MetersPerFoot / 3.0f;
        public const float MetersPerMile = MetersPerYard / 1760.0f;
        public const float MetersPerNauticalMile = 1.0f / 1852.0f;
        public const float SquareMetersPerBarn = 1.0e-28f;
        public static readonly float DegreesPerRadian = 180.0f / (float)Math.PI;

        public static float Square(float a) { return a * a; }
        public static float Cube(float a) { return a * a * a; }
#elif DECIMAL
        public const decimal Yotta = 1.0e24m;
        public const decimal Zetta = 1.0e21m;
        public const decimal Exa = 1.0e18m;
        public const decimal Peta = 1.0e15m;
        public const decimal Tera = 1.0e12m;
        public const decimal Giga = 1.0e9m;
        public const decimal Mega = 1.0e6m;
        public const decimal Kilo = 1.0e3m;
        public const decimal Hecto = 1.0e2m;
        public const decimal Deka = 1.0e1m;
        public const decimal Deci = 1.0e-1m;
        public const decimal Centi = 1.0e-2m;
        public const decimal Milli = 1.0e-3m;
        public const decimal Micro = 1.0e-6m;
        public const decimal Nano = 1.0e-9m;
        public const decimal Pico = 1.0e-12m;
        public const decimal Femto = 1.0e-15m;
        public const decimal Atto = 1.0e-18m;
        public const decimal Zepto = 1.0e-21m;
        public const decimal Yocto = 1.0e-24m;
        public const decimal SecondsPerMinute = 60.0m;
        public const decimal SecondsPerHour = SecondsPerMinute * 60.0m;
        public const decimal SecondsPerDay = SecondsPerHour * 24.0m;
        public const decimal SecondsPerWeek = SecondsPerDay * 7.0m;
        public const decimal CelsiusKelvinDifference = 273.15m;
        public const decimal JoulesPerElectronVolt = 1.602e-19m;
        public const decimal MetersPerAngstrom = 1.0e-10m;
        public const decimal MetersPerInch = 1.0m / 0.0254m;
        public const decimal MetersPerFoot = MetersPerInch / 12.0m;
        public const decimal MetersPerYard = MetersPerFoot / 3.0m;
        public const decimal MetersPerMile = MetersPerYard / 1760.0m;
        public const decimal MetersPerNauticalMile = 1.0m / 1852.0m;
        public const decimal SquareMetersPerBarn = 1.0e-28m;
        public static readonly decimal DegreesPerRadian = 180.0m / (decimal)Math.PI;

        public static decimal Square(decimal a) { return a * a; }
        public static decimal Cube(decimal a) { return a * a * a; }
#endif

		#region METHODS

		internal static AmountType GetPrefixFactor(string iPrefixSymbol)
		{
			return smkPrefixSymbolsMap[iPrefixSymbol];
		}
		
		#endregion
    }
}