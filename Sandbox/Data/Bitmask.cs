using System;
using Sandbox.IO;

namespace Sandbox.Data
{
	public class Bitmask : Chunk
	{
		private string[] options;

		private bool[] flags;

		public string[] Options
		{
			get
			{
				return options;
			}
			set
			{
				options = value;
			}
		}

		public bool[] Flags
		{
			get
			{
				return flags;
			}
			set
			{
				flags = value;
			}
		}

		public override void Read(EndianReader br)
		{
			base.Read(br);
		}

		public override void Write(EndianWriter bw)
		{
			base.Write(bw);
		}

		public void GetFlags()
		{
			if (GetType().GetField("value").GetValue(this) == typeof(int))
			{
				flags = new bool[32];
			}
			else if (GetType().GetField("value").GetValue(this) == typeof(short))
			{
				flags = new bool[16];
			}
			else if (GetType().GetField("value").GetValue(this).GetType() == typeof(byte))
			{
				flags = new bool[8];
			}
			uint bit = 1u;
			uint temp = Convert.ToUInt32(GetType().GetField("value").GetValue(this));
			for (int i = 0; i < flags.Length; i++)
			{
				flags[i] = (((bit & temp) == bit) ? true : false);
				bit <<= 1;
			}
		}
	}
}
