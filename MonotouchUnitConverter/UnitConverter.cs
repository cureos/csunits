using System;
using MonoTouch.Dialog;

namespace MonotouchUnitConverter
{
	public class UnitConverter
	{
		[Section("Quantity")]
		
		[Entry("Enter expense name")]
		public string Name;
		
		[Section("Expense Details")]
		
		[Caption("Description")]
		[Entry]
		public string Details;
		
		[Checkbox]
		public bool IsApproved = true;
	}
}

