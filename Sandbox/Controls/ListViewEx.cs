using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Sandbox.Controls
{
	public class ListViewEx : ListView
	{
		private const string REORDER = "Reorder";

		private bool allowRowReorder = true;

		public bool AllowRowReorder
		{
			get
			{
				return allowRowReorder;
			}
			set
			{
				allowRowReorder = value;
				base.AllowDrop = value;
			}
		}

		public new SortOrder Sorting
		{
			get
			{
				return SortOrder.None;
			}
			set
			{
				base.Sorting = SortOrder.None;
			}
		}

		public ListViewEx()
		{
			AllowRowReorder = true;
		}

		protected override void OnDragDrop(DragEventArgs e)
		{
			base.OnDragDrop(e);
			if (!AllowRowReorder || base.SelectedItems.Count == 0)
			{
				return;
			}
			Point cp = PointToClient(new Point(e.X, e.Y));
			ListViewItem dragToItem = GetItemAt(cp.X, cp.Y);
			if (dragToItem == null)
			{
				return;
			}
			int dropIndex = dragToItem.Index;
			if (dropIndex > base.SelectedItems[0].Index)
			{
				dropIndex++;
			}
			ArrayList insertItems = new ArrayList(base.SelectedItems.Count);
			foreach (ListViewItem item in base.SelectedItems)
			{
				insertItems.Add(item.Clone());
			}
			for (int i = insertItems.Count - 1; i >= 0; i--)
			{
				ListViewItem insertItem = (ListViewItem)insertItems[i];
				base.Items.Insert(dropIndex, insertItem);
			}
			foreach (ListViewItem removeItem in base.SelectedItems)
			{
				base.Items.Remove(removeItem);
			}
		}

		protected override void OnDragOver(DragEventArgs e)
		{
			if (!AllowRowReorder)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			if (!e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			Point cp = PointToClient(new Point(e.X, e.Y));
			ListViewItem hoverItem = GetItemAt(cp.X, cp.Y);
			if (hoverItem == null)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			foreach (ListViewItem moveItem in base.SelectedItems)
			{
				if (moveItem.Index == hoverItem.Index)
				{
					e.Effect = DragDropEffects.None;
					hoverItem.EnsureVisible();
					return;
				}
			}
			base.OnDragOver(e);
			string text = (string)e.Data.GetData("Reorder".GetType());
			if (text.CompareTo("Reorder") == 0)
			{
				e.Effect = DragDropEffects.Move;
				hoverItem.EnsureVisible();
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		protected override void OnDragEnter(DragEventArgs e)
		{
			base.OnDragEnter(e);
			if (!AllowRowReorder)
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			if (!e.Data.GetDataPresent(DataFormats.Text))
			{
				e.Effect = DragDropEffects.None;
				return;
			}
			base.OnDragEnter(e);
			string text = (string)e.Data.GetData("Reorder".GetType());
			if (text.CompareTo("Reorder") == 0)
			{
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		protected override void OnItemDrag(ItemDragEventArgs e)
		{
			base.OnItemDrag(e);
			if (AllowRowReorder)
			{
				DoDragDrop("Reorder", DragDropEffects.Move);
			}
		}
	}
}
