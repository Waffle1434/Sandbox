using System;
using System.IO;

namespace Sandbox.IO
{
	public class EndianReader : BinaryReader
	{
		public EndianType endianstyle;

		public EndianReader(Stream stream, EndianType endianstyle)
			: base(stream)
		{
			this.endianstyle = endianstyle;
		}

		public void SeekTo(int offset)
		{
			SeekTo(offset, SeekOrigin.Begin);
		}

		public void SeekTo(uint offset)
		{
			SeekTo((int)offset, SeekOrigin.Begin);
		}

		public void SeekTo(long offset)
		{
			SeekTo((int)offset, SeekOrigin.Begin);
		}

		public void SeekTo(int offset, SeekOrigin SeekOrigin)
		{
			BaseStream.Seek(offset, SeekOrigin);
		}

		public override short ReadInt16()
		{
			return ReadInt16(endianstyle);
		}

		public short ReadInt16(EndianType EndianType)
		{
			byte[] buffer = base.ReadBytes(2);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			return BitConverter.ToInt16(buffer, 0);
		}

		public override ushort ReadUInt16()
		{
			return ReadUInt16(endianstyle);
		}

		public ushort ReadUInt16(EndianType EndianType)
		{
			byte[] buffer = base.ReadBytes(2);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			return BitConverter.ToUInt16(buffer, 0);
		}

		public override int ReadInt32()
		{
			return ReadInt32(endianstyle);
		}

		public int ReadInt32(EndianType EndianType)
		{
			byte[] buffer = base.ReadBytes(4);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			return BitConverter.ToInt32(buffer, 0);
		}

		public override uint ReadUInt32()
		{
			return ReadUInt32(endianstyle);
		}

		public uint ReadUInt32(EndianType EndianType)
		{
			byte[] buffer = base.ReadBytes(4);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			return BitConverter.ToUInt32(buffer, 0);
		}

		public override long ReadInt64()
		{
			return ReadInt64(endianstyle);
		}

		public long ReadInt64(EndianType EndianType)
		{
			byte[] buffer = base.ReadBytes(8);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			return BitConverter.ToInt64(buffer, 0);
		}

		public override ulong ReadUInt64()
		{
			return ReadUInt64(endianstyle);
		}

		public ulong ReadUInt64(EndianType EndianType)
		{
			byte[] buffer = base.ReadBytes(8);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			return BitConverter.ToUInt64(buffer, 0);
		}

		public override float ReadSingle()
		{
			return ReadSingle(endianstyle);
		}

		public float ReadSingle(EndianType EndianType)
		{
			byte[] buffer = base.ReadBytes(4);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			return BitConverter.ToSingle(buffer, 0);
		}

		public override double ReadDouble()
		{
			return ReadDouble(endianstyle);
		}

		public double ReadDouble(EndianType EndianType)
		{
			byte[] buffer = base.ReadBytes(4);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			return BitConverter.ToDouble(buffer, 0);
		}

		public string ReadNullTerminatedString()
		{
			string newString = "";
			char temp;
			while ((temp = ReadChar()) != 0 && temp != 0)
			{
				newString += temp;
			}
			return newString;
		}

		public string ReadAsciiString(int Length)
		{
			return ReadAsciiString(Length, endianstyle);
		}

		public string ReadAsciiString(int Length, EndianType EndianType)
		{
			string newString = "";
			int howMuch = 0;
			for (int x = 0; x < Length; x++)
			{
				char tempChar = (char)ReadByte();
				howMuch++;
				if (tempChar != 0)
				{
					newString += tempChar;
					continue;
				}
				break;
			}
			int size = Length - howMuch;
			BaseStream.Seek(size, SeekOrigin.Current);
			return newString;
		}

		public string ReadUnicodeString(int Length)
		{
			return ReadUnicodeString(Length, endianstyle);
		}

		public string ReadUnicodeString(int Length, EndianType EndianType)
		{
			string newString = "";
			int howMuch = 0;
			for (int x = 0; x < Length; x++)
			{
				char tempChar = (char)ReadUInt16(EndianType);
				howMuch++;
				if (tempChar != 0)
				{
					newString += tempChar;
					continue;
				}
				break;
			}
			int size = (Length - howMuch) * 2;
			BaseStream.Seek(size, SeekOrigin.Current);
			return newString;
		}

		public string ReadString(int Length)
		{
			return ReadAsciiString(Length);
		}

		public int ReadInt24()
		{
			return ReadInt24(endianstyle);
		}

		public int ReadInt24(EndianType EndianType)
		{
			byte[] buffer = base.ReadBytes(3);
			byte[] dest = new byte[4];
			Array.Copy(buffer, 0, dest, 0, 3);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(dest);
			}
			return BitConverter.ToInt32(dest, 0);
		}
	}
}
