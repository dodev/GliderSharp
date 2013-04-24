using System;

using GliderSharp.Config;
using GliderSharp.Graphics;

namespace GliderSharp.Game
{
	public class GameController : IDisposable
	{
		GameState _st;
		GameHost game;

		GameState state {
			get {
				return _st;
			}
			set {
				_st = value;
				OnStateChanged ();
			}
		}

		public GameController ()
		{
			state = GameState.BLANK;
			game = null;
		}

		public void StartConf ()
		{
			if (state == GameState.BLANK)
				state = GameState.CONFIG;
		}

		public void LoadConfNSurface (Configuration conf, ISurfaceInterpretator surface)
		{
			if (state == GameState.CONFIG) {
				game = new GameHost (conf, surface);
				game.TickFinished += OnGameTickFinished;
				game.Initialized += OnGameInitialized;
				state = GameState.DESIGNER;
			}
		}

		public void LoadSeed (CellState[,] seed)
		{
			if (state == GameState.DESIGNER || state == GameState.RUN) {
				game.AcceptSeed (seed);
				state = GameState.RUN;
			}
		}

		public void LoadFullConf (ISurfaceInterpretator gint, string path)
		{
			if (state == GameState.RUN || state == GameState.DESIGNER)
				game.Dispose ();
			var xmls = new XmlSerializer ();
			var conf = xmls.LoadConfigFromFile (path);
			game = new GameHost (conf, gint);
			game.TickFinished += OnGameTickFinished;
			game.Initialized += OnGameInitialized;
			state = GameState.RUN;
		}

		public void GameStart ()
		{
			if (state == GameState.RUN) {
				game.Start ();
			}
		}

		public void GameStop ()
		{
			if (state == GameState.RUN) {
				game.Stop ();
			}
		}

		public void GamePause ()
		{
			if (state == GameState.RUN) {
				game.Pause ();
			}
		}

		public void CancelConfig ()
		{
			if (state == GameState.CONFIG)
				state = GameState.BLANK;
		}

		public void CancelDesigner ()
		{
			if (state == GameState.DESIGNER) {
				game.Dispose ();
				state = GameState.BLANK;
			}
		}

		public void CancelRun ()
		{
			if (state == GameState.RUN) {
				game.Dispose ();
				state = GameState.BLANK;
			}
		}

		public void SaveConf (string path)
		{
			if (state == GameState.RUN) {
				var xmlserializer = new XmlSerializer ();
				xmlserializer.SaveConfigToFile (game.Config, path);
			}

		}

		public Configuration GetConf ()
		{
			if (state == GameState.RUN) {
				return game.Config;
			}
			return null;
		}

		public event EventHandler<GameStateEventArgs> StateChanged;

		void OnStateChanged ()
		{
			if (StateChanged != null)
				StateChanged (null, new GameStateEventArgs (state));
		}

		public event EventHandler<TickFinishedEventArgs> GameTickFinished;

		void OnGameTickFinished (object sender, TickFinishedEventArgs args)
		{
			if (GameTickFinished != null)
				GameTickFinished (sender, args);
		}

		public event EventHandler<GameInitializedEventArgs> GameInitialized;

		void OnGameInitialized (object sender, GameInitializedEventArgs args)
		{
			if (GameInitialized != null)
				GameInitialized (sender, args);
		}

		#region IDisposable implementation

		public void Dispose ()
		{
			if (game != null)
				game.Dispose ();
		}

		#endregion
	}
}
