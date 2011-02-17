**************
*** uomnet ***
**************

Simple C# framework to support Units of Measurement

Copyright 2011 (c) Anders Gustafsson, Cureos AB

Made available under Eclipse Public License, version 1.0



USAGE EXAMPLES
--------------

using Cureos.Measurables;
using Cureos.Measurables.Units;
...

Measurable<KiloGram> initialWgt = new Measurable<KiloGram>(75.0);
Measurable<KiloGram> gainedWgt = new Measurable<Gram>(2.5);
Measurable<KiloGram> newWgt = initialWgt + gainedWgt;


Measurable<Gram> newWgtInGram = newWgt.InUnit<Gram>();
Measurable<Gram> initialWgtInGram = newWgtInGram.Minus(gainedWgt);


Console.WriteLine("Initial weight: {0}", initialWgtInGram);


Measurable<CentiMeter> height = (Measurable<CentiMeter>)30.0;
Measurable<SquareMeter> area = new Measurable<SquareMeter>(0.02);


Measurable<Liter> vol = height.Times(area);
Measurable<Liter> maxVol = (Measurable<Liter>)10.0;


if (vol < maxVol)
{
  Console.WriteLine("Calculated volume is within limits, actual volume: {0} liters",
 vol.Amount);
}



should yield the output:

Initial weight: 75000 g
Calculated volume is within limits, actual volume 6 liters



REMARKS
-------

Developed with Visual Studio 2010, using .NET Framework 4. The solution might require tweaking to build with Mono or older versions of .NET Framework.

The "work-horse" Measurable<> is declared as a struct, and the struct itself only contains one value type member. The main goal of this approach is to maximize calculation performance, while at the same time ensuring unit type safety. In contrast, operations involving unit conversions are costly due to extensive use of type reflection.

With preprocessor directives, it is possible to configure the library so that the measurable amounts are defined in a desired floating-point value type. The following preprocessor directives are currently supported, and can be defined in the project build settings:

Preprocessor directive	Corresponding value type

----------------------	------------------------
DOUBLE			double

SINGLE			float

DECIMAL			decimal

Units are identified through their dimension in terms of SI Base Units. When extending this library, it is recommended that a quantity-specific unit dimension static class is added to the Dimensions sub-folder. The following conventions have been used when implementing the currently existing unit dimension specifications:

internal static class Energy
{
    internal static readonly UnitDimension Dimension;
    static Energy() { Dimension = new UnitDimension(2,1,-2,0,0,0,0); }
}

When creating a new energy unit, the Energy.Dimension field can then be used to define the new unit.

To add a new unit to the library, there are a few normative conventions to follow. New units are preferably added to the Units sub-folder. Provided is an example implementation:

public sealed class Joule : GenericUnit
{
    public static readonly Joule Instance;
    static Joule() { Instance = new Joule(); }
    private Joule() : base("J", Energy.Dimension) { }
}

The member constructor is declared private, to ensure that no instances of the unit class are accidentally created. The class only publicly exposes the static field denoted Instance. This field must be defined and initialized with an instance of the containing unit class to ensure that operations involving unit conversion does not fail.


----

Last updated on February 16, 2011 by Anders Gustafsson, anders[at]cureos[dot]com.
