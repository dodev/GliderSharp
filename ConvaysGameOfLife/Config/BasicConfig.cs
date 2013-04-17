using System;

using ConvaysGameOfLife.Game;

namespace ConvaysGameOfLife.Config
{
	public static class BasicConfig
	{
		public static int Rows {
			get { return 60; }
		}

		public static int Cols {
			get { return 60; }
		}

		public static int Interval {
			get { return 100; }
		}

		public static int SurfaceWidth {
			get { return 800; }
		}

		public static int SurfaceHeight {
			get { return 600; }
		}

		public static int MinBlockSide {
			get { return 2; }
		}

		public static int MaxBlockSide {
			get { return 10; }
		}

		public static float Density {
			get { return 0.25f; }
		}

		static INeighbourStrategy[] neighbourhoods = new INeighbourStrategy[] {
			new MooreNeighbourhood (),
			new MooreCyclicNeighbourhood (),
			new NeumanNeighbourhood ()
		};

		public static INeighbourStrategy[] NeighbourhoodStrategies {
			get { return neighbourhoods; }
		}

		public static INeighbourStrategy DefaultNeighbourhoodStrategy {
			get { return neighbourhoods[1]; } // Moore's cyclic neighbourhood
		}

		static IRule[] rules = new IRule[] {
			new ConwaysRules ()
		};

		public static IRule[] Rules {
			get { return rules; }
		}

		public static IRule DefaultRules {
			get { return rules [0]; } // Conway's rules
		}

		static SeedDesignerEnum[] designers = new SeedDesignerEnum[] {
			SeedDesignerEnum.Random,
			SeedDesignerEnum.Visual
		};

		public static SeedDesignerEnum[] SeedDesigners {
			get { return designers; }
		}

		public static SeedDesignerEnum DefaultSeedDesigner {
			get { return designers[1]; } // visual
		}
	}

}

