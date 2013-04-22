using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Gtk;
using Gdk;
using GLib;

using GliderSharp.Game;
using GliderSharp.Graphics;
using GliderSharp.Config;

namespace GliderSharp 
{
	public partial class RunWindow: Gtk.Window
	{	
		OutputConsole console;
		GameController controller;
		//GameHost host;

		public RunWindow (): base (Gtk.WindowType.Toplevel)
		{
			// handling all the exceptions thrown during the existance of the window
			ExceptionManager.UnhandledException += new UnhandledExceptionHandler (OnUnhandledException);

			Build ();

			controller = new GameController ();
			controller.StateChanged += controller_HandleStateChanged;
			controller.GameTickFinished += HandleGameTickFinished;
			controller.GameInitialized += HandleGameInitialized;
		}

		void HandleGameInitialized (object sender, GameInitializedEventArgs e)
		{
			Gtk.Application.Invoke (delegate {
				labelNeighbourhoodRulesValue.LabelProp = e.Neighbourhood.ToString ();
				labelRulesValue.LabelProp = e.Rules.ToString ();
			});
		}

		void HandleGameTickFinished (object sender, TickFinishedEventArgs e)
		{
			Gtk.Application.Invoke (delegate {
				labelPopulationValue.LabelProp = e.Population.ToString ();
				labelTicksValue.LabelProp = e.TickNum.ToString ();
			});
		}

		void controller_HandleStateChanged (object sender, GameStateEventArgs e)
		{
			// TODO: switch active GUI components depending on the state
			// TODO: echo state changes in console
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			// dispose the last pixbuf
			if (image1.Pixbuf != null)
				image1.Pixbuf.Dispose ();

			controller.Dispose ();

			// unsubscribe
			ExceptionManager.UnhandledException -= OnUnhandledException;

			Application.Quit ();
			a.RetVal = true;
		}

		public void OnUnhandledException (UnhandledExceptionArgs args)
		{
			this.console.Insert ("WARNING!!! AN EXCEPTION WAS THROWN: " + args.ExceptionObject.ToString ());
		}

		protected void RunWindow_onmapEvent (object o, MapEventArgs args)
		{
			Bitmap image = new Bitmap (BasicConfig.SurfaceWidth, BasicConfig.SurfaceHeight);

			using (MemoryStream stream = new MemoryStream ()) {
				image.Save (stream, ImageFormat.Bmp);
				stream.Position = 0;
				image1.Pixbuf = new Pixbuf (stream);
			}

			image.Dispose ();

			console = new OutputConsole (this.outputTextview);

			console.Insert ("The display image was mapped");
		}

		protected void buttonStart_onClicked (object sender, EventArgs e)
		{
			controller.GameStart ();
		}

		protected void buttonStop_onClicked (object sender, EventArgs e)
		{
			controller.GameStop ();
		}

		protected void menuItemNew_onActivated (object sender, EventArgs e)
		{
			controller.CancelRun ();
			IConfigurator configurator = new ConfigWindow ();
			configurator.Finished += ConfWindow_HandleFinished;
			configurator.Show ();
			controller.StartConf ();
		}

		protected void SaveItem_onActivated (object sender, EventArgs e)
		{
			Gtk.FileChooserDialog fc=
				new Gtk.FileChooserDialog("Choose directory and filename to save the current database",
				                          this,
				                          FileChooserAction.Save,
				                          "Cancel",ResponseType.Cancel,
				                          "Save",ResponseType.Accept);

			if (fc.Run () == (int)ResponseType.Accept) {
				controller.SaveConf (fc.Filename);
			}
			fc.Destroy ();
		}

		void ConfWindow_HandleFinished (object sender, ConfiguratorEventArgs args)
		{
			if (sender != null) {
				controller.LoadConfNSurface (args.Conf, new GtkSurfaceInterpretator (this.image1));

				ISeedDesigner sdesigner;

				switch (args.SeedDesigner) {
					case SeedDesignerEnum.Random:
					sdesigner = new RandomSeedGenerator ();
					break;
					case SeedDesignerEnum.Visual:
					sdesigner = new VisualSeedDesigner ();
					break;
					default:
					throw new Exception ("Unknown seed designer requested");
				}
				sdesigner.Init (args.Conf);
				sdesigner.Finished += SeedDesigner_HandleFinished;
				sdesigner.Show ();
			}
		}

		void SeedDesigner_HandleFinished (object sender, SeedEventArgs e)
		{
			if (sender != null)
				controller.LoadSeed (e.Seed);
		}

		protected void buttonStep_onClicked (object sender, EventArgs e)
		{

		}

		protected void Open_onActivated (object sender, EventArgs e)
		{
			Gtk.FileChooserDialog fc=
				new Gtk.FileChooserDialog("Choose the file to open",
				                          this,
				                          FileChooserAction.Open,
				                          "Cancel",ResponseType.Cancel,
				                          "Open",ResponseType.Accept);

			if (fc.Run () == (int)ResponseType.Accept) {
				controller.LoadFullConf (new GtkSurfaceInterpretator (this.image1), fc.Filename);
			}
			fc.Destroy ();
		}
	}
}
