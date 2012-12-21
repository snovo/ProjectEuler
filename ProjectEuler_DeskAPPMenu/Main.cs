using System;
//using System.Windows.Forms;
using Gtk;

namespace ProjectEuler_DeskAPPMenu
{
	class MainClass
	{
		[STAThread]
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();

			//Application.EnableVisualStyles();
			//Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Janela());

		}
	}
}
