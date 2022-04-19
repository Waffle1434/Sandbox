using Sandbox.IO;

namespace Sandbox.Data
{
	public class Bitmask8 : Bitmask
	{
		public byte value;

		public Bitmask8()
		{
		}

		public Bitmask8(EndianReader br, string[] option_names)
		{
			Read(br);
			base.Options = option_names;
			GetFlags();
		}
	}
}
