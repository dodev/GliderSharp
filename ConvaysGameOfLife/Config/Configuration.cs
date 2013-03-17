using System;
using ConvaysGameOfLife.Game;

namespace ConvaysGameOfLife.Config
{
	public class Configuration
	{
		private int rows;
		private int cols;
		private CellState[,] seed;
		private INeighbourStrategy neighbourhood;
		private IRule rules;
		private int tickInterval;

		public Configuration ()
		{
			this.rows = 0;
			this.cols = 0;
			this.seed = null;
			this.neighbourhood = null;
			this.rules = null;
			this.tickInterval = 0;
		}

		public Configuration (int rows, int cols,
		               CellState[,] seed,
		               INeighbourStrategy neighbourhood,
		               IRule rules, int tickInterval)
		{
			this.rows = rows;
			this.cols = cols;
			this.seed = seed;
			this.neighbourhood = neighbourhood;
			this.rules = rules;
			this.tickInterval = tickInterval;
		}

		public int Rows {
			get { return rows; }
			set {
				if (value > 1) // TODO: check for max value
					rows = value;
			}
		}

		public int Cols {
			get { return cols; }
			set {
				if (value > 1)
					cols = value;
			}
		}

		public CellState[,] Seed {
			get { return seed; }
			set { seed = value; }
		}

		public INeighbourStrategy Neighbourhood {
			get { return neighbourhood; }
			set { neighbourhood = value; }
		}

		public IRule Rules {
			get { return rules; }
			set { rules = value; }
		}

		public int TickInterval {
			get { return tickInterval; }
			set {
				if (value > 0)
					tickInterval = value;
			}
		}

		public void SetSeedsCell (int row, int col, CellState state) {
			seed[row, col] = state;
		}
	}
}

