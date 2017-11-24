using System;
using System.Drawing;
using System.Windows.Forms;

namespace NControls
{
	public class NImageButton : Control
	{
		protected Image propImage;

		protected bool IsButtonPressed;

		public Image Image
		{
			set
			{
				this.propImage = value;
			}
		}

		public NImageButton()
		{
			base.Paint += new PaintEventHandler(this.OnPaint);
			base.MouseDown += new MouseEventHandler(this.OnMouseDown);
			base.MouseUp += new MouseEventHandler(this.OnMouseUp);
		}

		protected virtual void OnMouseDown(object sender, MouseEventArgs e)
		{
			this.IsButtonPressed = true;
			base.Invalidate();
		}

		protected virtual void OnMouseUp(object sender, MouseEventArgs e)
		{
			this.IsButtonPressed = false;
			base.Invalidate();
		}

		protected virtual void OnPaint(object Sender, PaintEventArgs e)
		{
			SolidBrush brush;
			SolidBrush brush2;
			if (this.IsButtonPressed)
			{
				brush = new SolidBrush(Color.FromKnownColor(KnownColor.ControlLightLight));
				brush2 = new SolidBrush(Color.FromKnownColor(KnownColor.ControlDark));
			}
			else
			{
				brush = new SolidBrush(Color.FromKnownColor(KnownColor.ControlDark));
				brush2 = new SolidBrush(Color.FromKnownColor(KnownColor.ControlLightLight));
			}
			Color color = Color.FromKnownColor(KnownColor.Control);
			e.Graphics.FillRectangle(new SolidBrush(color), 0f, 0f, 16f, 16f);
			e.Graphics.FillRectangle(brush2, 0f, 0f, 15f, 1f);
			e.Graphics.FillRectangle(brush2, 0f, 0f, 1f, 15f);
			e.Graphics.FillRectangle(brush, 1f, 15f, 14f, 1f);
			e.Graphics.FillRectangle(brush, 15f, 0f, 1f, 15f);
			Image image = this.propImage;
			if (image != null)
			{
				e.Graphics.DrawImage(image, 2f, 2f, 12f, 12f);
			}
		}
	}
}
