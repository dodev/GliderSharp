using System;

namespace ConvaysGameOfLife.Game
{
	public class CellCoordinates
	{
		int row;
		int col;

		public CellCoordinates (int row, int col)
		{
			this.row = row;
			this.col = col;
		}

		public int Row {
			get { return row; }
		}

		public int Col {
			get { return col; }
		}
	}
}

