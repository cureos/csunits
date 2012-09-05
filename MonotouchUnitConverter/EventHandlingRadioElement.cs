using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace MonotouchUnitConverter
{
	public class EventHandlingRadioElement : RadioElement
	{
	    public EventHandlingRadioElement (string caption, string group) : base (caption, group) {}
	
	    public override void Selected (DialogViewController dvc, UITableView tableView, NSIndexPath path)
	    {
	        base.Selected (dvc, tableView, path);
	        var selected = OnSelected;
	        if (selected != null)
	            selected (this, EventArgs.Empty);
	    }
	
	    public event EventHandler<EventArgs> OnSelected;
	}
}

