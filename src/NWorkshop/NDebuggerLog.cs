using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NDebuggerLog : UserControl
	{
		private ListBox LogList;

		private Container components;

		public NDebuggerLog()
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
			this.LogList = new ListBox();
			base.SuspendLayout();
			this.LogList.Dock = DockStyle.Fill;
			this.LogList.HorizontalScrollbar = true;
			Point location = new Point(0, 0);
			this.LogList.Location = location;
			this.LogList.Name = "LogList";
			Size size = new Size(256, 303);
			this.LogList.Size = size;
			this.LogList.TabIndex = 0;
			base.Controls.Add(this.LogList);
			base.Name = "NDebuggerLog";
			Size size2 = new Size(256, 304);
			base.Size = size2;
			base.ResumeLayout(false);
		}

		public void Reset()
		{
			this.LogList.Items.Clear();
		}

		public void AddEcho(string row)
		{
			this.LogList.Items.Add(row);
			this.LogList.SelectedIndex = this.LogList.Items.Count - 1;
		}
	}
}
