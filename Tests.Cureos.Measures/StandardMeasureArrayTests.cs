// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using System.Linq;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
	[TestFixture]
	public class StandardMeasureArrayTests
	{
		private StandardMeasureArray<Length> _instance;

		#region Setup and TearDown
		[SetUp]
		public void Setup()
		{
			_instance = new StandardMeasureArray<Length>(new[] {1.0, 2.0, 3.0, 4.0, 5.0}, Length.CentiMeter);
		}

		[TearDown]
		public void TearDown()
		{
			_instance = null;
		}

		#endregion

		#region Unit tests

		[Test]
		public void Constructor_UsingNonReferenceUnit_MeasuredAmountsInReferenceUnit()
		{
			var expected = AmountConverter.ToAmountType(new[] {0.01, 0.02, 0.03, 0.04, 0.05});
			var actual = _instance.Amounts;
#if NUNIT24
			for (int i = 0; i < expected.Count(); ++i)
				Assert.IsTrue(AmountComparer.Instance.Compare(expected.ElementAt(i), actual[i]) == 0);
#else
			CollectionAssert.AreEqual(expected, actual, AmountComparer.Instance);
#endif
		}

		[Test]
		public void Indexer_AccessCenterElement_ReturnsMeasure()
		{
			var expected = new StandardMeasure<Length>(AmountConverter.ToAmountType(0.03));
			var actual = _instance[2];
			MeasureAssert.MeasuresAreEqual(expected, actual);
		}

		[Test]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void Indexer_AccessElementOutOfRange_Throws()
		{
			var throws = _instance[6];
		}

		[Test]
		[ExpectedException(typeof(InvalidCastException))]
		public void GetAmounts_CastToArray_Throws()
		{
			AmountConverter.CastToArray(_instance.Amounts);
		}

		[Test]
		public void Enumerator_OfStandardMeasureArray_ReturnsStandardMeasureValues()
		{
			CollectionAssert.AllItemsAreInstancesOfType(_instance, typeof(StandardMeasure<Length>));
		}

		[Test]
		public void Max_OnStandardMeasureArray_ReturnsMaxStandardMeasureFromArray()
		{
			var expected = new StandardMeasure<Length>(0.05);
			var actual = _instance.Max();
			MeasureAssert.MeasuresAreEqual(expected, actual);
		}

		[Test]
		public void ElementAt_RepeatedManyTimes_TimeOperation()
		{
			const int noValues = 10000;
			var measures = new StandardMeasureArray<Length>(new double[noValues]);
			StandardMeasure<Length> measure;
			DateTime start = DateTime.Now;
			for (int i = 0; i < noValues; ++i) measure = measures.ElementAt(i);
			DateTime stop = DateTime.Now;
#if NUNIT24
			Assert.Ignore
#else
			Assert.Pass
#endif
				("Timing: {0} ms", (stop - start).Ticks / 10000);
		}

		#endregion
	}
}
