using System.IO;

namespace Sandbox.IO
{
	public class EndianIO
	{
		private bool isfile = false;

		private bool isOpen = false;

		private Stream stream = null;

		private string filepath = "";

		private EndianType endiantype = EndianType.LittleEndian;

		private EndianReader _in = null;

		private EndianWriter _out = null;

		public bool Opened => isOpen;

		public bool Closed => !isOpen;

		public EndianReader In => _in;

		public EndianWriter Out => _out;

		public Stream Stream => stream;

		public EndianIO(string FilePath, EndianType EndianStyle)
		{
			endiantype = EndianStyle;
			filepath = FilePath;
			isfile = true;
		}

		public EndianIO(MemoryStream MemoryStream, EndianType EndianStyle)
		{
			endiantype = EndianStyle;
			stream = MemoryStream;
			isfile = false;
		}

		public EndianIO(Stream Stream, EndianType EndianStyle)
		{
			endiantype = EndianStyle;
			stream = Stream;
			isfile = false;
		}

		public EndianIO(byte[] Buffer, EndianType EndianStyle)
		{
			endiantype = EndianStyle;
			stream = new MemoryStream(Buffer);
			isfile = false;
		}

		public void SeekTo(int offset)
		{
			SeekTo(offset, SeekOrigin.Begin);
		}

		public void SeekTo(uint offset)
		{
			SeekTo((int)offset, SeekOrigin.Begin);
		}

		public void SeekTo(int offset, SeekOrigin SeekOrigin)
		{
			stream.Seek(offset, SeekOrigin);
		}

		public void Open()
		{
			if (!isOpen)
			{
				if (isfile)
				{
					stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
				}
				_in = new EndianReader(stream, endiantype);
				_out = new EndianWriter(stream, endiantype);
				isOpen = true;
			}
		}

		public void Close()
		{
			if (isOpen)
			{
				stream.Close();
				_in.Close();
				_out.Close();
				isOpen = false;
			}
		}
	}
}
