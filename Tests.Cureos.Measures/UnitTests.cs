// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using NUnit.Framework;
using Cureos.Measures;

namespace Tests.Cureos.Measures
{
	[TestFixture]
	public class UnitTests
	{
		private struct UnitTestsQuantity : IQuantity<UnitTestsQuantity>
		{
			public QuantityDimension Dimension
			{
				get { return new QuantityDimension(DimensionlessDifferentiators.Steradian); }
			}
			
			public IUnit<UnitTestsQuantity> StandardUnit
			{
				get { return new Unit<UnitTestsQuantity>("UTQ"); }
			}
		}
			
		[Test]
		public void CreateFromPrefix_UsingGigaPrefix_ReturnsGUTQ()
		{
			var newUnit = new Unit<UnitTestsQuantity>(UnitPrefix.Giga);
			Assert.AreEqual("GUTQ", newUnit.Symbol);
			AmountAssert.AreEqual(AmountConverter.ToAmountType(1.0e9), 
			                      newUnit.AmountToStandardUnitConverter(AmountConverter.ToAmountType(1.0)));
		}
	}
}
