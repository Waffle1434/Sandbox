using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sandbox.Controls
{
	public class Info : Form
	{
		private static Info info;

		private IContainer components = null;

		private Label lblChunkNumber;

		private Label lblOffsetInUsermap;

		private Label lblIndex;

		private Label lblIndexOffset;

		private Panel panel1;

		private Button button1;

		private TextBox textBox1;

		private TextBox textBox2;

		private TextBox textBox3;

		private TextBox textBox4;

		private PictureBox pictureBox1;

		public Info(int index)
		{
			InitializeComponent();
			textBox1.Text = index.ToString();
			textBox2.Text = "0x" + (632 + index * 84).ToString("X");
			int tagindex = GlobalVariables.Usermap.placementBlocks[index].TagIndex;
			textBox3.Text = tagindex.ToString();
			textBox4.Text = "0x" + (54420 + tagindex * 12).ToString("X");
			pictureBox1.Image = Misc.GetImagesFromID(GlobalVariables.Usermap.tagIndex[tagindex].ident);
		}

		public static void Show(int index)
		{
			info = new Info(index);
			info.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
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
			lblChunkNumber = new System.Windows.Forms.Label();
			lblOffsetInUsermap = new System.Windows.Forms.Label();
			lblIndex = new System.Windows.Forms.Label();
			lblIndexOffset = new System.Windows.Forms.Label();
			panel1 = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			textBox3 = new System.Windows.Forms.TextBox();
			textBox4 = new System.Windows.Forms.TextBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			lblChunkNumber.AutoSize = true;
			lblChunkNumber.Location = new System.Drawing.Point(13, 13);
			lblChunkNumber.Name = "lblChunkNumber";
			lblChunkNumber.Size = new System.Drawing.Size(103, 13);
			lblChunkNumber.TabIndex = 0;
			lblChunkNumber.Text = "Placement Block #: ";
			lblOffsetInUsermap.AutoSize = true;
			lblOffsetInUsermap.Location = new System.Drawing.Point(13, 36);
			lblOffsetInUsermap.Name = "lblOffsetInUsermap";
			lblOffsetInUsermap.Size = new System.Drawing.Size(97, 13);
			lblOffsetInUsermap.TabIndex = 1;
			lblOffsetInUsermap.Text = "Offset in Usermap: ";
			lblIndex.AutoSize = true;
			lblIndex.Location = new System.Drawing.Point(13, 59);
			lblIndex.Name = "lblIndex";
			lblIndex.Size = new System.Drawing.Size(66, 13);
			lblIndex.TabIndex = 2;
			lblIndex.Text = "Tags Index: ";
			lblIndexOffset.AutoSize = true;
			lblIndexOffset.Location = new System.Drawing.Point(13, 82);
			lblIndexOffset.Name = "lblIndexOffset";
			lblIndexOffset.Size = new System.Drawing.Size(126, 13);
			lblIndexOffset.TabIndex = 3;
			lblIndexOffset.Text = "Index Offset in Usermap: ";
			panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			panel1.Controls.Add(button1);
			panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel1.Location = new System.Drawing.Point(0, 119);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(315, 36);
			panel1.TabIndex = 4;
			button1.Location = new System.Drawing.Point(235, 7);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 0;
			button1.Text = "OK";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Location = new System.Drawing.Point(145, 13);
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new System.Drawing.Size(131, 13);
			textBox1.TabIndex = 5;
			textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox2.Location = new System.Drawing.Point(145, 36);
			textBox2.Name = "textBox2";
			textBox2.ReadOnly = true;
			textBox2.Size = new System.Drawing.Size(131, 13);
			textBox2.TabIndex = 6;
			textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox3.Location = new System.Drawing.Point(145, 59);
			textBox3.Name = "textBox3";
			textBox3.ReadOnly = true;
			textBox3.Size = new System.Drawing.Size(131, 13);
			textBox3.TabIndex = 7;
			textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox4.Location = new System.Drawing.Point(145, 82);
			textBox4.Name = "textBox4";
			textBox4.ReadOnly = true;
			textBox4.Size = new System.Drawing.Size(131, 13);
			textBox4.TabIndex = 8;
			pictureBox1.Location = new System.Drawing.Point(210, 5);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(100, 100);
			pictureBox1.TabIndex = 9;
			pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(315, 155);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(textBox4);
			base.Controls.Add(textBox3);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(panel1);
			base.Controls.Add(lblIndexOffset);
			base.Controls.Add(lblIndex);
			base.Controls.Add(lblOffsetInUsermap);
			base.Controls.Add(lblChunkNumber);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "Info";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			Text = "Slot Properties";
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
