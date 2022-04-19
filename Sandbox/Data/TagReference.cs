using Sandbox.IO;

namespace Sandbox.Data
{
	public class TagReference : Chunk
	{
		public string TagClass;

		[Size(8)]
		public byte[] Unknown;

		public short Ident;

		public short Index;

		private IdentType IDType;

		public TagReference()
		{
		}

		public TagReference(EndianReader br, IdentType type)
		{
			IDType = type;
			Read(br);
		}

		public override void Read(EndianReader br)
		{
			if (IDType == IdentType.TagReference)
			{
				TagClass = new string(br.ReadChars(4));
				Unknown = br.ReadBytes(8);
			}
			Ident = br.ReadInt16();
			Index = br.ReadInt16();
		}

		public override void Write(EndianWriter bw)
		{
			if (IDType == IdentType.TagReference)
			{
				bw.Write(TagClass.ToCharArray());
				bw.Write(Unknown);
			}
			bw.Write(Ident);
			bw.Write(Index);
		}
	}
}
