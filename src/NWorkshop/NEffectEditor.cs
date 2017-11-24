using <CppImplementationDetails>;
using GRTTI;
using NControls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NEffectEditor : Form
	{
		public unsafe delegate void __Delegate_PEffectChanged(sbyte*);

		protected ArrayList ToolWindows;

		protected int ToolWindowIdx;

		protected NFileDialog FileDialog;

		protected unsafe GHandle<9>* PEffect;

		protected unsafe GClass* PEffectClass;

		protected unsafe void* PEffectData;

		protected string FileName;

		protected string FileNameToLoad;

		protected bool Modified;

		protected int IRenderTargetIdx;

		protected unsafe GIRenderTarget* IRenderTarget;

		protected unsafe GIViewport* IViewport;

		protected unsafe GIScene* IScene;

		protected unsafe GITerrain* Terrain;

		protected unsafe GIEffect* Effect;

		protected long LastTime;

		protected int DragMode;

		protected int DragMX;

		protected int DragMY;

		protected $ArrayType$$$BY0BAA@_J KeyTimes;

		protected long LastUpdate;

		protected bool CamLimited;

		protected float CamDirection;

		protected float CamElevationMin;

		protected float CamElevationMax;

		protected float CamElevation;

		protected float CamDistanceMin;

		protected float CamDistanceMax;

		protected float CamDistance;

		protected float CameraBlendDist;

		protected unsafe GPoint3* EmitterPosition;

		protected unsafe GVector3* EmitterDirection;

		protected int EmitterVelType;

		protected int EmitterDirType;

		protected int EmitterMovType;

		protected int ShowEffectPosDir;

		protected unsafe GHandle<11>* EmitterLines;

		private Splitter splitter1;

		private MainMenu menuEffectEditor;

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

		private NSolidPanel panEffectViewport;

		private MenuItem menuItem8;

		private MenuItem menuEmitter;

		private MenuItem menuEmitterVel0;

		private MenuItem menuEmitterVel1;

		private MenuItem menuEmitterVel2;

		private MenuItem menuEmitterDirVerticalP;

		private MenuItem menuEmitterDirVerticalM;

		private MenuItem menuEmitterDirHorizontal;

		private MenuItem menuEmitterDirRotate;

		private MenuItem menuItem12;

		private MenuItem menuEmitterMovRotate;

		private MenuItem menuEmitterMovHorizontal;

		private MenuItem menuItem4;

		private MenuItem menuEmitterReset;

		private MenuItem menuEmitterVel3;

		private MenuItem menuEmitterMovVerticalP;

		private MenuItem menuEmitterMovVerticalM;

		private Panel panRight;

		private MenuItem menuItem3;

		private MenuItem menuViewDebugMode;

		private MenuItem menuItem2;

		private MenuItem menuItem5;

		private MenuItem menuViewShowEffectPosDir;

		private MenuItem menuItem1;

		private MenuItem menuWindOff;

		private MenuItem menuWindLight;

		private MenuItem menuWindMedium;

		private MenuItem menuWindHeavy;

		private Panel TrackPanel;

		private Splitter splitter2;

		private Panel panel1;

		private IContainer components;

		private Toolbar tbEffectEditor;

		private PropertyTree EffectPropTree;

		private NCurveEditor CurrentCurveEditor;

		private unsafe GArray<GStreamBuffer>* UndoArray;

		private int UndoIndex;

		private int SavedIndex;

		public event NEffectEditor.__Delegate_PEffectChanged PEffectChanged
		{
			add
			{
				this.PEffectChanged = Delegate.Combine(this.PEffectChanged, value);
			}
			remove
			{
				this.PEffectChanged = Delegate.Remove(this.PEffectChanged, value);
			}
		}

		public unsafe NEffectEditor(ArrayList toolwindows, string peffect_name, NPropertyClipboard* clipboard)
		{
			this.PEffectChanged = null;
			this.InitializeComponent();
			NSolidPanel nSolidPanel = new NSolidPanel();
			this.panEffectViewport = nSolidPanel;
			nSolidPanel.BorderStyle = BorderStyle.Fixed3D;
			this.panEffectViewport.Dock = DockStyle.Fill;
			Point location = new Point(0, 0);
			this.panEffectViewport.Location = location;
			this.panEffectViewport.Name = "panEffectViewport";
			Size size = new Size(629, 437);
			this.panEffectViewport.Size = size;
			this.panEffectViewport.TabIndex = 2;
			this.panEffectViewport.SizeChanged += new EventHandler(this.panEffectViewport_SizeChanged);
			this.panEffectViewport.MouseUp += new MouseEventHandler(this.panEffectViewport_MouseUp);
			this.panEffectViewport.Paint += new PaintEventHandler(this.panEffectViewport_Paint);
			this.panEffectViewport.MouseMove += new MouseEventHandler(this.panEffectViewport_MouseMove);
			this.panEffectViewport.MouseDown += new MouseEventHandler(this.panEffectViewport_MouseDown);
			this.panRight.Controls.Add(this.panEffectViewport);
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0NEffectEditor@NWorkshop@@Q$AAM@P$AAVArrayList@Collections@System@@P$AAVString@5@PAUNPropertyClipboard@NControls@@@Z@4PAUGToolbarItem@8@A), 24);
			this.tbEffectEditor = toolbar;
			toolbar.Dock = DockStyle.Top;
			this.tbEffectEditor.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tbEffectEditor_ButtonClick);
			base.Controls.Add(this.tbEffectEditor);
			PropertyTree propertyTree = new PropertyTree(1, NewAssetPicker.ObjectType.EffectEditor, clipboard);
			this.EffectPropTree = propertyTree;
			this.panel1.Controls.Add(propertyTree);
			this.EffectPropTree.Dock = DockStyle.Fill;
			Point location2 = new Point(0, 0);
			this.EffectPropTree.Location = location2;
			this.EffectPropTree.Name = "EffectPropTree";
			Size size2 = new Size(250, 435);
			this.EffectPropTree.Size = size2;
			this.EffectPropTree.TabIndex = 0;
			this.EffectPropTree.Text = "EffectPropTree";
			this.EffectPropTree.ItemChanged += new PropertyTree.__Delegate_ItemChanged(this.EffectPropTree_ItemChanged);
			this.EffectPropTree.SelectedIndexChanged += new PropertyTree.__Delegate_SelectedIndexChanged(this.EffectPropTree_SelectedIndexChanged);
			this.EffectPropTree.TrackSelected += new PropertyTreeCore.TrackSelectedHandler(this.StartTrackEditor);
			this.ToolWindows = toolwindows;
			NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 44, true);
			this.FileDialog = nFileDialog;
			nFileDialog.DefaultExtension = "fx";
			GHandle<9>* ptr = <Module>.@new(4u);
			GHandle<9>* pEffect;
			try
			{
				if (ptr != null)
				{
					*(int*)ptr = 0;
					pEffect = ptr;
				}
				else
				{
					pEffect = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr);
				throw;
			}
			this.PEffect = pEffect;
			this.PEffectClass = null;
			this.PEffectData = null;
			this.FileName = "";
			this.FileNameToLoad = peffect_name;
			this.Modified = false;
			this.UpdateWindowText();
			this.tbEffectEditor.SetItemEnable(203, false);
			this.tbEffectEditor.SetItemEnable(204, false);
			this.tbEffectEditor.SetItemEnable(205, false);
			this.tbEffectEditor.SetItemEnable(206, false);
			this.tbEffectEditor.SetItemEnable(207, false);
			this.tbEffectEditor.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = false;
			this.menuEditRedo.Enabled = false;
			this.menuFileSave.Enabled = false;
			this.IRenderTargetIdx = -1;
			this.IRenderTarget = null;
			this.IViewport = null;
			this.IScene = null;
			this.Terrain = null;
			this.Effect = null;
			initblk(ref this.KeyTimes, 0, 2048);
			this.LastUpdate = 0L;
			this.LastTime = 0L;
			this.DragMode = 0;
			this.DragMY = 0;
			this.DragMX = 0;
			this.CamLimited = true;
			this.CamDirection = 0f;
			this.CamElevationMin = 0.6981317f;
			this.CamElevationMax = 1.134464f;
			this.CamElevation = 0.916297853f;
			this.CamDistanceMin = <Module>.Measures * 44f;
			float num = <Module>.Measures * 80f;
			this.CamDistanceMax = num;
			float num2 = (this.CamDistanceMin + num) * 0.5f;
			this.CamDistance = num2;
			this.CameraBlendDist = num2;
			GPoint3* ptr2 = <Module>.@new(12u);
			GPoint3* emitterPosition;
			try
			{
				if (ptr2 != null)
				{
					*(float*)ptr2 = 0f;
					*(float*)(ptr2 + 4 / sizeof(GPoint3)) = 0f;
					*(float*)(ptr2 + 8 / sizeof(GPoint3)) = 0f;
					emitterPosition = ptr2;
				}
				else
				{
					emitterPosition = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr2);
				throw;
			}
			this.EmitterPosition = emitterPosition;
			GVector3* ptr3 = <Module>.@new(12u);
			GVector3* emitterDirection;
			try
			{
				if (ptr3 != null)
				{
					*(float*)ptr3 = 0f;
					*(float*)(ptr3 + 4 / sizeof(GVector3)) = 1f;
					*(float*)(ptr3 + 8 / sizeof(GVector3)) = 0f;
					emitterDirection = ptr3;
				}
				else
				{
					emitterDirection = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr3);
				throw;
			}
			this.EmitterDirection = emitterDirection;
			this.EmitterVelType = 0;
			this.EmitterDirType = 0;
			this.EmitterMovType = 2;
			this.ShowEffectPosDir = 1;
			this.menuViewShowEffectPosDir.Checked = true;
			GArray<GStreamBuffer>* ptr4 = <Module>.@new(12u);
			GArray<GStreamBuffer>* undoArray;
			try
			{
				if (ptr4 != null)
				{
					*(int*)ptr4 = 0;
					*(int*)(ptr4 + 4 / sizeof(GArray<GStreamBuffer>)) = 0;
					*(int*)(ptr4 + 8 / sizeof(GArray<GStreamBuffer>)) = 0;
					undoArray = ptr4;
				}
				else
				{
					undoArray = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr4);
				throw;
			}
			this.UndoArray = undoArray;
			this.UndoIndex = 0;
			this.CurrentCurveEditor = null;
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

		protected unsafe void RefreshEmitter(long time, long elapsed)
		{
			float num = (float)this.EmitterVelType / <Module>.Measures;
			switch (this.EmitterMovType)
			{
			case 0:
			{
				GPoint3* ptr = this.EmitterPosition + 4 / sizeof(GPoint3);
				*(float*)ptr = (float)elapsed * 1E-06f * num + *(float*)ptr;
				GPoint3* ptr2 = this.EmitterPosition + 4 / sizeof(GPoint3);
				if (*(float*)ptr2 > 32f)
				{
					*(float*)ptr2 -= 32f;
				}
				break;
			}
			case 1:
			{
				*(float*)(this.EmitterPosition + 4 / sizeof(GPoint3)) -= (float)elapsed * 1E-06f * num;
				GPoint3* ptr3 = this.EmitterPosition + 4 / sizeof(GPoint3);
				if (*(float*)ptr3 < 0f)
				{
					*(float*)ptr3 += 32f;
				}
				break;
			}
			case 2:
			{
				GPoint3* ptr4 = this.EmitterPosition + 8 / sizeof(GPoint3);
				*(float*)ptr4 = (float)elapsed * 1E-06f * num + *(float*)ptr4;
				GPoint3* ptr5 = this.EmitterPosition + 8 / sizeof(GPoint3);
				if (*(float*)ptr5 > 32f)
				{
					*(float*)ptr5 -= 64f;
				}
				break;
			}
			case 3:
			{
				float num2 = (float)time * 1E-06f * num * 0.09549297f;
				float num3 = (float)Math.Sin((double)num2);
				*(float*)this.EmitterPosition = num3 * 24f;
				float num4 = (float)Math.Cos((double)num2);
				*(float*)(this.EmitterPosition + 8 / sizeof(GPoint3)) = num4 * 24f;
				break;
			}
			}
			switch (this.EmitterDirType)
			{
			case 0:
			{
				GVector3 gVector = 0f;
				*(ref gVector + 4) = 1f;
				*(ref gVector + 8) = 0f;
				cpblk(this.EmitterDirection, ref gVector, 12);
				break;
			}
			case 1:
			{
				GVector3 gVector2 = 0f;
				*(ref gVector2 + 4) = -1f;
				*(ref gVector2 + 8) = 0f;
				cpblk(this.EmitterDirection, ref gVector2, 12);
				break;
			}
			case 2:
			{
				GVector3 gVector3 = 0f;
				*(ref gVector3 + 4) = 0f;
				*(ref gVector3 + 8) = 1f;
				cpblk(this.EmitterDirection, ref gVector3, 12);
				break;
			}
			case 3:
			{
				float num5 = (float)time * 1E-06f;
				float num6 = (float)Math.Sin((double)(num5 * 0.636619747f));
				*(float*)this.EmitterDirection = num6;
				float num7 = (float)Math.Sin((double)(num5 * 0.6684507f));
				*(float*)(this.EmitterDirection + 4 / sizeof(GVector3)) = num7;
				float num8 = (float)Math.Sin((double)(num5 * 0.700281739f));
				*(float*)(this.EmitterDirection + 8 / sizeof(GVector3)) = num8;
				break;
			}
			}
			GPoint3* emitterPosition = this.EmitterPosition;
			float num9 = *emitterPosition + 32f;
			float num10 = *(emitterPosition + 4);
			float num11 = *(emitterPosition + 8) + 32f;
			GPoint3 gPoint = num9;
			*(ref gPoint + 4) = num10;
			*(ref gPoint + 8) = num11;
			GIEffect* effect = this.Effect;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), effect, ref gPoint, *(*(int*)effect + 16));
			GIEffect* effect2 = this.Effect;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single), effect2, this.EmitterDirection, 0f, *(*(int*)effect2 + 20));
			GIScene* iScene = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), iScene, *this.EmitterLines, *(*(int*)iScene + 264));
			if (this.ShowEffectPosDir != 0)
			{
				GIScene* iScene2 = this.IScene;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iScene2, *this.EmitterLines, gPoint, 16776960, *(*(int*)iScene2 + 276));
				GVector3* emitterDirection = this.EmitterDirection;
				float num12 = *emitterDirection * 3f;
				float num13 = *(emitterDirection + 4) * 3f;
				float num14 = *(emitterDirection + 8) * 3f;
				float num15 = num12 + gPoint;
				float num16 = *(ref gPoint + 4) + num13;
				float num17 = *(ref gPoint + 8) + num14;
				GPoint3 gPoint2 = num15;
				*(ref gPoint2 + 4) = num16;
				*(ref gPoint2 + 8) = num17;
				iScene = this.IScene;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong),GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iScene, *this.EmitterLines, gPoint, 16776960, gPoint2, 16776960, *(*(int*)iScene + 280));
			}
		}

		private void InitializeComponent()
		{
			ResourceManager resourceManager = new ResourceManager(typeof(NEffectEditor));
			this.panel1 = new Panel();
			this.splitter1 = new Splitter();
			this.menuEffectEditor = new MainMenu();
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
			this.menuItem3 = new MenuItem();
			this.menuViewShowEffectPosDir = new MenuItem();
			this.menuItem5 = new MenuItem();
			this.menuItem2 = new MenuItem();
			this.menuViewDebugMode = new MenuItem();
			this.menuEmitter = new MenuItem();
			this.menuEmitterReset = new MenuItem();
			this.menuItem4 = new MenuItem();
			this.menuEmitterVel0 = new MenuItem();
			this.menuEmitterVel1 = new MenuItem();
			this.menuEmitterVel2 = new MenuItem();
			this.menuEmitterVel3 = new MenuItem();
			this.menuItem8 = new MenuItem();
			this.menuEmitterMovHorizontal = new MenuItem();
			this.menuEmitterMovVerticalP = new MenuItem();
			this.menuEmitterMovVerticalM = new MenuItem();
			this.menuEmitterMovRotate = new MenuItem();
			this.menuItem12 = new MenuItem();
			this.menuEmitterDirHorizontal = new MenuItem();
			this.menuEmitterDirVerticalP = new MenuItem();
			this.menuEmitterDirVerticalM = new MenuItem();
			this.menuEmitterDirRotate = new MenuItem();
			this.menuItem1 = new MenuItem();
			this.menuWindOff = new MenuItem();
			this.menuWindLight = new MenuItem();
			this.menuWindMedium = new MenuItem();
			this.menuWindHeavy = new MenuItem();
			this.panRight = new Panel();
			this.splitter2 = new Splitter();
			this.TrackPanel = new Panel();
			this.panRight.SuspendLayout();
			base.SuspendLayout();
			this.panel1.BorderStyle = BorderStyle.Fixed3D;
			this.panel1.Dock = DockStyle.Left;
			Point location = new Point(0, 0);
			this.panel1.Location = location;
			this.panel1.Name = "panel1";
			Size size = new Size(384, 654);
			this.panel1.Size = size;
			this.panel1.TabIndex = 0;
			Point location2 = new Point(384, 0);
			this.splitter1.Location = location2;
			this.splitter1.Name = "splitter1";
			Size size2 = new Size(3, 654);
			this.splitter1.Size = size2;
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			MenuItem[] items = new MenuItem[]
			{
				this.menuFile,
				this.menuEdit,
				this.menuItem3,
				this.menuEmitter,
				this.menuItem1
			};
			this.menuEffectEditor.MenuItems.AddRange(items);
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
			this.menuEditUndo.Text = "&Undo";
			this.menuEditUndo.Click += new EventHandler(this.menuEditUndo_Click);
			this.menuEditRedo.Index = 1;
			this.menuEditRedo.Text = "&Redo";
			this.menuEditRedo.Click += new EventHandler(this.menuEditRedo_Click);
			this.menuItem3.Index = 2;
			MenuItem[] items4 = new MenuItem[]
			{
				this.menuViewShowEffectPosDir,
				this.menuItem5,
				this.menuItem2,
				this.menuViewDebugMode
			};
			this.menuItem3.MenuItems.AddRange(items4);
			this.menuItem3.Text = "&View";
			this.menuViewShowEffectPosDir.Index = 0;
			this.menuViewShowEffectPosDir.Text = "Show Effect Position && Direction";
			this.menuViewShowEffectPosDir.Click += new EventHandler(this.menuViewShowEffectPosDir_Click);
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "Near-Camera Fade";
			this.menuItem2.Index = 2;
			this.menuItem2.Text = "-";
			this.menuViewDebugMode.Index = 3;
			this.menuViewDebugMode.Text = "&DebugMode";
			this.menuViewDebugMode.Click += new EventHandler(this.menuViewDebugMode_Click);
			this.menuEmitter.Index = 3;
			MenuItem[] items5 = new MenuItem[]
			{
				this.menuEmitterReset,
				this.menuItem4,
				this.menuEmitterVel0,
				this.menuEmitterVel1,
				this.menuEmitterVel2,
				this.menuEmitterVel3,
				this.menuItem8,
				this.menuEmitterMovHorizontal,
				this.menuEmitterMovVerticalP,
				this.menuEmitterMovVerticalM,
				this.menuEmitterMovRotate,
				this.menuItem12,
				this.menuEmitterDirHorizontal,
				this.menuEmitterDirVerticalP,
				this.menuEmitterDirVerticalM,
				this.menuEmitterDirRotate
			};
			this.menuEmitter.MenuItems.AddRange(items5);
			this.menuEmitter.Text = "E&mitterTest";
			this.menuEmitterReset.Index = 0;
			this.menuEmitterReset.Shortcut = Shortcut.CtrlR;
			this.menuEmitterReset.Text = "R&eset";
			this.menuEmitterReset.Click += new EventHandler(this.menuEmitterReset_Click);
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "-";
			this.menuEmitterVel0.Checked = true;
			this.menuEmitterVel0.Index = 2;
			this.menuEmitterVel0.Shortcut = Shortcut.Ctrl0;
			this.menuEmitterVel0.Text = "Vel.&0";
			this.menuEmitterVel0.Click += new EventHandler(this.menuEmitterVel0_Click);
			this.menuEmitterVel1.Index = 3;
			this.menuEmitterVel1.Shortcut = Shortcut.Ctrl1;
			this.menuEmitterVel1.Text = "Vel.&1";
			this.menuEmitterVel1.Click += new EventHandler(this.menuEmitterVel1_Click);
			this.menuEmitterVel2.Index = 4;
			this.menuEmitterVel2.Shortcut = Shortcut.Ctrl2;
			this.menuEmitterVel2.Text = "Vel.&2";
			this.menuEmitterVel2.Click += new EventHandler(this.menuEmitterVel2_Click);
			this.menuEmitterVel3.Index = 5;
			this.menuEmitterVel3.Shortcut = Shortcut.Ctrl3;
			this.menuEmitterVel3.Text = "Vel.3";
			this.menuEmitterVel3.Click += new EventHandler(this.menuEmitterVel3_Click);
			this.menuItem8.Index = 6;
			this.menuItem8.Text = "-";
			this.menuEmitterMovHorizontal.Checked = true;
			this.menuEmitterMovHorizontal.Index = 7;
			this.menuEmitterMovHorizontal.Text = "Mov.Horizontal";
			this.menuEmitterMovHorizontal.Click += new EventHandler(this.menuEmitterMovHorizontal_Click);
			this.menuEmitterMovVerticalP.Index = 8;
			this.menuEmitterMovVerticalP.Text = "Mov.Vertical +";
			this.menuEmitterMovVerticalP.Click += new EventHandler(this.menuEmitterMovVerticalP_Click);
			this.menuEmitterMovVerticalM.Index = 9;
			this.menuEmitterMovVerticalM.Text = "Mov.Vertical -";
			this.menuEmitterMovVerticalM.Click += new EventHandler(this.menuEmitterMovVerticalM_Click);
			this.menuEmitterMovRotate.Index = 10;
			this.menuEmitterMovRotate.Text = "Mov.Rotate";
			this.menuEmitterMovRotate.Click += new EventHandler(this.menuEmitterMovRotate_Click);
			this.menuItem12.Index = 11;
			this.menuItem12.Text = "-";
			this.menuEmitterDirHorizontal.Index = 12;
			this.menuEmitterDirHorizontal.Text = "Dir.Horizontal";
			this.menuEmitterDirHorizontal.Click += new EventHandler(this.menuEmitterDirHorizontal_Click);
			this.menuEmitterDirVerticalP.Checked = true;
			this.menuEmitterDirVerticalP.Index = 13;
			this.menuEmitterDirVerticalP.Text = "Dir.Vertical +";
			this.menuEmitterDirVerticalP.Click += new EventHandler(this.menuEmitterDirVerticalP_Click);
			this.menuEmitterDirVerticalM.Index = 14;
			this.menuEmitterDirVerticalM.Text = "Dir.Vertical -";
			this.menuEmitterDirVerticalM.Click += new EventHandler(this.menuEmitterDirVerticalM_Click);
			this.menuEmitterDirRotate.Index = 15;
			this.menuEmitterDirRotate.Text = "Dir.Rotate";
			this.menuEmitterDirRotate.Click += new EventHandler(this.menuEmitterDirRotate_Click);
			this.menuItem1.Index = 4;
			MenuItem[] items6 = new MenuItem[]
			{
				this.menuWindOff,
				this.menuWindLight,
				this.menuWindMedium,
				this.menuWindHeavy
			};
			this.menuItem1.MenuItems.AddRange(items6);
			this.menuItem1.Text = "&Wind";
			this.menuWindOff.Checked = true;
			this.menuWindOff.Index = 0;
			this.menuWindOff.RadioCheck = true;
			this.menuWindOff.Text = "Off";
			this.menuWindOff.Click += new EventHandler(this.menuWindOff_Click);
			this.menuWindLight.Index = 1;
			this.menuWindLight.RadioCheck = true;
			this.menuWindLight.Text = "Light (20 km/h)";
			this.menuWindLight.Click += new EventHandler(this.menuWindLight_Click);
			this.menuWindMedium.Index = 2;
			this.menuWindMedium.RadioCheck = true;
			this.menuWindMedium.Text = "Medium (40 km/h)";
			this.menuWindMedium.Click += new EventHandler(this.menuWindMedium_Click);
			this.menuWindHeavy.Index = 3;
			this.menuWindHeavy.RadioCheck = true;
			this.menuWindHeavy.Text = "Heavy (60 km/h)";
			this.menuWindHeavy.Click += new EventHandler(this.menuWindHeavy_Click);
			this.panRight.Controls.Add(this.splitter2);
			this.panRight.Controls.Add(this.TrackPanel);
			this.panRight.Dock = DockStyle.Fill;
			Point location3 = new Point(387, 0);
			this.panRight.Location = location3;
			this.panRight.Name = "panRight";
			Size size3 = new Size(629, 654);
			this.panRight.Size = size3;
			this.panRight.TabIndex = 4;
			this.splitter2.Dock = DockStyle.Bottom;
			Point location4 = new Point(0, 437);
			this.splitter2.Location = location4;
			this.splitter2.Name = "splitter2";
			Size size4 = new Size(629, 3);
			this.splitter2.Size = size4;
			this.splitter2.TabIndex = 3;
			this.splitter2.TabStop = false;
			this.TrackPanel.Dock = DockStyle.Bottom;
			Point location5 = new Point(0, 440);
			this.TrackPanel.Location = location5;
			this.TrackPanel.Name = "TrackPanel";
			Size size5 = new Size(629, 214);
			this.TrackPanel.Size = size5;
			this.TrackPanel.TabIndex = 4;
			Size autoScaleBaseSize = new Size(5, 14);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(1016, 654);
			base.ClientSize = clientSize;
			base.Controls.Add(this.panRight);
			base.Controls.Add(this.splitter1);
			base.Controls.Add(this.panel1);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Icon = (Icon)resourceManager.GetObject("$this.Icon");
			base.Menu = this.menuEffectEditor;
			base.Name = "NEffectEditor";
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "EffectEditor";
			base.Closing += new CancelEventHandler(this.EffectEditor_Closing);
			base.Load += new EventHandler(this.EffectEditor_Load);
			base.Closed += new EventHandler(this.EffectEditor_Closed);
			base.Activated += new EventHandler(this.EffectEditor_Activated);
			base.Deactivate += new EventHandler(this.EffectEditor_Deactivate);
			this.panRight.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private bool SaveDocumentIfChanged()
		{
			if (!this.Modified)
			{
				return true;
			}
			DialogResult dialogResult = MessageBox.Show("The effect has been modified since the last save.\nDo you want to save?", "Save Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
			if (((*(int*)this.PEffect != 0) ? 1 : 0) != 0)
			{
				GMeasures gMeasures;
				this.EffectPropTree.SetVariable(null, null, <Module>.GMeasures.{ctor}(ref gMeasures, <Module>.Measures, 1f));
				this.PEffectClass = null;
				this.PEffectData = null;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>), <Module>.IEngine, *this.PEffect, *(*(int*)<Module>.IEngine + 216));
			}
		}

		private unsafe void NewDocument()
		{
			this.DiscardDocument();
			GHandle<9> gHandle<9>;
			int num = calli(GHandle<9>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>*), <Module>.IEngine, ref gHandle<9>, *(*(int*)<Module>.IEngine + 220));
			cpblk(this.PEffect, num, 4);
			GClass* pEffectClass;
			void* pEffectData;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GRTTI.GClass** modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Void** modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), <Module>.IEngine, *this.PEffect, ref pEffectClass, ref pEffectData, *(*(int*)<Module>.IEngine + 236));
			this.PEffectClass = pEffectClass;
			this.PEffectData = pEffectData;
			GMeasures gMeasures;
			this.EffectPropTree.SetVariable(this.PEffectClass, this.PEffectData, <Module>.GMeasures.{ctor}(ref gMeasures, <Module>.Measures, 1f));
			<Module>.GArray<GStreamBuffer>.Clear(this.UndoArray, 0);
			int num2 = <Module>.GArray<GStreamBuffer>.Add(this.UndoArray);
			this.UndoIndex = num2;
			object arg_D4_0 = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GStream*), <Module>.IEngine, *this.PEffect, num2 * 36 + *(int*)this.UndoArray, *(*(int*)<Module>.IEngine + 224));
			this.SavedIndex = this.UndoIndex;
			this.FileName = "";
			this.Modified = false;
			this.tbEffectEditor.SetItemEnable(207, false);
			this.tbEffectEditor.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = false;
			this.menuEditRedo.Enabled = false;
			this.UpdateWindowText();
			this.UpdateEffect(true);
		}

		private unsafe void OpenDocument(sbyte* filepathname)
		{
			this.DiscardDocument();
			GHandle<9> gHandle<9>;
			int num = calli(GHandle<9>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>*,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, ref gHandle<9>, filepathname, *(*(int*)<Module>.IEngine + 212));
			GHandle<9> gHandle<9>2;
			cpblk(ref gHandle<9>2, num, 4);
			if (((gHandle<9>2 != 0) ? 1 : 0) != 0)
			{
				this.FileName = new string((sbyte*)filepathname);
				cpblk(this.PEffect, ref gHandle<9>2, 4);
				GClass* pEffectClass;
				void* pEffectData;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GRTTI.GClass** modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Void** modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), <Module>.IEngine, *this.PEffect, ref pEffectClass, ref pEffectData, *(*(int*)<Module>.IEngine + 236));
				this.PEffectClass = pEffectClass;
				this.PEffectData = pEffectData;
				GMeasures gMeasures;
				this.EffectPropTree.SetVariable(this.PEffectClass, this.PEffectData, <Module>.GMeasures.{ctor}(ref gMeasures, <Module>.Measures, 1f));
				<Module>.GArray<GStreamBuffer>.Clear(this.UndoArray, 0);
				int num2 = <Module>.GArray<GStreamBuffer>.Add(this.UndoArray);
				this.UndoIndex = num2;
				object arg_F8_0 = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GStream*), <Module>.IEngine, *this.PEffect, num2 * 36 + *(int*)this.UndoArray, *(*(int*)<Module>.IEngine + 224));
				this.SavedIndex = this.UndoIndex;
				this.Modified = false;
				this.tbEffectEditor.SetItemEnable(207, false);
				this.tbEffectEditor.SetItemEnable(208, false);
				this.menuEditUndo.Enabled = false;
				this.menuEditRedo.Enabled = false;
				this.UpdateWindowText();
				this.UpdateEffect(true);
				this.FileDialog.UpdateRecentFiles();
			}
			else
			{
				this.NewDocument();
			}
		}

		private unsafe void SaveDocument()
		{
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.FileName);
			bool flag;
			try
			{
				uint num = (uint)(*ptr);
				sbyte* ptr2;
				if (num != 0u)
				{
					ptr2 = num;
				}
				else
				{
					ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				flag = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, *this.PEffect, ptr2, *(*(int*)<Module>.IEngine + 228));
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
			if (flag)
			{
				this.SavedIndex = this.UndoIndex;
				this.Modified = false;
				this.UpdateWindowText();
				GIEngine* expr_80 = <Module>.IEngine;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_80, *(*(int*)expr_80 + 244));
			}
		}

		private void EffectEditor_Activated(object sender, EventArgs e)
		{
		}

		private void EffectEditor_Deactivate(object sender, EventArgs e)
		{
		}

		private unsafe void UpdateEffect([MarshalAs(UnmanagedType.U1)] bool refresh_prototype)
		{
			GIEffect* effect = this.Effect;
			if (effect != null)
			{
				GIEffect* expr_0B = effect;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_0B, *(*(int*)expr_0B + 4));
				effect = this.Effect;
				if (effect != null)
				{
					GIEffect* expr_20 = effect;
					GIEffect* expr_2A = expr_20 + *(*(int*)(expr_20 + 4 / sizeof(GIEffect)) + 4) / sizeof(GIEffect) + 4 / sizeof(GIEffect);
					object arg_34_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_2A, *(*(int*)expr_2A + 4));
					this.Effect = null;
				}
			}
			GHandle<9>* pEffect = this.PEffect;
			if (pEffect != null && ((*(int*)pEffect != 0) ? 1 : 0) != 0)
			{
				if (refresh_prototype)
				{
					object arg_78_0 = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>), <Module>.IEngine, *pEffect, *(*(int*)<Module>.IEngine + 240));
				}
				GPoint3* emitterPosition = this.EmitterPosition;
				float num = *emitterPosition + 32f;
				float num2 = *(emitterPosition + 4);
				float num3 = *(emitterPosition + 8) + 32f;
				GPoint3 gPoint = num;
				*(ref gPoint + 4) = num2;
				*(ref gPoint + 8) = num3;
				GIScene* iScene = this.IScene;
				this.Effect = calli(GIEffect* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),GVector3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single), iScene, *this.PEffect, ref gPoint, this.EmitterDirection, 0f, *(*(int*)iScene + 316));
			}
		}

		private unsafe void EffectPropTree_ItemChanged()
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
			object arg_F4_0 = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GStream*), <Module>.IEngine, *this.PEffect, num3 * 36 + *(int*)this.UndoArray, *(*(int*)<Module>.IEngine + 224));
			if (this.UndoIndex <= this.SavedIndex)
			{
				this.SavedIndex = 0;
			}
			this.Modified = true;
			this.tbEffectEditor.SetItemEnable(202, true);
			this.tbEffectEditor.SetItemEnable(207, true);
			this.tbEffectEditor.SetItemEnable(208, false);
			this.menuEditUndo.Enabled = true;
			this.menuEditRedo.Enabled = false;
			this.menuFileSave.Enabled = true;
			this.UpdateWindowText();
			this.UpdateEffect(true);
		}

		private void EffectPropTree_SelectedIndexChanged()
		{
		}

		private unsafe void EffectEditor_Load(object sender, EventArgs e)
		{
			HWND__* ptr = (HWND__*)this.panEffectViewport.Handle.ToPointer();
			int num = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,HWND__*,System.Int32), <Module>.IEngine, ptr, 4, *(*(int*)<Module>.IEngine + 100));
			this.IRenderTargetIdx = num;
			int num2 = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, num, *(*(int*)<Module>.IEngine + 96));
			this.IRenderTarget = num2;
			this.IViewport = calli(GIViewport* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), num2, 0, *(*num2 + 32));
			int num3 = calli(GIScene* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.IEngine, 1, *(*(int*)<Module>.IEngine + 12));
			this.IScene = num3;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), num3, 0.5f, 0.5f, 0.5f, 0f, 0f, 0f, 1f, 1f, *(*num3 + 76));
			GColor gColor = 0.6f;
			*(ref gColor + 4) = 0.6f;
			*(ref gColor + 8) = 0.6f;
			*(ref gColor + 12) = 1f;
			GIScene* iScene = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), iScene, ref gColor, *(*(int*)iScene + 68));
			GColor gColor2 = 0.5f;
			*(ref gColor2 + 4) = 0.5f;
			*(ref gColor2 + 8) = 0.5f;
			*(ref gColor2 + 12) = 1f;
			GIScene* iScene2 = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene2, ref gColor2, 2.61799383f, -0.6632251f, *(*(int*)iScene2 + 72));
			GIScene* iScene3 = this.IScene;
			int num4 = calli(GITerrain* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), iScene3, 64, 64, 1, *(*(int*)iScene3 + 152));
			this.Terrain = num4;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), num4, 5, *(*num4 + 32));
			GITerrain* terrain = this.Terrain;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), terrain, 0, ref <Module>.??_C@_0BC@NCEDNBHE@tiles?1000?5default?$AA@, *(*(int*)terrain + 12));
			this.panEffectViewport.MouseWheel += new MouseEventHandler(this.panEffectViewport_MouseWheel);
			this.panEffectViewport.KeyDown += new KeyEventHandler(this.panEffectViewport_KeyDown);
			this.panEffectViewport.KeyUp += new KeyEventHandler(this.panEffectViewport_KeyUp);
			this.ShowEffectPosDir = 1;
			this.menuViewShowEffectPosDir.Checked = true;
			GHandle<11>* ptr2 = <Module>.@new(4u);
			GHandle<11>* emitterLines;
			try
			{
				if (ptr2 != null)
				{
					*(int*)ptr2 = 0;
					emitterLines = ptr2;
				}
				else
				{
					emitterLines = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr2);
				throw;
			}
			this.EmitterLines = emitterLines;
			GIScene* iScene4 = this.IScene;
			GHandle<11> gHandle<11>;
			int num5 = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), iScene4, ref gHandle<11>, 0, *(*(int*)iScene4 + 256));
			cpblk(this.EmitterLines, num5, 4);
			Application.Idle += new EventHandler(this.OnIdle);
			if (this.FileNameToLoad.Length > 0)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr3 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.FileNameToLoad);
				GBaseString<char> gBaseString<char>2;
				try
				{
					uint num6 = (uint)(*ptr3);
					sbyte* ptr4;
					if (num6 != 0u)
					{
						ptr4 = num6;
					}
					else
					{
						ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					<Module>.GFileSystem.GetFileFullPath(ref <Module>.FS, &gBaseString<char>2, ptr4);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
					throw;
				}
				try
				{
					if (gBaseString<char> != null)
					{
						<Module>.free(gBaseString<char>);
					}
					if (((*(ref gBaseString<char>2 + 4) == 0) ? 1 : 0) == 0)
					{
						sbyte* value;
						if (gBaseString<char>2 != null)
						{
							value = gBaseString<char>2;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						this.FileDialog.FilePath = new string((sbyte*)value);
						sbyte* filepathname;
						if (gBaseString<char>2 != null)
						{
							filepathname = gBaseString<char>2;
						}
						else
						{
							filepathname = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						this.OpenDocument(filepathname);
					}
					else
					{
						this.NewDocument();
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
				}
			}
			else
			{
				this.NewDocument();
			}
		}

		private void EffectEditor_Closing(object sender, CancelEventArgs e)
		{
			if (!this.SaveDocumentIfChanged())
			{
				e.Cancel = true;
			}
		}

		private unsafe void EffectEditor_Closed(object sender, EventArgs e)
		{
			this.StartTrackEditor(null);
			GIScene* iScene = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), iScene, *this.EmitterLines, *(*(int*)iScene + 260));
			GHandle<11>* emitterLines = this.EmitterLines;
			if (emitterLines != null)
			{
				<Module>.delete((void*)emitterLines);
				this.EmitterLines = null;
			}
			GPoint3* emitterPosition = this.EmitterPosition;
			if (emitterPosition != null)
			{
				<Module>.delete((void*)emitterPosition);
				this.EmitterPosition = null;
			}
			GVector3* emitterDirection = this.EmitterDirection;
			if (emitterDirection != null)
			{
				<Module>.delete((void*)emitterDirection);
				this.EmitterDirection = null;
			}
			ArrayList toolWindows = this.ToolWindows;
			if (toolWindows != null)
			{
				toolWindows.Remove(this);
				this.ToolWindows = null;
			}
			GIEffect* effect = this.Effect;
			if (effect != null)
			{
				GIEffect* expr_9F = effect;
				GIEffect* expr_A9 = expr_9F + *(*(int*)(expr_9F + 4 / sizeof(GIEffect)) + 4) / sizeof(GIEffect) + 4 / sizeof(GIEffect);
				object arg_B3_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_A9, *(*(int*)expr_A9 + 4));
				this.Effect = null;
			}
			GIScene* expr_C1 = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_C1, *(*(int*)expr_C1 + 156));
			this.Terrain = null;
			GIScene* iScene2 = this.IScene;
			if (iScene2 != null)
			{
				GIScene* expr_E1 = iScene2;
				GIScene* expr_EB = expr_E1 + *(*(int*)(expr_E1 + 4 / sizeof(GIScene)) + 4) / sizeof(GIScene) + 4 / sizeof(GIScene);
				object arg_F5_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_EB, *(*(int*)expr_EB + 4));
				this.IScene = null;
			}
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, this.IRenderTargetIdx, *(*(int*)<Module>.IEngine + 104));
			this.IRenderTargetIdx = -1;
			this.IRenderTarget = null;
			this.IViewport = null;
			if (((*(int*)this.PEffect != 0) ? 1 : 0) != 0)
			{
				GMeasures gMeasures;
				this.EffectPropTree.SetVariable(null, null, <Module>.GMeasures.{ctor}(ref gMeasures, <Module>.Measures, 1f));
				this.PEffectClass = null;
				this.PEffectData = null;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>), <Module>.IEngine, *this.PEffect, *(*(int*)<Module>.IEngine + 216));
				*(int*)this.PEffect = 0;
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

		private void OnIdle(object sender, EventArgs e)
		{
			if (base.ContainsFocus)
			{
				this.panEffectViewport.Invalidate(false);
			}
		}

		private unsafe void panEffectViewport_Paint(object sender, PaintEventArgs e)
		{
			if (<Module>.ISoundSys != null)
			{
				GISoundSys* expr_0C = <Module>.ISoundSys;
				object arg_14_0 = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_0C, *(*(int*)expr_0C));
			}
			if (this.IRenderTarget != null && this.IViewport != null && this.IScene != null && this.Effect != null)
			{
				if (this.LastTime == 0L)
				{
					this.LastTime = <Module>.GTimer.GetTimeH(<Module>.Timer);
					this.CameraBlendDist = this.CamDistance;
				}
				long num = <Module>.GTimer.GetTimeH(<Module>.Timer);
				long num2 = num - this.LastTime;
				this.LastTime = num;
				float num3 = (float)Math.Exp((double)((float)num2 * -5E-06f));
				float num4 = (this.CameraBlendDist - this.CamDistance) * num3 + this.CamDistance;
				this.CameraBlendDist = num4;
				float camDirection = this.CamDirection;
				float num5 = (float)Math.Sin((double)camDirection);
				float camDirection2 = this.CamDirection;
				float num6 = (float)Math.Cos((double)camDirection2);
				float camElevation = this.CamElevation;
				float num7 = (float)Math.Sin((double)camElevation);
				float camElevation2 = this.CamElevation;
				float num8 = -(float)Math.Cos((double)camElevation2);
				GVector3 gVector = num8 * num5;
				*(ref gVector + 4) = num7;
				*(ref gVector + 8) = num8 * num6;
				float num9 = num4;
				float num10 = gVector * num9;
				float num11 = num9 * num7;
				float num12 = num9 * *(ref gVector + 8);
				float num13 = num10 + 32f;
				float num14 = num11;
				float num15 = num12 + 32f;
				GPoint3 gPoint = num13;
				*(ref gPoint + 4) = num14;
				*(ref gPoint + 8) = num15;
				GVector3 gVector2 = -(num7 * num5);
				*(ref gVector2 + 4) = num8;
				*(ref gVector2 + 8) = -(num7 * num6);
				GIViewport* iViewport = this.IViewport;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single,System.Single), iViewport, ref gPoint, this.CamDirection, this.CamElevation, 0f, *(*(int*)iViewport + 12));
				if (<Module>.ISoundSys != null)
				{
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),GVector3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),GVector3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), <Module>.ISoundSys, ref gPoint, ref gVector, ref gVector2, *(*(int*)<Module>.ISoundSys + 4));
				}
				this.RefreshEmitter(num, num2);
				GIScene* iScene = this.IScene;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), iScene, num2, *(*(int*)iScene + 32));
				GIRenderTarget* iRenderTarget = this.IRenderTarget;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GIScene*,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iRenderTarget, this.IScene, 8256, *(*(int*)iRenderTarget + 36));
			}
		}

		private unsafe void panEffectViewport_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.CompletePressedDrag(e.X, e.Y);
				if (*(ref this.KeyTimes + 136) != 0L)
				{
					this.DragMY = e.Y;
					this.DragMode = 10;
					this.panEffectViewport.Capture = true;
				}
				else
				{
					GPoint3 gPoint;
					*(ref gPoint + 8) = 0f;
					gPoint = 0f;
					GPlane gPlane = 0f;
					*(ref gPlane + 4) = 1f;
					*(ref gPlane + 8) = 0f;
					*(ref gPlane + 12) = -0f;
					int num = *(int*)this.IViewport + 56;
					GRay gRay;
					if (<Module>.GPlane.Intersect(ref gPlane, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, e.X, e.Y, *num), ref gPoint) != null)
					{
						*(float*)this.EmitterPosition = gPoint - 32f;
						*(float*)(this.EmitterPosition + 8 / sizeof(GPoint3)) = *(ref gPoint + 8) - 32f;
						this.DragMode = 9;
						this.panEffectViewport.Capture = true;
					}
				}
			}
			else if (e.Button == MouseButtons.Middle)
			{
				this.CompletePressedDrag(e.X, e.Y);
				this.DragMX = e.X;
				this.DragMY = e.Y;
				this.DragMode = 18;
				this.panEffectViewport.Capture = true;
				<Module>.ShowCursor(0);
			}
		}

		private void panEffectViewport_MouseUp(object sender, MouseEventArgs e)
		{
			this.CompletePressedDrag(e.X, e.Y);
		}

		private void CompletePressedDrag(int m_x, int m_y)
		{
			int dragMode = this.DragMode;
			if (dragMode != 0 && dragMode >= 6)
			{
				if (dragMode - 18 <= 1)
				{
					<Module>.ShowCursor(1);
				}
				this.DragMode = 0;
				this.panEffectViewport.Capture = false;
			}
		}

		private unsafe void panEffectViewport_MouseMove(object sender, MouseEventArgs e)
		{
			if (Form.ActiveForm == this)
			{
				this.panEffectViewport.Focus();
				int dragMode = this.DragMode;
				if (dragMode != 9)
				{
					if (dragMode != 10)
					{
						if (dragMode == 18 && (e.X != this.DragMX || e.Y != this.DragMY))
						{
							this.CamDirection = (float)(e.X - this.DragMX) * 0.002f + this.CamDirection;
							int dragMY = this.DragMY;
							float num = this.CamElevation - (float)(e.Y - dragMY) * 0.002f;
							float camElevationMax = this.CamElevationMax;
							float num2;
							if (num < camElevationMax)
							{
								num2 = num;
							}
							else
							{
								num2 = camElevationMax;
							}
							float camElevationMin = this.CamElevationMin;
							float camElevation;
							if (num2 > camElevationMin)
							{
								camElevation = num2;
							}
							else
							{
								camElevation = camElevationMin;
							}
							this.CamElevation = camElevation;
							tagPOINT dragMX = this.DragMX;
							*(ref dragMX + 4) = dragMY;
							<Module>.ClientToScreen((HWND__*)this.panEffectViewport.Handle.ToPointer(), &dragMX);
							<Module>.SetCursorPos(dragMX, *(ref dragMX + 4));
						}
					}
					else
					{
						GPoint3* ptr = this.EmitterPosition + 4 / sizeof(GPoint3);
						*(float*)ptr = (float)((double)(this.DragMY - e.Y) * 0.04 + (double)(*(float*)ptr));
						this.DragMY = e.Y;
					}
				}
				else
				{
					GPoint3 gPoint;
					*(ref gPoint + 8) = 0f;
					gPoint = 0f;
					GPlane gPlane = 0f;
					*(ref gPlane + 4) = 1f;
					*(ref gPlane + 8) = 0f;
					*(ref gPlane + 12) = -0f;
					int num3 = *(int*)this.IViewport + 56;
					GRay gRay;
					if (<Module>.GPlane.Intersect(ref gPlane, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, e.X, e.Y, *num3), ref gPoint) != null)
					{
						*(float*)this.EmitterPosition = gPoint - 32f;
						*(float*)(this.EmitterPosition + 8 / sizeof(GPoint3)) = *(ref gPoint + 8) - 32f;
					}
				}
			}
		}

		private void panEffectViewport_MouseWheel(object sender, MouseEventArgs e)
		{
			float num = this.CamDistance - (float)e.Delta * 0.008333334f * 2f;
			float camDistanceMin = this.CamDistanceMin;
			float num2;
			if (num > camDistanceMin)
			{
				num2 = num;
			}
			else
			{
				num2 = camDistanceMin;
			}
			float camDistanceMax = this.CamDistanceMax;
			float camDistance;
			if (num2 < camDistanceMax)
			{
				camDistance = num2;
			}
			else
			{
				camDistance = camDistanceMax;
			}
			this.CamDistance = camDistance;
		}

		private unsafe void panEffectViewport_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode >= Keys.None || e.KeyCode < (Keys)256)
			{
				if (*(e.KeyCode * Keys.Back + ref this.KeyTimes) == 0L)
				{
					*(e.KeyCode * Keys.Back + ref this.KeyTimes) = <Module>.GTimer.GetTimeH(<Module>.Timer);
				}
				e.Handled = true;
				Keys keyCode = e.KeyCode;
				if (keyCode != Keys.W)
				{
					if (keyCode != Keys.F1)
					{
						if (keyCode == Keys.F5)
						{
							this.UpdateEffect(e.Control);
						}
					}
					else
					{
						byte b = (!this.CamLimited) ? 1 : 0;
						this.CamLimited = (b != 0);
						if (b != 0)
						{
							this.CamElevationMin = 0.6981317f;
							this.CamElevationMax = 1.134464f;
							float camElevation = this.CamElevation;
							float num;
							float camElevation2;
							if (camElevation < 1.134464f)
							{
								num = camElevation;
								if (camElevation <= 0.6981317f)
								{
									camElevation2 = 0.6981317f;
									goto IL_EB;
								}
							}
							else
							{
								num = 1.134464f;
							}
							camElevation2 = num;
							IL_EB:
							this.CamElevation = camElevation2;
							this.CamDistanceMin = <Module>.Measures * 44f;
							float num2 = <Module>.Measures * 80f;
							this.CamDistanceMax = num2;
							float camDistance = this.CamDistance;
							float camDistanceMin = this.CamDistanceMin;
							float num3;
							if (camDistance > camDistanceMin)
							{
								num3 = camDistance;
							}
							else
							{
								num3 = camDistanceMin;
							}
							float num4 = num2;
							float camDistance2;
							if (num3 < num4)
							{
								camDistance2 = num3;
							}
							else
							{
								camDistance2 = num4;
							}
							this.CamDistance = camDistance2;
						}
						else
						{
							this.CamElevationMin = -1.57079637f;
							this.CamElevationMax = 1.57079637f;
							this.CamDistanceMin = 0f;
							this.CamDistanceMax = 1000f;
						}
					}
				}
				else
				{
					GITerrain* terrain = this.Terrain;
					int num5 = *(int*)terrain;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), this.Terrain, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), terrain, *(num5 + 36)) ^ 34, *(num5 + 32));
				}
			}
		}

		private unsafe void panEffectViewport_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode >= Keys.None || e.KeyCode < (Keys)256)
			{
				if (*(e.KeyCode * Keys.Back + ref this.KeyTimes) != 0L)
				{
					*(e.KeyCode * Keys.Back + ref this.KeyTimes) = 0L;
				}
				e.Handled = true;
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
			this.Text = str2 + str + " - EffectEditor";
		}

		private void menuFileNew_Click(object sender, EventArgs e)
		{
			if (this.SaveDocumentIfChanged())
			{
				this.NewDocument();
			}
		}

		private unsafe void menuFileOpen_Click(object sender, EventArgs e)
		{
			this.tbEffectEditor.Focus();
			if (this.SaveDocumentIfChanged())
			{
				this.FileDialog.AvailableModes = 10;
				this.FileDialog.SelectedMode = 2;
				this.FileDialog.FileName = "";
				if (this.FileDialog.ShowDialog() == DialogResult.OK)
				{
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.FileDialog.FilePath);
					try
					{
						uint num = (uint)(*ptr);
						sbyte* filepathname;
						if (num != 0u)
						{
							filepathname = num;
						}
						else
						{
							filepathname = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						this.OpenDocument(filepathname);
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
					<Module>.SaveOptions();
				}
			}
		}

		private unsafe void menuFileOpenRecent_Click(object sender, EventArgs e)
		{
			this.tbEffectEditor.Focus();
			if (this.SaveDocumentIfChanged())
			{
				this.FileDialog.AvailableModes = 10;
				this.FileDialog.SelectedMode = 8;
				this.FileDialog.FileName = "";
				if (this.FileDialog.ShowDialog() == DialogResult.OK)
				{
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.FileDialog.FilePath);
					try
					{
						uint num = (uint)(*ptr);
						sbyte* filepathname;
						if (num != 0u)
						{
							filepathname = num;
						}
						else
						{
							filepathname = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						this.OpenDocument(filepathname);
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
					<Module>.SaveOptions();
				}
			}
		}

		private unsafe void menuFileSave_Click(object sender, EventArgs e)
		{
			this.tbEffectEditor.Focus();
			this.EffectPropTree.Focus();
			if (((*(int*)this.PEffect != 0) ? 1 : 0) != 0)
			{
				if (this.FileName.Length == 0)
				{
					this.menuFileSaveAs_Click(sender, e);
				}
				else
				{
					this.SaveDocument();
				}
			}
		}

		private unsafe void menuFileSaveAs_Click(object sender, EventArgs e)
		{
			this.tbEffectEditor.Focus();
			this.EffectPropTree.Focus();
			if (((*(int*)this.PEffect != 0) ? 1 : 0) != 0)
			{
				this.FileDialog.AvailableModes = 4;
				this.FileDialog.SelectedMode = 4;
				if (this.FileDialog.ShowDialog() == DialogResult.OK)
				{
					GBaseString<char> gBaseString<char>;
					<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.FileDialog.FilePath);
					try
					{
						sbyte* ptr;
						if (gBaseString<char> != null)
						{
							ptr = gBaseString<char>;
						}
						else
						{
							ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						if (calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, *this.PEffect, ptr, *(*(int*)<Module>.IEngine + 228)))
						{
							this.SavedIndex = this.UndoIndex;
							sbyte* value;
							if (gBaseString<char> != null)
							{
								value = gBaseString<char>;
							}
							else
							{
								value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							this.FileName = new string((sbyte*)value);
							this.Modified = false;
							this.UpdateWindowText();
							this.FileDialog.UpdateRecentFiles();
							<Module>.SaveOptions();
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
			}
		}

		private void menuFileClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void tbEffectEditor_ButtonClick(int idx, int radio_group)
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

		private unsafe void panEffectViewport_SizeChanged(object sender, EventArgs e)
		{
			if (this.IRenderTarget != null)
			{
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CH@OGONMAAB@c?3?2jtfcode?2src?2workshop?2EffectEd@), 1345, (sbyte*)(&<Module>.??_C@_0DI@LOKDIGJJ@NWorkshop?3?3NEffectEditor?3?3panEff@));
				Size clientSize = this.panEffectViewport.ClientSize;
				<Module>.GLogger.Log(0, (sbyte*)(&<Module>.??_C@_0CC@JPPJGCIM@Resize?5effect?5viewport?5to?5?$CFd?5x?5?$CF@), this.panEffectViewport.ClientSize.Width, clientSize.Height);
				Size clientSize2 = this.panEffectViewport.ClientSize;
				Size clientSize3 = this.panEffectViewport.ClientSize;
				int num = *(int*)this.IRenderTarget + 12;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), this.IRenderTarget, clientSize3.Width, clientSize2.Height, *num);
				if (this.panEffectViewport.ClientSize.Width != 0 && this.panEffectViewport.ClientSize.Height != 0)
				{
					base.Invalidate();
				}
			}
		}

		private void menuTrackEditor_Click(object sender, EventArgs e)
		{
		}

		private unsafe void menuEmitterReset_Click(object sender, EventArgs e)
		{
			GPoint3 gPoint = 0f;
			*(ref gPoint + 4) = 0f;
			*(ref gPoint + 8) = 0f;
			cpblk(this.EmitterPosition, ref gPoint, 12);
			GVector3 gVector = 0f;
			*(ref gVector + 4) = 1f;
			*(ref gVector + 8) = 0f;
			cpblk(this.EmitterDirection, ref gVector, 12);
			this.EmitterVelType = 0;
			this.EmitterDirType = 0;
			this.EmitterMovType = 2;
			this.menuEmitterVel0.Checked = true;
			this.menuEmitterVel1.Checked = false;
			this.menuEmitterVel2.Checked = false;
			this.menuEmitterVel3.Checked = false;
			this.menuEmitterDirHorizontal.Checked = false;
			this.menuEmitterDirVerticalP.Checked = true;
			this.menuEmitterDirVerticalM.Checked = false;
			this.menuEmitterDirRotate.Checked = false;
			this.menuEmitterMovHorizontal.Checked = true;
			this.menuEmitterMovVerticalP.Checked = false;
			this.menuEmitterMovVerticalM.Checked = false;
			this.menuEmitterMovRotate.Checked = false;
		}

		private void menuEmitterVel0_Click(object sender, EventArgs e)
		{
			this.EmitterVelType = 0;
			this.menuEmitterVel0.Checked = true;
			this.menuEmitterVel1.Checked = false;
			this.menuEmitterVel2.Checked = false;
			this.menuEmitterVel3.Checked = false;
		}

		private void menuEmitterVel1_Click(object sender, EventArgs e)
		{
			this.EmitterVelType = 5;
			this.menuEmitterVel0.Checked = false;
			this.menuEmitterVel1.Checked = true;
			this.menuEmitterVel2.Checked = false;
			this.menuEmitterVel3.Checked = false;
		}

		private void menuEmitterVel2_Click(object sender, EventArgs e)
		{
			this.EmitterVelType = 10;
			this.menuEmitterVel0.Checked = false;
			this.menuEmitterVel1.Checked = false;
			this.menuEmitterVel2.Checked = true;
			this.menuEmitterVel3.Checked = false;
		}

		private void menuEmitterVel3_Click(object sender, EventArgs e)
		{
			this.EmitterVelType = 30;
			this.menuEmitterVel0.Checked = false;
			this.menuEmitterVel1.Checked = false;
			this.menuEmitterVel2.Checked = false;
			this.menuEmitterVel3.Checked = true;
		}

		private void menuEmitterDirVerticalP_Click(object sender, EventArgs e)
		{
			this.EmitterDirType = 0;
			this.menuEmitterDirHorizontal.Checked = false;
			this.menuEmitterDirVerticalP.Checked = true;
			this.menuEmitterDirVerticalM.Checked = false;
			this.menuEmitterDirRotate.Checked = false;
		}

		private void menuEmitterDirVerticalM_Click(object sender, EventArgs e)
		{
			this.EmitterDirType = 1;
			this.menuEmitterDirHorizontal.Checked = false;
			this.menuEmitterDirVerticalP.Checked = false;
			this.menuEmitterDirVerticalM.Checked = true;
			this.menuEmitterDirRotate.Checked = false;
		}

		private void menuEmitterDirHorizontal_Click(object sender, EventArgs e)
		{
			this.EmitterDirType = 2;
			this.menuEmitterDirHorizontal.Checked = true;
			this.menuEmitterDirVerticalP.Checked = false;
			this.menuEmitterDirVerticalM.Checked = false;
			this.menuEmitterDirRotate.Checked = false;
		}

		private void menuEmitterDirRotate_Click(object sender, EventArgs e)
		{
			this.EmitterDirType = 3;
			this.menuEmitterDirHorizontal.Checked = false;
			this.menuEmitterDirVerticalP.Checked = false;
			this.menuEmitterDirVerticalM.Checked = false;
			this.menuEmitterDirRotate.Checked = true;
		}

		private void menuEmitterMovHorizontal_Click(object sender, EventArgs e)
		{
			this.EmitterMovType = 2;
			this.menuEmitterMovHorizontal.Checked = true;
			this.menuEmitterMovVerticalP.Checked = false;
			this.menuEmitterMovVerticalM.Checked = false;
			this.menuEmitterMovRotate.Checked = false;
		}

		private void menuEmitterMovVerticalP_Click(object sender, EventArgs e)
		{
			this.EmitterMovType = 0;
			this.menuEmitterMovHorizontal.Checked = false;
			this.menuEmitterMovVerticalP.Checked = true;
			this.menuEmitterMovVerticalM.Checked = false;
			this.menuEmitterMovRotate.Checked = false;
		}

		private void menuEmitterMovVerticalM_Click(object sender, EventArgs e)
		{
			this.EmitterMovType = 1;
			this.menuEmitterMovHorizontal.Checked = false;
			this.menuEmitterMovVerticalP.Checked = false;
			this.menuEmitterMovVerticalM.Checked = true;
			this.menuEmitterMovRotate.Checked = false;
		}

		private void menuEmitterMovRotate_Click(object sender, EventArgs e)
		{
			this.EmitterMovType = 3;
			this.menuEmitterMovHorizontal.Checked = false;
			this.menuEmitterMovVerticalP.Checked = false;
			this.menuEmitterMovVerticalM.Checked = false;
			this.menuEmitterMovRotate.Checked = true;
		}

		private void menuViewShowEffectPosDir_Click(object sender, EventArgs e)
		{
			int num = (this.ShowEffectPosDir == 0) ? 1 : 0;
			this.ShowEffectPosDir = num;
			byte @checked = (num != 0) ? 1 : 0;
			this.menuViewShowEffectPosDir.Checked = (@checked != 0);
		}

		private unsafe void menuViewDebugMode_Click(object sender, EventArgs e)
		{
			GIScene* expr_06 = this.IScene;
			int num = (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_06, *(*(int*)expr_06 + 332)) == 0) ? 1 : 0;
			GIScene* iScene = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), iScene, num, *(*(int*)iScene + 336));
			byte @checked = (num != 0) ? 1 : 0;
			this.menuViewDebugMode.Checked = (@checked != 0);
		}

		private unsafe void menuEditUndo_Click(object sender, EventArgs e)
		{
			int undoIndex = this.UndoIndex;
			if (undoIndex > 0)
			{
				int num = undoIndex - 1;
				this.UndoIndex = num;
				<Module>.GStream.Reset(num * 36 + *(int*)this.UndoArray);
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Void*,GStream*), <Module>.IEngine, this.PEffectData, this.UndoIndex * 36 + *(int*)this.UndoArray, *(*(int*)<Module>.IEngine + 232));
				GMeasures gMeasures;
				this.EffectPropTree.SetVariableNoReset(this.PEffectClass, this.PEffectData, <Module>.GMeasures.{ctor}(ref gMeasures, <Module>.Measures, 1f));
				this.UpdateEffect(true);
				if (this.UndoIndex == this.SavedIndex)
				{
					this.Modified = false;
					this.UpdateWindowText();
					this.tbEffectEditor.SetItemEnable(202, false);
					this.menuFileSave.Enabled = false;
				}
				else
				{
					this.Modified = true;
					this.tbEffectEditor.SetItemEnable(202, true);
					this.menuFileSave.Enabled = true;
				}
				this.UpdateWindowText();
				this.menuEditRedo.Enabled = true;
				this.tbEffectEditor.SetItemEnable(208, true);
				if (this.UndoIndex == 0)
				{
					this.tbEffectEditor.SetItemEnable(207, false);
					this.menuEditUndo.Enabled = false;
				}
				NCurveEditor currentCurveEditor = this.CurrentCurveEditor;
				if (currentCurveEditor != null)
				{
					currentCurveEditor.Update();
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
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Void*,GStream*), <Module>.IEngine, this.PEffectData, this.UndoIndex * 36 + *(int*)this.UndoArray, *(*(int*)<Module>.IEngine + 232));
				GMeasures gMeasures;
				this.EffectPropTree.SetVariableNoReset(this.PEffectClass, this.PEffectData, <Module>.GMeasures.{ctor}(ref gMeasures, <Module>.Measures, 1f));
				this.UpdateEffect(true);
				if (this.UndoIndex == this.SavedIndex)
				{
					this.Modified = false;
					this.UpdateWindowText();
					this.tbEffectEditor.SetItemEnable(202, false);
					this.menuFileSave.Enabled = false;
				}
				else
				{
					this.Modified = true;
					this.tbEffectEditor.SetItemEnable(202, true);
					this.menuFileSave.Enabled = true;
				}
				this.UpdateWindowText();
				this.menuEditUndo.Enabled = true;
				this.tbEffectEditor.SetItemEnable(207, true);
				if (this.UndoIndex == *(int*)(this.UndoArray + 4 / sizeof(GArray<GStreamBuffer>)) - 1)
				{
					this.tbEffectEditor.SetItemEnable(208, false);
					this.menuEditRedo.Enabled = false;
				}
				NCurveEditor currentCurveEditor = this.CurrentCurveEditor;
				if (currentCurveEditor != null)
				{
					currentCurveEditor.Update();
				}
			}
		}

		private void StartTrackEditor(NCurveEditor curveeditor)
		{
			NCurveEditor currentCurveEditor = this.CurrentCurveEditor;
			if (currentCurveEditor != null)
			{
				this.TrackPanel.Controls.Remove(currentCurveEditor);
				this.CurrentCurveEditor.DisposeD3DX();
			}
			this.CurrentCurveEditor = curveeditor;
			if (curveeditor != null)
			{
				curveeditor.Dock = DockStyle.Fill;
				this.TrackPanel.Controls.Add(this.CurrentCurveEditor);
				this.CurrentCurveEditor.NotifyUndoStep += new NCurveEditor.CurveChangedHandler(this.EffectPropTree_ItemChanged);
			}
		}

		private unsafe void menuWindOff_Click(object sender, EventArgs e)
		{
			GVector2 gVector = 1f;
			*(ref gVector + 4) = 0f;
			GIScene* iScene = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector2 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene, ref gVector, 0f, 0.5f, *(*(int*)iScene + 80));
			this.menuWindOff.Checked = true;
			this.menuWindLight.Checked = false;
			this.menuWindMedium.Checked = false;
			this.menuWindHeavy.Checked = false;
		}

		private unsafe void menuWindLight_Click(object sender, EventArgs e)
		{
			GVector2 gVector = 1f;
			*(ref gVector + 4) = 0f;
			GIScene* iScene = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector2 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene, ref gVector, 20f, 0.5f, *(*(int*)iScene + 80));
			this.menuWindOff.Checked = false;
			this.menuWindLight.Checked = true;
			this.menuWindMedium.Checked = false;
			this.menuWindHeavy.Checked = false;
		}

		private unsafe void menuWindMedium_Click(object sender, EventArgs e)
		{
			GVector2 gVector = 1f;
			*(ref gVector + 4) = 0f;
			GIScene* iScene = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector2 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene, ref gVector, 40f, 0.5f, *(*(int*)iScene + 80));
			this.menuWindOff.Checked = false;
			this.menuWindLight.Checked = false;
			this.menuWindMedium.Checked = true;
			this.menuWindHeavy.Checked = false;
		}

		private unsafe void menuWindHeavy_Click(object sender, EventArgs e)
		{
			GVector2 gVector = 1f;
			*(ref gVector + 4) = 0f;
			GIScene* iScene = this.IScene;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector2 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene, ref gVector, 60f, 0.5f, *(*(int*)iScene + 80));
			this.menuWindOff.Checked = false;
			this.menuWindLight.Checked = false;
			this.menuWindMedium.Checked = false;
			this.menuWindHeavy.Checked = true;
		}

		protected unsafe void raise_PEffectChanged(sbyte* i1)
		{
			NEffectEditor.__Delegate_PEffectChanged pEffectChanged = this.PEffectChanged;
			if (pEffectChanged != null)
			{
				pEffectChanged(i1);
			}
		}
	}
}
