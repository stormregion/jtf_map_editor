using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class MissingAssetDialog : Form
	{
		private Button IgnoreAllBtn;

		private Button DeleteBtn;

		private Button AbortBtn;

		private Button ReplaceBtn;

		private Label WarningText;

		private Button IgnoreBtn;

		private Container components;

		private string propAssetName;

		private string propNewName;

		private bool propAllowIgnore;

		private int propType;

		private NewAssetPicker NewDialog;

		private int AssetResult;

		public int Type
		{
			get
			{
				return this.propType;
			}
			set
			{
				this.propType = value;
			}
		}

		public bool AllowIgnore
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.propAllowIgnore;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.propAllowIgnore = value;
			}
		}

		public string NewName
		{
			get
			{
				return this.propNewName;
			}
			set
			{
				this.propNewName = value;
			}
		}

		public string AssetName
		{
			get
			{
				return this.propAssetName;
			}
			set
			{
				this.propAssetName = value;
			}
		}

		public MissingAssetDialog()
		{
			this.propAssetName = "";
			this.propNewName = "";
			this.propAllowIgnore = true;
			this.AssetResult = 105;
			this.InitializeComponent();
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing)
			{
				NewAssetPicker newDialog = this.NewDialog;
				if (newDialog != null)
				{
					newDialog.Dispose();
				}
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
			this.WarningText = new Label();
			this.IgnoreBtn = new Button();
			this.IgnoreAllBtn = new Button();
			this.DeleteBtn = new Button();
			this.AbortBtn = new Button();
			this.ReplaceBtn = new Button();
			base.SuspendLayout();
			Point location = new Point(8, 8);
			this.WarningText.Location = location;
			this.WarningText.Name = "WarningText";
			Size size = new Size(424, 48);
			this.WarningText.Size = size;
			this.WarningText.TabIndex = 0;
			this.IgnoreBtn.DialogResult = DialogResult.Ignore;
			this.IgnoreBtn.FlatStyle = FlatStyle.System;
			Point location2 = new Point(8, 64);
			this.IgnoreBtn.Location = location2;
			this.IgnoreBtn.Name = "IgnoreBtn";
			this.IgnoreBtn.TabIndex = 1;
			this.IgnoreBtn.Text = "Ignore";
			this.IgnoreAllBtn.DialogResult = DialogResult.Yes;
			this.IgnoreAllBtn.FlatStyle = FlatStyle.System;
			Point location3 = new Point(88, 64);
			this.IgnoreAllBtn.Location = location3;
			this.IgnoreAllBtn.Name = "IgnoreAllBtn";
			this.IgnoreAllBtn.TabIndex = 2;
			this.IgnoreAllBtn.Text = "Ignore All";
			this.DeleteBtn.DialogResult = DialogResult.No;
			this.DeleteBtn.FlatStyle = FlatStyle.System;
			Point location4 = new Point(184, 64);
			this.DeleteBtn.Location = location4;
			this.DeleteBtn.Name = "DeleteBtn";
			this.DeleteBtn.TabIndex = 3;
			this.DeleteBtn.Text = "Delete";
			this.AbortBtn.DialogResult = DialogResult.Abort;
			this.AbortBtn.FlatStyle = FlatStyle.System;
			Point location5 = new Point(360, 64);
			this.AbortBtn.Location = location5;
			this.AbortBtn.Name = "AbortBtn";
			this.AbortBtn.TabIndex = 4;
			this.AbortBtn.Text = "Abort load";
			this.ReplaceBtn.FlatStyle = FlatStyle.System;
			Point location6 = new Point(264, 64);
			this.ReplaceBtn.Location = location6;
			this.ReplaceBtn.Name = "ReplaceBtn";
			this.ReplaceBtn.TabIndex = 5;
			this.ReplaceBtn.Text = "Replace";
			this.ReplaceBtn.Click += new EventHandler(this.ReplaceBtn_Click);
			base.AcceptButton = this.IgnoreBtn;
			base.AutoScale = false;
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			base.CancelButton = this.AbortBtn;
			Size clientSize = new Size(440, 94);
			base.ClientSize = clientSize;
			base.Controls.Add(this.ReplaceBtn);
			base.Controls.Add(this.AbortBtn);
			base.Controls.Add(this.DeleteBtn);
			base.Controls.Add(this.IgnoreAllBtn);
			base.Controls.Add(this.IgnoreBtn);
			base.Controls.Add(this.WarningText);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MissingAssetDialog";
			base.ShowInTaskbar = false;
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.CenterParent;
			base.Load += new EventHandler(this.MissingAssetDialog_Load);
			base.ResumeLayout(false);
		}

		public new int ShowDialog(IWin32Window owner)
		{
			switch (base.ShowDialog(owner))
			{
			case DialogResult.Abort:
				return 105;
			case DialogResult.Ignore:
				return 100;
			case DialogResult.Yes:
				return 103;
			case DialogResult.No:
				return 101;
			}
			return this.AssetResult;
		}

		private void MissingAssetDialog_Load(object sender, EventArgs e)
		{
			string text = "";
			string str = text;
			string str2 = text;
			switch (this.propType)
			{
			case 0:
				str = "ambient sound";
				str2 = "An ambient sound";
				break;
			case 1:
				str = "decal";
				str2 = "A decal";
				break;
			case 2:
				str = "object";
				str2 = "An object";
				break;
			case 3:
				str = "road";
				str2 = "A road texture";
				break;
			case 4:
				str = "terrain texture";
				str2 = "A terrain texture";
				break;
			case 5:
				str = "unit";
				str2 = "A unit";
				break;
			case 6:
				str = "building";
				str2 = "A building";
				break;
			case 7:
				str = "effect";
				str2 = "An effect";
				break;
			}
			this.Text = "Missing " + str + "!";
			this.WarningText.Text = str2 + " is missing\n\n" + this.propAssetName;
			this.IgnoreAllBtn.Enabled = this.propAllowIgnore;
			this.IgnoreBtn.Enabled = this.propAllowIgnore;
			this.NewDialog = new NewAssetPicker(NewAssetPicker.ObjectType.MissingAsset, this.propType);
		}

		private void ReplaceBtn_Click(object sender, EventArgs e)
		{
			this.NewDialog.Reset();
			if (this.NewDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.propNewName = this.NewDialog.NewName;
				this.AssetResult = 102;
				base.Close();
			}
		}
	}
}
