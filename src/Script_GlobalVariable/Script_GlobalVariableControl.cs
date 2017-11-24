using Script_GlobalVariable_Header;
using Script_GlobalVariable_ListItem;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Script_GlobalVariable
{
	public class Script_GlobalVariableControl : UserControl
	{
		public enum eSortMode
		{
			SORT_Descending = 2,
			SORT_Ascending = 1,
			SORT_Unsorted = 0
		}

		private enum eMode
		{
			MODE_ColumnResize = 1,
			MODE_Normal = 0
		}

		private Script_GlobalVariableControl.eMode mMode;

		private int mHeaderHeight;

		private int mRowHeight;

		private bool mDrawGrid;

		private Script_GlobalVariableControl_Header[] mColumnHeaders;

		private Script_GlobalVariableControl_ListItem[] mItems;

		private Script_GlobalVariableControl.eSortMode mSortMode;

		private int mSortColumn;

		private int[] mSortIndices;

		private int mFirstDisplayed;

		private int mSelectedIndex;

		private int mMaxRows;

		private int mClickedIndex;

		private int mClickedColumnIndex;

		private int mColumnToResize;

		private int mColumnResizeMouseX;

		private int mFrameSize;

		private Pen Pen_Dark;

		private Pen Pen_DarkDark;

		private Pen Pen_Light;

		private Pen Pen_LightLight;

		private new Font Font;

		private Brush Brush_Selection;

		private Brush Brush_Selection_Focus;

		private Brush Brush_Header;

		private Brush Brush_Header_Focus;

		private Brush Brush_Header_Text;

		private Brush Brush_Header_Text_Focus;

		private Brush Brush_Text;

		private Brush Brush_Text_Focus;

		private Brush Brush_Text_Highlight;

		private Brush Brush_Text_Highlight_Focus;

		private VScrollBar VertScrollBar;

		private Container components;

		public event EventHandler SortModeChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.SortModeChanged = Delegate.Combine(this.SortModeChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.SortModeChanged = Delegate.Remove(this.SortModeChanged, value);
			}
		}

		public event EventHandler ItemDoubleClicked
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.ItemDoubleClicked = Delegate.Combine(this.ItemDoubleClicked, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.ItemDoubleClicked = Delegate.Remove(this.ItemDoubleClicked, value);
			}
		}

		public event EventHandler ItemClicked
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.ItemClicked = Delegate.Combine(this.ItemClicked, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.ItemClicked = Delegate.Remove(this.ItemClicked, value);
			}
		}

		public event EventHandler DragStarted
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.DragStarted = Delegate.Combine(this.DragStarted, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.DragStarted = Delegate.Remove(this.DragStarted, value);
			}
		}

		public event EventHandler SelectedIndexChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.SelectedIndexChanged = Delegate.Combine(this.SelectedIndexChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.SelectedIndexChanged = Delegate.Remove(this.SelectedIndexChanged, value);
			}
		}

		public int ClickedColumnIndex
		{
			get
			{
				return this.mClickedColumnIndex;
			}
		}

		public int ClickedIndex
		{
			get
			{
				return this.mClickedIndex;
			}
		}

		public int SelectedIndex
		{
			get
			{
				int num = this.mSelectedIndex;
				if (num == -1)
				{
					return -1;
				}
				return this.mSortIndices[num];
			}
			set
			{
				int num = 0;
				int[] array = this.mSortIndices;
				int num2 = array.Length;
				if (0 < num2)
				{
					while (array[num] != value)
					{
						num++;
						if (num >= this.mSortIndices.Length)
						{
							break;
						}
					}
				}
				if (num == num2)
				{
					num = 0;
				}
				int num3 = this.mItems.Length;
				if (num3 == 0)
				{
					num = -1;
				}
				else if (num < 0)
				{
					num = 0;
				}
				else if (num >= num3)
				{
					num = num3 - 1;
				}
				if (this.mFirstDisplayed > num)
				{
					if (num != -1 && this.mMaxRows < num2)
					{
						this.mFirstDisplayed = num;
					}
					else
					{
						this.mFirstDisplayed = 0;
					}
				}
				int num4 = this.mMaxRows;
				if (this.mFirstDisplayed + num4 <= num)
				{
					this.mFirstDisplayed = num - num4 + 1;
				}
				if (this.mSelectedIndex != num)
				{
					this.mSelectedIndex = num;
					this.UpdateScrollbar();
					base.Invalidate();
					this.raise_SelectedIndexChanged(this, new EventArgs());
				}
			}
		}

		public int RealSelectedIndex
		{
			get
			{
				return this.mSelectedIndex;
			}
			set
			{
				int num = this.mItems.Length;
				if (num == 0)
				{
					value = -1;
				}
				else if (value < 0)
				{
					value = 0;
				}
				else if (value >= num)
				{
					value = num - 1;
				}
				if (this.mFirstDisplayed > value)
				{
					if (value != -1 && this.mMaxRows < this.mSortIndices.Length)
					{
						this.mFirstDisplayed = value;
					}
					else
					{
						this.mFirstDisplayed = 0;
					}
				}
				int num2 = this.mMaxRows;
				if (this.mFirstDisplayed + num2 <= value)
				{
					this.mFirstDisplayed = value - num2 + 1;
				}
				if (this.mSelectedIndex != value)
				{
					this.mSelectedIndex = value;
					base.Invalidate();
					this.UpdateScrollbar();
					this.raise_SelectedIndexChanged(this, new EventArgs());
				}
			}
		}

		public bool DrawGrid
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.mDrawGrid;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.mDrawGrid = value;
				base.Invalidate();
			}
		}

		public int HeaderHeight
		{
			get
			{
				return this.mHeaderHeight;
			}
			set
			{
				this.mHeaderHeight = value;
				if (value < 10)
				{
					this.mHeaderHeight = 10;
				}
				base.Invalidate();
			}
		}

		public int RowHeight
		{
			get
			{
				return this.mRowHeight;
			}
			set
			{
				this.mRowHeight = value;
				if (value < 10)
				{
					this.mRowHeight = 10;
				}
				base.Invalidate();
			}
		}

		public int[] SortIndices
		{
			get
			{
				return this.mSortIndices;
			}
		}

		public Script_GlobalVariableControl_ListItem[] Items
		{
			get
			{
				return this.mItems;
			}
			set
			{
				int selectedIndex = this.SelectedIndex;
				this.mItems = value;
				this.mSortIndices = new int[value.Length];
				this.Sort(false);
				int num = this.RealSelectedIndex;
				int num2 = this.mItems.Length;
				if (num2 == 0)
				{
					num = -1;
				}
				else if (num >= num2)
				{
					num = num2 - 1;
				}
				else if (num == -1)
				{
					num = 0;
				}
				if (selectedIndex != -1)
				{
					int num3 = 0;
					int[] array = this.mSortIndices;
					int num4 = array.Length;
					if (0 < num4)
					{
						while (array[num3] != selectedIndex)
						{
							num3++;
							if (num3 >= this.mSortIndices.Length)
							{
								break;
							}
						}
					}
					if (num3 != num4)
					{
						num = num3;
					}
				}
				int num5;
				if (this.mSelectedIndex == num && (num == -1 || this.mSortIndices[num] == selectedIndex))
				{
					num5 = 0;
				}
				else
				{
					num5 = 1;
				}
				bool flag = (byte)num5 != 0;
				this.mSelectedIndex = num;
				if (this.mFirstDisplayed > num)
				{
					if (num != -1 && this.mMaxRows < this.mSortIndices.Length)
					{
						this.mFirstDisplayed = num;
					}
					else
					{
						this.mFirstDisplayed = 0;
					}
				}
				base.Invalidate();
				this.UpdateScrollbar();
				if (flag)
				{
					this.raise_SelectedIndexChanged(this, new EventArgs());
				}
			}
		}

		public Script_GlobalVariableControl_Header[] ColumnHeaders
		{
			get
			{
				return this.mColumnHeaders;
			}
			set
			{
				this.mColumnHeaders = value;
				base.Invalidate();
			}
		}

		public Script_GlobalVariableControl()
		{
			this.SelectedIndexChanged = null;
			this.DragStarted = null;
			this.ItemClicked = null;
			this.ItemDoubleClicked = null;
			this.SortModeChanged = null;
			this.InitializeComponent();
			this.mColumnHeaders = new Script_GlobalVariableControl_Header[0];
			this.mItems = new Script_GlobalVariableControl_ListItem[0];
			this.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Unsorted;
			this.mSortColumn = 0;
			this.mSortIndices = new int[0];
			this.mHeaderHeight = 18;
			this.mRowHeight = 14;
			this.mFirstDisplayed = 0;
			this.mSelectedIndex = -1;
			this.mDrawGrid = false;
			this.mFrameSize = 2;
			this.mMaxRows = 0;
			this.mMode = Script_GlobalVariableControl.eMode.MODE_Normal;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.UpdateStyles();
			this.Pen_Dark = SystemPens.ControlDark;
			this.Pen_DarkDark = SystemPens.ControlDarkDark;
			this.Pen_Light = SystemPens.ControlLight;
			this.Pen_LightLight = SystemPens.ControlLightLight;
			Color color = Color.FromKnownColor(KnownColor.LightGray);
			this.Brush_Header = new SolidBrush(color);
			Color color2 = Color.FromKnownColor(KnownColor.MediumBlue);
			this.Brush_Header_Focus = new SolidBrush(color2);
			Color color3 = Color.FromKnownColor(KnownColor.ControlText);
			this.Brush_Header_Text = new SolidBrush(color3);
			Color color4 = Color.FromKnownColor(KnownColor.HighlightText);
			this.Brush_Header_Text_Focus = new SolidBrush(color4);
			Color color5 = Color.FromKnownColor(KnownColor.DarkGray);
			this.Brush_Selection = new SolidBrush(color5);
			this.Brush_Selection_Focus = SystemBrushes.Highlight;
			Color color6 = Color.FromKnownColor(KnownColor.ControlText);
			this.Brush_Text = new SolidBrush(color6);
			Color color7 = Color.FromKnownColor(KnownColor.ControlText);
			this.Brush_Text_Focus = new SolidBrush(color7);
			Color color8 = Color.FromKnownColor(KnownColor.HighlightText);
			this.Brush_Text_Highlight = new SolidBrush(color8);
			Color color9 = Color.FromKnownColor(KnownColor.HighlightText);
			this.Brush_Text_Highlight_Focus = new SolidBrush(color9);
			this.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
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
			this.VertScrollBar = new VScrollBar();
			base.SuspendLayout();
			this.VertScrollBar.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
			Point location = new Point(212, 0);
			this.VertScrollBar.Location = location;
			this.VertScrollBar.Name = "VertScrollBar";
			Size size = new Size(16, 176);
			this.VertScrollBar.Size = size;
			this.VertScrollBar.TabIndex = 0;
			this.VertScrollBar.ValueChanged += new EventHandler(this.VertScrollBar_ValueChanged);
			this.VertScrollBar.Scroll += new ScrollEventHandler(this.VertScrollBar_Scroll);
			Color window = SystemColors.Window;
			this.BackColor = window;
			base.Controls.Add(this.VertScrollBar);
			base.Name = "Script_GlobalVariableControl";
			Size size2 = new Size(228, 176);
			base.Size = size2;
			base.SizeChanged += new EventHandler(this.Script_GlobalVariableControl_Update);
			base.Enter += new EventHandler(this.Script_GlobalVariableControl_Update);
			base.MouseUp += new MouseEventHandler(this.Script_GlobalVariableControl_MouseUp);
			base.Paint += new PaintEventHandler(this.Script_GlobalVariableControl_Paint);
			base.KeyDown += new KeyEventHandler(this.Script_GlobalVariableControl_KeyDown);
			base.Leave += new EventHandler(this.Script_GlobalVariableControl_Update);
			base.MouseMove += new MouseEventHandler(this.Script_GlobalVariableControl_MouseMove);
			base.MouseWheel += new MouseEventHandler(this.Script_GlobalVariableControl_MouseWheel);
			base.MouseDown += new MouseEventHandler(this.Script_GlobalVariableControl_MouseDown);
			base.ResumeLayout(false);
		}

		public unsafe void GetClickedRect(Rectangle* rect)
		{
			rect.Y = (this.mClickedIndex - this.mFirstDisplayed) * this.mRowHeight + this.mHeaderHeight + this.mFrameSize;
			rect.Height = this.mRowHeight;
			rect.X = this.mFrameSize;
			int num = 0;
			if (0 < this.mClickedColumnIndex)
			{
				do
				{
					rect.X = this.mColumnHeaders[num].Width + rect.X;
					num++;
				}
				while (num < this.mClickedColumnIndex);
			}
			rect.Width = this.mColumnHeaders[this.mClickedColumnIndex].Width;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public bool IsInOriginalOrder()
		{
			if (this.mSortMode == Script_GlobalVariableControl.eSortMode.SORT_Unsorted)
			{
				return true;
			}
			int num = 0;
			int[] array = this.mSortIndices;
			int num2 = array.Length;
			if (0 < num2)
			{
				while (array[num] == num)
				{
					num++;
					if (num >= num2)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		public void ForceUnsorted()
		{
			this.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Unsorted;
			this.Sort(true);
		}

		[return: MarshalAs(UnmanagedType.U1)]
		protected override bool IsInputKey(Keys key)
		{
			return key >= Keys.Left && key <= Keys.Down;
		}

		private void Script_GlobalVariableControl_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle clientRectangle = base.ClientRectangle;
			clientRectangle.Width -= this.VertScrollBar.Width;
			clientRectangle.X += this.mFrameSize;
			clientRectangle.Y += this.mFrameSize;
			clientRectangle.Width -= this.mFrameSize << 1;
			clientRectangle.Height -= this.mFrameSize << 1;
			int width = clientRectangle.Width;
			clientRectangle.Width = width - 1;
			int height = clientRectangle.Height;
			clientRectangle.Height = height - 1;
			Brush brush;
			Brush brush2;
			Brush brush3;
			Brush brush4;
			Brush brush5;
			if (this.Focused)
			{
				brush = this.Brush_Selection_Focus;
				brush2 = this.Brush_Header_Focus;
				brush3 = this.Brush_Header_Text_Focus;
				brush4 = this.Brush_Text_Focus;
				brush5 = this.Brush_Text_Highlight_Focus;
			}
			else
			{
				brush = this.Brush_Selection;
				brush2 = this.Brush_Header;
				brush3 = this.Brush_Header_Text;
				brush4 = this.Brush_Text;
				brush5 = this.Brush_Text_Highlight;
			}
			if (this.Items.Length != 0)
			{
				int num = (this.RealSelectedIndex - this.mFirstDisplayed) * this.mRowHeight;
				int num2 = clientRectangle.Top + this.mHeaderHeight + num;
				if (num2 < clientRectangle.Bottom)
				{
					graphics.FillRectangle(brush, clientRectangle.Left, num2, clientRectangle.Width, this.mRowHeight);
				}
			}
			graphics.FillRectangle(brush2, clientRectangle.Left, clientRectangle.Top, clientRectangle.Width, this.mHeaderHeight);
			int num3 = clientRectangle.Left;
			int top = clientRectangle.Top;
			int num4 = this.mHeaderHeight + top - 1;
			StringFormat format = new StringFormat();
			int num5 = 0;
			if (0 < this.mColumnHeaders.Length)
			{
				do
				{
					if (num3 < clientRectangle.Right)
					{
						Script_GlobalVariableControl_Header[] array = this.mColumnHeaders;
						int num6;
						if (num5 + 1 == array.Length)
						{
							num6 = clientRectangle.Right - num3;
						}
						else
						{
							num6 = array[num5].Width;
						}
						int num7 = num3 + num6 - 1;
						graphics.DrawLine(this.Pen_LightLight, num3, top, num7, top);
						graphics.DrawLine(this.Pen_LightLight, num3, top, num3, num4);
						graphics.DrawLine(this.Pen_Dark, num3 + 1, num4, num7, num4);
						graphics.DrawLine(this.Pen_Dark, num7, top + 1, num7, num4);
						if (this.mColumnHeaders[num5].Text != null)
						{
							RectangleF layoutRectangle = new RectangleF((float)(num3 + 2), (float)((this.mHeaderHeight - this.Font.Height) / 2 + top), (float)(num6 - 4), (float)this.Font.Height);
							graphics.DrawString(this.mColumnHeaders[num5].Text, this.Font, brush3, layoutRectangle, format);
						}
						Script_GlobalVariableControl.eSortMode eSortMode = this.mSortMode;
						if (eSortMode != Script_GlobalVariableControl.eSortMode.SORT_Unsorted && this.mSortColumn == num5)
						{
							int y;
							if (eSortMode == Script_GlobalVariableControl.eSortMode.SORT_Ascending)
							{
								y = num4 - 5;
							}
							else
							{
								y = top + 5;
							}
							int x = (num7 * 2 - 14) / 2;
							int y2 = (num4 + top) / 2;
							graphics.DrawLine(this.Pen_LightLight, num7 - 10, y2, x, y);
							graphics.DrawLine(this.Pen_LightLight, num7 - 4, y2, x, y);
						}
						num3 = num7 + 1;
					}
					num5++;
				}
				while (num5 < this.mColumnHeaders.Length);
			}
			num4++;
			if (this.mDrawGrid)
			{
				int num8 = clientRectangle.Left;
				int num9 = 0;
				if (1 < this.mColumnHeaders.Length)
				{
					do
					{
						if (num8 < clientRectangle.Right)
						{
							num8 = this.mColumnHeaders[num9].Width + num8;
							graphics.DrawLine(this.Pen_Light, num8, num4, num8, clientRectangle.Bottom);
						}
						num9++;
					}
					while (num9 + 1 < this.mColumnHeaders.Length);
				}
				int num10 = (clientRectangle.Height - this.mHeaderHeight) / this.mRowHeight;
				int num11 = clientRectangle.Top + this.mHeaderHeight;
				if (0 < num10)
				{
					uint num12 = (uint)num10;
					do
					{
						num11 = this.RowHeight + num11;
						graphics.DrawLine(this.Pen_Light, clientRectangle.Left, num11, clientRectangle.Right, num11);
						num12 -= 1u;
					}
					while (num12 > 0u);
				}
			}
			if (this.Items.Length != 0)
			{
				int num13 = this.mFirstDisplayed;
				int i = clientRectangle.Top + this.mHeaderHeight;
				if (num13 < this.Items.Length)
				{
					while (i < clientRectangle.Bottom)
					{
						Script_GlobalVariableControl_ListItem script_GlobalVariableControl_ListItem = this.mItems[this.mSortIndices[num13]];
						int num14 = clientRectangle.Left;
						int j = 0;
						if (0 < this.mColumnHeaders.Length)
						{
							while (j < script_GlobalVariableControl_ListItem.SubItems.Length)
							{
								if (script_GlobalVariableControl_ListItem.SubItems[j].Text != null && num14 < clientRectangle.Right)
								{
									Script_GlobalVariableControl_Header[] array2 = this.mColumnHeaders;
									int num15;
									if (j + 1 == array2.Length)
									{
										num15 = clientRectangle.Right - num14;
									}
									else
									{
										num15 = array2[j].Width;
									}
									Brush brush6;
									if (num13 == this.RealSelectedIndex)
									{
										brush6 = brush5;
									}
									else
									{
										brush6 = brush4;
									}
									RectangleF layoutRectangle2 = new RectangleF((float)(num14 + 2), (float)((this.mRowHeight - this.Font.Height) / 2 + i), (float)(num15 - 4), (float)this.Font.Height);
									graphics.DrawString(script_GlobalVariableControl_ListItem.SubItems[j].Text, this.Font, brush6, layoutRectangle2, format);
								}
								Script_GlobalVariableControl_Header[] array3 = this.mColumnHeaders;
								Script_GlobalVariableControl_Header arg_534_0 = array3[j];
								j++;
								num14 = arg_534_0.Width + num14;
								if (j >= array3.Length)
								{
									break;
								}
							}
						}
						i = this.mRowHeight + i;
						num13++;
						if (num13 >= this.Items.Length)
						{
							break;
						}
					}
				}
			}
			clientRectangle.X -= this.mFrameSize;
			clientRectangle.Y -= this.mFrameSize;
			clientRectangle.Width = this.mFrameSize * 2 + clientRectangle.Width;
			clientRectangle.Height = this.mFrameSize * 2 + clientRectangle.Height;
			graphics.DrawLine(this.Pen_Dark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Right, clientRectangle.Top);
			graphics.DrawLine(this.Pen_DarkDark, clientRectangle.Left, clientRectangle.Top + 1, clientRectangle.Right - 1, clientRectangle.Top + 1);
			graphics.DrawLine(this.Pen_Dark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Left, clientRectangle.Bottom);
			graphics.DrawLine(this.Pen_DarkDark, clientRectangle.Left + 1, clientRectangle.Top, clientRectangle.Left + 1, clientRectangle.Bottom - 1);
			graphics.DrawLine(this.Pen_LightLight, clientRectangle.Left + 1, clientRectangle.Bottom, clientRectangle.Right - 1, clientRectangle.Bottom);
			graphics.DrawLine(this.Pen_Light, clientRectangle.Left + 2, clientRectangle.Bottom - 1, clientRectangle.Right - 1, clientRectangle.Bottom - 1);
			graphics.DrawLine(this.Pen_LightLight, clientRectangle.Right, clientRectangle.Top + 1, clientRectangle.Right, clientRectangle.Bottom);
			graphics.DrawLine(this.Pen_Light, clientRectangle.Right - 1, clientRectangle.Top + 2, clientRectangle.Right - 1, clientRectangle.Bottom);
		}

		private void Script_GlobalVariableControl_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.RealSelectedIndex != -1)
			{
				switch (e.KeyCode)
				{
				case Keys.Prior:
					if (this.RealSelectedIndex > 0)
					{
						int num = this.mMaxRows;
						if (this.RealSelectedIndex >= num)
						{
							int num2 = this.mSelectedIndex - num;
							if (this.mFirstDisplayed > num2)
							{
								this.mFirstDisplayed = num2;
							}
							this.RealSelectedIndex = num2;
						}
						else
						{
							this.mFirstDisplayed = 0;
							this.RealSelectedIndex = 0;
						}
					}
					e.Handled = true;
					break;
				case Keys.Next:
					if (this.RealSelectedIndex + 1 < this.Items.Length)
					{
						int num3 = this.mMaxRows;
						int num4;
						if (num3 + this.RealSelectedIndex + 1 < this.Items.Length)
						{
							num4 = this.RealSelectedIndex + num3;
						}
						else
						{
							num4 = this.Items.Length - 1;
						}
						if (num4 - this.mFirstDisplayed >= num3)
						{
							this.mFirstDisplayed = num4 - num3 + 1;
						}
						this.RealSelectedIndex = num4;
					}
					e.Handled = true;
					break;
				case Keys.End:
					if (this.RealSelectedIndex + 1 < this.Items.Length)
					{
						int num5 = this.Items.Length - 1;
						int num6 = this.mMaxRows;
						if (num5 - this.mFirstDisplayed >= num6)
						{
							this.mFirstDisplayed = num5 - num6 + 1;
						}
						this.RealSelectedIndex = num5;
					}
					e.Handled = true;
					break;
				case Keys.Home:
					if (this.RealSelectedIndex > 0)
					{
						this.mFirstDisplayed = 0;
						this.RealSelectedIndex = 0;
					}
					e.Handled = true;
					break;
				case Keys.Up:
					if (this.RealSelectedIndex > 0)
					{
						int num7 = this.mSelectedIndex - 1;
						if (this.mFirstDisplayed > num7)
						{
							this.mFirstDisplayed = num7;
						}
						this.RealSelectedIndex = num7;
					}
					e.Handled = true;
					break;
				case Keys.Down:
					if (this.RealSelectedIndex + 1 < this.Items.Length)
					{
						int num8 = this.mSelectedIndex + 1;
						int num9 = this.mFirstDisplayed;
						if (num8 - num9 == this.mMaxRows)
						{
							this.mFirstDisplayed = num9 + 1;
						}
						this.RealSelectedIndex = num8;
					}
					e.Handled = true;
					break;
				}
			}
		}

		private void Script_GlobalVariableControl_Update(object sender, EventArgs e)
		{
			if (base.ClientRectangle.Height > this.mFrameSize * 2 + this.mHeaderHeight)
			{
				int num = (base.ClientRectangle.Height - (this.mFrameSize << 1) - this.mHeaderHeight) / this.mRowHeight;
				this.mMaxRows = num;
				int realSelectedIndex = this.RealSelectedIndex;
				if (realSelectedIndex != -1)
				{
					int num2 = this.mItems.Length;
					if (num >= num2)
					{
						this.mFirstDisplayed = 0;
					}
					else
					{
						int num3 = num + this.mFirstDisplayed;
						if (num3 <= realSelectedIndex)
						{
							this.mFirstDisplayed = realSelectedIndex - num + 1;
						}
						else if (num3 > num2)
						{
							this.mFirstDisplayed = num2 - num;
						}
					}
				}
				int num4 = 0;
				int num5 = 0;
				Script_GlobalVariableControl_Header[] array = this.mColumnHeaders;
				if (0 < array.Length)
				{
					int num6 = this.mColumnHeaders.Length;
					do
					{
						num4 = array[num5].Width + num4;
						num5++;
					}
					while (num5 < num6);
				}
				num4 = base.ClientRectangle.Width - num4 - this.VertScrollBar.Width;
				if (num4 != 0)
				{
					Script_GlobalVariableControl_Header script_GlobalVariableControl_Header = this.mColumnHeaders[0];
					num4 = script_GlobalVariableControl_Header.Width + num4;
					if (num4 < 40)
					{
						num4 = 40;
					}
					script_GlobalVariableControl_Header.Width = num4;
				}
			}
			else
			{
				this.mMaxRows = 0;
				this.mFirstDisplayed = 0;
			}
			this.UpdateScrollbar();
			base.Invalidate();
		}

		private void Script_GlobalVariableControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.mColumnHeaders.Length != 0 && e.Button == MouseButtons.Left)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.Width -= this.VertScrollBar.Width;
				clientRectangle.X += this.mFrameSize;
				clientRectangle.Y += this.mFrameSize;
				clientRectangle.Width -= this.mFrameSize << 1;
				clientRectangle.Height -= this.mFrameSize << 1;
				int num = e.X;
				int y = e.Y;
				if (clientRectangle.Contains(num, y))
				{
					num -= this.mFrameSize;
					int num2 = 0;
					Script_GlobalVariableControl_Header[] array = this.mColumnHeaders;
					int num3 = array.Length;
					if (0 < num3)
					{
						do
						{
							Script_GlobalVariableControl_Header script_GlobalVariableControl_Header = array[num2];
							if (num < script_GlobalVariableControl_Header.Width)
							{
								break;
							}
							Script_GlobalVariableControl_Header script_GlobalVariableControl_Header2 = script_GlobalVariableControl_Header;
							num2++;
							num -= script_GlobalVariableControl_Header2.Width;
						}
						while (num2 < this.mColumnHeaders.Length);
					}
					if (num2 == num3)
					{
						num2 = num3 - 1;
						num = 5;
					}
					if ((num2 != 0 && num <= 4) || (num2 + 1 < num3 && num + 4 >= array[num2].Width))
					{
						this.mMode = Script_GlobalVariableControl.eMode.MODE_ColumnResize;
						if (num <= 4)
						{
							this.mColumnToResize = num2 - 1;
						}
						else
						{
							this.mColumnToResize = num2;
						}
						this.mColumnResizeMouseX = e.X;
						base.Capture = true;
						this.Cursor = Cursors.SizeWE;
						base.Invalidate();
					}
					else if (y < clientRectangle.Y + this.mHeaderHeight)
					{
						if (this.mItems.Length != 0)
						{
							if (num2 == this.mSortColumn)
							{
								Script_GlobalVariableControl.eSortMode eSortMode = this.mSortMode;
								if (eSortMode != Script_GlobalVariableControl.eSortMode.SORT_Unsorted)
								{
									if (eSortMode != Script_GlobalVariableControl.eSortMode.SORT_Ascending)
									{
										if (eSortMode == Script_GlobalVariableControl.eSortMode.SORT_Descending)
										{
											this.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Unsorted;
										}
									}
									else
									{
										this.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Descending;
									}
								}
								else
								{
									this.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Ascending;
								}
							}
							else
							{
								this.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Ascending;
								this.mSortColumn = num2;
							}
							this.Sort(true);
							base.Invalidate();
						}
					}
					else
					{
						int num4 = (y - clientRectangle.Y - this.mHeaderHeight) / this.mRowHeight + this.mFirstDisplayed;
						if (num4 < this.mItems.Length)
						{
							this.mClickedColumnIndex = num2;
							this.mClickedIndex = num4;
							this.raise_ItemClicked(this, new EventArgs());
							if (e.Clicks == 2)
							{
								this.raise_ItemDoubleClicked(this, new EventArgs());
							}
							int num5 = this.mFirstDisplayed;
							if (num4 - num5 == this.mMaxRows)
							{
								this.mFirstDisplayed = num5 + 1;
							}
							this.RealSelectedIndex = num4;
							if (e.Clicks == 1)
							{
								this.raise_DragStarted(this, new EventArgs());
							}
						}
					}
				}
			}
		}

		private void Script_GlobalVariableControl_MouseMove(object sender, MouseEventArgs e)
		{
			Script_GlobalVariableControl_Header[] array = this.mColumnHeaders;
			if (array.Length != 0)
			{
				Script_GlobalVariableControl.eMode eMode = this.mMode;
				if (eMode != Script_GlobalVariableControl.eMode.MODE_Normal)
				{
					if (eMode == Script_GlobalVariableControl.eMode.MODE_ColumnResize)
					{
						int num = array[this.mColumnToResize].Width - this.mColumnResizeMouseX;
						int num2 = e.X + num;
						if (num2 < 5)
						{
							num2 = 5;
						}
						else
						{
							int num3 = 0;
							int num4 = 0;
							if (0 < this.mColumnToResize)
							{
								array = this.mColumnHeaders;
								int num5 = this.mColumnToResize;
								do
								{
									num3 = array[num4].Width + num3;
									num4++;
								}
								while (num4 < num5);
							}
							int num6 = base.ClientRectangle.Width - (this.mFrameSize << 1) - this.VertScrollBar.Width;
							if (num3 + num2 > num6)
							{
								num2 = num6 - num3;
							}
						}
						int num7 = this.mColumnToResize;
						array = this.mColumnHeaders;
						this.mColumnResizeMouseX = num2 - array[num7].Width + this.mColumnResizeMouseX;
						array[num7].Width = num2;
						base.Invalidate();
					}
				}
				else
				{
					Rectangle clientRectangle = base.ClientRectangle;
					clientRectangle.Width -= this.VertScrollBar.Width;
					clientRectangle.X += this.mFrameSize;
					clientRectangle.Y += this.mFrameSize;
					clientRectangle.Width -= this.mFrameSize << 1;
					clientRectangle.Height -= this.mFrameSize << 1;
					int num8 = e.X;
					int y = e.Y;
					if (clientRectangle.Contains(num8, y))
					{
						num8 -= this.mFrameSize;
						int num9 = 0;
						array = this.mColumnHeaders;
						int num10 = array.Length;
						if (0 < num10)
						{
							do
							{
								Script_GlobalVariableControl_Header script_GlobalVariableControl_Header = array[num9];
								if (num8 < script_GlobalVariableControl_Header.Width)
								{
									break;
								}
								Script_GlobalVariableControl_Header script_GlobalVariableControl_Header2 = script_GlobalVariableControl_Header;
								num9++;
								num8 -= script_GlobalVariableControl_Header2.Width;
							}
							while (num9 < this.mColumnHeaders.Length);
						}
						if (num9 == num10)
						{
							num9 = num10 - 1;
							num8 = 5;
						}
						if ((num9 != 0 && num8 <= 4) || (num9 + 1 < num10 && num8 + 4 >= array[num9].Width))
						{
							this.Cursor = Cursors.SizeWE;
							return;
						}
					}
					this.Cursor = Cursors.Default;
				}
			}
		}

		private void Script_GlobalVariableControl_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.mMode == Script_GlobalVariableControl.eMode.MODE_ColumnResize && e.Button == MouseButtons.Left)
			{
				this.mMode = Script_GlobalVariableControl.eMode.MODE_Normal;
				base.Capture = false;
				this.Cursor = Cursors.Default;
				base.Invalidate();
			}
		}

		private void Script_GlobalVariableControl_MouseWheel(object sender, MouseEventArgs e)
		{
			int num = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
			if (num != 0)
			{
				if (num > 0)
				{
					if (this.RealSelectedIndex > 0)
					{
						if (this.RealSelectedIndex >= num)
						{
							int num2 = this.mSelectedIndex - num;
							if (this.mFirstDisplayed > num2)
							{
								this.mFirstDisplayed = num2;
							}
							this.RealSelectedIndex = num2;
						}
						else
						{
							this.mFirstDisplayed = 0;
							this.RealSelectedIndex = 0;
						}
					}
				}
				else
				{
					num = -num;
					if (this.RealSelectedIndex + 1 < this.Items.Length)
					{
						int num3;
						if (num + this.RealSelectedIndex + 1 < this.Items.Length)
						{
							num3 = this.RealSelectedIndex + num;
						}
						else
						{
							num3 = this.Items.Length - 1;
						}
						int num4 = this.mMaxRows;
						if (num3 - this.mFirstDisplayed >= num4)
						{
							this.mFirstDisplayed = num3 - num4 + 1;
						}
						this.RealSelectedIndex = num3;
					}
				}
			}
		}

		private void VertScrollBar_Scroll(object sender, ScrollEventArgs e)
		{
			int value = this.VertScrollBar.Value;
			if (value != this.mFirstDisplayed)
			{
				this.mFirstDisplayed = value;
				if (this.RealSelectedIndex != -1)
				{
					int realSelectedIndex = this.RealSelectedIndex;
					if (realSelectedIndex < value)
					{
						this.RealSelectedIndex = value;
					}
					else
					{
						int num = this.mMaxRows;
						if (realSelectedIndex >= num + value)
						{
							this.RealSelectedIndex = value + num - 1;
						}
					}
				}
				base.Invalidate();
			}
		}

		private void VertScrollBar_ValueChanged(object sender, EventArgs e)
		{
			int value = this.VertScrollBar.Value;
			if (value != this.mFirstDisplayed)
			{
				this.mFirstDisplayed = value;
				if (this.RealSelectedIndex != -1)
				{
					int realSelectedIndex = this.RealSelectedIndex;
					if (realSelectedIndex < value)
					{
						this.RealSelectedIndex = value;
					}
					else
					{
						int num = this.mMaxRows;
						if (realSelectedIndex >= num + value)
						{
							this.RealSelectedIndex = value + num - 1;
						}
					}
				}
				base.Invalidate();
			}
		}

		private void Sort([MarshalAs(UnmanagedType.U1)] bool @event)
		{
			int num = 0;
			if (0 < this.mItems.Length)
			{
				do
				{
					int[] arg_16_0 = this.mSortIndices;
					int expr_15 = num;
					arg_16_0[expr_15] = expr_15;
					num++;
				}
				while (num < this.mItems.Length);
			}
			Script_GlobalVariableControl.eSortMode eSortMode = this.mSortMode;
			if (eSortMode != Script_GlobalVariableControl.eSortMode.SORT_Ascending)
			{
				if (eSortMode == Script_GlobalVariableControl.eSortMode.SORT_Descending)
				{
					int num2 = 1;
					if (1 < this.mItems.Length)
					{
						do
						{
							int num3 = 0;
							if (0 < num2)
							{
								do
								{
									int[] array = this.mSortIndices;
									Script_GlobalVariableControl_ListItem[] array2 = this.mItems;
									Script_GlobalVariableControl_ListItem script_GlobalVariableControl_ListItem = array2[array[num2]];
									Script_GlobalVariableControl_ListItem script_GlobalVariableControl_ListItem2 = array2[array[num3]];
									int num4 = this.mSortColumn;
									if ((script_GlobalVariableControl_ListItem.SubItems.Length > num4 || script_GlobalVariableControl_ListItem2.SubItems.Length > num4) && script_GlobalVariableControl_ListItem.SubItems.Length > num4)
									{
										if (script_GlobalVariableControl_ListItem2.SubItems.Length > num4)
										{
											string arg_D8_0 = script_GlobalVariableControl_ListItem.SubItems[num4].Text;
											string text = script_GlobalVariableControl_ListItem2.SubItems[num4].Text;
											if (string.Compare(arg_D8_0, text) <= 0)
											{
												goto IL_102;
											}
										}
										array = this.mSortIndices;
										int num5 = array[num2];
										array[num2] = array[num3];
										this.mSortIndices[num3] = num5;
									}
									IL_102:
									num3++;
								}
								while (num3 < num2);
							}
							num2++;
						}
						while (num2 < this.mItems.Length);
					}
				}
			}
			else
			{
				int num6 = 1;
				if (1 < this.mItems.Length)
				{
					do
					{
						int num7 = 0;
						if (0 < num6)
						{
							do
							{
								int[] array3 = this.mSortIndices;
								Script_GlobalVariableControl_ListItem[] array4 = this.mItems;
								Script_GlobalVariableControl_ListItem script_GlobalVariableControl_ListItem3 = array4[array3[num6]];
								Script_GlobalVariableControl_ListItem script_GlobalVariableControl_ListItem4 = array4[array3[num7]];
								int num8 = this.mSortColumn;
								if ((script_GlobalVariableControl_ListItem3.SubItems.Length > num8 || script_GlobalVariableControl_ListItem4.SubItems.Length > num8) && script_GlobalVariableControl_ListItem3.SubItems.Length > num8)
								{
									if (script_GlobalVariableControl_ListItem4.SubItems.Length > num8)
									{
										string arg_1B2_0 = script_GlobalVariableControl_ListItem3.SubItems[num8].Text;
										string text2 = script_GlobalVariableControl_ListItem4.SubItems[num8].Text;
										if (string.Compare(arg_1B2_0, text2) >= 0)
										{
											goto IL_1D8;
										}
									}
									array3 = this.mSortIndices;
									int num9 = array3[num6];
									array3[num6] = array3[num7];
									this.mSortIndices[num7] = num9;
								}
								IL_1D8:
								num7++;
							}
							while (num7 < num6);
						}
						num6++;
					}
					while (num6 < this.mItems.Length);
				}
			}
			if (@event)
			{
				this.UpdateScrollbar();
				this.raise_SelectedIndexChanged(this, new EventArgs());
				this.raise_SortModeChanged(this, new EventArgs());
			}
		}

		private void UpdateScrollbar()
		{
			this.VertScrollBar.Minimum = 0;
			int num = this.mMaxRows;
			if (num != 0 && num < this.mItems.Length)
			{
				this.VertScrollBar.LargeChange = num - 1;
				this.VertScrollBar.Maximum = this.mItems.Length - 2;
				this.VertScrollBar.Value = this.mFirstDisplayed;
			}
			else
			{
				this.VertScrollBar.Maximum = 0;
				this.VertScrollBar.Value = 0;
			}
		}

		protected void raise_SelectedIndexChanged(object i1, EventArgs i2)
		{
			EventHandler selectedIndexChanged = this.SelectedIndexChanged;
			if (selectedIndexChanged != null)
			{
				selectedIndexChanged(i1, i2);
			}
		}

		protected void raise_DragStarted(object i1, EventArgs i2)
		{
			EventHandler dragStarted = this.DragStarted;
			if (dragStarted != null)
			{
				dragStarted(i1, i2);
			}
		}

		protected void raise_ItemClicked(object i1, EventArgs i2)
		{
			EventHandler itemClicked = this.ItemClicked;
			if (itemClicked != null)
			{
				itemClicked(i1, i2);
			}
		}

		protected void raise_ItemDoubleClicked(object i1, EventArgs i2)
		{
			EventHandler itemDoubleClicked = this.ItemDoubleClicked;
			if (itemDoubleClicked != null)
			{
				itemDoubleClicked(i1, i2);
			}
		}

		protected void raise_SortModeChanged(object i1, EventArgs i2)
		{
			EventHandler sortModeChanged = this.SortModeChanged;
			if (sortModeChanged != null)
			{
				sortModeChanged(i1, i2);
			}
		}
	}
}
