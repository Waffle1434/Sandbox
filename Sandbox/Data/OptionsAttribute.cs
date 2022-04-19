using System;

namespace Sandbox.Data
{
	public class OptionsAttribute : Attribute
	{
		private string[] options;

		public string[] Options => options;

		public OptionsAttribute(string[] optionNames)
		{
			options = optionNames;
		}
	}
}
