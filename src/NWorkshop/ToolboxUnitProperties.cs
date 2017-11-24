using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxUnitProperties : UserControl
	{
		public unsafe delegate void __Delegate_PropertiesChanged(GUnitStats*);

		private GroupBox groupBox1;

		private TextBox textBoxHP;

		private Label label5;

		private TextBox textBoxAmmo;

		private TextBox textBoxCargo;

		private Label label6;

		private Label label7;

		private Label label8;

		private ComboBox comboBoxBehaviour;

		private Label label1;

		private Label label2;

		private ComboBox comboBoxPlayer;

		private TextBox textBoxScriptID;

		private ComboBox comboBoxLevel;

		private Label label4;

		private ComboBox comboBoxOwnedGear;

		private Label label3;

		private TextBox textBoxHPConcrete;

		private TextBox textBoxAmmoConcrete;

		private TextBox textBoxCargoConcrete;

		private Label label12;

		private Label label10;

		private Label label11;

		private GroupBox groupBoxUnitState;

		private RadioButton radioButton1;

		private RadioButton radioButton4;

		private RadioButton radioButton5;

		private RadioButton radioButton6;

		private RadioButton radioButton2;

		private RadioButton radioButton3;

		private RadioButton radioButton7;

		private CheckBox checkBoxRelax;

		private Label label9;

		private RadioButton radioButton8;

		private Label label13;

		private CheckBox checkBoxUnloadAtCriticalDamage;

		private unsafe GUnitStats* Stats;

		private unsafe GWorld* World;

		private Container components;

		public event ToolboxUnitProperties.__Delegate_PropertiesChanged PropertiesChanged
		{
			add
			{
				this.PropertiesChanged = Delegate.Combine(this.PropertiesChanged, value);
			}
			remove
			{
				this.PropertiesChanged = Delegate.Remove(this.PropertiesChanged, value);
			}
		}

		public unsafe ToolboxUnitProperties()
		{
			this.PropertiesChanged = null;
			GUnitStats* ptr = <Module>.@new(96u);
			GUnitStats* stats;
			try
			{
				if (ptr != null)
				{
					GBaseString<char>* ptr2 = ptr + 4 / sizeof(GUnitStats);
					*ptr2 = 0;
					*(ptr2 + 4) = 0;
					try
					{
						GBaseString<char>* ptr3 = ptr + 12 / sizeof(GUnitStats);
						*ptr3 = 0;
						*(ptr3 + 4) = 0;
						try
						{
							GBaseString<char>* ptr4 = ptr + 88 / sizeof(GUnitStats);
							*ptr4 = 0;
							*(ptr4 + 4) = 0;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(ptr + 12 / sizeof(GUnitStats)));
							throw;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(ptr + 4 / sizeof(GUnitStats)));
						throw;
					}
					stats = ptr;
				}
				else
				{
					stats = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr);
				throw;
			}
			this.Stats = stats;
			this.InitializeComponent();
			int num = 0;
			do
			{
				int num2 = num + 1;
				int num3 = num2;
				this.comboBoxPlayer.Items.Add("Player " + num3.ToString());
				num = num2;
			}
			while (num < 12);
			this.comboBoxBehaviour.Items.Add("Free move");
			this.comboBoxBehaviour.Items.Add("Hold move");
			this.comboBoxBehaviour.Items.Add("Guardian");
			this.comboBoxBehaviour.Items.Add("Partisan");
			this.comboBoxBehaviour.Items.Add("Fanatic");
			int num4 = 0;
			do
			{
				int num5 = num4 + 1;
				int num6 = num5;
				this.comboBoxLevel.Items.Add("Level " + num6.ToString());
				num4 = num5;
			}
			while (num4 < 5);
			int num7 = 0;
			do
			{
				int num8 = num7 + 1;
				int num9 = num8;
				this.comboBoxLevel.Items.Add("Hero Level " + num9.ToString());
				num7 = num8;
			}
			while (num7 < 10);
			this.comboBoxPlayer.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.comboBoxPlayer.Enabled = false;
			this.comboBoxLevel.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.comboBoxLevel.Enabled = false;
			this.textBoxScriptID.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxScriptID.Enabled = false;
			this.comboBoxBehaviour.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.comboBoxBehaviour.Enabled = false;
			this.checkBoxRelax.Enabled = false;
			this.checkBoxUnloadAtCriticalDamage.Enabled = false;
			this.textBoxHP.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxHP.Enabled = false;
			this.textBoxHPConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxHPConcrete.Enabled = false;
			this.textBoxAmmo.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxAmmo.Enabled = false;
			this.textBoxAmmoConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxAmmoConcrete.Enabled = false;
			this.textBoxCargo.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxCargo.Enabled = false;
			this.textBoxCargoConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxCargoConcrete.Enabled = false;
			this.comboBoxOwnedGear.Items.Add("No gear");
			int num10 = 0;
			if (0 < *(int*)(<Module>.UnitRegistry + 4 / sizeof(GUnitRegistry)))
			{
				do
				{
					int num11 = num10 * 4;
					int expr_330 = *(num11 + *(int*)<Module>.UnitRegistry);
					if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_330, *(*expr_330 + 48)))
					{
						GPEquipmentUnit* ptr5 = <Module>.__RTDynamicCast(*(num11 + *(int*)<Module>.UnitRegistry), 0, (void*)(&<Module>.??_R0?AVGPUnit@@@8), (void*)(&<Module>.??_R0?AVGPEquipmentUnit@@@8), 0);
						if (<Module>.GPEquipmentUnit.IsPassive(ptr5) == null)
						{
							uint num12 = (uint)(*(int*)(ptr5 + 380 / sizeof(GPEquipmentUnit)));
							sbyte* value;
							if (num12 != 0u)
							{
								value = num12;
							}
							else
							{
								value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							this.comboBoxOwnedGear.Items.Add(new string((sbyte*)value));
						}
					}
					num10++;
				}
				while (num10 < *(int*)(<Module>.UnitRegistry + 4 / sizeof(GUnitRegistry)));
			}
			this.comboBoxOwnedGear.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.comboBoxOwnedGear.Enabled = false;
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
			this.comboBoxPlayer = new ComboBox();
			this.textBoxScriptID = new TextBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.comboBoxLevel = new ComboBox();
			this.label4 = new Label();
			this.groupBox1 = new GroupBox();
			this.label11 = new Label();
			this.label10 = new Label();
			this.label12 = new Label();
			this.textBoxCargoConcrete = new TextBox();
			this.textBoxAmmoConcrete = new TextBox();
			this.textBoxHPConcrete = new TextBox();
			this.label7 = new Label();
			this.label6 = new Label();
			this.textBoxCargo = new TextBox();
			this.textBoxAmmo = new TextBox();
			this.label5 = new Label();
			this.textBoxHP = new TextBox();
			this.label8 = new Label();
			this.comboBoxBehaviour = new ComboBox();
			this.comboBoxOwnedGear = new ComboBox();
			this.label3 = new Label();
			this.groupBoxUnitState = new GroupBox();
			this.radioButton1 = new RadioButton();
			this.radioButton2 = new RadioButton();
			this.radioButton3 = new RadioButton();
			this.radioButton4 = new RadioButton();
			this.radioButton5 = new RadioButton();
			this.radioButton6 = new RadioButton();
			this.radioButton7 = new RadioButton();
			this.radioButton8 = new RadioButton();
			this.checkBoxRelax = new CheckBox();
			this.label9 = new Label();
			this.label13 = new Label();
			this.checkBoxUnloadAtCriticalDamage = new CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBoxUnitState.SuspendLayout();
			base.SuspendLayout();
			this.comboBoxPlayer.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location = new Point(80, 8);
			this.comboBoxPlayer.Location = location;
			this.comboBoxPlayer.Name = "comboBoxPlayer";
			Size size = new Size(176, 21);
			this.comboBoxPlayer.Size = size;
			this.comboBoxPlayer.MaxDropDownItems = 20;
			this.comboBoxPlayer.TabIndex = 0;
			this.comboBoxPlayer.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location2 = new Point(80, 56);
			this.textBoxScriptID.Location = location2;
			this.textBoxScriptID.Name = "textBoxScriptID";
			Size size2 = new Size(176, 20);
			this.textBoxScriptID.Size = size2;
			this.textBoxScriptID.TabIndex = 1;
			this.textBoxScriptID.Text = "ScriptID";
			this.textBoxScriptID.KeyDown += new KeyEventHandler(this.textBoxScriptID_KeyDown);
			this.textBoxScriptID.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location3 = new Point(32, 8);
			this.label1.Location = location3;
			this.label1.Name = "label1";
			Size size3 = new Size(48, 24);
			this.label1.Size = size3;
			this.label1.TabIndex = 2;
			this.label1.Text = "Owner:";
			this.label1.TextAlign = ContentAlignment.MiddleRight;
			Point location4 = new Point(32, 56);
			this.label2.Location = location4;
			this.label2.Name = "label2";
			Size size4 = new Size(48, 24);
			this.label2.Size = size4;
			this.label2.TabIndex = 3;
			this.label2.Text = "ScriptID:";
			this.label2.TextAlign = ContentAlignment.MiddleRight;
			this.comboBoxLevel.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location5 = new Point(80, 32);
			this.comboBoxLevel.Location = location5;
			this.comboBoxLevel.Name = "comboBoxLevel";
			Size size5 = new Size(176, 21);
			this.comboBoxLevel.Size = size5;
			this.comboBoxLevel.MaxDropDownItems = 20;
			this.comboBoxLevel.TabIndex = 6;
			this.comboBoxLevel.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location6 = new Point(32, 32);
			this.label4.Location = location6;
			this.label4.Name = "label4";
			Size size6 = new Size(48, 24);
			this.label4.Size = size6;
			this.label4.TabIndex = 7;
			this.label4.Text = "Level:";
			this.label4.TextAlign = ContentAlignment.MiddleRight;
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.textBoxCargoConcrete);
			this.groupBox1.Controls.Add(this.textBoxAmmoConcrete);
			this.groupBox1.Controls.Add(this.textBoxHPConcrete);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBoxCargo);
			this.groupBox1.Controls.Add(this.textBoxAmmo);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBoxHP);
			this.groupBox1.FlatStyle = FlatStyle.System;
			Point location7 = new Point(80, 192);
			this.groupBox1.Location = location7;
			this.groupBox1.Name = "groupBox1";
			Size size7 = new Size(176, 96);
			this.groupBox1.Size = size7;
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Stats";
			Point location8 = new Point(96, 64);
			this.label11.Location = location8;
			this.label11.Name = "label11";
			Size size8 = new Size(16, 24);
			this.label11.Size = size8;
			this.label11.TabIndex = 22;
			this.label11.Text = "%";
			this.label11.TextAlign = ContentAlignment.MiddleLeft;
			Point location9 = new Point(96, 40);
			this.label10.Location = location9;
			this.label10.Name = "label10";
			Size size9 = new Size(16, 24);
			this.label10.Size = size9;
			this.label10.TabIndex = 21;
			this.label10.Text = "%";
			this.label10.TextAlign = ContentAlignment.MiddleLeft;
			this.label10.Click += new EventHandler(this.label10_Click);
			Point location10 = new Point(96, 16);
			this.label12.Location = location10;
			this.label12.Name = "label12";
			Size size10 = new Size(16, 24);
			this.label12.Size = size10;
			this.label12.TabIndex = 20;
			this.label12.Text = "%";
			this.label12.TextAlign = ContentAlignment.MiddleLeft;
			this.textBoxCargoConcrete.Enabled = false;
			Point location11 = new Point(120, 64);
			this.textBoxCargoConcrete.Location = location11;
			this.textBoxCargoConcrete.Name = "textBoxCargoConcrete";
			Size size11 = new Size(32, 20);
			this.textBoxCargoConcrete.Size = size11;
			this.textBoxCargoConcrete.TabIndex = 19;
			this.textBoxCargoConcrete.Text = "Cargo";
			this.textBoxAmmoConcrete.Enabled = false;
			Point location12 = new Point(120, 40);
			this.textBoxAmmoConcrete.Location = location12;
			this.textBoxAmmoConcrete.Name = "textBoxAmmoConcrete";
			Size size12 = new Size(32, 20);
			this.textBoxAmmoConcrete.Size = size12;
			this.textBoxAmmoConcrete.TabIndex = 18;
			this.textBoxAmmoConcrete.Text = "Ammo";
			this.textBoxHPConcrete.Enabled = false;
			Point location13 = new Point(120, 16);
			this.textBoxHPConcrete.Location = location13;
			this.textBoxHPConcrete.Name = "textBoxHPConcrete";
			Size size13 = new Size(32, 20);
			this.textBoxHPConcrete.Size = size13;
			this.textBoxHPConcrete.TabIndex = 17;
			this.textBoxHPConcrete.Text = "HP";
			Point location14 = new Point(8, 64);
			this.label7.Location = location14;
			this.label7.Name = "label7";
			Size size14 = new Size(48, 24);
			this.label7.Size = size14;
			this.label7.TabIndex = 16;
			this.label7.Text = "Cargo";
			this.label7.TextAlign = ContentAlignment.MiddleLeft;
			Point location15 = new Point(8, 40);
			this.label6.Location = location15;
			this.label6.Name = "label6";
			Size size15 = new Size(56, 24);
			this.label6.Size = size15;
			this.label6.TabIndex = 15;
			this.label6.Text = "Ammo";
			this.label6.TextAlign = ContentAlignment.MiddleLeft;
			Point location16 = new Point(64, 64);
			this.textBoxCargo.Location = location16;
			this.textBoxCargo.Name = "textBoxCargo";
			Size size16 = new Size(32, 20);
			this.textBoxCargo.Size = size16;
			this.textBoxCargo.TabIndex = 13;
			this.textBoxCargo.Text = "Cargo";
			this.textBoxCargo.KeyDown += new KeyEventHandler(this.textBoxCargo_KeyDown);
			this.textBoxCargo.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location17 = new Point(64, 40);
			this.textBoxAmmo.Location = location17;
			this.textBoxAmmo.Name = "textBoxAmmo";
			Size size17 = new Size(32, 20);
			this.textBoxAmmo.Size = size17;
			this.textBoxAmmo.TabIndex = 12;
			this.textBoxAmmo.Text = "Ammo";
			this.textBoxAmmo.KeyDown += new KeyEventHandler(this.textBoxAmmo_KeyDown);
			this.textBoxAmmo.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location18 = new Point(8, 16);
			this.label5.Location = location18;
			this.label5.Name = "label5";
			Size size18 = new Size(40, 24);
			this.label5.Size = size18;
			this.label5.TabIndex = 11;
			this.label5.Text = "HP";
			this.label5.TextAlign = ContentAlignment.MiddleLeft;
			Point location19 = new Point(64, 16);
			this.textBoxHP.Location = location19;
			this.textBoxHP.Name = "textBoxHP";
			Size size19 = new Size(32, 20);
			this.textBoxHP.Size = size19;
			this.textBoxHP.TabIndex = 10;
			this.textBoxHP.Text = "HP";
			this.textBoxHP.KeyDown += new KeyEventHandler(this.textBoxHP_KeyDown);
			this.textBoxHP.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location20 = new Point(16, 80);
			this.label8.Location = location20;
			this.label8.Name = "label8";
			Size size20 = new Size(64, 24);
			this.label8.Size = size20;
			this.label8.TabIndex = 11;
			this.label8.Text = "Behaviour:";
			this.label8.TextAlign = ContentAlignment.MiddleRight;
			this.comboBoxBehaviour.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location21 = new Point(80, 80);
			this.comboBoxBehaviour.Location = location21;
			this.comboBoxBehaviour.Name = "comboBoxBehaviour";
			Size size21 = new Size(176, 21);
			this.comboBoxBehaviour.Size = size21;
			this.comboBoxBehaviour.TabIndex = 10;
			this.comboBoxBehaviour.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			this.comboBoxOwnedGear.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location22 = new Point(80, 296);
			this.comboBoxOwnedGear.Location = location22;
			this.comboBoxOwnedGear.Name = "comboBoxOwnedGear";
			Size size22 = new Size(176, 21);
			this.comboBoxOwnedGear.Size = size22;
			this.comboBoxOwnedGear.MaxDropDownItems = 20;
			this.comboBoxOwnedGear.TabIndex = 0;
			this.comboBoxOwnedGear.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location23 = new Point(8, 296);
			this.label3.Location = location23;
			this.label3.Name = "label3";
			Size size23 = new Size(72, 24);
			this.label3.Size = size23;
			this.label3.TabIndex = 14;
			this.label3.Text = "Equipment:";
			this.label3.TextAlign = ContentAlignment.MiddleRight;
			this.groupBoxUnitState.Controls.Add(this.radioButton1);
			this.groupBoxUnitState.Controls.Add(this.radioButton2);
			this.groupBoxUnitState.Controls.Add(this.radioButton3);
			this.groupBoxUnitState.Controls.Add(this.radioButton4);
			this.groupBoxUnitState.Controls.Add(this.radioButton5);
			this.groupBoxUnitState.Controls.Add(this.radioButton6);
			this.groupBoxUnitState.Controls.Add(this.radioButton7);
			this.groupBoxUnitState.Controls.Add(this.radioButton8);
			Point location24 = new Point(80, 104);
			this.groupBoxUnitState.Location = location24;
			this.groupBoxUnitState.Name = "groupBoxUnitState";
			Size size24 = new Size(176, 88);
			this.groupBoxUnitState.Size = size24;
			this.groupBoxUnitState.TabIndex = 15;
			this.groupBoxUnitState.TabStop = false;
			this.groupBoxUnitState.Text = "Unit state";
			this.groupBoxUnitState.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location25 = new Point(16, 16);
			this.radioButton1.Location = location25;
			this.radioButton1.Name = "radioButton1";
			Size size25 = new Size(64, 16);
			this.radioButton1.Size = size25;
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "Normal";
			Point location26 = new Point(16, 32);
			this.radioButton2.Location = location26;
			this.radioButton2.Name = "radioButton2";
			Size size26 = new Size(64, 16);
			this.radioButton2.Size = size26;
			this.radioButton2.TabIndex = 8;
			this.radioButton2.Text = "Knee";
			Point location27 = new Point(16, 48);
			this.radioButton3.Location = location27;
			this.radioButton3.Name = "radioButton3";
			Size size27 = new Size(64, 16);
			this.radioButton3.Size = size27;
			this.radioButton3.TabIndex = 10;
			this.radioButton3.Text = "Lay";
			Point location28 = new Point(16, 64);
			this.radioButton4.Location = location28;
			this.radioButton4.Name = "radioButton4";
			Size size28 = new Size(72, 16);
			this.radioButton4.Size = size28;
			this.radioButton4.TabIndex = 1;
			this.radioButton4.Text = "Walk";
			Point location29 = new Point(88, 16);
			this.radioButton5.Location = location29;
			this.radioButton5.Name = "radioButton5";
			Size size29 = new Size(82, 16);
			this.radioButton5.Size = size29;
			this.radioButton5.TabIndex = 2;
			this.radioButton5.Text = "Vehicle";
			Point location30 = new Point(88, 32);
			this.radioButton6.Location = location30;
			this.radioButton6.Name = "radioButton6";
			Size size30 = new Size(82, 16);
			this.radioButton6.Size = size30;
			this.radioButton6.TabIndex = 6;
			this.radioButton6.Text = "Fireposition";
			Point location31 = new Point(88, 48);
			this.radioButton7.Location = location31;
			this.radioButton7.Name = "radioButton7";
			Size size31 = new Size(64, 16);
			this.radioButton7.Size = size31;
			this.radioButton7.TabIndex = 11;
			this.radioButton7.Text = "Dug in";
			Point location32 = new Point(88, 64);
			this.radioButton8.Location = location32;
			this.radioButton8.Name = "radioButton8";
			Size size32 = new Size(64, 16);
			this.radioButton8.Size = size32;
			this.radioButton8.TabIndex = 12;
			this.radioButton8.Text = "Supply";
			Point location33 = new Point(240, 320);
			this.checkBoxRelax.Location = location33;
			this.checkBoxRelax.Name = "checkBoxRelax";
			Size size33 = new Size(16, 24);
			this.checkBoxRelax.Size = size33;
			this.checkBoxRelax.TabIndex = 16;
			this.checkBoxRelax.ThreeState = true;
			this.checkBoxRelax.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location34 = new Point(200, 320);
			this.label9.Location = location34;
			this.label9.Name = "label9";
			Size size34 = new Size(40, 24);
			this.label9.Size = size34;
			this.label9.TabIndex = 17;
			this.label9.Text = "Relax";
			this.label9.TextAlign = ContentAlignment.MiddleLeft;
			Point location35 = new Point(24, 320);
			this.label13.Location = location35;
			this.label13.Name = "label13";
			Size size35 = new Size(136, 24);
			this.label13.Size = size35;
			this.label13.TabIndex = 19;
			this.label13.Text = "Unload at critical damage";
			this.label13.TextAlign = ContentAlignment.MiddleLeft;
			Point location36 = new Point(160, 320);
			this.checkBoxUnloadAtCriticalDamage.Location = location36;
			this.checkBoxUnloadAtCriticalDamage.Name = "checkBoxUnloadAtCriticalDamage";
			Size size36 = new Size(16, 24);
			this.checkBoxUnloadAtCriticalDamage.Size = size36;
			this.checkBoxUnloadAtCriticalDamage.TabIndex = 18;
			this.checkBoxUnloadAtCriticalDamage.ThreeState = true;
			this.checkBoxUnloadAtCriticalDamage.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.checkBoxUnloadAtCriticalDamage);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.checkBoxRelax);
			base.Controls.Add(this.groupBoxUnitState);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.comboBoxBehaviour);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.comboBoxLevel);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textBoxScriptID);
			base.Controls.Add(this.comboBoxPlayer);
			base.Controls.Add(this.comboBoxOwnedGear);
			base.Name = "ToolboxUnitProperties";
			Size size37 = new Size(264, 352);
			base.Size = size37;
			this.groupBox1.ResumeLayout(false);
			this.groupBoxUnitState.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public unsafe void Refresh(GEditorWorld* world)
		{
			<Module>.GEditorWorld.GetSelectedWUnitStats(world, this.Stats);
			int num = *(int*)this.Stats;
			if (num == -1)
			{
				this.comboBoxPlayer.SelectedIndex = -1;
				this.comboBoxPlayer.Enabled = false;
			}
			else if (num == -2)
			{
				this.comboBoxPlayer.SelectedIndex = -1;
				this.comboBoxPlayer.Enabled = true;
			}
			else
			{
				this.comboBoxPlayer.SelectedIndex = num;
				this.comboBoxPlayer.Enabled = true;
			}
			int num2 = *(int*)(this.Stats + 44 / sizeof(GUnitStats));
			if (num2 == -1)
			{
				this.comboBoxLevel.SelectedIndex = -1;
				this.comboBoxLevel.Enabled = false;
			}
			else if (num2 == -2)
			{
				this.comboBoxLevel.SelectedIndex = -1;
				this.comboBoxLevel.Enabled = true;
			}
			else
			{
				this.comboBoxLevel.SelectedIndex = num2;
				this.comboBoxLevel.Enabled = true;
			}
			if (((<Module>.GBaseString<char>.Compare(this.Stats + 4 / sizeof(GUnitStats), (sbyte*)(&<Module>.??_C@_02PGHGPEOM@?91?$AA@), false) == 0) ? 1 : 0) != 0)
			{
				this.textBoxScriptID.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxScriptID.Enabled = false;
			}
			else if (((<Module>.GBaseString<char>.Compare(this.Stats + 4 / sizeof(GUnitStats), (sbyte*)(&<Module>.??_C@_02NNFLKHCP@?92?$AA@), false) == 0) ? 1 : 0) != 0)
			{
				this.textBoxScriptID.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxScriptID.Enabled = true;
			}
			else
			{
				uint num3 = (uint)(*(int*)(this.Stats + 4 / sizeof(GUnitStats)));
				sbyte* value;
				if (num3 != 0u)
				{
					value = num3;
				}
				else
				{
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				this.textBoxScriptID.Text = new string((sbyte*)value);
				this.textBoxScriptID.Enabled = true;
			}
			int num4 = *(int*)(this.Stats + 48 / sizeof(GUnitStats));
			if (num4 == -1)
			{
				this.comboBoxBehaviour.SelectedIndex = -1;
				this.comboBoxBehaviour.Enabled = false;
			}
			else if (num4 == -2)
			{
				this.comboBoxBehaviour.SelectedIndex = -1;
				this.comboBoxBehaviour.Enabled = true;
			}
			else
			{
				this.comboBoxBehaviour.SelectedIndex = num4;
				this.comboBoxBehaviour.Enabled = true;
			}
			int num5 = *(int*)(this.Stats + 52 / sizeof(GUnitStats));
			if (num5 == -1)
			{
				this.UpdateUnitStateGroupBox();
				this.groupBoxUnitState.Enabled = false;
			}
			else if (num5 == -2)
			{
				this.UpdateUnitStateGroupBox();
				this.groupBoxUnitState.Enabled = true;
			}
			else
			{
				this.UpdateUnitStateGroupBox();
				this.groupBoxUnitState.Enabled = true;
			}
			int num6 = *(int*)(this.Stats + 68 / sizeof(GUnitStats));
			if (num6 == -1)
			{
				this.checkBoxRelax.CheckState = CheckState.Indeterminate;
				this.checkBoxRelax.Enabled = false;
			}
			else if (num6 == -2)
			{
				this.checkBoxRelax.CheckState = CheckState.Indeterminate;
				this.checkBoxRelax.Enabled = true;
			}
			else
			{
				if (num6 != 0)
				{
					this.checkBoxRelax.CheckState = CheckState.Checked;
				}
				else
				{
					this.checkBoxRelax.CheckState = CheckState.Unchecked;
				}
				this.checkBoxRelax.Enabled = true;
			}
			int num7 = *(int*)(this.Stats + 72 / sizeof(GUnitStats));
			if (num7 == -1)
			{
				this.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Indeterminate;
				this.checkBoxUnloadAtCriticalDamage.Enabled = false;
			}
			else if (num7 == -2)
			{
				this.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Indeterminate;
				this.checkBoxUnloadAtCriticalDamage.Enabled = true;
			}
			else
			{
				if (num7 != 0)
				{
					this.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Checked;
				}
				else
				{
					this.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Unchecked;
				}
				this.checkBoxUnloadAtCriticalDamage.Enabled = true;
			}
			GUnitStats* ptr = this.Stats + 20 / sizeof(GUnitStats);
			int num8 = *(int*)ptr;
			if (num8 == -1)
			{
				this.textBoxHP.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxHP.Enabled = false;
			}
			else if (num8 == -2)
			{
				this.textBoxHP.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxHP.Enabled = true;
			}
			else
			{
				int num9 = *(int*)ptr;
				this.textBoxHP.Text = num9.ToString();
				this.textBoxHP.Enabled = true;
			}
			GUnitStats* ptr2 = this.Stats + 24 / sizeof(GUnitStats);
			int num10 = *(int*)ptr2;
			if (num10 == -1)
			{
				this.textBoxHPConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			}
			else if (num10 == -2)
			{
				this.textBoxHPConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			}
			else
			{
				int num11 = *(int*)ptr2;
				this.textBoxHPConcrete.Text = num11.ToString();
			}
			GUnitStats* ptr3 = this.Stats + 28 / sizeof(GUnitStats);
			int num12 = *(int*)ptr3;
			if (num12 == -1)
			{
				this.textBoxAmmo.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxAmmo.Enabled = false;
			}
			else if (num12 == -2)
			{
				this.textBoxAmmo.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxAmmo.Enabled = true;
			}
			else
			{
				int num13 = *(int*)ptr3;
				this.textBoxAmmo.Text = num13.ToString();
				this.textBoxAmmo.Enabled = true;
			}
			GUnitStats* stats = this.Stats;
			if (*(int*)(stats + 32 / sizeof(GUnitStats)) == -1)
			{
				this.textBoxAmmoConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			}
			else if (*(int*)(stats + 24 / sizeof(GUnitStats)) == -2)
			{
				this.textBoxAmmoConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			}
			else
			{
				int num14 = *(int*)(stats + 32 / sizeof(GUnitStats));
				this.textBoxAmmoConcrete.Text = num14.ToString();
			}
			GUnitStats* ptr4 = this.Stats + 36 / sizeof(GUnitStats);
			int num15 = *(int*)ptr4;
			if (num15 == -1)
			{
				this.textBoxCargo.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxCargo.Enabled = false;
			}
			else if (num15 == -2)
			{
				this.textBoxCargo.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxCargo.Enabled = true;
			}
			else
			{
				int num16 = *(int*)ptr4;
				this.textBoxCargo.Text = num16.ToString();
				this.textBoxCargo.Enabled = true;
			}
			GUnitStats* ptr5 = this.Stats + 40 / sizeof(GUnitStats);
			int num17 = *(int*)ptr5;
			if (num17 == -1)
			{
				this.textBoxCargoConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			}
			else if (num17 == -2)
			{
				this.textBoxCargoConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			}
			else
			{
				int num18 = *(int*)ptr5;
				this.textBoxCargoConcrete.Text = num18.ToString();
			}
			GUnitStats* stats2 = this.Stats;
			int num19 = *(int*)(stats2 + 84 / sizeof(GUnitStats));
			if (num19 == -1)
			{
				this.comboBoxOwnedGear.SelectedIndex = -1;
				this.comboBoxOwnedGear.Enabled = false;
			}
			else if (num19 == -2)
			{
				this.comboBoxOwnedGear.SelectedIndex = -1;
				this.comboBoxOwnedGear.Enabled = true;
			}
			else
			{
				if (((*(int*)(stats2 + 92 / sizeof(GUnitStats)) == 0) ? 1 : 0) != 0)
				{
					this.comboBoxOwnedGear.SelectedIndex = 0;
				}
				else
				{
					uint num20 = (uint)(*(int*)(stats2 + 88 / sizeof(GUnitStats)));
					sbyte* value2;
					if (num20 != 0u)
					{
						value2 = num20;
					}
					else
					{
						value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					this.comboBoxOwnedGear.Text = new string((sbyte*)value2);
				}
				this.comboBoxOwnedGear.Enabled = true;
			}
		}

		public unsafe void UpdateStats()
		{
			GBaseString<char> gBaseString<char> = 0;
			*(ref gBaseString<char> + 4) = 0;
			try
			{
				*(int*)this.Stats = this.comboBoxPlayer.SelectedIndex;
				*(int*)(this.Stats + 44 / sizeof(GUnitStats)) = this.comboBoxLevel.SelectedIndex;
				GBaseString<char> gBaseString<char>2;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, this.textBoxScriptID.Text);
				try
				{
					int num = *(ptr + 4);
					if (num != 0)
					{
						*(ref gBaseString<char> + 4) = num;
						uint num2 = (uint)(*(ref gBaseString<char> + 4) + 1);
						gBaseString<char> = <Module>.realloc(null, num2);
						cpblk(gBaseString<char>, *ptr, num2);
					}
					else
					{
						*(ref gBaseString<char> + 4) = 0;
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
					throw;
				}
				if (gBaseString<char>2 != null)
				{
					<Module>.free(gBaseString<char>2);
				}
				if (((*(ref gBaseString<char> + 4) == 0) ? 1 : 0) != 0)
				{
					<Module>.GBaseString<char>.=(this.Stats + 4 / sizeof(GUnitStats), (sbyte*)(&<Module>.??_C@_02PGHGPEOM@?91?$AA@));
				}
				else
				{
					GBaseString<char>* ptr2 = this.Stats + 4 / sizeof(GUnitStats);
					if (*(ref gBaseString<char> + 4) != 0)
					{
						*(ptr2 + 4) = *(ref gBaseString<char> + 4);
						void* ptr3 = <Module>.realloc(*ptr2, (uint)(*(ref gBaseString<char> + 4) + 1));
						*ptr2 = ptr3;
						cpblk(ptr3, gBaseString<char>, *(ptr2 + 4) + 1);
					}
					else
					{
						*(ptr2 + 4) = 0;
						int num3 = *ptr2;
						if (num3 != 0)
						{
							<Module>.free(num3);
							*ptr2 = 0;
						}
					}
				}
				*(int*)(this.Stats + 48 / sizeof(GUnitStats)) = this.comboBoxBehaviour.SelectedIndex;
				*(int*)(this.Stats + 52 / sizeof(GUnitStats)) = this.GetUnitState();
				*(int*)(this.Stats + 68 / sizeof(GUnitStats)) = (this.checkBoxRelax.Checked ? 1 : 0);
				*(int*)(this.Stats + 72 / sizeof(GUnitStats)) = (this.checkBoxUnloadAtCriticalDamage.Checked ? 1 : 0);
				GBaseString<char> gBaseString<char>3;
				GBaseString<char>* ptr4 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, this.textBoxHP.Text);
				try
				{
					int num4 = *(ptr4 + 4);
					if (num4 != 0)
					{
						*(ref gBaseString<char> + 4) = num4;
						uint num5 = (uint)(*(ref gBaseString<char> + 4) + 1);
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num5);
						cpblk(gBaseString<char>, *ptr4, num5);
					}
					else
					{
						*(ref gBaseString<char> + 4) = 0;
						if (gBaseString<char> != null)
						{
							<Module>.free(gBaseString<char>);
							gBaseString<char> = 0;
						}
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
				if (gBaseString<char>3 != null)
				{
					<Module>.free(gBaseString<char>3);
				}
				if (((*(ref gBaseString<char> + 4) == 0) ? 1 : 0) != 0)
				{
					*(int*)(this.Stats + 20 / sizeof(GUnitStats)) = -1;
				}
				else
				{
					sbyte* ptr5;
					if (gBaseString<char> != null)
					{
						ptr5 = gBaseString<char>;
					}
					else
					{
						ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					*(int*)(this.Stats + 20 / sizeof(GUnitStats)) = <Module>.atoi(ptr5);
				}
				GBaseString<char> gBaseString<char>4;
				GBaseString<char>* ptr6 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>4, this.textBoxAmmo.Text);
				try
				{
					int num6 = *(ptr6 + 4);
					if (num6 != 0)
					{
						*(ref gBaseString<char> + 4) = num6;
						uint num7 = (uint)(*(ref gBaseString<char> + 4) + 1);
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num7);
						cpblk(gBaseString<char>, *ptr6, num7);
					}
					else
					{
						*(ref gBaseString<char> + 4) = 0;
						if (gBaseString<char> != null)
						{
							<Module>.free(gBaseString<char>);
							gBaseString<char> = 0;
						}
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
					throw;
				}
				if (gBaseString<char>4 != null)
				{
					<Module>.free(gBaseString<char>4);
				}
				if (((*(ref gBaseString<char> + 4) == 0) ? 1 : 0) != 0)
				{
					*(int*)(this.Stats + 28 / sizeof(GUnitStats)) = -1;
				}
				else
				{
					sbyte* ptr7;
					if (gBaseString<char> != null)
					{
						ptr7 = gBaseString<char>;
					}
					else
					{
						ptr7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					*(int*)(this.Stats + 28 / sizeof(GUnitStats)) = <Module>.atoi(ptr7);
				}
				GBaseString<char> gBaseString<char>5;
				GBaseString<char>* ptr8 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>5, this.textBoxCargo.Text);
				try
				{
					int num8 = *(ptr8 + 4);
					if (num8 != 0)
					{
						*(ref gBaseString<char> + 4) = num8;
						uint num9 = (uint)(*(ref gBaseString<char> + 4) + 1);
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num9);
						cpblk(gBaseString<char>, *ptr8, num9);
					}
					else
					{
						*(ref gBaseString<char> + 4) = 0;
						if (gBaseString<char> != null)
						{
							<Module>.free(gBaseString<char>);
							gBaseString<char> = 0;
						}
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>5));
					throw;
				}
				if (gBaseString<char>5 != null)
				{
					<Module>.free(gBaseString<char>5);
				}
				if (((*(ref gBaseString<char> + 4) == 0) ? 1 : 0) != 0)
				{
					*(int*)(this.Stats + 36 / sizeof(GUnitStats)) = -1;
				}
				else
				{
					sbyte* ptr9;
					if (gBaseString<char> != null)
					{
						ptr9 = gBaseString<char>;
					}
					else
					{
						ptr9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					*(int*)(this.Stats + 36 / sizeof(GUnitStats)) = <Module>.atoi(ptr9);
				}
				GBaseString<char> gBaseString<char>6;
				GBaseString<char>* ptr10 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>6, this.comboBoxOwnedGear.Text);
				try
				{
					int num10 = *(ptr10 + 4);
					if (num10 != 0)
					{
						*(ref gBaseString<char> + 4) = num10;
						uint num11 = (uint)(*(ref gBaseString<char> + 4) + 1);
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num11);
						cpblk(gBaseString<char>, *ptr10, num11);
					}
					else
					{
						*(ref gBaseString<char> + 4) = 0;
						if (gBaseString<char> != null)
						{
							<Module>.free(gBaseString<char>);
							gBaseString<char> = 0;
						}
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
					throw;
				}
				if (gBaseString<char>6 != null)
				{
					<Module>.free(gBaseString<char>6);
				}
				if (this.comboBoxOwnedGear.SelectedIndex == 0)
				{
					*(int*)(this.Stats + 84 / sizeof(GUnitStats)) = 0;
					GBaseString<char>* ptr11 = this.Stats + 88 / sizeof(GUnitStats);
					uint num12 = (uint)(*ptr11);
					if (num12 != 0u)
					{
						<Module>.free(num12);
						*ptr11 = 0;
					}
					*(ptr11 + 4) = 0;
				}
				else if (((*(ref gBaseString<char> + 4) == 0) ? 1 : 0) != 0)
				{
					*(int*)(this.Stats + 84 / sizeof(GUnitStats)) = -1;
				}
				else
				{
					*(int*)(this.Stats + 84 / sizeof(GUnitStats)) = 1;
					<Module>.GBaseString<char>.=(this.Stats + 88 / sizeof(GUnitStats), ref gBaseString<char>);
				}
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
		}

		public int GetUnitState()
		{
			IEnumerator enumerator = this.groupBoxUnitState.Controls.GetEnumerator();
			int num = 0;
			if (enumerator.MoveNext())
			{
				while (!(enumerator.Current as RadioButton).Checked)
				{
					num++;
					if (!enumerator.MoveNext())
					{
						return -1;
					}
				}
				return num;
			}
			return -1;
		}

		public unsafe void UpdateUnitStateGroupBox()
		{
			IEnumerator enumerator = this.groupBoxUnitState.Controls.GetEnumerator();
			int num = 0;
			if (enumerator.MoveNext())
			{
				do
				{
					if (*(byte*)(num / sizeof(GUnitStats) + this.Stats + 56 / sizeof(GUnitStats)) != 0)
					{
						(enumerator.Current as RadioButton).Enabled = true;
					}
					else
					{
						(enumerator.Current as RadioButton).Enabled = false;
					}
					num++;
				}
				while (enumerator.MoveNext());
			}
			int num2 = *(int*)(this.Stats + 52 / sizeof(GUnitStats));
			if (num2 == -1)
			{
				if (enumerator.MoveNext())
				{
					do
					{
						(enumerator.Current as RadioButton).Checked = false;
					}
					while (enumerator.MoveNext());
				}
			}
			else if (num2 >= 0)
			{
				num2 = *(int*)(this.Stats + 52 / sizeof(GUnitStats));
				if (num2 < this.groupBoxUnitState.Controls.Count)
				{
					(this.groupBoxUnitState.Controls[num2] as RadioButton).Checked = true;
				}
			}
		}

		private void ToolboxUnitProperties_Validated(object sender, EventArgs e)
		{
			this.UpdateStats();
			this.raise_PropertiesChanged(this.Stats);
		}

		private void textBoxHP_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.ToolboxUnitProperties_Validated(this, null);
			}
		}

		private void textBoxAmmo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.ToolboxUnitProperties_Validated(this, null);
			}
		}

		private void textBoxCargo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.ToolboxUnitProperties_Validated(this, null);
			}
		}

		private void textBoxScriptID_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.ToolboxUnitProperties_Validated(this, null);
			}
		}

		private void textBoxGroupID_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				this.ToolboxUnitProperties_Validated(this, null);
			}
		}

		private void label10_Click(object sender, EventArgs e)
		{
		}

		protected unsafe void raise_PropertiesChanged(GUnitStats* i1)
		{
			ToolboxUnitProperties.__Delegate_PropertiesChanged propertiesChanged = this.PropertiesChanged;
			if (propertiesChanged != null)
			{
				propertiesChanged(i1);
			}
		}
	}
}
