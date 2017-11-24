using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxTerrainTools : UserControl, IRearrangeableControl
	{
		public delegate void FillSelectionHandler(int filltype);

		public delegate void ColorChangedHandler(uint newcolor);

		public delegate void __Delegate_PaintTypeChanged(int);

		private IContainer components;

		private BrushTools BrushToolbox;

		private int PaintTypeP;

		private Toolbar tbPaint;

		private ColorPicker ColorTool;

		private int ExtraCPHeight;

		public event ToolboxTerrainTools.__Delegate_PaintTypeChanged PaintTypeChanged
		{
			add
			{
				this.PaintTypeChanged = Delegate.Combine(this.PaintTypeChanged, value);
			}
			remove
			{
				this.PaintTypeChanged = Delegate.Remove(this.PaintTypeChanged, value);
			}
		}

		public event ToolboxTerrainTools.ColorChangedHandler BrushColorChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.BrushColorChanged = Delegate.Combine(this.BrushColorChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.BrushColorChanged = Delegate.Remove(this.BrushColorChanged, value);
			}
		}

		public event ToolboxTerrainTools.FillSelectionHandler FillSelection
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.FillSelection = Delegate.Combine(this.FillSelection, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.FillSelection = Delegate.Remove(this.FillSelection, value);
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

		public bool FillEnable
		{
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.tbPaint.SetGroupEnable(2, value);
			}
		}

		public int PaintType
		{
			get
			{
				return this.PaintTypeP;
			}
			set
			{
				this.PaintTypeP = value;
				this.tbPaint.SetItemPushed(value, true);
			}
		}

		public unsafe ToolboxTerrainTools()
		{
			this.Rearranged = null;
			this.PaintTypeChanged = null;
			this.BrushParametersChanged = null;
			this.FillSelection = null;
			this.BrushColorChanged = null;
			this.InitializeComponent();
			this.ColorTool = new ColorPicker();
			this.ColorTool.ValueChanged += new ColorPicker.__Delegate_ValueChanged(this.ColorChanged);
			base.Controls.Add(this.ColorTool);
			this.BrushToolbox = new BrushTools(false);
			this.BrushToolbox.BrushParametersChanged += new BrushTools.BrushParametersChangeHandler(this.InternalBrushParamChanged);
			this.BrushToolbox.Rearranged += new ToolRearranged(this.SlidersRearranged);
			Point location = new Point(0, 36);
			this.BrushToolbox.Location = location;
			this.BrushToolbox.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
			base.Controls.Add(this.BrushToolbox);
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0ToolboxTerrainTools@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), 24);
			this.tbPaint = toolbar;
			toolbar.Dock = DockStyle.Top;
			this.tbPaint.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tbPaint_ButtonClick);
			this.tbPaint.Rearranged += new ToolRearranged(this.ToolbarRearranged);
			Size size = base.Size;
			Size size2 = new Size(base.Size.Width, size.Height);
			this.tbPaint.Size = size2;
			base.Controls.Add(this.tbPaint);
			Point location2 = this.BrushToolbox.Location;
			Point location3 = new Point(10, this.BrushToolbox.Height + location2.Y);
			this.ColorTool.Location = location3;
			this.ColorTool.Text = "Brush color";
			this.ExtraCPHeight = 0;
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
			base.Name = "ToolboxTerrainTools";
			Size size = new Size(256, 192);
			base.Size = size;
			base.Resize += new EventHandler(this.ToolboxTerrainTools_Resize);
		}

		public void ResetToNone()
		{
			this.tbPaint.SetGroupPushed(1, false);
			this.BrushToolbox.SetBrushSize1(0);
		}

		public void EmulatePush(int ordinal)
		{
			this.tbPaint.EmulatePush(ordinal);
		}

		public void EmulateUp(int ordinal)
		{
			this.tbPaint.EmulateUp(ordinal);
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

		public unsafe void SetColor(uint color)
		{
			GColor gColor = (color >> 16 & 255) * 0.003921569f;
			*(ref gColor + 4) = (color >> 8 & 255) * 0.003921569f;
			*(ref gColor + 8) = (color & 255) * 0.003921569f;
			*(ref gColor + 12) = (color >> 24) * 0.003921569f;
			int hue;
			int sat;
			int val;
			<Module>.GColor.ToHSV(ref gColor, ref hue, ref sat, ref val);
			this.ColorTool.Hue = hue;
			this.ColorTool.Sat = sat;
			this.ColorTool.Val = val;
		}

		private void ToolbarRearranged(object sender, int newheight)
		{
			Size size = base.Size;
			Size size2 = this.BrushToolbox.Size;
			if (newheight != size.Height - size2.Height)
			{
				Point location = new Point(0, newheight + 8);
				this.BrushToolbox.Location = location;
				Point location2 = this.BrushToolbox.Location;
				Point location3 = new Point(10, this.BrushToolbox.Height + location2.Y);
				this.ColorTool.Location = location3;
				Size size3 = this.BrushToolbox.Size;
				Size size4 = new Size(base.Size.Width, size3.Height + this.ExtraCPHeight + newheight);
				base.Size = size4;
				this.raise_Rearranged(sender, base.Size.Height);
			}
		}

		private void SlidersRearranged(object sender, int newheight)
		{
			Size size = base.Size;
			Size size2 = this.tbPaint.Size;
			if (newheight != size.Height - size2.Height)
			{
				Point location = this.BrushToolbox.Location;
				Point location2 = new Point(10, this.BrushToolbox.Height + location.Y);
				this.ColorTool.Location = location2;
				Size size3 = this.tbPaint.Size;
				Size size4 = new Size(base.Size.Width, size3.Height + this.ExtraCPHeight + newheight);
				base.Size = size4;
				this.raise_Rearranged(sender, base.Size.Height);
			}
		}

		private void tbPaint_ButtonClick(int idx, int radio_group)
		{
			if (radio_group == 1)
			{
				if (idx == 15 && 15 != this.PaintType)
				{
					this.ExtraCPHeight = 140;
					Size size = base.Size;
					Size size2 = new Size(base.Size.Width, size.Height + this.ExtraCPHeight);
					base.Size = size2;
					this.raise_Rearranged(this, base.Size.Height);
					this.ColorChanged();
				}
				else if (this.PaintType == 15 && idx != this.PaintType)
				{
					this.ExtraCPHeight = 0;
					Size size3 = base.Size;
					Size size4 = new Size(base.Size.Width, size3.Height + this.ExtraCPHeight);
					base.Size = size4;
					this.raise_Rearranged(this, base.Size.Height);
				}
				this.PaintType = idx;
				this.raise_PaintTypeChanged(this.PaintType);
			}
			else if (radio_group == 2)
			{
				this.raise_FillSelection(idx);
			}
		}

		private void InternalBrushParamChanged(float size1, float size2, float pressure, float height)
		{
			this.raise_BrushParametersChanged(size1, size2, pressure, height);
		}

		private void ToolboxTerrainTools_Resize(object sender, EventArgs e)
		{
			Size size = this.BrushToolbox.Size;
			Size size2 = new Size(base.Size.Width, size.Height);
			this.BrushToolbox.Size = size2;
		}

		private unsafe void ColorChanged()
		{
			GColor gColor;
			*(ref gColor + 8) = 0f;
			*(ref gColor + 4) = 0f;
			gColor = 0f;
			*(ref gColor + 12) = 1f;
			ColorPicker colorTool = this.ColorTool;
			<Module>.GColor.FromHSV(ref gColor, colorTool.Hue, colorTool.Sat, colorTool.Val);
			this.raise_BrushColorChanged(<Module>.GColor..K(ref gColor));
		}

		protected void raise_Rearranged(object i1, int i2)
		{
			ToolRearranged rearranged = this.Rearranged;
			if (rearranged != null)
			{
				rearranged(i1, i2);
			}
		}

		protected void raise_PaintTypeChanged(int i1)
		{
			ToolboxTerrainTools.__Delegate_PaintTypeChanged paintTypeChanged = this.PaintTypeChanged;
			if (paintTypeChanged != null)
			{
				paintTypeChanged(i1);
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

		protected void raise_FillSelection(int i1)
		{
			ToolboxTerrainTools.FillSelectionHandler fillSelection = this.FillSelection;
			if (fillSelection != null)
			{
				fillSelection(i1);
			}
		}

		protected void raise_BrushColorChanged(uint i1)
		{
			ToolboxTerrainTools.ColorChangedHandler brushColorChanged = this.BrushColorChanged;
			if (brushColorChanged != null)
			{
				brushColorChanged(i1);
			}
		}
	}
}
