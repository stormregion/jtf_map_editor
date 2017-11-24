using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxVertex : UserControl, IRearrangeableControl
	{
		public delegate void BrushTypeChangeHandler(int newtype);

		public delegate void VertexFlagChangeHandler(int flag, [MarshalAs(UnmanagedType.U1)] bool value);

		public delegate void SelectionTypeChangedHandler(int newtype);

		public delegate void InvertSelectionHandler();

		public delegate void __Delegate_BrushTypeChanged(int);

		private IContainer components;

		private BrushTools BrushToolbox;

		private int propBrushType;

		private int propFalloffType;

		private Toolbar tbBrush;

		private int propSelectionType;

		private bool Additive;

		private bool LockHeight;

		public event ToolboxVertex.__Delegate_BrushTypeChanged BrushTypeChanged
		{
			add
			{
				this.BrushTypeChanged = Delegate.Combine(this.BrushTypeChanged, value);
			}
			remove
			{
				this.BrushTypeChanged = Delegate.Remove(this.BrushTypeChanged, value);
			}
		}

		public event ToolboxVertex.InvertSelectionHandler InvertSelection
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.InvertSelection = Delegate.Combine(this.InvertSelection, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.InvertSelection = Delegate.Remove(this.InvertSelection, value);
			}
		}

		public event ToolboxVertex.SelectionTypeChangedHandler SelectionTypeChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.SelectionTypeChanged = Delegate.Combine(this.SelectionTypeChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.SelectionTypeChanged = Delegate.Remove(this.SelectionTypeChanged, value);
			}
		}

		public event ToolboxVertex.VertexFlagChangeHandler VertexFlagChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.VertexFlagChanged = Delegate.Combine(this.VertexFlagChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.VertexFlagChanged = Delegate.Remove(this.VertexFlagChanged, value);
			}
		}

		public event ToolboxVertex.BrushTypeChangeHandler BrushFalloffTypeChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.BrushFalloffTypeChanged = Delegate.Combine(this.BrushFalloffTypeChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.BrushFalloffTypeChanged = Delegate.Remove(this.BrushFalloffTypeChanged, value);
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

		public event BrushTools.BrushParametersChangeHandler BrushParametersChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.BrushParametersChanged = Delegate.Combine(this.BrushParametersChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.BrushParametersChanged = Delegate.Remove(this.BrushParametersChanged, value);
			}
		}

		public bool InvertEnable
		{
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.tbBrush.SetItemEnable(25, value);
			}
		}

		public int SelectionType
		{
			get
			{
				return this.propSelectionType;
			}
			set
			{
				this.propSelectionType = value;
				if (value < 20)
				{
					this.tbBrush.SetGroupPushed(4, false);
				}
				else
				{
					this.tbBrush.SetItemPushed(value, true);
					this.tbBrush.SetGroupPushed(1, false);
				}
			}
		}

		public bool LockObjectHeights
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.LockHeight;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.LockHeight = value;
				if (this.propSelectionType < 20)
				{
					this.tbBrush.SetItemPushed(201, value);
				}
			}
		}

		public bool AdditiveMode
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.Additive;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.Additive = value;
				int num = this.propBrushType;
				if ((num != 7 && num != 1 && this.propSelectionType < 20) || this.propSelectionType == 24)
				{
					this.tbBrush.SetItemPushed(200, value);
				}
			}
		}

		public int FalloffType
		{
			get
			{
				return this.propFalloffType;
			}
			set
			{
				this.propFalloffType = value;
				if ((this.propBrushType != 1 && this.propSelectionType < 20) || this.propSelectionType == 24)
				{
					this.tbBrush.SetItemPushed(value, true);
				}
			}
		}

		public int BrushType
		{
			get
			{
				return this.propBrushType;
			}
			set
			{
				this.propBrushType = value;
				this.tbBrush.SetItemPushed(value, true);
			}
		}

		public unsafe ToolboxVertex()
		{
			this.BrushTypeChanged = null;
			this.BrushParametersChanged = null;
			this.Rearranged = null;
			this.BrushFalloffTypeChanged = null;
			this.VertexFlagChanged = null;
			this.SelectionTypeChanged = null;
			this.InvertSelection = null;
			this.InitializeComponent();
			this.BrushToolbox = new BrushTools(true);
			this.BrushToolbox.BrushParametersChanged += new BrushTools.BrushParametersChangeHandler(this.InternalBrushParamChanged);
			this.BrushToolbox.Rearranged += new ToolRearranged(this.SlidersRearranged);
			Point location = new Point(0, 36);
			this.BrushToolbox.Location = location;
			this.BrushToolbox.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
			base.Controls.Add(this.BrushToolbox);
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0ToolboxVertex@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), 24);
			this.tbBrush = toolbar;
			toolbar.Dock = DockStyle.Top;
			this.tbBrush.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tbBrush_ButtonClick);
			this.tbBrush.Rearranged += new ToolRearranged(this.ToolbarRearranged);
			Size size = base.Size;
			Size size2 = new Size(base.Size.Width, size.Height);
			this.tbBrush.Size = size2;
			base.Controls.Add(this.tbBrush);
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing)
			{
				IContainer container = this.components;
				if (container != null)
				{
					container.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Name = "ToolboxVertex";
			Size size = new Size(256, 256);
			base.Size = size;
			base.Resize += new EventHandler(this.ToolboxVertex_Resize);
		}

		public void ResetToNone()
		{
			this.tbBrush.SetGroupPushed(1, false);
			this.BrushToolbox.SetBrushSize1(0);
		}

		public void SetBrushSize1(ref float val)
		{
			this.BrushToolbox.SetBrushSize1(ref val);
		}

		public void SetBrushSize2(ref float val)
		{
			this.BrushToolbox.SetBrushSize2(ref val);
		}

		public void SetBrushPressure(ref float val)
		{
			this.BrushToolbox.SetBrushPressure(ref val);
		}

		public void SetBrushHeight(ref float val)
		{
			this.BrushToolbox.SetBrushHeight(ref val);
		}

		public void EmulatePush(int ordinal)
		{
			this.tbBrush.EmulatePush(ordinal);
		}

		public void EmulateUp(int ordinal)
		{
			this.tbBrush.EmulateUp(ordinal);
		}

		private void ToolbarRearranged(object sender, int newheight)
		{
			Size size = base.Size;
			Size size2 = this.BrushToolbox.Size;
			if (newheight != size.Height - size2.Height)
			{
				Point location = new Point(0, newheight + 8);
				this.BrushToolbox.Location = location;
				Size size3 = this.BrushToolbox.Size;
				Size size4 = new Size(base.Size.Width, size3.Height + newheight);
				base.Size = size4;
				this.raise_Rearranged(sender, base.Size.Height);
			}
		}

		private void SlidersRearranged(object sender, int newheight)
		{
			Size size = base.Size;
			Size size2 = this.tbBrush.Size;
			if (newheight != size.Height - size2.Height)
			{
				Size size3 = this.tbBrush.Size;
				Size size4 = new Size(base.Size.Width, size3.Height + newheight);
				base.Size = size4;
				this.raise_Rearranged(sender, base.Size.Height);
			}
		}

		private void tbBrush_ButtonClick(int idx, int radio_group)
		{
			if (radio_group == 1)
			{
				this.BrushType = idx;
				this.raise_BrushTypeChanged(this.BrushType);
				if (idx != 7)
				{
					if (idx != 1)
					{
						this.tbBrush.SetGroupEnable(2, true);
						this.tbBrush.SetItemPushed(this.propFalloffType, true);
						this.tbBrush.SetItemEnable(200, true);
						this.tbBrush.SetItemPushed(200, this.Additive);
						this.raise_VertexFlagChanged(200, this.Additive);
						goto IL_DB;
					}
					this.tbBrush.SetGroupPushed(2, false);
					this.tbBrush.SetGroupEnable(2, false);
				}
				else
				{
					this.tbBrush.SetGroupEnable(2, true);
					this.tbBrush.SetItemPushed(this.propFalloffType, true);
				}
				this.tbBrush.SetItemPushed(200, false);
				this.tbBrush.SetItemEnable(200, false);
				IL_DB:
				this.tbBrush.SetItemEnable(201, true);
				this.tbBrush.SetItemPushed(201, this.LockHeight);
				this.raise_VertexFlagChanged(201, this.LockHeight);
			}
			else if (radio_group == 2)
			{
				this.tbBrush.SetItemPushed(idx, true);
				this.raise_BrushFalloffTypeChanged(idx);
			}
			else if (radio_group == 3)
			{
				Toolbar toolbar = this.tbBrush;
				bool flag = ((!toolbar.GetItemPushed(idx)) ? 1 : 0) != 0;
				toolbar.SetItemPushed(idx, flag);
				int additive;
				if (flag && idx == 200)
				{
					additive = 1;
				}
				else
				{
					additive = 0;
				}
				this.Additive = (additive != 0);
				int lockHeight;
				if (flag && idx == 201)
				{
					lockHeight = 1;
				}
				else
				{
					lockHeight = 0;
				}
				this.LockHeight = (lockHeight != 0);
				this.raise_VertexFlagChanged(idx, flag);
			}
			else if (radio_group == 4)
			{
				this.tbBrush.SetItemPushed(idx, true);
				if (idx == 24)
				{
					this.tbBrush.SetGroupEnable(2, true);
					this.tbBrush.SetItemPushed(this.propFalloffType, true);
					this.tbBrush.SetItemEnable(200, true);
					this.tbBrush.SetItemPushed(200, this.Additive);
					this.raise_VertexFlagChanged(200, this.Additive);
				}
				else
				{
					this.tbBrush.SetGroupPushed(2, false);
					this.tbBrush.SetGroupEnable(2, false);
					this.tbBrush.SetItemPushed(200, false);
					this.tbBrush.SetItemEnable(200, false);
				}
				this.tbBrush.SetItemPushed(201, false);
				this.tbBrush.SetItemEnable(201, false);
				this.propSelectionType = idx;
				this.raise_SelectionTypeChanged(idx);
			}
			else if (radio_group == 5)
			{
				this.raise_InvertSelection();
			}
		}

		private void InternalBrushParamChanged(float size1, float size2, float pressure, float height)
		{
			this.raise_BrushParametersChanged(size1, size2, pressure, height);
		}

		private void InternalBrushFalloffTypeChanged(int newtype)
		{
			this.raise_BrushFalloffTypeChanged(newtype);
		}

		private void ToolboxVertex_Resize(object sender, EventArgs e)
		{
			Size size = this.BrushToolbox.Size;
			Size size2 = new Size(base.Size.Width, size.Height);
			this.BrushToolbox.Size = size2;
		}

		protected void raise_BrushTypeChanged(int i1)
		{
			ToolboxVertex.__Delegate_BrushTypeChanged brushTypeChanged = this.BrushTypeChanged;
			if (brushTypeChanged != null)
			{
				brushTypeChanged(i1);
			}
		}

		protected void raise_BrushParametersChanged(float i1, float i2, float i3, float i4)
		{
			BrushTools.BrushParametersChangeHandler brushParametersChanged = this.BrushParametersChanged;
			if (brushParametersChanged != null)
			{
				brushParametersChanged(i1, i2, i3, i4);
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

		protected void raise_BrushFalloffTypeChanged(int i1)
		{
			ToolboxVertex.BrushTypeChangeHandler brushFalloffTypeChanged = this.BrushFalloffTypeChanged;
			if (brushFalloffTypeChanged != null)
			{
				brushFalloffTypeChanged(i1);
			}
		}

		protected void raise_VertexFlagChanged(int i1, [MarshalAs(UnmanagedType.U1)] bool i2)
		{
			ToolboxVertex.VertexFlagChangeHandler vertexFlagChanged = this.VertexFlagChanged;
			if (vertexFlagChanged != null)
			{
				vertexFlagChanged(i1, i2);
			}
		}

		protected void raise_SelectionTypeChanged(int i1)
		{
			ToolboxVertex.SelectionTypeChangedHandler selectionTypeChanged = this.SelectionTypeChanged;
			if (selectionTypeChanged != null)
			{
				selectionTypeChanged(i1);
			}
		}

		protected void raise_InvertSelection()
		{
			ToolboxVertex.InvertSelectionHandler invertSelection = this.InvertSelection;
			if (invertSelection != null)
			{
				invertSelection();
			}
		}
	}
}
