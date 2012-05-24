using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonotouchUnitConverter
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow _window;
		UINavigationController _nav;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			_window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			var converter = new UnitConverter();
			var bctx = new BindingContext (null, converter, "Cureos Unit Converter");
			var dvc = new DialogViewController (bctx.Root);
			   
			_nav = new UINavigationController(dvc);
			_window.RootViewController = _nav;
			
			// make the window visible
			_window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}
