using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Sandbox.Editor;
using Sandbox.Usermap;

namespace Sandbox.Controls
{
	public class ListpanelV2 : UserControl
	{
		private IContainer components = null;

		private Panel panel1;

		private Button btnClear;

		private Button btnPaste;

		private Button btnCopy;

		private Button btnEdit;

		private ComboBox comboBox1;

		private Button btnSwap;

		private TextBox txtSearch;

		private Button btnSave;

		private ContextMenuStrip cmsOptions;

		private ToolStripMenuItem propertiesToolStripMenuItem;

		private ListViewEx listView1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private PictureBox pictureBox1;

		private PictureBox pbxSearch;

		private ContextMenuStrip cmsSearchOptions;

		private ToolStripMenuItem nameToolStripMenuItem;

		private ToolStripMenuItem indexToolStripMenuItem;

		private ToolStripMenuItem extractSlotToolStripMenuItem;

		private ToolStripMenuItem injectSlotToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator1;

		private ContextMenuStrip cmsWindowOptions;

		private ToolStripMenuItem refreshWindowToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem groupByToolStripMenuItem1;

		private ToolStripMenuItem blockTypeToolStripMenuItem1;

		private ToolStripMenuItem tagTypeToolStripMenuItem1;

		private ToolStripMenuItem showToolStripMenuItem;

		private ToolStripMenuItem placementBlocksToolStripMenuItem;

		private ToolStripMenuItem tagIndexToolStripMenuItem;

		private ToolStripMenuItem noGroupingToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem viewByToolStripMenuItem;

		private ToolStripMenuItem reservedSlotsToolStripMenuItem;

		private ToolStripMenuItem originalSlotsToolStripMenuItem;

		private ToolStripMenuItem addedSlotsToolStripMenuItem;

		private ToolStripMenuItem editedSlotsToolStripMenuItem;

		private ToolStripMenuItem unsortedSlotsToolStripMenuItem;

		private ToolStripMenuItem emptySlotsToolStripMenuItem;

		private ToolStripMenuItem playerSpawnsToolStripMenuItem;

		private ToolStripMenuItem mapInformationToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator4;

		public ListpanelV2()
		{
			InitializeComponent();
		}

		public void Populate()
		{
			listView1.Items.Clear();
			listView1.LargeImageList = GlobalVariables.ImageIcons;
			listView1.SmallImageList = GlobalVariables.SmallImageIcons;
			if (placementBlocksToolStripMenuItem.Checked)
			{
				for (int i = 0; i < 640; i++)
				{
					ListViewItem li = new ListViewItem();
					int tIndex = GlobalVariables.Usermap.placementBlocks[i].TagIndex;
					if (tIndex != -1)
					{
						li.Text = GlobalVariables.Plugin.GetTagNameFromID(GlobalVariables.Usermap.tagIndex[tIndex].ident);
						li.ImageKey = li.Text.Replace('\\', '_');
					}
					else
					{
						li.Text = "Empty";
					}
					if (blockTypeToolStripMenuItem1.Checked)
					{
						switch (GlobalVariables.Usermap.placementBlocks[i].BlockType)
						{
						case H3Usermap.PlacementBlock.blockType.NULL:
						case H3Usermap.PlacementBlock.blockType.Player_Spawn:
						case H3Usermap.PlacementBlock.blockType.Reserved:
						case H3Usermap.PlacementBlock.blockType.Added:
						case H3Usermap.PlacementBlock.blockType.Original:
						case H3Usermap.PlacementBlock.blockType.Edited:
							li.Group = listView1.Groups[GlobalVariables.Usermap.placementBlocks[i].BlockType.ToString()];
							break;
						default:
							li.Group = listView1.Groups["Unsorted"];
							break;
						}
					}
					else if (tIndex != -1)
					{
						li.Group = listView1.Groups[GlobalVariables.Plugin.GetTagTypeFromID(GlobalVariables.Usermap.tagIndex[tIndex].ident)];
					}
					else
					{
						li.Group = listView1.Groups["no class"];
					}
					li.SubItems.Add(i.ToString());
					li.Tag = i;
					if (txtSearch.Text.Equals(""))
					{
						if (CheckIfBlockIsShown(GlobalVariables.Usermap.placementBlocks[i].BlockType))
						{
							listView1.Items.Add(li);
						}
					}
					else if (li.Text.Contains(txtSearch.Text) && CheckIfBlockIsShown(GlobalVariables.Usermap.placementBlocks[i].BlockType))
					{
						listView1.Items.Add(li);
					}
				}
				return;
			}
			for (int i = 0; i < 255; i++)
			{
				ListViewItem li = new ListViewItem();
				int ident = GlobalVariables.Usermap.tagIndex[i].ident;
				if (ident != -1)
				{
					li.Text = GlobalVariables.Plugin.GetTagNameFromID(ident);
					li.ImageKey = li.Text.Replace('\\', '_');
				}
				else
				{
					li.Text = "Null Entry";
				}
				li.SubItems.Add(i.ToString());
				li.Tag = i;
				if (txtSearch.Text.Equals(""))
				{
					listView1.Items.Add(li);
				}
				else if (li.Text.Contains(txtSearch.Text))
				{
					listView1.Items.Add(li);
				}
			}
		}

		public void Clear()
		{
			listView1.Items.Clear();
		}

		public bool CheckIfBlockIsShown(H3Usermap.PlacementBlock.blockType type)
		{
			return type switch
			{
				H3Usermap.PlacementBlock.blockType.Reserved => reservedSlotsToolStripMenuItem.Checked, 
				H3Usermap.PlacementBlock.blockType.Original => originalSlotsToolStripMenuItem.Checked, 
				H3Usermap.PlacementBlock.blockType.Added => addedSlotsToolStripMenuItem.Checked, 
				H3Usermap.PlacementBlock.blockType.Edited => editedSlotsToolStripMenuItem.Checked, 
				H3Usermap.PlacementBlock.blockType.Player_Spawn => playerSpawnsToolStripMenuItem.Checked, 
				H3Usermap.PlacementBlock.blockType.NULL => emptySlotsToolStripMenuItem.Checked, 
				_ => unsortedSlotsToolStripMenuItem.Checked, 
			};
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (comboBox1.Text)
			{
			case "Large Icons":
				listView1.View = View.LargeIcon;
				break;
			case "Small Icons":
				listView1.View = View.SmallIcon;
				break;
			case "List":
				listView1.View = View.List;
				break;
			case "Details":
				listView1.View = View.Details;
				break;
			case "Tile":
				listView1.View = View.Tile;
				break;
			}
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				if (placementBlocksToolStripMenuItem.Checked)
				{
					GlobalVariables.Clipboard = GlobalVariables.Usermap.placementBlocks[(int)listView1.SelectedItems[0].Tag];
				}
				else
				{
					GlobalVariables.Clipboard = GlobalVariables.Usermap.tagIndex[(int)listView1.SelectedItems[0].Tag];
				}
			}
		}

		private void btnPaste_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null && GlobalVariables.Clipboard != null)
			{
				if (placementBlocksToolStripMenuItem.Checked)
				{
					GlobalVariables.Usermap.placementBlocks[(int)listView1.SelectedItems[0].Tag] = (H3Usermap.PlacementBlock)GlobalVariables.Clipboard;
				}
				else
				{
					GlobalVariables.Usermap.tagIndex[(int)listView1.SelectedItems[0].Tag] = (H3Usermap.TagIndexEntry)GlobalVariables.Clipboard;
				}
				pe_FormClosing(null, null);
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				PropertyEditor pe = ((!placementBlocksToolStripMenuItem.Checked) ? new PropertyEditor(GlobalVariables.Usermap.tagIndex[(int)listView1.SelectedItems[0].Tag]) : new PropertyEditor(GlobalVariables.Usermap.placementBlocks[(int)listView1.SelectedItems[0].Tag]));
				pe.FormClosing += pe_FormClosing;
				pe.ShowDialog();
			}
		}

		private void btnSwap_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				int index = GlobalVariables.Usermap.placementBlocks[(int)listView1.SelectedItems[0].Tag].TagIndex;
				if (index != -1)
				{
					PropertyEditor pe = new PropertyEditor(GlobalVariables.Usermap.tagIndex[index]);
					pe.FormClosing += pe_FormClosing;
					pe.ShowDialog();
				}
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				if (placementBlocksToolStripMenuItem.Checked)
				{
					H3Usermap.PlacementBlock nullBlock = new H3Usermap.PlacementBlock();
					nullBlock.LoadNull();
					GlobalVariables.Usermap.placementBlocks[(int)listView1.SelectedItems[0].Tag] = nullBlock;
					listView1.SelectedItems[0].Text = "Empty";
					listView1.SelectedItems[0].ImageKey = "Null";
				}
				else
				{
					H3Usermap.TagIndexEntry nullEntry = new H3Usermap.TagIndexEntry();
					nullEntry.LoadNull();
					GlobalVariables.Usermap.tagIndex[(int)listView1.SelectedItems[0].Tag] = nullEntry;
					listView1.SelectedItems[0].Text = "Null Entry";
					listView1.SelectedItems[0].ImageKey = "";
				}
			}
		}

		private void pe_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (placementBlocksToolStripMenuItem.Checked)
			{
				int tIndex = GlobalVariables.Usermap.placementBlocks[(int)listView1.SelectedItems[0].Tag].TagIndex;
				if (tIndex != -1)
				{
					listView1.SelectedItems[0].Text = GlobalVariables.Plugin.GetTagNameFromID(GlobalVariables.Usermap.tagIndex[tIndex].ident);
					listView1.SelectedItems[0].ImageKey = listView1.SelectedItems[0].Text.Replace('\\', '_');
				}
				else
				{
					listView1.SelectedItems[0].Text = "Empty";
					listView1.SelectedItems[0].ImageKey = "Empty";
				}
				listView1.SelectedItems[0].Group = listView1.Groups[GlobalVariables.Usermap.placementBlocks[(int)listView1.SelectedItems[0].Tag].BlockType.ToString()];
				listView1.SelectedItems[0].EnsureVisible();
			}
			else
			{
				int ident = GlobalVariables.Usermap.tagIndex[(int)listView1.SelectedItems[0].Tag].ident;
				if (ident != -1)
				{
					listView1.SelectedItems[0].Text = GlobalVariables.Plugin.GetTagNameFromID(ident);
					listView1.SelectedItems[0].ImageKey = listView1.SelectedItems[0].Text.Replace('\\', '_');
				}
				else
				{
					listView1.SelectedItems[0].Text = "Null Entry";
					listView1.SelectedItems[0].ImageKey = "";
				}
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap == null)
			{
				return;
			}
			if (nameToolStripMenuItem.Checked)
			{
				listView1.Hide();
				Populate();
				listView1.Show();
				return;
			}
			int sNum = 0;
			if (int.TryParse(txtSearch.Text, out sNum) && sNum >= 0 && sNum <= 639)
			{
				listView1.Items[sNum].EnsureVisible();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap == null)
			{
				return;
			}
			byte objCount = (byte)GlobalVariables.Usermap.baseObjectCount;
			for (int i = 0; i < 640; i++)
			{
				if (GlobalVariables.Usermap.placementBlocks[i].BlockType != 0)
				{
					objCount = (byte)(objCount + 1);
				}
			}
			GlobalVariables.Usermap.unamedBlock1.Spawned_Object_Count = objCount;
			if (GlobalVariables.Usermap.Write() == 0)
			{
				SuccessMessage sm = new SuccessMessage("Changes saved.");
				sm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Changes were not saved.", "Error");
			}
		}

		private void listView1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ListViewHitTestInfo hitTestInfo = listView1.HitTest(e.X, e.Y);
				if (hitTestInfo.Item != null)
				{
					cmsOptions.Show(this, e.X, e.Y + 30);
				}
			}
		}

		private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Info.Show((int)listView1.SelectedItems[0].Tag);
		}

		private void nameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				indexToolStripMenuItem.Checked = !nameToolStripMenuItem.Checked;
				txtSearch.Text = "";
				listView1.Hide();
				Populate();
				listView1.Show();
			}
			else
			{
				nameToolStripMenuItem.Checked = true;
			}
		}

		private void indexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				nameToolStripMenuItem.Checked = !indexToolStripMenuItem.Checked;
				txtSearch.Text = "";
				listView1.Hide();
				Populate();
				listView1.Show();
			}
			else
			{
				indexToolStripMenuItem.Checked = false;
			}
		}

		public void GroupItems()
		{
			if (blockTypeToolStripMenuItem1.Checked)
			{
				listView1.ShowGroups = true;
				listView1.Groups.Clear();
				listView1.Groups.Add("Reserved", "Reserved Slots");
				listView1.Groups.Add("Original", "Original Slots");
				listView1.Groups.Add("Added", "Added Slots");
				listView1.Groups.Add("Edited", "Edited Slots");
				listView1.Groups.Add("Unsorted", "Unsorted Slots");
				listView1.Groups.Add("Player_Spawn", "Player Spawns");
				listView1.Groups.Add("NULL", "Empty Slots");
				Populate();
			}
			else if (tagTypeToolStripMenuItem1.Checked)
			{
				listView1.ShowGroups = true;
				listView1.Groups.Clear();
				foreach (string s in GlobalVariables.Plugin.TagClasses)
				{
					listView1.Groups.Add(s, s);
				}
				listView1.Groups.Add("no class", "no class");
				Populate();
			}
			else if (noGroupingToolStripMenuItem.Checked)
			{
				listView1.ShowGroups = false;
				Populate();
			}
		}

		private void blockTypeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				noGroupingToolStripMenuItem.Checked = false;
				tagTypeToolStripMenuItem1.Checked = false;
				blockTypeToolStripMenuItem1.Checked = true;
				GroupItems();
			}
			else
			{
				blockTypeToolStripMenuItem1.Checked = true;
			}
		}

		private void tagTypeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				noGroupingToolStripMenuItem.Checked = false;
				blockTypeToolStripMenuItem1.Checked = false;
				tagTypeToolStripMenuItem1.Checked = true;
				GroupItems();
			}
			else
			{
				tagTypeToolStripMenuItem1.Checked = false;
			}
		}

		private void noGroupingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				blockTypeToolStripMenuItem1.Checked = false;
				tagTypeToolStripMenuItem1.Checked = false;
				noGroupingToolStripMenuItem.Checked = true;
				GroupItems();
			}
			else
			{
				noGroupingToolStripMenuItem.Checked = false;
			}
		}

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				Populate();
			}
		}

		private void placementBlocksToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				tagIndexToolStripMenuItem.Checked = false;
				placementBlocksToolStripMenuItem.Checked = true;
				listView1.ShowGroups = !noGroupingToolStripMenuItem.Checked;
				viewByToolStripMenuItem.Enabled = true;
				groupByToolStripMenuItem1.Enabled = true;
				Populate();
			}
		}

		private void tagIndexToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (GlobalVariables.Usermap != null)
			{
				placementBlocksToolStripMenuItem.Checked = false;
				tagIndexToolStripMenuItem.Checked = true;
				listView1.ShowGroups = false;
				viewByToolStripMenuItem.Enabled = false;
				groupByToolStripMenuItem1.Enabled = false;
				Populate();
			}
		}

		private void mapInformationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PropertyEditor pe = new PropertyEditor();
			pe.SelectedObject = GlobalVariables.Usermap.header;
			pe.ShowDialog();
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sandbox.Controls.ListpanelV2));
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Reserved Slots", System.Windows.Forms.HorizontalAlignment.Center);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Original Slots", System.Windows.Forms.HorizontalAlignment.Center);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Added Slots", System.Windows.Forms.HorizontalAlignment.Center);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Edited Slots", System.Windows.Forms.HorizontalAlignment.Center);
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Unsorted Slots", System.Windows.Forms.HorizontalAlignment.Center);
			System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Player Spawns", System.Windows.Forms.HorizontalAlignment.Center);
			System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Empty Slots", System.Windows.Forms.HorizontalAlignment.Center);
			panel1 = new System.Windows.Forms.Panel();
			btnSave = new System.Windows.Forms.Button();
			btnSwap = new System.Windows.Forms.Button();
			btnClear = new System.Windows.Forms.Button();
			btnPaste = new System.Windows.Forms.Button();
			btnCopy = new System.Windows.Forms.Button();
			btnEdit = new System.Windows.Forms.Button();
			comboBox1 = new System.Windows.Forms.ComboBox();
			txtSearch = new System.Windows.Forms.TextBox();
			cmsOptions = new System.Windows.Forms.ContextMenuStrip(components);
			extractSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			injectSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			pbxSearch = new System.Windows.Forms.PictureBox();
			cmsSearchOptions = new System.Windows.Forms.ContextMenuStrip(components);
			nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			cmsWindowOptions = new System.Windows.Forms.ContextMenuStrip(components);
			showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			placementBlocksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			tagIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			viewByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			reservedSlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			originalSlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			addedSlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			editedSlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			unsortedSlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			emptySlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			playerSpawnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			groupByToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			noGroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			blockTypeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			tagTypeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			refreshWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mapInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			listView1 = new Sandbox.Controls.ListViewEx();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			panel1.SuspendLayout();
			cmsOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbxSearch).BeginInit();
			cmsSearchOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			cmsWindowOptions.SuspendLayout();
			SuspendLayout();
			panel1.Controls.Add(btnSave);
			panel1.Controls.Add(btnSwap);
			panel1.Controls.Add(btnClear);
			panel1.Controls.Add(btnPaste);
			panel1.Controls.Add(btnCopy);
			panel1.Controls.Add(btnEdit);
			panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel1.Location = new System.Drawing.Point(0, 399);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(514, 52);
			panel1.TabIndex = 1;
			btnSave.Image = (System.Drawing.Image)resources.GetObject("btnSave.Image");
			btnSave.Location = new System.Drawing.Point(441, 9);
			btnSave.Name = "btnSave";
			btnSave.Size = new System.Drawing.Size(59, 34);
			btnSave.TabIndex = 8;
			btnSave.Text = "Save";
			btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnSave.UseVisualStyleBackColor = false;
			btnSave.Click += new System.EventHandler(btnSave_Click);
			btnSwap.Image = (System.Drawing.Image)resources.GetObject("btnSwap.Image");
			btnSwap.Location = new System.Drawing.Point(276, 9);
			btnSwap.Name = "btnSwap";
			btnSwap.Size = new System.Drawing.Size(59, 34);
			btnSwap.TabIndex = 6;
			btnSwap.Text = "Swap";
			btnSwap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnSwap.UseVisualStyleBackColor = false;
			btnSwap.Visible = false;
			btnSwap.Click += new System.EventHandler(btnSwap_Click);
			btnClear.Image = (System.Drawing.Image)resources.GetObject("btnClear.Image");
			btnClear.Location = new System.Drawing.Point(211, 9);
			btnClear.Name = "btnClear";
			btnClear.Size = new System.Drawing.Size(59, 34);
			btnClear.TabIndex = 7;
			btnClear.Text = "Clear";
			btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnClear.UseVisualStyleBackColor = false;
			btnClear.Click += new System.EventHandler(btnClear_Click);
			btnPaste.BackColor = System.Drawing.SystemColors.Control;
			btnPaste.Image = (System.Drawing.Image)resources.GetObject("btnPaste.Image");
			btnPaste.Location = new System.Drawing.Point(81, 9);
			btnPaste.Name = "btnPaste";
			btnPaste.Size = new System.Drawing.Size(59, 34);
			btnPaste.TabIndex = 4;
			btnPaste.Text = "Paste";
			btnPaste.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnPaste.UseVisualStyleBackColor = false;
			btnPaste.Click += new System.EventHandler(btnPaste_Click);
			btnCopy.Image = (System.Drawing.Image)resources.GetObject("btnCopy.Image");
			btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			btnCopy.Location = new System.Drawing.Point(16, 9);
			btnCopy.Name = "btnCopy";
			btnCopy.Size = new System.Drawing.Size(59, 34);
			btnCopy.TabIndex = 3;
			btnCopy.Text = "Copy";
			btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnCopy.UseVisualStyleBackColor = false;
			btnCopy.Click += new System.EventHandler(btnCopy_Click);
			btnEdit.Image = (System.Drawing.Image)resources.GetObject("btnEdit.Image");
			btnEdit.Location = new System.Drawing.Point(146, 9);
			btnEdit.Name = "btnEdit";
			btnEdit.Size = new System.Drawing.Size(59, 34);
			btnEdit.TabIndex = 5;
			btnEdit.Text = "Edit";
			btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnEdit.UseVisualStyleBackColor = false;
			btnEdit.Click += new System.EventHandler(btnEdit_Click);
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[5] { "Large Icons", "Small Icons", "Details", "List", "Tile" });
			comboBox1.Location = new System.Drawing.Point(25, 8);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(121, 21);
			comboBox1.TabIndex = 0;
			comboBox1.Text = "Details";
			comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
			txtSearch.Location = new System.Drawing.Point(174, 8);
			txtSearch.Name = "txtSearch";
			txtSearch.Size = new System.Drawing.Size(335, 20);
			txtSearch.TabIndex = 1;
			txtSearch.TextChanged += new System.EventHandler(txtSearch_TextChanged);
			cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { extractSlotToolStripMenuItem, injectSlotToolStripMenuItem, toolStripSeparator1, propertiesToolStripMenuItem });
			cmsOptions.Name = "cmsOptions";
			cmsOptions.Size = new System.Drawing.Size(151, 76);
			extractSlotToolStripMenuItem.Name = "extractSlotToolStripMenuItem";
			extractSlotToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			extractSlotToolStripMenuItem.Text = "Extract Slot";
			injectSlotToolStripMenuItem.Name = "injectSlotToolStripMenuItem";
			injectSlotToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			injectSlotToolStripMenuItem.Text = "Inject Slot";
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
			propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			propertiesToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			propertiesToolStripMenuItem.Text = "Slot Properties";
			propertiesToolStripMenuItem.Click += new System.EventHandler(propertiesToolStripMenuItem_Click);
			pbxSearch.ContextMenuStrip = cmsSearchOptions;
			pbxSearch.Image = (System.Drawing.Image)resources.GetObject("pbxSearch.Image");
			pbxSearch.Location = new System.Drawing.Point(152, 10);
			pbxSearch.Name = "pbxSearch";
			pbxSearch.Size = new System.Drawing.Size(16, 16);
			pbxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pbxSearch.TabIndex = 6;
			pbxSearch.TabStop = false;
			cmsSearchOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { nameToolStripMenuItem, indexToolStripMenuItem });
			cmsSearchOptions.Name = "cmsSearchOptions";
			cmsSearchOptions.Size = new System.Drawing.Size(107, 48);
			nameToolStripMenuItem.Checked = true;
			nameToolStripMenuItem.CheckOnClick = true;
			nameToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			nameToolStripMenuItem.Name = "nameToolStripMenuItem";
			nameToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			nameToolStripMenuItem.Text = "Name";
			nameToolStripMenuItem.Click += new System.EventHandler(nameToolStripMenuItem_Click);
			indexToolStripMenuItem.CheckOnClick = true;
			indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			indexToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
			indexToolStripMenuItem.Text = "Index";
			indexToolStripMenuItem.Click += new System.EventHandler(indexToolStripMenuItem_Click);
			pictureBox1.ContextMenuStrip = cmsWindowOptions;
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(3, 10);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(16, 16);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 5;
			pictureBox1.TabStop = false;
			cmsWindowOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { showToolStripMenuItem, viewByToolStripMenuItem, groupByToolStripMenuItem1, toolStripSeparator2, refreshWindowToolStripMenuItem });
			cmsWindowOptions.Name = "cmsWindowOptions";
			cmsWindowOptions.Size = new System.Drawing.Size(161, 98);
			showToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { mapInformationToolStripMenuItem, toolStripSeparator4, placementBlocksToolStripMenuItem, tagIndexToolStripMenuItem });
			showToolStripMenuItem.Name = "showToolStripMenuItem";
			showToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			showToolStripMenuItem.Text = "Show";
			placementBlocksToolStripMenuItem.Checked = true;
			placementBlocksToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			placementBlocksToolStripMenuItem.Name = "placementBlocksToolStripMenuItem";
			placementBlocksToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			placementBlocksToolStripMenuItem.Text = "Placement Blocks";
			placementBlocksToolStripMenuItem.Click += new System.EventHandler(placementBlocksToolStripMenuItem_Click);
			tagIndexToolStripMenuItem.Name = "tagIndexToolStripMenuItem";
			tagIndexToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			tagIndexToolStripMenuItem.Text = "Tag Index";
			tagIndexToolStripMenuItem.Click += new System.EventHandler(tagIndexToolStripMenuItem_Click);
			viewByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7] { reservedSlotsToolStripMenuItem, originalSlotsToolStripMenuItem, addedSlotsToolStripMenuItem, editedSlotsToolStripMenuItem, unsortedSlotsToolStripMenuItem, emptySlotsToolStripMenuItem, playerSpawnsToolStripMenuItem });
			viewByToolStripMenuItem.Name = "viewByToolStripMenuItem";
			viewByToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			viewByToolStripMenuItem.Text = "View By";
			reservedSlotsToolStripMenuItem.Checked = true;
			reservedSlotsToolStripMenuItem.CheckOnClick = true;
			reservedSlotsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			reservedSlotsToolStripMenuItem.Name = "reservedSlotsToolStripMenuItem";
			reservedSlotsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			reservedSlotsToolStripMenuItem.Text = "Reserved Slots";
			reservedSlotsToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
			originalSlotsToolStripMenuItem.Checked = true;
			originalSlotsToolStripMenuItem.CheckOnClick = true;
			originalSlotsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			originalSlotsToolStripMenuItem.Name = "originalSlotsToolStripMenuItem";
			originalSlotsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			originalSlotsToolStripMenuItem.Text = "Original Slots";
			originalSlotsToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
			addedSlotsToolStripMenuItem.Checked = true;
			addedSlotsToolStripMenuItem.CheckOnClick = true;
			addedSlotsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			addedSlotsToolStripMenuItem.Name = "addedSlotsToolStripMenuItem";
			addedSlotsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			addedSlotsToolStripMenuItem.Text = "Added Slots";
			addedSlotsToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
			editedSlotsToolStripMenuItem.Checked = true;
			editedSlotsToolStripMenuItem.CheckOnClick = true;
			editedSlotsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			editedSlotsToolStripMenuItem.Name = "editedSlotsToolStripMenuItem";
			editedSlotsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			editedSlotsToolStripMenuItem.Text = "Edited Slots";
			editedSlotsToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
			unsortedSlotsToolStripMenuItem.Checked = true;
			unsortedSlotsToolStripMenuItem.CheckOnClick = true;
			unsortedSlotsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			unsortedSlotsToolStripMenuItem.Name = "unsortedSlotsToolStripMenuItem";
			unsortedSlotsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			unsortedSlotsToolStripMenuItem.Text = "Unsorted Slots";
			unsortedSlotsToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
			emptySlotsToolStripMenuItem.Checked = true;
			emptySlotsToolStripMenuItem.CheckOnClick = true;
			emptySlotsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			emptySlotsToolStripMenuItem.Name = "emptySlotsToolStripMenuItem";
			emptySlotsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			emptySlotsToolStripMenuItem.Text = "Empty Slots";
			emptySlotsToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
			playerSpawnsToolStripMenuItem.Checked = true;
			playerSpawnsToolStripMenuItem.CheckOnClick = true;
			playerSpawnsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			playerSpawnsToolStripMenuItem.Name = "playerSpawnsToolStripMenuItem";
			playerSpawnsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			playerSpawnsToolStripMenuItem.Text = "Player Spawns";
			playerSpawnsToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
			groupByToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { noGroupingToolStripMenuItem, toolStripSeparator3, blockTypeToolStripMenuItem1, tagTypeToolStripMenuItem1 });
			groupByToolStripMenuItem1.Name = "groupByToolStripMenuItem1";
			groupByToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
			groupByToolStripMenuItem1.Text = "Group By";
			noGroupingToolStripMenuItem.CheckOnClick = true;
			noGroupingToolStripMenuItem.Name = "noGroupingToolStripMenuItem";
			noGroupingToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			noGroupingToolStripMenuItem.Text = "No Grouping";
			noGroupingToolStripMenuItem.Click += new System.EventHandler(noGroupingToolStripMenuItem_Click);
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
			blockTypeToolStripMenuItem1.Checked = true;
			blockTypeToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			blockTypeToolStripMenuItem1.Name = "blockTypeToolStripMenuItem1";
			blockTypeToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
			blockTypeToolStripMenuItem1.Text = "Block Type";
			blockTypeToolStripMenuItem1.Click += new System.EventHandler(blockTypeToolStripMenuItem1_Click);
			tagTypeToolStripMenuItem1.Name = "tagTypeToolStripMenuItem1";
			tagTypeToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
			tagTypeToolStripMenuItem1.Text = "Tag Type";
			tagTypeToolStripMenuItem1.Click += new System.EventHandler(tagTypeToolStripMenuItem1_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
			refreshWindowToolStripMenuItem.Name = "refreshWindowToolStripMenuItem";
			refreshWindowToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			refreshWindowToolStripMenuItem.Text = "Refresh Window";
			refreshWindowToolStripMenuItem.Click += new System.EventHandler(refreshToolStripMenuItem_Click);
			mapInformationToolStripMenuItem.Name = "mapInformationToolStripMenuItem";
			mapInformationToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			mapInformationToolStripMenuItem.Text = "Map Information";
			mapInformationToolStripMenuItem.Click += new System.EventHandler(mapInformationToolStripMenuItem_Click);
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new System.Drawing.Size(164, 6);
			listView1.AllowDrop = true;
			listView1.AllowRowReorder = false;
			listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { columnHeader1, columnHeader2 });
			listViewGroup1.Header = "Reserved Slots";
			listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup1.Name = "Reserved";
			listViewGroup2.Header = "Original Slots";
			listViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup2.Name = "Original";
			listViewGroup3.Header = "Added Slots";
			listViewGroup3.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup3.Name = "Added";
			listViewGroup4.Header = "Edited Slots";
			listViewGroup4.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup4.Name = "Edited";
			listViewGroup5.Header = "Unsorted Slots";
			listViewGroup5.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup5.Name = "Unsorted";
			listViewGroup6.Header = "Player Spawns";
			listViewGroup6.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup6.Name = "Player_Spawn";
			listViewGroup7.Header = "Empty Slots";
			listViewGroup7.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
			listViewGroup7.Name = "NULL";
			listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[7] { listViewGroup1, listViewGroup2, listViewGroup3, listViewGroup4, listViewGroup5, listViewGroup6, listViewGroup7 });
			listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			listView1.Location = new System.Drawing.Point(0, 34);
			listView1.MultiSelect = false;
			listView1.Name = "listView1";
			listView1.ShowItemToolTips = true;
			listView1.Size = new System.Drawing.Size(514, 364);
			listView1.TabIndex = 4;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = System.Windows.Forms.View.Details;
			listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(listView1_MouseDown);
			columnHeader1.Text = "Name";
			columnHeader1.Width = 400;
			columnHeader2.Text = "Index";
			columnHeader2.Width = 103;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(panel1);
			base.Controls.Add(listView1);
			base.Controls.Add(comboBox1);
			base.Controls.Add(txtSearch);
			base.Controls.Add(pbxSearch);
			base.Controls.Add(pictureBox1);
			base.Name = "ListpanelV2";
			base.Size = new System.Drawing.Size(514, 451);
			panel1.ResumeLayout(false);
			cmsOptions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pbxSearch).EndInit();
			cmsSearchOptions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			cmsWindowOptions.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
