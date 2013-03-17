using System;

namespace ConvaysGameOfLife.Game
{
	public class ConwaysRules : IRule
	{
		public ConwaysRules ()
		{
		}

		#region IRule implementation
		public CellState CheckCell (RegularGrid<CellState> grid, int row, int col)
		{
			int aliveNeighbours = 0;

			foreach (CellState state in grid.GetNeighboursCellValues (row, col)) {
				if (state == CellState.ALIVE)
					aliveNeighbours++;
			}

			CellState currState = grid [row, col];

			if (currState == CellState.ALIVE) {
				// a cell with 2 or 3 alive neighbours lives on
				if (aliveNeighbours < 2 || aliveNeighbours > 3)
					return CellState.DEAD; // dies from loneliness or overpopulation
			} else {
				if (aliveNeighbours == 3)
					return CellState.ALIVE; // a new ALIVE block is born :)
			}

			return currState;
		}
		#endregion

	}
}

