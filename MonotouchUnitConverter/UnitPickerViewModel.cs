using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using Cureos.Measures;

namespace MonotouchUnitConverter
{
	public class UnitPickerViewModel : UIPickerViewModel
	{
		private IEnumerable<IUnit> mUnits;
		
		# region CONSTRUCTORS
		
		public UnitPickerViewModel(IEnumerable<IUnit> iUnits)
		{
			mUnits = iUnits;
		}
		
		#endregion
		
		#region OVERRIDDEN METHODS
		
		public override int GetComponentCount (UIPickerView picker)
		{
			return 1;
		}
		
		public override int GetRowsInComponent (UIPickerView picker, int component)
		{
			return mUnits.Count();
		}
		
		public override string GetTitle (UIPickerView picker, int row, int component)
		{
			return mUnits.ElementAt(row).Symbol;
		}
		
		#endregion
	}
}

