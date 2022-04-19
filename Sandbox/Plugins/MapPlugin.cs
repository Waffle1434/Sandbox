using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Sandbox.Plugins
{
	public class MapPlugin
	{
		public struct Tag
		{
			public string Type;

			public string Filename;

			public int Ident;
		}

		public List<Tag> Tags;

		public List<string> TagClasses;

		public MapPlugin(string path)
		{
			Tags = new List<Tag>();
			TagClasses = new List<string>();
			XmlTextReader xtr = new XmlTextReader(new FileStream(path, FileMode.Open));
			while (xtr.Read())
			{
				XmlNodeType nodeType = xtr.NodeType;
				if (nodeType != XmlNodeType.Element || !(xtr.Name == "Tag"))
				{
					continue;
				}
				Tag t = new Tag
				{
					Type = xtr.GetAttribute("Class")
				};
				bool exist = false;
				foreach (string s in TagClasses)
				{
					if (s.Equals(t.Type))
					{
						exist = true;
					}
				}
				if (!exist)
				{
					TagClasses.Add(t.Type);
				}
				t.Filename = xtr.GetAttribute("Path");
				t.Ident = Convert.ToInt32(xtr.GetAttribute("Ident"));
				Tags.Add(t);
			}
		}

		public string GetTagNameFromID(int id)
		{
			foreach (Tag t in Tags)
			{
				if (t.Ident == id)
				{
					return t.Filename;
				}
			}
			return null;
		}

		public string GetTagTypeFromID(int id)
		{
			foreach (Tag t in Tags)
			{
				if (t.Ident == id)
				{
					return t.Type;
				}
			}
			return null;
		}

		public int GetIDFromTagName(string filename)
		{
			foreach (Tag t in Tags)
			{
				if (t.Filename == filename)
				{
					return t.Ident;
				}
			}
			return -1;
		}
	}
}
