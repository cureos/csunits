using System;
using Cureos.Measures.Quantities;

namespace Cureos.Measures
{
	public struct Meter : IUnit<Length>
	{
		public Unit EnumeratedValue
		{
			get { return Unit.Meter; }
		}
	}
}

