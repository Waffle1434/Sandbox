using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using Sandbox.Controls;

namespace Sandbox.Editor
{
	public class UIIdentSwapper : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context != null)
			{
				return UITypeEditorEditStyle.Modal;
			}
			return UITypeEditorEditStyle.None;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context == null || provider == null || context.Instance == null)
			{
				return EditValue(provider, value);
			}
			IdentSwapDialog isd = new IdentSwapDialog((string)value);
			if (isd.ShowDialog() == DialogResult.OK)
			{
				value = isd.Ident;
			}
			return isd.Ident;
		}
	}
}
