using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Cureos.Measures;

namespace MonotouchUnitConverter
{
    using Cureos.Measures.Collections;

    // The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		private UIWindow _window;
		private UINavigationController _nav;
		private DialogViewController _rootVC;
		private RootElement _rootElement;

		private RadioGroup _quantityGroup;
		private RadioGroup _fromUnitGroup;
		private RadioGroup _toUnitGroup;
		
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			_window = new UIWindow (UIScreen.MainScreen.Bounds);

			_quantityGroup = new RadioGroup("Qty", 0);
			_fromUnitGroup = new RadioGroup("FromU", 0);
			_toUnitGroup = new RadioGroup("ToU", 0);
			
			var quantityRootElement = new RootElement("Quantity", _quantityGroup) { new Section() };
			quantityRootElement[0].AddAll(QuantityCollection.Quantities.Select(qty => {
				var elem = new EventHandlingRadioElement(qty.Quantity.DisplayName, "Qty");
				elem.OnSelected += OnQuantitySelected;
				return elem as Element;
			}));
			
			_rootElement = new RootElement ("Unit Converter")
			{
				new Section() { quantityRootElement }, 
				new Section("From") { new EntryElement("Amount", string.Empty, string.Empty), 
					new RootElement("Unit", _fromUnitGroup) { new Section() } },
				new Section("To") { new EntryElement("Amount", string.Empty, string.Empty), 
					new RootElement("Unit", _toUnitGroup) { new Section() } }
			};

			_rootVC = new DialogViewController(_rootElement);
			_nav = new UINavigationController(_rootVC);

			_window.RootViewController = _nav;
			_window.MakeKeyAndVisible();
			   
			return true;
		}
		
		private void OnQuantitySelected(object sender, EventArgs e)
		{
			var root = _rootElement[1][1] as RootElement;
			root[0].Clear();
			var qtyIdx = _quantityGroup.Selected;
			var units = QuantityCollection.Quantities.ElementAt(qtyIdx).Units;
			root[0].AddAll(units.Select(unit => new EventHandlingRadioElement(unit.Symbol, "FromU") as Element));
		}
	}
}
