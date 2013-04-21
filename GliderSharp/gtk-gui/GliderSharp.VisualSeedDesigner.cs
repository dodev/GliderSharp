
// This file has been generated by the GUI designer. Do not modify.
namespace GliderSharp
{
	public partial class VisualSeedDesigner
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.EventBox eventbox1;
		private global::Gtk.Image image1;
		private global::Gtk.HBox hbox4;
		private global::Gtk.Label labelRules;
		private global::Gtk.Label labelNeighbourhood;
		private global::Gtk.Label labelRow;
		private global::Gtk.Label labelCol;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Button buttonAccept;
		private global::Gtk.Button buttonCancel;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget GliderSharp.VisualSeedDesigner
			this.Name = "GliderSharp.VisualSeedDesigner";
			this.Title = global::Mono.Unix.Catalog.GetString ("VisualSeedDesigner");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child GliderSharp.VisualSeedDesigner.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.eventbox1 = new global::Gtk.EventBox ();
			this.eventbox1.Name = "eventbox1";
			// Container child eventbox1.Gtk.Container+ContainerChild
			this.image1 = new global::Gtk.Image ();
			this.image1.Name = "image1";
			this.eventbox1.Add (this.image1);
			this.vbox2.Add (this.eventbox1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.eventbox1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.labelRules = new global::Gtk.Label ();
			this.labelRules.Name = "labelRules";
			this.labelRules.LabelProp = global::Mono.Unix.Catalog.GetString ("label2");
			this.hbox4.Add (this.labelRules);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.labelRules]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.labelNeighbourhood = new global::Gtk.Label ();
			this.labelNeighbourhood.Name = "labelNeighbourhood";
			this.labelNeighbourhood.LabelProp = global::Mono.Unix.Catalog.GetString ("label3");
			this.hbox4.Add (this.labelNeighbourhood);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.labelNeighbourhood]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.labelRow = new global::Gtk.Label ();
			this.labelRow.Name = "labelRow";
			this.labelRow.LabelProp = global::Mono.Unix.Catalog.GetString ("label4");
			this.hbox4.Add (this.labelRow);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.labelRow]));
			w5.Position = 3;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.labelCol = new global::Gtk.Label ();
			this.labelCol.Name = "labelCol";
			this.labelCol.LabelProp = global::Mono.Unix.Catalog.GetString ("label5");
			this.hbox4.Add (this.labelCol);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.labelCol]));
			w6.Position = 4;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox2.Add (this.hbox4);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox4]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonAccept = new global::Gtk.Button ();
			this.buttonAccept.CanFocus = true;
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.UseUnderline = true;
			this.buttonAccept.Label = global::Mono.Unix.Catalog.GetString ("Accept");
			this.hbox3.Add (this.buttonAccept);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonAccept]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Cancel");
			this.hbox3.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonCancel]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.vbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox3]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.eventbox1.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.eventBox_onButtonRelease);
			this.buttonAccept.Clicked += new global::System.EventHandler (this.buttonAccept_onClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.buttonCancel_onClicked);
		}
	}
}
