using Sandbox.IO;

namespace Sandbox.Data
{
	public class Bitmask16 : Bitmask
	{
		public short value;

		public Bitmask16(EndianReader br, string[] option_names)
		{
			Read(br);
			base.Options = option_names;
			GetFlags();
		}
	}
}
