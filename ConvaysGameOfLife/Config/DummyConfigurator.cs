using System;

namespace ConvaysGameOfLife.Config
{
	public class DummyConfigurator : IConfigurator
	{
		private Configuration conf;
		private static string[] strSeed = {
			"01000000001001001000",
			"10101000000010010100",
			"00011010010001010000",
			"00001000010000000000",
			"00000000000100010000",
			"00100010000010001010",
			"01010010001000101010",
			"00111100001001001000",
			"00000001000101010000",
			"10000001100100001000",
			"00000010010101100000",
			"11000001000001000100",
			"00001001000100100000",
			"00100010001001110000",
			"10110001000100001000",
			"00100000100100010000",
			"00010001000010010010",
			"00001000100100000100",
			"00011001001100010000",
			"10000010100010010001"
		};

		public DummyConfigurator ()
		{
			conf = new Configuration ();
			conf.Cols = 20;
			conf.Rows = 20;
			conf.Neighbourhood = new Game.MooreNeighbourhood ();
			conf.Rules = new Game.ConwaysRules ();
			conf.TickInterval = 500;
			conf.Seed = PopulateGrid ();
		}

		private Game.CellState[,] PopulateGrid ()
		{
			if (strSeed.Length != 20)
				throw new Exception ("dummy configurator broke. The seed array does not conform with the restrictions.");

			Game.CellState[,] grid = new Game.CellState[20, 20];
			for (int i = 0; i < 20; i++) {
				for (int j = 0; j < 20; j++) {
					grid[i,j] = (strSeed[i][j] == '1') ? Game.CellState.ALIVE : Game.CellState.DEAD;
				}
			}

			return grid;
		}

		#region IConfigurator implementation
		public Configuration Config {
			get {
				return conf;
			}
		}
		#endregion

	}
}

