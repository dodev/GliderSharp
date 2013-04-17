using System;
using System.IO;
using System.Drawing.Imaging;

using Gtk;
using Gdk;

namespace GliderSharp.Graphics
{
	public class GtkSurfaceInterpretator : ISurfaceInterpretator
	{
		private Gtk.Image imgWidget;

		public GtkSurfaceInterpretator (Gtk.Image imgWidget)
		{
			this.imgWidget = imgWidget;
		}

		#region ISurfaceInterpretator implementation
		public void UpdateSurface (System.Drawing.Image frame)
		{
			Pixbuf pixbuf1, pixbuf2;

			using (MemoryStream stream = new MemoryStream ()) {
				frame.Save (stream, ImageFormat.Bmp);
				stream.Position = 0;
				pixbuf1 = new Pixbuf (stream);
			}

			Gtk.Application.Invoke (delegate {
				pixbuf2 = imgWidget.Pixbuf;
				imgWidget.Pixbuf = pixbuf1;
				pixbuf2.Dispose ();
			});
		}
		#endregion

	}
}

