using System;

namespace ConvaysGameOfLife.Config
{

	public class ConfiguratorEventArgs : EventArgs
	{
		Configuration conf;

		SeedDesignerEnum designer;

		public ConfiguratorEventArgs (Configuration conf, SeedDesignerEnum designer): base ()
		{
			this.conf = conf;
			this.designer = designer;
		}

		public Configuration Conf {
			get { return conf; }
		}

		public SeedDesignerEnum SeedDesigner {
			get { return designer; }
		}
	}
}
