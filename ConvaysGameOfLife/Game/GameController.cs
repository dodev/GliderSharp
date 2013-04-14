using System;

using ConvaysGameOfLife.Config;
using ConvaysGameOfLife.Graphics;

namespace ConvaysGameOfLife.Game
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
				state = GameState.DESIGNER;
			}
		}

		public void LoadSeed (CellState[,] seed)
		{
			if (state == GameState.DESIGNER) {
				game.AcceptSeed (seed);
				state = GameState.RUN;
			}
		}

		public void LoadFullConf (Configuration conf, ISurfaceInterpretator gint)
		{
			if (state == GameState.RUN || state == GameState.DESIGNER)
				game.Dispose ();

			game = new GameHost (conf, gint);
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

		public event EventHandler<GameStateEventArgs> StateChanged;

		void OnStateChanged ()
		{
			if (StateChanged != null)
				StateChanged (null, new GameStateEventArgs (state));
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
