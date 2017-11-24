using NControls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NGameVariablesEditor : Form
	{
		public unsafe delegate void __Delegate_PUnitChanged(sbyte*);

		protected ArrayList ToolWindows;

		protected int ToolWindowIdx;

		protected NFileDialog FileDialog;

		protected string FileName;

		protected bool Modified;

		private MainMenu menuGameVariablesEditor;

		private MenuItem menuFile;

		private MenuItem menuFileSave;

		private MenuItem menuFileClose;

		private MenuItem menuFileSeparator2;

		private MenuItem menuEdit;

		private MenuItem menuEditUndo;

		private MenuItem menuEditRedo;

		private MenuItem menuItem1;

		private MenuItem menuItem2;

		private Panel panel1;

		private IContainer components;

		private Toolbar tbMain;

		private PropertyTree GameVarsPropTree;

		private unsafe GArray<GStreamBuffer>* UndoArray;

		private int UndoIndex;

		private int SavedIndex;

		public event NGameVariablesEditor.__Delegate_PUnitChanged PUnitChanged
		{
			add
			{
				this.PUnitChanged = Delegate.Combine(this.PUnitChanged, value);
			}
			remove
			{
				this.PUnitChanged = Delegate.Remove(this.PUnitChanged, value);
			}
		}

		public unsafe NGameVariablesEditor(ArrayList toolwindows)
		{
			this.PUnitChanged = null;
			this.InitializeComponent();
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0NGameVariablesEditor@NWorkshop@@Q$AAM@P$AAVArrayList@Collections@System@@@Z@4PAUGToolbarItem@NControls@@A), 24);
			this.tbMain = toolbar;
			toolbar.Dock = DockStyle.Top;
			this.tbMain.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tbGameVariablesEditor_ButtonClick);
			base.Controls.Add(this.tbMain);
			PropertyTree propertyTree = new PropertyTree(2, NewAssetPicker.ObjectType.GameVariablesEditor, null);
			this.GameVarsPropTree = propertyTree;
			this.panel1.Controls.Add(propertyTree);
			this.GameVarsPropTree.Dock = DockStyle.Fill;
			Point location = new Point(0, 0);
			this.GameVarsPropTree.Location = location;
			this.GameVarsPropTree.Name = "GameVarsPropTree";
			Size size = new Size(250, 435);
			this.GameVarsPropTree.Size = size;
			this.GameVarsPropTree.TabIndex = 0;
			this.GameVarsPropTree.Text = "GameVarsPropTree";
			this.GameVarsPropTree.ItemChanged += new PropertyTree.__Delegate_ItemChanged(this.GameVarsPropTree_ItemChanged);
			this.ToolWindows = toolwindows;
			toolwindows.Add(this);
			this.Modified = false;
			this.UpdateWindowText();
			this.tbMain.SetItemEnable(202, false);
			this.tbMain.SetItemEnable(203, false);
			this.tbMain.SetItemEnable(204, false);
			this.tbMain.SetItemEnable(205, false);
			this.tbMain.SetItemEnable(206, false);
			this.tbMain.SetItemEnable(207, false);
			this.tbMain.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = false;
			this.menuEditRedo.Enabled = false;
			this.menuFileSave.Enabled = false;
			GArray<GStreamBuffer>* ptr = <Module>.@new(12u);
			GArray<GStreamBuffer>* undoArray;
			try
			{
				if (ptr != null)
				{
					*(int*)ptr = 0;
					*(int*)(ptr + 4 / sizeof(GArray<GStreamBuffer>)) = 0;
					*(int*)(ptr + 8 / sizeof(GArray<GStreamBuffer>)) = 0;
					undoArray = ptr;
				}
				else
				{
					undoArray = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr);
				throw;
			}
			this.UndoArray = undoArray;
			this.UndoIndex = 0;
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
			this.panel1 = new Panel();
			this.menuGameVariablesEditor = new MainMenu();
			this.menuFile = new MenuItem();
			this.menuFileSave = new MenuItem();
			this.menuFileSeparator2 = new MenuItem();
			this.menuFileClose = new MenuItem();
			this.menuEdit = new MenuItem();
			this.menuEditUndo = new MenuItem();
			this.menuEditRedo = new MenuItem();
			this.menuItem1 = new MenuItem();
			this.menuItem2 = new MenuItem();
			base.SuspendLayout();
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Dock = DockStyle.Fill;
			Point location = new Point(0, 0);
			this.panel1.Location = location;
			this.panel1.Name = "panel1";
			Size size = new Size(408, 457);
			this.panel1.Size = size;
			this.panel1.TabIndex = 0;
			MenuItem[] items = new MenuItem[]
			{
				this.menuFile,
				this.menuEdit,
				this.menuItem1
			};
			this.menuGameVariablesEditor.MenuItems.AddRange(items);
			this.menuFile.Index = 0;
			MenuItem[] items2 = new MenuItem[]
			{
				this.menuFileSave,
				this.menuFileSeparator2,
				this.menuFileClose
			};
			this.menuFile.MenuItems.AddRange(items2);
			this.menuFile.Text = "&File";
			this.menuFileSave.Index = 0;
			this.menuFileSave.Shortcut = Shortcut.CtrlS;
			this.menuFileSave.Text = "&Save";
			this.menuFileSave.Click += new EventHandler(this.menuFileSave_Click);
			this.menuFileSeparator2.Index = 1;
			this.menuFileSeparator2.Text = "-";
			this.menuFileClose.Index = 2;
			this.menuFileClose.Shortcut = Shortcut.AltF4;
			this.menuFileClose.Text = "&Close";
			this.menuFileClose.Click += new EventHandler(this.menuFileClose_Click);
			this.menuEdit.Index = 1;
			MenuItem[] items3 = new MenuItem[]
			{
				this.menuEditUndo,
				this.menuEditRedo
			};
			this.menuEdit.MenuItems.AddRange(items3);
			this.menuEdit.Text = "&Edit";
			this.menuEditUndo.Index = 0;
			this.menuEditUndo.Shortcut = Shortcut.CtrlZ;
			this.menuEditUndo.Text = "&Undo";
			this.menuEditUndo.Click += new EventHandler(this.menuEditUndo_Click);
			this.menuEditRedo.Index = 1;
			this.menuEditRedo.Shortcut = Shortcut.CtrlR;
			this.menuEditRedo.Text = "&Redo";
			this.menuEditRedo.Click += new EventHandler(this.menuEditRedo_Click);
			this.menuItem1.Index = 2;
			MenuItem[] items4 = new MenuItem[]
			{
				this.menuItem2
			};
			this.menuItem1.MenuItems.AddRange(items4);
			this.menuItem1.Text = "&Help";
			this.menuItem2.Enabled = false;
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "RTFS ;)";
			Size autoScaleBaseSize = new Size(5, 14);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(408, 457);
			base.ClientSize = clientSize;
			base.Controls.Add(this.panel1);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Menu = this.menuGameVariablesEditor;
			base.Name = "NGameVariablesEditor";
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Game Variables";
			base.Closing += new CancelEventHandler(this.GameVariablesEditor_Closing);
			base.Load += new EventHandler(this.NGameVariablesEditor_Load);
			base.Closed += new EventHandler(this.GameVariablesEditor_Closed);
			base.ResumeLayout(false);
		}

		private unsafe void NGameVariablesEditor_Load(object sender, EventArgs e)
		{
			this.GameVarsPropTree.SetVariable(&<Module>.GRTT_GameVariables.Class_GGameVariables, (void*)(&<Module>.GameVariables), ref <Module>.Measures);
			this.GameVarsPropTree.Focus();
			<Module>.GArray<GStreamBuffer>.Clear(this.UndoArray, 0);
			int num = <Module>.GArray<GStreamBuffer>.Add(this.UndoArray);
			this.UndoIndex = num;
			<Module>.GRTTI.SaveVariablesAsText(num * 36 + *(int*)this.UndoArray, &<Module>.GRTT_GameVariables.Class_GGameVariables, (void*)(&<Module>.GameVariables), ref <Module>.Measures);
			this.SavedIndex = this.UndoIndex;
			this.Modified = false;
			this.UpdateWindowText();
			this.tbMain.SetItemEnable(207, false);
			this.tbMain.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = false;
			this.menuEditRedo.Enabled = false;
		}

		private unsafe void GameVarsPropTree_ItemChanged()
		{
			if (this.UndoIndex + 1 < *(int*)(this.UndoArray + 4 / sizeof(GArray<GStreamBuffer>)))
			{
				do
				{
					GArray<GStreamBuffer>* expr_19 = this.UndoArray;
					<Module>.GArray<GStreamBuffer>.Remove(expr_19, *(int*)(expr_19 + 4 / sizeof(GArray<GStreamBuffer>)) - 1);
				}
				while (this.UndoIndex + 1 < *(int*)(this.UndoArray + 4 / sizeof(GArray<GStreamBuffer>)));
			}
			GArray<GStreamBuffer>* undoArray = this.UndoArray;
			if (*(int*)(undoArray + 4 / sizeof(GArray<GStreamBuffer>)) >= 32)
			{
				GArray<GStreamBuffer>* ptr = undoArray;
				if (0 >= *(ptr + 4))
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DB@DFIJMDNC@c?3?2jtfcode?2src?2core?2include?2?4?4?1t@), 116, (sbyte*)(&<Module>.??_C@_0CE@LPFCBJKE@GArray?$DMclass?5GStreamBuffer?$DO?3?3Rem@));
					<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BN@PNEPLEML@invalid?5index?5?$CI?$CFd?$CJ?5Size?5?$DN?5?$CFd?$AA@), 0, *(ptr + 4));
				}
				int num = *ptr;
				object arg_7F_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), num, 0, *(*num));
				*(ptr + 4) = *(ptr + 4) + -1;
				int num2 = *(ptr + 4);
				if (num2 != 0)
				{
					num = *ptr;
					int expr_96 = num;
					<Module>.memmove(expr_96, expr_96 + 36, (uint)(num2 * 36));
				}
				initblk(*(ptr + 4) * 36 + *ptr, 0, 36);
			}
			int num3 = <Module>.GArray<GStreamBuffer>.Add(this.UndoArray);
			this.UndoIndex = num3;
			<Module>.GRTTI.SaveVariablesAsText(num3 * 36 + *(int*)this.UndoArray, &<Module>.GRTT_GameVariables.Class_GGameVariables, (void*)(&<Module>.GameVariables), ref <Module>.Measures);
			if (this.UndoIndex <= this.SavedIndex)
			{
				this.SavedIndex = 0;
			}
			this.Modified = true;
			this.tbMain.SetItemEnable(202, true);
			this.tbMain.SetItemEnable(207, true);
			this.tbMain.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = true;
			this.menuEditRedo.Enabled = false;
			this.menuFileSave.Enabled = true;
			this.UpdateWindowText();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private bool SaveIfModified(object sender, EventArgs e)
		{
			if (!this.Modified)
			{
				return true;
			}
			DialogResult dialogResult = MessageBox.Show("Game variables have been modified since the last save.\nDo you want to save?", "Save Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.No)
			{
				return true;
			}
			if (dialogResult == DialogResult.Yes)
			{
				this.menuFileSave_Click(sender, e);
				if (!this.Modified)
				{
					return true;
				}
			}
			return false;
		}

		private void GameVariablesEditor_Closing(object sender, CancelEventArgs e)
		{
			if (!this.SaveIfModified(sender, e))
			{
				e.Cancel = true;
			}
		}

		private void GameVariablesEditor_Closed(object sender, EventArgs e)
		{
			ArrayList toolWindows = this.ToolWindows;
			if (toolWindows != null)
			{
				toolWindows.Remove(this);
			}
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
			this.Text = "Game Variables" + str;
		}

		private void menuFileSave_Click(object sender, EventArgs e)
		{
			this.tbMain.Focus();
			this.GameVarsPropTree.Focus();
			if (<Module>.GGameVariables.SaveGameVariables(ref <Module>.GameVariables) != null)
			{
				this.SavedIndex = this.UndoIndex;
				this.Modified = false;
				this.tbMain.SetItemEnable(202, false);
				this.menuFileSave.Enabled = false;
				this.UpdateWindowText();
			}
		}

		private void menuFileClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void tbGameVariablesEditor_ButtonClick(int idx, int radio_group)
		{
			if (idx == 202)
			{
				this.menuFileSave_Click(null, null);
			}
			else if (idx == 207)
			{
				this.menuEditUndo_Click(null, null);
			}
			else if (idx == 208)
			{
				this.menuEditRedo_Click(null, null);
			}
		}

		private unsafe void menuEditUndo_Click(object sender, EventArgs e)
		{
			int undoIndex = this.UndoIndex;
			if (undoIndex > 0)
			{
				int num = undoIndex - 1;
				this.UndoIndex = num;
				<Module>.GStream.Reset(num * 36 + *(int*)this.UndoArray);
				<Module>.GRTTI.LoadVariablesAsText(this.UndoIndex * 36 + *(int*)this.UndoArray, &<Module>.GRTT_GameVariables.Class_GGameVariables, (void*)(&<Module>.GameVariables), ref <Module>.Measures);
				this.GameVarsPropTree.SetVariable(&<Module>.GRTT_GameVariables.Class_GGameVariables, (void*)(&<Module>.GameVariables), ref <Module>.Measures);
				if (this.UndoIndex == this.SavedIndex)
				{
					this.Modified = false;
					this.UpdateWindowText();
					this.tbMain.SetItemEnable(202, false);
					this.menuFileSave.Enabled = false;
				}
				else
				{
					this.Modified = true;
					this.tbMain.SetItemEnable(202, true);
					this.menuFileSave.Enabled = true;
				}
				this.UpdateWindowText();
				this.menuEditRedo.Enabled = true;
				this.tbMain.SetItemEnable(208, true);
				if (this.UndoIndex == 0)
				{
					this.tbMain.SetItemEnable(207, false);
					this.menuEditUndo.Enabled = false;
				}
			}
		}

		private unsafe void menuEditRedo_Click(object sender, EventArgs e)
		{
			GArray<GStreamBuffer>* undoArray = this.UndoArray;
			int undoIndex = this.UndoIndex;
			if (undoIndex < *(int*)(undoArray + 4 / sizeof(GArray<GStreamBuffer>)) - 1)
			{
				int num = undoIndex + 1;
				this.UndoIndex = num;
				<Module>.GStream.Reset(num * 36 + *(int*)undoArray);
				<Module>.GRTTI.LoadVariablesAsText(this.UndoIndex * 36 + *(int*)this.UndoArray, &<Module>.GRTT_GameVariables.Class_GGameVariables, (void*)(&<Module>.GameVariables), ref <Module>.Measures);
				this.GameVarsPropTree.SetVariable(&<Module>.GRTT_GameVariables.Class_GGameVariables, (void*)(&<Module>.GameVariables), ref <Module>.Measures);
				if (this.UndoIndex == this.SavedIndex)
				{
					this.Modified = false;
					this.UpdateWindowText();
					this.tbMain.SetItemEnable(202, false);
					this.menuFileSave.Enabled = false;
				}
				else
				{
					this.Modified = true;
					this.tbMain.SetItemEnable(202, true);
					this.menuFileSave.Enabled = true;
				}
				this.UpdateWindowText();
				this.menuEditUndo.Enabled = true;
				this.tbMain.SetItemEnable(207, true);
				if (this.UndoIndex == *(int*)(this.UndoArray + 4 / sizeof(GArray<GStreamBuffer>)) - 1)
				{
					this.tbMain.SetItemEnable(208, false);
					this.menuEditRedo.Enabled = false;
				}
			}
		}

		protected unsafe void raise_PUnitChanged(sbyte* i1)
		{
			NGameVariablesEditor.__Delegate_PUnitChanged pUnitChanged = this.PUnitChanged;
			if (pUnitChanged != null)
			{
				pUnitChanged(i1);
			}
		}
	}
}
