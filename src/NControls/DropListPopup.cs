using System;
using System.Drawing;
using System.Windows.Forms;

namespace NControls
{
	public class DropListPopup : ListBox
	{
		public delegate void __Delegate_ChooseItem(int);

		public event DropListPopup.__Delegate_ChooseItem ChooseItem
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

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style = -1868562432;
				createParams.ExStyle = 0;
				return createParams;
			}
		}

		public DropListPopup()
		{
			this.ChooseItem = null;
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.ItemHeight += 2;
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.raise_ChooseItem(this.SelectedIndex);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.X >= 0)
			{
				Size size = base.Size;
				if (e.X < size.Width && e.Y >= 0)
				{
					Size size2 = base.Size;
					if (e.Y < size2.Height)
					{
						return;
					}
				}
			}
			this.raise_ChooseItem(-1);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.raise_ChooseItem(this.SelectedIndex);
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.raise_ChooseItem(-1);
			}
			else
			{
				base.OnKeyDown(e);
			}
		}

		protected void raise_ChooseItem(int i1)
		{
			DropListPopup.__Delegate_ChooseItem chooseItem = this.ChooseItem;
			if (chooseItem != null)
			{
				chooseItem(i1);
			}
		}
	}
}
