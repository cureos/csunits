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
		
		public QuantityPickerViewModel(UIPickerView iQuantityPicker, UIPickerView iFromUnitPicker, UIPickerView iToUnitPicker)
		{
			mQuantities = QuantityCollection.Quantities.OrderBy(qa => qa.Quantity.ToString());
			mFromUnitPicker = iFromUnitPicker;
			mToUnitPicker = iToUnitPicker;
			
			Selected(iQuantityPicker, 0, 0);
		}
		
		#endregion
		
		#region EVENTS
		
		public event EventHandler UnitPickerUnitChanged;
		
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
		
		public override void Selected(UIPickerView pickerView, int row, int component)
		{
			var fromUnitModel = mFromUnitPicker.Model as UnitPickerViewModel;
			if (fromUnitModel != null) fromUnitModel.UnitChanged -= OnUnitPickerUnitChanged;
			fromUnitModel = new UnitPickerViewModel(mFromUnitPicker, mQuantities.ElementAt(row).Units);
			fromUnitModel.UnitChanged += OnUnitPickerUnitChanged;
			mFromUnitPicker.Model = fromUnitModel;
			mFromUnitPicker.ReloadAllComponents();
			mFromUnitPicker.Select(0, 0, true);
			
			var toUnitModel = mToUnitPicker.Model as UnitPickerViewModel;
			if (toUnitModel != null) toUnitModel.UnitChanged -= OnUnitPickerUnitChanged;
			toUnitModel = new UnitPickerViewModel(mToUnitPicker, mQuantities.ElementAt(row).Units);
			toUnitModel.UnitChanged += OnUnitPickerUnitChanged;
			mToUnitPicker.Model = toUnitModel;			
			mToUnitPicker.ReloadAllComponents();
			mToUnitPicker.Select(0, 0, true);
			
			fromUnitModel.Selected(mFromUnitPicker, 0, 0);
			toUnitModel.Selected(mToUnitPicker, 0, 0);
		}

		private void OnUnitPickerUnitChanged(object sender, EventArgs e)
		{
			if (UnitPickerUnitChanged != null) UnitPickerUnitChanged(sender, e);
		}

		#endregion
	}
}

