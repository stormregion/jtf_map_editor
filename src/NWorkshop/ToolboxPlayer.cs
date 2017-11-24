using NControls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxPlayer : UserControl
	{
		public delegate void __Delegate_PlayerChanged(int);

		public delegate void __Delegate_EditPlayerProperties(int);

		private GridControl PlayersGrid;

		private Container components;

		public event ToolboxPlayer.__Delegate_EditPlayerProperties EditPlayerProperties
		{
			add
			{
				this.EditPlayerProperties = Delegate.Combine(this.EditPlayerProperties, value);
			}
			remove
			{
				this.EditPlayerProperties = Delegate.Remove(this.EditPlayerProperties, value);
			}
		}

		public event ToolboxPlayer.__Delegate_PlayerChanged PlayerChanged
		{
			add
			{
				this.PlayerChanged = Delegate.Combine(this.PlayerChanged, value);
			}
			remove
			{
				this.PlayerChanged = Delegate.Remove(this.PlayerChanged, value);
			}
		}

		public ToolboxPlayer()
		{
			this.PlayerChanged = null;
			this.EditPlayerProperties = null;
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
			base.Name = "ToolboxPlayer";
			Size size = new Size(200, 236);
			base.Size = size;
			base.ResumeLayout(false);
		}

		public unsafe void InitPlayersGrid(GWorld* world)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new ColumnItem(new string((sbyte*)(&<Module>.??_C@_02JINPPBEP@No?$AA@)), 15));
			arrayList.Add(new ColumnItem(new string((sbyte*)(&<Module>.??_C@_07CEAHOFOL@Faction?$AA@)), 50));
			arrayList.Add(new ColumnItem(new string((sbyte*)(&<Module>.??_C@_07DFGIDBBA@Control?$AA@)), 50));
			arrayList.Add(new ColumnItem(new string((sbyte*)(&<Module>.??_C@_04GBPANCCF@Team?$AA@)), 20));
			arrayList.Add(new ColumnItem(new string((sbyte*)(&<Module>.??_C@_05PDOBBJNA@Color?$AA@)), 20));
			if (this.PlayersGrid == null)
			{
				GridControl gridControl = new GridControl(200, 236, arrayList, 0);
				this.PlayersGrid = gridControl;
				gridControl.Dock = DockStyle.Fill;
				this.PlayersGrid.SelectedIndex = 0;
				this.PlayersGrid.ChooseItem += new GridControl.__Delegate_ChooseItem(this.PlayersGridChooseItem);
				this.PlayersGrid.DoubleClickItem += new GridControl.__Delegate_DoubleClickItem(this.PlayersGridDoubleClickItem);
				base.Controls.Add(this.PlayersGrid);
			}
			this.InitItems(world);
		}

		public void RemovePlayersGrid()
		{
			base.Controls.Remove(this.PlayersGrid);
		}

		public unsafe void InitItems(GWorld* world)
		{
			string value = null;
			if (this.PlayersGrid.Items.Count > 0)
			{
				this.PlayersGrid.Items.Clear();
			}
			int num = 0;
			do
			{
				GPlayer* ptr = <Module>.GWorld.GetPlayer(world, num);
				ArrayList arrayList = new ArrayList();
				arrayList.Add(string.Format("{0}", num + 1));
				switch (*(int*)(ptr + 4 / sizeof(GPlayer)))
				{
				case 0:
					value = new string((sbyte*)(&<Module>.??_C@_05IHOOPELI@Iraqi?$AA@));
					break;
				case 1:
					value = new string((sbyte*)(&<Module>.??_C@_03OHIEPGFF@JTF?$AA@));
					break;
				case 2:
					value = new string((sbyte*)(&<Module>.??_C@_07NDGKDAPO@Bosnian?$AA@));
					break;
				case 3:
					value = new string((sbyte*)(&<Module>.??_C@_08NKKMBANE@Somalian?$AA@));
					break;
				case 4:
					value = new string((sbyte*)(&<Module>.??_C@_09LDEFILLJ@Colombian?$AA@));
					break;
				case 5:
					value = new string((sbyte*)(&<Module>.??_C@_06DJKJCBIE@Afghan?$AA@));
					break;
				}
				arrayList.Add(value);
				switch (*(int*)(ptr + 8 / sizeof(GPlayer)))
				{
				case 0:
					value = new string((sbyte*)(&<Module>.??_C@_05OHCDHBAC@Human?$AA@));
					break;
				case 1:
					value = new string((sbyte*)(&<Module>.??_C@_08JABLAMKL@Computer?$AA@));
					break;
				case 2:
					value = new string((sbyte*)(&<Module>.??_C@_07GJJCKENN@Neutral?$AA@));
					break;
				case 3:
					value = new string((sbyte*)(&<Module>.??_C@_09BIDEJFLN@Rescuable?$AA@));
					break;
				case 4:
					value = new string((sbyte*)(&<Module>.??_C@_03KNAPCKEA@Spy?$AA@));
					break;
				case 5:
					value = new string((sbyte*)(&<Module>.??_C@_05JDMJBIOG@Civil?$AA@));
					break;
				}
				arrayList.Add(value);
				arrayList.Add(string.Format("{0}", *(int*)(ptr + 16 / sizeof(GPlayer))));
				arrayList.Add(string.Format("{0}", *(int*)ptr));
				this.PlayersGrid.Items.Add(arrayList);
				num++;
			}
			while (num < 12);
			this.PlayersGrid.UpdateViewHeight();
		}

		private void PlayersGridChooseItem(int index)
		{
			this.raise_PlayerChanged(index);
		}

		private void PlayersGridDoubleClickItem(int index)
		{
			this.raise_EditPlayerProperties(index);
		}

		protected void raise_PlayerChanged(int i1)
		{
			ToolboxPlayer.__Delegate_PlayerChanged playerChanged = this.PlayerChanged;
			if (playerChanged != null)
			{
				playerChanged(i1);
			}
		}

		protected void raise_EditPlayerProperties(int i1)
		{
			ToolboxPlayer.__Delegate_EditPlayerProperties editPlayerProperties = this.EditPlayerProperties;
			if (editPlayerProperties != null)
			{
				editPlayerProperties(i1);
			}
		}
	}
}
