using System.ComponentModel;
using System.Drawing.Design;
using Sandbox.Editor;

namespace Sandbox
{
	public class Settings : ISettings
	{
		public const double SettingsVersion = 0.01;

		private string settingsAuthor;

		private string mapFolder = "";

		[Description("User that created this settings file")]
		[Category("General Settings")]
		[ReadOnly(true)]
		public string SettingsAuthor
		{
			get
			{
				return settingsAuthor;
			}
			set
			{
				settingsAuthor = value;
			}
		}

		[Description("Location of the maps folder containg your Halo 3 Maps")]
		[Category("General Settings")]
		[Editor(typeof(UIFolderNameEditor), typeof(UITypeEditor))]
		public string MapFolder
		{
			get
			{
				return mapFolder;
			}
			set
			{
				mapFolder = value;
			}
		}
	}
}
