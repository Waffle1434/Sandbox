using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;

namespace Sandbox.Editor
{
	public class UIFolderNameEditor : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context != null)
			{
				return UITypeEditorEditStyle.Modal;
			}
			return UITypeEditorEditStyle.None;
		}

		[RefreshProperties(RefreshProperties.All)]
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context == null || provider == null || context.Instance == null)
			{
				return EditValue(provider, value);
			}
			FolderBrowserDialog fd = new FolderBrowserDialog();
			fd.ShowNewFolderButton = false;
			if (fd.ShowDialog() == DialogResult.OK && Directory.Exists(fd.SelectedPath))
			{
				value = fd.SelectedPath + "\\";
			}
			return value;
		}
	}
}
