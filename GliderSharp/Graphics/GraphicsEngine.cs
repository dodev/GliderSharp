using System;
using System.Drawing;
using System.Collections.Generic;

using GliderSharp.Config;
using GliderSharp.Game;

namespace GliderSharp.Graphics
{
	public class GraphicsEngine
	{
		Configuration config;
		int blockSize;
		Size imgSize;
		Point gridBeginning;
		Point gridEnd;
		Size gridSize;
		Image grid;
		bool showGrid;
		Image border;
		bool showBorder;

		public GraphicsEngine (Configuration config)
		{
			this.config = config;
			imgSize = new Size (BasicConfig.SurfaceWidth, BasicConfig.SurfaceHeight);

			// determining the block's side depending on the image size
			// and the requested grid width and height
			blockSize = BasicConfig.MaxBlockSide;

			if (blockSize * config.Cols > imgSize.Width) {
				// trying the rounded value
				blockSize = (int)Math.Round (imgSize.Width / (double)config.Cols);

				// if the rounded value is too much, get the floored
				if (blockSize * config.Cols > imgSize.Width)
					blockSize--;
			}

			if (blockSize * config.Rows > imgSize.Height) {
				blockSize = (int)Math.Round (imgSize.Height / (double)config.Rows);

				if (blockSize * config.Rows > imgSize.Height)
					blockSize--;
			}

			if (blockSize < BasicConfig.MinBlockSide)
				throw new Exception (String.Format ("Blocks can not be smaller than {0}. Failed to allocate grid's dimensions.", BasicConfig.MinBlockSide));

			// calculate where the image should be
			int gridWidth = config.Cols * blockSize;

			if (gridWidth > imgSize.Width)
				throw new Exception ("Too many cells allocated horizontally");

			int gridHeight = config.Rows * blockSize;

			if (gridHeight > imgSize.Height)
				throw new Exception ("Too many cells allocated vertically");

			int sizeX = blockSize * config.Cols;
			int sizeY = blockSize * config.Rows;

			gridSize = new Size (sizeX, sizeY);

			int beginningX = (int)Math.Floor ((imgSize.Width - gridWidth) / 2d);
			int beginningY = (int)Math.Floor ((imgSize.Height - gridHeight) / 2d);

			gridBeginning = new Point (beginningX, beginningY);

			int endX = beginningX + sizeX;
			int endY = beginningY + sizeY;

			gridEnd = new Point (endX, endY);

			grid = null;
			showGrid = false;

			border = null;
			showBorder = false;
		}

		public bool ShowGrid {
			set {
				if (value && grid == null)
					CreateGrid ();

				showGrid = value;
			}
		}

		void CreateGrid ()
		{
			grid = new Bitmap (gridSize.Width, gridSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			using (System.Drawing.Graphics drawer = System.Drawing.Graphics.FromImage (grid)) {
				Pen drawingPen = new Pen (Color.DarkGray);

				int offset = blockSize - 1;
				// vertical lines
				while (offset < gridSize.Width) {
					drawer.DrawLine (
						drawingPen,
						offset,
						0,
						offset, 
						gridSize.Height);
					offset += blockSize;
				}

				offset = blockSize - 1;
				while (offset < gridSize.Height) {
					drawer.DrawLine (
						drawingPen,
						0,
						offset,
						gridSize.Width,
						offset);
					offset += blockSize;
				}

				drawingPen.Dispose ();           
			}
		}

		public bool ShowBorder {
			set {
				if (value && border == null)
					CreateBorder ();

				showBorder = value;
			}
		}

		void CreateBorder ()
		{
			border = new Bitmap (gridSize.Width, gridSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			using (System.Drawing.Graphics drawer = System.Drawing.Graphics.FromImage (border)) {
				drawer.DrawRectangle (Pens.DarkGray, 
			                      0, 
			                      0, 
			                      gridSize.Width - 1, 
			                      gridSize.Height - 1);
			}
		}

		public CellCoordinates GetCellByXY (double x, double y)
		{
			if (gridBeginning.X > x || gridEnd.X <= x
			    || gridBeginning.Y > y || gridEnd.Y <= y)
				return null;

			double absX = x - gridBeginning.X;
			double absY = y - gridBeginning.Y;

			int row = (int)Math.Floor (absY / blockSize);
			int col = (int)Math.Floor (absX / blockSize);

			return new CellCoordinates (row, col);
		}

		public Image DrawBlocks (IEnumerable<CellCoordinates> coordinates)
		{
			Bitmap img = new Bitmap (imgSize.Width, imgSize.Height);

			using (System.Drawing.Graphics drawer = System.Drawing.Graphics.FromImage (img)) {

				// draw the alive cells
				foreach (CellCoordinates coord in coordinates) {
					drawer.FillRectangle (Brushes.White, 
					                      gridBeginning.X + coord.Col * blockSize,
					                      gridBeginning.Y + coord.Row * blockSize,
					                      blockSize,
					                      blockSize);
				}

				// the border of the world
				if (showBorder)
					drawer.DrawImage (border, gridBeginning.X, gridBeginning.Y);

				// the grid
				if (showGrid)
					drawer.DrawImage (grid, gridBeginning.X, gridBeginning.Y);
			}

			return img;
		}
	}
}

