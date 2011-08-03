// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Cureos.Measures
{
	[TestFixture]
	public class TimingTests
	{
		private const double no = 1000000;

		[Test]
		public void TimeEmptyLoop()
		{
			PerformTiming(() =>
							  {
								  const double val = 0.0;
								  for (double i = 0.0; i < no; ++i)
								  {
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeDoubleAdditions()
		{
			PerformTiming(() =>
							  {
								  double val = 0.0;
								  for (double i = 0.0; i < no; ++i)
								  {
									  val += i;
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeMeasureAdditionsStandardUnitWithStandardMeasure()
		{
			PerformTiming(() =>
							  {
								  var val = new Measure<Mass>(0.0);
								  for (double i = 0.0; i < no; ++i)
								  {
									  val += new StandardMeasure<Mass>(i);
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeMeasureAdditionsWithDifferentUnit()
		{
			PerformTiming(() =>
							  {
								  var val = new Measure<Mass>(0.0, Mass.KiloGram);
								  for (double i = 0.0; i < no; ++i)
								  {
									  val += new Measure<Mass>(i, Mass.Gram);
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeStandardMeasureAdditions()
		{
			PerformTiming(() =>
							  {
								  var val = new StandardMeasure<Length>(0.0);
								  for (double i = 0.0; i < no; ++i)
								  {
									  val += new StandardMeasure<Length>(i);
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeMeasureAdditionsNonStandardUnitWithStandardMeasure()
		{
			PerformTiming(() =>
			{
				var val = new Measure<Length>(0.0, Length.CentiMeter);
				for (double i = 0.0; i < no; ++i)
				{
					val += new StandardMeasure<Length>(i);
				}
				return val;
			});
		}

		private static void PerformTiming(Func<object> a)
		{
			DateTime start = DateTime.Now;
			var val = a.Invoke();
			DateTime stop = DateTime.Now;

#if NUNIT24
			Assert.Ignore
#else
			Assert.Pass
#endif
				("Sum: {0}, timing {1} ms", val, (stop.Ticks - start.Ticks) / 10000);
		}
	}
}