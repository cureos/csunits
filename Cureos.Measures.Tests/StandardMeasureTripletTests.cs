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
    public class StandardMeasureTripletTests
    {
        #region Fields

        private StandardMeasureTriplet<Time, Power, ElectricPotential> _instance;

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void Setup()
        {
            _instance = new StandardMeasureTriplet<Time, Power, ElectricPotential>(5.0, 0.12, 0.6);
        }

        [TearDown]
        public void Teardown()
        {
        }

        #endregion

        #region Unit tests

        [Test]
        public void PlusOperator_AddInstanceWithItself_ReturnsDoubleInstance()
        {
            var expected = new StandardMeasureTriplet<Time, Power, ElectricPotential>(10.0, 0.24, 1.2);
            var actual = _instance + _instance;
            IMeasureTripletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void MinusOperator_SubtractInstanceWithItself_ReturnsZero()
        {
            var expected = new StandardMeasureTriplet<Time, Power, ElectricPotential>(0.0, 0.0, 0.0);
            var actual = _instance - _instance;
            IMeasureTripletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TimesOperator_MultiplyBy2And3And4_ReturnsDoubleTimeThreeTimesPowerFourTimesPotential()
        {
            var expected = new StandardMeasureTriplet<Time, Power, ElectricPotential>(10.0, 0.36, 2.4);
            var actual = _instance * new StandardMeasureTriplet<Number, Number, Number>(2.0, 3.0, 4.0);
            IMeasureTripletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DivideOperator_DivideBy2And3And4_ReturnsHalfTimeOneThirdPowerOneFourthPotential()
        {
            var expected = new StandardMeasureTriplet<Time, Power, ElectricPotential>(2.5, 0.04, 0.15);
            var actual = _instance / new StandardMeasureTriplet<Number, Number, Number>(2.0, 3.0, 4.0);
            IMeasureTripletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void DivideOperator_DivideByItself_ReturnsUnityDoublet()
        {
            var expected = new StandardMeasureTriplet<Number, Number, Number>(1.0, 1.0, 1.0);
            var actual = _instance / _instance;
            IMeasureTripletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TimesOperator_MultiplyScalarRhs_AllMeasuresEquallyScaled()
        {
            var expected = new StandardMeasureTriplet<Time, Power, ElectricPotential>(15.0, 0.36, 1.8);;
            var actual = _instance * 3.0;
            IMeasureTripletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TimesOperator_MultiplyScalarLhs_AllMeasuresEquallyScaled()
        {
            var expected = new StandardMeasureTriplet<Time, Power, ElectricPotential>(15.0, 0.36, 1.8); ;
            var actual = 3.0 * _instance;
            IMeasureTripletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TimesOperator_MultiplyNumberLhs_AllMeasuresEquallyScaled()
        {
            var expected = new StandardMeasureTriplet<Time, Power, ElectricPotential>(15.0, 0.36, 1.8); ;
            var actual = _instance * new StandardMeasure<Number>(3.0);
            IMeasureTripletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TimesOperator_MultiplyNumberRhs_AllMeasuresEquallyScaled()
        {
            var expected = new StandardMeasureTriplet<Time, Power, ElectricPotential>(15.0, 0.36, 1.8); ;
            var actual = new StandardMeasure<Number>(3.0) * _instance;
            IMeasureTripletAssert.AreEqual(expected, actual);
        }

        [Test]
        public void IMeasureXAccessor_CheckReturnType_ShouldBeIMeasure()
        {
            var expected = typeof(IMeasure<Time>);
            IMeasureTriplet<Time, Power, ElectricPotential> triplet = _instance;
            var actual = triplet.X;
            Assert.IsInstanceOf(expected, actual);
        }

        #endregion
    }
}
