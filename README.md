# CSUnits

[![NuGet](https://img.shields.io/nuget/v/csunits.svg)](https://www.nuget.org/packages/csunits/)
[![NuGet](https://img.shields.io/nuget/dt/csunits.svg)](https://www.nuget.org/packages/csunits/)
[![Build status](https://ci.appveyor.com/api/projects/status/6rntuke5f9y307n0?svg=true)](https://ci.appveyor.com/project/anders9ustafsson/csunits)
[![Join the chat at https://gitter.im/cureos/csunits](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cureos/csunits?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Simple C# framework to support Units of Measurement

Copyright 2011-2015 (c) Anders Gustafsson, Cureos AB.  
Made available under GNU Lesser General Public License, LGPL, version 3.


## Introduction

The *Cureos.Measures* class library is portable and can without modifications be included in .NET 4+, Silverlight 5, Windows Phone 8+ (Silverlight and non-Silverlight), Windows 8+, Xamarin.Android and Xamarin.iOS applications.

Quantity `Q` and `Measure<Q>` are the main "work-horses" of the library. `Q` represents both the quantity itself and a measure in the same quantity, and is always expressed in the reference unit of the associated quantity. If a different unit is specified in instantiation of `Q`, the measured amount is automatically converted to the equivalent reference unit amount. On the other hand, the amount and unit used in instantiation of `Measure<Q>` are internally maintained.

Quantity `Q` is declared as a `struct` and only holds one member, the amount. The main goal of this approach is to maximize calculation performance, while at the same time ensuring quantity type safety.

There are also `MeasureDoublet<Q1, Q2>` and `MeasureTriplet<Q1, Q2, Q3>` structures that holds two and three measures, respectively, of potentially different quantities.

## How to get it

Download *CSUnits* from [NuGet](https://www.nuget.org/packages/csunits/) or, if you prefer, build it from source.

## Usage

### Create measure objects in standard unit

    Force f1 = new Force(1000.0);                  // 1000 N
    Force f2 = new Force(1.0m, Force.KiloNewton);  // 1000 N
    Force f3 = (Force)1000.0m;                     // 1000 N, explicit cast
    Force f4 = 0.001f * Force.MegaNewton;          // ~1000 N, multiply with unit
    Force f5 = Force.KiloNewton;                   // 1000 N, implicitly cast from unit

### Create measure objects with preserved unit information

    Force f0 = new Force(1000.0);
	...
    Measure<Force> f1 = new Measure<Force>(f0);							// 1000 N
    Measure<Force> f2 = new Measure<Force>(0.001f, Force.MegaNewton);	// ~0.001 MN
    IMeasure<Force> f3 = 1.0 | Force.KiloNewton;						// 1 kN
    Measure<Force> f4 = (Measure<Force>)f3;								// 1 kN

### Brief API overview

	Area a = new Area(5.0, Area.SquareDeciMeter);
	...
	double amount = a.Amount;											// 0.05;
	IUnit<Area> unit = a.Unit;											// Area.SquareMeter
	double stdAmount = a.StandardAmount;								// 0.05;
	IUnit<Area> stdUnit = a.StandardUnit;								// Area.SquareMeter
	double amountInCm2 = a.GetAmount(Area.SquareCentiMeter);			// 500
	IMeasure<Area> measureInMm2 = a[Area.SquareMilliMeter];				// 50000 mm²
	
	Measure<Volume> v = new Measure<Volume>(2.0, Volume.Liter);
	...
	double amount = v.Amount;											// 2
	IUnit<Volume> unit = v.Unit;										// Volume.Liter
	double stdAmount = v.StandardAmount;								// 0.002
	IUnit<Volume> stdUnit = v.StandardUnit;								// Volume.CubicMeter
	double amountInCm3 = v.GetAmount(Volume.CubicCentiMeter);			// 2000
	IMeasure<Volume> measureInDm3 = v[Volume.CubicDeciMeter];			// 2 dm³

### Non-generic API

	IMeasure doseRate;
	...
	doseRate = new Measure<AbsorbedDoseMetersetRate>(
					98.0, AbsorbedDoseMetersetRate.CentiGrayPerMeterset);
	...
	double amount = doseRate.Amount;									// 98.0
	IUnit unit = doseRate.Unit;											// cGy/MU
	double stdAmount = doseRate.StandardAmount;							// 0.98
	double stdUnit = doseRate.StandardUnit;								// Gy/MU
	double amountInGyPerMU = doseRate.GetAmount(
					AbsorbedDoseMetersetRate.GrayPerMeterset);			// 0.98
	IMeasure measureInGyPerSec = 
					doseRate[AbsorbedDoseRate.GrayPerSecond];			// Run-time exception
					
### Comparison operators

	Length l1 = new Length(0.02);										// 0.02 m
	Length l2 = Length.CentiMeter;										// 0.01 m
	Measure<Length> l3 = new Measure<Length>(15.0, Length.MilliMeter);	// 15 mm

	l1 > l2		// true
	l2 >= l1	// false
	l3 < l1		// true
	l3 <= l2	// false
	l1 == l3	// false
	l2 != l1	// true

### Additive operators

	Force f1 = Force.KiloNewton;
	Force f2 = (Force)2000.0;
	IMeasure<Force> f3 = 0.5 | Force.KiloNewton;
	...
	Force f4 = f1 + f2 - f3;											// 2500 N
	Measure<Force> f5 = (Measure<Force>)f3 + f2 - f1;					// 1.5 kN

### Multiplicative scalar operations

	Energy e1 = new Energy(5.0);
	Measure<Energy> e2 = new Measure<Energy>(0.1, Energy.KiloJoule);
	...
	Energy e3 = e1 / 2.0;												// 2.5 J
	Measure<Energy> e4 = 0.2 * e2;										// 0.02 kJ

### Multiplicative operations

	Length s = new Length(180.0, Length.KiloMeter);
	Time t = new Time(2.0, Time.Hour);
	Velocity v1 = s / t;												// 25 m/s

## Application

For pure demonstration and testing purposes, there are very simple unit converter applications included in the solution. Implementation of these applications were inspired by Andrew Cheng's feedback and usage of CSUnits in a [Windows Forms application](https://github.com/hamxiaoz/cureos.uomnet.tests.winform).
