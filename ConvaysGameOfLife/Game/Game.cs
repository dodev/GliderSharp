using System;
using System.Threading;
using System.Collections.Generic;

using ConvaysGameOfLife.Config;

namespace ConvaysGameOfLife.Game
{
	public class Game
	{
		private Configuration conf;
		private RegularGrid<CellState> grid1;
		private RegularGrid<CellState> grid2;
		private bool initialized;
		private Thread gameThread;

		public Game (Configuration conf)
		{
			this.conf = conf;
			initialized = false;
			gameThread = new Thread (this.Worker);
		}

		public void Init ()
		{
			NeighbourContext nCtx = new NeighbourContext (conf.Neighbourhood, conf.Rows, conf.Cols);
			grid1 = new RegularGrid<CellState> (conf.Rows, conf.Cols, nCtx, conf.Seed);
			grid1 = new RegularGrid<CellState> (conf.Rows, conf.Cols, nCtx);

			initialized = true;
		}



		public void Start ()
		{
			//if (!initialized)
			//	throw new Exception ("You need to initialize the game first");

			gameThread.Start ();

		}

		public void Pause ()
		{
			gameThread.Abort ();
		}

		public void Stop ()
		{
			gameThread.Abort ();
		}


		private void Worker ()
		{
			if (! initialized)
				this.Init ();

			RegularGrid<CellState> bufGrid;
			CellState bufState;
			// list of cells that need to be drawn with state ALIVE
			List<CellCoordinates> pointsToDraw = new List<CellCoordinates> (); // TODO: init with a proper size

			// the game loop
			for (;;) {
				// begining of a tick

				for (int i = 0; i < conf.Rows; i++) {
					for (int j = 0; j < conf.Cols; j++) {
						bufState = conf.Rules.CheckCell (grid1, i, j);

						// if in the cell there is someting alive, we should draw it
						if (bufState == CellState.ALIVE)
							pointsToDraw.Add (new CellCoordinates (i,j));

						// write the state to the future grid
						grid2[i,j] = bufState;
					}
				}

				// TODO: generate "to display array"

				// the list is no longer neede
				pointsToDraw.Clear ();

				// changing references places
				// since the game current state depends on its past state, we perserve
				// the past state in grid1 and write in grid2 the current
				// that is, offcourse, for the next iteration
				bufGrid = grid1;
				grid1 = grid2;
				grid2 = bufGrid;

				// pause the tread for a while :)
				Thread.Sleep (conf.TickInterval);
			}
		}
	}
}

