using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Sandbox.Forms
{
	public class About : Form
	{
		private IContainer components = null;

		private LinkLabel linkLabel1;

		private Label label2;

		private Label label3;

		private PictureBox pictureBox1;

		private LinkLabel linkLabel2;

		private LinkLabel linkLabel3;

		private Label label1;

		public About()
		{
			InitializeComponent();
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.halosource.net");
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.halomods.com");
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.vistaico.com");
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sandbox.Forms.About));
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			linkLabel3 = new System.Windows.Forms.LinkLabel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			linkLabel1.AutoSize = true;
			linkLabel1.LinkColor = System.Drawing.Color.Black;
			linkLabel1.Location = new System.Drawing.Point(176, 99);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(93, 13);
			linkLabel1.TabIndex = 1;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "www.vistaico.com";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(135, 9);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(66, 18);
			label2.TabIndex = 2;
			label2.Text = "Sandbox";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(162, 27);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(62, 13);
			label3.TabIndex = 3;
			label3.Text = "by shade45";
			linkLabel2.AutoSize = true;
			linkLabel2.LinkColor = System.Drawing.Color.Black;
			linkLabel2.Location = new System.Drawing.Point(135, 76);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(79, 13);
			linkLabel2.TabIndex = 5;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "Halosource.net";
			linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			linkLabel3.AutoSize = true;
			linkLabel3.LinkColor = System.Drawing.Color.Black;
			linkLabel3.Location = new System.Drawing.Point(220, 76);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(77, 13);
			linkLabel3.TabIndex = 6;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "Halomods.com";
			linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel3_LinkClicked);
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(12, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(100, 100);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 4;
			pictureBox1.TabStop = false;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(135, 53);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(89, 12);
			label1.TabIndex = 7;
			label1.Text = "Credits: grimdoomer";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(331, 126);
			base.Controls.Add(label1);
			base.Controls.Add(linkLabel3);
			base.Controls.Add(linkLabel2);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(linkLabel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "About";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			Text = "About";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
