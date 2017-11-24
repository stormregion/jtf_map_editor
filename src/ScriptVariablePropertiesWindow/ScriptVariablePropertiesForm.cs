using ScriptEditor;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScriptVariablePropertiesWindow
{
	public class ScriptVariablePropertiesForm : Form
	{
		private TextBox VarProp_AutoChangePeriod;

		private Label VarProp_AutoChangeModeLabel;

		private ComboBox VarProp_AutoChangeMode;

		private Label Variable_Name_Label;

		private TextBox VarProp_Name;

		private Label VarProp_Type_Label;

		private ComboBox VarProp_Type;

		private Label VarProp_Value_Label;

		private TextBox VarProp_Value;

		private Button VarProp_OK_Button;

		private Button VarProp_Cancel_Button;

		private Label VarProp_AutoChangeValue_Label;

		private TextBox VarProp_AutoChangeValue;

		private Label VarProp_AutoChangePeriod_Label;

		private Container components;

		private int Var_Used;

		private unsafe cEditor* Editor;

		private unsafe cTrigger* Trigger;

		public unsafe int Variable_AutoChange_Value
		{
			get
			{
				int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
				try
				{
					return ((IConvertible)this.VarProp_AutoChangeValue.Text).ToInt32(new NumberFormatInfo());
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			}
		}

		public unsafe int Variable_AutoChange_Period
		{
			get
			{
				int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
				try
				{
					return ((IConvertible)this.VarProp_AutoChangePeriod.Text).ToInt32(new NumberFormatInfo());
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			}
		}

		public int Variable_AutoChangeMode
		{
			get
			{
				return this.VarProp_AutoChangeMode.SelectedIndex;
			}
		}

		public unsafe int Variable_Value
		{
			get
			{
				int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
				try
				{
					return ((IConvertible)this.VarProp_Value.Text).ToInt32(new NumberFormatInfo());
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			}
		}

		public unsafe int Variable_Type
		{
			get
			{
				return *(this.VarProp_Type.SelectedIndex * 4 + ref <Module>.ScriptEditor.ValueTypeList);
			}
		}

		public string Variable_Name
		{
			get
			{
				return this.VarProp_Name.Text;
			}
		}

		public ScriptVariablePropertiesForm()
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
			this.VarProp_AutoChangeValue_Label = new Label();
			this.VarProp_AutoChangeValue = new TextBox();
			this.VarProp_AutoChangePeriod_Label = new Label();
			this.VarProp_AutoChangePeriod = new TextBox();
			this.VarProp_AutoChangeModeLabel = new Label();
			this.VarProp_AutoChangeMode = new ComboBox();
			this.Variable_Name_Label = new Label();
			this.VarProp_Name = new TextBox();
			this.VarProp_Type_Label = new Label();
			this.VarProp_Type = new ComboBox();
			this.VarProp_Value_Label = new Label();
			this.VarProp_Value = new TextBox();
			this.VarProp_OK_Button = new Button();
			this.VarProp_Cancel_Button = new Button();
			base.SuspendLayout();
			Point location = new Point(8, 168);
			this.VarProp_AutoChangeValue_Label.Location = location;
			this.VarProp_AutoChangeValue_Label.Name = "VarProp_AutoChangeValue_Label";
			Size size = new Size(80, 16);
			this.VarProp_AutoChangeValue_Label.Size = size;
			this.VarProp_AutoChangeValue_Label.TabIndex = 26;
			this.VarProp_AutoChangeValue_Label.Text = "Change value";
			Point location2 = new Point(104, 168);
			this.VarProp_AutoChangeValue.Location = location2;
			this.VarProp_AutoChangeValue.Name = "VarProp_AutoChangeValue";
			Size size2 = new Size(184, 20);
			this.VarProp_AutoChangeValue.Size = size2;
			this.VarProp_AutoChangeValue.TabIndex = 25;
			this.VarProp_AutoChangeValue.Text = "";
			Point location3 = new Point(8, 136);
			this.VarProp_AutoChangePeriod_Label.Location = location3;
			this.VarProp_AutoChangePeriod_Label.Name = "VarProp_AutoChangePeriod_Label";
			Size size3 = new Size(80, 16);
			this.VarProp_AutoChangePeriod_Label.Size = size3;
			this.VarProp_AutoChangePeriod_Label.TabIndex = 24;
			this.VarProp_AutoChangePeriod_Label.Text = "Change period";
			Point location4 = new Point(104, 136);
			this.VarProp_AutoChangePeriod.Location = location4;
			this.VarProp_AutoChangePeriod.Name = "VarProp_AutoChangePeriod";
			Size size4 = new Size(184, 20);
			this.VarProp_AutoChangePeriod.Size = size4;
			this.VarProp_AutoChangePeriod.TabIndex = 23;
			this.VarProp_AutoChangePeriod.Text = "";
			Point location5 = new Point(8, 104);
			this.VarProp_AutoChangeModeLabel.Location = location5;
			this.VarProp_AutoChangeModeLabel.Name = "VarProp_AutoChangeModeLabel";
			Size size5 = new Size(96, 16);
			this.VarProp_AutoChangeModeLabel.Size = size5;
			this.VarProp_AutoChangeModeLabel.TabIndex = 22;
			this.VarProp_AutoChangeModeLabel.Text = "AutoChangeMode";
			this.VarProp_AutoChangeMode.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location6 = new Point(104, 104);
			this.VarProp_AutoChangeMode.Location = location6;
			this.VarProp_AutoChangeMode.Name = "VarProp_AutoChangeMode";
			Size size6 = new Size(184, 21);
			this.VarProp_AutoChangeMode.Size = size6;
			this.VarProp_AutoChangeMode.TabIndex = 21;
			this.VarProp_AutoChangeMode.SelectedIndexChanged += new EventHandler(this.VarProp_AutoChangeMode_SelectedIndexChanged);
			Point location7 = new Point(8, 8);
			this.Variable_Name_Label.Location = location7;
			this.Variable_Name_Label.Name = "Variable_Name_Label";
			Size size7 = new Size(40, 16);
			this.Variable_Name_Label.Size = size7;
			this.Variable_Name_Label.TabIndex = 15;
			this.Variable_Name_Label.Text = "Name";
			Point location8 = new Point(56, 8);
			this.VarProp_Name.Location = location8;
			this.VarProp_Name.Name = "VarProp_Name";
			Size size8 = new Size(184, 20);
			this.VarProp_Name.Size = size8;
			this.VarProp_Name.TabIndex = 17;
			this.VarProp_Name.Text = "";
			Point location9 = new Point(8, 40);
			this.VarProp_Type_Label.Location = location9;
			this.VarProp_Type_Label.Name = "VarProp_Type_Label";
			Size size9 = new Size(40, 16);
			this.VarProp_Type_Label.Size = size9;
			this.VarProp_Type_Label.TabIndex = 16;
			this.VarProp_Type_Label.Text = "Type";
			this.VarProp_Type.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location10 = new Point(56, 40);
			this.VarProp_Type.Location = location10;
			this.VarProp_Type.Name = "VarProp_Type";
			Size size10 = new Size(184, 21);
			this.VarProp_Type.Size = size10;
			this.VarProp_Type.TabIndex = 19;
			this.VarProp_Type.SelectedIndexChanged += new EventHandler(this.VarProp_Type_SelectedIndexChanged);
			Point location11 = new Point(8, 72);
			this.VarProp_Value_Label.Location = location11;
			this.VarProp_Value_Label.Name = "VarProp_Value_Label";
			Size size11 = new Size(40, 16);
			this.VarProp_Value_Label.Size = size11;
			this.VarProp_Value_Label.TabIndex = 18;
			this.VarProp_Value_Label.Text = "Value";
			Point location12 = new Point(56, 72);
			this.VarProp_Value.Location = location12;
			this.VarProp_Value.Name = "VarProp_Value";
			Size size12 = new Size(184, 20);
			this.VarProp_Value.Size = size12;
			this.VarProp_Value.TabIndex = 20;
			this.VarProp_Value.Text = "";
			Point location13 = new Point(120, 208);
			this.VarProp_OK_Button.Location = location13;
			this.VarProp_OK_Button.Name = "VarProp_OK_Button";
			Size size13 = new Size(80, 23);
			this.VarProp_OK_Button.Size = size13;
			this.VarProp_OK_Button.TabIndex = 27;
			this.VarProp_OK_Button.Text = "OK";
			this.VarProp_OK_Button.Click += new EventHandler(this.VarProp_OK_Button_Click);
			this.VarProp_Cancel_Button.DialogResult = DialogResult.Cancel;
			Point location14 = new Point(208, 208);
			this.VarProp_Cancel_Button.Location = location14;
			this.VarProp_Cancel_Button.Name = "VarProp_Cancel_Button";
			Size size14 = new Size(80, 23);
			this.VarProp_Cancel_Button.Size = size14;
			this.VarProp_Cancel_Button.TabIndex = 28;
			this.VarProp_Cancel_Button.Text = "Cancel";
			base.AcceptButton = this.VarProp_OK_Button;
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			base.CancelButton = this.VarProp_Cancel_Button;
			Size clientSize = new Size(296, 245);
			base.ClientSize = clientSize;
			base.Controls.Add(this.VarProp_Cancel_Button);
			base.Controls.Add(this.VarProp_OK_Button);
			base.Controls.Add(this.VarProp_AutoChangeValue_Label);
			base.Controls.Add(this.VarProp_AutoChangeValue);
			base.Controls.Add(this.VarProp_AutoChangePeriod);
			base.Controls.Add(this.VarProp_Name);
			base.Controls.Add(this.VarProp_Value);
			base.Controls.Add(this.VarProp_AutoChangePeriod_Label);
			base.Controls.Add(this.VarProp_AutoChangeModeLabel);
			base.Controls.Add(this.VarProp_AutoChangeMode);
			base.Controls.Add(this.Variable_Name_Label);
			base.Controls.Add(this.VarProp_Type_Label);
			base.Controls.Add(this.VarProp_Type);
			base.Controls.Add(this.VarProp_Value_Label);
			base.MaximizeBox = false;
			Size maximumSize = new Size(304, 272);
			this.MaximumSize = maximumSize;
			Size minimumSize = new Size(304, 272);
			this.MinimumSize = minimumSize;
			base.Name = "ScriptVariablePropertiesForm";
			base.SizeGripStyle = SizeGripStyle.Hide;
			this.Text = "Variable Properties";
			base.ResumeLayout(false);
		}

		public unsafe void SetFrom(cEditor* editor, cTrigger* trigger, cVariable* variable)
		{
			this.Editor = editor;
			this.Trigger = trigger;
			int* ptr = (int*)(&<Module>.ScriptEditor.ValueTypeList);
			if (<Module>.ScriptEditor.ValueTypeList != 31)
			{
				do
				{
					ptr += 4 / sizeof(int);
				}
				while (*(int*)ptr != 31);
			}
			int num = ptr - ref <Module>.ScriptEditor.ValueTypeList / sizeof(int) >> 2;
			object[] array = new object[num];
			int* ptr2 = (int*)(&<Module>.ScriptEditor.ValueTypeList);
			int num2 = 0;
			if (0 < num)
			{
				do
				{
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr3 = <Module>.ScriptEditor.GetValueTypeAsString(&gBaseString<char>, *(int*)ptr2);
					try
					{
						uint num3 = (uint)(*(int*)ptr3);
						sbyte* value;
						if (num3 != 0u)
						{
							value = num3;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						array[num2] = new string((sbyte*)value);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
						throw;
					}
					if (gBaseString<char> != null)
					{
						<Module>.free(gBaseString<char>);
						gBaseString<char> = 0;
					}
					num2++;
					ptr2 += 4 / sizeof(int);
				}
				while (num2 < num);
			}
			this.VarProp_Type.Items.Clear();
			this.VarProp_Type.Items.AddRange(array);
			object[] array2 = new object[3];
			int num4 = 0;
			do
			{
				GBaseString<char> gBaseString<char>2;
				GBaseString<char>* ptr4 = <Module>.?GetAutoChangeModeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eAutoChange_Mode@cVariable@Script@@@Z(&gBaseString<char>2, num4);
				try
				{
					uint num5 = (uint)(*(int*)ptr4);
					sbyte* value2;
					if (num5 != 0u)
					{
						value2 = num5;
					}
					else
					{
						value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					array2[num4] = new string((sbyte*)value2);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
					throw;
				}
				if (gBaseString<char>2 != null)
				{
					<Module>.free(gBaseString<char>2);
					gBaseString<char>2 = 0;
				}
				num4++;
			}
			while (num4 < 3);
			this.VarProp_AutoChangeMode.Items.Clear();
			this.VarProp_AutoChangeMode.Items.AddRange(array2);
			bool flag = <Module>.ScriptEditor.cVariable.IsConstant(variable) != null;
			int* ptr5 = (int*)(&<Module>.ScriptEditor.ValueTypeList);
			if (<Module>.ScriptEditor.ValueTypeList != 31)
			{
				int num6 = *(variable + 16);
				int num7 = <Module>.ScriptEditor.ValueTypeList;
				while (num7 != num6)
				{
					ptr5 += 4 / sizeof(int);
					num7 = *(int*)ptr5;
					if (num7 == 31)
					{
						break;
					}
				}
			}
			int var_Used = *(variable + 32);
			this.Var_Used = var_Used;
			uint num8 = (uint)(*<Module>.ScriptEditor.cVariable.GetName(variable));
			sbyte* value3;
			if (num8 != 0u)
			{
				value3 = num8;
			}
			else
			{
				value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
			}
			this.VarProp_Name.Text = new string((sbyte*)value3);
			if (flag)
			{
				this.VarProp_Type.Enabled = false;
				this.VarProp_Type.SelectedIndex = -1;
				this.VarProp_Value.Enabled = false;
				this.VarProp_Value.Text = "0";
			}
			else
			{
				byte enabled;
				if (*(variable + 32) == 0 && *(variable + 40) == 0)
				{
					enabled = 1;
				}
				else
				{
					enabled = 0;
				}
				this.VarProp_Type.Enabled = (enabled != 0);
				this.VarProp_Type.SelectedIndex = ptr5 - ref <Module>.ScriptEditor.ValueTypeList / sizeof(int) >> 2;
				cVariable* ptr6 = variable + 16;
				if (*ptr6 - 1 <= 1)
				{
					this.VarProp_Value.Enabled = true;
					GBaseString<char> gBaseString<char>3;
					GBaseString<char>* ptr7 = <Module>.ScriptEditor.sValue.GetAsEditingString(ptr6, &gBaseString<char>3);
					try
					{
						uint num9 = (uint)(*(int*)ptr7);
						sbyte* value4;
						if (num9 != 0u)
						{
							value4 = num9;
						}
						else
						{
							value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						this.VarProp_Value.Text = new string((sbyte*)value4);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
						throw;
					}
					if (gBaseString<char>3 != null)
					{
						<Module>.free(gBaseString<char>3);
						gBaseString<char>3 = 0;
					}
				}
				else
				{
					this.VarProp_Value.Enabled = false;
					this.VarProp_Value.Text = "0";
				}
				if (*ptr6 == 2)
				{
					this.VarProp_AutoChangeMode.Enabled = true;
					this.VarProp_AutoChangeMode.SelectedIndex = *(variable + 40);
					if (*(variable + 40) == 0)
					{
						this.VarProp_AutoChangePeriod.Enabled = false;
						this.VarProp_AutoChangePeriod.Text = string.Empty;
						this.VarProp_AutoChangeValue.Enabled = false;
						this.VarProp_AutoChangeValue.Text = string.Empty;
						return;
					}
					this.VarProp_AutoChangePeriod.Enabled = true;
					int num10 = *(variable + 48);
					this.VarProp_AutoChangePeriod.Text = string.Format(new string((sbyte*)(&<Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@)), num10);
					this.VarProp_AutoChangeValue.Enabled = true;
					int num11 = *(variable + 44);
					this.VarProp_AutoChangeValue.Text = string.Format(new string((sbyte*)(&<Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@)), num11);
					return;
				}
			}
			this.VarProp_AutoChangeMode.Enabled = false;
			this.VarProp_AutoChangeMode.SelectedIndex = 0;
			this.VarProp_AutoChangePeriod.Enabled = false;
			this.VarProp_AutoChangePeriod.Text = string.Empty;
			this.VarProp_AutoChangeValue.Enabled = false;
			this.VarProp_AutoChangeValue.Text = string.Empty;
		}

		private void VarProp_OK_Button_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private unsafe void VarProp_Type_SelectedIndexChanged(object sender, EventArgs e)
		{
			int num = *(this.VarProp_Type.SelectedIndex * 4 + ref <Module>.ScriptEditor.ValueTypeList);
			if (num > 0 && num <= 2)
			{
				this.VarProp_Value.Enabled = true;
			}
			else
			{
				this.VarProp_Value.Enabled = false;
			}
			if (num == 2)
			{
				this.VarProp_AutoChangeMode.Enabled = true;
				if (this.VarProp_AutoChangeMode.SelectedIndex == 0)
				{
					this.VarProp_AutoChangePeriod.Enabled = false;
					this.VarProp_AutoChangeValue.Enabled = false;
				}
				else
				{
					this.VarProp_AutoChangePeriod.Enabled = true;
					this.VarProp_AutoChangeValue.Enabled = true;
				}
			}
			else
			{
				this.VarProp_AutoChangeMode.Enabled = false;
				this.VarProp_AutoChangePeriod.Enabled = false;
				this.VarProp_AutoChangeValue.Enabled = false;
			}
		}

		private void VarProp_AutoChangeMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.VarProp_AutoChangeMode.SelectedIndex == 0)
			{
				byte enabled = (this.Var_Used == 0) ? 1 : 0;
				this.VarProp_Type.Enabled = (enabled != 0);
				this.VarProp_AutoChangePeriod.Enabled = false;
				this.VarProp_AutoChangeValue.Enabled = false;
			}
			else
			{
				this.VarProp_Type.Enabled = false;
				this.VarProp_AutoChangePeriod.Enabled = true;
				this.VarProp_AutoChangeValue.Enabled = true;
			}
		}
	}
}
