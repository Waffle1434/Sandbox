using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sandbox.Plugins;

namespace Sandbox.Controls
{
	public class IdentSwapDialog : Form
	{
		private int ident;

		private IContainer components = null;

		private Label label1;

		private Button btnSwap;

		private ComboBox comboBox1;

		private Label label2;

		private ComboBox comboBox2;

		private Button btnCancel;

		public string SwapButtonText
		{
			get
			{
				return btnSwap.Text;
			}
			set
			{
				btnSwap.Text = value;
			}
		}

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

		public IdentSwapDialog()
		{
			InitializeComponent();
			comboBox1.Text = "null";
			comboBox2.Text = "null";
			Load_Tag_Class_List();
		}

		public IdentSwapDialog(string tagname)
		{
			InitializeComponent();
			Ident = tagname;
			if (ident != -1)
			{
				foreach (MapPlugin.Tag t in GlobalVariables.Plugin.Tags)
				{
					if (t.Ident == ident)
					{
						comboBox1.Text = t.Type;
						comboBox2.Text = t.Filename;
					}
				}
				Load_Tag_List(comboBox1.Text);
			}
			else
			{
				comboBox1.Text = "null";
				comboBox2.Text = "null";
			}
			Load_Tag_Class_List();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Load_Tag_List(comboBox1.Items[comboBox1.SelectedIndex].ToString());
		}

		public void Load_Tag_Class_List()
		{
			comboBox1.Items.Clear();
			for (int i = 0; i < GlobalVariables.Plugin.TagClasses.Count; i++)
			{
				comboBox1.Items.Add(GlobalVariables.Plugin.TagClasses[i]);
			}
		}

		public void Load_Tag_List(string type)
		{
			comboBox2.Items.Clear();
			for (int i = 0; i < GlobalVariables.Plugin.Tags.Count; i++)
			{
				if (type == GlobalVariables.Plugin.Tags[i].Type)
				{
					comboBox2.Items.Add(GlobalVariables.Plugin.Tags[i].Filename);
				}
			}
		}

		private void btnSwap_Click(object sender, EventArgs e)
		{
			Ident = comboBox2.Text;
			base.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
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
			label1 = new System.Windows.Forms.Label();
			btnSwap = new System.Windows.Forms.Button();
			comboBox1 = new System.Windows.Forms.ComboBox();
			label2 = new System.Windows.Forms.Label();
			comboBox2 = new System.Windows.Forms.ComboBox();
			btnCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 21);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(32, 13);
			label1.TabIndex = 0;
			label1.Text = "Class";
			btnSwap.Location = new System.Drawing.Point(258, 46);
			btnSwap.Name = "btnSwap";
			btnSwap.Size = new System.Drawing.Size(75, 23);
			btnSwap.TabIndex = 2;
			btnSwap.Text = "Swap";
			btnSwap.UseVisualStyleBackColor = true;
			btnSwap.Click += new System.EventHandler(btnSwap_Click);
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(50, 18);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(55, 21);
			comboBox1.TabIndex = 3;
			comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(120, 21);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(35, 13);
			label2.TabIndex = 4;
			label2.Text = "Name";
			comboBox2.FormattingEnabled = true;
			comboBox2.Location = new System.Drawing.Point(161, 18);
			comboBox2.Name = "comboBox2";
			comboBox2.Size = new System.Drawing.Size(253, 21);
			comboBox2.TabIndex = 5;
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(339, 46);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(75, 23);
			btnCancel.TabIndex = 6;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += new System.EventHandler(btnCancel_Click);
			base.AcceptButton = btnSwap;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = btnCancel;
			base.ClientSize = new System.Drawing.Size(426, 81);
			base.Controls.Add(btnCancel);
			base.Controls.Add(comboBox2);
			base.Controls.Add(label2);
			base.Controls.Add(comboBox1);
			base.Controls.Add(btnSwap);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "IdentSwapDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Choose new ident...";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
