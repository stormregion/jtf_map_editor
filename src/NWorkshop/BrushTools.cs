using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class BrushTools : UserControl, IRearrangeableControl
	{
		public delegate void BrushParametersChangeHandler(float size1, float size2, float pressure, float height);

		private Panel panPressure;

		private Label lblPressure;

		private TextBox tbPressure;

		private TrackBar trkPressure;

		private Panel panSize2;

		private Label lblSize2;

		private TextBox tbSize2;

		private TrackBar trkSize2;

		private Panel panSize1;

		private Label lblSize1;

		private TextBox tbSize1;

		private TrackBar trkSize1;

		private Panel panHeight;

		private Label lblHeight;

		private TextBox tbHeight;

		private TrackBar trkHeight;

		private Container components;

		private Toolbar BrushTypeTools;

		private float propBrushSize1;

		private float propBrushSize2;

		private float propBrushPressure;

		private float propBrushHeight;

		private bool SecondRadiusEnable;

		private bool HeightEnable;

		private bool DisableAll;

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

		public BrushTools([MarshalAs(UnmanagedType.U1)] bool secondradiusenable)
		{
			this.BrushParametersChanged = null;
			this.Rearranged = null;
			this.InitializeComponent();
			this.HeightEnable = false;
			this.SecondRadiusEnable = false;
			this.DisableAll = false;
			this.trkHeight.Maximum = 50;
			this.trkHeight.Minimum = -30;
			this.trkPressure.Maximum = 100;
			this.trkPressure.Minimum = 5;
			this.trkSize1.Maximum = 1500;
			this.trkSize1.Minimum = 25;
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
			this.panPressure = new Panel();
			this.lblPressure = new Label();
			this.tbPressure = new TextBox();
			this.trkPressure = new TrackBar();
			this.panSize2 = new Panel();
			this.lblSize2 = new Label();
			this.tbSize2 = new TextBox();
			this.trkSize2 = new TrackBar();
			this.panSize1 = new Panel();
			this.lblSize1 = new Label();
			this.tbSize1 = new TextBox();
			this.trkSize1 = new TrackBar();
			this.panHeight = new Panel();
			this.lblHeight = new Label();
			this.tbHeight = new TextBox();
			this.trkHeight = new TrackBar();
			this.panPressure.SuspendLayout();
			((ISupportInitialize)this.trkPressure).BeginInit();
			this.panSize2.SuspendLayout();
			((ISupportInitialize)this.trkSize2).BeginInit();
			this.panSize1.SuspendLayout();
			((ISupportInitialize)this.trkSize1).BeginInit();
			this.panHeight.SuspendLayout();
			((ISupportInitialize)this.trkHeight).BeginInit();
			base.SuspendLayout();
			this.panPressure.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panPressure.Controls.Add(this.lblPressure);
			this.panPressure.Controls.Add(this.tbPressure);
			this.panPressure.Controls.Add(this.trkPressure);
			Point location = new Point(0, 60);
			this.panPressure.Location = location;
			this.panPressure.Name = "panPressure";
			Size size = new Size(256, 30);
			this.panPressure.Size = size;
			this.panPressure.TabIndex = 8;
			Point location2 = new Point(0, 0);
			this.lblPressure.Location = location2;
			this.lblPressure.Name = "lblPressure";
			Size size2 = new Size(48, 24);
			this.lblPressure.Size = size2;
			this.lblPressure.TabIndex = 0;
			this.lblPressure.Text = "Pressure";
			this.lblPressure.TextAlign = ContentAlignment.MiddleRight;
			Point location3 = new Point(48, 0);
			this.tbPressure.Location = location3;
			this.tbPressure.Name = "tbPressure";
			Size size3 = new Size(40, 21);
			this.tbPressure.Size = size3;
			this.tbPressure.TabIndex = 3;
			this.tbPressure.Text = "0";
			this.tbPressure.Validated += new EventHandler(this.tbPressure_Validated);
			this.trkPressure.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			Point location4 = new Point(88, 0);
			this.trkPressure.Location = location4;
			this.trkPressure.Maximum = 100;
			this.trkPressure.Minimum = 5;
			this.trkPressure.Name = "trkPressure";
			Size size4 = new Size(168, 45);
			this.trkPressure.Size = size4;
			this.trkPressure.TabIndex = 2;
			this.trkPressure.TickFrequency = 5;
			this.trkPressure.Value = 5;
			this.trkPressure.Scroll += new EventHandler(this.trkPressure_Scroll);
			this.panSize2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panSize2.Controls.Add(this.lblSize2);
			this.panSize2.Controls.Add(this.tbSize2);
			this.panSize2.Controls.Add(this.trkSize2);
			Point location5 = new Point(0, 30);
			this.panSize2.Location = location5;
			this.panSize2.Name = "panSize2";
			Size size5 = new Size(256, 30);
			this.panSize2.Size = size5;
			this.panSize2.TabIndex = 7;
			Point location6 = new Point(0, 0);
			this.lblSize2.Location = location6;
			this.lblSize2.Name = "lblSize2";
			Size size6 = new Size(48, 24);
			this.lblSize2.Size = size6;
			this.lblSize2.TabIndex = 0;
			this.lblSize2.Text = "Falloff";
			this.lblSize2.TextAlign = ContentAlignment.MiddleRight;
			Point location7 = new Point(48, 0);
			this.tbSize2.Location = location7;
			this.tbSize2.Name = "tbSize2";
			Size size7 = new Size(40, 21);
			this.tbSize2.Size = size7;
			this.tbSize2.TabIndex = 3;
			this.tbSize2.Text = "0";
			this.tbSize2.Validated += new EventHandler(this.tbSize2_Validated);
			this.trkSize2.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			Point location8 = new Point(88, 0);
			this.trkSize2.Location = location8;
			this.trkSize2.Maximum = 100;
			this.trkSize2.Name = "trkSize2";
			Size size8 = new Size(168, 45);
			this.trkSize2.Size = size8;
			this.trkSize2.TabIndex = 2;
			this.trkSize2.TickFrequency = 5;
			this.trkSize2.Value = 25;
			this.trkSize2.Scroll += new EventHandler(this.trkSize2_Scroll);
			this.panSize1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panSize1.Controls.Add(this.lblSize1);
			this.panSize1.Controls.Add(this.tbSize1);
			this.panSize1.Controls.Add(this.trkSize1);
			Point location9 = new Point(0, 0);
			this.panSize1.Location = location9;
			this.panSize1.Name = "panSize1";
			Size size9 = new Size(256, 30);
			this.panSize1.Size = size9;
			this.panSize1.TabIndex = 6;
			Point location10 = new Point(0, 0);
			this.lblSize1.Location = location10;
			this.lblSize1.Name = "lblSize1";
			Size size10 = new Size(48, 24);
			this.lblSize1.Size = size10;
			this.lblSize1.TabIndex = 0;
			this.lblSize1.Text = "Radius";
			this.lblSize1.TextAlign = ContentAlignment.MiddleRight;
			Point location11 = new Point(48, 0);
			this.tbSize1.Location = location11;
			this.tbSize1.Name = "tbSize1";
			Size size11 = new Size(40, 21);
			this.tbSize1.Size = size11;
			this.tbSize1.TabIndex = 3;
			this.tbSize1.Text = "0";
			this.tbSize1.Validated += new EventHandler(this.tbSize1_Validated);
			this.trkSize1.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.trkSize1.LargeChange = 25;
			Point location12 = new Point(88, 0);
			this.trkSize1.Location = location12;
			this.trkSize1.Maximum = 800;
			this.trkSize1.Minimum = 25;
			this.trkSize1.Name = "trkSize1";
			Size size12 = new Size(168, 45);
			this.trkSize1.Size = size12;
			this.trkSize1.TabIndex = 2;
			this.trkSize1.TickFrequency = 50;
			this.trkSize1.Value = 25;
			this.trkSize1.Scroll += new EventHandler(this.trkSize1_Scroll);
			this.panHeight.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.panHeight.Controls.Add(this.lblHeight);
			this.panHeight.Controls.Add(this.tbHeight);
			this.panHeight.Controls.Add(this.trkHeight);
			Point location13 = new Point(0, 96);
			this.panHeight.Location = location13;
			this.panHeight.Name = "panHeight";
			Size size13 = new Size(256, 30);
			this.panHeight.Size = size13;
			this.panHeight.TabIndex = 9;
			Point location14 = new Point(0, 0);
			this.lblHeight.Location = location14;
			this.lblHeight.Name = "lblHeight";
			Size size14 = new Size(48, 24);
			this.lblHeight.Size = size14;
			this.lblHeight.TabIndex = 0;
			this.lblHeight.Text = "Height";
			this.lblHeight.TextAlign = ContentAlignment.MiddleRight;
			Point location15 = new Point(48, 0);
			this.tbHeight.Location = location15;
			this.tbHeight.Name = "tbHeight";
			Size size15 = new Size(40, 21);
			this.tbHeight.Size = size15;
			this.tbHeight.TabIndex = 3;
			this.tbHeight.Text = "0";
			this.tbHeight.Validated += new EventHandler(this.tbHeight_Validated);
			this.trkHeight.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			Point location16 = new Point(88, 0);
			this.trkHeight.Location = location16;
			this.trkHeight.Maximum = 50;
			this.trkHeight.Minimum = 20;
			this.trkHeight.Name = "trkHeight";
			Size size16 = new Size(168, 45);
			this.trkHeight.Size = size16;
			this.trkHeight.TabIndex = 2;
			this.trkHeight.TickFrequency = 5;
			this.trkHeight.Value = 20;
			this.trkHeight.Scroll += new EventHandler(this.trkHeight_Scroll);
			base.Controls.Add(this.panHeight);
			base.Controls.Add(this.panPressure);
			base.Controls.Add(this.panSize2);
			base.Controls.Add(this.panSize1);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 238);
			base.Name = "BrushTools";
			Size size17 = new Size(256, 136);
			base.Size = size17;
			base.Resize += new EventHandler(this.BrushTools_Resize);
			base.Load += new EventHandler(this.BrushTools_Load);
			this.panPressure.ResumeLayout(false);
			((ISupportInitialize)this.trkPressure).EndInit();
			this.panSize2.ResumeLayout(false);
			((ISupportInitialize)this.trkSize2).EndInit();
			this.panSize1.ResumeLayout(false);
			((ISupportInitialize)this.trkSize1).EndInit();
			this.panHeight.ResumeLayout(false);
			((ISupportInitialize)this.trkHeight).EndInit();
			base.ResumeLayout(false);
		}

		public void SetBrushSize1(ref float val)
		{
			if (ref val == null)
			{
				this.lblSize1.Enabled = false;
				this.tbSize1.Enabled = false;
				this.trkSize1.Enabled = false;
				this.DisableAll = true;
			}
			else
			{
				this.lblSize1.Enabled = true;
				this.tbSize1.Enabled = true;
				this.trkSize1.Enabled = true;
				this.tbSize1.Text = val.ToString();
				float num;
				if (val < 30f)
				{
					num = <Module>.fround(val * 50f);
				}
				else
				{
					num = 1500f;
				}
				this.trkSize1.Value = (int)((double)num);
				this.DisableAll = false;
			}
			this.propBrushSize1 = (float)this.trkSize1.Value * 0.02f;
			this.Rearrange();
		}

		public void SetBrushSize2(ref float val)
		{
			if (ref val == null)
			{
				this.lblSize2.Enabled = false;
				this.tbSize2.Enabled = false;
				this.trkSize2.Enabled = false;
				this.SecondRadiusEnable = false;
			}
			else
			{
				this.lblSize2.Enabled = true;
				this.tbSize2.Enabled = true;
				this.trkSize2.Enabled = true;
				this.trkSize2.Value = (int)((double)val);
				this.tbSize2.Text = ((int)this.trkSize2.Value).ToString() + " %";
				this.SecondRadiusEnable = true;
			}
			this.propBrushSize2 = (float)this.trkSize2.Value;
			this.Rearrange();
		}

		public void SetBrushPressure(ref float val)
		{
			if (ref val == null)
			{
				this.lblPressure.Enabled = false;
				this.tbPressure.Enabled = false;
				this.trkPressure.Enabled = false;
			}
			else
			{
				this.lblPressure.Enabled = true;
				this.tbPressure.Enabled = true;
				this.trkPressure.Enabled = true;
				this.tbPressure.Text = ((int)<Module>.fround(val)).ToString();
				this.trkPressure.Value = (int)((double)val);
			}
			this.propBrushPressure = (float)this.trkPressure.Value;
		}

		public void SetBrushHeight(ref float val)
		{
			if (ref val == null)
			{
				this.lblHeight.Enabled = false;
				this.tbHeight.Enabled = false;
				this.trkHeight.Enabled = false;
				this.HeightEnable = false;
			}
			else
			{
				this.lblHeight.Enabled = true;
				this.tbHeight.Enabled = true;
				this.trkHeight.Enabled = true;
				this.tbHeight.Text = ((int)<Module>.fround(val)).ToString();
				this.trkHeight.Value = (int)((double)val);
				this.HeightEnable = true;
			}
			this.propBrushHeight = (float)this.trkHeight.Value;
			this.Rearrange();
		}

		public void trkSize1_Scroll(object sender, EventArgs e)
		{
			float i = (float)this.trkSize1.Value * 0.02f;
			this.propBrushSize1 = i;
			this.raise_BrushParametersChanged(i, this.propBrushSize2, this.propBrushPressure, this.propBrushHeight);
		}

		public void trkSize2_Scroll(object sender, EventArgs e)
		{
			float i = (float)this.trkSize2.Value;
			this.propBrushSize2 = i;
			this.raise_BrushParametersChanged(this.propBrushSize1, i, this.propBrushPressure, this.propBrushHeight);
		}

		public void trkPressure_Scroll(object sender, EventArgs e)
		{
			float i = (float)this.trkPressure.Value;
			this.propBrushPressure = i;
			this.raise_BrushParametersChanged(this.propBrushSize1, this.propBrushSize2, i, this.propBrushHeight);
		}

		private void BrushTools_Load(object sender, EventArgs e)
		{
			this.Rearrange();
		}

		private void Rearrange()
		{
			if (this.DisableAll)
			{
				Size size = new Size(base.Size.Width, 8);
				base.Size = size;
			}
			else if (this.SecondRadiusEnable)
			{
				this.panSize2.Show();
				Point location = this.panSize2.Location;
				Point location2 = new Point(0, this.panSize2.Size.Height + location.Y);
				this.panPressure.Location = location2;
				if (this.HeightEnable)
				{
					this.panHeight.Show();
					Point location3 = this.panPressure.Location;
					Point location4 = new Point(0, this.panPressure.Size.Height + location3.Y);
					this.panHeight.Location = location4;
					Size size2 = new Size(base.Size.Width, 136);
					base.Size = size2;
				}
				else
				{
					this.panHeight.Hide();
					Size size3 = new Size(base.Size.Width, 104);
					base.Size = size3;
				}
			}
			else
			{
				this.panSize2.Hide();
				Point location5 = this.panSize2.Location;
				this.panPressure.Location = location5;
				if (this.HeightEnable)
				{
					this.panHeight.Show();
					Point location6 = this.panPressure.Location;
					Point location7 = new Point(0, this.panPressure.Size.Height + location6.Y);
					this.panHeight.Location = location7;
					Size size4 = new Size(base.Size.Width, 106);
					base.Size = size4;
				}
				else
				{
					this.panHeight.Hide();
					Size size5 = new Size(base.Size.Width, 74);
					base.Size = size5;
				}
			}
			this.raise_Rearranged(this, base.Size.Height);
		}

		private void trkHeight_Scroll(object sender, EventArgs e)
		{
			float i = (float)this.trkHeight.Value;
			this.propBrushHeight = i;
			this.raise_BrushParametersChanged(this.propBrushSize1, this.propBrushSize2, this.propBrushPressure, i);
		}

		private void BrushTools_Resize(object sender, EventArgs e)
		{
		}

		private unsafe void tbHeight_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.tbHeight.Text);
				goto IL_71;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_71:
			if (num2 > 50)
			{
				num2 = 50;
			}
			else if (num2 < -30)
			{
				num2 = -30;
			}
			float i = (float)num2;
			this.propBrushHeight = i;
			this.raise_BrushParametersChanged(this.propBrushSize1, this.propBrushSize2, this.propBrushPressure, i);
		}

		private unsafe void tbPressure_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.tbPressure.Text);
				goto IL_71;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_71:
			if (num2 > 100)
			{
				num2 = 100;
			}
			else if (num2 < 5)
			{
				num2 = 5;
			}
			float i = (float)num2;
			this.propBrushPressure = i;
			this.raise_BrushParametersChanged(this.propBrushSize1, this.propBrushSize2, i, this.propBrushHeight);
		}

		private unsafe void tbSize2_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.tbSize2.Text);
				goto IL_71;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_71:
			if (num2 > 100)
			{
				num2 = 100;
			}
			else if (num2 < 0)
			{
				num2 = 0;
			}
			float i = (float)num2;
			this.propBrushSize2 = i;
			this.raise_BrushParametersChanged(this.propBrushSize1, i, this.propBrushPressure, this.propBrushHeight);
		}

		private unsafe void tbSize1_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.tbSize1.Text);
				goto IL_71;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_71:
			float num3 = (float)num2;
			if (num3 > 30f)
			{
				num2 = 30;
			}
			else if (num3 < 0.5f)
			{
				num2 = 0;
			}
			num3 = (float)num2;
			this.propBrushSize1 = num3;
			this.raise_BrushParametersChanged(num3, this.propBrushSize2, this.propBrushPressure, this.propBrushHeight);
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
	}
}
