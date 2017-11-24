using Script;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NDebuggerGVars : UserControl
	{
		private Container components;

		private ListView GVarList;

		private ColumnHeader GVarName;

		private ColumnHeader GVarType;

		private ColumnHeader GVarValue;

		public NDebuggerGVars()
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
			this.GVarList = new ListView();
			this.GVarName = new ColumnHeader();
			this.GVarType = new ColumnHeader();
			this.GVarValue = new ColumnHeader();
			base.SuspendLayout();
			this.GVarList.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			ColumnHeader[] values = new ColumnHeader[]
			{
				this.GVarName,
				this.GVarType,
				this.GVarValue
			};
			this.GVarList.Columns.AddRange(values);
			this.GVarList.GridLines = true;
			Point location = new Point(8, 8);
			this.GVarList.Location = location;
			this.GVarList.Name = "GVarList";
			Size size = new Size(232, 312);
			this.GVarList.Size = size;
			this.GVarList.TabIndex = 0;
			this.GVarList.View = View.Details;
			this.GVarList.Resize += new EventHandler(this.GVarList_Resize);
			this.GVarName.Text = "Name";
			this.GVarName.Width = 125;
			this.GVarType.Text = "Type";
			this.GVarType.Width = 49;
			this.GVarValue.Text = "Value";
			this.GVarValue.Width = 54;
			base.Controls.Add(this.GVarList);
			base.Name = "NDebuggerGVars";
			Size size2 = new Size(248, 328);
			base.Size = size2;
			base.ResumeLayout(false);
		}

		public unsafe void Init(cScript* script)
		{
			GArray<Script::cVariable *> gArray<Script::cVariable *>;
			<Module>.GArray<Script::cVariable *>.{ctor}(ref gArray<Script::cVariable *>, script + 8 / sizeof(cScript));
			try
			{
				this.GVarList.Items.Clear();
				int num = 0;
				if (0 < *(ref gArray<Script::cVariable *> + 4))
				{
					do
					{
						cVariable* ptr = *(num * 4 + gArray<Script::cVariable *>);
						uint num2 = (uint)(*(int*)ptr);
						ListViewItem listViewItem = new ListViewItem(new string((sbyte*)((num2 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num2)));
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr2 = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(&gBaseString<char>, *(int*)(ptr + 12 / sizeof(cVariable)), 0);
						try
						{
							uint num3 = (uint)(*(int*)ptr2);
							sbyte* value;
							if (num3 != 0u)
							{
								value = num3;
							}
							else
							{
								value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							listViewItem.SubItems.Add(new string((sbyte*)value));
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
						GBaseString<char> gBaseString<char>2;
						GBaseString<char>* ptr3 = <Module>.Script.sValue.GetAsString(ptr + 12 / sizeof(cVariable), &gBaseString<char>2);
						try
						{
							uint num4 = (uint)(*(int*)ptr3);
							sbyte* value2;
							if (num4 != 0u)
							{
								value2 = num4;
							}
							else
							{
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							listViewItem.SubItems.Add(new string((sbyte*)value2));
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
						this.GVarList.Items.Add(listViewItem);
						num++;
					}
					while (num < *(ref gArray<Script::cVariable *> + 4));
				}
				this.GVarList_Resize(null, null);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GArray<Script::cVariable *>.{dtor}), (void*)(&gArray<Script::cVariable *>));
				throw;
			}
			if (gArray<Script::cVariable *> != null)
			{
				<Module>.free(gArray<Script::cVariable *>);
			}
		}

		public unsafe void Refresh(cScript* script)
		{
			GArray<Script::cVariable *> gArray<Script::cVariable *>;
			<Module>.GArray<Script::cVariable *>.{ctor}(ref gArray<Script::cVariable *>, script + 8 / sizeof(cScript));
			try
			{
				int num = 0;
				if (0 < *(ref gArray<Script::cVariable *> + 4))
				{
					do
					{
						cVariable* ptr = *(num * 4 + gArray<Script::cVariable *>);
						ListViewItem listViewItem = this.GVarList.Items[num];
						uint num2 = (uint)(*(int*)ptr);
						sbyte* value;
						if (num2 != 0u)
						{
							value = num2;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						listViewItem.Text = new string((sbyte*)value);
						cVariable* ptr2 = ptr + 12 / sizeof(cVariable);
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr3 = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(&gBaseString<char>, *(int*)ptr2, 0);
						try
						{
							uint num3 = (uint)(*(int*)ptr3);
							sbyte* value2;
							if (num3 != 0u)
							{
								value2 = num3;
							}
							else
							{
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							listViewItem.SubItems[1].Text = new string((sbyte*)value2);
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
						GBaseString<char> gBaseString<char>2;
						GBaseString<char>* ptr4 = <Module>.Script.sValue.GetAsString(ptr2, &gBaseString<char>2);
						try
						{
							uint num4 = (uint)(*(int*)ptr4);
							sbyte* value3;
							if (num4 != 0u)
							{
								value3 = num4;
							}
							else
							{
								value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							listViewItem.SubItems[2].Text = new string((sbyte*)value3);
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
						num++;
					}
					while (num < *(ref gArray<Script::cVariable *> + 4));
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GArray<Script::cVariable *>.{dtor}), (void*)(&gArray<Script::cVariable *>));
				throw;
			}
			if (gArray<Script::cVariable *> != null)
			{
				<Module>.free(gArray<Script::cVariable *>);
			}
		}

		private void GVarList_Resize(object sender, EventArgs e)
		{
			int num = this.GVarList.ClientSize.Width - this.GVarType.Width;
			this.GVarName.Width = num - this.GVarValue.Width;
		}
	}
}
