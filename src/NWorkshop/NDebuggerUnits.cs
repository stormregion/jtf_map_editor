using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NDebuggerUnits : UserControl
	{
		private ListBox MainFilter;

		private ListBox SecondaryFilter;

		private ListView UnitList;

		private ColumnHeader UnitID;

		private ColumnHeader UnitType;

		private Container components;

		public NDebuggerUnits()
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
			this.MainFilter = new ListBox();
			this.SecondaryFilter = new ListBox();
			this.UnitList = new ListView();
			this.UnitID = new ColumnHeader();
			this.UnitType = new ColumnHeader();
			base.SuspendLayout();
			object[] items = new object[]
			{
				"Infantry",
				"Vehicle",
				"Building",
				"Other"
			};
			this.MainFilter.Items.AddRange(items);
			Point location = new Point(8, 272);
			this.MainFilter.Location = location;
			this.MainFilter.Name = "MainFilter";
			Size size = new Size(120, 69);
			this.MainFilter.Size = size;
			this.MainFilter.TabIndex = 1;
			object[] items2 = new object[]
			{
				"Anarchist",
				"Team1",
				"Team2",
				"Team3",
				"Team4"
			};
			this.SecondaryFilter.Items.AddRange(items2);
			Point location2 = new Point(128, 272);
			this.SecondaryFilter.Location = location2;
			this.SecondaryFilter.Name = "SecondaryFilter";
			Size size2 = new Size(112, 69);
			this.SecondaryFilter.Size = size2;
			this.SecondaryFilter.TabIndex = 2;
			ColumnHeader[] values = new ColumnHeader[]
			{
				this.UnitID,
				this.UnitType
			};
			this.UnitList.Columns.AddRange(values);
			this.UnitList.GridLines = true;
			Point location3 = new Point(8, 8);
			this.UnitList.Location = location3;
			this.UnitList.Name = "UnitList";
			Size size3 = new Size(232, 256);
			this.UnitList.Size = size3;
			this.UnitList.TabIndex = 3;
			this.UnitList.View = View.Details;
			this.UnitID.Text = "Unit ID";
			this.UnitID.Width = 168;
			this.UnitType.Text = "Type";
			base.Controls.Add(this.UnitList);
			base.Controls.Add(this.SecondaryFilter);
			base.Controls.Add(this.MainFilter);
			base.Name = "NDebuggerUnits";
			Size size4 = new Size(248, 344);
			base.Size = size4;
			base.ResumeLayout(false);
		}
	}
}
