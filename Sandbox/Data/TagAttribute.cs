using System;

namespace Sandbox.Data
{
	public class TagAttribute : Attribute
	{
		private string author;

		private string tagType;

		private double version;

		public string Author => author;

		public string TagType => tagType;

		public double Version => version;

		public TagAttribute(string Author, string TagType, double Version)
		{
			author = Author;
			tagType = TagType;
			version = Version;
		}
	}
}
