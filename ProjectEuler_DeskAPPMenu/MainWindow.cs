using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		ProjectEuler_DeskAPPMenu.ProjectEuler_Questions q = new ProjectEuler_DeskAPPMenu.ProjectEuler_Questions("http://www.projecteuler.net/problem=");
		string s = q.GetQuestion (100);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
