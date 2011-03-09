// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
	[TestFixture]
	public class ExampleTests
	{
		[Test]
		public void Example1()
		{
			StandardMeasure<Mass> initialWgt = new StandardMeasure<Mass>(75.0);
			StandardMeasure<Mass> gainedWgt = new StandardMeasure<Mass>(2.5, Units.HectoGram);
			StandardMeasure<Mass> newWgt = initialWgt + gainedWgt;

			Measure<Mass> newWgtInGram = newWgt[Units.Gram];
			Measure<Mass> initialWgtInGram = newWgtInGram - gainedWgt;

			Console.WriteLine("Initial weight: {0}", initialWgtInGram);

			Measure<Length> height = new Measure<Length>(30.0, Units.CentiMeter);
			StandardMeasure<Area> area = (StandardMeasure<Area>)0.02;

			var vol = StandardMeasure<Volume>.Times(height, area);
			var maxVol = new StandardMeasure<Volume>(10.0, Units.Liter);

			if (vol < maxVol)
			{
				Console.WriteLine("Calculated volume is within limits, actual volume: {0}", vol[Units.Liter]);
			}

#if NUNIT24
			Assert.Ignore();
#else
			Assert.Pass();
#endif
		}
	}
}