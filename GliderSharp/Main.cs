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
			RunWindow win = new RunWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
