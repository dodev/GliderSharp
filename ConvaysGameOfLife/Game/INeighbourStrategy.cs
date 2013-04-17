using System;
using System.Collections.Generic;

namespace GliderSharp.Game
{
	public interface INeighbourStrategy
	{
		IEnumerable<CellCoordinates> GetNeighbourCells (int row, int col, int rows, int cols);
		int MaxNeighbours {get;}
	}
}

