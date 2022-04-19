using System;
using System.IO;

namespace Sandbox.IO
{
	public class EndianWriter : BinaryWriter
	{
		private EndianType endianstyle;

		public EndianWriter(Stream stream, EndianType endianstyle)
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

		public override void Write(short value)
		{
			Write(value, endianstyle);
		}

		public void Write(short value, EndianType EndianType)
		{
			byte[] buffer = BitConverter.GetBytes(value);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			base.Write(buffer);
		}

		public override void Write(ushort value)
		{
			Write(value, endianstyle);
		}

		public void Write(ushort value, EndianType EndianType)
		{
			byte[] buffer = BitConverter.GetBytes(value);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			base.Write(buffer);
		}

		public override void Write(int value)
		{
			Write(value, endianstyle);
		}

		public void Write(int value, EndianType EndianType)
		{
			byte[] buffer = BitConverter.GetBytes(value);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			base.Write(buffer);
		}

		public override void Write(uint value)
		{
			Write(value, endianstyle);
		}

		public void Write(uint value, EndianType EndianType)
		{
			byte[] buffer = BitConverter.GetBytes(value);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			base.Write(buffer);
		}

		public override void Write(long value)
		{
			Write(value, endianstyle);
		}

		public void Write(long value, EndianType EndianType)
		{
			byte[] buffer = BitConverter.GetBytes(value);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			base.Write(buffer);
		}

		public override void Write(ulong value)
		{
			Write(value, endianstyle);
		}

		public void Write(ulong value, EndianType EndianType)
		{
			byte[] buffer = BitConverter.GetBytes(value);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			base.Write(buffer);
		}

		public override void Write(float value)
		{
			Write(value, endianstyle);
		}

		public void Write(float value, EndianType EndianType)
		{
			byte[] buffer = BitConverter.GetBytes(value);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			base.Write(buffer);
		}

		public override void Write(double value)
		{
			Write(value, endianstyle);
		}

		public void Write(double value, EndianType EndianType)
		{
			byte[] buffer = BitConverter.GetBytes(value);
			if (EndianType == EndianType.BigEndian)
			{
				Array.Reverse(buffer);
			}
			base.Write(buffer);
		}

		public void WriteAsciiString(string String, int Length)
		{
			WriteAsciiString(String, Length, endianstyle);
		}

		public void WriteAsciiString(string String, int Length, EndianType EndianType)
		{
			int strLen = String.Length;
			for (int x = 0; x < strLen && x <= Length; x++)
			{
				byte val = (byte)String[x];
				Write(val);
			}
			int nullSize = Length - strLen;
			if (nullSize > 0)
			{
				Write(new byte[nullSize]);
			}
		}

		public void WriteUnicodeString(string String, int Length)
		{
			WriteUnicodeString(String, Length, endianstyle);
		}

		public void WriteUnicodeString(string String, int Length, EndianType EndianType)
		{
			int strLen = String.Length;
			for (int x = 0; x < strLen && x <= Length; x++)
			{
				ushort val = String[x];
				Write(val, EndianType);
			}
			int nullSize = (Length - strLen) * 2;
			if (nullSize > 0)
			{
				Write(new byte[nullSize]);
			}
		}
	}
}
