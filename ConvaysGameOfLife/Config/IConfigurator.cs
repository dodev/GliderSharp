using System;

namespace GliderSharp.Config
{
	public interface IConfigurator
	{
		/*
		Configuration Config { get; }

		ISeedDesigner SeedDesigner { get; }
		*/
		void Show ();

		event EventHandler<ConfiguratorEventArgs> Finished;
	}

}

