using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Sandbox.IO;

namespace Sandbox.Data
{
	public abstract class Chunk
	{
		private FieldInfo[] fields;

		public Chunk()
		{
		}

		public void SetFields()
		{
			fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
		}

		public virtual void Read(EndianReader br)
		{
			fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
			FieldInfo[] array = fields;
			foreach (FieldInfo fi in array)
			{
				if (fi.FieldType == typeof(byte))
				{
					fi.SetValue(this, br.ReadByte());
				}
				else if (fi.FieldType == typeof(char))
				{
					fi.SetValue(this, br.ReadChar());
				}
				else if (fi.FieldType == typeof(short))
				{
					fi.SetValue(this, br.ReadInt16());
				}
				else if (fi.FieldType == typeof(ushort))
				{
					fi.SetValue(this, br.ReadUInt16());
				}
				else if (fi.FieldType == typeof(int))
				{
					fi.SetValue(this, br.ReadInt32());
				}
				else if (fi.FieldType == typeof(uint))
				{
					fi.SetValue(this, br.ReadUInt32());
				}
				else if (fi.FieldType == typeof(long))
				{
					fi.SetValue(this, br.ReadInt64());
				}
				else if (fi.FieldType == typeof(ulong))
				{
					fi.SetValue(this, br.ReadUInt64());
				}
				else if (fi.FieldType == typeof(double))
				{
					fi.SetValue(this, br.ReadDouble());
				}
				else if (fi.FieldType == typeof(float))
				{
					fi.SetValue(this, br.ReadSingle());
				}
				else if (fi.FieldType == typeof(float))
				{
					fi.SetValue(this, br.ReadSingle());
				}
				else if (fi.FieldType.IsEnum)
				{
					Type t = Enum.GetUnderlyingType(fi.FieldType);
					if (t == typeof(byte))
					{
						fi.SetValue(this, br.ReadByte());
					}
					else if (t == typeof(short))
					{
						fi.SetValue(this, br.ReadInt16());
					}
					else if (t == typeof(int))
					{
						fi.SetValue(this, br.ReadInt32());
					}
					else if (t == typeof(long))
					{
						fi.SetValue(this, br.ReadInt64());
					}
					else
					{
						MessageBox.Show("Unable to read this enum type! Type: " + t.ToString());
					}
				}
				else if (fi.FieldType == typeof(byte[]))
				{
					int size = 0;
					object[] attributes = fi.GetCustomAttributes(typeof(SizeAttribute), inherit: true);
					if (attributes.Length > 0)
					{
						size = ((SizeAttribute)attributes[0]).Size;
					}
					fi.SetValue(this, br.ReadBytes(size));
				}
				else if (fi.FieldType == typeof(char[]))
				{
					int size = 0;
					object[] attributes = fi.GetCustomAttributes(typeof(SizeAttribute), inherit: true);
					if (attributes.Length > 0)
					{
						size = ((SizeAttribute)attributes[0]).Size;
					}
					fi.SetValue(this, br.ReadChars(size));
				}
				else if (fi.FieldType == typeof(string))
				{
					int size = 32;
					StringType st = StringType.Ascii;
					object[] attributes = fi.GetCustomAttributes(typeof(StringAttribute), inherit: true);
					if (attributes.Length > 0)
					{
						size = ((StringAttribute)attributes[0]).Size;
						st = ((StringAttribute)attributes[0]).StringType;
					}
					string temp = "";
					if (st == StringType.Ascii)
					{
						ASCIIEncoding ae = new ASCIIEncoding();
						temp = ae.GetString(br.ReadBytes(size)).Replace("\0", "");
					}
					else
					{
						temp = br.ReadUnicodeString(size);
					}
					fi.SetValue(this, temp);
				}
				else if (fi.FieldType == typeof(Bitmask8))
				{
					string[] options = null;
					object[] attributes = fi.GetCustomAttributes(typeof(OptionsAttribute), inherit: true);
					if (attributes.Length > 0)
					{
						options = ((OptionsAttribute)attributes[0]).Options;
					}
					object bm = Activator.CreateInstance(fi.FieldType, br, options);
					fi.SetValue(this, bm);
				}
				else if (fi.FieldType == typeof(Bitmask16))
				{
					string[] options = null;
					object[] attributes = fi.GetCustomAttributes(typeof(OptionsAttribute), inherit: true);
					if (attributes.Length > 0)
					{
						options = ((OptionsAttribute)attributes[0]).Options;
					}
					object bm = Activator.CreateInstance(fi.FieldType, br, options);
					fi.SetValue(this, bm);
				}
				else if (fi.FieldType == typeof(Bitmask32))
				{
					string[] options = null;
					object[] attributes = fi.GetCustomAttributes(typeof(OptionsAttribute), inherit: true);
					if (attributes.Length > 0)
					{
						options = ((OptionsAttribute)attributes[0]).Options;
					}
					object bm = Activator.CreateInstance(fi.FieldType, br, options);
					fi.SetValue(this, bm);
				}
				else if (fi.FieldType == typeof(TagReference))
				{
					IdentType type = IdentType.TagReference;
					object[] attributes = fi.GetCustomAttributes(typeof(IdentAttribute), inherit: true);
					if (attributes.Length > 0)
					{
						type = ((IdentAttribute)attributes[0]).Type;
					}
					object tagref = Activator.CreateInstance(fi.FieldType, br, type);
					fi.SetValue(this, tagref);
				}
				else
				{
					MessageBox.Show("Unable to read this datatype! Type: " + fi.FieldType.ToString());
				}
			}
		}

		public virtual void Write(EndianWriter bw)
		{
			FieldInfo[] array = fields;
			foreach (FieldInfo fi in array)
			{
				if (fi.FieldType == typeof(byte))
				{
					bw.Write((byte)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(char))
				{
					bw.Write((char)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(short))
				{
					bw.Write((short)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(ushort))
				{
					bw.Write((ushort)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(int))
				{
					bw.Write((int)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(uint))
				{
					bw.Write((uint)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(long))
				{
					bw.Write((long)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(ulong))
				{
					bw.Write((ulong)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(double))
				{
					bw.Write((double)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(float))
				{
					bw.Write((float)fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(float))
				{
					bw.Write((float)fi.GetValue(this));
				}
				else if (fi.FieldType.IsEnum)
				{
					Type t2 = Enum.GetUnderlyingType(fi.FieldType);
					if (t2 == typeof(byte))
					{
						bw.Write((byte)fi.GetValue(this));
					}
					else if (t2 == typeof(short))
					{
						bw.Write((short)fi.GetValue(this));
					}
					else if (t2 == typeof(int))
					{
						bw.Write((int)fi.GetValue(this));
					}
					else if (t2 == typeof(long))
					{
						bw.Write((long)fi.GetValue(this));
					}
					else
					{
						MessageBox.Show("Unable to write this enum type! Type: " + t2.ToString());
					}
				}
				else if (fi.FieldType == typeof(char[]))
				{
					bw.Write((char[])fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(byte[]))
				{
					bw.Write((byte[])fi.GetValue(this));
				}
				else if (fi.FieldType == typeof(string))
				{
					int size = 32;
					StringType st = StringType.Ascii;
					object[] attributes = fi.GetCustomAttributes(typeof(StringAttribute), inherit: true);
					if (attributes.Length > 0)
					{
						size = ((StringAttribute)attributes[0]).Size;
						st = ((StringAttribute)attributes[0]).StringType;
					}
					if (st == StringType.Ascii)
					{
						bw.WriteAsciiString((string)fi.GetValue(this), size);
					}
					else
					{
						bw.WriteUnicodeString((string)fi.GetValue(this), size);
					}
				}
				else if (fi.FieldType == typeof(Bitmask8))
				{
					Bitmask8 b3 = (Bitmask8)fi.GetValue(this);
					b3.Write(bw);
				}
				else if (fi.FieldType == typeof(Bitmask16))
				{
					Bitmask16 b2 = (Bitmask16)fi.GetValue(this);
					b2.Write(bw);
				}
				else if (fi.FieldType == typeof(Bitmask32))
				{
					Bitmask32 b = (Bitmask32)fi.GetValue(this);
					b.Write(bw);
				}
				else if (fi.FieldType == typeof(TagReference))
				{
					TagReference t = (TagReference)fi.GetValue(this);
					t.Write(bw);
				}
				else
				{
					MessageBox.Show("Unable to write this datatype! Type: " + fi.FieldType.ToString());
				}
			}
		}
	}
}
