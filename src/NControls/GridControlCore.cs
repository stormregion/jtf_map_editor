using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class GridControlCore : ScrollableControl, IMultiColumnControl
	{
		public delegate void __Delegate_ChooseItem(int);

		public delegate void __Delegate_DoubleClickItem(int);

		private ArrayList propItems;

		private ArrayList propColumnDatas;

		private int propSelectedIndex;

		private float CellHeight;

		public Brush NormalItemBackgroundBrush;

		public Brush SelectedItemBackgroundBrush;

		public Brush NormalItemTextBrush;

		public Brush SelectedItemTextBrush;

		public event GridControlCore.__Delegate_DoubleClickItem DoubleClickItem
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

		public event GridControlCore.__Delegate_ChooseItem ChooseItem
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

		public int SelectedIndex
		{
			get
			{
				return this.propSelectedIndex;
			}
			set
			{
				this.propSelectedIndex = value;
			}
		}

		public override ArrayList ColumnDatas
		{
			get
			{
				return this.propColumnDatas;
			}
		}

		public ArrayList Items
		{
			get
			{
				return this.propItems;
			}
		}

		public GridControlCore(int width, int height, int viewheight, int scrollbarmode) : base(width, height, viewheight, scrollbarmode)
		{
			this.ChooseItem = null;
			this.DoubleClickItem = null;
			this.propItems = new ArrayList();
			this.propColumnDatas = new ArrayList();
			Color color = Color.FromKnownColor(KnownColor.Window);
			this.NormalItemBackgroundBrush = new SolidBrush(color);
			Color color2 = Color.FromKnownColor(KnownColor.WindowText);
			this.NormalItemTextBrush = new SolidBrush(color2);
			Color color3 = Color.FromKnownColor(KnownColor.ActiveCaption);
			this.SelectedItemBackgroundBrush = new SolidBrush(color3);
			Color color4 = Color.FromKnownColor(KnownColor.ActiveCaptionText);
			this.SelectedItemTextBrush = new SolidBrush(color4);
			this.ViewControl.Paint += new PaintEventHandler(this.ViewControlPaint);
			this.ViewControl.MouseDown += new MouseEventHandler(this.ViewControlMouseDown);
			this.ViewControl.DoubleClick += new EventHandler(this.ViewControlDoubleClick);
			this.CellHeight = (float)((double)this.Font.Height + 5.0);
			Color backColor = Color.FromKnownColor(KnownColor.Window);
			this.BackColor = backColor;
		}

		private void ViewControlPaint(object sender, PaintEventArgs e)
		{
			int num = (int)((double)((float)base.StartY / this.CellHeight));
			int num2 = (int)((double)((float)base.Height / this.CellHeight + 2f));
			if (num2 + num > this.propItems.Count - 1)
			{
				num2 = this.propItems.Count - num;
			}
			IEnumerator enumerator = this.propItems.GetRange(num, num2).GetEnumerator();
			int num3 = (int)((double)(this.CellHeight * (float)num));
			if (enumerator.MoveNext())
			{
				do
				{
					if (enumerator.Current.GetType().Equals(Type.GetType("System.Collections.ArrayList")))
					{
						IEnumerator enumerator2 = (enumerator.Current as ArrayList).GetEnumerator();
						IEnumerator enumerator3 = this.ColumnDatas.GetEnumerator();
						float num4 = 0f;
						if (enumerator2.MoveNext())
						{
							while (enumerator3.MoveNext())
							{
								float width = (enumerator3.Current as ColumnData).Width;
								float num5;
								Brush brush;
								if (num != this.SelectedIndex)
								{
									num5 = (float)num3;
									e.Graphics.FillRectangle(this.NormalItemBackgroundBrush, num4, num5, width, this.CellHeight);
									brush = this.NormalItemTextBrush;
								}
								else
								{
									num5 = (float)num3;
									e.Graphics.FillRectangle(this.SelectedItemBackgroundBrush, num4, num5, width, this.CellHeight);
									brush = this.SelectedItemTextBrush;
								}
								e.Graphics.DrawString(enumerator2.Current.ToString(), this.Font, brush, num4, num5 + 2f);
								num4 = width + num4;
								if (!enumerator2.MoveNext())
								{
									break;
								}
							}
						}
					}
					else
					{
						Brush brush;
						if (num != this.SelectedIndex)
						{
							brush = this.NormalItemTextBrush;
						}
						else
						{
							e.Graphics.FillRectangle(this.SelectedItemBackgroundBrush, 0f, (float)num3, (float)base.Width, this.CellHeight);
							brush = this.SelectedItemTextBrush;
						}
						e.Graphics.DrawString(enumerator.Current.ToString(), this.Font, brush, 0f, (float)num3 + 1f);
					}
					num3 = (int)((double)(this.CellHeight + (float)num3));
					num++;
				}
				while (enumerator.MoveNext());
			}
		}

		private void ViewControlMouseDown(object sender, MouseEventArgs e)
		{
			this.SelectedIndex = (int)((double)((float)(e.Y - 1) / this.CellHeight));
			this.EnsureSelectedVisible();
			this.raise_ChooseItem(this.SelectedIndex);
		}

		private void ViewControlDoubleClick(object sender, EventArgs e)
		{
			this.raise_DoubleClickItem(this.SelectedIndex);
		}

		[return: MarshalAs(UnmanagedType.U1)]
		protected override bool IsInputKey(Keys keyData)
		{
			return true;
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				if (this.SelectedIndex > 0)
				{
					this.SelectedIndex--;
					this.EnsureSelectedVisible();
				}
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Down)
			{
				if (this.SelectedIndex < this.Items.Count - 1)
				{
					this.SelectedIndex++;
					this.EnsureSelectedVisible();
				}
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Home)
			{
				this.SelectedIndex = 0;
				this.EnsureSelectedVisible();
				e.Handled = true;
			}
			if (e.KeyCode == Keys.End)
			{
				if (this.Items.Count > 0)
				{
					this.SelectedIndex = this.Items.Count - 1;
					this.EnsureSelectedVisible();
				}
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Prior)
			{
				float num = (float)this.SelectedIndex;
				int num2 = (int)((double)(num - (float)base.Height / this.CellHeight + 1f));
				if (num2 >= 0)
				{
					this.SelectedIndex = num2;
				}
				else
				{
					this.SelectedIndex = 0;
				}
				this.EnsureSelectedVisible();
				e.Handled = true;
			}
			if (e.KeyCode == Keys.Next)
			{
				int num3 = (int)((double)((float)base.Height / this.CellHeight + (float)this.SelectedIndex - 1f));
				if (num3 < this.Items.Count)
				{
					this.SelectedIndex = num3;
				}
				else
				{
					this.SelectedIndex = this.Items.Count - 1;
				}
				this.EnsureSelectedVisible();
				e.Handled = true;
			}
			base.OnKeyDown(e);
			this.raise_ChooseItem(this.SelectedIndex);
		}

		public int GetViewControlWidth()
		{
			return this.ViewControl.Width;
		}

		public void UpdateViewHeight()
		{
			base.ViewHeight = (int)((double)((float)this.propItems.Count * this.CellHeight));
		}

		public void EnsureSelectedVisible()
		{
			if ((float)this.SelectedIndex * this.CellHeight < (float)base.StartY)
			{
				base.StartY = (int)((double)((float)this.SelectedIndex * this.CellHeight));
			}
			else
			{
				float num = (float)this.SelectedIndex * this.CellHeight - (float)base.StartY;
				if (num > (float)base.Height - this.CellHeight)
				{
					float num2 = (float)this.SelectedIndex * this.CellHeight;
					base.StartY = (int)((double)(num2 - (float)base.Height + this.CellHeight));
				}
			}
			this.ViewControl.Refresh();
		}

		public override void ColumnsResized()
		{
			this.ViewControl.Refresh();
		}

		protected void raise_ChooseItem(int i1)
		{
			GridControlCore.__Delegate_ChooseItem chooseItem = this.ChooseItem;
			if (chooseItem != null)
			{
				chooseItem(i1);
			}
		}

		protected void raise_DoubleClickItem(int i1)
		{
			GridControlCore.__Delegate_DoubleClickItem doubleClickItem = this.DoubleClickItem;
			if (doubleClickItem != null)
			{
				doubleClickItem(i1);
			}
		}
	}
}
