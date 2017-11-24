using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxBuildingProperties : UserControl
	{
		public unsafe delegate void __Delegate_PropertiesChanged(GUnitStats*);

		private Label label2;

		private TextBox textBoxScriptID;

		private Label label13;

		private CheckBox checkBoxUnloadAtCriticalDamage;

		private Label label1;

		private Label label3;

		private TextBox textBoxHPConcrete;

		private TextBox textBoxHP;

		private unsafe GUnitStats* Stats;

		private unsafe GWorld* World;

		private Container components;

		public event ToolboxBuildingProperties.__Delegate_PropertiesChanged PropertiesChanged
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

		public unsafe ToolboxBuildingProperties()
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
			this.textBoxScriptID.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxScriptID.Enabled = false;
			this.checkBoxUnloadAtCriticalDamage.Enabled = false;
			this.textBoxHP.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxHP.Enabled = false;
			this.textBoxHPConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.textBoxHPConcrete.Enabled = false;
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
			this.textBoxScriptID = new TextBox();
			this.label2 = new Label();
			this.label13 = new Label();
			this.checkBoxUnloadAtCriticalDamage = new CheckBox();
			this.label1 = new Label();
			this.textBoxHPConcrete = new TextBox();
			this.label3 = new Label();
			this.textBoxHP = new TextBox();
			base.SuspendLayout();
			Point location = new Point(56, 8);
			this.textBoxScriptID.Location = location;
			this.textBoxScriptID.Name = "textBoxScriptID";
			Size size = new Size(200, 20);
			this.textBoxScriptID.Size = size;
			this.textBoxScriptID.TabIndex = 1;
			this.textBoxScriptID.Text = "ScriptID";
			this.textBoxScriptID.KeyDown += new KeyEventHandler(this.textBoxScriptID_KeyDown);
			this.textBoxScriptID.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location2 = new Point(0, 8);
			this.label2.Location = location2;
			this.label2.Name = "label2";
			Size size2 = new Size(48, 24);
			this.label2.Size = size2;
			this.label2.TabIndex = 3;
			this.label2.Text = "ScriptID:";
			this.label2.TextAlign = ContentAlignment.MiddleRight;
			Point location3 = new Point(104, 32);
			this.label13.Location = location3;
			this.label13.Name = "label13";
			Size size3 = new Size(136, 24);
			this.label13.Size = size3;
			this.label13.TabIndex = 19;
			this.label13.Text = "Unload at critical damage";
			this.label13.TextAlign = ContentAlignment.MiddleLeft;
			Point location4 = new Point(240, 32);
			this.checkBoxUnloadAtCriticalDamage.Location = location4;
			this.checkBoxUnloadAtCriticalDamage.Name = "checkBoxUnloadAtCriticalDamage";
			Size size4 = new Size(16, 24);
			this.checkBoxUnloadAtCriticalDamage.Size = size4;
			this.checkBoxUnloadAtCriticalDamage.TabIndex = 18;
			this.checkBoxUnloadAtCriticalDamage.Text = "checkBox1";
			this.checkBoxUnloadAtCriticalDamage.ThreeState = true;
			this.checkBoxUnloadAtCriticalDamage.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			Point location5 = new Point(56, 32);
			this.label1.Location = location5;
			this.label1.Name = "label1";
			Size size5 = new Size(24, 24);
			this.label1.Size = size5;
			this.label1.TabIndex = 24;
			this.label1.Text = "%";
			this.label1.TextAlign = ContentAlignment.MiddleLeft;
			this.textBoxHPConcrete.Enabled = false;
			Point location6 = new Point(80, 32);
			this.textBoxHPConcrete.Location = location6;
			this.textBoxHPConcrete.Name = "textBoxHPConcrete";
			Size size6 = new Size(24, 20);
			this.textBoxHPConcrete.Size = size6;
			this.textBoxHPConcrete.TabIndex = 23;
			this.textBoxHPConcrete.Text = "HP";
			Point location7 = new Point(8, 32);
			this.label3.Location = location7;
			this.label3.Name = "label3";
			Size size7 = new Size(24, 24);
			this.label3.Size = size7;
			this.label3.TabIndex = 22;
			this.label3.Text = "HP";
			this.label3.TextAlign = ContentAlignment.MiddleLeft;
			Point location8 = new Point(32, 32);
			this.textBoxHP.Location = location8;
			this.textBoxHP.Name = "textBoxHP";
			Size size8 = new Size(24, 20);
			this.textBoxHP.Size = size8;
			this.textBoxHP.TabIndex = 21;
			this.textBoxHP.Text = "HP";
			this.textBoxHP.Validated += new EventHandler(this.ToolboxUnitProperties_Validated);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.textBoxHPConcrete);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.textBoxHP);
			base.Controls.Add(this.label13);
			base.Controls.Add(this.checkBoxUnloadAtCriticalDamage);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.textBoxScriptID);
			base.Name = "ToolboxBuildingProperties";
			Size size9 = new Size(264, 64);
			base.Size = size9;
			base.ResumeLayout(false);
		}

		public unsafe void Refresh(GEditorWorld* world)
		{
			<Module>.GEditorWorld.GetSelectedWUnitStats(world, this.Stats);
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
				uint num = (uint)(*(int*)(this.Stats + 4 / sizeof(GUnitStats)));
				sbyte* value;
				if (num != 0u)
				{
					value = num;
				}
				else
				{
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				this.textBoxScriptID.Text = new string((sbyte*)value);
				this.textBoxScriptID.Enabled = true;
			}
			int num2 = *(int*)(this.Stats + 72 / sizeof(GUnitStats));
			if (num2 == -1)
			{
				this.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Indeterminate;
				this.checkBoxUnloadAtCriticalDamage.Enabled = false;
			}
			else if (num2 == -2)
			{
				this.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Indeterminate;
				this.checkBoxUnloadAtCriticalDamage.Enabled = true;
			}
			else
			{
				if (num2 != 0)
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
			int num3 = *(int*)ptr;
			if (num3 == -1)
			{
				this.textBoxHP.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxHP.Enabled = false;
			}
			else if (num3 == -2)
			{
				this.textBoxHP.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
				this.textBoxHP.Enabled = true;
			}
			else
			{
				int num4 = *(int*)ptr;
				this.textBoxHP.Text = num4.ToString();
				this.textBoxHP.Enabled = true;
			}
			GUnitStats* ptr2 = this.Stats + 24 / sizeof(GUnitStats);
			int num5 = *(int*)ptr2;
			if (num5 == -1)
			{
				this.textBoxHPConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			}
			else if (num5 == -2)
			{
				this.textBoxHPConcrete.Text = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			}
			else
			{
				int num6 = *(int*)ptr2;
				this.textBoxHPConcrete.Text = num6.ToString();
			}
		}

		public unsafe void UpdateStats()
		{
			GBaseString<char> gBaseString<char> = 0;
			*(ref gBaseString<char> + 4) = 0;
			try
			{
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
					gBaseString<char>2 = 0;
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
					gBaseString<char>3 = 0;
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

		protected unsafe void raise_PropertiesChanged(GUnitStats* i1)
		{
			ToolboxBuildingProperties.__Delegate_PropertiesChanged propertiesChanged = this.PropertiesChanged;
			if (propertiesChanged != null)
			{
				propertiesChanged(i1);
			}
		}
	}
}
