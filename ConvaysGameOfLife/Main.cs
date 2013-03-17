using System;
using Gtk;

using ConvaysGameOfLife.Game;
using ConvaysGameOfLife.Config;

namespace ConvaysGameOfLife
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IConfigurator configurator = new DummyConfigurator ();
			GameHost game = new GameHost (configurator.Config);

			Application.Init ();
			MainWindow win = new MainWindow (game);
			win.Show ();
			Application.Run ();

			game.Dispose ();
		}
	}
}
