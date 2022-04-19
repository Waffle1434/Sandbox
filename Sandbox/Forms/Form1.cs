using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sandbox.Controls;
using Sandbox.Editor;
using Sandbox.Forms;
using Sandbox.Plugins;
using Sandbox.Usermap;

namespace Sandbox
{
	public class Form1 : Form
	{
		public enum BuildType
		{
			Internal_Release,
			Stable,
			Unstable,
			Beta
		}

		private IContainer components = null;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem helpToolStripMenuItem;

		private ToolStripMenuItem openMToolStripMenuItem;

		private ToolStripMenuItem exitToolStripMenuItem;

		private ToolStripMenuItem toolsToolStripMenuItem;

		private ToolStripMenuItem settingsToolStripMenuItem;

		private ToolStripMenuItem aboutToolStripMenuItem1;

		private ToolStripSeparator toolStripSeparator6;

		private ListpanelV2 listpanel1;

		private ToolStripMenuItem closeUsermapToolStripMenuItem;

		public static double CurrentVersion = 3.0;

		public static BuildType CurrentBuildType = BuildType.Stable;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sandbox.Form1));
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			openMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			closeUsermapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			listpanel1 = new Sandbox.Controls.ListpanelV2();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { fileToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new System.Drawing.Size(514, 24);
			menuStrip1.TabIndex = 3;
			menuStrip1.Text = "menuStrip1";
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { openMToolStripMenuItem, closeUsermapToolStripMenuItem, toolStripSeparator6, exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			openMToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("openMToolStripMenuItem.Image");
			openMToolStripMenuItem.Name = "openMToolStripMenuItem";
			openMToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			openMToolStripMenuItem.Text = "Open Usermap...";
			openMToolStripMenuItem.Click += new System.EventHandler(openMToolStripMenuItem_Click);
			closeUsermapToolStripMenuItem.Name = "closeUsermapToolStripMenuItem";
			closeUsermapToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			closeUsermapToolStripMenuItem.Text = "Close Usermap";
			closeUsermapToolStripMenuItem.Click += new System.EventHandler(closeUsermapToolStripMenuItem_Click);
			toolStripSeparator6.Name = "toolStripSeparator6";
			toolStripSeparator6.Size = new System.Drawing.Size(159, 6);
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			exitToolStripMenuItem.Text = "Exit";
			exitToolStripMenuItem.Click += new System.EventHandler(exitToolStripMenuItem_Click);
			toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { settingsToolStripMenuItem });
			toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			toolsToolStripMenuItem.Text = "Tools";
			toolsToolStripMenuItem.Visible = false;
			settingsToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("settingsToolStripMenuItem.Image");
			settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			settingsToolStripMenuItem.Text = "Settings";
			settingsToolStripMenuItem.Click += new System.EventHandler(settingsToolStripMenuItem_Click);
			helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { aboutToolStripMenuItem1 });
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			helpToolStripMenuItem.Text = "Help";
			aboutToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("aboutToolStripMenuItem1.Image");
			aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
			aboutToolStripMenuItem1.Text = "About";
			aboutToolStripMenuItem1.Click += new System.EventHandler(aboutToolStripMenuItem1_Click);
			listpanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			listpanel1.Location = new System.Drawing.Point(0, 24);
			listpanel1.Name = "listpanel1";
			listpanel1.Size = new System.Drawing.Size(514, 453);
			listpanel1.TabIndex = 9;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(514, 477);
			base.Controls.Add(listpanel1);
			base.Controls.Add(menuStrip1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MainMenuStrip = menuStrip1;
			base.MaximizeBox = false;
			base.Name = "Form1";
			Text = "Sandbox 3.0";
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public Form1()
		{
			InitializeComponent();
			LoadImages();
		}

		public void LoadImages()
		{
			GlobalVariables.ImageIcons = new ImageList();
			GlobalVariables.ImageIcons.ImageSize = new Size(64, 64);
			GlobalVariables.SmallImageIcons = new ImageList();
			GlobalVariables.SmallImageIcons.ImageSize = new Size(32, 32);
			DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\Images");
			FileInfo[] fi = di.GetFiles();
			for (int i = 0; i < fi.Length; i++)
			{
				Image im = Image.FromFile(fi[i].FullName);
				GlobalVariables.ImageIcons.Images.Add(im);
				GlobalVariables.ImageIcons.Images.SetKeyName(i, fi[i].Name.Replace(".png", ""));
				GlobalVariables.SmallImageIcons.Images.Add(im);
				GlobalVariables.SmallImageIcons.Images.SetKeyName(i, fi[i].Name.Replace(".png", ""));
			}
		}

		private void openMToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select a Halo 3 usermap...";
			ofd.Filter = "Map Varients (.map)|*.map";
			if (ofd.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			GlobalVariables.Usermap = new H3Usermap(ofd.FileName);
			switch (GlobalVariables.Usermap.Read())
			{
			case 1:
				MessageBox.Show("You must extract the usermap from the con file before opening.");
				return;
			case 2:
				MessageBox.Show("File was not a usermap.", "Error incorrect format.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			case 3:
				MessageBox.Show("An error was encountered reading this usermap.", "Error reading file.", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			string path = Misc.GetPluginName((int)GlobalVariables.Usermap.header.MapId);
			if (File.Exists(path))
			{
				GlobalVariables.Plugin = new MapPlugin(path);
				listpanel1.Populate();
			}
			else
			{
				MessageBox.Show("Could not find a plugin for this usermap.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PropertyEditor pe = new PropertyEditor();
			pe.SelectedObject = AppSettings.Settings;
			pe.FormClosing += settings_FormClosing;
			pe.Text = "Settings";
			pe.ShowDialog();
		}

		private void settings_FormClosing(object sender, FormClosingEventArgs e)
		{
			AppSettings.SaveSettings();
		}

		private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			About ab = new About();
			ab.ShowDialog();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void closeUsermapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GlobalVariables.Usermap.Close();
			listpanel1.Clear();
		}
	}
}
