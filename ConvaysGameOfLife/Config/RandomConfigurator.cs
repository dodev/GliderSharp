using System;

using ConvaysGameOfLife.Game;

namespace ConvaysGameOfLife.Config
{
	public class RandomConfigurator : IConfigurator
	{
		private Configuration conf;
		public RandomConfigurator (int rows, int cols, double concentration)
		{
			conf = new Configuration ();
			conf.Cols = cols;
			conf.Rows = rows;
			conf.Neighbourhood = new Game.MooreCyclicNeighbourhood ();
			conf.Rules = new Game.ConwaysRules ();
			conf.TickInterval = 100;

			// populating the seed
			CellState[,] seed = new CellState[rows, cols];
			Random rand = new Random ();
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < cols; j++) {
					seed[i,j] = (rand.NextDouble () < concentration) ? CellState.DEAD : CellState.ALIVE;
				}
			}

			conf.Seed = seed;
		}

		//public CellState[,] PopulateGrid () {
		//
		//}

		#region IConfigurator implementation
		public Configuration Config {
			get {
				return conf;
			}
		}
		#endregion

	}
}

