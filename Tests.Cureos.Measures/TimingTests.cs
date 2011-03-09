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
	public class TimingTests
	{
		private const double no = 1000000;

		[Test]
		public void TimeEmptyLoop()
		{
			PerformTiming(() =>
							  {
								  double val = 0.0;
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
		public void TimeMeasureAdditionsSameUnit()
		{
			PerformTiming(() =>
							  {
								  var val = new Measure<Mass>(0.0, Units.KiloGram);
								  for (double i = 0.0; i < no; ++i)
								  {
									  val += new ReferenceMeasure<Mass>(i);
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeMeasureAdditionsToDifferentUnit()
		{
			PerformTiming(() =>
							  {
								  var val = new Measure<Mass>(0.0, Units.KiloGram);
								  for (double i = 0.0; i < no; ++i)
								  {
									  val += new Measure<Mass>(i, Units.Gram);
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeGenericMeasureAdditionsSameUnit()
		{
			PerformTiming(() =>
							  {
								  var val = new ReferenceMeasure<Length>(0.0);
								  for (double i = 0.0; i < no; ++i)
								  {
									  val += new ReferenceMeasure<Length>(i);
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeGenericMeasureAdditionsDifferentUnit()
		{
			PerformTiming(() =>
			{
				var val = new Measure<Length>(0.0, Units.CentiMeter);
				for (double i = 0.0; i < no; ++i)
				{
					val += new ReferenceMeasure<Length>(i);
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