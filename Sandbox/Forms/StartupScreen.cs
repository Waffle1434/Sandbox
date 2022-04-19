using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Sandbox.Forms
{
	public class StartupScreen : Form
	{
		private IContainer components = null;

		private Label lblVersion;

		private Label label1;

		private int splashDuration;

		public int SplashDuration
		{
			get
			{
				return splashDuration;
			}
			set
			{
				splashDuration = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sandbox.Forms.StartupScreen));
			lblVersion = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			lblVersion.AutoSize = true;
			lblVersion.BackColor = System.Drawing.Color.Transparent;
			lblVersion.Font = new System.Drawing.Font("Estrangelo Edessa", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblVersion.ForeColor = System.Drawing.Color.White;
			lblVersion.Location = new System.Drawing.Point(240, 271);
			lblVersion.Name = "lblVersion";
			lblVersion.Size = new System.Drawing.Size(48, 20);
			lblVersion.TabIndex = 3;
			lblVersion.Text = "V 1.0";
			label1.AutoSize = true;
			label1.BackColor = System.Drawing.Color.Transparent;
			label1.Font = new System.Drawing.Font("Estrangelo Edessa", 14.25f);
			label1.ForeColor = System.Drawing.Color.White;
			label1.Location = new System.Drawing.Point(12, 271);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(76, 20);
			label1.TabIndex = 4;
			label1.Text = "Shade45";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
			base.ClientSize = new System.Drawing.Size(300, 300);
			base.Controls.Add(label1);
			base.Controls.Add(lblVersion);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "StartupScreen";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "StartupScreen";
			base.TopMost = true;
			ResumeLayout(false);
			PerformLayout();
		}

		public StartupScreen()
		{
			InitializeComponent();
			lblVersion.Text = "V " + Form1.CurrentVersion.ToString("N1");
		}

		public void StartTimer()
		{
			Timer t = new Timer();
			t.Interval = splashDuration;
			t.Tick += t_Tick;
			t.Start();
		}

		private void t_Tick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
