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
			IConfigurator configurator = new RandomConfigurator (60, 80, 0.25d);
			//IConfigurator configurator = new DummyConfigurator ();
			GameHost game = new GameHost (configurator.Config);

			Application.Init ();
			//MainWindow win = new MainWindow (game);
			//win.Show ();

			MainMenu menu = new MainMenu ();
			menu.Show ();
			Application.Run ();

			game.Dispose ();
		}
	}
}
