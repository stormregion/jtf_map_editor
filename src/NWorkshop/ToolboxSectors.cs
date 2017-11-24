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
	public class ToolboxSectors : UserControl
	{
		public delegate void SectorActionHandler(int op, string info);

		private Container components;

		private Panel SketchPanel;

		private Button BtnDownPlus;

		private Button BtnRightPlus;

		private Button BtnLeftPlus;

		private Button BtnUpPlus;

		private Button BtnDown;

		private Button BtnUp;

		private Button BtnRight;

		private Button BtnLeft;

		private Button SketchBtn;

		private Toolbar SectorTools;

		private NFileDialog LoadSketchDialog;

		private ToolboxScriptEntities SectorList;

		public event ToolboxSectors.SectorActionHandler Action
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.Action = Delegate.Combine(this.Action, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.Action = Delegate.Remove(this.Action, value);
			}
		}

		public ToolboxScriptEntities ScriptEntityTool
		{
			get
			{
				return this.SectorList;
			}
		}

		public unsafe GEditorWorld* World
		{
			set
			{
				this.SectorList.World = value;
			}
		}

		public unsafe ToolboxSectors()
		{
			this.Action = null;
			this.InitializeComponent();
			this.SectorList = new ToolboxScriptEntities(4);
			Point location = new Point(0, 32);
			this.SectorList.Location = location;
			base.Controls.Add(this.SectorList);
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0ToolboxSectors@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), 24);
			this.SectorTools = toolbar;
			toolbar.Dock = DockStyle.Top;
			this.SectorTools.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.SectorTools_ButtonClick);
			Size size = new Size(base.Size.Width, 32);
			this.SectorTools.Size = size;
			base.Controls.Add(this.SectorTools);
			NFileDialog nFileDialog = new NFileDialog(null, true);
			this.LoadSketchDialog = nFileDialog;
			nFileDialog.AvailableModes = 2;
			this.LoadSketchDialog.DefaultExtension = "tga";
			this.LoadSketchDialog.SelectedMode = 2;
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing)
			{
				Container container = this.components;
				if (container != null)
				{
					container.Dispose();
					base.Dispose(disposing);
				}
			}
		}

		private void InitializeComponent()
		{
			ResourceManager resourceManager = new ResourceManager(typeof(ToolboxSectors));
			this.SketchPanel = new Panel();
			this.BtnDownPlus = new Button();
			this.BtnRightPlus = new Button();
			this.BtnLeftPlus = new Button();
			this.BtnUpPlus = new Button();
			this.BtnDown = new Button();
			this.BtnUp = new Button();
			this.BtnRight = new Button();
			this.BtnLeft = new Button();
			this.SketchBtn = new Button();
			this.SketchPanel.SuspendLayout();
			base.SuspendLayout();
			this.SketchPanel.Controls.Add(this.BtnDownPlus);
			this.SketchPanel.Controls.Add(this.BtnRightPlus);
			this.SketchPanel.Controls.Add(this.BtnLeftPlus);
			this.SketchPanel.Controls.Add(this.BtnUpPlus);
			this.SketchPanel.Controls.Add(this.BtnDown);
			this.SketchPanel.Controls.Add(this.BtnUp);
			this.SketchPanel.Controls.Add(this.BtnRight);
			this.SketchPanel.Controls.Add(this.BtnLeft);
			this.SketchPanel.Controls.Add(this.SketchBtn);
			this.SketchPanel.Dock = DockStyle.Bottom;
			Point location = new Point(0, 360);
			this.SketchPanel.Location = location;
			this.SketchPanel.Name = "SketchPanel";
			Size size = new Size(256, 120);
			this.SketchPanel.Size = size;
			this.SketchPanel.TabIndex = 9;
			this.BtnDownPlus.Image = (Image)resourceManager.GetObject("BtnDownPlus.Image");
			Point location2 = new Point(24, 96);
			this.BtnDownPlus.Location = location2;
			this.BtnDownPlus.Name = "BtnDownPlus";
			Size size2 = new Size(128, 24);
			this.BtnDownPlus.Size = size2;
			this.BtnDownPlus.TabIndex = 17;
			this.BtnDownPlus.Click += new EventHandler(this.BtnDownPlus_Click);
			this.BtnRightPlus.Image = (Image)resourceManager.GetObject("BtnRightPlus.Image");
			Point location3 = new Point(152, 0);
			this.BtnRightPlus.Location = location3;
			this.BtnRightPlus.Name = "BtnRightPlus";
			Size size3 = new Size(24, 120);
			this.BtnRightPlus.Size = size3;
			this.BtnRightPlus.TabIndex = 16;
			this.BtnRightPlus.Click += new EventHandler(this.BtnRightPlus_Click);
			this.BtnLeftPlus.Image = (Image)resourceManager.GetObject("BtnLeftPlus.Image");
			Point location4 = new Point(0, 0);
			this.BtnLeftPlus.Location = location4;
			this.BtnLeftPlus.Name = "BtnLeftPlus";
			Size size4 = new Size(24, 120);
			this.BtnLeftPlus.Size = size4;
			this.BtnLeftPlus.TabIndex = 15;
			this.BtnLeftPlus.Click += new EventHandler(this.BtnLeftPlus_Click);
			this.BtnUpPlus.Image = (Image)resourceManager.GetObject("BtnUpPlus.Image");
			Point location5 = new Point(24, 0);
			this.BtnUpPlus.Location = location5;
			this.BtnUpPlus.Name = "BtnUpPlus";
			Size size5 = new Size(128, 24);
			this.BtnUpPlus.Size = size5;
			this.BtnUpPlus.TabIndex = 14;
			this.BtnUpPlus.Click += new EventHandler(this.BtnUpPlus_Click);
			this.BtnDown.Image = (Image)resourceManager.GetObject("BtnDown.Image");
			Point location6 = new Point(48, 72);
			this.BtnDown.Location = location6;
			this.BtnDown.Name = "BtnDown";
			Size size6 = new Size(80, 24);
			this.BtnDown.Size = size6;
			this.BtnDown.TabIndex = 13;
			this.BtnDown.Click += new EventHandler(this.BtnDown_Click);
			this.BtnUp.Image = (Image)resourceManager.GetObject("BtnUp.Image");
			Point location7 = new Point(48, 24);
			this.BtnUp.Location = location7;
			this.BtnUp.Name = "BtnUp";
			Size size7 = new Size(80, 24);
			this.BtnUp.Size = size7;
			this.BtnUp.TabIndex = 12;
			this.BtnUp.Click += new EventHandler(this.BtnUp_Click);
			this.BtnRight.Image = (Image)resourceManager.GetObject("BtnRight.Image");
			Point location8 = new Point(128, 24);
			this.BtnRight.Location = location8;
			this.BtnRight.Name = "BtnRight";
			Size size8 = new Size(24, 72);
			this.BtnRight.Size = size8;
			this.BtnRight.TabIndex = 11;
			this.BtnRight.Click += new EventHandler(this.BtnRight_Click);
			this.BtnLeft.Image = (Image)resourceManager.GetObject("BtnLeft.Image");
			Point location9 = new Point(24, 24);
			this.BtnLeft.Location = location9;
			this.BtnLeft.Name = "BtnLeft";
			Size size9 = new Size(24, 72);
			this.BtnLeft.Size = size9;
			this.BtnLeft.TabIndex = 10;
			this.BtnLeft.Click += new EventHandler(this.BtnLeft_Click);
			Point location10 = new Point(48, 48);
			this.SketchBtn.Location = location10;
			this.SketchBtn.Name = "SketchBtn";
			Size size10 = new Size(80, 23);
			this.SketchBtn.Size = size10;
			this.SketchBtn.TabIndex = 9;
			this.SketchBtn.Text = "Load sketch";
			this.SketchBtn.Click += new EventHandler(this.SketchBtn_Click);
			base.Controls.Add(this.SketchPanel);
			base.Name = "ToolboxSectors";
			Size size11 = new Size(256, 480);
			base.Size = size11;
			this.SketchPanel.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void SectorTools_ButtonClick(int idx, int radio_group)
		{
			if (radio_group == 1)
			{
				this.raise_Action(idx, null);
			}
		}

		private void SketchBtn_Click(object sender, EventArgs e)
		{
			if (this.LoadSketchDialog.ShowDialog() == DialogResult.OK)
			{
				this.raise_Action(2, this.LoadSketchDialog.FileName);
			}
		}

		private void BtnUp_Click(object sender, EventArgs e)
		{
			this.raise_Action(3, null);
		}

		private void BtnDown_Click(object sender, EventArgs e)
		{
			this.raise_Action(4, null);
		}

		private void BtnRight_Click(object sender, EventArgs e)
		{
			this.raise_Action(6, null);
		}

		private void BtnLeft_Click(object sender, EventArgs e)
		{
			this.raise_Action(5, null);
		}

		private void BtnRightPlus_Click(object sender, EventArgs e)
		{
			this.raise_Action(10, null);
		}

		private void BtnUpPlus_Click(object sender, EventArgs e)
		{
			this.raise_Action(7, null);
		}

		private void BtnLeftPlus_Click(object sender, EventArgs e)
		{
			this.raise_Action(9, null);
		}

		private void BtnDownPlus_Click(object sender, EventArgs e)
		{
			this.raise_Action(8, null);
		}

		protected void raise_Action(int i1, string i2)
		{
			ToolboxSectors.SectorActionHandler action = this.Action;
			if (action != null)
			{
				action(i1, i2);
			}
		}
	}
}
