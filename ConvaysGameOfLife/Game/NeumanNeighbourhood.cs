using System;

namespace ConvaysGameOfLife.Game
{
	public class NeumanNeighbourhood : INeighbourStrategy
	{
		private const int maxN = 4;

		public NeumanNeighbourhood ()
		{
		}
		#region INeighbourStrategy implementation
		public System.Collections.Generic.IEnumerable<CellCoordinates> GetNeighbourCells (int row, int col, int rows, int cols)
		{
			//
			//		O					0
			//	O	O	O			1	X	2
			//		O					3	
			//
			int prevRow = row - 1;
			int nextRow = row + 1;
			int prevCol = col - 1;
			int nextCol = col + 1;

			if (prevRow >= 0) {
				// previous row, current column
				yield return new CellCoordinates (prevRow, col);
			}

			if (prevCol >= 0)
				yield return new CellCoordinates (row, prevCol);

			if (nextCol < cols)
				yield return new CellCoordinates (row, nextCol);

			if (nextRow < rows) {
				// next row, current column
				yield return new CellCoordinates (nextRow, col);
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

