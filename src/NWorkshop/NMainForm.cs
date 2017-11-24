using <CppImplementationDetails>;
using NControls;
using ScriptEditorWindow;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	[UnsafeValueType]
	public class NMainForm : Form
	{
		public static NMainForm MainWorkshopForm = null;

		private ScriptEditorForm ScriptEditorFormInstance;

		private MenuItem menuFile;

		private MenuItem menuFileExit;

		private StatusBar sbMain;

		private AllKeyHandlingSolidPanel panMainViewport;

		private MenuItem menuFileNew;

		private MenuItem menuFileOpen;

		private MenuItem menuFileSave;

		private MenuItem menuFileSaveAs;

		private MenuItem menuFileSeparator1;

		private MenuItem menuFileSeparator2;

		private MenuItem menuFileOpenRecent;

		private MenuItem menuEdit;

		private MenuItem menuEditUndo;

		private MenuItem menuEditRedo;

		private MenuItem menuEditSeparator1;

		private MenuItem menuEditCut;

		private MenuItem menuEditCopy;

		private MenuItem menuEditPaste;

		private MenuItem menuEditDelete;

		private MenuItem menuEditSeparator2;

		private MenuItem menuEditSelectAll;

		private MenuItem menuEditSelectNone;

		private MenuItem menuView;

		private MenuItem menuSound;

		private MenuItem menuSoundDisable;

		private MenuItem menuSoundStereo;

		private MenuItem menuSoundQuad;

		private MenuItem menuSoundSurround;

		private MenuItem menuSoundReverseStereo;

		private MenuItem menuTools;

		private MenuItem menuToolsOptions;

		private MenuItem menuToolsSeparator1;

		private MenuItem menuToolsScriptEditor;

		private MenuItem menuViewSidebar;

		private MenuItem menuViewSidebarLeft;

		private MenuItem menuViewSidebarRight;

		private MenuItem menuViewStatusBar;

		private MenuItem menuViewToolbar;

		private MenuItem menuViewSidebarOff;

		private Splitter splitMain;

		private MenuItem menuMode;

		private MenuItem menuModeVertex;

		private MenuItem menuModeRoad;

		private MenuItem menuModeDecal;

		private MenuItem menuItem5;

		private MenuItem menuModeLake;

		private MenuItem menuModeRiver;

		private MenuItem menuModeCameraCurve;

		private MenuItem menuItem8;

		private MenuItem menuModeDoodad;

		private MenuItem menuModeWire;

		private MenuItem menuModeUnit;

		private MenuItem menuModeAmbient;

		private MenuItem menuModeEffect;

		private MainMenu menuMain;

		private MenuItem menuModePaint;

		private ContextMenu MainViewPopupMenu;

		private MenuItem menuEditControlPaste;

		private MenuItem menuItem3;

		private MenuItem menuModePaths;

		private MenuItem menuModeLocations;

		private MenuItem menuModeUnitGroup;

		private MenuItem menuModeBuilding;

		private MenuItem menuModeSectors;

		private MenuItem menuFileImportCam;

		private MenuItem menuFileExport;

		private MenuItem menuItem1;

		private MenuItem menuFileRemoveImportCam;

		private MenuItem menuToolsMissionVariables;

		private IContainer components;

		private Toolbar tbMain;

		private Toolbar tbDebug;

		private NControls.ScrollableControl panSideBar;

		private unsafe GIRenderTarget* IRenderTarget;

		private unsafe GIViewport* IViewport;

		private $ArrayType$$$BY0BAA@_J KeyTimes;

		private long LastUpdate;

		private long LastCamViewPortUpdate;

		private int DragMode;

		private int KeyDragMode;

		private bool DragStarted;

		private bool DragPreventMenu;

		private int DragMX;

		private int DragMY;

		private int DragLastX;

		private int DragLastY;

		private float DragX;

		private float DragY;

		private float DragZ;

		private float DragTX;

		private float DragTZ;

		private int DragTarget;

		private unsafe GNativeData* ND;

		private unsafe GEditorWorld* World;

		private unsafe GWorldClipboard* Clipboard;

		private unsafe GEntityClipboard* EntityClipboard;

		private unsafe NPropertyClipboard* EffectEditorClipboard;

		private unsafe NPropertyClipboard* UnitEditorClipboard;

		private bool GameDebugMode;

		private bool GameDebugWithShotsMode;

		private unsafe GEditorWorld* GameDebugBackupWorld;

		private unsafe GIScene* GameDebugBackupScene;

		private unsafe GWorld* GameDebugWorld;

		private int EditorMode;

		private int DebugMode;

		private int propBrushType;

		private int propPaintType;

		private int VertexFalloffType;

		private int SelectionFalloffType;

		private bool SelectionAdditiveMode;

		private bool SelectionActive;

		private bool SelectionPossible;

		private int EntityType;

		private $ArrayType$$$BY0BE@W4GEntityOperation@@ EntityOperation;

		private $ArrayType$$$BY0BE@_N EntityAlignRotate;

		private $ArrayType$$$BY0BE@_N EntityAlignMove;

		private $ArrayType$$$BY0BE@_N EntityLockSelection;

		private $ArrayType$$$BY0BE@_N EntityLockHeights;

		private $ArrayType$$$BY0BE@_N EntityRandomAngle;

		private $ArrayType$$$BY0BE@PAV?$GBaseString@D@@ EntityName;

		private int PreCreatedEntity;

		private float UpDownBrushDiam;

		private float UpDownBrushDiam2;

		private float UpDownBrushPressure;

		private float HeightSetValue;

		private float HeightSetBrushDiam;

		private float HeightSetBrushDiam2;

		private float HeightSetBrushPressure;

		private float SmoothBrushDiam;

		private float SmoothBrushDiam2;

		private float SmoothBrushPressure;

		private float PaintBrushDiam;

		private float PaintBrushPressure;

		private float SelectionDiam;

		private float SelectionDiam2;

		private float SelectionPressure;

		private float ForestStrokeSize;

		private float ForestStrokePressure;

		private unsafe GTerraformer* Terraformer;

		private unsafe GBaseString<char>* MapFileName;

		private unsafe GBaseString<char>* ExportMapFileName;

		private unsafe GBaseString<char>* ImportCamFileName;

		private ArrayList ToolWindows;

		private int TileParcelX;

		private int TileParcelZ;

		private bool TileDataValid;

		private ToolboxVertex VertexTools;

		private ToolboxContainer VertexToolContainer;

		private FilePickerControl ObjectFilePicker;

		private ToolboxEntities ObjectTools;

		private ToolboxContainer ObjectFileContainer;

		private ToolboxContainer ObjectToolContainer;

		private FilePickerControl RoadFilePicker;

		private ToolboxEntities RoadTools;

		private ToolboxContainer RoadFileContainer;

		private ToolboxContainer RoadToolContainer;

		private ToolboxEntities NavPointTools;

		private ToolboxContainer NavPointToolContainer;

		private FilePickerControl DecalFilePicker;

		private ToolboxEntities DecalTools;

		private ToolboxContainer DecalFileContainer;

		private ToolboxContainer DecalToolContainer;

		private FilePickerControl LakeFilePicker;

		private ToolboxEntities LakeTools;

		private ToolboxContainer LakeToolContainer;

		private ToolboxContainer LakeFileContainer;

		private FilePickerControl RiverFilePicker;

		private ToolboxEntities RiverTools;

		private ToolboxContainer RiverToolContainer;

		private ToolboxContainer RiverFileContainer;

		private ToolboxEntities CameraCurveTools;

		private ToolboxContainer CameraCurveToolContainer;

		private ToolboxContainer CameraCurvePropsContainer;

		private ToolboxScriptEntities CameraCurveProps;

		private FilePickerControl BuildingFilePicker;

		private ToolboxEntities BuildingTools;

		private ToolboxBuildingProperties BuildingPropertiesTools;

		private ToolboxContainer BuildingFileContainer;

		private ToolboxContainer BuildingToolContainer;

		private ToolboxContainer BuildingPropertiesContainer;

		private FilePickerControl UnitFilePicker;

		private ToolboxEntities UnitTools;

		private ToolboxPlayer PlayerTools;

		private ToolboxUnitProperties UnitPropertiesTools;

		private ToolboxContainer UnitFileContainer;

		private ToolboxContainer UnitToolContainer;

		private ToolboxContainer PlayerContainer;

		private ToolboxContainer UnitPropertiesContainer;

		private FilePickerControl SoundFilePicker;

		private ToolboxEntities SoundTools;

		private ToolboxContainer SoundFileContainer;

		private ToolboxContainer SoundToolContainer;

		private FilePickerControl EffectFilePicker;

		private ToolboxEntities EffectTools;

		private ToolboxContainer EffectFileContainer;

		private ToolboxContainer EffectToolContainer;

		private FilePickerControl LocaleFilePicker;

		private ToolboxTerrain TerrainFilePicker;

		private ToolboxTerrainTools TerrainTools;

		private ToolboxContainer TerrainFileContainer;

		private ToolboxContainer TerrainToolContainer;

		private ToolboxSectors SectorTools;

		private ToolboxContainer SectorToolContainer;

		private ToolboxScriptEntities CurrentScriptEnittyToolbar;

		private ToolboxEntities PathTools;

		private ToolboxScriptEntities PathProps;

		private ToolboxContainer PathToolContainer;

		private ToolboxContainer PathPropsContainer;

		private ToolboxEntities LocationTools;

		private ToolboxScriptEntities LocationProps;

		private ToolboxContainer LocationToolContainer;

		private ToolboxContainer LocationPropsContainer;

		private ToolboxEntities UnitGroupTools;

		private ToolboxScriptEntities UnitGroupProps;

		private ToolboxContainer UnitGroupToolContainer;

		private ToolboxContainer UnitGroupPropsContainer;

		private ToolboxEntities ObjectiveTools;

		private ToolboxScriptEntities ObjectiveProps;

		private ToolboxContainer ObjectiveToolContainer;

		private ToolboxContainer ObjectivePropsContainer;

		private ToolboxWeather WeatherTools;

		private ToolboxContainer WeatherToolContainer;

		private ToolboxOptions OptionsTools;

		private ToolboxContainer OptionToolContainer;

		private Minimap MinimapPanel;

		private ToolboxContainer VertexMinimap;

		private ToolboxContainer ObjectsMinimap;

		private ToolboxContainer RoadsMinimap;

		private ToolboxContainer NavPointsMinimap;

		private ToolboxContainer DecalsMinimap;

		private ToolboxContainer LakeMinimap;

		private ToolboxContainer RiverMinimap;

		private ToolboxContainer CameraCurveMinimap;

		private ToolboxContainer UnitMinimap;

		private ToolboxContainer SoundMinimap;

		private ToolboxContainer EffectMinimap;

		private ToolboxContainer TerrainMinimap;

		private ToolboxContainer PathMinimap;

		private ToolboxContainer LocationMinimap;

		private ToolboxContainer UnitGroupMinimap;

		private ToolboxContainer BuildingMinimap;

		private ToolboxContainer LoggerContainer;

		private NDebuggerLog LoggerTool;

		private ToolboxContainer DUnitsContainer;

		private NDebuggerUnits DUnitsTool;

		private ToolboxContainer DUnitGroupsContainer;

		private NDebuggerUnitGroups DUnitGroupsTool;

		private ToolboxContainer DTriggersContainer;

		private NDebuggerTriggers DTriggersTool;

		private ToolboxContainer DGVarsContainer;

		private NDebuggerGVars DGVarsTool;

		private NDebuggerControlPanel DControlPanel;

		private ToolboxContainer LogControlPanel;

		private ToolboxContainer UnitsControlPanel;

		private ToolboxContainer UnitGroupsControlPanel;

		private ToolboxContainer TriggersControlPanel;

		private ToolboxContainer CurrentControlPanel;

		private bool ScrollbarOn;

		private bool Rearranging;

		private int OldHeight;

		private bool LayoutChanged;

		private bool VariableSizeToolChanged;

		private string OpenFileName;

		private bool TemporaryModeChange;

		private uint LastPasteOptions;

		private bool BrushNeedsUpdate;

		private float BrushX;

		private float BrushZ;

		private bool MinimapViewportNeedsUpdate;

		private bool MinimapUnitsNeedUpdate;

		private ToolboxEntities CurrentEntityToolbar;

		private ToolboxContainer CurrentMinimap;

		private int LastCameraType;

		private unsafe GCamera* LastCamera;

		private bool SectorSelectionNeedsUpdate;

		private unsafe GHandle<11>* BrushCursor;

		private unsafe GHandle<11>* ParcelSelection;

		private unsafe GArray<GIModel *>* PhysicsModels;

		private float MouseTargetX;

		private float MouseTargetY;

		private float MouseTargetZ;

		private int SelectedMapNote;

		private int MapNoteX;

		private int MapNoteY;

		private bool GroupListRefreshNeeded;

		private long LastClickTime;

		private long LastClickTimeRightButton;

		private int LastClickUnit;

		private int TurnUnitIdx;

		private int CommandMode;

		private int AcceptedCommand;

		private int LastEditorMode;

		private unsafe GOrder* CurrentOrder;

		private $ArrayType$$$BY0DA@_N AvailableCommands;

		private float DebugMapTempFOV;

		private float DebugMapTempNearPlane;

		private float DebugMapTempFarPlane;

		private int DebugMapTemp_RefractBufferWidth;

		private int DebugMapTemp_RefractBufferHeight;

		private int DebugMapTemp_ReflectBufferWidth;

		private int DebugMapTemp_ReflectBufferHeight;

		private int DebugMapTemp_DistanceBufferWidth;

		private int DebugMapTemp_DistanceBufferHeight;

		private int DebugMapTemp_ShadowBufferSize;

		private int DebugMapTemp_SoundDevice;

		private bool WindowClosing;

		public ThumbProgress ProgressDialog;

		private int PaintType
		{
			set
			{
				this.propPaintType = value;
				this.TerrainTools.PaintType = value;
				if (this.propPaintType != 14)
				{
					this.TileDataValid = false;
					this.TerrainFilePicker.UpdateLayerUsage(0);
				}
			}
		}

		private unsafe int BrushType
		{
			set
			{
				this.propBrushType = value;
				this.VertexTools.BrushType = value;
				this.VertexTools.SelectionType = value;
				this.VertexTools.FalloffType = this.VertexFalloffType;
				this.VertexTools.AdditiveMode = (*(byte*)(this.Terraformer + 8 / sizeof(GTerraformer)) != 0);
				this.VertexTools.LockObjectHeights = (*(byte*)(this.Terraformer + 9 / sizeof(GTerraformer)) != 0);
			}
		}

		private unsafe GColor* BrushColor
		{
			get
			{
				return (GColor*)(this.Terraformer + 16 / sizeof(GTerraformer));
			}
			set
			{
				cpblk(this.Terraformer + 16 / sizeof(GTerraformer), value, 16);
			}
		}

		private unsafe float* BrushPressure
		{
			get
			{
				int editorMode = this.EditorMode;
				if (editorMode == 1)
				{
					int num = this.propBrushType;
					if (num == 24)
					{
						return ref this.SelectionPressure;
					}
					if (num < 20)
					{
						switch (num)
						{
						case 2:
						case 3:
							return ref this.UpDownBrushPressure;
						case 4:
						case 5:
						case 6:
							return ref this.HeightSetBrushPressure;
						case 7:
						case 8:
							return ref this.SmoothBrushPressure;
						}
					}
				}
				else if (editorMode == 2)
				{
					switch (this.propPaintType)
					{
					case 9:
					case 10:
					case 11:
					case 15:
					case 16:
						return ref this.PaintBrushPressure;
					}
				}
				return 0;
			}
			set
			{
				float* brushPressure = this.BrushPressure;
				float num = value;
				if (brushPressure != null)
				{
					if (num < 5f)
					{
						num = 5f;
					}
					else if (num > 100f)
					{
						num = 100f;
					}
					*brushPressure = num;
				}
			}
		}

		private unsafe float* BrushSize2
		{
			get
			{
				if (this.EditorMode == 1)
				{
					int num = this.propBrushType;
					if (num == 24 && this.SelectionFalloffType == 101)
					{
						return ref this.SelectionDiam2;
					}
					if (num < 20 && this.VertexFalloffType == 101)
					{
						switch (num)
						{
						case 2:
						case 3:
							return ref this.UpDownBrushDiam2;
						case 4:
						case 5:
						case 6:
							return ref this.HeightSetBrushDiam2;
						case 7:
						case 8:
							return ref this.SmoothBrushDiam2;
						}
					}
				}
				return 0;
			}
			set
			{
				float* brushSize = this.BrushSize2;
				float num = value;
				if (brushSize != null)
				{
					if (num < 0f)
					{
						num = 0f;
					}
					else if (num > 100f)
					{
						num = 100f;
					}
					*brushSize = num;
				}
			}
		}

		private unsafe float* BrushSize
		{
			get
			{
				int editorMode = this.EditorMode;
				if (editorMode == 1)
				{
					int num = this.propBrushType;
					if (num == 24)
					{
						return ref this.SelectionDiam;
					}
					if (num < 20)
					{
						switch (num)
						{
						case 2:
						case 3:
							return ref this.UpDownBrushDiam;
						case 4:
						case 5:
						case 6:
							return ref this.HeightSetBrushDiam;
						case 7:
						case 8:
							return ref this.SmoothBrushDiam;
						}
					}
				}
				else if (editorMode == 2)
				{
					switch (this.propPaintType)
					{
					case 9:
					case 10:
					case 11:
					case 15:
					case 16:
						return ref this.PaintBrushDiam;
					}
				}
				return 0;
			}
			set
			{
				float* brushSize = this.BrushSize;
				float num = value;
				if (brushSize != null)
				{
					if (num < 0.5f)
					{
						num = 0.5f;
					}
					else if (num > 30f)
					{
						num = 30f;
					}
					*brushSize = <Module>.fround(num * 50f) * 0.02f;
				}
			}
		}

		private unsafe float* BrushHeight
		{
			get
			{
				if (this.EditorMode == 1)
				{
					int num = this.propBrushType;
					if (num < 20 && num - 4 <= 2)
					{
						return ref this.HeightSetValue;
					}
				}
				return 0;
			}
			set
			{
				float* brushHeight = this.BrushHeight;
				float num = value;
				if (brushHeight != null)
				{
					if (num < -30f)
					{
						num = -30f;
					}
					else if (num > 50f)
					{
						num = 50f;
					}
					*brushHeight = num;
				}
			}
		}

		public unsafe NMainForm()
		{
			this.Rearranging = true;
			this.LayoutChanged = true;
			this.VariableSizeToolChanged = false;
			this.WindowClosing = false;
			this.InitializeComponent();
			AllKeyHandlingSolidPanel allKeyHandlingSolidPanel = new AllKeyHandlingSolidPanel();
			this.panMainViewport = allKeyHandlingSolidPanel;
			allKeyHandlingSolidPanel.BorderStyle = BorderStyle.Fixed3D;
			this.panMainViewport.Dock = DockStyle.Fill;
			Point location = new Point(3, 0);
			this.panMainViewport.Location = location;
			this.panMainViewport.Name = "panMainViewport";
			Size size = new Size(789, 551);
			this.panMainViewport.Size = size;
			this.panMainViewport.TabIndex = 4;
			this.panMainViewport.TabStop = true;
			this.panMainViewport.SizeChanged += new EventHandler(this.panMainViewport_SizeChanged);
			this.panMainViewport.MouseUp += new MouseEventHandler(this.panMainViewport_MouseUp);
			this.panMainViewport.Paint += new PaintEventHandler(this.panMainViewport_Paint);
			this.panMainViewport.MouseMove += new MouseEventHandler(this.panMainViewport_MouseMove);
			this.panMainViewport.MouseDown += new MouseEventHandler(this.panMainViewport_MouseDown);
			this.panMainViewport.DoubleClick += new EventHandler(this.panMainViewport_DoubleClick);
			base.Controls.Add(this.panMainViewport);
			this.InitializeVariables();
			NControls.ScrollableControl scrollableControl = new NControls.ScrollableControl(256, 551, 551, 2);
			this.panSideBar = scrollableControl;
			scrollableControl.HideScrollBar();
			this.panSideBar.Dock = DockStyle.Left;
			Point location2 = new Point(0, 0);
			this.panSideBar.Location = location2;
			this.panSideBar.Name = "panSideBar";
			this.panSideBar.TabIndex = 2;
			this.panSideBar.Resize += new EventHandler(this.panSideBar_Resize);
			base.Controls.Remove(this.sbMain);
			base.Controls.Add(this.panSideBar);
			base.Controls.Add(this.sbMain);
			this.tbMain = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0NMainForm@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), 24);
			Size size2 = new Size(300, 300);
			this.tbMain.Size = size2;
			this.tbMain.Dock = DockStyle.Top;
			this.tbMain.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tbMain_ButtonClick);
			base.Controls.Add(this.tbMain);
			this.tbDebug = new Toolbar((GToolbarItem*)(&<Module>.?debugitems@?1???0NMainForm@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), 24);
			Size size3 = new Size(300, 300);
			this.tbDebug.Size = size3;
			this.tbDebug.Dock = DockStyle.Top;
			this.tbDebug.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tbDebug_ButtonClick);
			GHandle<11>* ptr = <Module>.@new(4u);
			GHandle<11>* brushCursor;
			try
			{
				if (ptr != null)
				{
					*(int*)ptr = 0;
					brushCursor = ptr;
				}
				else
				{
					brushCursor = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr);
				throw;
			}
			this.BrushCursor = brushCursor;
			GHandle<11>* ptr2 = <Module>.@new(4u);
			GHandle<11>* parcelSelection;
			try
			{
				if (ptr2 != null)
				{
					*(int*)ptr2 = 0;
					parcelSelection = ptr2;
				}
				else
				{
					parcelSelection = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr2);
				throw;
			}
			this.ParcelSelection = parcelSelection;
			this.ScriptEditorFormInstance = null;
		}

		public void ShellOpenFile(string filename)
		{
			this.OpenFileName = filename;
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
			ResourceManager resourceManager = new ResourceManager(typeof(NMainForm));
			this.menuMain = new MainMenu();
			this.menuFile = new MenuItem();
			this.menuFileNew = new MenuItem();
			this.menuFileOpen = new MenuItem();
			this.menuFileOpenRecent = new MenuItem();
			this.menuFileSeparator1 = new MenuItem();
			this.menuFileSave = new MenuItem();
			this.menuFileSaveAs = new MenuItem();
			this.menuItem1 = new MenuItem();
			this.menuFileExport = new MenuItem();
			this.menuFileImportCam = new MenuItem();
			this.menuFileRemoveImportCam = new MenuItem();
			this.menuFileSeparator2 = new MenuItem();
			this.menuFileExit = new MenuItem();
			this.menuEdit = new MenuItem();
			this.menuEditUndo = new MenuItem();
			this.menuEditRedo = new MenuItem();
			this.menuEditSeparator1 = new MenuItem();
			this.menuEditCut = new MenuItem();
			this.menuEditCopy = new MenuItem();
			this.menuEditPaste = new MenuItem();
			this.menuEditControlPaste = new MenuItem();
			this.menuEditDelete = new MenuItem();
			this.menuEditSeparator2 = new MenuItem();
			this.menuEditSelectAll = new MenuItem();
			this.menuEditSelectNone = new MenuItem();
			this.menuView = new MenuItem();
			this.menuViewToolbar = new MenuItem();
			this.menuViewSidebar = new MenuItem();
			this.menuViewSidebarLeft = new MenuItem();
			this.menuViewSidebarRight = new MenuItem();
			this.menuViewSidebarOff = new MenuItem();
			this.menuViewStatusBar = new MenuItem();
			this.menuSound = new MenuItem();
			this.menuSoundDisable = new MenuItem();
			this.menuSoundStereo = new MenuItem();
			this.menuSoundQuad = new MenuItem();
			this.menuSoundSurround = new MenuItem();
			this.menuSoundReverseStereo = new MenuItem();
			this.menuMode = new MenuItem();
			this.menuModeVertex = new MenuItem();
			this.menuModePaint = new MenuItem();
			this.menuModeRoad = new MenuItem();
			this.menuModeDecal = new MenuItem();
			this.menuModeSectors = new MenuItem();
			this.menuItem5 = new MenuItem();
			this.menuModeLake = new MenuItem();
			this.menuModeRiver = new MenuItem();
			this.menuItem8 = new MenuItem();
			this.menuModeDoodad = new MenuItem();
			this.menuModeWire = new MenuItem();
			this.menuModeBuilding = new MenuItem();
			this.menuModeUnit = new MenuItem();
			this.menuModeAmbient = new MenuItem();
			this.menuModeEffect = new MenuItem();
			this.menuItem3 = new MenuItem();
			this.menuModeCameraCurve = new MenuItem();
			this.menuModePaths = new MenuItem();
			this.menuModeLocations = new MenuItem();
			this.menuModeUnitGroup = new MenuItem();
			this.menuTools = new MenuItem();
			this.menuToolsScriptEditor = new MenuItem();
			this.menuToolsSeparator1 = new MenuItem();
			this.menuToolsOptions = new MenuItem();
			this.sbMain = new StatusBar();
			this.splitMain = new Splitter();
			this.MainViewPopupMenu = new ContextMenu();
			this.menuToolsMissionVariables = new MenuItem();
			base.SuspendLayout();
			MenuItem[] items = new MenuItem[]
			{
				this.menuFile,
				this.menuEdit,
				this.menuView,
				this.menuMode,
				this.menuTools,
				this.menuSound
			};
			this.menuMain.MenuItems.AddRange(items);
			this.menuFile.Index = 0;
			MenuItem[] items2 = new MenuItem[]
			{
				this.menuFileNew,
				this.menuFileOpen,
				this.menuFileOpenRecent,
				this.menuFileSeparator1,
				this.menuFileSave,
				this.menuFileSaveAs,
				this.menuItem1,
				this.menuFileExport,
				this.menuFileImportCam,
				this.menuFileRemoveImportCam,
				this.menuFileSeparator2,
				this.menuFileExit
			};
			this.menuFile.MenuItems.AddRange(items2);
			this.menuFile.Text = "&File";
			this.menuFileNew.Index = 0;
			this.menuFileNew.Shortcut = Shortcut.CtrlN;
			this.menuFileNew.Text = "&New...";
			this.menuFileNew.Click += new EventHandler(this.menuFileNew_Click);
			this.menuFileOpen.Index = 1;
			this.menuFileOpen.Shortcut = Shortcut.CtrlO;
			this.menuFileOpen.Text = "&Open...";
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
			this.menuItem1.Index = 6;
			this.menuItem1.Text = "-";
			this.menuFileExport.Index = 7;
			this.menuFileExport.Text = "&Export map...";
			this.menuFileExport.Click += new EventHandler(this.menuFileExport_Click);
			this.menuFileImportCam.Index = 8;
			this.menuFileImportCam.Text = "&Import camera...";
			this.menuFileImportCam.Click += new EventHandler(this.menuFileImportCam_Click);
			this.menuFileRemoveImportCam.Index = 9;
			this.menuFileRemoveImportCam.Text = "&Remove ImportCamera";
			this.menuFileRemoveImportCam.Click += new EventHandler(this.menuFileRemoveImportCam_Click);
			this.menuFileSeparator2.Index = 10;
			this.menuFileSeparator2.Text = "-";
			this.menuFileExit.Index = 11;
			this.menuFileExit.Shortcut = Shortcut.AltF4;
			this.menuFileExit.Text = "E&xit";
			this.menuFileExit.Click += new EventHandler(this.menuFileExit_Click);
			this.menuEdit.Index = 1;
			MenuItem[] items3 = new MenuItem[]
			{
				this.menuEditUndo,
				this.menuEditRedo,
				this.menuEditSeparator1,
				this.menuEditCut,
				this.menuEditCopy,
				this.menuEditPaste,
				this.menuEditControlPaste,
				this.menuEditDelete,
				this.menuEditSeparator2,
				this.menuEditSelectAll,
				this.menuEditSelectNone
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
			this.menuEditSeparator1.Index = 2;
			this.menuEditSeparator1.Text = "-";
			this.menuEditCut.Index = 3;
			this.menuEditCut.Shortcut = Shortcut.CtrlX;
			this.menuEditCut.Text = "Cu&t";
			this.menuEditCut.Click += new EventHandler(this.menuEditCut_Click);
			this.menuEditCopy.Index = 4;
			this.menuEditCopy.Shortcut = Shortcut.CtrlC;
			this.menuEditCopy.Text = "&Copy";
			this.menuEditCopy.Click += new EventHandler(this.menuEditCopy_Click);
			this.menuEditPaste.Index = 5;
			this.menuEditPaste.Shortcut = Shortcut.CtrlV;
			this.menuEditPaste.Text = "&Paste";
			this.menuEditPaste.Click += new EventHandler(this.menuEditPaste_Click);
			this.menuEditControlPaste.Index = 6;
			this.menuEditControlPaste.Shortcut = Shortcut.CtrlShiftV;
			this.menuEditControlPaste.Text = "Paste &Special";
			this.menuEditControlPaste.Click += new EventHandler(this.menuEditControlPaste_Click);
			this.menuEditDelete.Index = 7;
			this.menuEditDelete.Shortcut = Shortcut.CtrlDel;
			this.menuEditDelete.Text = "&Delete";
			this.menuEditDelete.Click += new EventHandler(this.menuEditDelete_Click);
			this.menuEditSeparator2.Index = 8;
			this.menuEditSeparator2.Text = "-";
			this.menuEditSelectAll.Index = 9;
			this.menuEditSelectAll.Shortcut = Shortcut.CtrlA;
			this.menuEditSelectAll.Text = "Select &All";
			this.menuEditSelectAll.Click += new EventHandler(this.menuEditSelectAll_Click);
			this.menuEditSelectNone.Index = 10;
			this.menuEditSelectNone.Shortcut = Shortcut.CtrlShiftA;
			this.menuEditSelectNone.Text = "Select None";
			this.menuEditSelectNone.Click += new EventHandler(this.menuEditSelectNone_Click);
			this.menuView.Index = 2;
			MenuItem[] items4 = new MenuItem[]
			{
				this.menuViewToolbar,
				this.menuViewSidebar,
				this.menuViewStatusBar
			};
			this.menuView.MenuItems.AddRange(items4);
			this.menuView.Text = "&View";
			this.menuViewToolbar.Checked = true;
			this.menuViewToolbar.Index = 0;
			this.menuViewToolbar.Text = "&Toolbar";
			this.menuViewToolbar.Click += new EventHandler(this.menuViewToolbar_Click);
			this.menuViewSidebar.Index = 1;
			MenuItem[] items5 = new MenuItem[]
			{
				this.menuViewSidebarLeft,
				this.menuViewSidebarRight,
				this.menuViewSidebarOff
			};
			this.menuViewSidebar.MenuItems.AddRange(items5);
			this.menuViewSidebar.Text = "&Sidebar";
			this.menuViewSidebarLeft.Checked = true;
			this.menuViewSidebarLeft.Index = 0;
			this.menuViewSidebarLeft.Text = "Left";
			this.menuViewSidebarLeft.Click += new EventHandler(this.menuViewSidebarLeft_Click);
			this.menuViewSidebarRight.Index = 1;
			this.menuViewSidebarRight.Text = "Right";
			this.menuViewSidebarRight.Click += new EventHandler(this.menuViewSidebarRight_Click);
			this.menuViewSidebarOff.Index = 2;
			this.menuViewSidebarOff.Text = "Off";
			this.menuViewSidebarOff.Click += new EventHandler(this.menuViewSidebarOff_Click);
			this.menuViewStatusBar.Checked = true;
			this.menuViewStatusBar.Index = 2;
			this.menuViewStatusBar.Text = "St&atus Bar";
			this.menuViewStatusBar.Click += new EventHandler(this.menuViewStatusBar_Click);
			this.menuSound.Index = 5;
			MenuItem[] items6 = new MenuItem[]
			{
				this.menuSoundDisable,
				this.menuSoundStereo,
				this.menuSoundQuad,
				this.menuSoundSurround,
				this.menuSoundReverseStereo
			};
			this.menuSound.MenuItems.AddRange(items6);
			this.menuSound.Text = "&Sound";
			this.menuSoundDisable.Checked = false;
			this.menuSoundDisable.Index = 0;
			this.menuSoundDisable.Text = "&Disable";
			this.menuSoundDisable.Click += new EventHandler(this.menuSoundDisable_Click);
			this.menuSoundStereo.Checked = true;
			this.menuSoundStereo.Index = 1;
			this.menuSoundStereo.Text = "2.0 &Stereo";
			this.menuSoundStereo.Click += new EventHandler(this.menuSoundStereo_Click);
			this.menuSoundQuad.Checked = false;
			this.menuSoundQuad.Index = 2;
			this.menuSoundQuad.Text = "4.0 &Quadro";
			this.menuSoundQuad.Click += new EventHandler(this.menuSoundQuad_Click);
			this.menuSoundSurround.Checked = false;
			this.menuSoundSurround.Index = 3;
			this.menuSoundSurround.Text = "5.1 S&urround";
			this.menuSoundSurround.Click += new EventHandler(this.menuSoundSurround_Click);
			this.menuSoundReverseStereo.Checked = false;
			this.menuSoundReverseStereo.Index = 4;
			this.menuSoundReverseStereo.Text = "&Reverse Stereo";
			this.menuSoundReverseStereo.Click += new EventHandler(this.menuSoundReverseStereo_Click);
			this.menuMode.Index = 3;
			MenuItem[] items7 = new MenuItem[]
			{
				this.menuModeVertex,
				this.menuModePaint,
				this.menuModeRoad,
				this.menuModeDecal,
				this.menuModeSectors,
				this.menuItem5,
				this.menuModeLake,
				this.menuModeRiver,
				this.menuItem8,
				this.menuModeDoodad,
				this.menuModeWire,
				this.menuModeBuilding,
				this.menuModeUnit,
				this.menuModeAmbient,
				this.menuModeEffect,
				this.menuItem3,
				this.menuModeCameraCurve,
				this.menuModePaths,
				this.menuModeLocations,
				this.menuModeUnitGroup
			};
			this.menuMode.MenuItems.AddRange(items7);
			this.menuMode.Text = "&Mode";
			this.menuModeVertex.Index = 0;
			this.menuModeVertex.Text = "Vertex";
			this.menuModeVertex.Click += new EventHandler(this.menuModeVertex_Click);
			this.menuModePaint.Index = 1;
			this.menuModePaint.Text = "Paint";
			this.menuModePaint.Click += new EventHandler(this.menuModePaint_Click);
			this.menuModeRoad.Index = 2;
			this.menuModeRoad.Text = "Road";
			this.menuModeRoad.Click += new EventHandler(this.menuModeRoad_Click);
			this.menuModeDecal.Index = 3;
			this.menuModeDecal.Text = "Decal";
			this.menuModeDecal.Click += new EventHandler(this.menuModeDecal_Click);
			this.menuModeSectors.Index = 4;
			this.menuModeSectors.Text = "Sector";
			this.menuModeSectors.Click += new EventHandler(this.menuModeSectors_Click);
			this.menuItem5.Index = 5;
			this.menuItem5.Text = "-";
			this.menuModeLake.Index = 6;
			this.menuModeLake.Text = "Lake";
			this.menuModeLake.Click += new EventHandler(this.menuModeLake_Click);
			this.menuModeRiver.Index = 7;
			this.menuModeRiver.Text = "River";
			this.menuModeRiver.Click += new EventHandler(this.menuModeRiver_Click);
			this.menuItem8.Index = 8;
			this.menuItem8.Text = "-";
			this.menuModeDoodad.Index = 9;
			this.menuModeDoodad.Text = "Doodad";
			this.menuModeDoodad.Click += new EventHandler(this.menuModeDoodad_Click);
			this.menuModeWire.Index = 10;
			this.menuModeWire.Text = "Wire";
			this.menuModeWire.Click += new EventHandler(this.menuModeWire_Click);
			this.menuModeBuilding.Index = 11;
			this.menuModeBuilding.Text = "Building";
			this.menuModeBuilding.Click += new EventHandler(this.menuModeBuilding_Click);
			this.menuModeUnit.Index = 12;
			this.menuModeUnit.Text = "Unit";
			this.menuModeUnit.Click += new EventHandler(this.menuModeUnit_Click);
			this.menuModeAmbient.Index = 13;
			this.menuModeAmbient.Text = "Ambient";
			this.menuModeAmbient.Click += new EventHandler(this.menuModeAmbient_Click);
			this.menuModeEffect.Index = 14;
			this.menuModeEffect.Text = "Effect";
			this.menuModeEffect.Click += new EventHandler(this.menuModeEffect_Click);
			this.menuItem3.Index = 15;
			this.menuItem3.Text = "-";
			this.menuModeCameraCurve.Index = 16;
			this.menuModeCameraCurve.Text = "CameraCurve";
			this.menuModeCameraCurve.Click += new EventHandler(this.menuModeCameraCurve_Click);
			this.menuModePaths.Index = 17;
			this.menuModePaths.Text = "Path";
			this.menuModePaths.Click += new EventHandler(this.menuModePaths_Click);
			this.menuModeLocations.Index = 18;
			this.menuModeLocations.Text = "Location";
			this.menuModeLocations.Click += new EventHandler(this.menuModeLocations_Click);
			this.menuModeUnitGroup.Index = 19;
			this.menuModeUnitGroup.Text = "Unit AI group";
			this.menuModeUnitGroup.Click += new EventHandler(this.menuModeUnitGroup_Click);
			this.menuTools.Index = 4;
			MenuItem[] items8 = new MenuItem[]
			{
				this.menuToolsScriptEditor,
				this.menuToolsMissionVariables,
				this.menuToolsSeparator1,
				this.menuToolsOptions
			};
			this.menuTools.MenuItems.AddRange(items8);
			this.menuTools.Text = "&Tools";
			this.menuToolsScriptEditor.Index = 0;
			this.menuToolsScriptEditor.Text = "&Script Editor...";
			this.menuToolsScriptEditor.Click += new EventHandler(this.menuToolsScriptEditor_Click);
			this.menuToolsMissionVariables.Index = 1;
			this.menuToolsMissionVariables.Text = "&Mission Variables...";
			this.menuToolsMissionVariables.Click += new EventHandler(this.menuToolsMissionVariables_Click);
			this.menuToolsSeparator1.Index = 2;
			this.menuToolsSeparator1.Text = "-";
			this.menuToolsOptions.Index = 3;
			this.menuToolsOptions.Text = "&Options...";
			Point location = new Point(0, 551);
			this.sbMain.Location = location;
			this.sbMain.Name = "sbMain";
			Size size = new Size(792, 22);
			this.sbMain.Size = size;
			this.sbMain.TabIndex = 0;
			this.sbMain.Text = "sbMain";
			Point location2 = new Point(0, 0);
			this.splitMain.Location = location2;
			this.splitMain.MinExtra = 512;
			this.splitMain.MinSize = 256;
			this.splitMain.Name = "splitMain";
			Size size2 = new Size(3, 551);
			this.splitMain.Size = size2;
			this.splitMain.TabIndex = 3;
			this.splitMain.TabStop = false;
			this.MainViewPopupMenu.Popup += new EventHandler(this.MainViewPopupMenu_Popup);
			Size autoScaleBaseSize = new Size(5, 14);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(792, 573);
			base.ClientSize = clientSize;
			base.Controls.Add(this.splitMain);
			base.Controls.Add(this.sbMain);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Icon = (Icon)resourceManager.GetObject("$this.Icon");
			base.Menu = this.menuMain;
			Size minimumSize = new Size(800, 600);
			this.MinimumSize = minimumSize;
			base.Name = "NMainForm";
			this.Text = "Workshop™";
			base.WindowState = FormWindowState.Maximized;
			base.Closing += new CancelEventHandler(this.NMainForm_Closing);
			base.Load += new EventHandler(this.NMainForm_Load);
			base.Closed += new EventHandler(this.NMainForm_Closed);
			base.Activated += new EventHandler(this.NMainForm_Activated);
			base.ResumeLayout(false);
		}

		private unsafe void InitializeVariables()
		{
			this.IViewport = null;
			initblk(ref this.KeyTimes, 0, 2048);
			this.LastUpdate = 0L;
			this.LastCamViewPortUpdate = 0L;
			this.DragMode = 0;
			this.DragStarted = false;
			this.DragPreventMenu = false;
			this.SelectionPossible = false;
			GNativeData* ptr = <Module>.@new(36u);
			GNativeData* nD;
			try
			{
				if (ptr != null)
				{
					*(int*)ptr = 0;
					*(int*)(ptr + 4 / sizeof(GNativeData)) = 0;
					*(int*)(ptr + 8 / sizeof(GNativeData)) = 0;
					*(int*)(ptr + 12 / sizeof(GNativeData)) = 0;
					void* ptr2 = (void*)(ptr + 16 / sizeof(GNativeData));
					*(int*)ptr2 = 0;
					*(int*)((byte*)ptr2 + 4) = 0;
					*(int*)((byte*)ptr2 + 8) = 0;
					*(int*)(ptr + 28 / sizeof(GNativeData)) = 0;
					*(int*)(ptr + 32 / sizeof(GNativeData)) = 0;
					nD = ptr;
				}
				else
				{
					nD = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr);
				throw;
			}
			this.ND = nD;
			this.World = null;
			this.Clipboard = null;
			GEntityClipboard* ptr3 = <Module>.@new(300u);
			GEntityClipboard* entityClipboard;
			try
			{
				if (ptr3 != null)
				{
					entityClipboard = <Module>.GEntityClipboard.{ctor}(ptr3);
				}
				else
				{
					entityClipboard = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr3);
				throw;
			}
			this.EntityClipboard = entityClipboard;
			NPropertyClipboard* ptr4 = <Module>.@new(8u);
			NPropertyClipboard* effectEditorClipboard;
			try
			{
				if (ptr4 != null)
				{
					*(int*)(ptr4 + 4 / sizeof(NPropertyClipboard)) = 0;
					effectEditorClipboard = ptr4;
				}
				else
				{
					effectEditorClipboard = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr4);
				throw;
			}
			this.EffectEditorClipboard = effectEditorClipboard;
			NPropertyClipboard* ptr5 = <Module>.@new(8u);
			NPropertyClipboard* unitEditorClipboard;
			try
			{
				if (ptr5 != null)
				{
					*(int*)(ptr5 + 4 / sizeof(NPropertyClipboard)) = 0;
					unitEditorClipboard = ptr5;
				}
				else
				{
					unitEditorClipboard = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr5);
				throw;
			}
			this.UnitEditorClipboard = unitEditorClipboard;
			this.GameDebugMode = false;
			this.GameDebugWithShotsMode = false;
			this.GameDebugBackupWorld = null;
			this.GameDebugBackupScene = null;
			this.CurrentOrder = null;
			this.EditorMode = 0;
			this.DebugMode = 500;
			this.propBrushType = 2;
			this.propPaintType = 9;
			GTerraformer* ptr6 = <Module>.@new(76u);
			GTerraformer* ptr7;
			try
			{
				if (ptr6 != null)
				{
					ptr7 = <Module>.GTerraformer.{ctor}(ptr6);
				}
				else
				{
					ptr7 = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr6);
				throw;
			}
			this.Terraformer = ptr7;
			this.VertexFalloffType = 100;
			*(ptr7 + 8) = 1;
			*(byte*)(this.Terraformer + 9 / sizeof(GTerraformer)) = 0;
			GColor gColor = 0f;
			*(ref gColor + 4) = 0f;
			*(ref gColor + 8) = 0f;
			*(ref gColor + 12) = 0f;
			cpblk(this.Terraformer + 16 / sizeof(GTerraformer), ref gColor, 16);
			this.SelectionFalloffType = 100;
			this.SelectionAdditiveMode = true;
			this.SelectionActive = false;
			this.UpDownBrushDiam = 1.5f;
			this.UpDownBrushPressure = 20f;
			this.HeightSetValue = 0f;
			this.HeightSetBrushDiam = 2f;
			this.HeightSetBrushPressure = 20f;
			this.SmoothBrushDiam = 1f;
			this.SmoothBrushPressure = 10f;
			this.PaintBrushDiam = 1.5f;
			this.PaintBrushPressure = 25f;
			*(int*)(this.Terraformer + 12 / sizeof(GTerraformer)) = 0;
			this.SelectionDiam = 1.5f;
			this.SelectionPressure = 20f;
			this.UpDownBrushDiam2 = 75f;
			this.HeightSetBrushDiam2 = 75f;
			this.SmoothBrushDiam2 = 75f;
			this.SelectionDiam2 = 75f;
			this.ForestStrokeSize = 1.5f;
			this.ForestStrokePressure = 25f;
			this.EntityType = 0;
			$ArrayType$$$BY0BE@_N* ptr8 = ref this.EntityAlignMove;
			$ArrayType$$$BY0BE@PAV?$GBaseString@D@@* ptr9 = ref this.EntityName;
			int num = ref this.EntityOperation - ref this.EntityName;
			int num2 = ref this.EntityAlignRotate - ref this.EntityAlignMove;
			int num3 = ref this.EntityLockSelection - ref this.EntityAlignMove;
			int num4 = ref this.EntityLockHeights - ref this.EntityAlignMove;
			int num5 = ref this.EntityRandomAngle - ref this.EntityAlignMove;
			uint num6 = 20u;
			do
			{
				*(num + ptr9) = 1;
				GBaseString<char>* ptr10 = <Module>.@new(8u);
				GBaseString<char>* ptr11;
				try
				{
					if (ptr10 != null)
					{
						*(int*)ptr10 = 0;
						*(int*)(ptr10 + 4 / sizeof(GBaseString<char>)) = 0;
						ptr11 = ptr10;
					}
					else
					{
						ptr11 = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr10);
					throw;
				}
				*ptr9 = ptr11;
				*(ptr8 + num2) = 0;
				*ptr8 = 0;
				*(ptr8 + num3) = 0;
				*(ptr8 + num4) = 0;
				*(ptr8 + num5) = 0;
				ptr9 += 4;
				ptr8++;
				num6 -= 1u;
			}
			while (num6 > 0u);
			this.PreCreatedEntity = -1;
			GBaseString<char>* ptr12 = <Module>.@new(8u);
			GBaseString<char>* mapFileName;
			try
			{
				if (ptr12 != null)
				{
					*(int*)ptr12 = 0;
					*(int*)(ptr12 + 4 / sizeof(GBaseString<char>)) = 0;
					mapFileName = ptr12;
				}
				else
				{
					mapFileName = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr12);
				throw;
			}
			this.MapFileName = mapFileName;
			GBaseString<char>* ptr13 = <Module>.@new(8u);
			GBaseString<char>* exportMapFileName;
			try
			{
				if (ptr13 != null)
				{
					*(int*)ptr13 = 0;
					*(int*)(ptr13 + 4 / sizeof(GBaseString<char>)) = 0;
					exportMapFileName = ptr13;
				}
				else
				{
					exportMapFileName = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr13);
				throw;
			}
			this.ExportMapFileName = exportMapFileName;
			GBaseString<char>* ptr14 = <Module>.@new(8u);
			GBaseString<char>* importCamFileName;
			try
			{
				if (ptr14 != null)
				{
					*(int*)ptr14 = 0;
					*(int*)(ptr14 + 4 / sizeof(GBaseString<char>)) = 0;
					importCamFileName = ptr14;
				}
				else
				{
					importCamFileName = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr14);
				throw;
			}
			this.ImportCamFileName = importCamFileName;
			this.ToolWindows = new ArrayList();
			this.ScrollbarOn = false;
			this.OldHeight = 0;
			this.OpenFileName = "";
			this.TemporaryModeChange = false;
			this.CurrentEntityToolbar = null;
			this.CurrentMinimap = null;
			this.BrushNeedsUpdate = false;
			this.MinimapViewportNeedsUpdate = false;
			this.MinimapUnitsNeedUpdate = false;
			this.LastCameraType = 0;
			GCamera* lastCamera = <Module>.@new(20u);
			this.LastCamera = lastCamera;
			this.SectorSelectionNeedsUpdate = false;
			this.LastPasteOptions = 8191u;
			GArray<GIModel *>* ptr15 = <Module>.@new(12u);
			GArray<GIModel *>* physicsModels;
			try
			{
				if (ptr15 != null)
				{
					*(int*)ptr15 = 0;
					*(int*)(ptr15 + 4 / sizeof(GArray<GIModel *>)) = 0;
					*(int*)(ptr15 + 8 / sizeof(GArray<GIModel *>)) = 0;
					physicsModels = ptr15;
				}
				else
				{
					physicsModels = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr15);
				throw;
			}
			this.PhysicsModels = physicsModels;
			this.KeyDragMode = 0;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private unsafe bool SaveDocumentIfChanged()
		{
			GEditorWorld* world = this.World;
			if (world == null || <Module>.GEditorWorld.IsChanged(world) == null)
			{
				return true;
			}
			DialogResult dialogResult = MessageBox.Show("The map has been modified since the last save.\nDo you want to save?", "Save Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
			if (dialogResult == DialogResult.No)
			{
				return true;
			}
			if (dialogResult == DialogResult.Yes)
			{
				this.menuFileSave_Click(null, null);
				if (<Module>.GEditorWorld.IsChanged(this.World) == null)
				{
					return true;
				}
			}
			return false;
		}

		private unsafe void DiscardDocument()
		{
			this.EndDebugMap();
			this.SetEditorMode(0);
			this.EnableMenuAndToolbarItems(false);
			this.SelectionActive = false;
			ScriptEditorForm scriptEditorFormInstance = this.ScriptEditorFormInstance;
			if (scriptEditorFormInstance != null)
			{
				scriptEditorFormInstance.Close();
				*(int*)(this.World + 5080 / sizeof(GEditorWorld)) = 0;
				this.ScriptEditorFormInstance = null;
			}
			if (<Module>.Scene != null)
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *this.BrushCursor, *(*(int*)<Module>.Scene + 260));
				*(int*)this.BrushCursor = 0;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *this.ParcelSelection, *(*(int*)<Module>.Scene + 260));
				*(int*)this.ParcelSelection = 0;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *(GHandle<11>*)(this.ND + 28 / sizeof(GNativeData)), *(*(int*)<Module>.Scene + 260));
				*(int*)(this.ND + 28 / sizeof(GNativeData)) = 0;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *(GHandle<11>*)(this.ND + 32 / sizeof(GNativeData)), *(*(int*)<Module>.Scene + 260));
				*(int*)(this.ND + 32 / sizeof(GNativeData)) = 0;
			}
			GEditorWorld* world = this.World;
			if (world != null)
			{
				GEditorWorld* ptr = world;
				object arg_114_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr, 1, *(*(int*)ptr));
				this.World = null;
			}
		}

		private unsafe void NewDocument(int width, int height)
		{
			this.DiscardDocument();
			this.CameraCurveProps.InitCameraCurveProps();
			GEditorWorld* ptr = <Module>.@new(5192u);
			GEditorWorld* ptr2;
			try
			{
				if (ptr != null)
				{
					GNativeData* nD = this.ND;
					ptr2 = <Module>.GEditorWorld.{ctor}(ptr, *(GHandle<12>*)(nD + 4 / sizeof(GNativeData)), *(GHandle<19>*)nD, *(GHandle<19>*)nD);
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
			<Module>.GWorld.New(ptr2, width, height, (sbyte*)(&<Module>.??_C@_0M@PDMEOFLC@000?5default?$AA@));
			<Module>.GEditorWorld.Initialize(ptr2);
			<Module>.GWorld.SetCameraFarClip(ptr2, 600f);
			this.World = ptr2;
			<Module>.SafeWorld = ptr2;
			<Module>.GEditorWorld.SelectNone(this.World);
			this.InitUI();
			GBaseString<char>* mapFileName = this.MapFileName;
			uint num = (uint)(*mapFileName);
			if (num != 0u)
			{
				<Module>.free(num);
				*mapFileName = 0;
			}
			*(mapFileName + 4) = 0;
			this.EnableMenuAndToolbarItems(true);
			this.InitMinimap();
			this.InitScriptTools();
			this.SetEditorMode(1);
		}

		private unsafe void OpenDocument(string filepathname)
		{
			this.DiscardDocument();
			this.CameraCurveProps.InitCameraCurveProps();
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* src = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, filepathname);
			try
			{
				<Module>.GBaseString<char>.=(this.MapFileName, src);
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
			uint num = (uint)(*(int*)this.MapFileName);
			sbyte* ptr;
			if (num != 0u)
			{
				ptr = num;
			}
			else
			{
				ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
			}
			GStream* ptr2 = <Module>.GFileSystem.OpenRead(ref <Module>.FS, ptr, null);
			GBaseString<char>* mapFileName = this.MapFileName;
			int num2 = *(mapFileName + 4);
			GBaseString<char> gBaseString<char>2;
			if (num2 != 0)
			{
				*(ref gBaseString<char>2 + 4) = num2;
				gBaseString<char>2 = <Module>.malloc((uint)(*(ref gBaseString<char>2 + 4) + 1));
				cpblk(gBaseString<char>2, *mapFileName, *(ref gBaseString<char>2 + 4) + 1);
			}
			else
			{
				*(ref gBaseString<char>2 + 4) = 0;
				gBaseString<char>2 = 0;
			}
			try
			{
				uint num3 = (uint)(*<Module>.GBaseString<char>.SetExtension(ref gBaseString<char>2, (sbyte*)(&<Module>.??_C@_03LDJCPKFL@ma2?$AA@)));
				sbyte* ptr3;
				if (num3 != 0u)
				{
					ptr3 = num3;
				}
				else
				{
					ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				GStream* ptr4 = <Module>.GFileSystem.OpenRead(ref <Module>.FS, ptr3, null);
				if (ptr2 == null)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 1021, (sbyte*)(&<Module>.??_C@_0CD@EHEEFEHN@NWorkshop?3?3NMainForm?3?3OpenDocume@));
					<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), *this.MapFileName);
				}
				GEditorWorld* ptr5 = <Module>.@new(5192u);
				GEditorWorld* ptr6;
				try
				{
					if (ptr5 != null)
					{
						GNativeData* nD = this.ND;
						ptr6 = <Module>.GEditorWorld.{ctor}(ptr5, *(GHandle<12>*)(nD + 4 / sizeof(GNativeData)), *(GHandle<19>*)nD, *(GHandle<19>*)nD);
					}
					else
					{
						ptr6 = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr5);
					throw;
				}
				GAWorld gAWorld;
				<Module>.GAWorld.{ctor}(ref gAWorld);
				try
				{
					<Module>.GAWorld.Load(ref gAWorld, ptr4);
					if (<Module>.?Load@GWorld@@$$FQAE_NPAVGStream@@PAVGAWorld@@_NP6AXABUGLoadingInfo@@PAX@ZP6AXXZP6AHW4AssetType@@PBDAAV?$GBaseString@D@@2@Z4@Z(ptr6, ptr2, &gAWorld, true, <Module>.__unep@?OnLoadNotifier@NWorkshop@@$$FYAXABUGLoadingInfo@@PAX@Z, <Module>.__unep@?OnLoadRefresh@NWorkshop@@$$FYAXXZ, <Module>.__unep@?MissingAssetHandler@NWorkshop@@$$FYAHW4AssetType@@PBDAAV?$GBaseString@D@@_N@Z, null) != null)
					{
						<Module>.GEditorWorld.Initialize(ptr6);
						<Module>.GEditorWorld.ReplaceDoodadsToBuildings(ptr6);
						<Module>.GWorld.SetCameraFarClip(ptr6, 600f);
						this.World = ptr6;
						<Module>.SafeWorld = ptr6;
						<Module>.GEditorWorld.SelectNone(this.World);
						this.InitUI();
						this.EnableMenuAndToolbarItems(true);
						this.InitMinimap();
						this.InitScriptTools();
						this.SetEditorMode(1);
					}
					else
					{
						GBaseString<char>* mapFileName2 = this.MapFileName;
						uint num4 = (uint)(*mapFileName2);
						if (num4 != 0u)
						{
							<Module>.free(num4);
							*mapFileName2 = 0;
						}
						*(mapFileName2 + 4) = 0;
						if (ptr6 != null)
						{
							object arg_1F8_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, *(*ptr6));
						}
					}
					object arg_203_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, *(*(int*)ptr2));
					if (ptr4 != null)
					{
						object arg_213_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, *(*(int*)ptr4));
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GAWorld.{dtor}), (void*)(&gAWorld));
					throw;
				}
				<Module>.GAWorld.{dtor}(ref gAWorld);
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

		private unsafe void SaveDocument()
		{
			if (this.World != null)
			{
				GBaseString<char>* mapFileName = this.MapFileName;
				if (((*(int*)(mapFileName + 4 / sizeof(GBaseString<char>)) == 0) ? 1 : 0) == 0)
				{
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr = <Module>.GBaseString<char>.Dirname(mapFileName, &gBaseString<char>);
					GBaseString<char> gBaseString<char>2;
					try
					{
						<Module>.GBaseString<char>.+(ptr, &gBaseString<char>2, (sbyte*)(&<Module>.??_C@_09IECNAGPM@?1$$temp$$?$AA@));
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
						GBaseString<char> gBaseString<char>3;
						GBaseString<char>* ptr2 = <Module>.GBaseString<char>.Dirname(this.MapFileName, &gBaseString<char>3);
						GBaseString<char> gBaseString<char>4;
						try
						{
							<Module>.GBaseString<char>.+(ptr2, &gBaseString<char>4, (sbyte*)(&<Module>.??_C@_0L@DABFHKNE@?1$$temp2$$?$AA@));
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
							throw;
						}
						try
						{
							if (gBaseString<char>3 != null)
							{
								<Module>.free(gBaseString<char>3);
							}
							GBaseString<char>* mapFileName2 = this.MapFileName;
							int num = *(mapFileName2 + 4);
							GBaseString<char> gBaseString<char>5;
							if (num != 0)
							{
								*(ref gBaseString<char>5 + 4) = num;
								uint num2 = (uint)(*(ref gBaseString<char>5 + 4) + 1);
								gBaseString<char>5 = <Module>.malloc(num2);
								cpblk(gBaseString<char>5, *mapFileName2, num2);
							}
							else
							{
								*(ref gBaseString<char>5 + 4) = 0;
								gBaseString<char>5 = 0;
							}
							try
							{
								<Module>.GBaseString<char>.SetExtension(ref gBaseString<char>5, (sbyte*)(&<Module>.??_C@_03LDJCPKFL@ma2?$AA@));
								sbyte* ptr3;
								if (gBaseString<char>2 != null)
								{
									ptr3 = gBaseString<char>2;
								}
								else
								{
									ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								GStream* ptr4 = <Module>.GFileSystem.OpenWrite(ref <Module>.FS, ptr3, null);
								sbyte* ptr5;
								if (gBaseString<char>4 != null)
								{
									ptr5 = gBaseString<char>4;
								}
								else
								{
									ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								GStream* ptr6 = <Module>.GFileSystem.OpenWrite(ref <Module>.FS, ptr5, null);
								if (ptr4 == null)
								{
									<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 1066, (sbyte*)(&<Module>.??_C@_0CD@DBLALDPC@NWorkshop?3?3NMainForm?3?3SaveDocume@));
									uint num3 = (uint)(*(int*)this.MapFileName);
									sbyte* ptr7;
									if (num3 != 0u)
									{
										ptr7 = num3;
									}
									else
									{
										ptr7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
									}
									<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), ptr7);
								}
								if (<Module>.GEditorWorld.Save(this.World, ptr4, ptr6) != null)
								{
									<Module>.GEditorWorld.MarkSaved(this.World);
									object arg_18B_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, *(*(int*)ptr4));
									if (ptr6 != null)
									{
										object arg_199_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, *(*(int*)ptr6));
									}
									uint num4 = (uint)(*(int*)this.MapFileName);
									<Module>.unlink((num4 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num4);
									<Module>.unlink((gBaseString<char>5 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>5);
									uint num5 = (uint)(*(int*)this.MapFileName);
									sbyte* ptr8;
									if (num5 != 0u)
									{
										ptr8 = num5;
									}
									else
									{
										ptr8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
									}
									<Module>.rename((gBaseString<char>2 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>2, ptr8);
									sbyte* ptr9;
									if (gBaseString<char>5 != null)
									{
										ptr9 = gBaseString<char>5;
									}
									else
									{
										ptr9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
									}
									<Module>.rename((gBaseString<char>4 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>4, ptr9);
								}
								else
								{
									object arg_22C_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, *(*(int*)ptr4));
									if (ptr6 != null)
									{
										object arg_23A_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, *(*(int*)ptr6));
									}
									<Module>.unlink((gBaseString<char>2 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>2);
									<Module>.unlink((gBaseString<char>4 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>4);
								}
								this.RefreshMenuAndToolbarItems();
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>5));
								throw;
							}
							if (gBaseString<char>5 != null)
							{
								<Module>.free(gBaseString<char>5);
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
							throw;
						}
						if (gBaseString<char>4 != null)
						{
							<Module>.free(gBaseString<char>4);
							gBaseString<char>4 = 0;
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
			}
		}

		private unsafe void ExportMap()
		{
			if (this.World != null)
			{
				GBaseString<char>* exportMapFileName = this.ExportMapFileName;
				if (((*(int*)(exportMapFileName + 4 / sizeof(GBaseString<char>)) == 0) ? 1 : 0) == 0)
				{
					GStream* ptr = <Module>.GFileSystem.OpenWrite(ref <Module>.FS, <Module>.GBaseString<char>..PBD(exportMapFileName), null);
					if (ptr == null)
					{
						<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 1098, (sbyte*)(&<Module>.??_C@_0CA@EEBAHGLL@NWorkshop?3?3NMainForm?3?3ExportMap?$AA@));
						<Module>.GLogger.Warning((sbyte*)(&<Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), <Module>.GBaseString<char>..PBD(this.ExportMapFileName));
					}
					else
					{
						GBaseString<char> gBaseString<char>;
						<Module>.GBaseString<char>.Basename(this.ExportMapFileName, &gBaseString<char>);
						try
						{
							GBaseString<char> gBaseString<char>2;
							<Module>.GBaseString<char>.Copy(ref gBaseString<char>, &gBaseString<char>2, 0, <Module>.GBaseString<char>.GetFirstCharIndex(ref gBaseString<char>, 46));
							try
							{
								GBaseString<char> gBaseString<char>3;
								<Module>.GBaseString<char>.+(ref gBaseString<char>2, &gBaseString<char>3, (sbyte*)(&<Module>.??_C@_0N@KFJPEGJO@_terrain?44dp?$AA@));
								try
								{
									GBaseString<char> gBaseString<char>4;
									GBaseString<char>* ptr2 = <Module>.GBaseString<char>.Dirname(this.ExportMapFileName, &gBaseString<char>4);
									GBaseString<char> gBaseString<char>6;
									try
									{
										GBaseString<char> gBaseString<char>5;
										GBaseString<char>* ptr3 = <Module>.GBaseString<char>.+(ptr2, &gBaseString<char>5, (sbyte*)(&<Module>.??_C@_01KMDKNFGN@?1?$AA@));
										try
										{
											<Module>.GBaseString<char>.+(ptr3, &gBaseString<char>6, ref gBaseString<char>3);
										}
										catch
										{
											<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>5));
											throw;
										}
										try
										{
											<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>5);
										}
										catch
										{
											<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
											throw;
										}
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
										throw;
									}
									try
									{
										<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>4);
										G4DPModel* ptr4 = <Module>.@new(56u);
										G4DPModel* ptr5;
										try
										{
											if (ptr4 != null)
											{
												ptr5 = <Module>.G4DPModel.{ctor}(ptr4);
											}
											else
											{
												ptr5 = 0;
											}
										}
										catch
										{
											<Module>.delete((void*)ptr4);
											throw;
										}
										*ptr5 = 1;
										int num = <Module>.GArray<G4DPNode>.Add(ptr5 + 32);
										int num2 = *(int*)(this.World + 2548 / sizeof(GEditorWorld));
										int num3 = num * 128;
										int* arg_16A_0 = num3 + *(ptr5 + 32) + 100;
										int expr_15F = num2;
										*arg_16A_0 = calli(G4DPMesh* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_15F, *(*expr_15F + 52));
										<Module>.GBaseString<char>.=(num3 + *(ptr5 + 32), (sbyte*)(&<Module>.??_C@_07GICFIHGN@Terrain?$AA@));
										<Module>.GBaseString<char>.=(*(ptr5 + 32) + num3 + 8, (sbyte*)(&<Module>.??_C@_07GICFIHGN@Terrain?$AA@));
										*(<Module>.GArray<G4DPNode>.[](ptr5 + 32, num) + 16) = -1;
										*(<Module>.GArray<G4DPNode>.[](ptr5 + 32, num) + 20) = -1;
										GStream* ptr6 = <Module>.GFileSystem.OpenWrite(ref <Module>.FS, <Module>.GBaseString<char>..PBD(ref gBaseString<char>6), null);
										<Module>.GRTTI.SaveVariablesAsText(ptr6, &<Module>.GRTT_4dpModel.Class_G4DPModel, ptr5, ref <Module>.Measures);
										if (ptr6 != null)
										{
											object arg_1ED_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, *(*(int*)ptr6));
										}
										G4DPModelList* ptr7 = <Module>.@new(12u);
										G4DPModelList* ptr8;
										try
										{
											if (ptr7 != null)
											{
												ptr8 = <Module>.G4DPModelList.{ctor}(ptr7);
											}
											else
											{
												ptr8 = 0;
											}
										}
										catch
										{
											<Module>.delete((void*)ptr7);
											throw;
										}
										int num4 = <Module>.GArray<G4DPModelInfo>.Add(ptr8);
										<Module>.GBaseString<char>.=(<Module>.GArray<G4DPModelInfo>.[](ptr8, num4), ref gBaseString<char>3);
										<Module>.GBaseString<char>.=(<Module>.GArray<G4DPModelInfo>.[](ptr8, num4) + 8, (sbyte*)(&<Module>.??_C@_07GICFIHGN@Terrain?$AA@));
										cpblk(<Module>.GArray<G4DPModelInfo>.[](ptr8, num4) + 16, ref <Module>.RHandToLHandMatrix, 48);
										GEditorWorld* ptr9 = this.World + 3196 / sizeof(GEditorWorld);
										int num5 = <Module>.GHeap<GWCameraCurve>.GetNext(ptr9, -1);
										if (num5 >= 0)
										{
											do
											{
												int num6 = num5 * 104;
												if (*(num6 + *(int*)ptr9 + 4 + 32) == 0)
												{
													GWCameraCurve* src = num6 + *(int*)ptr9 + 4;
													GBaseString<char> gBaseString<char>7;
													<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>7, src);
													try
													{
														GPoint3 gPoint;
														*(ref gPoint + 8) = 0f;
														*(ref gPoint + 4) = 0f;
														gPoint = 0f;
														GPoint3 gPoint2;
														*(ref gPoint2 + 8) = 0f;
														*(ref gPoint2 + 4) = 0f;
														gPoint2 = 0f;
														float num7 = <Module>.GWorld.GetCameraCurveDuration(this.World, num5);
														if (num7 != 0f)
														{
															goto IL_306;
														}
													}
													catch
													{
														<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>7));
														throw;
													}
													<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>7);
													goto IL_6C3;
													IL_306:
													try
													{
														int num8 = 0;
														ptr9 = this.World + 3196 / sizeof(GEditorWorld);
														GWCameraCurve* ptr10 = num6 + *(int*)ptr9 + 4;
														int num9 = *(ptr10 + 48);
														if (0 < num9)
														{
															do
															{
																int num10 = *(int*)ptr9;
																GWCameraCurve* ptr11 = num6 + num10 + 4;
																int num11 = *(num8 * 4 + *(ptr11 + 44));
																GWCameraCurve* src2 = num10 + num11 * 104 + 4;
																GBaseString<char> gBaseString<char>8;
																<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>8, src2);
																try
																{
																	GBaseString<char> gBaseString<char>9;
																	GBaseString<char>* ptr12 = <Module>.GBaseString<char>.+(ref gBaseString<char>7, &gBaseString<char>9, (sbyte*)(&<Module>.??_C@_01IDAFKMJL@_?$AA@));
																	GBaseString<char> gBaseString<char>10;
																	try
																	{
																		<Module>.GBaseString<char>.+(ptr12, &gBaseString<char>10, ref gBaseString<char>8);
																	}
																	catch
																	{
																		<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>9));
																		throw;
																	}
																	try
																	{
																		if (gBaseString<char>9 != null)
																		{
																			<Module>.free(gBaseString<char>9);
																			gBaseString<char>9 = 0;
																		}
																		GBaseString<char> gBaseString<char>11;
																		GBaseString<char>* ptr13 = <Module>.GBaseString<char>.+(ref gBaseString<char>2, &gBaseString<char>11, ref gBaseString<char>10);
																		GBaseString<char> gBaseString<char>12;
																		try
																		{
																			<Module>.GBaseString<char>.+(ptr13, &gBaseString<char>12, (sbyte*)(&<Module>.??_C@_07PAGPJACA@?44dpcam?$AA@));
																		}
																		catch
																		{
																			<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>11));
																			throw;
																		}
																		try
																		{
																			if (gBaseString<char>11 != null)
																			{
																				<Module>.free(gBaseString<char>11);
																				gBaseString<char>11 = 0;
																			}
																			GBaseString<char> gBaseString<char>13;
																			GBaseString<char>* ptr14 = <Module>.GBaseString<char>.Dirname(this.ExportMapFileName, &gBaseString<char>13);
																			GBaseString<char> gBaseString<char>15;
																			try
																			{
																				GBaseString<char> gBaseString<char>14;
																				GBaseString<char>* ptr15 = <Module>.GBaseString<char>.+(ptr14, &gBaseString<char>14, (sbyte*)(&<Module>.??_C@_01KMDKNFGN@?1?$AA@));
																				try
																				{
																					<Module>.GBaseString<char>.+(ptr15, &gBaseString<char>15, ref gBaseString<char>12);
																				}
																				catch
																				{
																					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>14));
																					throw;
																				}
																				try
																				{
																					if (gBaseString<char>14 != null)
																					{
																						<Module>.free(gBaseString<char>14);
																						gBaseString<char>14 = 0;
																					}
																				}
																				catch
																				{
																					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>15));
																					throw;
																				}
																			}
																			catch
																			{
																				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>13));
																				throw;
																			}
																			try
																			{
																				if (gBaseString<char>13 != null)
																				{
																					<Module>.free(gBaseString<char>13);
																					gBaseString<char>13 = 0;
																				}
																				G4DPCameraCurve* ptr16 = <Module>.@new(32u);
																				G4DPCameraCurve* ptr17;
																				try
																				{
																					if (ptr16 != null)
																					{
																						ptr17 = <Module>.G4DPCameraCurve.{ctor}(ptr16);
																					}
																					else
																					{
																						ptr17 = 0;
																					}
																				}
																				catch
																				{
																					<Module>.delete((void*)ptr16);
																					throw;
																				}
																				float num7;
																				*(ptr17 + 8) = num7;
																				<Module>.GBaseString<char>.=(ptr17, ref gBaseString<char>10);
																				*(ptr17 + 12) = 1.76666665f;
																				*(ptr17 + 16) = 20f;
																				float num12 = 0f;
																				if (0f <= num7)
																				{
																					float num13 = 1f / num7;
																					do
																					{
																						GPoint3 gPoint;
																						GPoint3 gPoint2;
																						float num14;
																						float num15;
																						float num16;
																						float num17;
																						<Module>.GWorld.GetCameraAllParams(this.World, num5, num11, true, num12 * num13, ref gPoint, ref gPoint2, ref num14, ref num15, ref num16, ref num17);
																						gPoint *= 1.5f;
																						*(ref gPoint + 4) = *(ref gPoint + 4) * 1.5f;
																						*(ref gPoint + 8) = *(ref gPoint + 8) * -1.5f;
																						gPoint2 *= 1.5f;
																						*(ref gPoint2 + 4) = *(ref gPoint2 + 4) * 1.5f;
																						*(ref gPoint2 + 8) = *(ref gPoint2 + 8) * -1.5f;
																						int num18 = <Module>.GArray<G4DPCameraKey>.Add(ptr17 + 20) * 36;
																						*(*(ptr17 + 20) + num18) = num12;
																						cpblk(num18 + *(ptr17 + 20) + 4, ref gPoint, 12);
																						cpblk(num18 + *(ptr17 + 20) + 16, ref gPoint2, 12);
																						*(num18 + *(ptr17 + 20) + 28) = num16;
																						*(num18 + *(ptr17 + 20) + 32) = num17;
																						num12 += 0.05f;
																					}
																					while (num12 <= num7);
																				}
																				sbyte* ptr18;
																				if (gBaseString<char>15 != null)
																				{
																					ptr18 = gBaseString<char>15;
																				}
																				else
																				{
																					ptr18 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
																				}
																				GStream* ptr19 = <Module>.GFileSystem.OpenWrite(ref <Module>.FS, ptr18, null);
																				<Module>.GRTTI.SaveVariablesAsText(ptr19, &<Module>.GRTT_4dpModel.Class_G4DPCameraCurve, ptr17, ref <Module>.Measures);
																				if (ptr19 != null)
																				{
																					object arg_5EA_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr19, 1, *(*(int*)ptr19));
																				}
																				<Module>.G4DPCameraCurve.{dtor}(ptr17);
																				<Module>.delete(ptr17);
																				num4 = <Module>.GArray<G4DPModelInfo>.Add(ptr8);
																				int num19 = num4 * 64;
																				<Module>.GBaseString<char>.=(*ptr8 + num19, ref gBaseString<char>12);
																				<Module>.GBaseString<char>.=(num19 + *ptr8 + 8, (sbyte*)(&<Module>.??_C@_06JCBBMBIP@Camera?$AA@));
																			}
																			catch
																			{
																				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>15));
																				throw;
																			}
																			<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>15);
																		}
																		catch
																		{
																			<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>12));
																			throw;
																		}
																		<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>12);
																	}
																	catch
																	{
																		<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>10));
																		throw;
																	}
																	<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>10);
																}
																catch
																{
																	<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>8));
																	throw;
																}
																<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>8);
																num8++;
																ptr9 = this.World + 3196 / sizeof(GEditorWorld);
																ptr10 = num6 + *(int*)ptr9 + 4;
																num9 = *(ptr10 + 48);
															}
															while (num8 < num9);
														}
													}
													catch
													{
														<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>7));
														throw;
													}
													<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>7);
												}
												IL_6C3:
												ptr9 = this.World + 3196 / sizeof(GEditorWorld);
												num5 = <Module>.GHeap<GWCameraCurve>.GetNext(ptr9, num5);
											}
											while (num5 >= 0);
										}
										GEditorWorld* ptr20 = this.World + 2928 / sizeof(GEditorWorld);
										int num20 = <Module>.GHeapDRB<GUnit *>.GetNext(ptr20, -1);
										if (num20 >= 0)
										{
											while (true)
											{
												int expr_712 = *(*(num20 * 8 + *(int*)ptr20 + 4) + 8);
												int num21;
												if (calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_712, *(*expr_712 + 44)))
												{
													num4 = <Module>.GArray<G4DPModelInfo>.Add(ptr8);
													num21 = num4 * 64;
													<Module>.GBaseString<char>.=(num21 + *ptr8 + 8, (sbyte*)(&<Module>.??_C@_0N@MGNDAPHK@UnitBuilding?$AA@));
													goto IL_785;
												}
												int expr_757 = *(*(num20 * 8 + *(int*)(this.World + 2928 / sizeof(GEditorWorld)) + 4) + 8);
												if (calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_757, *(*expr_757 + 36)))
												{
													num4 = <Module>.GArray<G4DPModelInfo>.Add(ptr8);
													num21 = num4 * 64;
													<Module>.GBaseString<char>.=(num21 + *ptr8 + 8, (sbyte*)(&<Module>.??_C@_0M@OIHLOAJC@UnitVehicle?$AA@));
													goto IL_785;
												}
												IL_857:
												ptr20 = this.World + 2928 / sizeof(GEditorWorld);
												num20 = <Module>.GHeapDRB<GUnit *>.GetNext(ptr20, num20);
												if (num20 < 0)
												{
													break;
												}
												continue;
												IL_785:
												GUnit** ptr21 = num20 * 8 + *(int*)(this.World + 2928 / sizeof(GEditorWorld)) + 4;
												<Module>.GBaseString<char>.=(*ptr8 + num21, *(*ptr21 + 8) + 12);
												ptr20 = this.World + 2928 / sizeof(GEditorWorld);
												GUnit** ptr22 = num20 * 8 + *(int*)ptr20 + 4;
												GPoint3 gPoint3;
												cpblk(ref gPoint3, *ptr22 + 528, 12);
												GVector3 gVector;
												*(ref gVector + 8) = -(*(ref gPoint3 + 8));
												float num22 = gPoint3 * 1.5f;
												float num23 = *(ref gPoint3 + 4) * 1.5f;
												float num24 = *(ref gVector + 8) * 1.5f;
												GVector3 gVector2 = num22;
												*(ref gVector2 + 4) = num23;
												*(ref gVector2 + 8) = num24;
												GUnit** ptr23 = num20 * 8 + *(int*)ptr20 + 4;
												GMatrix3 gMatrix;
												GMatrix3 gMatrix2;
												GMatrix3 gMatrix3;
												<Module>.GMatrix3.*(<Module>.Matrix3RotationY(&gMatrix, -(*(*ptr23 + 564))), &gMatrix2, <Module>.Matrix3Translation(&gMatrix3, ref gVector2));
												cpblk(num21 + *ptr8 + 16, ref gMatrix2, 48);
												goto IL_857;
											}
										}
										int num25 = <Module>.GHeap<GWDoodad>.GetNext(this.World + 2864 / sizeof(GEditorWorld), -1);
										if (num25 >= 0)
										{
											do
											{
												num4 = <Module>.GArray<G4DPModelInfo>.Add(ptr8);
												GWDoodad* ptr24 = num25 * 208 + *(int*)(this.World + 2864 / sizeof(GEditorWorld)) + 4;
												int num26 = num4 * 64;
												<Module>.GBaseString<char>.=(*ptr8 + num26, ptr24 + 8);
												<Module>.GBaseString<char>.=(num26 + *ptr8 + 8, (sbyte*)(&<Module>.??_C@_06MMNHEDBI@Doodad?$AA@));
												GEditorWorld* world = this.World;
												float num27 = *(<Module>.GHeap<GWDoodad>.[](world + 2864 / sizeof(GEditorWorld), num25) + 20);
												float num28 = *(<Module>.GHeap<GWDoodad>.[](world + 2864 / sizeof(GEditorWorld), num25) + 28);
												float num29 = *(<Module>.GHeap<GWDoodad>.[](world + 2864 / sizeof(GEditorWorld), num25) + 24);
												float num30 = <Module>.GWorld.GetHeight(world, num27, num29) + num28;
												GVector3 gVector3 = num27;
												*(ref gVector3 + 4) = num30;
												*(ref gVector3 + 8) = -num29;
												GTransformation gTransformation;
												<Module>.GTransformation.{ctor}(ref gTransformation);
												GVector3 gVector4;
												GVector3* ptr25 = <Module>.GVector3.*(ref gVector3, &gVector4, 1.5f);
												cpblk(ref gTransformation, ptr25, 12);
												GEditorWorld* ptr26 = this.World + 2864 / sizeof(GEditorWorld);
												<Module>.GTransformation.SetRotationTiltXZ(ref gTransformation, -(*(<Module>.GHeap<GWDoodad>.[](ptr26, num25) + 32)), *(<Module>.GHeap<GWDoodad>.[](ptr26, num25) + 36), -(*(<Module>.GHeap<GWDoodad>.[](ptr26, num25) + 40)));
												int arg_9AC_0 = *ptr8 + num26;
												GMatrix3 gMatrix4;
												GMatrix3* ptr27 = <Module>.GTransformation.GetMatrix(ref gTransformation, &gMatrix4);
												cpblk(arg_9AC_0 + 16, ptr27, 48);
												num25 = <Module>.GHeap<GWDoodad>.GetNext(this.World + 2864 / sizeof(GEditorWorld), num25);
											}
											while (num25 >= 0);
										}
										<Module>.GRTTI.SaveVariablesAsText(ptr, &<Module>.GRTT_4dpModel.Class_G4DPModelList, ptr8, ref <Module>.Measures);
										if (ptr8 != null)
										{
											<Module>.G4DPModelList.__delDtor(ptr8, 1u);
										}
										object arg_9F7_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr, 1, *(*(int*)ptr));
										this.RefreshMenuAndToolbarItems();
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>6);
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>3);
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
								throw;
							}
							<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>2);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
							throw;
						}
						<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>);
					}
				}
			}
		}

		private unsafe void ImportCamera()
		{
			if (this.World != null)
			{
				uint num = (uint)(*(int*)this.ImportCamFileName);
				sbyte* ptr;
				if (num != 0u)
				{
					ptr = num;
				}
				else
				{
					ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				GStream* ptr2 = <Module>.GFileSystem.OpenRead(ref <Module>.FS, ptr, null);
				if (ptr2 == null)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 1255, (sbyte*)(&<Module>.??_C@_0CD@EMPMDFDB@NWorkshop?3?3NMainForm?3?3ImportCame@));
					uint num2 = (uint)(*(int*)this.ImportCamFileName);
					sbyte* ptr3;
					if (num2 != 0u)
					{
						ptr3 = num2;
					}
					else
					{
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					<Module>.GLogger.Warning((sbyte*)(&<Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), ptr3);
				}
				else
				{
					uint num3 = (uint)(*(int*)(this.World + 3216 / sizeof(GEditorWorld)));
					if (num3 != 0u)
					{
						G4DPCameraCurve* ptr4 = num3;
						<Module>.G4DPCameraCurve.{dtor}(ptr4);
						<Module>.delete((void*)ptr4);
						*(int*)(this.World + 3216 / sizeof(GEditorWorld)) = 0;
					}
					G4DPCameraCurve* ptr5 = <Module>.@new(32u);
					G4DPCameraCurve* ptr6;
					try
					{
						if (ptr5 != null)
						{
							ptr6 = <Module>.G4DPCameraCurve.{ctor}(ptr5);
						}
						else
						{
							ptr6 = 0;
						}
					}
					catch
					{
						<Module>.delete((void*)ptr5);
						throw;
					}
					*(int*)(this.World + 3216 / sizeof(GEditorWorld)) = ptr6;
					GMeasures gMeasures;
					<Module>.GRTTI.LoadVariablesAsText(ptr2, &<Module>.GRTT_4dpModel.Class_G4DPCameraCurve, *(int*)(this.World + 3216 / sizeof(GEditorWorld)), <Module>.GMeasures.{ctor}(ref gMeasures, 1f, 1f));
					*(byte*)(this.World + 3220 / sizeof(GEditorWorld)) = 1;
					this.CameraCurveProps.RefreshCameraCurveIndex();
					object arg_11F_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, *(*(int*)ptr2));
				}
			}
		}

		private unsafe void RemoveImportCamera()
		{
			GEditorWorld* world = this.World;
			if (world != null)
			{
				uint num = (uint)(*(int*)(world + 3216 / sizeof(GEditorWorld)));
				if (num != 0u)
				{
					G4DPCameraCurve* ptr = num;
					<Module>.G4DPCameraCurve.{dtor}(ptr);
					<Module>.delete((void*)ptr);
					*(int*)(this.World + 3216 / sizeof(GEditorWorld)) = 0;
				}
				*(byte*)(this.World + 3220 / sizeof(GEditorWorld)) = 0;
				this.CameraCurveProps.RefreshCameraCurveIndex();
			}
		}

		private unsafe void LoadScripts()
		{
			NFileDialog nFileDialog = new NFileDialog(null, true);
			nFileDialog.AvailableModes = 2;
			nFileDialog.SelectedMode = 2;
			nFileDialog.DefaultExtension = "scr";
			GBaseString<char> gBaseString<char>3;
			if (nFileDialog.ShowDialog() == DialogResult.OK)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, nFileDialog.FilePath);
				GStream* ptr3;
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
					ptr3 = <Module>.GFileSystem.OpenRead(ref <Module>.FS, ptr2, null);
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
				GBaseString<char>* ptr4 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, nFileDialog.FilePath);
				GStream* ptr6;
				try
				{
					uint num2 = (uint)(*<Module>.GBaseString<char>.SetExtension(ptr4, (sbyte*)(&<Module>.??_C@_03PFCKMFAK@sce?$AA@)));
					sbyte* ptr5;
					if (num2 != 0u)
					{
						ptr5 = num2;
					}
					else
					{
						ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					ptr6 = <Module>.GFileSystem.OpenRead(ref <Module>.FS, ptr5, null);
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
				if (ptr3 == null)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 1293, (sbyte*)(&<Module>.??_C@_0CC@OLBJKMDA@NWorkshop?3?3NMainForm?3?3LoadScript@));
					GBaseString<char>* ptr7 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, nFileDialog.FilePath);
					try
					{
						<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), *ptr7);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
						throw;
					}
				}
				try
				{
					<Module>.?LoadScriptEntities@GEditorWorld@@$$FQAE_NPAVGStream@@0P6AHW4AssetType@@PBDAAV?$GBaseString@D@@_N@Z@Z(this.World, ptr3, ptr6, <Module>.__unep@?MissingAssetHandler@NWorkshop@@$$FYAHW4AssetType@@PBDAAV?$GBaseString@D@@_N@Z);
					this.RefreshMenuAndToolbarItems();
					object arg_147_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, *(*(int*)ptr3));
					if (ptr6 != null)
					{
						object arg_157_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, *(*(int*)ptr6));
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
			}
			try
			{
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
				throw;
			}
		}

		private unsafe void SaveScripts()
		{
			NFileDialog nFileDialog = new NFileDialog(null, true);
			nFileDialog.AvailableModes = 4;
			nFileDialog.SelectedMode = 4;
			nFileDialog.DefaultExtension = "scr";
			GBaseString<char> gBaseString<char>4;
			if (nFileDialog.ShowDialog() == DialogResult.OK)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, nFileDialog.FilePath);
				GStream* ptr3;
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
					ptr3 = <Module>.GFileSystem.OpenWrite(ref <Module>.FS, ptr2, null);
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
				GBaseString<char>* ptr4 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, nFileDialog.FilePath);
				GStream* ptr6;
				try
				{
					uint num2 = (uint)(*<Module>.GBaseString<char>.SetExtension(ptr4, (sbyte*)(&<Module>.??_C@_03PFCKMFAK@sce?$AA@)));
					sbyte* ptr5;
					if (num2 != 0u)
					{
						ptr5 = num2;
					}
					else
					{
						ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					ptr6 = <Module>.GFileSystem.OpenWrite(ref <Module>.FS, ptr5, null);
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
				GBaseString<char> gBaseString<char>3;
				if (ptr3 == null)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 1315, (sbyte*)(&<Module>.??_C@_0CC@BFOKHLGJ@NWorkshop?3?3NMainForm?3?3SaveScript@));
					GBaseString<char>* ptr7 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, nFileDialog.FilePath);
					try
					{
						<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BC@OMEJDKEE@Couldn?8t?5write?5?$CFs?$AA@), *ptr7);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
						throw;
					}
				}
				GBaseString<char>* ptr8;
				try
				{
					if (ptr6 != null)
					{
						goto IL_188;
					}
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 1317, (sbyte*)(&<Module>.??_C@_0CC@BFOKHLGJ@NWorkshop?3?3NMainForm?3?3SaveScript@));
					ptr8 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>4, nFileDialog.FilePath);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
				try
				{
					<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BC@OMEJDKEE@Couldn?8t?5write?5?$CFs?$AA@), *<Module>.GBaseString<char>.SetExtension(ptr8, (sbyte*)(&<Module>.??_C@_03PFCKMFAK@sce?$AA@)));
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
					throw;
				}
				IL_188:
				try
				{
					<Module>.GEditorWorld.SaveScriptEntities(this.World, ptr3, ptr6);
					object arg_1A1_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, *(*(int*)ptr3));
					object arg_1AC_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, *(*(int*)ptr6));
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
					throw;
				}
			}
			try
			{
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
				throw;
			}
		}

		private unsafe void UpdateKey(long time, int keycode)
		{
			if (this.KeyDragMode == 0)
			{
				long num = *(keycode * 8 + ref this.KeyTimes);
				long num2 = time - num;
				long lastUpdate = this.LastUpdate;
				long num3;
				if (lastUpdate > num)
				{
					num3 = lastUpdate - num;
				}
				else
				{
					num3 = 0L;
				}
				GWorld* gameDebugWorld = this.GameDebugWorld;
				GWorld* ptr;
				if (gameDebugWorld != null)
				{
					ptr = gameDebugWorld;
				}
				else
				{
					ptr = (GWorld*)this.World;
				}
				switch (keycode)
				{
				case 33:
					<Module>.GWorld.CameraZoom(ptr, (float)((double)(num2 - num3) * 2E-05));
					break;
				case 34:
					<Module>.GWorld.CameraRotate(ptr, (float)((double)(num2 - num3) * 1E-06), 0f);
					break;
				case 35:
					<Module>.GWorld.CameraRotate(ptr, 0f, (float)((double)(num2 - num3) * 1E-06));
					break;
				case 36:
					<Module>.GWorld.CameraRotate(ptr, 0f, (float)((double)(num3 - num2) * 1E-06));
					break;
				case 37:
					<Module>.GWorld.CameraMove(ptr, 0f, (float)((double)(num3 - num2) * 2E-05));
					break;
				case 38:
					<Module>.GWorld.CameraMove(ptr, (float)((double)(num2 - num3) * 2E-05), 0f);
					break;
				case 39:
					<Module>.GWorld.CameraMove(ptr, 0f, (float)((double)(num2 - num3) * 2E-05));
					break;
				case 40:
					<Module>.GWorld.CameraMove(ptr, (float)((double)(num3 - num2) * 2E-05), 0f);
					break;
				case 45:
					<Module>.GWorld.CameraZoom(ptr, (float)((double)(num3 - num2) * 2E-05));
					break;
				case 46:
					<Module>.GWorld.CameraRotate(ptr, (float)((double)(num3 - num2) * 1E-06), 0f);
					break;
				}
				this.MinimapViewportNeedsUpdate = true;
			}
		}

		private unsafe void SetEditorMode(int mode)
		{
			if (this.EditorMode != mode)
			{
				base.SuspendLayout();
				bool flag = false;
				switch (this.EditorMode)
				{
				case 1:
					this.CancelDepressedDrag(true);
					this.panSideBar.Controls.Remove(this.VertexToolContainer);
					this.panSideBar.Controls.Remove(this.VertexMinimap);
					if (this.World != null)
					{
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *this.BrushCursor, *(*(int*)<Module>.Scene + 264));
					}
					break;
				case 2:
				{
					this.panSideBar.Controls.Remove(this.TerrainToolContainer);
					this.panSideBar.Controls.Remove(this.TerrainFileContainer);
					this.panSideBar.Controls.Remove(this.TerrainMinimap);
					GEditorWorld* world = this.World;
					if (world != null)
					{
						<Module>.GEditorWorld.ShowInvertedSelection(world, false);
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *this.BrushCursor, *(*(int*)<Module>.Scene + 264));
					}
					break;
				}
				case 3:
					this.panSideBar.Controls.Remove(this.RoadFileContainer);
					this.panSideBar.Controls.Remove(this.RoadToolContainer);
					this.panSideBar.Controls.Remove(this.RoadsMinimap);
					this.CurrentEntityToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 4:
					this.panSideBar.Controls.Remove(this.DecalFileContainer);
					this.panSideBar.Controls.Remove(this.DecalToolContainer);
					this.panSideBar.Controls.Remove(this.DecalsMinimap);
					this.CurrentEntityToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 5:
					this.panSideBar.Controls.Remove(this.LakeToolContainer);
					this.panSideBar.Controls.Remove(this.LakeFileContainer);
					this.panSideBar.Controls.Remove(this.LakeMinimap);
					this.CurrentEntityToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 6:
					this.panSideBar.Controls.Remove(this.RiverToolContainer);
					this.panSideBar.Controls.Remove(this.RiverFileContainer);
					this.panSideBar.Controls.Remove(this.RiverMinimap);
					this.CurrentEntityToolbar = null;
					this.CurrentScriptEnittyToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 7:
					this.panSideBar.Controls.Remove(this.ObjectFileContainer);
					this.panSideBar.Controls.Remove(this.ObjectToolContainer);
					this.panSideBar.Controls.Remove(this.ObjectsMinimap);
					this.CurrentEntityToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 8:
				{
					this.CurrentEntityToolbar = null;
					GEditorWorld* world2 = this.World;
					if (world2 != null)
					{
						int num = <Module>.GHeap<GWWirePoint>.GetNext(world2 + 3112 / sizeof(GEditorWorld), -1);
						if (num >= 0)
						{
							do
							{
								<Module>.GWorld.UpdateWirePoint(this.World, num, false);
								num = <Module>.GHeap<GWWirePoint>.GetNext(this.World + 3112 / sizeof(GEditorWorld), num);
							}
							while (num >= 0);
						}
					}
					break;
				}
				case 9:
					this.panSideBar.Controls.Remove(this.BuildingPropertiesContainer);
					this.panSideBar.Controls.Remove(this.BuildingFileContainer);
					this.panSideBar.Controls.Remove(this.BuildingToolContainer);
					this.panSideBar.Controls.Remove(this.BuildingMinimap);
					this.CurrentEntityToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 10:
					this.panSideBar.Controls.Remove(this.UnitFileContainer);
					this.panSideBar.Controls.Remove(this.UnitPropertiesContainer);
					this.panSideBar.Controls.Remove(this.PlayerContainer);
					this.panSideBar.Controls.Remove(this.UnitToolContainer);
					this.panSideBar.Controls.Remove(this.UnitMinimap);
					this.CurrentEntityToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 11:
					this.panSideBar.Controls.Remove(this.SoundFileContainer);
					this.panSideBar.Controls.Remove(this.SoundToolContainer);
					this.panSideBar.Controls.Remove(this.SoundMinimap);
					this.CurrentEntityToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 12:
					this.panSideBar.Controls.Remove(this.EffectFileContainer);
					this.panSideBar.Controls.Remove(this.EffectToolContainer);
					this.panSideBar.Controls.Remove(this.EffectMinimap);
					this.CurrentEntityToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 13:
					this.panSideBar.Controls.Remove(this.WeatherToolContainer);
					break;
				case 14:
					this.panSideBar.Controls.Remove(this.OptionToolContainer);
					break;
				case 15:
					this.panSideBar.Controls.Remove(this.SectorToolContainer);
					if (this.World != null)
					{
						this.InitMinimap();
						<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(this.World, this.LastCameraType);
						<Module>.GWorld.SetCamera(this.World, this.LastCamera);
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *this.ParcelSelection, *(*(int*)<Module>.Scene + 264));
					}
					this.CurrentScriptEnittyToolbar = null;
					break;
				case 16:
				{
					GEditorWorld* world3 = this.World;
					if (world3 != null && <Module>.GEditorWorld.GetCameraCurveAlwaysDraw(world3) == null)
					{
						this.CameraCurveProps.RemoveCameraViewPort();
					}
					this.panSideBar.Controls.Remove(this.CameraCurveToolContainer);
					this.panSideBar.Controls.Remove(this.CameraCurveMinimap);
					this.panSideBar.Controls.Remove(this.CameraCurvePropsContainer);
					this.CurrentEntityToolbar = null;
					this.CurrentScriptEnittyToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				}
				case 17:
					this.panSideBar.Controls.Remove(this.PathToolContainer);
					this.panSideBar.Controls.Remove(this.PathPropsContainer);
					this.panSideBar.Controls.Remove(this.PathMinimap);
					this.CurrentEntityToolbar = null;
					this.CurrentScriptEnittyToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 18:
					this.panSideBar.Controls.Remove(this.LocationToolContainer);
					this.panSideBar.Controls.Remove(this.LocationPropsContainer);
					this.panSideBar.Controls.Remove(this.LocationMinimap);
					this.CurrentEntityToolbar = null;
					this.CurrentScriptEnittyToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 19:
					this.panSideBar.Controls.Remove(this.UnitGroupPropsContainer);
					this.panSideBar.Controls.Remove(this.UnitGroupMinimap);
					this.CurrentEntityToolbar = null;
					this.CurrentScriptEnittyToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
						<Module>.GEditorWorld.ShowAIGroups(this.World);
					}
					break;
				case 20:
					this.panSideBar.Controls.Remove(this.ObjectiveToolContainer);
					this.panSideBar.Controls.Remove(this.ObjectivePropsContainer);
					this.CurrentScriptEnittyToolbar = null;
					break;
				case 21:
					this.panSideBar.Controls.Remove(this.NavPointToolContainer);
					this.panSideBar.Controls.Remove(this.NavPointsMinimap);
					this.CurrentEntityToolbar = null;
					if (this.World != null)
					{
						this.LeaveEntityMode();
					}
					break;
				case 22:
					base.Controls.Remove(this.tbDebug);
					base.Controls.Add(this.tbMain);
					flag = true;
					break;
				}
				this.EditorMode = mode;
				this.CurrentMinimap = null;
				byte @checked = (mode == 1) ? 1 : 0;
				this.menuModeVertex.Checked = (@checked != 0);
				byte checked2 = (this.EditorMode == 2) ? 1 : 0;
				this.menuModePaint.Checked = (checked2 != 0);
				byte checked3 = (this.EditorMode == 3) ? 1 : 0;
				this.menuModeRoad.Checked = (checked3 != 0);
				byte checked4 = (this.EditorMode == 4) ? 1 : 0;
				this.menuModeDecal.Checked = (checked4 != 0);
				byte checked5 = (this.EditorMode == 5) ? 1 : 0;
				this.menuModeLake.Checked = (checked5 != 0);
				byte checked6 = (this.EditorMode == 6) ? 1 : 0;
				this.menuModeRiver.Checked = (checked6 != 0);
				byte checked7 = (this.EditorMode == 16) ? 1 : 0;
				this.menuModeCameraCurve.Checked = (checked7 != 0);
				byte checked8 = (this.EditorMode == 7) ? 1 : 0;
				this.menuModeDoodad.Checked = (checked8 != 0);
				byte checked9 = (this.EditorMode == 8) ? 1 : 0;
				this.menuModeWire.Checked = (checked9 != 0);
				byte checked10 = (this.EditorMode == 9) ? 1 : 0;
				this.menuModeBuilding.Checked = (checked10 != 0);
				byte checked11 = (this.EditorMode == 10) ? 1 : 0;
				this.menuModeUnit.Checked = (checked11 != 0);
				byte checked12 = (this.EditorMode == 11) ? 1 : 0;
				this.menuModeAmbient.Checked = (checked12 != 0);
				byte checked13 = (this.EditorMode == 12) ? 1 : 0;
				this.menuModeEffect.Checked = (checked13 != 0);
				byte checked14 = (this.EditorMode == 15) ? 1 : 0;
				this.menuModeSectors.Checked = (checked14 != 0);
				byte checked15 = (this.EditorMode == 17) ? 1 : 0;
				this.menuModePaths.Checked = (checked15 != 0);
				byte checked16 = (this.EditorMode == 18) ? 1 : 0;
				this.menuModeLocations.Checked = (checked16 != 0);
				byte checked17 = (this.EditorMode == 19) ? 1 : 0;
				this.menuModeUnitGroup.Checked = (checked17 != 0);
				this.tbMain.SetItemPushed(this.EditorMode, true);
				GEditorWorld* world4 = this.World;
				if (world4 == null && this.GameDebugWorld == null)
				{
					base.ResumeLayout(false);
				}
				else
				{
					if (world4 != null)
					{
						<Module>.?SetEditorMode@GEditorWorld@@$$FQAEXW4GEditorMode@@@Z(world4, this.EditorMode);
					}
					switch (this.EditorMode)
					{
					case 1:
						this.VertexTools.SelectionType = *(int*)this.Terraformer;
						this.VertexMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.VertexMinimap);
						this.panSideBar.Controls.Add(this.VertexToolContainer);
						this.CurrentMinimap = this.VertexMinimap;
						break;
					case 2:
						this.TerrainFilePicker.World = this.World;
						this.TerrainMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.TerrainMinimap);
						this.panSideBar.Controls.Add(this.TerrainFileContainer);
						this.panSideBar.Controls.Add(this.TerrainToolContainer);
						this.CurrentMinimap = this.TerrainMinimap;
						this.TerrainFilePicker.UpdateLayerList(-1, 0);
						<Module>.GEditorWorld.ShowInvertedSelection(this.World, true);
						break;
					case 3:
						this.RoadsMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.RoadsMinimap);
						this.panSideBar.Controls.Add(this.RoadFileContainer);
						this.panSideBar.Controls.Add(this.RoadToolContainer);
						this.CurrentMinimap = this.RoadsMinimap;
						this.CurrentEntityToolbar = this.RoadTools;
						this.EntityType = 9;
						break;
					case 4:
						this.DecalsMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.DecalsMinimap);
						this.panSideBar.Controls.Add(this.DecalFileContainer);
						this.panSideBar.Controls.Add(this.DecalToolContainer);
						this.CurrentMinimap = this.DecalsMinimap;
						this.CurrentEntityToolbar = this.DecalTools;
						this.EntityType = 7;
						break;
					case 5:
						this.LakeMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.LakeMinimap);
						this.panSideBar.Controls.Add(this.LakeFileContainer);
						this.panSideBar.Controls.Add(this.LakeToolContainer);
						this.CurrentMinimap = this.LakeMinimap;
						this.CurrentEntityToolbar = this.LakeTools;
						this.EntityType = 6;
						<Module>.GEditorWorld.UpdateWaters(this.World);
						if (<Module>.GWorld.GetBlockMapMode(this.World) != null)
						{
							<Module>.GWorld.UpdateWaterMap(this.World);
						}
						break;
					case 6:
						this.RiverMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.RiverMinimap);
						this.panSideBar.Controls.Add(this.RiverFileContainer);
						this.panSideBar.Controls.Add(this.RiverToolContainer);
						this.CurrentMinimap = this.RiverMinimap;
						this.CurrentEntityToolbar = this.RiverTools;
						this.EntityType = 11;
						<Module>.GEditorWorld.UpdateWaters(this.World);
						if (<Module>.GWorld.GetBlockMapMode(this.World) != null)
						{
							<Module>.GWorld.UpdateWaterMap(this.World);
						}
						break;
					case 7:
						this.ObjectsMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.ObjectsMinimap);
						this.panSideBar.Controls.Add(this.ObjectFileContainer);
						this.panSideBar.Controls.Add(this.ObjectToolContainer);
						this.CurrentMinimap = this.ObjectsMinimap;
						this.CurrentEntityToolbar = this.ObjectTools;
						this.EntityType = 1;
						break;
					case 8:
					{
						int num2 = <Module>.GHeap<GWWirePoint>.GetNext(this.World + 3112 / sizeof(GEditorWorld), -1);
						if (num2 >= 0)
						{
							do
							{
								<Module>.GWorld.UpdateWirePoint(this.World, num2, true);
								num2 = <Module>.GHeap<GWWirePoint>.GetNext(this.World + 3112 / sizeof(GEditorWorld), num2);
							}
							while (num2 >= 0);
						}
						break;
					}
					case 9:
						this.BuildingMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.BuildingMinimap);
						this.panSideBar.Controls.Add(this.BuildingFileContainer);
						this.panSideBar.Controls.Add(this.BuildingPropertiesContainer);
						this.panSideBar.Controls.Add(this.BuildingToolContainer);
						this.CurrentMinimap = this.BuildingMinimap;
						this.CurrentEntityToolbar = this.BuildingTools;
						this.EntityType = 2;
						break;
					case 10:
						this.UnitMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.UnitMinimap);
						this.panSideBar.Controls.Add(this.UnitFileContainer);
						this.panSideBar.Controls.Add(this.UnitPropertiesContainer);
						this.panSideBar.Controls.Add(this.PlayerContainer);
						this.panSideBar.Controls.Add(this.UnitToolContainer);
						this.CurrentMinimap = this.UnitMinimap;
						this.CurrentEntityToolbar = this.UnitTools;
						this.EntityType = 3;
						break;
					case 11:
						this.SoundMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.SoundMinimap);
						this.panSideBar.Controls.Add(this.SoundFileContainer);
						this.panSideBar.Controls.Add(this.SoundToolContainer);
						this.CurrentMinimap = this.SoundMinimap;
						this.CurrentEntityToolbar = this.SoundTools;
						this.EntityType = 5;
						break;
					case 12:
						this.EffectMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.EffectMinimap);
						this.panSideBar.Controls.Add(this.EffectFileContainer);
						this.panSideBar.Controls.Add(this.EffectToolContainer);
						this.CurrentMinimap = this.EffectMinimap;
						this.CurrentEntityToolbar = this.EffectTools;
						this.EntityType = 8;
						break;
					case 13:
						this.WeatherTools.Refresh(this.World);
						this.panSideBar.Controls.Add(this.WeatherToolContainer);
						break;
					case 14:
						this.OptionsTools.Refresh();
						this.OptionsTools.RefreshResourceTree();
						this.panSideBar.Controls.Add(this.OptionToolContainer);
						break;
					case 15:
						this.panSideBar.Controls.Add(this.SectorToolContainer);
						if (!flag)
						{
							this.LastCameraType = <Module>.?GetCameraType@GWorld@@$$FQBE?AW4GCameraType@@XZ(this.World);
							<Module>.GWorld.GetCamera(this.World, this.LastCamera);
						}
						<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(this.World, 1);
						this.SectorSelectionNeedsUpdate = true;
						this.SectorTools.World = this.World;
						this.CurrentScriptEnittyToolbar = this.SectorTools.ScriptEntityTool;
						break;
					case 16:
						this.CameraCurveMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.CameraCurveMinimap);
						this.panSideBar.Controls.Add(this.CameraCurvePropsContainer);
						this.panSideBar.Controls.Add(this.CameraCurveToolContainer);
						this.CurrentMinimap = this.CameraCurveMinimap;
						this.CurrentEntityToolbar = this.CameraCurveTools;
						this.EntityType = 13;
						this.CameraCurveProps.World = this.World;
						this.CurrentScriptEnittyToolbar = this.CameraCurveProps;
						break;
					case 17:
						this.PathMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.PathMinimap);
						this.panSideBar.Controls.Add(this.PathPropsContainer);
						this.panSideBar.Controls.Add(this.PathToolContainer);
						this.CurrentMinimap = this.PathMinimap;
						this.CurrentEntityToolbar = this.PathTools;
						this.EntityType = 15;
						this.PathProps.World = this.World;
						this.CurrentScriptEnittyToolbar = this.PathProps;
						break;
					case 18:
						this.LocationMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.LocationMinimap);
						this.panSideBar.Controls.Add(this.LocationPropsContainer);
						this.panSideBar.Controls.Add(this.LocationToolContainer);
						this.CurrentMinimap = this.LocationMinimap;
						this.CurrentEntityToolbar = this.LocationTools;
						this.EntityType = 17;
						this.LocationProps.World = this.World;
						this.CurrentScriptEnittyToolbar = this.LocationProps;
						break;
					case 19:
						this.UnitGroupMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.UnitGroupMinimap);
						this.panSideBar.Controls.Add(this.UnitGroupPropsContainer);
						this.CurrentMinimap = this.UnitGroupMinimap;
						this.UnitGroupProps.World = this.World;
						this.CurrentScriptEnittyToolbar = this.UnitGroupProps;
						this.EntityType = 4;
						break;
					case 20:
						this.panSideBar.Controls.Add(this.ObjectivePropsContainer);
						this.panSideBar.Controls.Add(this.ObjectiveToolContainer);
						this.EntityType = 0;
						this.ObjectiveProps.World = this.World;
						this.CurrentScriptEnittyToolbar = this.ObjectiveProps;
						break;
					case 21:
						this.NavPointsMinimap.AddToolbox(this.MinimapPanel);
						this.panSideBar.Controls.Add(this.NavPointsMinimap);
						this.panSideBar.Controls.Add(this.NavPointToolContainer);
						this.CurrentMinimap = this.NavPointsMinimap;
						this.CurrentEntityToolbar = this.NavPointTools;
						this.EntityType = 19;
						break;
					case 22:
						base.Controls.Remove(this.tbMain);
						base.Controls.Add(this.tbDebug);
						break;
					}
					this.SetViewType();
					this.LayoutChanged = true;
					this.TileDataValid = false;
					int num3 = *(this.EntityType * 4 + ref this.EntityOperation);
					if (num3 == 2 || num3 == 4)
					{
						this.ResetToolbars();
					}
					this.RefreshMenuAndToolbarItems();
					this.RefreshMinimap();
					this.MinimapViewportNeedsUpdate = true;
					base.ResumeLayout(false);
				}
			}
		}

		private void SetDebugMode(int mode)
		{
			switch (this.DebugMode)
			{
			case 500:
				this.panSideBar.Controls.Remove(this.LoggerContainer);
				this.panSideBar.Controls.Remove(this.LogControlPanel);
				break;
			case 501:
				this.panSideBar.Controls.Remove(this.DUnitsContainer);
				this.panSideBar.Controls.Remove(this.UnitsControlPanel);
				break;
			case 502:
				this.panSideBar.Controls.Remove(this.DUnitGroupsContainer);
				this.panSideBar.Controls.Remove(this.UnitGroupsControlPanel);
				break;
			case 503:
				this.panSideBar.Controls.Remove(this.DTriggersContainer);
				this.panSideBar.Controls.Remove(this.DGVarsContainer);
				this.panSideBar.Controls.Remove(this.TriggersControlPanel);
				break;
			}
			this.CurrentControlPanel = null;
			this.DebugMode = mode;
			this.tbDebug.SetItemPushed(mode, true);
			switch (mode)
			{
			case 500:
				this.LogControlPanel.AddToolbox(this.DControlPanel);
				this.panSideBar.Controls.Add(this.LogControlPanel);
				this.panSideBar.Controls.Add(this.LoggerContainer);
				this.CurrentControlPanel = this.LogControlPanel;
				break;
			case 501:
				this.UnitsControlPanel.AddToolbox(this.DControlPanel);
				this.panSideBar.Controls.Add(this.UnitsControlPanel);
				this.panSideBar.Controls.Add(this.DUnitsContainer);
				this.CurrentControlPanel = this.UnitsControlPanel;
				break;
			case 502:
				this.UnitGroupsControlPanel.AddToolbox(this.DControlPanel);
				this.panSideBar.Controls.Add(this.UnitGroupsControlPanel);
				this.panSideBar.Controls.Add(this.DUnitGroupsContainer);
				this.CurrentControlPanel = this.UnitGroupsControlPanel;
				break;
			case 503:
				this.TriggersControlPanel.AddToolbox(this.DControlPanel);
				this.panSideBar.Controls.Add(this.TriggersControlPanel);
				this.panSideBar.Controls.Add(this.DGVarsContainer);
				this.panSideBar.Controls.Add(this.DTriggersContainer);
				this.CurrentControlPanel = this.TriggersControlPanel;
				break;
			}
		}

		private unsafe void StartPaste()
		{
			if (this.DragMode == 0)
			{
				int entityType = this.EntityType;
				if (entityType != 0)
				{
					if (<Module>.?StartEntityPaste@GEditorWorld@@$$FQAE_NW4GEntityType@@AAUGEntityClipboard@@_N@Z(this.World, entityType, this.EntityClipboard, *(ref this.EntityAlignMove + entityType) != 0) != null)
					{
						this.DragMode = 3;
						$ArrayType$$$BY0BE@W4GEntityOperation@@* ptr = this.EntityType * 4 + ref this.EntityOperation;
						int num = *ptr;
						if (num == 2 || num == 4)
						{
							*ptr = 1;
						}
					}
				}
				else if (this.EditorMode == 1)
				{
					Point mousePosition = Control.MousePosition;
					Point mousePosition2 = Control.MousePosition;
					int num2 = *(int*)this.IViewport + 56;
					GRay gRay;
					float num3;
					float num4;
					float num5;
					<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, mousePosition2.X, mousePosition.Y, *num2), ref num3, ref num4, ref num5);
					<Module>.GEditorWorld.StartPaste(this.World, this.Clipboard, <Module>.fround(num3), <Module>.fround(num5), 8191);
					this.DragMode = 4;
				}
			}
		}

		private unsafe void StartEntityPreCreate()
		{
			this.CancelDepressedDrag(true);
			this.ResetToolbarsToPlace();
			if (this.DragMode == 0)
			{
				int entityType = this.EntityType;
				uint num = (uint)(*(*(entityType * 4 + ref this.EntityName)));
				sbyte* ptr;
				if (num != 0u)
				{
					ptr = num;
				}
				else
				{
					ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				if (<Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(this.World, entityType, ptr, *(ref this.EntityAlignMove + entityType) != 0, *(ref this.EntityRandomAngle + entityType) != 0) != null)
				{
					*(this.EntityType * 4 + ref this.EntityOperation) = 2;
					this.DragMode = 1;
				}
			}
		}

		private unsafe void StartEntityPreCreateNode()
		{
			this.CancelDepressedDrag(true);
			if (this.DragMode == 0)
			{
				switch (this.EntityType)
				{
				case 9:
				{
					this.RoadTools.ResetToPlaceNode();
					int entityType = this.EntityType;
					uint num = (uint)(*(*(entityType * 4 + ref this.EntityName)));
					sbyte* ptr;
					if (num != 0u)
					{
						ptr = num;
					}
					else
					{
						ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					if (<Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(this.World, 10, ptr, *(ref this.EntityAlignMove + entityType) != 0, *(ref this.EntityRandomAngle + entityType) != 0) != null)
					{
						this.DragMode = 2;
					}
					break;
				}
				case 11:
				{
					this.RiverTools.ResetToPlaceNode();
					int entityType2 = this.EntityType;
					uint num2 = (uint)(*(*(entityType2 * 4 + ref this.EntityName)));
					sbyte* ptr2;
					if (num2 != 0u)
					{
						ptr2 = num2;
					}
					else
					{
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					if (<Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(this.World, 12, ptr2, *(ref this.EntityAlignMove + entityType2) != 0, *(ref this.EntityRandomAngle + entityType2) != 0) != null)
					{
						this.DragMode = 2;
					}
					break;
				}
				case 13:
				{
					this.CameraCurveTools.ResetToPlaceNode();
					int entityType3 = this.EntityType;
					uint num3 = (uint)(*(*(entityType3 * 4 + ref this.EntityName)));
					sbyte* ptr3;
					if (num3 != 0u)
					{
						ptr3 = num3;
					}
					else
					{
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					if (<Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(this.World, 14, ptr3, *(ref this.EntityAlignMove + entityType3) != 0, *(ref this.EntityRandomAngle + entityType3) != 0) != null)
					{
						this.DragMode = 2;
					}
					break;
				}
				case 15:
				{
					this.PathTools.ResetToPlaceNode();
					int entityType4 = this.EntityType;
					uint num4 = (uint)(*(*(entityType4 * 4 + ref this.EntityName)));
					sbyte* ptr4;
					if (num4 != 0u)
					{
						ptr4 = num4;
					}
					else
					{
						ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					if (<Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(this.World, 16, ptr4, *(ref this.EntityAlignMove + entityType4) != 0, *(ref this.EntityRandomAngle + entityType4) != 0) != null)
					{
						this.DragMode = 2;
					}
					break;
				}
				case 17:
				{
					this.LocationTools.ResetToPlaceNode();
					int entityType5 = this.EntityType;
					uint num5 = (uint)(*(*(entityType5 * 4 + ref this.EntityName)));
					sbyte* ptr5;
					if (num5 != 0u)
					{
						ptr5 = num5;
					}
					else
					{
						ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					if (<Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(this.World, 18, ptr5, *(ref this.EntityAlignMove + entityType5) != 0, *(ref this.EntityRandomAngle + entityType5) != 0) != null)
					{
						this.DragMode = 2;
					}
					break;
				}
				}
			}
		}

		private void LeaveEntityMode()
		{
			this.CancelDepressedDrag(true);
			this.EntityType = 0;
		}

		private unsafe void SetViewType()
		{
			int num = 0;
			if ((*(ref <Module>.Options + 68) & 1) != 0)
			{
				num = 34;
			}
			if ((*(ref <Module>.Options + 68) & 2) != 0)
			{
				num |= 1;
			}
			if (*(ref <Module>.Options + 72) == 1)
			{
				num |= 8;
			}
			else if (*(ref <Module>.Options + 72) == 2)
			{
				num |= 4;
			}
			if (*(ref <Module>.Options + 78) != 0)
			{
				num |= 128;
			}
			int editorMode = this.EditorMode;
			if (editorMode == 2)
			{
				int num2 = this.propPaintType;
				if (num2 == 13 || num2 == 14)
				{
					num |= 32;
				}
			}
			if (editorMode == 15)
			{
				num |= 32;
			}
			GEditorWorld* world = this.World;
			if (world != null)
			{
				<Module>.GWorld.SetTerrainViewType(world, num);
			}
		}

		private unsafe void InitUI()
		{
			if (<Module>.Scene != null)
			{
				GHandle<11> gHandle<11>;
				int num = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, ref gHandle<11>, 0, *(*(int*)<Module>.Scene + 256));
				cpblk(this.BrushCursor, num, 4);
				GHandle<11> gHandle<11>2;
				int num2 = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, ref gHandle<11>2, 0, *(*(int*)<Module>.Scene + 256));
				cpblk(this.ParcelSelection, num2, 4);
			}
			this.toolboxOptions_OptionsChanged();
			int editorMode = this.EditorMode;
			this.EditorMode = 1;
			this.VertexTools.SelectionType = 0;
			this.VertexTools.SetBrushSize1(this.BrushSize);
			this.VertexTools.SetBrushSize2(0);
			this.VertexTools.SetBrushPressure(this.BrushPressure);
			this.VertexTools.AdditiveMode = (*(byte*)(this.Terraformer + 8 / sizeof(GTerraformer)) != 0);
			this.VertexTools.LockObjectHeights = (*(byte*)(this.Terraformer + 9 / sizeof(GTerraformer)) != 0);
			this.EditorMode = 2;
			this.TerrainTools.SetBrushSize1(this.BrushSize);
			this.TerrainTools.SetBrushSize2(0);
			this.TerrainTools.SetBrushPressure(this.BrushPressure);
			this.EditorMode = editorMode;
			this.VertexTools.BrushType = this.propBrushType;
			this.VertexTools.FalloffType = this.VertexFalloffType;
			this.TerrainTools.PaintType = this.propPaintType;
			this.VertexTools.InvertEnable = false;
			this.TerrainTools.FillEnable = false;
			this.PlayerTools.InitPlayersGrid((GWorld*)this.World);
			<Module>.GEditorWorld.ClearParcelSelection(this.World);
		}

		private void UpdateBrushSliders()
		{
			int editorMode = this.EditorMode;
			if (editorMode == 1)
			{
				this.VertexTools.SetBrushSize1(this.BrushSize);
				this.VertexTools.SetBrushSize2(this.BrushSize2);
				this.VertexTools.SetBrushPressure(this.BrushPressure);
				this.VertexTools.SetBrushHeight(this.BrushHeight);
			}
			else if (editorMode == 2)
			{
				this.TerrainTools.SetBrushSize1(this.BrushSize);
				this.TerrainTools.SetBrushSize2(this.BrushSize2);
				this.TerrainTools.SetBrushPressure(this.BrushPressure);
			}
		}

		private unsafe void SetAffectedLayer(int value)
		{
			*(int*)(this.Terraformer + 12 / sizeof(GTerraformer)) = value;
		}

		private void ResetToolbars()
		{
			ToolboxEntities currentEntityToolbar = this.CurrentEntityToolbar;
			if (currentEntityToolbar != null)
			{
				currentEntityToolbar.ResetToMove();
			}
		}

		private void ResetToolbarsToPlace()
		{
			ToolboxEntities currentEntityToolbar = this.CurrentEntityToolbar;
			if (currentEntityToolbar != null)
			{
				currentEntityToolbar.ResetToPlace();
			}
		}

		private unsafe void CompleteDepressedDrag(int m_x, int m_y)
		{
			int dragMode = this.DragMode;
			if (dragMode != 0 && dragMode < 6)
			{
				switch (dragMode)
				{
				case 1:
				case 2:
				{
					GIViewport* iViewport = this.IViewport;
					GRay gRay;
					if (<Module>.GEditorWorld.CompleteEntityPlace(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay, m_x, m_y, *(*(int*)iViewport + 56))) >= 0)
					{
						int entityType = this.EntityType;
						$ArrayType$$$BY0BE@W4GEntityOperation@@* ptr = entityType * 4 + ref this.EntityOperation;
						if (*ptr == 2 && (entityType == 9 || entityType == 11 || entityType == 13 || entityType == 15 || entityType == 17))
						{
							*ptr = 4;
						}
					}
					break;
				}
				case 3:
					<Module>.GEditorWorld.CompleteEntityPaste(this.World);
					break;
				case 4:
					<Module>.GEditorWorld.CompletePaste(this.World, this.Clipboard);
					this.propBrushType = 0;
					this.VertexTools.EmulatePush(0);
					this.VertexTools.EmulateUp(0);
					break;
				case 5:
					<Module>.GEditorWorld.AddPolySelectPoint(this.World);
					return;
				}
				this.DragMode = 0;
				this.RefreshMenuAndToolbarItems();
				if (this.EntityType == 3)
				{
					this.MinimapUnitsNeedUpdate = true;
				}
				else
				{
					this.RefreshMinimap();
				}
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private unsafe bool CancelDepressedDrag([MarshalAs(UnmanagedType.U1)] bool reset)
		{
			int dragMode = this.DragMode;
			if (dragMode != 0 && dragMode < 6)
			{
				switch (dragMode)
				{
				case 1:
				case 2:
					<Module>.GEditorWorld.CancelEntityPlace(this.World);
					if (reset)
					{
						*(this.EntityType * 4 + ref this.EntityOperation) = 1;
						this.ResetToolbars();
					}
					this.DragMode = 0;
					this.RefreshMenuAndToolbarItems();
					return true;
				case 3:
					<Module>.GEditorWorld.CancelEntityPaste(this.World);
					this.DragMode = 0;
					this.RefreshMenuAndToolbarItems();
					return true;
				case 4:
					<Module>.GEditorWorld.CancelPaste(this.World, this.Clipboard);
					this.propBrushType = 0;
					this.DragMode = 0;
					return true;
				case 5:
					<Module>.GEditorWorld.FinishTerraforming(this.World);
					this.SelectionActive = true;
					this.VertexTools.InvertEnable = true;
					this.TerrainTools.FillEnable = true;
					this.DragMode = 0;
					return true;
				}
			}
			this.RefreshMenuAndToolbarItems();
			return false;
		}

		private unsafe void CompletePressedDrag(int m_x, int m_y)
		{
			int dragMode = this.DragMode;
			if (dragMode != 0 && dragMode >= 6)
			{
				float num;
				float num3;
				if (this.GameDebugWorld != null)
				{
					GIViewport* iViewport = this.IViewport;
					GRay gRay;
					float num2;
					<Module>.GWorld.GetTarget(this.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay, m_x, m_y, *(*(int*)iViewport + 56)), ref num, ref num2, ref num3);
				}
				else
				{
					GIViewport* iViewport = this.IViewport;
					float num2;
					GRay gRay2;
					<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay2, m_x, m_y, *(*(int*)iViewport + 56)), ref num, ref num2, ref num3);
				}
				switch (this.DragMode)
				{
				case 7:
				{
					<Module>.GEditorWorld.FinishTerraforming(this.World);
					int num4 = *(int*)this.Terraformer;
					if (num4 == 14)
					{
						this.TileDataValid = false;
						this.UpdateLayerUsage((int)((double)num), (int)((double)num3));
					}
					else if (num4 >= 20)
					{
						this.SelectionActive = true;
						this.VertexTools.InvertEnable = true;
						this.TerrainTools.FillEnable = true;
					}
					break;
				}
				case 9:
				{
					GIViewport* iViewport = this.IViewport;
					GRay gRay3;
					<Module>.GEditorWorld.CompleteEntityMove(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay3, m_x, m_y, *(*(int*)iViewport + 56)));
					ScriptEditorForm scriptEditorFormInstance = this.ScriptEditorFormInstance;
					if (scriptEditorFormInstance != null)
					{
						scriptEditorFormInstance.EditorsChanged();
					}
					break;
				}
				case 10:
					<Module>.GEditorWorld.CompleteEntityLift(this.World);
					break;
				case 11:
					if (this.EntityType != 7)
					{
						<Module>.GEditorWorld.CompleteEntityRotate(this.World);
					}
					break;
				case 12:
					<Module>.GEditorWorld.CompleteEntityPointRotate(this.World);
					break;
				case 13:
					<Module>.GEditorWorld.CompleteEntityTilt(this.World);
					break;
				case 14:
				case 15:
				{
					<Module>.GWorld.ClearBoxSelection(this.World);
					int num5 = (this.DragMode == 15) ? 5 : 16;
					int num6 = *(int*)this.World + 20;
					GIViewport* iViewport = this.IViewport;
					GPyramid gPyramid;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GPyramid modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32), this.World, this.EntityType, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), iViewport, ref gPyramid, this.DragMX, this.DragMY, m_x, m_y, *(*(int*)iViewport + 60)), num5, *num6);
					ToolboxScriptEntities currentScriptEnittyToolbar = this.CurrentScriptEnittyToolbar;
					if (currentScriptEnittyToolbar != null)
					{
						currentScriptEnittyToolbar.UpdateHilighting();
					}
					break;
				}
				case 16:
					<Module>.GEditorWorld.CompleteEntityScale(this.World);
					break;
				case 17:
					switch (this.EntityType)
					{
					case 9:
					{
						GIViewport* iViewport = this.IViewport;
						GRay gRay4;
						<Module>.GEditorWorld.CompleteEntityPlaceRoadNode(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay4, m_x, m_y, *(*(int*)iViewport + 56)));
						break;
					}
					case 11:
					{
						GIViewport* iViewport = this.IViewport;
						GRay gRay5;
						<Module>.GEditorWorld.CompleteEntityPlaceRiverNode(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay5, m_x, m_y, *(*(int*)iViewport + 56)));
						break;
					}
					case 13:
					{
						GIViewport* iViewport = this.IViewport;
						GRay gRay6;
						<Module>.GEditorWorld.CompleteEntityPlaceCameraCurveNode(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay6, m_x, m_y, *(*(int*)iViewport + 56)));
						break;
					}
					case 15:
					{
						GIViewport* iViewport = this.IViewport;
						GRay gRay7;
						<Module>.GEditorWorld.CompleteEntityPlacePathNode(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay7, m_x, m_y, *(*(int*)iViewport + 56)));
						break;
					}
					case 17:
					{
						GIViewport* iViewport = this.IViewport;
						GRay gRay8;
						<Module>.GEditorWorld.CompleteEntityPlaceLocationVertex(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay8, m_x, m_y, *(*(int*)iViewport + 56)));
						break;
					}
					}
					break;
				case 18:
				case 19:
				case 20:
				case 21:
				case 27:
				case 28:
					<Module>.ShowCursor(1);
					break;
				case 24:
				{
					GIViewport* iViewport = this.IViewport;
					GRay gRay9;
					int num7 = <Module>.GWorld.GetTargetWirePoint(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay9, m_x, m_y, *(*(int*)iViewport + 56)));
					GEditorWorld* world = this.World;
					int num8 = *(int*)(world + 3104 / sizeof(GEditorWorld));
					if (num8 >= 0 && num7 >= 0 && num7 != num8)
					{
						<Module>.GWorld.CreateWire(world, num8, num7, 0.35f, 0.025f);
						<Module>.GWorld.SelectWirePoint(this.World, num7, 48);
					}
					break;
				}
				case 25:
					this.SectorSelectionNeedsUpdate = true;
					break;
				}
				int dragMode2 = this.DragMode;
				if (dragMode2 != 19 && dragMode2 != 18 && this.EntityType != 3)
				{
					this.RefreshMinimap();
				}
				dragMode = this.DragMode;
				if (dragMode != 19 && dragMode != 18 && this.EntityType == 3)
				{
					this.MinimapUnitsNeedUpdate = true;
				}
				this.panMainViewport.Capture = false;
				this.DragMode = 0;
				this.RefreshMenuAndToolbarItems();
			}
		}

		private unsafe void RefreshTerraformer()
		{
			if (this.BrushHeight != null)
			{
				float* brushHeight = this.BrushHeight;
				*(float*)(this.Terraformer + 48 / sizeof(GTerraformer)) = *brushHeight;
			}
			if (this.BrushPressure != null)
			{
				float* brushPressure = this.BrushPressure;
				*(float*)(this.Terraformer + 44 / sizeof(GTerraformer)) = *brushPressure;
			}
			if (this.BrushSize != null)
			{
				float* brushSize = this.BrushSize;
				*(float*)(this.Terraformer + 32 / sizeof(GTerraformer)) = *brushSize;
			}
			if (this.BrushSize2 != null)
			{
				float* brushSize2 = this.BrushSize2;
				*(float*)(this.Terraformer + 40 / sizeof(GTerraformer)) = *brushSize2;
			}
			GTerraformer* terraformer = this.Terraformer;
			*(float*)(terraformer + 36 / sizeof(GTerraformer)) = *(float*)(terraformer + 40 / sizeof(GTerraformer)) * *(float*)(terraformer + 32 / sizeof(GTerraformer)) * 0.01f;
			int editorMode = this.EditorMode;
			if (editorMode != 1)
			{
				if (editorMode == 2)
				{
					*(int*)this.Terraformer = this.propPaintType;
				}
			}
			else
			{
				*(int*)this.Terraformer = this.propBrushType;
			}
			GTerraformer* terraformer2 = this.Terraformer;
			if (*(int*)terraformer2 < 20)
			{
				*(int*)(terraformer2 + 4 / sizeof(GTerraformer)) = this.VertexFalloffType;
			}
			else
			{
				*(int*)(terraformer2 + 4 / sizeof(GTerraformer)) = this.SelectionFalloffType;
			}
		}

		private void ResetTerrainTool()
		{
			int num = this.propPaintType;
			if (num == 15 || num == 16 || num == 17)
			{
				this.TerrainTools.EmulatePush(0);
				this.TerrainTools.EmulateUp(0);
			}
		}

		private void EnableMenuAndToolbarItems([MarshalAs(UnmanagedType.U1)] bool enable)
		{
			this.menuFileSave.Enabled = enable;
			this.menuFileSaveAs.Enabled = enable;
			this.menuEdit.Enabled = enable;
			this.menuToolsScriptEditor.Enabled = enable;
			this.tbMain.SetItemEnable(202, enable);
			this.tbMain.SetItemEnable(203, enable);
			this.tbMain.SetItemEnable(204, enable);
			this.tbMain.SetItemEnable(205, enable);
			this.tbMain.SetItemEnable(206, enable);
			this.tbMain.SetItemEnable(207, enable);
			this.tbMain.SetItemEnable(208, enable);
			this.tbMain.SetItemEnable(209, enable);
			this.tbMain.SetItemEnable(210, enable);
			this.tbMain.SetItemEnable(211, enable);
			this.menuModeVertex.Enabled = enable;
			this.menuModePaint.Enabled = enable;
			this.menuModeRoad.Enabled = enable;
			this.menuModeDecal.Enabled = enable;
			this.menuModeLake.Enabled = enable;
			this.menuModeRiver.Enabled = enable;
			this.menuModeCameraCurve.Enabled = enable;
			this.menuModeDoodad.Enabled = enable;
			this.menuModeWire.Enabled = enable;
			this.menuModeBuilding.Enabled = enable;
			this.menuModeUnit.Enabled = enable;
			this.menuModeAmbient.Enabled = enable;
			this.menuModeEffect.Enabled = enable;
			this.menuModePaths.Enabled = enable;
			this.menuModeLocations.Enabled = enable;
			this.menuModeUnitGroup.Enabled = enable;
			this.menuModeSectors.Enabled = enable;
			this.tbMain.SetGroupEnable(1, enable);
			this.RefreshMenuAndToolbarItems();
		}

		private unsafe void RefreshMenuAndToolbarItems()
		{
			byte enabled = (this.EditorMode != 22) ? 1 : 0;
			this.menuToolsScriptEditor.Enabled = (enabled != 0);
			if (this.World != null)
			{
				GBaseString<char> gBaseString<char> = 0;
				*(ref gBaseString<char> + 4) = 0;
				try
				{
					GBaseString<char>* mapFileName = this.MapFileName;
					if (((*(int*)(mapFileName + 4 / sizeof(GBaseString<char>)) == 0) ? 1 : 0) != 0)
					{
						<Module>.GBaseString<char>.=(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_08OBKBFOJH@Untitled?$AA@));
					}
					else
					{
						<Module>.GBaseString<char>.=(ref gBaseString<char>, mapFileName);
					}
					GEditorWorld* world = this.World;
					int num = *(int*)(world + 2544 / sizeof(GEditorWorld));
					int num2 = *(int*)(world + 2540 / sizeof(GEditorWorld));
					int num3 = *(int*)(world + 2544 / sizeof(GEditorWorld));
					int num4 = *(int*)(world + 2540 / sizeof(GEditorWorld));
					GBaseString<char> gBaseString<char>2;
					GBaseString<char>* ptr = <Module>.Format(&gBaseString<char>2, (sbyte*)(&<Module>.??_C@_0BC@PHOIDCLM@?5?$FL?5?$CFdx?$CFd?0?5?$CFdx?$CFd?5?$FN?$AA@), (int)((double)((float)num4 * *(ref <Module>.Measures + 4))), (int)((double)((float)num3 * *(ref <Module>.Measures + 4))), (int)((double)((float)(num2 - 32) * *(ref <Module>.Measures + 4))), (int)((double)((float)(num - 32) * *(ref <Module>.Measures + 4))));
					try
					{
						int num5 = *(int*)(ptr + 4 / sizeof(GBaseString<char>));
						if (num5 != 0)
						{
							gBaseString<char> = <Module>.realloc(gBaseString<char>, (uint)(*(ref gBaseString<char> + 4) + num5 + 1));
							cpblk(*(ref gBaseString<char> + 4) + gBaseString<char>, *(int*)ptr, *(int*)(ptr + 4 / sizeof(GBaseString<char>)) + 1);
							*(ref gBaseString<char> + 4) = *(int*)(ptr + 4 / sizeof(GBaseString<char>)) + *(ref gBaseString<char> + 4);
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
					if (<Module>.GEditorWorld.IsChanged(this.World) != null)
					{
						<Module>.GBaseString<char>.+=(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_02FHJIKMCF@?5?$CK?$AA@));
					}
					sbyte* ptr2 = (sbyte*)(&<Module>.??_C@_0N@EPOCAHEK@?5?9?5Workshop?$JJ?$AA@);
					sbyte b;
					do
					{
						b = *(sbyte*)ptr2;
						ptr2 += 1 / sizeof(sbyte);
					}
					while (b != 0);
					int num6 = ptr2 - ref <Module>.??_C@_0N@EPOCAHEK@?5?9?5Workshop?$JJ?$AA@ / sizeof(sbyte) - 1 / sizeof(sbyte);
					if (num6 != 0)
					{
						uint num7 = (uint)(num6 + *(ref gBaseString<char> + 4));
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num7 + 1u);
						cpblk(*(ref gBaseString<char> + 4) + gBaseString<char>, ref <Module>.??_C@_0N@EPOCAHEK@?5?9?5Workshop?$JJ?$AA@, num6 + 1);
						*(ref gBaseString<char> + 4) = (int)num7;
					}
					sbyte* value;
					if (gBaseString<char> != null)
					{
						value = gBaseString<char>;
					}
					else
					{
						value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					if (this.Text != new string((sbyte*)value))
					{
						sbyte* value2;
						if (gBaseString<char> != null)
						{
							value2 = gBaseString<char>;
						}
						else
						{
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						this.Text = new string((sbyte*)value2);
					}
					int entityType;
					int num8;
					if (this.EditorMode != 1 || <Module>.GEditorWorld.SelectionExists(this.World) == null)
					{
						entityType = this.EntityType;
						if (entityType != 0)
						{
							world = this.World;
							if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, entityType, *(*(int*)world + 32)) && this.EditorMode != 19)
							{
								goto IL_226;
							}
						}
						num8 = 0;
						goto IL_22E;
					}
					IL_226:
					num8 = 1;
					IL_22E:
					bool flag = (byte)num8 != 0;
					this.menuEditCopy.Enabled = flag;
					this.tbMain.SetItemEnable(204, flag);
					entityType = this.EntityType;
					int num9;
					if (entityType != 0)
					{
						world = this.World;
						if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, entityType, *(*(int*)world + 32)) && this.EditorMode != 19)
						{
							num9 = 1;
							goto IL_284;
						}
					}
					num9 = 0;
					IL_284:
					bool flag2 = (byte)num9 != 0;
					this.menuEditCut.Enabled = flag2;
					this.tbMain.SetItemEnable(203, flag2);
					int editorMode = this.EditorMode;
					int num10;
					if (editorMode != 1 || this.Clipboard == null)
					{
						entityType = this.EntityType;
						if (entityType == 0 || <Module>.?HasEntity@GEntityClipboard@@$$FQAE_NW4GEntityType@@@Z(this.EntityClipboard, entityType) == null || editorMode == 19)
						{
							num10 = 0;
							goto IL_2E3;
						}
					}
					num10 = 1;
					IL_2E3:
					bool flag3 = (byte)num10 != 0;
					this.menuEditPaste.Enabled = flag3;
					byte enabled2;
					if (this.EditorMode == 1 && this.Clipboard != null)
					{
						enabled2 = 1;
					}
					else
					{
						enabled2 = 0;
					}
					this.menuEditControlPaste.Enabled = (enabled2 != 0);
					this.tbMain.SetItemEnable(205, flag3);
					entityType = this.EntityType;
					if (entityType != 0)
					{
						world = this.World;
						if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, entityType, *(*(int*)world + 32)) && this.EditorMode != 19)
						{
							goto IL_370;
						}
					}
					int num11;
					if (this.EditorMode != 8 || *(int*)(this.World + 3104 / sizeof(GEditorWorld)) < 0)
					{
						num11 = 0;
						goto IL_378;
					}
					IL_370:
					num11 = 1;
					IL_378:
					bool flag4 = (byte)num11 != 0;
					this.menuEditDelete.Enabled = flag4;
					this.tbMain.SetItemEnable(206, flag4);
					bool flag5 = <Module>.GEditorWorld.IsUndoAvail(this.World) != null;
					this.menuEditUndo.Enabled = flag5;
					this.tbMain.SetItemEnable(207, flag5);
					bool flag6 = <Module>.GEditorWorld.IsRedoAvail(this.World) != null;
					this.menuEditRedo.Enabled = flag6;
					this.tbMain.SetItemEnable(208, flag6);
					this.VertexTools.InvertEnable = (<Module>.GEditorWorld.SelectionExists(this.World) != null);
					this.TerrainTools.FillEnable = (<Module>.GEditorWorld.SelectionExists(this.World) != null);
					ToolboxScriptEntities currentScriptEnittyToolbar = this.CurrentScriptEnittyToolbar;
					if (currentScriptEnittyToolbar != null)
					{
						currentScriptEnittyToolbar.RefreshEntityList();
					}
					ScriptEditorForm scriptEditorFormInstance = this.ScriptEditorFormInstance;
					if (scriptEditorFormInstance != null)
					{
						scriptEditorFormInstance.EditorsChanged();
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

		private unsafe void RegisterScriptRefreshCallback()
		{
			*(int*)(this.World + 5080 / sizeof(GEditorWorld)) = <Module>.__unep@?ScriptEditorNotifier@NWorkshop@@$$FYAXXZ;
		}

		private unsafe void VisualizeBrush(float x, float z)
		{
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *this.BrushCursor, *(*(int*)<Module>.Scene + 264));
			float* brushPressure = this.BrushPressure;
			Color color = Color.FromArgb(4259648);
			if (brushPressure != null)
			{
				if (*brushPressure < 75f)
				{
					if (*brushPressure < 50f)
					{
						if (*brushPressure < 25f)
						{
							color = Color.FromArgb(40, (int)((double)(*brushPressure * 0.04f * 215f + 40f)), 255);
						}
						else
						{
							color = Color.FromArgb(40, 255, (int)((double)((1f - (*brushPressure - 25f) * 0.04f) * 215f + 40f)));
						}
					}
					else
					{
						color = Color.FromArgb((int)((double)((*brushPressure - 50f) * 0.04f * 215f + 40f)), 255, 40);
					}
				}
				else
				{
					color = Color.FromArgb(255, (int)((double)((1f - (*brushPressure - 75f) * 0.04f) * 215f + 40f)), 40);
				}
			}
			float* brushSize = this.BrushSize;
			if (brushSize != null)
			{
				GPoint2 gPoint = x;
				*(ref gPoint + 4) = z;
				int num = *(int*)<Module>.Scene + 296;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint2,System.Single,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, *this.BrushCursor, gPoint, *brushSize, color.ToArgb(), *num);
			}
			float* brushSize2 = this.BrushSize2;
			if (brushSize2 != null)
			{
				GPoint2 gPoint2 = x;
				*(ref gPoint2 + 4) = z;
				int num2 = *(int*)<Module>.Scene + 296;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint2,System.Single,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, *this.BrushCursor, gPoint2, *brushSize * *brushSize2 * 0.01f, color.ToArgb(), *num2);
			}
			float* brushHeight = this.BrushHeight;
			if (brushHeight != null)
			{
				float num3 = *brushHeight;
				GPoint3 gPoint3 = x;
				*(ref gPoint3 + 4) = num3;
				*(ref gPoint3 + 8) = z;
				float num4 = <Module>.GWorld.GetHeight(this.World, x, z);
				GPoint3 gPoint4 = x;
				*(ref gPoint4 + 4) = num4;
				*(ref gPoint4 + 8) = z;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, *this.BrushCursor, gPoint4, gPoint3, 4259648, *(*(int*)<Module>.Scene + 284));
				float num5 = *brushHeight;
				GPoint3 gPoint5 = x;
				*(ref gPoint5 + 4) = num5;
				*(ref gPoint5 + 8) = z;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, *this.BrushCursor, gPoint5, 16777024, *(*(int*)<Module>.Scene + 276));
				float num6 = <Module>.GWorld.GetHeight(this.World, x, z);
				GPoint3 gPoint6 = x;
				*(ref gPoint6 + 4) = num6;
				*(ref gPoint6 + 8) = z;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, *this.BrushCursor, gPoint6, 16777024, *(*(int*)<Module>.Scene + 276));
			}
		}

		private unsafe void RearrangeToolbars()
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			int num2 = this.panSideBar.Height;
			if (num2 != 0)
			{
				int num3 = 0;
				this.Rearranging = true;
				for (int i = 0; i < this.panSideBar.Controls.Count; i++)
				{
					try
					{
						ToolboxContainer toolboxContainer = this.panSideBar.Controls[i] as ToolboxContainer;
						if (toolboxContainer != null)
						{
							if (toolboxContainer.Autosize && toolboxContainer.Open)
							{
								num3++;
							}
							num2 -= toolboxContainer.MinHeight;
						}
						goto IL_CD;
					}
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
					IL_CD:;
				}
				int num4 = 0;
				if (num3 > 0)
				{
					num4 = num2 / num3;
				}
				this.panSideBar.SuspendLayout();
				int systemMetrics = <Module>.GetSystemMetrics(2);
				if (num2 < 0)
				{
					this.panSideBar.ViewHeight = this.panSideBar.Height - num2;
				}
				else
				{
					this.panSideBar.ViewHeight = this.panSideBar.Height;
				}
				if (num2 < 0)
				{
					if (!this.ScrollbarOn)
					{
						this.ScrollbarOn = true;
						this.splitMain.MinSize = systemMetrics + 256;
						Size size = this.panSideBar.Size;
						Size size2 = new Size(this.panSideBar.Size.Width + systemMetrics, size.Height);
						this.panSideBar.Size = size2;
						this.panSideBar.ShowScrollBar();
					}
				}
				else if (this.ScrollbarOn)
				{
					this.ScrollbarOn = false;
					this.splitMain.MinSize = 256;
					Size size3 = this.panSideBar.Size;
					Size size4 = new Size(this.panSideBar.Size.Width - systemMetrics, size3.Height);
					this.panSideBar.Size = size4;
					this.panSideBar.HideScrollBar();
				}
				if (num4 < 0)
				{
					num4 = 0;
				}
				for (int j = 0; j < this.panSideBar.Controls.Count; j++)
				{
					try
					{
						ToolboxContainer toolboxContainer2 = this.panSideBar.Controls[j] as ToolboxContainer;
						if (toolboxContainer2 != null && toolboxContainer2.Autosize && toolboxContainer2.Open)
						{
							toolboxContainer2.Inflate(num4);
						}
						goto IL_2AC;
					}
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
					IL_2AC:;
				}
				this.panSideBar.ResumeLayout();
				this.Rearranging = false;
				this.OldHeight = this.panSideBar.Height;
				int width;
				if (this.ScrollbarOn)
				{
					width = this.panSideBar.Size.Width - systemMetrics;
				}
				else
				{
					width = this.panSideBar.Size.Width;
				}
				int editorMode = this.EditorMode;
				if (editorMode == 2)
				{
					Size size5 = new Size(width, this.TerrainTools.Size.Height);
					this.TerrainTools.Size = size5;
				}
				else if (editorMode == 1)
				{
					Size size6 = new Size(width, this.VertexTools.Size.Height);
					this.VertexTools.Size = size6;
				}
			}
		}

		private void UpdateLayerUsage(int x, int z)
		{
			int num = x / 16;
			int num2 = z / 16;
			if (!this.TileDataValid || num != this.TileParcelX || num2 != this.TileParcelZ)
			{
				this.TileParcelX = num;
				this.TileParcelZ = num2;
				this.TileDataValid = true;
				this.TerrainFilePicker.UpdateLayerUsage(<Module>.GEditorWorld.GetLayerUsageFlags(this.World, num, num2));
			}
		}

		private unsafe void RefreshMinimapCameraGizmo()
		{
			ToolboxContainer currentMinimap = this.CurrentMinimap;
			if (currentMinimap != null && currentMinimap.Open)
			{
				PointF[] array = new PointF[200];
				float num = (float)this.panMainViewport.Size.Width * 0.02f;
				float num2 = (float)this.panMainViewport.Size.Height * 0.02f;
				int num3 = 0;
				do
				{
					GIViewport* iViewport = this.IViewport;
					float num4 = (float)num3;
					float num5 = num4 * num2;
					GRay gRay;
					float x;
					float num6;
					float y;
					<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay, 0, (int)((double)num5), *(*(int*)iViewport + 56)), ref x, ref num6, ref y);
					array[num3].X = x;
					array[num3].Y = y;
					Size size = this.panMainViewport.Size;
					int num7 = *(int*)this.IViewport + 56;
					float num8 = num4 * num;
					GRay gRay2;
					<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay2, (int)((double)num8), size.Height, *num7), ref x, ref num6, ref y);
					int num9 = num3 + 100 - 50;
					array[num9].X = x;
					array[num9].Y = y;
					Size size2 = this.panMainViewport.Size;
					Size size3 = this.panMainViewport.Size;
					int num10 = *(int*)this.IViewport + 56;
					GRay gRay3;
					<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay3, size3.Width, (int)((double)((float)size2.Height - num5)), *num10), ref x, ref num6, ref y);
					array[num3 + 100].X = x;
					array[num3 + 100].Y = y;
					Size size4 = this.panMainViewport.Size;
					int num11 = *(int*)this.IViewport + 56;
					GRay gRay4;
					<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay4, (int)((double)((float)size4.Width - num8)), 0, *num11), ref x, ref num6, ref y);
					int num12 = num3 + 100 + 50;
					array[num12].X = x;
					array[num12].Y = y;
					num3++;
				}
				while (num3 < 50);
				this.MinimapPanel.RefreshViewport(array);
				this.MinimapPanel.DrawMap();
			}
		}

		private void RefreshMinimap()
		{
			ToolboxContainer currentMinimap = this.CurrentMinimap;
			if (currentMinimap != null && currentMinimap.Open)
			{
				this.MinimapPanel.RefreshMap(false);
				this.RefreshMinimapCameraGizmo();
			}
		}

		private unsafe void InitMinimap()
		{
			this.MinimapPanel.World = this.World;
			GEditorWorld* world = this.World;
			this.MinimapPanel.SetScene(<Module>.Scene, *(int*)(world + 2540 / sizeof(GEditorWorld)), *(int*)(world + 2544 / sizeof(GEditorWorld)));
			this.MinimapNeedsRefresh();
		}

		private void InitScriptTools()
		{
			this.SectorTools.World = this.World;
			this.CameraCurveProps.World = this.World;
			this.PathProps.World = this.World;
			this.LocationProps.World = this.World;
			this.UnitGroupProps.World = this.World;
		}

		private void RefreshUnitsOnMinimap()
		{
			this.MinimapPanel.RefreshUnits();
			this.RefreshMinimapCameraGizmo();
		}

		private unsafe void RefreshSectorSelection()
		{
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *this.ParcelSelection, *(*(int*)<Module>.Scene + 264));
			int num;
			int num2;
			int num3;
			int num4;
			if (<Module>.GEditorWorld.GetParcelSelection(this.World, ref num, ref num2, ref num3, ref num4) != null)
			{
				int num5 = num;
				if (num < num3)
				{
					do
					{
						if (num5 % 2 != 0)
						{
							float num6 = (float)(num5 + 1);
							GPoint3 gPoint = num6;
							*(ref gPoint + 4) = 58f;
							float num7 = (float)num2;
							*(ref gPoint + 8) = num7;
							float num8 = (float)num5;
							GPoint3 gPoint2 = num8;
							*(ref gPoint2 + 4) = 58f;
							*(ref gPoint2 + 8) = num7;
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, *this.ParcelSelection, gPoint2, gPoint, 4210943, *(*(int*)<Module>.Scene + 284));
							GPoint3 gPoint3 = num6;
							*(ref gPoint3 + 4) = 58f;
							float num9 = (float)num4;
							*(ref gPoint3 + 8) = num9;
							GPoint3 gPoint4 = num8;
							*(ref gPoint4 + 4) = 58f;
							*(ref gPoint4 + 8) = num9;
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, *this.ParcelSelection, gPoint4, gPoint3, 4210943, *(*(int*)<Module>.Scene + 284));
						}
						num5++;
					}
					while (num5 < num3);
				}
				int num10 = num2;
				if (num2 < num4)
				{
					do
					{
						if (num10 % 2 != 0)
						{
							float num11 = (float)num;
							GPoint3 gPoint5 = num11;
							*(ref gPoint5 + 4) = 58f;
							float num12 = (float)(num10 + 1);
							*(ref gPoint5 + 8) = num12;
							GPoint3 gPoint6 = num11;
							*(ref gPoint6 + 4) = 58f;
							float num13 = (float)num10;
							*(ref gPoint6 + 8) = num13;
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, *this.ParcelSelection, gPoint6, gPoint5, 4210943, *(*(int*)<Module>.Scene + 284));
							float num14 = (float)num3;
							GPoint3 gPoint7 = num14;
							*(ref gPoint7 + 4) = 58f;
							*(ref gPoint7 + 8) = num12;
							GPoint3 gPoint8 = num14;
							*(ref gPoint8 + 4) = 58f;
							*(ref gPoint8 + 8) = num13;
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, *this.ParcelSelection, gPoint8, gPoint7, 4210943, *(*(int*)<Module>.Scene + 284));
						}
						num10++;
					}
					while (num10 < num4);
				}
			}
		}

		private unsafe void RunMap()
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			if (this.World != null)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, <Module>.GFileSystem.GetHomePath(ref <Module>.FS));
				GBaseString<char> gBaseString<char>2;
				try
				{
					<Module>.GBaseString<char>.+(ptr, &gBaseString<char>2, (sbyte*)(&<Module>.??_C@_0BA@FGELNJIA@$$TestRun$$?4map?$AA@));
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
					throw;
				}
				GBaseString<char> gBaseString<char>4;
				try
				{
					if (gBaseString<char> != null)
					{
						<Module>.free(gBaseString<char>);
					}
					GBaseString<char> gBaseString<char>3;
					GBaseString<char>* ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, <Module>.GFileSystem.GetHomePath(ref <Module>.FS));
					try
					{
						<Module>.GBaseString<char>.+(ptr2, &gBaseString<char>4, (sbyte*)(&<Module>.??_C@_0BA@JEAEPEAH@$$TestRun$$?4ma2?$AA@));
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
						throw;
					}
					try
					{
						if (gBaseString<char>3 != null)
						{
							<Module>.free(gBaseString<char>3);
							gBaseString<char>3 = 0;
						}
						FileInfo fileInfo = new FileInfo(Application.ExecutablePath);
						sbyte* ptr3;
						if (gBaseString<char>2 != null)
						{
							ptr3 = gBaseString<char>2;
						}
						else
						{
							ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						GStream* ptr4 = <Module>.GFileSystem.OpenWrite(ref <Module>.FS, ptr3, null);
						sbyte* ptr5;
						if (gBaseString<char>4 != null)
						{
							ptr5 = gBaseString<char>4;
						}
						else
						{
							ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						GStream* ptr6 = <Module>.GFileSystem.OpenWrite(ref <Module>.FS, ptr5, null);
						if (ptr4 == null)
						{
							<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 1980, (sbyte*)(&<Module>.??_C@_0BN@CIJBGNFH@NWorkshop?3?3NMainForm?3?3RunMap?$AA@));
							sbyte* ptr7;
							if (gBaseString<char>2 != null)
							{
								ptr7 = gBaseString<char>2;
							}
							else
							{
								ptr7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), *(sbyte*)ptr7);
						}
						if (ptr6 == null)
						{
							<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 1983, (sbyte*)(&<Module>.??_C@_0BN@CIJBGNFH@NWorkshop?3?3NMainForm?3?3RunMap?$AA@));
							sbyte* ptr8;
							if (gBaseString<char>4 != null)
							{
								ptr8 = gBaseString<char>4;
							}
							else
							{
								ptr8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), *(sbyte*)ptr8);
						}
						if (<Module>.GEditorWorld.Save(this.World, ptr4, ptr6) == null)
						{
							goto IL_2D8;
						}
						object arg_172_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, *(*(int*)ptr4));
						object arg_17D_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, *(*(int*)ptr6));
						Process process = new Process();
						string fileName = fileInfo.Directory.FullName + "/jtf.exe";
						process.StartInfo.FileName = fileName;
						process.StartInfo.CreateNoWindow = false;
						sbyte* value;
						if (gBaseString<char>2 != null)
						{
							value = gBaseString<char>2;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						process.StartInfo.Arguments = "-map \"" + new string((sbyte*)value) + new string((sbyte*)(&<Module>.??_C@_01BJJEKLCA@?$CC?$AA@));
						try
						{
							process.Start();
							goto IL_285;
						}
						uint exceptionCode = (uint)Marshal.GetExceptionCode();
						endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
						IL_285:
						process.WaitForExit();
						goto IL_30F;
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
						throw;
					}
					if (gBaseString<char>4 != null)
					{
						<Module>.free(gBaseString<char>4);
						gBaseString<char>4 = 0;
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
					return;
				}
				return;
				IL_2D8:
				try
				{
					try
					{
						GStream* ptr4;
						object arg_2E3_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, *(*(int*)ptr4));
						GStream* ptr6;
						object arg_2EE_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, *(*(int*)ptr6));
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
						throw;
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
					throw;
				}
				IL_30F:
				try
				{
					try
					{
						sbyte* ptr9;
						if (gBaseString<char>2 != null)
						{
							ptr9 = gBaseString<char>2;
						}
						else
						{
							ptr9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						<Module>.GFileSystem.Remove(ref <Module>.FS, ptr9);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
						throw;
					}
					if (gBaseString<char>4 != null)
					{
						<Module>.free(gBaseString<char>4);
						gBaseString<char>4 = 0;
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
		}

		private unsafe void UpdateCameraCurvePreview(long elapsed, [MarshalAs(UnmanagedType.U1)] bool force_refresh)
		{
			ToolboxScriptEntities cameraCurveProps = this.CameraCurveProps;
			float num = cameraCurveProps.GetCameraCurvePos();
			float cameraCurveDuration = cameraCurveProps.GetCameraCurveDuration();
			GBaseString<char> gBaseString<char> = 0;
			*(ref gBaseString<char> + 4) = 0;
			try
			{
				int cameraStatus = this.CameraCurveProps.GetCameraStatus();
				if (cameraStatus != 1)
				{
					if (cameraStatus != 2)
					{
						if (cameraStatus != 3)
						{
							<Module>.GBaseString<char>.=(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_05PDJBBECF@pause?$AA@));
						}
						else
						{
							num = (float)elapsed * 3E-06f + num;
							<Module>.GBaseString<char>.=(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_02MBHFIONK@3x?$AA@));
						}
					}
					else
					{
						num -= (float)elapsed * 3E-06f;
						<Module>.GBaseString<char>.=(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_03ENCIPPDH@?93x?$AA@));
					}
				}
				else
				{
					num = (float)elapsed * 1E-06f + num;
					<Module>.GBaseString<char>.=(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_02MCPBFKLE@1x?$AA@));
				}
				if (this.CameraCurveProps.GetCameraCurveLoop())
				{
					if (num > cameraCurveDuration)
					{
						num = 0f;
					}
					else if (num < 0f)
					{
						num = cameraCurveDuration;
					}
				}
				else
				{
					if (num > cameraCurveDuration)
					{
						num = cameraCurveDuration;
					}
					if (num < 0f)
					{
						num = 0f;
					}
				}
				this.CameraCurveProps.SetCameraCurvePos(num);
				this.CameraCurveProps.RefreshCameraCurvePos();
				if (this.CameraCurveProps.RefreshCameraViewport(ref gBaseString<char>, cameraStatus, force_refresh))
				{
					base.Focus();
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

		private unsafe void DebugMap()
		{
			if (this.World != null)
			{
				GIViewport* iViewport = this.IViewport;
				float debugMapTempFOV;
				float debugMapTempNearPlane;
				float debugMapTempFarPlane;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), iViewport, ref debugMapTempFOV, ref debugMapTempNearPlane, ref debugMapTempFarPlane, *(*(int*)iViewport + 44));
				this.DebugMapTempFOV = debugMapTempFOV;
				this.DebugMapTempNearPlane = debugMapTempNearPlane;
				this.DebugMapTempFarPlane = debugMapTempFarPlane;
				this.LastCameraType = <Module>.?GetCameraType@GWorld@@$$FQBE?AW4GCameraType@@XZ(this.World);
				<Module>.GWorld.GetCamera(this.World, this.LastCamera);
				GEditorWorld* world = this.World;
				int num = *(int*)(world + 3228 / sizeof(GEditorWorld));
				int num2 = *(int*)(world + 3232 / sizeof(GEditorWorld));
				GStreamBuffer gStreamBuffer;
				<Module>.GStreamBuffer.{ctor}(ref gStreamBuffer);
				try
				{
					GStreamBuffer gStreamBuffer2;
					<Module>.GStreamBuffer.{ctor}(ref gStreamBuffer2);
					try
					{
						GEditorWorld* world2 = this.World;
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world2, 3, 0, *(*(int*)world2 + 12));
						GEditorWorld* world3 = this.World;
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world3, 2, 0, *(*(int*)world3 + 12));
						<Module>.GEditorWorld.Refresh(this.World, 0L, this.IViewport);
						<Module>.GEditorWorld.ResetForDebug(this.World, this.IViewport);
						if (<Module>.GEditorWorld.Save(this.World, (GStream*)(&gStreamBuffer), (GStream*)(&gStreamBuffer2)) != null)
						{
							goto IL_129;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GStreamBuffer.{dtor}), (void*)(&gStreamBuffer2));
						throw;
					}
					<Module>.GStreamBuffer.{dtor}(ref gStreamBuffer2);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GStreamBuffer.{dtor}), (void*)(&gStreamBuffer));
					throw;
				}
				<Module>.GStreamBuffer.{dtor}(ref gStreamBuffer);
				return;
				IL_129:
				try
				{
					GStreamBuffer gStreamBuffer2;
					try
					{
						this.GameDebugMode = true;
						this.GameDebugBackupWorld = this.World;
						this.World = null;
						<Module>.World = null;
						this.GameDebugBackupScene = <Module>.Scene;
						<Module>.Scene = null;
						initblk(ref this.AvailableCommands, 0, 48);
						GWorld* ptr = <Module>.@new(4200u);
						GWorld* gameDebugWorld;
						try
						{
							if (ptr != null)
							{
								GNativeData* nD = this.ND;
								gameDebugWorld = <Module>.GWorld.{ctor}(ptr, *(GHandle<12>*)(nD + 4 / sizeof(GNativeData)), *(GHandle<19>*)nD, *(GHandle<19>*)nD, true);
							}
							else
							{
								gameDebugWorld = 0;
							}
						}
						catch
						{
							<Module>.delete((void*)ptr);
							throw;
						}
						this.GameDebugWorld = gameDebugWorld;
						GAWorld gAWorld;
						<Module>.GAWorld.{ctor}(ref gAWorld);
						try
						{
							<Module>.GAWorld.Load(ref gAWorld, (GStream*)(&gStreamBuffer2));
							<Module>.GStream.Reset(ref gStreamBuffer);
							if (<Module>.?Load@GWorld@@$$FQAE_NPAVGStream@@PAVGAWorld@@_NP6AXABUGLoadingInfo@@PAX@ZP6AXXZP6AHW4AssetType@@PBDAAV?$GBaseString@D@@2@Z4@Z(this.GameDebugWorld, (GStream*)(&gStreamBuffer), &gAWorld, true, 0, 0, 0, null) == null)
							{
								<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), 2081, (sbyte*)(&<Module>.??_C@_0BP@KBDKBGLO@NWorkshop?3?3NMainForm?3?3DebugMap?$AA@));
								<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0P@BIPNFHPK@Can?8t?5load?5map?$AA@));
							}
							<Module>.GWorld.Initialize(this.GameDebugWorld);
							GGameLogicSettings gGameLogicSettings = 0;
							GGameLogic* ptr2 = <Module>.@new(75952u);
							GGameLogic* ptr3;
							try
							{
								if (ptr2 != null)
								{
									GNativeData* nD2 = this.ND;
									ptr3 = <Module>.GGameLogic.{ctor}(ptr2, *(GHandle<12>*)(nD2 + 4 / sizeof(GNativeData)), *(GHandle<12>*)(nD2 + 8 / sizeof(GNativeData)), *(GHandle<12>*)(nD2 + 12 / sizeof(GNativeData)), ref gGameLogicSettings, null);
								}
								else
								{
									ptr3 = 0;
								}
							}
							catch
							{
								<Module>.delete((void*)ptr2);
								throw;
							}
							<Module>.GameLogic = ptr3;
							<Module>.GGameLogic.SetEchoCallback(ptr3, <Module>.__unep@?EchoLogHandler@NWorkshop@@$$FYAXV?$GBaseString@D@@@Z);
							GOrder* ptr4 = <Module>.@new(120u);
							GOrder* currentOrder;
							try
							{
								if (ptr4 != null)
								{
									currentOrder = <Module>.GOrder.{ctor}(ptr4);
								}
								else
								{
									currentOrder = 0;
								}
							}
							catch
							{
								<Module>.delete((void*)ptr4);
								throw;
							}
							this.CurrentOrder = currentOrder;
							this.LastEditorMode = this.EditorMode;
							this.SetEditorMode(22);
							this.CurrentControlPanel = null;
							this.SetDebugMode(this.DebugMode);
							this.LoggerTool.Reset();
							this.LastCamViewPortUpdate = <Module>.GTimer.GetTimeH(<Module>.Timer);
							this.LastUpdate = this.LastCamViewPortUpdate;
							<Module>.GWorld.AlwaysDrawPaths(this.GameDebugWorld, true);
							<Module>.GWorld.AlwaysDrawLocations(this.GameDebugWorld, true);
							this.tbDebug.SetItemPushed(214, true);
							this.DTriggersTool.Init(*(int*)(<Module>.GameLogic + 2932 / sizeof(GGameLogic)));
							this.DGVarsTool.Init(*(int*)(<Module>.GameLogic + 2932 / sizeof(GGameLogic)));
							*(int*)(this.GameDebugWorld + 3228 / sizeof(GWorld)) = num;
							*(int*)(this.GameDebugWorld + 3232 / sizeof(GWorld)) = num2;
							*(byte*)(this.GameDebugWorld + 3236 / sizeof(GWorld)) = (this.CameraCurveProps.GetCameraCurveMakeShots() ? 1 : 0);
							*(byte*)(this.GameDebugWorld + 3220 / sizeof(GWorld)) = *(byte*)(this.GameDebugBackupWorld + 3220 / sizeof(GEditorWorld));
							*(int*)(this.GameDebugWorld + 3216 / sizeof(GWorld)) = *(int*)(this.GameDebugBackupWorld + 3216 / sizeof(GEditorWorld));
							*(float*)(this.GameDebugWorld + 3224 / sizeof(GWorld)) = *(float*)(this.GameDebugBackupWorld + 3224 / sizeof(GEditorWorld));
							if (this.CameraCurveProps.GetCameraCurveDebugShow())
							{
								if (num != -1 || *(byte*)(this.GameDebugWorld + 3220 / sizeof(GWorld)) != 0)
								{
									if (this.CameraCurveProps.GetCameraCurveMakeShots())
									{
										GBaseString<char> gBaseString<char>;
										<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, <Module>.GFileSystem.GetHomePath(ref <Module>.FS));
										try
										{
											GBaseString<char> gBaseString<char>2;
											GBaseString<char>* src = <Module>.GBaseString<char>.+(ref gBaseString<char>, &gBaseString<char>2, (sbyte*)(&<Module>.??_C@_0N@FEIMNKOL@?1CameraShots?$AA@));
											try
											{
												<Module>.GBaseString<char>.=(this.GameDebugWorld + 3240 / sizeof(GWorld), src);
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
											uint num3 = (uint)(*(int*)(this.GameDebugWorld + 3240 / sizeof(GWorld)));
											sbyte* ptr5;
											if (num3 != 0u)
											{
												ptr5 = num3;
											}
											else
											{
												ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
											}
											<Module>.GFileSystem.CreatePath(ref <Module>.FS, ptr5);
											this.GameDebugWithShotsMode = true;
											GWorld* gameDebugWorld2 = this.GameDebugWorld;
											this.CameraCurveProps.GetResolution(gameDebugWorld2 + 3248 / sizeof(GWorld), gameDebugWorld2 + 3252 / sizeof(GWorld));
											this.DebugMapTemp_RefractBufferWidth = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 1, *(*(int*)<Module>.IEngine + 20));
											this.DebugMapTemp_RefractBufferHeight = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 2, *(*(int*)<Module>.IEngine + 20));
											this.DebugMapTemp_ReflectBufferWidth = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 3, *(*(int*)<Module>.IEngine + 20));
											this.DebugMapTemp_ReflectBufferHeight = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 4, *(*(int*)<Module>.IEngine + 20));
											this.DebugMapTemp_DistanceBufferWidth = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 5, *(*(int*)<Module>.IEngine + 20));
											this.DebugMapTemp_DistanceBufferHeight = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 6, *(*(int*)<Module>.IEngine + 20));
											this.DebugMapTemp_ShadowBufferSize = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 8, *(*(int*)<Module>.IEngine + 20));
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 1, *(int*)(this.GameDebugWorld + 3248 / sizeof(GWorld)), *(*(int*)<Module>.IEngine + 16));
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 2, *(int*)(this.GameDebugWorld + 3252 / sizeof(GWorld)), *(*(int*)<Module>.IEngine + 16));
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 3, *(int*)(this.GameDebugWorld + 3248 / sizeof(GWorld)), *(*(int*)<Module>.IEngine + 16));
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 4, *(int*)(this.GameDebugWorld + 3252 / sizeof(GWorld)), *(*(int*)<Module>.IEngine + 16));
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 5, *(int*)(this.GameDebugWorld + 3248 / sizeof(GWorld)), *(*(int*)<Module>.IEngine + 16));
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 6, *(int*)(this.GameDebugWorld + 3252 / sizeof(GWorld)), *(*(int*)<Module>.IEngine + 16));
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 8, 2048, *(*(int*)<Module>.IEngine + 16));
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
									<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(this.GameDebugWorld, 2);
									GISoundSys* expr_670 = <Module>.ISoundSys;
									calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_670, *(*(int*)expr_670 + 144));
								}
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GAWorld.{dtor}), (void*)(&gAWorld));
							throw;
						}
						<Module>.GAWorld.{dtor}(ref gAWorld);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GStreamBuffer.{dtor}), (void*)(&gStreamBuffer2));
						throw;
					}
					<Module>.GStreamBuffer.{dtor}(ref gStreamBuffer2);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GStreamBuffer.{dtor}), (void*)(&gStreamBuffer));
					throw;
				}
				<Module>.GStreamBuffer.{dtor}(ref gStreamBuffer);
			}
		}

		private unsafe void EndDebugMap()
		{
			if (this.GameDebugMode)
			{
				this.panSideBar.Controls.Remove(this.LoggerContainer);
				this.panSideBar.Controls.Remove(this.DUnitsContainer);
				this.panSideBar.Controls.Remove(this.DUnitGroupsContainer);
				this.panSideBar.Controls.Remove(this.DTriggersContainer);
				this.panSideBar.Controls.Remove(this.DGVarsContainer);
				ToolboxContainer currentControlPanel = this.CurrentControlPanel;
				if (currentControlPanel != null)
				{
					this.panSideBar.Controls.Remove(currentControlPanel);
				}
				this.CurrentControlPanel = null;
				GOrder* currentOrder = this.CurrentOrder;
				if (currentOrder != null)
				{
					GOrder* ptr = currentOrder;
					<Module>.GOrder.{dtor}(ptr);
					<Module>.delete((void*)ptr);
					this.CurrentOrder = null;
				}
				if (<Module>.GameLogic != null)
				{
					void* arg_D9_0 = (void*)<Module>.GameLogic;
					<Module>.GGameLogic.{dtor}(<Module>.GameLogic);
					<Module>.delete(arg_D9_0);
					<Module>.GameLogic = null;
				}
				GWorld* gameDebugWorld = this.GameDebugWorld;
				if (gameDebugWorld != null)
				{
					GWorld* ptr2 = gameDebugWorld;
					object arg_FA_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, *(*(int*)ptr2));
					this.GameDebugWorld = null;
				}
				GEditorWorld* gameDebugBackupWorld = this.GameDebugBackupWorld;
				this.World = gameDebugBackupWorld;
				<Module>.World = (GWorld*)gameDebugBackupWorld;
				<Module>.Scene = this.GameDebugBackupScene;
				if (this.GameDebugWithShotsMode)
				{
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 1, this.DebugMapTemp_RefractBufferWidth, *(*(int*)<Module>.IEngine + 16));
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 2, this.DebugMapTemp_RefractBufferHeight, *(*(int*)<Module>.IEngine + 16));
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 3, this.DebugMapTemp_ReflectBufferWidth, *(*(int*)<Module>.IEngine + 16));
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 4, this.DebugMapTemp_ReflectBufferHeight, *(*(int*)<Module>.IEngine + 16));
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 5, this.DebugMapTemp_DistanceBufferWidth, *(*(int*)<Module>.IEngine + 16));
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 6, this.DebugMapTemp_DistanceBufferHeight, *(*(int*)<Module>.IEngine + 16));
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 8, this.DebugMapTemp_ShadowBufferSize, *(*(int*)<Module>.IEngine + 16));
					GISoundSys* expr_1EE = <Module>.ISoundSys;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_1EE, *(*(int*)expr_1EE + 148));
				}
				this.GameDebugMode = false;
				this.GameDebugWithShotsMode = false;
				this.SetEditorMode(this.LastEditorMode);
				<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(this.World, this.LastCameraType);
				<Module>.GWorld.SetCamera(this.World, this.LastCamera);
				GIViewport* iViewport = this.IViewport;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single), iViewport, this.DebugMapTempFOV, this.DebugMapTempNearPlane, this.DebugMapTempFarPlane, *(*(int*)iViewport + 40));
			}
		}

		private unsafe void UpdateCameraDebugText()
		{
			if (!calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 3, *(*(int*)<Module>.IEngine + 32)))
			{
				GWorld* gameDebugWorld = this.GameDebugWorld;
				GCamera gCamera;
				if (gameDebugWorld != null)
				{
					<Module>.GWorld.GetCamera(gameDebugWorld, ref gCamera);
				}
				else
				{
					<Module>.GWorld.GetCamera(this.World, ref gCamera);
				}
				float num = *(ref gCamera + 8) * 0.159154937f;
				float num2 = (float)((double)num % 1.0);
				if (num2 < 0f)
				{
					num2 += 1f;
				}
				int num3 = ((4 - *(ref <Module>.MissionVariables + 4)) * 2 + <Module>.fround(num2 * 8f)) % 8;
				$ArrayType$$$BY08PBD $ArrayType$$$BY08PBD = ref <Module>.??_C@_05FPOHJMOI@North?$AA@;
				*(ref $ArrayType$$$BY08PBD + 4) = ref <Module>.??_C@_09DEECMKJ@NorthEast?$AA@;
				*(ref $ArrayType$$$BY08PBD + 8) = ref <Module>.??_C@_04DHLACFEG@East?$AA@;
				*(ref $ArrayType$$$BY08PBD + 12) = ref <Module>.??_C@_09NLNBCPOI@SouthEast?$AA@;
				*(ref $ArrayType$$$BY08PBD + 16) = ref <Module>.??_C@_05HNHILFBE@South?$AA@;
				*(ref $ArrayType$$$BY08PBD + 20) = ref <Module>.??_C@_09EOJDHMFN@SouthWest?$AA@;
				*(ref $ArrayType$$$BY08PBD + 24) = ref <Module>.??_C@_04KCPCHGPD@West?$AA@;
				*(ref $ArrayType$$$BY08PBD + 28) = ref <Module>.??_C@_09JGAGHPBM@NorthWest?$AA@;
				*(ref $ArrayType$$$BY08PBD + 32) = ref <Module>.??_C@_05FPOHJMOI@North?$AA@;
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.Format(&gBaseString<char>, (sbyte*)(&<Module>.??_C@_0EF@KDOIMJMO@X?3?5?$CFf?0?5Z?3?5?$CFf?0?5Y?3?5?$CFf?0?5Camera?3?5?$FLDi@), (double)this.MouseTargetX, (double)this.MouseTargetZ, (double)this.MouseTargetY, (double)(num2 * 360f), *(num3 * 4 + ref $ArrayType$$$BY08PBD), (double)(*(ref gCamera + 12) * 57.29578f), (double)(*(ref <Module>.Measures + 4) * *(ref gCamera + 16)));
				try
				{
					uint num4 = (uint)(*(int*)ptr);
					sbyte* ptr2;
					if (num4 != 0u)
					{
						ptr2 = num4;
					}
					else
					{
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					GNativeData* nD = this.ND;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>,GHandle<12>,System.Int32,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.ILayout, *(GHandle<19>*)(nD + 24 / sizeof(GNativeData)), *(GHandle<12>*)(nD + 4 / sizeof(GNativeData)), 0, ptr2, *(*(int*)<Module>.ILayout + 84));
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

		private unsafe void RefreshDebug()
		{
			long num = <Module>.GTimer.GetTimeH(<Module>.Timer);
			if (this.LastUpdate == 0L)
			{
				this.LastUpdate = num;
			}
			int num2 = 0;
			do
			{
				if (*(num2 * 8 + ref this.KeyTimes) != 0L)
				{
					this.UpdateKey(num, num2);
				}
				num2++;
			}
			while (num2 < 256);
			long num3 = num - this.LastUpdate;
			this.LastUpdate = num;
			if (this.GameDebugMode && this.GameDebugWithShotsMode)
			{
				num3 = 50000L;
			}
			<Module>.GGameLogic.Refresh(<Module>.GameLogic, num3, this.IViewport);
			this.UpdateCameraDebugText();
			if (!this.GameDebugWithShotsMode)
			{
				GWorld* gameDebugWorld = this.GameDebugWorld;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GIViewport*), gameDebugWorld, this.IViewport, *(*(int*)gameDebugWorld + 36));
				GWorld* gameDebugWorld2 = this.GameDebugWorld;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), gameDebugWorld2, 0, *(*(int*)gameDebugWorld2 + 40));
			}
			GGamePanelStatus gGamePanelStatus;
			<Module>.GGamePanelStatus.{ctor}(ref gGamePanelStatus);
			try
			{
				GModOptions gModOptions = 0;
				*(ref gModOptions + 4) = 0;
				*(ref gModOptions + 8) = 0;
				try
				{
					GMissionStatus gMissionStatus = 0;
					*(ref gMissionStatus + 4) = 0;
					*(ref gMissionStatus + 8) = 0;
					try
					{
						*(ref gMissionStatus + 12) = 0;
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GArray<GMissionObjectiveInfo>.{dtor}), (void*)(&gMissionStatus));
						throw;
					}
					try
					{
						int num4;
						<Module>.GGameLogic.GetGamePanelStatus(<Module>.GameLogic, ref gGamePanelStatus, this.CurrentOrder, ref gModOptions, ref gMissionStatus, ref num4);
						int num5 = 0;
						do
						{
							byte b = (*(num5 + ref gGamePanelStatus) != 0) ? 1 : 0;
							*(ref this.AvailableCommands + num5) = b;
							num5++;
						}
						while (num5 < 48);
						if (*(ref gGamePanelStatus + 228) == 1)
						{
							if (this.CommandMode != 20 && this.AcceptedCommand != 20)
							{
								<Module>.GWorld.ShowUnitRange(this.GameDebugWorld, *(ref gGamePanelStatus + 232), 5, 0f);
							}
							else
							{
								<Module>.GWorld.ShowUnitRange(this.GameDebugWorld, *(ref gGamePanelStatus + 232), 2, 0f);
							}
						}
						else
						{
							<Module>.GWorld.ShowUnitRange(this.GameDebugWorld, -1, 15, 0f);
						}
						if (this.DebugMode == 503)
						{
							this.DTriggersTool.Refresh(*(int*)(<Module>.GameLogic + 2932 / sizeof(GGameLogic)));
							this.DGVarsTool.Refresh(*(int*)(<Module>.GameLogic + 2932 / sizeof(GGameLogic)));
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GMissionStatus.{dtor}), (void*)(&gMissionStatus));
						throw;
					}
					int num6 = 0;
					if (0 < *(ref gMissionStatus + 4))
					{
						int num7 = 0;
						do
						{
							<Module>.GMissionObjectiveInfo.__delDtor(num7 + gMissionStatus, 0u);
							num6++;
							num7 += 24;
						}
						while (num6 < *(ref gMissionStatus + 4));
					}
					if (gMissionStatus != null)
					{
						<Module>.free(gMissionStatus);
						gMissionStatus = 0;
					}
					*(ref gMissionStatus + 4) = 0;
					*(ref gMissionStatus + 8) = 0;
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GModOptions.{dtor}), (void*)(&gModOptions));
					throw;
				}
				<Module>.GArray<GBaseString<char> >.{dtor}(ref gModOptions);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GGamePanelStatus.{dtor}), (void*)(&gGamePanelStatus));
				throw;
			}
			<Module>.GGamePanelStatus.{dtor}(ref gGamePanelStatus);
		}

		private void SetPlaySpeed(int play_speed)
		{
			<Module>.GGameLogic.SetPlaySpeed(<Module>.GameLogic, play_speed, true);
		}

		private unsafe void HandleDebugKeys(Keys code)
		{
			switch (code)
			{
			case Keys.Pause:
				if (<Module>.GGameLogic.GetPlaySpeed(<Module>.GameLogic) == null)
				{
					<Module>.GGameLogic.RefreshMicroFrame(<Module>.GameLogic);
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), <Module>.Scene, 25000L, *(*(int*)<Module>.Scene + 32));
					return;
				}
				this.SetPlaySpeed(0);
				return;
			case Keys.Escape:
				this.EndDebugMap();
				return;
			case Keys.Space:
			{
				int num = (<Module>.GGameLogic.GetPlaySpeed(<Module>.GameLogic) == 0) ? 1 : 0;
				<Module>.GGameLogic.SetPlaySpeed(<Module>.GameLogic, num, true);
				return;
			}
			case Keys.A:
				this.StartDebugCommand(7);
				return;
			case Keys.B:
				this.StartDebugCommand(2);
				return;
			case Keys.D:
				if (*(ref this.AvailableCommands + 6) != 0)
				{
					byte b;
					if (*(ref this.KeyTimes + 128) != 0L)
					{
						b = 1;
					}
					else
					{
						b = 0;
					}
					<Module>.?QUnitCommand@GGameLogic@@$$FQAEXW4GTargetTask@@_N@Z(<Module>.GameLogic, 24, b != 0);
					return;
				}
				return;
			case Keys.M:
				this.StartDebugCommand(1);
				return;
			case Keys.P:
				if (*(ref this.AvailableCommands + 4) != 0)
				{
					byte b2;
					if (*(ref this.KeyTimes + 128) != 0L)
					{
						b2 = 1;
					}
					else
					{
						b2 = 0;
					}
					<Module>.?QUnitCommand@GGameLogic@@$$FQAEXW4GTargetTask@@_N@Z(<Module>.GameLogic, 23, b2 != 0);
					return;
				}
				return;
			case Keys.S:
				if (*(ref this.AvailableCommands + 3) != 0)
				{
					byte b3;
					if (*(ref this.KeyTimes + 128) != 0L)
					{
						b3 = 1;
					}
					else
					{
						b3 = 0;
					}
					<Module>.?QUnitCommand@GGameLogic@@$$FQAEXW4GTargetTask@@_N@Z(<Module>.GameLogic, 4, b3 != 0);
					return;
				}
				return;
			case Keys.U:
				if (*(ref this.AvailableCommands + 5) != 0)
				{
					byte b4;
					if (*(ref this.KeyTimes + 128) != 0L)
					{
						b4 = 1;
					}
					else
					{
						b4 = 0;
					}
					<Module>.?QUnitCommand@GGameLogic@@$$FQAEXW4GTargetTask@@_N@Z(<Module>.GameLogic, 22, b4 != 0);
					return;
				}
				return;
			case Keys.F1:
				if (*(ref this.KeyTimes + 128) != 0L)
				{
					<Module>.GWorld.CameraInitialize(this.GameDebugWorld);
				}
				else
				{
					GWorld* gameDebugWorld = this.GameDebugWorld;
					byte b5 = (*(byte*)(gameDebugWorld + 136 / sizeof(GWorld)) == 0) ? 1 : 0;
					<Module>.GWorld.LimitGameCamera(gameDebugWorld, b5 != 0);
				}
				this.MinimapViewportNeedsUpdate = true;
				return;
			case Keys.F7:
			{
				if (*(ref this.KeyTimes + 136) != 0L)
				{
					byte b6 = (<Module>.GWorld.GetBlockMapMode(this.GameDebugWorld) == 0) ? 1 : 0;
					<Module>.GWorld.SetBlockMapMode(this.GameDebugWorld, b6 != 0);
					return;
				}
				byte b7 = (calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *(GHandle<11>*)(<Module>.GameLogic + 2440 / sizeof(GGameLogic)), *(*(int*)<Module>.Scene + 272)) == 0) ? 1 : 0;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, *(GHandle<11>*)(<Module>.GameLogic + 2440 / sizeof(GGameLogic)), b7, *(*(int*)<Module>.Scene + 268));
				return;
			}
			}
			if (code - Keys.D1 <= 8)
			{
				if (*(ref this.KeyTimes + 128) != 0L)
				{
					switch (code)
					{
					case Keys.D1:
						<Module>.?QUnitCommandWithUnitState@GGameLogic@@$$FQAEXW4GTargetTask@@H_N@Z(<Module>.GameLogic, 32, 0, false);
						break;
					case Keys.D2:
						<Module>.?QUnitCommandWithUnitState@GGameLogic@@$$FQAEXW4GTargetTask@@H_N@Z(<Module>.GameLogic, 32, 2, false);
						break;
					case Keys.D4:
						<Module>.GGameLogic.QSetFormation(<Module>.GameLogic, 2);
						break;
					case Keys.D5:
						<Module>.GGameLogic.QSetFormation(<Module>.GameLogic, 1);
						break;
					case Keys.D6:
						<Module>.GGameLogic.QSetFormation(<Module>.GameLogic, 0);
						break;
					}
				}
				else if (*(ref this.KeyTimes + 136) != 0L)
				{
					<Module>.GWorld.CreateUnitGroup(this.GameDebugWorld, code - Keys.D0);
				}
				else
				{
					<Module>.GWorld.SelectUnitGroup(this.GameDebugWorld, code - Keys.D0);
				}
			}
		}

		private unsafe void DebugMouseDown(object sender, MouseEventArgs e)
		{
			int num = *(int*)this.IViewport + 56;
			GRay gRay;
			float dragX;
			float num2;
			float dragZ;
			<Module>.GWorld.GetTarget(this.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, e.X, e.Y, *num), ref dragX, ref num2, ref dragZ);
			if (e.Button == MouseButtons.Left)
			{
				if (this.DragMode == 31)
				{
					int commandMode = this.CommandMode;
					if (commandMode == 20)
					{
						this.CancelDebugCommand();
					}
					else
					{
						if (commandMode != 1 && commandMode != 2)
						{
							this.ExecuteDebugCommand(e.X, e.Y, (int)(*(ref this.KeyTimes + 136)), commandMode);
							this.CommandMode = 0;
							this.DragMode = 0;
							return;
						}
						this.DragX = dragX;
						this.DragZ = dragZ;
						this.DragY = num2 + 0.1f;
						this.DragMode = 33;
						return;
					}
				}
				else
				{
					if (this.LastClickTime != 0L && Math.Abs(this.DragMX - e.X) <= 4 && Math.Abs(this.DragMY - e.Y) <= 4 && <Module>.GTimer.GetTimeH(<Module>.Timer) - this.LastClickTime <= 200000L)
					{
						int num3;
						if (*(ref this.KeyTimes + 128) != 0L)
						{
							num3 = 5;
						}
						else
						{
							num3 = 16;
						}
						int num4 = *(int*)this.IViewport + 60;
						GPyramid gPyramid;
						<Module>.GWorld.SelectUnitByType(this.GameDebugWorld, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), this.IViewport, ref gPyramid, 0, 0, base.Width, base.Height, *num4), this.LastClickUnit, num3);
						this.LastClickTime = 0L;
						this.LastClickTimeRightButton = 0L;
						return;
					}
					if (*(ref this.KeyTimes + 136) != 0L)
					{
						long num5 = *(ref this.KeyTimes + 128);
						int num6;
						if (num5 != 0L)
						{
							num6 = 5;
						}
						else
						{
							num6 = 16;
						}
						int num7;
						if (num5 != 0L)
						{
							num7 = 5;
						}
						else
						{
							num7 = 16;
						}
						int num8 = *(int*)this.IViewport + 56;
						int num9 = *(int*)this.IViewport + 60;
						GPyramid gPyramid2;
						GRay gRay2;
						<Module>.GWorld.SelectUnitByType(this.GameDebugWorld, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), this.IViewport, ref gPyramid2, 0, 0, base.Width, base.Height, *num9), <Module>.GWorld.SelectUnit(this.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay2, e.X, e.Y, *num8), num7), num6);
						this.LastClickTime = 0L;
						this.LastClickTimeRightButton = 0L;
						return;
					}
					if (this.DragMode == 19)
					{
						this.DragMX = e.X;
						this.DragMY = e.Y;
						this.DragMode = 18;
						this.DragStarted = false;
						return;
					}
				}
				this.DragMX = e.X;
				this.DragMY = e.Y;
				this.DragMode = 30;
				this.DragStarted = false;
				this.LastClickTime = <Module>.GTimer.GetTimeH(<Module>.Timer);
				this.LastClickUnit = -1;
			}
			else if (e.Button == MouseButtons.Right)
			{
				<Module>.GWorld.ClearBoxSelection(this.GameDebugWorld);
				bool flag = ((<Module>.GWorld.CountSelectedUnits(this.GameDebugWorld) != 0) ? 1 : 0) != 0;
				int dragMode = this.DragMode;
				if (dragMode == 31)
				{
					this.CancelDebugCommand();
				}
				else if (dragMode == 30)
				{
					<Module>.GWorld.SelectUnit(this.GameDebugWorld, 1);
					this.DragMX = e.X;
					this.DragMY = e.Y;
					this.DragMode = 18;
				}
				else if (flag)
				{
					int num10 = *(int*)this.IViewport + 56;
					GRay gRay3;
					int num11 = <Module>.GWorld.GetTargetUnit(this.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay3, e.X, e.Y, *num10));
					int num12 = <Module>.GGameLogic.GetUnitAlignment(<Module>.GameLogic, num11);
					if (num11 >= 0 && num12 == -1)
					{
						int control = (int)(*(ref this.KeyTimes + 136));
						if (this.LastClickTimeRightButton != 0L && Math.Abs(this.DragMX - e.X) <= 4 && Math.Abs(this.DragMY - e.Y) <= 4 && <Module>.GTimer.GetTimeH(<Module>.Timer) - this.LastClickTimeRightButton <= 200000L)
						{
							control = 1;
							this.LastClickTime = 0L;
							this.LastClickTimeRightButton = 0L;
						}
						else
						{
							this.LastClickTimeRightButton = <Module>.GTimer.GetTimeH(<Module>.Timer);
							this.DragMX = e.X;
							this.DragMY = e.Y;
						}
						this.CommandMode = 0;
						this.ExecuteDebugCommand(e.X, e.Y, control, 0);
					}
					else
					{
						this.DragX = dragX;
						this.DragY = num2;
						this.DragZ = dragZ;
						if (num12 == 1 && num11 >= 0 && (*(*(num11 * 8 + *(int*)(this.GameDebugWorld + 2928 / sizeof(GWorld)) + 4) + 844) & 1) != 0)
						{
							this.DragMode = 32;
							this.TurnUnitIdx = num11;
						}
						else
						{
							this.DragMode = 33;
						}
						this.DragY = num2 + 0.1f;
						this.CommandMode = 0;
					}
				}
				else if (dragMode != 18)
				{
					this.DragMX = e.X;
					this.DragMY = e.Y;
					this.DragMode = 19;
					this.CommandMode = 0;
					<Module>.ShowCursor(0);
				}
			}
			else if (e.Button == MouseButtons.Middle)
			{
				this.CompletePressedDrag(e.X, e.Y);
				this.CancelDepressedDrag(true);
				this.DragMX = e.X;
				this.DragMY = e.Y;
				this.DragMode = 18;
				this.panMainViewport.Capture = true;
				<Module>.ShowCursor(0);
			}
		}

		private unsafe void DebugMouseUp(object sender, MouseEventArgs e)
		{
			int dragMode = this.DragMode;
			if (dragMode == 33 || dragMode == 32)
			{
				int control = (int)(*(ref this.KeyTimes + 136));
				if (this.LastClickTimeRightButton != 0L && Math.Abs(this.DragMX - e.X) <= 4 && Math.Abs(this.DragMY - e.Y) <= 4 && <Module>.GTimer.GetTimeH(<Module>.Timer) - this.LastClickTimeRightButton <= 200000L)
				{
					control = 1;
					this.LastClickTime = 0L;
					this.LastClickTimeRightButton = 0L;
				}
				else
				{
					this.LastClickTimeRightButton = <Module>.GTimer.GetTimeH(<Module>.Timer);
					this.DragMX = e.X;
					this.DragMY = e.Y;
				}
				this.ExecuteDebugCommand(e.X, e.Y, control, this.CommandMode);
				this.DragMode = 0;
				this.CommandMode = 0;
			}
			if (this.DragMode == 30)
			{
				<Module>.GWorld.ClearBoxSelection(this.GameDebugWorld);
				if (this.DragStarted)
				{
					this.LastClickTime = 0L;
					this.LastClickTimeRightButton = 0L;
					int num;
					if (*(ref this.KeyTimes + 128) != 0L)
					{
						num = 5;
					}
					else
					{
						num = 16;
					}
					int num2 = *(int*)this.IViewport + 60;
					GPyramid gPyramid;
					<Module>.GWorld.SelectUnit(this.GameDebugWorld, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), this.IViewport, ref gPyramid, this.DragMX, this.DragMY, e.X, e.Y, *num2), num);
				}
				else
				{
					int num3;
					if (*(ref this.KeyTimes + 128) != 0L)
					{
						num3 = 17;
					}
					else
					{
						num3 = 16;
					}
					int num4 = *(int*)this.IViewport + 56;
					GRay gRay;
					this.LastClickUnit = <Module>.GWorld.SelectUnit(this.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, e.X, e.Y, *num4), num3);
				}
			}
			this.CompletePressedDrag(e.X, e.Y);
		}

		private unsafe void DebugMouseMove(object sender, MouseEventArgs e)
		{
			int num = *(int*)this.IViewport + 56;
			GRay gRay;
			float x;
			float num2;
			float z;
			<Module>.GWorld.GetTarget(this.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, e.X, e.Y, *num), ref x, ref num2, ref z);
			int dragMode = this.DragMode;
			if (dragMode != 18)
			{
				if (dragMode != 19)
				{
					if (dragMode != 30)
					{
						this.MouseUpdateDefault(e.X, e.Y, x, z);
					}
					else
					{
						int num3;
						if (!this.DragStarted && Math.Abs(this.DragMX - e.X) <= 4 && Math.Abs(this.DragMY - e.Y) <= 4)
						{
							num3 = 0;
						}
						else
						{
							num3 = 1;
						}
						byte b = (byte)num3;
						this.DragStarted = (b != 0);
						if (b != 0)
						{
							<Module>.GWorld.SetBoxSelection(this.GameDebugWorld, this.DragMX, this.DragMY, e.X, e.Y);
							int num4 = *(int*)this.IViewport + 60;
							GPyramid gPyramid;
							<Module>.GWorld.SelectUnit(this.GameDebugWorld, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), this.IViewport, ref gPyramid, this.DragMX, this.DragMY, e.X, e.Y, *num4), 33);
						}
						else
						{
							this.MouseUpdateDefault(e.X, e.Y, x, z);
						}
					}
				}
				else if ((this.DragStarted || Math.Abs(e.X - this.DragMX) >= 2 || Math.Abs(e.Y - this.DragMY) >= 2) && (e.X != this.DragMX || e.Y != this.DragMY))
				{
					this.DragStarted = true;
					<Module>.GWorld.CameraMove(this.GameDebugWorld, (float)((double)(this.DragMY - e.Y) * 0.02), (float)((double)(e.X - this.DragMX) * 0.02));
					Point p = new Point(this.DragMX, this.DragMY);
					p = this.panMainViewport.PointToScreen(p);
					<Module>.SetCursorPos(p.X, p.Y);
				}
			}
			else if (e.X != this.DragMX || e.Y != this.DragMY)
			{
				<Module>.GWorld.CameraRotate(this.GameDebugWorld, (float)((double)(e.X - this.DragMX) * 0.002), (float)((double)(e.Y - this.DragMY) * 0.002));
				Point p2 = new Point(this.DragMX, this.DragMY);
				p2 = this.panMainViewport.PointToScreen(p2);
				<Module>.SetCursorPos(p2.X, p2.Y);
			}
		}

		private unsafe void MouseUpdateDefault(int m_x, int m_y, float x, float z)
		{
			GIViewport* iViewport = this.IViewport;
			GRay gRay;
			int num = <Module>.GWorld.GetTargetUnit(this.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay, m_x, m_y, *(*(int*)iViewport + 56)));
			if (this.panMainViewport.Focused)
			{
				<Module>.GWorld.SelectUnit(this.GameDebugWorld, num, 33);
				if (num < 0)
				{
					GPoint2 gPoint = x;
					*(ref gPoint + 4) = z;
					GCircle gCircle;
					<Module>.GGameLogic.IntersectionWithStaticObjects(<Module>.GCircle.{ctor}(ref gCircle, ref gPoint, 0.25f), 67);
				}
			}
			else
			{
				<Module>.GWorld.SelectUnit(this.GameDebugWorld, 1);
				<Module>.SetCursor(null);
			}
		}

		private void StartDebugCommand(int command)
		{
			this.StartDebugCommand(command, true);
		}

		private unsafe void StartDebugCommand(int command, [MarshalAs(UnmanagedType.U1)] bool cancellast)
		{
			if (*(ref this.AvailableCommands + command) != 0)
			{
				if (cancellast)
				{
					this.CancelDebugCommand();
				}
				this.DragMode = 31;
				this.CommandMode = command;
			}
		}

		private void CancelDebugCommand()
		{
			this.CommandMode = 0;
			this.DragMode = 0;
			this.panMainViewport.Capture = false;
		}

		private unsafe void ExecuteDebugCommand(int m_x, int m_y, int control, int command)
		{
			GIViewport* iViewport = this.IViewport;
			GRay gRay;
			int num = <Module>.GWorld.GetTargetUnit(this.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay, m_x, m_y, *(*(int*)iViewport + 56)));
			int dragMode = this.DragMode;
			if (((dragMode != 33 && dragMode != 32) || (m_x == this.DragMX && m_y == this.DragMY)) && num > -1)
			{
				int commandMode = this.CommandMode;
				if (commandMode != 1)
				{
					if (commandMode != 7)
					{
						byte b;
						if (*(ref this.KeyTimes + 128) != 0L)
						{
							b = 1;
						}
						else
						{
							b = 0;
						}
						<Module>.?QUnitCommandWithUnit@GGameLogic@@$$FQAEXW4GTargetTask@@H_N@Z(<Module>.GameLogic, 1, num, b != 0);
					}
					else
					{
						byte b2;
						if (*(ref this.KeyTimes + 128) != 0L)
						{
							b2 = 1;
						}
						else
						{
							b2 = 0;
						}
						<Module>.?QUnitCommandWithUnitAndGunnertype@GGameLogic@@$$FQAEXW4GTargetTask@@HW4GGunnerType@@_N@Z(<Module>.GameLogic, 5, num, 0, b2 != 0);
					}
				}
				else
				{
					byte b3;
					if (*(ref this.KeyTimes + 128) != 0L)
					{
						b3 = 1;
					}
					else
					{
						b3 = 0;
					}
					<Module>.?QUnitCommandWithUnit@GGameLogic@@$$FQAEXW4GTargetTask@@H_N@Z(<Module>.GameLogic, 2, num, b3 != 0);
				}
			}
			else
			{
				iViewport = this.IViewport;
				GRay gRay2;
				float num2;
				float num3;
				float num4;
				<Module>.GWorld.GetTarget(this.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay2, m_x, m_y, *(*(int*)iViewport + 56)), ref num2, ref num3, ref num4);
				if (<Module>.GWorld.IsParcelPlayable(this.GameDebugWorld, num2, num4) != null)
				{
					int commandMode2 = this.CommandMode;
					if (commandMode2 != 1)
					{
						if (commandMode2 != 2)
						{
							if (commandMode2 != 7)
							{
								if (this.DragMode == 32)
								{
									byte b4;
									if (*(ref this.KeyTimes + 128) != 0L)
									{
										b4 = 1;
									}
									else
									{
										b4 = 0;
									}
									int num5 = *(this.TurnUnitIdx * 8 + *(int*)(this.GameDebugWorld + 2928 / sizeof(GWorld)) + 4);
									float num6 = num2 - *(num5 + 528);
									float num7 = num4 - *(num5 + 536);
									float num8 = (float)Math.Atan2((double)num6, (double)num7);
									<Module>.?QUnitCommandWithDir@GGameLogic@@$$FQAEXW4GTargetTask@@M_N@Z(<Module>.GameLogic, 2, num8, b4 != 0);
								}
								else
								{
									float num9 = num2 - this.DragX;
									float num10 = num9;
									if ((double)((float)Math.Abs((double)num10)) < 0.05)
									{
										float num11 = num4 - this.DragZ;
										if ((double)((float)Math.Abs((double)num11)) < 0.05)
										{
											byte b5;
											if (*(ref this.KeyTimes + 128) != 0L)
											{
												b5 = 1;
											}
											else
											{
												b5 = 0;
											}
											<Module>.?QUnitCommandWithPoint@GGameLogic@@$$FQAEXW4GTargetTask@@MM_N@Z(<Module>.GameLogic, 2, num2, num4, b5 != 0);
											return;
										}
									}
									byte b6;
									if (*(ref this.KeyTimes + 128) != 0L)
									{
										b6 = 1;
									}
									else
									{
										b6 = 0;
									}
									float num12 = num9;
									float num13 = num4 - this.DragZ;
									float num14 = (float)Math.Atan2((double)num12, (double)num13);
									<Module>.?QUnitCommandWithPointAndDir@GGameLogic@@$$FQAEXW4GTargetTask@@MMM_N@Z(<Module>.GameLogic, 2, this.DragX, this.DragZ, num14, b6 != 0);
								}
							}
							else
							{
								byte b7;
								if (*(ref this.KeyTimes + 128) != 0L)
								{
									b7 = 1;
								}
								else
								{
									b7 = 0;
								}
								<Module>.?QUnitCommandWithPoint@GGameLogic@@$$FQAEXW4GTargetTask@@MM_N@Z(<Module>.GameLogic, 7, num2, num4, b7 != 0);
							}
						}
						else
						{
							float num9 = num2 - this.DragX;
							float num15 = num9;
							if ((double)((float)Math.Abs((double)num15)) < 0.05)
							{
								float num16 = num4 - this.DragZ;
								if ((double)((float)Math.Abs((double)num16)) < 0.05)
								{
									byte b8;
									if (*(ref this.KeyTimes + 128) != 0L)
									{
										b8 = 1;
									}
									else
									{
										b8 = 0;
									}
									<Module>.GGameLogic.QMoveBackwardToPoint(<Module>.GameLogic, num2, num4, b8 != 0);
									return;
								}
							}
							byte b9;
							if (*(ref this.KeyTimes + 128) != 0L)
							{
								b9 = 1;
							}
							else
							{
								b9 = 0;
							}
							float num17 = num9;
							float num18 = num4 - this.DragZ;
							float num19 = (float)Math.Atan2((double)num17, (double)num18);
							<Module>.GGameLogic.QMoveBackwardToPointWithDir(<Module>.GameLogic, this.DragX, this.DragZ, num19, b9 != 0);
						}
					}
					else
					{
						float num9 = num2 - this.DragX;
						float num20 = num9;
						if ((double)((float)Math.Abs((double)num20)) < 0.05)
						{
							float num21 = num4 - this.DragZ;
							if ((double)((float)Math.Abs((double)num21)) < 0.05)
							{
								byte b10;
								if (*(ref this.KeyTimes + 128) != 0L)
								{
									b10 = 1;
								}
								else
								{
									b10 = 0;
								}
								<Module>.?QUnitCommandWithPoint@GGameLogic@@$$FQAEXW4GTargetTask@@MM_N@Z(<Module>.GameLogic, 2, num2, num4, b10 != 0);
								return;
							}
						}
						byte b11;
						if (*(ref this.KeyTimes + 128) != 0L)
						{
							b11 = 1;
						}
						else
						{
							b11 = 0;
						}
						float num22 = num9;
						float num23 = num4 - this.DragZ;
						float num24 = (float)Math.Atan2((double)num22, (double)num23);
						<Module>.?QUnitCommandWithPointAndDir@GGameLogic@@$$FQAEXW4GTargetTask@@MMM_N@Z(<Module>.GameLogic, 2, this.DragX, this.DragZ, num24, b11 != 0);
					}
				}
			}
		}

		private void menuFileNew_Click(object sender, EventArgs e)
		{
			if (this.SaveDocumentIfChanged())
			{
				NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 8, true);
				nFileDialog.AvailableModes = 11;
				nFileDialog.SelectedMode = 1;
				nFileDialog.DefaultExtension = "map";
				if (nFileDialog.ShowDialog() == DialogResult.OK)
				{
					if (nFileDialog.SelectedMode == 1)
					{
						this.NewDocument(nFileDialog.NewWidht, nFileDialog.NewHeight);
					}
					else
					{
						this.OpenDocument(nFileDialog.FilePath);
						nFileDialog.UpdateRecentFiles();
						<Module>.SaveOptions();
					}
				}
			}
		}

		private void menuFileOpen_Click(object sender, EventArgs e)
		{
			if (this.SaveDocumentIfChanged())
			{
				NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 8, true);
				nFileDialog.AvailableModes = 11;
				nFileDialog.SelectedMode = 2;
				nFileDialog.DefaultExtension = "map";
				if (nFileDialog.ShowDialog() == DialogResult.OK)
				{
					if (nFileDialog.SelectedMode == 1)
					{
						this.NewDocument(nFileDialog.NewWidht, nFileDialog.NewHeight);
					}
					else
					{
						this.OpenDocument(nFileDialog.FilePath);
						nFileDialog.UpdateRecentFiles();
						<Module>.SaveOptions();
					}
				}
			}
		}

		private void menuFileOpenRecent_Click(object sender, EventArgs e)
		{
			if (this.SaveDocumentIfChanged())
			{
				NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 8, true);
				nFileDialog.AvailableModes = 11;
				nFileDialog.SelectedMode = 8;
				nFileDialog.DefaultExtension = "map";
				if (nFileDialog.ShowDialog() == DialogResult.OK)
				{
					if (nFileDialog.SelectedMode == 1)
					{
						this.NewDocument(nFileDialog.NewWidht, nFileDialog.NewHeight);
					}
					else
					{
						this.OpenDocument(nFileDialog.FilePath);
						nFileDialog.UpdateRecentFiles();
						<Module>.SaveOptions();
					}
				}
			}
		}

		private unsafe void menuFileSave_Click(object sender, EventArgs e)
		{
			if (this.World != null)
			{
				if (((*(int*)(this.MapFileName + 4 / sizeof(GBaseString<char>)) == 0) ? 1 : 0) != 0)
				{
					this.menuFileSaveAs_Click(sender, e);
				}
				else
				{
					this.SaveDocument();
				}
			}
		}

		private void menuFileSaveAs_Click(object sender, EventArgs e)
		{
			if (this.World != null)
			{
				NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 8, true);
				nFileDialog.AvailableModes = 4;
				nFileDialog.SelectedMode = 4;
				nFileDialog.DefaultExtension = "map";
				if (nFileDialog.ShowDialog() == DialogResult.OK)
				{
					<Module>.GBaseString<char>.=(this.MapFileName, nFileDialog.FilePath);
					this.SaveDocument();
					nFileDialog.UpdateRecentFiles();
					<Module>.SaveOptions();
				}
			}
		}

		private void menuFileExport_Click(object sender, EventArgs e)
		{
			if (this.World != null)
			{
				NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 20, true);
				nFileDialog.AvailableModes = 4;
				nFileDialog.SelectedMode = 4;
				nFileDialog.DefaultExtension = "xsimap";
				if (nFileDialog.ShowDialog() == DialogResult.OK)
				{
					<Module>.GBaseString<char>.=(this.ExportMapFileName, nFileDialog.FilePath);
					this.ExportMap();
					nFileDialog.UpdateRecentFiles();
					<Module>.SaveOptions();
				}
			}
		}

		private void menuFileImportCam_Click(object sender, EventArgs e)
		{
			if (this.World != null)
			{
				NFileDialog nFileDialog = new NFileDialog(ref <Module>.Options + 32, true);
				nFileDialog.AvailableModes = 2;
				nFileDialog.SelectedMode = 2;
				nFileDialog.DefaultExtension = "4dpcam";
				if (nFileDialog.ShowDialog() == DialogResult.OK)
				{
					<Module>.GBaseString<char>.=(this.ImportCamFileName, nFileDialog.FilePath);
					this.ImportCamera();
					nFileDialog.UpdateRecentFiles();
					<Module>.SaveOptions();
				}
			}
		}

		private void menuFileRemoveImportCam_Click(object sender, EventArgs e)
		{
			this.RemoveImportCamera();
		}

		private void menuFileExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void tbMain_ButtonClick(int idx, int radio_group)
		{
			this.TemporaryModeChange = false;
			if (radio_group == 1)
			{
				this.SetEditorMode(idx);
			}
			else if (idx == 200)
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
			else if (idx == 203)
			{
				this.menuEditCut_Click(null, null);
			}
			else if (idx == 204)
			{
				this.menuEditCopy_Click(null, null);
			}
			else if (idx == 205)
			{
				this.menuEditPaste_Click(null, null);
			}
			else if (idx == 206)
			{
				this.menuEditDelete_Click(null, null);
			}
			else if (idx == 209)
			{
				this.menuToolsScriptEditor_Click(null, null);
			}
			else if (idx == 210)
			{
				this.RunMap();
			}
			else if (idx == 211)
			{
				this.DebugMap();
			}
		}

		private unsafe void tbDebug_ButtonClick(int idx, int radio_group)
		{
			this.tbDebug.SetItemPushed(213, false);
			this.tbDebug.SetItemPushed(214, false);
			this.tbDebug.SetItemPushed(216, false);
			this.tbDebug.SetItemPushed(217, false);
			if (radio_group == 3)
			{
				this.SetDebugMode(idx);
			}
			else
			{
				switch (idx)
				{
				case 212:
					this.EndDebugMap();
					break;
				case 213:
					this.SetPlaySpeed(0);
					this.tbDebug.SetItemPushed(213, true);
					break;
				case 214:
					this.SetPlaySpeed(1);
					this.tbDebug.SetItemPushed(214, true);
					break;
				case 215:
					if (<Module>.GGameLogic.GetPlaySpeed(<Module>.GameLogic) == null)
					{
						<Module>.GGameLogic.RefreshMicroFrame(<Module>.GameLogic);
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), <Module>.Scene, 25000L, *(*(int*)<Module>.Scene + 32));
					}
					else
					{
						this.SetPlaySpeed(0);
					}
					this.tbDebug.SetItemPushed(213, true);
					break;
				case 216:
					this.SetPlaySpeed(2);
					this.tbDebug.SetItemPushed(216, true);
					break;
				case 217:
					this.SetPlaySpeed(4);
					this.tbDebug.SetItemPushed(217, true);
					break;
				}
			}
		}

		private unsafe void OnIdle(object sender, EventArgs e)
		{
			if (this.LayoutChanged)
			{
				this.RearrangeToolbars();
				this.LayoutChanged = false;
				base.PerformLayout(this.panSideBar, new string((sbyte*)(&<Module>.??_C@_06OJKCFPBI@Bounds?$AA@)));
				if (this.CurrentMinimap != null)
				{
					this.RefreshMinimap();
				}
			}
			if (base.ContainsFocus)
			{
				this.panMainViewport.Invalidate(false);
			}
			long num = <Module>.GTimer.GetTimeH(<Module>.Timer);
			if (this.LastCamViewPortUpdate == 0L)
			{
				this.LastCamViewPortUpdate = num;
			}
			long elapsed = num - this.LastCamViewPortUpdate;
			this.LastCamViewPortUpdate = num;
			byte force_refresh = (this.EditorMode != 16) ? 1 : 0;
			this.UpdateCameraCurvePreview(elapsed, force_refresh != 0);
		}

		private unsafe void NMainForm_Load(object sender, EventArgs e)
		{
			<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), 2173, (sbyte*)(&<Module>.??_C@_0CF@NJHDLMN@NWorkshop?3?3NMainForm?3?3NMainForm_@));
			<Module>.GLogger.Log(0, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.EnableMenuAndToolbarItems(false);
			<Module>.LoadOptions();
			if (*(ref <Module>.Options + 4) == 1)
			{
				base.SuspendLayout();
				this.panSideBar.Dock = DockStyle.Right;
				this.splitMain.Dock = DockStyle.Right;
				base.ResumeLayout();
				this.menuViewSidebarLeft.Checked = false;
				this.menuViewSidebarRight.Checked = true;
				this.menuViewSidebarOff.Checked = false;
			}
			else if (*(ref <Module>.Options + 4) == 2)
			{
				base.SuspendLayout();
				this.panSideBar.Visible = false;
				this.splitMain.Visible = false;
				base.ResumeLayout();
				this.menuViewSidebarLeft.Checked = false;
				this.menuViewSidebarRight.Checked = false;
				this.menuViewSidebarOff.Checked = true;
			}
			if (<Module>.Options == null)
			{
				this.menuViewToolbar.Checked = false;
				this.tbMain.Visible = false;
			}
			if (*(ref <Module>.Options + 1) == 0)
			{
				this.menuViewStatusBar.Checked = false;
				this.sbMain.Visible = false;
			}
			GEngineInitParams gEngineInitParams;
			<Module>.GEngineInitParams.{ctor}(ref gEngineInitParams);
			GMeasures gMeasures;
			<Module>.GMeasures.{ctor}(ref gMeasures, <Module>.Measures, 1f);
			gEngineInitParams = this.panMainViewport.Handle.ToPointer();
			*(ref gEngineInitParams + 4) = *(ref <Module>.Options + 84);
			*(ref gEngineInitParams + 12) = ref gMeasures;
			<Module>.EngineInitialize(ref gEngineInitParams);
			int num = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, *(*(int*)<Module>.IEngine + 96));
			this.IRenderTarget = num;
			GHandle<19> gHandle<19>;
			num = calli(GHandle<19>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>*), num, ref gHandle<19>, *(*num + 16));
			cpblk(this.ND, num, 4);
			GIRenderTarget* iRenderTarget = this.IRenderTarget;
			this.IViewport = calli(GIViewport* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), iRenderTarget, 0, *(*(int*)iRenderTarget + 32));
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 34, 1, *(*(int*)<Module>.IEngine + 16));
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 17, 1, *(*(int*)<Module>.IEngine + 16));
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 10, 1, *(*(int*)<Module>.IEngine + 16));
			int num2 = *(int*)<Module>.IEngine;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 0, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, *(num2 + 32)), *(num2 + 16));
			GHandle<12> gHandle<12>;
			num2 = calli(GHandle<12>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>*,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, ref gHandle<12>, ref <Module>.??_C@_0BN@LLMEMFNI@menu?1fonts?1sans_serif_14?4gui?$AA@, *(*(int*)<Module>.IEngine + 128));
			cpblk(this.ND + 4 / sizeof(GNativeData), num2, 4);
			GHandle<12> gHandle<12>2;
			num2 = calli(GHandle<12>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>*,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, ref gHandle<12>2, ref <Module>.??_C@_0CA@EFIECEJB@menu?1fonts?1medium_shadow?4ttfont?$AA@, *(*(int*)<Module>.IEngine + 128));
			cpblk(this.ND + 8 / sizeof(GNativeData), num2, 4);
			GHandle<12> gHandle<12>3;
			num2 = calli(GHandle<12>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>*,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, ref gHandle<12>3, ref <Module>.??_C@_0BP@MPLAGJCI@menu?1fonts?1large_shadow?4ttfont?$AA@, *(*(int*)<Module>.IEngine + 128));
			cpblk(this.ND + 12 / sizeof(GNativeData), num2, 4);
			GRect gRect = 8;
			*(ref gRect + 4) = 8;
			*(ref gRect + 8) = 0;
			*(ref gRect + 12) = 0;
			GHandle<19> gHandle<19>2;
			int num3 = calli(GHandle<19>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>*,System.Int32,GHandle<19>,GRect,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.ILayout, ref gHandle<19>2, 3, *(GHandle<19>*)this.ND, gRect, 5, *(*(int*)<Module>.ILayout));
			cpblk(this.ND + 16 / sizeof(GNativeData), num3, 4);
			GRect gRect2 = 8;
			*(ref gRect2 + 4) = 26;
			*(ref gRect2 + 8) = 0;
			*(ref gRect2 + 12) = 0;
			GHandle<19> gHandle<19>3;
			int num4 = calli(GHandle<19>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>*,System.Int32,GHandle<19>,GRect,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.ILayout, ref gHandle<19>3, 3, *(GHandle<19>*)this.ND, gRect2, 5, *(*(int*)<Module>.ILayout));
			cpblk(this.ND + 20 / sizeof(GNativeData), num4, 4);
			GRect gRect3 = 8;
			*(ref gRect3 + 4) = 44;
			*(ref gRect3 + 8) = 0;
			*(ref gRect3 + 12) = 0;
			GHandle<19> gHandle<19>4;
			int num5 = calli(GHandle<19>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>*,System.Int32,GHandle<19>,GRect,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.ILayout, ref gHandle<19>4, 3, *(GHandle<19>*)this.ND, gRect3, 5, *(*(int*)<Module>.ILayout));
			cpblk(this.ND + 24 / sizeof(GNativeData), num5, 4);
			GUnitRegistry* ptr = <Module>.@new(60u);
			GUnitRegistry* unitRegistry;
			try
			{
				if (ptr != null)
				{
					unitRegistry = <Module>.GUnitRegistry.{ctor}(ptr);
				}
				else
				{
					unitRegistry = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr);
				throw;
			}
			<Module>.UnitRegistry = unitRegistry;
			Application.Idle += new EventHandler(this.OnIdle);
			this.panMainViewport.MouseWheel += new MouseEventHandler(this.panMainViewport_MouseWheel);
			this.panMainViewport.KeyDown += new KeyEventHandler(this.panMainViewport_KeyDown);
			this.panMainViewport.KeyUp += new KeyEventHandler(this.panMainViewport_KeyUp);
			ToolboxVertex toolboxVertex = new ToolboxVertex();
			this.VertexTools = toolboxVertex;
			toolboxVertex.Text = "Vertex";
			this.VertexTools.BrushTypeChanged += new ToolboxVertex.__Delegate_BrushTypeChanged(this.toolboxVertex_BrushTypeChanged);
			this.VertexTools.BrushParametersChanged += new BrushTools.BrushParametersChangeHandler(this.toolboxVertex_BrushParametersChanged);
			this.VertexTools.BrushFalloffTypeChanged += new ToolboxVertex.BrushTypeChangeHandler(this.BrushFalloffTypeChanged);
			this.VertexTools.VertexFlagChanged += new ToolboxVertex.VertexFlagChangeHandler(this.BrushFlagChanged);
			this.VertexTools.SelectionTypeChanged += new ToolboxVertex.SelectionTypeChangedHandler(this.SelectionTypeChanged);
			this.VertexTools.InvertSelection += new ToolboxVertex.InvertSelectionHandler(this.InvertSelection);
			string[] extensions = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_03MBBDFFBP@4dp?$AA@)),
				new string((sbyte*)(&<Module>.??_C@_02CCENMFAC@4d?$AA@))
			};
			FilePickerControl filePickerControl = new FilePickerControl();
			this.ObjectFilePicker = filePickerControl;
			filePickerControl.Text = "Objects";
			this.ObjectFilePicker.Root = "Objects";
			this.ObjectFilePicker.ThumbRoot = "Objects";
			this.ObjectFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.ObjectFilePicker.ThumbMode = ThumbnailServer.ThumbType.Model;
			this.ObjectFilePicker.Extensions = extensions;
			this.ObjectFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.ObjectTools = new ToolboxEntities(ref <Module>.NWorkshop.ObjectTools);
			this.ObjectTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.ObjectTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.ObjectTools.Text = "Object manipulators";
			string[] extensions2 = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_03BFLBBCNI@mat?$AA@))
			};
			FilePickerControl filePickerControl2 = new FilePickerControl();
			this.RoadFilePicker = filePickerControl2;
			filePickerControl2.Text = "Roads";
			this.RoadFilePicker.Root = "Roads";
			this.RoadFilePicker.ThumbRoot = "Roads";
			this.RoadFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.RoadFilePicker.ThumbMode = ThumbnailServer.ThumbType.Tile;
			this.RoadFilePicker.Extensions = extensions2;
			this.RoadFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.RoadTools = new ToolboxEntities(ref <Module>.NWorkshop.RoadTools);
			this.RoadTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.RoadTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.RoadTools.DecalAction += new ToolboxActionHandler(this.EntityDecalAction);
			this.RoadTools.Text = "Road manipulators";
			this.NavPointTools = new ToolboxEntities(ref <Module>.NWorkshop.NavPointTools);
			this.NavPointTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.NavPointTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.NavPointTools.Text = "Navigation point manipulators";
			string[] extensions3 = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_03BFLBBCNI@mat?$AA@))
			};
			FilePickerControl filePickerControl3 = new FilePickerControl();
			this.DecalFilePicker = filePickerControl3;
			filePickerControl3.Text = "Decals";
			this.DecalFilePicker.Root = "Decals";
			this.DecalFilePicker.ThumbRoot = "Decals";
			this.DecalFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.DecalFilePicker.ThumbMode = ThumbnailServer.ThumbType.Material;
			this.DecalFilePicker.Extensions = extensions3;
			this.DecalFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.DecalTools = new ToolboxEntities(ref <Module>.NWorkshop.DecalTools);
			this.DecalTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.DecalTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.DecalTools.DecalAction += new ToolboxActionHandler(this.EntityDecalAction);
			this.DecalTools.Text = "Decal manipulators";
			string[] extensions4 = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_05NGCECGPF@fluid?$AA@)),
				new string((sbyte*)(&<Module>.??_C@_03KJMBPJEB@fog?$AA@))
			};
			FilePickerControl filePickerControl4 = new FilePickerControl();
			this.LakeFilePicker = filePickerControl4;
			filePickerControl4.Text = "Fluids";
			this.LakeFilePicker.Root = "Water";
			this.LakeFilePicker.ThumbRoot = "Water";
			this.LakeFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.LakeFilePicker.ThumbMode = ThumbnailServer.ThumbType.Fluid;
			this.LakeFilePicker.Extensions = extensions4;
			this.LakeFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.LakeTools = new ToolboxEntities(ref <Module>.NWorkshop.LakeTools);
			this.LakeTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.LakeTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.LakeTools.Text = "Lake manipulators";
			string[] extensions5 = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_05NGCECGPF@fluid?$AA@))
			};
			FilePickerControl filePickerControl5 = new FilePickerControl();
			this.RiverFilePicker = filePickerControl5;
			filePickerControl5.Text = "Fluids";
			this.RiverFilePicker.Root = "Water";
			this.RiverFilePicker.ThumbRoot = "Water";
			this.RiverFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.RiverFilePicker.ThumbMode = ThumbnailServer.ThumbType.Fluid;
			this.RiverFilePicker.Extensions = extensions5;
			this.RiverFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.RiverTools = new ToolboxEntities(ref <Module>.NWorkshop.RiverTools);
			this.RiverTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.RiverTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.RiverTools.Text = "River manipulators";
			this.CameraCurveTools = new ToolboxEntities(ref <Module>.NWorkshop.CameraCurveTools);
			this.CameraCurveTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.CameraCurveTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.CameraCurveTools.Action += new ToolboxActionHandler(this.EntityAction);
			this.CameraCurveTools.Text = "CameraCurve manipulators";
			ToolboxScriptEntities toolboxScriptEntities = new ToolboxScriptEntities(2);
			this.CameraCurveProps = toolboxScriptEntities;
			toolboxScriptEntities.Text = "CameraCurve properties";
			this.PathTools = new ToolboxEntities(ref <Module>.NWorkshop.PathTools);
			this.PathTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.PathTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.PathTools.Action += new ToolboxActionHandler(this.EntityAction);
			this.PathTools.Text = "Path manipulators";
			ToolboxScriptEntities toolboxScriptEntities2 = new ToolboxScriptEntities(0);
			this.PathProps = toolboxScriptEntities2;
			toolboxScriptEntities2.Text = "Path properties";
			this.LocationTools = new ToolboxEntities(ref <Module>.NWorkshop.LocationTools);
			this.LocationTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.LocationTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.LocationTools.Action += new ToolboxActionHandler(this.EntityAction);
			this.LocationTools.Text = "Location manipulators";
			toolboxScriptEntities2 = new ToolboxScriptEntities(1);
			this.LocationProps = toolboxScriptEntities2;
			toolboxScriptEntities2.Text = "Location properties";
			toolboxScriptEntities2 = new ToolboxScriptEntities(3);
			this.UnitGroupProps = toolboxScriptEntities2;
			toolboxScriptEntities2.Text = "Unit AI group properties";
			this.ObjectiveTools = new ToolboxEntities(ref <Module>.NWorkshop.ObjectiveTools);
			this.ObjectiveTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.ObjectiveTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.ObjectiveTools.Action += new ToolboxActionHandler(this.EntityAction);
			this.ObjectiveTools.Text = "Objective manipulators";
			toolboxScriptEntities2 = new ToolboxScriptEntities(6);
			this.ObjectiveProps = toolboxScriptEntities2;
			toolboxScriptEntities2.Text = "Objective properties";
			string[] extensions6 = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_04NPEDKLDA@unit?$AA@))
			};
			FilePickerControl filePickerControl6 = new FilePickerControl();
			this.BuildingFilePicker = filePickerControl6;
			filePickerControl6.Text = "Buildings";
			this.BuildingFilePicker.Root = "Buildings";
			this.BuildingFilePicker.ThumbRoot = "Buildings";
			this.BuildingFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.BuildingFilePicker.ThumbMode = ThumbnailServer.ThumbType.Unit;
			this.BuildingFilePicker.Extensions = extensions6;
			this.BuildingFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.BuildingFilePicker.ContextPopup += new FilePickerControl.ContextMenuPopupHandler(this.BuildingFilePicker_ContextPopup);
			this.BuildingTools = new ToolboxEntities(ref <Module>.NWorkshop.BuildingTools);
			this.BuildingTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.BuildingTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.BuildingTools.Text = "Building manipulators";
			ToolboxBuildingProperties toolboxBuildingProperties = new ToolboxBuildingProperties();
			this.BuildingPropertiesTools = toolboxBuildingProperties;
			toolboxBuildingProperties.Text = "Building properties";
			this.BuildingPropertiesTools.PropertiesChanged += new ToolboxBuildingProperties.__Delegate_PropertiesChanged(this.toolboxUnitProperties_PropertiesChanged);
			string[] extensions7 = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_04NPEDKLDA@unit?$AA@))
			};
			FilePickerControl filePickerControl7 = new FilePickerControl();
			this.UnitFilePicker = filePickerControl7;
			filePickerControl7.Text = "Units";
			this.UnitFilePicker.Root = "Units";
			this.UnitFilePicker.ThumbRoot = "Units";
			this.UnitFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.UnitFilePicker.ThumbMode = ThumbnailServer.ThumbType.Unit;
			this.UnitFilePicker.Extensions = extensions7;
			this.UnitFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.UnitFilePicker.ContextPopup += new FilePickerControl.ContextMenuPopupHandler(this.UnitFilePicker_ContextPopup);
			this.UnitTools = new ToolboxEntities(ref <Module>.NWorkshop.UnitTools);
			this.UnitTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.UnitTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.UnitTools.Text = "Unit manipulators";
			ToolboxPlayer toolboxPlayer = new ToolboxPlayer();
			this.PlayerTools = toolboxPlayer;
			toolboxPlayer.Text = "Player selection";
			this.PlayerTools.PlayerChanged += new ToolboxPlayer.__Delegate_PlayerChanged(this.toolboxPlayer_PlayerChanged);
			this.PlayerTools.EditPlayerProperties += new ToolboxPlayer.__Delegate_EditPlayerProperties(this.toolboxPlayer_EditPlayerProperties);
			ToolboxUnitProperties toolboxUnitProperties = new ToolboxUnitProperties();
			this.UnitPropertiesTools = toolboxUnitProperties;
			toolboxUnitProperties.Text = "Unit properties";
			this.UnitPropertiesTools.PropertiesChanged += new ToolboxUnitProperties.__Delegate_PropertiesChanged(this.toolboxUnitProperties_PropertiesChanged);
			string[] extensions8 = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_03BICDMHKB@wav?$AA@))
			};
			FilePickerControl filePickerControl8 = new FilePickerControl();
			this.SoundFilePicker = filePickerControl8;
			filePickerControl8.Text = "Sounds";
			this.SoundFilePicker.Root = "Sounds";
			this.SoundFilePicker.ThumbRoot = "Sounds";
			this.SoundFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.SoundFilePicker.ThumbMode = ThumbnailServer.ThumbType.Sound;
			this.SoundFilePicker.Extensions = extensions8;
			this.SoundFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.SoundTools = new ToolboxEntities(ref <Module>.NWorkshop.SoundTools);
			this.SoundTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.SoundTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.SoundTools.Text = "Sound manipulators";
			string[] extensions9 = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_02KLACGCIB@fx?$AA@))
			};
			FilePickerControl filePickerControl9 = new FilePickerControl();
			this.EffectFilePicker = filePickerControl9;
			filePickerControl9.Text = "Effects";
			this.EffectFilePicker.Root = "Effects";
			this.EffectFilePicker.ThumbRoot = "Effects";
			this.EffectFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.EffectFilePicker.ThumbMode = ThumbnailServer.ThumbType.Effect;
			this.EffectFilePicker.Extensions = extensions9;
			this.EffectFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.EffectTools = new ToolboxEntities(ref <Module>.NWorkshop.EffectTools);
			this.EffectTools.ModeChanged += new ToolboxModeHandler(this.EntityModeChanged);
			this.EffectTools.FlagChanged += new ToolboxFlagHandler(this.EntityFlagChanged);
			this.EffectTools.Text = "Effect manipulators";
			string[] extensions10 = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_03KCBANMCB@loc?$AA@))
			};
			FilePickerControl filePickerControl10 = new FilePickerControl();
			this.LocaleFilePicker = filePickerControl10;
			filePickerControl10.Text = "Locals";
			this.LocaleFilePicker.Root = "Locals";
			this.LocaleFilePicker.ThumbRoot = "Locals";
			this.LocaleFilePicker.ViewMode = FilePickerControl.Mode.Treeview;
			this.LocaleFilePicker.ThumbMode = ThumbnailServer.ThumbType.Locale;
			this.LocaleFilePicker.Extensions = extensions10;
			this.LocaleFilePicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			ToolboxTerrain toolboxTerrain = new ToolboxTerrain();
			this.TerrainFilePicker = toolboxTerrain;
			toolboxTerrain.Text = "Terrain layers";
			this.TerrainFilePicker.LayerSelected += new ToolboxTerrain.LayerSet(this.SetAffectedLayer);
			this.TerrainFilePicker.ResetToPaint += new ToolboxTerrain.ResumePaint(this.ResetTerrainTool);
			this.TerrainFilePicker.GUINeedRefreshEvent += new ToolboxTerrain.GUINeedRefreshHandler(this.RefreshMenuAndToolbarItems);
			ToolboxTerrainTools toolboxTerrainTools = new ToolboxTerrainTools();
			this.TerrainTools = toolboxTerrainTools;
			toolboxTerrainTools.Text = "Terrain layer manipulators";
			this.TerrainTools.PaintTypeChanged += new ToolboxTerrainTools.__Delegate_PaintTypeChanged(this.toolboxPainter_BrushTypeChanged);
			this.TerrainTools.BrushParametersChanged += new BrushTools.BrushParametersChangeHandler(this.toolboxPainter_BrushParametersChanged);
			this.TerrainTools.FillSelection += new ToolboxTerrainTools.FillSelectionHandler(this.FillSelection);
			this.TerrainTools.BrushColorChanged += new ToolboxTerrainTools.ColorChangedHandler(this.toolboxPainter_BrushColorChanged);
			ToolboxSectors toolboxSectors = new ToolboxSectors();
			this.SectorTools = toolboxSectors;
			toolboxSectors.Text = "Sector manipulators";
			this.SectorTools.Action += new ToolboxSectors.SectorActionHandler(this.toolboxSectors_OperationActivated);
			ToolboxWeather toolboxWeather = new ToolboxWeather();
			this.WeatherTools = toolboxWeather;
			toolboxWeather.Text = "Weather";
			this.WeatherTools.ValueChanged += new ToolboxWeather.__Delegate_ValueChanged(this.toolboxWeather_ValueChanged);
			ToolboxOptions toolboxOptions = new ToolboxOptions();
			this.OptionsTools = toolboxOptions;
			toolboxOptions.Text = "Options";
			this.OptionsTools.OptionsChanged += new ToolboxOptions.__Delegate_OptionsChanged(this.toolboxOptions_OptionsChanged);
			NDebuggerLog nDebuggerLog = new NDebuggerLog();
			this.LoggerTool = nDebuggerLog;
			nDebuggerLog.Text = "Log";
			NDebuggerUnits nDebuggerUnits = new NDebuggerUnits();
			this.DUnitsTool = nDebuggerUnits;
			nDebuggerUnits.Text = "Unit debugger";
			NDebuggerUnitGroups nDebuggerUnitGroups = new NDebuggerUnitGroups();
			this.DUnitGroupsTool = nDebuggerUnitGroups;
			nDebuggerUnitGroups.Text = "AI goup debugger";
			NDebuggerTriggers nDebuggerTriggers = new NDebuggerTriggers();
			this.DTriggersTool = nDebuggerTriggers;
			nDebuggerTriggers.Text = "Trigger debugger";
			NDebuggerGVars nDebuggerGVars = new NDebuggerGVars();
			this.DGVarsTool = nDebuggerGVars;
			nDebuggerGVars.Text = "Global variables";
			NDebuggerControlPanel nDebuggerControlPanel = new NDebuggerControlPanel();
			this.DControlPanel = nDebuggerControlPanel;
			nDebuggerControlPanel.Text = "Game panel";
			ToolboxContainer toolboxContainer = new ToolboxContainer();
			this.VertexToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.VertexTools);
			this.VertexToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.ObjectFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.ObjectFilePicker);
			this.ObjectFileContainer.Autosize = true;
			this.ObjectFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.ObjectToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.ObjectTools);
			this.ObjectToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.RoadFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.RoadFilePicker);
			this.RoadFileContainer.Autosize = true;
			this.RoadFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.RoadToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.RoadTools);
			this.RoadToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.NavPointToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.NavPointTools);
			this.NavPointToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.DecalFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.DecalFilePicker);
			this.DecalFileContainer.Autosize = true;
			this.DecalFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.DecalToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.DecalTools);
			this.DecalToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.LakeFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.LakeFilePicker);
			this.LakeFileContainer.Autosize = true;
			this.LakeFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.LakeToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.LakeTools);
			this.LakeToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.RiverFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.RiverFilePicker);
			this.RiverFileContainer.Autosize = true;
			this.RiverFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.RiverToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.RiverTools);
			this.RiverToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.CameraCurveToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.CameraCurveTools);
			this.CameraCurveToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.CameraCurvePropsContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.CameraCurveProps);
			this.CameraCurvePropsContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.PathToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.PathTools);
			this.PathToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.PathPropsContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.PathProps);
			this.PathPropsContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.LocationToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.LocationTools);
			this.LocationToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.LocationPropsContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.LocationProps);
			this.LocationPropsContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.UnitGroupPropsContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.UnitGroupProps);
			this.UnitGroupPropsContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.ObjectiveToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.ObjectiveTools);
			this.ObjectiveToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.ObjectivePropsContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.ObjectiveProps);
			this.ObjectivePropsContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.BuildingFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.BuildingFilePicker);
			this.BuildingFileContainer.Autosize = true;
			this.BuildingFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.BuildingToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.BuildingTools);
			this.BuildingToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.BuildingPropertiesContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.BuildingPropertiesTools);
			this.BuildingPropertiesContainer.Open = false;
			this.BuildingPropertiesContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.UnitFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.UnitFilePicker);
			this.UnitFileContainer.Autosize = true;
			this.UnitFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.UnitToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.UnitTools);
			this.UnitToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.PlayerContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.PlayerTools);
			this.PlayerContainer.Open = false;
			this.PlayerContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.UnitPropertiesContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.UnitPropertiesTools);
			this.UnitPropertiesContainer.Open = false;
			this.UnitPropertiesContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.SoundFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.SoundFilePicker);
			this.SoundFileContainer.Autosize = true;
			this.SoundFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.SoundToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.SoundTools);
			this.SoundToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.EffectFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.EffectFilePicker);
			this.EffectFileContainer.Autosize = true;
			this.EffectFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.EffectToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.EffectTools);
			this.EffectToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.TerrainFileContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.TerrainFilePicker);
			this.TerrainFileContainer.Autosize = true;
			this.TerrainFileContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.TerrainToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.TerrainTools);
			this.TerrainToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.SectorToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.SectorTools);
			this.SectorToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.WeatherToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.WeatherTools);
			this.WeatherToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.OptionToolContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.OptionsTools);
			this.OptionToolContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.LoggerContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.LoggerTool);
			this.LoggerContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.DUnitsContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.DUnitsTool);
			this.DUnitsContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.DUnitGroupsContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.DUnitGroupsTool);
			this.DUnitGroupsContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.DTriggersContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.DTriggersTool);
			this.DTriggersContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer = new ToolboxContainer();
			this.DGVarsContainer = toolboxContainer;
			toolboxContainer.AddToolbox(this.DGVarsTool);
			this.DGVarsContainer.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			this.LogControlPanel = new ToolboxContainer();
			this.LogControlPanel.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			this.UnitsControlPanel = new ToolboxContainer();
			this.UnitsControlPanel.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			this.UnitGroupsControlPanel = new ToolboxContainer();
			this.UnitGroupsControlPanel.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			this.TriggersControlPanel = new ToolboxContainer();
			this.TriggersControlPanel.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			Minimap minimap = new Minimap();
			this.MinimapPanel = minimap;
			minimap.Text = "Minimap";
			this.MinimapPanel.MapNeedsRefresh += new Minimap.MapNeedsRefreshHandler(this.MinimapNeedsRefresh);
			this.MinimapPanel.CameraMove += new Minimap.MoveCameraHandler(this.MinimapMovesCamera);
			this.MinimapPanel.CameraRotate += new Minimap.RotateCameraHandler(this.MinimapRotatesCamera);
			this.VertexMinimap = new ToolboxContainer();
			this.VertexMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			ToolboxContainer toolboxContainer2 = new ToolboxContainer();
			this.ObjectsMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.ObjectsMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.RoadsMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.RoadsMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.NavPointsMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.NavPointsMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.DecalsMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.DecalsMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.LakeMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.LakeMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.RiverMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.RiverMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.CameraCurveMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.CameraCurveMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.PathMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.PathMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.LocationMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.LocationMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.UnitGroupMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.UnitGroupMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.BuildingMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.BuildingMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.UnitMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.UnitMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.SoundMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.SoundMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.EffectMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.EffectMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			toolboxContainer2 = new ToolboxContainer();
			this.TerrainMinimap = toolboxContainer2;
			toolboxContainer2.Open = false;
			this.TerrainMinimap.OpenStateToggledEvent += new ToolboxContainer.OpenStateToggleHandler(this.panSideBarToolStateToggled);
			if (this.OpenFileName.Length > 0)
			{
				this.OpenDocument(this.OpenFileName);
			}
			else if (*(ref <Module>.Options + 12) != 0)
			{
				this.menuFileOpenRecent_Click(sender, e);
			}
			else
			{
				this.menuFileOpen_Click(sender, e);
			}
		}

		private unsafe void NMainForm_Activated(object sender, EventArgs e)
		{
			if (<Module>.IEngine != null)
			{
				GIEngine* expr_0C = <Module>.IEngine;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_0C, *(*(int*)expr_0C + 244));
			}
		}

		private unsafe void FileSelectedSingle(string FileName)
		{
			<Module>.GBaseString<char>.=(*(this.EntityType * 4 + ref this.EntityName), FileName);
			this.StartEntityPreCreate();
		}

		private unsafe void EntityModeChanged(int mode)
		{
			this.CancelDepressedDrag(false);
			if (mode == 256)
			{
				<Module>.GEditorWorld.ResetSelectedObjectHeights(this.World);
				this.CurrentEntityToolbar.EmulatePushByID(1);
				this.CurrentEntityToolbar.EmulateUpByID(1);
			}
			else
			{
				*(this.EntityType * 4 + ref this.EntityOperation) = mode;
				if (mode == 2)
				{
					int entityType = this.EntityType;
					switch (entityType)
					{
					case 13:
					{
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr2;
						GEditorWorld* world;
						try
						{
							GBaseString<char> gBaseString<char>2;
							ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
							try
							{
								world = this.World;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
							throw;
						}
						GBaseString<char> gBaseString<char>3;
						GBaseString<char>* src = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world, &gBaseString<char>3, 2, ptr2, -1, ptr);
						try
						{
							<Module>.GBaseString<char>.=(*(this.EntityType * 4 + ref this.EntityName), src);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
							throw;
						}
						if (gBaseString<char>3 != null)
						{
							<Module>.free(gBaseString<char>3);
						}
						break;
					}
					case 15:
					{
						GBaseString<char> gBaseString<char>4;
						GBaseString<char>* ptr3 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>4, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr4;
						GEditorWorld* world2;
						try
						{
							GBaseString<char> gBaseString<char>5;
							ptr4 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>5, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
							try
							{
								world2 = this.World;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>5));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
							throw;
						}
						GBaseString<char> gBaseString<char>6;
						GBaseString<char>* src2 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world2, &gBaseString<char>6, 0, ptr4, -1, ptr3);
						try
						{
							<Module>.GBaseString<char>.=(*(this.EntityType * 4 + ref this.EntityName), src2);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
							throw;
						}
						if (gBaseString<char>6 != null)
						{
							<Module>.free(gBaseString<char>6);
						}
						break;
					}
					case 17:
					{
						GBaseString<char> gBaseString<char>7;
						GBaseString<char>* ptr5 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>7, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr6;
						GEditorWorld* world3;
						try
						{
							GBaseString<char> gBaseString<char>8;
							ptr6 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>8, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
							try
							{
								world3 = this.World;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>8));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>7));
							throw;
						}
						GBaseString<char> gBaseString<char>9;
						GBaseString<char>* src3 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world3, &gBaseString<char>9, 1, ptr6, -1, ptr5);
						try
						{
							<Module>.GBaseString<char>.=(*(this.EntityType * 4 + ref this.EntityName), src3);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>9));
							throw;
						}
						if (gBaseString<char>9 != null)
						{
							<Module>.free(gBaseString<char>9);
						}
						break;
					}
					case 19:
						<Module>.GBaseString<char>.=(*(entityType * 4 + ref this.EntityName), (sbyte*)(&<Module>.??_C@_08MDCLHJPM@Navpoint?$AA@));
						break;
					}
				}
				else if (mode == 4)
				{
					this.StartEntityPreCreateNode();
					goto IL_285;
				}
				if (*(*(this.EntityType * 4 + ref this.EntityName) + 4) > 0 && mode == 2)
				{
					this.StartEntityPreCreate();
				}
				IL_285:
				ToolboxScriptEntities currentScriptEnittyToolbar = this.CurrentScriptEnittyToolbar;
				if (currentScriptEnittyToolbar != null)
				{
					currentScriptEnittyToolbar.RefreshEntityList();
				}
			}
		}

		private void EntityDecalAction(int operation)
		{
			<Module>.?TransformSelectedDecals@GEditorWorld@@$$FQAEXW4GDecalOp@@@Z(this.World, operation);
			this.RefreshMenuAndToolbarItems();
			this.RefreshMinimap();
		}

		private unsafe void EntityAction(int operation)
		{
			switch (operation)
			{
			case 400:
				if (MessageBox.Show("Are you sure you want to clear the script entities from the map?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
				{
					ScriptEditorForm scriptEditorFormInstance = this.ScriptEditorFormInstance;
					if (scriptEditorFormInstance != null)
					{
						scriptEditorFormInstance.Close();
					}
					*(int*)(this.World + 5080 / sizeof(GEditorWorld)) = 0;
					<Module>.GEditorWorld.ClearScriptEntities(this.World, true);
					this.RefreshMenuAndToolbarItems();
				}
				break;
			case 401:
				this.SaveScripts();
				break;
			case 402:
				if (MessageBox.Show("Are you sure you want to replace the script entities on the map?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
				{
					ScriptEditorForm scriptEditorFormInstance2 = this.ScriptEditorFormInstance;
					if (scriptEditorFormInstance2 != null)
					{
						scriptEditorFormInstance2.Close();
					}
					*(int*)(this.World + 5080 / sizeof(GEditorWorld)) = 0;
					this.LoadScripts();
				}
				break;
			case 403:
				<Module>.GEditorWorld.CreateObjective(this.World);
				this.RefreshMenuAndToolbarItems();
				break;
			case 404:
				<Module>.GEditorWorld.DeleteObjective(this.World, this.CurrentScriptEnittyToolbar.SelectedEntityIndex);
				this.RefreshMenuAndToolbarItems();
				break;
			}
		}

		private unsafe void EntityFlagChanged(FlagType flag, [MarshalAs(UnmanagedType.U1)] bool value)
		{
			switch (flag)
			{
			case FlagType.SNAP_ANGLE:
				*(ref this.EntityAlignRotate + this.EntityType) = (value ? 1 : 0);
				break;
			case FlagType.SNAP_TO_GRID:
				*(ref this.EntityAlignMove + this.EntityType) = (value ? 1 : 0);
				break;
			case FlagType.RANDOM_ORIENTATION:
				*(ref this.EntityRandomAngle + this.EntityType) = (value ? 1 : 0);
				break;
			case FlagType.LOCK_SELECTION:
				*(ref this.EntityLockSelection + this.EntityType) = (value ? 1 : 0);
				if (!value)
				{
					GEditorWorld* world = this.World;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world, this.EntityType, 0, *(*(int*)world + 12));
				}
				break;
			case FlagType.LOCK_HEIGHTS:
				*(ref this.EntityLockHeights + this.EntityType) = (value ? 1 : 0);
				break;
			}
		}

		private unsafe void toolboxUnitProperties_PropertiesChanged(GUnitStats* stats)
		{
			<Module>.GEditorWorld.StartWUnitPropertiesChange(this.World);
			<Module>.GEditorWorld.SetSelectedWUnitStats(this.World, stats);
			int num = -1;
			while (true)
			{
				GEditorWorld* ptr = this.World + 2884 / sizeof(GEditorWorld);
				GHeap<GWUnit>* ptr2 = ptr;
				int num2 = num + 1;
				int num3 = *(ptr2 + 4);
				if (num2 >= num3)
				{
					break;
				}
				int num4 = num2 * 124 + *ptr2;
				while (*num4 != 2147483647)
				{
					num2++;
					num4 += 124;
					if (num2 >= num3)
					{
						goto IL_76;
					}
				}
				num = num2;
				if (num2 < 0)
				{
					break;
				}
				int expr_6A = *(int*)ptr + num2 * 124 + 4;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_6A, *(*expr_6A + 8));
			}
			IL_76:
			this.MinimapUnitsNeedUpdate = true;
			<Module>.GEditorWorld.CompleteWUnitPropertiesChange(this.World);
		}

		private void toolboxPlayer_PlayerChanged(int player)
		{
			<Module>.GEditorWorld.SetActualPlayer(this.World, player);
		}

		private unsafe void toolboxPlayer_EditPlayerProperties(int player_idx)
		{
			PlayerForm playerForm = new PlayerForm();
			playerForm.StartPosition = FormStartPosition.CenterScreen;
			int num = player_idx * 160;
			playerForm.comboBoxColor.SelectedIndex = *(int*)(num / sizeof(GEditorWorld) + this.World + 284 / sizeof(GEditorWorld));
			playerForm.SetTeam(*(int*)(num / sizeof(GEditorWorld) + this.World + 300 / sizeof(GEditorWorld)));
			playerForm.SetRace(*(int*)(num / sizeof(GEditorWorld) + this.World + 288 / sizeof(GEditorWorld)));
			playerForm.SetControl(*(int*)(num / sizeof(GEditorWorld) + this.World + 292 / sizeof(GEditorWorld)));
			playerForm.SetTargetElector(*(int*)(num / sizeof(GEditorWorld) + this.World + 304 / sizeof(GEditorWorld)));
			playerForm.Money = *(int*)(num / sizeof(GEditorWorld) + this.World + 352 / sizeof(GEditorWorld));
			if (playerForm.ShowDialog() == DialogResult.OK)
			{
				*(int*)(num / sizeof(GEditorWorld) + this.World + 284 / sizeof(GEditorWorld)) = playerForm.comboBoxColor.SelectedIndex;
				*(int*)(num / sizeof(GEditorWorld) + this.World + 300 / sizeof(GEditorWorld)) = playerForm.GetTeam();
				*(int*)(num / sizeof(GEditorWorld) + this.World + 288 / sizeof(GEditorWorld)) = playerForm.GetRace();
				*(int*)(num / sizeof(GEditorWorld) + this.World + 292 / sizeof(GEditorWorld)) = playerForm.GetControl();
				*(int*)(num / sizeof(GEditorWorld) + this.World + 304 / sizeof(GEditorWorld)) = playerForm.GetTargetElector();
				int money = playerForm.Money;
				*(int*)(num / sizeof(GEditorWorld) + this.World + 352 / sizeof(GEditorWorld)) = money;
				this.PlayerTools.InitItems((GWorld*)this.World);
			}
		}

		private unsafe void toolboxVertex_BrushTypeChanged(int e)
		{
			this.TemporaryModeChange = false;
			this.BrushType = e;
			this.SetViewType();
			Size size = this.panMainViewport.Size;
			Size size2 = this.panMainViewport.Size;
			int num = *(int*)this.IViewport + 56;
			GRay gRay;
			float x;
			float num2;
			float z;
			<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, size2.Width / 2, size.Height / 2, *num), ref x, ref num2, ref z);
			this.VisualizeBrush(x, z);
			this.UpdateBrushSliders();
		}

		private unsafe void BrushFalloffTypeChanged(int newtype)
		{
			if (this.EditorMode == 1)
			{
				if (this.propBrushType < 20)
				{
					this.VertexFalloffType = newtype;
				}
				else
				{
					this.SelectionFalloffType = newtype;
				}
			}
			Size size = this.panMainViewport.Size;
			Size size2 = this.panMainViewport.Size;
			int num = *(int*)this.IViewport + 56;
			GRay gRay;
			float x;
			float num2;
			float z;
			<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, size2.Width / 2, size.Height / 2, *num), ref x, ref num2, ref z);
			this.VisualizeBrush(x, z);
			this.UpdateBrushSliders();
		}

		private unsafe void BrushFlagChanged(int flag, [MarshalAs(UnmanagedType.U1)] bool value)
		{
			if (flag != 200)
			{
				if (flag == 201)
				{
					*(byte*)(this.Terraformer + 9 / sizeof(GTerraformer)) = (value ? 1 : 0);
				}
			}
			else if (this.EditorMode == 1)
			{
				if (this.propBrushType < 20)
				{
					*(byte*)(this.Terraformer + 8 / sizeof(GTerraformer)) = (value ? 1 : 0);
				}
				else
				{
					this.SelectionAdditiveMode = value;
				}
			}
		}

		private unsafe void toolboxVertex_BrushParametersChanged(float size1, float size2, float pressure, float height)
		{
			this.BrushSize = ref size1;
			this.BrushSize2 = ref size2;
			this.BrushPressure = ref pressure;
			this.BrushHeight = ref height;
			Size size3 = this.panMainViewport.Size;
			Size size4 = this.panMainViewport.Size;
			int num = *(int*)this.IViewport + 56;
			GRay gRay;
			float x;
			float num2;
			float z;
			<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, size4.Width / 2, size3.Height / 2, *num), ref x, ref num2, ref z);
			this.VisualizeBrush(x, z);
			this.UpdateBrushSliders();
		}

		private void toolboxPainter_BrushTypeChanged(int e)
		{
			this.TemporaryModeChange = false;
			this.PaintType = e;
			this.SetViewType();
			this.UpdateBrushSliders();
		}

		private unsafe void toolboxPainter_BrushParametersChanged(float size1, float size2, float pressure, float height)
		{
			this.BrushSize = ref size1;
			this.BrushSize2 = ref size2;
			this.BrushPressure = ref pressure;
			Size size3 = this.panMainViewport.Size;
			Size size4 = this.panMainViewport.Size;
			int num = *(int*)this.IViewport + 56;
			GRay gRay;
			float x;
			float num2;
			float z;
			<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, size4.Width / 2, size3.Height / 2, *num), ref x, ref num2, ref z);
			this.VisualizeBrush(x, z);
			this.UpdateBrushSliders();
		}

		private unsafe void toolboxPainter_BrushColorChanged(uint newcolor)
		{
			GColor gColor = (newcolor >> 16 & 255) * 0.003921569f;
			*(ref gColor + 4) = (newcolor >> 8 & 255) * 0.003921569f;
			*(ref gColor + 8) = (newcolor & 255) * 0.003921569f;
			*(ref gColor + 12) = (newcolor >> 24) * 0.003921569f;
			cpblk(this.Terraformer + 16 / sizeof(GTerraformer), ref gColor, 16);
		}

		private unsafe void SelectionTypeChanged(int newtype)
		{
			this.propBrushType = newtype;
			this.VertexTools.ResetToNone();
			this.VertexTools.FalloffType = this.SelectionFalloffType;
			this.VertexTools.AdditiveMode = this.SelectionAdditiveMode;
			this.SetViewType();
			Size size = this.panMainViewport.Size;
			Size size2 = this.panMainViewport.Size;
			int num = *(int*)this.IViewport + 56;
			GRay gRay;
			float x;
			float num2;
			float z;
			<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, size2.Width / 2, size.Height / 2, *num), ref x, ref num2, ref z);
			this.VisualizeBrush(x, z);
			this.UpdateBrushSliders();
		}

		private void InvertSelection()
		{
			<Module>.GEditorWorld.InvertSelection(this.World);
			this.RefreshMenuAndToolbarItems();
			this.RefreshMinimap();
		}

		private unsafe void FillSelection(int filltype)
		{
			this.RefreshTerraformer();
			*(int*)this.Terraformer = filltype;
			<Module>.GEditorWorld.StartTerraforming(this.World, this.Terraformer);
			this.RefreshMenuAndToolbarItems();
			this.RefreshMinimap();
		}

		private unsafe void toolboxSectors_OperationActivated(int op, string info)
		{
			switch (op)
			{
			case 0:
				<Module>.GEditorWorld.AddSelectedParcels(this.World);
				break;
			case 1:
				<Module>.GEditorWorld.RemoveSelectedParcels(this.World);
				break;
			case 2:
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, info);
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
					<Module>.GWorld.SetSketchTexture(this.World, ptr2);
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
				break;
			}
			case 3:
				<Module>.GWorld.ShiftSketch(this.World, 0, -1);
				break;
			case 4:
				<Module>.GWorld.ShiftSketch(this.World, 0, 1);
				break;
			case 5:
				<Module>.GWorld.ShiftSketch(this.World, 1, 0);
				break;
			case 6:
				<Module>.GWorld.ShiftSketch(this.World, -1, 0);
				break;
			case 7:
				<Module>.GWorld.ShiftSketch(this.World, 0, -16);
				break;
			case 8:
				<Module>.GWorld.ShiftSketch(this.World, 0, 16);
				break;
			case 9:
				<Module>.GWorld.ShiftSketch(this.World, 16, 0);
				break;
			case 10:
				<Module>.GWorld.ShiftSketch(this.World, -16, 0);
				break;
			}
			this.RefreshSectorSelection();
			this.RefreshMenuAndToolbarItems();
		}

		private unsafe void toolboxOptions_OptionsChanged()
		{
			this.SetViewType();
			GEditorWorld* world = this.World;
			if (world != null && <Module>.GWorld.GetBlockMapMode(world) != *(ref <Module>.Options + 76))
			{
				<Module>.GWorld.SetBlockMapMode(this.World, *(ref <Module>.Options + 76) != 0);
				this.RefreshMinimap();
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 17, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 77))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 17, *(ref <Module>.Options + 77), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 28, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 79))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 28, *(ref <Module>.Options + 79), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 11, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 80))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 11, *(ref <Module>.Options + 80), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 12, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 81))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 12, *(ref <Module>.Options + 81), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 13, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 88))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 13, *(ref <Module>.Options + 88), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 14, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 92))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 14, *(ref <Module>.Options + 92), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 30, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 112))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 30, *(ref <Module>.Options + 112), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, *(*(int*)<Module>.IEngine + 20)) && *(ref <Module>.Options + 93) == 0)
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 0, 0, *(*(int*)<Module>.IEngine + 16));
			}
			if (!calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, *(*(int*)<Module>.IEngine + 20)) && *(ref <Module>.Options + 93) != 0)
			{
				int num = *(int*)<Module>.IEngine;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 0, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, *(num + 32)), *(num + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 21, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 94))
			{
				int num2 = *(int*)<Module>.IEngine;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 21, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 2, *(num2 + 32)) * *(ref <Module>.Options + 94), *(num2 + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 22, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 96))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 22, *(ref <Module>.Options + 96), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 27, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 108))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 27, *(ref <Module>.Options + 108), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 29, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 109))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 29, *(ref <Module>.Options + 109), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 18, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 100))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 18, *(ref <Module>.Options + 100), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 23, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 104))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 23, *(ref <Module>.Options + 104), *(*(int*)<Module>.IEngine + 16));
			}
			if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 33, *(*(int*)<Module>.IEngine + 20)) != *(ref <Module>.Options + 116))
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 33, *(ref <Module>.Options + 116), *(*(int*)<Module>.IEngine + 16));
			}
			int num3 = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, *(*(int*)<Module>.IEngine + 96));
			bool flag;
			int num4;
			int num5;
			int num6;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Boolean* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), num3, ref flag, ref num4, ref num5, ref num6, *(*num3));
			if (num6 != *(ref <Module>.Options + 84))
			{
				int num7 = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, *(*(int*)<Module>.IEngine + 96));
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), num7, 0, 0, *(ref <Module>.Options + 84), *(*num7 + 4));
			}
			<Module>.SaveOptions();
		}

		private unsafe void toolboxWeather_ValueChanged(GWWeather* weather)
		{
			<Module>.GEditorWorld.SetWeather(this.World, -1, weather);
		}

		private unsafe void panMainViewport_SizeChanged(object sender, EventArgs e)
		{
			<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), 3225, (sbyte*)(&<Module>.??_C@_0DC@IFGJDFHM@NWorkshop?3?3NMainForm?3?3panMainVie@));
			<Module>.GLogger.Log(0, (sbyte*)(&<Module>.??_C@_0BL@LAMDIDIP@Resize?5viewport?5to?5?$CFd?5x?5?$CFd?$AA@), this.panMainViewport.Width, this.panMainViewport.Height);
			if (<Module>.IEngine != null)
			{
				int num = *(int*)this.IRenderTarget + 12;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), this.IRenderTarget, this.panMainViewport.Width, this.panMainViewport.Height, *num);
			}
		}

		private void NMainForm_Closing(object sender, CancelEventArgs e)
		{
			if (this.GameDebugWorld != null)
			{
				this.EndDebugMap();
				e.Cancel = true;
			}
			else
			{
				if (this.ToolWindows.Count > 0)
				{
					do
					{
						Form form = this.ToolWindows[0] as Form;
						form.Activate();
						form.Close();
						if (this.ToolWindows.Contains(form))
						{
							goto IL_61;
						}
					}
					while (this.ToolWindows.Count > 0);
					goto IL_68;
					IL_61:
					e.Cancel = true;
				}
				IL_68:
				if (!this.SaveDocumentIfChanged())
				{
					e.Cancel = true;
				}
			}
		}

		private unsafe void NMainForm_Closed(object sender, EventArgs e)
		{
			this.WindowClosing = true;
			this.DiscardDocument();
			GHandle<11>* brushCursor = this.BrushCursor;
			if (brushCursor != null)
			{
				<Module>.delete((void*)brushCursor);
				this.BrushCursor = null;
			}
			GHandle<11>* parcelSelection = this.ParcelSelection;
			if (parcelSelection != null)
			{
				<Module>.delete((void*)parcelSelection);
				this.ParcelSelection = null;
			}
			<Module>.delete((void*)this.LastCamera);
			if (this.ToolWindows.Count > 0)
			{
				do
				{
					Form form = this.ToolWindows[0] as Form;
					form.Close();
					this.ToolWindows.Remove(form);
				}
				while (this.ToolWindows.Count > 0);
			}
			this.CameraCurveProps.RemoveCameraViewPort();
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>), <Module>.ILayout, *(GHandle<19>*)(this.ND + 16 / sizeof(GNativeData)), *(*(int*)<Module>.ILayout + 4));
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>), <Module>.ILayout, *(GHandle<19>*)(this.ND + 20 / sizeof(GNativeData)), *(*(int*)<Module>.ILayout + 4));
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>), <Module>.ILayout, *(GHandle<19>*)(this.ND + 24 / sizeof(GNativeData)), *(*(int*)<Module>.ILayout + 4));
			*(int*)(this.ND + 16 / sizeof(GNativeData)) = 0;
			*(int*)(this.ND + 20 / sizeof(GNativeData)) = 0;
			*(int*)(this.ND + 24 / sizeof(GNativeData)) = 0;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>), <Module>.IEngine, *(GHandle<12>*)(this.ND + 4 / sizeof(GNativeData)), *(*(int*)<Module>.IEngine + 144));
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>), <Module>.IEngine, *(GHandle<12>*)(this.ND + 8 / sizeof(GNativeData)), *(*(int*)<Module>.IEngine + 144));
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>), <Module>.IEngine, *(GHandle<12>*)(this.ND + 12 / sizeof(GNativeData)), *(*(int*)<Module>.IEngine + 144));
			FilePickerControl objectFilePicker = this.ObjectFilePicker;
			if (objectFilePicker != null)
			{
				objectFilePicker.Dispose();
			}
			FilePickerControl roadFilePicker = this.RoadFilePicker;
			if (roadFilePicker != null)
			{
				roadFilePicker.Dispose();
			}
			FilePickerControl decalFilePicker = this.DecalFilePicker;
			if (decalFilePicker != null)
			{
				decalFilePicker.Dispose();
			}
			FilePickerControl unitFilePicker = this.UnitFilePicker;
			if (unitFilePicker != null)
			{
				unitFilePicker.Dispose();
			}
			ToolboxTerrainTools terrainTools = this.TerrainTools;
			if (terrainTools != null)
			{
				terrainTools.Dispose();
			}
			FilePickerControl riverFilePicker = this.RiverFilePicker;
			if (riverFilePicker != null)
			{
				riverFilePicker.Dispose();
			}
			FilePickerControl lakeFilePicker = this.LakeFilePicker;
			if (lakeFilePicker != null)
			{
				lakeFilePicker.Dispose();
			}
			FilePickerControl buildingFilePicker = this.BuildingFilePicker;
			if (buildingFilePicker != null)
			{
				buildingFilePicker.Dispose();
			}
			FilePickerControl soundFilePicker = this.SoundFilePicker;
			if (soundFilePicker != null)
			{
				soundFilePicker.Dispose();
			}
			FilePickerControl effectFilePicker = this.EffectFilePicker;
			if (effectFilePicker != null)
			{
				effectFilePicker.Dispose();
			}
			FilePickerControl localeFilePicker = this.LocaleFilePicker;
			if (localeFilePicker != null)
			{
				localeFilePicker.Dispose();
			}
			NPropertyClipboard* unitEditorClipboard = this.UnitEditorClipboard;
			if (unitEditorClipboard != null)
			{
				uint num = (uint)(*(int*)(unitEditorClipboard + 4 / sizeof(NPropertyClipboard)));
				if (num != 0u)
				{
					GStream* ptr = num;
					object arg_283_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr, 1, *(*(int*)ptr));
					*(int*)(this.UnitEditorClipboard + 4 / sizeof(NPropertyClipboard)) = 0;
				}
			}
			NPropertyClipboard* effectEditorClipboard = this.EffectEditorClipboard;
			if (effectEditorClipboard != null)
			{
				uint num2 = (uint)(*(int*)(effectEditorClipboard + 4 / sizeof(NPropertyClipboard)));
				if (num2 != 0u)
				{
					GStream* ptr2 = num2;
					object arg_2B5_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, *(*(int*)ptr2));
					*(int*)(this.EffectEditorClipboard + 4 / sizeof(NPropertyClipboard)) = 0;
				}
			}
			NPropertyClipboard* unitEditorClipboard2 = this.UnitEditorClipboard;
			if (unitEditorClipboard2 != null)
			{
				<Module>.delete((void*)unitEditorClipboard2);
				this.UnitEditorClipboard = null;
			}
			NPropertyClipboard* effectEditorClipboard2 = this.EffectEditorClipboard;
			if (effectEditorClipboard2 != null)
			{
				<Module>.delete((void*)effectEditorClipboard2);
				this.EffectEditorClipboard = null;
			}
			int num3 = 0;
			if (0 < *(int*)(this.PhysicsModels + 4 / sizeof(GArray<GIModel *>)))
			{
				do
				{
					int num4 = num3 * 4;
					int num5 = num4 + *(int*)this.PhysicsModels;
					if (*num5 != 0)
					{
						int expr_31B = *num5;
						int expr_325 = expr_31B + *(*(expr_31B + 4) + 4) + 4;
						object arg_32F_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_325, *(*expr_325 + 4));
						*(*(int*)this.PhysicsModels + num4) = 0;
					}
					num3++;
				}
				while (num3 < *(int*)(this.PhysicsModels + 4 / sizeof(GArray<GIModel *>)));
			}
			GArray<GIModel *>* physicsModels = this.PhysicsModels;
			if (physicsModels != null)
			{
				GArray<GIModel *>* ptr3 = physicsModels;
				int* arg_371_0 = ref *(int*)(ptr3 + 4 / sizeof(GArray<GIModel *>));
				uint num6 = (uint)(*(int*)ptr3);
				if (num6 != 0u)
				{
					<Module>.free(num6);
					*(int*)ptr3 = 0;
				}
				*arg_371_0 = 0;
				*(int*)(ptr3 + 8 / sizeof(GArray<GIModel *>)) = 0;
				<Module>.delete((void*)ptr3);
				this.PhysicsModels = null;
			}
			GEditorWorld* world = this.World;
			if (world != null)
			{
				GEditorWorld* ptr4 = world;
				object arg_39A_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, *(*(int*)ptr4));
				this.World = null;
			}
			if (<Module>.UnitRegistry != null)
			{
				void* arg_3B8_0 = (void*)<Module>.UnitRegistry;
				<Module>.GUnitRegistry.{dtor}(<Module>.UnitRegistry);
				<Module>.delete(arg_3B8_0);
				<Module>.UnitRegistry = null;
			}
			<Module>.EngineShutdown();
		}

		private unsafe void panMainViewport_Paint(object sender, PaintEventArgs e)
		{
			if (<Module>.GLogger.ActiveDialogExists() == null && !this.WindowClosing)
			{
				if (<Module>.ISoundSys != null)
				{
					GISoundSys* expr_21 = <Module>.ISoundSys;
					object arg_29_0 = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_21, *(*(int*)expr_21));
				}
				if (this.World != null)
				{
					long num = <Module>.GTimer.GetTimeH(<Module>.Timer);
					if (this.LastUpdate == 0L)
					{
						this.LastUpdate = num;
					}
					int num2 = 0;
					do
					{
						if (*(num2 * 8 + ref this.KeyTimes) != 0L)
						{
							this.UpdateKey(num, num2);
						}
						num2++;
					}
					while (num2 < 256);
					long num3 = num - this.LastUpdate;
					this.LastUpdate = num;
					if (this.BrushNeedsUpdate)
					{
						this.VisualizeBrush(this.BrushX, this.BrushZ);
						this.BrushNeedsUpdate = false;
					}
					<Module>.GWorld.UpdateCamera(this.World, this.IViewport);
					<Module>.GEditorWorld.Refresh(this.World, num3, this.IViewport);
					<Module>.GEditorWorld.RefreshTopology(this.World);
					<Module>.GWorld.UpdateWaterDeferred(this.World);
					<Module>.GWorld.UpdateBlockMap(this.World);
					<Module>.GWorld.UpdateVectorBlock(this.World);
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), <Module>.Scene, num3, *(*(int*)<Module>.Scene + 32));
					if (this.MinimapUnitsNeedUpdate)
					{
						this.RefreshUnitsOnMinimap();
						this.MinimapUnitsNeedUpdate = false;
					}
					if (this.MinimapViewportNeedsUpdate || <Module>.GWorld.IsCameraMoving(this.World) != null)
					{
						this.RefreshMinimapCameraGizmo();
						this.MinimapViewportNeedsUpdate = false;
					}
					if (this.SectorSelectionNeedsUpdate)
					{
						this.RefreshSectorSelection();
						this.SectorSelectionNeedsUpdate = false;
					}
					byte b = (*(ref <Module>.Options + 68) == 3) ? 1 : 0;
					GEditorWorld* world = this.World;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), world, b, *(*(int*)world + 40));
					this.UpdateCameraDebugText();
				}
				if (this.GameDebugWorld != null)
				{
					this.RefreshDebug();
				}
				if (<Module>.IEngine != null)
				{
					GIScene* ptr;
					if (this.World == null && this.GameDebugWorld == null)
					{
						ptr = null;
					}
					else
					{
						ptr = <Module>.Scene;
					}
					GIRenderTarget* iRenderTarget = this.IRenderTarget;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GIScene*,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iRenderTarget, ptr, 4194304, *(*(int*)iRenderTarget + 36));
					if (!calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 3, *(*(int*)<Module>.IEngine + 32)) && ((*(int*)this.ND != 0) ? 1 : 0) != 0)
					{
						GBaseString<char> gBaseString<char>;
						int num4 = calli(GBaseString<char>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GBaseString<char>*), <Module>.IEngine, ref gBaseString<char>, *(*(int*)<Module>.IEngine + 4));
						try
						{
							uint num5 = (uint)(*num4);
							sbyte* ptr2;
							if (num5 != 0u)
							{
								ptr2 = num5;
							}
							else
							{
								ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							GNativeData* nD = this.ND;
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>,GHandle<12>,System.Int32,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.ILayout, *(GHandle<19>*)(nD + 16 / sizeof(GNativeData)), *(GHandle<12>*)(nD + 4 / sizeof(GNativeData)), 0, ptr2, *(*(int*)<Module>.ILayout + 84));
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
						if (<Module>.ISoundSys != null)
						{
							GBaseString<char> gBaseString<char>2;
							int num6 = calli(GBaseString<char>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GBaseString<char>*), <Module>.ISoundSys, ref gBaseString<char>2, *(*(int*)<Module>.ISoundSys + 60));
							try
							{
								uint num7 = (uint)(*num6);
								sbyte* ptr3;
								if (num7 != 0u)
								{
									ptr3 = num7;
								}
								else
								{
									ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								GNativeData* nD2 = this.ND;
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>,GHandle<12>,System.Int32,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.ILayout, *(GHandle<19>*)(nD2 + 20 / sizeof(GNativeData)), *(GHandle<12>*)(nD2 + 4 / sizeof(GNativeData)), 0, ptr3, *(*(int*)<Module>.ILayout + 84));
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
					}
				}
			}
		}

		private unsafe void panMainViewport_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode >= Keys.None || e.KeyCode < (Keys)256)
			{
				if (*(e.KeyCode * Keys.Back + ref this.KeyTimes) == 0L)
				{
					*(e.KeyCode * Keys.Back + ref this.KeyTimes) = <Module>.GTimer.GetTimeH(<Module>.Timer);
				}
				e.Handled = true;
				if (this.GameDebugMode)
				{
					this.HandleDebugKeys(e.KeyCode);
				}
				else
				{
					if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
					{
						switch (this.EditorMode)
						{
						case 1:
							this.VertexTools.EmulatePush(e.KeyCode - Keys.D1);
							break;
						case 2:
							this.TerrainTools.EmulatePush(e.KeyCode - Keys.D1);
							break;
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 9:
						case 10:
						case 11:
						case 12:
						case 16:
							if (this.CurrentEntityToolbar != null)
							{
								if (e.KeyCode == Keys.D1)
								{
									this.CurrentEntityToolbar.PrevGroup();
								}
								else if (e.KeyCode == Keys.D2)
								{
									this.CurrentEntityToolbar.PrevTool();
								}
								else if (e.KeyCode == Keys.D3)
								{
									this.CurrentEntityToolbar.NextTool();
								}
								else if (e.KeyCode == Keys.D4)
								{
									this.CurrentEntityToolbar.NextGroup();
								}
								else if (e.KeyCode == Keys.D5)
								{
									this.CurrentEntityToolbar.NextTool();
									this.CurrentEntityToolbar.PrevTool();
									this.CurrentEntityToolbar.EmulatePush(-1);
								}
							}
							break;
						}
					}
					$ArrayType$$$BY0BAA@_J* ptr = ref this.KeyTimes + 128;
					if (*ptr != 0L && this.EntityType != 0 && this.World != null && (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
					{
						GEditorWorld* world = this.World;
						if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, this.EntityType, *(*(int*)world + 32)))
						{
							float num = 0f;
							float num2 = 0f;
							switch (e.KeyCode)
							{
							case Keys.Left:
								num = -0.1f;
								break;
							case Keys.Up:
								num2 = 0.1f;
								break;
							case Keys.Right:
								num = 0.1f;
								break;
							case Keys.Down:
								num2 = -0.1f;
								break;
							}
							switch (*(this.EntityType * 4 + ref this.EntityOperation))
							{
							case 1:
								if (this.KeyDragMode != 9)
								{
									Cursor arg_39A_0 = this.panMainViewport.Cursor;
									Point position = Cursor.Position;
									Cursor arg_3AD_0 = this.panMainViewport.Cursor;
									this.CompleteDepressedDrag(Cursor.Position.X, position.Y);
									Cursor arg_3D4_0 = this.panMainViewport.Cursor;
									Point position2 = Cursor.Position;
									Cursor arg_3E7_0 = this.panMainViewport.Cursor;
									this.CompletePressedDrag(Cursor.Position.X, position2.Y);
									int entityType = this.EntityType;
									if (<Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@_N@Z(this.World, entityType, *(ref this.EntityAlignMove + entityType) != 0) != null)
									{
										this.KeyDragMode = 9;
									}
								}
								<Module>.GEditorWorld.FollowEntityMove(this.World, num, num2);
								break;
							case 8:
							{
								if (this.KeyDragMode != 10)
								{
									Cursor arg_457_0 = this.panMainViewport.Cursor;
									Point position3 = Cursor.Position;
									Cursor arg_46A_0 = this.panMainViewport.Cursor;
									this.CompleteDepressedDrag(Cursor.Position.X, position3.Y);
									Cursor arg_491_0 = this.panMainViewport.Cursor;
									Point position4 = Cursor.Position;
									Cursor arg_4A4_0 = this.panMainViewport.Cursor;
									this.CompletePressedDrag(Cursor.Position.X, position4.Y);
									if (<Module>.?StartEntityLift@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(this.World, this.EntityType, 0) != null)
									{
										this.KeyDragMode = 10;
										this.DragY = 0f;
									}
								}
								float num3 = (float)((double)this.DragY - (double)num2 * 50.0);
								this.DragY = num3;
								<Module>.GEditorWorld.FollowEntityLift(this.World, (int)((double)num3));
								break;
							}
							case 16:
							{
								if (this.KeyDragMode != 11)
								{
									Cursor arg_532_0 = this.panMainViewport.Cursor;
									Point position5 = Cursor.Position;
									Cursor arg_545_0 = this.panMainViewport.Cursor;
									this.CompleteDepressedDrag(Cursor.Position.X, position5.Y);
									Cursor arg_56C_0 = this.panMainViewport.Cursor;
									Point position6 = Cursor.Position;
									Cursor arg_57F_0 = this.panMainViewport.Cursor;
									this.CompletePressedDrag(Cursor.Position.X, position6.Y);
									int entityType2 = this.EntityType;
									if (<Module>.?StartEntityRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@H_N@Z(this.World, entityType2, 0, *(ref this.EntityAlignRotate + entityType2) != 0) != null)
									{
										this.KeyDragMode = 11;
										this.DragY = 0f;
									}
								}
								float num4 = (float)((double)this.DragY + (double)(num2 * 3.14159274f) * 15.625);
								this.DragY = num4;
								<Module>.GEditorWorld.FollowEntityRotate(this.World, (int)((double)num4));
								break;
							}
							case 64:
							{
								if (this.KeyDragMode != 13)
								{
									Cursor arg_621_0 = this.panMainViewport.Cursor;
									Point position7 = Cursor.Position;
									Cursor arg_634_0 = this.panMainViewport.Cursor;
									this.CompleteDepressedDrag(Cursor.Position.X, position7.Y);
									Cursor arg_65B_0 = this.panMainViewport.Cursor;
									Point position8 = Cursor.Position;
									Cursor arg_66E_0 = this.panMainViewport.Cursor;
									this.CompletePressedDrag(Cursor.Position.X, position8.Y);
									if (<Module>.?StartEntityTilt@GEditorWorld@@$$FQAE_NW4GEntityType@@MM@Z(this.World, this.EntityType, 0f, 0f) != null)
									{
										this.KeyDragMode = 13;
										this.DragX = 0f;
										this.DragY = 0f;
									}
								}
								float num5 = (float)((double)this.DragX + (double)num * 0.2);
								this.DragX = num5;
								float num6 = (float)((double)this.DragY + (double)num2 * 0.2);
								this.DragY = num6;
								<Module>.GEditorWorld.FollowEntityTilt(this.World, num5, num6);
								break;
							}
							}
						}
					}
					switch (e.KeyCode)
					{
					case Keys.ShiftKey:
					{
						int editorMode = this.EditorMode;
						if (editorMode == 2)
						{
							if (this.propPaintType == 9)
							{
								this.PaintType = 10;
								this.TemporaryModeChange = true;
							}
							if (this.propPaintType == 15)
							{
								this.PaintType = 16;
								this.TemporaryModeChange = true;
							}
						}
						else if (editorMode == 1)
						{
							int num7 = this.propBrushType;
							if (num7 < 20 && num7 == 2)
							{
								this.BrushType = 3;
								this.TemporaryModeChange = true;
							}
						}
						break;
					}
					case Keys.ControlKey:
						if (this.EditorMode == 2 && this.propPaintType == 9)
						{
							this.PaintType = 11;
							this.TemporaryModeChange = true;
						}
						break;
					case Keys.Space:
						switch (this.EditorMode)
						{
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
						case 11:
						case 12:
						case 16:
						case 17:
						case 18:
						case 21:
						{
							ToolboxEntities currentEntityToolbar = this.CurrentEntityToolbar;
							if (currentEntityToolbar != null)
							{
								currentEntityToolbar.EmulatePushByID(303);
							}
							break;
						}
						}
						break;
					case Keys.A:
					{
						int num8 = (*(ref <Module>.Options + 81) == 0) ? 1 : 0;
						*(ref <Module>.Options + 81) = (byte)num8;
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					}
					case Keys.B:
					{
						int num9 = (*(ref <Module>.Options + 76) == 0) ? 1 : 0;
						*(ref <Module>.Options + 76) = (byte)num9;
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					}
					case Keys.C:
					{
						int num10 = (*(ref <Module>.Options + 92) == 0) ? 1 : 0;
						*(ref <Module>.Options + 92) = (byte)num10;
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					}
					case Keys.E:
					{
						int num11 = (*(ref <Module>.Options + 93) == 0) ? 1 : 0;
						*(ref <Module>.Options + 93) = (byte)num11;
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					}
					case Keys.I:
					{
						int num12 = (*(ref <Module>.Options + 79) == 0) ? 1 : 0;
						*(ref <Module>.Options + 79) = (byte)num12;
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					}
					case Keys.L:
					{
						int num13 = (*(ref <Module>.Options + 77) == 0) ? 1 : 0;
						*(ref <Module>.Options + 77) = (byte)num13;
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					}
					case Keys.O:
					{
						int num14 = (*(ref <Module>.Options + 78) == 0) ? 1 : 0;
						*(ref <Module>.Options + 78) = (byte)num14;
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					}
					case Keys.P:
					{
						int num15 = (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 24, *(*(int*)<Module>.IEngine + 20)) == 0) ? 1 : 0;
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 24, num15, *(*(int*)<Module>.IEngine + 16));
						break;
					}
					case Keys.Q:
						*(ref <Module>.Options + 72) = ((*(ref <Module>.Options + 72) == 2) ? 0 : 2);
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					case Keys.S:
						*(ref <Module>.Options + 72) = ((*(ref <Module>.Options + 72) == 1) ? 2 : 1);
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					case Keys.T:
					{
						int num16 = (*(ref <Module>.Options + 80) == 0) ? 1 : 0;
						*(ref <Module>.Options + 80) = (byte)num16;
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					}
					case Keys.U:
					{
						int num17 = *(ref <Module>.Options + 112);
						if (num17 != 0)
						{
							if (num17 != 1)
							{
								*(ref <Module>.Options + 112) = ((num17 != 2) ? 0 : 3);
							}
							else
							{
								*(ref <Module>.Options + 112) = 2;
							}
						}
						else
						{
							*(ref <Module>.Options + 112) = 1;
						}
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					}
					case Keys.W:
						*(ref <Module>.Options + 68) = ((*(ref <Module>.Options + 68) == 3) ? 2 : 3);
						this.toolboxOptions_OptionsChanged();
						if (this.EditorMode == 14)
						{
							this.OptionsTools.Refresh();
						}
						break;
					case Keys.Multiply:
						if (*ptr != 0L)
						{
							if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 26, *(*(int*)<Module>.IEngine + 20)) < 16)
							{
								int num18 = *(int*)<Module>.IEngine;
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 26, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 26, *(num18 + 20)) + 1, *(num18 + 16));
							}
						}
						else if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 25, *(*(int*)<Module>.IEngine + 20)) < 16)
						{
							int num19 = *(int*)<Module>.IEngine;
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 25, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 25, *(num19 + 20)) + 1, *(num19 + 16));
						}
						break;
					case Keys.Divide:
						if (*ptr != 0L)
						{
							if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 26, *(*(int*)<Module>.IEngine + 20)) > 0)
							{
								int num20 = *(int*)<Module>.IEngine;
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 26, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 26, *(num20 + 20)) - 1, *(num20 + 16));
							}
						}
						else if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 25, *(*(int*)<Module>.IEngine + 20)) > 0)
						{
							int num21 = *(int*)<Module>.IEngine;
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 25, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 25, *(num21 + 20)) - 1, *(num21 + 16));
						}
						break;
					case Keys.F1:
					{
						GEditorWorld* world2 = this.World;
						if (world2 != null)
						{
							if (*ptr != 0L)
							{
								<Module>.GWorld.CameraInitialize(world2);
							}
							else
							{
								byte b = (*(byte*)(world2 + 136 / sizeof(GEditorWorld)) == 0) ? 1 : 0;
								<Module>.GWorld.LimitGameCamera(world2, b != 0);
							}
							this.MinimapViewportNeedsUpdate = true;
						}
						break;
					}
					case Keys.F2:
					{
						int num22 = (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 15, *(*(int*)<Module>.IEngine + 20)) == 0) ? 1 : 0;
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 15, num22, *(*(int*)<Module>.IEngine + 16));
						break;
					}
					case Keys.F3:
						if (*(ref this.KeyTimes + 136) != 0L)
						{
							int num23 = (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 19, *(*(int*)<Module>.IEngine + 20)) == 0) ? 1 : 0;
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 19, num23, *(*(int*)<Module>.IEngine + 16));
						}
						else if (*ptr != 0L)
						{
							int num24 = (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 9, *(*(int*)<Module>.IEngine + 20)) == 0) ? 1 : 0;
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 9, num24, *(*(int*)<Module>.IEngine + 16));
						}
						break;
					case Keys.F5:
						if (*(ref this.KeyTimes + 136) != 0L)
						{
							this.RunMap();
						}
						else
						{
							this.DebugMap();
						}
						break;
					case Keys.F7:
						this.menuToolsScriptEditor_Click(null, null);
						break;
					case Keys.F8:
						if (((*(int*)(this.ND + 32 / sizeof(GNativeData)) != 0) ? 1 : 0) == 0)
						{
							GHandle<11> gHandle<11>;
							int num25 = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, ref gHandle<11>, 1, *(*(int*)<Module>.Scene + 256));
							cpblk(this.ND + 32 / sizeof(GNativeData), num25, 4);
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, *(GHandle<11>*)(this.ND + 32 / sizeof(GNativeData)), 0, *(*(int*)<Module>.Scene + 268));
						}
						if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *(GHandle<11>*)(this.ND + 32 / sizeof(GNativeData)), *(*(int*)<Module>.Scene + 272)))
						{
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *(GHandle<11>*)(this.ND + 32 / sizeof(GNativeData)), *(*(int*)<Module>.Scene + 264));
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, *(GHandle<11>*)(this.ND + 32 / sizeof(GNativeData)), 1, *(*(int*)<Module>.Scene + 268));
							int num26 = <Module>.GHeapDRB<GUnit *>.GetNext(this.World + 2928 / sizeof(GEditorWorld), -1);
							if (num26 >= 0)
							{
								while (true)
								{
									GUnit* ptr2 = *(num26 * 8 + *(int*)(this.World + 2928 / sizeof(GEditorWorld)) + 4);
									int expr_B19 = *(int*)(ptr2 + 8 / sizeof(GUnit));
									if (calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_B19, *(*expr_B19 + 32)))
									{
										goto IL_B37;
									}
									int expr_B2A = *(int*)(ptr2 + 8 / sizeof(GUnit));
									if (calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_B2A, *(*expr_B2A + 36)))
									{
										goto IL_B37;
									}
									IL_B95:
									num26 = <Module>.GHeapDRB<GUnit *>.GetNext(this.World + 2928 / sizeof(GEditorWorld), num26);
									if (num26 < 0)
									{
										break;
									}
									continue;
									IL_B37:
									float num27 = *(float*)(ptr2 + 528 / sizeof(GUnit));
									float num28 = *(float*)(ptr2 + 528 / sizeof(GUnit) + 8 / sizeof(GUnit));
									GPoint2 gPoint = num27;
									*(ref gPoint + 4) = num28;
									calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint2,System.Single,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong),System.Single), <Module>.Scene, *(GHandle<11>*)(this.ND + 32 / sizeof(GNativeData)), gPoint, *(float*)(ptr2 + 124 / sizeof(GUnit)) * 0.5f, 16777215, 0f, *(*(int*)<Module>.Scene + 288));
									goto IL_B95;
								}
							}
						}
						else
						{
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, *(GHandle<11>*)(this.ND + 32 / sizeof(GNativeData)), 0, *(*(int*)<Module>.Scene + 268));
						}
						break;
					case Keys.F9:
						if (((*(int*)(this.ND + 28 / sizeof(GNativeData)) != 0) ? 1 : 0) == 0)
						{
							GHandle<11> gHandle<11>2;
							int num29 = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, ref gHandle<11>2, 1, *(*(int*)<Module>.Scene + 256));
							cpblk(this.ND + 28 / sizeof(GNativeData), num29, 4);
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, *(GHandle<11>*)(this.ND + 28 / sizeof(GNativeData)), 0, *(*(int*)<Module>.Scene + 268));
						}
						if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *(GHandle<11>*)(this.ND + 28 / sizeof(GNativeData)), *(*(int*)<Module>.Scene + 272)))
						{
							GPUnit* ptr3 = <Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, (sbyte*)(&<Module>.??_C@_0CB@NBPLGCPO@units?1JTF?5?9?5Infantry?1Ranger?4unit@), false, true);
							if (ptr3 != null)
							{
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, *(GHandle<11>*)(this.ND + 28 / sizeof(GNativeData)), *(*(int*)<Module>.Scene + 264));
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, *(GHandle<11>*)(this.ND + 28 / sizeof(GNativeData)), 1, *(*(int*)<Module>.Scene + 268));
								GGraph gGraph;
								<Module>.GGraph.{ctor}(ref gGraph, *(float*)(ptr3 + 92 / sizeof(GPUnit)) * 0.5f, <Module>.GPUnit.GetMovementMaskWithoutEdge(ptr3), *(GHandle<11>*)(this.ND + 28 / sizeof(GNativeData)));
								<Module>.GGraph.{dtor}(ref gGraph);
							}
						}
						else
						{
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, *(GHandle<11>*)(this.ND + 28 / sizeof(GNativeData)), 0, *(*(int*)<Module>.Scene + 268));
						}
						break;
					}
				}
			}
		}

		private unsafe void panMainViewport_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode >= Keys.None || e.KeyCode < (Keys)256)
			{
				if (*(e.KeyCode * Keys.Back + ref this.KeyTimes) != 0L)
				{
					if (this.World != null)
					{
						this.UpdateKey(<Module>.GTimer.GetTimeH(<Module>.Timer), (int)e.KeyCode);
					}
					*(e.KeyCode * Keys.Back + ref this.KeyTimes) = 0L;
				}
				if (e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
				{
					switch (this.EditorMode)
					{
					case 1:
						this.VertexTools.EmulateUp(e.KeyCode - Keys.D1);
						break;
					case 2:
						this.TerrainTools.EmulateUp(e.KeyCode - Keys.D1);
						break;
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 9:
					case 10:
					case 11:
					case 12:
					case 16:
						if (this.CurrentEntityToolbar != null && e.KeyCode == Keys.D5)
						{
							this.CurrentEntityToolbar.EmulateUp(-1);
						}
						break;
					}
				}
				if (this.KeyDragMode != 0 && (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.ShiftKey))
				{
					switch (this.KeyDragMode)
					{
					case 9:
					{
						<Module>.GEditorWorld.CompleteEntityMove(this.World);
						ScriptEditorForm scriptEditorFormInstance = this.ScriptEditorFormInstance;
						if (scriptEditorFormInstance != null)
						{
							scriptEditorFormInstance.EditorsChanged();
						}
						break;
					}
					case 10:
						<Module>.GEditorWorld.CompleteEntityLift(this.World);
						break;
					case 11:
						<Module>.GEditorWorld.CompleteEntityRotate(this.World);
						break;
					case 13:
						<Module>.GEditorWorld.CompleteEntityTilt(this.World);
						break;
					}
					if (this.EntityType == 3)
					{
						this.MinimapUnitsNeedUpdate = true;
					}
					this.KeyDragMode = 0;
					this.RefreshMenuAndToolbarItems();
				}
				Keys keyCode = e.KeyCode;
				if (keyCode != Keys.ShiftKey)
				{
					if (keyCode != Keys.ControlKey)
					{
						if (keyCode == Keys.Space)
						{
							switch (this.EditorMode)
							{
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 10:
							case 11:
							case 12:
							case 16:
							case 17:
							case 18:
							case 21:
							{
								ToolboxEntities currentEntityToolbar = this.CurrentEntityToolbar;
								if (currentEntityToolbar != null)
								{
									currentEntityToolbar.EmulateUpByID(303);
								}
								break;
							}
							}
						}
					}
					else if (this.EditorMode == 2 && this.propPaintType == 11)
					{
						this.PaintType = 9;
						this.TemporaryModeChange = false;
					}
				}
				else
				{
					int editorMode = this.EditorMode;
					if (editorMode == 2 && this.TemporaryModeChange)
					{
						if (this.propPaintType == 10)
						{
							this.PaintType = 9;
							this.TemporaryModeChange = false;
						}
						if (this.propPaintType == 16)
						{
							this.PaintType = 15;
							this.TemporaryModeChange = false;
						}
					}
					else if (editorMode == 1 && this.TemporaryModeChange && this.propBrushType == 3)
					{
						this.BrushType = 2;
						this.TemporaryModeChange = false;
					}
				}
			}
		}

		private void panMainViewport_Click(object sender, EventArgs e)
		{
			int editorMode = this.EditorMode;
			if (editorMode == 10)
			{
				this.UnitPropertiesTools.Refresh(this.World);
			}
			else if (editorMode == 9)
			{
				this.BuildingPropertiesTools.Refresh(this.World);
			}
		}

		private unsafe void panMainViewport_MouseDown(object sender, MouseEventArgs e)
		{
			if (this.GameDebugMode)
			{
				this.DebugMouseDown(sender, e);
			}
			else if (this.World != null)
			{
				if (e.Button == MouseButtons.Left)
				{
					this.CompleteDepressedDrag(e.X, e.Y);
					this.CompletePressedDrag(e.X, e.Y);
					float num;
					float heightSetValue;
					float num2;
					if (this.EditorMode == 15)
					{
						<Module>.GWorld.GetPointInTopMode(this.World, this.IViewport, (float)e.X, (float)e.Y, ref num, ref heightSetValue, ref num2);
					}
					else
					{
						int num3 = *(int*)this.IViewport + 56;
						GRay gRay;
						<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, e.X, e.Y, *num3), ref num, ref heightSetValue, ref num2);
					}
					if (this.EntityType != 0)
					{
						int num4 = *(int*)this.World + 8;
						int num5 = *(int*)this.IViewport + 56;
						GRay gRay2;
						int num6 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GRay modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), this.World, this.EntityType, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay2, e.X, e.Y, *num5), 0, *num4);
						this.DragX = num;
						this.DragZ = num2;
						this.DragMX = e.X;
						this.DragMY = e.Y;
						int entityType = this.EntityType;
						$ArrayType$$$BY0BE@W4GEntityOperation@@* ptr = entityType * 4 + ref this.EntityOperation;
						int num7 = *ptr;
						if (num7 != 2 && num7 != 4 && *(ref this.KeyTimes + 128) != 0L)
						{
							if (num6 >= 0)
							{
								GEditorWorld* world = this.World;
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world, entityType, num6, 17, *(*(int*)world + 16));
								ToolboxScriptEntities currentScriptEnittyToolbar = this.CurrentScriptEnittyToolbar;
								if (currentScriptEnittyToolbar != null)
								{
									currentScriptEnittyToolbar.UpdateHilighting();
								}
							}
							else
							{
								this.DragMode = 15;
							}
						}
						else
						{
							switch (*ptr)
							{
							case 1:
								if (num6 < 0 && *(ref this.EntityLockSelection + entityType) == 0)
								{
									this.DragMode = 14;
								}
								else
								{
									if (*(ref this.EntityLockSelection + entityType) == 0)
									{
										GEditorWorld* world2 = this.World;
										if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world2, entityType, num6, *(*(int*)world2 + 28)))
										{
											GEditorWorld* world3 = this.World;
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world3, this.EntityType, num6, 16, *(*(int*)world3 + 16));
										}
									}
									if (*(ref this.KeyTimes + 136) != 0L)
									{
										switch (<Module>.?GetEntityAlternativeOp@GEditorWorld@@$$FQAEHW4GEntityType@@@Z(this.World, this.EntityType))
										{
										case 8:
											if (<Module>.?StartEntityLift@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(this.World, this.EntityType, e.Y) != null)
											{
												this.DragMode = 10;
												goto IL_C39;
											}
											goto IL_C39;
										case 16:
											entityType = this.EntityType;
											if (entityType == 7 || <Module>.?StartEntityRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@H_N@Z(this.World, this.EntityType, e.Y, *(ref this.EntityAlignRotate + entityType) != 0) != null)
											{
												this.DragMode = 11;
												goto IL_C39;
											}
											goto IL_C39;
										case 32:
											entityType = this.EntityType;
											if (<Module>.?StartEntityPointRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@MMH_N1@Z(this.World, this.EntityType, num, num2, e.Y, *(ref this.EntityAlignRotate + entityType) != 0, *(ref this.EntityLockHeights + entityType) != 0) != null)
											{
												this.DragMode = 12;
												goto IL_C39;
											}
											goto IL_C39;
										case 128:
											if (<Module>.?StartEntityScale@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(this.World, this.EntityType, e.Y) != null)
											{
												this.DragMode = 16;
												goto IL_C39;
											}
											goto IL_C39;
										}
										int num8 = *(int*)this.IViewport + 56;
										entityType = this.EntityType;
										GRay gRay3;
										if (<Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(this.World, entityType, num, num2, *(ref this.EntityAlignMove + entityType) != 0, *(ref this.EntityLockHeights + entityType) != 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay3, e.X, e.Y, *num8)) != null)
										{
											this.DragMode = 9;
										}
									}
									else
									{
										int num9 = *(int*)this.IViewport + 56;
										entityType = this.EntityType;
										GRay gRay4;
										if (<Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(this.World, entityType, num, num2, *(ref this.EntityAlignMove + entityType) != 0, *(ref this.EntityLockHeights + entityType) != 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay4, e.X, e.Y, *num9)) != null)
										{
											this.DragMode = 9;
										}
									}
								}
								break;
							case 2:
							case 4:
								if ((num6 >= 0 && (entityType == 9 || entityType == 10 || entityType == 12 || entityType == 14 || entityType == 15 || entityType == 16 || entityType == 17 || entityType == 18)) || entityType == 11 || entityType == 13)
								{
									this.DragMode = 17;
								}
								break;
							case 8:
								if (num6 < 0 && *(ref this.EntityLockSelection + entityType) == 0)
								{
									this.DragMode = 14;
								}
								else
								{
									if (*(ref this.EntityLockSelection + entityType) == 0)
									{
										GEditorWorld* world4 = this.World;
										if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world4, entityType, num6, *(*(int*)world4 + 28)))
										{
											GEditorWorld* world5 = this.World;
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world5, this.EntityType, num6, 16, *(*(int*)world5 + 16));
										}
									}
									if (<Module>.?StartEntityLift@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(this.World, this.EntityType, e.Y) != null)
									{
										this.DragMode = 10;
									}
								}
								break;
							case 16:
								if (num6 < 0 && *(ref this.EntityLockSelection + entityType) == 0)
								{
									this.DragMode = 14;
								}
								else
								{
									if (*(ref this.EntityLockSelection + entityType) == 0)
									{
										GEditorWorld* world6 = this.World;
										if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world6, entityType, num6, *(*(int*)world6 + 28)))
										{
											GEditorWorld* world7 = this.World;
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world7, this.EntityType, num6, 16, *(*(int*)world7 + 16));
										}
									}
									if (*(ref this.KeyTimes + 136) != 0L)
									{
										int num10 = *(int*)this.IViewport + 56;
										entityType = this.EntityType;
										GRay gRay5;
										if (<Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(this.World, entityType, num, num2, *(ref this.EntityAlignMove + entityType) != 0, *(ref this.EntityLockHeights + entityType) != 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay5, e.X, e.Y, *num10)) != null)
										{
											this.DragMode = 9;
										}
									}
									else if (<Module>.?StartEntityRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@H_N@Z(this.World, this.EntityType, e.Y, *(ref this.EntityAlignRotate + this.EntityType) != 0) != null)
									{
										this.DragMode = 11;
									}
								}
								break;
							case 32:
								if (num6 < 0 && *(ref this.EntityLockSelection + entityType) == 0)
								{
									this.DragMode = 14;
								}
								else
								{
									if (*(ref this.EntityLockSelection + entityType) == 0)
									{
										GEditorWorld* world8 = this.World;
										if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world8, entityType, num6, *(*(int*)world8 + 28)))
										{
											GEditorWorld* world9 = this.World;
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world9, this.EntityType, num6, 16, *(*(int*)world9 + 16));
										}
									}
									if (*(ref this.KeyTimes + 136) != 0L)
									{
										int num11 = *(int*)this.IViewport + 56;
										entityType = this.EntityType;
										GRay gRay6;
										if (<Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(this.World, entityType, num, num2, *(ref this.EntityAlignMove + entityType) != 0, *(ref this.EntityLockHeights + entityType) != 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay6, e.X, e.Y, *num11)) != null)
										{
											this.DragMode = 9;
										}
									}
									else
									{
										entityType = this.EntityType;
										if (<Module>.?StartEntityPointRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@MMH_N1@Z(this.World, this.EntityType, num, num2, e.Y, *(ref this.EntityAlignRotate + entityType) != 0, *(ref this.EntityLockHeights + entityType) != 0) != null)
										{
											this.DragMode = 12;
										}
									}
								}
								break;
							case 64:
								if (num6 < 0 && *(ref this.EntityLockSelection + entityType) == 0)
								{
									this.DragMode = 14;
								}
								else
								{
									if (*(ref this.EntityLockSelection + entityType) == 0)
									{
										GEditorWorld* world10 = this.World;
										if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world10, entityType, num6, *(*(int*)world10 + 28)))
										{
											GEditorWorld* world11 = this.World;
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world11, this.EntityType, num6, 16, *(*(int*)world11 + 16));
										}
									}
									if (<Module>.?StartEntityTilt@GEditorWorld@@$$FQAE_NW4GEntityType@@MM@Z(this.World, this.EntityType, num, num2) != null)
									{
										this.DragMode = 13;
									}
								}
								break;
							case 128:
								if (num6 < 0 && *(ref this.EntityLockSelection + entityType) == 0)
								{
									this.DragMode = 14;
								}
								else
								{
									if (*(ref this.EntityLockSelection + entityType) == 0)
									{
										GEditorWorld* world12 = this.World;
										if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world12, entityType, num6, *(*(int*)world12 + 28)))
										{
											GEditorWorld* world13 = this.World;
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world13, this.EntityType, num6, 16, *(*(int*)world13 + 16));
										}
									}
									if (*(ref this.KeyTimes + 136) != 0L)
									{
										int num12 = *(int*)this.IViewport + 56;
										entityType = this.EntityType;
										GRay gRay7;
										if (<Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(this.World, entityType, num, num2, *(ref this.EntityAlignMove + entityType) != 0, *(ref this.EntityLockHeights + entityType) != 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay7, e.X, e.Y, *num12)) != null)
										{
											this.DragMode = 9;
										}
									}
									else if (<Module>.?StartEntityScale@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(this.World, this.EntityType, e.Y) != null)
									{
										this.DragMode = 16;
									}
								}
								break;
							}
						}
						IL_C39:
						int editorMode = this.EditorMode;
						if (editorMode == 10)
						{
							this.UnitPropertiesTools.Refresh(this.World);
						}
						else if (editorMode == 9)
						{
							this.BuildingPropertiesTools.Refresh(this.World);
						}
					}
					if (this.EditorMode == 1 && num >= 0f)
					{
						$ArrayType$$$BY0BAA@_J* ptr2 = ref this.KeyTimes + 136;
						long num13 = *ptr2;
						if (num13 != 0L)
						{
							int num14 = this.propBrushType;
							if (num14 != 21 && num14 != 22 && num14 != 23)
							{
								this.HeightSetValue = heightSetValue;
								this.UpdateBrushSliders();
								goto IL_EE8;
							}
						}
						int num15 = this.propBrushType;
						if (num15 >= 20 && this.DragMode != 5)
						{
							this.DragMode = 7;
							if (this.SelectionActive && *(ref this.KeyTimes + 128) == 0L && num13 == 0L && num15 != 24)
							{
								if (<Module>.GEditorWorld.IsSelection(this.World, num, num2) != null)
								{
									this.RefreshTerraformer();
									*(int*)this.Terraformer = 20;
									<Module>.GEditorWorld.StartTerraforming(this.World, this.Terraformer, e.X, e.Y, false, false);
									this.DragX = num;
									this.DragZ = num2;
								}
								else
								{
									<Module>.GEditorWorld.SelectNone(this.World);
									this.SelectionActive = false;
									this.VertexTools.InvertEnable = false;
									this.TerrainTools.FillEnable = false;
									this.DragMode = 0;
									this.SelectionPossible = true;
									this.DragX = num;
									this.DragZ = num2;
									this.RefreshMenuAndToolbarItems();
									this.RefreshMinimap();
								}
							}
							else if (num15 == 24)
							{
								this.RefreshTerraformer();
								if (*(ref this.KeyTimes + 128) != 0L)
								{
									*(float*)(this.Terraformer + 44 / sizeof(GTerraformer)) = -this.SelectionPressure;
								}
								else
								{
									*(float*)(this.Terraformer + 44 / sizeof(GTerraformer)) = this.SelectionPressure;
								}
								<Module>.GEditorWorld.StartTerraforming(this.World, this.Terraformer, e.X, e.Y, false, false);
							}
							else
							{
								this.RefreshTerraformer();
								if (*ptr2 != 0L && this.SelectionActive)
								{
									*(float*)(this.Terraformer + 44 / sizeof(GTerraformer)) = -1f;
								}
								else
								{
									*(float*)(this.Terraformer + 44 / sizeof(GTerraformer)) = 1f;
								}
								<Module>.GEditorWorld.StartTerraforming(this.World, this.Terraformer, e.X, e.Y, false, false);
								this.DragX = num;
								this.DragZ = num2;
								if (this.propBrushType == 23)
								{
									this.DragMode = 5;
								}
							}
						}
						else if (this.DragMode != 5)
						{
							this.RefreshTerraformer();
							this.DragMode = 7;
							<Module>.GEditorWorld.StartTerraforming(this.World, this.Terraformer, e.X, e.Y, false, false);
						}
					}
					IL_EE8:
					if (this.EditorMode == 2 && num >= 0f)
					{
						this.RefreshTerraformer();
						if (this.propPaintType == 15 && *(ref this.KeyTimes + 136) != 0L)
						{
							GColor gColor;
							<Module>.GColor.{ctor}(ref gColor, <Module>.GEditorWorld.GetVertexColor(this.World, num, num2));
							cpblk(this.Terraformer + 16 / sizeof(GTerraformer), ref gColor, 16);
							this.TerrainTools.SetColor(<Module>.GColor..K(this.Terraformer + 16 / sizeof(GTerraformer)));
						}
						else if (<Module>.GEditorWorld.StartTerraforming(this.World, this.Terraformer, e.X, e.Y, false, false) != null)
						{
							this.DragMode = 7;
						}
					}
					if (this.EditorMode == 15)
					{
						<Module>.GEditorWorld.ClearParcelSelection(this.World);
						if (<Module>.GEditorWorld.IsParcelSelectionValid(this.World) == null)
						{
							this.DragMode = 25;
							this.DragX = num;
							this.DragZ = num2;
						}
						else
						{
							this.DragMode = 0;
						}
						this.SectorSelectionNeedsUpdate = true;
					}
					if (this.EditorMode == 8 && num >= 0f)
					{
						int num16 = *(int*)this.IViewport + 56;
						GRay gRay8;
						int num17 = <Module>.GWorld.GetTargetWirePoint(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay8, e.X, e.Y, *num16));
						if (num17 >= 0)
						{
							<Module>.GWorld.SelectWirePoint(this.World, num17, 48);
							<Module>.GWorld.UpdateWirePoint(this.World, num17, true);
							this.DragMode = 24;
							this.DragX = num;
							this.DragZ = num2;
						}
					}
					int dragMode = this.DragMode;
					if (dragMode != 0 && dragMode >= 6)
					{
						this.panMainViewport.Capture = true;
					}
				}
				else if (e.Button == MouseButtons.Right)
				{
					this.DragPreventMenu = this.CancelDepressedDrag(true);
					this.CompletePressedDrag(e.X, e.Y);
					if (this.EntityType != 0)
					{
						int num18 = *(int*)this.World + 8;
						int num19 = *(int*)this.IViewport + 56;
						GRay gRay9;
						int num20 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GRay modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), this.World, this.EntityType, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay9, e.X, e.Y, *num19), 0, *num18);
						if (num20 >= 0)
						{
							GEditorWorld* world14 = this.World;
							if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world14, this.EntityType, num20, *(*(int*)world14 + 28)))
							{
								int entityType2 = this.EntityType;
								if (*(ref this.EntityLockSelection + entityType2) == 0)
								{
									GEditorWorld* world15 = this.World;
									calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world15, entityType2, num20, 16, *(*(int*)world15 + 16));
									ToolboxScriptEntities currentScriptEnittyToolbar2 = this.CurrentScriptEnittyToolbar;
									if (currentScriptEnittyToolbar2 != null)
									{
										currentScriptEnittyToolbar2.UpdateHilighting();
									}
								}
							}
						}
					}
					this.DragMX = e.X;
					this.DragMY = e.Y;
					int editorMode2 = this.EditorMode;
					if (editorMode2 == 1)
					{
						int num21 = this.propBrushType;
						if (num21 < 20 || num21 == 24)
						{
							goto IL_11A5;
						}
					}
					if (editorMode2 != 2)
					{
						goto IL_11CE;
					}
					IL_11A5:
					if (*(ref this.KeyTimes + 128) != 0L && this.BrushSize != null)
					{
						this.DragMode = 20;
						goto IL_129B;
					}
					IL_11CE:
					if (editorMode2 == 1)
					{
						int num22 = this.propBrushType;
						if (num22 < 20 || num22 == 24)
						{
							goto IL_11EC;
						}
					}
					if (editorMode2 != 2)
					{
						goto IL_1215;
					}
					IL_11EC:
					if (*(ref this.KeyTimes + 136) != 0L && this.BrushSize != null)
					{
						this.DragMode = 21;
						goto IL_129B;
					}
					IL_1215:
					if (editorMode2 == 11)
					{
						GEditorWorld* world16 = this.World;
						if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world16, 5, *(*(int*)world16 + 32)) && *(ref this.KeyTimes + 128) != 0L)
						{
							this.DragMode = 28;
							goto IL_129B;
						}
					}
					if (this.EditorMode == 11)
					{
						GEditorWorld* world17 = this.World;
						if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world17, 5, *(*(int*)world17 + 32)) && *(ref this.KeyTimes + 136) != 0L)
						{
							this.DragMode = 27;
							goto IL_129B;
						}
					}
					this.DragMode = 19;
					IL_129B:
					this.DragStarted = false;
					this.panMainViewport.Capture = true;
					<Module>.ShowCursor(0);
				}
				else if (e.Button == MouseButtons.Middle)
				{
					this.CompletePressedDrag(e.X, e.Y);
					this.CancelDepressedDrag(true);
					this.DragMX = e.X;
					this.DragMY = e.Y;
					this.DragMode = 18;
					this.panMainViewport.Capture = true;
					<Module>.ShowCursor(0);
				}
			}
		}

		private unsafe void panMainViewport_MouseUp(object sender, MouseEventArgs e)
		{
			this.SelectionPossible = false;
			if (this.GameDebugMode)
			{
				this.DebugMouseUp(sender, e);
			}
			else if (e.Button == MouseButtons.Left)
			{
				this.CompletePressedDrag(e.X, e.Y);
				int entityType = this.EntityType;
				if (entityType != 0 && *(entityType * 4 + ref this.EntityOperation) == 2)
				{
					this.StartEntityPreCreate();
				}
				else if ((entityType == 9 || entityType == 11 || entityType == 13 || entityType == 15 || entityType == 17) && *(entityType * 4 + ref this.EntityOperation) == 4)
				{
					this.StartEntityPreCreateNode();
				}
				int editorMode = this.EditorMode;
				if (editorMode == 10)
				{
					this.UnitPropertiesTools.Refresh(this.World);
				}
				else if (editorMode == 9)
				{
					this.BuildingPropertiesTools.Refresh(this.World);
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				if ((this.DragMode != 0 && this.DragStarted) || this.DragPreventMenu)
				{
					this.CompletePressedDrag(e.X, e.Y);
					this.DragPreventMenu = false;
				}
				else
				{
					this.CompletePressedDrag(e.X, e.Y);
					this.MapNoteX = e.X;
					this.MapNoteY = e.Y;
					Point pos = new Point(e.X, e.Y);
					this.MainViewPopupMenu.Show(this.panMainViewport, pos);
				}
			}
			else if (e.Button == MouseButtons.Middle)
			{
				this.CompletePressedDrag(e.X, e.Y);
			}
		}

		private unsafe void panMainViewport_MouseMove(object sender, MouseEventArgs e)
		{
			if (Form.ActiveForm == this)
			{
				this.panMainViewport.Focus();
				if (this.GameDebugMode)
				{
					this.DebugMouseMove(sender, e);
				}
				else if (this.World != null)
				{
					float num;
					float mouseTargetY;
					float num2;
					if (this.EditorMode == 15)
					{
						<Module>.GWorld.GetPointInTopMode(this.World, this.IViewport, (float)e.X, (float)e.Y, ref num, ref mouseTargetY, ref num2);
					}
					else if (this.DragMode == 4)
					{
						int num3 = *(int*)this.IViewport + 56;
						GRay gRay;
						<Module>.GEditorWorld.GetPasteTarget(this.World, this.Clipboard, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, e.X, e.Y, *num3), ref num, ref mouseTargetY, ref num2);
					}
					else
					{
						int num4 = *(int*)this.IViewport + 56;
						GRay gRay2;
						<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay2, e.X, e.Y, *num4), ref num, ref mouseTargetY, ref num2);
					}
					this.MouseTargetX = num;
					this.MouseTargetY = mouseTargetY;
					this.MouseTargetZ = num2;
					if (this.SelectionPossible && (e.X != this.DragMX || e.Y != this.DragMY))
					{
						this.DragMode = 7;
						this.RefreshTerraformer();
						<Module>.GEditorWorld.StartTerraforming(this.World, this.Terraformer);
						this.SelectionActive = true;
						this.SelectionPossible = false;
					}
					switch (this.DragMode)
					{
					case 1:
					case 2:
					{
						int num5 = *(int*)this.IViewport + 56;
						GRay gRay3;
						<Module>.GEditorWorld.FollowEntityPlace(this.World, num, num2, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay3, e.X, e.Y, *num5));
						goto IL_B14;
					}
					case 3:
						<Module>.GEditorWorld.FollowEntityPaste(this.World, num, num2);
						goto IL_B14;
					case 4:
						if (num >= 0f)
						{
							<Module>.GEditorWorld.DragPaste(this.World, this.Clipboard, <Module>.fround(num), <Module>.fround(num2));
							goto IL_B14;
						}
						goto IL_B14;
					case 5:
					case 7:
						<Module>.GEditorWorld.Terraform(this.World, e.X, e.Y, false, false);
						goto IL_B14;
					case 9:
					{
						int num6 = *(int*)this.IViewport + 56;
						GRay gRay4;
						<Module>.GEditorWorld.FollowEntityMove(this.World, num, num2, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay4, e.X, e.Y, *num6));
						goto IL_B14;
					}
					case 10:
						<Module>.GEditorWorld.FollowEntityLift(this.World, e.Y);
						goto IL_B14;
					case 11:
						if (this.EntityType != 7)
						{
							<Module>.GEditorWorld.FollowEntityRotate(this.World, e.Y);
							goto IL_B14;
						}
						if (e.Y - this.DragMY > 20)
						{
							<Module>.?TransformSelectedDecals@GEditorWorld@@$$FQAEXW4GDecalOp@@@Z(this.World, 403);
							this.DragMY = e.Y;
							goto IL_B14;
						}
						if (this.DragMY - e.Y > 20)
						{
							<Module>.?TransformSelectedDecals@GEditorWorld@@$$FQAEXW4GDecalOp@@@Z(this.World, 402);
							this.DragMY = e.Y;
							goto IL_B14;
						}
						goto IL_B14;
					case 12:
						<Module>.GEditorWorld.FollowEntityPointRotate(this.World, e.Y);
						goto IL_B14;
					case 13:
						<Module>.GEditorWorld.FollowEntityTilt(this.World, num, num2);
						goto IL_B14;
					case 14:
					case 15:
					{
						<Module>.GWorld.SetBoxSelection(this.World, this.DragMX, this.DragMY, e.X, e.Y);
						int num7 = *(int*)this.World + 20;
						int num8 = *(int*)this.IViewport + 60;
						GPyramid gPyramid;
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GPyramid modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32), this.World, this.EntityType, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), this.IViewport, ref gPyramid, this.DragMX, this.DragMY, e.X, e.Y, *num8), 33, *num7);
						ToolboxScriptEntities currentScriptEnittyToolbar = this.CurrentScriptEnittyToolbar;
						if (currentScriptEnittyToolbar != null)
						{
							currentScriptEnittyToolbar.UpdateHilighting();
							goto IL_B14;
						}
						goto IL_B14;
					}
					case 16:
						<Module>.GEditorWorld.FollowEntityScale(this.World, e.Y);
						goto IL_B14;
					case 17:
					{
						int num9 = *(int*)this.IViewport + 56;
						GRay gRay5;
						<Module>.GEditorWorld.FollowEntityPostPlace(this.World, num, num2, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay5, e.X, e.Y, *num9));
						goto IL_B14;
					}
					case 18:
						if (e.X != this.DragMX || e.Y != this.DragMY)
						{
							<Module>.GWorld.CameraRotate(this.World, (float)((double)(e.X - this.DragMX) * 0.002), (float)((double)(e.Y - this.DragMY) * 0.002));
							tagPOINT dragMX = this.DragMX;
							*(ref dragMX + 4) = this.DragMY;
							<Module>.ClientToScreen((HWND__*)this.panMainViewport.Handle.ToPointer(), &dragMX);
							<Module>.SetCursorPos(dragMX, *(ref dragMX + 4));
							this.MinimapViewportNeedsUpdate = true;
							goto IL_B14;
						}
						goto IL_B14;
					case 19:
						if ((this.DragStarted || Math.Abs(e.X - this.DragMX) >= 2 || Math.Abs(e.Y - this.DragMY) >= 2) && (e.X != this.DragMX || e.Y != this.DragMY))
						{
							this.DragStarted = true;
							<Module>.GWorld.CameraMove(this.World, (float)((double)(this.DragMY - e.Y) * 0.02), (float)((double)(e.X - this.DragMX) * 0.02));
							tagPOINT dragMX2 = this.DragMX;
							*(ref dragMX2 + 4) = this.DragMY;
							<Module>.ClientToScreen((HWND__*)this.panMainViewport.Handle.ToPointer(), &dragMX2);
							<Module>.SetCursorPos(dragMX2, *(ref dragMX2 + 4));
							this.MinimapViewportNeedsUpdate = true;
							goto IL_B14;
						}
						goto IL_B14;
					case 20:
						if ((this.DragStarted || Math.Abs(e.X - this.DragMX) >= 2 || Math.Abs(e.Y - this.DragMY) >= 2) && (e.X != this.DragMX || e.Y != this.DragMY))
						{
							this.DragStarted = true;
							float* brushSize = this.BrushSize;
							float num10 = (float)((double)(e.X - this.DragMX) * 0.02 + (double)(*brushSize));
							this.BrushSize = ref num10;
							if (this.EditorMode == 1)
							{
								int num11 = this.propBrushType;
								if ((num11 < 20 && this.VertexFalloffType == 101) || (num11 == 24 && this.SelectionFalloffType == 101))
								{
									float* brushSize2 = this.BrushSize2;
									float num12 = (float)((double)(this.DragMY - e.Y) * 0.1 + (double)(*brushSize2));
									this.BrushSize2 = ref num12;
								}
							}
							this.UpdateBrushSliders();
							tagPOINT dragMX3 = this.DragMX;
							*(ref dragMX3 + 4) = this.DragMY;
							<Module>.ClientToScreen((HWND__*)this.panMainViewport.Handle.ToPointer(), &dragMX3);
							<Module>.SetCursorPos(dragMX3, *(ref dragMX3 + 4));
							goto IL_B14;
						}
						goto IL_B14;
					case 21:
						if ((this.DragStarted || Math.Abs(e.X - this.DragMX) >= 2 || Math.Abs(e.Y - this.DragMY) >= 2) && (e.X != this.DragMX || e.Y != this.DragMY))
						{
							this.DragStarted = true;
							float* brushPressure = this.BrushPressure;
							float num13 = (float)((double)(e.X - this.DragMX) * 0.2 + (double)(*brushPressure));
							this.BrushPressure = ref num13;
							if (this.EditorMode == 1)
							{
								int num14 = this.propBrushType;
								if (num14 == 6 || num14 == 5 || num14 == 4)
								{
									float* brushHeight = this.BrushHeight;
									float num15 = (float)((double)(this.DragMY - e.Y) * 0.1 + (double)(*brushHeight));
									this.BrushHeight = ref num15;
								}
							}
							this.UpdateBrushSliders();
							tagPOINT dragMX4 = this.DragMX;
							*(ref dragMX4 + 4) = this.DragMY;
							<Module>.ClientToScreen((HWND__*)this.panMainViewport.Handle.ToPointer(), &dragMX4);
							<Module>.SetCursorPos(dragMX4, *(ref dragMX4 + 4));
							goto IL_B14;
						}
						goto IL_B14;
					case 22:
					case 23:
					{
						int num16 = *(int*)this.IViewport + 56;
						GRay gRay6;
						<Module>.GWorld.SelectWirePoint(this.World, <Module>.GWorld.GetTargetWirePoint(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay6, e.X, e.Y, *num16)), 33);
						goto IL_B14;
					}
					case 24:
						goto IL_B14;
					case 25:
						<Module>.GEditorWorld.SetParcelSelection(this.World, this.DragX, this.DragZ, num, num2);
						this.SectorSelectionNeedsUpdate = true;
						goto IL_B14;
					case 27:
						if ((this.DragStarted || Math.Abs(e.X - this.DragMX) >= 2 || Math.Abs(e.Y - this.DragMY) >= 2) && (e.X != this.DragMX || e.Y != this.DragMY))
						{
							this.DragStarted = true;
							if (this.EditorMode == 11)
							{
								GEditorWorld* world = this.World;
								if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, 5, *(*(int*)world + 32)))
								{
									<Module>.GEditorWorld.ChangeSelectedAmbientMinRange(this.World, (float)((double)(e.X - this.DragMX) * 0.1));
								}
							}
							tagPOINT dragMX5 = this.DragMX;
							*(ref dragMX5 + 4) = this.DragMY;
							<Module>.ClientToScreen((HWND__*)this.panMainViewport.Handle.ToPointer(), &dragMX5);
							<Module>.SetCursorPos(dragMX5, *(ref dragMX5 + 4));
							goto IL_B14;
						}
						goto IL_B14;
					case 28:
						if ((this.DragStarted || Math.Abs(e.X - this.DragMX) >= 2 || Math.Abs(e.Y - this.DragMY) >= 2) && (e.X != this.DragMX || e.Y != this.DragMY))
						{
							this.DragStarted = true;
							if (this.EditorMode == 11)
							{
								GEditorWorld* world2 = this.World;
								if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world2, 5, *(*(int*)world2 + 32)))
								{
									<Module>.GEditorWorld.ChangeSelectedAmbientMaxRange(this.World, (float)((double)(e.X - this.DragMX) * 0.1));
								}
							}
							tagPOINT dragMX6 = this.DragMX;
							*(ref dragMX6 + 4) = this.DragMY;
							<Module>.ClientToScreen((HWND__*)this.panMainViewport.Handle.ToPointer(), &dragMX6);
							<Module>.SetCursorPos(dragMX6, *(ref dragMX6 + 4));
							goto IL_B14;
						}
						goto IL_B14;
					}
					if (this.EditorMode == 8)
					{
						int num17 = *(int*)this.IViewport + 56;
						GRay gRay7;
						<Module>.GWorld.SelectWirePoint(this.World, <Module>.GWorld.GetTargetWirePoint(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay7, e.X, e.Y, *num17)), 33);
					}
					else if (this.EntityType != 0)
					{
						int num18 = *(int*)this.World + 24;
						int num19 = *(int*)this.IViewport + 56;
						GRay gRay8;
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GRay modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32), this.World, this.EntityType, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay8, e.X, e.Y, *num19), 33, *num18);
						ToolboxScriptEntities currentScriptEnittyToolbar2 = this.CurrentScriptEnittyToolbar;
						if (currentScriptEnittyToolbar2 != null)
						{
							currentScriptEnittyToolbar2.UpdateHilighting();
						}
					}
					IL_B14:
					int editorMode = this.EditorMode;
					if (editorMode == 1 || editorMode == 2)
					{
						this.BrushNeedsUpdate = true;
						this.BrushX = num;
						this.BrushZ = num2;
						if (this.propPaintType == 14)
						{
							float num20;
							if (num >= 0f)
							{
								num20 = num * 0.0625f;
							}
							else
							{
								num20 = -1f;
							}
							int num21 = (int)((double)num20);
							float num22;
							if (num2 >= 0f)
							{
								num22 = num2 * 0.0625f;
							}
							else
							{
								num22 = -1f;
							}
							int num23 = (int)((double)num22);
							if (!this.TileDataValid || num21 != this.TileParcelX || num23 != this.TileParcelZ)
							{
								this.TileParcelX = num21;
								this.TileParcelZ = num23;
								this.TileDataValid = true;
								this.TerrainFilePicker.UpdateLayerUsage(<Module>.GEditorWorld.GetLayerUsageFlags(this.World, num21, num23));
							}
						}
					}
				}
			}
		}

		private unsafe void panMainViewport_MouseWheel(object sender, MouseEventArgs e)
		{
			GEditorWorld* world = this.World;
			if (world != null || this.GameDebugWorld != null)
			{
				int editorMode = this.EditorMode;
				if (editorMode == 2 && *(ref this.KeyTimes + 128) != 0L)
				{
					if (e.Delta > 0)
					{
						GTerraformer* ptr = this.Terraformer + 12 / sizeof(GTerraformer);
						int num = *(int*)ptr;
						if (num < 19)
						{
							*(int*)ptr = num + 1;
						}
					}
					if (e.Delta < 0)
					{
						GTerraformer* ptr2 = this.Terraformer + 12 / sizeof(GTerraformer);
						int num2 = *(int*)ptr2;
						if (num2 > 0)
						{
							*(int*)ptr2 = num2 - 1;
						}
					}
					this.TerrainFilePicker.SelectLayer(*(int*)(this.Terraformer + 12 / sizeof(GTerraformer)));
				}
				else if (editorMode == 11 && calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, 5, *(*(int*)world + 32)) && *(ref this.KeyTimes + 128) != 0L)
				{
					<Module>.GEditorWorld.ChangeSelectedAmbientVolume(this.World, (float)e.Delta * 0.0003f);
				}
				else if (this.GameDebugMode)
				{
					<Module>.GWorld.CameraZoom(this.GameDebugWorld, (float)e.Delta * 0.008333334f * -2f);
				}
				else
				{
					<Module>.GWorld.CameraZoom(this.World, (float)e.Delta * 0.008333334f * -2f);
					this.MinimapViewportNeedsUpdate = true;
				}
			}
		}

		private unsafe void menuEditUndo_Click(object sender, EventArgs e)
		{
			GEditorWorld* world = this.World;
			if (world != null)
			{
				if (this.EditorMode != 15)
				{
					this.LastCameraType = <Module>.?GetCameraType@GWorld@@$$FQBE?AW4GCameraType@@XZ(world);
					<Module>.GWorld.GetCamera(this.World, this.LastCamera);
				}
				<Module>.GEditorWorld.Undo(this.World);
				if (this.EditorMode != 15)
				{
					<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(this.World, this.LastCameraType);
					<Module>.GWorld.SetCamera(this.World, this.LastCamera);
					this.InitMinimap();
				}
				if (this.EditorMode == 2)
				{
					this.TerrainFilePicker.UpdateLayerList(-1, 0);
				}
				int editorMode = this.EditorMode;
				if (editorMode == 10)
				{
					this.UnitPropertiesTools.Refresh(this.World);
				}
				else if (editorMode == 9)
				{
					this.BuildingPropertiesTools.Refresh(this.World);
				}
				this.RefreshMenuAndToolbarItems();
				this.RefreshMinimap();
			}
		}

		private unsafe void menuEditRedo_Click(object sender, EventArgs e)
		{
			GEditorWorld* world = this.World;
			if (world != null)
			{
				if (this.EditorMode != 15)
				{
					this.LastCameraType = <Module>.?GetCameraType@GWorld@@$$FQBE?AW4GCameraType@@XZ(world);
					<Module>.GWorld.GetCamera(this.World, this.LastCamera);
				}
				<Module>.GEditorWorld.Redo(this.World);
				if (this.EditorMode != 15)
				{
					<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(this.World, this.LastCameraType);
					<Module>.GWorld.SetCamera(this.World, this.LastCamera);
					this.InitMinimap();
				}
				if (this.EditorMode == 2)
				{
					this.TerrainFilePicker.UpdateLayerList(-1, 0);
				}
				int editorMode = this.EditorMode;
				if (editorMode == 10)
				{
					this.UnitPropertiesTools.Refresh(this.World);
				}
				else if (editorMode == 9)
				{
					this.BuildingPropertiesTools.Refresh(this.World);
				}
				this.RefreshMenuAndToolbarItems();
				this.RefreshMinimap();
			}
		}

		private unsafe void menuEditCut_Click(object sender, EventArgs e)
		{
			GEditorWorld* world = this.World;
			if (world != null)
			{
				int entityType = this.EntityType;
				if (entityType != 0)
				{
					<Module>.?CutSelectedEntities@GEditorWorld@@$$FQAEXW4GEntityType@@AAUGEntityClipboard@@@Z(world, entityType, this.EntityClipboard);
				}
				this.RefreshMenuAndToolbarItems();
			}
		}

		private unsafe void menuEditCopy_Click(object sender, EventArgs e)
		{
			GEditorWorld* world = this.World;
			if (world != null)
			{
				if (this.EditorMode == 1)
				{
					GWorldClipboard* clipboard = this.Clipboard;
					if (clipboard != null)
					{
						GWorldClipboard* ptr = clipboard;
						<Module>.GWorldClipboard.{dtor}(ptr);
						<Module>.delete((void*)ptr);
						this.Clipboard = null;
					}
					this.Clipboard = <Module>.GEditorWorld.Copy(this.World);
				}
				else
				{
					int entityType = this.EntityType;
					if (entityType != 0)
					{
						<Module>.?CopySelectedEntities@GEditorWorld@@$$FQAEXW4GEntityType@@AAUGEntityClipboard@@@Z(world, entityType, this.EntityClipboard);
					}
				}
				this.RefreshMenuAndToolbarItems();
			}
		}

		private void menuEditPaste_Click(object sender, EventArgs e)
		{
			if (this.World != null)
			{
				this.StartPaste();
				this.RefreshMenuAndToolbarItems();
			}
		}

		private unsafe void menuEditDelete_Click(object sender, EventArgs e)
		{
			GEditorWorld* world = this.World;
			if (world != null)
			{
				switch (this.EditorMode)
				{
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 9:
				case 10:
				case 11:
				case 12:
				case 16:
				case 17:
				case 18:
				case 21:
				{
					<Module>.?RemoveSelectedEntities@GEditorWorld@@$$FQAEXW4GEntityType@@@Z(world, this.EntityType);
					ToolboxEntities currentEntityToolbar = this.CurrentEntityToolbar;
					if (currentEntityToolbar != null && *(ref this.EntityLockSelection + this.EntityType) != 0)
					{
						currentEntityToolbar.EmulatePushByID(303);
						this.CurrentEntityToolbar.EmulateUpByID(303);
					}
					break;
				}
				case 8:
				{
					int num = *(int*)(world + 3104 / sizeof(GEditorWorld));
					if (num >= 0)
					{
						<Module>.GWorld.RemoveWirePointConnections(world, num);
					}
					break;
				}
				}
				this.RefreshMenuAndToolbarItems();
			}
		}

		private unsafe void panMainViewport_DoubleClick(object sender, EventArgs e)
		{
			if (!this.GameDebugMode)
			{
				GEditorWorld* world = this.World;
				if (world != null)
				{
					switch (this.EntityType)
					{
					case 13:
					case 14:
						<Module>.GEditorWorld.SelectAllCorrespondingCameraCurveNodes(world);
						break;
					case 15:
					case 16:
						<Module>.GEditorWorld.SelectAllCorrespondingPathNodes(world);
						break;
					case 17:
					case 18:
						<Module>.GEditorWorld.SelectAllCorrespondingLocationVertices(world);
						break;
					}
				}
			}
		}

		private unsafe void menuEditSelectAll_Click(object sender, EventArgs e)
		{
			GEditorWorld* world = this.World;
			if (world != null)
			{
				int entityType = this.EntityType;
				if (entityType != 0)
				{
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world, entityType, 16, *(*(int*)world + 12));
					ToolboxScriptEntities currentScriptEnittyToolbar = this.CurrentScriptEnittyToolbar;
					if (currentScriptEnittyToolbar != null)
					{
						currentScriptEnittyToolbar.UpdateHilighting();
					}
					int editorMode = this.EditorMode;
					if (editorMode == 10)
					{
						this.UnitPropertiesTools.Refresh(this.World);
					}
					else if (editorMode == 9)
					{
						this.BuildingPropertiesTools.Refresh(this.World);
					}
				}
				else
				{
					int editorMode = this.EditorMode;
					if (editorMode == 1 || editorMode == 2)
					{
						<Module>.GEditorWorld.SelectAll(world);
					}
				}
				this.RefreshMenuAndToolbarItems();
			}
		}

		private unsafe void menuEditSelectNone_Click(object sender, EventArgs e)
		{
			GEditorWorld* world = this.World;
			if (world != null)
			{
				int entityType = this.EntityType;
				if (entityType != 0)
				{
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world, entityType, 0, *(*(int*)world + 12));
					ToolboxEntities currentEntityToolbar = this.CurrentEntityToolbar;
					if (currentEntityToolbar != null && *(ref this.EntityLockSelection + this.EntityType) != 0)
					{
						currentEntityToolbar.EmulatePushByID(303);
						this.CurrentEntityToolbar.EmulateUpByID(303);
					}
					ToolboxScriptEntities currentScriptEnittyToolbar = this.CurrentScriptEnittyToolbar;
					if (currentScriptEnittyToolbar != null)
					{
						currentScriptEnittyToolbar.UpdateHilighting();
					}
				}
				else
				{
					int editorMode = this.EditorMode;
					if (editorMode == 1 || editorMode == 2)
					{
						<Module>.GEditorWorld.SelectNone(world);
						this.SelectionActive = false;
					}
				}
				this.RefreshMenuAndToolbarItems();
			}
		}

		private void menuModeVertex_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(1);
		}

		private void menuModePaint_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(2);
		}

		private void menuModeRoad_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(3);
		}

		private void menuModeDecal_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(4);
		}

		private void menuModeLake_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(5);
		}

		private void menuModeRiver_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(6);
		}

		private void menuModeCameraCurve_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(16);
		}

		private void menuModePaths_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(17);
		}

		private void menuModeLocations_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(18);
		}

		private void menuModeUnitGroup_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(19);
		}

		private void menuModeDoodad_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(7);
		}

		private void menuModeWire_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(8);
		}

		private void menuModeBuilding_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(9);
		}

		private void menuModeUnit_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(10);
		}

		private void menuModeAmbient_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(11);
		}

		private void menuModeEffect_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(12);
		}

		private void menuModeSectors_Click(object sender, EventArgs e)
		{
			this.SetEditorMode(15);
		}

		private unsafe void menuViewSidebarLeft_Click(object sender, EventArgs e)
		{
			base.SuspendLayout();
			this.panSideBar.Dock = DockStyle.Left;
			this.splitMain.Dock = DockStyle.Left;
			this.panSideBar.Visible = true;
			this.splitMain.Visible = true;
			base.ResumeLayout();
			this.menuViewSidebarLeft.Checked = true;
			this.menuViewSidebarRight.Checked = false;
			this.menuViewSidebarOff.Checked = false;
			*(ref <Module>.Options + 4) = 0;
			<Module>.SaveOptions();
		}

		private unsafe void menuViewSidebarRight_Click(object sender, EventArgs e)
		{
			base.SuspendLayout();
			this.panSideBar.Dock = DockStyle.Right;
			this.splitMain.Dock = DockStyle.Right;
			this.panSideBar.Visible = true;
			this.splitMain.Visible = true;
			base.ResumeLayout();
			this.menuViewSidebarLeft.Checked = false;
			this.menuViewSidebarRight.Checked = true;
			this.menuViewSidebarOff.Checked = false;
			*(ref <Module>.Options + 4) = 1;
			<Module>.SaveOptions();
		}

		private unsafe void menuViewSidebarOff_Click(object sender, EventArgs e)
		{
			base.SuspendLayout();
			this.panSideBar.Visible = false;
			this.splitMain.Visible = false;
			base.ResumeLayout();
			this.menuViewSidebarLeft.Checked = false;
			this.menuViewSidebarRight.Checked = false;
			this.menuViewSidebarOff.Checked = true;
			*(ref <Module>.Options + 4) = 2;
			<Module>.SaveOptions();
		}

		private void menuViewToolbar_Click(object sender, EventArgs e)
		{
			byte @checked = (!this.menuViewToolbar.Checked) ? 1 : 0;
			this.menuViewToolbar.Checked = (@checked != 0);
			this.tbMain.Visible = this.menuViewToolbar.Checked;
			<Module>.Options = this.menuViewToolbar.Checked;
			<Module>.SaveOptions();
		}

		private unsafe void menuViewStatusBar_Click(object sender, EventArgs e)
		{
			byte @checked = (!this.menuViewStatusBar.Checked) ? 1 : 0;
			this.menuViewStatusBar.Checked = (@checked != 0);
			this.sbMain.Visible = this.menuViewStatusBar.Checked;
			*(ref <Module>.Options + 1) = (this.menuViewStatusBar.Checked ? 1 : 0);
			<Module>.SaveOptions();
		}

		private unsafe void menuSoundDisable_Click(object sender, EventArgs e)
		{
			this.menuSoundDisable.Checked = true;
			this.menuSoundStereo.Checked = false;
			this.menuSoundQuad.Checked = false;
			this.menuSoundSurround.Checked = false;
			if (<Module>.ISoundSys != null)
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.ISoundSys, 3, 2, *(*(int*)<Module>.ISoundSys + 28));
			}
		}

		private unsafe void menuSoundStereo_Click(object sender, EventArgs e)
		{
			this.menuSoundDisable.Checked = false;
			this.menuSoundStereo.Checked = true;
			this.menuSoundQuad.Checked = false;
			this.menuSoundSurround.Checked = false;
			if (<Module>.ISoundSys != null)
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.ISoundSys, 0, 2, *(*(int*)<Module>.ISoundSys + 28));
			}
		}

		private unsafe void menuSoundQuad_Click(object sender, EventArgs e)
		{
			this.menuSoundDisable.Checked = false;
			this.menuSoundStereo.Checked = false;
			this.menuSoundQuad.Checked = true;
			this.menuSoundSurround.Checked = false;
			if (<Module>.ISoundSys != null)
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.ISoundSys, 0, 3, *(*(int*)<Module>.ISoundSys + 28));
			}
		}

		private unsafe void menuSoundSurround_Click(object sender, EventArgs e)
		{
			this.menuSoundDisable.Checked = false;
			this.menuSoundStereo.Checked = false;
			this.menuSoundQuad.Checked = false;
			this.menuSoundSurround.Checked = true;
			if (<Module>.ISoundSys != null)
			{
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.ISoundSys, 0, 5, *(*(int*)<Module>.ISoundSys + 28));
			}
		}

		private unsafe void menuSoundReverseStereo_Click(object sender, EventArgs e)
		{
			byte @checked = (!this.menuSoundReverseStereo.Checked) ? 1 : 0;
			this.menuSoundReverseStereo.Checked = (@checked != 0);
			if (<Module>.ISoundSys != null)
			{
				GISoundSys* expr_27 = <Module>.ISoundSys;
				int num = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_27, *(*(int*)expr_27 + 12)) & -33;
				int num2 = this.menuSoundReverseStereo.Checked ? 32 : 0;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.ISoundSys, num2 | num, *(*(int*)<Module>.ISoundSys + 16));
			}
		}

		private void menuToolsUnitEditor_Click(object sender, EventArgs e)
		{
			NUnitEditor nUnitEditor = new NUnitEditor(this.ToolWindows, string.Empty, this.UnitEditorClipboard);
			nUnitEditor.PUnitChanged += new NUnitEditor.__Delegate_PUnitChanged(this.UnitEditor_PUnitChanged);
			nUnitEditor.Show();
			<Module>.SaveOptions();
		}

		private unsafe void UnitEditor_PUnitChanged(sbyte* punit_filename)
		{
			if (this.World != null)
			{
				int num = -1;
				while (true)
				{
					GEditorWorld* world = this.World;
					GHeap<GWUnit>* ptr = world + 2884 / sizeof(GEditorWorld);
					int num2 = num + 1;
					int num3 = *(ptr + 4);
					if (num2 >= num3)
					{
						break;
					}
					int num4 = num2 * 124 + *ptr;
					while (*num4 != 2147483647)
					{
						num2++;
						num4 += 124;
						if (num2 >= num3)
						{
							goto IL_7E;
						}
					}
					num = num2;
					if (num2 < 0)
					{
						break;
					}
					GEditorWorld* expr_65 = world;
					<Module>.GWorld.RemoveUnit(expr_65, *(*(int*)(expr_65 + 2884 / sizeof(GEditorWorld)) + num2 * 124 + 108));
				}
				IL_7E:
				int num5 = -1;
				while (true)
				{
					GEditorWorld* world = this.World;
					GHeap<GWUnit>* ptr2 = world + 2884 / sizeof(GEditorWorld);
					int num6 = num5 + 1;
					int num7 = *(ptr2 + 4);
					if (num6 >= num7)
					{
						break;
					}
					int num8 = num6 * 124 + *ptr2;
					while (*num8 != 2147483647)
					{
						num6++;
						num8 += 124;
						if (num6 >= num7)
						{
							goto IL_12A;
						}
					}
					num5 = num6;
					if (num6 < 0)
					{
						break;
					}
					int num9 = *(int*)(world + 2884 / sizeof(GEditorWorld)) + num6 * 124 + 108;
					int num10 = *num9;
					int num11;
					if (num10 >= 0 && num10 < *(int*)(world + 2928 / sizeof(GEditorWorld) + 4 / sizeof(GEditorWorld)) && *(num10 * 8 + *(int*)(world + 2928 / sizeof(GEditorWorld))) == 2147483647)
					{
						num11 = 1;
					}
					else
					{
						num11 = 0;
					}
					if ((byte)num11 == 0)
					{
						*num9 = -1;
					}
				}
				IL_12A:
				int num12 = -1;
				while (true)
				{
					GEditorWorld* world = this.World;
					GHeap<GWUnit>* ptr3 = world + 2884 / sizeof(GEditorWorld);
					int num13 = num12 + 1;
					int num14 = *(ptr3 + 4);
					if (num13 >= num14)
					{
						break;
					}
					int num15 = num13 * 124 + *ptr3;
					while (*num15 != 2147483647)
					{
						num13++;
						num15 += 124;
						if (num13 >= num14)
						{
							goto IL_1EA;
						}
					}
					num12 = num13;
					if (num13 < 0)
					{
						break;
					}
					int num16 = *(int*)(world + 2884 / sizeof(GEditorWorld)) + num13 * 124;
					int num17 = *(num16 + 108);
					int num18;
					if (num17 >= 0 && num17 < *(int*)(world + 2928 / sizeof(GEditorWorld) + 4 / sizeof(GEditorWorld)) && *(num17 * 8 + *(int*)(world + 2928 / sizeof(GEditorWorld))) == 2147483647)
					{
						num18 = 1;
					}
					else
					{
						num18 = 0;
					}
					if ((byte)num18 == 0)
					{
						int num19 = num16 + 4;
						GWUnit* ptr4 = num19;
						*(num19 + 104) = <Module>.GWorld.CreateUnit(world, ptr4);
					}
				}
				IL_1EA:
				int num20 = -1;
				while (true)
				{
					GEditorWorld* ptr5 = this.World + 2884 / sizeof(GEditorWorld);
					GHeap<GWUnit>* ptr6 = ptr5;
					int num21 = num20 + 1;
					int num22 = *(ptr6 + 4);
					if (num21 >= num22)
					{
						break;
					}
					int num23 = num21 * 124 + *ptr6;
					while (*num23 != 2147483647)
					{
						num21++;
						num23 += 124;
						if (num21 >= num22)
						{
							return;
						}
					}
					num20 = num21;
					if (num21 < 0)
					{
						break;
					}
					int expr_247 = *(int*)ptr5 + num21 * 124 + 4;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_247, *(*expr_247 + 8));
					this.panMainViewport.Invalidate();
				}
			}
		}

		private void menuToolsEffectEditor_Click(object sender, EventArgs e)
		{
			NEffectEditor nEffectEditor = new NEffectEditor(this.ToolWindows, "", this.EffectEditorClipboard);
			this.ToolWindows.Add(nEffectEditor);
			nEffectEditor.Show();
			<Module>.SaveOptions();
		}

		private void menuToolsScriptEditor_Click(object sender, EventArgs e)
		{
			ScriptEditorForm scriptEditorFormInstance = this.ScriptEditorFormInstance;
			if (scriptEditorFormInstance != null)
			{
				scriptEditorFormInstance.Focus();
				this.RegisterScriptRefreshCallback();
			}
			else if (this.World != null)
			{
				this.ScriptEditorFormInstance = new ScriptEditorForm();
				this.ScriptEditorFormInstance.Closed += new EventHandler(this.ScriptEditorForm_Closed);
				this.ScriptEditorFormInstance.Show();
				this.RegisterScriptRefreshCallback();
				<Module>.SaveOptions();
			}
		}

		private unsafe void ScriptEditorForm_Closed(object sender, EventArgs e)
		{
			this.ScriptEditorFormInstance = null;
			*(int*)(this.World + 5080 / sizeof(GEditorWorld)) = 0;
		}

		private unsafe void EffectEditor_PEffectChanged(sbyte* peffect_filename)
		{
			if (this.World != null)
			{
				int num = -1;
				while (true)
				{
					GEditorWorld* ptr = this.World + 3084 / sizeof(GEditorWorld);
					GHeap<GWEffect>* ptr2 = ptr;
					int num2 = num + 1;
					int num3 = *(ptr2 + 4);
					if (num2 >= num3)
					{
						break;
					}
					int num4 = num2 * 60 + *ptr2;
					while (*num4 != 2147483647)
					{
						num2++;
						num4 += 60;
						if (num2 >= num3)
						{
							return;
						}
					}
					num = num2;
					if (num2 < 0)
					{
						break;
					}
					int num5 = num2 * 60;
					if (((<Module>.GBaseString<char>.Compare(*(int*)ptr + num5 + 4 + 8, peffect_filename, false) == 0) ? 1 : 0) != 0)
					{
						int expr_91 = *(num5 + *(int*)(this.World + 3084 / sizeof(GEditorWorld)) + 52);
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_91, *(*expr_91 + 4));
						int expr_AE = *(num5 + *(int*)(this.World + 3084 / sizeof(GEditorWorld)) + 52);
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_AE, *(*expr_AE));
						int num6 = *(num5 + *(int*)(this.World + 3084 / sizeof(GEditorWorld)) + 52);
						if (num6 != 0)
						{
							int expr_D1 = num6;
							int expr_DB = expr_D1 + *(*(expr_D1 + 4) + 4) + 4;
							object arg_E5_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_DB, *(*expr_DB + 4));
							*(num5 + *(int*)(this.World + 3084 / sizeof(GEditorWorld)) + 52) = 0;
						}
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>), <Module>.IEngine, *(num5 + *(int*)(this.World + 3084 / sizeof(GEditorWorld)) + 48), *(*(int*)<Module>.IEngine + 216));
						GAEntity* ptr3 = num5 + *(int*)(this.World + 3084 / sizeof(GEditorWorld)) + 4;
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), ptr3, num2, *(*ptr3 + 4));
						*(ptr3 + 4) = 1;
						this.panMainViewport.Invalidate();
					}
				}
			}
		}

		private void menuToolsGameVariables_Click(object sender, EventArgs e)
		{
			new NGameVariablesEditor(this.ToolWindows).Show();
			<Module>.SaveOptions();
		}

		private void menuToolsMissionVariables_Click(object sender, EventArgs e)
		{
			new NMissionVariablesEditor(this.ToolWindows, this.World).Show();
			<Module>.SaveOptions();
		}

		private void panSideBar_Resize(object sender, EventArgs e)
		{
			Size size = this.panSideBar.Size;
			this.panSideBar.ViewWidth = size.Width;
			if (!this.Rearranging)
			{
				Size size2 = this.panSideBar.Size;
				if (this.OldHeight != size2.Height)
				{
					Size size3 = this.panSideBar.Size;
					this.panSideBar.ViewHeight = size3.Height;
					this.LayoutChanged = true;
				}
			}
		}

		private void panSideBarToolStateToggled()
		{
			this.LayoutChanged = true;
		}

		private unsafe void MainViewPopupMenu_Popup(object sender, EventArgs e)
		{
			this.MainViewPopupMenu.MenuItems.Clear();
			this.MainViewPopupMenu.MergeMenu(this.menuEdit);
			MenuItem item = new MenuItem("-");
			this.MainViewPopupMenu.MenuItems.Add(item);
			this.SelectedMapNote = <Module>.GEditorWorld.GetMapNoteAt(this.World, this.MapNoteX, this.MapNoteY);
			MenuItem menuItem = new MenuItem("Create map note");
			byte enabled = (this.SelectedMapNote == -1) ? 1 : 0;
			menuItem.Enabled = (enabled != 0);
			menuItem.Click += new EventHandler(this.menuItemCreateNote_Clicked);
			this.MainViewPopupMenu.MenuItems.Add(menuItem);
			MenuItem menuItem2 = new MenuItem("Edit map note");
			byte enabled2 = (this.SelectedMapNote > -1) ? 1 : 0;
			menuItem2.Enabled = (enabled2 != 0);
			menuItem2.Click += new EventHandler(this.menuItemEditNote_Clicked);
			this.MainViewPopupMenu.MenuItems.Add(menuItem2);
			MenuItem menuItem3 = new MenuItem("Remove map note");
			byte enabled3 = (this.SelectedMapNote > -1) ? 1 : 0;
			menuItem3.Enabled = (enabled3 != 0);
			menuItem3.Click += new EventHandler(this.menuItemRemoveNote_Clicked);
			this.MainViewPopupMenu.MenuItems.Add(menuItem3);
			int editorMode = this.EditorMode;
			if (editorMode == 10 || editorMode == 9)
			{
				GEditorWorld* world = this.World;
				if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, this.EntityType, *(*(int*)world + 32)) > 0)
				{
					MenuItem item2 = new MenuItem("-");
					MenuItem menuItem4 = new MenuItem("Unload All");
					menuItem4.Click += new EventHandler(this.menuItemUnloadAll_Clicked);
					this.MainViewPopupMenu.MenuItems.Add(item2);
					this.MainViewPopupMenu.MenuItems.Add(menuItem4);
				}
			}
			if (this.EditorMode == 19)
			{
				MenuItem item3 = new MenuItem("-");
				this.MainViewPopupMenu.MenuItems.Add(item3);
				GEditorWorld* world = this.World;
				if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, this.EntityType, *(*(int*)world + 32)) > 0)
				{
					MenuItem menuItem5 = new MenuItem("Add to new group");
					menuItem5.Click += new EventHandler(this.menuItemNewGroup_Clicked);
					this.MainViewPopupMenu.MenuItems.Add(menuItem5);
					MenuItem menuItem6 = new MenuItem("Add to selected group");
					menuItem6.Click += new EventHandler(this.menuItemAddtoGroup_Clicked);
					byte enabled4 = (this.CurrentScriptEnittyToolbar.SelectedEntityIndex >= 0) ? 1 : 0;
					menuItem6.Enabled = (enabled4 != 0);
					this.MainViewPopupMenu.MenuItems.Add(menuItem6);
					MenuItem menuItem7 = new MenuItem("Remove from group");
					menuItem7.Click += new EventHandler(this.menuItemRemovefromGroup_Clicked);
					byte enabled5 = (<Module>.GEditorWorld.GetSelectedAIGroup(this.World) >= -1) ? 1 : 0;
					menuItem7.Enabled = (enabled5 != 0);
					this.MainViewPopupMenu.MenuItems.Add(menuItem7);
				}
				MenuItem menuItem8 = new MenuItem("Create empty group");
				menuItem8.Click += new EventHandler(this.menuItemNewEmptyGroup_Clicked);
				this.MainViewPopupMenu.MenuItems.Add(menuItem8);
			}
			if (this.EditorMode == 15 && <Module>.GEditorWorld.IsParcelSelectionValid(this.World) != null)
			{
				MenuItem item4 = new MenuItem("-");
				this.MainViewPopupMenu.MenuItems.Add(item4);
				MenuItem menuItem9 = new MenuItem("Create sector");
				menuItem9.Click += new EventHandler(this.menuItemNewSector_Clicked);
				this.MainViewPopupMenu.MenuItems.Add(menuItem9);
				MenuItem menuItem10 = new MenuItem("Add to selected sector");
				menuItem10.Click += new EventHandler(this.menuItemAddtoSector_Clicked);
				byte enabled6 = (this.CurrentScriptEnittyToolbar.SelectedEntityIndex >= 0) ? 1 : 0;
				menuItem10.Enabled = (enabled6 != 0);
				this.MainViewPopupMenu.MenuItems.Add(menuItem10);
				MenuItem menuItem11 = new MenuItem("Clear parcels");
				menuItem11.Click += new EventHandler(this.menuItemRemovefromSector_Clicked);
				byte enabled7 = (<Module>.GEditorWorld.GetSelectedSector(this.World) >= -1) ? 1 : 0;
				menuItem11.Enabled = (enabled7 != 0);
				this.MainViewPopupMenu.MenuItems.Add(menuItem11);
			}
			if (this.EditorMode == 17)
			{
				GEditorWorld* world = this.World;
				if (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, this.EntityType, *(*(int*)world + 32)) == 1)
				{
					MenuItem item5 = new MenuItem("-");
					MenuItem menuItem12 = new MenuItem("Waiting node");
					menuItem12.Click += new EventHandler(this.menuItemPathnodeWait_Clicked);
					menuItem12.Checked = (<Module>.GEditorWorld.GetSelectedPathNodeWait(this.World) != null);
					this.MainViewPopupMenu.MenuItems.Add(item5);
					this.MainViewPopupMenu.MenuItems.Add(menuItem12);
				}
			}
			if (this.EditorMode == 6 && <Module>.GEditorWorld.CountSelectedRivers(this.World) == 1)
			{
				MenuItem item6 = new MenuItem("-");
				MenuItem menuItem13 = new MenuItem("Waterfall");
				menuItem13.Click += new EventHandler(this.menuItemWaterfall_Clicked);
				menuItem13.Checked = (<Module>.GEditorWorld.GetSelectedWaterFall(this.World) != null);
				this.MainViewPopupMenu.MenuItems.Add(item6);
				this.MainViewPopupMenu.MenuItems.Add(menuItem13);
			}
		}

		private void UnitFilePicker_ContextPopup(string punit_filename)
		{
		}

		private void BuildingFilePicker_ContextPopup(string punit_filename)
		{
		}

		private void menuItemUnloadAll_Clicked(object sender, EventArgs e)
		{
			int editorMode = this.EditorMode;
			if (editorMode == 10 || editorMode == 19 || editorMode == 9)
			{
				<Module>.GEditorWorld.UnloadAllStoredUnits(this.World);
				ScriptEditorForm scriptEditorFormInstance = this.ScriptEditorFormInstance;
				if (scriptEditorFormInstance != null)
				{
					scriptEditorFormInstance.EditorsChanged();
				}
			}
		}

		private void menuItemNewGroup_Clicked(object sender, EventArgs e)
		{
			<Module>.GEditorWorld.AddSelectedUnitsToGroup(this.World, -1);
			this.RefreshMenuAndToolbarItems();
		}

		private void menuItemNewEmptyGroup_Clicked(object sender, EventArgs e)
		{
			<Module>.GEditorWorld.CreateEmptyGroup(this.World);
			this.RefreshMenuAndToolbarItems();
		}

		private void menuItemAddtoGroup_Clicked(object sender, EventArgs e)
		{
			<Module>.GEditorWorld.AddSelectedUnitsToGroup(this.World, this.CurrentScriptEnittyToolbar.SelectedEntityIndex);
			this.RefreshMenuAndToolbarItems();
		}

		private void menuItemRemovefromGroup_Clicked(object sender, EventArgs e)
		{
			<Module>.GEditorWorld.RemoveSelectedUnitsFromGroup(this.World);
			this.RefreshMenuAndToolbarItems();
		}

		private void menuItemNewSector_Clicked(object sender, EventArgs e)
		{
			<Module>.GEditorWorld.AddSelectedParcelsToSector(this.World, -1);
			this.RefreshMenuAndToolbarItems();
		}

		private void menuItemAddtoSector_Clicked(object sender, EventArgs e)
		{
			<Module>.GEditorWorld.AddSelectedParcelsToSector(this.World, this.CurrentScriptEnittyToolbar.SelectedEntityIndex);
			this.RefreshMenuAndToolbarItems();
		}

		private void menuItemRemovefromSector_Clicked(object sender, EventArgs e)
		{
			<Module>.GEditorWorld.RemoveSelectedParcelsFromSector(this.World);
			this.RefreshMenuAndToolbarItems();
		}

		private unsafe void menuItemCreateNote_Clicked(object sender, EventArgs e)
		{
			GIViewport* iViewport = this.IViewport;
			GRay gRay;
			float num;
			float num2;
			float num3;
			<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, ref gRay, this.MapNoteX, this.MapNoteY, *(*(int*)iViewport + 56)), ref num, ref num2, ref num3);
			GPoint3 gPoint = num;
			*(ref gPoint + 4) = num2;
			*(ref gPoint + 8) = num3;
			this.SelectedMapNote = <Module>.GEditorWorld.CreateMapNote(this.World, gPoint);
			TextInputBox textInputBox = new TextInputBox();
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* ptr = <Module>.GEditorWorld.GetMapNoteText(this.World, &gBaseString<char>, this.SelectedMapNote);
			try
			{
				uint num4 = (uint)(*(int*)ptr);
				sbyte* value;
				if (num4 != 0u)
				{
					value = num4;
				}
				else
				{
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				textInputBox.EditText = new string((sbyte*)value);
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
			Point p = new Point(this.MapNoteX, this.MapNoteY);
			Point location = this.panMainViewport.PointToScreen(p);
			textInputBox.Location = location;
			if (textInputBox.ShowDialog() == DialogResult.OK)
			{
				GBaseString<char> gBaseString<char>2;
				GBaseString<char>* ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, textInputBox.EditText);
				GEditorWorld* world;
				int selectedMapNote;
				try
				{
					world = this.World;
					selectedMapNote = this.SelectedMapNote;
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
					throw;
				}
				<Module>.GEditorWorld.SetMapNote(world, selectedMapNote, ptr2);
			}
			else
			{
				<Module>.GEditorWorld.RemoveMapNote(this.World, this.SelectedMapNote);
			}
		}

		private unsafe void menuItemEditNote_Clicked(object sender, EventArgs e)
		{
			if (this.SelectedMapNote >= 0)
			{
				TextInputBox textInputBox = new TextInputBox();
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GEditorWorld.GetMapNoteText(this.World, &gBaseString<char>, this.SelectedMapNote);
				try
				{
					uint num = (uint)(*(int*)ptr);
					sbyte* value;
					if (num != 0u)
					{
						value = num;
					}
					else
					{
						value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					textInputBox.EditText = new string((sbyte*)value);
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
				Point p = new Point(this.MapNoteX, this.MapNoteY);
				Point location = this.panMainViewport.PointToScreen(p);
				textInputBox.Location = location;
				if (textInputBox.ShowDialog() == DialogResult.OK)
				{
					GBaseString<char> gBaseString<char>2;
					GBaseString<char>* ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, textInputBox.EditText);
					GEditorWorld* world;
					int selectedMapNote;
					try
					{
						world = this.World;
						selectedMapNote = this.SelectedMapNote;
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
						throw;
					}
					<Module>.GEditorWorld.SetMapNote(world, selectedMapNote, ptr2);
				}
			}
		}

		private void menuItemRemoveNote_Clicked(object sender, EventArgs e)
		{
			int selectedMapNote = this.SelectedMapNote;
			if (selectedMapNote >= 0)
			{
				<Module>.GEditorWorld.RemoveMapNote(this.World, selectedMapNote);
			}
		}

		private unsafe void menuItemEditUnit_Clicked(object sender, EventArgs e)
		{
			int editorMode = this.EditorMode;
			if (editorMode == 10)
			{
				GBaseString<char> gBaseString<char>;
				<Module>.GEditorWorld.GetSelectedPUnit(this.World, &gBaseString<char>);
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
					GBaseString<char> gBaseString<char>2;
					GBaseString<char>* ptr2 = <Module>.GFileSystem.GetFileFullPath(ref <Module>.FS, &gBaseString<char>2, ptr);
					NUnitEditor nUnitEditor;
					try
					{
						uint num = (uint)(*(int*)ptr2);
						sbyte* value;
						if (num != 0u)
						{
							value = num;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						nUnitEditor = new NUnitEditor(this.ToolWindows, new string((sbyte*)value), this.UnitEditorClipboard);
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
					nUnitEditor.PUnitChanged += new NUnitEditor.__Delegate_PUnitChanged(this.UnitEditor_PUnitChanged);
					nUnitEditor.Show();
					<Module>.SaveOptions();
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
			else if (editorMode == 9)
			{
				GBaseString<char> gBaseString<char>3;
				<Module>.GEditorWorld.GetSelectedPUnit(this.World, &gBaseString<char>3);
				try
				{
					sbyte* ptr3;
					if (gBaseString<char>3 != null)
					{
						ptr3 = gBaseString<char>3;
					}
					else
					{
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					GBaseString<char> gBaseString<char>4;
					GBaseString<char>* ptr4 = <Module>.GFileSystem.GetFileFullPath(ref <Module>.FS, &gBaseString<char>4, ptr3);
					NUnitEditor nUnitEditor2;
					try
					{
						uint num2 = (uint)(*(int*)ptr4);
						sbyte* value2;
						if (num2 != 0u)
						{
							value2 = num2;
						}
						else
						{
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						nUnitEditor2 = new NUnitEditor(this.ToolWindows, new string((sbyte*)value2), this.UnitEditorClipboard);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
						throw;
					}
					if (gBaseString<char>4 != null)
					{
						<Module>.free(gBaseString<char>4);
						gBaseString<char>4 = 0;
					}
					nUnitEditor2.PUnitChanged += new NUnitEditor.__Delegate_PUnitChanged(this.UnitEditor_PUnitChanged);
					nUnitEditor2.Show();
					<Module>.SaveOptions();
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
				if (gBaseString<char>3 != null)
				{
					<Module>.free(gBaseString<char>3);
				}
			}
		}

		private unsafe void menuItemFPEditUnit_Clicked(object sender, EventArgs e)
		{
			int editorMode = this.EditorMode;
			if (editorMode == 10)
			{
				GBaseString<char> gBaseString<char>;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, "units/" + this.UnitFilePicker.File);
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
					GBaseString<char> gBaseString<char>2;
					GBaseString<char>* ptr2 = <Module>.GFileSystem.GetFileFullPath(ref <Module>.FS, &gBaseString<char>2, ptr);
					NUnitEditor nUnitEditor;
					try
					{
						uint num = (uint)(*(int*)ptr2);
						sbyte* value;
						if (num != 0u)
						{
							value = num;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						nUnitEditor = new NUnitEditor(this.ToolWindows, new string((sbyte*)value), this.UnitEditorClipboard);
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
					nUnitEditor.PUnitChanged += new NUnitEditor.__Delegate_PUnitChanged(this.UnitEditor_PUnitChanged);
					nUnitEditor.Show();
					<Module>.SaveOptions();
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
			else if (editorMode == 9)
			{
				GBaseString<char> gBaseString<char>3;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, "buildings/" + this.BuildingFilePicker.File);
				try
				{
					sbyte* ptr3;
					if (gBaseString<char>3 != null)
					{
						ptr3 = gBaseString<char>3;
					}
					else
					{
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					GBaseString<char> gBaseString<char>4;
					GBaseString<char>* ptr4 = <Module>.GFileSystem.GetFileFullPath(ref <Module>.FS, &gBaseString<char>4, ptr3);
					NUnitEditor nUnitEditor2;
					try
					{
						uint num2 = (uint)(*(int*)ptr4);
						sbyte* value2;
						if (num2 != 0u)
						{
							value2 = num2;
						}
						else
						{
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						nUnitEditor2 = new NUnitEditor(this.ToolWindows, new string((sbyte*)value2), this.UnitEditorClipboard);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
						throw;
					}
					if (gBaseString<char>4 != null)
					{
						<Module>.free(gBaseString<char>4);
						gBaseString<char>4 = 0;
					}
					nUnitEditor2.PUnitChanged += new NUnitEditor.__Delegate_PUnitChanged(this.UnitEditor_PUnitChanged);
					nUnitEditor2.Show();
					<Module>.SaveOptions();
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
				if (gBaseString<char>3 != null)
				{
					<Module>.free(gBaseString<char>3);
				}
			}
		}

		private unsafe void menuItemEditEffect_Clicked(object sender, EventArgs e)
		{
			if (this.EditorMode == 12)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GEditorWorld.GetSelectedPEffect(this.World, &gBaseString<char>);
				string peffect_name;
				try
				{
					uint num = (uint)(*(int*)ptr);
					peffect_name = new string((sbyte*)((num == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num));
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
				NEffectEditor nEffectEditor = new NEffectEditor(this.ToolWindows, peffect_name, this.EffectEditorClipboard);
				nEffectEditor.PEffectChanged += new NEffectEditor.__Delegate_PEffectChanged(this.EffectEditor_PEffectChanged);
				nEffectEditor.Show();
				<Module>.SaveOptions();
			}
		}

		private void menuItemPathnodeWait_Clicked(object sender, EventArgs e)
		{
			if (this.EditorMode == 17)
			{
				byte b = (<Module>.GEditorWorld.GetSelectedPathNodeWait(this.World) == 0) ? 1 : 0;
				<Module>.GEditorWorld.SetSelectedPathNodeWait(this.World, b != 0);
			}
		}

		private void menuItemWaterfall_Clicked(object sender, EventArgs e)
		{
			if (this.EditorMode == 6)
			{
				byte b = (<Module>.GEditorWorld.GetSelectedWaterFall(this.World) == 0) ? 1 : 0;
				<Module>.GEditorWorld.SetSelectedWaterFall(this.World, b != 0);
			}
		}

		private void MinimapNeedsRefresh()
		{
			this.MinimapPanel.RefreshMap(true);
			this.MinimapPanel.RefreshUnits();
			this.RefreshMinimapCameraGizmo();
			this.MinimapPanel.DrawMap();
		}

		private unsafe void MinimapMovesCamera(float dx, float dz)
		{
			GCamera gCamera;
			<Module>.GWorld.GetCamera(this.World, ref gCamera);
			<Module>.GWorld.CameraSetPosition(this.World, gCamera + dx, *(ref gCamera + 4) - dz);
			this.MinimapViewportNeedsUpdate = true;
		}

		private void MinimapRotatesCamera(float alpha)
		{
			<Module>.GWorld.CameraRotate(this.World, alpha, 0f);
			this.MinimapViewportNeedsUpdate = true;
		}

		private unsafe void menuEditControlPaste_Click(object sender, EventArgs e)
		{
			PasteOptions pasteOptions = new PasteOptions();
			pasteOptions.PasteOptionFlags = this.LastPasteOptions;
			if (pasteOptions.ShowDialog() == DialogResult.OK)
			{
				this.LastPasteOptions = pasteOptions.PasteOptionFlags;
				Point mousePosition = Control.MousePosition;
				Point mousePosition2 = Control.MousePosition;
				int num = *(int*)this.IViewport + 56;
				GRay gRay;
				float num2;
				float num3;
				float num4;
				<Module>.GWorld.GetTarget(this.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), this.IViewport, ref gRay, mousePosition2.X, mousePosition.Y, *num), ref num2, ref num3, ref num4);
				<Module>.GEditorWorld.StartPaste(this.World, this.Clipboard, (int)((double)num2), (int)((double)num4), pasteOptions.PasteOptionFlags);
				this.DragMode = 4;
			}
			*(ref this.KeyTimes + 128) = 0L;
			*(ref this.KeyTimes + 136) = 0L;
			*(ref this.KeyTimes + 688) = 0L;
		}

		public void RefreshScriptEditorForm()
		{
			this.ScriptEditorFormInstance.EditorsChanged();
		}

		private void menuHelpContents_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, "Workshop.chm", HelpNavigator.TableOfContents);
		}

		private void menuHelpIndex_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, "Workshop.chm", HelpNavigator.Index);
		}

		private void menuHelpAbout_Click(object sender, EventArgs e)
		{
		}

		public unsafe void LogDebugMessage(GBaseString<char>* message)
		{
			try
			{
				uint num = (uint)(*(int*)message);
				sbyte* value;
				if (num != 0u)
				{
					value = num;
				}
				else
				{
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				this.LoggerTool.AddEcho(new string((sbyte*)value));
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)message);
				throw;
			}
			uint num2 = (uint)(*(int*)message);
			if (num2 != 0u)
			{
				<Module>.free(num2);
				*(int*)message = 0;
			}
		}
	}
}
