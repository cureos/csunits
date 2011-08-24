using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cureos.Measures;

namespace MonotouchUnitConverter
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}
	
	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			var quantityPickerViewScalingTransform = new MonoTouch.CoreGraphics.CGAffineTransform(0.8f, 0.0f, 0.0f, 0.8f, 0.0f, 0.0f);
			quantitySelector.Transform = quantityPickerViewScalingTransform;

			var unitPickerViewScalingTransform = new MonoTouch.CoreGraphics.CGAffineTransform(0.6f, 0.0f, 0.0f, 0.6f, 0.0f, 0.0f);
			fromUnitSelector.Transform = unitPickerViewScalingTransform;
			toUnitSelector.Transform = unitPickerViewScalingTransform;
			
			var quantityModel = new QuantityPickerViewModel(quantitySelector, fromUnitSelector, toUnitSelector);
			quantityModel.UnitPickerUnitChanged += OnAmountUnitValuesChanged;
			quantitySelector.Model = quantityModel;

			fromAmountEditor.Ended += OnAmountUnitValuesChanged;
			fromAmountEditor.ShouldReturn = delegate { return fromAmountEditor.ResignFirstResponder(); };
			
			using (var myImage = new UIImageView(new RectangleF(2f, 24f, 60f, 52f)))
			{
			    myImage.Image = UIImage.FromFile("Assets/cureos-symbol.png");
			    myImage.Opaque = true;
			    window.AddSubview(myImage);
			}
			
			window.MakeKeyAndVisible();
	
			return true;
		}
	
		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}

		private void OnAmountUnitValuesChanged (object sender, EventArgs e)
		{
			double fromAmount;
			IUnit fromUnit, toUnit;
			if (Double.TryParse(fromAmountEditor.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out fromAmount) &&
				(fromUnit = (fromUnitSelector.Model as UnitPickerViewModel).SelectedUnit) != null &&
				(toUnit = (toUnitSelector.Model as UnitPickerViewModel).SelectedUnit) != null)
			{
                toAmountEditor.Text =
                    toUnit.AmountFromStandardUnitConverter(fromUnit.AmountToStandardUnitConverter(fromAmount)).ToString(
                        CultureInfo.CurrentCulture);
			}
		}
	}
}

