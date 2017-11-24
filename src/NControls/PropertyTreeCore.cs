using GRTTI;
using NWorkshop;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;

namespace NControls
{
	public class PropertyTreeCore : ScrollableControl, IMultiColumnControl
	{
		public delegate void TrackSelectedHandler(NCurveEditor curveeditor);

		public delegate void __Delegate_ItemChanged();

		public delegate void __Delegate_SelectedIndexChanged();

		public float ItemHeight;

		public unsafe GMeasures* Measures;

		public NewAssetPicker.ObjectType ObjType;

		private ArrayList propItems;

		private ArrayList propColumnDatas;

		private int propSelectedIndex;

		private Label DescLabel;

		private Brush NormalItemBackgroundBrush;

		private Brush NormalItemTextBrush;

		private Brush SelectedItemBackgroundBrush;

		private Brush SelectedItemTextBrush;

		private Brush FocusSelectedItemBackgroundBrush;

		private Brush FocusSelectedItemTextBrush;

		private Pen ItemBorderPen;

		private Pen ExpandedLinePen;

		private int IndentWidth;

		private int LastSelectedIndex;

		private bool IsDblClickEnabled;

		private System.Timers.Timer ForbidDblClickTimer;

		private ContextMenu LocalMenu;

		private unsafe NPropertyClipboard* Clipboard;

		private PropertyItem.CopyPasteHandler ItemCopyHandler;

		private PropertyItem.CopyPasteHandler ItemPasteHandler;

		private Container components;

		public event PropertyTreeCore.__Delegate_SelectedIndexChanged SelectedIndexChanged
		{
			add
			{
				this.SelectedIndexChanged = Delegate.Combine(this.SelectedIndexChanged, value);
			}
			remove
			{
				this.SelectedIndexChanged = Delegate.Remove(this.SelectedIndexChanged, value);
			}
		}

		public event PropertyTreeCore.__Delegate_ItemChanged ItemChanged
		{
			add
			{
				this.ItemChanged = Delegate.Combine(this.ItemChanged, value);
			}
			remove
			{
				this.ItemChanged = Delegate.Remove(this.ItemChanged, value);
			}
		}

		public event PropertyTreeCore.TrackSelectedHandler TrackSelected
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.TrackSelected = Delegate.Combine(this.TrackSelected, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.TrackSelected = Delegate.Remove(this.TrackSelected, value);
			}
		}

		public unsafe int SelectedIndex
		{
			get
			{
				return this.propSelectedIndex;
			}
			set
			{
				int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
				this.propSelectedIndex = value;
				this.raise_SelectedIndexChanged();
				PropertyItemScalarTrack propertyItemScalarTrack = null;
				try
				{
					propertyItemScalarTrack = (this.Items[this.SelectedIndex] as PropertyItemScalarTrack);
					goto IL_7A;
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
				IL_7A:
				if (propertyItemScalarTrack != null)
				{
					this.raise_TrackSelected(propertyItemScalarTrack.GetTrackEditor());
				}
				else
				{
					this.raise_TrackSelected(null);
				}
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

		public unsafe PropertyTreeCore(int width, int height, int viewheight, int scrollbarmode, Label desclabel, NewAssetPicker.ObjectType objecttype, NPropertyClipboard* clipboard) : base(width, height, viewheight, scrollbarmode)
		{
			this.ItemChanged = null;
			this.SelectedIndexChanged = null;
			this.TrackSelected = null;
			this.DescLabel = desclabel;
			this.ObjType = objecttype;
			this.InitializeComponent();
			this.propItems = new ArrayList();
			this.propColumnDatas = new ArrayList();
			this.ItemHeight = (float)(this.Font.Height + 3);
			this.IndentWidth = 13;
			this.LastSelectedIndex = -1;
			Color color = Color.FromKnownColor(KnownColor.Window);
			this.NormalItemBackgroundBrush = new SolidBrush(color);
			Color color2 = Color.FromKnownColor(KnownColor.WindowText);
			this.NormalItemTextBrush = new SolidBrush(color2);
			Color color3 = Color.FromKnownColor(KnownColor.Control);
			this.SelectedItemBackgroundBrush = new SolidBrush(color3);
			Color color4 = Color.FromKnownColor(KnownColor.ControlText);
			this.SelectedItemTextBrush = new SolidBrush(color4);
			Color color5 = Color.FromKnownColor(KnownColor.Highlight);
			this.FocusSelectedItemBackgroundBrush = new SolidBrush(color5);
			Color color6 = Color.FromKnownColor(KnownColor.HighlightText);
			this.FocusSelectedItemTextBrush = new SolidBrush(color6);
			Color color7 = Color.FromKnownColor(KnownColor.Control);
			this.ItemBorderPen = new Pen(color7);
			Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlText));
			this.ExpandedLinePen = pen;
			pen.DashStyle = DashStyle.Dot;
			this.ViewControl.Paint += new PaintEventHandler(this.ViewControlPaint);
			this.ViewControl.MouseDown += new MouseEventHandler(this.ViewControlMouseDown);
			this.ViewControl.MouseUp += new MouseEventHandler(this.ViewControlMouseUp);
			this.ViewControl.DoubleClick += new EventHandler(this.ViewControlDoubleClick);
			this.IsDblClickEnabled = true;
			this.ForbidDblClickTimer = new System.Timers.Timer();
			this.ForbidDblClickTimer.Elapsed += new ElapsedEventHandler(this.EnableDblClick);
			this.ForbidDblClickTimer.Interval = 500.0;
			this.ForbidDblClickTimer.Enabled = false;
			this.LocalMenu = new ContextMenu();
			this.Clipboard = clipboard;
			this.ItemCopyHandler = new PropertyItem.CopyPasteHandler(this.OnItemCopy);
			this.ItemPasteHandler = new PropertyItem.CopyPasteHandler(this.OnItemPaste);
		}

		public unsafe void AddSubitems(ArrayList subitems, int indent_depth, int* insert_at)
		{
			this.AddSubitems(subitems, indent_depth, insert_at, null);
		}

		public unsafe void AddSubitems(ArrayList subitems, int indent_depth, int* insert_at, ArrayList expansions)
		{
			int num = 0;
			if (0 < subitems.Count)
			{
				do
				{
					PropertyItem propertyItem = subitems[num] as PropertyItem;
					propertyItem.IndentDepth = indent_depth;
					propertyItem.Index = *insert_at;
					propertyItem.Host = this;
					this.Items.Insert(*insert_at, propertyItem);
					propertyItem.UpdateControl(new Rectangle
					{
						X = (int)((double)((this.ColumnDatas[1] as ColumnData).StartX + 2f)),
						Y = (int)((double)((float)propertyItem.Index * this.ItemHeight)),
						Width = (int)((double)((this.ColumnDatas[1] as ColumnData).Width - 1f)),
						Height = (int)((double)this.ItemHeight)
					});
					(*insert_at)++;
					bool flag = true;
					if (expansions != null)
					{
						int num2 = 0;
						if (0 < expansions.Count)
						{
							ItemStatus itemStatus;
							do
							{
								itemStatus = (expansions[num2] as ItemStatus);
								if (string.Compare(itemStatus.Name, propertyItem.GetName()) == 0 && itemStatus.Type == propertyItem.IdentifyType())
								{
									goto IL_117;
								}
								num2++;
							}
							while (num2 < expansions.Count);
							goto IL_11F;
							IL_117:
							flag = itemStatus.Expanded;
						}
					}
					IL_11F:
					if (propertyItem.ShouldBeExpanded() && flag)
					{
						this.AddSubitems(propertyItem.Expand(), indent_depth + 1, insert_at, expansions);
						propertyItem.Expanded = true;
					}
					else
					{
						propertyItem.Expanded = false;
					}
					num++;
				}
				while (num < subitems.Count);
			}
		}

		public void UpdateSubitems(int start_idx)
		{
			int num = start_idx;
			if (start_idx < this.Items.Count)
			{
				do
				{
					PropertyItem propertyItem = this.Items[num] as PropertyItem;
					propertyItem.Index = num;
					propertyItem.UpdateControl(new Rectangle
					{
						X = (int)((double)((this.ColumnDatas[1] as ColumnData).StartX + 2f)),
						Y = (int)((double)((float)propertyItem.Index * this.ItemHeight)),
						Width = (int)((double)((this.ColumnDatas[1] as ColumnData).Width - 1f)),
						Height = (int)((double)this.ItemHeight)
					});
					num++;
				}
				while (num < this.Items.Count);
			}
		}

		public unsafe void SetVariable(GClass* type, void* var, GMeasures* measures)
		{
			this.SetVariable(type, var, measures, true);
		}

		public unsafe void SetVariable(GClass* type, void* var, GMeasures* measures, [MarshalAs(UnmanagedType.U1)] bool reset)
		{
			GMeasures* ptr = <Module>.@new(52u);
			GMeasures* measures2;
			if (ptr != null)
			{
				cpblk(ptr, measures, 52);
				measures2 = ptr;
			}
			else
			{
				measures2 = null;
			}
			this.Measures = measures2;
			base.SuspendLayout();
			ArrayList arrayList = null;
			if (this.Items.Count != 0)
			{
				do
				{
					PropertyItem propertyItem = this.Items[this.Items.Count - 1] as PropertyItem;
					if (!reset && propertyItem.CanBeExpanded())
					{
						ItemStatus itemStatus = new ItemStatus();
						itemStatus.Name = propertyItem.GetName();
						itemStatus.Type = propertyItem.IdentifyType();
						itemStatus.Expanded = propertyItem.Expanded;
						if (arrayList == null)
						{
							arrayList = new ArrayList();
						}
						arrayList.Add(itemStatus);
					}
					propertyItem.DestroyControl();
					this.Items.RemoveAt(this.Items.Count - 1);
				}
				while (this.Items.Count != 0);
			}
			if (type != null && var != null)
			{
				PropertyItem propertyItem2 = PropertyItem.MakeProperty(null, null, type, var, 0, 0, 0, 0);
				if (!propertyItem2.CanBeExpanded())
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0BM@KKOJMHJP@?4?2controls?2PropertyTree?4cpp?$AA@), 111, (sbyte*)(&<Module>.??_C@_0CJ@KLAPHJA@NControls?3?3PropertyTreeCore?3?3Set@));
					<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0CF@JFNPDDOC@The?5passed?5type?5should?5be?5expand@));
				}
				int num = 0;
				this.AddSubitems(propertyItem2.Expand(), 0, ref num, arrayList);
			}
			base.ResumeLayout();
			this.UpdateViewHeight();
		}

		public void RegenerateSubtree(int index)
		{
			base.SuspendLayout();
			PropertyItem propertyItem = this.Items[index] as PropertyItem;
			if (propertyItem.Expanded)
			{
				int num = index + 1;
				if (num < this.Items.Count)
				{
					do
					{
						PropertyItem propertyItem2 = this.Items[index + 1] as PropertyItem;
						if (propertyItem2.IndentDepth <= propertyItem.IndentDepth)
						{
							break;
						}
						propertyItem2.DestroyControl();
						this.Items.RemoveAt(index + 1);
					}
					while (num < this.Items.Count);
				}
			}
			if (propertyItem.CanBeExpanded() && (propertyItem.Expanded || propertyItem.ShouldBeExpanded()))
			{
				int num2 = index + 1;
				this.AddSubitems(propertyItem.Expand(), propertyItem.IndentDepth + 1, ref num2);
				propertyItem.Expanded = true;
			}
			else
			{
				propertyItem.Expanded = false;
			}
			this.UpdateSubitems(index + 1);
			base.ResumeLayout();
			this.UpdateViewHeight();
		}

		public void InvalidateViewControl()
		{
			this.ViewControl.Invalidate();
		}

		public void RaiseItemChanged()
		{
			this.raise_ItemChanged();
		}

		public int GetViewControlWidth()
		{
			return this.ViewControl.Width;
		}

		public override void ColumnsResized()
		{
			this.ViewControl.Refresh();
			this.UpdateSubitems(0);
		}

		public void EnsureSelectedVisible()
		{
			if ((float)this.SelectedIndex * this.ItemHeight < (float)base.StartY)
			{
				base.StartY = (int)((double)((float)this.SelectedIndex * this.ItemHeight));
			}
			else
			{
				float num = (float)this.SelectedIndex * this.ItemHeight - (float)base.StartY;
				if (num > (float)base.Height - this.ItemHeight)
				{
					float num2 = (float)this.SelectedIndex * this.ItemHeight;
					base.StartY = (int)((double)(num2 - (float)base.Height + this.ItemHeight));
				}
			}
			this.ViewControl.Invalidate();
			if (this.DescLabel != null && this.Items.Count != 0)
			{
				PropertyItem propertyItem = this.Items[this.SelectedIndex] as PropertyItem;
				this.DescLabel.Text = propertyItem.GetDescription();
			}
		}

		public void UpdateViewHeight()
		{
			base.ViewHeight = (int)((double)((float)this.propItems.Count * this.ItemHeight + 1f));
		}

		public override void Refresh()
		{
			if (this.Items != null)
			{
				this.UpdateSubitems(0);
			}
			this.ViewControl.Refresh();
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
			else if (e.KeyCode == Keys.Down)
			{
				if (this.SelectedIndex < this.Items.Count - 1)
				{
					this.SelectedIndex++;
					this.EnsureSelectedVisible();
				}
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Home)
			{
				this.SelectedIndex = 0;
				this.EnsureSelectedVisible();
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.End)
			{
				if (this.Items.Count > 0)
				{
					this.SelectedIndex = this.Items.Count - 1;
					this.EnsureSelectedVisible();
				}
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Prior)
			{
				float num = (float)this.SelectedIndex;
				int num2 = (int)((double)(num - (float)base.Height / this.ItemHeight + 1f));
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
			else if (e.KeyCode == Keys.Next)
			{
				int num3 = (int)((double)((float)base.Height / this.ItemHeight + (float)this.SelectedIndex - 1f));
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
			else if (e.KeyCode == Keys.Return)
			{
				e.Handled = true;
				if (this.SelectedIndex >= 0 && !(this.Items[this.SelectedIndex] as PropertyItem).OnEnterPressed())
				{
					this.ViewControlDoubleClick(this, null);
				}
			}
			else if (e.KeyCode == Keys.Space)
			{
				e.Handled = true;
				this.ViewControlDoubleClick(this, null);
			}
			base.OnKeyDown(e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			this.ViewControl.Invalidate();
		}

		protected unsafe void OnItemCopy(PropertyItem item)
		{
			uint num = (uint)(*(int*)(this.Clipboard + 4 / sizeof(NPropertyClipboard)));
			if (num != 0u)
			{
				GStream* ptr = num;
				object arg_19_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr, 1, *(*(int*)ptr));
				*(int*)(this.Clipboard + 4 / sizeof(NPropertyClipboard)) = 0;
			}
			*(int*)this.Clipboard = item.IdentifyType();
			GStreamBuffer* ptr2 = <Module>.@new(36u);
			GStreamBuffer* ptr3;
			try
			{
				if (ptr2 != null)
				{
					ptr3 = <Module>.GStreamBuffer.{ctor}(ptr2);
				}
				else
				{
					ptr3 = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr2);
				throw;
			}
			*(int*)(this.Clipboard + 4 / sizeof(NPropertyClipboard)) = ptr3;
			item.SaveToBuffer(*(int*)(this.Clipboard + 4 / sizeof(NPropertyClipboard)));
		}

		protected unsafe void OnItemPaste(PropertyItem item)
		{
			item.LoadFromBuffer(*(int*)(this.Clipboard + 4 / sizeof(NPropertyClipboard)));
			item.Refresh();
		}

		private void InitializeComponent()
		{
			this.Font = new Font("Tahoma", 8.25f);
		}

		private void ViewControlPaint(object sender, PaintEventArgs e)
		{
			int num = 0;
			if (0 < this.Items.Count)
			{
				do
				{
					Rectangle clip = default(Rectangle);
					clip.X = 0;
					clip.Y = 0;
					clip.Width = this.ViewControl.Width;
					clip.Height = this.ViewControl.Height;
					e.Graphics.SetClip(clip);
					PropertyItem propertyItem = this.Items[num] as PropertyItem;
					propertyItem.Index = num;
					Rectangle rect = default(Rectangle);
					Rectangle rect2 = default(Rectangle);
					rect.X = (int)((double)(this.ColumnDatas[0] as ColumnData).StartX);
					rect.Y = (int)((double)((float)propertyItem.Index * this.ItemHeight));
					rect.Width = (int)((double)(this.ColumnDatas[0] as ColumnData).Width);
					rect.Height = (int)((double)this.ItemHeight);
					clip.X = rect.X;
					clip.Y = rect.Y;
					clip.Width = rect.Width - 2;
					clip.Height = rect.Height;
					rect2.X = (int)((double)(this.ColumnDatas[1] as ColumnData).StartX);
					rect2.Y = rect.Y;
					rect2.Width = (int)((double)(this.ColumnDatas[1] as ColumnData).Width);
					rect2.Height = rect.Height;
					Brush brush;
					Brush brush2;
					if (propertyItem.Index == this.SelectedIndex)
					{
						if (this.Focused)
						{
							brush = this.FocusSelectedItemBackgroundBrush;
							brush2 = this.FocusSelectedItemTextBrush;
						}
						else
						{
							brush = this.SelectedItemBackgroundBrush;
							brush2 = this.SelectedItemTextBrush;
						}
					}
					else
					{
						brush = this.NormalItemBackgroundBrush;
						brush2 = this.NormalItemTextBrush;
					}
					e.Graphics.FillRectangle(brush, rect);
					e.Graphics.DrawRectangle(this.ItemBorderPen, rect);
					e.Graphics.DrawRectangle(this.ItemBorderPen, rect2);
					e.Graphics.SetClip(clip);
					rect.X = propertyItem.IndentDepth * this.IndentWidth + rect.X + 3;
					if (propertyItem.Expanded)
					{
						Rectangle rect3 = default(Rectangle);
						rect3.X = rect.X;
						rect3.Y = (int)((double)((float)rect.Y + this.ItemHeight * 0.5f - 4f));
						rect3.Width = 9;
						rect3.Height = 9;
						e.Graphics.FillRectangle(brush2, rect3);
						rect3.X++;
						rect3.Y++;
						rect3.Width = 7;
						rect3.Height = 7;
						e.Graphics.FillRectangle(brush, rect3);
						rect3.X++;
						rect3.Y += 3;
						rect3.Width = 5;
						rect3.Height = 1;
						e.Graphics.FillRectangle(brush2, rect3);
						PointF point = new PointF((float)(rect.X + 10), (float)(rect.Y + 2));
						e.Graphics.DrawString(propertyItem.GetName(), this.Font, brush2, point);
					}
					else if (propertyItem.CanBeExpanded())
					{
						Rectangle rect4 = default(Rectangle);
						rect4.X = rect.X;
						rect4.Y = (int)((double)((float)rect.Y + this.ItemHeight * 0.5f - 4f));
						rect4.Width = 9;
						rect4.Height = 9;
						e.Graphics.FillRectangle(brush2, rect4);
						rect4.X++;
						rect4.Y++;
						rect4.Width = 7;
						rect4.Height = 7;
						e.Graphics.FillRectangle(brush, rect4);
						rect4.X++;
						rect4.Y += 3;
						rect4.Width = 5;
						rect4.Height = 1;
						e.Graphics.FillRectangle(brush2, rect4);
						rect4.X += 2;
						rect4.Y -= 2;
						rect4.Width = 1;
						rect4.Height = 5;
						e.Graphics.FillRectangle(brush2, rect4);
						PointF point2 = new PointF((float)(rect.X + 10), (float)(rect.Y + 2));
						e.Graphics.DrawString(propertyItem.GetNameWithMeasure(), this.Font, brush2, point2);
					}
					else
					{
						PointF point3 = new PointF((float)(rect.X + 10), (float)(rect.Y + 2));
						e.Graphics.DrawString(propertyItem.GetNameWithMeasure(), this.Font, brush2, point3);
					}
					num++;
				}
				while (num < this.Items.Count);
			}
		}

		private void ViewControlMouseDown(object sender, MouseEventArgs e)
		{
			this.SelectedIndex = (int)((double)((float)(e.Y - 1) / this.ItemHeight));
			this.EnsureSelectedVisible();
			int num = (this.Items[this.SelectedIndex] as PropertyItem).IndentDepth * this.IndentWidth + 2;
			if (e.X >= num && e.X < num + 10)
			{
				this.ExpandItem(this.SelectedIndex);
				this.IsDblClickEnabled = false;
				this.ForbidDblClickTimer.Enabled = true;
			}
		}

		private unsafe void ViewControlMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				this.SelectedIndex = (int)((double)((float)(e.Y - 1) / this.ItemHeight));
				this.EnsureSelectedVisible();
				PropertyItem propertyItem = this.Items[this.SelectedIndex] as PropertyItem;
				float num = (float)e.X;
				if (num < (this.ColumnDatas[0] as ColumnData).Width)
				{
					this.LocalMenu.MenuItems.Clear();
					if (propertyItem.GetContextMenu() != null)
					{
						this.LocalMenu.MergeMenu(propertyItem.GetContextMenu());
					}
					if (propertyItem.GetEditContextMenu() != null && this.Clipboard != null)
					{
						this.LocalMenu.MenuItems.Add("-");
						this.LocalMenu.MergeMenu(propertyItem.GetEditContextMenu());
						NPropertyClipboard* clipboard = this.Clipboard;
						byte enabled;
						if (*(int*)(clipboard + 4 / sizeof(NPropertyClipboard)) != 0 && *(int*)clipboard == propertyItem.IdentifyType())
						{
							enabled = 1;
						}
						else
						{
							enabled = 0;
						}
						this.LocalMenu.MenuItems[this.LocalMenu.MenuItems.Count - 1].Enabled = (enabled != 0);
						propertyItem.Copy += this.ItemCopyHandler;
						propertyItem.Paste += this.ItemPasteHandler;
					}
					Point location = this.ViewControl.Location;
					Point location2 = this.ViewControl.Location;
					Point pos = new Point(e.X + location2.X, e.Y + location.Y);
					this.LocalMenu.Show(this, pos);
				}
			}
		}

		private void EnableDblClick(object source, ElapsedEventArgs __unnamed001)
		{
			this.IsDblClickEnabled = true;
			this.ForbidDblClickTimer.Enabled = false;
		}

		private void ViewControlDoubleClick(object sender, EventArgs e)
		{
			if (this.IsDblClickEnabled && this.SelectedIndex >= 0)
			{
				this.ExpandItem(this.SelectedIndex);
			}
		}

		private void ExpandItem(int index)
		{
			PropertyItem propertyItem = this.Items[index] as PropertyItem;
			if (propertyItem.Expanded)
			{
				base.SuspendLayout();
				int num = index + 1;
				if (num < this.Items.Count)
				{
					do
					{
						PropertyItem propertyItem2 = this.Items[index + 1] as PropertyItem;
						if (propertyItem2.IndentDepth <= propertyItem.IndentDepth)
						{
							break;
						}
						propertyItem2.DestroyControl();
						this.Items.RemoveAt(index + 1);
					}
					while (num < this.Items.Count);
				}
				this.UpdateSubitems(index + 1);
				base.ResumeLayout();
				propertyItem.Expanded = false;
				this.UpdateViewHeight();
			}
			else if (propertyItem.CanBeExpanded())
			{
				base.SuspendLayout();
				int num2 = index + 1;
				int num3 = num2;
				this.AddSubitems(propertyItem.Expand(), propertyItem.IndentDepth + 1, ref num3);
				this.UpdateSubitems(num2);
				base.ResumeLayout();
				propertyItem.Expanded = true;
				this.UpdateViewHeight();
			}
		}

		protected void raise_ItemChanged()
		{
			PropertyTreeCore.__Delegate_ItemChanged itemChanged = this.ItemChanged;
			if (itemChanged != null)
			{
				itemChanged();
			}
		}

		protected void raise_SelectedIndexChanged()
		{
			PropertyTreeCore.__Delegate_SelectedIndexChanged selectedIndexChanged = this.SelectedIndexChanged;
			if (selectedIndexChanged != null)
			{
				selectedIndexChanged();
			}
		}

		protected void raise_TrackSelected(NCurveEditor i1)
		{
			PropertyTreeCore.TrackSelectedHandler trackSelected = this.TrackSelected;
			if (trackSelected != null)
			{
				trackSelected(i1);
			}
		}
	}
}
