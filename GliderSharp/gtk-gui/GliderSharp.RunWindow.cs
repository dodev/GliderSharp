
// This file has been generated by the GUI designer. Do not modify.
namespace GliderSharp
{
	public partial class RunWindow
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action FileAction;
		private global::Gtk.Action newAction;
		private global::Gtk.Action openAction;
		private global::Gtk.Action saveAction;
		private global::Gtk.Action quitAction;
		private global::Gtk.VBox vbox1;
		private global::Gtk.MenuBar menubar1;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Image image1;
		private global::Gtk.VBox vbox2;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView outputTextview;
		private global::Gtk.Table table1;
		private global::Gtk.Label label4;
		private global::Gtk.Label label5;
		private global::Gtk.Label label6;
		private global::Gtk.Label label7;
		private global::Gtk.Label labelNeighbourhoodRulesValue;
		private global::Gtk.Label labelPopulationValue;
		private global::Gtk.Label labelRulesValue;
		private global::Gtk.Label labelTicksValue;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Button buttonStart;
		private global::Gtk.Button buttonStop;
		private global::Gtk.Button buttonStep;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget GliderSharp.RunWindow
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
			this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
			w1.Add (this.FileAction, null);
			this.newAction = new global::Gtk.Action ("newAction", global::Mono.Unix.Catalog.GetString ("_New"), null, "gtk-new");
			this.newAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_New");
			w1.Add (this.newAction, null);
			this.openAction = new global::Gtk.Action ("openAction", global::Mono.Unix.Catalog.GetString ("_Open"), null, "gtk-open");
			this.openAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Open");
			w1.Add (this.openAction, null);
			this.saveAction = new global::Gtk.Action ("saveAction", global::Mono.Unix.Catalog.GetString ("_Save"), null, "gtk-save");
			this.saveAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Save");
			w1.Add (this.saveAction, null);
			this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("_Quit"), null, "gtk-quit");
			this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Quit");
			w1.Add (this.quitAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "GliderSharp.RunWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("RunWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child GliderSharp.RunWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			// Container child vbox1.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='newAction' action='newAction'/><menuitem name='openAction' action='openAction'/><menuitem name='saveAction' action='saveAction'/><menuitem name='quitAction' action='quitAction'/></menu></menubar></ui>");
			this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
			this.menubar1.Name = "menubar1";
			this.vbox1.Add (this.menubar1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			this.hbox1.BorderWidth = ((uint)(6));
			// Container child hbox1.Gtk.Box+BoxChild
			this.image1 = new global::Gtk.Image ();
			this.image1.Name = "image1";
			this.hbox1.Add (this.image1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.image1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.outputTextview = new global::Gtk.TextView ();
			this.outputTextview.CanFocus = true;
			this.outputTextview.Name = "outputTextview";
			this.GtkScrolledWindow.Add (this.outputTextview);
			this.vbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow]));
			w5.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(4)), ((uint)(3)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Rules:");
			this.table1.Add (this.label4);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.label4]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 0F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Neightbourhood rules:");
			this.table1.Add (this.label5);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.label5]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 0F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Population:");
			this.table1.Add (this.label6);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.label6]));
			w8.TopAttach = ((uint)(2));
			w8.BottomAttach = ((uint)(3));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.Xalign = 0F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Ticks:");
			this.table1.Add (this.label7);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.label7]));
			w9.TopAttach = ((uint)(3));
			w9.BottomAttach = ((uint)(4));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelNeighbourhoodRulesValue = new global::Gtk.Label ();
			this.labelNeighbourhoodRulesValue.Name = "labelNeighbourhoodRulesValue";
			this.table1.Add (this.labelNeighbourhoodRulesValue);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelNeighbourhoodRulesValue]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelPopulationValue = new global::Gtk.Label ();
			this.labelPopulationValue.Name = "labelPopulationValue";
			this.table1.Add (this.labelPopulationValue);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelPopulationValue]));
			w11.TopAttach = ((uint)(2));
			w11.BottomAttach = ((uint)(3));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelRulesValue = new global::Gtk.Label ();
			this.labelRulesValue.Name = "labelRulesValue";
			this.table1.Add (this.labelRulesValue);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelRulesValue]));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelTicksValue = new global::Gtk.Label ();
			this.labelTicksValue.Name = "labelTicksValue";
			this.table1.Add (this.labelTicksValue);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelTicksValue]));
			w13.TopAttach = ((uint)(3));
			w13.BottomAttach = ((uint)(4));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add (this.table1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.table1]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonStart = new global::Gtk.Button ();
			this.buttonStart.CanFocus = true;
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.UseUnderline = true;
			this.buttonStart.Label = global::Mono.Unix.Catalog.GetString ("Start");
			this.hbox3.Add (this.buttonStart);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonStart]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonStop = new global::Gtk.Button ();
			this.buttonStop.CanFocus = true;
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.UseUnderline = true;
			this.buttonStop.Label = global::Mono.Unix.Catalog.GetString ("Stop");
			this.hbox3.Add (this.buttonStop);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonStop]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonStep = new global::Gtk.Button ();
			this.buttonStep.CanFocus = true;
			this.buttonStep.Name = "buttonStep";
			this.buttonStep.UseUnderline = true;
			this.buttonStep.Label = global::Mono.Unix.Catalog.GetString ("Step");
			this.hbox3.Add (this.buttonStep);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.buttonStep]));
			w17.Position = 2;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox2.Add (this.hbox3);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox3]));
			w18.Position = 2;
			w18.Expand = false;
			w18.Fill = false;
			this.hbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox2]));
			w19.Position = 1;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w20.Position = 1;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 1188;
			this.DefaultHeight = 310;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.MapEvent += new global::Gtk.MapEventHandler (this.RunWindow_onmapEvent);
			this.newAction.Activated += new global::System.EventHandler (this.menuItemNew_onActivated);
			this.openAction.Activated += new global::System.EventHandler (this.Open_onActivated);
			this.saveAction.Activated += new global::System.EventHandler (this.SaveItem_onActivated);
			this.quitAction.Activated += new global::System.EventHandler (this.Quit_onActivated);
			this.buttonStart.Clicked += new global::System.EventHandler (this.buttonStart_onClicked);
			this.buttonStop.Clicked += new global::System.EventHandler (this.buttonStop_onClicked);
			this.buttonStep.Clicked += new global::System.EventHandler (this.buttonStep_onClicked);
		}
	}
}
