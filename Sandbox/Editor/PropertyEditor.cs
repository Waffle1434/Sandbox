using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sandbox.Editor
{
	public class PropertyEditor : Form
	{
		private IContainer components = null;

		private PropertyGrid propertyGrid1;

		private Button btnOK;

		private Panel panel1;

		private object selectedObject;

		public object SelectedObject
		{
			get
			{
				return selectedObject;
			}
			set
			{
				selectedObject = value;
				OnSelectedObjectChange(value);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			btnOK = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			panel1.SuspendLayout();
			SuspendLayout();
			propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top;
			propertyGrid1.Location = new System.Drawing.Point(0, 0);
			propertyGrid1.Name = "propertyGrid1";
			propertyGrid1.Size = new System.Drawing.Size(287, 253);
			propertyGrid1.TabIndex = 0;
			propertyGrid1.ToolbarVisible = false;
			btnOK.Location = new System.Drawing.Point(200, 6);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(75, 23);
			btnOK.TabIndex = 1;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += new System.EventHandler(btnOK_Click);
			panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			panel1.Controls.Add(btnOK);
			panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel1.Location = new System.Drawing.Point(0, 254);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(287, 34);
			panel1.TabIndex = 2;
			base.AcceptButton = btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(287, 288);
			base.Controls.Add(panel1);
			base.Controls.Add(propertyGrid1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "PropertyEditor";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Property Editor";
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		public PropertyEditor()
		{
			InitializeComponent();
		}

		public PropertyEditor(object selectedObject)
		{
			InitializeComponent();
			SelectedObject = selectedObject;
		}

		protected void OnSelectedObjectChange(object newObject)
		{
			propertyGrid1.SelectedObject = newObject;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
