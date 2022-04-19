using System.IO;
using System.Windows.Forms;

namespace Sandbox
{
	public static class AppSettings
	{
		private static Settings settings = new Settings();

		public static string settingsDirectory = "";

		public static string settingsName = "\\AppSettings.dat";

		public static Settings Settings => settings;

		public static void SaveSettings()
		{
			FileStream fs = new FileStream(settingsDirectory + settingsName, FileMode.Create, FileAccess.Write);
			BinaryWriter bw = new BinaryWriter(fs);
			bw.Write(0.01);
			settings.SettingsAuthor = SystemInformation.UserName;
			settings.Write(bw);
			fs.Close();
		}

		public static void LoadSettings()
		{
			if (!File.Exists(settingsDirectory + settingsName))
			{
				SaveSettings();
			}
			FileStream fs = new FileStream(settingsDirectory + settingsName, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);
			if (0.01 != br.ReadDouble())
			{
				fs.Close();
				MessageBox.Show("You are using a different version of settings. Your settings will be cleared to prevent problems.", "Different settings Ver.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				File.Delete(settingsDirectory + settingsName);
				settings = new Settings();
				SaveSettings();
				return;
			}
			settings.Read(br);
			fs.Close();
			if (settings.SettingsAuthor != SystemInformation.UserName)
			{
				DialogResult dr = MessageBox.Show("The settings file indicates that you are not user that created this Settings File. Would you like to start with a fresh Settings File?", "Hmmm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{
					File.Delete(settingsDirectory + settingsName);
					settings = new Settings();
					SaveSettings();
				}
				else
				{
					SaveSettings();
				}
			}
		}

		public static void ClearSettings()
		{
			settings = new Settings();
			SaveSettings();
		}

		public static void DeleteSettings()
		{
			if (File.Exists(settingsDirectory + settingsName))
			{
				File.Delete(settingsDirectory + settingsName);
			}
		}
	}
}
