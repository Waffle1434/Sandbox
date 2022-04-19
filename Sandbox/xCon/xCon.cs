using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using Sandbox.IO;

namespace Sandbox.xCon
{
	public class xCon
	{
		public struct Block
		{
			public int Offset;

			public int Size;

			public string Name;

			public Color Color;
		}

		public class BlockSorter : IComparer<Block>
		{
			public int Compare(Block a, Block b)
			{
				return a.Offset.CompareTo(b.Offset);
			}
		}

		public class STFS_DIRENT
		{
			public uint blockNum;

			public uint createTime;

			public uint curAlloc;

			public ushort dirIndex;

			public string fileName = "";

			public uint fileSize;

			public byte flags = 0;

			public uint modTime;

			public uint totalAlloc;

			public bool isDir => (flags & 0x80) >> 7 == 1;

			public bool isValid => flags != 0;

			public void Read(EndianReader er)
			{
				fileName = er.ReadAsciiString(40);
				flags = er.ReadByte();
				curAlloc = (uint)er.ReadInt24(EndianType.LittleEndian);
				totalAlloc = (uint)er.ReadInt24(EndianType.LittleEndian);
				blockNum = (uint)er.ReadInt24(EndianType.LittleEndian);
				dirIndex = er.ReadUInt16();
				fileSize = er.ReadUInt32();
				createTime = er.ReadUInt32();
				modTime = er.ReadUInt32();
			}

			public void Write(EndianWriter ew)
			{
			}
		}

		public class stfsVolumeDescriptorReader
		{
			public int directoryRelocator;

			public byte[] hashtableHash;

			public byte structSize;

			public ushort unknown1;

			public ushort unknown2;

			public uint unknown3;

			public uint unknown4;

			public stfsVolumeDescriptorReader()
			{
				structSize = 0;
				unknown1 = 0;
				unknown2 = 0;
				directoryRelocator = 0;
				hashtableHash = new byte[20];
				unknown3 = 0u;
				unknown4 = 0u;
			}

			public stfsVolumeDescriptorReader(byte[] stfsVolumeDescriptor)
			{
				structSize = 0;
				unknown1 = 0;
				unknown2 = 0;
				directoryRelocator = 0;
				hashtableHash = new byte[20];
				unknown3 = 0u;
				unknown4 = 0u;
				Read(stfsVolumeDescriptor);
			}

			public void Read(byte[] stfsVolumeDescriptor)
			{
				MemoryStream stream = new MemoryStream(stfsVolumeDescriptor);
				EndianReader reader = new EndianReader(stream, EndianType.BigEndian);
				structSize = reader.ReadByte();
				unknown1 = reader.ReadUInt16(EndianType.LittleEndian);
				unknown2 = reader.ReadUInt16(EndianType.LittleEndian);
				directoryRelocator = reader.ReadInt24(EndianType.LittleEndian);
				hashtableHash = reader.ReadBytes(20);
				unknown3 = reader.ReadUInt32();
				unknown4 = reader.ReadUInt32();
			}

			public byte[] Write()
			{
				MemoryStream stream = new MemoryStream();
				EndianWriter writer = new EndianWriter(stream, EndianType.BigEndian);
				writer.Write(structSize);
				writer.Write(unknown1, EndianType.LittleEndian);
				writer.Write(unknown2, EndianType.LittleEndian);
				writer.Write(hashtableHash);
				writer.Write(unknown3);
				writer.Write(unknown4);
				return stream.ToArray();
			}
		}

		public uint baseVersion;

		public string conMagic;

		public byte[] conSignature;

		public byte[] consoleID;

		public byte[] contentID;

		public ulong contentSize;

		public uint contentType;

		public ulong creator;

		public uint dataFiles;

		public ulong dataFileSize;

		public string description;

		public string[] descriptionEx;

		public byte[] deviceId;

		public List<STFS_DIRENT> dirents;

		public byte discNum;

		public byte discsInSet;

		public string displayName;

		public string[] displayNameEx;

		public byte executableType;

		public EndianIO io;

		public byte[] licenseFlags;

		public uint mediaID;

		public byte[] metaDataPadding;

		public uint metaDataVersion;

		public byte platform;

		public byte[] pubKey;

		public string publisher;

		public ulong reserved2;

		public uint saveGameID;

		public uint sizeOfHeaders;

		private stfsVolumeDescriptorReader stfsvd;

		public byte[] stfsVolumeDescriptor;

		public byte[] thumbnailImage;

		public uint thumbnailSize;

		public uint TitleID;

		public string titleName;

		public byte[] titleThumbnailImage;

		public uint titleThumbnailSize;

		public byte transferFlags;

		public uint version;

		public xCon()
		{
			conMagic = "CON ";
			pubKey = new byte[424];
			conSignature = new byte[128];
			licenseFlags = new byte[256];
			contentID = new byte[20];
			sizeOfHeaders = 0u;
			contentType = 0u;
			metaDataVersion = 0u;
			contentSize = 0uL;
			mediaID = 0u;
			version = 0u;
			baseVersion = 0u;
			TitleID = 0u;
			platform = 0;
			executableType = 0;
			discNum = 0;
			discsInSet = 0;
			saveGameID = 0u;
			consoleID = new byte[5];
			creator = 0uL;
			stfsVolumeDescriptor = new byte[36];
			dataFiles = 0u;
			dataFileSize = 0uL;
			reserved2 = 0uL;
			metaDataPadding = new byte[76];
			deviceId = new byte[20];
			displayName = "";
			displayNameEx = new string[8];
			description = "";
			descriptionEx = new string[8];
			publisher = "";
			titleName = "";
			transferFlags = 0;
			thumbnailSize = 0u;
			titleThumbnailSize = 0u;
			thumbnailImage = new byte[16384];
			titleThumbnailImage = new byte[16384];
			dirents = new List<STFS_DIRENT>();
			io = new EndianIO(new MemoryStream(), EndianType.BigEndian);
		}

		public xCon(string FilePath)
		{
			conMagic = "CON ";
			pubKey = new byte[424];
			conSignature = new byte[128];
			licenseFlags = new byte[256];
			contentID = new byte[20];
			sizeOfHeaders = 0u;
			contentType = 0u;
			metaDataVersion = 0u;
			contentSize = 0uL;
			mediaID = 0u;
			version = 0u;
			baseVersion = 0u;
			TitleID = 0u;
			platform = 0;
			executableType = 0;
			discNum = 0;
			discsInSet = 0;
			saveGameID = 0u;
			consoleID = new byte[5];
			creator = 0uL;
			stfsVolumeDescriptor = new byte[36];
			dataFiles = 0u;
			dataFileSize = 0uL;
			reserved2 = 0uL;
			metaDataPadding = new byte[76];
			deviceId = new byte[20];
			displayName = "";
			displayNameEx = new string[8];
			description = "";
			descriptionEx = new string[8];
			publisher = "";
			titleName = "";
			transferFlags = 0;
			thumbnailSize = 0u;
			titleThumbnailSize = 0u;
			thumbnailImage = new byte[16384];
			titleThumbnailImage = new byte[16384];
			dirents = new List<STFS_DIRENT>();
			io = new EndianIO(FilePath, EndianType.BigEndian);
		}

		public List<Block> Analyze()
		{
			List<Block> list = new List<Block>();
			Block item = default(Block);
			item.Offset = 0;
			item.Size = 40960;
			item.Name = string.Format("{0}\nOffset: 0x{1:X8}\nSize: 0x{2:X8}", "Meta Data", item.Offset, item.Size);
			item.Color = Color.Blue;
			list.Add(item);
			Block block2 = default(Block);
			block2.Offset = 40960;
			block2.Size = 4096;
			block2.Name = string.Format("{0}\nOffset: 0x{1:X8}\nSize: 0x{2:X8}", "Hash table 1", block2.Offset, block2.Size);
			block2.Color = Color.Pink;
			list.Add(block2);
			Block block3 = default(Block);
			block3.Offset = 45056;
			block3.Size = 4096;
			block3.Name = string.Format("{0}\nOffset: 0x{1:X8}\nSize: 0x{2:X8}", "Hash table 2", block3.Offset, block3.Size);
			block3.Color = Color.Plum;
			list.Add(block3);
			Block block4 = default(Block);
			block4.Offset = 49152 + stfsvd.directoryRelocator * 4096;
			block4.Size = 4096;
			block4.Color = Color.Red;
			block4.Name = string.Format("{0}\nOffset: 0x{1:X8}\nSize: 0x{2:X8}", "File Table", block4.Offset, block4.Size);
			list.Add(block4);
			EndianReader @in = io.In;
			Block block5;
			foreach (STFS_DIRENT stfs_dirent in dirents)
			{
				if (stfs_dirent.isDir)
				{
					continue;
				}
				int blockNum = (int)stfs_dirent.blockNum;
				int num2 = 1;
				int num3 = 0;
				while (true)
				{
					block5 = default(Block);
					block5.Color = Color.Orange;
					block5.Offset = 49152 + blockNum * 4096;
					block5.Size = 4096;
					block5.Name = $"{stfs_dirent.fileName}\nOffset: 0x{block5.Offset:X8}\nSize: 0x{block5.Size:X8}";
					list.Add(block5);
					@in.SeekTo(40960 + 4096 * num2 + blockNum * 24 + 21);
					blockNum = io.In.ReadInt24();
					if (blockNum == 16777215)
					{
						break;
					}
					num3++;
				}
			}
			list.Sort(new BlockSorter());
			List<Block> list2 = new List<Block>();
			for (int i = 0; i < list.Count - 1; i++)
			{
				list2.Add(list[i]);
				if (list[i].Offset + list[i].Size != list[i + 1].Offset)
				{
					block5 = default(Block);
					block5.Offset = list[i].Offset + list[i].Size;
					block5.Size = list[i + 1].Offset - block5.Offset;
					block5.Color = Color.Gray;
					block5.Name = $"Unknown\nOffset: 0x{block5.Offset:X8}\nSize: 0x{block5.Size:X8}";
					list2.Add(block5);
				}
			}
			if (list[list.Count - 1].Offset + list[list.Count - 1].Size != (int)io.Stream.Length)
			{
				block5 = default(Block);
				block5.Offset = list[list.Count - 1].Offset + list[list.Count - 1].Size;
				block5.Size = (int)io.Stream.Length - block5.Offset;
				block5.Color = Color.Gray;
				block5.Name = $"Unknown\nOffset: 0x{block5.Offset:X8}\nSize: 0x{block5.Size:X8}";
				list2.Add(block5);
			}
			list2.Add(list[list.Count - 1]);
			return list2;
		}

		public void Close()
		{
			io.Close();
		}

		public void ExtractAll(string ExtractDirectory)
		{
			for (int i = 0; i < dirents.Count; i++)
			{
				if (!dirents[i].isDir)
				{
					ExtractFile(i, ExtractDirectory + dirents[i].fileName);
				}
			}
		}

		public void ExtractFile(int DirentIndex, string ExtractPath)
		{
			FileStream output = new FileStream(ExtractPath, FileMode.Create, FileAccess.Write);
			BinaryWriter writer = new BinaryWriter(output);
			EndianReader @in = io.In;
			STFS_DIRENT stfs_dirent = dirents[DirentIndex];
			if (stfs_dirent.isDir)
			{
				throw new Exception("You cannot extract a directory!");
			}
			int blockNum = (int)stfs_dirent.blockNum;
			int num2 = 1;
			int num3 = 0;
			while (true)
			{
				bool flag = true;
				@in.SeekTo(49152 + blockNum * 4096);
				writer.Write(@in.ReadBytes(4096));
				@in.SeekTo(40960 + 4096 * num2 + blockNum * 24 + 21);
				blockNum = io.In.ReadInt24();
				if (blockNum == 16777215)
				{
					break;
				}
				num3++;
			}
			output.Close();
		}

		public uint GetDirentOffset(STFS_DIRENT Dirent)
		{
			return 49152 + 4096 * Dirent.blockNum;
		}

		private byte[] HashDataBlock(byte[] Data)
		{
			return SHA1.Create().ComputeHash(Data);
		}

		public void Open()
		{
			io.Open();
		}

		public void Read()
		{
			EndianReader @in = io.In;
			conMagic = @in.ReadAsciiString(4);
			pubKey = @in.ReadBytes(424);
			conSignature = @in.ReadBytes(128);
			licenseFlags = @in.ReadBytes(256);
			contentID = @in.ReadBytes(20);
			sizeOfHeaders = @in.ReadUInt32();
			contentType = @in.ReadUInt32();
			metaDataVersion = @in.ReadUInt32();
			contentSize = @in.ReadUInt64();
			mediaID = @in.ReadUInt32();
			version = @in.ReadUInt32();
			baseVersion = @in.ReadUInt32();
			TitleID = @in.ReadUInt32();
			platform = @in.ReadByte();
			executableType = @in.ReadByte();
			discNum = @in.ReadByte();
			discsInSet = @in.ReadByte();
			saveGameID = @in.ReadUInt32();
			consoleID = @in.ReadBytes(5);
			creator = @in.ReadUInt64();
			stfsVolumeDescriptor = @in.ReadBytes(36);
			dataFiles = @in.ReadUInt32();
			dataFileSize = @in.ReadUInt64();
			reserved2 = @in.ReadUInt64();
			metaDataPadding = @in.ReadBytes(76);
			deviceId = @in.ReadBytes(20);
			displayName = @in.ReadUnicodeString(128);
			for (int num = 0; num < 8; num++)
			{
				displayNameEx[num] = @in.ReadUnicodeString(128);
			}
			description = @in.ReadUnicodeString(128);
			for (int num = 0; num < 8; num++)
			{
				descriptionEx[num] = @in.ReadUnicodeString(128);
			}
			publisher = @in.ReadUnicodeString(64);
			titleName = @in.ReadUnicodeString(64);
			transferFlags = @in.ReadByte();
			thumbnailSize = @in.ReadUInt32();
			titleThumbnailSize = @in.ReadUInt32();
			thumbnailImage = @in.ReadBytes(16384);
			titleThumbnailImage = @in.ReadBytes(16384);
			stfsvd = new stfsVolumeDescriptorReader(stfsVolumeDescriptor);
			dirents.Clear();
			@in.SeekTo(49152 + 4096 * stfsvd.directoryRelocator);
			while (true)
			{
				bool flag = true;
				STFS_DIRENT item = new STFS_DIRENT();
				item.Read(@in);
				if (!item.isValid)
				{
					break;
				}
				dirents.Add(item);
			}
		}

		public void Write()
		{
			EndianWriter @out = io.Out;
			@out.WriteAsciiString(conMagic, 4);
			@out.Write(pubKey);
			@out.Write(conSignature);
			@out.Write(licenseFlags);
			@out.Write(contentID);
			@out.Write(sizeOfHeaders);
			@out.Write(contentType);
			@out.Write(metaDataVersion);
			@out.Write(contentSize);
			@out.Write(mediaID);
			@out.Write(version);
			@out.Write(baseVersion);
			@out.Write(TitleID);
			@out.Write(platform);
			@out.Write(executableType);
			@out.Write(discNum);
			@out.Write(discsInSet);
			@out.Write(saveGameID);
			@out.Write(consoleID);
			@out.Write(creator);
			@out.Write(stfsVolumeDescriptor);
			@out.Write(dataFiles);
			@out.Write(dataFileSize);
			@out.Write(reserved2);
			@out.Write(metaDataPadding);
			@out.Write(deviceId);
			@out.WriteUnicodeString(displayName, 128);
			for (int num = 0; num < 8; num++)
			{
				@out.WriteUnicodeString(displayNameEx[num], 128);
			}
			@out.WriteUnicodeString(description, 128);
			for (int num = 0; num < 8; num++)
			{
				@out.WriteUnicodeString(descriptionEx[num], 128);
			}
			@out.WriteUnicodeString(publisher, 64);
			@out.WriteUnicodeString(titleName, 64);
			@out.Write(transferFlags);
			@out.Write(thumbnailSize);
			@out.Write(titleThumbnailSize);
			@out.Write(thumbnailImage);
			@out.Write(titleThumbnailImage);
		}
	}
}
