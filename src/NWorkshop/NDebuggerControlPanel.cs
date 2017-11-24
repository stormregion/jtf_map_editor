using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NDebuggerControlPanel : UserControl
	{
		private Container components;

		public NDebuggerControlPanel()
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
			Size clientSize = new Size(248, 270);
			base.ClientSize = clientSize;
			base.Name = "DebuggerControlPanel";
			this.Text = "DebuggerControlPanel";
		}
	}
}
