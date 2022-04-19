using Sandbox.IO;

namespace Sandbox.Data
{
	public class Bitmask32 : Bitmask
	{
		public int value;

		public Bitmask32(EndianReader br, string[] option_names)
		{
			Read(br);
			base.Options = option_names;
			GetFlags();
		}
	}
}
