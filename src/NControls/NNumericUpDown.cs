using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace NControls
{
	public class NNumericUpDown : Control
	{
		private TextBox NumericBox;

		private Control DraggerButton;

		private Cursor DraggerCursor;

		private long propMinimum;

		private long propMaximum;

		private long propIncrement;

		private long propValue;

		private int propLeftMargin;

		private Color propUnValidatedColor;

		private SolidBrush DropButtonLightBorderBrush;

		private SolidBrush DropButtonDarkBorderBrush;

		private SolidBrush DropButtonBackgroundBrush;

		private SolidBrush DropButtonTextBrush;

		private System.Timers.Timer ValueChangeTimer;

		private bool IsButtonUpPressed;

		private bool IsButtonDownPressed;

		public Color UnValidatedColor
		{
			get
			{
				return this.propUnValidatedColor;
			}
			set
			{
				this.propUnValidatedColor = value;
			}
		}

		public int SelectionLength
		{
			get
			{
				return this.NumericBox.SelectionLength;
			}
			set
			{
				this.NumericBox.SelectionLength = value;
			}
		}

		public BorderStyle BorderStyle
		{
			get
			{
				return this.NumericBox.BorderStyle;
			}
			set
			{
				this.NumericBox.BorderStyle = value;
			}
		}

		public int LeftMargin
		{
			get
			{
				return this.propLeftMargin;
			}
			set
			{
				this.propLeftMargin = value;
				Point location = new Point(value, 1);
				this.NumericBox.Location = location;
				Size size = new Size(base.Width - this.DraggerButton.Width - this.propLeftMargin, base.Height - 1);
				this.NumericBox.Size = size;
				this.NumericBox.Invalidate();
			}
		}

		public override string Text
		{
			get
			{
				return this.NumericBox.Text;
			}
		}

		public long Value
		{
			get
			{
				return this.propValue;
			}
			set
			{
				if (value < this.Minimum)
				{
					value = this.Minimum;
				}
				if (value > this.Maximum)
				{
					value = this.Maximum;
				}
				this.propValue = value;
				long num = value;
				this.NumericBox.Text = num.ToString();
				this.NumericBox.Invalidate();
			}
		}

		public long Increment
		{
			get
			{
				return this.propIncrement;
			}
			set
			{
				this.propIncrement = value;
			}
		}

		public long Maximum
		{
			get
			{
				return this.propMaximum;
			}
			set
			{
				this.propMaximum = value;
				if (this.Value > value)
				{
					this.Value = value;
				}
			}
		}

		public long Minimum
		{
			get
			{
				return this.propMinimum;
			}
			set
			{
				this.propMinimum = value;
				if (this.Value < value)
				{
					this.Value = value;
				}
			}
		}

		public NNumericUpDown()
		{
			base.Height = 16;
			this.propLeftMargin = 0;
			Color color = Color.FromKnownColor(KnownColor.ControlLightLight);
			this.DropButtonLightBorderBrush = new SolidBrush(color);
			Color color2 = Color.FromKnownColor(KnownColor.ControlDark);
			this.DropButtonDarkBorderBrush = new SolidBrush(color2);
			Color color3 = Color.FromKnownColor(KnownColor.Control);
			this.DropButtonBackgroundBrush = new SolidBrush(color3);
			Color color4 = Color.FromKnownColor(KnownColor.ControlText);
			this.DropButtonTextBrush = new SolidBrush(color4);
			this.DraggerButton = new Control();
			Color backColor = Color.FromKnownColor(KnownColor.Window);
			this.DraggerButton.BackColor = backColor;
			this.DraggerButton.Dock = DockStyle.Right;
			Size size = new Size(16, 16);
			this.DraggerButton.Size = size;
			this.DraggerButton.MouseDown += new MouseEventHandler(this.DraggerButton_MouseDown);
			this.DraggerButton.MouseUp += new MouseEventHandler(this.DraggerButton_MouseUp);
			this.DraggerButton.MouseMove += new MouseEventHandler(this.DraggerButton_MouseMove);
			this.DraggerButton.Paint += new PaintEventHandler(this.DraggerButton_Paint);
			this.NumericBox = new TextBox();
			Point location = new Point(this.propLeftMargin, 1);
			this.NumericBox.Location = location;
			Size size2 = new Size(base.Width - this.DraggerButton.Width - this.propLeftMargin, base.Height - 1);
			this.NumericBox.Size = size2;
			this.NumericBox.KeyDown += new KeyEventHandler(this.NumericBox_KeyDown);
			this.NumericBox.MouseDown += new MouseEventHandler(this.NumericBox_MouseDown);
			this.NumericBox.Validated += new EventHandler(this.NumericBox_Validated);
			this.NumericBox.TextChanged += new EventHandler(this.NumericBox_TextChanged);
			Color foreColor = Color.FromKnownColor(KnownColor.WindowText);
			this.NumericBox.ForeColor = foreColor;
			base.Controls.Add(this.DraggerButton);
			base.Controls.Add(this.NumericBox);
			this.Minimum = -9223372036854775808L;
			this.Maximum = 9223372036854775807L;
			this.Increment = 0L;
			this.Value = 0L;
			Color foreColor2 = Color.FromKnownColor(KnownColor.WindowText);
			this.NumericBox.ForeColor = foreColor2;
			Color unValidatedColor = Color.FromKnownColor(KnownColor.WindowText);
			this.UnValidatedColor = unValidatedColor;
			this.ValueChangeTimer = new System.Timers.Timer();
			this.IsButtonUpPressed = false;
			this.IsButtonDownPressed = false;
		}

		protected override void OnGotFocus(EventArgs e)
		{
			this.NumericBox.Focus();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			if (this.NumericBox != null)
			{
				Size size = new Size(base.Width - this.DraggerButton.Width - this.propLeftMargin, base.Height - 1);
				this.NumericBox.Size = size;
				this.NumericBox.Invalidate();
			}
		}

		public void RaiseValidate()
		{
			this.NumericBox_Validated(this.NumericBox, null);
		}

		private void DraggerButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (!this.NumericBox.Focused)
			{
				this.NumericBox.Focus();
			}
			if (e.Y <= 8)
			{
				this.IsButtonUpPressed = true;
			}
			else
			{
				this.IsButtonDownPressed = true;
			}
			this.DraggerButton.Invalidate();
			this.NumericBox_Validated(this.NumericBox, null);
			this.OnMouseDown(e);
		}

		private void TimedDecrease(object source, ElapsedEventArgs __unnamed001)
		{
			this.ValueChangeTimer.Interval = this.ValueChangeTimer.Interval * 0.8;
			this.Value -= this.Increment;
		}

		private void TimedIncrease(object source, ElapsedEventArgs __unnamed001)
		{
			this.ValueChangeTimer.Interval = this.ValueChangeTimer.Interval * 0.8;
			this.Value += this.Increment;
		}

		private void DraggerButton_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Y <= 8)
			{
				this.Value += this.Increment;
				this.IsButtonUpPressed = false;
			}
			else
			{
				this.Value -= this.Increment;
				this.IsButtonDownPressed = false;
			}
			this.NumericBox_Validated(this.NumericBox, null);
			this.DraggerButton.Invalidate();
		}

		private void DraggerButton_MouseMove(object sender, MouseEventArgs e)
		{
		}

		private void DraggerButton_Paint(object sender, PaintEventArgs e)
		{
			SolidBrush dropButtonLightBorderBrush;
			SolidBrush brush;
			SolidBrush dropButtonDarkBorderBrush;
			SolidBrush brush2;
			if (this.IsButtonDownPressed)
			{
				dropButtonLightBorderBrush = this.DropButtonLightBorderBrush;
				brush = dropButtonLightBorderBrush;
				dropButtonDarkBorderBrush = this.DropButtonDarkBorderBrush;
				brush2 = dropButtonDarkBorderBrush;
			}
			else
			{
				dropButtonDarkBorderBrush = this.DropButtonDarkBorderBrush;
				brush = dropButtonDarkBorderBrush;
				dropButtonLightBorderBrush = this.DropButtonLightBorderBrush;
				brush2 = dropButtonLightBorderBrush;
			}
			SolidBrush brush3;
			SolidBrush brush4;
			if (this.IsButtonUpPressed)
			{
				brush3 = dropButtonLightBorderBrush;
				brush4 = dropButtonDarkBorderBrush;
			}
			else
			{
				brush3 = dropButtonDarkBorderBrush;
				brush4 = dropButtonLightBorderBrush;
			}
			e.Graphics.FillRectangle(this.DropButtonBackgroundBrush, 0f, 0f, 16f, 16f);
			e.Graphics.FillRectangle(brush4, 0f, 0f, 15f, 1f);
			e.Graphics.FillRectangle(brush4, 0f, 0f, 1f, 8f);
			e.Graphics.FillRectangle(brush3, 1f, 7f, 14f, 1f);
			e.Graphics.FillRectangle(brush3, 15f, 0f, 1f, 8f);
			e.Graphics.FillRectangle(brush2, 0f, 8f, 15f, 1f);
			e.Graphics.FillRectangle(brush2, 0f, 8f, 1f, 8f);
			e.Graphics.FillRectangle(brush, 1f, 15f, 14f, 1f);
			e.Graphics.FillRectangle(brush, 15f, 8f, 1f, 8f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 8f, 3f, 1f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 7f, 4f, 3f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 7f, 11f, 3f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 8f, 12f, 1f, 1f);
		}

		private void NumericBox_KeyDown(object __unnamed000, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				this.Value += this.Increment;
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Down)
			{
				this.Value -= this.Increment;
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Return)
			{
				this.UpdateValueFromText();
			}
			this.OnKeyDown(e);
		}

		private void NumericBox_MouseDown(object __unnamed000, MouseEventArgs e)
		{
			this.OnMouseDown(e);
		}

		private void NumericBox_Validated(object __unnamed000, EventArgs e)
		{
			this.UpdateValueFromText();
			Color foreColor = Color.FromKnownColor(KnownColor.WindowText);
			this.NumericBox.ForeColor = foreColor;
			this.OnValidated(e);
		}

		private void NumericBox_TextChanged(object __unnamed000, EventArgs e)
		{
			Color unValidatedColor = this.UnValidatedColor;
			this.NumericBox.ForeColor = unValidatedColor;
			this.OnTextChanged(e);
		}

		private unsafe void UpdateValueFromText()
		{
			*<Module>._errno() = 0;
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.NumericBox.Text);
			long value;
			try
			{
				uint num = (uint)(*ptr);
				value = <Module>._strtoi64((num == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num, null, 10);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
			}
			if (*<Module>._errno() == 34)
			{
				long value2 = this.Value;
				this.NumericBox.Text = value2.ToString();
				this.NumericBox.Invalidate();
			}
			else
			{
				this.Value = value;
			}
		}
	}
}
