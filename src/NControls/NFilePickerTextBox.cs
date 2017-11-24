using NWorkshop;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NControls
{
	public class NFilePickerTextBox : Control
	{
		private TextBox FileTextBox;

		private Control DraggerButton;

		private Cursor DraggerCursor;

		private int propLeftMargin;

		private NewAssetPicker.ObjectType ObjType;

		private int FileType;

		private Color propUnValidatedColor;

		private SolidBrush DropButtonLightBorderBrush;

		private SolidBrush DropButtonDarkBorderBrush;

		private SolidBrush DropButtonBackgroundBrush;

		private SolidBrush DropButtonTextBrush;

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

		public BorderStyle BorderStyle
		{
			get
			{
				return this.FileTextBox.BorderStyle;
			}
			set
			{
				this.FileTextBox.BorderStyle = value;
			}
		}

		public int SelectionLength
		{
			get
			{
				return this.FileTextBox.SelectionLength;
			}
			set
			{
				this.FileTextBox.SelectionLength = value;
			}
		}

		public override string Text
		{
			get
			{
				return this.FileTextBox.Text;
			}
			set
			{
				this.FileTextBox.Text = value;
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
				this.FileTextBox.Location = location;
				Size size = new Size(base.Width - this.DraggerButton.Width - this.propLeftMargin, base.Height - 1);
				this.FileTextBox.Size = size;
				this.FileTextBox.Invalidate();
			}
		}

		public NFilePickerTextBox(NewAssetPicker.ObjectType objecttype, int filetype)
		{
			this.ObjType = objecttype;
			this.FileType = filetype;
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
			Control control = new Control();
			this.DraggerButton = control;
			control.Dock = DockStyle.Right;
			Size size = new Size(16, 16);
			this.DraggerButton.Size = size;
			this.DraggerButton.MouseDown += new MouseEventHandler(this.DraggerButton_MouseDown);
			this.DraggerButton.Click += new EventHandler(this.DraggerButton_Click);
			this.DraggerButton.Paint += new PaintEventHandler(this.DraggerButton_Paint);
			this.FileTextBox = new TextBox();
			Point location = new Point(this.propLeftMargin, 1);
			this.FileTextBox.Location = location;
			Size size2 = new Size(base.Width - this.DraggerButton.Width - this.propLeftMargin, base.Height - 1);
			this.FileTextBox.Size = size2;
			this.FileTextBox.KeyDown += new KeyEventHandler(this.FileTextBox_KeyDown);
			this.FileTextBox.MouseDown += new MouseEventHandler(this.FileTextBox_MouseDown);
			this.FileTextBox.Validated += new EventHandler(this.FileTextBox_Validated);
			this.FileTextBox.TextChanged += new EventHandler(this.FileTextBox_TextChanged);
			base.Controls.Add(this.DraggerButton);
			base.Controls.Add(this.FileTextBox);
			Color foreColor = Color.FromKnownColor(KnownColor.WindowText);
			this.FileTextBox.ForeColor = foreColor;
			Color unValidatedColor = Color.FromKnownColor(KnownColor.WindowText);
			this.UnValidatedColor = unValidatedColor;
		}

		protected override void OnGotFocus(EventArgs e)
		{
			this.FileTextBox.Focus();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			if (this.FileTextBox != null)
			{
				Size size = new Size(base.Width - this.DraggerButton.Width - this.propLeftMargin, base.Height - 1);
				this.FileTextBox.Size = size;
				this.FileTextBox.Invalidate();
			}
		}

		public void RaiseValidate()
		{
			this.FileTextBox_Validated(this.FileTextBox, null);
		}

		private void DraggerButton_MouseDown(object sender, MouseEventArgs e)
		{
			this.OnMouseDown(e);
		}

		private void DraggerButton_Click(object sender, EventArgs e)
		{
			base.Focus();
			this.SelectionLength = 0;
			NewAssetPicker newAssetPicker = new NewAssetPicker(this.ObjType, this.FileType);
			newAssetPicker.StartPosition = FormStartPosition.CenterScreen;
			if (newAssetPicker.ShowDialog() == DialogResult.OK)
			{
				this.FileTextBox.Text = newAssetPicker.NewName;
				this.FileTextBox_Validated(this.FileTextBox, e);
			}
			newAssetPicker.Dispose();
			this.OnClick(e);
		}

		private void DraggerButton_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.FillRectangle(this.DropButtonBackgroundBrush, 0f, 0f, 16f, 16f);
			e.Graphics.FillRectangle(this.DropButtonLightBorderBrush, 0f, 0f, 15f, 1f);
			e.Graphics.FillRectangle(this.DropButtonLightBorderBrush, 0f, 0f, 1f, 15f);
			e.Graphics.FillRectangle(this.DropButtonDarkBorderBrush, 1f, 15f, 14f, 1f);
			e.Graphics.FillRectangle(this.DropButtonDarkBorderBrush, 15f, 0f, 1f, 15f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 6f, 6f, 1f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 8f, 6f, 1f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 10f, 6f, 1f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 6f, 9f, 5f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 7f, 10f, 3f, 1f);
			e.Graphics.FillRectangle(this.DropButtonTextBrush, 8f, 11f, 1f, 1f);
		}

		private void FileTextBox_KeyDown(object __unnamed000, KeyEventArgs e)
		{
			this.OnKeyDown(e);
		}

		private void FileTextBox_MouseDown(object __unnamed000, MouseEventArgs e)
		{
			if (!this.FileTextBox.Focused)
			{
				this.FileTextBox.Focus();
			}
			this.OnMouseDown(e);
		}

		private void FileTextBox_Validated(object __unnamed000, EventArgs e)
		{
			Color foreColor = Color.FromKnownColor(KnownColor.WindowText);
			this.FileTextBox.ForeColor = foreColor;
			this.OnValidated(e);
		}

		private void FileTextBox_TextChanged(object __unnamed000, EventArgs e)
		{
			Color unValidatedColor = this.UnValidatedColor;
			this.FileTextBox.ForeColor = unValidatedColor;
			this.OnTextChanged(e);
		}
	}
}
