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
				if (aliveNeighbours < 2)
					return CellState.DEAD; // dies from loneliness
				else if (aliveNeighbours == 2 || aliveNeighbours == 3)
					return CellState.ALIVE; // just the right amount of living beings around me :)
				else if (aliveNeighbours > 3)
					return CellState.DEAD; // dies from overpopulation
			} else {
				if (aliveNeighbours == 3)
					return CellState.ALIVE; // a new block animal is born :)
			}

			return currState;
		}
		#endregion

	}
}

