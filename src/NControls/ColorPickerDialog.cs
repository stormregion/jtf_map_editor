using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class ColorPickerDialog : Form
	{
		private Button OKBtn;

		private Button CancelBtn;

		private ColorPicker ColorPicker;

		private SliderPanel AlfaSlider;

		private Container components;

		public ColorPickerDialog()
		{
			this.InitializeComponent();
			this.ColorPicker = new ColorPicker();
			Point location = new Point(10, 10);
			this.ColorPicker.Location = location;
			base.Controls.Add(this.ColorPicker);
			SliderPanel sliderPanel = new SliderPanel(0, 255, 15);
			this.AlfaSlider = sliderPanel;
			sliderPanel.Text = "Alfa";
			Size sz = new Size(0, this.ColorPicker.Height + 6);
			Point location2 = this.ColorPicker.Location + sz;
			this.AlfaSlider.Location = location2;
			base.Controls.Add(this.AlfaSlider);
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
			this.OKBtn = new Button();
			this.CancelBtn = new Button();
			base.SuspendLayout();
			this.OKBtn.DialogResult = DialogResult.OK;
			Point location = new Point(8, 176);
			this.OKBtn.Location = location;
			this.OKBtn.Name = "OKBtn";
			Size size = new Size(120, 23);
			this.OKBtn.Size = size;
			this.OKBtn.TabIndex = 0;
			this.OKBtn.Text = "Accept";
			this.CancelBtn.DialogResult = DialogResult.Cancel;
			Point location2 = new Point(136, 176);
			this.CancelBtn.Location = location2;
			this.CancelBtn.Name = "CancelBtn";
			Size size2 = new Size(120, 23);
			this.CancelBtn.Size = size2;
			this.CancelBtn.TabIndex = 1;
			this.CancelBtn.Text = "Cancel";
			base.AcceptButton = this.OKBtn;
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			base.CancelButton = this.CancelBtn;
			Size clientSize = new Size(264, 210);
			base.ClientSize = clientSize;
			base.ControlBox = false;
			base.Controls.Add(this.CancelBtn);
			base.Controls.Add(this.OKBtn);
			base.Name = "ColorPickerDialog";
			base.SizeGripStyle = SizeGripStyle.Hide;
			this.Text = "Calibrate color";
			base.ResumeLayout(false);
		}

		public unsafe void SetRGBA(float r, float g, float b, float a)
		{
			GColor gColor = r;
			*(ref gColor + 4) = g;
			*(ref gColor + 8) = b;
			*(ref gColor + 12) = a;
			<Module>.GColor.Saturate(ref gColor);
			int hue;
			int sat;
			int val;
			<Module>.GColor.ToHSV(ref gColor, ref hue, ref sat, ref val);
			this.ColorPicker.Hue = hue;
			this.ColorPicker.Sat = sat;
			this.ColorPicker.Val = val;
			this.AlfaSlider.Value = <Module>.ffloor(a * 255f);
		}

		public unsafe void GetRGBA(float* r, float* g, float* b, float* a)
		{
			GColor gColor;
			*(ref gColor + 8) = 0f;
			*(ref gColor + 4) = 0f;
			gColor = 0f;
			*(ref gColor + 12) = 1f;
			ColorPicker colorPicker = this.ColorPicker;
			<Module>.GColor.FromHSV(ref gColor, colorPicker.Hue, colorPicker.Sat, colorPicker.Val);
			*r = gColor;
			*g = *(ref gColor + 4);
			*b = *(ref gColor + 8);
			*a = (float)this.AlfaSlider.Value * 0.003921569f;
		}
	}
}
