using System.Windows.Forms;
using Sandbox.Plugins;
using Sandbox.Usermap;

namespace Sandbox
{
	public static class GlobalVariables
	{
		private static MapPlugin plugin;

		private static H3Usermap umap;

		private static object clipboard;

		private static ImageList imageIcons;

		private static ImageList smallImageIcons;

		public static MapPlugin Plugin
		{
			get
			{
				return plugin;
			}
			set
			{
				plugin = value;
			}
		}

		public static H3Usermap Usermap
		{
			get
			{
				return umap;
			}
			set
			{
				umap = value;
			}
		}

		public static object Clipboard
		{
			get
			{
				return clipboard;
			}
			set
			{
				clipboard = value;
			}
		}

		public static ImageList ImageIcons
		{
			get
			{
				return imageIcons;
			}
			set
			{
				imageIcons = value;
			}
		}

		public static ImageList SmallImageIcons
		{
			get
			{
				return smallImageIcons;
			}
			set
			{
				smallImageIcons = value;
			}
		}
	}
}
