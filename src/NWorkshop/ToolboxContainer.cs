using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxContainer : UserControl, IRearrangeableControl
	{
		public delegate void OpenStateToggleHandler();

		private Panel panel1;

		private Button btnClose;

		private Label lblCaption;

		private ImageList imageListCloseButton;

		private IContainer components;

		private bool ContainerOpen;

		private bool AutosizeP;

		private int MinHeightP;

		private int MinWidth;

		private UserControl Toolbox;

		private ToolRearranged RearrangeHandler;

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

		public event ToolboxContainer.OpenStateToggleHandler OpenStateToggledEvent
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.OpenStateToggledEvent = Delegate.Combine(this.OpenStateToggledEvent, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.OpenStateToggledEvent = Delegate.Remove(this.OpenStateToggledEvent, value);
			}
		}

		public bool Open
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.ContainerOpen;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				if (value != this.ContainerOpen)
				{
					this.ContainerOpen = value;
					if (value)
					{
						this.btnClose.ImageIndex = 0;
						Size size = this.Toolbox.Size;
						Size size2 = new Size(base.Size.Width, size.Height + 16);
						base.Size = size2;
					}
					else
					{
						this.btnClose.ImageIndex = 1;
						Size size3 = new Size(base.Size.Width, 16);
						base.Size = size3;
					}
				}
			}
		}

		public int MinHeight
		{
			get
			{
				if (!this.AutosizeP)
				{
					return base.Height;
				}
				if (this.ContainerOpen)
				{
					return this.MinHeightP;
				}
				return 16;
			}
		}

		public bool Autosize
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.AutosizeP;
			}
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.AutosizeP = value;
			}
		}

		public ToolboxContainer()
		{
			this.OpenStateToggledEvent = null;
			this.Rearranged = null;
			this.MinHeightP = 16;
			this.AutosizeP = false;
			this.RearrangeHandler = null;
			this.InitializeComponent();
			this.ContainerOpen = true;
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing)
			{
				IContainer container = this.components;
				if (container != null)
				{
					container.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(ToolboxContainer));
			this.panel1 = new Panel();
			this.lblCaption = new Label();
			this.btnClose = new Button();
			this.imageListCloseButton = new ImageList(this.components);
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			Color activeCaption = SystemColors.ActiveCaption;
			this.panel1.BackColor = activeCaption;
			this.panel1.Controls.Add(this.lblCaption);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Dock = DockStyle.Top;
			Point location = new Point(0, 0);
			this.panel1.Location = location;
			this.panel1.Name = "panel1";
			Size size = new Size(256, 16);
			this.panel1.Size = size;
			this.panel1.TabIndex = 0;
			this.lblCaption.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.lblCaption.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			Color activeCaptionText = SystemColors.ActiveCaptionText;
			this.lblCaption.ForeColor = activeCaptionText;
			Point location2 = new Point(1, 1);
			this.lblCaption.Location = location2;
			this.lblCaption.Name = "lblCaption";
			Size size2 = new Size(238, 15);
			this.lblCaption.Size = size2;
			this.lblCaption.TabIndex = 1;
			this.lblCaption.Text = "This is the caption text";
			this.lblCaption.DoubleClick += new EventHandler(this.lblCaption_DoubleClick);
			this.btnClose.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			Color control = SystemColors.Control;
			this.btnClose.BackColor = control;
			this.btnClose.FlatStyle = FlatStyle.Flat;
			this.btnClose.ImageIndex = 0;
			this.btnClose.ImageList = this.imageListCloseButton;
			Point location3 = new Point(240, 0);
			this.btnClose.Location = location3;
			this.btnClose.Name = "btnClose";
			Size size3 = new Size(16, 16);
			this.btnClose.Size = size3;
			this.btnClose.TabIndex = 0;
			this.btnClose.Click += new EventHandler(this.btnClose_Click);
			this.imageListCloseButton.ColorDepth = ColorDepth.Depth24Bit;
			Size imageSize = new Size(16, 16);
			this.imageListCloseButton.ImageSize = imageSize;
			this.imageListCloseButton.ImageStream = (ImageListStreamer)resourceManager.GetObject("imageListCloseButton.ImageStream");
			Color magenta = Color.Magenta;
			this.imageListCloseButton.TransparentColor = magenta;
			Color control2 = SystemColors.Control;
			this.BackColor = control2;
			base.Controls.Add(this.panel1);
			base.Name = "ToolboxContainer";
			Size size4 = new Size(256, 16);
			base.Size = size4;
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public unsafe void AddToolbox(UserControl toolbox)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			this.Toolbox = toolbox;
			bool containerOpen = this.ContainerOpen;
			this.ContainerOpen = true;
			base.SuspendLayout();
			Size size = this.Toolbox.Size;
			Size size2 = new Size(this.Toolbox.Size.Width, size.Height + 16);
			base.Size = size2;
			Point location = new Point(0, 16);
			this.Toolbox.Location = location;
			this.lblCaption.Text = this.Toolbox.Text;
			this.Toolbox.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			base.Controls.Add(toolbox);
			this.Dock = DockStyle.Top;
			base.ResumeLayout(false);
			this.MinHeightP = this.Toolbox.Height + 16;
			this.MinWidth = this.Toolbox.Width;
			IRearrangeableControl rearrangeableControl = null;
			try
			{
				rearrangeableControl = (this.Toolbox as IRearrangeableControl);
				goto IL_132;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_132:
			if (rearrangeableControl != null)
			{
				ToolRearranged toolRearranged = new ToolRearranged(this.ChildToolRearranged);
				this.RearrangeHandler = toolRearranged;
				rearrangeableControl.Rearranged += toolRearranged;
			}
			if (!containerOpen)
			{
				this.Open = false;
			}
		}

		public unsafe void RemoveToolbox()
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			if (this.Toolbox != null)
			{
				Size size = new Size(this.MinWidth, this.MinHeightP - 16);
				this.Toolbox.Size = size;
				base.Controls.Remove(this.Toolbox);
				IRearrangeableControl rearrangeableControl = null;
				try
				{
					rearrangeableControl = (this.Toolbox as IRearrangeableControl);
					goto IL_A2;
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
				IL_A2:
				if (rearrangeableControl != null)
				{
					ToolRearranged rearrangeHandler = this.RearrangeHandler;
					if (rearrangeHandler != null)
					{
						rearrangeableControl.Rearranged -= rearrangeHandler;
					}
				}
			}
			this.Toolbox = null;
			this.RearrangeHandler = null;
		}

		public void Inflate(int extraheight)
		{
			UserControl toolbox = this.Toolbox;
			if (toolbox != null)
			{
				Size size = new Size(toolbox.Size.Width, this.MinHeightP + extraheight - 16);
				this.Toolbox.Size = size;
				Size size2 = this.Toolbox.Size;
				Size size3 = new Size(this.Toolbox.Size.Width, size2.Height + 16);
				base.Size = size3;
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			byte open = (!this.Open) ? 1 : 0;
			this.Open = (open != 0);
			this.raise_OpenStateToggledEvent();
		}

		private void lblCaption_DoubleClick(object sender, EventArgs e)
		{
			byte open = (!this.Open) ? 1 : 0;
			this.Open = (open != 0);
			this.raise_OpenStateToggledEvent();
		}

		private void ChildToolRearranged(object sender, int newsize)
		{
			if (this.ContainerOpen)
			{
				base.SuspendLayout();
				Size size = this.Toolbox.Size;
				int num = newsize + 16;
				Size size2 = new Size(size.Width, num);
				base.Size = size2;
				Point location = new Point(0, 16);
				this.Toolbox.Location = location;
				base.ResumeLayout(false);
				this.MinHeightP = num;
				this.MinWidth = this.Toolbox.Width;
				this.raise_OpenStateToggledEvent();
			}
		}

		protected void raise_OpenStateToggledEvent()
		{
			ToolboxContainer.OpenStateToggleHandler openStateToggledEvent = this.OpenStateToggledEvent;
			if (openStateToggledEvent != null)
			{
				openStateToggledEvent();
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
