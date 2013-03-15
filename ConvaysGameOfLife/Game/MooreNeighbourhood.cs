using System;
using System.Collections.Generic;

namespace ConvaysGameOfLife.Game
{
	public class MooreNeighbourhood : INeighbourStrategy
	{
		private const int maxN = 8;

		public MooreNeighbourhood ()
		{
		}

		#region INeighbourStrategy implementation
		public IEnumerable<CellCoordinates> GetNeighbourCells (int row, int col, int rows, int cols)
		{
			//
			//	O	O	O			0	1	2
			//	O	O	O			3	X	4
			//	O	O	O			5	6	7
			//
			int prevRow = row - 1;
			int nextRow = row + 1;
			int prevCol = col - 1;
			int nextCol = col + 1;

			if (prevRow >= 0) {
				if (prevCol >= 0)
					yield return new CellCoordinates (prevRow, prevCol);

				// previous row, current column
				yield return new CellCoordinates (prevRow, col);

				if (nextCol >= 0)
					yield return new CellCoordinates (prevRow, nextCol);
			}

			if (prevCol >= 0)
				yield return new CellCoordinates (row, prevCol);

			if (nextCol >= 0)
				yield return new CellCoordinates (row, nextCol);

			if (nextRow >= 0) {
				if (prevCol >= 0)
					yield return new CellCoordinates (nextRow, prevCol);

				// next row, current column
				yield return new CellCoordinates (nextRow, col);

				if (nextCol >= 0)
					yield return new CellCoordinates (nextRow, nextCol);
			}
		}

		public int MaxNeighbours {
			get {
				return maxN;
			}
		}
		#endregion

	}
}

