using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class SliderPanel : Control
	{
		public delegate void __Delegate_ValueChanged();

		private Container components;

		private Label lblValue;

		private TextBox tbValue;

		private TrackBar trkValue;

		private Bitmap SliderPanelBitmap;

		private int propValue;

		private int MinimumValue;

		private int MaximumValue;

		public event SliderPanel.__Delegate_ValueChanged ValueChanged
		{
			add
			{
				this.ValueChanged = Delegate.Combine(this.ValueChanged, value);
			}
			remove
			{
				this.ValueChanged = Delegate.Remove(this.ValueChanged, value);
			}
		}

		public override string Text
		{
			set
			{
				base.Text = value;
				Label label = this.lblValue;
				if (label != null)
				{
					label.Text = value;
				}
			}
		}

		public int Value
		{
			get
			{
				return this.propValue;
			}
			set
			{
				this.propValue = value;
				int num = value;
				this.tbValue.Text = num.ToString();
				this.trkValue.Value = value;
			}
		}

		public SliderPanel(int min_value, int max_value, int tick_frequency)
		{
			this.ValueChanged = null;
			int num = (0 > min_value) ? 0 : min_value;
			int num2;
			if (num < max_value)
			{
				num2 = num;
			}
			else
			{
				num2 = max_value;
			}
			this.propValue = num2;
			this.MinimumValue = min_value;
			this.MaximumValue = max_value;
			this.InitializeComponent();
			this.lblValue = new Label();
			Point location = new Point(0, 1);
			this.lblValue.Location = location;
			this.lblValue.Name = "lblValue";
			Size size = new Size(48, 21);
			this.lblValue.Size = size;
			this.lblValue.TabIndex = 0;
			this.lblValue.Text = "Value";
			this.lblValue.TextAlign = ContentAlignment.MiddleRight;
			base.Controls.Add(this.lblValue);
			this.tbValue = new TextBox();
			Point location2 = new Point(48, 1);
			this.tbValue.Location = location2;
			this.tbValue.Name = "tbValue";
			Size size2 = new Size(32, 21);
			this.tbValue.Size = size2;
			this.tbValue.TabIndex = 3;
			this.tbValue.Text = "0";
			this.tbValue.Validated += new EventHandler(this.tbValue_Validated);
			base.Controls.Add(this.tbValue);
			TrackBar trackBar = new TrackBar();
			this.trkValue = trackBar;
			trackBar.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			Point location3 = new Point(80, 0);
			this.trkValue.Location = location3;
			this.trkValue.Maximum = this.MaximumValue;
			this.trkValue.Minimum = this.MinimumValue;
			this.trkValue.Name = "trkValue";
			Size size3 = new Size(168, 45);
			this.trkValue.Size = size3;
			this.trkValue.TabIndex = 2;
			this.trkValue.TickFrequency = tick_frequency;
			this.trkValue.Value = this.propValue;
			this.trkValue.Scroll += new EventHandler(this.trkValue_Scroll);
			base.Controls.Add(this.trkValue);
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
			this.components = new Container();
			Size size = new Size(256, 28);
			base.Size = size;
			this.Text = "SliderPanel";
		}

		private unsafe void tbValue_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.tbValue.Text);
				goto IL_72;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_72:
			int maximumValue = this.MaximumValue;
			if (num2 > maximumValue)
			{
				num2 = maximumValue;
			}
			else
			{
				int minimumValue = this.MinimumValue;
				if (num2 < minimumValue)
				{
					num2 = minimumValue;
				}
			}
			this.propValue = num2;
			int num3 = num2;
			this.tbValue.Text = num3.ToString();
			this.trkValue.Value = this.propValue;
			this.raise_ValueChanged();
		}

		private void trkValue_Scroll(object sender, EventArgs e)
		{
			int value = this.trkValue.Value;
			this.propValue = value;
			int num = value;
			this.tbValue.Text = num.ToString();
			this.raise_ValueChanged();
		}

		protected void raise_ValueChanged()
		{
			SliderPanel.__Delegate_ValueChanged valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged();
			}
		}
	}
}
