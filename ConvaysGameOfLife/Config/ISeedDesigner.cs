using System;

using ConvaysGameOfLife.Game;

namespace ConvaysGameOfLife.Config
{
	public interface ISeedDesigner
	{
		//CellState[,] Seed { get; }
		void Init (Configuration conf);

		void Show ();

		event EventHandler<SeedEventArgs> Finished;
	}

}
