using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Sandbox
{
	public abstract class ISettings
	{
		public virtual void Read(BinaryReader br)
		{
			PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo pi in properties)
			{
				pi.SetValue(this, ReadValue(br, pi.PropertyType), null);
			}
		}

		public virtual void Write(BinaryWriter bw)
		{
			PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo pi in properties)
			{
				WriteValue(bw, pi.GetValue(this, null));
			}
		}

		private object ReadValue(BinaryReader br, Type type)
		{
			if (type == typeof(int))
			{
				return br.ReadInt32();
			}
			if (type == typeof(bool))
			{
				return br.ReadBoolean();
			}
			if (type == typeof(string))
			{
				return br.ReadString();
			}
			if (type.IsEnum)
			{
				Type t = Enum.GetUnderlyingType(type);
				if (t == typeof(byte))
				{
					return br.ReadByte();
				}
				if (t == typeof(short))
				{
					return br.ReadInt16();
				}
				if (t == typeof(int))
				{
					return br.ReadInt32();
				}
				if (t == typeof(long))
				{
					return br.ReadInt64();
				}
				MessageBox.Show("Unable to read this enum type! Type: " + t.ToString());
			}
			else
			{
				if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ISettingList<>))
				{
					object settingList = Activator.CreateInstance(type, new object[0]);
					settingList.GetType().GetMethod("Read").Invoke(settingList, new object[1] { br });
					return settingList;
				}
				MessageBox.Show("Cannot read type " + type.ToString());
			}
			return null;
		}

		private void WriteValue(BinaryWriter bw, object value)
		{
			Type type = value.GetType();
			if (type == typeof(int))
			{
				bw.Write((int)value);
			}
			else if (type == typeof(bool))
			{
				bw.Write((bool)value);
			}
			else if (type == typeof(string))
			{
				bw.Write((string)value);
			}
			else if (type.IsEnum)
			{
				Type t = Enum.GetUnderlyingType(type);
				if (t == typeof(byte))
				{
					bw.Write((byte)value);
				}
				else if (t == typeof(short))
				{
					bw.Write((short)value);
				}
				else if (t == typeof(int))
				{
					bw.Write((int)value);
				}
				else if (t == typeof(long))
				{
					bw.Write((long)value);
				}
				else
				{
					MessageBox.Show("Unable to write this enum type! Type: " + t.ToString());
				}
			}
			else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ISettingList<>))
			{
				MethodInfo mi = type.GetMethod("Write");
				mi.Invoke(value, new object[1] { bw });
			}
			else
			{
				MessageBox.Show("Cannot write type " + type);
			}
		}
	}
}
