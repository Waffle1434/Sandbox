using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;

namespace Sandbox.Editor
{
	public class UIFileNameEditor : UITypeEditor
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
			FileDialog fd = new OpenFileDialog();
			fd.CheckFileExists = true;
			fd.CheckPathExists = true;
			fd.Title = "Select Filename";
			fd.FileName = value as string;
			fd.Filter = "All Files (*.*)|*.*";
			if (fd.ShowDialog() == DialogResult.OK && File.Exists(fd.FileName))
			{
				value = fd.FileName;
			}
			return value;
		}
	}
}
