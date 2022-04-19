using System;

namespace Sandbox.Data
{
	public class IdentAttribute : Attribute
	{
		private IdentType type;

		public IdentType Type => type;

		public IdentAttribute(IdentType idType)
		{
			type = idType;
		}
	}
}
