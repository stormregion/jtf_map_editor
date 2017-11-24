using GRTTI;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class PropertyItemEnum : PropertyItem
	{
		protected DropList dropList;

		protected void dropList_Enter(object sender, EventArgs e)
		{
		}

		protected void dropList_ChooseItem(int index)
		{
			if (index >= 0)
			{
				this.SelectItem(index);
			}
			if (this.IsDefault())
			{
				this.dropList.Font = new Font(this.dropList.Font, FontStyle.Regular);
			}
			else
			{
				this.dropList.Font = new Font(this.dropList.Font, FontStyle.Bold);
			}
			this.Host.Focus();
			this.Host.InvalidateViewControl();
		}

		protected void dropList_MouseDown(object __unnamed000, MouseEventArgs e)
		{
			Point location = this.dropList.Location;
			PropertyTreeCore host = this.Host;
			host.SelectedIndex = (int)((double)((float)location.Y / host.ItemHeight));
			this.Host.EnsureSelectedVisible();
			this.Host.InvalidateViewControl();
		}

		protected unsafe virtual void GetItems()
		{
			int num = 0;
			int num2 = *(int*)(this.Type + 24 / sizeof(GClass));
			if (*num2 != 0)
			{
				int num3 = 0;
				do
				{
					this.dropList.Items.Add(new string(*(num3 + num2 + 4)));
					if (*(num3 + *(int*)(this.Type + 24 / sizeof(GClass)) + 8) == *(int*)this.Var)
					{
						this.dropList.SelectedIndex = num;
					}
					num++;
					num3 = num * 12;
					num2 = *(int*)(this.Type + 24 / sizeof(GClass));
				}
				while (*(num2 + num3) != 0);
			}
		}

		protected unsafe virtual void SelectItem(int index)
		{
			string text = this.dropList.Items[index] as string;
			int num = 0;
			int num2 = *(int*)(this.Type + 24 / sizeof(GClass));
			if (*num2 != 0)
			{
				int num3 = 0;
				do
				{
					if (text.CompareTo(new string(*(num3 + num2 + 4))) == 0)
					{
						void* var = this.Var;
						int num4 = *(num3 + *(int*)(this.Type + 24 / sizeof(GClass)) + 8);
						if (*(int*)var != num4)
						{
							*(int*)var = num4;
							this.Host.RaiseItemChanged();
							this.Host.InvalidateViewControl();
						}
					}
					num++;
					num3 = num * 12;
					num2 = *(int*)(this.Type + 24 / sizeof(GClass));
				}
				while (*(num2 + num3) != 0);
			}
		}

		public unsafe override void Refresh()
		{
			int num = 0;
			int num2 = 0;
			int num3 = *(int*)(this.Type + 24 / sizeof(GClass));
			if (*num3 != 0)
			{
				int num4 = num3;
				int num5 = *(int*)this.Var;
				while (num5 != *(num4 + 8))
				{
					num2++;
					num4 = num3 + num2 * 12;
					if (*num4 == 0)
					{
						goto IL_3B;
					}
				}
				num = num2;
			}
			IL_3B:
			int num6 = 0;
			if (0 < this.dropList.Items.Count)
			{
				int num7 = num * 12;
				while ((this.dropList.Items[num6] as string).CompareTo(new string(*(num7 + *(int*)(this.Type + 24 / sizeof(GClass)) + 4))) != 0)
				{
					num6++;
					if (num6 >= this.dropList.Items.Count)
					{
						goto IL_AE;
					}
				}
				this.dropList.SetSelection(num6);
			}
			IL_AE:
			this.Host.RaiseItemChanged();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe override bool IsDefault()
		{
			return *(int*)this.Var == (int)this.Default;
		}

		public unsafe override void SetDefault()
		{
			int num = 0;
			int num2 = 0;
			int num3 = *(int*)(this.Type + 24 / sizeof(GClass));
			if (*num3 != 0)
			{
				int num4 = num3;
				uint @default = this.Default;
				while (@default != *(num4 + 8))
				{
					num2++;
					num4 = num3 + num2 * 12;
					if (*num4 == 0)
					{
						goto IL_3A;
					}
				}
				num = num2;
			}
			IL_3A:
			int num5 = 0;
			if (0 < this.dropList.Items.Count)
			{
				int num6 = num * 12;
				while ((this.dropList.Items[num5] as string).CompareTo(new string(*(num6 + *(int*)(this.Type + 24 / sizeof(GClass)) + 4))) != 0)
				{
					num5++;
					if (num5 >= this.dropList.Items.Count)
					{
						return;
					}
				}
				this.dropList.SetSelection(num5);
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public override bool HasDefaultOption()
		{
			return true;
		}

		public override void UpdateControl(Rectangle bounds)
		{
			bounds.X--;
			bounds.Y++;
			bounds.Height--;
			if (this.dropList != null)
			{
				Point location = bounds.Location;
				this.dropList.Location = location;
				Size size = bounds.Size;
				this.dropList.Size = size;
			}
			else
			{
				this.dropList = new DropList();
				Point location2 = bounds.Location;
				this.dropList.Location = location2;
				Size size2 = bounds.Size;
				this.dropList.Size = size2;
				this.dropList.TabIndex = 1;
				this.GetItems();
				if (this.IsDefault())
				{
					this.dropList.Font = new Font(this.dropList.Font, FontStyle.Regular);
				}
				else
				{
					this.dropList.Font = new Font(this.dropList.Font, FontStyle.Bold);
				}
				this.Host.Controls.Add(this.dropList);
				this.dropList.Enter += new EventHandler(this.dropList_Enter);
				this.dropList.ChooseItem += new DropList.__Delegate_ChooseItem(this.dropList_ChooseItem);
				this.dropList.MouseDown += new MouseEventHandler(this.dropList_MouseDown);
			}
		}

		public override void DestroyControl()
		{
			if (this.dropList != null)
			{
				this.dropList.Enter -= new EventHandler(this.dropList_Enter);
				this.dropList.ChooseItem -= new DropList.__Delegate_ChooseItem(this.dropList_ChooseItem);
				this.dropList.MouseDown -= new MouseEventHandler(this.dropList_MouseDown);
				this.Host.Controls.Remove(this.dropList);
				this.dropList = null;
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public override bool OnEnterPressed()
		{
			DropList dropList = this.dropList;
			if (dropList != null)
			{
				dropList.Focus();
			}
			this.Host.InvalidateViewControl();
			return true;
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
