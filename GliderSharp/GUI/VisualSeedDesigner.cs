using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;

using Gdk;
using Gtk;

using GliderSharp.Config;
using GliderSharp.Game;
using GliderSharp.Graphics;

namespace GliderSharp
{
	public partial class VisualSeedDesigner : Gtk.Window, ISeedDesigner
	{
		Configuration conf;
		CellState[,] seed;
		Dictionary<int, CellCoordinates> aliveCells;
		GraphicsEngine engine;
		ISurfaceInterpretator gtkInterpretator;

		public VisualSeedDesigner () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		#region ISeedDesigner implementation

		public event EventHandler<SeedEventArgs> Finished;

		public void Init (Configuration conf)
		{
			this.conf = conf;
			engine = new GraphicsEngine (conf);
			engine.ShowGrid = true;
			engine.ShowBorder = true;
			gtkInterpretator = new GtkSurfaceInterpretator (this.image1);

			aliveCells = new Dictionary<int, CellCoordinates> ();

			if (conf.Seed != null)
				PopulateDict ();

			seed = new CellState[conf.Rows, conf.Cols];

			labelRules.LabelProp = conf.Rules.ToString ();
			labelNeighbourhood.LabelProp = conf.Neighbourhood.ToString ();
			labelCol.LabelProp = String.Empty;
			labelRow.LabelProp = String.Empty;

			this.MapEvent += image1_HandleMapEvent;
		}

		void image1_HandleMapEvent (object o, MapEventArgs args)
		{
			// draw grid border
			gtkInterpretator.UpdateSurface (engine.DrawBlocks (aliveCells.Values));
		}

		void PopulateDict ()
		{
			for (int i = 0; i < conf.Rows; i++) {
				for (int j = 0; j < conf.Cols; j++) {
					if (conf.Seed [i, j] == CellState.ALIVE) {
						CellCoordinates coord = new CellCoordinates (i, j);
						aliveCells.Add (coord.GetHashCode (), coord);
					}
				}
			}
		}

		#endregion

		void OnFinished (bool isAccepted)
		{
			if (Finished != null) {
				if (isAccepted)
					Finished (this, new SeedEventArgs (seed));
				else
					Finished (null, null);
			}
		}

		protected void eventBox_onButtonRelease (object o, ButtonReleaseEventArgs args)
		{
			var ev = args.Event as EventButton;

			CellCoordinates coord = engine.GetCellByXY (ev.X, ev.Y);
			if (coord != null) {
				int hash = coord.GetHashCode ();

				if (aliveCells.ContainsKey (hash))
					aliveCells.Remove (hash);
				else
					aliveCells.Add (hash, coord);

				this.labelCol.LabelProp = coord.Row.ToString ();
				this.labelRow.LabelProp = coord.Col.ToString ();

				System.Drawing.Image img = engine.DrawBlocks (aliveCells.Values);
				gtkInterpretator.UpdateSurface (img);
			}

		}

		protected void buttonAccept_onClicked (object sender, EventArgs e)
		{
			// build the seed from the dictionary
			foreach (CellCoordinates kv in aliveCells.Values)
				seed [kv.Row, kv.Col] = CellState.ALIVE;

			OnFinished (true);
			this.Destroy ();
		}

		protected void buttonCancel_onClicked (object sender, EventArgs e)
		{
			OnFinished (false);
			this.Destroy ();
		}

		protected void buttonClear_onClicked (object sender, EventArgs e)
		{
			gtkInterpretator.UpdateSurface (engine.DrawBlocks (new CellCoordinates[] {}));
			aliveCells = new Dictionary<int, CellCoordinates> ();
		}
	}
}

