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
		
		public UnitPickerViewModel(UIPickerView iUnitPicker, IEnumerable<IUnit> iUnits)
		{
			mUnits = iUnits;
		}
		
		#endregion
		
		#region AUTO-IMPLEMENTED PROPERTIES
		
		public IUnit SelectedUnit { get; private set; }
		
		#endregion
		
		#region EVENTS
		
		public event EventHandler UnitChanged;
		
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
		
		public override void Selected (UIPickerView picker, int row, int component)
		{
			SelectedUnit = mUnits.ElementAt(row);
			if (UnitChanged != null) UnitChanged(this, EventArgs.Empty);
		}
		
		#endregion
	}
}

