using System;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Cureos.Measures
{
	[TestFixture]
	public class MeasureCreationTests
	{
		[Test]
		public void NonGenericFrom_ExistingUnit_Measure()
		{
			IMeasure tenFeet = Measure.From(10d, "ft");

			Assert.That(tenFeet, Is.EqualTo(new Measure<Length>(10d, Length.Foot)));
		}

		[Test]
		public void NonGenericFrom_MissingUnit_Exception()
		{
			Assert.That(()=> Measure.From(10d, "non-existing"),
				Throws.InstanceOf<UnitNotFoundException>());
		}

		[Test]
		public void GenericFrom_ExistingUnit_Measure()
		{
			IMeasure<Length> tenFeet = Measure.From<Length>(10d, "ft");

			Assert.That(tenFeet, Is.EqualTo(new Measure<Length>(10d, Length.Foot)));
		}

		[Test]
		public void GenericFrom_MissingUnit_Exception()
		{
			Assert.That(() => Measure.From<Length>(10d, "non-existing"),
				Throws.InstanceOf<UnitNotFoundException>());
		}

		[Test]
		public void GenericFrom_IncorrectQuantity_RuntimeException()
		{
			Assert.That(() => Measure.From<Time>(10d, "cm"),
				Throws.InstanceOf<InvalidCastException>());
		}
	}
}
