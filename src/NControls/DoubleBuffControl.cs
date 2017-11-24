using System;
using System.Windows.Forms;

namespace NControls
{
	public class DoubleBuffControl : Control
	{
		public DoubleBuffControl(Control parent, string text, int left, int top, int width, int height) : base(parent, text, left, top, width, height)
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.UpdateStyles();
		}

		public DoubleBuffControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.UpdateStyles();
		}
	}
}
