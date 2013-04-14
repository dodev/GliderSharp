using System;

using ConvaysGameOfLife.Game;

namespace ConvaysGameOfLife
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
