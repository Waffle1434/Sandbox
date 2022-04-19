using System;
using System.Collections.Generic;
using System.IO;

namespace Sandbox
{
	public class ISettingList<T> : List<T> where T : ISettings
	{
		public void Read(BinaryReader br)
		{
			int count = br.ReadInt32();
			for (int x = 0; x < count; x++)
			{
				T setting = (T)Activator.CreateInstance(typeof(T));
				setting.Read(br);
				Add(setting);
			}
		}

		public void Write(BinaryWriter bw)
		{
			bw.Write(base.Count);
			for (int x = 0; x < base.Count; x++)
			{
				T val = base[x];
				val.Write(bw);
			}
		}
	}
}
