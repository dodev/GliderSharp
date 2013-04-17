using System;

namespace GliderSharp.Game
{
	public interface IRule
	{
		CellState CheckCell (RegularGrid<CellState> grid, int row, int col);
	}
}

