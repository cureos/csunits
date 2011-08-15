using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

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
			var pickerViewScalingTransform = new MonoTouch.CoreGraphics.CGAffineTransform(0.6f, 0.0f, 0.0f, 0.6f, 0.0f, 0.0f);
			quantitySelector.Transform = pickerViewScalingTransform;
			fromUnitSelector.Transform = pickerViewScalingTransform;
			toUnitSelector.Transform = pickerViewScalingTransform;
			
			quantitySelector.Model = new QuantityPickerViewModel(fromUnitSelector, toUnitSelector);
			
			window.MakeKeyAndVisible();
	
			return true;
		}
	
		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
}

