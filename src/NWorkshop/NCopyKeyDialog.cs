using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NCopyKeyDialog : Form
	{
		private Button Yes;

		private Button No;

		private Button Cancel;

		private Label TextLabel;

		private Container components;

		public NCopyKeyDialog(string yestext, string notext)
		{
			this.InitializeComponent();
			this.Yes.Text = yestext;
			this.No.Text = notext;
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
			this.Yes = new Button();
			this.No = new Button();
			this.Cancel = new Button();
			this.TextLabel = new Label();
			base.SuspendLayout();
			Point location = new Point(8, 48);
			this.Yes.Location = location;
			this.Yes.Name = "Yes";
			Size size = new Size(216, 24);
			this.Yes.Size = size;
			this.Yes.TabIndex = 0;
			this.Yes.Text = "Copy loop start value to this key";
			this.Yes.Click += new EventHandler(this.Yes_Click);
			Point location2 = new Point(240, 48);
			this.No.Location = location2;
			this.No.Name = "No";
			Size size2 = new Size(216, 24);
			this.No.Size = size2;
			this.No.TabIndex = 1;
			this.No.Text = "Copy value of this key to loop start";
			this.No.Click += new EventHandler(this.No_Click);
			Point location3 = new Point(192, 88);
			this.Cancel.Location = location3;
			this.Cancel.Name = "Cancel";
			Size size3 = new Size(80, 24);
			this.Cancel.Size = size3;
			this.Cancel.TabIndex = 2;
			this.Cancel.Text = "&Cancel";
			this.Cancel.Click += new EventHandler(this.Cancel_Click);
			Point location4 = new Point(24, 16);
			this.TextLabel.Location = location4;
			this.TextLabel.Name = "TextLabel";
			Size size4 = new Size(416, 16);
			this.TextLabel.Size = size4;
			this.TextLabel.TabIndex = 3;
			this.TextLabel.Text = "The key value of loop start and loop end must be equal!";
			this.TextLabel.TextAlign = ContentAlignment.MiddleCenter;
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(464, 125);
			base.ClientSize = clientSize;
			base.ControlBox = false;
			base.Controls.Add(this.TextLabel);
			base.Controls.Add(this.Cancel);
			base.Controls.Add(this.No);
			base.Controls.Add(this.Yes);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Name = "NCopyKeyDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Key value mismatch";
			base.ResumeLayout(false);
		}

		private void Yes_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Yes;
			base.Close();
		}

		private void No_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			base.Close();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}
	}
}
