using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class ScrollableControl : BaseScrollableControl
	{
		protected DoubleBuffControl ViewControl;

		protected VScrollBar Scrollbar;

		private int propScrollbarMode;

		private int propViewWidth;

		private int propViewHeight;

		private int propStartY;

		private int propSmallChangeFactor;

		private int StartX;

		private bool Suspended;

		private bool HiddenScrollbar;

		private Container components;

		private ControlEventHandler MyControlAddedHandler;

		private ControlEventHandler MyControlRemovedHandler;

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
				return this.ViewControl.Controls;
			}
		}

		public int SmallChangeFactor
		{
			get
			{
				return this.propSmallChangeFactor;
			}
			set
			{
				this.propSmallChangeFactor = value;
				if (this.OwnControls.Contains(this.Scrollbar))
				{
					this.Scrollbar.SmallChange = this.Scrollbar.LargeChange / this.propSmallChangeFactor;
				}
			}
		}

		public int StartY
		{
			get
			{
				return this.propStartY;
			}
			set
			{
				if (value > this.propViewHeight - base.Height)
				{
					value = this.propViewHeight - base.Height;
				}
				if (value < 0)
				{
					value = 0;
				}
				int num = this.propStartY;
				this.propStartY = value;
				Point location = new Point(this.StartX, -value);
				this.ViewControl.Location = location;
				int num2 = this.propStartY;
				int num3 = num2 - num;
				if (num3 > 0)
				{
					Rectangle rc = new Rectangle(this.StartX, base.Height + num, this.propViewWidth, num3);
					this.ViewControl.Invalidate(rc);
				}
				else
				{
					Rectangle rc2 = new Rectangle(this.StartX, num2, this.propViewWidth, num3);
					this.ViewControl.Invalidate(rc2);
				}
				VScrollBar scrollbar = this.Scrollbar;
				if (scrollbar != null)
				{
					scrollbar.Value = this.propStartY;
				}
				this.ViewControl.Refresh();
			}
		}

		public int ViewHeight
		{
			get
			{
				return this.propViewWidth;
			}
			set
			{
				if (value > 0)
				{
					this.propViewHeight = value;
					if (this.Scrollbar != null)
					{
						this.CalcScrollParams();
						this.Scrollbar.Invalidate();
					}
					this.ViewControl.Height = this.propViewHeight;
					if (base.Height + this.propStartY > this.propViewHeight)
					{
						int num = this.propViewHeight - base.Height;
						if (num < 0)
						{
							num = 0;
						}
						this.StartY = num;
					}
					Point location = new Point(this.StartX, -this.propStartY);
					this.ViewControl.Location = location;
					this.ViewControl.Refresh();
				}
			}
		}

		public int ViewWidth
		{
			get
			{
				return this.propViewWidth;
			}
			set
			{
				this.propViewWidth = value;
				this.ViewControl.Width = value;
			}
		}

		public int ScrollbarMode
		{
			get
			{
				return this.propScrollbarMode;
			}
			set
			{
				this.propScrollbarMode = value;
				this.propStartY = 0;
				if (value != 0)
				{
					if (!this.OwnControls.Contains(this.Scrollbar))
					{
						this.Scrollbar = new VScrollBar();
						this.Scrollbar.Scroll += new ScrollEventHandler(this.ScrollbarScroll);
						this.CalcScrollParams();
						if (this.ScrollbarMode == 2)
						{
							this.Scrollbar.Dock = DockStyle.Right;
							this.StartX = 0;
						}
						else
						{
							this.Scrollbar.Dock = DockStyle.Left;
							this.StartX = this.Scrollbar.Width;
						}
						base.ControlAdded -= this.MyControlAddedHandler;
						this.OwnControls.Add(this.Scrollbar);
						base.ControlAdded += this.MyControlAddedHandler;
						this.propViewWidth = base.Width - this.Scrollbar.Width;
					}
					else if (this.ScrollbarMode == 2)
					{
						this.Scrollbar.Dock = DockStyle.Right;
						this.StartX = 0;
					}
					else
					{
						this.Scrollbar.Dock = DockStyle.Left;
						this.StartX = this.Scrollbar.Width;
					}
				}
				else
				{
					if (this.OwnControls.Contains(this.Scrollbar))
					{
						base.ControlRemoved -= this.MyControlRemovedHandler;
						this.OwnControls.Remove(this.Scrollbar);
						base.ControlRemoved += this.MyControlRemovedHandler;
						this.Scrollbar.Dispose();
						this.StartX = 0;
					}
					this.propViewWidth = base.Width;
				}
				Point location = new Point(this.StartX, -this.propStartY);
				this.ViewControl.Location = location;
				this.ViewControl.Width = this.propViewWidth;
			}
		}

		public unsafe ScrollableControl(int width, int height, int viewheight, int scrollbarmode)
		{
			this.InitializeComponent();
			base.Width = width;
			base.Height = height;
			this.propViewHeight = viewheight;
			this.propScrollbarMode = scrollbarmode;
			this.Suspended = false;
			this.HiddenScrollbar = false;
			this.propStartY = 0;
			this.StartX = 0;
			this.propSmallChangeFactor = 8;
			if (this.ScrollbarMode != 0)
			{
				this.Scrollbar = new VScrollBar();
				this.Scrollbar.Scroll += new ScrollEventHandler(this.ScrollbarScroll);
				this.CalcScrollParams();
				if (this.ScrollbarMode == 2)
				{
					this.Scrollbar.Dock = DockStyle.Right;
				}
				else
				{
					this.Scrollbar.Dock = DockStyle.Left;
					this.StartX = this.Scrollbar.Width;
				}
				this.OwnControls.Add(this.Scrollbar);
				this.propViewWidth = base.Width - this.Scrollbar.Width;
			}
			else
			{
				this.propViewWidth = base.Width;
			}
			DoubleBuffControl doubleBuffControl = new DoubleBuffControl(this, new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@)), this.StartX, this.propStartY, this.propViewWidth, this.propViewHeight);
			this.ViewControl = doubleBuffControl;
			this.OwnControls.Add(doubleBuffControl);
			ControlEventHandler controlEventHandler = new ControlEventHandler(this.myControlAdded);
			this.MyControlAddedHandler = controlEventHandler;
			base.ControlAdded += controlEventHandler;
			ControlEventHandler controlEventHandler2 = new ControlEventHandler(this.myControlRemoved);
			this.MyControlRemovedHandler = controlEventHandler2;
			base.ControlRemoved += controlEventHandler2;
			this.ViewControl.MouseDown += new MouseEventHandler(this.ViewControlMouseDown);
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

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (this.ViewControl != null)
			{
				if (this.ScrollbarMode != 0 && !this.HiddenScrollbar)
				{
					this.ViewWidth = base.Width - this.Scrollbar.Width;
				}
				else
				{
					this.ViewWidth = base.Width;
				}
				if (this.ScrollbarMode != 0 && !this.HiddenScrollbar)
				{
					this.CalcScrollParams();
					this.Scrollbar.Refresh();
				}
				if (base.Height > this.propViewHeight - this.propStartY)
				{
					this.StartY = this.propViewHeight - base.Height;
				}
				this.ViewControl.Refresh();
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (!this.IsFocusedScrollableChild(this))
			{
				VScrollBar scrollbar = this.Scrollbar;
				if (scrollbar != null)
				{
					int num = e.Delta / 120 * scrollbar.SmallChange;
					int num2 = this.Scrollbar.Value - num;
					if (num2 < 0)
					{
						num2 = 0;
					}
					else if (num2 > this.Scrollbar.Maximum)
					{
						num2 = this.Scrollbar.Maximum;
					}
					this.StartY = num2;
				}
			}
		}

		private void InitializeComponent()
		{
			this.components = new Container();
		}

		private void myControlAdded(object __unnamed000, ControlEventArgs e)
		{
			this.ViewControl.Controls.Add(e.Control);
		}

		private void myControlRemoved(object __unnamed000, ControlEventArgs e)
		{
			this.ViewControl.Controls.Remove(e.Control);
		}

		private void ViewControlMouseDown(object __unnamed000, MouseEventArgs e)
		{
			base.Focus();
		}

		private void ScrollbarScroll(object __unnamed000, ScrollEventArgs e)
		{
			this.StartY = e.NewValue;
		}

		private void CalcScrollParams()
		{
			if (base.Height > 0)
			{
				int num = this.propViewHeight;
				if (num - base.Height > 0)
				{
					this.Scrollbar.Maximum = num;
					this.Scrollbar.LargeChange = base.Height;
					this.Scrollbar.SmallChange = this.Scrollbar.LargeChange / this.propSmallChangeFactor;
					this.Scrollbar.Enabled = true;
				}
				else
				{
					this.Scrollbar.Maximum = 0;
					this.Scrollbar.LargeChange = base.Height;
					this.Scrollbar.SmallChange = base.Height;
					this.Scrollbar.Enabled = false;
				}
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private bool IsFocusedScrollableChild(Control rootcontrol)
		{
			if (rootcontrol.Controls.Count > 0)
			{
				IEnumerator enumerator = rootcontrol.Controls.GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						if (enumerator.Current.GetType().BaseType.Equals(Type.GetType("NControls.BaseScrollableControl")))
						{
							if ((enumerator.Current as BaseScrollableControl).ContainsFocus)
							{
								return true;
							}
						}
						else if (this.IsFocusedScrollableChild(enumerator.Current as Control))
						{
							return true;
						}
					}
					while (enumerator.MoveNext());
					return false;
				}
			}
			return false;
		}

		public new void SuspendLayout()
		{
			this.Suspended = true;
			DoubleBuffControl viewControl = this.ViewControl;
			if (viewControl != null)
			{
				viewControl.SuspendLayout();
			}
			VScrollBar scrollbar = this.Scrollbar;
			if (scrollbar != null)
			{
				scrollbar.SuspendLayout();
			}
			base.SuspendLayout();
		}

		public new void ResumeLayout()
		{
			this.Suspended = false;
			DoubleBuffControl viewControl = this.ViewControl;
			if (viewControl != null)
			{
				viewControl.ResumeLayout();
			}
			VScrollBar scrollbar = this.Scrollbar;
			if (scrollbar != null)
			{
				scrollbar.ResumeLayout();
			}
			base.ResumeLayout();
		}

		public void HideScrollBar()
		{
			VScrollBar scrollbar = this.Scrollbar;
			if (scrollbar != null && this.OwnControls.Contains(scrollbar))
			{
				this.HiddenScrollbar = true;
				base.ControlRemoved -= this.MyControlRemovedHandler;
				this.OwnControls.Remove(this.Scrollbar);
				base.ControlRemoved += this.MyControlRemovedHandler;
				int width = base.Width;
				this.propViewWidth = width;
				this.ViewControl.Width = width;
			}
		}

		public void ShowScrollBar()
		{
			VScrollBar scrollbar = this.Scrollbar;
			if (scrollbar != null && !this.OwnControls.Contains(scrollbar))
			{
				this.HiddenScrollbar = false;
				base.ControlAdded -= this.MyControlAddedHandler;
				this.OwnControls.Add(this.Scrollbar);
				base.ControlAdded += this.MyControlAddedHandler;
				int width = base.Width - this.Scrollbar.Width;
				this.propViewWidth = width;
				this.ViewControl.Width = width;
			}
		}
	}
}
