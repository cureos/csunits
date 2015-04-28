// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Cureos.Measures
{
	[TestFixture]
	public class UnitTests
	{
		private Unit<UnitTestsQuantity> _instance;

		private struct UnitTestsQuantity : IQuantity<UnitTestsQuantity>
		{
		    public string DisplayName { get; private set; }

		    public QuantityDimension Dimension
			{
				get { return QuantityDimension.Steradian; }
			}

			IUnit IQuantity.StandardUnit
			{
				get { return StandardUnit; }
			}

			public IUnit<UnitTestsQuantity> StandardUnit
			{
				get { return new Unit<UnitTestsQuantity>("UTQ"); }
			}

		    public bool Equals(IQuantity other)
		    {
		        return other is UnitTestsQuantity;
		    }
		}

		#region Setup and TearDown

		[SetUp]
		public void Setup()
		{
			_instance = new Unit<UnitTestsQuantity>(UnitPrefix.Giga);
		}

		[TearDown]
		public void TearDown()
		{
			_instance = null;
		}

		#endregion

		#region Unit tests

		[Test]
		public void SymbolGetter_InstanceUnit_ReturnsGUTQ()
		{
			var expected = "GUTQ";
			var actual = _instance.Symbol;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AmountToStandardUnitConverter_InstanceUnit_ReturnsGigaTimesOriginalValue()
		{
			var expected = AmountConverter.ToAmountType(1.0e9);
			var actual = _instance.AmountToStandardUnitConverter(AmountConverter.ToAmountType(1.0));
			AmountAssert.AreEqual(expected, actual);
		}

		[Test]
		public void Quantity_OfLengthUnit_IsLength()
		{
			Assert.IsInstanceOf(typeof(Length), Length.PicoMeter.Quantity);
		}

		[Test]
		public void Quantity_OfIUnitDefinedAsMassUnit_IsMass()
		{
			IUnit unit = Mass.HectoGram;
			Assert.IsInstanceOf(typeof(Mass), unit.Quantity);
		}

		[Test]
		public void DisplayNameGetter_NoExplicitDefinition_ReturnsFieldNameAndSymbol()
		{
			var expected = "Hectare | ha";
			var actual = Area.Hectare.DisplayName;
			StringAssert.AreEqualIgnoringCase(expected, actual);
		}
		#endregion
	}
}
