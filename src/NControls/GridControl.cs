using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace NControls
{
	public class GridControl : BaseScrollableControl
	{
		public delegate void __Delegate_ChooseItem(int);

		public delegate void __Delegate_DoubleClickItem(int);

		private HeaderControl GridHeader;

		private GridControlCore GridCore;

		private ControlEventHandler MyControlAddedHandler;

		public event GridControl.__Delegate_DoubleClickItem DoubleClickItem
		{
			add
			{
				this.DoubleClickItem = Delegate.Combine(this.DoubleClickItem, value);
			}
			remove
			{
				this.DoubleClickItem = Delegate.Remove(this.DoubleClickItem, value);
			}
		}

		public event GridControl.__Delegate_ChooseItem ChooseItem
		{
			add
			{
				this.ChooseItem = Delegate.Combine(this.ChooseItem, value);
			}
			remove
			{
				this.ChooseItem = Delegate.Remove(this.ChooseItem, value);
			}
		}

		public Control.ControlCollection OwnControls
		{
			get
			{
				return base.Controls;
			}
		}

		public new Control.ControlCollection Controls
		{
			get
			{
				return this.GridCore.Controls;
			}
		}

		public ArrayList ColumnDatas
		{
			get
			{
				return this.GridCore.ColumnDatas;
			}
		}

		public int SelectedIndex
		{
			get
			{
				return this.GridCore.SelectedIndex;
			}
			set
			{
				this.GridCore.SelectedIndex = value;
			}
		}

		public ArrayList Items
		{
			get
			{
				return this.GridCore.Items;
			}
		}

		public GridControl(int width, int height, ArrayList column_items, int scrollbarmode)
		{
			this.ChooseItem = null;
			this.DoubleClickItem = null;
			base.Width = width;
			base.Height = height;
			int num = height - 20;
			int expr_2C = num;
			this.GridCore = new GridControlCore(width, expr_2C, expr_2C, scrollbarmode);
			Point location = new Point(0, 20);
			this.GridCore.Location = location;
			IEnumerator enumerator = column_items.GetEnumerator();
			float proportion = 1f / (float)column_items.Count;
			if (enumerator.MoveNext())
			{
				do
				{
					ColumnItem columnItem = enumerator.Current as ColumnItem;
					ColumnData columnData = new ColumnData(columnItem.Name, (int)((double)columnItem.MinWidth));
					columnData.Proportion = proportion;
					this.ColumnDatas.Add(columnData);
				}
				while (enumerator.MoveNext());
			}
			this.GridHeader = new HeaderControl(this.GridCore);
			this.GridHeader.Width = this.GridCore.GetViewControlWidth();
			this.GridHeader.Height = 20;
			this.GridHeader.RecalcColumnDatas();
			this.OwnControls.Add(this.GridHeader);
			this.OwnControls.Add(this.GridCore);
			this.GridCore.ChooseItem += new GridControlCore.__Delegate_ChooseItem(this.GridCoreChooseItem);
			this.GridCore.DoubleClickItem += new GridControlCore.__Delegate_DoubleClickItem(this.GridCoreDoubleClickItem);
		}

		public void GridCoreChooseItem(int index)
		{
			this.raise_ChooseItem(index);
		}

		public void GridCoreDoubleClickItem(int index)
		{
			this.raise_DoubleClickItem(index);
		}

		public void UpdateViewHeight()
		{
			this.GridCore.UpdateViewHeight();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (this.GridCore != null)
			{
				this.GridCore.Width = base.Width;
				this.GridCore.Height = base.Height - 20;
				this.GridHeader.Width = this.GridCore.GetViewControlWidth();
				this.GridHeader.RecalcColumnDatas();
				this.GridHeader.Refresh();
			}
		}

		protected void raise_ChooseItem(int i1)
		{
			GridControl.__Delegate_ChooseItem chooseItem = this.ChooseItem;
			if (chooseItem != null)
			{
				chooseItem(i1);
			}
		}

		protected void raise_DoubleClickItem(int i1)
		{
			GridControl.__Delegate_DoubleClickItem doubleClickItem = this.DoubleClickItem;
			if (doubleClickItem != null)
			{
				doubleClickItem(i1);
			}
		}
	}
}
