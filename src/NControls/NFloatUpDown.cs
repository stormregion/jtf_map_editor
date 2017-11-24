using System;
using System.Drawing;
using System.Windows.Forms;

namespace NControls
{
	public class NFloatUpDown : Control
	{
		private TextBox NumericBox;

		private Control DraggerButton;

		private Cursor DraggerCursor;

		private double propMinimum;

		private double propMaximum;

		private double propIncrement;

		private double propValue;

		private int propLeftMargin;

		private Color propUnValidatedColor;

		private SolidBrush DropButtonLightBorderBrush;

		private SolidBrush DropButtonDarkBorderBrush;

		private SolidBrush DropButtonBackgroundBrush;

		private SolidBrush DropButtonTextBrush;

		private bool IsButtonPressed;

		private bool IsMovedWhileButtonPressed;

		private int DragFromY;

		private Point StartPoint;

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

		public unsafe double Value
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
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.Format(&gBaseString<char>, (sbyte*)(&<Module>.??_C@_02NJPGOMH@?$CFf?$AA@), value);
				try
				{
					uint num = (uint)(*(int*)ptr);
					sbyte* value2;
					if (num != 0u)
					{
						value2 = num;
					}
					else
					{
						value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					this.NumericBox.Text = new string((sbyte*)value2);
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
				this.NumericBox.Invalidate();
			}
		}

		public double Increment
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

		public double Maximum
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

		public double Minimum
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

		public NFloatUpDown()
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
			base.Controls.Add(this.DraggerButton);
			base.Controls.Add(this.NumericBox);
			this.Minimum = -1.7976931348623157E+308;
			this.Maximum = 1.7976931348623157E+308;
			this.Increment = 0.0;
			this.Value = 0.0;
			Color foreColor = Color.FromKnownColor(KnownColor.WindowText);
			this.NumericBox.ForeColor = foreColor;
			Color unValidatedColor = Color.FromKnownColor(KnownColor.WindowText);
			this.UnValidatedColor = unValidatedColor;
			this.IsButtonPressed = false;
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
			Cursor arg_06_0 = this.Cursor;
			this.DragFromY = Cursor.Position.Y;
			Cursor arg_20_0 = this.Cursor;
			Point position = Cursor.Position;
			this.StartPoint = position;
			Cursor arg_34_0 = this.Cursor;
			Cursor.Current = Cursors.SizeNS;
			if (!this.NumericBox.Focused)
			{
				this.NumericBox.Focus();
			}
			this.IsButtonPressed = true;
			this.IsMovedWhileButtonPressed = false;
			this.DraggerButton.Invalidate();
			this.OnMouseDown(e);
		}

		private void DraggerButton_MouseUp(object sender, MouseEventArgs e)
		{
			if (!this.IsMovedWhileButtonPressed)
			{
				if (e.Y <= 8)
				{
					this.Value += this.Increment;
				}
				else
				{
					this.Value -= this.Increment;
				}
			}
			this.IsButtonPressed = false;
			this.DraggerButton.Invalidate();
			int arg_5F_0 = Screen.AllScreens[0].Bounds.Top;
			Cursor arg_66_0 = this.Cursor;
			Cursor.Position = this.StartPoint;
			this.NumericBox_Validated(this.NumericBox, null);
		}

		private void DraggerButton_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.IsButtonPressed)
			{
				Cursor arg_11_0 = this.Cursor;
				Point position = Cursor.Position;
				this.Value -= (double)(position.Y - this.DragFromY) * this.Increment;
				this.Value = (double)(<Module>.fround((float)(this.Value * 100000.0)) * 1E-05f);
				Cursor arg_66_0 = this.Cursor;
				Point position2 = Cursor.Position;
				bool flag = false;
				int num = Screen.AllScreens[0].Bounds.Right - 3;
				if (position2.X > num)
				{
					position2.X = Screen.AllScreens[0].Bounds.Left + 4;
					flag = true;
				}
				else
				{
					int num2 = Screen.AllScreens[0].Bounds.Left + 3;
					if (position2.X < num2)
					{
						position2.X = Screen.AllScreens[0].Bounds.Right - 4;
						flag = true;
					}
				}
				int num3 = Screen.AllScreens[0].Bounds.Bottom - 3;
				if (position2.Y > num3)
				{
					position2.Y = Screen.AllScreens[0].Bounds.Top + 4;
				}
				else
				{
					int num4 = Screen.AllScreens[0].Bounds.Top + 3;
					if (position2.Y < num4)
					{
						position2.Y = Screen.AllScreens[0].Bounds.Bottom - 4;
					}
					else if (!flag)
					{
						goto IL_18D;
					}
				}
				Cursor arg_185_0 = this.Cursor;
				Cursor.Position = position2;
				IL_18D:
				Cursor arg_193_0 = this.Cursor;
				this.DragFromY = Cursor.Position.Y;
				this.IsMovedWhileButtonPressed = true;
			}
		}

		private void DraggerButton_Paint(object sender, PaintEventArgs e)
		{
			SolidBrush brush;
			SolidBrush brush2;
			if (this.IsButtonPressed)
			{
				brush = this.DropButtonLightBorderBrush;
				brush2 = this.DropButtonDarkBorderBrush;
			}
			else
			{
				brush = this.DropButtonDarkBorderBrush;
				brush2 = this.DropButtonLightBorderBrush;
			}
			e.Graphics.FillRectangle(this.DropButtonBackgroundBrush, 0f, 0f, 16f, 16f);
			e.Graphics.FillRectangle(brush2, 0f, 0f, 15f, 1f);
			e.Graphics.FillRectangle(brush2, 0f, 0f, 1f, 15f);
			e.Graphics.FillRectangle(brush, 1f, 15f, 14f, 1f);
			e.Graphics.FillRectangle(brush, 15f, 0f, 1f, 15f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 8f, 4f, 1f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 7f, 5f, 3f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 6f, 6f, 5f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 6f, 9f, 5f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 7f, 10f, 3f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 8f, 11f, 1f, 1f);
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
				this.NumericBox_Validated(null, e);
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
			double value;
			try
			{
				uint num = (uint)(*ptr);
				value = <Module>.strtod((num == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num, null);
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
				double value2 = this.Value;
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
