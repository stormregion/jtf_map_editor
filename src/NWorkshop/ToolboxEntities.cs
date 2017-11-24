using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxEntities : UserControl, IRearrangeableControl
	{
		private Container components;

		private Toolbar Toolbar;

		public override event ToolRearranged Rearranged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.Rearranged = Delegate.Combine(this.Rearranged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.Rearranged = Delegate.Remove(this.Rearranged, value);
			}
		}

		public event ToolboxActionHandler Action
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.Action = Delegate.Combine(this.Action, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.Action = Delegate.Remove(this.Action, value);
			}
		}

		public event ToolboxActionHandler DecalAction
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.DecalAction = Delegate.Combine(this.DecalAction, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.DecalAction = Delegate.Remove(this.DecalAction, value);
			}
		}

		public event ToolboxFlagHandler FlagChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.FlagChanged = Delegate.Combine(this.FlagChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.FlagChanged = Delegate.Remove(this.FlagChanged, value);
			}
		}

		public event ToolboxModeHandler ModeChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.ModeChanged = Delegate.Combine(this.ModeChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.ModeChanged = Delegate.Remove(this.ModeChanged, value);
			}
		}

		public unsafe ToolboxEntities(GToolbarItem* items)
		{
			this.ModeChanged = null;
			this.FlagChanged = null;
			this.DecalAction = null;
			this.Action = null;
			this.Rearranged = null;
			this.InitializeComponent();
			this.Toolbar = new Toolbar(items, 24);
			this.Toolbar.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tbEntity_ButtonClick);
			this.Toolbar.Rearranged += new ToolRearranged(this.ChildRearranged);
			this.ResetToMove();
			base.Controls.Add(this.Toolbar);
			Size size = base.Size;
			Size size2 = new Size(base.Size.Width, size.Height);
			this.Toolbar.Size = size2;
			this.Toolbar.Dock = DockStyle.Top;
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
			base.Name = "ToolboxEntities";
			Size size = new Size(256, 80);
			base.Size = size;
		}

		public void EmulatePush(int ordinal)
		{
			this.Toolbar.EmulatePush(ordinal);
		}

		public void EmulateUp(int ordinal)
		{
			this.Toolbar.EmulateUp(ordinal);
		}

		public void EmulatePushByID(int indx)
		{
			this.Toolbar.EmulatePushByID(indx);
		}

		public void EmulateUpByID(int indx)
		{
			this.Toolbar.EmulateUpByID(indx);
		}

		public void NextTool()
		{
			if (this.Toolbar.NextTool() == 1)
			{
				this.Toolbar.EmulatePush(-1);
				this.Toolbar.EmulateUp(-1);
			}
		}

		public void PrevTool()
		{
			if (this.Toolbar.PrevTool() == 1)
			{
				this.Toolbar.EmulatePush(-1);
				this.Toolbar.EmulateUp(-1);
			}
		}

		public void NextGroup()
		{
			this.Toolbar.NextGroup();
		}

		public void PrevGroup()
		{
			this.Toolbar.PrevGroup();
		}

		public void ResetToMove()
		{
			this.Toolbar.SetItemPushed(1, true);
			this.Toolbar.SetSelectedItem(1);
		}

		public void ResetToPlace()
		{
			this.Toolbar.SetItemPushed(2, true);
			this.Toolbar.SetItemPushed(303, false);
			this.Toolbar.SetSelectedItem(2);
			this.raise_FlagChanged(FlagType.LOCK_SELECTION, false);
		}

		public void ResetToPlaceNode()
		{
			this.Toolbar.SetItemPushed(4, true);
			this.Toolbar.SetItemPushed(303, false);
			this.Toolbar.SetSelectedItem(4);
			this.raise_FlagChanged(FlagType.LOCK_SELECTION, false);
		}

		private void ChildRearranged(object sender, int newheight)
		{
			if (newheight != base.Size.Height)
			{
				Size size = new Size(base.Size.Width, newheight);
				base.Size = size;
				this.raise_Rearranged(sender, base.Size.Height);
			}
		}

		private void tbEntity_ButtonClick(int idx, int radio_group)
		{
			if (radio_group == 1)
			{
				if (idx == 2)
				{
					this.Toolbar.SetItemPushed(303, false);
					this.raise_FlagChanged(FlagType.LOCK_SELECTION, false);
				}
				this.Toolbar.SetItemPushed(idx, true);
				this.raise_ModeChanged(idx);
			}
			else if (radio_group == 2)
			{
				this.raise_DecalAction(idx);
			}
			else if (radio_group == 3)
			{
				this.raise_Action(idx);
			}
			else
			{
				Toolbar toolbar = this.Toolbar;
				bool flag = ((!toolbar.GetItemPushed(idx)) ? 1 : 0) != 0;
				toolbar.SetItemPushed(idx, flag);
				this.raise_FlagChanged((FlagType)idx, flag);
			}
		}

		protected void raise_ModeChanged(int i1)
		{
			ToolboxModeHandler modeChanged = this.ModeChanged;
			if (modeChanged != null)
			{
				modeChanged(i1);
			}
		}

		protected void raise_FlagChanged(FlagType i1, [MarshalAs(UnmanagedType.U1)] bool i2)
		{
			ToolboxFlagHandler flagChanged = this.FlagChanged;
			if (flagChanged != null)
			{
				flagChanged(i1, i2);
			}
		}

		protected void raise_DecalAction(int i1)
		{
			ToolboxActionHandler decalAction = this.DecalAction;
			if (decalAction != null)
			{
				decalAction(i1);
			}
		}

		protected void raise_Action(int i1)
		{
			ToolboxActionHandler action = this.Action;
			if (action != null)
			{
				action(i1);
			}
		}

		protected void raise_Rearranged(object i1, int i2)
		{
			ToolRearranged rearranged = this.Rearranged;
			if (rearranged != null)
			{
				rearranged(i1, i2);
			}
		}
	}
}
