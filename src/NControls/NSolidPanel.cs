using System;
using System.Windows.Forms;

namespace NControls
{
	public class NSolidPanel : Panel
	{
		public NSolidPanel()
		{
			base.SetStyle(ControlStyles.Opaque, true);
		}
	}
}
