# CSUnits

Simple C# framework to support Units of Measurement

Copyright 2011-2015 (c) Anders Gustafsson, Cureos AB.  
Made available under GNU Lesser General Public License, LGPL, version 3.


## Prerequisites

Visual Studio 2010 Service Pack 1 or higher with [Portable Library Tools](http://msdn.microsoft.com/en-us/library/gg597391.aspx) extension.


## Introduction

Developed with Visual Studio 2010, using .NET Frameworks 3.5 and 4.0. The latter class library is portable and can without modifications be included in Silverlight 5, Windows Phone 8+ (Silverlight and non-Silverlight), Windows 8+, Xamarin.Android and Xamarin.iOS applications.

`Measure<Q>` and `StandardMeasure<Q>` are the main "work-horses" of the library. `StandardMeasure<Q>` is always represented in the reference unit of the associated quantity. If a different unit is specified in instantiation of `StandardMeasure<Q>`, the measured amount is automatically converted to the equivalent reference unit amount. On the other hand, the amount and unit used in instantiation of `Measure<Q>` are internally maintained.

`StandardMeasure<Q>` is declared as a struct and only holds one member, the amount. The main goal of this approach is to maximize calculation performance, while at the same time ensuring quantity type safety.

There are also `StandardMeasureDoublet<Q1, Q2>` and `StandardMeasureTriplet<Q1, Q2, Q3>` structures that holds two and three measures, respectively, of potentially different quantities.


## Usage examples

    using Cureos.Measures;
    using Cureos.Measures.Quantities;
    ...

    StandardMeasure<Mass> initialWgt = new StandardMeasure<Mass>(75.0);
    StandardMeasure<Mass> gainedWgt = new StandardMeasure<Mass>(2.5, Mass.HectoGram);
    StandardMeasure<Mass> newWgt = initialWgt + gainedWgt;

    Measure<Mass> newWgtInGram = newWgt[Mass.Gram];
    Measure<Mass> initialWgtInGram = newWgtInGram - gainedWgt;

    Console.WriteLine("Initial weight: {0}", initialWgtInGram);

    Measure<Length> height = new Measure<Length>(30.0, Length.CentiMeter);
    StandardMeasure<Area> area = (StandardMeasure<Area>)0.02;

    StandardMeasure<Volume> vol; 
    ArithmeticOperations.Times(height, area, out vol);
    var maxVol = new StandardMeasure<Volume>(10.0, Volume.Liter);

    if (vol < maxVol)
    {
      Console.WriteLine("Calculated volume is within limits, actual volume: {0}", vol[Volume.Liter]);
    }

should yield the output:

> Initial weight: 75000 g  
> Calculated volume is within limits, actual volume 6 l


## Application

For pure demonstration and testing purposes, there are very simple unit converter applications included in the solution. Implementation of these applications were inspired by Andrew Cheng's feedback and usage of CSUnits in a [Windows Forms application](https://github.com/hamxiaoz/cureos.uomnet.tests.winform).
