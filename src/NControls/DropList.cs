using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace NControls
{
	public class DropList : Control
	{
		public delegate void __Delegate_ChooseItem(int);

		public delegate void __Delegate_MouseDownOccured();

		public Brush NormalItemBackgroundBrush;

		public Brush NormalItemTextBrush;

		public Brush DropButtonLightBorderBrush;

		public Brush DropButtonDarkBorderBrush;

		public Brush DropButtonBackgroundBrush;

		public Brush DropButtonTextBrush;

		public Font ListFont;

		public DropListPopup ItemsListBox;

		public ArrayList Items;

		public int SelectedIndex;

		public event DropList.__Delegate_MouseDownOccured MouseDownOccured
		{
			add
			{
				this.MouseDownOccured = Delegate.Combine(this.MouseDownOccured, value);
			}
			remove
			{
				this.MouseDownOccured = Delegate.Remove(this.MouseDownOccured, value);
			}
		}

		public event DropList.__Delegate_ChooseItem ChooseItem
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

		public DropList()
		{
			this.ChooseItem = null;
			this.MouseDownOccured = null;
			Color color = Color.FromKnownColor(KnownColor.Window);
			this.NormalItemBackgroundBrush = new SolidBrush(color);
			Color color2 = Color.FromKnownColor(KnownColor.WindowText);
			this.NormalItemTextBrush = new SolidBrush(color2);
			Color color3 = Color.FromKnownColor(KnownColor.ControlLightLight);
			this.DropButtonLightBorderBrush = new SolidBrush(color3);
			Color color4 = Color.FromKnownColor(KnownColor.ControlDark);
			this.DropButtonDarkBorderBrush = new SolidBrush(color4);
			Color color5 = Color.FromKnownColor(KnownColor.Control);
			this.DropButtonBackgroundBrush = new SolidBrush(color5);
			Color color6 = Color.FromKnownColor(KnownColor.ControlText);
			this.DropButtonTextBrush = new SolidBrush(color6);
			this.ListFont = this.Font;
			this.Items = new ArrayList();
			this.SelectedIndex = -1;
		}

		public void SetSelection(int sel)
		{
			this.SelectedIndex = sel;
			base.Invalidate();
			this.UnDrop();
			this.raise_ChooseItem(this.SelectedIndex);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			Rectangle clipRectangle = e.ClipRectangle;
			e.Graphics.FillRectangle(this.NormalItemBackgroundBrush, clipRectangle);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.SelectedIndex >= 0)
			{
				PointF point = new PointF(0f, 1f);
				e.Graphics.DrawString(this.Items[this.SelectedIndex].ToString(), this.Font, this.NormalItemTextBrush, point);
			}
			float num = (float)(base.Width - 16);
			float x = num + 1f;
			e.Graphics.FillRectangle(this.DropButtonBackgroundBrush, x, 1f, 14f, (float)base.Height - 2f);
			e.Graphics.FillRectangle(this.DropButtonLightBorderBrush, num, 0f, 15f, 1f);
			e.Graphics.FillRectangle(this.DropButtonLightBorderBrush, num, 0f, 1f, (float)base.Height);
			e.Graphics.FillRectangle(this.DropButtonDarkBorderBrush, x, (float)base.Height - 1f, 14f, 1f);
			e.Graphics.FillRectangle(this.DropButtonDarkBorderBrush, num + 16f - 1f, 0f, 1f, (float)base.Height);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, num + 5f, 6f, 7f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, num + 6f, 7f, 5f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, num + 7f, 8f, 3f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, num + 8f, 9f, 1f, 1f);
		}

		protected override void OnClick(EventArgs e)
		{
			if (this.ItemsListBox == null)
			{
				this.Drop();
			}
			else
			{
				this.UnDrop();
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			this.Drop();
		}

		protected void ItemsListBox_ChooseItem(int index)
		{
			if (index >= 0)
			{
				this.SelectedIndex = index;
				base.Invalidate();
			}
			this.UnDrop();
			this.raise_ChooseItem(this.SelectedIndex);
		}

		protected unsafe void Drop()
		{
			if (this.ItemsListBox == null)
			{
				this.ItemsListBox = new DropListPopup();
				Size size = new Size(base.Size.Width, 300);
				this.ItemsListBox.Size = size;
				this.ItemsListBox.Font = this.ListFont;
				ArrayList items = this.Items;
				if (items != null)
				{
					int num = 0;
					if (0 < items.Count)
					{
						do
						{
							this.ItemsListBox.Items.Add(this.Items[num]);
							num++;
						}
						while (num < this.Items.Count);
					}
				}
				int selectedIndex = this.SelectedIndex;
				if (selectedIndex >= 0)
				{
					this.ItemsListBox.SelectedIndex = selectedIndex;
				}
				Size size2 = base.Size;
				int num2 = this.ItemsListBox.Items.Count + 1;
				Size size3 = new Size(size2.Width, this.ItemsListBox.ItemHeight * num2);
				this.ItemsListBox.Size = size3;
				Point p = new Point(-1, base.Size.Height);
				Point location = base.PointToScreen(p);
				this.ItemsListBox.Location = location;
				int arg_14C_0 = <Module>.GetSystemMetrics(1);
				Point location2 = this.ItemsListBox.Location;
				if (arg_14C_0 < this.ItemsListBox.Size.Height + location2.Y)
				{
					Point p2 = new Point(-1, -(this.ItemsListBox.Items.Count * this.ItemsListBox.ItemHeight));
					Point location3 = base.PointToScreen(p2);
					this.ItemsListBox.Location = location3;
				}
				this.ItemsListBox.Parent = base.Parent;
				this.ItemsListBox.ChooseItem += new DropListPopup.__Delegate_ChooseItem(this.ItemsListBox_ChooseItem);
				this.ItemsListBox.CreateControl();
				<Module>.SetCapture((HWND__*)this.ItemsListBox.Handle.ToPointer());
			}
		}

		protected void UnDrop()
		{
			DropListPopup itemsListBox = this.ItemsListBox;
			if (itemsListBox != null)
			{
				itemsListBox.Dispose();
				this.ItemsListBox = null;
			}
		}

		protected void raise_ChooseItem(int i1)
		{
			DropList.__Delegate_ChooseItem chooseItem = this.ChooseItem;
			if (chooseItem != null)
			{
				chooseItem(i1);
			}
		}

		protected void raise_MouseDownOccured()
		{
			DropList.__Delegate_MouseDownOccured mouseDownOccured = this.MouseDownOccured;
			if (mouseDownOccured != null)
			{
				mouseDownOccured();
			}
		}
	}
}
