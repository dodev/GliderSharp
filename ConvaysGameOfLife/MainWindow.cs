using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using Gtk;
using Gdk;
using ConvaysGameOfLife;
using GLib;

public partial class MainWindow: Gtk.Window
{	
	OutputConsole console;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		// handling all the exceptions thrown during the existance of the window
		ExceptionManager.UnhandledException += new UnhandledExceptionHandler (OnUnhandledException);

		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		// dispose the last pixbuf
		if (image1.Pixbuf != null)
			image1.Pixbuf.Dispose ();

		// unsubscribe
		ExceptionManager.UnhandledException -= OnUnhandledException;

		Application.Quit ();
		a.RetVal = true;

	}

	public void OnUnhandledException (UnhandledExceptionArgs args)
	{
		this.console.Insert ("WARNING!!! AN EXCEPTION WAS THROWN: " + args.ExceptionObject.ToString ());
	}

	/*protected void eventBox_buttonPressedEvent (object o, ButtonPressEventArgs args)
	{
		entry1.Text = args.Event.X.ToString ();
		entry2.Text = args.Event.Y.ToString ();
		//this.drawingarea2;
	}

	protected void button1_clicked (object sender, EventArgs e)
	{
		if (image1.Pixbuf != null) {
			image1.Pixbuf.Dispose ();
			image1.Pixbuf = null;
		}

		Bitmap image = new Bitmap (800, 600);

		//Pen whitePen = new Pen (System.Drawing.Color.White, 1f);
		using (Graphics drawer = Graphics.FromImage (image)) {
			//drawer.DrawRectangle (whitePen, 50, 50, 10, 10);
			drawer.FillRectangle (Brushes.White, 50, 50, 10, 10);
			drawer.FillRectangle (Brushes.White, 60, 60, 10, 10);
			drawer.FillRectangle (Brushes.White, 50, 60, 10, 10);
		}

		using (MemoryStream stream = new MemoryStream ()) {
			image.Save (stream, ImageFormat.Bmp);
			stream.Position = 0;
			image1.Pixbuf = new Pixbuf (stream);
		}
	}
	*/
	protected void MainWindow_onmapEvent (object o, MapEventArgs args)
	{
		// TODO: make the image size configurable
		Bitmap image = new Bitmap (800, 600);

		using (MemoryStream stream = new MemoryStream ()) {
			image.Save (stream, ImageFormat.Bmp);
			stream.Position = 0;
			image1.Pixbuf = new Pixbuf (stream);
		}

		//Gtk.TextIter outputIter = outputTextview.Buffer.StartIter;
		console = new OutputConsole (this.outputTextview);

		console.Insert ("The display image was mapped");
	}

	protected void buttonStart_onClicked (object sender, EventArgs e)
	{
		console.Insert ("Something weird happened");
	}

	protected void buttonStop_onClick (object sender, EventArgs e)
	{
		throw new System.NotImplementedException ();
	}

}
