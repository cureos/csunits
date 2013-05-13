using System;
using Cureos.Measures.Quantities;
using NUnit.Framework;

namespace Cureos.Measures
{
	[TestFixture]
	public class UnitParsingTests
	{
		[Test]
		public void NonGenericParse_ExistingUnit_UnitReturned()
		{
			IUnit cm = Unit.Parse("cm");

			Assert.That(cm, Is.SameAs(Length.CentiMeter));
		}

		[Test]
		public void NonGenericParse_WrongCase_UnitReturned()
		{
			IUnit CM = Unit.Parse("CM");

			Assert.That(CM, Is.SameAs(Length.CentiMeter));
		}

		[Test]
		public void NonGenericParse_NonExistingUnit_Exception()
		{
			Assert.That(() => Unit.Parse("non-existing"),
				Throws.InstanceOf<UnitNotFoundException>()
					.With.Message.StringContaining("non-existing"));
		}

		[Test]
		public void GenericParse_ExistingUnitWithCorrectQuantity_UnitReturned()
		{
			IUnit<Length> cm = Unit.Parse<Length>("cm");

			Assert.That(cm, Is.SameAs(Length.CentiMeter));
		}

		[Test]
		public void GenericParse_WrongCase_UnitReturned()
		{
			IUnit<Length> CM = Unit.Parse<Length>("CM");

			Assert.That(CM, Is.SameAs(Length.CentiMeter));
		}

		[Test]
		public void GenericParse_NonExistingUnit_Exception()
		{
			Assert.That(() => Unit.Parse<Length>("non-existing"),
				Throws.InstanceOf<UnitNotFoundException>()
					.With.Message.StringContaining("non-existing"));
		}

		[Test]
		public void GenericParse_IncorrectQuantity_RuntimeException()
		{
			Assert.That(() => Unit.Parse<Time>("cm"),
				Throws.InstanceOf<InvalidCastException>());
		}
	}
}
