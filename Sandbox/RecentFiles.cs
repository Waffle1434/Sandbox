using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Sandbox.Editor;

namespace Sandbox
{
	public class RecentFiles : ISettings
	{
		private string filePath;

		public ToolStripMenuItem MenuItem;

		[Description("Recent File Path")]
		[Category("General Settings")]
		[Editor(typeof(UIFileNameEditor), typeof(UITypeEditor))]
		public string FilePath
		{
			get
			{
				return filePath;
			}
			set
			{
				filePath = value;
			}
		}
	}
}
