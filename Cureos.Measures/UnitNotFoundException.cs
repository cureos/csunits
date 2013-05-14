using System;

namespace Cureos.Measures
{
	//[System.Serializable]
	public class UnitNotFoundException : ArgumentException
	{
		public UnitNotFoundException() {}
		public UnitNotFoundException(string message) : base(message) {}
		public UnitNotFoundException(string message, string paramName) : base(message, paramName) {}
		public UnitNotFoundException(string message, Exception inner) : base(message, inner) {}
		//protected UnitNotFoundException(System.Runtime.Serialization.SerializationInfo info, StreamingContext context) : base(info, context) {}

		public static UnitNotFoundException Default(string toBeParsed, string paramName)
		{
			string message = string.Format("Unit '{0}' could not be parsed.", toBeParsed);
			return new UnitNotFoundException(message, paramName);
		}
	}
}