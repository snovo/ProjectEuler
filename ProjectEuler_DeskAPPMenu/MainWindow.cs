using System;
using Gtk;
using Glade;
using System.Threading;

public partial class MainWindow: Gtk.Window
{	
	private Thread _threadQ = null, _threadR = null;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}   


	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void btnSolve_Clicked (object sender, EventArgs e)
	{
		ProjectEuler_DeskAPPMenu.ProjectEuler_Questions q = new ProjectEuler_DeskAPPMenu.ProjectEuler_Questions("http://www.projecteuler.net/problem=");

		_threadQ = new Thread(() => 
		                      {
			textview1.Buffer.Text = q.GetQuestion (Int32.Parse (entry3.Text));
		});

		_threadR = new Thread(() => 
		                      {
			label1.Text = ProjectEuler.CheckSolution.SolveProblem (Int32.Parse (entry3.Text)).ToString ();
		});
		
		textview1.Buffer.Text = "Loading question...";
		//textview1.Buffer.Text = q.GetQuestion (Int32.Parse (entry3.Text));
		_threadQ.Start ();
		label1.Text = "Solving problem...";	
		//label1.Text = ProjectEuler.CheckSolution.SolveProblem (Int32.Parse (entry3.Text)).ToString ();
		_threadR.Start ();
	
	}

}
