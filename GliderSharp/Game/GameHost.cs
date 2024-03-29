using System;
using System.Threading;
using System.Collections.Generic;

using GliderSharp.Config;
using GliderSharp.Graphics;

namespace GliderSharp.Game
{
	public class GameHost : IDisposable
	{
		private Configuration initConf;
		private Configuration conf;

		private RegularGrid<CellState> grid1;
		private RegularGrid<CellState> grid2;

		private GraphicsEngine gEngine;
		private ISurfaceInterpretator gInterpretator;

		private Thread gameThread;

		private bool isStarted;
		private bool isInitialized;

		private int ticks;

		public GameHost (Configuration conf, ISurfaceInterpretator gint)
		{
			initConf = conf;

			gEngine = new GraphicsEngine (conf);
			gInterpretator = gint;
			gEngine.ShowBorder = true;

			isInitialized = false;
			isStarted = false;

			if (initConf.Seed != null)
				DrawInitial ();
		}

		public void AcceptSeed (CellState[,] seed)
		{
			if (seed != null) {
				initConf.Seed = seed;
				DrawInitial ();
			}
		}

		public Configuration Config {
			get { return initConf; }
		}

		void DrawInitial ()
		{
			List<CellCoordinates> pointsToDraw = new List<CellCoordinates> (); // TODO: init with a proper size
			for (int i = 0; i < initConf.Rows; i++) {
				for (int j = 0; j < initConf.Cols; j++) {
					if (initConf.Seed[i,j] == CellState.ALIVE)
						pointsToDraw.Add (new CellCoordinates(i, j));
				}
			}

			System.Drawing.Image frame = gEngine.DrawBlocks (pointsToDraw);
			// draw it on the surface
			gInterpretator.UpdateSurface (frame);
			// and throw it away
			frame.Dispose ();
		}

		void Init ()
		{
			conf = initConf.Clone () as Configuration; // reset the configuration

			NeighbourContext nCtx = new NeighbourContext (conf.Neighbourhood, conf.Rows, conf.Cols);

			grid1 = new RegularGrid<CellState> (conf.Rows, conf.Cols, nCtx, conf.Seed);
			grid2 = new RegularGrid<CellState> (conf.Rows, conf.Cols, nCtx);

			ticks = 0;

			OnInitialized ();

			isInitialized = true;
		}

		public bool Start ()
		{
			if (!isStarted) {
				gameThread = new Thread (new ThreadStart(this.Worker)); // create a new thread
				gameThread.Start ();
				isStarted = true;
				return true;
			}
			return false;
		}

		// TODO: stop and pause properly
		public void Pause ()
		{
			if (gameThread.IsAlive) {
				//gameThread.
			} else {
				//gameThread.Resume ();
			}
		}

		/// <summary>
		/// Stop and resets the game
		/// </summary>
		public bool Stop ()
		{
			if (isStarted) {
				gameThread.Abort ();
				gameThread.Join (); // wait for it to finish

				isStarted = false;
				isInitialized = false;
				return true;
			}
			return false;
		}

		private void Worker ()
		{
			if (! isInitialized)
				this.Init ();

			if (gInterpretator == null)
				throw new Exception ("The game host needs a surface interpretator to draw its results");

			RegularGrid<CellState> bufGrid;
			CellState bufState;
			int population;
			// list of cells that need to be drawn with state ALIVE
			List<CellCoordinates> pointsToDraw = new List<CellCoordinates> (); // TODO: init with a proper size

			// the game loop
			for (;;) {
				// begining of a tick
				population = 0;

				for (int i = 0; i < conf.Rows; i++) {
					for (int j = 0; j < conf.Cols; j++) {
						bufState = conf.Rules.CheckCell (grid1, i, j);

						// if in the cell there is someting alive, we should draw it
						if (bufState == CellState.ALIVE) {
							pointsToDraw.Add (new CellCoordinates (i, j));
							population++;
						}

						// write the state to the future grid
						grid2[i,j] = bufState;
					}
				}

				// TODO: make drawing more scalable (support different rendering engines)
				// call the graphics engine to draw the current state on a frame
				System.Drawing.Image frame = gEngine.DrawBlocks (pointsToDraw);
				// draw it on the surface
				gInterpretator.UpdateSurface (frame);
				// and throw it away
				frame.Dispose ();

				// the list is no longer neede
				pointsToDraw.Clear ();

				// changing references places
				// since the game current state depends on its past state, we perserve
				// the past state in grid1 and write in grid2 the current
				// that is, offcourse, for the next iteration
				bufGrid = grid1;
				grid1 = grid2;
				grid2 = bufGrid;

				OnTickFinished (ticks, population);
				ticks++;

				// pause the tread for a while :)
				Thread.Sleep (conf.TickInterval);
			}
		}

		public event EventHandler<TickFinishedEventArgs> TickFinished;

		void OnTickFinished (int tn, int p)
		{
			if (TickFinished != null)
				TickFinished (this, new TickFinishedEventArgs (tn, p));
		}

		public event EventHandler<GameInitializedEventArgs> Initialized;

		void OnInitialized ()
		{
			if (Initialized != null)
				Initialized (this, new GameInitializedEventArgs (conf.Neighbourhood, conf.Rules));
		}

		#region IDisposable implementation
		public void Dispose ()
		{
			if (isStarted)
				Stop ();

			if (isInitialized) {
				// TODO: dispose all disposable fields
			}
		}
		#endregion
	}

	public class TickFinishedEventArgs : EventArgs
	{
		public int TickNum { get; set; }
		public int Population { get; set; }
		public TickFinishedEventArgs (int tickNum, int population) : base ()
		{
			TickNum = tickNum;
			Population = population;
		}
	}

	public class GameInitializedEventArgs : EventArgs
	{
		public INeighbourStrategy Neighbourhood { get; set; }
		public IRule Rules { get; set; }
		public GameInitializedEventArgs (INeighbourStrategy neigh, IRule rules)
		{
			Neighbourhood = neigh;
			Rules = rules;
		}
	}
}

