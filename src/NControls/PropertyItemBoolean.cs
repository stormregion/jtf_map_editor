using System;
using System.Runtime.InteropServices;

namespace NControls
{
	public class PropertyItemBoolean : PropertyItemEnum
	{
		protected unsafe override void GetItems()
		{
			this.dropList.Items.Add("True");
			this.dropList.Items.Add("False");
			int selectedIndex = (*(byte*)this.Var != 0) ? 0 : 1;
			this.dropList.SelectedIndex = selectedIndex;
		}

		protected unsafe override void SelectItem(int index)
		{
			if ((this.dropList.Items[index] as string).CompareTo("True") == 0)
			{
				void* var = this.Var;
				if (*(byte*)var != 1)
				{
					*(byte*)var = 1;
					this.Host.RaiseItemChanged();
					this.Host.InvalidateViewControl();
				}
			}
			else
			{
				void* var = this.Var;
				if (*(byte*)var != 0)
				{
					*(byte*)var = 0;
					this.Host.RaiseItemChanged();
					this.Host.InvalidateViewControl();
				}
			}
		}

		public unsafe override void Refresh()
		{
			int num = 0;
			if (0 < this.dropList.Items.Count)
			{
				do
				{
					string text = this.dropList.Items[num] as string;
					if (text.CompareTo("True") == 0 && *(byte*)this.Var != 0)
					{
						goto IL_74;
					}
					if (text.CompareTo("False") == 0 && *(byte*)this.Var == 0)
					{
						goto IL_82;
					}
					num++;
				}
				while (num < this.dropList.Items.Count);
				goto IL_8E;
				IL_74:
				this.dropList.SetSelection(num);
				goto IL_8E;
				IL_82:
				this.dropList.SetSelection(num);
			}
			IL_8E:
			this.Host.RaiseItemChanged();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe override bool IsDefault()
		{
			byte b = (this.Default != 0u) ? 1 : 0;
			return *(byte*)this.Var == b;
		}

		public override void SetDefault()
		{
			bool flag = this.Default != 0u;
			int num = 0;
			if (0 < this.dropList.Items.Count)
			{
				do
				{
					string text = this.dropList.Items[num] as string;
					if (text.CompareTo("True") == 0 && flag)
					{
						goto IL_73;
					}
					if (text.CompareTo("False") == 0 && !flag)
					{
						goto IL_81;
					}
					num++;
				}
				while (num < this.dropList.Items.Count);
				return;
				IL_73:
				this.dropList.SetSelection(num);
				return;
				IL_81:
				this.dropList.SetSelection(num);
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public override bool HasDefaultOption()
		{
			return true;
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
