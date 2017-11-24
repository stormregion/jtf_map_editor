using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxScriptEntities : UserControl
	{
		private ListView EntityList;

		private ColumnHeader Dummy;

		private ColumnHeader EntityName;

		private ColumnHeader EntityColor;

		private ContextMenu ColorChooser;

		private MenuItem Red;

		private MenuItem Yellow;

		private MenuItem Green;

		private MenuItem Cyan;

		private MenuItem Blue;

		private MenuItem Magenta;

		private CheckBox ShowCheck;

		private GroupBox UnitGroupBox;

		private Label BehaviorLbl;

		private ListBox BehaviorList;

		private Label BraveryLbl;

		private ListBox BraveryList;

		private Label HelpCountLbl;

		private NumericUpDown MaxHelpNumeric;

		private ListBox FallbackList;

		private Label FallbackLbl;

		private ListBox HelpTypeList;

		private Label HelpTypeLbl;

		private Panel ObjectivePanel;

		private GroupBox ObjectiveGroup;

		private ListBox TargetList;

		private Button AddBtn;

		private Label ObjPathsLbl;

		private Label ObjLocLblb;

		private ListBox ObjPathList;

		private ListBox ObjLocList;

		private Label DescriptionLbl;

		private Label TargetLbl;

		private TextBox DescriptionEdit;

		private Button RemoveBtn;

		private NumericUpDown RewardNumeric;

		private Label RewardLbl;

		private GroupBox CurveGroupBox;

		private Button TimeCurveButton;

		private Button FOVCurveButton;

		private Button RollCurveButton;

		private Button CamBeginButton;

		private Button CamPauseButton;

		private Button CamPlayButton;

		private Button CamRewindButton;

		private Button CamForwardButton;

		private Label label1;

		private Label label2;

		private TextBox CurveDuration;

		private CheckBox CurveLoop;

		private TrackBar CurvePositionTrack;

		private TextBox CurveActPos;

		private ComboBox EyeCurveSelect;

		private ComboBox TargetCurveSelect;

		private Label label3;

		private Label label5;

		private Label label6;

		private TextBox CurveActPercent;

		private Label label7;

		private Label label4;

		private CheckBox TargetUsed;

		private CheckBox ShowViewport;

		private Label label8;

		private TextBox CurveDebugStart;

		private Label label9;

		private CheckBox CurveDebugShow;

		private CheckBox CurveMakeShots;

		private ComboBox ResolutionList;

		private Button AddTargetCurve;

		private Button RemoveTargetCurve;

		private Label LinkedTarget;

		private Label HelpRangeLbl;

		private TextBox HelpRangeEdit;

		private Label RangeLbl;

		private TextBox RangeEdit;

		private CheckBox VehiclesCheck;

		private CheckBox BuildingsCheck;

		private Container components;

		private unsafe GEditorWorld* propWorld;

		private int SCEType;

		private int SelectedItem;

		private int SelectedWorldIndex;

		private bool EditLabel;

		private string EditedLabel;

		private int[] Locations;

		private int[] Paths;

		private int[] Targets;

		private int CameraEyeCurveSelectedIdx;

		private int CameraTargetCurveSelectedIdx;

		private int CameraEyeCurveIndex;

		private int CameraTargetCurveIndex;

		private int CameraStatus;

		private float CameraPlayPosition;

		private ToolboxCameraViewport CamViewport;

		private ArrayList ToolWindows;

		private unsafe bool* CameraViewPortExist;

		private bool PropsRefreshing;

		public bool ForceRefresh;

		public int SelectedEntityIndex
		{
			get
			{
				return this.SelectedWorldIndex;
			}
		}

		public unsafe GEditorWorld* World
		{
			set
			{
				this.propWorld = value;
				if (value != null)
				{
					this.ShowCheck_CheckedChanged(null, null);
				}
			}
		}

		public unsafe ToolboxScriptEntities(int type)
		{
			this.InitializeComponent();
			this.ToolWindows = new ArrayList();
			bool* ptr = <Module>.@new(1u);
			bool* cameraViewPortExist;
			if (ptr != null)
			{
				*ptr = false;
				cameraViewPortExist = ptr;
			}
			else
			{
				cameraViewPortExist = null;
			}
			this.CameraViewPortExist = cameraViewPortExist;
			this.InitCameraCurveProps();
			this.SelectedItem = -1;
			this.SelectedWorldIndex = -1;
			this.SCEType = type;
			this.EditLabel = false;
			this.PropsRefreshing = false;
			this.propWorld = null;
			if (type == 0)
			{
				this.EntityList.Columns.Add("Looped", 50, HorizontalAlignment.Center);
			}
			else if (type == 2)
			{
				this.EntityList.Columns.Add("Eye", 50, HorizontalAlignment.Center);
			}
			else if (type == 4)
			{
				this.EntityList.Columns.Add("Active", 60, HorizontalAlignment.Center);
				this.EntityList.Columns.Add("AISleep", 60, HorizontalAlignment.Center);
			}
			else if (type == 1)
			{
				this.EntityList.Columns.Add("Effect range", 60, HorizontalAlignment.Center);
				this.EntityList.Columns.Add("Event source", 60, HorizontalAlignment.Center);
			}
			else if (type == 6)
			{
				this.EntityList.Columns.Remove(this.EntityColor);
				this.EntityList.Columns.Add("Inititial state", 60, HorizontalAlignment.Center);
				this.EntityList.Columns.Add("Type", 60, HorizontalAlignment.Center);
			}
			else if (type == 3)
			{
				this.EntityList.Columns.Add("Type", 60, HorizontalAlignment.Center);
				goto IL_2A1;
			}
			base.Controls.Remove(this.UnitGroupBox);
			base.Controls.Remove(this.BehaviorLbl);
			base.Controls.Remove(this.BehaviorList);
			base.Controls.Remove(this.RangeLbl);
			base.Controls.Remove(this.RangeEdit);
			base.Controls.Remove(this.BraveryLbl);
			base.Controls.Remove(this.BraveryList);
			base.Controls.Remove(this.HelpTypeLbl);
			base.Controls.Remove(this.HelpTypeList);
			base.Controls.Remove(this.FallbackLbl);
			base.Controls.Remove(this.FallbackList);
			base.Controls.Remove(this.HelpCountLbl);
			base.Controls.Remove(this.MaxHelpNumeric);
			Size size = base.Size;
			Size size2 = new Size(base.Size.Width, size.Height - this.UnitGroupBox.Height);
			base.Size = size2;
			if (type == 6)
			{
				Point location = this.ObjectivePanel.Location;
				Point location2 = this.ObjectivePanel.Location;
				int num = -8 - this.UnitGroupBox.Height;
				Point location3 = new Point(location2.X, location.Y + num);
				this.ObjectivePanel.Location = location3;
				goto IL_342;
			}
			IL_2A1:
			base.Controls.Remove(this.ObjectivePanel);
			Size size3 = base.Size;
			Size size4 = new Size(base.Size.Width, size3.Height - this.ObjectivePanel.Height);
			base.Size = size4;
			if (type == 2)
			{
				Point location4 = this.CurveGroupBox.Location;
				Point location5 = this.CurveGroupBox.Location;
				int num2 = -8 - this.UnitGroupBox.Height - this.ObjectivePanel.Height;
				Point location6 = new Point(location5.X, location4.Y + num2);
				this.CurveGroupBox.Location = location6;
				object[] items = new object[]
				{
					"848x480 (1x)",
					"1024x580",
					"1280x725",
					"1600x906",
					"1696x960 (2x)",
					"2048x1160",
					"2544x1440 (3x)",
					"3392x1920 (4x)"
				};
				this.ResolutionList.Items.AddRange(items);
				goto IL_443;
			}
			IL_342:
			base.Controls.Remove(this.CurveGroupBox);
			Size size5 = base.Size;
			Size size6 = new Size(base.Size.Width, size5.Height - this.CurveGroupBox.Height);
			base.Size = size6;
			IL_443:
			Application.Idle += new EventHandler(this.OnIdle);
		}

		private unsafe void OnIdle(object sender, EventArgs e)
		{
			this.ShowViewport.Checked = *this.CameraViewPortExist;
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
			this.EntityList = new ListView();
			this.Dummy = new ColumnHeader();
			this.EntityName = new ColumnHeader();
			this.EntityColor = new ColumnHeader();
			this.ColorChooser = new ContextMenu();
			this.Red = new MenuItem();
			this.Yellow = new MenuItem();
			this.Green = new MenuItem();
			this.Cyan = new MenuItem();
			this.Blue = new MenuItem();
			this.Magenta = new MenuItem();
			this.ShowCheck = new CheckBox();
			this.UnitGroupBox = new GroupBox();
			this.VehiclesCheck = new CheckBox();
			this.RangeLbl = new Label();
			this.RangeEdit = new TextBox();
			this.MaxHelpNumeric = new NumericUpDown();
			this.HelpCountLbl = new Label();
			this.FallbackList = new ListBox();
			this.FallbackLbl = new Label();
			this.HelpTypeList = new ListBox();
			this.HelpTypeLbl = new Label();
			this.BraveryList = new ListBox();
			this.BraveryLbl = new Label();
			this.HelpRangeLbl = new Label();
			this.HelpRangeEdit = new TextBox();
			this.BehaviorLbl = new Label();
			this.BehaviorList = new ListBox();
			this.ObjectivePanel = new Panel();
			this.ObjectiveGroup = new GroupBox();
			this.RewardLbl = new Label();
			this.RewardNumeric = new NumericUpDown();
			this.TargetLbl = new Label();
			this.RemoveBtn = new Button();
			this.TargetList = new ListBox();
			this.AddBtn = new Button();
			this.ObjPathsLbl = new Label();
			this.ObjLocLblb = new Label();
			this.ObjPathList = new ListBox();
			this.ObjLocList = new ListBox();
			this.DescriptionLbl = new Label();
			this.DescriptionEdit = new TextBox();
			this.CurveGroupBox = new GroupBox();
			this.LinkedTarget = new Label();
			this.RemoveTargetCurve = new Button();
			this.AddTargetCurve = new Button();
			this.ResolutionList = new ComboBox();
			this.CurveMakeShots = new CheckBox();
			this.CurveDebugShow = new CheckBox();
			this.label8 = new Label();
			this.CurveDebugStart = new TextBox();
			this.label9 = new Label();
			this.ShowViewport = new CheckBox();
			this.TargetUsed = new CheckBox();
			this.label7 = new Label();
			this.CurveActPercent = new TextBox();
			this.label6 = new Label();
			this.label5 = new Label();
			this.label4 = new Label();
			this.label3 = new Label();
			this.TargetCurveSelect = new ComboBox();
			this.EyeCurveSelect = new ComboBox();
			this.CurveActPos = new TextBox();
			this.CurvePositionTrack = new TrackBar();
			this.CurveLoop = new CheckBox();
			this.label2 = new Label();
			this.CamForwardButton = new Button();
			this.CamRewindButton = new Button();
			this.CamPlayButton = new Button();
			this.CamPauseButton = new Button();
			this.CamBeginButton = new Button();
			this.RollCurveButton = new Button();
			this.FOVCurveButton = new Button();
			this.TimeCurveButton = new Button();
			this.CurveDuration = new TextBox();
			this.label1 = new Label();
			this.BuildingsCheck = new CheckBox();
			this.UnitGroupBox.SuspendLayout();
			((ISupportInitialize)this.MaxHelpNumeric).BeginInit();
			this.ObjectivePanel.SuspendLayout();
			this.ObjectiveGroup.SuspendLayout();
			((ISupportInitialize)this.RewardNumeric).BeginInit();
			this.CurveGroupBox.SuspendLayout();
			((ISupportInitialize)this.CurvePositionTrack).BeginInit();
			base.SuspendLayout();
			ColumnHeader[] values = new ColumnHeader[]
			{
				this.Dummy,
				this.EntityName,
				this.EntityColor
			};
			this.EntityList.Columns.AddRange(values);
			this.EntityList.FullRowSelect = true;
			this.EntityList.GridLines = true;
			this.EntityList.HeaderStyle = ColumnHeaderStyle.None;
			this.EntityList.HideSelection = false;
			this.EntityList.LabelEdit = true;
			Point location = new Point(8, 8);
			this.EntityList.Location = location;
			this.EntityList.MultiSelect = false;
			this.EntityList.Name = "EntityList";
			Size size = new Size(240, 288);
			this.EntityList.Size = size;
			this.EntityList.Sorting = SortOrder.Ascending;
			this.EntityList.TabIndex = 0;
			this.EntityList.View = View.Details;
			this.EntityList.MouseUp += new MouseEventHandler(this.EntityList_MouseUp);
			this.EntityList.AfterLabelEdit += new LabelEditEventHandler(this.EntityList_AfterLabelEdit);
			this.EntityList.SelectedIndexChanged += new EventHandler(this.EntityList_SelectedIndexChanged);
			this.Dummy.Text = "Dummy";
			this.Dummy.Width = 0;
			this.EntityName.Text = "NameHeader";
			this.EntityName.Width = 216;
			this.EntityColor.Text = "ColorHeader";
			this.EntityColor.Width = 20;
			MenuItem[] items = new MenuItem[]
			{
				this.Red,
				this.Yellow,
				this.Green,
				this.Cyan,
				this.Blue,
				this.Magenta
			};
			this.ColorChooser.MenuItems.AddRange(items);
			this.Red.Index = 0;
			this.Red.OwnerDraw = true;
			this.Red.Text = "";
			this.Red.DrawItem += new DrawItemEventHandler(this.DrawColorSelector);
			this.Red.Click += new EventHandler(this.ColorSelected);
			this.Red.MeasureItem += new MeasureItemEventHandler(this.MeasureColorSelector);
			this.Yellow.Index = 1;
			this.Yellow.OwnerDraw = true;
			this.Yellow.Text = "";
			this.Yellow.DrawItem += new DrawItemEventHandler(this.DrawColorSelector);
			this.Yellow.Click += new EventHandler(this.ColorSelected);
			this.Yellow.MeasureItem += new MeasureItemEventHandler(this.MeasureColorSelector);
			this.Green.Index = 2;
			this.Green.OwnerDraw = true;
			this.Green.Text = "";
			this.Green.DrawItem += new DrawItemEventHandler(this.DrawColorSelector);
			this.Green.Click += new EventHandler(this.ColorSelected);
			this.Green.MeasureItem += new MeasureItemEventHandler(this.MeasureColorSelector);
			this.Cyan.Index = 3;
			this.Cyan.OwnerDraw = true;
			this.Cyan.Text = "";
			this.Cyan.DrawItem += new DrawItemEventHandler(this.DrawColorSelector);
			this.Cyan.Click += new EventHandler(this.ColorSelected);
			this.Cyan.MeasureItem += new MeasureItemEventHandler(this.MeasureColorSelector);
			this.Blue.Index = 4;
			this.Blue.OwnerDraw = true;
			this.Blue.Text = "";
			this.Blue.DrawItem += new DrawItemEventHandler(this.DrawColorSelector);
			this.Blue.Click += new EventHandler(this.ColorSelected);
			this.Blue.MeasureItem += new MeasureItemEventHandler(this.MeasureColorSelector);
			this.Magenta.Index = 5;
			this.Magenta.OwnerDraw = true;
			this.Magenta.Text = "";
			this.Magenta.DrawItem += new DrawItemEventHandler(this.DrawColorSelector);
			this.Magenta.Click += new EventHandler(this.ColorSelected);
			this.Magenta.MeasureItem += new MeasureItemEventHandler(this.MeasureColorSelector);
			Point location2 = new Point(8, 304);
			this.ShowCheck.Location = location2;
			this.ShowCheck.Name = "ShowCheck";
			Size size2 = new Size(104, 16);
			this.ShowCheck.Size = size2;
			this.ShowCheck.TabIndex = 1;
			this.ShowCheck.Text = "Show Always";
			this.ShowCheck.CheckedChanged += new EventHandler(this.ShowCheck_CheckedChanged);
			this.UnitGroupBox.Controls.Add(this.BuildingsCheck);
			this.UnitGroupBox.Controls.Add(this.VehiclesCheck);
			this.UnitGroupBox.Controls.Add(this.RangeLbl);
			this.UnitGroupBox.Controls.Add(this.RangeEdit);
			this.UnitGroupBox.Controls.Add(this.MaxHelpNumeric);
			this.UnitGroupBox.Controls.Add(this.HelpCountLbl);
			this.UnitGroupBox.Controls.Add(this.FallbackList);
			this.UnitGroupBox.Controls.Add(this.FallbackLbl);
			this.UnitGroupBox.Controls.Add(this.HelpTypeList);
			this.UnitGroupBox.Controls.Add(this.HelpTypeLbl);
			this.UnitGroupBox.Controls.Add(this.BraveryList);
			this.UnitGroupBox.Controls.Add(this.BraveryLbl);
			this.UnitGroupBox.Controls.Add(this.HelpRangeLbl);
			this.UnitGroupBox.Controls.Add(this.HelpRangeEdit);
			this.UnitGroupBox.Controls.Add(this.BehaviorLbl);
			this.UnitGroupBox.Controls.Add(this.BehaviorList);
			Point location3 = new Point(8, 328);
			this.UnitGroupBox.Location = location3;
			this.UnitGroupBox.Name = "UnitGroupBox";
			Size size3 = new Size(240, 368);
			this.UnitGroupBox.Size = size3;
			this.UnitGroupBox.TabIndex = 4;
			this.UnitGroupBox.TabStop = false;
			this.UnitGroupBox.Text = "Unit group props";
			Point location4 = new Point(8, 312);
			this.VehiclesCheck.Location = location4;
			this.VehiclesCheck.Name = "VehiclesCheck";
			Size size4 = new Size(224, 24);
			this.VehiclesCheck.Size = size4;
			this.VehiclesCheck.TabIndex = 19;
			this.VehiclesCheck.Text = "Advanced vehicle usage";
			this.VehiclesCheck.CheckedChanged += new EventHandler(this.VehiclesCheck_CheckedChanged);
			Point location5 = new Point(128, 200);
			this.RangeLbl.Location = location5;
			this.RangeLbl.Name = "RangeLbl";
			this.RangeLbl.TabIndex = 18;
			this.RangeLbl.Text = "Group range";
			Point location6 = new Point(128, 224);
			this.RangeEdit.Location = location6;
			this.RangeEdit.Name = "RangeEdit";
			this.RangeEdit.TabIndex = 17;
			this.RangeEdit.Text = "";
			this.RangeEdit.Validated += new EventHandler(this.RangeEdit_Validated);
			this.RangeEdit.TextChanged += new EventHandler(this.RangeEdit_TextChanged);
			Point location7 = new Point(8, 280);
			this.MaxHelpNumeric.Location = location7;
			decimal maximum = new decimal(new int[]
			{
				10,
				0,
				0,
				0
			});
			this.MaxHelpNumeric.Maximum = maximum;
			this.MaxHelpNumeric.Name = "MaxHelpNumeric";
			Size size5 = new Size(104, 20);
			this.MaxHelpNumeric.Size = size5;
			this.MaxHelpNumeric.TabIndex = 16;
			this.MaxHelpNumeric.ValueChanged += new EventHandler(this.MaxHelpNumeric_ValueChanged);
			Point location8 = new Point(8, 256);
			this.HelpCountLbl.Location = location8;
			this.HelpCountLbl.Name = "HelpCountLbl";
			this.HelpCountLbl.TabIndex = 15;
			this.HelpCountLbl.Text = "Max. help count";
			Point location9 = new Point(128, 136);
			this.FallbackList.Location = location9;
			this.FallbackList.Name = "FallbackList";
			Size size6 = new Size(104, 56);
			this.FallbackList.Size = size6;
			this.FallbackList.TabIndex = 13;
			this.FallbackList.SelectedIndexChanged += new EventHandler(this.FallbackList_SelectedIndexChanged);
			Point location10 = new Point(128, 112);
			this.FallbackLbl.Location = location10;
			this.FallbackLbl.Name = "FallbackLbl";
			Size size7 = new Size(96, 23);
			this.FallbackLbl.Size = size7;
			this.FallbackLbl.TabIndex = 12;
			this.FallbackLbl.Text = "Fallback location";
			object[] items2 = new object[]
			{
				"Freelance",
				"Support",
				"Artillery",
				"Light backup",
				"Heavy backup",
				"Air support",
				"Recon"
			};
			this.HelpTypeList.Items.AddRange(items2);
			Point location11 = new Point(8, 152);
			this.HelpTypeList.Location = location11;
			this.HelpTypeList.Name = "HelpTypeList";
			this.HelpTypeList.SelectionMode = SelectionMode.MultiSimple;
			Size size8 = new Size(104, 95);
			this.HelpTypeList.Size = size8;
			this.HelpTypeList.TabIndex = 11;
			this.HelpTypeList.SelectedIndexChanged += new EventHandler(this.HelpTypeList_SelectedIndexChanged);
			Point location12 = new Point(8, 128);
			this.HelpTypeLbl.Location = location12;
			this.HelpTypeLbl.Name = "HelpTypeLbl";
			Size size9 = new Size(88, 23);
			this.HelpTypeLbl.Size = size9;
			this.HelpTypeLbl.TabIndex = 10;
			this.HelpTypeLbl.Text = "AvailableHelp";
			object[] items3 = new object[]
			{
				"Coward",
				"Normal",
				"Brave",
				"Fanatic"
			};
			this.BraveryList.Items.AddRange(items3);
			Point location13 = new Point(128, 48);
			this.BraveryList.Location = location13;
			this.BraveryList.Name = "BraveryList";
			Size size10 = new Size(104, 56);
			this.BraveryList.Size = size10;
			this.BraveryList.TabIndex = 9;
			this.BraveryList.SelectedIndexChanged += new EventHandler(this.BraveryList_SelectedIndexChanged);
			Point location14 = new Point(128, 24);
			this.BraveryLbl.Location = location14;
			this.BraveryLbl.Name = "BraveryLbl";
			Size size11 = new Size(88, 23);
			this.BraveryLbl.Size = size11;
			this.BraveryLbl.TabIndex = 8;
			this.BraveryLbl.Text = "Bravery";
			Point location15 = new Point(128, 256);
			this.HelpRangeLbl.Location = location15;
			this.HelpRangeLbl.Name = "HelpRangeLbl";
			this.HelpRangeLbl.TabIndex = 7;
			this.HelpRangeLbl.Text = "Group help range";
			Point location16 = new Point(128, 280);
			this.HelpRangeEdit.Location = location16;
			this.HelpRangeEdit.Name = "HelpRangeEdit";
			this.HelpRangeEdit.TabIndex = 6;
			this.HelpRangeEdit.Text = "";
			this.HelpRangeEdit.Validated += new EventHandler(this.HelpRangeEdit_Validated);
			this.HelpRangeEdit.TextChanged += new EventHandler(this.HelpRangeEdit_TextChanged);
			Point location17 = new Point(8, 24);
			this.BehaviorLbl.Location = location17;
			this.BehaviorLbl.Name = "BehaviorLbl";
			this.BehaviorLbl.TabIndex = 5;
			this.BehaviorLbl.Text = "Group behavior";
			object[] items4 = new object[]
			{
				"Defend",
				"Scout",
				"Freelance",
				"Support",
				"Dumb"
			};
			this.BehaviorList.Items.AddRange(items4);
			Point location18 = new Point(8, 48);
			this.BehaviorList.Location = location18;
			this.BehaviorList.Name = "BehaviorList";
			Size size12 = new Size(104, 69);
			this.BehaviorList.Size = size12;
			this.BehaviorList.TabIndex = 4;
			this.BehaviorList.SelectedIndexChanged += new EventHandler(this.BehaviorList_SelectedIndexChanged);
			this.ObjectivePanel.Controls.Add(this.ObjectiveGroup);
			Point location19 = new Point(8, 712);
			this.ObjectivePanel.Location = location19;
			this.ObjectivePanel.Name = "ObjectivePanel";
			Size size13 = new Size(240, 400);
			this.ObjectivePanel.Size = size13;
			this.ObjectivePanel.TabIndex = 5;
			this.ObjectiveGroup.Controls.Add(this.RewardLbl);
			this.ObjectiveGroup.Controls.Add(this.RewardNumeric);
			this.ObjectiveGroup.Controls.Add(this.TargetLbl);
			this.ObjectiveGroup.Controls.Add(this.RemoveBtn);
			this.ObjectiveGroup.Controls.Add(this.TargetList);
			this.ObjectiveGroup.Controls.Add(this.AddBtn);
			this.ObjectiveGroup.Controls.Add(this.ObjPathsLbl);
			this.ObjectiveGroup.Controls.Add(this.ObjLocLblb);
			this.ObjectiveGroup.Controls.Add(this.ObjPathList);
			this.ObjectiveGroup.Controls.Add(this.ObjLocList);
			this.ObjectiveGroup.Controls.Add(this.DescriptionLbl);
			this.ObjectiveGroup.Controls.Add(this.DescriptionEdit);
			Point location20 = new Point(0, 0);
			this.ObjectiveGroup.Location = location20;
			this.ObjectiveGroup.Name = "ObjectiveGroup";
			Size size14 = new Size(240, 400);
			this.ObjectiveGroup.Size = size14;
			this.ObjectiveGroup.TabIndex = 6;
			this.ObjectiveGroup.TabStop = false;
			this.ObjectiveGroup.Text = "Objective props";
			Point location21 = new Point(8, 120);
			this.RewardLbl.Location = location21;
			this.RewardLbl.Name = "RewardLbl";
			Size size15 = new Size(48, 23);
			this.RewardLbl.Size = size15;
			this.RewardLbl.TabIndex = 11;
			this.RewardLbl.Text = "Reward:";
			decimal increment = new decimal(new int[]
			{
				100,
				0,
				0,
				0
			});
			this.RewardNumeric.Increment = increment;
			Point location22 = new Point(56, 120);
			this.RewardNumeric.Location = location22;
			decimal maximum2 = new decimal(new int[]
			{
				10000000,
				0,
				0,
				0
			});
			this.RewardNumeric.Maximum = maximum2;
			this.RewardNumeric.Name = "RewardNumeric";
			Size size16 = new Size(176, 20);
			this.RewardNumeric.Size = size16;
			this.RewardNumeric.TabIndex = 10;
			this.RewardNumeric.ValueChanged += new EventHandler(this.RewardNumeric_ValueChanged);
			Point location23 = new Point(8, 304);
			this.TargetLbl.Location = location23;
			this.TargetLbl.Name = "TargetLbl";
			this.TargetLbl.TabIndex = 9;
			this.TargetLbl.Text = "Targets";
			Point location24 = new Point(8, 272);
			this.RemoveBtn.Location = location24;
			this.RemoveBtn.Name = "RemoveBtn";
			Size size17 = new Size(224, 23);
			this.RemoveBtn.Size = size17;
			this.RemoveBtn.TabIndex = 8;
			this.RemoveBtn.Text = "Remove";
			this.RemoveBtn.Click += new EventHandler(this.RemoveBtn_Click);
			Point location25 = new Point(8, 328);
			this.TargetList.Location = location25;
			this.TargetList.Name = "TargetList";
			Size size18 = new Size(224, 56);
			this.TargetList.Size = size18;
			this.TargetList.TabIndex = 7;
			Point location26 = new Point(8, 248);
			this.AddBtn.Location = location26;
			this.AddBtn.Name = "AddBtn";
			Size size19 = new Size(224, 23);
			this.AddBtn.Size = size19;
			this.AddBtn.TabIndex = 6;
			this.AddBtn.Text = "Add";
			this.AddBtn.Click += new EventHandler(this.AddBtn_Click);
			Point location27 = new Point(128, 152);
			this.ObjPathsLbl.Location = location27;
			this.ObjPathsLbl.Name = "ObjPathsLbl";
			this.ObjPathsLbl.TabIndex = 5;
			this.ObjPathsLbl.Text = "Paths";
			Point location28 = new Point(8, 152);
			this.ObjLocLblb.Location = location28;
			this.ObjLocLblb.Name = "ObjLocLblb";
			this.ObjLocLblb.TabIndex = 4;
			this.ObjLocLblb.Text = "Locations";
			Point location29 = new Point(128, 176);
			this.ObjPathList.Location = location29;
			this.ObjPathList.Name = "ObjPathList";
			Size size20 = new Size(104, 69);
			this.ObjPathList.Size = size20;
			this.ObjPathList.TabIndex = 3;
			this.ObjPathList.SelectedIndexChanged += new EventHandler(this.ObjPathList_SelectedIndexChanged);
			Point location30 = new Point(8, 176);
			this.ObjLocList.Location = location30;
			this.ObjLocList.Name = "ObjLocList";
			Size size21 = new Size(104, 69);
			this.ObjLocList.Size = size21;
			this.ObjLocList.TabIndex = 2;
			this.ObjLocList.SelectedIndexChanged += new EventHandler(this.ObjLocList_SelectedIndexChanged);
			Point location31 = new Point(8, 24);
			this.DescriptionLbl.Location = location31;
			this.DescriptionLbl.Name = "DescriptionLbl";
			this.DescriptionLbl.TabIndex = 1;
			this.DescriptionLbl.Text = "Description";
			Point location32 = new Point(8, 48);
			this.DescriptionEdit.Location = location32;
			this.DescriptionEdit.Multiline = true;
			this.DescriptionEdit.Name = "DescriptionEdit";
			Size size22 = new Size(224, 64);
			this.DescriptionEdit.Size = size22;
			this.DescriptionEdit.TabIndex = 0;
			this.DescriptionEdit.Text = "";
			this.DescriptionEdit.Validated += new EventHandler(this.DescriptionEdit_Validated);
			this.DescriptionEdit.TextChanged += new EventHandler(this.DescriptionEdit_TextChanged);
			this.CurveGroupBox.Controls.Add(this.LinkedTarget);
			this.CurveGroupBox.Controls.Add(this.RemoveTargetCurve);
			this.CurveGroupBox.Controls.Add(this.AddTargetCurve);
			this.CurveGroupBox.Controls.Add(this.ResolutionList);
			this.CurveGroupBox.Controls.Add(this.CurveMakeShots);
			this.CurveGroupBox.Controls.Add(this.CurveDebugShow);
			this.CurveGroupBox.Controls.Add(this.label8);
			this.CurveGroupBox.Controls.Add(this.CurveDebugStart);
			this.CurveGroupBox.Controls.Add(this.label9);
			this.CurveGroupBox.Controls.Add(this.ShowViewport);
			this.CurveGroupBox.Controls.Add(this.TargetUsed);
			this.CurveGroupBox.Controls.Add(this.label7);
			this.CurveGroupBox.Controls.Add(this.CurveActPercent);
			this.CurveGroupBox.Controls.Add(this.label6);
			this.CurveGroupBox.Controls.Add(this.label5);
			this.CurveGroupBox.Controls.Add(this.label4);
			this.CurveGroupBox.Controls.Add(this.label3);
			this.CurveGroupBox.Controls.Add(this.TargetCurveSelect);
			this.CurveGroupBox.Controls.Add(this.EyeCurveSelect);
			this.CurveGroupBox.Controls.Add(this.CurveActPos);
			this.CurveGroupBox.Controls.Add(this.CurvePositionTrack);
			this.CurveGroupBox.Controls.Add(this.CurveLoop);
			this.CurveGroupBox.Controls.Add(this.label2);
			this.CurveGroupBox.Controls.Add(this.CamForwardButton);
			this.CurveGroupBox.Controls.Add(this.CamRewindButton);
			this.CurveGroupBox.Controls.Add(this.CamPlayButton);
			this.CurveGroupBox.Controls.Add(this.CamPauseButton);
			this.CurveGroupBox.Controls.Add(this.CamBeginButton);
			this.CurveGroupBox.Controls.Add(this.RollCurveButton);
			this.CurveGroupBox.Controls.Add(this.FOVCurveButton);
			this.CurveGroupBox.Controls.Add(this.TimeCurveButton);
			this.CurveGroupBox.Controls.Add(this.CurveDuration);
			this.CurveGroupBox.Controls.Add(this.label1);
			Point location33 = new Point(8, 1128);
			this.CurveGroupBox.Location = location33;
			this.CurveGroupBox.Name = "CurveGroupBox";
			Size size23 = new Size(240, 320);
			this.CurveGroupBox.Size = size23;
			this.CurveGroupBox.TabIndex = 17;
			this.CurveGroupBox.TabStop = false;
			this.CurveGroupBox.Text = "Curve group props";
			Point location34 = new Point(21, 68);
			this.LinkedTarget.Location = location34;
			this.LinkedTarget.Name = "LinkedTarget";
			Size size24 = new Size(40, 16);
			this.LinkedTarget.Size = size24;
			this.LinkedTarget.TabIndex = 45;
			this.LinkedTarget.Text = "Linked";
			this.LinkedTarget.Visible = false;
			Point location35 = new Point(136, 64);
			this.RemoveTargetCurve.Location = location35;
			this.RemoveTargetCurve.Name = "RemoveTargetCurve";
			Size size25 = new Size(88, 23);
			this.RemoveTargetCurve.Size = size25;
			this.RemoveTargetCurve.TabIndex = 44;
			this.RemoveTargetCurve.Text = "RemoveTarget";
			this.RemoveTargetCurve.Click += new EventHandler(this.RemoveTargetCurve_Click);
			Point location36 = new Point(64, 64);
			this.AddTargetCurve.Location = location36;
			this.AddTargetCurve.Name = "AddTargetCurve";
			Size size26 = new Size(72, 23);
			this.AddTargetCurve.Size = size26;
			this.AddTargetCurve.TabIndex = 43;
			this.AddTargetCurve.Text = "AddTarget";
			this.AddTargetCurve.Click += new EventHandler(this.AddTargetCurve_Click);
			this.ResolutionList.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location37 = new Point(96, 280);
			this.ResolutionList.Location = location37;
			this.ResolutionList.Name = "ResolutionList";
			Size size27 = new Size(121, 21);
			this.ResolutionList.Size = size27;
			this.ResolutionList.TabIndex = 42;
			Point location38 = new Point(145, 248);
			this.CurveMakeShots.Location = location38;
			this.CurveMakeShots.Name = "CurveMakeShots";
			Size size28 = new Size(88, 24);
			this.CurveMakeShots.Size = size28;
			this.CurveMakeShots.TabIndex = 41;
			this.CurveMakeShots.Text = "MakeShots";
			Point location39 = new Point(145, 232);
			this.CurveDebugShow.Location = location39;
			this.CurveDebugShow.Name = "CurveDebugShow";
			Size size29 = new Size(88, 24);
			this.CurveDebugShow.Size = size29;
			this.CurveDebugShow.TabIndex = 40;
			this.CurveDebugShow.Text = "DebugShow";
			Point location40 = new Point(116, 250);
			this.label8.Location = location40;
			this.label8.Name = "label8";
			Size size30 = new Size(28, 16);
			this.label8.Size = size30;
			this.label8.TabIndex = 39;
			this.label8.Text = "sec";
			Point location41 = new Point(69, 248);
			this.CurveDebugStart.Location = location41;
			this.CurveDebugStart.Name = "CurveDebugStart";
			Size size31 = new Size(47, 20);
			this.CurveDebugStart.Size = size31;
			this.CurveDebugStart.TabIndex = 38;
			this.CurveDebugStart.Text = "";
			this.CurveDebugStart.Validated += new EventHandler(this.CurveDebugStart_Validated);
			this.CurveDebugStart.TextChanged += new EventHandler(this.CurveDebugStart_TextChanged);
			Point location42 = new Point(7, 250);
			this.label9.Location = location42;
			this.label9.Name = "label9";
			Size size32 = new Size(72, 16);
			this.label9.Size = size32;
			this.label9.TabIndex = 37;
			this.label9.Text = "DebugStart:";
			Point location43 = new Point(180, 176);
			this.ShowViewport.Location = location43;
			this.ShowViewport.Name = "ShowViewport";
			Size size33 = new Size(56, 24);
			this.ShowViewport.Size = size33;
			this.ShowViewport.TabIndex = 36;
			this.ShowViewport.Text = "show";
			this.ShowViewport.CheckedChanged += new EventHandler(this.ShowViewport_CheckedChanged);
			Point location44 = new Point(46, 39);
			this.TargetUsed.Location = location44;
			this.TargetUsed.Name = "TargetUsed";
			Size size34 = new Size(16, 24);
			this.TargetUsed.Size = size34;
			this.TargetUsed.TabIndex = 35;
			this.TargetUsed.Text = "loop";
			this.TargetUsed.CheckedChanged += new EventHandler(this.TargetUsed_CheckedChanged);
			Point location45 = new Point(162, 154);
			this.label7.Location = location45;
			this.label7.Name = "label7";
			Size size35 = new Size(16, 16);
			this.label7.Size = size35;
			this.label7.TabIndex = 34;
			this.label7.Text = "%";
			this.CurveActPercent.Cursor = Cursors.Default;
			this.CurveActPercent.Enabled = false;
			Point location46 = new Point(128, 152);
			this.CurveActPercent.Location = location46;
			this.CurveActPercent.Name = "CurveActPercent";
			this.CurveActPercent.ReadOnly = true;
			Size size36 = new Size(34, 20);
			this.CurveActPercent.Size = size36;
			this.CurveActPercent.TabIndex = 33;
			this.CurveActPercent.Text = "";
			Point location47 = new Point(104, 154);
			this.label6.Location = location47;
			this.label6.Name = "label6";
			Size size37 = new Size(28, 16);
			this.label6.Size = size37;
			this.label6.TabIndex = 32;
			this.label6.Text = "sec";
			Point location48 = new Point(8, 154);
			this.label5.Location = location48;
			this.label5.Name = "label5";
			Size size38 = new Size(48, 16);
			this.label5.Size = size38;
			this.label5.TabIndex = 31;
			this.label5.Text = "Position:";
			Point location49 = new Point(6, 43);
			this.label4.Location = location49;
			this.label4.Name = "label4";
			Size size39 = new Size(48, 16);
			this.label4.Size = size39;
			this.label4.TabIndex = 30;
			this.label4.Text = "Target:";
			Point location50 = new Point(32, 19);
			this.label3.Location = location50;
			this.label3.Name = "label3";
			Size size40 = new Size(32, 16);
			this.label3.Size = size40;
			this.label3.TabIndex = 29;
			this.label3.Text = "Eye:";
			this.TargetCurveSelect.AllowDrop = true;
			this.TargetCurveSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location51 = new Point(64, 40);
			this.TargetCurveSelect.Location = location51;
			this.TargetCurveSelect.MaxDropDownItems = 16;
			this.TargetCurveSelect.Name = "TargetCurveSelect";
			Size size41 = new Size(160, 21);
			this.TargetCurveSelect.Size = size41;
			this.TargetCurveSelect.TabIndex = 28;
			this.TargetCurveSelect.SelectedIndexChanged += new EventHandler(this.TargetCurveSelect_SelectedIndexChanged);
			this.EyeCurveSelect.AllowDrop = true;
			this.EyeCurveSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			Point location52 = new Point(64, 16);
			this.EyeCurveSelect.Location = location52;
			this.EyeCurveSelect.MaxDropDownItems = 16;
			this.EyeCurveSelect.Name = "EyeCurveSelect";
			Size size42 = new Size(160, 21);
			this.EyeCurveSelect.Size = size42;
			this.EyeCurveSelect.TabIndex = 27;
			this.EyeCurveSelect.SelectedIndexChanged += new EventHandler(this.EyeCurveSelect_SelectedIndexChanged);
			this.CurveActPos.Cursor = Cursors.Default;
			this.CurveActPos.Enabled = false;
			Point location53 = new Point(56, 152);
			this.CurveActPos.Location = location53;
			this.CurveActPos.Name = "CurveActPos";
			this.CurveActPos.ReadOnly = true;
			Size size43 = new Size(48, 20);
			this.CurveActPos.Size = size43;
			this.CurveActPos.TabIndex = 26;
			this.CurveActPos.Text = "";
			this.CurvePositionTrack.LargeChange = 100;
			Point location54 = new Point(8, 208);
			this.CurvePositionTrack.Location = location54;
			this.CurvePositionTrack.Maximum = 10000;
			this.CurvePositionTrack.Name = "CurvePositionTrack";
			Size size44 = new Size(224, 45);
			this.CurvePositionTrack.Size = size44;
			this.CurvePositionTrack.TabIndex = 25;
			this.CurvePositionTrack.TickStyle = TickStyle.None;
			this.CurvePositionTrack.Scroll += new EventHandler(this.CurvePositionTrack_Scroll);
			this.CurveLoop.Checked = true;
			this.CurveLoop.CheckState = CheckState.Checked;
			Point location55 = new Point(180, 152);
			this.CurveLoop.Location = location55;
			this.CurveLoop.Name = "CurveLoop";
			Size size45 = new Size(48, 24);
			this.CurveLoop.Size = size45;
			this.CurveLoop.TabIndex = 24;
			this.CurveLoop.Text = "loop";
			Point location56 = new Point(104, 130);
			this.label2.Location = location56;
			this.label2.Name = "label2";
			Size size46 = new Size(28, 16);
			this.label2.Size = size46;
			this.label2.TabIndex = 23;
			this.label2.Text = "sec";
			Point location57 = new Point(136, 176);
			this.CamForwardButton.Location = location57;
			this.CamForwardButton.Name = "CamForwardButton";
			Size size47 = new Size(32, 23);
			this.CamForwardButton.Size = size47;
			this.CamForwardButton.TabIndex = 22;
			this.CamForwardButton.Text = ">>";
			this.CamForwardButton.Click += new EventHandler(this.CamForwardButton_Click);
			Point location58 = new Point(40, 176);
			this.CamRewindButton.Location = location58;
			this.CamRewindButton.Name = "CamRewindButton";
			Size size48 = new Size(32, 23);
			this.CamRewindButton.Size = size48;
			this.CamRewindButton.TabIndex = 21;
			this.CamRewindButton.Text = "<<";
			this.CamRewindButton.Click += new EventHandler(this.CamRewindButton_Click);
			Point location59 = new Point(104, 176);
			this.CamPlayButton.Location = location59;
			this.CamPlayButton.Name = "CamPlayButton";
			Size size49 = new Size(32, 23);
			this.CamPlayButton.Size = size49;
			this.CamPlayButton.TabIndex = 20;
			this.CamPlayButton.Text = ">";
			this.CamPlayButton.Click += new EventHandler(this.CamPlayButton_Click);
			Point location60 = new Point(72, 176);
			this.CamPauseButton.Location = location60;
			this.CamPauseButton.Name = "CamPauseButton";
			Size size50 = new Size(32, 23);
			this.CamPauseButton.Size = size50;
			this.CamPauseButton.TabIndex = 19;
			this.CamPauseButton.Text = "| |";
			this.CamPauseButton.Click += new EventHandler(this.CamPauseButton_Click);
			Point location61 = new Point(8, 176);
			this.CamBeginButton.Location = location61;
			this.CamBeginButton.Name = "CamBeginButton";
			Size size51 = new Size(32, 23);
			this.CamBeginButton.Size = size51;
			this.CamBeginButton.TabIndex = 18;
			this.CamBeginButton.Text = "|<<";
			this.CamBeginButton.Click += new EventHandler(this.CamBeginButton_Click);
			Point location62 = new Point(152, 96);
			this.RollCurveButton.Location = location62;
			this.RollCurveButton.Name = "RollCurveButton";
			Size size52 = new Size(72, 23);
			this.RollCurveButton.Size = size52;
			this.RollCurveButton.TabIndex = 14;
			this.RollCurveButton.Text = "Roll";
			this.RollCurveButton.Click += new EventHandler(this.RollCurveButton_Click);
			Point location63 = new Point(80, 96);
			this.FOVCurveButton.Location = location63;
			this.FOVCurveButton.Name = "FOVCurveButton";
			Size size53 = new Size(72, 23);
			this.FOVCurveButton.Size = size53;
			this.FOVCurveButton.TabIndex = 13;
			this.FOVCurveButton.Text = "FOV";
			this.FOVCurveButton.Click += new EventHandler(this.FOVCurveButton_Click);
			Point location64 = new Point(8, 96);
			this.TimeCurveButton.Location = location64;
			this.TimeCurveButton.Name = "TimeCurveButton";
			Size size54 = new Size(72, 23);
			this.TimeCurveButton.Size = size54;
			this.TimeCurveButton.TabIndex = 12;
			this.TimeCurveButton.Text = "Time%";
			this.TimeCurveButton.Click += new EventHandler(this.TimeCurveButton_Click);
			Point location65 = new Point(57, 128);
			this.CurveDuration.Location = location65;
			this.CurveDuration.Name = "CurveDuration";
			Size size55 = new Size(47, 20);
			this.CurveDuration.Size = size55;
			this.CurveDuration.TabIndex = 17;
			this.CurveDuration.Text = "";
			this.CurveDuration.Validated += new EventHandler(this.CurveDuration_Validated);
			this.CurveDuration.TextChanged += new EventHandler(this.CurveDuration_TextChanged);
			Point location66 = new Point(8, 130);
			this.label1.Location = location66;
			this.label1.Name = "label1";
			Size size56 = new Size(56, 16);
			this.label1.Size = size56;
			this.label1.TabIndex = 12;
			this.label1.Text = "Duration:";
			Point location67 = new Point(8, 336);
			this.BuildingsCheck.Location = location67;
			this.BuildingsCheck.Name = "BuildingsCheck";
			Size size57 = new Size(224, 24);
			this.BuildingsCheck.Size = size57;
			this.BuildingsCheck.TabIndex = 20;
			this.BuildingsCheck.Text = "Advanced building usage";
			this.BuildingsCheck.CheckedChanged += new EventHandler(this.BuildingsCheck_CheckedChanged);
			base.Controls.Add(this.ObjectivePanel);
			base.Controls.Add(this.UnitGroupBox);
			base.Controls.Add(this.ShowCheck);
			base.Controls.Add(this.EntityList);
			base.Controls.Add(this.CurveGroupBox);
			base.Name = "ToolboxScriptEntities";
			Size size58 = new Size(256, 1456);
			base.Size = size58;
			base.Paint += new PaintEventHandler(this.ToolboxScriptEntities_Paint);
			this.UnitGroupBox.ResumeLayout(false);
			((ISupportInitialize)this.MaxHelpNumeric).EndInit();
			this.ObjectivePanel.ResumeLayout(false);
			this.ObjectiveGroup.ResumeLayout(false);
			((ISupportInitialize)this.RewardNumeric).EndInit();
			this.CurveGroupBox.ResumeLayout(false);
			((ISupportInitialize)this.CurvePositionTrack).EndInit();
			base.ResumeLayout(false);
		}

		private void SelectItem(ListViewItem lvi)
		{
			Color backColor = Color.FromKnownColor(KnownColor.Highlight);
			lvi.SubItems[1].BackColor = backColor;
			Color foreColor = Color.FromKnownColor(KnownColor.HighlightText);
			lvi.SubItems[1].ForeColor = foreColor;
			if (this.SCEType == 0)
			{
				Color backColor2 = Color.FromKnownColor(KnownColor.Highlight);
				lvi.SubItems[3].BackColor = backColor2;
				Color foreColor2 = Color.FromKnownColor(KnownColor.HighlightText);
				lvi.SubItems[3].ForeColor = foreColor2;
			}
		}

		private void DeselectItem(ListViewItem lvi)
		{
			Color backColor = Color.FromKnownColor(KnownColor.Window);
			lvi.SubItems[1].BackColor = backColor;
			Color foreColor = Color.FromKnownColor(KnownColor.WindowText);
			lvi.SubItems[1].ForeColor = foreColor;
			if (this.SCEType == 0)
			{
				Color backColor2 = Color.FromKnownColor(KnownColor.Window);
				lvi.SubItems[3].BackColor = backColor2;
				Color foreColor2 = Color.FromKnownColor(KnownColor.WindowText);
				lvi.SubItems[3].ForeColor = foreColor2;
			}
		}

		private unsafe void RefreshScriptEntityProps(int idx)
		{
			if (this.propWorld != null)
			{
				int sCEType = this.SCEType;
				if (sCEType == 3 || sCEType == 6)
				{
					if (sCEType == 3)
					{
						if (idx < 0)
						{
							this.PropsRefreshing = true;
							this.BehaviorList.SelectedIndex = -1;
							this.BraveryList.SelectedIndex = -1;
							this.FallbackList.SelectedIndex = -1;
							int num = 0;
							if (0 < this.HelpTypeList.Items.Count)
							{
								do
								{
									this.HelpTypeList.SetSelected(num, false);
									num++;
								}
								while (num < this.HelpTypeList.Items.Count);
							}
							this.RangeEdit.Text = "";
							this.HelpRangeEdit.Text = "";
							this.MaxHelpNumeric.Text = "";
							this.VehiclesCheck.Checked = false;
							this.BuildingsCheck.Checked = false;
							this.PropsRefreshing = false;
							this.BehaviorList.Enabled = false;
							this.BraveryList.Enabled = false;
							this.FallbackList.Enabled = false;
							this.HelpTypeList.Enabled = false;
							this.MaxHelpNumeric.Enabled = false;
							this.RangeEdit.Enabled = false;
							this.HelpRangeEdit.Enabled = false;
							this.VehiclesCheck.Enabled = false;
							this.BuildingsCheck.Enabled = false;
						}
						else
						{
							this.BehaviorList.Enabled = true;
							this.BraveryList.Enabled = true;
							this.FallbackList.Enabled = true;
							this.HelpTypeList.Enabled = true;
							this.MaxHelpNumeric.Enabled = true;
							this.RangeEdit.Enabled = true;
							this.HelpRangeEdit.Enabled = true;
							this.VehiclesCheck.Enabled = true;
							this.BuildingsCheck.Enabled = true;
							GAIGroupProps selectedIndex;
							<Module>.GEditorWorld.GetAIGroupProps(this.propWorld, &selectedIndex, idx);
							this.PropsRefreshing = true;
							this.BehaviorList.SelectedIndex = selectedIndex;
							this.BraveryList.SelectedIndex = *(ref selectedIndex + 16);
							this.HelpTypeList.SetSelected(0, (byte)(*(ref selectedIndex + 12) & 1) != 0);
							byte value = (byte)((uint)(*(ref selectedIndex + 12)) >> 1 & 1u);
							this.HelpTypeList.SetSelected(1, value != 0);
							byte value2 = (byte)((uint)(*(ref selectedIndex + 12)) >> 2 & 1u);
							this.HelpTypeList.SetSelected(2, value2 != 0);
							byte value3 = (byte)((uint)(*(ref selectedIndex + 12)) >> 3 & 1u);
							this.HelpTypeList.SetSelected(3, value3 != 0);
							byte value4 = (byte)((uint)(*(ref selectedIndex + 12)) >> 4 & 1u);
							this.HelpTypeList.SetSelected(4, value4 != 0);
							byte value5 = (byte)((uint)(*(ref selectedIndex + 12)) >> 5 & 1u);
							this.HelpTypeList.SetSelected(5, value5 != 0);
							byte value6 = (byte)((uint)(*(ref selectedIndex + 12)) >> 6 & 1u);
							this.HelpTypeList.SetSelected(6, value6 != 0);
							if (*(ref selectedIndex + 24) == -1)
							{
								this.FallbackList.SelectedIndex = 0;
							}
							else if (*(ref selectedIndex + 24) == -2)
							{
								this.FallbackList.SelectedIndex = 1;
							}
							else
							{
								int num2 = 0;
								if (0 < this.Locations.Length)
								{
									do
									{
										if (this.Locations[num2] == *(ref selectedIndex + 24))
										{
											this.FallbackList.SelectedIndex = num2 + 2;
										}
										num2++;
									}
									while (num2 < this.Locations.Length);
								}
							}
							float num3 = *(ref selectedIndex + 4) / <Module>.Measures;
							this.RangeEdit.Text = num3.ToString();
							float num4 = *(ref selectedIndex + 8) / <Module>.Measures;
							this.HelpRangeEdit.Text = num4.ToString();
							decimal value7 = new decimal(*(ref selectedIndex + 20));
							this.MaxHelpNumeric.Value = value7;
							this.VehiclesCheck.Checked = (*(ref selectedIndex + 28) != 0);
							this.BuildingsCheck.Checked = (*(ref selectedIndex + 29) != 0);
							this.PropsRefreshing = false;
						}
					}
					else if (sCEType == 6)
					{
						if (idx < 0)
						{
							this.PropsRefreshing = true;
							this.ObjLocList.SelectedIndex = -1;
							this.ObjPathList.SelectedIndex = -1;
							this.TargetList.SelectedIndex = -1;
							this.DescriptionEdit.Text = "";
							decimal value8 = new decimal(0);
							this.RewardNumeric.Value = value8;
							this.PropsRefreshing = false;
							this.ObjLocList.Enabled = false;
							this.ObjPathList.Enabled = false;
							this.TargetList.Enabled = false;
							this.DescriptionEdit.Enabled = false;
							this.RewardNumeric.Enabled = false;
						}
						else
						{
							this.ObjLocList.Enabled = true;
							this.ObjPathList.Enabled = true;
							this.TargetList.Enabled = true;
							this.DescriptionEdit.Enabled = true;
							this.RewardNumeric.Enabled = true;
							this.PropsRefreshing = true;
							GBaseString<char> gBaseString<char>;
							GBaseString<char>* ptr = <Module>.GEditorWorld.GetObjectiveDescription(this.propWorld, &gBaseString<char>, idx);
							try
							{
								uint num5 = (uint)(*(int*)ptr);
								sbyte* value9;
								if (num5 != 0u)
								{
									value9 = num5;
								}
								else
								{
									value9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								this.DescriptionEdit.Text = new string((sbyte*)value9);
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
							decimal value10 = new decimal(<Module>.GEditorWorld.GetObjectiveReward(this.propWorld, idx));
							this.RewardNumeric.Value = value10;
							this.TargetList.Items.Clear();
							int num6 = idx * 68;
							int num7 = *(num6 + *(int*)(this.propWorld + 3416 / sizeof(GEditorWorld)) + 4 + 40);
							this.Targets = new int[num7];
							int num8 = 0;
							GBaseString<char> gBaseString<char>2 = 0;
							*(ref gBaseString<char>2 + 4) = 0;
							try
							{
								GBaseString<char> gBaseString<char>3 = 0;
								*(ref gBaseString<char>3 + 4) = 0;
								try
								{
									int num9 = -1;
									while (true)
									{
										GWObjective* ptr2 = num6 + *(int*)(this.propWorld + 3416 / sizeof(GEditorWorld)) + 4;
										int num10 = num9 + 1;
										int num11 = num9 * 8 + 8;
										if (num10 >= *(ptr2 + 40))
										{
											break;
										}
										num9 = num10;
										if (num10 < 0)
										{
											break;
										}
										<Module>.GBaseString<char>.Format(ref gBaseString<char>2, (sbyte*)(&<Module>.??_C@_0O@PNCAEKFM@Target?5?$CFd?5?3?3?5?$AA@), num10);
										GEditorWorld* ptr3 = this.propWorld;
										int num12 = num6 + *(int*)(ptr3 + 3416 / sizeof(GEditorWorld)) + 4;
										GWObjective* ptr4 = num12;
										if (*(num11 + *(ptr4 + 36) + 4) == 0)
										{
											GAObjectiveTarget* ptr5 = *(num12 + 36) + num11;
											if (<Module>.GHeap<GWLocation>.Present(ptr3 + 3352 / sizeof(GEditorWorld), *ptr5) != null)
											{
												int num13 = *(*(num12 + 36) + num11);
												<Module>.GBaseString<char>.=(ref gBaseString<char>3, *(int*)(ptr3 + 3352 / sizeof(GEditorWorld)) + num13 * 76 + 4);
											}
											else
											{
												<Module>.GBaseString<char>.=(ref gBaseString<char>3, (sbyte*)(&<Module>.??_C@_0BB@JAFGFJIC@Invalid?5location?$AA@));
											}
										}
										else
										{
											GAObjectiveTarget* ptr6 = *(num12 + 36) + num11;
											if (<Module>.GHeap<GWPath>.Present(ptr3 + 3312 / sizeof(GEditorWorld), *ptr6) != null)
											{
												GAObjectiveTarget* ptr7 = *(num12 + 36) + num11;
												<Module>.GBaseString<char>.=(ref gBaseString<char>3, <Module>.GHeap<GWPath>.[](ptr3 + 3312 / sizeof(GEditorWorld), *ptr7));
											}
											else
											{
												<Module>.GBaseString<char>.=(ref gBaseString<char>3, (sbyte*)(&<Module>.??_C@_0N@KKHAJPLM@Invalid?5path?$AA@));
											}
										}
										GBaseString<char> gBaseString<char>4;
										GBaseString<char>* ptr8 = <Module>.GBaseString<char>.+(ref gBaseString<char>2, &gBaseString<char>4, ref gBaseString<char>3);
										try
										{
											this.TargetList.Items.Add(new string(<Module>.GBaseString<char>..PBD(ptr8)));
										}
										catch
										{
											<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
											throw;
										}
										<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>4);
										this.Targets[num8] = num10;
										num8++;
									}
									this.PropsRefreshing = false;
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
					}
				}
			}
		}

		public unsafe void RefreshEntityList()
		{
			this.EntityList.Items.Clear();
			if (this.propWorld != null)
			{
				GBaseString<char> gBaseString<char> = 0;
				*(ref gBaseString<char> + 4) = 0;
				try
				{
					Color color = default(Color);
					this.EntityList.BeginUpdate();
					int num17;
					switch (this.SCEType)
					{
					case 0:
					{
						int num = <Module>.GHeap<GWPath>.GetNext(this.propWorld + 3312 / sizeof(GEditorWorld), -1);
						if (num >= 0)
						{
							do
							{
								GBaseString<char> gBaseString<char>2;
								GBaseString<char>* src = <Module>.GEditorWorld.GetPathName(this.propWorld, &gBaseString<char>2, num);
								try
								{
									<Module>.GBaseString<char>.=(ref gBaseString<char>, src);
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
								color = Color.FromArgb(<Module>.GEditorWorld.GetPathColor(this.propWorld, num));
								color = Color.FromArgb(255, color);
								ListViewItem listViewItem = new ListViewItem();
								listViewItem.UseItemStyleForSubItems = false;
								sbyte* value;
								if (gBaseString<char> != null)
								{
									value = gBaseString<char>;
								}
								else
								{
									value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem.Text = new string((sbyte*)value);
								listViewItem.Tag = num;
								if (gBaseString<char> != null)
								{
									value = gBaseString<char>;
								}
								else
								{
									value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem.SubItems.Add(new string((sbyte*)value));
								ListViewItem.ListViewSubItemCollection arg_161_0 = listViewItem.SubItems;
								string arg_161_1 = "";
								Color expr_14C = color;
								arg_161_0.Add(arg_161_1, expr_14C, expr_14C, new Font(new string((sbyte*)(&<Module>.??_C@_05MPFIAJAP@Arial?$AA@)), 1f));
								int num2 = <Module>.GEditorWorld.GetPathLooping(this.propWorld, num);
								if (num2 != 0)
								{
									if (num2 != 1)
									{
										if (num2 == 2)
										{
											listViewItem.SubItems.Add("Return");
										}
									}
									else
									{
										listViewItem.SubItems.Add("Loop");
									}
								}
								else
								{
									listViewItem.SubItems.Add("Single");
								}
								if (num == this.SelectedWorldIndex)
								{
									this.SelectItem(listViewItem);
								}
								this.EntityList.Items.Add(listViewItem);
								num = <Module>.GHeap<GWPath>.GetNext(this.propWorld + 3312 / sizeof(GEditorWorld), num);
							}
							while (num >= 0);
						}
						break;
					}
					case 1:
					{
						int num3 = <Module>.GHeap<GWLocation>.GetNext(this.propWorld + 3352 / sizeof(GEditorWorld), -1);
						if (num3 >= 0)
						{
							while (true)
							{
								GBaseString<char> gBaseString<char>3;
								GBaseString<char>* src2 = <Module>.GEditorWorld.GetLocationName(this.propWorld, &gBaseString<char>3, num3);
								try
								{
									<Module>.GBaseString<char>.=(ref gBaseString<char>, src2);
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
									throw;
								}
								if (gBaseString<char>3 != null)
								{
									<Module>.free(gBaseString<char>3);
									gBaseString<char>3 = 0;
								}
								color = Color.FromArgb(<Module>.GEditorWorld.GetLocationColor(this.propWorld, num3));
								color = Color.FromArgb(255, color);
								ListViewItem listViewItem2 = new ListViewItem();
								listViewItem2.UseItemStyleForSubItems = false;
								sbyte* value2;
								if (gBaseString<char> != null)
								{
									value2 = gBaseString<char>;
								}
								else
								{
									value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem2.Text = new string((sbyte*)value2);
								listViewItem2.Tag = num3;
								if (gBaseString<char> != null)
								{
									value2 = gBaseString<char>;
								}
								else
								{
									value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem2.SubItems.Add(new string((sbyte*)value2));
								ListViewItem.ListViewSubItemCollection arg_6B1_0 = listViewItem2.SubItems;
								string arg_6B1_1 = "";
								Color expr_69C = color;
								arg_6B1_0.Add(arg_6B1_1, expr_69C, expr_69C, new Font(new string((sbyte*)(&<Module>.??_C@_05MPFIAJAP@Arial?$AA@)), 1f));
								switch (<Module>.GEditorWorld.GetLocationEffectRange(this.propWorld, num3))
								{
								case 1:
									listViewItem2.SubItems.Add("Ground");
									break;
								case 2:
									listViewItem2.SubItems.Add("Air");
									break;
								case 3:
									listViewItem2.SubItems.Add("Full");
									break;
								case 4:
									listViewItem2.SubItems.Add("Civil meeting area");
									break;
								case 5:
								case 6:
								case 7:
									goto IL_750;
								case 8:
									listViewItem2.SubItems.Add("Patrol waiting area");
									break;
								default:
									goto IL_750;
								}
								IL_761:
								if (<Module>.GEditorWorld.IsLocationEventSource(this.propWorld, num3) != null)
								{
									listViewItem2.SubItems.Add("Active");
								}
								else
								{
									listViewItem2.SubItems.Add("Passive");
								}
								if (num3 == this.SelectedWorldIndex)
								{
									this.SelectItem(listViewItem2);
								}
								this.EntityList.Items.Add(listViewItem2);
								num3 = <Module>.GHeap<GWLocation>.GetNext(this.propWorld + 3352 / sizeof(GEditorWorld), num3);
								if (num3 < 0)
								{
									break;
								}
								continue;
								IL_750:
								listViewItem2.SubItems.Add("Invalid");
								goto IL_761;
							}
						}
						break;
					}
					case 2:
					{
						int num2 = <Module>.GHeap<GWCameraCurve>.GetNext(this.propWorld + 3196 / sizeof(GEditorWorld), -1);
						if (num2 >= 0)
						{
							do
							{
								GBaseString<char> gBaseString<char>4;
								GBaseString<char>* src3 = <Module>.GEditorWorld.GetCameraCurveName(this.propWorld, &gBaseString<char>4, num2);
								try
								{
									<Module>.GBaseString<char>.=(ref gBaseString<char>, src3);
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
								color = Color.FromArgb(<Module>.GEditorWorld.GetCameraCurveColor(this.propWorld, num2));
								color = Color.FromArgb(255, color);
								ListViewItem listViewItem3 = new ListViewItem();
								listViewItem3.UseItemStyleForSubItems = false;
								sbyte* value3;
								if (gBaseString<char> != null)
								{
									value3 = gBaseString<char>;
								}
								else
								{
									value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem3.Text = new string((sbyte*)value3);
								listViewItem3.Tag = num2;
								if (gBaseString<char> != null)
								{
									value3 = gBaseString<char>;
								}
								else
								{
									value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem3.SubItems.Add(new string((sbyte*)value3));
								ListViewItem.ListViewSubItemCollection arg_2F9_0 = listViewItem3.SubItems;
								string arg_2F9_1 = "";
								Color expr_2E4 = color;
								arg_2F9_0.Add(arg_2F9_1, expr_2E4, expr_2E4, new Font(new string((sbyte*)(&<Module>.??_C@_05MPFIAJAP@Arial?$AA@)), 1f));
								int num4 = <Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(this.propWorld, num2);
								if (num4 != 0)
								{
									if (num4 == 1)
									{
										listViewItem3.SubItems.Add("Target");
									}
								}
								else
								{
									listViewItem3.SubItems.Add("Eye");
								}
								if (num2 == this.SelectedWorldIndex)
								{
									this.SelectItem(listViewItem3);
								}
								this.EntityList.Items.Add(listViewItem3);
								num2 = <Module>.GHeap<GWCameraCurve>.GetNext(this.propWorld + 3196 / sizeof(GEditorWorld), num2);
							}
							while (num2 >= 0);
						}
						this.CameraEyeCurveSelectedIdx = this.EyeCurveSelect.SelectedIndex;
						this.CameraTargetCurveSelectedIdx = this.TargetCurveSelect.SelectedIndex;
						this.EyeCurveSelect.Items.Clear();
						this.TargetCurveSelect.Items.Clear();
						int num5 = <Module>.GHeap<GWCameraCurve>.GetNext(this.propWorld + 3196 / sizeof(GEditorWorld), -1);
						if (num5 >= 0)
						{
							do
							{
								if (<Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(this.propWorld, num5) == null)
								{
									GBaseString<char> gBaseString<char>5;
									GBaseString<char>* ptr = <Module>.GEditorWorld.GetCameraCurveName(this.propWorld, &gBaseString<char>5, num5);
									try
									{
										uint num6 = (uint)(*(int*)ptr);
										sbyte* value4;
										if (num6 != 0u)
										{
											value4 = num6;
										}
										else
										{
											value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
										}
										this.EyeCurveSelect.Items.Add(new string((sbyte*)value4));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>5));
										throw;
									}
									if (gBaseString<char>5 != null)
									{
										<Module>.free(gBaseString<char>5);
										gBaseString<char>5 = 0;
									}
								}
								else if (<Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(this.propWorld, num5) == 1)
								{
									GBaseString<char> gBaseString<char>6;
									GBaseString<char>* ptr = <Module>.GEditorWorld.GetCameraCurveName(this.propWorld, &gBaseString<char>6, num5);
									try
									{
										uint num6 = (uint)(*(int*)ptr);
										sbyte* value4;
										if (num6 != 0u)
										{
											value4 = num6;
										}
										else
										{
											value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
										}
										this.TargetCurveSelect.Items.Add(new string((sbyte*)value4));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
										throw;
									}
									if (gBaseString<char>6 != null)
									{
										<Module>.free(gBaseString<char>6);
										gBaseString<char>6 = 0;
									}
								}
								num5 = <Module>.GHeap<GWCameraCurve>.GetNext(this.propWorld + 3196 / sizeof(GEditorWorld), num5);
							}
							while (num5 >= 0);
						}
						if (this.EyeCurveSelect.Items.Count != 0)
						{
							int num7 = this.CameraEyeCurveSelectedIdx;
							if (num7 < this.EyeCurveSelect.Items.Count)
							{
								this.EyeCurveSelect.SelectedIndex = num7;
							}
							else
							{
								this.EyeCurveSelect.SelectedIndex = this.EyeCurveSelect.Items.Count - 1;
							}
						}
						if (this.TargetCurveSelect.Items.Count != 0)
						{
							int num7 = this.CameraTargetCurveSelectedIdx;
							if (num7 < this.TargetCurveSelect.Items.Count)
							{
								this.TargetCurveSelect.SelectedIndex = num7;
							}
							else
							{
								this.TargetCurveSelect.SelectedIndex = this.TargetCurveSelect.Items.Count - 1;
							}
						}
						this.CameraEyeCurveSelectedIdx = this.EyeCurveSelect.SelectedIndex;
						this.CameraTargetCurveSelectedIdx = this.TargetCurveSelect.SelectedIndex;
						this.RefreshCameraCurveIndex();
						break;
					}
					case 3:
					{
						int num8 = <Module>.GHeap<GWAIGroup>.GetNext(this.propWorld + 3392 / sizeof(GEditorWorld), -1);
						if (num8 >= 0)
						{
							do
							{
								GBaseString<char> gBaseString<char>7;
								GBaseString<char>* src4 = <Module>.GEditorWorld.GetAIGroupName(this.propWorld, &gBaseString<char>7, num8);
								try
								{
									<Module>.GBaseString<char>.=(ref gBaseString<char>, src4);
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>7));
									throw;
								}
								if (gBaseString<char>7 != null)
								{
									<Module>.free(gBaseString<char>7);
									gBaseString<char>7 = 0;
								}
								color = Color.FromArgb(<Module>.GEditorWorld.GetAIGroupColor(this.propWorld, num8));
								color = Color.FromArgb(255, color);
								ListViewItem listViewItem4 = new ListViewItem();
								listViewItem4.UseItemStyleForSubItems = false;
								sbyte* value5;
								if (gBaseString<char> != null)
								{
									value5 = gBaseString<char>;
								}
								else
								{
									value5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem4.Text = new string((sbyte*)value5);
								listViewItem4.Tag = num8;
								if (gBaseString<char> != null)
								{
									value5 = gBaseString<char>;
								}
								else
								{
									value5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem4.SubItems.Add(new string((sbyte*)value5));
								ListViewItem.ListViewSubItemCollection arg_8D6_0 = listViewItem4.SubItems;
								string arg_8D6_1 = "";
								Color expr_8C1 = color;
								arg_8D6_0.Add(arg_8D6_1, expr_8C1, expr_8C1, new Font(new string((sbyte*)(&<Module>.??_C@_05MPFIAJAP@Arial?$AA@)), 1f));
								if (*(num8 * 392 + *(int*)(this.propWorld + 3392 / sizeof(GEditorWorld)) + 8 + 55) != 0)
								{
									listViewItem4.SubItems.Add("Empty");
								}
								else
								{
									listViewItem4.SubItems.Add("Normal");
								}
								if (num8 == this.SelectedWorldIndex)
								{
									this.SelectItem(listViewItem4);
								}
								this.EntityList.Items.Add(listViewItem4);
								num8 = <Module>.GHeap<GWAIGroup>.GetNext(this.propWorld + 3392 / sizeof(GEditorWorld), num8);
							}
							while (num8 >= 0);
						}
						this.FallbackList.Items.Clear();
						this.FallbackList.Items.Add("None");
						this.FallbackList.Items.Add("Merge group");
						GEditorWorld* ptr2 = this.propWorld;
						int num9 = *(int*)(ptr2 + 3368 / sizeof(GEditorWorld));
						this.Locations = new int[num9];
						num9 = 0;
						int num10 = <Module>.GHeap<GWLocation>.GetNext(ptr2 + 3352 / sizeof(GEditorWorld), -1);
						if (num10 >= 0)
						{
							do
							{
								GBaseString<char> gBaseString<char>8;
								GBaseString<char>* src5 = <Module>.GEditorWorld.GetLocationName(this.propWorld, &gBaseString<char>8, num10);
								try
								{
									<Module>.GBaseString<char>.=(ref gBaseString<char>, src5);
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>8));
									throw;
								}
								if (gBaseString<char>8 != null)
								{
									<Module>.free(gBaseString<char>8);
									gBaseString<char>8 = 0;
								}
								sbyte* value6;
								if (gBaseString<char> != null)
								{
									value6 = gBaseString<char>;
								}
								else
								{
									value6 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								this.FallbackList.Items.Add(new string((sbyte*)value6));
								this.Locations[num9] = num10;
								num9++;
								num10 = <Module>.GHeap<GWLocation>.GetNext(this.propWorld + 3352 / sizeof(GEditorWorld), num10);
							}
							while (num10 >= 0);
						}
						break;
					}
					case 4:
					{
						int num11 = <Module>.GHeap<GSector>.GetNext(this.propWorld + 2712 / sizeof(GEditorWorld), -1);
						if (num11 >= 0)
						{
							do
							{
								GBaseString<char> gBaseString<char>9;
								GBaseString<char>* src6 = <Module>.GEditorWorld.GetSectorName(this.propWorld, &gBaseString<char>9, num11);
								try
								{
									<Module>.GBaseString<char>.=(ref gBaseString<char>, src6);
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>9));
									throw;
								}
								if (gBaseString<char>9 != null)
								{
									<Module>.free(gBaseString<char>9);
									gBaseString<char>9 = 0;
								}
								color = Color.FromArgb(<Module>.GEditorWorld.GetSectorColor(this.propWorld, num11));
								color = Color.FromArgb(255, color);
								ListViewItem listViewItem5 = new ListViewItem();
								listViewItem5.UseItemStyleForSubItems = false;
								sbyte* value7;
								if (gBaseString<char> != null)
								{
									value7 = gBaseString<char>;
								}
								else
								{
									value7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem5.Text = new string((sbyte*)value7);
								listViewItem5.Tag = num11;
								if (gBaseString<char> != null)
								{
									value7 = gBaseString<char>;
								}
								else
								{
									value7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem5.SubItems.Add(new string((sbyte*)value7));
								ListViewItem.ListViewSubItemCollection arg_B6F_0 = listViewItem5.SubItems;
								string arg_B6F_1 = "";
								Color expr_B5A = color;
								arg_B6F_0.Add(arg_B6F_1, expr_B5A, expr_B5A, new Font(new string((sbyte*)(&<Module>.??_C@_05MPFIAJAP@Arial?$AA@)), 1f));
								if (<Module>.GWorld.IsSectorInactive(this.propWorld, num11) != null)
								{
									listViewItem5.SubItems.Add("Inactive");
								}
								else
								{
									listViewItem5.SubItems.Add("Active");
								}
								if (<Module>.GWorld.IsSectorAISleep(this.propWorld, num11) != null)
								{
									listViewItem5.SubItems.Add("AI sleep");
								}
								else
								{
									listViewItem5.SubItems.Add("AI active");
								}
								if (num11 == this.SelectedWorldIndex)
								{
									this.SelectItem(listViewItem5);
								}
								this.EntityList.Items.Add(listViewItem5);
								num11 = <Module>.GHeap<GSector>.GetNext(this.propWorld + 2712 / sizeof(GEditorWorld), num11);
							}
							while (num11 >= 0);
						}
						break;
					}
					case 6:
					{
						int num12 = <Module>.GHeap<GWObjective>.GetNext(this.propWorld + 3416 / sizeof(GEditorWorld), -1);
						if (num12 >= 0)
						{
							do
							{
								GBaseString<char> gBaseString<char>10;
								GBaseString<char>* src7 = <Module>.GEditorWorld.GetObjectiveName(this.propWorld, &gBaseString<char>10, num12);
								try
								{
									<Module>.GBaseString<char>.=(ref gBaseString<char>, src7);
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>10));
									throw;
								}
								if (gBaseString<char>10 != null)
								{
									<Module>.free(gBaseString<char>10);
									gBaseString<char>10 = 0;
								}
								ListViewItem listViewItem6 = new ListViewItem();
								listViewItem6.UseItemStyleForSubItems = false;
								sbyte* value8;
								if (gBaseString<char> != null)
								{
									value8 = gBaseString<char>;
								}
								else
								{
									value8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem6.Text = new string((sbyte*)value8);
								listViewItem6.Tag = num12;
								if (gBaseString<char> != null)
								{
									value8 = gBaseString<char>;
								}
								else
								{
									value8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								listViewItem6.SubItems.Add(new string((sbyte*)value8));
								int num13 = <Module>.GEditorWorld.GetObjectiveType(this.propWorld, num12);
								if (num13 != 0)
								{
									if (num13 != 1)
									{
										if (num13 == 2)
										{
											listViewItem6.SubItems.Add("Condition");
										}
									}
									else
									{
										listViewItem6.SubItems.Add("Optional");
									}
								}
								else
								{
									listViewItem6.SubItems.Add("Primary");
								}
								if (<Module>.GEditorWorld.IsObjectiveActive(this.propWorld, num12) != null)
								{
									listViewItem6.SubItems.Add("Active");
								}
								else
								{
									listViewItem6.SubItems.Add("Inactive");
								}
								if (num12 == this.SelectedWorldIndex)
								{
									this.SelectItem(listViewItem6);
								}
								this.EntityList.Items.Add(listViewItem6);
								num12 = <Module>.GHeap<GWObjective>.GetNext(this.propWorld + 3416 / sizeof(GEditorWorld), num12);
							}
							while (num12 >= 0);
						}
						this.ObjLocList.Items.Clear();
						GEditorWorld* ptr3 = this.propWorld;
						int num14 = *(int*)(ptr3 + 3368 / sizeof(GEditorWorld));
						this.Locations = new int[num14];
						num14 = 0;
						int num15 = <Module>.GHeap<GWLocation>.GetNext(ptr3 + 3352 / sizeof(GEditorWorld), -1);
						if (num15 >= 0)
						{
							do
							{
								GBaseString<char> gBaseString<char>11;
								GBaseString<char>* src8 = <Module>.GEditorWorld.GetLocationName(this.propWorld, &gBaseString<char>11, num15);
								try
								{
									<Module>.GBaseString<char>.=(ref gBaseString<char>, src8);
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>11));
									throw;
								}
								if (gBaseString<char>11 != null)
								{
									<Module>.free(gBaseString<char>11);
									gBaseString<char>11 = 0;
								}
								sbyte* value9;
								if (gBaseString<char> != null)
								{
									value9 = gBaseString<char>;
								}
								else
								{
									value9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								this.ObjLocList.Items.Add(new string((sbyte*)value9));
								this.Locations[num14] = num15;
								num14++;
								num15 = <Module>.GHeap<GWLocation>.GetNext(this.propWorld + 3352 / sizeof(GEditorWorld), num15);
							}
							while (num15 >= 0);
						}
						this.ObjPathList.Items.Clear();
						GEditorWorld* ptr4 = this.propWorld;
						int num16 = *(int*)(ptr4 + 3328 / sizeof(GEditorWorld));
						this.Paths = new int[num16];
						num16 = 0;
						num17 = <Module>.GHeap<GWPath>.GetNext(ptr4 + 3312 / sizeof(GEditorWorld), -1);
						if (num17 >= 0)
						{
							do
							{
								GBaseString<char> gBaseString<char>12;
								GBaseString<char>* src9 = <Module>.GEditorWorld.GetPathName(this.propWorld, &gBaseString<char>12, num17);
								try
								{
									<Module>.GBaseString<char>.=(ref gBaseString<char>, src9);
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>12));
									throw;
								}
								if (gBaseString<char>12 != null)
								{
									<Module>.free(gBaseString<char>12);
									gBaseString<char>12 = 0;
								}
								sbyte* value10;
								if (gBaseString<char> != null)
								{
									value10 = gBaseString<char>;
								}
								else
								{
									value10 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								this.ObjPathList.Items.Add(new string((sbyte*)value10));
								this.Paths[num16] = num17;
								num16++;
								num17 = <Module>.GHeap<GWPath>.GetNext(this.propWorld + 3312 / sizeof(GEditorWorld), num17);
							}
							while (num17 >= 0);
						}
						break;
					}
					}
					this.EntityList.EndUpdate();
					int num18 = 0;
					num17 = 2;
					if (2 < this.EntityList.Columns.Count)
					{
						do
						{
							num18 = this.EntityList.Columns[num17].Width + num18;
							num17++;
						}
						while (num17 < this.EntityList.Columns.Count);
					}
					Size clientSize = this.EntityList.ClientSize;
					this.EntityList.Columns[1].Width = clientSize.Width - num18;
					num18 = 0;
					if (0 >= this.EntityList.Items.Count)
					{
						goto IL_1088;
					}
					do
					{
						object tag = this.EntityList.Items[num18].Tag;
						if (*((!(tag is int)) ? 0 : ref (int)tag) == this.SelectedWorldIndex)
						{
							goto IL_1055;
						}
						num18++;
					}
					while (num18 < this.EntityList.Items.Count);
					goto IL_1088;
					IL_1055:
					this.SelectedItem = num18;
					this.RefreshScriptEntityProps(this.SelectedWorldIndex);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
					throw;
				}
				if (gBaseString<char> != null)
				{
					<Module>.free(gBaseString<char>);
					return;
				}
				return;
				IL_1088:
				try
				{
					this.SelectedItem = -1;
					this.SelectedWorldIndex = -1;
					this.RefreshScriptEntityProps(-1);
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

		public unsafe void UpdateHilighting()
		{
			if (this.propWorld != null && this.SCEType == 3)
			{
				GArray<int> gArray<int> = 0;
				*(ref gArray<int> + 4) = 0;
				*(ref gArray<int> + 8) = 0;
				try
				{
					<Module>.GEditorWorld.CountAIGroupSelections(this.propWorld, ref gArray<int>);
					int num = 0;
					int num2 = -1;
					int num3 = 0;
					if (0 < this.EntityList.Items.Count)
					{
						do
						{
							if (num3 != this.SelectedItem)
							{
								object tag = this.EntityList.Items[num3].Tag;
								if (*(*((!(tag is int)) ? 0 : ref (int)tag) * 4 + gArray<int>) > 0)
								{
									Color backColor = Color.FromKnownColor(KnownColor.ControlLightLight);
									this.EntityList.Items[num3].SubItems[1].BackColor = backColor;
									num++;
									object tag2 = this.EntityList.Items[num3].Tag;
									num2 = *((!(tag2 is int)) ? 0 : ref (int)tag2);
								}
								else
								{
									Color backColor2 = Color.FromKnownColor(KnownColor.Window);
									this.EntityList.Items[num3].SubItems[1].BackColor = backColor2;
								}
							}
							num3++;
						}
						while (num3 < this.EntityList.Items.Count);
						if (num != 0)
						{
							if (num != 1)
							{
								this.RefreshScriptEntityProps(-1);
								goto IL_1E9;
							}
							this.RefreshScriptEntityProps(num2);
							if (num2 == this.SelectedWorldIndex)
							{
								goto IL_1E9;
							}
							this.BehaviorList.Enabled = false;
							this.BraveryList.Enabled = false;
							this.FallbackList.Enabled = false;
							this.HelpTypeList.Enabled = false;
							this.MaxHelpNumeric.Enabled = false;
							this.RangeEdit.Enabled = false;
							this.HelpRangeEdit.Enabled = false;
							this.VehiclesCheck.Enabled = false;
							this.BuildingsCheck.Enabled = false;
							goto IL_1E9;
						}
					}
					this.RefreshScriptEntityProps(this.SelectedWorldIndex);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
					throw;
				}
				IL_1E9:
				if (gArray<int> != null)
				{
					<Module>.free(gArray<int>);
				}
			}
		}

		public unsafe void SetEntityName(int idx, string newname)
		{
			if (this.propWorld != null)
			{
				GBaseString<char> gBaseString<char>;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, newname);
				try
				{
					switch (this.SCEType)
					{
					case 0:
					{
						GBaseString<char> gBaseString<char>2;
						GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr2;
						GEditorWorld* ptr3;
						try
						{
							GBaseString<char> gBaseString<char>3;
							ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, ref gBaseString<char>);
							try
							{
								ptr3 = this.propWorld;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
							throw;
						}
						GBaseString<char> gBaseString<char>4;
						GBaseString<char>* ptr4 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr3, &gBaseString<char>4, 0, ptr2, idx, ptr);
						try
						{
							uint num = (uint)(*(int*)ptr4);
							sbyte* ptr5;
							if (num != 0u)
							{
								ptr5 = num;
							}
							else
							{
								ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							<Module>.GEditorWorld.SetPathName(this.propWorld, idx, ptr5);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
							throw;
						}
						if (gBaseString<char>4 != null)
						{
							<Module>.free(gBaseString<char>4);
						}
						break;
					}
					case 1:
					{
						GBaseString<char> gBaseString<char>5;
						GBaseString<char>* ptr6 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>5, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr7;
						GEditorWorld* ptr8;
						try
						{
							GBaseString<char> gBaseString<char>6;
							ptr7 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>6, ref gBaseString<char>);
							try
							{
								ptr8 = this.propWorld;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>5));
							throw;
						}
						GBaseString<char> gBaseString<char>7;
						GBaseString<char>* ptr9 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr8, &gBaseString<char>7, 1, ptr7, idx, ptr6);
						try
						{
							<Module>.GEditorWorld.SetLocationName(this.propWorld, idx, <Module>.GBaseString<char>..PBD(ptr9));
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>7));
							throw;
						}
						if (gBaseString<char>7 != null)
						{
							<Module>.free(gBaseString<char>7);
						}
						break;
					}
					case 2:
					{
						GBaseString<char> gBaseString<char>8;
						GBaseString<char>* ptr10 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>8, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr11;
						GEditorWorld* ptr12;
						try
						{
							GBaseString<char> gBaseString<char>9;
							ptr11 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>9, ref gBaseString<char>);
							try
							{
								ptr12 = this.propWorld;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>9));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>8));
							throw;
						}
						GBaseString<char> gBaseString<char>10;
						GBaseString<char>* ptr13 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr12, &gBaseString<char>10, 2, ptr11, idx, ptr10);
						try
						{
							<Module>.GEditorWorld.SetCameraCurveName(this.propWorld, idx, <Module>.GBaseString<char>..PBD(ptr13));
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>10));
							throw;
						}
						if (gBaseString<char>10 != null)
						{
							<Module>.free(gBaseString<char>10);
						}
						break;
					}
					case 3:
					{
						GBaseString<char> gBaseString<char>11;
						GBaseString<char>* ptr14 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>11, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr15;
						GEditorWorld* ptr16;
						try
						{
							GBaseString<char> gBaseString<char>12;
							ptr15 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>12, ref gBaseString<char>);
							try
							{
								ptr16 = this.propWorld;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>12));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>11));
							throw;
						}
						GBaseString<char> gBaseString<char>13;
						GBaseString<char>* ptr17 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr16, &gBaseString<char>13, 3, ptr15, idx, ptr14);
						GEditorWorld* ptr18;
						try
						{
							ptr18 = this.propWorld;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>13));
							throw;
						}
						<Module>.GEditorWorld.SetAIGroupName(ptr18, idx, (GBaseString<char>*)ptr17);
						break;
					}
					case 4:
					{
						GBaseString<char> gBaseString<char>14;
						GBaseString<char>* ptr19 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>14, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr20;
						GEditorWorld* ptr21;
						try
						{
							GBaseString<char> gBaseString<char>15;
							ptr20 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>15, ref gBaseString<char>);
							try
							{
								ptr21 = this.propWorld;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>15));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>14));
							throw;
						}
						GBaseString<char> gBaseString<char>16;
						GBaseString<char>* ptr22 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr21, &gBaseString<char>16, 4, ptr20, idx, ptr19);
						GEditorWorld* ptr23;
						try
						{
							ptr23 = this.propWorld;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>16));
							throw;
						}
						<Module>.GEditorWorld.SetSectorName(ptr23, idx, (GBaseString<char>*)ptr22);
						break;
					}
					case 6:
					{
						GBaseString<char> gBaseString<char>17;
						GBaseString<char>* ptr24 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>17, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr25;
						GEditorWorld* ptr26;
						try
						{
							GBaseString<char> gBaseString<char>18;
							ptr25 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>18, ref gBaseString<char>);
							try
							{
								ptr26 = this.propWorld;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>18));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>17));
							throw;
						}
						GBaseString<char> gBaseString<char>19;
						GBaseString<char>* ptr27 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr26, &gBaseString<char>19, 6, ptr25, idx, ptr24);
						GEditorWorld* ptr28;
						try
						{
							ptr28 = this.propWorld;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>19));
							throw;
						}
						<Module>.GEditorWorld.SetObjectiveName(ptr28, idx, (GBaseString<char>*)ptr27);
						break;
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
		}

		public unsafe void RefreshCameraCurveIndex()
		{
			if (this.propWorld != null)
			{
				this.CameraEyeCurveIndex = -1;
				this.CameraTargetCurveIndex = -1;
				int num = -1;
				while (true)
				{
					GHeap<GWCameraCurve>* ptr = this.propWorld + 3196 / sizeof(GEditorWorld);
					int num2 = num + 1;
					int num3 = *(ptr + 4);
					if (num2 >= num3)
					{
						break;
					}
					int num4 = num2 * 104 + *ptr;
					while (*num4 != 2147483647)
					{
						num2++;
						num4 += 104;
						if (num2 >= num3)
						{
							goto IL_1C5;
						}
					}
					num = num2;
					if (num2 < 0)
					{
						break;
					}
					if (this.EyeCurveSelect.SelectedIndex >= 0)
					{
						GBaseString<char> gBaseString<char>;
						<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.EyeCurveSelect.Items[this.EyeCurveSelect.SelectedIndex].ToString());
						try
						{
							GBaseString<char> gBaseString<char>2;
							GBaseString<char>* ptr2 = <Module>.GEditorWorld.GetCameraCurveName(this.propWorld, &gBaseString<char>2, num2);
							bool flag;
							try
							{
								flag = (((<Module>.GBaseString<char>.Compare(ptr2, ref gBaseString<char>, false) == 0) ? 1 : 0) != 0);
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
							if (flag)
							{
								this.CameraEyeCurveIndex = num2;
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
							gBaseString<char> = 0;
						}
					}
					if (this.TargetCurveSelect.SelectedIndex >= 0)
					{
						GBaseString<char> gBaseString<char>3;
						<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, this.TargetCurveSelect.Items[this.TargetCurveSelect.SelectedIndex].ToString());
						try
						{
							GBaseString<char> gBaseString<char>4;
							GBaseString<char>* ptr3 = <Module>.GEditorWorld.GetCameraCurveName(this.propWorld, &gBaseString<char>4, num2);
							bool flag2;
							try
							{
								flag2 = (((<Module>.GBaseString<char>.Compare(ptr3, ref gBaseString<char>3, false) == 0) ? 1 : 0) != 0);
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
							if (flag2)
							{
								this.CameraTargetCurveIndex = num2;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
							throw;
						}
						if (gBaseString<char>3 != null)
						{
							<Module>.free(gBaseString<char>3);
							gBaseString<char>3 = 0;
						}
					}
				}
				IL_1C5:
				*(int*)(this.propWorld + 3228 / sizeof(GEditorWorld)) = this.CameraEyeCurveIndex;
				int num5;
				if (this.TargetUsed.Checked)
				{
					num5 = this.CameraTargetCurveIndex;
				}
				else
				{
					num5 = -1;
				}
				*(int*)(this.propWorld + 3232 / sizeof(GEditorWorld)) = num5;
				this.LinkedTarget.Visible = (<Module>.GEditorWorld.IsCameraCurveTargetLinked(this.propWorld, this.CameraEyeCurveIndex, this.CameraTargetCurveIndex) != null);
				int cameraEyeCurveIndex = this.CameraEyeCurveIndex;
				if (cameraEyeCurveIndex >= 0 || *(byte*)(this.propWorld + 3220 / sizeof(GEditorWorld)) != 0)
				{
					float num6 = <Module>.GWorld.GetCameraCurveDuration(this.propWorld, cameraEyeCurveIndex);
					this.CurveDuration.Text = num6.ToString();
					float num7 = <Module>.GWorld.GetCameraCurveDebugStart(this.propWorld, this.CameraEyeCurveIndex);
					this.CurveDebugStart.Text = num7.ToString();
				}
				if (*(byte*)(this.propWorld + 3220 / sizeof(GEditorWorld)) != 0)
				{
					this.AddTargetCurve.Enabled = false;
					this.RemoveTargetCurve.Enabled = false;
					this.EyeCurveSelect.Enabled = false;
					this.TargetCurveSelect.Enabled = false;
					this.LinkedTarget.Visible = false;
					this.TimeCurveButton.Enabled = false;
					this.FOVCurveButton.Enabled = false;
					this.RollCurveButton.Enabled = false;
					this.CurveDuration.Enabled = false;
					this.CurveDebugStart.Enabled = true;
					this.CamBeginButton.Enabled = true;
					this.CamRewindButton.Enabled = true;
					this.CamPauseButton.Enabled = true;
					this.CamPlayButton.Enabled = true;
					this.CamForwardButton.Enabled = true;
					this.CurvePositionTrack.Enabled = true;
				}
				else if (this.CameraEyeCurveIndex != -1 && this.CameraTargetCurveIndex != -1)
				{
					this.EyeCurveSelect.Enabled = true;
					this.TargetCurveSelect.Enabled = true;
					this.AddTargetCurve.Enabled = true;
					this.RemoveTargetCurve.Enabled = true;
					this.TimeCurveButton.Enabled = true;
					this.FOVCurveButton.Enabled = true;
					this.RollCurveButton.Enabled = true;
					this.CamBeginButton.Enabled = true;
					this.CamRewindButton.Enabled = true;
					this.CamPauseButton.Enabled = true;
					this.CamPlayButton.Enabled = true;
					this.CamForwardButton.Enabled = true;
					this.CurvePositionTrack.Enabled = true;
					this.CurveDuration.Enabled = true;
					this.CurveDebugStart.Enabled = true;
				}
				else
				{
					this.EyeCurveSelect.Enabled = true;
					this.TargetCurveSelect.Enabled = true;
					this.LinkedTarget.Visible = false;
					this.AddTargetCurve.Enabled = false;
					this.RemoveTargetCurve.Enabled = false;
					if (this.CameraEyeCurveIndex == -1)
					{
						this.TimeCurveButton.Enabled = false;
						this.FOVCurveButton.Enabled = false;
						this.RollCurveButton.Enabled = false;
						this.CurveDuration.Enabled = false;
						this.CurveDebugStart.Enabled = false;
						this.CamBeginButton.Enabled = false;
						this.CamRewindButton.Enabled = false;
						this.CamPauseButton.Enabled = false;
						this.CamPlayButton.Enabled = false;
						this.CamForwardButton.Enabled = false;
						this.CurvePositionTrack.Enabled = false;
					}
					else
					{
						this.TimeCurveButton.Enabled = true;
						this.FOVCurveButton.Enabled = true;
						this.RollCurveButton.Enabled = true;
						this.CurveDuration.Enabled = true;
						this.CurveDebugStart.Enabled = true;
						byte enabled = (!this.TargetUsed.Checked) ? 1 : 0;
						this.CamBeginButton.Enabled = (enabled != 0);
						byte enabled2 = (!this.TargetUsed.Checked) ? 1 : 0;
						this.CamRewindButton.Enabled = (enabled2 != 0);
						byte enabled3 = (!this.TargetUsed.Checked) ? 1 : 0;
						this.CamPauseButton.Enabled = (enabled3 != 0);
						byte enabled4 = (!this.TargetUsed.Checked) ? 1 : 0;
						this.CamPlayButton.Enabled = (enabled4 != 0);
						byte enabled5 = (!this.TargetUsed.Checked) ? 1 : 0;
						this.CamForwardButton.Enabled = (enabled5 != 0);
						byte enabled6 = (!this.TargetUsed.Checked) ? 1 : 0;
						this.CurvePositionTrack.Enabled = (enabled6 != 0);
					}
				}
			}
		}

		public unsafe void InitCameraCurveProps()
		{
			this.ForceRefresh = false;
			this.RemoveCameraViewPort();
			this.CameraEyeCurveSelectedIdx = -1;
			this.CameraTargetCurveSelectedIdx = -1;
			this.CameraEyeCurveIndex = -1;
			this.CameraTargetCurveIndex = -1;
			this.CameraStatus = 0;
			this.CameraPlayPosition = 0f;
			this.CamViewport = null;
			this.CurveMakeShots.Checked = false;
			this.CurveDebugShow.Checked = false;
			this.CurveDebugStart.Text = new string((sbyte*)(&<Module>.??_C@_01GBGANLPD@0?$AA@));
			this.ShowViewport.Checked = false;
			this.CurveLoop.Checked = true;
			this.TargetUsed.Checked = false;
		}

		public void RefreshCameraCurvePos()
		{
			float cameraCurvePosPercent = this.GetCameraCurvePosPercent();
			this.CurvePositionTrack.Value = (int)((double)((float)this.CurvePositionTrack.Maximum * cameraCurvePosPercent));
			float cameraPlayPosition = this.CameraPlayPosition;
			this.CurveActPos.Text = cameraPlayPosition.ToString();
			float num = cameraCurvePosPercent * 100f;
			this.CurveActPercent.Text = num.ToString();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe bool RefreshCameraViewport(GBaseString<char>* caption, int camstat, [MarshalAs(UnmanagedType.U1)] bool forcerefresh)
		{
			GEditorWorld* ptr = this.propWorld;
			if (ptr == null)
			{
				return false;
			}
			if (*(byte*)(ptr + 3220 / sizeof(GEditorWorld)) == 0 && (this.CameraEyeCurveIndex == -1 || (this.TargetUsed.Checked && this.CameraTargetCurveIndex == -1)))
			{
				return false;
			}
			this.ForceRefresh = forcerefresh;
			GPoint3 gPoint;
			*(ref gPoint + 8) = 0f;
			*(ref gPoint + 4) = 0f;
			gPoint = 0f;
			GPoint3 gPoint2;
			*(ref gPoint2 + 8) = 0f;
			*(ref gPoint2 + 4) = 0f;
			gPoint2 = 0f;
			float dir;
			float elev;
			float fov;
			float roll;
			<Module>.GWorld.GetCameraAllParams(this.propWorld, this.CameraEyeCurveIndex, this.CameraTargetCurveIndex, this.TargetUsed.Checked, this.GetCameraCurvePosPercent(), ref gPoint, ref gPoint2, ref dir, ref elev, ref fov, ref roll);
			<Module>.GEditorWorld.SetCameraCurveDebugPosition(this.propWorld, ref gPoint, ref gPoint2);
			ToolboxCameraViewport camViewport = this.CamViewport;
			if (camViewport != null)
			{
				camViewport.SetCamera(ref gPoint, dir, elev, fov, roll, this.ForceRefresh);
				this.CamViewport.SetCaption(caption);
				this.CamViewport.Paint();
				return this.CamViewport.GetFocus();
			}
			return false;
		}

		public float GetCameraCurvePos()
		{
			return this.CameraPlayPosition;
		}

		public void SetCameraCurvePos(float time)
		{
			this.CameraPlayPosition = time;
		}

		public int GetCameraStatus()
		{
			return this.CameraStatus;
		}

		public unsafe float GetCameraCurveDuration()
		{
			GEditorWorld* ptr = this.propWorld;
			if (ptr != null)
			{
				int cameraEyeCurveIndex = this.CameraEyeCurveIndex;
				if (cameraEyeCurveIndex >= 0 || *(byte*)(ptr + 3220 / sizeof(GEditorWorld)) != 0)
				{
					return <Module>.GWorld.GetCameraCurveDuration(ptr, cameraEyeCurveIndex);
				}
			}
			return 0f;
		}

		public unsafe float GetCameraCurveDebugStart()
		{
			GEditorWorld* ptr = this.propWorld;
			if (ptr != null)
			{
				int cameraEyeCurveIndex = this.CameraEyeCurveIndex;
				if (cameraEyeCurveIndex >= 0 || *(byte*)(ptr + 3220 / sizeof(GEditorWorld)) != 0)
				{
					return <Module>.GWorld.GetCameraCurveDebugStart(ptr, cameraEyeCurveIndex);
				}
			}
			return 0f;
		}

		public float GetCameraCurvePosPercent()
		{
			float cameraCurveDuration = this.GetCameraCurveDuration();
			float result;
			if (cameraCurveDuration > 0f)
			{
				result = this.CameraPlayPosition / cameraCurveDuration;
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		public void SetCameraCurvePosPercent(float percent)
		{
			float cameraCurveDuration = this.GetCameraCurveDuration();
			float num;
			if (percent >= 1f)
			{
				num = 1f;
			}
			else
			{
				float num2;
				if (percent <= 0f)
				{
					num2 = 0f;
				}
				else
				{
					num2 = percent;
				}
				num = num2;
			}
			float cameraCurvePos;
			if (cameraCurveDuration > 0f)
			{
				cameraCurvePos = num * cameraCurveDuration;
			}
			else
			{
				cameraCurvePos = 0f;
			}
			this.SetCameraCurvePos(cameraCurvePos);
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public bool GetCameraCurveLoop()
		{
			return this.CurveLoop.Checked;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public bool GetCameraCurveDebugShow()
		{
			return this.CurveDebugShow.Checked;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public bool GetCameraCurveMakeShots()
		{
			return this.CurveMakeShots.Checked;
		}

		public unsafe void GetResolution(int* resx, int* resy)
		{
			switch (this.ResolutionList.SelectedIndex)
			{
			case 0:
				*resx = 848;
				*resy = 480;
				break;
			case 1:
				*resx = 1024;
				*resy = 580;
				break;
			case 2:
				*resx = 1280;
				*resy = 725;
				break;
			case 3:
				*resx = 1600;
				*resy = 906;
				break;
			case 4:
				*resx = 1696;
				*resy = 960;
				break;
			case 5:
				*resx = 2048;
				*resy = 1160;
				break;
			case 6:
				*resx = 2544;
				*resy = 1440;
				break;
			case 7:
				*resx = 3392;
				*resy = 1920;
				break;
			default:
				*resx = 848;
				*resy = 480;
				break;
			}
		}

		public unsafe void CreateCameraViewPort()
		{
			GEditorWorld* ptr = this.propWorld;
			if (ptr == null || *(byte*)(ptr + 3220 / sizeof(GEditorWorld)) != 0 || (this.CameraEyeCurveIndex != -1 && (!this.TargetUsed.Checked || this.CameraTargetCurveIndex != -1)))
			{
				bool* cameraViewPortExist = this.CameraViewPortExist;
				if (!(*cameraViewPortExist))
				{
					*cameraViewPortExist = true;
					ToolboxCameraViewport toolboxCameraViewport = new ToolboxCameraViewport(this.ToolWindows, this.CameraViewPortExist);
					this.CamViewport = toolboxCameraViewport;
					this.ToolWindows.Add(toolboxCameraViewport);
					this.CamViewport.Show();
				}
			}
		}

		public unsafe void RemoveCameraViewPort()
		{
			if (*this.CameraViewPortExist)
			{
				this.ToolWindows.Remove(this.CamViewport);
				this.CamViewport.Destroy();
			}
		}

		private void EntityList_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			this.EditLabel = false;
			if (e.Label != null)
			{
				this.SetEntityName(this.SelectedWorldIndex, e.Label);
			}
			this.EntityList.Items[this.SelectedItem].Selected = false;
			this.RefreshEntityList();
		}

		private unsafe void EntityList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.EntityList.SelectedIndices.Count > 0)
			{
				if (this.SelectedItem >= 0)
				{
					int selectedItem = this.SelectedItem;
					if (selectedItem != this.EntityList.SelectedIndices[0])
					{
						this.DeselectItem(this.EntityList.Items[selectedItem]);
					}
				}
				if (this.SelectedItem == this.EntityList.SelectedIndices[0])
				{
					this.EditLabel = true;
				}
				int num = this.EntityList.SelectedIndices[0];
				this.SelectedItem = num;
				object tag = this.EntityList.Items[num].Tag;
				int* ptr;
				if (tag is int)
				{
					ptr = ref (int)tag;
				}
				else
				{
					ptr = 0;
				}
				this.SelectedWorldIndex = *ptr;
				this.EntityList.Items[this.SelectedItem].Selected = false;
				this.SelectItem(this.EntityList.Items[this.SelectedItem]);
				<Module>.GEditorWorld.SelectAIGroup(this.propWorld, this.SelectedWorldIndex);
			}
			else
			{
				int selectedItem = this.SelectedItem;
				if (selectedItem >= 0)
				{
					this.DeselectItem(this.EntityList.Items[selectedItem]);
				}
			}
			this.RefreshScriptEntityProps(this.SelectedWorldIndex);
		}

		private unsafe void EntityList_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.SelectedItem >= 0 && this.EditLabel && e.Button == MouseButtons.Left)
			{
				int num = this.EntityList.Items[this.SelectedItem].Bounds.Left;
				int num2 = 0;
				int num3 = 1;
				if (1 < this.EntityList.Columns.Count)
				{
					do
					{
						num = this.EntityList.Columns[num3].Width + num;
						if (num > e.X)
						{
							goto IL_9F;
						}
						num3++;
					}
					while (num3 < this.EntityList.Columns.Count);
					goto IL_A2;
					IL_9F:
					num2 = num3;
				}
				IL_A2:
				switch (num2)
				{
				case 1:
					this.EntityList.Items[this.SelectedItem].Text = this.EntityList.Items[this.SelectedItem].SubItems[1].Text;
					this.EntityList.Items[this.SelectedItem].SubItems[1].Text = "";
					this.EntityList.Items[this.SelectedItem].Selected = true;
					this.EntityList.Items[this.SelectedItem].BeginEdit();
					break;
				case 2:
					if (this.SCEType == 6)
					{
						<Module>.GEditorWorld.SetObjectiveType(this.propWorld, this.SelectedWorldIndex, (<Module>.GEditorWorld.GetObjectiveType(this.propWorld, this.SelectedWorldIndex) + 1) % 3);
						this.RefreshEntityList();
						this.EditLabel = false;
					}
					else
					{
						Point pos = new Point(e.X, e.Y);
						this.ColorChooser.Show(this.EntityList, pos);
						this.EditLabel = false;
					}
					break;
				case 3:
				{
					int sCEType = this.SCEType;
					if (sCEType == 0)
					{
						<Module>.GEditorWorld.SetPathLooping(this.propWorld, this.SelectedWorldIndex, (<Module>.GEditorWorld.GetPathLooping(this.propWorld, this.SelectedWorldIndex) + 1) % 3);
						this.RefreshEntityList();
						this.EditLabel = false;
					}
					else if (sCEType == 2)
					{
						if (<Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(this.propWorld, this.SelectedWorldIndex) == null)
						{
							<Module>.?SetCameraCurveType@GEditorWorld@@$$FQAEXHW4GCameraCurveType@@@Z(this.propWorld, this.SelectedWorldIndex, 1);
						}
						else if (<Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(this.propWorld, this.SelectedWorldIndex) == 1)
						{
							<Module>.?SetCameraCurveType@GEditorWorld@@$$FQAEXHW4GCameraCurveType@@@Z(this.propWorld, this.SelectedWorldIndex, 0);
						}
						this.RefreshEntityList();
						this.EditLabel = false;
					}
					else if (sCEType == 4)
					{
						<Module>.GWorld.SetSectorActive(this.propWorld, this.SelectedWorldIndex, <Module>.GWorld.IsSectorInactive(this.propWorld, this.SelectedWorldIndex) != null);
						this.RefreshEntityList();
						this.EditLabel = false;
					}
					else if (sCEType == 1)
					{
						byte b = <Module>.GEditorWorld.GetLocationEffectRange(this.propWorld, this.SelectedWorldIndex) + 1;
						if (b > 4)
						{
							b = 1;
						}
						<Module>.GEditorWorld.SetLocationEffectRange(this.propWorld, this.SelectedWorldIndex, b);
						this.RefreshEntityList();
						this.EditLabel = false;
					}
					else if (sCEType == 6)
					{
						byte b2 = (<Module>.GEditorWorld.IsObjectiveActive(this.propWorld, this.SelectedWorldIndex) == 0) ? 1 : 0;
						<Module>.GEditorWorld.SetObjectiveActive(this.propWorld, this.SelectedWorldIndex, b2 != 0);
						this.EditLabel = false;
						this.RefreshEntityList();
					}
					else if (sCEType == 3)
					{
						int selectedWorldIndex = this.SelectedWorldIndex;
						GEditorWorld* ptr = this.propWorld + 3392 / sizeof(GEditorWorld);
						if (<Module>.GHeap<GWAIGroup>.Present(ptr, selectedWorldIndex) != null)
						{
							int num4 = *(int*)ptr + selectedWorldIndex * 392 + 63;
							int num5 = (*num4 == 0) ? 1 : 0;
							*num4 = (byte)num5;
							<Module>.GEditorWorld.PurgeAIGroup(this.propWorld, this.SelectedWorldIndex, null);
							this.RefreshEntityList();
							this.EditLabel = false;
						}
					}
					break;
				}
				case 4:
				{
					int sCEType2 = this.SCEType;
					if (sCEType2 == 4)
					{
						byte b3 = (<Module>.GWorld.IsSectorAISleep(this.propWorld, this.SelectedWorldIndex) == 0) ? 1 : 0;
						<Module>.GWorld.SetSectorAISleep(this.propWorld, this.SelectedWorldIndex, b3 != 0);
						this.RefreshEntityList();
						this.EditLabel = false;
					}
					else if (sCEType2 == 1)
					{
						byte b4 = (<Module>.GEditorWorld.IsLocationEventSource(this.propWorld, this.SelectedWorldIndex) == 0) ? 1 : 0;
						<Module>.GEditorWorld.SetLocationEventSource(this.propWorld, this.SelectedWorldIndex, b4 != 0);
						this.RefreshEntityList();
						this.EditLabel = false;
					}
					break;
				}
				}
			}
		}

		private void DrawColorSelector(object sender, DrawItemEventArgs e)
		{
			if (sender == this.Red)
			{
				Rectangle bounds = e.Bounds;
				Color color = Color.FromArgb(-57312);
				e.Graphics.FillRectangle(new SolidBrush(color), bounds);
			}
			else if (sender == this.Yellow)
			{
				Rectangle bounds2 = e.Bounds;
				Color color2 = Color.FromArgb(-224);
				e.Graphics.FillRectangle(new SolidBrush(color2), bounds2);
			}
			else if (sender == this.Green)
			{
				Rectangle bounds3 = e.Bounds;
				Color color3 = Color.FromArgb(-14614752);
				e.Graphics.FillRectangle(new SolidBrush(color3), bounds3);
			}
			else if (sender == this.Cyan)
			{
				Rectangle bounds4 = e.Bounds;
				Color color4 = Color.FromArgb(-14614529);
				e.Graphics.FillRectangle(new SolidBrush(color4), bounds4);
			}
			else if (sender == this.Blue)
			{
				Rectangle bounds5 = e.Bounds;
				Color color5 = Color.FromArgb(-14671617);
				e.Graphics.FillRectangle(new SolidBrush(color5), bounds5);
			}
			else if (sender == this.Magenta)
			{
				Rectangle bounds6 = e.Bounds;
				Color color6 = Color.FromArgb(-57089);
				e.Graphics.FillRectangle(new SolidBrush(color6), bounds6);
			}
			if ((e.State & DrawItemState.Selected) != DrawItemState.None)
			{
				Rectangle bounds7 = e.Bounds;
				Color color7 = Color.FromKnownColor(KnownColor.Highlight);
				e.Graphics.DrawRectangle(new Pen(color7, 2f), bounds7);
			}
			else
			{
				Rectangle bounds8 = e.Bounds;
				Color color8 = Color.FromKnownColor(KnownColor.Window);
				e.Graphics.DrawRectangle(new Pen(color8, 2f), bounds8);
			}
		}

		private void MeasureColorSelector(object sender, MeasureItemEventArgs e)
		{
			e.ItemWidth = this.EntityColor.Width - 12;
			e.ItemHeight = this.EntityList.Items[this.SelectedItem].Bounds.Height + 2;
		}

		private void ColorSelected(object sender, EventArgs e)
		{
			uint num = 0u;
			if (sender == this.Red)
			{
				num = 16719904u;
			}
			else if (sender == this.Yellow)
			{
				num = 16776992u;
			}
			else if (sender == this.Green)
			{
				num = 2162464u;
			}
			else if (sender == this.Cyan)
			{
				num = 2162687u;
			}
			else if (sender == this.Blue)
			{
				num = 2105599u;
			}
			else if (sender == this.Magenta)
			{
				num = 16720127u;
			}
			switch (this.SCEType)
			{
			case 0:
				<Module>.GEditorWorld.SetPathColor(this.propWorld, this.SelectedWorldIndex, num);
				break;
			case 1:
				<Module>.GEditorWorld.SetLocationColor(this.propWorld, this.SelectedWorldIndex, (int)num);
				break;
			case 2:
				<Module>.GEditorWorld.SetCameraCurveColor(this.propWorld, this.SelectedWorldIndex, num);
				break;
			case 3:
				<Module>.GEditorWorld.SetAIGroupColor(this.propWorld, this.SelectedWorldIndex, num);
				break;
			case 4:
				<Module>.GEditorWorld.SetSectorColor(this.propWorld, this.SelectedWorldIndex, num);
				break;
			}
			this.RefreshEntityList();
		}

		private void ShowCheck_CheckedChanged(object sender, EventArgs e)
		{
			switch (this.SCEType)
			{
			case 0:
				<Module>.GWorld.AlwaysDrawPaths(this.propWorld, this.ShowCheck.Checked);
				break;
			case 1:
				<Module>.GWorld.AlwaysDrawLocations(this.propWorld, this.ShowCheck.Checked);
				break;
			case 2:
				<Module>.GEditorWorld.AlwaysDrawCameraCurves(this.propWorld, this.ShowCheck.Checked);
				break;
			case 3:
				<Module>.GEditorWorld.AlwaysDrawAIGroups(this.propWorld, this.ShowCheck.Checked);
				break;
			case 4:
				<Module>.GEditorWorld.AlwaysDrawSectors(this.propWorld, this.ShowCheck.Checked);
				break;
			}
		}

		private void RangeEdit_TextChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing && this.RangeEdit.Text.Length > 0)
			{
				this.RangeEdit_Validated(null, null);
			}
		}

		private unsafe void BehaviorList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing)
			{
				GEditorWorld* ptr = this.propWorld;
				if (ptr != null)
				{
					int selectedWorldIndex = this.SelectedWorldIndex;
					if (selectedWorldIndex >= 0)
					{
						GAIGroupProps selectedIndex;
						<Module>.GEditorWorld.GetAIGroupProps(ptr, &selectedIndex, selectedWorldIndex);
						selectedIndex = this.BehaviorList.SelectedIndex;
						<Module>.GEditorWorld.SetAIGroupProps(this.propWorld, this.SelectedWorldIndex, ref selectedIndex);
					}
				}
			}
		}

		private unsafe void BraveryList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing)
			{
				GEditorWorld* ptr = this.propWorld;
				if (ptr != null)
				{
					int selectedWorldIndex = this.SelectedWorldIndex;
					if (selectedWorldIndex >= 0)
					{
						GAIGroupProps gAIGroupProps;
						<Module>.GEditorWorld.GetAIGroupProps(ptr, &gAIGroupProps, selectedWorldIndex);
						*(ref gAIGroupProps + 16) = this.BraveryList.SelectedIndex;
						<Module>.GEditorWorld.SetAIGroupProps(this.propWorld, this.SelectedWorldIndex, ref gAIGroupProps);
					}
				}
			}
		}

		private unsafe void HelpTypeList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing)
			{
				GEditorWorld* ptr = this.propWorld;
				if (ptr != null)
				{
					int selectedWorldIndex = this.SelectedWorldIndex;
					if (selectedWorldIndex >= 0)
					{
						GAIGroupProps gAIGroupProps;
						<Module>.GEditorWorld.GetAIGroupProps(ptr, &gAIGroupProps, selectedWorldIndex);
						*(ref gAIGroupProps + 12) = 0;
						if (this.HelpTypeList.GetSelected(0))
						{
							*(ref gAIGroupProps + 12) = (*(ref gAIGroupProps + 12) | 1);
						}
						if (this.HelpTypeList.GetSelected(1))
						{
							*(ref gAIGroupProps + 12) = (*(ref gAIGroupProps + 12) | 2);
						}
						if (this.HelpTypeList.GetSelected(2))
						{
							*(ref gAIGroupProps + 12) = (*(ref gAIGroupProps + 12) | 4);
						}
						if (this.HelpTypeList.GetSelected(3))
						{
							*(ref gAIGroupProps + 12) = (*(ref gAIGroupProps + 12) | 8);
						}
						if (this.HelpTypeList.GetSelected(4))
						{
							*(ref gAIGroupProps + 12) = (*(ref gAIGroupProps + 12) | 16);
						}
						if (this.HelpTypeList.GetSelected(5))
						{
							*(ref gAIGroupProps + 12) = (*(ref gAIGroupProps + 12) | 32);
						}
						if (this.HelpTypeList.GetSelected(6))
						{
							*(ref gAIGroupProps + 12) = (*(ref gAIGroupProps + 12) | 64);
						}
						<Module>.GEditorWorld.SetAIGroupProps(this.propWorld, this.SelectedWorldIndex, ref gAIGroupProps);
					}
				}
			}
		}

		private unsafe void FallbackList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing)
			{
				GEditorWorld* ptr = this.propWorld;
				if (ptr != null)
				{
					int selectedWorldIndex = this.SelectedWorldIndex;
					if (selectedWorldIndex >= 0)
					{
						GAIGroupProps gAIGroupProps;
						<Module>.GEditorWorld.GetAIGroupProps(ptr, &gAIGroupProps, selectedWorldIndex);
						if (this.FallbackList.SelectedIndex == 0)
						{
							*(ref gAIGroupProps + 24) = -1;
						}
						else if (this.FallbackList.SelectedIndex == 1)
						{
							*(ref gAIGroupProps + 24) = -2;
						}
						else
						{
							*(ref gAIGroupProps + 24) = this.Locations[this.FallbackList.SelectedIndex - 2];
						}
						<Module>.GEditorWorld.SetAIGroupProps(this.propWorld, this.SelectedWorldIndex, ref gAIGroupProps);
					}
				}
			}
		}

		private unsafe void RangeEdit_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			GEditorWorld* ptr = this.propWorld;
			if (ptr != null)
			{
				int selectedWorldIndex = this.SelectedWorldIndex;
				if (selectedWorldIndex >= 0)
				{
					GAIGroupProps gAIGroupProps;
					<Module>.GEditorWorld.GetAIGroupProps(ptr, &gAIGroupProps, selectedWorldIndex);
					float num2 = 0f;
					try
					{
						num2 = (float)(double.Parse(this.RangeEdit.Text) * <Module>.Measures);
						goto IL_BD;
					}
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
					IL_BD:
					*(ref gAIGroupProps + 4) = num2;
					<Module>.GEditorWorld.SetAIGroupProps(this.propWorld, this.SelectedWorldIndex, ref gAIGroupProps);
				}
			}
		}

		private unsafe void MaxHelpNumeric_ValueChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing)
			{
				GEditorWorld* ptr = this.propWorld;
				if (ptr != null)
				{
					int selectedWorldIndex = this.SelectedWorldIndex;
					if (selectedWorldIndex >= 0)
					{
						GAIGroupProps gAIGroupProps;
						<Module>.GEditorWorld.GetAIGroupProps(ptr, &gAIGroupProps, selectedWorldIndex);
						decimal value = this.MaxHelpNumeric.Value;
						*(ref gAIGroupProps + 20) = decimal.ToInt32(value);
						<Module>.GEditorWorld.SetAIGroupProps(this.propWorld, this.SelectedWorldIndex, ref gAIGroupProps);
					}
				}
			}
		}

		private unsafe void DescriptionEdit_Validated(object sender, EventArgs e)
		{
			if (this.propWorld != null && this.SelectedWorldIndex >= 0)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.DescriptionEdit.Text);
				GEditorWorld* ptr2;
				int selectedWorldIndex;
				try
				{
					ptr2 = this.propWorld;
					selectedWorldIndex = this.SelectedWorldIndex;
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
					throw;
				}
				<Module>.GEditorWorld.SetObjectiveDescription(ptr2, selectedWorldIndex, ptr);
			}
		}

		private void DescriptionEdit_TextChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing)
			{
				this.DescriptionEdit_Validated(null, null);
			}
		}

		private void ObjLocList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ObjLocList.SelectedIndex >= 0)
			{
				this.ObjPathList.SelectedIndex = -1;
			}
		}

		private void ObjPathList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.ObjPathList.SelectedIndex >= 0)
			{
				this.ObjLocList.SelectedIndex = -1;
			}
		}

		private unsafe void AddBtn_Click(object sender, EventArgs e)
		{
			if (this.propWorld != null && this.SelectedWorldIndex >= 0)
			{
				GObjectiveTarget gObjectiveTarget;
				if (this.ObjLocList.SelectedIndex >= 0)
				{
					*(ref gObjectiveTarget + 4) = 0;
					gObjectiveTarget = this.Locations[this.ObjLocList.SelectedIndex];
				}
				else
				{
					if (this.ObjPathList.SelectedIndex < 0)
					{
						return;
					}
					*(ref gObjectiveTarget + 4) = 1;
					gObjectiveTarget = this.Paths[this.ObjPathList.SelectedIndex];
				}
				<Module>.GEditorWorld.AddTargetToObjective(this.propWorld, this.SelectedWorldIndex, ref gObjectiveTarget);
				this.RefreshEntityList();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (this.propWorld != null && this.SelectedWorldIndex >= 0 && this.TargetList.SelectedIndex >= 0)
			{
				<Module>.GEditorWorld.RemoveTargetFromObjective(this.propWorld, this.SelectedWorldIndex, this.Targets[this.TargetList.SelectedIndex]);
				this.RefreshEntityList();
			}
		}

		private void RewardNumeric_ValueChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing && this.propWorld != null && this.SelectedWorldIndex >= 0)
			{
				decimal value = this.RewardNumeric.Value;
				<Module>.GEditorWorld.SetObjectiveReward(this.propWorld, this.SelectedWorldIndex, decimal.ToInt32(value));
			}
		}

		private unsafe void TimeCurveButton_Click(object sender, EventArgs e)
		{
			GEditorWorld* ptr = this.propWorld;
			if (ptr != null && this.CameraEyeCurveIndex >= 0 && *(byte*)(ptr + 3220 / sizeof(GEditorWorld)) == 0)
			{
				GBaseString<char> gBaseString<char>;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_0M@ONDGBKLB@Time?$CF?5Curve?$AA@));
				try
				{
					new ToolboxCurveEditor(0, this.CameraEyeCurveIndex, this.propWorld, &gBaseString<char>, 0f, 1f).ShowDialog();
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

		private unsafe void FOVCurveButton_Click(object sender, EventArgs e)
		{
			GEditorWorld* ptr = this.propWorld;
			if (ptr != null && this.CameraEyeCurveIndex >= 0 && *(byte*)(ptr + 3220 / sizeof(GEditorWorld)) == 0)
			{
				GBaseString<char> gBaseString<char>;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_09ODDABLAP@FOV?5Curve?$AA@));
				try
				{
					new ToolboxCurveEditor(1, this.CameraEyeCurveIndex, this.propWorld, &gBaseString<char>, 0f, 180f).ShowDialog();
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

		private unsafe void RollCurveButton_Click(object sender, EventArgs e)
		{
			GEditorWorld* ptr = this.propWorld;
			if (ptr != null && this.CameraEyeCurveIndex >= 0 && *(byte*)(ptr + 3220 / sizeof(GEditorWorld)) == 0)
			{
				GBaseString<char> gBaseString<char>;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_0L@FHNGHPLJ@Roll?5Curve?$AA@));
				try
				{
					new ToolboxCurveEditor(2, this.CameraEyeCurveIndex, this.propWorld, &gBaseString<char>, -180f, 180f).ShowDialog();
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

		private void CamBeginButton_Click(object sender, EventArgs e)
		{
			this.CameraStatus = 0;
			this.CameraPlayPosition = 0f;
		}

		private void CamRewindButton_Click(object sender, EventArgs e)
		{
			this.CameraStatus = 2;
		}

		private void CamPauseButton_Click(object sender, EventArgs e)
		{
			this.CameraStatus = 0;
		}

		private void CamPlayButton_Click(object sender, EventArgs e)
		{
			this.CameraStatus = 1;
		}

		private void CamForwardButton_Click(object sender, EventArgs e)
		{
			this.CameraStatus = 3;
		}

		private void EyeCurveSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.propWorld != null && this.CameraEyeCurveSelectedIdx != this.EyeCurveSelect.SelectedIndex)
			{
				this.CameraEyeCurveSelectedIdx = this.EyeCurveSelect.SelectedIndex;
				this.RefreshCameraCurveIndex();
				this.CameraStatus = 0;
				this.CameraPlayPosition = 0f;
			}
		}

		private void TargetCurveSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.propWorld != null && this.CameraTargetCurveSelectedIdx != this.TargetCurveSelect.SelectedIndex)
			{
				this.CameraTargetCurveSelectedIdx = this.TargetCurveSelect.SelectedIndex;
				this.RefreshCameraCurveIndex();
			}
		}

		private void CurveDuration_TextChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing && this.CurveDuration.Text.Length > 0)
			{
				this.CurveDuration_Validated(null, null);
			}
		}

		private unsafe void CurveDuration_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			if (this.propWorld != null && this.CameraEyeCurveIndex >= 0)
			{
				float num2 = 0f;
				try
				{
					num2 = (float)double.Parse(this.CurveDuration.Text);
					goto IL_A8;
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
				IL_A8:
				<Module>.GWorld.SetCameraCurveDuration(this.propWorld, this.CameraEyeCurveIndex, num2);
			}
		}

		private void CurveDebugStart_TextChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing && this.CurveDebugStart.Text.Length > 0)
			{
				this.CurveDebugStart_Validated(null, null);
			}
		}

		private unsafe void CurveDebugStart_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			if (this.propWorld != null && this.CameraEyeCurveIndex >= 0)
			{
				float num2 = 0f;
				try
				{
					num2 = (float)double.Parse(this.CurveDebugStart.Text);
					goto IL_A8;
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
				IL_A8:
				<Module>.GWorld.SetCameraCurveDebugStart(this.propWorld, this.CameraEyeCurveIndex, num2);
			}
		}

		private void CurvePositionTrack_Scroll(object sender, EventArgs e)
		{
			this.CameraStatus = 0;
			float num = (float)this.CurvePositionTrack.Value;
			this.SetCameraCurvePosPercent(num / (float)this.CurvePositionTrack.Maximum);
		}

		private void TargetUsed_CheckedChanged(object sender, EventArgs e)
		{
			this.RefreshCameraCurveIndex();
		}

		private void ShowViewport_CheckedChanged(object sender, EventArgs e)
		{
			if (this.ShowViewport.Checked)
			{
				this.CreateCameraViewPort();
			}
			else
			{
				this.RemoveCameraViewPort();
			}
		}

		private void ToolboxScriptEntities_Paint(object sender, PaintEventArgs e)
		{
		}

		private unsafe void AddTargetCurve_Click(object sender, EventArgs e)
		{
			GEditorWorld* ptr = this.propWorld;
			if (ptr != null)
			{
				int cameraEyeCurveIndex = this.CameraEyeCurveIndex;
				if (cameraEyeCurveIndex >= 0)
				{
					int cameraTargetCurveIndex = this.CameraTargetCurveIndex;
					if (cameraTargetCurveIndex >= 0)
					{
						<Module>.GEditorWorld.AddToCameraCurveTargetList(ptr, cameraEyeCurveIndex, cameraTargetCurveIndex);
						this.LinkedTarget.Visible = true;
					}
				}
			}
		}

		private unsafe void RemoveTargetCurve_Click(object sender, EventArgs e)
		{
			GEditorWorld* ptr = this.propWorld;
			if (ptr != null)
			{
				int cameraEyeCurveIndex = this.CameraEyeCurveIndex;
				if (cameraEyeCurveIndex >= 0)
				{
					int cameraTargetCurveIndex = this.CameraTargetCurveIndex;
					if (cameraTargetCurveIndex >= 0)
					{
						<Module>.GEditorWorld.RemoveFromCameraCurveTargetList(ptr, cameraEyeCurveIndex, cameraTargetCurveIndex);
						this.LinkedTarget.Visible = false;
					}
				}
			}
		}

		private void HelpRangeEdit_TextChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing && this.HelpRangeEdit.Text.Length > 0)
			{
				this.HelpRangeEdit_Validated(null, null);
			}
		}

		private unsafe void HelpRangeEdit_Validated(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			GEditorWorld* ptr = this.propWorld;
			if (ptr != null)
			{
				int selectedWorldIndex = this.SelectedWorldIndex;
				if (selectedWorldIndex >= 0)
				{
					GAIGroupProps gAIGroupProps;
					<Module>.GEditorWorld.GetAIGroupProps(ptr, &gAIGroupProps, selectedWorldIndex);
					float num2 = 0f;
					try
					{
						num2 = (float)(double.Parse(this.HelpRangeEdit.Text) * <Module>.Measures);
						goto IL_BD;
					}
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
					IL_BD:
					*(ref gAIGroupProps + 8) = num2;
					<Module>.GEditorWorld.SetAIGroupProps(this.propWorld, this.SelectedWorldIndex, ref gAIGroupProps);
				}
			}
		}

		private unsafe void VehiclesCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing)
			{
				GEditorWorld* ptr = this.propWorld;
				if (ptr != null)
				{
					int selectedWorldIndex = this.SelectedWorldIndex;
					if (selectedWorldIndex >= 0)
					{
						GAIGroupProps gAIGroupProps;
						<Module>.GEditorWorld.GetAIGroupProps(ptr, &gAIGroupProps, selectedWorldIndex);
						*(ref gAIGroupProps + 28) = (this.VehiclesCheck.Checked ? 1 : 0);
						<Module>.GEditorWorld.SetAIGroupProps(this.propWorld, this.SelectedWorldIndex, ref gAIGroupProps);
					}
				}
			}
		}

		private unsafe void BuildingsCheck_CheckedChanged(object sender, EventArgs e)
		{
			if (!this.PropsRefreshing)
			{
				GEditorWorld* ptr = this.propWorld;
				if (ptr != null)
				{
					int selectedWorldIndex = this.SelectedWorldIndex;
					if (selectedWorldIndex >= 0)
					{
						GAIGroupProps gAIGroupProps;
						<Module>.GEditorWorld.GetAIGroupProps(ptr, &gAIGroupProps, selectedWorldIndex);
						*(ref gAIGroupProps + 29) = (this.BuildingsCheck.Checked ? 1 : 0);
						<Module>.GEditorWorld.SetAIGroupProps(this.propWorld, this.SelectedWorldIndex, ref gAIGroupProps);
					}
				}
			}
		}
	}
}
