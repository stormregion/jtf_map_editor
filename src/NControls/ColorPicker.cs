using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class ColorPicker : Control
	{
		private enum DragType
		{
			DRAG_SATVAL = 2,
			DRAG_HUE = 1,
			DRAG_NONE = 0
		}

		private enum DisplayMode
		{
			DISPLAY_TRACKBARS = 1,
			DISPLAY_GRAPHS = 0
		}

		public delegate void __Delegate_ValueChanged();

		public Brush BackgroundBrush;

		public Brush MarkerBrush;

		private Container components;

		private Panel panColor;

		private Label lblHue;

		private TextBox tbHue;

		private Label lblSat;

		private TextBox tbSat;

		private Label lblVal;

		private TextBox tbVal;

		private Label lblText;

		private Panel panHue;

		private Panel panSat;

		private Panel panVal;

		private NSolidPanel panHueColor;

		private NSolidPanel panSatColor;

		private NSolidPanel panValColor;

		private TrackBar trkHue;

		private TrackBar trkSat;

		private TrackBar trkVal;

		private Toolbar ModeSelector;

		private Bitmap ColorPickerBitmap;

		private Bitmap TrackbarBitmap;

		private int propHue;

		private int propSat;

		private int propVal;

		private ColorPicker.DragType DragType;

		private ColorPicker.DisplayMode DisplayMode;

		public event ColorPicker.__Delegate_ValueChanged ValueChanged
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
				Label label = this.lblText;
				if (label != null)
				{
					label.Text = value;
				}
			}
		}

		public int Val
		{
			get
			{
				return this.propVal;
			}
			set
			{
				this.propVal = value;
				int num = value;
				this.tbVal.Text = num.ToString();
				this.trkVal.Value = value;
				this.ColorPickerBitmap = null;
				this.UpdatePanelColor();
				base.Invalidate();
			}
		}

		public int Sat
		{
			get
			{
				return this.propSat;
			}
			set
			{
				this.propSat = value;
				int num = value;
				this.tbSat.Text = num.ToString();
				this.trkSat.Value = value;
				this.ColorPickerBitmap = null;
				this.UpdatePanelColor();
				base.Invalidate();
			}
		}

		public int Hue
		{
			get
			{
				return this.propHue;
			}
			set
			{
				this.propHue = value;
				int num = value;
				this.tbHue.Text = num.ToString();
				this.trkHue.Value = value;
				this.ColorPickerBitmap = null;
				this.UpdatePanelColor();
				base.Invalidate();
			}
		}

		public ColorPicker()
		{
			this.ValueChanged = null;
			this.propHue = 0;
			this.propSat = 100;
			this.propVal = 100;
			this.DragType = ColorPicker.DragType.DRAG_NONE;
			this.InitializeComponent();
			this.InitializeComponent2();
			Color color = Color.FromKnownColor(KnownColor.Control);
			this.BackgroundBrush = new SolidBrush(color);
			Color color2 = Color.FromKnownColor(KnownColor.Black);
			this.MarkerBrush = new SolidBrush(color2);
			this.TrackbarBitmap = new Bitmap(142, 15);
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
			Size size = new Size(256, 120);
			base.Size = size;
			this.Text = "ColorPicker";
		}

		private unsafe void InitializeComponent2()
		{
			this.lblText = new Label();
			Point location = new Point(0, 0);
			this.lblText.Location = location;
			this.lblText.Name = "lblText";
			Size size = new Size(80, 15);
			this.lblText.Size = size;
			this.lblText.TabIndex = 0;
			this.lblText.Font = this.Font;
			this.lblText.Text = this.Text;
			this.lblText.TextAlign = ContentAlignment.TopCenter;
			base.Controls.Add(this.lblText);
			this.panColor = new Panel();
			Point location2 = new Point(0, 15);
			this.panColor.Location = location2;
			Size size2 = new Size(80, 21);
			this.panColor.Size = size2;
			this.panColor.BorderStyle = BorderStyle.Fixed3D;
			base.Controls.Add(this.panColor);
			this.UpdatePanelColor();
			this.lblHue = new Label();
			Point location3 = new Point(0, 43);
			this.lblHue.Location = location3;
			this.lblHue.Name = "lblHue";
			Size size3 = new Size(48, 21);
			this.lblHue.Size = size3;
			this.lblHue.TabIndex = 0;
			this.lblHue.Font = this.Font;
			this.lblHue.Text = "Hue";
			this.lblHue.TextAlign = ContentAlignment.MiddleRight;
			base.Controls.Add(this.lblHue);
			this.tbHue = new TextBox();
			Point location4 = new Point(48, 43);
			this.tbHue.Location = location4;
			this.tbHue.Name = "tbHue";
			Size size4 = new Size(32, 21);
			this.tbHue.Size = size4;
			this.tbHue.TabIndex = 1;
			int hue = this.Hue;
			this.tbHue.Text = hue.ToString();
			this.tbHue.Validated += new EventHandler(this.tbHue_Validated);
			base.Controls.Add(this.tbHue);
			this.lblSat = new Label();
			Point location5 = new Point(0, 71);
			this.lblSat.Location = location5;
			this.lblSat.Name = "lblSat";
			Size size5 = new Size(48, 21);
			this.lblSat.Size = size5;
			this.lblSat.TabIndex = 2;
			this.lblSat.Font = this.Font;
			this.lblSat.Text = "Sat";
			this.lblSat.TextAlign = ContentAlignment.MiddleRight;
			base.Controls.Add(this.lblSat);
			this.tbSat = new TextBox();
			Point location6 = new Point(48, 71);
			this.tbSat.Location = location6;
			this.tbSat.Name = "tbSat";
			Size size6 = new Size(32, 21);
			this.tbSat.Size = size6;
			this.tbSat.TabIndex = 3;
			int sat = this.Sat;
			this.tbSat.Text = sat.ToString();
			this.tbSat.Validated += new EventHandler(this.tbSat_Validated);
			base.Controls.Add(this.tbSat);
			this.lblVal = new Label();
			Point location7 = new Point(0, 99);
			this.lblVal.Location = location7;
			this.lblVal.Name = "lblVal";
			Size size7 = new Size(48, 21);
			this.lblVal.Size = size7;
			this.lblVal.TabIndex = 4;
			this.lblVal.Font = this.Font;
			this.lblVal.Text = "Val";
			this.lblVal.TextAlign = ContentAlignment.MiddleRight;
			base.Controls.Add(this.lblVal);
			this.tbVal = new TextBox();
			Point location8 = new Point(48, 99);
			this.tbVal.Location = location8;
			this.tbVal.Name = "tbVal";
			Size size8 = new Size(32, 21);
			this.tbVal.Size = size8;
			this.tbVal.TabIndex = 5;
			int val = this.Val;
			this.tbVal.Text = val.ToString();
			this.tbVal.Validated += new EventHandler(this.tbVal_Validated);
			base.Controls.Add(this.tbVal);
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?A0x2cec50cb.?items@?1??InitializeComponent2@ColorPicker@NControls@@A$AAMXXZ@4PAUGToolbarItem@3@A), 16);
			this.ModeSelector = toolbar;
			toolbar.Dock = DockStyle.None;
			this.ModeSelector.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tb_ModeSelector_Pushed);
			Size size9 = new Size(22, 20);
			this.ModeSelector.Size = size9;
			Point location9 = new Point(base.Size.Width - 36, 0);
			this.ModeSelector.Location = location9;
			base.Controls.Add(this.ModeSelector);
			this.panHue = new Panel();
			Point location10 = new Point(80, 36);
			this.panHue.Location = location10;
			Size size10 = new Size(168, 28);
			this.panHue.Size = size10;
			this.panHue.TabIndex = 0;
			this.panSat = new Panel();
			Point location11 = new Point(80, 64);
			this.panSat.Location = location11;
			Size size11 = new Size(168, 28);
			this.panSat.Size = size11;
			this.panSat.TabIndex = 0;
			this.panVal = new Panel();
			Point location12 = new Point(80, 92);
			this.panVal.Location = location12;
			Size size12 = new Size(168, 28);
			this.panVal.Size = size12;
			this.panVal.TabIndex = 0;
			this.panHueColor = new NSolidPanel();
			Point location13 = new Point(13, 1);
			this.panHueColor.Location = location13;
			Size size13 = new Size(142, 5);
			this.panHueColor.Size = size13;
			this.panHueColor.TabIndex = 0;
			this.panHueColor.Paint += new PaintEventHandler(this.trkHue_Paint);
			this.panSatColor = new NSolidPanel();
			Point location14 = new Point(13, 1);
			this.panSatColor.Location = location14;
			Size size14 = new Size(142, 5);
			this.panSatColor.Size = size14;
			this.panSatColor.TabIndex = 0;
			this.panSatColor.Paint += new PaintEventHandler(this.trkSat_Paint);
			this.panValColor = new NSolidPanel();
			Point location15 = new Point(13, 1);
			this.panValColor.Location = location15;
			Size size15 = new Size(142, 5);
			this.panValColor.Size = size15;
			this.panValColor.TabIndex = 0;
			this.panValColor.Paint += new PaintEventHandler(this.trkVal_Paint);
			this.trkHue = new TrackBar();
			Point location16 = new Point(0, -3);
			this.trkHue.Location = location16;
			this.trkHue.Maximum = 359;
			this.trkHue.Minimum = 0;
			this.trkHue.Name = "trkHue";
			Size size16 = new Size(168, 45);
			this.trkHue.Size = size16;
			this.trkHue.TabIndex = 6;
			this.trkHue.TickStyle = TickStyle.TopLeft;
			this.trkHue.TickFrequency = 360;
			this.trkHue.Value = this.Hue;
			this.trkHue.Scroll += new EventHandler(this.trkHue_Scroll);
			this.trkSat = new TrackBar();
			Point location17 = new Point(0, -3);
			this.trkSat.Location = location17;
			this.trkSat.Maximum = 100;
			this.trkSat.Minimum = 0;
			this.trkSat.Name = "trkHue";
			Size size17 = new Size(168, 45);
			this.trkSat.Size = size17;
			this.trkSat.TabIndex = 6;
			this.trkSat.TickStyle = TickStyle.TopLeft;
			this.trkSat.TickFrequency = 100;
			this.trkSat.Value = this.Sat;
			this.trkSat.Scroll += new EventHandler(this.trkSat_Scroll);
			this.trkVal = new TrackBar();
			Point location18 = new Point(0, -3);
			this.trkVal.Location = location18;
			this.trkVal.Maximum = 100;
			this.trkVal.Minimum = 0;
			this.trkVal.Name = "trkHue";
			Size size18 = new Size(168, 45);
			this.trkVal.Size = size18;
			this.trkVal.TabIndex = 6;
			this.trkVal.TickStyle = TickStyle.TopLeft;
			this.trkVal.TickFrequency = 100;
			this.trkVal.Value = this.Val;
			this.trkVal.Scroll += new EventHandler(this.trkVal_Scroll);
			this.panHue.Controls.Add(this.panHueColor);
			this.panSat.Controls.Add(this.panSatColor);
			this.panVal.Controls.Add(this.panValColor);
			this.panHue.Controls.Add(this.trkHue);
			this.panSat.Controls.Add(this.trkSat);
			this.panVal.Controls.Add(this.trkVal);
			base.Controls.Add(this.panHue);
			base.Controls.Add(this.panSat);
			base.Controls.Add(this.panVal);
		}

		private unsafe Bitmap CalculateColorPickerBitmap(float hue)
		{
			Bitmap bitmap = new Bitmap(120, 120);
			Color color = Color.FromKnownColor(KnownColor.Control);
			float num = hue * -0.0174532924f;
			double num2 = (double)num;
			float num3 = (float)Math.Cos(num2);
			GLine gLine = (float)Math.Sin(num2);
			double num4 = (double)(num + 2.09439516f);
			float num5 = (float)Math.Cos(num4);
			float num6 = num5;
			float num7 = (float)Math.Sin(num4);
			GLine gLine2 = num7;
			double num8 = (double)(num - 2.09439516f);
			float num9 = (float)Math.Cos(num8);
			GLine gLine3 = (float)Math.Sin(num8);
			int num10 = 0;
			do
			{
				float num11 = (float)(num10 - 60);
				float num12 = num11 + 0.5f;
				int num13 = -60;
				do
				{
					float num14 = num12;
					float num15 = (float)num13;
					float num16 = num15 + 0.5f;
					float num17 = num16;
					float expr_AC = num17;
					float arg_B2_0 = expr_AC * expr_AC;
					float expr_B0 = num14;
					float num18 = arg_B2_0 + expr_B0 * expr_B0;
					if (num18 > 3685.353f)
					{
						bitmap.SetPixel(num13 + 60, num10, color);
					}
					else if (num18 < 2236.61768f)
					{
						int num19 = 0;
						int num20 = 0;
						float num21 = num15 + 0.125f;
						float num22 = num15 + 0.375f;
						float num23 = num15 + 0.625f;
						float num24 = num15 + 0.875f;
						do
						{
							GPoint2 gPoint = num21;
							float num25 = ((float)num20 + 0.5f) * 0.25f + num11;
							*(ref gPoint + 4) = num25;
							if (*(ref gPoint + 4) * num3 + gPoint * gLine - 22.5f < 0f && gPoint * gLine2 + *(ref gPoint + 4) * num6 - 22.5f < 0f && gPoint * gLine3 + *(ref gPoint + 4) * num9 - 22.5f < 0f)
							{
								num19++;
							}
							gPoint = num22;
							*(ref gPoint + 4) = num25;
							if (*(ref gPoint + 4) * num3 + gPoint * gLine - 22.5f < 0f && gPoint * gLine2 + *(ref gPoint + 4) * num6 - 22.5f < 0f && gPoint * gLine3 + *(ref gPoint + 4) * num9 - 22.5f < 0f)
							{
								num19++;
							}
							gPoint = num23;
							*(ref gPoint + 4) = num25;
							if (*(ref gPoint + 4) * num3 + gPoint * gLine - 22.5f < 0f && gPoint * gLine2 + *(ref gPoint + 4) * num6 - 22.5f < 0f && gPoint * gLine3 + *(ref gPoint + 4) * num9 - 22.5f < 0f)
							{
								num19++;
							}
							gPoint = num24;
							*(ref gPoint + 4) = num25;
							if (*(ref gPoint + 4) * num3 + gPoint * gLine - 22.5f < 0f && gPoint * gLine2 + *(ref gPoint + 4) * num6 - 22.5f < 0f && gPoint * gLine3 + *(ref gPoint + 4) * num9 - 22.5f < 0f)
							{
								num19++;
							}
							num20++;
						}
						while (num20 < 4);
						if (num19 != 0)
						{
							GPoint2 gPoint2 = num16;
							*(ref gPoint2 + 4) = num12;
							float num26 = num5;
							float num27 = num7;
							float num28 = (num27 * gPoint2 + num26 * *(ref gPoint2 + 4) + 45f) * 0.0148148146f;
							float num29;
							if (num28 <= 0f)
							{
								num29 = 0f;
								goto IL_32A;
							}
							num29 = num28;
							if (num28 < 1f)
							{
								goto IL_32A;
							}
							float num30 = 1f;
							IL_337:
							double num31 = (double)(num + 3.66519165f);
							float num32 = (float)Math.Cos(num31);
							float num33 = (float)Math.Sin(num31);
							float num34 = num33 * gPoint2 + num32 * *(ref gPoint2 + 4);
							if (num30 <= 0.001f)
							{
								goto IL_3A2;
							}
							num34 = num34 / num30 * 0.0222222228f / (float)Math.Sqrt(3.0) + 0.5f;
							if (num34 <= 0f)
							{
								goto IL_3A2;
							}
							float num35 = num34;
							if (num34 < 1f)
							{
								goto IL_3B4;
							}
							float num36 = 1f;
							IL_3C1:
							GColor gColor;
							*(ref gColor + 8) = 0f;
							*(ref gColor + 4) = 0f;
							gColor = 0f;
							*(ref gColor + 12) = 1f;
							<Module>.GColor.FromHSV(ref gColor, (int)((double)hue), (int)((double)(num36 * 100f)), (int)((double)(num30 * 100f)));
							if (num19 == 16)
							{
								Color color2 = Color.FromArgb(255, (int)(gColor * 255f), (int)((double)(*(ref gColor + 4) * 255f)), (int)((double)(*(ref gColor + 8) * 255f)));
								bitmap.SetPixel(num13 + 60, num10, color2);
								goto IL_8D1;
							}
							float num37 = (float)num19 * 0.0625f;
							float num38 = 1f - num37;
							Color color3 = Color.FromArgb(255, (int)((float)color.R * num38 + num37 * gColor * 255f), (int)((double)((float)color.G * num38 + num37 * *(ref gColor + 4) * 255f)), (int)((double)((float)color.B * num38 + num37 * *(ref gColor + 8) * 255f)));
							bitmap.SetPixel(num13 + 60, num10, color3);
							goto IL_8D1;
							IL_3B4:
							num36 = num35;
							goto IL_3C1;
							IL_3A2:
							num35 = 0f;
							goto IL_3B4;
							IL_32A:
							num30 = num29;
							goto IL_337;
						}
						bitmap.SetPixel(num13 + 60, num10, color);
					}
					else
					{
						int num39 = 0;
						int num40 = 0;
						float num21 = num15 + 0.125f;
						float num22 = num15 + 0.375f;
						float num23 = num15 + 0.625f;
						float num24 = num15 + 0.875f;
						do
						{
							float num41 = ((float)num40 + 0.5f) * 0.25f + num11;
							float num42 = num41;
							float num43 = num21;
							float expr_534 = num43;
							float arg_53A_0 = expr_534 * expr_534;
							float expr_538 = num42;
							float num44 = arg_53A_0 + expr_538 * expr_538;
							if (num44 < 3600f && num44 > 2304f)
							{
								num39++;
							}
							num42 = num41;
							num43 = num22;
							float expr_55A = num43;
							float arg_560_0 = expr_55A * expr_55A;
							float expr_55E = num42;
							num44 = arg_560_0 + expr_55E * expr_55E;
							if (num44 < 3600f && num44 > 2304f)
							{
								num39++;
							}
							num42 = num41;
							num43 = num23;
							float expr_580 = num43;
							float arg_586_0 = expr_580 * expr_580;
							float expr_584 = num42;
							num44 = arg_586_0 + expr_584 * expr_584;
							if (num44 < 3600f && num44 > 2304f)
							{
								num39++;
							}
							num42 = num41;
							num43 = num24;
							float expr_5A6 = num43;
							float arg_5AC_0 = expr_5A6 * expr_5A6;
							float expr_5AA = num42;
							num44 = arg_5AC_0 + expr_5AA * expr_5AA;
							if (num44 < 3600f && num44 > 2304f)
							{
								num39++;
							}
							num40++;
						}
						while (num40 < 4);
						if (num39 != 0)
						{
							float num45 = (float)(Math.Atan2((double)(num10 - 60) + 0.5, (double)num13 + 0.5) * 57.295780181884766 + 90.0);
							if (num45 < 0f)
							{
								num45 += 360f;
							}
							GColor gColor2;
							*(ref gColor2 + 8) = 0f;
							*(ref gColor2 + 4) = 0f;
							gColor2 = 0f;
							*(ref gColor2 + 12) = 1f;
							<Module>.GColor.FromHSV(ref gColor2, (int)((double)num45), 100, 100);
							float num46 = num16;
							float num47 = num12;
							float expr_660 = num47;
							double arg_666_0 = (double)(expr_660 * expr_660);
							float expr_664 = num46;
							float num48 = (float)Math.Sqrt(arg_666_0 + (double)(expr_664 * expr_664));
							float num49 = 1f / num48;
							num46 *= num49;
							num47 *= num49;
							if (num48 > 58f)
							{
								float num50 = num48 - 58f;
								num46 = num46 * num50 * 0.5f;
								num47 = num47 * num50 * 0.5f;
							}
							else if (num48 < 50f)
							{
								float num51 = num48 - 50f;
								num46 = num46 * num51 * 0.5f;
								num47 = num47 * num51 * 0.5f;
							}
							else
							{
								num46 = 0f;
								num47 = 0f;
							}
							GVector3 gVector = num46;
							*(ref gVector + 4) = num47;
							*(ref gVector + 8) = 1f;
							<Module>.GVector3.Normalize(ref gVector);
							GVector3 gVector2 = -0.707106769f;
							*(ref gVector2 + 4) = -0.707106769f;
							*(ref gVector2 + 8) = 1f;
							<Module>.GVector3.Normalize(ref gVector2);
							float num52 = *(ref gVector2 + 8) * *(ref gVector + 8);
							float num53 = gVector2 * gVector;
							float num54 = *(ref gVector2 + 4) * *(ref gVector + 4);
							float num55 = 1f - num52 + num54 + num53 + num52;
							float num56 = num54 + num53 + num52;
							float num57;
							if (num56 > 0f)
							{
								num57 = num56;
							}
							else
							{
								num57 = 0f;
							}
							float num58 = num57;
							uint num59 = 16u;
							float num60 = 1f;
							while (true)
							{
								if ((num59 & 1u) != 0u)
								{
									num60 *= num58;
								}
								num59 >>= 1;
								if (num59 == 0u)
								{
									break;
								}
								float expr_7B4 = num58;
								num58 = expr_7B4 * expr_7B4;
							}
							float num61 = num60 * 2f;
							gColor2 = gColor2 * num55 + num61;
							*(ref gColor2 + 4) = *(ref gColor2 + 4) * num55 + num61;
							*(ref gColor2 + 8) = *(ref gColor2 + 8) * num55 + num61;
							<Module>.GColor.Saturate(ref gColor2);
							if (num39 == 16)
							{
								Color color4 = Color.FromArgb(255, (int)(gColor2 * 255f), (int)((double)(*(ref gColor2 + 4) * 255f)), (int)((double)(*(ref gColor2 + 8) * 255f)));
								bitmap.SetPixel(num13 + 60, num10, color4);
							}
							else
							{
								float num62 = (float)num39 * 0.0625f;
								float num63 = 1f - num62;
								Color color5 = Color.FromArgb(255, (int)((float)color.R * num63 + num62 * gColor2 * 255f), (int)((double)((float)color.G * num63 + num62 * *(ref gColor2 + 4) * 255f)), (int)((double)((float)color.B * num63 + num62 * *(ref gColor2 + 8) * 255f)));
								bitmap.SetPixel(num13 + 60, num10, color5);
							}
						}
						else
						{
							bitmap.SetPixel(num13 + 60, num10, color);
						}
					}
					IL_8D1:
					num13++;
				}
				while (num13 + 60 < 120);
				num10++;
			}
			while (num10 < 120);
			return bitmap;
		}

		private void UpdateHue(MouseEventArgs e)
		{
			float num = (float)(e.X - 160) + 0.5f;
			float num2 = (float)(e.Y - 60) + 0.5f;
			float num3 = (float)Math.Atan2((double)num2, (double)num);
			float num4 = <Module>.fround(num3 * 57.29578f) + 90;
			if (num4 < 0f)
			{
				num4 += 360f;
			}
			this.Hue = (int)((double)num4);
			this.raise_ValueChanged();
		}

		private void UpdateSatVal(MouseEventArgs e)
		{
			float num = (float)(e.X - 160) + 0.5f;
			float num2 = (float)(e.Y - 60) + 0.5f;
			float num3 = (float)(-(float)this.Hue) * 0.0174532924f;
			float num4 = num3 + 2.09439516f;
			float num5 = (float)Math.Cos((double)num4);
			float num6 = (float)Math.Sin((double)num4);
			float num7 = (num6 * num + num5 * num2 + 45f) * 0.0148148146f;
			float num8;
			float num9;
			if (num7 > 0f)
			{
				num8 = num7;
				if (num7 >= 1f)
				{
					num9 = 1f;
					goto IL_98;
				}
			}
			else
			{
				num8 = 0f;
			}
			num9 = num8;
			IL_98:
			float num10 = num3 + 3.66519165f;
			float num11 = (float)Math.Cos((double)num10);
			float num12 = (float)Math.Sin((double)num10);
			float num13 = num12 * num + num11 * num2;
			float num14;
			float num15;
			if (num9 > 0.001f)
			{
				num13 = num13 / num9 * 0.0222222228f / (float)Math.Sqrt(3.0) + 0.5f;
				if (num13 > 0f)
				{
					num14 = num13;
					if (num13 < 1f)
					{
						goto IL_10A;
					}
					num15 = 1f;
					goto IL_115;
				}
			}
			num14 = 0f;
			IL_10A:
			num15 = num14;
			IL_115:
			this.Sat = (int)((double)(num15 * 100f));
			this.Val = (int)((double)(num9 * 100f));
			this.raise_ValueChanged();
		}

		private unsafe void UpdatePanelColor()
		{
			GColor gColor;
			*(ref gColor + 8) = 0f;
			*(ref gColor + 4) = 0f;
			gColor = 0f;
			*(ref gColor + 12) = 1f;
			<Module>.GColor.FromHSV(ref gColor, this.Hue, this.Sat, this.Val);
			Color backColor = Color.FromArgb((int)(gColor * 255f), (int)((double)(*(ref gColor + 4) * 255f)), (int)((double)(*(ref gColor + 8) * 255f)));
			this.panColor.BackColor = backColor;
			if (this.DisplayMode == ColorPicker.DisplayMode.DISPLAY_TRACKBARS)
			{
				this.UpdateTrackbarColors();
			}
		}

		private unsafe void UpdateTrackbarColors()
		{
			GColor gColor;
			*(ref gColor + 8) = 0f;
			*(ref gColor + 4) = 0f;
			gColor = 0f;
			*(ref gColor + 12) = 1f;
			int num = 0;
			do
			{
				float num2 = (float)num;
				<Module>.GColor.FromHSV(ref gColor, (int)((double)(num2 * 2.53521132f)), this.Sat, this.Val);
				int num3 = 0;
				int blue = (int)((double)(*(ref gColor + 8) * 255f));
				int green = (int)((double)(*(ref gColor + 4) * 255f));
				int red = (int)(gColor * 255f);
				do
				{
					Color color = Color.FromArgb(red, green, blue);
					this.TrackbarBitmap.SetPixel(num, num3, color);
					num3++;
				}
				while (num3 < 5);
				int num4 = (int)((double)(num2 * 0.704225361f));
				<Module>.GColor.FromHSV(ref gColor, this.Hue, num4, this.Val);
				int num5 = 5;
				int blue2 = (int)((double)(*(ref gColor + 8) * 255f));
				int green2 = (int)((double)(*(ref gColor + 4) * 255f));
				int red2 = (int)(gColor * 255f);
				do
				{
					Color color2 = Color.FromArgb(red2, green2, blue2);
					this.TrackbarBitmap.SetPixel(num, num5, color2);
					num5++;
				}
				while (num5 < 10);
				<Module>.GColor.FromHSV(ref gColor, this.Hue, this.Sat, num4);
				int num6 = 10;
				int blue3 = (int)((double)(*(ref gColor + 8) * 255f));
				int green3 = (int)((double)(*(ref gColor + 4) * 255f));
				int red3 = (int)(gColor * 255f);
				do
				{
					Color color3 = Color.FromArgb(red3, green3, blue3);
					this.TrackbarBitmap.SetPixel(num, num6, color3);
					num6++;
				}
				while (num6 < 15);
				num++;
			}
			while (num < 142);
			this.panHueColor.Invalidate();
			this.panSatColor.Invalidate();
			this.panValColor.Invalidate();
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			ColorPicker.DisplayMode displayMode = this.DisplayMode;
			if (displayMode != ColorPicker.DisplayMode.DISPLAY_GRAPHS)
			{
				if (displayMode == ColorPicker.DisplayMode.DISPLAY_TRACKBARS)
				{
					this.panHue.Show();
					this.panSat.Show();
					this.panVal.Show();
					Size size = base.Size;
					Size size2 = base.Size;
					e.Graphics.FillRectangle(this.BackgroundBrush, 0, 0, size2.Width, size.Height);
				}
			}
			else
			{
				this.panHue.Hide();
				this.panSat.Hide();
				this.panVal.Hide();
				Size size3 = base.Size;
				e.Graphics.FillRectangle(this.BackgroundBrush, 0, 0, 100, size3.Height);
				Size size4 = base.Size;
				Size size5 = base.Size;
				e.Graphics.FillRectangle(this.BackgroundBrush, size5.Width - 36, 0, 36, size4.Height);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.DisplayMode == ColorPicker.DisplayMode.DISPLAY_GRAPHS)
			{
				if (this.ColorPickerBitmap == null)
				{
					this.ColorPickerBitmap = this.CalculateColorPickerBitmap((float)this.Hue);
				}
				e.Graphics.DrawImage(this.ColorPickerBitmap, 100, 0, this.ColorPickerBitmap.Width, this.ColorPickerBitmap.Height);
				float num = (float)this.Hue * 0.0174532924f;
				float num2 = (float)Math.Sin((double)num) * 54f + 159.5f;
				float num3 = 59.5f - (float)Math.Cos((double)num) * 54f;
				e.Graphics.FillEllipse(this.MarkerBrush, num2 - 4f, num3 - 4f, 8f, 8f);
				num = 2.09439516f - num;
				float num4 = (float)((double)this.Val * 0.01 * 67.5 - 45.0);
				float num5 = (float)Math.Sqrt(3.0);
				float num6 = (float)(((double)this.Sat * 0.01 - 0.5) * ((double)this.Val * 0.01) * (double)(num5 * 45f));
				float num7 = (float)Math.Cos((double)num);
				float num8 = num7;
				float num9 = (float)Math.Sin((double)num);
				float num10 = num9 * num4 + num8 * num6 + 159.5f;
				float num11 = num9;
				float num12 = 59.5f - num11 * num6 + num7 * num4;
				e.Graphics.FillEllipse(this.MarkerBrush, num10 - 4f, num12 - 4f, 8f, 8f);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) != MouseButtons.None && this.DisplayMode == ColorPicker.DisplayMode.DISPLAY_GRAPHS)
			{
				float num = (float)(e.X - 160) + 0.5f;
				float num2 = (float)(e.Y - 60) + 0.5f;
				float expr_42 = num2;
				double arg_47_0 = (double)(expr_42 * expr_42);
				float expr_45 = num;
				float num3 = (float)Math.Sqrt(arg_47_0 + (double)(expr_45 * expr_45));
				if (num3 <= 60f && num3 >= 48f)
				{
					this.DragType = ColorPicker.DragType.DRAG_HUE;
					this.UpdateHue(e);
				}
				else
				{
					float num4 = (float)(-(float)this.Hue) * 0.0174532924f;
					float num5 = (float)Math.Cos((double)num4);
					GLine gLine = (float)Math.Sin((double)num4);
					float num6 = num4 + 2.09439516f;
					float num7 = (float)Math.Cos((double)num6);
					GLine gLine2 = (float)Math.Sin((double)num6);
					float num8 = num4 - 2.09439516f;
					float num9 = (float)Math.Cos((double)num8);
					GLine gLine3 = (float)Math.Sin((double)num8);
					if (gLine * num + num5 * num2 - 22.5f < 0f && gLine2 * num + num7 * num2 - 22.5f < 0f && gLine3 * num + num9 * num2 - 22.5f < 0f)
					{
						this.DragType = ColorPicker.DragType.DRAG_SATVAL;
						this.UpdateSatVal(e);
					}
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			ColorPicker.DragType dragType = this.DragType;
			if (dragType == ColorPicker.DragType.DRAG_HUE)
			{
				this.UpdateHue(e);
			}
			else if (dragType == ColorPicker.DragType.DRAG_SATVAL)
			{
				this.UpdateSatVal(e);
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			this.DragType = ColorPicker.DragType.DRAG_NONE;
		}

		private unsafe void tbHue_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.tbHue.Text);
				goto IL_6E;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_6E:
			if (num2 > 360)
			{
				num2 = 360;
			}
			else if (num2 < 0)
			{
				num2 = 0;
			}
			if (this.Hue != num2)
			{
				this.Hue = num2;
			}
			this.raise_ValueChanged();
		}

		private unsafe void tbSat_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.tbSat.Text);
				goto IL_6E;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_6E:
			if (num2 > 100)
			{
				num2 = 100;
			}
			else if (num2 < 0)
			{
				num2 = 0;
			}
			if (this.Sat != num2)
			{
				this.Sat = num2;
			}
			this.raise_ValueChanged();
		}

		private unsafe void tbVal_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			int num2 = 0;
			try
			{
				num2 = int.Parse(this.tbVal.Text);
				goto IL_6E;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_6E:
			if (num2 > 100)
			{
				num2 = 100;
			}
			else if (num2 < 0)
			{
				num2 = 0;
			}
			if (this.Val != num2)
			{
				this.Val = num2;
			}
			this.raise_ValueChanged();
		}

		private void tb_ModeSelector_Pushed(int idx, int radio_group)
		{
			if (this.DisplayMode == ColorPicker.DisplayMode.DISPLAY_GRAPHS)
			{
				this.DisplayMode = ColorPicker.DisplayMode.DISPLAY_TRACKBARS;
				this.UpdateTrackbarColors();
			}
			else
			{
				this.DisplayMode = ColorPicker.DisplayMode.DISPLAY_GRAPHS;
			}
			base.Invalidate();
		}

		private void trkHue_Scroll(object sender, EventArgs e)
		{
			this.Hue = this.trkHue.Value;
			this.raise_ValueChanged();
		}

		private void trkSat_Scroll(object sender, EventArgs e)
		{
			this.Sat = this.trkSat.Value;
			this.raise_ValueChanged();
		}

		private void trkVal_Scroll(object sender, EventArgs e)
		{
			this.Val = this.trkVal.Value;
			this.raise_ValueChanged();
		}

		private void trkHue_Paint(object sender, PaintEventArgs e)
		{
			Rectangle srcRect = new Rectangle(0, 0, 142, 5);
			e.Graphics.DrawImage(this.TrackbarBitmap, 0, 0, srcRect, GraphicsUnit.Pixel);
		}

		private void trkSat_Paint(object sender, PaintEventArgs e)
		{
			Rectangle srcRect = new Rectangle(0, 5, 142, 10);
			e.Graphics.DrawImage(this.TrackbarBitmap, 0, 0, srcRect, GraphicsUnit.Pixel);
		}

		private void trkVal_Paint(object sender, PaintEventArgs e)
		{
			Rectangle srcRect = new Rectangle(0, 10, 142, 15);
			e.Graphics.DrawImage(this.TrackbarBitmap, 0, 0, srcRect, GraphicsUnit.Pixel);
		}

		protected void raise_ValueChanged()
		{
			ColorPicker.__Delegate_ValueChanged valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged();
			}
		}
	}
}
