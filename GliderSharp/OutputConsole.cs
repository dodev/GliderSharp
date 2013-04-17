using System;
using Gtk;

namespace GliderSharp
{
	public class OutputConsole
	{
		private TextView textView;
		public OutputConsole (TextView _tview)
		{
			textView = _tview;
		}

		public void Insert (string str)
		{
			TextIter endIter = textView.Buffer.EndIter;
			textView.Buffer.Insert (ref endIter, str + "\n");
			textView.ScrollToIter (endIter, 0, false, 0, 0);
		}
	}
}

