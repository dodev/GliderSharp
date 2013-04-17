using System;
using System.Collections.Generic;

namespace GliderSharp.Game
{
	public class MooreCyclicNeighbourhood : INeighbourStrategy
	{
		private const int maxN = 8;

		public MooreCyclicNeighbourhood ()
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

			if (prevRow == -1)
				prevRow = rows - 1;

			if (nextRow == rows)
				nextRow = 0;

			if (prevCol == -1)
				prevCol = cols - 1;

			if (nextCol == cols)
				nextCol = 0;


			yield return new CellCoordinates (prevRow, prevCol);

			// previous row, current column
			yield return new CellCoordinates (prevRow, col);

			yield return new CellCoordinates (prevRow, nextCol);

			yield return new CellCoordinates (row, prevCol);

			yield return new CellCoordinates (row, nextCol);

			yield return new CellCoordinates (nextRow, prevCol);

			// next row, current column
			yield return new CellCoordinates (nextRow, col);

			yield return new CellCoordinates (nextRow, nextCol);
		}

		public int MaxNeighbours {
			get {
				return maxN;
			}
		}
		#endregion

		public string ToString (bool full)
		{
			if (full)
				return "Moore's cyclic neighbourhood";
			else
				return "Moore's cyclic";
		}

		public override string ToString ()
		{
			return ToString (false);
		}
	}
}

