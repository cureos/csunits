using System;
using System.Linq;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Cureos.Measures;
using Cureos.Measures.Quantities;
using Activity = Android.App.Activity;

namespace MonodroidUnitConverter
{
	[Activity (Label = "Monodroid Unit Converter", MainLauncher = true)]
	public class UnitConverterActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
		    base.OnCreate (bundle);

			var adapter = new ArrayAdapter<QuantityAdapter>(this, Android.Resource.Layout.SimpleSpinnerItem, 
				QuantityCollection.Quantities.ToArray());
			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			
			var spinner = new Spinner(this);
			spinner.Adapter = adapter;
			
		    SetContentView(spinner);
		}
	}
}


