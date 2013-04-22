using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

using GliderSharp.Game;

namespace GliderSharp.Config
{
	public class XmlSerializer
	{
		public XmlSerializer ()
		{
		}

		const string ROOT_EL = "GliderSharpConfiguration";
		const string CONF_EL = "Configuration";
		const string SEED_EL = "Seed";
		const string ROWS_EL = "Rows";
		const string COLS_EL = "Cols";
		const string TICK_EL = "TickInterval";
		const string RULS_EL = "Rules";
		const string NRLS_EL = "NeighbourhoodRules";
		const string CLST_EL = "CellStates";
		const string STAT_EL = "State";
		const string STVL_AT = "Value";
		const string SDST_EL = "SeedString";

		public void SaveConfigToFile (Configuration conf, string path)
		{
			var settings = new XmlWriterSettings ();
			settings.Indent = true;

			using (var writer = XmlWriter.Create (path, settings)) {
				writer.WriteStartDocument ();
				writer.WriteStartElement (ROOT_EL);

				writer.WriteStartElement (CONF_EL);
				writer.WriteElementString (ROWS_EL, conf.Rows.ToString ());
				writer.WriteElementString (COLS_EL, conf.Cols.ToString ());
				writer.WriteElementString (TICK_EL, conf.TickInterval.ToString ());
				writer.WriteElementString (RULS_EL, conf.Rules.ToString ());
				writer.WriteElementString (NRLS_EL, conf.Neighbourhood.ToString ());
				writer.WriteEndElement (); // CONF_EL

				writer.WriteStartElement (SEED_EL);
				writer.WriteStartElement (CLST_EL);
				// TODO: enum cell states
				writer.WriteEndElement (); // CLST_EL
				writer.WriteElementString (SDST_EL, GenSeedString (conf.Seed));
				writer.WriteEndElement (); // SEED_EL

				writer.WriteEndElement (); // ROOT_EL
				writer.WriteEndDocument ();
			}
		}

		string GenSeedString (Game.CellState [,] seed)
		{
			StringBuilder sb = new StringBuilder ();
			foreach (Game.CellState cell in seed)
				sb.Append (((int)cell).ToString ());
			return sb.ToString ();
		}

		public Configuration LoadConfigFromFile (string path)
		{
			int cols, rows, tickInterval;
			INeighbourStrategy strategy;
			IRule rules;
			CellState[,] seed;
			var xmlDoc = new XmlDocument ();
			xmlDoc.Load (path);

			XmlNode nd = xmlDoc.GetElementsByTagName (ROWS_EL) [0];
			if (!int.TryParse (xmlDoc.GetElementsByTagName (ROWS_EL) [0].InnerText, out rows))
				throw new Exception ("Error reading configuration");

			if (!int.TryParse (xmlDoc.GetElementsByTagName (COLS_EL)[0].InnerText, out cols))
				throw new Exception ("Error reading configuration");

			if (!int.TryParse (xmlDoc.GetElementsByTagName (TICK_EL)[0].InnerText, out tickInterval))
				throw new Exception ("Error reading configuration");

			strategy = GetStrategy (xmlDoc.GetElementsByTagName (NRLS_EL) [0].InnerText);
			if (strategy == null)
				throw new Exception ("Error reading configuration");

			rules = GetRules (xmlDoc.GetElementsByTagName (RULS_EL) [0].InnerText);
			if (rules == null)
				throw new Exception ("Error reading configuration");

			seed = new CellState [rows, cols];
			// TODO: Build a dictionary from the configs cell states
			Dictionary<char, CellState> cellDict = new Dictionary<char, CellState> () {
				{((int)CellState.DEAD).ToString ()[0], CellState.DEAD},
				{((int)CellState.ALIVE).ToString ()[0], CellState.ALIVE}
			};
			string seedStr = xmlDoc.GetElementsByTagName (SDST_EL) [0].InnerText;

			unsafe {
			fixed (char* pString = seedStr) {
				char* pChar = pString;
				int r = 0;
				int c = 0;
				for (int i = 0; i < seedStr.Length; i++, pChar++) {
					seed [r, c] = cellDict [*pChar];
					c++;
					if (c >= cols) {
						c = 0;
						r++;
					}
				}
			}
			}

			return new Configuration (rows, cols, seed, strategy, rules, tickInterval);
		}

		INeighbourStrategy GetStrategy (string name)
		{
			foreach (INeighbourStrategy strategy in BasicConfig.NeighbourhoodStrategies) {
				if (strategy.ToString () == name)
					return strategy;
			}
			return null;
		}

		IRule GetRules (string name)
		{
			foreach (IRule rule in BasicConfig.Rules) {
				if (rule.ToString () == name)
					return rule;
			}
			return null;
		}
	}
}

