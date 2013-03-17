using System;

namespace ConvaysGameOfLife.Config
{
	public interface IConfigurator
	{
		Configuration Config { get; }

		//void SetRows (int rows);

		//void SetCols (int cols);

		/// TODO: is this interface necessazry?!

	}
}

