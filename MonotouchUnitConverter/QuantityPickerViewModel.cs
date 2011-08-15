using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using Cureos.Measures;

namespace MonotouchUnitConverter
{
	public class QuantityPickerViewModel : UIPickerViewModel
	{
		private IEnumerable<QuantityAdapter> mQuantities;
		private UIPickerView mFromUnitPicker;
		private UIPickerView mToUnitPicker;

		#region CONSTRUCTORS
		
		public QuantityPickerViewModel(UIPickerView iFromUnitPicker, UIPickerView iToUnitPicker)
		{
			mQuantities = QuantityCollection.Quantities.OrderBy(qa => qa.Quantity.ToString());
			mFromUnitPicker = iFromUnitPicker;
			mToUnitPicker = iToUnitPicker;
		}
		
		#endregion
		
		#region OVERRIDDEN METHODS
		
		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}
		
		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			return mQuantities.Count();
		}
		
		public override string GetTitle (UIPickerView picker, int row, int component)
		{
			return mQuantities.ElementAt(row).ToString();
		}
		
		public override void Selected (UIPickerView pickerView, int row, int component)
		{
			var unitsModel = new UnitPickerViewModel(mQuantities.ElementAt(row).Units);
			mFromUnitPicker.Model = unitsModel;
			mToUnitPicker.Model = unitsModel;
			
			mFromUnitPicker.ReloadAllComponents();
			mToUnitPicker.ReloadAllComponents();
		}

		#endregion
	}
}

