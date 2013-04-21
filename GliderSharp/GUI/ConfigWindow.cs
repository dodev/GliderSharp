using System;
using System.Collections.Generic;

using GliderSharp.Config;
using GliderSharp.Game;

namespace GliderSharp
{
	public partial class ConfigWindow : Gtk.Window, IConfigurator
	{
		Configuration conf;
		SeedDesignerEnum designer;

		public ConfigWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			conf = new Configuration (BasicConfig.Rows,
			                          BasicConfig.Cols,
			                          null,
			                          BasicConfig.DefaultNeighbourhoodStrategy,
			                          BasicConfig.DefaultRules,
			                          BasicConfig.Interval
			                          );

			PopulateComboBox (this.cbNeighbourhoods, BasicConfig.NeighbourhoodStrategies);
			PopulateComboBox (this.cbRules, BasicConfig.Rules);
			PopulateSeedDesigners (this.cbDesigners, BasicConfig.SeedDesigners);
			designer = BasicConfig.DefaultSeedDesigner;

			InitFields ();
		}

		void PopulateComboBox (Gtk.ComboBox cmBox, object[] keys)
		{
			var listStore = new Gtk.ListStore (typeof(string));
			cmBox.Model = listStore;
			foreach (object key in keys) {
				listStore.AppendValues (key.ToString ());
			}
		}

		void PopulateSeedDesigners (Gtk.ComboBox cmBox, SeedDesignerEnum[] keys)
		{
			var listStore = new Gtk.ListStore (typeof(string));
			cmBox.Model = listStore;
			foreach (object key in keys) {
				listStore.AppendValues (key.ToString ());
			}
		}

		void InitFields ()
		{
			sbRows.Value = (double)conf.Rows;
			sbCols.Value = (double)conf.Cols;
			sbInterval.Value = (double)conf.TickInterval;
			SetSelected (cbDesigners, BasicConfig.DefaultSeedDesigner.ToString ());
			SetSelected (cbNeighbourhoods, conf.Neighbourhood.ToString ());
			SetSelected (cbRules, conf.Rules.ToString ());
		}

		void SetSelected (Gtk.ComboBox cb, string val)
		{
			Gtk.TreeIter ti;
			cb.Model.GetIterFirst (out ti);
			do {
				var str = cb.Model.GetValue (ti, 0) as String;
				if (str == val) {
					cb.SetActiveIter (ti);
					break;
				}
			} while (cb.Model.IterNext (ref ti));
		}

		void HarvestForm ()
		{
			conf.Rows = (int)sbRows.Value;
			conf.Cols = (int)sbCols.Value;
			conf.TickInterval = (int)sbInterval.Value;
			conf.Neighbourhood = GetSelectedItem (cbNeighbourhoods, BasicConfig.NeighbourhoodStrategies) as INeighbourStrategy;
			conf.Rules = GetSelectedItem (cbRules, BasicConfig.Rules) as IRule;
			designer = GetSelectedDesigner (cbDesigners, BasicConfig.SeedDesigners);
		}

		object GetSelectedItem (Gtk.ComboBox cb, object[] objs)
		{
			for (int i = 0; i < objs.Length; i++)
				if (objs [i].ToString () == cb.ActiveText)
					return objs [i];
			return null;
		}

		SeedDesignerEnum GetSelectedDesigner (Gtk.ComboBox cb, SeedDesignerEnum[] objs)
		{
			for (int i = 0; i < objs.Length; i++)
				if (objs [i].ToString () == cb.ActiveText)
					return objs [i];
			return BasicConfig.DefaultSeedDesigner;
		}

		protected void buttonAccept_onClicked (object sender, EventArgs e)
		{
			HarvestForm ();
			OnFinish (true);
			this.Destroy ();
		}

		protected void buttonCancel_onClicked (object sender, EventArgs e)
		{
			OnFinish (false);
			this.Destroy ();
		}

		#region IConfigurator implementation

		public event EventHandler<ConfiguratorEventArgs> Finished;

		#endregion

		void OnFinish (bool isAccepted)
		{
			if (Finished != null) {
				if (isAccepted)
					Finished (this, new ConfiguratorEventArgs (conf, designer));
				else
					Finished (null, null);
			}
		}
	}
}

