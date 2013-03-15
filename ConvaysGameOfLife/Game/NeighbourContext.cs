using System;
using System.Collections.Generic;

namespace ConvaysGameOfLife.Game
{
	public class NeighbourContext
	{
		private INeighbourStrategy strategy;
		private CellCoordinates[,,] neighbours;
		private int cols;
		private int rows;

		public NeighbourContext (INeighbourStrategy strategy, int rows, int cols)
		{
			this.strategy = strategy;
			this.rows = rows;
			this.cols = cols;

			neighbours = new CellCoordinates[rows, cols, strategy.MaxNeighbours];

			// populateing the neighbours matrix
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < cols; j++)
					this.PopulateNeighboursInfo (i, j);
			}
		}

		private void PopulateNeighboursInfo (int row, int col)
		{
			int counter = 0;
			foreach (CellCoordinates cord in strategy.GetNeighbourCells (row, col, rows, cols)) {
				neighbours [row,col,counter] = cord;

				if (++counter >= strategy.MaxNeighbours)
					break;
			}
		}

		public int GetMaxNeighbours ()
		{
			return strategy.MaxNeighbours;
		}

		public IEnumerable<CellCoordinates> GetNeighboursOf (int row, int col)
		{
			for (int z = 0; z < strategy.MaxNeighbours; z++) {
				if (neighbours [row, col, z] != null)
					yield return neighbours [row, col, z];
				else
					yield break;
			}
		}
	}
}

