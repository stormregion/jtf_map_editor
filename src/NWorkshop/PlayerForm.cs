using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class PlayerForm : Form
	{
		public ComboBox comboBoxColor;

		private RadioButton radioButtonControl0;

		private RadioButton radioButtonControl1;

		private RadioButton radioButtonControl2;

		private RadioButton radioButtonControl3;

		private GroupBox groupBoxResources;

		private Label labelMoney;

		private NumericUpDown numericMoney;

		private RadioButton radioButton1;

		private RadioButton radioButton2;

		private RadioButton radioButton3;

		private RadioButton radioButton4;

		private RadioButton radioButton5;

		private GroupBox groupBoxTargetElector;

		private RadioButton radioButton6;

		private RadioButton radioButtonControl5;

		private RadioButton radioButtonControl4;

		private GroupBox groupBoxColor;

		private GroupBox groupBoxTeam;

		private GroupBox groupBoxControl;

		private GroupBox groupBoxRace;

		private RadioButton radioButtonTeam1;

		private RadioButton radioButtonTeam2;

		private RadioButton radioButtonTeam3;

		private RadioButton radioButtonTeam4;

		private RadioButton radioButtonTeam0;

		private RadioButton radioButtonRace0;

		private RadioButton radioButtonRace1;

		private RadioButton radioButtonRace2;

		private RadioButton radioButtonRace3;

		private RadioButton radioButtonRace4;

		private RadioButton radioButtonRace5;

		private Button buttonOK;

		private Button buttonCancel;

		private Container components;

		public int Money
		{
			get
			{
				return decimal.ToInt32(this.numericMoney.Value);
			}
			set
			{
				decimal value2 = new decimal(value);
				this.numericMoney.Value = value2;
			}
		}

		public PlayerForm()
		{
			this.InitializeComponent();
			object[] items = new object[]
			{
				"Red",
				"Orange",
				"Yellow",
				"Green",
				"Cyan",
				"Blue",
				"Purple",
				"Pink",
				"Black",
				"Grey",
				"White",
				"Brown"
			};
			this.comboBoxColor.Items.AddRange(items);
			base.AcceptButton = this.buttonOK;
			base.CancelButton = this.buttonCancel;
		}

		public int GetTeam()
		{
			IEnumerator enumerator = this.groupBoxTeam.Controls.GetEnumerator();
			int num = 0;
			if (enumerator.MoveNext())
			{
				while (!(enumerator.Current as RadioButton).Checked)
				{
					num++;
					if (!enumerator.MoveNext())
					{
						return 0;
					}
				}
				return num;
			}
			return 0;
		}

		public int GetRace()
		{
			IEnumerator enumerator = this.groupBoxRace.Controls.GetEnumerator();
			int num = 0;
			if (enumerator.MoveNext())
			{
				while (!(enumerator.Current as RadioButton).Checked)
				{
					num++;
					if (!enumerator.MoveNext())
					{
						return 0;
					}
				}
				return num;
			}
			return 0;
		}

		public int GetControl()
		{
			IEnumerator enumerator = this.groupBoxControl.Controls.GetEnumerator();
			int num = 0;
			if (enumerator.MoveNext())
			{
				while (!(enumerator.Current as RadioButton).Checked)
				{
					num++;
					if (!enumerator.MoveNext())
					{
						return 0;
					}
				}
				return num;
			}
			return 0;
		}

		public int GetTargetElector()
		{
			IEnumerator enumerator = this.groupBoxTargetElector.Controls.GetEnumerator();
			int num = 0;
			if (enumerator.MoveNext())
			{
				while (!(enumerator.Current as RadioButton).Checked)
				{
					num++;
					if (!enumerator.MoveNext())
					{
						return 0;
					}
				}
				return num;
			}
			return 0;
		}

		public void SetTeam(int idx)
		{
			if (idx >= 0 && idx < this.groupBoxTeam.Controls.Count)
			{
				(this.groupBoxTeam.Controls[idx] as RadioButton).Checked = true;
			}
		}

		public void SetRace(int idx)
		{
			if (idx >= 0 && idx < this.groupBoxRace.Controls.Count)
			{
				(this.groupBoxRace.Controls[idx] as RadioButton).Checked = true;
			}
		}

		public void SetControl(int idx)
		{
			if (idx >= 0 && idx < this.groupBoxControl.Controls.Count)
			{
				(this.groupBoxControl.Controls[idx] as RadioButton).Checked = true;
			}
		}

		public void SetTargetElector(int idx)
		{
			if (idx >= 0 && idx < this.groupBoxTargetElector.Controls.Count)
			{
				(this.groupBoxTargetElector.Controls[idx] as RadioButton).Checked = true;
			}
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
			this.groupBoxColor = new GroupBox();
			this.comboBoxColor = new ComboBox();
			this.groupBoxTeam = new GroupBox();
			this.radioButtonTeam0 = new RadioButton();
			this.radioButtonTeam1 = new RadioButton();
			this.radioButtonTeam2 = new RadioButton();
			this.radioButtonTeam3 = new RadioButton();
			this.radioButtonTeam4 = new RadioButton();
			this.groupBoxRace = new GroupBox();
			this.radioButtonRace0 = new RadioButton();
			this.radioButtonRace1 = new RadioButton();
			this.radioButtonRace2 = new RadioButton();
			this.radioButtonRace3 = new RadioButton();
			this.radioButtonRace4 = new RadioButton();
			this.radioButtonRace5 = new RadioButton();
			this.buttonOK = new Button();
			this.buttonCancel = new Button();
			this.groupBoxControl = new GroupBox();
			this.radioButtonControl0 = new RadioButton();
			this.radioButtonControl1 = new RadioButton();
			this.radioButtonControl2 = new RadioButton();
			this.radioButtonControl3 = new RadioButton();
			this.radioButtonControl4 = new RadioButton();
			this.radioButtonControl5 = new RadioButton();
			this.groupBoxResources = new GroupBox();
			this.numericMoney = new NumericUpDown();
			this.labelMoney = new Label();
			this.groupBoxTargetElector = new GroupBox();
			this.radioButton1 = new RadioButton();
			this.radioButton2 = new RadioButton();
			this.radioButton3 = new RadioButton();
			this.radioButton4 = new RadioButton();
			this.radioButton5 = new RadioButton();
			this.radioButton6 = new RadioButton();
			this.groupBoxColor.SuspendLayout();
			this.groupBoxTeam.SuspendLayout();
			this.groupBoxRace.SuspendLayout();
			this.groupBoxControl.SuspendLayout();
			this.groupBoxResources.SuspendLayout();
			((ISupportInitialize)this.numericMoney).BeginInit();
			this.groupBoxTargetElector.SuspendLayout();
			base.SuspendLayout();
			this.groupBoxColor.Controls.Add(this.comboBoxColor);
			this.groupBoxColor.FlatStyle = FlatStyle.System;
			Point location = new Point(8, 8);
			this.groupBoxColor.Location = location;
			this.groupBoxColor.Name = "groupBoxColor";
			Size size = new Size(128, 48);
			this.groupBoxColor.Size = size;
			this.groupBoxColor.TabIndex = 0;
			this.groupBoxColor.TabStop = false;
			this.groupBoxColor.Text = "Color";
			this.comboBoxColor.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location2 = new Point(8, 16);
			this.comboBoxColor.Location = location2;
			this.comboBoxColor.Name = "comboBoxColor";
			Size size2 = new Size(112, 21);
			this.comboBoxColor.Size = size2;
			this.comboBoxColor.TabIndex = 0;
			this.groupBoxTeam.Controls.Add(this.radioButtonTeam0);
			this.groupBoxTeam.Controls.Add(this.radioButtonTeam1);
			this.groupBoxTeam.Controls.Add(this.radioButtonTeam2);
			this.groupBoxTeam.Controls.Add(this.radioButtonTeam3);
			this.groupBoxTeam.Controls.Add(this.radioButtonTeam4);
			this.groupBoxTeam.FlatStyle = FlatStyle.System;
			Point location3 = new Point(144, 136);
			this.groupBoxTeam.Location = location3;
			this.groupBoxTeam.Name = "groupBoxTeam";
			Size size3 = new Size(128, 104);
			this.groupBoxTeam.Size = size3;
			this.groupBoxTeam.TabIndex = 1;
			this.groupBoxTeam.TabStop = false;
			this.groupBoxTeam.Text = "Team";
			this.radioButtonTeam0.FlatStyle = FlatStyle.System;
			Point location4 = new Point(8, 16);
			this.radioButtonTeam0.Location = location4;
			this.radioButtonTeam0.Name = "radioButtonTeam0";
			Size size4 = new Size(104, 16);
			this.radioButtonTeam0.Size = size4;
			this.radioButtonTeam0.TabIndex = 5;
			this.radioButtonTeam0.Text = "Anarchist";
			this.radioButtonTeam1.FlatStyle = FlatStyle.System;
			Point location5 = new Point(8, 32);
			this.radioButtonTeam1.Location = location5;
			this.radioButtonTeam1.Name = "radioButtonTeam1";
			Size size5 = new Size(104, 16);
			this.radioButtonTeam1.Size = size5;
			this.radioButtonTeam1.TabIndex = 0;
			this.radioButtonTeam1.Text = "Team 1";
			this.radioButtonTeam2.FlatStyle = FlatStyle.System;
			Point location6 = new Point(8, 48);
			this.radioButtonTeam2.Location = location6;
			this.radioButtonTeam2.Name = "radioButtonTeam2";
			Size size6 = new Size(104, 16);
			this.radioButtonTeam2.Size = size6;
			this.radioButtonTeam2.TabIndex = 1;
			this.radioButtonTeam2.Text = "Team 2";
			this.radioButtonTeam3.FlatStyle = FlatStyle.System;
			Point location7 = new Point(8, 64);
			this.radioButtonTeam3.Location = location7;
			this.radioButtonTeam3.Name = "radioButtonTeam3";
			Size size7 = new Size(104, 16);
			this.radioButtonTeam3.Size = size7;
			this.radioButtonTeam3.TabIndex = 2;
			this.radioButtonTeam3.Text = "Team 3";
			this.radioButtonTeam4.FlatStyle = FlatStyle.System;
			Point location8 = new Point(8, 80);
			this.radioButtonTeam4.Location = location8;
			this.radioButtonTeam4.Name = "radioButtonTeam4";
			Size size8 = new Size(104, 16);
			this.radioButtonTeam4.Size = size8;
			this.radioButtonTeam4.TabIndex = 3;
			this.radioButtonTeam4.Text = "Team 4";
			this.groupBoxRace.Controls.Add(this.radioButtonRace0);
			this.groupBoxRace.Controls.Add(this.radioButtonRace1);
			this.groupBoxRace.Controls.Add(this.radioButtonRace2);
			this.groupBoxRace.Controls.Add(this.radioButtonRace3);
			this.groupBoxRace.Controls.Add(this.radioButtonRace4);
			this.groupBoxRace.Controls.Add(this.radioButtonRace5);
			this.groupBoxRace.FlatStyle = FlatStyle.System;
			Point location9 = new Point(144, 8);
			this.groupBoxRace.Location = location9;
			this.groupBoxRace.Name = "groupBoxRace";
			Size size9 = new Size(128, 120);
			this.groupBoxRace.Size = size9;
			this.groupBoxRace.TabIndex = 2;
			this.groupBoxRace.TabStop = false;
			this.groupBoxRace.Text = "Faction";
			this.radioButtonRace0.FlatStyle = FlatStyle.System;
			Point location10 = new Point(8, 16);
			this.radioButtonRace0.Location = location10;
			this.radioButtonRace0.Name = "radioButtonRace0";
			Size size10 = new Size(88, 16);
			this.radioButtonRace0.Size = size10;
			this.radioButtonRace0.TabIndex = 0;
			this.radioButtonRace0.Text = "Iraqi";
			this.radioButtonRace1.FlatStyle = FlatStyle.System;
			Point location11 = new Point(8, 32);
			this.radioButtonRace1.Location = location11;
			this.radioButtonRace1.Name = "radioButtonRace1";
			Size size11 = new Size(88, 16);
			this.radioButtonRace1.Size = size11;
			this.radioButtonRace1.TabIndex = 1;
			this.radioButtonRace1.Text = "JTF";
			this.radioButtonRace2.FlatStyle = FlatStyle.System;
			Point location12 = new Point(8, 48);
			this.radioButtonRace2.Location = location12;
			this.radioButtonRace2.Name = "radioButtonRace2";
			Size size12 = new Size(88, 16);
			this.radioButtonRace2.Size = size12;
			this.radioButtonRace2.TabIndex = 2;
			this.radioButtonRace2.Text = "Bosnian";
			this.radioButtonRace3.FlatStyle = FlatStyle.System;
			Point location13 = new Point(8, 64);
			this.radioButtonRace3.Location = location13;
			this.radioButtonRace3.Name = "radioButtonRace3";
			Size size13 = new Size(88, 16);
			this.radioButtonRace3.Size = size13;
			this.radioButtonRace3.TabIndex = 3;
			this.radioButtonRace3.Text = "Somalian";
			this.radioButtonRace4.FlatStyle = FlatStyle.System;
			Point location14 = new Point(8, 80);
			this.radioButtonRace4.Location = location14;
			this.radioButtonRace4.Name = "radioButtonRace4";
			Size size14 = new Size(88, 16);
			this.radioButtonRace4.Size = size14;
			this.radioButtonRace4.TabIndex = 4;
			this.radioButtonRace4.Text = "Colombian";
			this.radioButtonRace5.FlatStyle = FlatStyle.System;
			Point location15 = new Point(8, 96);
			this.radioButtonRace5.Location = location15;
			this.radioButtonRace5.Name = "radioButtonRace5";
			Size size15 = new Size(88, 16);
			this.radioButtonRace5.Size = size15;
			this.radioButtonRace5.TabIndex = 5;
			this.radioButtonRace5.Text = "Afghan";
			this.buttonOK.FlatStyle = FlatStyle.System;
			Point location16 = new Point(280, 216);
			this.buttonOK.Location = location16;
			this.buttonOK.Name = "buttonOK";
			Size size16 = new Size(72, 24);
			this.buttonOK.Size = size16;
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "OK";
			this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
			this.buttonCancel.FlatStyle = FlatStyle.System;
			Point location17 = new Point(360, 216);
			this.buttonCancel.Location = location17;
			this.buttonCancel.Name = "buttonCancel";
			Size size17 = new Size(64, 24);
			this.buttonCancel.Size = size17;
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
			this.groupBoxControl.Controls.Add(this.radioButtonControl0);
			this.groupBoxControl.Controls.Add(this.radioButtonControl1);
			this.groupBoxControl.Controls.Add(this.radioButtonControl2);
			this.groupBoxControl.Controls.Add(this.radioButtonControl3);
			this.groupBoxControl.Controls.Add(this.radioButtonControl4);
			this.groupBoxControl.Controls.Add(this.radioButtonControl5);
			this.groupBoxControl.FlatStyle = FlatStyle.System;
			Point location18 = new Point(8, 64);
			this.groupBoxControl.Location = location18;
			this.groupBoxControl.Name = "groupBoxControl";
			Size size18 = new Size(128, 128);
			this.groupBoxControl.Size = size18;
			this.groupBoxControl.TabIndex = 5;
			this.groupBoxControl.TabStop = false;
			this.groupBoxControl.Text = "Control";
			this.radioButtonControl0.FlatStyle = FlatStyle.System;
			Point location19 = new Point(8, 24);
			this.radioButtonControl0.Location = location19;
			this.radioButtonControl0.Name = "radioButtonControl0";
			Size size19 = new Size(104, 16);
			this.radioButtonControl0.Size = size19;
			this.radioButtonControl0.TabIndex = 0;
			this.radioButtonControl0.Text = "Human";
			this.radioButtonControl1.FlatStyle = FlatStyle.System;
			Point location20 = new Point(8, 40);
			this.radioButtonControl1.Location = location20;
			this.radioButtonControl1.Name = "radioButtonControl1";
			Size size20 = new Size(104, 16);
			this.radioButtonControl1.Size = size20;
			this.radioButtonControl1.TabIndex = 1;
			this.radioButtonControl1.Text = "Computer";
			this.radioButtonControl2.FlatStyle = FlatStyle.System;
			Point location21 = new Point(8, 56);
			this.radioButtonControl2.Location = location21;
			this.radioButtonControl2.Name = "radioButtonControl2";
			Size size21 = new Size(104, 16);
			this.radioButtonControl2.Size = size21;
			this.radioButtonControl2.TabIndex = 2;
			this.radioButtonControl2.Text = "Neutral";
			this.radioButtonControl3.FlatStyle = FlatStyle.System;
			Point location22 = new Point(8, 72);
			this.radioButtonControl3.Location = location22;
			this.radioButtonControl3.Name = "radioButtonControl3";
			Size size22 = new Size(104, 16);
			this.radioButtonControl3.Size = size22;
			this.radioButtonControl3.TabIndex = 3;
			this.radioButtonControl3.Text = "Rescuable";
			this.radioButtonControl4.FlatStyle = FlatStyle.System;
			Point location23 = new Point(8, 88);
			this.radioButtonControl4.Location = location23;
			this.radioButtonControl4.Name = "radioButtonControl4";
			Size size23 = new Size(104, 16);
			this.radioButtonControl4.Size = size23;
			this.radioButtonControl4.TabIndex = 4;
			this.radioButtonControl4.Text = "Spy";
			this.radioButtonControl5.FlatStyle = FlatStyle.System;
			Point location24 = new Point(8, 104);
			this.radioButtonControl5.Location = location24;
			this.radioButtonControl5.Name = "radioButtonControl5";
			Size size24 = new Size(104, 16);
			this.radioButtonControl5.Size = size24;
			this.radioButtonControl5.TabIndex = 5;
			this.radioButtonControl5.Text = "Civil";
			this.groupBoxResources.Controls.Add(this.numericMoney);
			this.groupBoxResources.Controls.Add(this.labelMoney);
			Point location25 = new Point(280, 136);
			this.groupBoxResources.Location = location25;
			this.groupBoxResources.Name = "groupBoxResources";
			Size size25 = new Size(144, 64);
			this.groupBoxResources.Size = size25;
			this.groupBoxResources.TabIndex = 6;
			this.groupBoxResources.TabStop = false;
			this.groupBoxResources.Text = "Resources";
			decimal increment = new decimal(new int[]
			{
				10,
				0,
				0,
				0
			});
			this.numericMoney.Increment = increment;
			Point location26 = new Point(8, 32);
			this.numericMoney.Location = location26;
			decimal maximum = new decimal(new int[]
			{
				1000000,
				0,
				0,
				0
			});
			this.numericMoney.Maximum = maximum;
			this.numericMoney.Name = "numericMoney";
			Size size26 = new Size(112, 20);
			this.numericMoney.Size = size26;
			this.numericMoney.TabIndex = 2;
			Point location27 = new Point(8, 16);
			this.labelMoney.Location = location27;
			this.labelMoney.Name = "labelMoney";
			Size size27 = new Size(56, 23);
			this.labelMoney.Size = size27;
			this.labelMoney.TabIndex = 1;
			this.labelMoney.Text = "Money";
			this.groupBoxTargetElector.Controls.Add(this.radioButton1);
			this.groupBoxTargetElector.Controls.Add(this.radioButton2);
			this.groupBoxTargetElector.Controls.Add(this.radioButton3);
			this.groupBoxTargetElector.Controls.Add(this.radioButton4);
			this.groupBoxTargetElector.Controls.Add(this.radioButton5);
			this.groupBoxTargetElector.Controls.Add(this.radioButton6);
			this.groupBoxTargetElector.FlatStyle = FlatStyle.System;
			Point location28 = new Point(280, 8);
			this.groupBoxTargetElector.Location = location28;
			this.groupBoxTargetElector.Name = "groupBoxTargetElector";
			Size size28 = new Size(144, 120);
			this.groupBoxTargetElector.Size = size28;
			this.groupBoxTargetElector.TabIndex = 6;
			this.groupBoxTargetElector.TabStop = false;
			this.groupBoxTargetElector.Text = "Target-elector";
			this.radioButton1.Enabled = false;
			this.radioButton1.FlatStyle = FlatStyle.System;
			Point location29 = new Point(8, 16);
			this.radioButton1.Location = location29;
			this.radioButton1.Name = "radioButton1";
			Size size29 = new Size(120, 16);
			this.radioButton1.Size = size29;
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "Nearest";
			this.radioButton1.CheckedChanged += new EventHandler(this.radioButton1_CheckedChanged);
			this.radioButton2.FlatStyle = FlatStyle.System;
			Point location30 = new Point(8, 32);
			this.radioButton2.Location = location30;
			this.radioButton2.Name = "radioButton2";
			Size size30 = new Size(120, 16);
			this.radioButton2.Size = size30;
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Best type";
			this.radioButton3.FlatStyle = FlatStyle.System;
			Point location31 = new Point(8, 48);
			this.radioButton3.Location = location31;
			this.radioButton3.Name = "radioButton3";
			Size size31 = new Size(128, 16);
			this.radioButton3.Size = size31;
			this.radioButton3.TabIndex = 2;
			this.radioButton3.Text = "Best damage/danger";
			this.radioButton4.Enabled = false;
			this.radioButton4.FlatStyle = FlatStyle.System;
			Point location32 = new Point(8, 64);
			this.radioButton4.Location = location32;
			this.radioButton4.Name = "radioButton4";
			Size size32 = new Size(120, 16);
			this.radioButton4.Size = size32;
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "Fastest kill";
			this.radioButton5.Enabled = false;
			this.radioButton5.FlatStyle = FlatStyle.System;
			Point location33 = new Point(8, 80);
			this.radioButton5.Location = location33;
			this.radioButton5.Name = "radioButton5";
			Size size33 = new Size(120, 16);
			this.radioButton5.Size = size33;
			this.radioButton5.TabIndex = 4;
			this.radioButton5.Text = "Fastest kill/danger";
			this.radioButton6.FlatStyle = FlatStyle.System;
			Point location34 = new Point(8, 96);
			this.radioButton6.Location = location34;
			this.radioButton6.Name = "radioButton6";
			Size size34 = new Size(120, 16);
			this.radioButton6.Size = size34;
			this.radioButton6.TabIndex = 5;
			this.radioButton6.Text = "Fastest kill/reward";
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(432, 245);
			base.ClientSize = clientSize;
			base.Controls.Add(this.groupBoxResources);
			base.Controls.Add(this.groupBoxControl);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.groupBoxRace);
			base.Controls.Add(this.groupBoxTeam);
			base.Controls.Add(this.groupBoxColor);
			base.Controls.Add(this.groupBoxTargetElector);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "PlayerForm";
			base.SizeGripStyle = SizeGripStyle.Hide;
			this.Text = "Player properties";
			this.groupBoxColor.ResumeLayout(false);
			this.groupBoxTeam.ResumeLayout(false);
			this.groupBoxRace.ResumeLayout(false);
			this.groupBoxControl.ResumeLayout(false);
			this.groupBoxResources.ResumeLayout(false);
			((ISupportInitialize)this.numericMoney).EndInit();
			this.groupBoxTargetElector.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
		}
	}
}
