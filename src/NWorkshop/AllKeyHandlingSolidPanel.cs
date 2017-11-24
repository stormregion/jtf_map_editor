using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	internal class AllKeyHandlingSolidPanel : Panel
	{
		public AllKeyHandlingSolidPanel()
		{
			base.SetStyle(ControlStyles.Opaque, true);
		}

		[return: MarshalAs(UnmanagedType.U1)]
		protected override bool IsInputKey(Keys keyData)
		{
			return true;
		}
	}
}
