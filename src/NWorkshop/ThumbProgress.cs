using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ThumbProgress : Form
	{
		private ProgressBar TheProgressBar;

		private Container components;

		private string Prompt;

		public ThumbProgress([MarshalAs(UnmanagedType.U1)] bool loading)
		{
			this.InitializeComponent();
			if (loading)
			{
				this.Text = "Loading map";
			}
		}

		public ThumbProgress()
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
			this.TheProgressBar = new ProgressBar();
			base.SuspendLayout();
			Point location = new Point(8, 64);
			this.TheProgressBar.Location = location;
			this.TheProgressBar.Name = "TheProgressBar";
			Size size = new Size(424, 23);
			this.TheProgressBar.Size = size;
			this.TheProgressBar.Step = 1;
			this.TheProgressBar.TabIndex = 0;
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			base.CausesValidation = false;
			Size clientSize = new Size(442, 100);
			base.ClientSize = clientSize;
			base.ControlBox = false;
			base.Controls.Add(this.TheProgressBar);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Name = "ThumbProgress";
			base.ShowInTaskbar = false;
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Generating thumbnails";
			base.ResumeLayout(false);
		}

		private unsafe void PaintInfoPanel()
		{
			Font font = new Font(new string((sbyte*)(&<Module>.??_C@_0BF@LKOMBMBF@Microsoft?5Sans?5Serif?$AA@)), 8.25f);
			Graphics graphics = base.CreateGraphics();
			Color color = Color.FromKnownColor(KnownColor.Control);
			graphics.Clear(color);
			Color black = Color.Black;
			graphics.DrawString("Processing:", font, new SolidBrush(black), 0f, 0f);
			Color black2 = Color.Black;
			graphics.DrawString(this.Prompt, font, new SolidBrush(black2), 20f, 20f);
			graphics.Dispose();
		}

		public void StartThumbnailGeneration(int count)
		{
			this.TheProgressBar.Minimum = 0;
			this.TheProgressBar.Maximum = count;
			this.TheProgressBar.Value = 0;
		}

		public void Next(int current, string prompt)
		{
			this.TheProgressBar.Value = current;
			this.Prompt = prompt;
			this.PaintInfoPanel();
		}

		public void Next(string prompt)
		{
			int value = this.TheProgressBar.Value;
			this.TheProgressBar.Value = value + 1;
			int value2 = this.TheProgressBar.Value;
			this.TheProgressBar.Value = value2 - 1;
			this.Prompt = prompt;
			this.PaintInfoPanel();
		}

		public void Finished()
		{
			int value = this.TheProgressBar.Value;
			this.TheProgressBar.Value = value + 1;
			if (this.TheProgressBar.Value == this.TheProgressBar.Maximum)
			{
				base.Hide();
			}
		}
	}
}
