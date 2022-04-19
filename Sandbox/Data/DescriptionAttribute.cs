using System;

namespace Sandbox.Data
{
	public class DescriptionAttribute : Attribute
	{
		private string description;

		public string Description => description;

		public DescriptionAttribute(string Description)
		{
			description = Description;
		}
	}
}
