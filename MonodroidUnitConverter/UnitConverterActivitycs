using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using Activity = Android.App.Activity;

namespace MonodroidUnitConverter
{
	[Activity (Label = "MonodroidUnitConverter", MainLauncher = true)]
	public class UnitConverterActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
		    base.OnCreate (bundle);
		            
		    var tv = new TextView (this);
		    tv.Text = new Measure<Length>(30.0, Length.CentiMeter).ToString();
		
		    SetContentView (tv);
		}
	}
}


