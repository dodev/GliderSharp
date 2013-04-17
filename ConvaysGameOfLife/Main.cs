using System;
using Gtk;

using GliderSharp.Game;
using GliderSharp.Config;

namespace GliderSharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
