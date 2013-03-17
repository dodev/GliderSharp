using System;
using System.Collections.Generic;

namespace ConvaysGameOfLife.Game
{
	public class RegularGrid <CellType>
	{
		private CellType[,] grid;
		private int rows;
		private int cols;
		private NeighbourContext komshi;

		public RegularGrid (int rows, int cols, NeighbourContext nCtx)
		{
			// init private fields
			this.rows = rows;
			this.cols = cols;
			this.komshi = nCtx;

			// createing the grid itself
			grid = new CellType[rows, cols];
		}

		public RegularGrid (int rows, int cols, NeighbourContext nCtx, CellType[,] seed)
		{
			// init private fields
			this.rows = rows;
			this.cols = cols;
			this.komshi = nCtx;

			// createing the grid itself
			grid = seed;
		}

		public void WipeWith (CellType val)
		{
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < cols; j++)
					grid[i,j] = val;
			}
		}

		public CellType this [int i, int j] {
			get {
				return grid [i, j];
			}
			set {
				grid [i,j] = value;
			}
		}

		public CellType this [CellCoordinates c] {
			get {
				return grid [c.Row, c.Col];
			}
			set {
				grid [c.Row, c.Col] = value;
			}
		}

		public IEnumerable<CellType> GetNeighboursCellValues (int row, int col)
		{
			foreach (CellCoordinates c in komshi.GetNeighboursOf (row, col)) {
				yield return grid [c.Row, c.Col];
			}
		}
	}
}

