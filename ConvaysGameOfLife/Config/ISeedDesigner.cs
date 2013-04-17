using System;

using GliderSharp.Game;

namespace GliderSharp.Config
{
	public interface ISeedDesigner
	{
		//CellState[,] Seed { get; }
		void Init (Configuration conf);

		void Show ();

		event EventHandler<SeedEventArgs> Finished;
	}

}
