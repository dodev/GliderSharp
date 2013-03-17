using System;
using System.Drawing;
using System.Collections.Generic;

using ConvaysGameOfLife.Config;
using ConvaysGameOfLife.Game;

namespace ConvaysGameOfLife.Graphics
{
	public class GraphicsEngine
	{
		Configuration config;
		int blockSize;
		Size imgSize;
		Point gridBeginning;
		bool initialized;
		//UpdateGameSurface Updater;

		public GraphicsEngine (Configuration config/*, UpdateGameSurface updr*/)
		{
			this.config = config;

			// TODO: make the img properties configurable
			blockSize = 10;
			imgSize = new Size (800, 600);

			initialized = false;

			//Updater = updr;
		}

		public void Init ()
		{
			if (initialized)
				return;

			// calculate where the image should be
			int gridWidth = config.Cols * blockSize;

			if (gridWidth > imgSize.Width)
				throw new Exception ("Too many cells allocated horizontally");

			int gridHeight = config.Rows * blockSize;

			if (gridHeight > imgSize.Height)
				throw new Exception ("Too many cells allocated vertically");

			int beginningX = (imgSize.Width - gridWidth) / 2;
			int beginningY = (imgSize.Height - gridHeight) / 2;

			gridBeginning = new Point (beginningX, beginningY);

			initialized = true;
		}


//		private void DrawBlock (Graphics drawer, int row, int col)
//		{
//
//		}

		public Image DrawBlocks (IEnumerable<CellCoordinates> coordinates)
		{
			Bitmap img = new Bitmap (imgSize.Width, imgSize.Height);

			using (System.Drawing.Graphics drawer = System.Drawing.Graphics.FromImage (img)) {
				// the border of the world
				drawer.DrawRectangle (Pens.LightGray, 
				                      gridBeginning.X, 
				                      gridBeginning.Y, 
				                      blockSize * config.Cols, 
				                      blockSize * config.Rows);

				// draw the alive cells
				foreach (CellCoordinates coord in coordinates) {
					drawer.FillRectangle (Brushes.White, 
					                      gridBeginning.X + coord.Col * blockSize,
					                      gridBeginning.Y + coord.Row * blockSize,
					                      blockSize,
					                      blockSize);
				}
			}

			/*if (Updater == null)
				throw new Exception ("Graphics engine can't update the game surface, because no drawing delegate was provided");
			else
				Updater (img);
			*/
			return img;
		}
	}
}

