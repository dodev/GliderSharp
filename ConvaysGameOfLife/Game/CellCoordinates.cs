using System;

namespace GliderSharp.Game
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

		// there won't be collision if the grid is less than 1000x1000 big
		public override int GetHashCode ()
		{
			return row * 1000 + col;
		}
	}
}

