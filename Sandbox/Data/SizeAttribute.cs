using System;

namespace Sandbox.Data
{
	public class SizeAttribute : Attribute
	{
		private int size;

		public int Size => size;

		public SizeAttribute(int Size)
		{
			size = Size;
		}
	}
}
