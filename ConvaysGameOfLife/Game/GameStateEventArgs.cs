using System;

namespace GliderSharp.Game
{
	public class GameStateEventArgs : EventArgs
	{
		public GameStateEventArgs (GameState state) : base () {
			this.state = state;
		}

		GameState state;

		public GameState State {
			get { return state; }
		}
	}
	
}
