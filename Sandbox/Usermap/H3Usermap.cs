using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Sandbox.Data;
using Sandbox.Editor;
using Sandbox.IO;

namespace Sandbox.Usermap
{
	public class H3Usermap
	{
		public class Header : Chunk
		{
			[Size(4)]
			public char[] MapV;

			public int Size;

			public short Unknown_8;

			public short Unknown_10;

			[Size(12)]
			public byte[] Unknown_12;

			[String(StringType.Unicode, 16)]
			public string varientName;

			[String(128)]
			public string varientDescription;

			[String(16)]
			public string varientAuthor;

			public int Unknown_200;

			public int Unknown_204;

			public int Unknown_208;

			public int Unknown_212;

			public int Unknown_216;

			public int Entry_Size;

			public int CON_File_Name_1;

			public int CON_FIle_Name_2;

			public int Unknown_232;

			public int NULL;

			public int varientMapId;

			public int Unknown_244;

			public int NULL_2;

			public short NULL_3;

			[Size(10)]
			public byte[] Unknown_254;

			[System.ComponentModel.Description("Author of this usermap")]
			[Category("Map Info")]
			public string Author
			{
				get
				{
					return varientAuthor;
				}
				set
				{
					varientAuthor = OnAuthorChange(value);
				}
			}

			[System.ComponentModel.Description("Name of this usermap.")]
			[Category("Map Info")]
			public string Name
			{
				get
				{
					return varientName;
				}
				set
				{
					varientName = OnNameChange(value);
				}
			}

			[System.ComponentModel.Description("Desscription of this usermap.")]
			[Category("Map Info")]
			public string Description
			{
				get
				{
					return varientDescription;
				}
				set
				{
					varientDescription = OnDescriptionChange(value);
				}
			}

			[System.ComponentModel.Description("What map is this usermap for.")]
			[Category("Map Info")]
			public Misc.MapID MapId
			{
				get
				{
					return (Misc.MapID)varientMapId;
				}
				set
				{
					varientMapId = (int)value;
				}
			}

			protected string OnAuthorChange(string author)
			{
				if (author.Length <= 16)
				{
					return author;
				}
				MessageBox.Show("Author name must not be greater than 16 characters.", "Too long.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return varientAuthor;
			}

			protected string OnNameChange(string name)
			{
				if (name.Length <= 16)
				{
					return name;
				}
				MessageBox.Show("Map name must not be greater than 16 characters.", "Too long.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return name;
			}

			protected string OnDescriptionChange(string description)
			{
				if (description.Length <= 128)
				{
					return description;
				}
				MessageBox.Show("Description name must not be greater than 128 characters.", "Too long.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return varientDescription;
			}
		}

		public class UnnamedBlock1 : Chunk
		{
			public short Unknown;

			public short Unknown_2;

			public byte Unknown_4;

			public byte Spawned_Object_Count;

			public short Unknown_6;

			public int Map_ID;

			public float World_Bounds_X_Min;

			public float World_Bounds_X_Max;

			public float World_Bounds_Y_Min;

			public float World_Bounds_Y_Max;

			public float World_Bounds_Z_Min;

			public float World_Bounds_Z_Max;

			public int Unknown_36;

			public float Maximum_Budget;

			public float Current_Budget;

			public int Unknown_48;

			public int Unknown_52;
		}

		public class PlacementBlock : Chunk
		{
			public enum blockType : short
			{
				Player_Spawn = 9,
				Reserved = 41,
				Added = 131,
				Original = 137,
				Edited = 139,
				NULL = 0
			}

			public short Block_Type;

			[Size(10)]
			public byte[] Unused_4;

			public int Tags_Index;

			public float posX;

			public float posY;

			public float posZ;

			public float posYaw;

			public float posPitch;

			public float posRoll;

			public float Unknown_Rot_1;

			public float Unknown_Rot_2;

			public float Unknown_Rot_3;

			[Size(8)]
			public byte[] Unused_52;

			public byte Unknown_60;

			public byte Unknown_61;

			public byte flags;

			public byte team;

			public byte spareClips;

			public byte respawnTime;

			public short Unknown66;

			[Size(16)]
			public byte[] Unused_68;

			[Category("Block Type")]
			[System.ComponentModel.Description("What kind of placement block is this.")]
			[Browsable(true)]
			public blockType BlockType
			{
				get
				{
					return (blockType)Block_Type;
				}
				set
				{
					Block_Type = (short)value;
				}
			}

			[System.ComponentModel.Description("X co-ordinat object will spawn at.")]
			[Category("Spawn Location")]
			public float X
			{
				get
				{
					return posX;
				}
				set
				{
					posX = value;
				}
			}

			[System.ComponentModel.Description("Y co-ordinat object will spawn at.")]
			[Category("Spawn Location")]
			public float Y
			{
				get
				{
					return posY;
				}
				set
				{
					posY = value;
				}
			}

			[System.ComponentModel.Description("Z co-ordinat object will spawn at.")]
			[Category("Spawn Location")]
			public float Z
			{
				get
				{
					return posZ;
				}
				set
				{
					posZ = value;
				}
			}

			[Category("Object Rotation")]
			[System.ComponentModel.Description("Y axis rotation of object")]
			public float Yaw
			{
				get
				{
					return posYaw;
				}
				set
				{
					posYaw = value;
				}
			}

			[Category("Object Rotation")]
			[System.ComponentModel.Description("P axis rotation of object")]
			public float Pitch
			{
				get
				{
					return posPitch;
				}
				set
				{
					posPitch = value;
				}
			}

			[Category("Object Rotation")]
			[System.ComponentModel.Description("R axis rotation of object")]
			public float Roll
			{
				get
				{
					return posRoll;
				}
				set
				{
					posRoll = value;
				}
			}

			[Category("Respawn Settings")]
			public byte Flags
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

			[System.ComponentModel.Description("Team this object belongs to.")]
			[Category("Respawn Settings")]
			public byte Team
			{
				get
				{
					return team;
				}
				set
				{
					team = value;
				}
			}

			[Category("Respawn Settings")]
			[System.ComponentModel.Description("Amount of spare clips does this object has.")]
			public byte SpareClips
			{
				get
				{
					return spareClips;
				}
				set
				{
					spareClips = value;
				}
			}

			[Category("Respawn Settings")]
			[System.ComponentModel.Description("How long this object takes to respawn.")]
			public byte RespawnTime
			{
				get
				{
					return respawnTime;
				}
				set
				{
					respawnTime = value;
				}
			}

			[System.ComponentModel.Description("Index of object to spawn in tag index.")]
			[Category("Tag Reference")]
			public int TagIndex
			{
				get
				{
					return Tags_Index;
				}
				set
				{
					Tags_Index = OnTagIndexChanged(value);
				}
			}

			public void LoadNull()
			{
				SetFields();
				Block_Type = 0;
				Unused_4 = new byte[10] { 0, 0, 255, 255, 255, 255, 255, 255, 255, 255 };
				Tags_Index = -1;
				posX = 0f;
				posY = 0f;
				posZ = 0f;
				posYaw = 0f;
				posPitch = 0f;
				posRoll = 0f;
				Unknown_Rot_1 = 0f;
				Unknown_Rot_2 = 0f;
				Unknown_Rot_3 = 0f;
				Unused_52 = new byte[8] { 255, 255, 255, 255, 255, 255, 255, 255 };
				Unknown_60 = 0;
				Unknown_61 = 0;
				flags = 12;
				team = 9;
				spareClips = 0;
				respawnTime = 0;
				Unknown66 = 0;
				byte[] array = (Unused_68 = new byte[16]);
			}

			protected int OnTagIndexChanged(int index)
			{
				if (index >= 0 && index <= 254)
				{
					return index;
				}
				MessageBox.Show("Index must be between 0 and 254.", "Invalid index entered.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return Tags_Index;
			}
		}

		public class TagIndexEntry : Chunk
		{
			public int ident;

			public byte run_Time_Minimun;

			public byte run_Time_Maximun;

			public byte number_On_Map;

			public byte design_Time_Maximun;

			public float total_Cost;

			[Category("Object Info")]
			[Editor(typeof(UIIdentSwapper), typeof(UITypeEditor))]
			[System.ComponentModel.Description("What object will spawn.")]
			public string Ident
			{
				get
				{
					return GlobalVariables.Plugin.GetTagNameFromID(ident);
				}
				set
				{
					ident = GlobalVariables.Plugin.GetIDFromTagName(value);
				}
			}

			[Category("Spawn Rules")]
			[System.ComponentModel.Description("Minimun number of this object that can spawn at one time ingame")]
			public byte RunTimeMinimun
			{
				get
				{
					return run_Time_Minimun;
				}
				set
				{
					run_Time_Minimun = value;
				}
			}

			[System.ComponentModel.Description("Maximun number of this object that can spawn at one time ingame.")]
			[Category("Spawn Rules")]
			public byte RunTimeMaximun
			{
				get
				{
					return run_Time_Maximun;
				}
				set
				{
					run_Time_Maximun = value;
				}
			}

			[System.ComponentModel.Description("Number of this item on the map.")]
			[Category("Spawn Rules")]
			public byte NumberOnMap
			{
				get
				{
					return number_On_Map;
				}
				set
				{
					number_On_Map = value;
				}
			}

			[System.ComponentModel.Description("Maximun number of this object that can be placed at one time while creating map.")]
			[Category("Spawn Rules")]
			public byte DesignTimeMaximun
			{
				get
				{
					return design_Time_Maximun;
				}
				set
				{
					design_Time_Maximun = value;
				}
			}

			[System.ComponentModel.Description("How much per object does it cost to spawn.")]
			[Category("Object Info")]
			public float TotalCost
			{
				get
				{
					return total_Cost;
				}
				set
				{
					total_Cost = value;
				}
			}

			public void LoadNull()
			{
				SetFields();
				ident = -1;
				run_Time_Maximun = 0;
				run_Time_Minimun = 0;
				number_On_Map = 0;
				design_Time_Maximun = byte.MaxValue;
				total_Cost = -1f;
			}
		}

		private EndianIO io;

		public Header header;

		public UnnamedBlock1 unamedBlock1;

		public PlacementBlock[] placementBlocks;

		public TagIndexEntry[] tagIndex;

		public int baseObjectCount;

		public H3Usermap()
		{
		}

		public H3Usermap(string filepath)
		{
			io = new EndianIO(filepath, EndianType.BigEndian);
			io.Open();
		}

		public void Close()
		{
			io.Close();
		}

		public int Read()
		{
			try
			{
				io.In.BaseStream.Position = 0L;
				if (new string(io.In.ReadChars(4)) == "CON ")
				{
					return 1;
				}
				io.In.BaseStream.Position = 312L;
				if (new string(io.In.ReadChars(4)) != "mapv")
				{
					return 2;
				}
				io.In.BaseStream.Position = 312L;
				header = new Header();
				header.Read(io.In);
				unamedBlock1 = new UnnamedBlock1();
				unamedBlock1.Read(io.In);
				io.In.BaseStream.Position = 632L;
				int objCount = 0;
				placementBlocks = new PlacementBlock[640];
				for (int i = 0; i < 640; i++)
				{
					placementBlocks[i] = new PlacementBlock();
					placementBlocks[i].Read(io.In);
					if (placementBlocks[i].BlockType != 0)
					{
						objCount++;
					}
				}
				baseObjectCount = unamedBlock1.Spawned_Object_Count - objCount;
				io.In.BaseStream.Position = 54420L;
				tagIndex = new TagIndexEntry[256];
				for (int i = 0; i < 256; i++)
				{
					tagIndex[i] = new TagIndexEntry();
					tagIndex[i].Read(io.In);
				}
			}
			catch
			{
				return 3;
			}
			return 0;
		}

		public int Write()
		{
			try
			{
				io.Out.BaseStream.Position = 312L;
				header.Write(io.Out);
				unamedBlock1.Write(io.Out);
				io.Out.BaseStream.Position = 632L;
				for (int i = 0; i < 640; i++)
				{
					placementBlocks[i].Write(io.Out);
				}
				io.Out.BaseStream.Position = 54420L;
				for (int i = 0; i < 256; i++)
				{
					tagIndex[i].Write(io.Out);
				}
			}
			catch
			{
				return 1;
			}
			return 0;
		}

		public int FindPlacementBlock(int Ident, int index)
		{
			for (int i = index; i < 640; i++)
			{
				int tagIndex = GlobalVariables.Usermap.placementBlocks[i].TagIndex;
				if (tagIndex != -1 && GlobalVariables.Usermap.tagIndex[tagIndex].ident == Ident)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
