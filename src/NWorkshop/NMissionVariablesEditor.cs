using NControls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NMissionVariablesEditor : Form
	{
		protected ArrayList ToolWindows;

		protected int ToolWindowIdx;

		protected NFileDialog FileDialog;

		protected string FileName;

		protected bool Modified;

		private unsafe GEditorWorld* propWorld;

		private MainMenu menuMissionVariablesEditor;

		private MenuItem menuFile;

		private MenuItem menuFileClose;

		private Panel panel1;

		private Container components;

		private Toolbar tbMain;

		private PropertyTree MissionVarsPropTree;

		public unsafe NMissionVariablesEditor(ArrayList toolwindows, GEditorWorld* world)
		{
			this.propWorld = world;
			this.InitializeComponent();
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0NMissionVariablesEditor@NWorkshop@@Q$AAM@P$AAVArrayList@Collections@System@@PAVGEditorWorld@@@Z@4PAUGToolbarItem@NControls@@A), 24);
			this.tbMain = toolbar;
			toolbar.Dock = DockStyle.Top;
			this.tbMain.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tbMissionVariablesEditor_ButtonClick);
			base.Controls.Add(this.tbMain);
			PropertyTree propertyTree = new PropertyTree(2, NewAssetPicker.ObjectType.MissionVariablesEditor, null);
			this.MissionVarsPropTree = propertyTree;
			this.panel1.Controls.Add(propertyTree);
			this.MissionVarsPropTree.Dock = DockStyle.Fill;
			Point location = new Point(0, 0);
			this.MissionVarsPropTree.Location = location;
			this.MissionVarsPropTree.Name = "MissionVarsPropTree";
			Size size = new Size(250, 435);
			this.MissionVarsPropTree.Size = size;
			this.MissionVarsPropTree.TabIndex = 0;
			this.MissionVarsPropTree.Text = "MissionVarsPropTree";
			this.MissionVarsPropTree.ItemChanged += new PropertyTree.__Delegate_ItemChanged(this.MissionVarsPropTree_ItemChanged);
			this.ToolWindows = toolwindows;
			toolwindows.Add(this);
			this.tbMain.SetItemEnable(202, false);
			this.tbMain.SetItemEnable(203, false);
			this.tbMain.SetItemEnable(204, false);
			this.tbMain.SetItemEnable(205, false);
			this.tbMain.SetItemEnable(206, false);
			this.Modified = false;
			this.UpdateWindowText();
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
			this.menuMissionVariablesEditor = new MainMenu();
			this.menuFile = new MenuItem();
			this.menuFileClose = new MenuItem();
			this.panel1 = new Panel();
			base.SuspendLayout();
			MenuItem[] items = new MenuItem[]
			{
				this.menuFile
			};
			this.menuMissionVariablesEditor.MenuItems.AddRange(items);
			this.menuFile.Index = 0;
			MenuItem[] items2 = new MenuItem[]
			{
				this.menuFileClose
			};
			this.menuFile.MenuItems.AddRange(items2);
			this.menuFile.Text = "&File";
			this.menuFileClose.Index = 0;
			this.menuFileClose.Text = "&Close";
			this.menuFileClose.Click += new EventHandler(this.menuFileClose_Click);
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Dock = DockStyle.Fill;
			Point location = new Point(0, 0);
			this.panel1.Location = location;
			this.panel1.Name = "panel1";
			Size size = new Size(408, 457);
			this.panel1.Size = size;
			this.panel1.TabIndex = 0;
			Size autoScaleBaseSize = new Size(5, 14);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(408, 457);
			base.ClientSize = clientSize;
			base.Controls.Add(this.panel1);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Menu = this.menuMissionVariablesEditor;
			base.Name = "NMissionVariablesEditor";
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Mission Variables";
			base.Load += new EventHandler(this.NMissionVariablesEditor_Load);
			base.Closed += new EventHandler(this.NMissionVariablesEditor_Closed);
			base.ResumeLayout(false);
		}

		private void tbMissionVariablesEditor_ButtonClick(int idx, int radio_group)
		{
		}

		private void MissionVarsPropTree_ItemChanged()
		{
			this.Modified = true;
			this.UpdateWindowText();
		}

		private void UpdateWindowText()
		{
			string str;
			if (this.Modified)
			{
				str = " *";
			}
			else
			{
				str = "";
			}
			this.Text = "Mission Variables" + str;
		}

		private unsafe void NMissionVariablesEditor_Load(object sender, EventArgs e)
		{
			this.MissionVarsPropTree.SetVariable(&<Module>.GRTT_MissionVariables.Class_GMissionVariables, (void*)(&<Module>.MissionVariables), ref <Module>.Measures);
			this.MissionVarsPropTree.Focus();
			this.Modified = false;
			this.UpdateWindowText();
		}

		private void NMissionVariablesEditor_Closed(object sender, EventArgs e)
		{
			if (this.Modified)
			{
				<Module>.GWorld.LoadMissionLocales();
			}
			ArrayList toolWindows = this.ToolWindows;
			if (toolWindows != null)
			{
				toolWindows.Remove(this);
			}
		}

		private void menuFileClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
