using System;

namespace Sandbox.Data
{
	public class StringAttribute : Attribute
	{
		private int size = 32;

		private StringType stringType = StringType.Ascii;

		public int Size => size;

		public StringType StringType => stringType;

		public StringAttribute()
		{
		}

		public StringAttribute(int Size)
		{
			size = Size;
		}

		public StringAttribute(StringType Type)
		{
			stringType = Type;
		}

		public StringAttribute(StringType Type, int Size)
		{
			stringType = Type;
			size = Size;
		}
	}
}
