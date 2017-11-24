using Script;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NDebuggerTriggers : UserControl
	{
		private Container components;

		private ListView TriggerList;

		private ColumnHeader TriggerName;

		private ColumnHeader Active;

		private ColumnHeader Event;

		public NDebuggerTriggers()
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
			this.TriggerList = new ListView();
			this.TriggerName = new ColumnHeader();
			this.Event = new ColumnHeader();
			this.Active = new ColumnHeader();
			base.SuspendLayout();
			this.TriggerList.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			ColumnHeader[] values = new ColumnHeader[]
			{
				this.TriggerName,
				this.Event,
				this.Active
			};
			this.TriggerList.Columns.AddRange(values);
			this.TriggerList.GridLines = true;
			Point location = new Point(8, 8);
			this.TriggerList.Location = location;
			this.TriggerList.Name = "TriggerList";
			Size size = new Size(232, 312);
			this.TriggerList.Size = size;
			this.TriggerList.TabIndex = 0;
			this.TriggerList.View = View.Details;
			this.TriggerList.Resize += new EventHandler(this.TriggerList_Resize);
			this.TriggerName.Text = "Name";
			this.TriggerName.Width = 116;
			this.Event.Text = "Event";
			this.Event.Width = 69;
			this.Active.Text = "Active";
			this.Active.Width = 43;
			base.Controls.Add(this.TriggerList);
			base.Name = "NDebuggerTriggers";
			Size size2 = new Size(248, 328);
			base.Size = size2;
			base.ResumeLayout(false);
		}

		public unsafe void Init(cScript* script)
		{
			GArray<Script::cTrigger *> gArray<Script::cTrigger *>;
			<Module>.GArray<Script::cTrigger *>.{ctor}(ref gArray<Script::cTrigger *>, script + 32 / sizeof(cScript));
			try
			{
				this.TriggerList.Items.Clear();
				int num = 0;
				if (0 < *(ref gArray<Script::cTrigger *> + 4))
				{
					do
					{
						cTrigger* ptr = *(num * 4 + gArray<Script::cTrigger *>);
						uint num2 = (uint)(*(int*)ptr);
						ListViewItem listViewItem = new ListViewItem(new string((sbyte*)((num2 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num2)));
						int num3 = *(int*)(ptr + 8 / sizeof(cTrigger));
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr2 = <Module>.?GetEventTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eEvent_Type@Script@@@Z(&gBaseString<char>, num3);
						try
						{
							uint num4 = (uint)(*(int*)ptr2);
							sbyte* value;
							if (num4 != 0u)
							{
								value = num4;
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
						byte b = *(byte*)(ptr + 28 / sizeof(cTrigger));
						string text;
						if (b != 0)
						{
							text = "yes";
						}
						else
						{
							text = new string((sbyte*)(&<Module>.??_C@_02KAJCLHKP@no?$AA@));
						}
						listViewItem.SubItems.Add(text);
						this.TriggerList.Items.Add(listViewItem);
						num++;
					}
					while (num < *(ref gArray<Script::cTrigger *> + 4));
				}
				this.TriggerList_Resize(null, null);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GArray<Script::cTrigger *>.{dtor}), (void*)(&gArray<Script::cTrigger *>));
				throw;
			}
			if (gArray<Script::cTrigger *> != null)
			{
				<Module>.free(gArray<Script::cTrigger *>);
			}
		}

		public unsafe void Refresh(cScript* script)
		{
			GArray<Script::cTrigger *> gArray<Script::cTrigger *>;
			<Module>.GArray<Script::cTrigger *>.{ctor}(ref gArray<Script::cTrigger *>, script + 32 / sizeof(cScript));
			try
			{
				int num = 0;
				if (0 < *(ref gArray<Script::cTrigger *> + 4))
				{
					do
					{
						cTrigger* ptr = *(num * 4 + gArray<Script::cTrigger *>);
						ListViewItem listViewItem = this.TriggerList.Items[num];
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
						int num3 = *(int*)(ptr + 8 / sizeof(cTrigger));
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr2 = <Module>.?GetEventTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eEvent_Type@Script@@@Z(&gBaseString<char>, num3);
						try
						{
							uint num4 = (uint)(*(int*)ptr2);
							sbyte* value2;
							if (num4 != 0u)
							{
								value2 = num4;
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
						byte b = *(byte*)(ptr + 28 / sizeof(cTrigger));
						string text;
						if (b != 0)
						{
							text = "yes";
						}
						else
						{
							text = new string((sbyte*)(&<Module>.??_C@_02KAJCLHKP@no?$AA@));
						}
						listViewItem.SubItems[2].Text = text;
						num++;
					}
					while (num < *(ref gArray<Script::cTrigger *> + 4));
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GArray<Script::cTrigger *>.{dtor}), (void*)(&gArray<Script::cTrigger *>));
				throw;
			}
			if (gArray<Script::cTrigger *> != null)
			{
				<Module>.free(gArray<Script::cTrigger *>);
			}
		}

		private void TriggerList_Resize(object sender, EventArgs e)
		{
			int num = this.TriggerList.ClientSize.Width - this.Active.Width;
			this.TriggerName.Width = num - this.Event.Width;
		}
	}
}
