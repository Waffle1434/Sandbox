using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sandbox.Controls
{
	public class SuccessMessage : Form
	{
		private IContainer components = null;

		private PictureBox pictureBox1;

		private Panel panel1;

		private Button button1;

		private Label lblMessage;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sandbox.Controls.SuccessMessage));
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			button1 = new System.Windows.Forms.Button();
			lblMessage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 23);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(64, 64);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			panel1.Controls.Add(button1);
			panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel1.Location = new System.Drawing.Point(0, 105);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(280, 39);
			panel1.TabIndex = 1;
			button1.Location = new System.Drawing.Point(193, 8);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 0;
			button1.Text = "OK";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(button1_Click);
			lblMessage.AutoSize = true;
			lblMessage.Location = new System.Drawing.Point(92, 46);
			lblMessage.Name = "lblMessage";
			lblMessage.Size = new System.Drawing.Size(50, 13);
			lblMessage.TabIndex = 2;
			lblMessage.Text = "Message";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(280, 144);
			base.Controls.Add(lblMessage);
			base.Controls.Add(panel1);
			base.Controls.Add(pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SuccessMessage";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Success";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		public SuccessMessage(string message)
		{
			InitializeComponent();
			lblMessage.Text = message;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
