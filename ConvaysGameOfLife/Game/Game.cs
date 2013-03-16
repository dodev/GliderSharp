using System;

namespace ConvaysGameOfLife.Game
{
	public class Game
	{
		private CellState[,] _gridCurr;
		private CellState[,] _gridNew;
		private int _interval;

		public Game ()
		{
		}

		public void Init (int rows, int cols, int interval)
		{
			_gridCurr = new CellState[rows, cols];
			_gridNew = new CellState[rows,cols];
			_interval = interval;
			//_gridCurr.
		}



		public void Start ()
		{

		}

		public void Stop ()
		{

		}

	}
}

