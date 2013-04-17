using System;

using GliderSharp.Game;

namespace GliderSharp
{

	public class SeedEventArgs : EventArgs
	{
		CellState[,] seed;
		public SeedEventArgs (CellState[,] seed) : base ()
		{
			this.seed = seed;
		}

		public CellState[,] Seed {
			get { return seed; }
		}
	}
}
