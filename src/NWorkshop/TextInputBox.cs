using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class TextInputBox : Form
	{
		private Button OKBtn;

		private Button CancelBtn;

		private TextBox TextEdit;

		private Container components;

		public string EditText
		{
			get
			{
				return this.TextEdit.Text;
			}
			set
			{
				this.TextEdit.Text = value;
			}
		}

		public TextInputBox()
		{
			this.InitializeComponent();
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
			this.TextEdit = new TextBox();
			base.SuspendLayout();
			this.OKBtn.DialogResult = DialogResult.OK;
			Point location = new Point(16, 48);
			this.OKBtn.Location = location;
			this.OKBtn.Name = "OKBtn";
			Size size = new Size(120, 23);
			this.OKBtn.Size = size;
			this.OKBtn.TabIndex = 0;
			this.OKBtn.Text = "OK";
			this.CancelBtn.DialogResult = DialogResult.Cancel;
			Point location2 = new Point(160, 48);
			this.CancelBtn.Location = location2;
			this.CancelBtn.Name = "CancelBtn";
			Size size2 = new Size(120, 23);
			this.CancelBtn.Size = size2;
			this.CancelBtn.TabIndex = 1;
			this.CancelBtn.Text = "Cancel";
			Point location3 = new Point(16, 16);
			this.TextEdit.Location = location3;
			this.TextEdit.Name = "TextEdit";
			Size size3 = new Size(264, 20);
			this.TextEdit.Size = size3;
			this.TextEdit.TabIndex = 2;
			this.TextEdit.Text = "TextBox";
			base.AcceptButton = this.OKBtn;
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			base.CancelButton = this.CancelBtn;
			Size clientSize = new Size(292, 82);
			base.ClientSize = clientSize;
			base.ControlBox = false;
			base.Controls.Add(this.TextEdit);
			base.Controls.Add(this.CancelBtn);
			base.Controls.Add(this.OKBtn);
			base.Name = "TextInputBox";
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.Manual;
			this.Text = "Set text";
			base.ResumeLayout(false);
		}
	}
}
