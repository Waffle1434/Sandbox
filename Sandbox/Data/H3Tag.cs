using System.Windows.Forms;
using Sandbox.IO;

namespace Sandbox.Data
{
	public class H3Tag : Chunk
	{
		private string author;

		private string tagType;

		private double version;

		private int mapOffset;

		public string Author => author;

		public string TagType => tagType;

		public double Version => version;

		public int MapOffset
		{
			get
			{
				return mapOffset;
			}
			set
			{
				mapOffset = value;
			}
		}

		public H3Tag()
		{
			object[] attributes = GetType().GetCustomAttributes(typeof(TagAttribute), inherit: false);
			if (attributes.Length > 0)
			{
				TagAttribute tagA = (TagAttribute)attributes[0];
				author = tagA.Author;
				tagType = tagA.TagType;
				version = tagA.Version;
			}
			else
			{
				MessageBox.Show("There is no information for this tag! Tag: " + GetType());
			}
		}

		public override void Read(EndianReader br)
		{
			base.Read(br);
		}

		public void Read(EndianReader br, uint TagOffset)
		{
			Read(br, (int)TagOffset);
		}

		public void Read(EndianReader br, int TagOffset)
		{
			mapOffset = TagOffset;
			br.SeekTo(mapOffset);
			Read(br);
		}

		public override void Write(EndianWriter bw)
		{
			bw.SeekTo(mapOffset);
			base.Write(bw);
		}
	}
}
