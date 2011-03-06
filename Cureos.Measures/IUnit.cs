using System;
namespace Cureos.Measures
{
	public interface IUnit<Q> where Q : struct, IQuantity
	{
		Unit EnumeratedValue { get; }
	}
}

