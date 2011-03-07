// Copyright (c) 2011 Anders Gustafsson, Cureos AB.
// All rights reserved. This software and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html

using System;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using Cureos.Measures.Units;
using NUnit.Framework;

namespace Tests.Cureos.Measures
{
	[TestFixture]
	public class TimingTests
	{
		private const int no = 1000000;

		[Test]
		public void TimeDoubleAdditions()
		{
			PerformTiming(() =>
							  {
								  double val = 0.0;
								  for (int i = 0; i < no; ++i)
								  {
									  val += (double) i;
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeMeasureAdditionsSameUnit()
		{
			PerformTiming(() =>
							  {
								  var val = new Measure(0.0, EnumUnit.KiloGram);
								  for (int i = 0; i < no; ++i)
								  {
									  val += new Measure((double) i, EnumUnit.KiloGram);
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeMeasureAdditionsToDifferentUnit()
		{
			PerformTiming(() =>
							  {
								  var val = new Measure(0.0, EnumUnit.KiloGram);
								  for (int i = 0; i < no; ++i)
								  {
									  val += new Measure((double) i, EnumUnit.Gram);
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeGenericMeasureAdditionsSameUnit()
		{
			PerformTiming(() =>
							  {
								  var val = new Measure<Length>(0.0);
								  for (int i = 0; i < no; ++i)
								  {
									  val += new Measure<Length>((double)i);
								  }
								  return val;
							  });
		}

		[Test]
		public void TimeGenericMeasureAdditionsDifferentUnit()
		{
			PerformTiming(() =>
			{
				var val = new Measure<Length, CentiMeter>(0.0);
				for (int i = 0; i < no; ++i)
				{
					val += new Measure<Length>((double)i);
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