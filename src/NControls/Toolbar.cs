using NWorkshop;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class Toolbar : Control, IRearrangeableControl
	{
		private class ToolbarItemProp
		{
			public Image itemImage;

			public Image itemDisabledImage;

			public Rectangle itemBounds;

			public bool Pushed;

			public bool Enabled;
		}

		public delegate void __Delegate_ButtonClick(int, int);

		private unsafe GToolbarItem* Items;

		private Toolbar.ToolbarItemProp[] ItemProps;

		private int NumItems;

		private int IconSize;

		private int LineHeight;

		private int ActiveItem;

		private bool ActivePressed;

		private int SelectedItem;

		public Brush ControlLight;

		public Brush ControlDark;

		public Brush NormalBackgroundBrush;

		public Brush PushedBackgroundBrush;

		public Brush SelectionBrush;

		public ToolTip Tooltip;

		private Container components;

		public event Toolbar.__Delegate_ButtonClick ButtonClick
		{
			add
			{
				this.ButtonClick = Delegate.Combine(this.ButtonClick, value);
			}
			remove
			{
				this.ButtonClick = Delegate.Remove(this.ButtonClick, value);
			}
		}

		public override event ToolRearranged Rearranged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.Rearranged = Delegate.Combine(this.Rearranged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.Rearranged = Delegate.Remove(this.Rearranged, value);
			}
		}

		public unsafe Toolbar(GToolbarItem* items, int icon_size)
		{
			this.ButtonClick = null;
			this.Rearranged = null;
			this.NumItems = 0;
			this.ActiveItem = -2;
			this.SelectedItem = -1;
			this.ActivePressed = false;
			base.SetStyle(ControlStyles.Selectable, false);
			this.InitializeComponent();
			this.Items = items;
			this.IconSize = icon_size;
			this.NumItems = 0;
			if (*(int*)items != -3)
			{
				do
				{
					this.NumItems++;
				}
				while (*(int*)(this.NumItems * 16 / sizeof(GToolbarItem) + this.Items) != -3);
			}
			this.ItemProps = new Toolbar.ToolbarItemProp[this.NumItems];
			ImageServer imageServer = ImageServer.GetImageServer("Images");
			int num = 0;
			if (0 < this.NumItems)
			{
				int num2 = 0;
				do
				{
					this.ItemProps[num] = new Toolbar.ToolbarItemProp();
					GToolbarItem* ptr = num2 / sizeof(GToolbarItem) + this.Items;
					int num3 = *(int*)ptr;
					if (num3 != -1 && num3 != -2)
					{
						this.ItemProps[num].itemImage = imageServer.GetImage(new string(*(int*)(ptr + 8 / sizeof(GToolbarItem))));
						this.ItemProps[num].itemDisabledImage = imageServer.GetImage(new string(*(int*)(num2 / sizeof(GToolbarItem) + this.Items + 8 / sizeof(GToolbarItem))) + "-disabled");
						Toolbar.ToolbarItemProp toolbarItemProp = this.ItemProps[num];
						if (toolbarItemProp.itemImage == null || toolbarItemProp.itemDisabledImage == null)
						{
							goto IL_170;
						}
					}
					this.ItemProps[num].Enabled = true;
					this.ItemProps[num].Pushed = false;
					num++;
					num2 += 16;
				}
				while (num < this.NumItems);
				goto IL_199;
				IL_170:
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CL@OAFELHOF@c?3?2jtfcode?2src?2workshop?2controls@), 98, (sbyte*)(&<Module>.??_C@_0BM@GKMMDKEB@NControls?3?3Toolbar?3?3Toolbar?$AA@));
				<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BF@GFLGEJNH@Icon?5?8?$CFs?8?5is?5missing?$AA@), *(int*)(num * 16 / sizeof(GToolbarItem) + this.Items + 8 / sizeof(GToolbarItem)));
			}
			IL_199:
			this.LineHeight = this.IconSize + 6;
			Color color = Color.FromKnownColor(KnownColor.Control);
			Color color2 = Color.FromKnownColor(KnownColor.ControlLightLight);
			this.ControlLight = new SolidBrush(color2);
			Color color3 = Color.FromKnownColor(KnownColor.ControlDark);
			this.ControlDark = new SolidBrush(color3);
			Color color4 = Color.FromArgb((int)((double)((float)color.R * 0.8333333f)), (int)((double)((float)color.G * 0.8333333f)), (int)((double)((float)color.B * 0.8333333f)));
			int num4 = (int)((double)((float)color.B * 1.2f));
			int blue;
			if (num4 < 255)
			{
				blue = num4;
			}
			else
			{
				blue = 255;
			}
			int num5 = (int)((double)((float)color.G * 1.2f));
			int green;
			if (num5 < 255)
			{
				green = num5;
			}
			else
			{
				green = 255;
			}
			int num6 = (int)((double)((float)color.R * 1.2f));
			Color color5 = Color.FromArgb((num6 >= 255) ? 255 : num6, green, blue);
			Point point = new Point(0, this.LineHeight);
			Point point2 = new Point(0, 0);
			this.NormalBackgroundBrush = new LinearGradientBrush(point2, point, color5, color4);
			int num7 = (int)((double)((float)color.B * 1.2f));
			int blue2;
			if (num7 < 255)
			{
				blue2 = num7;
			}
			else
			{
				blue2 = 255;
			}
			int num8 = (int)((double)((float)color.G * 1.2f));
			int green2;
			if (num8 < 255)
			{
				green2 = num8;
			}
			else
			{
				green2 = 255;
			}
			int num9 = (int)((double)((float)color.R * 1.2f));
			Color color6 = Color.FromArgb((num9 >= 255) ? 255 : num9, green2, blue2);
			Color color7 = Color.FromArgb((int)((double)((float)color.R * 0.8333333f)), (int)((double)((float)color.G * 0.8333333f)), (int)((double)((float)color.B * 0.8333333f)));
			Point point3 = new Point(0, this.LineHeight);
			Point point4 = new Point(0, 0);
			this.PushedBackgroundBrush = new LinearGradientBrush(point4, point3, color7, color6);
			Color color8 = Color.FromKnownColor(KnownColor.Highlight);
			this.SelectionBrush = new SolidBrush(color8);
			ToolTip toolTip = new ToolTip();
			this.Tooltip = toolTip;
			toolTip.SetToolTip(this, " ");
			this.RearrangeToolbar();
		}

		public unsafe void RearrangeToolbar()
		{
			if (this.NumItems != 0 && base.Size.Width != 0)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int numItems = this.NumItems;
				if (0 < numItems)
				{
					while (true)
					{
						int num4 = 0;
						int num5 = 0;
						int num6 = 0;
						int num7 = 0;
						int num8 = num3;
						if (num3 >= numItems)
						{
							goto IL_11E;
						}
						int num11;
						do
						{
							int num9 = 0;
							int num10 = 0;
							num11 = num8;
							int num12 = numItems;
							if (num8 < num12)
							{
								GToolbarItem* ptr = num8 * 16 / sizeof(GToolbarItem) + this.Items;
								do
								{
									int num13 = *(int*)ptr;
									if (num13 == -1)
									{
										break;
									}
									if (num13 == -2)
									{
										num10++;
									}
									else
									{
										num9 = this.IconSize + num9 + 6;
									}
									num11++;
									ptr += 16 / sizeof(GToolbarItem);
								}
								while (num11 < num12);
							}
							Size size = base.Size;
							int num14 = num4 + (num9 + num6);
							if (num14 > size.Width)
							{
								break;
							}
							num4 = num14;
							num5 = num10 + num5;
							num7 = num11;
							num6 = 0;
							numItems = this.NumItems;
							int num15 = numItems;
							if (num11 < num15)
							{
								GToolbarItem* ptr2 = num11 * 16 / sizeof(GToolbarItem) + this.Items;
								while (*(int*)ptr2 == -1)
								{
									num6 += 6;
									num11++;
									ptr2 += 16 / sizeof(GToolbarItem);
									if (num11 >= num15)
									{
										break;
									}
								}
							}
							num8 = num11;
						}
						while (num11 < numItems);
						if (num8 == num3)
						{
							goto IL_11E;
						}
						int num16 = base.Size.Width - num4;
						int num17;
						if (num5 > 1)
						{
							num17 = num5;
						}
						else
						{
							num17 = 1;
						}
						int num18 = num16 / num17;
						int num19;
						if (num5 > 1)
						{
							num19 = num5;
						}
						else
						{
							num19 = 1;
						}
						int num20 = num16 % num19;
						int num21 = num3;
						if (num3 < num7)
						{
							int num22 = num3 * 16;
							do
							{
								int num23 = *(int*)(this.Items + num22 / sizeof(GToolbarItem));
								int num24;
								if (num23 == -1)
								{
									num24 = 6;
								}
								else if (num23 == -2)
								{
									num24 = num18;
									if (num20 != 0)
									{
										num24 = num18 + 1;
										num20--;
									}
								}
								else
								{
									num24 = this.IconSize + 6;
								}
								this.ItemProps[num21].itemBounds.X = num2;
								this.ItemProps[num21].itemBounds.Y = this.LineHeight * num;
								this.ItemProps[num21].itemBounds.Width = num24;
								this.ItemProps[num21].itemBounds.Height = this.LineHeight;
								num2 = num24 + num2;
								num21++;
								num22 += 16;
							}
							while (num21 < num7);
						}
						if (num21 < num8)
						{
							do
							{
								this.ItemProps[num21].itemBounds.X = num2;
								this.ItemProps[num21].itemBounds.Y = this.LineHeight * num;
								this.ItemProps[num21].itemBounds.Width = 0;
								this.ItemProps[num21].itemBounds.Height = this.LineHeight;
								num21++;
							}
							while (num21 < num8);
						}
						num++;
						num2 = 0;
						num3 = num21;
						IL_390:
						numItems = this.NumItems;
						if (num21 >= numItems)
						{
							break;
						}
						continue;
						IL_11E:
						num21 = num3;
						if (num3 < this.NumItems)
						{
							int num25 = num3 * 16;
							do
							{
								int num26 = *(int*)(this.Items + num25 / sizeof(GToolbarItem));
								if (num26 == -1)
								{
									break;
								}
								if (num26 != -2)
								{
									int num27 = this.IconSize + 6;
									Size size2 = base.Size;
									if (num2 + num27 > size2.Width)
									{
										break;
									}
									this.ItemProps[num21].itemBounds.X = num2;
									this.ItemProps[num21].itemBounds.Y = this.LineHeight * num;
									this.ItemProps[num21].itemBounds.Width = num27;
									this.ItemProps[num21].itemBounds.Height = this.LineHeight;
									num2 += num27;
								}
								num21++;
								num25 += 16;
							}
							while (num21 < this.NumItems);
						}
						int numItems2 = this.NumItems;
						if (num21 < numItems2)
						{
							GToolbarItem* ptr3 = num21 * 16 / sizeof(GToolbarItem) + this.Items;
							while (*(int*)ptr3 == -1)
							{
								num21++;
								ptr3 += 16 / sizeof(GToolbarItem);
								if (num21 >= numItems2)
								{
									break;
								}
							}
						}
						num++;
						num2 = 0;
						num3 = num21;
						goto IL_390;
					}
				}
				num--;
				Size size3 = base.Size;
				int num28 = num + 1;
				if (size3.Height != this.LineHeight * num28)
				{
					Size size4 = new Size(base.Size.Width, this.LineHeight * num28);
					base.Size = size4;
				}
				base.Invalidate();
			}
		}

		public unsafe void SetItemEnable(int idx, [MarshalAs(UnmanagedType.U1)] bool enable)
		{
			int num = 0;
			if (0 < this.NumItems)
			{
				int num2 = 0;
				do
				{
					if (*(int*)(this.Items + num2 / sizeof(GToolbarItem)) == idx)
					{
						Toolbar.ToolbarItemProp toolbarItemProp = this.ItemProps[num];
						if (toolbarItemProp.Enabled != enable)
						{
							toolbarItemProp.Enabled = enable;
							if (!enable)
							{
								this.ItemProps[num].Pushed = false;
							}
							this.InvalidateItem(num);
						}
					}
					num++;
					num2 += 16;
				}
				while (num < this.NumItems);
			}
		}

		public unsafe void SetGroupEnable(int idx, [MarshalAs(UnmanagedType.U1)] bool enable)
		{
			int num = 0;
			if (0 < this.NumItems)
			{
				int num2 = 0;
				do
				{
					if (*(int*)(num2 / sizeof(GToolbarItem) + this.Items + 12 / sizeof(GToolbarItem)) == idx)
					{
						Toolbar.ToolbarItemProp toolbarItemProp = this.ItemProps[num];
						if (toolbarItemProp.Enabled != enable)
						{
							toolbarItemProp.Enabled = enable;
							if (!enable)
							{
								this.ItemProps[num].Pushed = false;
							}
							this.InvalidateItem(num);
						}
					}
					num++;
					num2 += 16;
				}
				while (num < this.NumItems);
			}
		}

		public unsafe void SetGroupPushed(int idx, [MarshalAs(UnmanagedType.U1)] bool pushed)
		{
			int num = 0;
			if (0 < this.NumItems)
			{
				int num2 = 0;
				do
				{
					if (*(int*)(num2 / sizeof(GToolbarItem) + this.Items + 12 / sizeof(GToolbarItem)) == idx)
					{
						Toolbar.ToolbarItemProp toolbarItemProp = this.ItemProps[num];
						if (toolbarItemProp.Pushed != pushed)
						{
							if (toolbarItemProp.Enabled && pushed)
							{
								toolbarItemProp.Pushed = true;
							}
							else
							{
								toolbarItemProp.Pushed = false;
							}
							this.InvalidateItem(num);
						}
					}
					num++;
					num2 += 16;
				}
				while (num < this.NumItems);
			}
		}

		public unsafe void SetItemPushed(int idx, [MarshalAs(UnmanagedType.U1)] bool pushed)
		{
			int num = 0;
			int num2 = 0;
			if (0 < this.NumItems)
			{
				int num3 = 0;
				do
				{
					GToolbarItem* ptr = num3 / sizeof(GToolbarItem) + this.Items;
					if (*(int*)ptr == idx)
					{
						num = *(int*)(ptr + 12 / sizeof(GToolbarItem));
						Toolbar.ToolbarItemProp toolbarItemProp = this.ItemProps[num2];
						if (toolbarItemProp.Pushed != pushed)
						{
							toolbarItemProp.Pushed = pushed;
							this.InvalidateItem(num2);
						}
					}
					num2++;
					num3 += 16;
				}
				while (num2 < this.NumItems);
				if (num != 0)
				{
					int num4 = 0;
					if (0 < this.NumItems)
					{
						int num5 = 0;
						do
						{
							GToolbarItem* ptr2 = num5 / sizeof(GToolbarItem) + this.Items;
							if (*(int*)(ptr2 + 12 / sizeof(GToolbarItem)) == num && *(int*)ptr2 != idx)
							{
								Toolbar.ToolbarItemProp toolbarItemProp2 = this.ItemProps[num4];
								if (toolbarItemProp2.Pushed)
								{
									toolbarItemProp2.Pushed = false;
									this.InvalidateItem(num4);
								}
							}
							num4++;
							num5 += 16;
						}
						while (num4 < this.NumItems);
					}
				}
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool GetItemPushed(int idx)
		{
			int num = 0;
			int numItems = this.NumItems;
			if (0 < numItems)
			{
				GToolbarItem* ptr = this.Items;
				while (*(int*)ptr != idx)
				{
					num++;
					ptr += 16 / sizeof(GToolbarItem);
					if (num >= numItems)
					{
						return false;
					}
				}
				return this.ItemProps[num].Pushed;
			}
			return false;
		}

		public unsafe void EmulatePushByID(int indx)
		{
			int num = -1;
			int num2 = 0;
			int numItems = this.NumItems;
			if (0 < numItems)
			{
				GToolbarItem* items = this.Items;
				int numItems2 = this.NumItems;
				do
				{
					if (*(int*)(num2 * 16 / sizeof(GToolbarItem) + items) == indx)
					{
						num = num2;
						num2 = numItems;
					}
					num2++;
				}
				while (num2 < numItems2);
				if (num >= 0 && this.ItemProps[num].Enabled)
				{
					int activeItem = this.ActiveItem;
					if (activeItem != num)
					{
						this.InvalidateItem(activeItem);
						this.ActiveItem = num;
						this.InvalidateItem(num);
					}
					this.ActivePressed = true;
					this.InvalidateItem(this.ActiveItem);
				}
			}
		}

		public unsafe void EmulateUpByID(int indx)
		{
			int num = -1;
			int num2 = 0;
			int numItems = this.NumItems;
			if (0 < numItems)
			{
				GToolbarItem* items = this.Items;
				int numItems2 = this.NumItems;
				do
				{
					if (*(int*)(num2 * 16 / sizeof(GToolbarItem) + items) == indx)
					{
						num = num2;
						num2 = numItems;
					}
					num2++;
				}
				while (num2 < numItems2);
			}
			int activeItem = this.ActiveItem;
			if (num == activeItem && activeItem >= 0 && this.ItemProps[num].Enabled)
			{
				GToolbarItem* ptr = activeItem * 16 / sizeof(GToolbarItem) + this.Items;
				this.raise_ButtonClick(*(int*)ptr, *(int*)(ptr + 12 / sizeof(GToolbarItem)));
				this.ActivePressed = false;
				this.InvalidateItem(this.ActiveItem);
				this.ActiveItem = -1;
			}
		}

		public unsafe void EmulatePush(int ordinal)
		{
			int num = -1;
			int num2 = -1;
			if (ordinal < 0)
			{
				if (this.ActiveItem < 0)
				{
					return;
				}
			}
			else
			{
				int num3 = 0;
				if (-1 < ordinal)
				{
					GToolbarItem* ptr = this.Items;
					do
					{
						int num4 = *(int*)ptr;
						if (num4 != -1 && num4 != -2)
						{
							num2 = num3;
							num++;
						}
						num3++;
						ptr += 16 / sizeof(GToolbarItem);
					}
					while (num < ordinal);
				}
				int numItems = this.NumItems;
				if (ordinal >= numItems || num2 < 0 || num2 >= numItems || !this.ItemProps[num2].Enabled)
				{
					return;
				}
				int activeItem = this.ActiveItem;
				if (activeItem != num2)
				{
					this.InvalidateItem(activeItem);
					this.ActiveItem = num2;
					this.InvalidateItem(num2);
				}
			}
			this.ActivePressed = true;
			this.InvalidateItem(this.ActiveItem);
		}

		public unsafe void EmulateUp(int ordinal)
		{
			int num = -1;
			int num2 = -1;
			if (ordinal < 0)
			{
				num2 = this.ActiveItem;
			}
			else
			{
				int num3 = 0;
				if (-1 < ordinal)
				{
					GToolbarItem* ptr = this.Items;
					do
					{
						int num4 = *(int*)ptr;
						if (num4 != -1 && num4 != -2)
						{
							num2 = num3;
							num++;
						}
						num3++;
						ptr += 16 / sizeof(GToolbarItem);
					}
					while (num < ordinal);
				}
			}
			int activeItem = this.ActiveItem;
			if (num2 == activeItem && activeItem >= 0 && this.ItemProps[num2].Enabled)
			{
				GToolbarItem* ptr2 = activeItem * 16 / sizeof(GToolbarItem) + this.Items;
				this.raise_ButtonClick(*(int*)ptr2, *(int*)(ptr2 + 12 / sizeof(GToolbarItem)));
				this.ActivePressed = false;
				this.InvalidateItem(this.ActiveItem);
				this.SelectedItem = this.ActiveItem;
				this.ActiveItem = -1;
			}
		}

		public unsafe int NextTool()
		{
			int num = this.SelectedItem + 1;
			int num2 = 0;
			int numItems = this.NumItems;
			if (0 < numItems)
			{
				GToolbarItem* items = this.Items;
				do
				{
					if (num >= numItems)
					{
						num = 0;
					}
					if (*(int*)(num * 16 / sizeof(GToolbarItem) + items) >= 0)
					{
						goto IL_42;
					}
					num++;
					num2++;
				}
				while (num2 < this.NumItems);
				return -1;
				IL_42:
				int activeItem = this.ActiveItem;
				if (activeItem != num && num >= 0)
				{
					this.InvalidateItem(activeItem);
					this.ActiveItem = num;
					this.InvalidateItem(num);
				}
				this.SelectedItem = num;
				return *(int*)(num * 16 / sizeof(GToolbarItem) + this.Items + 12 / sizeof(GToolbarItem));
			}
			return -1;
		}

		public unsafe int PrevTool()
		{
			int num = this.SelectedItem - 1;
			int num2 = 0;
			int numItems = this.NumItems;
			if (0 < numItems)
			{
				GToolbarItem* items = this.Items;
				do
				{
					if (num < 0)
					{
						num = numItems - 1;
					}
					if (*(int*)(num * 16 / sizeof(GToolbarItem) + items) >= 0)
					{
						goto IL_44;
					}
					num--;
					num2++;
				}
				while (num2 < this.NumItems);
				return -1;
				IL_44:
				int activeItem = this.ActiveItem;
				if (activeItem != num && num >= 0)
				{
					this.InvalidateItem(activeItem);
					this.ActiveItem = num;
					this.InvalidateItem(num);
				}
				this.SelectedItem = num;
				return *(int*)(num * 16 / sizeof(GToolbarItem) + this.Items + 12 / sizeof(GToolbarItem));
			}
			return -1;
		}

		public unsafe int NextGroup()
		{
			int num = this.SelectedItem + 1;
			bool flag = false;
			int num2 = 0;
			int numItems = this.NumItems;
			if (0 < numItems)
			{
				GToolbarItem* items = this.Items;
				do
				{
					if (num >= numItems)
					{
						num = 0;
						flag = true;
					}
					int num3 = *(int*)(num * 16 / sizeof(GToolbarItem) + items);
					if (num3 >= 0 && flag)
					{
						goto IL_5A;
					}
					if (num3 < 0)
					{
						flag = true;
					}
					num++;
					num2++;
				}
				while (num2 < this.NumItems);
				return -1;
				IL_5A:
				int activeItem = this.ActiveItem;
				if (activeItem != num && num >= 0)
				{
					this.InvalidateItem(activeItem);
					this.ActiveItem = num;
					this.InvalidateItem(num);
				}
				this.SelectedItem = num;
				return *(int*)(num * 16 / sizeof(GToolbarItem) + this.Items + 12 / sizeof(GToolbarItem));
			}
			return -1;
		}

		public unsafe int PrevGroup()
		{
			int num = this.SelectedItem - 1;
			bool flag = false;
			int num2 = 0;
			int num3 = this.NumItems - 1;
			if (0 < num3)
			{
				GToolbarItem* items = this.Items;
				do
				{
					if (num < 0)
					{
						num = num3;
						flag = true;
					}
					int num4 = *(int*)(num * 16 / sizeof(GToolbarItem) + items);
					if (num4 >= 0 && flag)
					{
						goto IL_5E;
					}
					if (num4 < 0)
					{
						flag = true;
					}
					num--;
					num2++;
				}
				while (num2 < this.NumItems - 1);
				return -1;
				IL_5E:
				int activeItem = this.ActiveItem;
				if (activeItem != num && num >= 0)
				{
					this.InvalidateItem(activeItem);
					this.ActiveItem = num;
					this.InvalidateItem(num);
				}
				this.SelectedItem = num;
				return *(int*)(num * 16 / sizeof(GToolbarItem) + this.Items + 12 / sizeof(GToolbarItem));
			}
			return -1;
		}

		public unsafe void SetSelectedItem(int idx)
		{
			int num = 0;
			if (0 < this.NumItems)
			{
				GToolbarItem* ptr = this.Items;
				do
				{
					if (*(int*)ptr == idx)
					{
						this.SelectedItem = num;
					}
					num++;
					ptr += 16 / sizeof(GToolbarItem);
				}
				while (num < this.NumItems);
			}
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing)
			{
				Container container = this.components;
				if (container != null)
				{
					container.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.Font = new Font("Tahoma", 8.25f);
			Size size = new Size(300, 300);
			base.Size = size;
		}

		protected unsafe override void OnPaint(PaintEventArgs e)
		{
			if (this.NumItems != 0)
			{
				Size size = base.Size;
				Size size2 = base.Size;
				e.Graphics.FillRectangle(this.NormalBackgroundBrush, 0, 0, size2.Width, size.Height);
				int num = 0;
				if (0 < this.NumItems)
				{
					int num2 = 0;
					do
					{
						Toolbar.ToolbarItemProp[] itemProps = this.ItemProps;
						Rectangle itemBounds = itemProps[num].itemBounds;
						int num3 = *(int*)(this.Items + num2 / sizeof(GToolbarItem));
						if (num3 == -1)
						{
							if (itemBounds.Width != 0)
							{
								e.Graphics.FillRectangle(this.ControlDark, itemBounds.X + 2, itemBounds.Y + 2, 1, this.IconSize + 2);
								e.Graphics.FillRectangle(this.ControlLight, itemBounds.X + 3, itemBounds.Y + 2, 1, this.IconSize + 2);
							}
						}
						else if (num3 != -2)
						{
							if ((num == this.ActiveItem && this.ActivePressed) || itemProps[num].Pushed)
							{
								e.Graphics.FillRectangle(this.PushedBackgroundBrush, itemBounds.X + 1, itemBounds.Y + 1, itemBounds.Width - 2, itemBounds.Height - 2);
							}
							if (num == this.ActiveItem)
							{
								e.Graphics.FillRectangle(this.SelectionBrush, itemBounds.X + 1, itemBounds.Y + 1, itemBounds.Width - 2, 1);
								e.Graphics.FillRectangle(this.SelectionBrush, itemBounds.X + 1, itemBounds.Y + 1, 1, itemBounds.Height - 2);
								int num4 = itemBounds.Y - 2;
								e.Graphics.FillRectangle(this.SelectionBrush, itemBounds.X + 1, itemBounds.Height + num4, itemBounds.Width - 2, 1);
								int num5 = itemBounds.X - 2;
								e.Graphics.FillRectangle(this.SelectionBrush, itemBounds.Width + num5, itemBounds.Y + 1, 1, itemBounds.Height - 2);
							}
							if (!this.ItemProps[num].Enabled)
							{
								int iconSize = this.IconSize;
								Graphics arg_248_0 = e.Graphics;
								Image arg_248_1 = this.ItemProps[num].itemDisabledImage;
								int arg_248_2 = itemBounds.X + 3;
								int arg_248_3 = itemBounds.Y + 3;
								int expr_247 = iconSize;
								arg_248_0.DrawImage(arg_248_1, arg_248_2, arg_248_3, expr_247, expr_247);
							}
							else if (num == this.ActiveItem && this.ActivePressed)
							{
								int iconSize2 = this.IconSize;
								Graphics arg_293_0 = e.Graphics;
								Image arg_293_1 = this.ItemProps[num].itemImage;
								int arg_293_2 = itemBounds.X + 4;
								int arg_293_3 = itemBounds.Y + 4;
								int expr_292 = iconSize2;
								arg_293_0.DrawImage(arg_293_1, arg_293_2, arg_293_3, expr_292, expr_292);
							}
							else
							{
								int iconSize3 = this.IconSize;
								Graphics arg_2CA_0 = e.Graphics;
								Image arg_2CA_1 = this.ItemProps[num].itemImage;
								int arg_2CA_2 = itemBounds.X + 3;
								int arg_2CA_3 = itemBounds.Y + 3;
								int expr_2C9 = iconSize3;
								arg_2CA_0.DrawImage(arg_2CA_1, arg_2CA_2, arg_2CA_3, expr_2C9, expr_2C9);
							}
						}
						num++;
						num2 += 16;
					}
					while (num < this.NumItems);
				}
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			this.RearrangeToolbar();
			this.raise_Rearranged(this, base.Height);
		}

		protected unsafe override void OnMouseMove(MouseEventArgs e)
		{
			int num = -1;
			int num2 = 0;
			if (0 < this.NumItems)
			{
				int num3 = 0;
				do
				{
					if (*(int*)(this.Items + num3 / sizeof(GToolbarItem)) != -1)
					{
						Toolbar.ToolbarItemProp[] itemProps = this.ItemProps;
						if (itemProps[num2].Enabled)
						{
							Rectangle itemBounds = itemProps[num2].itemBounds;
							if (e.X >= itemBounds.Left && e.X < itemBounds.Right && e.Y >= itemBounds.Top && e.Y < itemBounds.Bottom)
							{
								goto IL_91;
							}
						}
					}
					num2++;
					num3 += 16;
				}
				while (num2 < this.NumItems);
				goto IL_93;
				IL_91:
				num = num2;
			}
			IL_93:
			int activeItem = this.ActiveItem;
			if (activeItem != num)
			{
				this.InvalidateItem(activeItem);
				this.ActiveItem = num;
				this.InvalidateItem(num);
				ToolTip tooltip = this.Tooltip;
				if (tooltip != null)
				{
					if (this.ActiveItem >= 0)
					{
						this.Tooltip.SetToolTip(this, new string(*(int*)(num2 * 16 / sizeof(GToolbarItem) + this.Items + 4 / sizeof(GToolbarItem))));
					}
					else
					{
						tooltip.SetToolTip(this, "");
					}
				}
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			int activeItem = this.ActiveItem;
			if (activeItem >= 0)
			{
				this.InvalidateItem(activeItem);
				this.ActiveItem = -1;
			}
			this.Tooltip.SetToolTip(this, "");
			this.ActivePressed = false;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			this.ActivePressed = true;
			this.InvalidateItem(this.ActiveItem);
		}

		protected unsafe override void OnMouseUp(MouseEventArgs e)
		{
			if (this.ActivePressed)
			{
				int activeItem = this.ActiveItem;
				if (activeItem >= 0)
				{
					GToolbarItem* ptr = activeItem * 16 / sizeof(GToolbarItem) + this.Items;
					this.raise_ButtonClick(*(int*)ptr, *(int*)(ptr + 12 / sizeof(GToolbarItem)));
				}
			}
			int activeItem2 = this.ActiveItem;
			this.SelectedItem = activeItem2;
			this.ActivePressed = false;
			this.InvalidateItem(activeItem2);
		}

		private void InvalidateItem(int idx)
		{
			if (idx >= 0 && idx < this.NumItems)
			{
				base.Invalidate(this.ItemProps[idx].itemBounds);
			}
		}

		protected void raise_ButtonClick(int i1, int i2)
		{
			Toolbar.__Delegate_ButtonClick buttonClick = this.ButtonClick;
			if (buttonClick != null)
			{
				buttonClick(i1, i2);
			}
		}

		protected void raise_Rearranged(object i1, int i2)
		{
			ToolRearranged rearranged = this.Rearranged;
			if (rearranged != null)
			{
				rearranged(i1, i2);
			}
		}
	}
}
