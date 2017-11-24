using GRTTI;
using NWorkshop;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace NControls
{
	public class PropertyTree : BaseScrollableControl
	{
		public delegate void __Delegate_ItemChanged();

		public delegate void __Delegate_SelectedIndexChanged();

		private Label PropTreeDescription;

		private HeaderControl PropTreeHeader;

		private PropertyTreeCore PropTreeCore;

		private Control PropTreeCorner;

		public event PropertyTree.__Delegate_SelectedIndexChanged SelectedIndexChanged
		{
			add
			{
				this.SelectedIndexChanged = Delegate.Combine(this.SelectedIndexChanged, value);
			}
			remove
			{
				this.SelectedIndexChanged = Delegate.Remove(this.SelectedIndexChanged, value);
			}
		}

		public event PropertyTree.__Delegate_ItemChanged ItemChanged
		{
			add
			{
				this.ItemChanged = Delegate.Combine(this.ItemChanged, value);
			}
			remove
			{
				this.ItemChanged = Delegate.Remove(this.ItemChanged, value);
			}
		}

		public event PropertyTreeCore.TrackSelectedHandler TrackSelected
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.TrackSelected = Delegate.Combine(this.TrackSelected, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.TrackSelected = Delegate.Remove(this.TrackSelected, value);
			}
		}

		public Control.ControlCollection OwnControls
		{
			get
			{
				return base.Controls;
			}
		}

		public new Control.ControlCollection Controls
		{
			get
			{
				return this.PropTreeCore.Controls;
			}
		}

		public ArrayList ColumnDatas
		{
			get
			{
				return this.PropTreeCore.ColumnDatas;
			}
		}

		public unsafe PropertyTree(int descriptionlines, NewAssetPicker.ObjectType objecttype, NPropertyClipboard* clipboard)
		{
			this.ItemChanged = null;
			this.SelectedIndexChanged = null;
			this.TrackSelected = null;
			Color backColor = Color.FromKnownColor(KnownColor.Window);
			this.BackColor = backColor;
			this.PropTreeDescription = new Label();
			Color backColor2 = Color.FromKnownColor(KnownColor.Control);
			this.PropTreeDescription.BackColor = backColor2;
			Color foreColor = Color.FromKnownColor(KnownColor.ControlText);
			this.PropTreeDescription.ForeColor = foreColor;
			this.PropTreeDescription.BorderStyle = BorderStyle.Fixed3D;
			this.PropTreeDescription.Width = base.Width;
			this.PropTreeDescription.Height = (this.Font.Height + 2) * descriptionlines;
			this.PropTreeDescription.Dock = DockStyle.Bottom;
			this.PropTreeCore = new PropertyTreeCore(base.Width, base.Height, base.Height, 2, this.PropTreeDescription, objecttype, clipboard);
			Point location = new Point(0, 20);
			this.PropTreeCore.Location = location;
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new ColumnItem(new string((sbyte*)(&<Module>.??_C@_07CKMABNOK@Setting?$AA@)), 90));
			arrayList.Add(new ColumnItem(new string((sbyte*)(&<Module>.??_C@_05LPIJGKJ@Value?$AA@)), 70));
			IEnumerator enumerator = arrayList.GetEnumerator();
			float proportion = 1f / (float)arrayList.Count;
			if (enumerator.MoveNext())
			{
				do
				{
					ColumnItem columnItem = enumerator.Current as ColumnItem;
					ColumnData columnData = new ColumnData(columnItem.Name, (int)((double)columnItem.MinWidth));
					columnData.Proportion = proportion;
					this.ColumnDatas.Add(columnData);
				}
				while (enumerator.MoveNext());
			}
			this.PropTreeHeader = new HeaderControl(this.PropTreeCore);
			this.PropTreeHeader.Width = this.PropTreeCore.GetViewControlWidth();
			this.PropTreeHeader.Height = 20;
			this.PropTreeCorner = new Control();
			Point location2 = new Point(this.PropTreeHeader.Width, 0);
			this.PropTreeCorner.Location = location2;
			this.PropTreeCorner.Width = base.Width - this.PropTreeHeader.Width;
			this.PropTreeCorner.Height = 20;
			Color backColor3 = Color.FromKnownColor(KnownColor.Control);
			this.PropTreeCorner.BackColor = backColor3;
			int num = base.Height - this.PropTreeHeader.Height;
			this.PropTreeCore.Height = num - this.PropTreeDescription.Height;
			this.PropTreeHeader.RecalcColumnDatas();
			this.PropTreeHeader.Refresh();
			this.PropTreeCore.Refresh();
			this.OwnControls.Add(this.PropTreeHeader);
			this.OwnControls.Add(this.PropTreeCorner);
			this.OwnControls.Add(this.PropTreeCore);
			this.OwnControls.Add(this.PropTreeDescription);
			this.PropTreeCore.ItemChanged += new PropertyTreeCore.__Delegate_ItemChanged(this.PropTreeCore_ItemChanged);
			this.PropTreeCore.SelectedIndexChanged += new PropertyTreeCore.__Delegate_SelectedIndexChanged(this.PropTreeCore_SelectedIndexChanged);
			this.PropTreeCore.TrackSelected += new PropertyTreeCore.TrackSelectedHandler(this.PropTreeCore_TrackSelected);
		}

		public unsafe void SetVariable(GClass* type, void* var, GMeasures* measures)
		{
			this.PropTreeCore.SetVariable(type, var, measures);
			this.PropTreeCore.SelectedIndex = 0;
			this.PropTreeCore.EnsureSelectedVisible();
			this.PropTreeCore.Refresh();
		}

		public unsafe void SetVariableNoReset(GClass* type, void* var, GMeasures* measures)
		{
			this.PropTreeCore.SetVariable(type, var, measures, false);
			PropertyTreeCore propTreeCore = this.PropTreeCore;
			if (propTreeCore.SelectedIndex >= this.PropTreeCore.Items.Count)
			{
				propTreeCore.SelectedIndex = 0;
			}
			this.PropTreeCore.EnsureSelectedVisible();
			this.PropTreeCore.Refresh();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			if (this.PropTreeCore != null)
			{
				this.PropTreeCore.Width = base.Width;
				int num = base.Height - this.PropTreeHeader.Height;
				this.PropTreeCore.Height = num - this.PropTreeDescription.Height;
				this.PropTreeHeader.Width = this.PropTreeCore.GetViewControlWidth();
				this.PropTreeHeader.RecalcColumnDatas();
				this.PropTreeCorner.Width = base.Width - this.PropTreeHeader.Width;
				this.PropTreeCorner.Height = 20;
				Point location = new Point(this.PropTreeHeader.Width, 0);
				this.PropTreeCorner.Location = location;
				this.PropTreeDescription.Width = base.Width;
				this.PropTreeHeader.Refresh();
				this.PropTreeCore.Refresh();
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			this.PropTreeCore.Focus();
		}

		private void PropTreeCore_ItemChanged()
		{
			this.raise_ItemChanged();
		}

		private void PropTreeCore_SelectedIndexChanged()
		{
			this.raise_SelectedIndexChanged();
		}

		private void PropTreeCore_TrackSelected(NCurveEditor curveeditor)
		{
			this.raise_TrackSelected(curveeditor);
		}

		protected void raise_ItemChanged()
		{
			PropertyTree.__Delegate_ItemChanged itemChanged = this.ItemChanged;
			if (itemChanged != null)
			{
				itemChanged();
			}
		}

		protected void raise_SelectedIndexChanged()
		{
			PropertyTree.__Delegate_SelectedIndexChanged selectedIndexChanged = this.SelectedIndexChanged;
			if (selectedIndexChanged != null)
			{
				selectedIndexChanged();
			}
		}

		protected void raise_TrackSelected(NCurveEditor i1)
		{
			PropertyTreeCore.TrackSelectedHandler trackSelected = this.TrackSelected;
			if (trackSelected != null)
			{
				trackSelected(i1);
			}
		}
	}
}
