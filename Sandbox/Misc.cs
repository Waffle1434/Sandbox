using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sandbox
{
	public static class Misc
	{
		public enum MapID
		{
			Zanzibar = 30,
			Construct = 300,
			Deadlock = 310,
			Gaurdian = 320,
			Isolation = 330,
			Riverworld = 340,
			Salvation = 350,
			Snowbound = 360,
			Chill = 380,
			Cyberdyne = 390,
			Shrine = 400,
			Bunkerworld = 410,
			Avalaunch = 470,
			Warehouse = 480,
			Blackout = 520,
			Armory = 580,
			GhostTown = 590,
			Chillout = 600
		}

		public static string GetPluginName(int mapId)
		{
			return mapId switch
			{
				30 => Application.StartupPath + "\\Plugins\\zanzibar.xml", 
				300 => Application.StartupPath + "\\Plugins\\construct.xml", 
				310 => Application.StartupPath + "\\Plugins\\deadlock.xml", 
				320 => Application.StartupPath + "\\Plugins\\guardian.xml", 
				330 => Application.StartupPath + "\\Plugins\\isolation.xml", 
				340 => Application.StartupPath + "\\Plugins\\riverworld.xml", 
				350 => Application.StartupPath + "\\Plugins\\salvation.xml", 
				360 => Application.StartupPath + "\\Plugins\\snowbound.xml", 
				380 => Application.StartupPath + "\\Plugins\\chill.xml", 
				390 => Application.StartupPath + "\\Plugins\\cyberdyne.xml", 
				400 => Application.StartupPath + "\\Plugins\\shrine.xml", 
				410 => Application.StartupPath + "\\Plugins\\bunkerworld.xml", 
				470 => Application.StartupPath + "\\Plugins\\sidewinder.xml", 
				480 => Application.StartupPath + "\\Plugins\\warehouse.xml", 
				520 => Application.StartupPath + "\\Plugins\\lockout.xml", 
				580 => Application.StartupPath + "\\Plugins\\armory.xml", 
				590 => Application.StartupPath + "\\Plugins\\ghosttown.xml", 
				600 => Application.StartupPath + "\\Plugins\\chillout.xml", 
				_ => null, 
			};
		}

		public static Bitmap GetImagesFromID(int id)
		{
			if (id != -1)
			{
				string path = Application.StartupPath + "\\Images\\" + GlobalVariables.Plugin.GetTagNameFromID(id).Replace('\\', '_') + ".png";
				if (File.Exists(path))
				{
					return new Bitmap(path);
				}
			}
			return new Bitmap(Application.StartupPath + "\\Images\\NoImage.png");
		}
	}
}
