using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Gtk;
using Gdk;
using GLib;

using ConvaysGameOfLife;
using ConvaysGameOfLife.Game;
using ConvaysGameOfLife.Graphics;

public partial class MainWindow: Gtk.Window
{	
	OutputConsole console;
	GameHost host;

	public MainWindow (GameHost host): base (Gtk.WindowType.Toplevel)
	{
		// handling all the exceptions thrown during the existance of the window
		ExceptionManager.UnhandledException += new UnhandledExceptionHandler (OnUnhandledException);
		this.host = host;

		Build ();

		host.SetSurfaceInterpretator (new GtkSurfaceInterpretator (this.image1));
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		// dispose the last pixbuf
		if (image1.Pixbuf != null)
			image1.Pixbuf.Dispose ();

		// stop the game thread
		host.Stop ();

		// unsubscribe
		ExceptionManager.UnhandledException -= OnUnhandledException;

		Application.Quit ();
		a.RetVal = true;
	}

	public void OnUnhandledException (UnhandledExceptionArgs args)
	{
		this.console.Insert ("WARNING!!! AN EXCEPTION WAS THROWN: " + args.ExceptionObject.ToString ());
	}

	protected void MainWindow_onmapEvent (object o, MapEventArgs args)
	{
		// TODO: make the image size configurable
		Bitmap image = new Bitmap (800, 600);

		using (MemoryStream stream = new MemoryStream ()) {
			image.Save (stream, ImageFormat.Bmp);
			stream.Position = 0;
			image1.Pixbuf = new Pixbuf (stream);
		}

		image.Dispose ();

		//Gtk.TextIter outputIter = outputTextview.Buffer.StartIter;
		console = new OutputConsole (this.outputTextview);

		console.Insert ("The display image was mapped");
	}

	protected void buttonStart_onClicked (object sender, EventArgs e)
	{
		if (host.Start ())
			console.Insert ("The game has started");
	}

	protected void buttonStop_onClick (object sender, EventArgs e)
	{
		if (host.Stop ())
			console.Insert ("The game has been stopped");
	}
}
