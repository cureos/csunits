/*
 *  Copyright (c) 2011-2015, Cureos AB.
 *  All rights reserved.
 *  http://www.cureos.com
 *
 *	This file is part of CSUnits.
 *
 *  CSUnits is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Lesser General Public License as
 *  published by the Free Software Foundation, either version 3 of the
 *  License, or (at your option) any later version.
 *
 *  CSUnits is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with CSUnits. If not, see http://www.gnu.org/licenses/.
 */

namespace Cureos.Measures
{
    using Cureos.Measures.Quantities;

    using NUnit.Framework;

    [TestFixture]
    public class UnitTests
    {
        private ConstantConverterUnit<UnitTestsQuantity> instance;

        private struct UnitTestsQuantity : IQuantity<UnitTestsQuantity>
        {
            public string DisplayName { get; private set; }

            public QuantityDimension Dimension
            {
                get { return QuantityDimension.Steradian; }
            }

            IUnit IQuantity.StandardUnit
            {
                get { return this.StandardUnit; }
            }

            public IMeasureFactory<UnitTestsQuantity> Factory
            {
                get
                {
                    throw new System.NotImplementedException();
                }
            }

            public IUnit<UnitTestsQuantity> StandardUnit
            {
                get { return new ConstantConverterUnit<UnitTestsQuantity>("UTQ"); }
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
            this.instance = new ConstantConverterUnit<UnitTestsQuantity>(UnitPrefix.Giga);
        }

        #endregion

        #region Unit tests

        [Test]
        public void SymbolGetter_InstanceUnit_ReturnsGUTQ()
        {
            var expected = "GUTQ";
            var actual = this.instance.Symbol;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AmountToStandardUnitConverter_InstanceUnit_ReturnsGigaTimesOriginalValue()
        {
            var expected = AmountConverter.ToAmountType(1.0e9);
            var actual = this.instance.ConvertAmountToStandardUnit(AmountConverter.ToAmountType(1.0));
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

        [Test]
        public void MultiplicationOperator_LengthAmount_YieldsMeasure()
        {
            var length = 5.0 * Length.CentiMeter;
            Assert.IsInstanceOf<Length>(length);
            Assert.AreEqual(0.05, length.Amount, 1e-7);
        }

        #endregion
    }
}
