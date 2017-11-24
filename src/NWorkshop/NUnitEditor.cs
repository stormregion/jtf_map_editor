using NControls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NUnitEditor : Form
	{
		public unsafe delegate void __Delegate_PUnitChanged(sbyte*);

		protected unsafe GPUnitContainer* PUnitContainer;

		protected ArrayList ToolWindows;

		protected int ToolWindowIdx;

		protected NFileDialog FileDialog;

		protected string FileName;

		protected bool Modified;

		private MainMenu menuUnitEditor;

		private MenuItem menuFile;

		private MenuItem menuFileNew;

		private MenuItem menuFileOpen;

		private MenuItem menuFileSave;

		private MenuItem menuFileSaveAs;

		private MenuItem menuFileClose;

		private MenuItem menuFileSeparator2;

		private MenuItem menuFileSeparator1;

		private MenuItem menuFileOpenRecent;

		private MenuItem menuEdit;

		private MenuItem menuEditUndo;

		private MenuItem menuEditRedo;

		private MenuItem menuItem1;

		private MenuItem menuItem2;

		private Panel panel1;

		private IContainer components;

		private Toolbar tbMain;

		private PropertyTree UnitPropTree;

		private unsafe GArray<GStreamBuffer>* UndoArray;

		private int UndoIndex;

		private int SavedIndex;

		private string PUnitNameToLoad;

		public event NUnitEditor.__Delegate_PUnitChanged PUnitChanged
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

		public unsafe NUnitEditor(ArrayList toolwindows, string punit_name, NPropertyClipboard* clipboard)
		{
			this.PUnitChanged = null;
			this.InitializeComponent();
			if (punit_name != null && punit_name.Length > 0)
			{
				this.PUnitNameToLoad = punit_name;
			}
			else
			{
				this.PUnitNameToLoad = null;
			}
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?4???0NUnitEditor@NWorkshop@@Q$AAM@P$AAVArrayList@Collections@System@@P$AAVString@5@PAUNPropertyClipboard@NControls@@@Z@4PAUGToolbarItem@8@A), 24);
			this.tbMain = toolbar;
			toolbar.Dock = DockStyle.Top;
			this.tbMain.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tbUnitEditor_ButtonClick);
			base.Controls.Add(this.tbMain);
			PropertyTree propertyTree = new PropertyTree(2, NewAssetPicker.ObjectType.UnitEditor, clipboard);
			this.UnitPropTree = propertyTree;
			this.panel1.Controls.Add(propertyTree);
			this.UnitPropTree.Dock = DockStyle.Fill;
			Point location = new Point(0, 0);
			this.UnitPropTree.Location = location;
			this.UnitPropTree.Name = "UnitPropTree";
			Size size = new Size(250, 435);
			this.UnitPropTree.Size = size;
			this.UnitPropTree.TabIndex = 0;
			this.UnitPropTree.Text = "UnitPropTree";
			this.UnitPropTree.ItemChanged += new PropertyTree.__Delegate_ItemChanged(this.UnitPropTree_ItemChanged);
			this.ToolWindows = toolwindows;
			toolwindows.Add(this);
			GPUnitContainer* ptr = <Module>.@new(12u);
			GPUnitContainer* ptr2;
			try
			{
				if (ptr != null)
				{
					*(int*)ptr = 0;
					*(int*)(ptr + 4 / sizeof(GPUnitContainer)) = 0;
					try
					{
						*(int*)(ptr + 8 / sizeof(GPUnitContainer)) = 0;
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)ptr);
						throw;
					}
					ptr2 = ptr;
				}
				else
				{
					ptr2 = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr);
				throw;
			}
			this.PUnitContainer = ptr2;
			*(ptr2 + 8) = 0;
			this.FileName = "";
			this.Modified = false;
			this.UpdateWindowText();
			this.tbMain.SetItemEnable(203, false);
			this.tbMain.SetItemEnable(204, false);
			this.tbMain.SetItemEnable(205, false);
			this.tbMain.SetItemEnable(206, false);
			this.tbMain.SetItemEnable(207, false);
			this.tbMain.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = false;
			this.menuEditRedo.Enabled = false;
			GArray<GStreamBuffer>* ptr3 = <Module>.@new(12u);
			GArray<GStreamBuffer>* undoArray;
			try
			{
				if (ptr3 != null)
				{
					*(int*)ptr3 = 0;
					*(int*)(ptr3 + 4 / sizeof(GArray<GStreamBuffer>)) = 0;
					*(int*)(ptr3 + 8 / sizeof(GArray<GStreamBuffer>)) = 0;
					undoArray = ptr3;
				}
				else
				{
					undoArray = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr3);
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
			this.menuUnitEditor = new MainMenu();
			this.menuFile = new MenuItem();
			this.menuFileNew = new MenuItem();
			this.menuFileOpen = new MenuItem();
			this.menuFileOpenRecent = new MenuItem();
			this.menuFileSeparator1 = new MenuItem();
			this.menuFileSave = new MenuItem();
			this.menuFileSaveAs = new MenuItem();
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
			Size size = new Size(408, 721);
			this.panel1.Size = size;
			this.panel1.TabIndex = 0;
			MenuItem[] items = new MenuItem[]
			{
				this.menuFile,
				this.menuEdit,
				this.menuItem1
			};
			this.menuUnitEditor.MenuItems.AddRange(items);
			this.menuFile.Index = 0;
			MenuItem[] items2 = new MenuItem[]
			{
				this.menuFileNew,
				this.menuFileOpen,
				this.menuFileOpenRecent,
				this.menuFileSeparator1,
				this.menuFileSave,
				this.menuFileSaveAs,
				this.menuFileSeparator2,
				this.menuFileClose
			};
			this.menuFile.MenuItems.AddRange(items2);
			this.menuFile.Text = "&File";
			this.menuFileNew.Index = 0;
			this.menuFileNew.Shortcut = Shortcut.CtrlN;
			this.menuFileNew.Text = "&New";
			this.menuFileNew.Click += new EventHandler(this.menuFileNew_Click);
			this.menuFileOpen.Index = 1;
			this.menuFileOpen.Shortcut = Shortcut.CtrlO;
			this.menuFileOpen.Text = "Open...";
			this.menuFileOpen.Click += new EventHandler(this.menuFileOpen_Click);
			this.menuFileOpenRecent.Index = 2;
			this.menuFileOpenRecent.Text = "Open &Recent...";
			this.menuFileOpenRecent.Click += new EventHandler(this.menuFileOpenRecent_Click);
			this.menuFileSeparator1.Index = 3;
			this.menuFileSeparator1.Text = "-";
			this.menuFileSave.Index = 4;
			this.menuFileSave.Shortcut = Shortcut.CtrlS;
			this.menuFileSave.Text = "&Save";
			this.menuFileSave.Click += new EventHandler(this.menuFileSave_Click);
			this.menuFileSaveAs.Index = 5;
			this.menuFileSaveAs.Text = "S&ave As...";
			this.menuFileSaveAs.Click += new EventHandler(this.menuFileSaveAs_Click);
			this.menuFileSeparator2.Index = 6;
			this.menuFileSeparator2.Text = "-";
			this.menuFileClose.Index = 7;
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
			Size clientSize = new Size(408, 721);
			base.ClientSize = clientSize;
			base.Controls.Add(this.panel1);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Menu = this.menuUnitEditor;
			base.Name = "NUnitEditor";
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Unit Editor";
			base.Closing += new CancelEventHandler(this.UnitEditor_Closing);
			base.Load += new EventHandler(this.UnitEditor_Load);
			base.Closed += new EventHandler(this.UnitEditor_Closed);
			base.ResumeLayout(false);
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private bool SaveDocumentIfChanged()
		{
			if (!this.Modified)
			{
				return true;
			}
			DialogResult dialogResult = MessageBox.Show("The unit has been modified since the last save.\nDo you want to save?", "Save Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.No)
			{
				return true;
			}
			if (dialogResult == DialogResult.Yes)
			{
				this.menuFileSave_Click(null, null);
				if (!this.Modified)
				{
					return true;
				}
			}
			return false;
		}

		private unsafe void DiscardDocument()
		{
			uint num = (uint)(*(int*)(this.PUnitContainer + 8 / sizeof(GPUnitContainer)));
			if (num != 0u)
			{
				uint expr_0E = num;
				uint expr_18 = expr_0E + (uint)(*(*(expr_0E + 4u) + 4)) + 4u;
				object arg_22_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_18, *(*expr_18 + 4));
				*(int*)(this.PUnitContainer + 8 / sizeof(GPUnitContainer)) = 0;
			}
		}

		private unsafe void NewDocument(string filename)
		{
			this.DiscardDocument();
			if (filename.Length > 0)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, filename);
				try
				{
					uint num = (uint)(*ptr);
					<Module>.GUnitRegistry.LoadUnitFile((num == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num, this.PUnitContainer);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
					throw;
				}
				if (gBaseString<char> != null)
				{
					<Module>.free(gBaseString<char>);
					gBaseString<char> = 0;
				}
				GBaseString<char> gBaseString<char>2;
				GBaseString<char>* src = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, filename);
				try
				{
					<Module>.GBaseString<char>.=(this.PUnitContainer, src);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
					throw;
				}
				if (gBaseString<char>2 != null)
				{
					<Module>.free(gBaseString<char>2);
					gBaseString<char>2 = 0;
				}
			}
			else
			{
				*(int*)(this.PUnitContainer + 8 / sizeof(GPUnitContainer)) = 0;
			}
			this.UnitPropTree.SetVariable(&<Module>.GRTT_Unit.Class_GPUnitContainer, (void*)this.PUnitContainer, ref <Module>.Measures);
			this.UnitPropTree.Focus();
			<Module>.GArray<GStreamBuffer>.Clear(this.UndoArray, 0);
			int num2 = <Module>.GArray<GStreamBuffer>.Add(this.UndoArray);
			this.UndoIndex = num2;
			<Module>.GRTTI.SaveVariablesAsText(num2 * 36 + *(int*)this.UndoArray, &<Module>.GRTT_Unit.Class_GPUnitContainer, (void*)this.PUnitContainer, ref <Module>.Measures);
			this.SavedIndex = this.UndoIndex;
			this.FileName = string.Empty;
			this.Modified = false;
			this.UpdateWindowText();
			this.tbMain.SetItemEnable(207, false);
			this.tbMain.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = false;
			this.menuEditRedo.Enabled = false;
		}

		private unsafe void OpenDocument(string filepathname)
		{
			this.DiscardDocument();
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, filepathname);
			try
			{
				uint num = (uint)(*ptr);
				<Module>.GUnitRegistry.LoadUnitFile((num == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num, this.PUnitContainer);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
			}
			this.UnitPropTree.SetVariable(&<Module>.GRTT_Unit.Class_GPUnitContainer, (void*)this.PUnitContainer, ref <Module>.Measures);
			this.UnitPropTree.Focus();
			<Module>.GArray<GStreamBuffer>.Clear(this.UndoArray, 0);
			int num2 = <Module>.GArray<GStreamBuffer>.Add(this.UndoArray);
			this.UndoIndex = num2;
			<Module>.GRTTI.SaveVariablesAsText(num2 * 36 + *(int*)this.UndoArray, &<Module>.GRTT_Unit.Class_GPUnitContainer, (void*)this.PUnitContainer, ref <Module>.Measures);
			this.SavedIndex = this.UndoIndex;
			this.FileName = filepathname;
			this.Modified = false;
			this.UpdateWindowText();
			this.tbMain.SetItemEnable(207, false);
			this.tbMain.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = false;
			this.menuEditRedo.Enabled = false;
		}

		private unsafe void SaveDocument()
		{
			GBaseString<char> gBaseString<char>;
			<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.FileName);
			try
			{
				if (<Module>.GUnitRegistry.SaveUnitFile((gBaseString<char> == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>, this.PUnitContainer) != null)
				{
					this.SavedIndex = this.UndoIndex;
					this.Modified = false;
					this.UpdateWindowText();
					<Module>.GUnitRegistry.ReloadPUnits(<Module>.UnitRegistry);
					sbyte* ptr;
					if (gBaseString<char> != null)
					{
						ptr = gBaseString<char>;
					}
					else
					{
						ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					GPath gPath;
					<Module>.GPath.{ctor}(ref gPath, ptr);
					try
					{
						int num = 0;
						if (0 < *(ref gPath + 16))
						{
							while (<Module>.GBaseString<char>.Compare(num * 8 + *(ref gPath + 12), (sbyte*)(&<Module>.??_C@_05CCBEFJDC@units?$AA@), false) != null)
							{
								num++;
								if (num >= *(ref gPath + 16))
								{
									break;
								}
							}
						}
						sbyte* ptr2 = (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@);
						sbyte b;
						do
						{
							b = *(sbyte*)ptr2;
							ptr2 += 1 / sizeof(sbyte);
						}
						while (b != 0);
						*(ref gBaseString<char> + 4) = ptr2 - ref <Module>.??_C@_00CNPNBAHC@?$AA@ / sizeof(sbyte) - 1 / sizeof(sbyte);
						uint num2 = (uint)(*(ref gBaseString<char> + 4) + 1);
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num2);
						cpblk(gBaseString<char>, ref <Module>.??_C@_00CNPNBAHC@?$AA@, num2);
						if (num < *(ref gPath + 16) - 1)
						{
							do
							{
								GBaseString<char> gBaseString<char>2;
								GBaseString<char>* ptr3 = <Module>.GBaseString<char>.+(num * 8 + *(ref gPath + 12), &gBaseString<char>2, (sbyte*)(&<Module>.??_C@_01KMDKNFGN@?1?$AA@));
								try
								{
									int num3 = *(int*)(ptr3 + 4 / sizeof(GBaseString<char>));
									if (num3 != 0)
									{
										gBaseString<char> = <Module>.realloc(gBaseString<char>, (uint)(*(ref gBaseString<char> + 4) + num3 + 1));
										cpblk(*(ref gBaseString<char> + 4) + gBaseString<char>, *(int*)ptr3, *(int*)(ptr3 + 4 / sizeof(GBaseString<char>)) + 1);
										*(ref gBaseString<char> + 4) = *(int*)(ptr3 + 4 / sizeof(GBaseString<char>)) + *(ref gBaseString<char> + 4);
									}
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
									throw;
								}
								if (gBaseString<char>2 != null)
								{
									<Module>.free(gBaseString<char>2);
									gBaseString<char>2 = 0;
								}
								num++;
							}
							while (num < *(ref gPath + 16) - 1);
						}
						GBaseString<char>* ptr4 = *(ref gPath + 16) * 8 + *(ref gPath + 12) - 8;
						int num4 = *(ptr4 + 4);
						if (num4 != 0)
						{
							gBaseString<char> = <Module>.realloc(gBaseString<char>, (uint)(*(ref gBaseString<char> + 4) + num4 + 1));
							cpblk(*(ref gBaseString<char> + 4) + gBaseString<char>, *ptr4, *(ptr4 + 4) + 1);
							*(ref gBaseString<char> + 4) = *(ptr4 + 4) + *(ref gBaseString<char> + 4);
						}
						sbyte* i;
						if (gBaseString<char> != null)
						{
							i = gBaseString<char>;
						}
						else
						{
							i = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						this.raise_PUnitChanged(i);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath));
						throw;
					}
					try
					{
						<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath + 12);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath));
						throw;
					}
					if (gPath != null)
					{
						<Module>.free(gPath);
					}
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
			}
		}

		private unsafe void UnitPropTree_ItemChanged()
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
			<Module>.GRTTI.SaveVariablesAsText(num3 * 36 + *(int*)this.UndoArray, &<Module>.GRTT_Unit.Class_GPUnitContainer, (void*)this.PUnitContainer, ref <Module>.Measures);
			if (this.UndoIndex <= this.SavedIndex)
			{
				this.SavedIndex = 0;
			}
			this.Modified = true;
			this.tbMain.SetItemEnable(207, true);
			this.tbMain.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = true;
			this.menuEditRedo.Enabled = false;
			this.UpdateWindowText();
		}

		private void UnitEditor_Load(object sender, EventArgs e)
		{
			string pUnitNameToLoad = this.PUnitNameToLoad;
			if (pUnitNameToLoad != null)
			{
				this.OpenDocument(pUnitNameToLoad);
			}
			else
			{
				this.menuFileNew_Click(sender, e);
			}
		}

		private void UnitEditor_Closing(object sender, CancelEventArgs e)
		{
			if (!this.SaveDocumentIfChanged())
			{
				e.Cancel = true;
			}
		}

		private unsafe void UnitEditor_Closed(object sender, EventArgs e)
		{
			ArrayList toolWindows = this.ToolWindows;
			if (toolWindows != null)
			{
				toolWindows.Remove(this);
			}
			uint num = (uint)(*(int*)(this.PUnitContainer + 8 / sizeof(GPUnitContainer)));
			if (num != 0u)
			{
				uint expr_1F = num;
				uint expr_29 = expr_1F + (uint)(*(*(expr_1F + 4u) + 4)) + 4u;
				object arg_33_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_29, *(*expr_29 + 4));
				*(int*)(this.PUnitContainer + 8 / sizeof(GPUnitContainer)) = 0;
			}
			GArray<GStreamBuffer>* undoArray = this.UndoArray;
			if (undoArray != null)
			{
				GArray<GStreamBuffer>* ptr = undoArray;
				<Module>.GArray<GStreamBuffer>.{dtor}(ptr);
				<Module>.delete((void*)ptr);
				this.UndoArray = null;
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
			string str2;
			if (this.FileName.Length != 0)
			{
				str2 = this.FileName;
			}
			else
			{
				str2 = "Untitled";
			}
			this.Text = str2 + str + " - Unit Editor";
		}

		private void menuFileNew_Click(object sender, EventArgs e)
		{
			this.tbMain.Focus();
			if (this.SaveDocumentIfChanged())
			{
				NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 56, true);
				this.FileDialog = nFileDialog;
				nFileDialog.SetTypeToUnitEditor();
				this.FileDialog.DefaultExtension = "unit";
				this.FileDialog.AvailableModes = 11;
				this.FileDialog.SelectedMode = 1;
				this.FileDialog.FileName = "";
				if (this.FileDialog.ShowDialog() == DialogResult.OK)
				{
					NFileDialog fileDialog = this.FileDialog;
					if (fileDialog.SelectedMode == 1)
					{
						this.NewDocument(fileDialog.NewUnitFileName);
					}
					else
					{
						this.OpenDocument(fileDialog.FilePath);
						this.FileDialog.UpdateRecentFiles();
						<Module>.SaveOptions();
					}
				}
			}
		}

		private void menuFileOpen_Click(object sender, EventArgs e)
		{
			this.tbMain.Focus();
			if (this.SaveDocumentIfChanged())
			{
				NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 56, true);
				this.FileDialog = nFileDialog;
				nFileDialog.SetTypeToUnitEditor();
				this.FileDialog.DefaultExtension = "unit";
				this.FileDialog.AvailableModes = 11;
				this.FileDialog.SelectedMode = 2;
				this.FileDialog.FileName = "";
				if (this.FileDialog.ShowDialog() == DialogResult.OK)
				{
					NFileDialog fileDialog = this.FileDialog;
					if (fileDialog.SelectedMode == 1)
					{
						this.NewDocument(fileDialog.NewUnitFileName);
					}
					else
					{
						this.OpenDocument(fileDialog.FilePath);
						this.FileDialog.UpdateRecentFiles();
						<Module>.SaveOptions();
					}
				}
			}
		}

		private void menuFileOpenRecent_Click(object sender, EventArgs e)
		{
			this.tbMain.Focus();
			if (this.SaveDocumentIfChanged())
			{
				NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 56, true);
				this.FileDialog = nFileDialog;
				nFileDialog.SetTypeToUnitEditor();
				this.FileDialog.DefaultExtension = "unit";
				this.FileDialog.AvailableModes = 11;
				this.FileDialog.SelectedMode = 8;
				this.FileDialog.FileName = "";
				if (this.FileDialog.ShowDialog() == DialogResult.OK)
				{
					NFileDialog fileDialog = this.FileDialog;
					if (fileDialog.SelectedMode == 1)
					{
						this.NewDocument(fileDialog.NewUnitFileName);
					}
					else
					{
						this.OpenDocument(fileDialog.FilePath);
						this.FileDialog.UpdateRecentFiles();
						<Module>.SaveOptions();
					}
				}
			}
		}

		private void menuFileSave_Click(object sender, EventArgs e)
		{
			this.tbMain.Focus();
			this.UnitPropTree.Focus();
			if (this.FileName.Length == 0)
			{
				this.menuFileSaveAs_Click(sender, e);
			}
			else
			{
				this.SaveDocument();
			}
		}

		private void menuFileSaveAs_Click(object sender, EventArgs e)
		{
			this.tbMain.Focus();
			this.UnitPropTree.Focus();
			NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 56, true);
			this.FileDialog = nFileDialog;
			nFileDialog.DefaultExtension = "unit";
			this.FileDialog.AvailableModes = 12;
			this.FileDialog.SelectedMode = 4;
			if (this.FileDialog.ShowDialog() == DialogResult.OK)
			{
				this.FileName = this.FileDialog.FilePath;
				this.SaveDocument();
				this.FileDialog.UpdateRecentFiles();
				<Module>.SaveOptions();
			}
		}

		private void menuFileClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void tbUnitEditor_ButtonClick(int idx, int radio_group)
		{
			if (idx == 200)
			{
				this.menuFileNew_Click(null, null);
			}
			else if (idx == 201)
			{
				this.menuFileOpen_Click(null, null);
			}
			else if (idx == 202)
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
				<Module>.GRTTI.LoadVariablesAsText(this.UndoIndex * 36 + *(int*)this.UndoArray, &<Module>.GRTT_Unit.Class_GPUnitContainer, (void*)this.PUnitContainer, ref <Module>.Measures);
				this.UnitPropTree.SetVariable(&<Module>.GRTT_Unit.Class_GPUnitContainer, (void*)this.PUnitContainer, ref <Module>.Measures);
				if (this.UndoIndex == this.SavedIndex)
				{
					this.Modified = false;
					this.UpdateWindowText();
				}
				else
				{
					this.Modified = true;
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
				<Module>.GRTTI.LoadVariablesAsText(this.UndoIndex * 36 + *(int*)this.UndoArray, &<Module>.GRTT_Unit.Class_GPUnitContainer, (void*)this.PUnitContainer, ref <Module>.Measures);
				this.UnitPropTree.SetVariable(&<Module>.GRTT_Unit.Class_GPUnitContainer, (void*)this.PUnitContainer, ref <Module>.Measures);
				if (this.UndoIndex == this.SavedIndex)
				{
					this.Modified = false;
					this.UpdateWindowText();
				}
				else
				{
					this.Modified = true;
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
			NUnitEditor.__Delegate_PUnitChanged pUnitChanged = this.PUnitChanged;
			if (pUnitChanged != null)
			{
				pUnitChanged(i1);
			}
		}
	}
}
