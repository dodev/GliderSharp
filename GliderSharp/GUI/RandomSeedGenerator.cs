using System;

using GliderSharp.Game;
using GliderSharp.Config;

namespace GliderSharp
{
	public partial class RandomSeedGenerator : Gtk.Window, ISeedDesigner
	{
		Configuration conf;
		CellState[,] seed;

		public RandomSeedGenerator () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			seed = null;
		}

		#region ISeedDesigner implementation

		public event EventHandler<SeedEventArgs> Finished;

		public void Init (Configuration conf)
		{
			this.conf = conf;
			seed = new CellState[conf.Rows, conf.Cols];
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

		protected void buttonCancel_onClicked (object sender, EventArgs e)
		{
			OnFinished (false);
			this.Destroy ();
		}

		protected void buttonAccept_onClicked (object sender, EventArgs e)
		{
			float density = 0;
			if (float.TryParse (entryDensity.Text, out density) &&
			    (density >= 0 && density <= 1)) {

				seed = new CellState[conf.Rows, conf.Cols];
				Random rand = new Random ();
				for (int i = 0; i < conf.Rows; i++) {
					for (int j = 0; j < conf.Cols; j++) {
						seed[i,j] = (rand.NextDouble () < density) ? CellState.ALIVE : CellState.DEAD;
					}
				}

				OnFinished (true);
				this.Destroy ();

			} else {
				Gtk.MessageDialog msg = new Gtk.MessageDialog (this, Gtk.DialogFlags.Modal, Gtk.MessageType.Error, Gtk.ButtonsType.Close, "A float value is required");
				msg.Show ();
			}
		}
	}
}

