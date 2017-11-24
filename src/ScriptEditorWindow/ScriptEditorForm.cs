using <CppImplementationDetails>;
using NWorkshop;
using Script_ActionListTree;
using Script_ActionListTree_Node;
using Script_GlobalVariable;
using Script_GlobalVariable_Header;
using Script_GlobalVariable_ListItem;
using ScriptEditor;
using ScriptVariablePropertiesWindow;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScriptEditorWindow
{
	public class ScriptEditorForm : Form
	{
		private enum eDragType
		{
			DRAG_MAX = 4,
			DRAG_Trigger = 3,
			DRAG_Entity = 2,
			DRAG_LocalVariable = 1,
			DRAG_GlobalVariable = 0
		}

		private int ScriptIndex;

		private unsafe cEditor* Editor;

		private unsafe GStreamBuffer* ClipboardStream;

		private ScriptEditorForm.eDragType DragType;

		private int DragIndex;

		private int ListSelection_ValueType;

		private int[] ScriptEntities_List;

		private int SelectedTriggerIndex;

		private MenuItem menuItem1;

		private MenuItem GlobalVariable_Create;

		private MenuItem GlobalVariable_Delete;

		private ContextMenu GlobalVariables_ContextMenu;

		private ContextMenu Triggers_ContextMenu;

		private MenuItem Trigger_Create;

		private MenuItem Trigger_Delete;

		private MenuItem Script_New;

		private MenuItem Script_Save;

		private MenuItem Script_SaveAs;

		private MenuItem Script_Close;

		private MenuItem menuItem3;

		private Script_GlobalVariableControl GlobalVariableControl;

		private Script_GlobalVariableControl TriggerVariableControl;

		private Script_GlobalVariableControl GlobalTriggerControl;

		private Script_GlobalVariableControl ScriptEntitiesControl;

		private ListBox ScriptEntitiesFilterBox;

		private Script_GlobalVariableControl_Header TV_Name;

		private Script_GlobalVariableControl_Header TV_Type;

		private Script_GlobalVariableControl_Header TV_Value;

		private Script_GlobalVariableControl_Header GLV_Name;

		private Script_GlobalVariableControl_Header GLV_Type;

		private Script_GlobalVariableControl_Header GLV_Value;

		private Script_GlobalVariableControl_Header GLV_Used;

		private Script_GlobalVariableControl_Header GT_Name;

		private Script_GlobalVariableControl_Header GT_Event;

		private Script_GlobalVariableControl_Header SEN_Name;

		private Script_GlobalVariableControl_Header SEN_Type;

		private Script_GlobalVariableControl_Header SEN_Value;

		private Script_GlobalVariableControl_Header SEN_Used;

		private Label TriggerActionListLabel;

		private Label GlobalVariablesLabel;

		private Label ScriptEntitiesFilterLabel;

		private Label ScriptEntitiesLabel;

		private Label TriggerVariablesLabel;

		private GroupBox TriggerGroup;

		private GroupBox GlobalGroupBox;

		private Script_GlobalVariableControl_Header GT_Active;

		private Script_GlobalVariableControl_Header TV_Used;

		private MainMenu MainMenu;

		private Label ActionType_Label;

		private Label ConditionType_Label;

		private Button AddActionButton;

		private Button DeleteActionButton;

		private Button AddConditionButton;

		private Button DeleteConditionButton;

		private Button DeleteActionBlockButton;

		private Button DeleteConditionBlockButton;

		private TextBox StatusLine;

		private Script_ActionListTreeControl ActionListTreeControl;

		private Button NegateConditionButton;

		private ContextMenu TriggerVariables_ContextMenu;

		private MenuItem TriggerVariable_Create;

		private MenuItem TriggerVariable_Delete;

		private ListBox ActionTypeBox;

		private ListBox ConditionTypeBox;

		private Button DeleteActionPartButton;

		private MenuItem menuItem2;

		private MenuItem MainMenu_Scripts;

		private MenuItem Edit_Undo;

		private MenuItem Edit_Redo;

		private MenuItem menuItem5;

		private MenuItem Edit_Copy;

		private MenuItem Edit_Cut;

		private MenuItem Edit_Paste;

		private MenuItem Edit_Clear;

		private MenuItem menuItem6;

		private MenuItem Script_Import;

		private MenuItem Script_Export;

		private MenuItem Script_Delete;

		private Button InsertSingleOrConditionButton;

		private MenuItem Trigger_Copy;

		private ContextMenu ActionList_ContextMenu;

		private MenuItem Actions_Insert;

		private MenuItem Actions_Delete;

		private MenuItem menuItem7;

		private MenuItem TriggerVariable_MoveUp;

		private MenuItem TriggerVariable_MoveDown;

		private MenuItem TriggerVariable_FixOrder;

		private MenuItem menuItem7a;

		private MenuItem GlobalVariable_MoveUp;

		private MenuItem GlobalVariable_MoveDown;

		private MenuItem GlobalVariable_FixOrder;

		private MenuItem menuItem8;

		private MenuItem Edit_Refresh;

		private MenuItem Trigger_Create_Empty;

		private MenuItem menuItem9;

		private MenuItem Trigger_FixOrder;

		private MenuItem Trigger_MoveUp;

		private MenuItem Trigger_MoveDown;

		private CheckBox ScriptEntities_ShowStoredUnits;

		private Container components;

		public ScriptEditorForm()
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
			this.MainMenu = new MainMenu();
			this.menuItem1 = new MenuItem();
			this.Script_New = new MenuItem();
			this.Script_Save = new MenuItem();
			this.Script_Delete = new MenuItem();
			this.menuItem3 = new MenuItem();
			this.Script_Import = new MenuItem();
			this.Script_Export = new MenuItem();
			this.menuItem6 = new MenuItem();
			this.Script_Close = new MenuItem();
			this.menuItem2 = new MenuItem();
			this.Edit_Undo = new MenuItem();
			this.Edit_Redo = new MenuItem();
			this.menuItem5 = new MenuItem();
			this.Edit_Cut = new MenuItem();
			this.Edit_Copy = new MenuItem();
			this.Edit_Paste = new MenuItem();
			this.Edit_Clear = new MenuItem();
			this.menuItem8 = new MenuItem();
			this.Edit_Refresh = new MenuItem();
			this.MainMenu_Scripts = new MenuItem();
			this.Script_SaveAs = new MenuItem();
			this.GlobalGroupBox = new GroupBox();
			this.GlobalTriggerControl = new Script_GlobalVariableControl();
			this.GT_Name = new Script_GlobalVariableControl_Header();
			this.GT_Event = new Script_GlobalVariableControl_Header();
			this.GT_Active = new Script_GlobalVariableControl_Header();
			this.Triggers_ContextMenu = new ContextMenu();
			this.Trigger_Create = new MenuItem();
			this.Trigger_Create_Empty = new MenuItem();
			this.Trigger_Copy = new MenuItem();
			this.Trigger_Delete = new MenuItem();
			this.menuItem9 = new MenuItem();
			this.Trigger_MoveUp = new MenuItem();
			this.Trigger_MoveDown = new MenuItem();
			this.Trigger_FixOrder = new MenuItem();
			this.GlobalVariablesLabel = new Label();
			this.GlobalVariableControl = new Script_GlobalVariableControl();
			this.GLV_Name = new Script_GlobalVariableControl_Header();
			this.GLV_Type = new Script_GlobalVariableControl_Header();
			this.GLV_Value = new Script_GlobalVariableControl_Header();
			this.GLV_Used = new Script_GlobalVariableControl_Header();
			this.GlobalVariables_ContextMenu = new ContextMenu();
			this.GlobalVariable_Create = new MenuItem();
			this.GlobalVariable_Delete = new MenuItem();
			this.ScriptEntitiesLabel = new Label();
			this.ScriptEntitiesControl = new Script_GlobalVariableControl();
			this.SEN_Name = new Script_GlobalVariableControl_Header();
			this.SEN_Type = new Script_GlobalVariableControl_Header();
			this.SEN_Value = new Script_GlobalVariableControl_Header();
			this.SEN_Used = new Script_GlobalVariableControl_Header();
			this.ScriptEntitiesFilterLabel = new Label();
			this.ScriptEntitiesFilterBox = new ListBox();
			this.TriggerGroup = new GroupBox();
			this.InsertSingleOrConditionButton = new Button();
			this.DeleteActionPartButton = new Button();
			this.ConditionTypeBox = new ListBox();
			this.ActionTypeBox = new ListBox();
			this.NegateConditionButton = new Button();
			this.DeleteConditionBlockButton = new Button();
			this.DeleteActionBlockButton = new Button();
			this.DeleteConditionButton = new Button();
			this.AddConditionButton = new Button();
			this.DeleteActionButton = new Button();
			this.AddActionButton = new Button();
			this.ConditionType_Label = new Label();
			this.ActionType_Label = new Label();
			this.ActionListTreeControl = new Script_ActionListTreeControl();
			this.ActionList_ContextMenu = new ContextMenu();
			this.Actions_Insert = new MenuItem();
			this.Actions_Delete = new MenuItem();
			this.TriggerActionListLabel = new Label();
			this.TriggerVariablesLabel = new Label();
			this.TriggerVariableControl = new Script_GlobalVariableControl();
			this.TV_Name = new Script_GlobalVariableControl_Header();
			this.TV_Type = new Script_GlobalVariableControl_Header();
			this.TV_Value = new Script_GlobalVariableControl_Header();
			this.TV_Used = new Script_GlobalVariableControl_Header();
			this.TriggerVariables_ContextMenu = new ContextMenu();
			this.TriggerVariable_Create = new MenuItem();
			this.TriggerVariable_Delete = new MenuItem();
			this.menuItem7 = new MenuItem();
			this.TriggerVariable_MoveUp = new MenuItem();
			this.TriggerVariable_MoveDown = new MenuItem();
			this.TriggerVariable_FixOrder = new MenuItem();
			this.menuItem7a = new MenuItem();
			this.GlobalVariable_MoveUp = new MenuItem();
			this.GlobalVariable_MoveDown = new MenuItem();
			this.GlobalVariable_FixOrder = new MenuItem();
			this.StatusLine = new TextBox();
			this.ScriptEntities_ShowStoredUnits = new CheckBox();
			this.GlobalGroupBox.SuspendLayout();
			this.TriggerGroup.SuspendLayout();
			base.SuspendLayout();
			MenuItem[] items = new MenuItem[]
			{
				this.menuItem1,
				this.menuItem2,
				this.MainMenu_Scripts
			};
			this.MainMenu.MenuItems.AddRange(items);
			this.menuItem1.Index = 0;
			MenuItem[] items2 = new MenuItem[]
			{
				this.Script_New,
				this.Script_Save,
				this.Script_Delete,
				this.menuItem3,
				this.Script_Import,
				this.Script_Export,
				this.menuItem6,
				this.Script_Close
			};
			this.menuItem1.MenuItems.AddRange(items2);
			this.menuItem1.Text = "File";
			this.Script_New.Index = 0;
			this.Script_New.Shortcut = Shortcut.CtrlN;
			this.Script_New.Text = "New";
			this.Script_New.Click += new EventHandler(this.Script_New_Click);
			this.Script_Save.Index = 1;
			this.Script_Save.Shortcut = Shortcut.CtrlS;
			this.Script_Save.Text = "Save";
			this.Script_Save.Click += new EventHandler(this.Script_Save_Click);
			this.Script_Delete.Index = 2;
			this.Script_Delete.Shortcut = Shortcut.CtrlDel;
			this.Script_Delete.Text = "Delete";
			this.Script_Delete.Click += new EventHandler(this.Script_Delete_Click);
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "-";
			this.Script_Import.Index = 4;
			this.Script_Import.Text = "Import...";
			this.Script_Import.Click += new EventHandler(this.Script_Import_Click);
			this.Script_Export.Index = 5;
			this.Script_Export.Text = "Export...";
			this.Script_Export.Click += new EventHandler(this.Script_Export_Click);
			this.menuItem6.Index = 6;
			this.menuItem6.Text = "-";
			this.Script_Close.Index = 7;
			this.Script_Close.Text = "Close";
			this.Script_Close.Click += new EventHandler(this.Script_Close_Click);
			this.menuItem2.Index = 1;
			MenuItem[] items3 = new MenuItem[]
			{
				this.Edit_Undo,
				this.Edit_Redo,
				this.menuItem5,
				this.Edit_Cut,
				this.Edit_Copy,
				this.Edit_Paste,
				this.Edit_Clear,
				this.menuItem8,
				this.Edit_Refresh
			};
			this.menuItem2.MenuItems.AddRange(items3);
			this.menuItem2.Text = "Edit";
			this.Edit_Undo.Enabled = false;
			this.Edit_Undo.Index = 0;
			this.Edit_Undo.Shortcut = Shortcut.CtrlZ;
			this.Edit_Undo.Text = "Undo";
			this.Edit_Undo.Click += new EventHandler(this.Edit_Undo_Click);
			this.Edit_Redo.Enabled = false;
			this.Edit_Redo.Index = 1;
			this.Edit_Redo.Shortcut = Shortcut.CtrlY;
			this.Edit_Redo.Text = "Redo";
			this.Edit_Redo.Click += new EventHandler(this.Edit_Redo_Click);
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "-";
			this.Edit_Cut.Index = 3;
			this.Edit_Cut.Shortcut = Shortcut.CtrlX;
			this.Edit_Cut.Text = "Cut";
			this.Edit_Cut.Click += new EventHandler(this.Edit_Cut_Click);
			this.Edit_Copy.Index = 4;
			this.Edit_Copy.Shortcut = Shortcut.CtrlC;
			this.Edit_Copy.Text = "Copy";
			this.Edit_Copy.Click += new EventHandler(this.Edit_Copy_Click);
			this.Edit_Paste.Index = 5;
			this.Edit_Paste.Shortcut = Shortcut.CtrlV;
			this.Edit_Paste.Text = "Paste";
			this.Edit_Paste.Click += new EventHandler(this.Edit_Paste_Click);
			this.Edit_Clear.Index = 6;
			this.Edit_Clear.Text = "Clear";
			this.Edit_Clear.Click += new EventHandler(this.Edit_Clear_Click);
			this.menuItem8.Index = 7;
			this.menuItem8.Text = "-";
			this.Edit_Refresh.Index = 8;
			this.Edit_Refresh.Shortcut = Shortcut.CtrlR;
			this.Edit_Refresh.Text = "Refresh";
			this.Edit_Refresh.Click += new EventHandler(this.Edit_Refresh_Click);
			this.MainMenu_Scripts.Index = 2;
			this.MainMenu_Scripts.Text = "Scripts";
			this.Script_SaveAs.Index = -1;
			this.Script_SaveAs.Text = "";
			this.GlobalGroupBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			this.GlobalGroupBox.Controls.Add(this.GlobalTriggerControl);
			Point location = new Point(8, 8);
			this.GlobalGroupBox.Location = location;
			this.GlobalGroupBox.Name = "GlobalGroupBox";
			Size size = new Size(296, 712);
			this.GlobalGroupBox.Size = size;
			this.GlobalGroupBox.TabIndex = 6;
			this.GlobalGroupBox.TabStop = false;
			this.GlobalGroupBox.Text = "Triggers";
			this.GlobalTriggerControl.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			Color window = SystemColors.Window;
			this.GlobalTriggerControl.BackColor = window;
			Script_GlobalVariableControl_Header[] columnHeaders = new Script_GlobalVariableControl_Header[]
			{
				this.GT_Name,
				this.GT_Event,
				this.GT_Active
			};
			this.GlobalTriggerControl.ColumnHeaders = columnHeaders;
			this.GlobalTriggerControl.ContextMenu = this.Triggers_ContextMenu;
			this.GlobalTriggerControl.DrawGrid = true;
			this.GlobalTriggerControl.HeaderHeight = 18;
			this.GlobalTriggerControl.Items = new Script_GlobalVariableControl_ListItem[0];
			Point location2 = new Point(8, 16);
			this.GlobalTriggerControl.Location = location2;
			this.GlobalTriggerControl.Name = "GlobalTriggerControl";
			this.GlobalTriggerControl.RealSelectedIndex = -1;
			this.GlobalTriggerControl.RowHeight = 14;
			this.GlobalTriggerControl.SelectedIndex = -1;
			Size size2 = new Size(280, 686);
			this.GlobalTriggerControl.Size = size2;
			this.GlobalTriggerControl.TabIndex = 6;
			this.GlobalTriggerControl.DragStarted += new EventHandler(this.GlobalTriggerControl_DragStarted);
			this.GlobalTriggerControl.SortModeChanged += new EventHandler(this.GlobalTriggerControl_SortModeChanged);
			this.GlobalTriggerControl.ItemClicked += new EventHandler(this.GlobalTriggerControl_ItemClicked);
			this.GlobalTriggerControl.ItemDoubleClicked += new EventHandler(this.GlobalTriggerControl_ItemDoubleClicked);
			this.GlobalTriggerControl.SelectedIndexChanged += new EventHandler(this.GlobalTriggerControl_SelectedIndexChanged);
			this.GT_Name.Text = "Name";
			this.GT_Name.Width = 150;
			this.GT_Event.Text = "Event";
			this.GT_Event.Width = 78;
			this.GT_Active.Text = "Act.";
			this.GT_Active.Width = 30;
			MenuItem[] items4 = new MenuItem[]
			{
				this.Trigger_Create,
				this.Trigger_Create_Empty,
				this.Trigger_Copy,
				this.Trigger_Delete,
				this.menuItem9,
				this.Trigger_MoveUp,
				this.Trigger_MoveDown,
				this.Trigger_FixOrder
			};
			this.Triggers_ContextMenu.MenuItems.AddRange(items4);
			this.Trigger_Create.Index = 0;
			this.Trigger_Create.Shortcut = Shortcut.Ins;
			this.Trigger_Create.Text = "Create trigger";
			this.Trigger_Create.Click += new EventHandler(this.Trigger_Create_Click);
			this.Trigger_Create_Empty.Index = 1;
			this.Trigger_Create_Empty.Text = "Create empty trigger";
			this.Trigger_Create_Empty.Click += new EventHandler(this.Trigger_Create_Empty_Click);
			this.Trigger_Copy.Index = 2;
			this.Trigger_Copy.Shortcut = Shortcut.CtrlIns;
			this.Trigger_Copy.Text = "Copy trigger";
			this.Trigger_Copy.Click += new EventHandler(this.Trigger_Copy_Click);
			this.Trigger_Delete.Index = 3;
			this.Trigger_Delete.Shortcut = Shortcut.Del;
			this.Trigger_Delete.Text = "Delete trigger";
			this.Trigger_Delete.Click += new EventHandler(this.Trigger_Delete_Click);
			this.menuItem9.Index = 4;
			this.menuItem9.Text = "-";
			this.Trigger_MoveUp.Index = 5;
			this.Trigger_MoveUp.Text = "Move Up";
			this.Trigger_MoveUp.Shortcut = Shortcut.AltUpArrow;
			this.Trigger_MoveUp.Click += new EventHandler(this.Trigger_MoveUp_Click);
			this.Trigger_MoveDown.Index = 6;
			this.Trigger_MoveDown.Text = "Move Down";
			this.Trigger_MoveDown.Shortcut = Shortcut.AltDownArrow;
			this.Trigger_MoveDown.Click += new EventHandler(this.Trigger_MoveDown_Click);
			this.Trigger_FixOrder.Index = 7;
			this.Trigger_FixOrder.Text = "Fix order";
			this.Trigger_FixOrder.Click += new EventHandler(this.Trigger_FixOrder_Click);
			this.ScriptEntitiesFilterLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			Point location3 = new Point(8, 456);
			this.ScriptEntitiesFilterLabel.Location = location3;
			this.ScriptEntitiesFilterLabel.Name = "ScriptEntitiesFilterLabel";
			Size size3 = new Size(80, 16);
			this.ScriptEntitiesFilterLabel.Size = size3;
			this.ScriptEntitiesFilterLabel.TabIndex = 1;
			this.ScriptEntitiesFilterLabel.Text = "Filter";
			this.ScriptEntitiesFilterBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			Color window2 = SystemColors.Window;
			this.ScriptEntitiesFilterBox.BackColor = window2;
			Point location4 = new Point(8, 472);
			this.ScriptEntitiesFilterBox.Location = location4;
			this.ScriptEntitiesFilterBox.Name = "ScriptEntitiesFilterBox";
			this.ScriptEntitiesFilterBox.ItemHeight = 14;
			this.ScriptEntitiesFilterBox.SelectedIndex = -1;
			Size size4 = new Size(128, 214);
			this.ScriptEntitiesFilterBox.Size = size4;
			this.ScriptEntitiesFilterBox.TabIndex = 15;
			this.ScriptEntitiesFilterBox.SelectionMode = SelectionMode.MultiExtended;
			this.ScriptEntitiesFilterBox.SelectedIndexChanged += new EventHandler(this.ScriptEntitiesFilterBox_SelectedIndexChanged);
			this.ScriptEntitiesLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			Point location5 = new Point(144, 456);
			this.ScriptEntitiesLabel.Location = location5;
			this.ScriptEntitiesLabel.Name = "ScriptEntitiesLabel";
			Size size5 = new Size(104, 16);
			this.ScriptEntitiesLabel.Size = size5;
			this.ScriptEntitiesLabel.TabIndex = 1;
			this.ScriptEntitiesLabel.Text = "Entities";
			this.ScriptEntitiesControl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			Color window3 = SystemColors.Window;
			this.ScriptEntitiesControl.BackColor = window3;
			Script_GlobalVariableControl_Header[] columnHeaders2 = new Script_GlobalVariableControl_Header[]
			{
				this.SEN_Name,
				this.SEN_Type,
				this.SEN_Value,
				this.SEN_Used
			};
			this.ScriptEntitiesControl.ColumnHeaders = columnHeaders2;
			this.ScriptEntitiesControl.DrawGrid = true;
			this.ScriptEntitiesControl.HeaderHeight = 18;
			this.ScriptEntitiesControl.Items = new Script_GlobalVariableControl_ListItem[0];
			Point location6 = new Point(144, 472);
			this.ScriptEntitiesControl.Location = location6;
			this.ScriptEntitiesControl.Name = "ScriptEntitiesControl";
			this.ScriptEntitiesControl.RealSelectedIndex = -1;
			this.ScriptEntitiesControl.RowHeight = 14;
			this.ScriptEntitiesControl.SelectedIndex = -1;
			Size size6 = new Size(272, 230);
			this.ScriptEntitiesControl.Size = size6;
			this.ScriptEntitiesControl.TabIndex = 15;
			this.ScriptEntitiesControl.DragStarted += new EventHandler(this.ScriptEntitiesControl_DragStarted);
			this.ScriptEntities_ShowStoredUnits.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			Point location7 = new Point(8, 690);
			this.ScriptEntities_ShowStoredUnits.Location = location7;
			this.ScriptEntities_ShowStoredUnits.Name = "ScriptEntities_ShowStoredUnits";
			Size size7 = new Size(128, 16);
			this.ScriptEntities_ShowStoredUnits.Size = size7;
			this.ScriptEntities_ShowStoredUnits.TabIndex = 20;
			this.ScriptEntities_ShowStoredUnits.Text = "Stored units";
			this.ScriptEntities_ShowStoredUnits.Checked = true;
			this.ScriptEntities_ShowStoredUnits.CheckedChanged += new EventHandler(this.ScriptEntities_ShowStoredUnits_CheckedChanged);
			this.SEN_Name.Text = "Name";
			this.SEN_Name.Width = 160;
			this.SEN_Type.Text = "Type";
			this.SEN_Type.Width = 32;
			this.SEN_Value.Text = "Value";
			this.SEN_Value.Width = 38;
			this.SEN_Used.Text = "Used";
			this.SEN_Used.Width = 42;
			this.GlobalVariablesLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location8 = new Point(428, 456);
			this.GlobalVariablesLabel.Location = location8;
			this.GlobalVariablesLabel.Name = "GlobalVariablesLabel";
			Size size8 = new Size(104, 16);
			this.GlobalVariablesLabel.Size = size8;
			this.GlobalVariablesLabel.TabIndex = 1;
			this.GlobalVariablesLabel.Text = "Global Variables";
			this.GlobalVariableControl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Color window4 = SystemColors.Window;
			this.GlobalVariableControl.BackColor = window4;
			Script_GlobalVariableControl_Header[] columnHeaders3 = new Script_GlobalVariableControl_Header[]
			{
				this.GLV_Name,
				this.GLV_Type,
				this.GLV_Value,
				this.GLV_Used
			};
			this.GlobalVariableControl.ColumnHeaders = columnHeaders3;
			this.GlobalVariableControl.ContextMenu = this.GlobalVariables_ContextMenu;
			this.GlobalVariableControl.DrawGrid = true;
			this.GlobalVariableControl.HeaderHeight = 18;
			this.GlobalVariableControl.Items = new Script_GlobalVariableControl_ListItem[0];
			Point location9 = new Point(428, 472);
			this.GlobalVariableControl.Location = location9;
			this.GlobalVariableControl.Name = "GlobalVariableControl";
			this.GlobalVariableControl.RealSelectedIndex = -1;
			this.GlobalVariableControl.RowHeight = 14;
			this.GlobalVariableControl.SelectedIndex = -1;
			Size size9 = new Size(380, 106);
			this.GlobalVariableControl.Size = size9;
			this.GlobalVariableControl.TabIndex = 5;
			this.GlobalVariableControl.DragStarted += new EventHandler(this.GlobalVariableControl_DragStarted);
			this.GlobalVariableControl.ItemDoubleClicked += new EventHandler(this.GlobalVariableControl_ItemDoubleClicked);
			this.GlobalVariableControl.SelectedIndexChanged += new EventHandler(this.GlobalVariableControl_SelectedIndexChanged);
			this.GLV_Name.Text = "Name";
			this.GLV_Name.Width = 268;
			this.GLV_Type.Text = "Type";
			this.GLV_Type.Width = 32;
			this.GLV_Value.Text = "Value";
			this.GLV_Value.Width = 38;
			this.GLV_Used.Text = "Used";
			this.GLV_Used.Width = 42;
			MenuItem[] items5 = new MenuItem[]
			{
				this.GlobalVariable_Create,
				this.GlobalVariable_Delete,
				this.menuItem7a,
				this.GlobalVariable_MoveUp,
				this.GlobalVariable_MoveDown,
				this.GlobalVariable_FixOrder
			};
			this.GlobalVariables_ContextMenu.MenuItems.AddRange(items5);
			this.GlobalVariable_Create.Index = 0;
			this.GlobalVariable_Create.Shortcut = Shortcut.Ins;
			this.GlobalVariable_Create.Text = "Create variable";
			this.GlobalVariable_Create.Click += new EventHandler(this.GlobalVariable_Create_Click);
			this.GlobalVariable_Delete.Index = 1;
			this.GlobalVariable_Delete.Shortcut = Shortcut.Del;
			this.GlobalVariable_Delete.Text = "Delete variable";
			this.GlobalVariable_Delete.Click += new EventHandler(this.GlobalVariable_Delete_Click);
			this.menuItem7a.Index = 2;
			this.menuItem7a.Text = "-";
			this.GlobalVariable_MoveUp.Enabled = false;
			this.GlobalVariable_MoveUp.Index = 3;
			this.GlobalVariable_MoveUp.Text = "Move Up";
			this.GlobalVariable_MoveUp.Click += new EventHandler(this.GlobalVariable_MoveUp_Click);
			this.GlobalVariable_MoveDown.Enabled = false;
			this.GlobalVariable_MoveDown.Index = 4;
			this.GlobalVariable_MoveDown.Text = "Move Down";
			this.GlobalVariable_MoveDown.Click += new EventHandler(this.GlobalVariable_MoveDown_Click);
			this.GlobalVariable_FixOrder.Index = 5;
			this.GlobalVariable_FixOrder.Text = "Fix order";
			this.GlobalVariable_FixOrder.Click += new EventHandler(this.GlobalVariable_FixOrder_Click);
			this.TriggerGroup.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.TriggerGroup.Controls.Add(this.InsertSingleOrConditionButton);
			this.TriggerGroup.Controls.Add(this.DeleteActionPartButton);
			this.TriggerGroup.Controls.Add(this.ConditionTypeBox);
			this.TriggerGroup.Controls.Add(this.ActionTypeBox);
			this.TriggerGroup.Controls.Add(this.NegateConditionButton);
			this.TriggerGroup.Controls.Add(this.DeleteConditionBlockButton);
			this.TriggerGroup.Controls.Add(this.DeleteActionBlockButton);
			this.TriggerGroup.Controls.Add(this.DeleteConditionButton);
			this.TriggerGroup.Controls.Add(this.AddConditionButton);
			this.TriggerGroup.Controls.Add(this.DeleteActionButton);
			this.TriggerGroup.Controls.Add(this.AddActionButton);
			this.TriggerGroup.Controls.Add(this.ConditionType_Label);
			this.TriggerGroup.Controls.Add(this.ActionType_Label);
			this.TriggerGroup.Controls.Add(this.ActionListTreeControl);
			this.TriggerGroup.Controls.Add(this.TriggerActionListLabel);
			this.TriggerGroup.Controls.Add(this.TriggerVariablesLabel);
			this.TriggerGroup.Controls.Add(this.TriggerVariableControl);
			this.TriggerGroup.Controls.Add(this.GlobalVariablesLabel);
			this.TriggerGroup.Controls.Add(this.GlobalVariableControl);
			this.TriggerGroup.Controls.Add(this.ScriptEntitiesLabel);
			this.TriggerGroup.Controls.Add(this.ScriptEntitiesControl);
			this.TriggerGroup.Controls.Add(this.ScriptEntities_ShowStoredUnits);
			this.TriggerGroup.Controls.Add(this.ScriptEntitiesFilterLabel);
			this.TriggerGroup.Controls.Add(this.ScriptEntitiesFilterBox);
			Point location10 = new Point(312, 8);
			this.TriggerGroup.Location = location10;
			this.TriggerGroup.Name = "TriggerGroup";
			Size size10 = new Size(816, 712);
			this.TriggerGroup.Size = size10;
			this.TriggerGroup.TabIndex = 7;
			this.TriggerGroup.TabStop = false;
			this.TriggerGroup.Text = "Trigger";
			this.InsertSingleOrConditionButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location11 = new Point(600, 416);
			this.InsertSingleOrConditionButton.Location = location11;
			this.InsertSingleOrConditionButton.Name = "InsertSingleOrConditionButton";
			Size size11 = new Size(96, 23);
			this.InsertSingleOrConditionButton.Size = size11;
			this.InsertSingleOrConditionButton.TabIndex = 31;
			this.InsertSingleOrConditionButton.Text = "InsertSingleOr";
			this.InsertSingleOrConditionButton.Click += new EventHandler(this.InsertSingleOrConditionButton_Click);
			this.DeleteActionPartButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location12 = new Point(496, 416);
			this.DeleteActionPartButton.Location = location12;
			this.DeleteActionPartButton.Name = "DeleteActionPartButton";
			Size size12 = new Size(96, 23);
			this.DeleteActionPartButton.Size = size12;
			this.DeleteActionPartButton.TabIndex = 30;
			this.DeleteActionPartButton.Text = "DeleteAPart";
			this.DeleteActionPartButton.Click += new EventHandler(this.DeleteActionPartButton_Click);
			this.ConditionTypeBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
			Point location13 = new Point(496, 32);
			this.ConditionTypeBox.Location = location13;
			this.ConditionTypeBox.Name = "ConditionTypeBox";
			Size size13 = new Size(312, 352);
			this.ConditionTypeBox.Size = size13;
			this.ConditionTypeBox.TabIndex = 29;
			this.ActionTypeBox.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
			Point location14 = new Point(496, 32);
			this.ActionTypeBox.Location = location14;
			this.ActionTypeBox.Name = "ActionTypeBox";
			Size size14 = new Size(312, 352);
			this.ActionTypeBox.Size = size14;
			this.ActionTypeBox.TabIndex = 28;
			this.NegateConditionButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location15 = new Point(496, 416);
			this.NegateConditionButton.Location = location15;
			this.NegateConditionButton.Name = "NegateConditionButton";
			Size size15 = new Size(96, 23);
			this.NegateConditionButton.Size = size15;
			this.NegateConditionButton.TabIndex = 20;
			this.NegateConditionButton.Text = "NegateCond.";
			this.NegateConditionButton.Click += new EventHandler(this.NegateConditionButton_Click);
			this.DeleteConditionBlockButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location16 = new Point(704, 384);
			this.DeleteConditionBlockButton.Location = location16;
			this.DeleteConditionBlockButton.Name = "DeleteConditionBlockButton";
			Size size16 = new Size(96, 23);
			this.DeleteConditionBlockButton.Size = size16;
			this.DeleteConditionBlockButton.TabIndex = 19;
			this.DeleteConditionBlockButton.Text = "DeleteCBlock";
			this.DeleteConditionBlockButton.Click += new EventHandler(this.DeleteConditionBlockButton_Click);
			this.DeleteActionBlockButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location17 = new Point(704, 384);
			this.DeleteActionBlockButton.Location = location17;
			this.DeleteActionBlockButton.Name = "DeleteActionBlockButton";
			Size size17 = new Size(96, 23);
			this.DeleteActionBlockButton.Size = size17;
			this.DeleteActionBlockButton.TabIndex = 18;
			this.DeleteActionBlockButton.Text = "DeleteABlock";
			this.DeleteActionBlockButton.Click += new EventHandler(this.DeletActionBlockButton_Click);
			this.DeleteConditionButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location18 = new Point(600, 384);
			this.DeleteConditionButton.Location = location18;
			this.DeleteConditionButton.Name = "DeleteConditionButton";
			Size size18 = new Size(96, 23);
			this.DeleteConditionButton.Size = size18;
			this.DeleteConditionButton.TabIndex = 17;
			this.DeleteConditionButton.Text = "DeleteCondition";
			this.DeleteConditionButton.Click += new EventHandler(this.DeleteConditionButton_Click);
			this.AddConditionButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location19 = new Point(496, 384);
			this.AddConditionButton.Location = location19;
			this.AddConditionButton.Name = "AddConditionButton";
			Size size19 = new Size(96, 23);
			this.AddConditionButton.Size = size19;
			this.AddConditionButton.TabIndex = 16;
			this.AddConditionButton.Text = "AddCondition";
			this.AddConditionButton.Click += new EventHandler(this.AddConditionButton_Click);
			this.DeleteActionButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location20 = new Point(600, 384);
			this.DeleteActionButton.Location = location20;
			this.DeleteActionButton.Name = "DeleteActionButton";
			Size size20 = new Size(96, 23);
			this.DeleteActionButton.Size = size20;
			this.DeleteActionButton.TabIndex = 15;
			this.DeleteActionButton.Text = "DeleteAction";
			this.DeleteActionButton.Click += new EventHandler(this.DeleteActionButton_Click);
			this.AddActionButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location21 = new Point(496, 384);
			this.AddActionButton.Location = location21;
			this.AddActionButton.Name = "AddActionButton";
			Size size21 = new Size(96, 23);
			this.AddActionButton.Size = size21;
			this.AddActionButton.TabIndex = 14;
			this.AddActionButton.Text = "AddAction";
			this.AddActionButton.Click += new EventHandler(this.AddActionButton_Click);
			this.ConditionType_Label.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			Point location22 = new Point(496, 16);
			this.ConditionType_Label.Location = location22;
			this.ConditionType_Label.Name = "ConditionType_Label";
			Size size22 = new Size(100, 16);
			this.ConditionType_Label.Size = size22;
			this.ConditionType_Label.TabIndex = 13;
			this.ConditionType_Label.Text = "ConditionType";
			this.ActionType_Label.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			Point location23 = new Point(496, 16);
			this.ActionType_Label.Location = location23;
			this.ActionType_Label.Name = "ActionType_Label";
			Size size23 = new Size(100, 16);
			this.ActionType_Label.Size = size23;
			this.ActionType_Label.TabIndex = 11;
			this.ActionType_Label.Text = "ActionType";
			this.ActionListTreeControl.AllowDrop = true;
			this.ActionListTreeControl.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			Color window5 = SystemColors.Window;
			this.ActionListTreeControl.BackColor = window5;
			this.ActionListTreeControl.ContextMenu = this.ActionList_ContextMenu;
			Point location24 = new Point(8, 32);
			this.ActionListTreeControl.Location = location24;
			this.ActionListTreeControl.Name = "ActionListTreeControl";
			Size size24 = new Size(480, 412);
			this.ActionListTreeControl.Size = size24;
			this.ActionListTreeControl.TabIndex = 9;
			this.ActionListTreeControl.ListSelectingFinished += new EventHandler(this.ActionListTreeControl_ListSelectingFinished);
			this.ActionListTreeControl.MouseTargetOnDrop += new EventHandler(this.ActionListTreeControl_MouseTargetOnDrop);
			this.ActionListTreeControl.TextEditingRequest += new EventHandler(this.ActionListTreeControl_TextEditingRequest);
			this.ActionListTreeControl.TextEditingFinished += new EventHandler(this.ActionListTreeControl_TextEditingFinished);
			this.ActionListTreeControl.ExpandChanged += new EventHandler(this.ActionListTreeControl_ExpandChanged);
			this.ActionListTreeControl.MouseTargetChanged += new EventHandler(this.ActionListTreeControl_MouseTargetChanged);
			this.ActionListTreeControl.MouseTargetDoubleClicked += new EventHandler(this.ActionListTreeControl_MouseTargetDoubleClicked);
			this.ActionListTreeControl.DragEnter += new DragEventHandler(this.ActionListTreeControl_DragEnter);
			this.ActionListTreeControl.SelectionChanged += new EventHandler(this.ActionListTreeControl_SelectionChanged);
			MenuItem[] items6 = new MenuItem[]
			{
				this.Actions_Insert,
				this.Actions_Delete
			};
			this.ActionList_ContextMenu.MenuItems.AddRange(items6);
			this.Actions_Insert.Index = 0;
			this.Actions_Insert.Shortcut = Shortcut.Ins;
			this.Actions_Insert.Text = "Insert";
			this.Actions_Insert.Click += new EventHandler(this.Actions_Insert_Click);
			this.Actions_Delete.Index = 1;
			this.Actions_Delete.Shortcut = Shortcut.Del;
			this.Actions_Delete.Text = "Delete";
			this.Actions_Delete.Click += new EventHandler(this.Actions_Delete_Click);
			Point location25 = new Point(8, 16);
			this.TriggerActionListLabel.Location = location25;
			this.TriggerActionListLabel.Name = "TriggerActionListLabel";
			Size size25 = new Size(100, 16);
			this.TriggerActionListLabel.Size = size25;
			this.TriggerActionListLabel.TabIndex = 2;
			this.TriggerActionListLabel.Text = "ActionList";
			this.TriggerVariablesLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Point location26 = new Point(428, 587);
			this.TriggerVariablesLabel.Location = location26;
			this.TriggerVariablesLabel.Name = "TriggerVariablesLabel";
			Size size26 = new Size(100, 16);
			this.TriggerVariablesLabel.Size = size26;
			this.TriggerVariablesLabel.TabIndex = 0;
			this.TriggerVariablesLabel.Text = "Trigger Variables";
			this.TriggerVariableControl.AllowDrop = true;
			this.TriggerVariableControl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			Color window6 = SystemColors.Window;
			this.TriggerVariableControl.BackColor = window6;
			Script_GlobalVariableControl_Header[] columnHeaders4 = new Script_GlobalVariableControl_Header[]
			{
				this.TV_Name,
				this.TV_Type,
				this.TV_Value,
				this.TV_Used
			};
			this.TriggerVariableControl.ColumnHeaders = columnHeaders4;
			this.TriggerVariableControl.ContextMenu = this.TriggerVariables_ContextMenu;
			this.TriggerVariableControl.DrawGrid = true;
			this.TriggerVariableControl.HeaderHeight = 18;
			this.TriggerVariableControl.Items = new Script_GlobalVariableControl_ListItem[0];
			Point location27 = new Point(428, 604);
			this.TriggerVariableControl.Location = location27;
			this.TriggerVariableControl.Name = "TriggerVariableControl";
			this.TriggerVariableControl.RealSelectedIndex = -1;
			this.TriggerVariableControl.RowHeight = 14;
			this.TriggerVariableControl.SelectedIndex = -1;
			Size size27 = new Size(380, 99);
			this.TriggerVariableControl.Size = size27;
			this.TriggerVariableControl.TabIndex = 6;
			this.TriggerVariableControl.DragStarted += new EventHandler(this.TriggerVariableControl_DragStarted);
			this.TriggerVariableControl.SortModeChanged += new EventHandler(this.TriggerVariableControl_SortModeChanged);
			this.TriggerVariableControl.ItemDoubleClicked += new EventHandler(this.TriggerVariableControl_ItemDoubleClicked);
			this.TriggerVariableControl.SelectedIndexChanged += new EventHandler(this.TriggerVariableControl_SelectedIndexChanged);
			this.TV_Name.Text = "Name";
			this.TV_Name.Width = 268;
			this.TV_Type.Text = "Type";
			this.TV_Type.Width = 32;
			this.TV_Value.Text = "Value";
			this.TV_Value.Width = 38;
			this.TV_Used.Text = "Used";
			this.TV_Used.Width = 42;
			MenuItem[] items7 = new MenuItem[]
			{
				this.TriggerVariable_Create,
				this.TriggerVariable_Delete,
				this.menuItem7,
				this.TriggerVariable_MoveUp,
				this.TriggerVariable_MoveDown,
				this.TriggerVariable_FixOrder
			};
			this.TriggerVariables_ContextMenu.MenuItems.AddRange(items7);
			this.TriggerVariable_Create.Index = 0;
			this.TriggerVariable_Create.Shortcut = Shortcut.Ins;
			this.TriggerVariable_Create.Text = "Create variable";
			this.TriggerVariable_Create.Click += new EventHandler(this.TriggerVariable_Create_Click);
			this.TriggerVariable_Delete.Index = 1;
			this.TriggerVariable_Delete.Shortcut = Shortcut.Del;
			this.TriggerVariable_Delete.Text = "Delete variable";
			this.TriggerVariable_Delete.Click += new EventHandler(this.TriggerVariable_Delete_Click);
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "-";
			this.TriggerVariable_MoveUp.Enabled = false;
			this.TriggerVariable_MoveUp.Index = 3;
			this.TriggerVariable_MoveUp.Text = "Move Up";
			this.TriggerVariable_MoveUp.Click += new EventHandler(this.TriggerVariable_MoveUp_Click);
			this.TriggerVariable_MoveDown.Enabled = false;
			this.TriggerVariable_MoveDown.Index = 4;
			this.TriggerVariable_MoveDown.Text = "Move Down";
			this.TriggerVariable_MoveDown.Click += new EventHandler(this.TriggerVariable_MoveDown_Click);
			this.TriggerVariable_FixOrder.Index = 5;
			this.TriggerVariable_FixOrder.Text = "Fix order";
			this.TriggerVariable_FixOrder.Click += new EventHandler(this.TriggerVariable_FixOrder_Click);
			this.StatusLine.AcceptsReturn = true;
			this.StatusLine.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			Point location28 = new Point(8, 726);
			this.StatusLine.Location = location28;
			this.StatusLine.Multiline = true;
			this.StatusLine.Name = "StatusLine";
			this.StatusLine.ReadOnly = true;
			Size size28 = new Size(1120, 38);
			this.StatusLine.Size = size28;
			this.StatusLine.TabIndex = 8;
			this.StatusLine.TabStop = false;
			this.StatusLine.Text = "";
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(1144, 773);
			base.ClientSize = clientSize;
			base.Controls.Add(this.StatusLine);
			base.Controls.Add(this.TriggerGroup);
			base.Controls.Add(this.GlobalGroupBox);
			base.Menu = this.MainMenu;
			base.Name = "ScriptEditorForm";
			this.RightToLeft = RightToLeft.No;
			this.Text = "Script editor";
			base.Load += new EventHandler(this.ScriptEditorForm_Load);
			base.Deactivate += new EventHandler(this.ScriptEditorForm_Deactivate);
			this.GlobalGroupBox.ResumeLayout(false);
			this.TriggerGroup.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private unsafe void ScriptEditorForm_Load(object sender, EventArgs e)
		{
			this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
			this.SelectedTriggerIndex = -1;
			uint* ptr = (uint*)(&<Module>.ScriptEditor.ValueTypeList_Filter);
			if (<Module>.ScriptEditor.ValueTypeList_Filter != 32)
			{
				do
				{
					ptr += 4 / sizeof(uint);
				}
				while (*(int*)ptr != 32);
			}
			int num = ptr - ref <Module>.ScriptEditor.ValueTypeList_Filter / sizeof(uint) >> 2;
			if (*(int*)ptr != 41)
			{
				do
				{
					ptr += 4 / sizeof(uint);
				}
				while (*(int*)ptr != 41);
			}
			int num2 = ptr - ref <Module>.ScriptEditor.ValueTypeList_Filter / sizeof(uint) >> 2;
			$ArrayType$$$BY0CJ@H* ptr2 = &<Module>.ScriptEditor.EntityTypeIndices;
			do
			{
				*(int*)ptr2 = -1;
				ptr2 += 4 / sizeof($ArrayType$$$BY0CJ@H);
			}
			while (ptr2 < ref <Module>.ScriptEditor.EntityTypeIndices + 164);
			object[] array = new object[num2];
			uint* ptr3 = (uint*)(&<Module>.ScriptEditor.ValueTypeList_Filter);
			int num3 = 0;
			if (0 < num)
			{
				do
				{
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr4 = <Module>.ScriptEditor.GetValueTypeAsString(&gBaseString<char>, *(int*)ptr3);
					try
					{
						uint num4 = (uint)(*(int*)ptr4);
						sbyte* value;
						if (num4 != 0u)
						{
							value = num4;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						array[num3] = new string((sbyte*)value);
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
					*(*(int*)ptr3 * 4 + ref <Module>.ScriptEditor.EntityTypeIndices) = num3;
					num3++;
					ptr3 += 4 / sizeof(uint);
				}
				while (num3 < num);
			}
			int num5 = num;
			if (num < num2)
			{
				do
				{
					GBaseString<char> gBaseString<char>2;
					GBaseString<char>* ptr5 = <Module>.ScriptEditor.GetExtraFilterAsString(&gBaseString<char>2, *(int*)ptr3);
					try
					{
						uint num6 = (uint)(*(int*)ptr5);
						sbyte* value2;
						if (num6 != 0u)
						{
							value2 = num6;
						}
						else
						{
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						array[num5] = new string((sbyte*)value2);
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
					*(*(int*)ptr3 * 4 + ref <Module>.ScriptEditor.EntityTypeIndices) = num5;
					num5++;
					ptr3 += 4 / sizeof(uint);
				}
				while (num5 < num2);
			}
			this.ScriptEntitiesFilterBox.Items.Clear();
			this.ScriptEntitiesFilterBox.Items.AddRange(array);
			int num7 = 0;
			if (0 < num2)
			{
				do
				{
					this.ScriptEntitiesFilterBox.SetSelected(num7, true);
					num7++;
				}
				while (num7 < num2);
			}
			int* ptr6 = (int*)(&<Module>.ScriptEditor.ActionTypeList);
			if (<Module>.ScriptEditor.ActionTypeList != 168)
			{
				do
				{
					ptr6 += 4 / sizeof(int);
				}
				while (*(int*)ptr6 != 168);
			}
			int num8 = ptr6 - ref <Module>.ScriptEditor.ActionTypeList / sizeof(int) >> 2;
			object[] array2 = new object[num8];
			int* ptr7 = (int*)(&<Module>.ScriptEditor.ActionTypeList);
			int num9 = 0;
			if (0 < num8)
			{
				do
				{
					GBaseString<char> gBaseString<char>3;
					GBaseString<char>* ptr8 = <Module>.?GetActionTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eAction_Type@Script@@@Z(&gBaseString<char>3, *(int*)ptr7);
					try
					{
						uint num10 = (uint)(*(int*)ptr8);
						sbyte* value3;
						if (num10 != 0u)
						{
							value3 = num10;
						}
						else
						{
							value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						array2[num9] = new string((sbyte*)value3);
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
					num9++;
					ptr7 += 4 / sizeof(int);
				}
				while (num9 < num8);
			}
			this.ActionTypeBox.Items.Clear();
			this.ActionTypeBox.Items.AddRange(array2);
			this.ActionTypeBox.SelectedIndex = 0;
			int* ptr9 = (int*)(&<Module>.ScriptEditor.ConditionTypeList);
			if (<Module>.ScriptEditor.ConditionTypeList != 26)
			{
				do
				{
					ptr9 += 4 / sizeof(int);
				}
				while (*(int*)ptr9 != 26);
			}
			int num11 = ptr9 - ref <Module>.ScriptEditor.ConditionTypeList / sizeof(int) >> 2;
			object[] array3 = new object[num11];
			int* ptr10 = (int*)(&<Module>.ScriptEditor.ConditionTypeList);
			int num12 = 0;
			if (0 < num11)
			{
				do
				{
					GBaseString<char> gBaseString<char>4;
					GBaseString<char>* ptr11 = <Module>.?GetConditionTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eCondition_Type@Script@@_N@Z(&gBaseString<char>4, *(int*)ptr10, 0);
					try
					{
						uint num13 = (uint)(*(int*)ptr11);
						sbyte* value4;
						if (num13 != 0u)
						{
							value4 = num13;
						}
						else
						{
							value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						array3[num12] = new string((sbyte*)value4);
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
					num12++;
					ptr10 += 4 / sizeof(int);
				}
				while (num12 < num11);
			}
			this.ConditionTypeBox.Items.Clear();
			this.ConditionTypeBox.Items.AddRange(array3);
			this.ConditionTypeBox.SelectedIndex = 0;
			GStreamBuffer* ptr12 = <Module>.@new(36u);
			GStreamBuffer* clipboardStream;
			try
			{
				if (ptr12 != null)
				{
					clipboardStream = <Module>.GStreamBuffer.{ctor}(ptr12);
				}
				else
				{
					clipboardStream = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr12);
				throw;
			}
			this.ClipboardStream = clipboardStream;
			this.ScriptIndex = -1;
			this.RefreshScriptList();
			this.ChangeScript(0);
			this.Edit_Copy.Enabled = true;
			this.Edit_Cut.Enabled = true;
			this.Edit_Paste.Enabled = false;
			this.Edit_Clear.Enabled = true;
		}

		private unsafe void RefreshScriptList()
		{
			this.MainMenu_Scripts.MenuItems.Clear();
			int num = *(int*)(<Module>.SafeWorld + 4084 / sizeof(GEditorWorld));
			MenuItem[] array = new MenuItem[num];
			int num2 = 0;
			if (0 < num)
			{
				do
				{
					array[num2] = new MenuItem();
					array[num2].Index = num2;
					int num3 = num2 + 1;
					array[num2].Text = string.Format(new string((sbyte*)(&<Module>.??_C@_0M@MABEAKPP@?$HL0?$HN?4?5script?$AA@)), num3);
					array[num2].Click += new EventHandler(this.MainMenu_Scripts_Click);
					if (num2 < 10)
					{
						array[num2].Shortcut = num2 + Shortcut.Ctrl1;
					}
					else if (num2 == 10)
					{
						array[10].Shortcut = Shortcut.Ctrl0;
					}
					num2 = num3;
				}
				while (num2 < *(int*)(<Module>.SafeWorld + 4084 / sizeof(GEditorWorld)));
			}
			this.MainMenu_Scripts.MenuItems.AddRange(array);
		}

		private void ChangeScript(int index)
		{
			int scriptIndex = this.ScriptIndex;
			if (index != scriptIndex)
			{
				if (scriptIndex != -1)
				{
					this.MainMenu_Scripts.MenuItems[scriptIndex].Checked = false;
					this.SaveScript();
				}
				this.ScriptIndex = index;
				this.Editor = this.GetEditor(index);
				this.MainMenu_Scripts.MenuItems[this.ScriptIndex].Checked = true;
				this.RefreshAll();
			}
		}

		private void SaveScript()
		{
			<Module>.ScriptEditor.cManager.SaveEditor(<Module>.SafeWorld + 5128 / sizeof(GEditorWorld), this.ScriptIndex);
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private unsafe bool FilterEntity(sValue* value, GBaseString<char>* scriptID)
		{
			int num = *value;
			int index;
			if (num == 3)
			{
				GWUnit* ptr = <Module>.GWorld.FindWUnitByScriptID(<Module>.SafeWorld, scriptID);
				if (ptr == null)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0BO@JEMOOMIB@?4?2script?2ScriptEditorForm?4cpp?$AA@), 300, (sbyte*)(&<Module>.??_C@_0DD@LOOMFEIB@ScriptEditorWindow?3?3ScriptEditor@));
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr2 = <Module>.Format(&gBaseString<char>, (sbyte*)(&<Module>.??_C@_0CD@OMJMMENC@Unit?5?$CFs?5not?5removed?5from?5scripte@), *scriptID);
					try
					{
						uint num2 = (uint)(*(int*)ptr2);
						<Module>.GLogger.Warning((num2 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num2);
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
					return true;
				}
				bool @checked = this.ScriptEntities_ShowStoredUnits.Checked;
				if (*(byte*)(ptr + 72 / sizeof(GWUnit)) != 0 && !@checked)
				{
					return true;
				}
				int num3 = *(int*)(ptr + 36 / sizeof(GWUnit));
				if (num3 >= 0)
				{
					index = *(*(int*)(<Module>.SafeWorld + num3 * 160 / sizeof(GEditorWorld) + 300 / sizeof(GEditorWorld)) * 4 + (ref <Module>.ScriptEditor.EntityTypeIndices + 144));
				}
				else
				{
					index = *(ref <Module>.ScriptEditor.EntityTypeIndices + 144);
				}
				if (!this.ScriptEntitiesFilterBox.GetSelected(index))
				{
					return true;
				}
				if (<Module>.GWUnit.IsBuilding(ptr) != null)
				{
					index = *(ref <Module>.ScriptEditor.EntityTypeIndices + 136);
				}
				else if (<Module>.GWUnit.IsVehicle(ptr) != null)
				{
					index = *(ref <Module>.ScriptEditor.EntityTypeIndices + 132);
				}
				else if (<Module>.GWUnit.IsInfantry(ptr) != null)
				{
					index = *(ref <Module>.ScriptEditor.EntityTypeIndices + 128);
				}
				else
				{
					index = *(ref <Module>.ScriptEditor.EntityTypeIndices + 140);
				}
			}
			else
			{
				index = *(num * 4 + ref <Module>.ScriptEditor.EntityTypeIndices);
			}
			return !this.ScriptEntitiesFilterBox.GetSelected(index);
		}

		private unsafe void RefreshAll()
		{
			this.RefreshScriptEntities();
			this.RefreshGlobalVariables();
			this.RefreshTriggers();
			cEditor* editor = this.Editor;
			if (*(int*)(editor + 32 / sizeof(cEditor)) != 0)
			{
				this.RefreshTriggerData(*(this.GlobalTriggerControl.SelectedIndex * 4 + *(int*)(editor + 28 / sizeof(cEditor))), 0);
			}
			int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
			this.Edit_Undo.Enabled = ((byte)num != 0);
			cEditor* editor2 = this.Editor;
			int num2 = (*(editor2 + 68) < *(editor2 + 60)) ? 1 : 0;
			this.Edit_Redo.Enabled = ((byte)num2 != 0);
		}

		private unsafe void RefreshScriptEntities()
		{
			if (this.Editor != null)
			{
				int index = *(ref <Module>.ScriptEditor.EntityTypeIndices + 128);
				this.ScriptEntities_ShowStoredUnits.Enabled = this.ScriptEntitiesFilterBox.GetSelected(index);
				int index2 = *(ref <Module>.ScriptEditor.EntityTypeIndices + 132);
				byte enabled;
				if (!this.ScriptEntities_ShowStoredUnits.Enabled && !this.ScriptEntitiesFilterBox.GetSelected(index2))
				{
					enabled = 0;
				}
				else
				{
					enabled = 1;
				}
				this.ScriptEntities_ShowStoredUnits.Enabled = (enabled != 0);
				int index3 = *(ref <Module>.ScriptEditor.EntityTypeIndices + 136);
				byte enabled2;
				if (!this.ScriptEntities_ShowStoredUnits.Enabled && !this.ScriptEntitiesFilterBox.GetSelected(index3))
				{
					enabled2 = 0;
				}
				else
				{
					enabled2 = 1;
				}
				this.ScriptEntities_ShowStoredUnits.Enabled = (enabled2 != 0);
				int num = 0;
				int num2 = 0;
				cEditor* editor = this.Editor;
				int num3 = *(editor + 48);
				if (0 < num3)
				{
					do
					{
						cEditor* editor2 = this.Editor;
						cVariable* ptr = *(num2 * 4 + *(editor2 + 44));
						sValue* value = ptr + 16;
						if (!this.FilterEntity(value, <Module>.ScriptEditor.cVariable.GetName(ptr)))
						{
							num++;
						}
						num2++;
						editor = this.Editor;
						num3 = *(editor + 48);
					}
					while (num2 < num3);
				}
				this.ScriptEntities_List = new int[num];
				if (num == 0)
				{
					this.ScriptEntitiesControl.Items = new Script_GlobalVariableControl_ListItem[0];
				}
				else
				{
					Script_GlobalVariableControl_ListItem[] array = new Script_GlobalVariableControl_ListItem[num];
					int num4 = 0;
					int num5 = 0;
					int num6 = *(int*)(this.Editor + 48 / sizeof(cEditor));
					if (0 < num6)
					{
						do
						{
							cEditor* editor3 = this.Editor;
							cVariable* ptr2 = *(num5 * 4 + *(editor3 + 44));
							sValue* value2 = ptr2 + 16;
							if (!this.FilterEntity(value2, <Module>.ScriptEditor.cVariable.GetName(ptr2)))
							{
								Script_GlobalVariableControl_ListSubItem[] array2 = new Script_GlobalVariableControl_ListSubItem[4];
								array2[0] = new Script_GlobalVariableControl_ListSubItem();
								uint num7 = (uint)(*<Module>.ScriptEditor.cVariable.GetName(ptr2));
								sbyte* value3;
								if (num7 != 0u)
								{
									value3 = num7;
								}
								else
								{
									value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								array2[0].Text = new string((sbyte*)value3);
								array2[1] = new Script_GlobalVariableControl_ListSubItem();
								GBaseString<char> gBaseString<char>;
								GBaseString<char>* ptr3 = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(&gBaseString<char>, *(ptr2 + 16), 0);
								try
								{
									uint num8 = (uint)(*(int*)ptr3);
									sbyte* value4;
									if (num8 != 0u)
									{
										value4 = num8;
									}
									else
									{
										value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
									}
									array2[1].Text = new string((sbyte*)value4);
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
								array2[2] = new Script_GlobalVariableControl_ListSubItem();
								GBaseString<char> gBaseString<char>2;
								GBaseString<char>* ptr4 = <Module>.ScriptEditor.sValue.GetAsString(ptr2 + 16, &gBaseString<char>2, this.Editor);
								try
								{
									uint num9 = (uint)(*(int*)ptr4);
									sbyte* value5;
									if (num9 != 0u)
									{
										value5 = num9;
									}
									else
									{
										value5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
									}
									array2[2].Text = new string((sbyte*)value5);
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
								array2[3] = new Script_GlobalVariableControl_ListSubItem();
								int num10 = *(ptr2 + 32);
								string text;
								if (num10 > 0)
								{
									int num11 = num10;
									text = string.Format(new string((sbyte*)(&<Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@)), num11);
								}
								else
								{
									text = new string((sbyte*)(&<Module>.??_C@_02KAJCLHKP@no?$AA@));
								}
								array2[3].Text = text;
								this.ScriptEntities_List[num4] = num5;
								array[num4] = new Script_GlobalVariableControl_ListItem();
								Script_GlobalVariableControl_ListItem arg_2E8_0 = array[num4];
								num4++;
								arg_2E8_0.SubItems = array2;
							}
							num5++;
						}
						while (num5 < *(int*)(this.Editor + 48 / sizeof(cEditor)));
					}
					this.ScriptEntitiesControl.Items = array;
				}
			}
		}

		private unsafe void RefreshGlobalVariables()
		{
			this.GlobalVariable_Create.Enabled = true;
			int num = *(int*)(this.Editor + 16 / sizeof(cEditor));
			this.GlobalVariable_Create.Enabled = true;
			if (num == 0)
			{
				this.GlobalVariableControl.Items = new Script_GlobalVariableControl_ListItem[0];
				this.GlobalVariable_Delete.Enabled = false;
				this.GlobalVariable_FixOrder.Enabled = false;
				this.GlobalVariable_MoveDown.Enabled = false;
				this.GlobalVariable_MoveUp.Enabled = false;
			}
			else
			{
				Script_GlobalVariableControl_ListItem[] array = new Script_GlobalVariableControl_ListItem[num];
				int num2 = 0;
				cEditor* editor = this.Editor;
				int num3 = *(int*)(editor + 16 / sizeof(cEditor));
				if (0 < num3)
				{
					do
					{
						cEditor* ptr = editor;
						cVariable* ptr2 = *(num2 * 4 + *(ptr + 12));
						Script_GlobalVariableControl_ListSubItem[] array2 = new Script_GlobalVariableControl_ListSubItem[4];
						array2[0] = new Script_GlobalVariableControl_ListSubItem();
						uint num4 = (uint)(*<Module>.ScriptEditor.cVariable.GetName(ptr2));
						sbyte* value;
						if (num4 != 0u)
						{
							value = num4;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						array2[0].Text = new string((sbyte*)value);
						array2[1] = new Script_GlobalVariableControl_ListSubItem();
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr3 = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(&gBaseString<char>, *(ptr2 + 16), 0);
						try
						{
							uint num5 = (uint)(*(int*)ptr3);
							sbyte* value2;
							if (num5 != 0u)
							{
								value2 = num5;
							}
							else
							{
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							array2[1].Text = new string((sbyte*)value2);
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
						array2[2] = new Script_GlobalVariableControl_ListSubItem();
						GBaseString<char> gBaseString<char>2;
						GBaseString<char>* ptr4 = <Module>.ScriptEditor.sValue.GetAsString(ptr2 + 16, &gBaseString<char>2, this.Editor);
						try
						{
							uint num6 = (uint)(*(int*)ptr4);
							sbyte* value3;
							if (num6 != 0u)
							{
								value3 = num6;
							}
							else
							{
								value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							array2[2].Text = new string((sbyte*)value3);
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
						array2[3] = new Script_GlobalVariableControl_ListSubItem();
						int num7 = *(ptr2 + 32);
						string text;
						if (num7 > 0)
						{
							int num8 = num7;
							text = string.Format(new string((sbyte*)(&<Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@)), num8);
						}
						else
						{
							text = new string((sbyte*)(&<Module>.??_C@_02KAJCLHKP@no?$AA@));
						}
						array2[3].Text = text;
						array[num2] = new Script_GlobalVariableControl_ListItem();
						Script_GlobalVariableControl_ListItem arg_1EE_0 = array[num2];
						num2++;
						arg_1EE_0.SubItems = array2;
						editor = this.Editor;
					}
					while (num2 < *(int*)(editor + 16 / sizeof(cEditor)));
				}
				this.GlobalVariableControl.Items = array;
				this.GlobalVariable_Delete.Enabled = true;
				Script_GlobalVariableControl globalVariableControl = this.GlobalVariableControl;
				if (globalVariableControl.IsInOriginalOrder())
				{
					byte enabled = (globalVariableControl.SelectedIndex + 1 < *(int*)(this.Editor + 16 / sizeof(cEditor))) ? 1 : 0;
					this.GlobalVariable_MoveDown.Enabled = (enabled != 0);
					byte enabled2 = (this.GlobalVariableControl.SelectedIndex > 0) ? 1 : 0;
					this.GlobalVariable_MoveUp.Enabled = (enabled2 != 0);
					this.GlobalVariable_FixOrder.Enabled = false;
				}
				else
				{
					this.GlobalVariable_MoveDown.Enabled = false;
					this.GlobalVariable_MoveUp.Enabled = false;
					this.GlobalVariable_FixOrder.Enabled = true;
				}
			}
		}

		private unsafe void RefreshTriggers()
		{
			cEditor* editor = this.Editor;
			if (*(int*)(editor + 32 / sizeof(cEditor)) == 0)
			{
				this.GlobalTriggerControl.Items = new Script_GlobalVariableControl_ListItem[0];
				this.RefreshTriggerData(null, 0);
				this.Trigger_MoveDown.Enabled = false;
				this.Trigger_MoveUp.Enabled = false;
				this.Trigger_FixOrder.Enabled = false;
				this.Trigger_Delete.Enabled = false;
			}
			else
			{
				Script_GlobalVariableControl_ListItem[] array = new Script_GlobalVariableControl_ListItem[*(int*)(editor + 32 / sizeof(cEditor))];
				int num = 0;
				int num2 = *(int*)(editor + 32 / sizeof(cEditor));
				if (0 < num2)
				{
					do
					{
						cEditor* ptr = editor;
						cTrigger* ptr2 = *(num * 4 + *(ptr + 28));
						Script_GlobalVariableControl_ListSubItem[] array2 = new Script_GlobalVariableControl_ListSubItem[3];
						array2[0] = new Script_GlobalVariableControl_ListSubItem();
						uint num3 = (uint)(*(ptr2 + 8));
						sbyte* value;
						if (num3 != 0u)
						{
							value = num3;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						array2[0].Text = new string((sbyte*)value);
						array2[1] = new Script_GlobalVariableControl_ListSubItem();
						int num4 = *(ptr2 + 16);
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr3 = <Module>.?GetEventTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eEvent_Type@Script@@@Z(&gBaseString<char>, num4);
						try
						{
							uint num5 = (uint)(*(int*)ptr3);
							sbyte* value2;
							if (num5 != 0u)
							{
								value2 = num5;
							}
							else
							{
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							array2[1].Text = new string((sbyte*)value2);
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
						array2[2] = new Script_GlobalVariableControl_ListSubItem();
						string text;
						if (*(ptr2 + 48) != 0)
						{
							text = "yes";
						}
						else
						{
							text = new string((sbyte*)(&<Module>.??_C@_02KAJCLHKP@no?$AA@));
						}
						array2[2].Text = text;
						array[num] = new Script_GlobalVariableControl_ListItem();
						array[num].SubItems = array2;
						num++;
						editor = this.Editor;
					}
					while (num < *(int*)(editor + 32 / sizeof(cEditor)));
				}
				this.GlobalTriggerControl.Items = array;
				if (this.GlobalTriggerControl.IsInOriginalOrder())
				{
					byte enabled = (this.SelectedTriggerIndex + 1 < *(int*)(this.Editor + 32 / sizeof(cEditor))) ? 1 : 0;
					this.Trigger_MoveDown.Enabled = (enabled != 0);
					byte enabled2 = (this.SelectedTriggerIndex > 0) ? 1 : 0;
					this.Trigger_MoveUp.Enabled = (enabled2 != 0);
					this.Trigger_FixOrder.Enabled = false;
				}
				else
				{
					this.Trigger_MoveDown.Enabled = false;
					this.Trigger_MoveUp.Enabled = false;
					this.Trigger_FixOrder.Enabled = true;
				}
				this.Trigger_Delete.Enabled = true;
			}
		}

		private unsafe void RefreshTriggerData(cTrigger* trigger, int treeselchange)
		{
			if (trigger == null)
			{
				this.ActionListTreeControl.RootNode.Clear();
				this.ActionListTreeControl.Enabled = false;
				this.ActionListTreeControl.Dirty(true);
				this.ActionType_Label.Hide();
				this.AddActionButton.Hide();
				this.DeleteActionButton.Hide();
				this.DeleteActionBlockButton.Hide();
				this.DeleteActionPartButton.Hide();
				this.ConditionType_Label.Hide();
				this.AddConditionButton.Hide();
				this.DeleteConditionButton.Hide();
				this.DeleteConditionBlockButton.Hide();
				this.ActionTypeBox.Hide();
				this.ConditionTypeBox.Hide();
				this.NegateConditionButton.Hide();
				this.InsertSingleOrConditionButton.Hide();
				this.Actions_Insert.Enabled = false;
				this.Actions_Delete.Enabled = false;
				this.AddActionButton.Enabled = false;
				this.DeleteActionButton.Enabled = false;
				this.DeleteActionBlockButton.Enabled = false;
				this.DeleteActionPartButton.Enabled = false;
				this.AddConditionButton.Enabled = false;
				this.DeleteConditionButton.Enabled = false;
				this.DeleteConditionBlockButton.Enabled = false;
				this.ActionTypeBox.Enabled = false;
				this.ConditionTypeBox.Enabled = false;
				this.NegateConditionButton.Enabled = false;
				this.InsertSingleOrConditionButton.Enabled = false;
				this.TriggerVariableControl.Items = new Script_GlobalVariableControl_ListItem[0];
				this.TriggerVariableControl.Enabled = false;
				this.RefreshTriggerVariables(null);
			}
			else
			{
				this.TriggerVariableControl.Enabled = true;
				this.RefreshTriggerVariables(trigger);
				this.ActionListTreeControl.Enabled = true;
				int firstdisplayed;
				int num;
				this.ActionListTreeControl.GetSelectionInfos(ref firstdisplayed, ref num);
				if (treeselchange < 0)
				{
					treeselchange = -treeselchange;
					if (treeselchange < num)
					{
						num -= treeselchange;
					}
					else
					{
						num = 0;
					}
				}
				else
				{
					num = treeselchange + num;
				}
				this.ActionListTreeControl.RootNode.Clear();
				this.Actions_Insert.Enabled = true;
				if (*(int*)(trigger + 40 / sizeof(cTrigger)) != 0)
				{
					this.Actions_Delete.Enabled = true;
					ActionListTreeControl_Node[] array = new ActionListTreeControl_Node[*(int*)(trigger + 40 / sizeof(cTrigger))];
					array[0] = null;
					int num2 = 0;
					int num3 = *(int*)(trigger + 40 / sizeof(cTrigger));
					if (0 < num3)
					{
						cTrigger* ptr = trigger + 36 / sizeof(cTrigger);
						do
						{
							cAction* ptr2 = *(num2 * 4 + *(int*)ptr);
							if (*(ptr2 + 436) == 0 && array[0] != null)
							{
								this.ActionListTreeControl.RootNode.AddNode(array[0]);
							}
							GBaseString<char> gBaseString<char>;
							GBaseString<char>* ptr3 = <Module>.ScriptEditor.cAction.GetAsFormattedString(ptr2, &gBaseString<char>);
							try
							{
								uint num4 = (uint)(*(int*)ptr3);
								sbyte* value;
								if (num4 != 0u)
								{
									value = num4;
								}
								else
								{
									value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								int num5 = *(ptr2 + 436);
								array[num5] = new ActionListTreeControl_Node(new string((sbyte*)value), true);
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
							int num6 = *(ptr2 + 436);
							array[num6].ActionIndex = num2;
							if (*(ptr2 + 436) != 0)
							{
								int num7 = *(ptr2 + 436);
								int num8 = num7;
								int num9 = num7;
								array[num9 - 1].AddNode(array[num8]);
							}
							switch (*(ptr2 + 4))
							{
							case 1:
							case 2:
							case 3:
							case 5:
							case 8:
							case 11:
							{
								if (*(ptr2 + 460) != 0)
								{
									int num10 = *(ptr2 + 436);
									array[num10].Expand();
								}
								int num11 = *(ptr2 + 436);
								array[num11 + 1] = null;
								break;
							}
							}
							int num12 = *(ptr2 + 4);
							if (num12 > 0 && (num12 <= 2 || num12 == 11))
							{
								int num13 = 0;
								int num14 = *(ptr2 + 12);
								if (0 < num14)
								{
									cAction* ptr4 = ptr2 + 8;
									do
									{
										GBaseString<char> gBaseString<char>2;
										GBaseString<char>* ptr5 = <Module>.ScriptEditor.cCondition.GetAsFormattedString(*(num13 * 4 + *ptr4), &gBaseString<char>2);
										ActionListTreeControl_Node actionListTreeControl_Node;
										try
										{
											uint num15 = (uint)(*(int*)ptr5);
											actionListTreeControl_Node = new ActionListTreeControl_Node(new string((sbyte*)((num15 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num15)), true);
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
										actionListTreeControl_Node.ActionIndex = num2;
										actionListTreeControl_Node.ConditionIndex = num13;
										array[*(ptr2 + 436)].AddHeaderNode(actionListTreeControl_Node);
										num13++;
									}
									while (num13 < *(ptr2 + 12));
								}
								ActionListTreeControl_Node actionListTreeControl_Node2 = new ActionListTreeControl_Node("r:End ConditionList", true);
								actionListTreeControl_Node2.ActionIndex = num2;
								actionListTreeControl_Node2.ConditionIndex = *(ptr2 + 12);
								array[*(ptr2 + 436)].AddHeaderNode(actionListTreeControl_Node2);
							}
							num2++;
						}
						while (num2 < *(int*)(trigger + 40 / sizeof(cTrigger)));
					}
					if (array[0] != null)
					{
						this.ActionListTreeControl.RootNode.AddNode(array[0]);
					}
				}
				else
				{
					this.Actions_Delete.Enabled = false;
				}
				ActionListTreeControl_Node actionListTreeControl_Node3 = new ActionListTreeControl_Node(new string((sbyte*)(&<Module>.??_C@_05MFELCDH@r?3End?$AA@)), true);
				actionListTreeControl_Node3.ActionIndex = *(int*)(trigger + 40 / sizeof(cTrigger));
				this.ActionListTreeControl.RootNode.AddNode(actionListTreeControl_Node3);
				this.ActionListTreeControl.Dirty(false);
				this.ActionListTreeControl.SetSelectionInfos(firstdisplayed, num);
			}
		}

		private unsafe void RefreshTriggerVariables(cTrigger* trigger)
		{
			if (trigger != null && *(int*)(trigger + 28 / sizeof(cTrigger)) != 0)
			{
				this.TriggerVariable_Delete.Enabled = true;
				int num = *(int*)(trigger + 28 / sizeof(cTrigger));
				Script_GlobalVariableControl_ListItem[] array = new Script_GlobalVariableControl_ListItem[num];
				int num2 = 0;
				int num3 = num;
				if (0 < num3)
				{
					cTrigger* ptr = trigger + 24 / sizeof(cTrigger);
					do
					{
						cVariable* ptr2 = *(num2 * 4 + *(int*)ptr);
						Script_GlobalVariableControl_ListSubItem[] array2 = new Script_GlobalVariableControl_ListSubItem[4];
						array2[0] = new Script_GlobalVariableControl_ListSubItem();
						uint num4 = (uint)(*<Module>.ScriptEditor.cVariable.GetName(ptr2));
						sbyte* value;
						if (num4 != 0u)
						{
							value = num4;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						array2[0].Text = new string((sbyte*)value);
						array2[1] = new Script_GlobalVariableControl_ListSubItem();
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr3 = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(&gBaseString<char>, *(ptr2 + 16), 0);
						try
						{
							uint num5 = (uint)(*(int*)ptr3);
							sbyte* value2;
							if (num5 != 0u)
							{
								value2 = num5;
							}
							else
							{
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							array2[1].Text = new string((sbyte*)value2);
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
						array2[2] = new Script_GlobalVariableControl_ListSubItem();
						GBaseString<char> gBaseString<char>2;
						GBaseString<char>* ptr4 = <Module>.ScriptEditor.sValue.GetAsString(ptr2 + 16, &gBaseString<char>2, this.Editor);
						try
						{
							uint num6 = (uint)(*(int*)ptr4);
							sbyte* value3;
							if (num6 != 0u)
							{
								value3 = num6;
							}
							else
							{
								value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							array2[2].Text = new string((sbyte*)value3);
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
						array2[3] = new Script_GlobalVariableControl_ListSubItem();
						int num7 = *(ptr2 + 32);
						string text;
						if (num7 > 0)
						{
							int num8 = num7;
							text = string.Format(new string((sbyte*)(&<Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@)), num8);
						}
						else
						{
							text = new string((sbyte*)(&<Module>.??_C@_02KAJCLHKP@no?$AA@));
						}
						array2[3].Text = text;
						array[num2] = new Script_GlobalVariableControl_ListItem();
						array[num2].SubItems = array2;
						num2++;
					}
					while (num2 < *(int*)(trigger + 28 / sizeof(cTrigger)));
				}
				this.TriggerVariableControl.Items = array;
				Script_GlobalVariableControl triggerVariableControl = this.TriggerVariableControl;
				if (triggerVariableControl.IsInOriginalOrder())
				{
					byte enabled = (triggerVariableControl.SelectedIndex + 1 < *(int*)(trigger + 28 / sizeof(cTrigger))) ? 1 : 0;
					this.TriggerVariable_MoveDown.Enabled = (enabled != 0);
					byte enabled2 = (this.TriggerVariableControl.SelectedIndex > 0) ? 1 : 0;
					this.TriggerVariable_MoveUp.Enabled = (enabled2 != 0);
					this.TriggerVariable_FixOrder.Enabled = false;
				}
				else
				{
					this.TriggerVariable_MoveDown.Enabled = false;
					this.TriggerVariable_MoveUp.Enabled = false;
					this.TriggerVariable_FixOrder.Enabled = true;
				}
			}
			else
			{
				this.TriggerVariableControl.Items = new Script_GlobalVariableControl_ListItem[0];
				this.TriggerVariable_Delete.Enabled = false;
				this.TriggerVariable_FixOrder.Enabled = false;
				this.TriggerVariable_MoveDown.Enabled = false;
				this.TriggerVariable_MoveUp.Enabled = false;
			}
		}

		private unsafe void Trigger_Create_Click(object sender, EventArgs e)
		{
			<Module>.ScriptEditor.cEditor.CreateTrigger(this.Editor, 0);
			this.RefreshTriggers();
			int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
			this.Edit_Undo.Enabled = ((byte)num != 0);
			cEditor* editor = this.Editor;
			int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
			this.Edit_Redo.Enabled = ((byte)num2 != 0);
		}

		private unsafe void Trigger_Create_Empty_Click(object sender, EventArgs e)
		{
			<Module>.ScriptEditor.cEditor.CreateTrigger(this.Editor, 1);
			this.RefreshTriggers();
			int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
			this.Edit_Undo.Enabled = ((byte)num != 0);
			cEditor* editor = this.Editor;
			int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
			this.Edit_Redo.Enabled = ((byte)num2 != 0);
		}

		private unsafe void Trigger_Copy_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.GlobalTriggerControl.SelectedIndex;
			if (selectedIndex != -1)
			{
				cEditor* editor = this.Editor;
				cTrigger* ptr = *(selectedIndex * 4 + *(int*)(editor + 28 / sizeof(cEditor)));
				if (<Module>.ScriptEditor.cEditor.CreateTrigger(editor, ptr) != null)
				{
					int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num != 0);
					cEditor* editor2 = this.Editor;
					int num2 = (*(editor2 + 68) < *(editor2 + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num2 != 0);
					this.RefreshAll();
				}
			}
		}

		private unsafe void Trigger_Delete_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.GlobalTriggerControl.SelectedIndex;
			if (selectedIndex != -1)
			{
				<Module>.ScriptEditor.cEditor.DeleteTrigger(this.Editor, selectedIndex, false);
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor = this.Editor;
				int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
				this.RefreshAll();
			}
		}

		private void ScriptEditorForm_Deactivate(object sender, EventArgs e)
		{
			this.SaveScript();
		}

		private void MainMenu_Scripts_Click(object sender, EventArgs e)
		{
			this.ChangeScript(sender.Index);
		}

		private unsafe void Script_New_Click(object sender, EventArgs e)
		{
			this.SaveScript();
			int index;
			cEditor* ptr = <Module>.ScriptEditor.cManager.CreateEditor(<Module>.SafeWorld + 5128 / sizeof(GEditorWorld), ref index);
			this.Editor = ptr;
			if (ptr != null)
			{
				this.RefreshScriptList();
				this.ChangeScript(index);
				this.RefreshAll();
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor = this.Editor;
				int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
			}
		}

		private void Script_Save_Click(object sender, EventArgs e)
		{
			this.SaveScript();
		}

		private unsafe void Script_Delete_Click(object sender, EventArgs e)
		{
			if (*(int*)(<Module>.SafeWorld + 4084 / sizeof(GEditorWorld)) >= 2)
			{
				int scriptIndex = this.ScriptIndex;
				int num = scriptIndex;
				<Module>.ScriptEditor.cManager.DeleteEditor(<Module>.SafeWorld + 5128 / sizeof(GEditorWorld), scriptIndex);
				this.ScriptIndex = -1;
				if (num >= *(int*)(<Module>.SafeWorld + 4084 / sizeof(GEditorWorld)))
				{
					num--;
				}
				this.RefreshScriptList();
				this.ChangeScript(num);
			}
		}

		private unsafe void Script_Import_Click(object sender, EventArgs e)
		{
			NFileDialog nFileDialog = new NFileDialog(null, true);
			nFileDialog.DefaultExtension = "hbs";
			nFileDialog.AvailableModes = 2;
			nFileDialog.SelectedMode = 2;
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
				if (ptr3 != null)
				{
					int index;
					bool flag = <Module>.ScriptEditor.cManager.ImportEditor(<Module>.SafeWorld + 5128 / sizeof(GEditorWorld), ref index, ptr3) != null;
					object arg_A3_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, *(*(int*)ptr3));
					if (flag)
					{
						this.RefreshScriptList();
						this.ChangeScript(index);
						this.RefreshAll();
						int num2 = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
						this.Edit_Undo.Enabled = ((byte)num2 != 0);
						cEditor* editor = this.Editor;
						int num3 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
						this.Edit_Redo.Enabled = ((byte)num3 != 0);
					}
				}
			}
		}

		private unsafe void Script_Export_Click(object sender, EventArgs e)
		{
			NFileDialog nFileDialog = new NFileDialog(null, true);
			nFileDialog.DefaultExtension = "hbs";
			nFileDialog.AvailableModes = 4;
			nFileDialog.SelectedMode = 4;
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
				if (ptr3 != null)
				{
					<Module>.ScriptEditor.cEditor.Store(this.Editor, ptr3);
					object arg_92_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, *(*(int*)ptr3));
				}
			}
		}

		private unsafe void Edit_Copy_Click(object sender, EventArgs e)
		{
			if (this.GlobalTriggerControl.SelectedIndex != -1)
			{
				int arg_20_0 = this.SelectedTriggerIndex;
				cEditor* editor = this.Editor;
				cTrigger* ptr = *(arg_20_0 * 4 + *(editor + 28));
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node selectedNode = actionListTreeControl.SelectedNode;
				if (selectedNode != null)
				{
					ActionListTreeControl_Node selectedNode_End = actionListTreeControl.SelectedNode_End;
					if (selectedNode_End != null)
					{
						int actionIndex;
						int actionIndex2;
						if (selectedNode.ActionIndex <= selectedNode_End.ActionIndex)
						{
							actionIndex = selectedNode.ActionIndex;
							actionIndex2 = selectedNode_End.ActionIndex;
						}
						else
						{
							actionIndex2 = selectedNode.ActionIndex;
							actionIndex = selectedNode_End.ActionIndex;
						}
						GStreamBuffer* ptr2 = <Module>.@new(36u);
						GStreamBuffer* ptr3;
						try
						{
							if (ptr2 != null)
							{
								ptr3 = <Module>.GStreamBuffer.{ctor}(ptr2);
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
						<Module>.GStreamBuffer.Clear(ptr3);
						if (<Module>.ScriptEditor.cTrigger.CopyActions(ptr, actionIndex, actionIndex2, ptr3) != null)
						{
							GStreamBuffer* clipboardStream = this.ClipboardStream;
							if (clipboardStream != null)
							{
								object arg_CA_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), clipboardStream, 1, *(*(int*)clipboardStream));
							}
							this.ClipboardStream = ptr3;
							this.Edit_Paste.Enabled = true;
						}
					}
				}
			}
		}

		private unsafe void Edit_Cut_Click(object sender, EventArgs e)
		{
			if (this.GlobalTriggerControl.SelectedIndex != -1)
			{
				int arg_20_0 = this.SelectedTriggerIndex;
				cEditor* editor = this.Editor;
				cTrigger* ptr = *(arg_20_0 * 4 + *(editor + 28));
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node selectedNode = actionListTreeControl.SelectedNode;
				if (selectedNode != null)
				{
					ActionListTreeControl_Node selectedNode_End = actionListTreeControl.SelectedNode_End;
					if (selectedNode_End != null)
					{
						int actionIndex;
						int actionIndex2;
						if (selectedNode.ActionIndex <= selectedNode_End.ActionIndex)
						{
							actionIndex = selectedNode.ActionIndex;
							actionIndex2 = selectedNode_End.ActionIndex;
						}
						else
						{
							actionIndex2 = selectedNode.ActionIndex;
							actionIndex = selectedNode_End.ActionIndex;
						}
						GStreamBuffer* ptr2 = <Module>.@new(36u);
						GStreamBuffer* ptr3;
						try
						{
							if (ptr2 != null)
							{
								ptr3 = <Module>.GStreamBuffer.{ctor}(ptr2);
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
						<Module>.GStreamBuffer.Clear(ptr3);
						if (<Module>.ScriptEditor.cTrigger.CopyActions(ptr, actionIndex, actionIndex2, ptr3) != null && <Module>.ScriptEditor.cTrigger.DeleteActionRange(ptr, actionIndex, actionIndex2) != null)
						{
							GStreamBuffer* clipboardStream = this.ClipboardStream;
							if (clipboardStream != null)
							{
								object arg_D7_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), clipboardStream, 1, *(*(int*)clipboardStream));
							}
							this.ClipboardStream = ptr3;
							this.Edit_Paste.Enabled = true;
							this.RefreshTriggerData(ptr, 0);
						}
					}
				}
			}
		}

		private unsafe void Edit_Paste_Click(object sender, EventArgs e)
		{
			if (this.GlobalTriggerControl.SelectedIndex != -1)
			{
				cTrigger* ptr = *(this.SelectedTriggerIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node selectedNode = actionListTreeControl.SelectedNode;
				if (selectedNode != null)
				{
					ActionListTreeControl_Node selectedNode_End = actionListTreeControl.SelectedNode_End;
					if (selectedNode_End != null)
					{
						int actionIndex;
						int actionIndex2;
						if (selectedNode == selectedNode_End)
						{
							actionIndex = selectedNode.ActionIndex;
							actionIndex2 = selectedNode_End.ActionIndex;
						}
						else if (selectedNode.ActionIndex <= selectedNode_End.ActionIndex)
						{
							actionIndex = selectedNode.ActionIndex;
							actionIndex2 = selectedNode_End.ActionIndex;
						}
						else
						{
							actionIndex2 = selectedNode.ActionIndex;
							actionIndex = selectedNode_End.ActionIndex;
						}
						byte b = (selectedNode == selectedNode_End) ? 1 : 0;
						if (<Module>.ScriptEditor.cTrigger.PasteActions(ptr, actionIndex, actionIndex2, b != 0, (GStream*)this.ClipboardStream) != null)
						{
							int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
							this.Edit_Undo.Enabled = ((byte)num != 0);
							cEditor* editor = this.Editor;
							int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
							this.Edit_Redo.Enabled = ((byte)num2 != 0);
							this.RefreshGlobalVariables();
							this.RefreshTriggerData(ptr, 0);
						}
					}
				}
			}
		}

		private unsafe void Edit_Clear_Click(object sender, EventArgs e)
		{
			if (this.GlobalTriggerControl.SelectedIndex != -1)
			{
				cTrigger* ptr = *(this.SelectedTriggerIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node selectedNode = actionListTreeControl.SelectedNode;
				if (selectedNode != null)
				{
					ActionListTreeControl_Node selectedNode_End = actionListTreeControl.SelectedNode_End;
					if (selectedNode_End != null)
					{
						int actionIndex;
						int actionIndex2;
						if (selectedNode.ActionIndex <= selectedNode_End.ActionIndex)
						{
							actionIndex = selectedNode.ActionIndex;
							actionIndex2 = selectedNode_End.ActionIndex;
						}
						else
						{
							actionIndex2 = selectedNode.ActionIndex;
							actionIndex = selectedNode_End.ActionIndex;
						}
						<Module>.ScriptEditor.cTrigger.DeleteActionRange(ptr, actionIndex, actionIndex2);
					}
				}
			}
		}

		private void Edit_Refresh_Click(object sender, EventArgs e)
		{
			this.RefreshAll();
		}

		private unsafe void GlobalVariableControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalVariableControl = this.GlobalVariableControl;
			if (globalVariableControl.SelectedIndex != -1)
			{
				if (globalVariableControl.IsInOriginalOrder())
				{
					byte enabled = (globalVariableControl.SelectedIndex + 1 < *(int*)(this.Editor + 16 / sizeof(cEditor))) ? 1 : 0;
					this.GlobalVariable_MoveDown.Enabled = (enabled != 0);
					byte enabled2 = (this.GlobalVariableControl.SelectedIndex > 0) ? 1 : 0;
					this.GlobalVariable_MoveUp.Enabled = (enabled2 != 0);
					this.GlobalVariable_FixOrder.Enabled = false;
				}
				else
				{
					this.GlobalVariable_MoveDown.Enabled = false;
					this.GlobalVariable_MoveUp.Enabled = false;
					this.GlobalVariable_FixOrder.Enabled = true;
				}
			}
		}

		private unsafe void GlobalVariableControl_ItemDoubleClicked(object sender, EventArgs e)
		{
			int clickedIndex = this.GlobalVariableControl.ClickedIndex;
			cEditor* editor = this.Editor;
			cVariable* ptr = *(clickedIndex * 4 + *(editor + 12));
			ScriptVariablePropertiesForm scriptVariablePropertiesForm = new ScriptVariablePropertiesForm();
			Point location = base.Location;
			scriptVariablePropertiesForm.Location.X = (location.X - scriptVariablePropertiesForm.Width) / 2;
			Point location2 = base.Location;
			scriptVariablePropertiesForm.Location.Y = (location2.Y - scriptVariablePropertiesForm.Height) / 2;
			scriptVariablePropertiesForm.SetFrom(this.Editor, null, ptr);
			if (scriptVariablePropertiesForm.ShowDialog() == DialogResult.OK)
			{
				int num = <Module>.ScriptEditor.cEditor.BeginUndoBlock(this.Editor);
				int variable_Type = scriptVariablePropertiesForm.Variable_Type;
				if (variable_Type != 2 && *(ptr + 40) != 0)
				{
					<Module>.?ChangeVariableAutoChangeMode@cEditor@ScriptEditor@@$$FQAE_NHW4eAutoChange_Mode@cVariable@Script@@HH@Z(this.Editor, clickedIndex, 0, 0, 0);
				}
				GBaseString<char> gBaseString<char>;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, scriptVariablePropertiesForm.Variable_Name);
				try
				{
					<Module>.ScriptEditor.cEditor.RenameVariable(this.Editor, clickedIndex, ref gBaseString<char>);
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
				<Module>.?ChangeVariableType@cEditor@ScriptEditor@@$$FQAE_NHW4eValue_Type@Script@@@Z(this.Editor, clickedIndex, variable_Type);
				<Module>.ScriptEditor.cEditor.ChangeVariableValue(this.Editor, clickedIndex, scriptVariablePropertiesForm.Variable_Value);
				if (variable_Type == 2)
				{
					<Module>.?ChangeVariableAutoChangeMode@cEditor@ScriptEditor@@$$FQAE_NHW4eAutoChange_Mode@cVariable@Script@@HH@Z(this.Editor, clickedIndex, scriptVariablePropertiesForm.Variable_AutoChangeMode, scriptVariablePropertiesForm.Variable_AutoChange_Value, scriptVariablePropertiesForm.Variable_AutoChange_Period);
				}
				<Module>.ScriptEditor.cEditor.EndUndoBlock(this.Editor, num);
				this.RefreshAll();
			}
		}

		private unsafe void GlobalVariable_Create_Click(object sender, EventArgs e)
		{
			cVariable* ptr = <Module>.ScriptEditor.cEditor.CreateVariable(this.Editor);
			*(int*)(ptr + 16 / sizeof(cVariable)) = 2;
			*(int*)(ptr + 20 / sizeof(cVariable)) = 0;
			this.RefreshGlobalVariables();
			int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
			this.Edit_Undo.Enabled = ((byte)num != 0);
			cEditor* editor = this.Editor;
			int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
			this.Edit_Redo.Enabled = ((byte)num2 != 0);
		}

		private unsafe void GlobalVariable_Delete_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.GlobalVariableControl.SelectedIndex;
			if (selectedIndex != -1)
			{
				<Module>.ScriptEditor.cEditor.DeleteVariable(this.Editor, selectedIndex, false);
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor = this.Editor;
				int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
				this.RefreshAll();
			}
		}

		private void GlobalVariableControl_DragStarted(object sender, EventArgs e)
		{
			this.DragType = ScriptEditorForm.eDragType.DRAG_GlobalVariable;
			Script_GlobalVariableControl globalVariableControl = this.GlobalVariableControl;
			if (globalVariableControl.SelectedIndex != -1)
			{
				int selectedIndex = globalVariableControl.SelectedIndex;
				this.DragIndex = selectedIndex;
				globalVariableControl.DoDragDrop(selectedIndex, DragDropEffects.Link);
			}
		}

		private unsafe void GlobalVariableControl_SortModeChanged(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalVariableControl = this.GlobalVariableControl;
			if (globalVariableControl.SelectedIndex != -1)
			{
				int num = *(int*)(this.Editor + 16 / sizeof(cEditor));
				if (num == 0)
				{
					this.GlobalVariable_MoveDown.Enabled = false;
					this.GlobalVariable_MoveUp.Enabled = false;
					this.GlobalVariable_FixOrder.Enabled = false;
				}
				else if (globalVariableControl.IsInOriginalOrder())
				{
					byte enabled = (globalVariableControl.SelectedIndex + 1 < num) ? 1 : 0;
					this.GlobalVariable_MoveDown.Enabled = (enabled != 0);
					byte enabled2 = (this.GlobalVariableControl.SelectedIndex > 0) ? 1 : 0;
					this.GlobalVariable_MoveUp.Enabled = (enabled2 != 0);
					this.GlobalVariable_FixOrder.Enabled = false;
				}
				else
				{
					this.GlobalVariable_MoveDown.Enabled = false;
					this.GlobalVariable_MoveUp.Enabled = false;
					this.GlobalVariable_FixOrder.Enabled = true;
				}
			}
		}

		private unsafe void GlobalVariable_FixOrder_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalVariableControl = this.GlobalVariableControl;
			if (globalVariableControl.SelectedIndex != -1 && !globalVariableControl.IsInOriginalOrder())
			{
				uint num = (uint)globalVariableControl.SortIndices.Length;
				int* ptr = <Module>.new[]((num > 1073741823u) ? 4294967295u : (num << 2));
				int num2 = 0;
				globalVariableControl = this.GlobalVariableControl;
				if (0 < globalVariableControl.SortIndices.Length)
				{
					do
					{
						num2[ptr] = globalVariableControl.SortIndices[num2];
						num2++;
						globalVariableControl = this.GlobalVariableControl;
					}
					while (num2 < globalVariableControl.SortIndices.Length);
				}
				bool flag = <Module>.ScriptEditor.cEditor.FixVariableOrder(this.Editor, (int*)ptr, this.GlobalVariableControl.SortIndices.Length) != null;
				<Module>.delete[]((void*)ptr);
				if (flag)
				{
					int num3 = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num3 != 0);
					cEditor* editor = this.Editor;
					int num4 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num4 != 0);
					this.RefreshGlobalVariables();
					this.GlobalVariableControl.ForceUnsorted();
				}
			}
		}

		private unsafe void GlobalVariable_MoveUp_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalVariableControl = this.GlobalVariableControl;
			if (globalVariableControl.SelectedIndex != -1 && globalVariableControl.IsInOriginalOrder() && <Module>.ScriptEditor.cEditor.MoveVariableUp(this.Editor, globalVariableControl.SelectedIndex) != null)
			{
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor = this.Editor;
				int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
				this.RefreshGlobalVariables();
				globalVariableControl = this.GlobalVariableControl;
				globalVariableControl.SelectedIndex--;
			}
		}

		private unsafe void GlobalVariable_MoveDown_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalVariableControl = this.GlobalVariableControl;
			if (globalVariableControl.SelectedIndex != -1 && globalVariableControl.IsInOriginalOrder() && <Module>.ScriptEditor.cEditor.MoveVariableDown(this.Editor, globalVariableControl.SelectedIndex) != null)
			{
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor = this.Editor;
				int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
				this.RefreshGlobalVariables();
				globalVariableControl = this.GlobalVariableControl;
				globalVariableControl.SelectedIndex++;
			}
		}

		private void ScriptEntitiesFilterBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.RefreshScriptEntities();
		}

		private void ScriptEntitiesControl_DragStarted(object sender, EventArgs e)
		{
			this.DragType = ScriptEditorForm.eDragType.DRAG_Entity;
			Script_GlobalVariableControl scriptEntitiesControl = this.ScriptEntitiesControl;
			if (scriptEntitiesControl.SelectedIndex != -1)
			{
				int num = this.ScriptEntities_List[scriptEntitiesControl.SelectedIndex];
				this.DragIndex = num;
				scriptEntitiesControl.DoDragDrop(num, DragDropEffects.Link);
			}
		}

		private unsafe void ScriptEntities_ShowStoredUnits_CheckedChanged(object sender, EventArgs e)
		{
			int num = *(ref <Module>.ScriptEditor.EntityTypeIndices + 136);
			if (num < 0)
			{
				num = *(ref <Module>.ScriptEditor.EntityTypeIndices + 132);
				if (num < 0)
				{
					num = *(ref <Module>.ScriptEditor.EntityTypeIndices + 128);
					if (num < 0)
					{
						num = *(ref <Module>.ScriptEditor.EntityTypeIndices + 140);
					}
				}
			}
			if (this.ScriptEntitiesFilterBox.GetSelected(num))
			{
				this.RefreshScriptEntities();
			}
		}

		private unsafe void GlobalTriggerControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			int selectedIndex = globalTriggerControl.SelectedIndex;
			this.SelectedTriggerIndex = selectedIndex;
			if (selectedIndex == -1)
			{
				this.RefreshTriggerData(null, 0);
				this.Trigger_MoveDown.Enabled = false;
				this.Trigger_MoveUp.Enabled = false;
				this.Trigger_FixOrder.Enabled = false;
			}
			else
			{
				if (globalTriggerControl.IsInOriginalOrder())
				{
					byte enabled = (selectedIndex + 1 < *(int*)(this.Editor + 32 / sizeof(cEditor))) ? 1 : 0;
					this.Trigger_MoveDown.Enabled = (enabled != 0);
					byte enabled2 = (this.SelectedTriggerIndex > 0) ? 1 : 0;
					this.Trigger_MoveUp.Enabled = (enabled2 != 0);
					this.Trigger_FixOrder.Enabled = false;
				}
				else
				{
					this.Trigger_MoveDown.Enabled = false;
					this.Trigger_MoveUp.Enabled = false;
					this.Trigger_FixOrder.Enabled = true;
				}
				this.RefreshTriggerData(*(this.SelectedTriggerIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor))), 0);
			}
		}

		private void GlobalTriggerControl_ItemClicked(object sender, EventArgs e)
		{
		}

		private unsafe void GlobalTriggerControl_ItemDoubleClicked(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			int clickedColumnIndex = globalTriggerControl.ClickedColumnIndex;
			if (clickedColumnIndex != 0)
			{
				if (clickedColumnIndex != 1)
				{
					if (clickedColumnIndex == 2)
					{
						int clickedIndex = globalTriggerControl.ClickedIndex;
						cEditor* editor = this.Editor;
						cTrigger* ptr = *(clickedIndex * 4 + *(int*)(editor + 28 / sizeof(cEditor)));
						byte b = (*(ptr + 48) == 0) ? 1 : 0;
						<Module>.ScriptEditor.cEditor.SetTriggerActiveState(editor, ptr, b != 0);
						if (clickedIndex == this.SelectedTriggerIndex)
						{
							this.RefreshTriggerData(ptr, 0);
						}
						string text;
						if (*(ptr + 48) != 0)
						{
							text = "yes";
						}
						else
						{
							text = "no";
						}
						this.GlobalTriggerControl.Items[clickedIndex].SubItems[2].Text = text;
						this.GlobalTriggerControl.Invalidate();
						int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
						this.Edit_Undo.Enabled = ((byte)num != 0);
						cEditor* editor2 = this.Editor;
						int num2 = (*(editor2 + 68) < *(editor2 + 60)) ? 1 : 0;
						this.Edit_Redo.Enabled = ((byte)num2 != 0);
					}
				}
				else
				{
					int arg_108_0 = globalTriggerControl.ClickedIndex;
					cEditor* editor3 = this.Editor;
					cTrigger* ptr2 = *(arg_108_0 * 4 + *(editor3 + 28));
					int* ptr3 = (int*)(&<Module>.ScriptEditor.EventTypeList);
					if (<Module>.ScriptEditor.EventTypeList != 11)
					{
						do
						{
							ptr3 += 4 / sizeof(int);
						}
						while (*(int*)ptr3 != 11);
					}
					int num3 = ptr3 - ref <Module>.ScriptEditor.EventTypeList / sizeof(int) >> 2;
					object[] array = new object[num3];
					int selectedIndex = 0;
					int num4 = 0;
					if (0 < num3)
					{
						cTrigger* ptr4 = ptr2 + 16;
						do
						{
							GBaseString<char> gBaseString<char>;
							GBaseString<char>* ptr5 = <Module>.?GetEventTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eEvent_Type@Script@@@Z(&gBaseString<char>, *(num4 * 4 + ref <Module>.ScriptEditor.EventTypeList));
							try
							{
								uint num5 = (uint)(*(int*)ptr5);
								sbyte* value;
								if (num5 != 0u)
								{
									value = num5;
								}
								else
								{
									value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								array[num4] = new string((sbyte*)value);
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
							if (*(num4 * 4 + ref <Module>.ScriptEditor.EventTypeList) == *ptr4)
							{
								selectedIndex = num4;
							}
							num4++;
						}
						while (num4 < num3);
					}
					InPlaceEditing_ListBox inPlaceEditing_ListBox = new InPlaceEditing_ListBox();
					inPlaceEditing_ListBox.Items.Clear();
					inPlaceEditing_ListBox.Items.AddRange(array);
					Rectangle rectangle = default(Rectangle);
					this.GlobalTriggerControl.GetClickedRect(ref rectangle);
					inPlaceEditing_ListBox.SelectedIndex = selectedIndex;
					Point p = new Point(rectangle.X, rectangle.Y + rectangle.Height);
					Point location = this.GlobalTriggerControl.PointToScreen(p);
					inPlaceEditing_ListBox.Location = location;
					int width;
					if (rectangle.Width > 80)
					{
						width = rectangle.Width;
					}
					else
					{
						width = 80;
					}
					int num6 = inPlaceEditing_ListBox.Items.Count + 1;
					Size size = new Size(width, inPlaceEditing_ListBox.ItemHeight * num6);
					inPlaceEditing_ListBox.Size = size;
					inPlaceEditing_ListBox.SelectionReady += new EventHandler(this.TriggerEventBox_InPlace_SelectionReady);
					inPlaceEditing_ListBox.SelectionCancel += new EventHandler(this.TriggerEventBox_InPlace_SelectionCancel);
					inPlaceEditing_ListBox.Parent = this;
					inPlaceEditing_ListBox.CreateControl();
					<Module>.SetCapture((HWND__*)inPlaceEditing_ListBox.Handle.ToPointer());
				}
			}
			else
			{
				int arg_2F3_0 = *(globalTriggerControl.ClickedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				InPlaceEditing_TextBox inPlaceEditing_TextBox = new InPlaceEditing_TextBox();
				Rectangle rectangle2 = default(Rectangle);
				this.GlobalTriggerControl.GetClickedRect(ref rectangle2);
				uint num7 = (uint)(*(arg_2F3_0 + 8));
				sbyte* value2;
				if (num7 != 0u)
				{
					value2 = num7;
				}
				else
				{
					value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				inPlaceEditing_TextBox.Text = new string((sbyte*)value2);
				Point p2 = new Point(rectangle2.X, rectangle2.Y);
				Point location2 = this.GlobalTriggerControl.PointToScreen(p2);
				inPlaceEditing_TextBox.Location = location2;
				int width2;
				if (rectangle2.Width > 120)
				{
					width2 = rectangle2.Width;
				}
				else
				{
					width2 = 120;
				}
				Size size2 = new Size(width2, rectangle2.Height);
				inPlaceEditing_TextBox.Size = size2;
				inPlaceEditing_TextBox.EditingReady += new EventHandler(this.TriggerNameBox_InPlace_EditingReady);
				inPlaceEditing_TextBox.EditingCancel += new EventHandler(this.TriggerNameBox_InPlace_EditingCancel);
				inPlaceEditing_TextBox.Parent = this;
				inPlaceEditing_TextBox.CreateControl();
				<Module>.SetCapture((HWND__*)inPlaceEditing_TextBox.Handle.ToPointer());
			}
		}

		private void GlobalTriggerControl_DragStarted(object sender, EventArgs e)
		{
			this.DragType = ScriptEditorForm.eDragType.DRAG_Trigger;
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			int selectedIndex = globalTriggerControl.SelectedIndex;
			this.DragIndex = selectedIndex;
			globalTriggerControl.DoDragDrop(selectedIndex, DragDropEffects.Link);
		}

		private unsafe void GlobalTriggerControl_SortModeChanged(object sender, EventArgs e)
		{
			int num = *(int*)(this.Editor + 32 / sizeof(cEditor));
			if (num == 0)
			{
				this.Trigger_MoveDown.Enabled = false;
				this.Trigger_MoveUp.Enabled = false;
				this.Trigger_FixOrder.Enabled = false;
			}
			else
			{
				Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
				if (globalTriggerControl.IsInOriginalOrder())
				{
					byte enabled = (globalTriggerControl.SelectedIndex + 1 < num) ? 1 : 0;
					this.Trigger_MoveDown.Enabled = (enabled != 0);
					byte enabled2 = (this.GlobalTriggerControl.SelectedIndex > 0) ? 1 : 0;
					this.Trigger_MoveUp.Enabled = (enabled2 != 0);
					this.Trigger_FixOrder.Enabled = false;
				}
				else
				{
					this.Trigger_MoveDown.Enabled = false;
					this.Trigger_MoveUp.Enabled = false;
					this.Trigger_FixOrder.Enabled = true;
				}
			}
		}

		private unsafe void Trigger_FixOrder_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (!globalTriggerControl.IsInOriginalOrder())
			{
				uint num = (uint)globalTriggerControl.SortIndices.Length;
				int* ptr = <Module>.new[]((num > 1073741823u) ? 4294967295u : (num << 2));
				int num2 = 0;
				globalTriggerControl = this.GlobalTriggerControl;
				if (0 < globalTriggerControl.SortIndices.Length)
				{
					do
					{
						num2[ptr] = globalTriggerControl.SortIndices[num2];
						num2++;
						globalTriggerControl = this.GlobalTriggerControl;
					}
					while (num2 < globalTriggerControl.SortIndices.Length);
				}
				bool flag = <Module>.ScriptEditor.cEditor.FixTriggerOrder(this.Editor, (int*)ptr, this.GlobalTriggerControl.SortIndices.Length) != null;
				<Module>.delete[]((void*)ptr);
				if (flag)
				{
					int num3 = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num3 != 0);
					cEditor* editor = this.Editor;
					int num4 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num4 != 0);
					this.RefreshTriggers();
					this.GlobalTriggerControl.ForceUnsorted();
				}
			}
		}

		private unsafe void Trigger_MoveUp_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.IsInOriginalOrder() && <Module>.ScriptEditor.cEditor.MoveTriggerUp(this.Editor, globalTriggerControl.SelectedIndex) != null)
			{
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor = this.Editor;
				int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
				this.RefreshTriggers();
				globalTriggerControl = this.GlobalTriggerControl;
				globalTriggerControl.SelectedIndex--;
			}
		}

		private unsafe void Trigger_MoveDown_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.IsInOriginalOrder() && <Module>.ScriptEditor.cEditor.MoveTriggerDown(this.Editor, globalTriggerControl.SelectedIndex) != null)
			{
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor = this.Editor;
				int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
				this.RefreshTriggers();
				globalTriggerControl = this.GlobalTriggerControl;
				globalTriggerControl.SelectedIndex++;
			}
		}

		private unsafe void ActionListTreeControl_SelectionChanged(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node selectedNode = actionListTreeControl.SelectedNode;
				if (selectedNode != null)
				{
					ActionListTreeControl_Node selectedNode_End = actionListTreeControl.SelectedNode_End;
					if (selectedNode_End != null)
					{
						int actionIndex;
						int actionIndex2;
						if (selectedNode.ActionIndex <= selectedNode_End.ActionIndex)
						{
							actionIndex = selectedNode.ActionIndex;
							actionIndex2 = selectedNode_End.ActionIndex;
						}
						else
						{
							actionIndex2 = selectedNode.ActionIndex;
							actionIndex = selectedNode_End.ActionIndex;
						}
						<Module>.ScriptEditor.cTrigger.CalculateSelection(ptr, ref actionIndex, ref actionIndex2);
						this.ActionListTreeControl.SetSelectionExtendedInfos(actionIndex, actionIndex2);
						if (selectedNode == selectedNode_End && selectedNode.HeaderNode)
						{
							this.ActionType_Label.Hide();
							this.ActionTypeBox.Hide();
							this.AddActionButton.Hide();
							this.DeleteActionButton.Hide();
							this.DeleteActionBlockButton.Hide();
							this.DeleteActionPartButton.Hide();
							this.ActionTypeBox.Enabled = false;
							this.AddActionButton.Enabled = false;
							this.DeleteActionButton.Enabled = false;
							this.DeleteActionBlockButton.Enabled = false;
							this.DeleteActionPartButton.Enabled = false;
							this.ConditionTypeBox.Enabled = true;
							this.AddConditionButton.Enabled = true;
							cAction* ptr2 = *(selectedNode.ActionIndex * 4 + *(ptr + 36));
							int conditionIndex = selectedNode.ConditionIndex;
							if (selectedNode.ConditionIndex < *(ptr2 + 12))
							{
								this.DeleteConditionButton.Enabled = true;
								this.InsertSingleOrConditionButton.Enabled = true;
								int num = *(*(conditionIndex * 4 + *(ptr2 + 8)) + 4);
								if (num >= 0 && num <= 4)
								{
									this.NegateConditionButton.Enabled = false;
								}
								else
								{
									this.NegateConditionButton.Enabled = true;
								}
								if (num >= 2 && num <= 4)
								{
									this.DeleteConditionBlockButton.Enabled = true;
								}
								else
								{
									this.DeleteConditionBlockButton.Enabled = false;
								}
							}
							else
							{
								this.DeleteConditionButton.Enabled = false;
								this.DeleteConditionBlockButton.Enabled = false;
								this.NegateConditionButton.Enabled = false;
								this.InsertSingleOrConditionButton.Enabled = false;
							}
							this.ConditionType_Label.Show();
							this.ConditionTypeBox.Show();
							this.AddConditionButton.Show();
							this.DeleteConditionButton.Show();
							this.DeleteConditionBlockButton.Show();
							this.NegateConditionButton.Show();
							this.InsertSingleOrConditionButton.Show();
						}
						else
						{
							this.ConditionType_Label.Hide();
							this.ConditionTypeBox.Hide();
							this.AddConditionButton.Hide();
							this.DeleteConditionButton.Hide();
							this.DeleteConditionBlockButton.Hide();
							this.NegateConditionButton.Hide();
							this.InsertSingleOrConditionButton.Hide();
							this.ConditionTypeBox.Enabled = false;
							this.AddConditionButton.Enabled = false;
							this.DeleteConditionButton.Enabled = false;
							this.DeleteConditionBlockButton.Enabled = false;
							this.NegateConditionButton.Enabled = false;
							this.InsertSingleOrConditionButton.Enabled = false;
							if (selectedNode != selectedNode_End)
							{
								this.ActionTypeBox.Enabled = false;
								this.AddActionButton.Enabled = false;
								this.DeleteActionButton.Enabled = true;
								this.DeleteActionBlockButton.Enabled = false;
								this.DeleteActionPartButton.Enabled = false;
							}
							else
							{
								this.ActionTypeBox.Enabled = true;
								this.AddActionButton.Enabled = true;
								int num2;
								if (selectedNode.ActionIndex < *(ptr + 40))
								{
									num2 = *(*(selectedNode.ActionIndex * 4 + *(ptr + 36)) + 4);
									this.DeleteActionButton.Enabled = true;
								}
								else
								{
									num2 = 168;
									this.DeleteActionButton.Enabled = false;
								}
								switch (num2)
								{
								case 1:
								case 2:
								case 3:
								case 4:
								case 5:
								case 7:
								case 8:
								case 10:
								case 11:
								case 12:
									this.DeleteActionBlockButton.Enabled = true;
									goto IL_3E2;
								}
								this.DeleteActionBlockButton.Enabled = false;
								IL_3E2:
								if (num2 >= 2 && num2 <= 3)
								{
									this.DeleteActionPartButton.Enabled = true;
								}
								else
								{
									this.DeleteActionPartButton.Enabled = false;
								}
							}
							this.ActionType_Label.Show();
							this.ActionTypeBox.Show();
							this.AddActionButton.Show();
							this.DeleteActionButton.Show();
							this.DeleteActionBlockButton.Show();
							this.DeleteActionPartButton.Show();
						}
					}
				}
			}
		}

		private unsafe void ActionListTreeControl_ExpandChanged(object sender, EventArgs e)
		{
			ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
			if (selectedNode != null)
			{
				cTrigger* ptr = *(this.GlobalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				int actionIndex = selectedNode.ActionIndex;
				if (actionIndex < *(ptr + 40))
				{
					cAction* ptr2 = *(actionIndex * 4 + *(ptr + 36));
					int num = (*(ptr2 + 460) == 0) ? 1 : 0;
					*(ptr2 + 460) = (byte)num;
				}
			}
		}

		private unsafe void ActionListTreeControl_MouseTargetChanged(object sender, EventArgs e)
		{
			Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
			ActionListTreeControl_Node mouseTargetNode = actionListTreeControl.MouseTargetNode;
			if (mouseTargetNode == null)
			{
				this.StatusLine.Text = string.Empty;
			}
			else
			{
				ActionListTreeControl_Node_TextElement mouseTargetTextElement = actionListTreeControl.MouseTargetTextElement;
				int arg_46_0 = this.GlobalTriggerControl.SelectedIndex;
				cEditor* editor = this.Editor;
				cTrigger* ptr = *(arg_46_0 * 4 + *(editor + 28));
				int actionIndex = mouseTargetNode.ActionIndex;
				int num = *(ptr + 40);
				if (actionIndex < num)
				{
					cAction* ptr2 = *(actionIndex * 4 + *(ptr + 36));
					if (mouseTargetNode.HeaderNode)
					{
						int conditionIndex = mouseTargetNode.ConditionIndex;
						int num2 = *(ptr2 + 12);
						if (conditionIndex < num2)
						{
							cCondition* ptr3 = *(conditionIndex * 4 + *(ptr2 + 8));
							string[] array = new string[4];
							int num3 = *(ptr3 + 4);
							GBaseString<char> gBaseString<char>;
							GBaseString<char>* ptr4 = <Module>.?GetConditionTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eCondition_Type@Script@@_N@Z(&gBaseString<char>, num3, 0);
							try
							{
								uint num4 = (uint)(*(int*)ptr4);
								sbyte* value;
								if (num4 != 0u)
								{
									value = num4;
								}
								else
								{
									value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								array[0] = new string((sbyte*)value);
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
							GBaseString<char> gBaseString<char>2;
							GBaseString<char>* ptr5 = <Module>.ScriptEditor.cCondition.GetAsString(ptr3, &gBaseString<char>2);
							try
							{
								uint num5 = (uint)(*(int*)ptr5);
								sbyte* value2;
								if (num5 != 0u)
								{
									value2 = num5;
								}
								else
								{
									value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								array[1] = new string((sbyte*)value2);
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
							sParameter* ptr6 = ptr3 + mouseTargetTextElement.ParameterIndex * 52 + 12;
							if (*ptr6 == 0 && *(ptr6 + 28) != 0)
							{
								string[] array2 = new string[4];
								array2[0] = mouseTargetTextElement.Text;
								string text;
								if (*(ptr6 + 28) == 2)
								{
									text = "global";
								}
								else
								{
									text = new string((sbyte*)(&<Module>.??_C@_05IDKHKMLA@local?$AA@));
								}
								array2[1] = text;
								GBaseString<char> gBaseString<char>3;
								GBaseString<char>* ptr7 = <Module>.ScriptEditor.GetValueTypeAsString(&gBaseString<char>3, *(ptr6 + 32));
								try
								{
									array2[2] = new string(<Module>.GBaseString<char>..PBD(ptr7));
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
								array2[3] = new string(<Module>.GBaseString<char>..PBD(ptr6 + 44));
								array[2] = string.Format("{0} was a {1} variable of type {2} with name {3}", array2);
							}
							else
							{
								array[2] = mouseTargetTextElement.Text;
							}
							cParameterInfoArray cParameterInfoArray = 0;
							*(ref cParameterInfoArray + 4) = 0;
							*(ref cParameterInfoArray + 8) = 0;
							try
							{
								bool flag;
								if (<Module>.ScriptEditor.cCondition.GetParameterBaseType(ptr3, mouseTargetTextElement.ParameterIndex, ref cParameterInfoArray, ref flag) != null)
								{
									array[3] = "Not implemented";
								}
								else
								{
									array[3] = "No info!";
								}
								this.StatusLine.Lines = array;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
								throw;
							}
							<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						}
					}
					else
					{
						string[] array3 = new string[4];
						int num6 = *(ptr2 + 4);
						GBaseString<char> gBaseString<char>4;
						GBaseString<char>* ptr8 = <Module>.?GetActionTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eAction_Type@Script@@@Z(&gBaseString<char>4, num6);
						try
						{
							uint num7 = (uint)(*(int*)ptr8);
							sbyte* value3;
							if (num7 != 0u)
							{
								value3 = num7;
							}
							else
							{
								value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							array3[0] = new string((sbyte*)value3);
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
						GBaseString<char> gBaseString<char>5;
						GBaseString<char>* ptr9 = <Module>.ScriptEditor.cAction.GetAsString(ptr2, &gBaseString<char>5);
						try
						{
							uint num8 = (uint)(*(int*)ptr9);
							sbyte* value4;
							if (num8 != 0u)
							{
								value4 = num8;
							}
							else
							{
								value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							array3[1] = new string((sbyte*)value4);
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
						sParameter* ptr10 = ptr2 + mouseTargetTextElement.ParameterIndex * 52 + 20;
						if (*ptr10 == 0 && *(ptr10 + 28) != 0)
						{
							string[] array4 = new string[4];
							array4[0] = mouseTargetTextElement.Text;
							string text2;
							if (*(ptr10 + 28) == 2)
							{
								text2 = "global";
							}
							else
							{
								text2 = new string((sbyte*)(&<Module>.??_C@_05IDKHKMLA@local?$AA@));
							}
							array4[1] = text2;
							GBaseString<char> gBaseString<char>6;
							GBaseString<char>* ptr11 = <Module>.ScriptEditor.GetValueTypeAsString(&gBaseString<char>6, *(ptr10 + 32));
							try
							{
								array4[2] = new string(<Module>.GBaseString<char>..PBD(ptr11));
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
								throw;
							}
							<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>6);
							array4[3] = new string(<Module>.GBaseString<char>..PBD(ptr10 + 44));
							array3[2] = string.Format("{0} was a {1} variable of type {2} with name {3}", array4);
						}
						else
						{
							array3[2] = mouseTargetTextElement.Text;
						}
						cParameterInfoArray cParameterInfoArray2 = 0;
						*(ref cParameterInfoArray2 + 4) = 0;
						*(ref cParameterInfoArray2 + 8) = 0;
						try
						{
							bool flag2;
							if (<Module>.ScriptEditor.cAction.GetParameterBaseType(ptr2, mouseTargetTextElement.ParameterIndex, ref cParameterInfoArray2, ref flag2) != null)
							{
								array3[3] = "Not implemented";
							}
							else
							{
								array3[3] = "No info!";
							}
							this.StatusLine.Lines = array3;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
					}
				}
			}
		}

		private void ActionListTreeControl_MouseTargetDoubleClicked(object sender, EventArgs e)
		{
		}

		private unsafe void ActionListTreeControl_MouseTargetOnDrop(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node mouseTargetNode = actionListTreeControl.MouseTargetNode;
				ActionListTreeControl_Node_TextElement mouseTargetTextElement = actionListTreeControl.MouseTargetTextElement;
				int arg_43_0 = globalTriggerControl.SelectedIndex;
				cEditor* editor = this.Editor;
				cEditor* ptr = editor;
				cTrigger* ptr2 = *(arg_43_0 * 4 + *(ptr + 28));
				int actionIndex = mouseTargetNode.ActionIndex;
				int num = *(ptr2 + 40);
				if (actionIndex < num)
				{
					int parameterIndex = mouseTargetTextElement.ParameterIndex;
					cVariable* ptr4;
					int num2;
					int num3;
					switch (this.DragType)
					{
					case ScriptEditorForm.eDragType.DRAG_GlobalVariable:
					{
						int arg_9A_0 = this.DragIndex;
						cEditor* ptr3 = editor;
						ptr4 = *(arg_9A_0 * 4 + *(ptr3 + 12));
						num2 = 2;
						num3 = 4;
						break;
					}
					case ScriptEditorForm.eDragType.DRAG_LocalVariable:
						ptr4 = *(this.DragIndex * 4 + *(ptr2 + 24));
						num2 = 3;
						num3 = 5;
						if (((*(int*)(ptr4 + 12 / sizeof(cVariable)) == 2) ? 1 : 0) != 0)
						{
							int num4 = 0;
							if (0 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2))
							{
								do
								{
									if (*(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4) + 4) == 5 || *(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4) + 4) == 8)
									{
										int arg_12C_0 = *(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4) + 440);
										int num5 = *(int*)ptr4;
										if (arg_12C_0 == num5)
										{
											break;
										}
									}
									num4++;
								}
								while (num4 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2));
							}
							if (num4 == <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) || actionIndex <= num4)
							{
								return;
							}
							int num6 = (<Module>.?GetType@cAction@ScriptEditor@@$$FQBE?AW4eAction_Type@Script@@XZ(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4)) == 5) ? 7 : 10;
							int num7 = <Module>.ScriptEditor.cAction.GetDepth(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4));
							if (num4 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2))
							{
								while (<Module>.?GetType@cAction@ScriptEditor@@$$FQBE?AW4eAction_Type@Script@@XZ(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4)) != num6 || <Module>.ScriptEditor.cAction.GetDepth(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4)) != num7)
								{
									num4++;
									if (num4 >= <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2))
									{
										break;
									}
								}
							}
							if (num4 == <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) || actionIndex >= num4)
							{
								return;
							}
						}
						else if (<Module>.ScriptEditor.cVariable.IsAuto(ptr4) != null)
						{
							int num8 = 0;
							if (0 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2))
							{
								do
								{
									if (*(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num8) + 4) == 39)
									{
										int num9 = *(int*)ptr4;
										if (<Module>.ScriptEditor.cAction.GetAutoVariableIndex(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num8)) == num9)
										{
											break;
										}
									}
									num8++;
								}
								while (num8 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2));
							}
							if (num8 == <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) || actionIndex <= num8)
							{
								return;
							}
							int num10 = <Module>.ScriptEditor.cAction.GetDepth(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num8));
							if (num8 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2))
							{
								while (<Module>.ScriptEditor.cAction.GetDepth(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num8)) >= num10)
								{
									num8++;
									if (num8 >= <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2))
									{
										break;
									}
								}
							}
							if (actionIndex >= num8)
							{
								return;
							}
						}
						break;
					case ScriptEditorForm.eDragType.DRAG_Entity:
					{
						int arg_BA_0 = this.DragIndex;
						cEditor* ptr5 = editor;
						ptr4 = *(arg_BA_0 * 4 + *(ptr5 + 44));
						num2 = 6;
						num3 = 7;
						break;
					}
					case ScriptEditorForm.eDragType.DRAG_Trigger:
						if (mouseTargetNode.HeaderNode)
						{
							int conditionIndex = mouseTargetNode.ConditionIndex;
							int num11 = *(<Module>.ScriptEditor.cEditor.GetTrigger(editor, this.DragIndex) + 4);
							if (<Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(editor, ptr2, actionIndex, conditionIndex, parameterIndex, 10, num11) == null)
							{
								return;
							}
						}
						else
						{
							int num12 = *(<Module>.ScriptEditor.cEditor.GetTrigger(editor, this.DragIndex) + 4);
							if (<Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(editor, ptr2, actionIndex, parameterIndex, 10, num12) == null)
							{
								return;
							}
						}
						this.RefreshTriggerData(ptr2, 0);
						this.RefreshGlobalVariables();
						this.Edit_Undo.Enabled = (<Module>.ScriptEditor.cEditor.HasUndo(this.Editor) != null);
						this.Edit_Redo.Enabled = (<Module>.ScriptEditor.cEditor.HasRedo(this.Editor) != null);
						return;
					default:
						return;
					}
					if (mouseTargetNode.HeaderNode)
					{
						int conditionIndex2 = mouseTargetNode.ConditionIndex;
						GArray<int> gArray<int>;
						<Module>.GArray<int>.{ctor}(ref gArray<int>);
						try
						{
							if (<Module>.ScriptEditor.cEditor.GetConditionParameterChangePossibilities(this.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, ptr4, ref gArray<int>) != null)
							{
								goto IL_2A9;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
							throw;
						}
						<Module>.GArray<int>.{dtor}(ref gArray<int>);
						return;
						IL_2A9:
						try
						{
							if (*(ref gArray<int> + 4) != 0)
							{
								goto IL_2CF;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
							throw;
						}
						<Module>.GArray<int>.{dtor}(ref gArray<int>);
						return;
						IL_2CF:
						try
						{
							if (*(ref gArray<int> + 4) != 1)
							{
								goto IL_372;
							}
							int num13 = *<Module>.GArray<int>.[](ref gArray<int>, 0);
							if (num13 != -1)
							{
								goto IL_329;
							}
							if (<Module>.?ChangeConditionParameterVariable@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eParameter_Type@Script@@H@Z(this.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, num2, <Module>.ScriptEditor.cVariable.GetVariableIndex(ptr4)) != null)
							{
								goto IL_366;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
							throw;
						}
						<Module>.GArray<int>.{dtor}(ref gArray<int>);
						return;
						IL_329:
						try
						{
							int num13;
							if (<Module>.?ChangeConditionParameterMember@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eParameter_Type@Script@@HH@Z(this.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, num3, <Module>.ScriptEditor.cVariable.GetVariableIndex(ptr4), num13) != null)
							{
								goto IL_366;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
							throw;
						}
						<Module>.GArray<int>.{dtor}(ref gArray<int>);
						return;
						IL_366:
						<Module>.GArray<int>.{dtor}(ref gArray<int>);
						goto IL_524;
						IL_372:
						try
						{
							string[] array = new string[*(ref gArray<int> + 4)];
							int num14 = *<Module>.ScriptEditor.cVariable.GetValue(ptr4);
							int num15 = 0;
							if (0 < *(ref gArray<int> + 4))
							{
								do
								{
									array[num15] = new string(<Module>.GBaseString<char>..PBD(<Module>.ScriptEditor.cVariable.GetName(ptr4)));
									int num16 = *<Module>.GArray<int>.[](ref gArray<int>, num15);
									if (num16 != -1)
									{
										sMemberInfo* ptr6 = <Module>.?GetMember@ScriptEditor@@$$FYAABUsMemberInfo@1@W4eValue_Type@Script@@H@Z(num14, num16);
										array[num15] = array[num15] + new string((sbyte*)(&<Module>.??_C@_01LFCBOECM@?4?$AA@)) + new string(*ptr6);
									}
									num15++;
								}
								while (num15 < *(ref gArray<int> + 4));
							}
							this.ActionListTreeControl.StartListSelecting(array);
							this.ActionListTreeControl.Focus();
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
							throw;
						}
						<Module>.GArray<int>.{dtor}(ref gArray<int>);
						return;
					}
					GArray<int> gArray<int>2;
					<Module>.GArray<int>.{ctor}(ref gArray<int>2);
					try
					{
						if (<Module>.ScriptEditor.cEditor.GetActionParameterChangePossibilities(this.Editor, ptr2, actionIndex, parameterIndex, ptr4, ref gArray<int>2) != null)
						{
							goto IL_464;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>2));
						throw;
					}
					<Module>.GArray<int>.{dtor}(ref gArray<int>2);
					return;
					IL_464:
					try
					{
						if (*(ref gArray<int>2 + 4) != 0)
						{
							goto IL_48A;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>2));
						throw;
					}
					<Module>.GArray<int>.{dtor}(ref gArray<int>2);
					return;
					IL_48A:
					try
					{
						if (*(ref gArray<int>2 + 4) != 1)
						{
							goto IL_55B;
						}
						int num17 = *<Module>.GArray<int>.[](ref gArray<int>2, 0);
						if (num17 != -1)
						{
							goto IL_4E2;
						}
						if (<Module>.?ChangeActionParameterVariable@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eParameter_Type@Script@@H@Z(this.Editor, ptr2, actionIndex, parameterIndex, num2, <Module>.ScriptEditor.cVariable.GetVariableIndex(ptr4)) != null)
						{
							goto IL_51D;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>2));
						throw;
					}
					<Module>.GArray<int>.{dtor}(ref gArray<int>2);
					return;
					IL_4E2:
					try
					{
						int num17;
						if (<Module>.?ChangeActionParameterMember@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eParameter_Type@Script@@HH@Z(this.Editor, ptr2, actionIndex, parameterIndex, num3, <Module>.ScriptEditor.cVariable.GetVariableIndex(ptr4), num17) != null)
						{
							goto IL_51D;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>2));
						throw;
					}
					<Module>.GArray<int>.{dtor}(ref gArray<int>2);
					return;
					IL_51D:
					<Module>.GArray<int>.{dtor}(ref gArray<int>2);
					goto IL_524;
					IL_55B:
					try
					{
						string[] array2 = new string[*(ref gArray<int>2 + 4)];
						int num18 = *<Module>.ScriptEditor.cVariable.GetValue(ptr4);
						int num19 = 0;
						if (0 < *(ref gArray<int>2 + 4))
						{
							do
							{
								array2[num19] = new string(<Module>.GBaseString<char>..PBD(<Module>.ScriptEditor.cVariable.GetName(ptr4)));
								int num20 = *<Module>.GArray<int>.[](ref gArray<int>2, num19);
								if (num20 != -1)
								{
									sMemberInfo* ptr7 = <Module>.?GetMember@ScriptEditor@@$$FYAABUsMemberInfo@1@W4eValue_Type@Script@@H@Z(num18, num20);
									array2[num19] = array2[num19] + new string((sbyte*)(&<Module>.??_C@_01LFCBOECM@?4?$AA@)) + new string(*ptr7);
								}
								num19++;
							}
							while (num19 < *(ref gArray<int>2 + 4));
						}
						this.ActionListTreeControl.StartListSelecting(array2);
						this.ActionListTreeControl.Focus();
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>2));
						throw;
					}
					<Module>.GArray<int>.{dtor}(ref gArray<int>2);
					return;
					IL_524:
					this.Edit_Undo.Enabled = (<Module>.ScriptEditor.cEditor.HasUndo(this.Editor) != null);
					this.Edit_Redo.Enabled = (<Module>.ScriptEditor.cEditor.HasRedo(this.Editor) != null);
					this.RefreshAll();
				}
			}
		}

		private void ActionListTreeControl_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Link;
		}

		private unsafe void ActionListTreeControl_TextEditingRequest(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node mouseTargetNode = actionListTreeControl.MouseTargetNode;
				ActionListTreeControl_Node_TextElement mouseTargetTextElement = actionListTreeControl.MouseTargetTextElement;
				int selectedIndex = globalTriggerControl.SelectedIndex;
				cTrigger* ptr = <Module>.ScriptEditor.cEditor.GetTrigger(this.Editor, selectedIndex);
				int actionIndex = mouseTargetNode.ActionIndex;
				if (actionIndex < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr))
				{
					cAction* ptr2 = <Module>.ScriptEditor.cTrigger.GetAction(ptr, actionIndex);
					int parameterIndex = mouseTargetTextElement.ParameterIndex;
					string s = "0";
					if (!mouseTargetNode.HeaderNode)
					{
						cParameterInfoArray cParameterInfoArray;
						<Module>.ScriptEditor.cParameterInfoArray.{ctor}(ref cParameterInfoArray);
						try
						{
							bool flag;
							if (<Module>.ScriptEditor.cAction.GetParameterBaseType(ptr2, parameterIndex, ref cParameterInfoArray, ref flag) != null)
							{
								goto IL_F4A;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_F4A:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 2) == null)
							{
								goto IL_FDE;
							}
							sParameter* ptr3 = <Module>.ScriptEditor.cAction.GetParameter(ptr2, parameterIndex);
							if (*ptr3 == 1)
							{
								if (*(ptr3 + 4) == 2)
								{
									GBaseString<char> gBaseString<char>;
									GBaseString<char>* ptr4 = <Module>.ScriptEditor.sValue.GetAsEditingString(ptr3 + 4, &gBaseString<char>);
									try
									{
										s = new string(<Module>.GBaseString<char>..PBD(ptr4));
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
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						goto IL_FCC;
						IL_FDE:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 9) == null)
							{
								goto IL_106F;
							}
							string[] array = new string[12];
							int num = 0;
							do
							{
								array[num] = string.Format(new string((sbyte*)(&<Module>.??_C@_0M@OAEPIHCK@Player?5?$CD?$HL0?$HN?$AA@)), num + 1);
								num++;
							}
							while (num < 12);
							this.ActionListTreeControl.StartListSelecting(array);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 9;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_106F:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 21) == null)
							{
								goto IL_111A;
							}
							string[] array2 = new string[4];
							int num2 = 0;
							do
							{
								GBaseString<char> gBaseString<char>2;
								GBaseString<char>* ptr5 = <Module>.Script.GetUnitCategoryString(&gBaseString<char>2, num2);
								try
								{
									array2[num2] = new string(<Module>.GBaseString<char>..PBD(ptr5));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>2);
								num2++;
							}
							while (num2 < 4);
							this.ActionListTreeControl.StartListSelecting(array2);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 21;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_111A:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 22) == null)
							{
								goto IL_11C5;
							}
							string[] array3 = new string[4];
							int num3 = 0;
							do
							{
								GBaseString<char> gBaseString<char>3;
								GBaseString<char>* ptr6 = <Module>.Script.GetSupportTypeString(&gBaseString<char>3, num3);
								try
								{
									array3[num3] = new string(<Module>.GBaseString<char>..PBD(ptr6));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>3);
								num3++;
							}
							while (num3 < 4);
							this.ActionListTreeControl.StartListSelecting(array3);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 22;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_11C5:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 1) == null)
							{
								goto IL_127E;
							}
							string[] array4 = new string[2];
							int num4 = 0;
							do
							{
								sValue sValue;
								GBaseString<char> gBaseString<char>4;
								GBaseString<char>* ptr7 = <Module>.ScriptEditor.sValue.GetAsString(<Module>.??0sValue@ScriptEditor@@$$FQAE@W4eValue_Type@Script@@H@Z(ref sValue, 1, num4), &gBaseString<char>4, this.Editor);
								try
								{
									array4[num4] = new string(<Module>.GBaseString<char>..PBD(ptr7));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>4);
								num4++;
							}
							while (num4 < 2);
							this.ActionListTreeControl.StartListSelecting(array4);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 1;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_127E:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 13) == null)
							{
								goto IL_1389;
							}
							int num5 = 0;
							GEditorWorld* ptr8 = <Module>.SafeWorld + 3436 / sizeof(GEditorWorld);
							int num6 = <Module>.GHeap<GWWeather>.GetNext(ptr8, -1);
							if (num6 >= 0)
							{
								do
								{
									num5++;
									num6 = <Module>.GHeap<GWWeather>.GetNext(ptr8, num6);
								}
								while (num6 >= 0);
								if (num5 != 0)
								{
									goto IL_12EC;
								}
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_12EC:
						try
						{
							int num5;
							string[] array5 = new string[num5];
							int num7 = 0;
							GEditorWorld* ptr8;
							int num8 = <Module>.GHeap<GWWeather>.GetNext(ptr8, -1);
							if (num8 >= 0)
							{
								do
								{
									array5[num7] = new string(<Module>.GBaseString<char>..PBD(<Module>.GHeap<GWWeather>.[](ptr8, num8) + 8));
									num7++;
									ptr8 = <Module>.SafeWorld + 3436 / sizeof(GEditorWorld);
									num8 = <Module>.GHeap<GWWeather>.GetNext(ptr8, num8);
								}
								while (num8 >= 0);
							}
							this.ActionListTreeControl.StartListSelecting(array5);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 13;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1389:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 5) == null)
							{
								goto IL_14A3;
							}
							NewAssetPicker newAssetPicker = new NewAssetPicker(NewAssetPicker.ObjectType.UnitEditor, 30);
							newAssetPicker.Reset();
							if (newAssetPicker.ShowDialog() == DialogResult.OK)
							{
								goto IL_13D9;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_13D9:
						try
						{
							NewAssetPicker newAssetPicker;
							GBaseString<char> gBaseString<char>5;
							<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>5, newAssetPicker.NewName);
							int num9;
							try
							{
								num9 = <Module>.ScriptEditor.cManager.RegisterUnitType(<Module>.SafeWorld + 5128 / sizeof(GEditorWorld), ref gBaseString<char>5);
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>5));
								throw;
							}
							<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>5);
							if (num9 != -1)
							{
								goto IL_1443;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1443:
						try
						{
							int num9;
							if (<Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(this.Editor, ptr, actionIndex, parameterIndex, 5, num9) != null)
							{
								goto IL_147A;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_147A:
						try
						{
							this.RefreshTriggerData(ptr, 0);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_14A3:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 14) == null)
							{
								goto IL_15BF;
							}
							NewAssetPicker newAssetPicker2 = new NewAssetPicker(NewAssetPicker.ObjectType.UnitEditor, 28);
							newAssetPicker2.Reset();
							if (newAssetPicker2.ShowDialog() == DialogResult.OK)
							{
								goto IL_14F4;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_14F4:
						try
						{
							NewAssetPicker newAssetPicker2;
							GBaseString<char> gBaseString<char>6;
							<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>6, newAssetPicker2.NewName);
							int num10;
							try
							{
								num10 = <Module>.ScriptEditor.cManager.RegisterEffectName(<Module>.SafeWorld + 5128 / sizeof(GEditorWorld), ref gBaseString<char>6);
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
								throw;
							}
							<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>6);
							if (num10 != -1)
							{
								goto IL_155E;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_155E:
						try
						{
							int num10;
							if (<Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(this.Editor, ptr, actionIndex, parameterIndex, 14, num10) != null)
							{
								goto IL_1596;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1596:
						try
						{
							this.RefreshTriggerData(ptr, 0);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_15BF:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 10) == null)
							{
								goto IL_1674;
							}
							cEditor* editor = this.Editor;
							string[] array6 = new string[<Module>.ScriptEditor.cEditor.GetNumberOfTriggers(editor)];
							int num11 = 0;
							if (0 < <Module>.ScriptEditor.cEditor.GetNumberOfTriggers(editor))
							{
								do
								{
									array6[num11] = new string(<Module>.GBaseString<char>..PBD(<Module>.ScriptEditor.cTrigger.GetName(<Module>.ScriptEditor.cEditor.GetTrigger(this.Editor, num11))));
									num11++;
								}
								while (num11 < <Module>.ScriptEditor.cEditor.GetNumberOfTriggers(this.Editor));
							}
							this.ActionListTreeControl.StartListSelecting(array6);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 10;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1674:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 17) == null)
							{
								goto IL_172D;
							}
							int num12 = <Module>.ScriptEditor.GetAIGroup_Behaviour_MAX();
							string[] array7 = new string[num12];
							int num13 = 0;
							if (0 < num12)
							{
								do
								{
									GBaseString<char> gBaseString<char>7;
									GBaseString<char>* ptr9 = <Module>.ScriptEditor.GetAIGroup_BehaviourAsString(&gBaseString<char>7, num13);
									try
									{
										array7[num13] = new string(<Module>.GBaseString<char>..PBD(ptr9));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>7));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>7);
									num13++;
								}
								while (num13 < num12);
							}
							this.ActionListTreeControl.StartListSelecting(array7);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 17;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_172D:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 18) == null)
							{
								goto IL_17E6;
							}
							int num14 = <Module>.ScriptEditor.GetAIGroup_Bravery_MAX();
							string[] array8 = new string[num14];
							int num15 = 0;
							if (0 < num14)
							{
								do
								{
									GBaseString<char> gBaseString<char>8;
									GBaseString<char>* ptr10 = <Module>.ScriptEditor.GetAIGroup_BraveryAsString(&gBaseString<char>8, num15);
									try
									{
										array8[num15] = new string(<Module>.GBaseString<char>..PBD(ptr10));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>8));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>8);
									num15++;
								}
								while (num15 < num14);
							}
							this.ActionListTreeControl.StartListSelecting(array8);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 18;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_17E6:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 19) == null)
							{
								goto IL_189F;
							}
							int num16 = <Module>.ScriptEditor.GetAIGroup_Helps_MAX();
							string[] array9 = new string[num16];
							int num17 = 0;
							if (0 < num16)
							{
								do
								{
									GBaseString<char> gBaseString<char>9;
									GBaseString<char>* ptr11 = <Module>.ScriptEditor.GetAIGroup_HelpsAsString(&gBaseString<char>9, num17);
									try
									{
										array9[num17] = new string(<Module>.GBaseString<char>..PBD(ptr11));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>9));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>9);
									num17++;
								}
								while (num17 < num16);
							}
							this.ActionListTreeControl.StartListSelecting(array9);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 19;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_189F:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 20) == null)
							{
								goto IL_1958;
							}
							int num18 = <Module>.ScriptEditor.GetUnit_Behaviour_MAX();
							string[] array10 = new string[num18];
							int num19 = 0;
							if (0 < num18)
							{
								do
								{
									GBaseString<char> gBaseString<char>10;
									GBaseString<char>* ptr12 = <Module>.ScriptEditor.GetUnit_BehaviourAsString(&gBaseString<char>10, num19);
									try
									{
										array10[num19] = new string(<Module>.GBaseString<char>..PBD(ptr12));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>10));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>10);
									num19++;
								}
								while (num19 < num18);
							}
							this.ActionListTreeControl.StartListSelecting(array10);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 20;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1958:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 24) == null)
							{
								goto IL_1A03;
							}
							string[] array11 = new string[3];
							int num20 = 0;
							do
							{
								GBaseString<char> gBaseString<char>11;
								GBaseString<char>* ptr13 = <Module>.Script.GetDisplayTypeString(&gBaseString<char>11, num20);
								try
								{
									array11[num20] = new string(<Module>.GBaseString<char>..PBD(ptr13));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>11));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>11);
								num20++;
							}
							while (num20 < 3);
							this.ActionListTreeControl.StartListSelecting(array11);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 24;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1A03:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 25) == null)
							{
								goto IL_1AB0;
							}
							string[] array12 = new string[11];
							int num21 = 0;
							do
							{
								GBaseString<char> gBaseString<char>12;
								GBaseString<char>* ptr14 = <Module>.Script.GetReinforcementString(&gBaseString<char>12, num21);
								try
								{
									array12[num21] = new string(<Module>.GBaseString<char>..PBD(ptr14));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>12));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>12);
								num21++;
							}
							while (num21 < 11);
							this.ActionListTreeControl.StartListSelecting(array12);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 25;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1AB0:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 27) == null)
							{
								goto IL_1B5B;
							}
							string[] array13 = new string[3];
							int num22 = 0;
							do
							{
								GBaseString<char> gBaseString<char>13;
								GBaseString<char>* ptr15 = <Module>.Script.GetMusicString(&gBaseString<char>13, num22);
								try
								{
									array13[num22] = new string(<Module>.GBaseString<char>..PBD(ptr15));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>13));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>13);
								num22++;
							}
							while (num22 < 3);
							this.ActionListTreeControl.StartListSelecting(array13);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 27;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1B5B:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 28) == null)
							{
								goto IL_1C08;
							}
							string[] array14 = new string[10];
							int num23 = 0;
							do
							{
								GBaseString<char> gBaseString<char>14;
								GBaseString<char>* ptr16 = <Module>.Script.GetGunnerString(&gBaseString<char>14, num23);
								try
								{
									array14[num23] = new string(<Module>.GBaseString<char>..PBD(ptr16));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>14));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>14);
								num23++;
							}
							while (num23 < 10);
							this.ActionListTreeControl.StartListSelecting(array14);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 28;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1C08:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 29) == null)
							{
								goto IL_1CB3;
							}
							string[] array15 = new string[3];
							int num24 = 0;
							do
							{
								GBaseString<char> gBaseString<char>15;
								GBaseString<char>* ptr17 = <Module>.Script.GetFormationString(&gBaseString<char>15, num24);
								try
								{
									array15[num24] = new string(<Module>.GBaseString<char>..PBD(ptr17));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>15));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>15);
								num24++;
							}
							while (num24 < 3);
							this.ActionListTreeControl.StartListSelecting(array15);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 29;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1CB3:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray, 1, 30) == null)
							{
								goto IL_1D5D;
							}
							string[] array16 = new string[59];
							int num25 = 0;
							do
							{
								GBaseString<char> gBaseString<char>16;
								GBaseString<char>* ptr18 = <Module>.Script.GetSpeechString(&gBaseString<char>16, num25);
								try
								{
									array16[num25] = new string(<Module>.GBaseString<char>..PBD(ptr18));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>16));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>16);
								num25++;
							}
							while (num25 < 59);
							this.ActionListTreeControl.StartListSelecting(array16);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 30;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
						IL_1D5D:
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray);
						return;
					}
					int conditionIndex = mouseTargetNode.ConditionIndex;
					if (conditionIndex < <Module>.ScriptEditor.cAction.GetNumberOfConditions(ptr2))
					{
						cCondition* ptr19 = <Module>.ScriptEditor.cAction.GetCondition(ptr2, conditionIndex);
						cParameterInfoArray cParameterInfoArray2;
						<Module>.ScriptEditor.cParameterInfoArray.{ctor}(ref cParameterInfoArray2);
						try
						{
							bool flag2;
							if (<Module>.ScriptEditor.cCondition.GetParameterBaseType(ptr19, parameterIndex, ref cParameterInfoArray2, ref flag2) != null)
							{
								goto IL_E9;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_E9:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 2) == null)
							{
								goto IL_174;
							}
							sParameter* ptr20 = <Module>.ScriptEditor.cCondition.GetParameter(ptr19, parameterIndex);
							if (*ptr20 == 1)
							{
								if (*(ptr20 + 4) == 2)
								{
									GBaseString<char> gBaseString<char>17;
									GBaseString<char>* ptr21 = <Module>.ScriptEditor.sValue.GetAsEditingString(ptr20 + 4, &gBaseString<char>17);
									try
									{
										s = new string(<Module>.GBaseString<char>..PBD(ptr21));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>17));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>17);
								}
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						goto IL_FCC;
						IL_174:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 5) == null)
							{
								goto IL_290;
							}
							NewAssetPicker newAssetPicker3 = new NewAssetPicker(NewAssetPicker.ObjectType.UnitEditor, 30);
							newAssetPicker3.Reset();
							if (newAssetPicker3.ShowDialog() == DialogResult.OK)
							{
								goto IL_1C4;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_1C4:
						try
						{
							NewAssetPicker newAssetPicker3;
							GBaseString<char> gBaseString<char>18;
							<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>18, newAssetPicker3.NewName);
							int num26;
							try
							{
								num26 = <Module>.ScriptEditor.cManager.RegisterUnitType(<Module>.SafeWorld + 5128 / sizeof(GEditorWorld), ref gBaseString<char>18);
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>18));
								throw;
							}
							<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>18);
							if (num26 != -1)
							{
								goto IL_22E;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_22E:
						try
						{
							int num26;
							if (<Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(this.Editor, ptr, actionIndex, conditionIndex, parameterIndex, 5, num26) != null)
							{
								goto IL_267;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_267:
						try
						{
							this.RefreshTriggerData(ptr, 0);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_290:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 14) == null)
							{
								goto IL_3AE;
							}
							NewAssetPicker newAssetPicker4 = new NewAssetPicker(NewAssetPicker.ObjectType.UnitEditor, 28);
							newAssetPicker4.Reset();
							if (newAssetPicker4.ShowDialog() == DialogResult.OK)
							{
								goto IL_2E1;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_2E1:
						try
						{
							NewAssetPicker newAssetPicker4;
							GBaseString<char> gBaseString<char>19;
							<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>19, newAssetPicker4.NewName);
							int num27;
							try
							{
								num27 = <Module>.ScriptEditor.cManager.RegisterEffectName(<Module>.SafeWorld + 5128 / sizeof(GEditorWorld), ref gBaseString<char>19);
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>19));
								throw;
							}
							<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>19);
							if (num27 != -1)
							{
								goto IL_34B;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_34B:
						try
						{
							int num27;
							if (<Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(this.Editor, ptr, actionIndex, conditionIndex, parameterIndex, 14, num27) != null)
							{
								goto IL_385;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_385:
						try
						{
							this.RefreshTriggerData(ptr, 0);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_3AE:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 9) == null)
							{
								goto IL_43F;
							}
							string[] array17 = new string[12];
							int num28 = 0;
							do
							{
								array17[num28] = string.Format(new string((sbyte*)(&<Module>.??_C@_0M@OAEPIHCK@Player?5?$CD?$HL0?$HN?$AA@)), num28 + 1);
								num28++;
							}
							while (num28 < 12);
							this.ActionListTreeControl.StartListSelecting(array17);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 9;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_43F:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 21) == null)
							{
								goto IL_4EE;
							}
							string[] array18 = new string[4];
							int num29 = 0;
							do
							{
								GBaseString<char> gBaseString<char>20;
								GBaseString<char>* ptr22 = <Module>.Script.GetUnitCategoryString(&gBaseString<char>20, num29);
								try
								{
									array18[num29] = new string(<Module>.GBaseString<char>..PBD(ptr22));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>20));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>20);
								num29++;
							}
							while (num29 < 4);
							this.ActionListTreeControl.StartListSelecting(array18);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 21;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_4EE:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 22) == null)
							{
								goto IL_599;
							}
							string[] array19 = new string[4];
							int num30 = 0;
							do
							{
								GBaseString<char> gBaseString<char>21;
								GBaseString<char>* ptr23 = <Module>.Script.GetSupportTypeString(&gBaseString<char>21, num30);
								try
								{
									array19[num30] = new string(<Module>.GBaseString<char>..PBD(ptr23));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>21));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>21);
								num30++;
							}
							while (num30 < 4);
							this.ActionListTreeControl.StartListSelecting(array19);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 22;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_599:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 1) == null)
							{
								goto IL_652;
							}
							string[] array20 = new string[2];
							int num31 = 0;
							do
							{
								sValue sValue2;
								GBaseString<char> gBaseString<char>22;
								GBaseString<char>* ptr24 = <Module>.ScriptEditor.sValue.GetAsString(<Module>.??0sValue@ScriptEditor@@$$FQAE@W4eValue_Type@Script@@H@Z(ref sValue2, 1, num31), &gBaseString<char>22, this.Editor);
								try
								{
									array20[num31] = new string(<Module>.GBaseString<char>..PBD(ptr24));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>22));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>22);
								num31++;
							}
							while (num31 < 2);
							this.ActionListTreeControl.StartListSelecting(array20);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 1;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_652:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 13) == null)
							{
								goto IL_75D;
							}
							int num32 = 0;
							GEditorWorld* ptr25 = <Module>.SafeWorld + 3436 / sizeof(GEditorWorld);
							int num33 = <Module>.GHeap<GWWeather>.GetNext(ptr25, -1);
							if (num33 >= 0)
							{
								do
								{
									num32++;
									num33 = <Module>.GHeap<GWWeather>.GetNext(ptr25, num33);
								}
								while (num33 >= 0);
								if (num32 != 0)
								{
									goto IL_6C0;
								}
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_6C0:
						try
						{
							int num32;
							string[] array21 = new string[num32];
							int num34 = 0;
							GEditorWorld* ptr25;
							int num35 = <Module>.GHeap<GWWeather>.GetNext(ptr25, -1);
							if (num35 >= 0)
							{
								do
								{
									array21[num34] = new string(<Module>.GBaseString<char>..PBD(<Module>.GHeap<GWWeather>.[](ptr25, num35) + 8));
									num34++;
									ptr25 = <Module>.SafeWorld + 3436 / sizeof(GEditorWorld);
									num35 = <Module>.GHeap<GWWeather>.GetNext(ptr25, num35);
								}
								while (num35 >= 0);
							}
							this.ActionListTreeControl.StartListSelecting(array21);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 13;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_75D:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 10) == null)
							{
								goto IL_812;
							}
							cEditor* editor2 = this.Editor;
							string[] array22 = new string[<Module>.ScriptEditor.cEditor.GetNumberOfTriggers(editor2)];
							int num36 = 0;
							if (0 < <Module>.ScriptEditor.cEditor.GetNumberOfTriggers(editor2))
							{
								do
								{
									array22[num36] = new string(<Module>.GBaseString<char>..PBD(<Module>.ScriptEditor.cTrigger.GetName(<Module>.ScriptEditor.cEditor.GetTrigger(this.Editor, num36))));
									num36++;
								}
								while (num36 < <Module>.ScriptEditor.cEditor.GetNumberOfTriggers(this.Editor));
							}
							this.ActionListTreeControl.StartListSelecting(array22);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 10;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_812:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 17) == null)
							{
								goto IL_8CB;
							}
							int num37 = <Module>.ScriptEditor.GetAIGroup_Behaviour_MAX();
							string[] array23 = new string[num37];
							int num38 = 0;
							if (0 < num37)
							{
								do
								{
									GBaseString<char> gBaseString<char>23;
									GBaseString<char>* ptr26 = <Module>.ScriptEditor.GetAIGroup_BehaviourAsString(&gBaseString<char>23, num38);
									try
									{
										array23[num38] = new string(<Module>.GBaseString<char>..PBD(ptr26));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>23));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>23);
									num38++;
								}
								while (num38 < num37);
							}
							this.ActionListTreeControl.StartListSelecting(array23);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 17;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_8CB:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 18) == null)
							{
								goto IL_984;
							}
							int num39 = <Module>.ScriptEditor.GetAIGroup_Bravery_MAX();
							string[] array24 = new string[num39];
							int num40 = 0;
							if (0 < num39)
							{
								do
								{
									GBaseString<char> gBaseString<char>24;
									GBaseString<char>* ptr27 = <Module>.ScriptEditor.GetAIGroup_BraveryAsString(&gBaseString<char>24, num40);
									try
									{
										array24[num40] = new string(<Module>.GBaseString<char>..PBD(ptr27));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>24));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>24);
									num40++;
								}
								while (num40 < num39);
							}
							this.ActionListTreeControl.StartListSelecting(array24);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 18;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_984:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 19) == null)
							{
								goto IL_A3D;
							}
							int num41 = <Module>.ScriptEditor.GetAIGroup_Helps_MAX();
							string[] array25 = new string[num41];
							int num42 = 0;
							if (0 < num41)
							{
								do
								{
									GBaseString<char> gBaseString<char>25;
									GBaseString<char>* ptr28 = <Module>.ScriptEditor.GetAIGroup_HelpsAsString(&gBaseString<char>25, num42);
									try
									{
										array25[num42] = new string(<Module>.GBaseString<char>..PBD(ptr28));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>25));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>25);
									num42++;
								}
								while (num42 < num41);
							}
							this.ActionListTreeControl.StartListSelecting(array25);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 19;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_A3D:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 20) == null)
							{
								goto IL_AF6;
							}
							int num43 = <Module>.ScriptEditor.GetUnit_Behaviour_MAX();
							string[] array26 = new string[num43];
							int num44 = 0;
							if (0 < num43)
							{
								do
								{
									GBaseString<char> gBaseString<char>26;
									GBaseString<char>* ptr29 = <Module>.ScriptEditor.GetUnit_BehaviourAsString(&gBaseString<char>26, num44);
									try
									{
										array26[num44] = new string(<Module>.GBaseString<char>..PBD(ptr29));
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>26));
										throw;
									}
									<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>26);
									num44++;
								}
								while (num44 < num43);
							}
							this.ActionListTreeControl.StartListSelecting(array26);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 20;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_AF6:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 24) == null)
							{
								goto IL_BA1;
							}
							string[] array27 = new string[3];
							int num45 = 0;
							do
							{
								GBaseString<char> gBaseString<char>27;
								GBaseString<char>* ptr30 = <Module>.Script.GetDisplayTypeString(&gBaseString<char>27, num45);
								try
								{
									array27[num45] = new string(<Module>.GBaseString<char>..PBD(ptr30));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>27));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>27);
								num45++;
							}
							while (num45 < 3);
							this.ActionListTreeControl.StartListSelecting(array27);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 24;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_BA1:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 25) == null)
							{
								goto IL_C4E;
							}
							string[] array28 = new string[11];
							int num46 = 0;
							do
							{
								GBaseString<char> gBaseString<char>28;
								GBaseString<char>* ptr31 = <Module>.Script.GetReinforcementString(&gBaseString<char>28, num46);
								try
								{
									array28[num46] = new string(<Module>.GBaseString<char>..PBD(ptr31));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>28));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>28);
								num46++;
							}
							while (num46 < 11);
							this.ActionListTreeControl.StartListSelecting(array28);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 25;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_C4E:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 27) == null)
							{
								goto IL_CF9;
							}
							string[] array29 = new string[3];
							int num47 = 0;
							do
							{
								GBaseString<char> gBaseString<char>29;
								GBaseString<char>* ptr32 = <Module>.Script.GetMusicString(&gBaseString<char>29, num47);
								try
								{
									array29[num47] = new string(<Module>.GBaseString<char>..PBD(ptr32));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>29));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>29);
								num47++;
							}
							while (num47 < 3);
							this.ActionListTreeControl.StartListSelecting(array29);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 27;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_CF9:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 28) == null)
							{
								goto IL_DA6;
							}
							string[] array30 = new string[10];
							int num48 = 0;
							do
							{
								GBaseString<char> gBaseString<char>30;
								GBaseString<char>* ptr33 = <Module>.Script.GetGunnerString(&gBaseString<char>30, num48);
								try
								{
									array30[num48] = new string(<Module>.GBaseString<char>..PBD(ptr33));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>30));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>30);
								num48++;
							}
							while (num48 < 10);
							this.ActionListTreeControl.StartListSelecting(array30);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 28;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_DA6:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 29) == null)
							{
								goto IL_E51;
							}
							string[] array31 = new string[3];
							int num49 = 0;
							do
							{
								GBaseString<char> gBaseString<char>31;
								GBaseString<char>* ptr34 = <Module>.Script.GetFormationString(&gBaseString<char>31, num49);
								try
								{
									array31[num49] = new string(<Module>.GBaseString<char>..PBD(ptr34));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>31));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>31);
								num49++;
							}
							while (num49 < 3);
							this.ActionListTreeControl.StartListSelecting(array31);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 29;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_E51:
						try
						{
							if (<Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(ref cParameterInfoArray2, 1, 30) == null)
							{
								goto IL_EFE;
							}
							string[] array32 = new string[59];
							int num50 = 0;
							do
							{
								GBaseString<char> gBaseString<char>32;
								GBaseString<char>* ptr35 = <Module>.Script.GetSpeechString(&gBaseString<char>32, num50);
								try
								{
									array32[num50] = new string(<Module>.GBaseString<char>..PBD(ptr35));
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>32));
									throw;
								}
								<Module>.GBaseString<char>.{dtor}(ref gBaseString<char>32);
								num50++;
							}
							while (num50 < 59);
							this.ActionListTreeControl.StartListSelecting(array32);
							this.ActionListTreeControl.Focus();
							this.DragType = ScriptEditorForm.eDragType.DRAG_MAX;
							this.ListSelection_ValueType = 30;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(ScriptEditor.cParameterInfoArray.{dtor}), (void*)(&cParameterInfoArray2));
							throw;
						}
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
						IL_EFE:
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(ref cParameterInfoArray2);
						return;
					}
					return;
					IL_FCC:
					this.ActionListTreeControl.StartTextEditing(s);
				}
			}
		}

		private unsafe void ActionListTreeControl_TextEditingFinished(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node mouseTargetNode = actionListTreeControl.MouseTargetNode;
				cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				int actionIndex = mouseTargetNode.ActionIndex;
				if (actionIndex < *(ptr + 40))
				{
					int parameterIndex = actionListTreeControl.MouseTargetTextElement.ParameterIndex;
					string editedText = actionListTreeControl.EditedText;
					int num = 0;
					int num2 = 1;
					int num3 = 0;
					if (editedText[0] == '-')
					{
						num2 = -1;
						num3 = 1;
					}
					if (num3 < editedText.Length)
					{
						while (editedText[num3] >= '0' && editedText[num3] <= '9')
						{
							num = num * 10 + (int)editedText[num3] - 48;
							num3++;
							if (num3 >= editedText.Length)
							{
								break;
							}
						}
					}
					num = num2 * num;
					if (mouseTargetNode.HeaderNode)
					{
						int conditionIndex = mouseTargetNode.ConditionIndex;
						if (<Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(this.Editor, ptr, actionIndex, conditionIndex, parameterIndex, 2, num) == null)
						{
							return;
						}
					}
					else if (<Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(this.Editor, ptr, actionIndex, parameterIndex, 2, num) == null)
					{
						return;
					}
					int num4 = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num4 != 0);
					cEditor* editor = this.Editor;
					int num5 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num5 != 0);
					this.RefreshTriggerData(ptr, 0);
				}
			}
		}

		private unsafe void ActionListTreeControl_ListSelectingFinished(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node mouseTargetNode = actionListTreeControl.MouseTargetNode;
				ActionListTreeControl_Node_TextElement mouseTargetTextElement = actionListTreeControl.MouseTargetTextElement;
				int arg_43_0 = globalTriggerControl.SelectedIndex;
				cEditor* editor = this.Editor;
				cEditor* ptr = editor;
				cTrigger* ptr2 = *(arg_43_0 * 4 + *(ptr + 28));
				int actionIndex = mouseTargetNode.ActionIndex;
				int num = *(ptr2 + 40);
				if (actionIndex < num)
				{
					int parameterIndex = mouseTargetTextElement.ParameterIndex;
					ScriptEditorForm.eDragType dragType = this.DragType;
					if (dragType == ScriptEditorForm.eDragType.DRAG_MAX)
					{
						int num2 = actionListTreeControl.ListSelection_Selected;
						GBaseString<char> gBaseString<char>;
						<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, actionListTreeControl.EditedText);
						try
						{
							this.ActionListTreeControl.StopListSelecting();
							int listSelection_ValueType = this.ListSelection_ValueType;
							if (listSelection_ValueType != 10)
							{
								if (listSelection_ValueType != 13)
								{
									if (listSelection_ValueType == 19)
									{
										num2 = 1 << num2;
									}
								}
								else
								{
									num2 = -1;
									GEditorWorld* ptr3 = <Module>.SafeWorld + 3436 / sizeof(GEditorWorld);
									int num3 = <Module>.GHeap<GWWeather>.GetNext(ptr3, -1);
									if (num3 >= 0)
									{
										while (((<Module>.GBaseString<char>.Compare(*(int*)ptr3 + num3 * 124 + 4 + 8, ref gBaseString<char>, false) == 0) ? 1 : 0) == 0)
										{
											ptr3 = <Module>.SafeWorld + 3436 / sizeof(GEditorWorld);
											num3 = <Module>.GHeap<GWWeather>.GetNext(ptr3, num3);
											if (num3 < 0)
											{
												goto IL_13A;
											}
										}
										num2 = num3;
									}
								}
							}
							else
							{
								cEditor* editor2 = this.Editor;
								num2 = *(*(num2 * 4 + *(editor2 + 28)) + 4);
							}
							IL_13A:
							if (!mouseTargetNode.HeaderNode)
							{
								goto IL_18F;
							}
							int conditionIndex = mouseTargetNode.ConditionIndex;
							if (<Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(this.Editor, ptr2, actionIndex, conditionIndex, parameterIndex, this.ListSelection_ValueType, num2) != null)
							{
								goto IL_1CF;
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
							return;
						}
						return;
						IL_18F:
						try
						{
							if (<Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(this.Editor, ptr2, actionIndex, parameterIndex, this.ListSelection_ValueType, num2) != null)
							{
								goto IL_1CF;
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
							return;
						}
						return;
						IL_1CF:
						if (gBaseString<char> != null)
						{
							<Module>.free(gBaseString<char>);
						}
					}
					else
					{
						ScriptEditorForm.eDragType eDragType = dragType;
						cVariable* ptr5;
						int num4;
						int num5;
						if (eDragType != ScriptEditorForm.eDragType.DRAG_GlobalVariable)
						{
							if (eDragType != ScriptEditorForm.eDragType.DRAG_LocalVariable)
							{
								if (eDragType != ScriptEditorForm.eDragType.DRAG_Entity)
								{
									return;
								}
								int arg_208_0 = this.DragIndex;
								cEditor* ptr4 = editor;
								ptr5 = *(arg_208_0 * 4 + *(ptr4 + 44));
								num4 = 6;
								num5 = 7;
							}
							else
							{
								ptr5 = *(this.DragIndex * 4 + *(ptr2 + 24));
								num4 = 3;
								num5 = 5;
							}
						}
						else
						{
							int arg_23D_0 = this.DragIndex;
							cEditor* ptr6 = editor;
							ptr5 = *(arg_23D_0 * 4 + *(ptr6 + 12));
							num4 = 2;
							num5 = 4;
						}
						if (mouseTargetNode.HeaderNode)
						{
							int conditionIndex2 = mouseTargetNode.ConditionIndex;
							int listSelection_Selected = actionListTreeControl.ListSelection_Selected;
							actionListTreeControl.StopListSelecting();
							GArray<int> gArray<int> = 0;
							*(ref gArray<int> + 4) = 0;
							*(ref gArray<int> + 8) = 0;
							try
							{
								if (<Module>.ScriptEditor.cEditor.GetConditionParameterChangePossibilities(this.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, ptr5, ref gArray<int>) != null)
								{
									goto IL_2B6;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
								throw;
							}
							<Module>.GArray<int>.{dtor}(ref gArray<int>);
							return;
							IL_2B6:
							try
							{
								if (listSelection_Selected < *(ref gArray<int> + 4))
								{
									goto IL_2DE;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
								throw;
							}
							<Module>.GArray<int>.{dtor}(ref gArray<int>);
							return;
							IL_2DE:
							try
							{
								int num6 = listSelection_Selected * 4 + gArray<int>;
								if (*num6 != -1)
								{
									goto IL_32A;
								}
								int num7 = *(int*)ptr5;
								if (<Module>.?ChangeConditionParameterVariable@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eParameter_Type@Script@@H@Z(this.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, num4, num7) != null)
								{
									goto IL_36B;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
								throw;
							}
							<Module>.GArray<int>.{dtor}(ref gArray<int>);
							return;
							IL_32A:
							try
							{
								int num6;
								int* ptr7 = num6;
								int num8 = *(int*)ptr5;
								if (<Module>.?ChangeConditionParameterMember@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eParameter_Type@Script@@HH@Z(this.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, num5, num8, *ptr7) != null)
								{
									goto IL_36B;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
								throw;
							}
							<Module>.GArray<int>.{dtor}(ref gArray<int>);
							return;
							IL_36B:
							<Module>.GArray<int>.{dtor}(ref gArray<int>);
						}
						else
						{
							int listSelection_Selected2 = actionListTreeControl.ListSelection_Selected;
							actionListTreeControl.StopListSelecting();
							GArray<int> gArray<int>2 = 0;
							*(ref gArray<int>2 + 4) = 0;
							*(ref gArray<int>2 + 8) = 0;
							try
							{
								if (<Module>.ScriptEditor.cEditor.GetActionParameterChangePossibilities(this.Editor, ptr2, actionIndex, parameterIndex, ptr5, ref gArray<int>2) != null)
								{
									goto IL_3C9;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>2));
								throw;
							}
							<Module>.GArray<int>.{dtor}(ref gArray<int>2);
							return;
							IL_3C9:
							try
							{
								if (listSelection_Selected2 < *(ref gArray<int>2 + 4))
								{
									goto IL_3F1;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>2));
								throw;
							}
							<Module>.GArray<int>.{dtor}(ref gArray<int>2);
							return;
							IL_3F1:
							try
							{
								int num9 = listSelection_Selected2 * 4 + gArray<int>2;
								if (*num9 != -1)
								{
									goto IL_43B;
								}
								int num10 = *(int*)ptr5;
								if (<Module>.?ChangeActionParameterVariable@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eParameter_Type@Script@@H@Z(this.Editor, ptr2, actionIndex, parameterIndex, num4, num10) != null)
								{
									goto IL_477;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>2));
								throw;
							}
							<Module>.GArray<int>.{dtor}(ref gArray<int>2);
							return;
							IL_43B:
							try
							{
								int num9;
								int* ptr8 = num9;
								int num11 = *(int*)ptr5;
								if (<Module>.?ChangeActionParameterMember@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eParameter_Type@Script@@HH@Z(this.Editor, ptr2, actionIndex, parameterIndex, num5, num11, *ptr8) != null)
								{
									goto IL_477;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>2));
								throw;
							}
							<Module>.GArray<int>.{dtor}(ref gArray<int>2);
							return;
							IL_477:
							<Module>.GArray<int>.{dtor}(ref gArray<int>2);
						}
					}
					this.Edit_Undo.Enabled = (<Module>.ScriptEditor.cEditor.HasUndo(this.Editor) != null);
					this.Edit_Redo.Enabled = (<Module>.ScriptEditor.cEditor.HasRedo(this.Editor) != null);
					this.RefreshAll();
				}
			}
		}

		private unsafe void Actions_Insert_Click(object sender, EventArgs e)
		{
			if (this.AddActionButton.Enabled || this.AddConditionButton.Enabled)
			{
				Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
				if (globalTriggerControl.SelectedIndex != -1)
				{
					cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
					ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
					if (selectedNode != null && selectedNode.HeaderNode)
					{
						int num = *(this.ConditionTypeBox.SelectedIndex * 4 + ref <Module>.ScriptEditor.ConditionTypeList);
						int actionIndex = selectedNode.ActionIndex;
						if (actionIndex >= *(ptr + 40))
						{
							return;
						}
						cAction* arg_A0_0 = *(actionIndex * 4 + *(ptr + 36));
						int conditionIndex = selectedNode.ConditionIndex;
						if (<Module>.?CreateCondition@cAction@ScriptEditor@@$$FQAEPAVcCondition@2@W4eCondition_Type@Script@@H@Z(arg_A0_0, num, conditionIndex) == null)
						{
							return;
						}
					}
					else
					{
						int num2 = *(this.ActionTypeBox.SelectedIndex * 4 + ref <Module>.ScriptEditor.ActionTypeList);
						if (num2 == 108)
						{
							return;
						}
						int num3;
						if (selectedNode != null)
						{
							num3 = selectedNode.ActionIndex;
						}
						else
						{
							num3 = 0;
						}
						if (<Module>.?CreateAction@cTrigger@ScriptEditor@@$$FQAEPAVcAction@2@W4eAction_Type@Script@@H@Z(ptr, num2, num3) == null)
						{
							return;
						}
					}
					int num4 = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num4 != 0);
					cEditor* editor = this.Editor;
					int num5 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num5 != 0);
					this.RefreshTriggerData(ptr, 1);
				}
			}
		}

		private unsafe void Actions_Delete_Click(object sender, EventArgs e)
		{
			if (this.DeleteActionButton.Enabled || this.DeleteConditionButton.Enabled)
			{
				Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
				if (globalTriggerControl.SelectedIndex != -1)
				{
					cEditor* editor = this.Editor;
					cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(editor + 28 / sizeof(cEditor)));
					Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
					ActionListTreeControl_Node selectedNode = actionListTreeControl.SelectedNode;
					ActionListTreeControl_Node selectedNode_End = actionListTreeControl.SelectedNode_End;
					if (selectedNode != null)
					{
						if (selectedNode == selectedNode_End)
						{
							if (selectedNode.HeaderNode)
							{
								int actionIndex = selectedNode.ActionIndex;
								int conditionIndex = selectedNode.ConditionIndex;
								if (<Module>.ScriptEditor.cEditor.DeleteCondition(editor, ptr, actionIndex, conditionIndex) == null)
								{
									return;
								}
							}
							else if (<Module>.ScriptEditor.cTrigger.DeleteAction(ptr, selectedNode.ActionIndex, false) == null)
							{
								return;
							}
						}
						else
						{
							int actionIndex2;
							int actionIndex3;
							if (selectedNode.ActionIndex <= selectedNode_End.ActionIndex)
							{
								actionIndex2 = selectedNode.ActionIndex;
								actionIndex3 = selectedNode_End.ActionIndex;
							}
							else
							{
								actionIndex3 = selectedNode.ActionIndex;
								actionIndex2 = selectedNode_End.ActionIndex;
							}
							if (<Module>.ScriptEditor.cTrigger.DeleteActionRange(ptr, actionIndex2, actionIndex3) == null)
							{
								return;
							}
						}
						int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
						this.Edit_Undo.Enabled = ((byte)num != 0);
						cEditor* editor2 = this.Editor;
						int num2 = (*(editor2 + 68) < *(editor2 + 60)) ? 1 : 0;
						this.Edit_Redo.Enabled = ((byte)num2 != 0);
						this.RefreshTriggerData(ptr, 0);
					}
				}
			}
		}

		private unsafe void AddActionButton_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
				if (selectedNode == null || !selectedNode.HeaderNode)
				{
					cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
					int num = *(this.ActionTypeBox.SelectedIndex * 4 + ref <Module>.ScriptEditor.ActionTypeList);
					if (num != 108)
					{
						int num2;
						if (selectedNode != null)
						{
							num2 = selectedNode.ActionIndex;
						}
						else
						{
							num2 = 0;
						}
						if (<Module>.?CreateAction@cTrigger@ScriptEditor@@$$FQAEPAVcAction@2@W4eAction_Type@Script@@H@Z(ptr, num, num2) != null)
						{
							int num3 = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
							this.Edit_Undo.Enabled = ((byte)num3 != 0);
							cEditor* editor = this.Editor;
							int num4 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
							this.Edit_Redo.Enabled = ((byte)num4 != 0);
							this.RefreshAll();
							this.RefreshTriggerData(ptr, 1);
						}
					}
				}
			}
		}

		private unsafe void DeleteActionButton_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				Script_ActionListTreeControl actionListTreeControl = this.ActionListTreeControl;
				ActionListTreeControl_Node selectedNode = actionListTreeControl.SelectedNode;
				ActionListTreeControl_Node selectedNode_End = actionListTreeControl.SelectedNode_End;
				if (selectedNode != null)
				{
					if (selectedNode == selectedNode_End)
					{
						if (selectedNode.HeaderNode || <Module>.ScriptEditor.cTrigger.DeleteAction(ptr, selectedNode.ActionIndex, false) == null)
						{
							return;
						}
					}
					else
					{
						int actionIndex;
						int actionIndex2;
						if (selectedNode.ActionIndex <= selectedNode_End.ActionIndex)
						{
							actionIndex = selectedNode.ActionIndex;
							actionIndex2 = selectedNode_End.ActionIndex;
						}
						else
						{
							actionIndex2 = selectedNode.ActionIndex;
							actionIndex = selectedNode_End.ActionIndex;
						}
						if (<Module>.ScriptEditor.cTrigger.DeleteActionRange(ptr, actionIndex, actionIndex2) == null)
						{
							return;
						}
					}
					int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num != 0);
					cEditor* editor = this.Editor;
					int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num2 != 0);
					this.RefreshAll();
				}
			}
		}

		private unsafe void DeletActionBlockButton_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
				if (selectedNode != null && !selectedNode.HeaderNode && <Module>.ScriptEditor.cTrigger.DeleteActionBlock(ptr, selectedNode.ActionIndex) != null)
				{
					int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num != 0);
					cEditor* editor = this.Editor;
					int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num2 != 0);
					this.RefreshAll();
				}
			}
		}

		private unsafe void DeleteActionPartButton_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
				if (selectedNode != null && !selectedNode.HeaderNode && <Module>.ScriptEditor.cTrigger.DeleteActionPart(ptr, selectedNode.ActionIndex) != null)
				{
					int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num != 0);
					cEditor* editor = this.Editor;
					int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num2 != 0);
					this.RefreshAll();
				}
			}
		}

		private unsafe void AddConditionButton_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
				if (selectedNode != null && selectedNode.HeaderNode)
				{
					cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
					int num = *(this.ConditionTypeBox.SelectedIndex * 4 + ref <Module>.ScriptEditor.ConditionTypeList);
					if (num != 24)
					{
						int actionIndex = selectedNode.ActionIndex;
						if (actionIndex < *(ptr + 40))
						{
							cAction* arg_8C_0 = *(actionIndex * 4 + *(ptr + 36));
							int conditionIndex = selectedNode.ConditionIndex;
							if (<Module>.?CreateCondition@cAction@ScriptEditor@@$$FQAEPAVcCondition@2@W4eCondition_Type@Script@@H@Z(arg_8C_0, num, conditionIndex) != null)
							{
								int num2 = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
								this.Edit_Undo.Enabled = ((byte)num2 != 0);
								cEditor* editor = this.Editor;
								int num3 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
								this.Edit_Redo.Enabled = ((byte)num3 != 0);
								this.RefreshTriggerData(ptr, 1);
							}
						}
					}
				}
			}
		}

		private unsafe void DeleteConditionButton_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
				if (selectedNode != null && selectedNode.HeaderNode)
				{
					cEditor* editor = this.Editor;
					cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(editor + 28 / sizeof(cEditor)));
					int actionIndex = selectedNode.ActionIndex;
					int conditionIndex = selectedNode.ConditionIndex;
					if (<Module>.ScriptEditor.cEditor.DeleteCondition(editor, ptr, actionIndex, conditionIndex) != null)
					{
						int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
						this.Edit_Undo.Enabled = ((byte)num != 0);
						cEditor* editor2 = this.Editor;
						int num2 = (*(editor2 + 68) < *(editor2 + 60)) ? 1 : 0;
						this.Edit_Redo.Enabled = ((byte)num2 != 0);
						this.RefreshAll();
					}
				}
			}
		}

		private unsafe void DeleteConditionBlockButton_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
				if (selectedNode != null && selectedNode.HeaderNode)
				{
					cEditor* editor = this.Editor;
					cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(editor + 28 / sizeof(cEditor)));
					int actionIndex = selectedNode.ActionIndex;
					int conditionIndex = selectedNode.ConditionIndex;
					if (<Module>.ScriptEditor.cEditor.DeleteConditionBlock(editor, ptr, actionIndex, conditionIndex) != null)
					{
						int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
						this.Edit_Undo.Enabled = ((byte)num != 0);
						cEditor* editor2 = this.Editor;
						int num2 = (*(editor2 + 68) < *(editor2 + 60)) ? 1 : 0;
						this.Edit_Redo.Enabled = ((byte)num2 != 0);
						this.RefreshAll();
					}
				}
			}
		}

		private unsafe void NegateConditionButton_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
				if (selectedNode != null && selectedNode.HeaderNode)
				{
					cEditor* editor = this.Editor;
					cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(editor + 28 / sizeof(cEditor)));
					int actionIndex = selectedNode.ActionIndex;
					int conditionIndex = selectedNode.ConditionIndex;
					if (<Module>.ScriptEditor.cEditor.NegateCondition(editor, ptr, actionIndex, conditionIndex) != null)
					{
						int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
						this.Edit_Undo.Enabled = ((byte)num != 0);
						cEditor* editor2 = this.Editor;
						int num2 = (*(editor2 + 68) < *(editor2 + 60)) ? 1 : 0;
						this.Edit_Redo.Enabled = ((byte)num2 != 0);
						this.RefreshTriggerData(ptr, 0);
					}
				}
			}
		}

		private unsafe void InsertSingleOrConditionButton_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl globalTriggerControl = this.GlobalTriggerControl;
			if (globalTriggerControl.SelectedIndex != -1)
			{
				ActionListTreeControl_Node selectedNode = this.ActionListTreeControl.SelectedNode;
				if (selectedNode != null && selectedNode.HeaderNode)
				{
					cTrigger* ptr = *(globalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
					int conditionIndex = selectedNode.ConditionIndex;
					if (<Module>.ScriptEditor.cAction.InsertSingleOrCondition(*(selectedNode.ActionIndex * 4 + *(ptr + 36)), conditionIndex) != null)
					{
						int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
						this.Edit_Undo.Enabled = ((byte)num != 0);
						cEditor* editor = this.Editor;
						int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
						this.Edit_Redo.Enabled = ((byte)num2 != 0);
						this.RefreshTriggerData(ptr, 0);
					}
				}
			}
		}

		private void TriggerVariableControl_DragStarted(object sender, EventArgs e)
		{
			this.DragType = ScriptEditorForm.eDragType.DRAG_LocalVariable;
			Script_GlobalVariableControl triggerVariableControl = this.TriggerVariableControl;
			int selectedIndex = triggerVariableControl.SelectedIndex;
			this.DragIndex = selectedIndex;
			triggerVariableControl.DoDragDrop(selectedIndex, DragDropEffects.Link);
		}

		private unsafe void TriggerVariableControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			Script_GlobalVariableControl triggerVariableControl = this.TriggerVariableControl;
			if (triggerVariableControl.SelectedIndex != -1)
			{
				if (triggerVariableControl.IsInOriginalOrder())
				{
					byte enabled = (triggerVariableControl.SelectedIndex + 1 < *(*(this.SelectedTriggerIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor))) + 28)) ? 1 : 0;
					this.TriggerVariable_MoveDown.Enabled = (enabled != 0);
					byte enabled2 = (this.TriggerVariableControl.SelectedIndex > 0) ? 1 : 0;
					this.TriggerVariable_MoveUp.Enabled = (enabled2 != 0);
					this.TriggerVariable_FixOrder.Enabled = false;
				}
				else
				{
					this.TriggerVariable_MoveDown.Enabled = false;
					this.TriggerVariable_MoveUp.Enabled = false;
					this.TriggerVariable_FixOrder.Enabled = true;
				}
			}
		}

		private unsafe void TriggerVariableControl_ItemDoubleClicked(object sender, EventArgs e)
		{
			int arg_0F_0 = this.SelectedTriggerIndex;
			cEditor* editor = this.Editor;
			cTrigger* ptr = *(arg_0F_0 * 4 + *(editor + 28));
			int clickedIndex = this.TriggerVariableControl.ClickedIndex;
			cVariable* ptr2 = *(clickedIndex * 4 + *(ptr + 24));
			ScriptVariablePropertiesForm scriptVariablePropertiesForm = new ScriptVariablePropertiesForm();
			Point location = base.Location;
			scriptVariablePropertiesForm.Location.X = (location.X - scriptVariablePropertiesForm.Width) / 2;
			Point location2 = base.Location;
			scriptVariablePropertiesForm.Location.Y = (location2.Y - scriptVariablePropertiesForm.Height) / 2;
			scriptVariablePropertiesForm.SetFrom(this.Editor, ptr, ptr2);
			if (scriptVariablePropertiesForm.ShowDialog() == DialogResult.OK)
			{
				int num = <Module>.ScriptEditor.cEditor.BeginUndoBlock(this.Editor);
				int variable_Type = scriptVariablePropertiesForm.Variable_Type;
				if (variable_Type != 2 && *(ptr2 + 40) != 0)
				{
					<Module>.?ChangeTriggerVariableAutoChangeMode@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HW4eAutoChange_Mode@cVariable@Script@@HH@Z(this.Editor, ptr, clickedIndex, 0, 0, 0);
				}
				GBaseString<char> gBaseString<char>;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, scriptVariablePropertiesForm.Variable_Name);
				try
				{
					<Module>.ScriptEditor.cEditor.RenameTriggerVariable(this.Editor, ptr, clickedIndex, ref gBaseString<char>);
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
				if (<Module>.ScriptEditor.cVariable.IsConstant(ptr2) == null)
				{
					<Module>.?ChangeTriggerVariableType@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HW4eValue_Type@Script@@@Z(this.Editor, ptr, clickedIndex, variable_Type);
					<Module>.ScriptEditor.cEditor.ChangeTriggerVariableValue(this.Editor, ptr, clickedIndex, scriptVariablePropertiesForm.Variable_Value);
				}
				if (variable_Type == 2)
				{
					<Module>.?ChangeTriggerVariableAutoChangeMode@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HW4eAutoChange_Mode@cVariable@Script@@HH@Z(this.Editor, ptr, clickedIndex, scriptVariablePropertiesForm.Variable_AutoChangeMode, scriptVariablePropertiesForm.Variable_AutoChange_Value, scriptVariablePropertiesForm.Variable_AutoChange_Period);
				}
				<Module>.ScriptEditor.cEditor.EndUndoBlock(this.Editor, num);
				this.RefreshAll();
			}
		}

		private unsafe void TriggerVariable_Create_Click(object sender, EventArgs e)
		{
			cTrigger* ptr = *(this.SelectedTriggerIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
			cVariable* ptr2 = <Module>.ScriptEditor.cTrigger.CreateVariable(ptr);
			*(int*)(ptr2 + 16 / sizeof(cVariable)) = 2;
			*(int*)(ptr2 + 20 / sizeof(cVariable)) = 0;
			this.RefreshTriggerVariables(ptr);
			int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
			this.Edit_Undo.Enabled = ((byte)num != 0);
			cEditor* editor = this.Editor;
			int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
			this.Edit_Redo.Enabled = ((byte)num2 != 0);
		}

		private unsafe void TriggerVariable_Delete_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.TriggerVariableControl.SelectedIndex;
			if (selectedIndex != -1)
			{
				cEditor* editor = this.Editor;
				cTrigger* ptr = *(this.SelectedTriggerIndex * 4 + *(int*)(editor + 28 / sizeof(cEditor)));
				if (<Module>.ScriptEditor.cEditor.DeleteTriggerVariable(editor, ptr, selectedIndex) != null)
				{
					int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num != 0);
					cEditor* editor2 = this.Editor;
					int num2 = (*(editor2 + 68) < *(editor2 + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num2 != 0);
					this.RefreshAll();
				}
			}
		}

		private unsafe void TriggerVariableControl_SortModeChanged(object sender, EventArgs e)
		{
			Script_GlobalVariableControl triggerVariableControl = this.TriggerVariableControl;
			if (triggerVariableControl.SelectedIndex != -1)
			{
				int num = *(*(this.SelectedTriggerIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor))) + 28);
				if (num == 0)
				{
					this.TriggerVariable_MoveDown.Enabled = false;
					this.TriggerVariable_MoveUp.Enabled = false;
					this.TriggerVariable_FixOrder.Enabled = false;
				}
				else if (triggerVariableControl.IsInOriginalOrder())
				{
					byte enabled = (triggerVariableControl.SelectedIndex + 1 < num) ? 1 : 0;
					this.TriggerVariable_MoveDown.Enabled = (enabled != 0);
					byte enabled2 = (this.TriggerVariableControl.SelectedIndex > 0) ? 1 : 0;
					this.TriggerVariable_MoveUp.Enabled = (enabled2 != 0);
					this.TriggerVariable_FixOrder.Enabled = false;
				}
				else
				{
					this.TriggerVariable_MoveDown.Enabled = false;
					this.TriggerVariable_MoveUp.Enabled = false;
					this.TriggerVariable_FixOrder.Enabled = true;
				}
			}
		}

		private unsafe void TriggerVariable_FixOrder_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl triggerVariableControl = this.TriggerVariableControl;
			if (triggerVariableControl.SelectedIndex != -1)
			{
				cTrigger* ptr = *(this.SelectedTriggerIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				if (!triggerVariableControl.IsInOriginalOrder())
				{
					uint num = (uint)triggerVariableControl.SortIndices.Length;
					int* ptr2 = <Module>.new[]((num > 1073741823u) ? 4294967295u : (num << 2));
					int num2 = 0;
					triggerVariableControl = this.TriggerVariableControl;
					if (0 < triggerVariableControl.SortIndices.Length)
					{
						do
						{
							num2[ptr2] = triggerVariableControl.SortIndices[num2];
							num2++;
							triggerVariableControl = this.TriggerVariableControl;
						}
						while (num2 < triggerVariableControl.SortIndices.Length);
					}
					bool flag = <Module>.ScriptEditor.cTrigger.FixVariableOrder(ptr, (int*)ptr2, this.TriggerVariableControl.SortIndices.Length) != null;
					<Module>.delete[]((void*)ptr2);
					if (flag)
					{
						int num3 = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
						this.Edit_Undo.Enabled = ((byte)num3 != 0);
						cEditor* editor = this.Editor;
						int num4 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
						this.Edit_Redo.Enabled = ((byte)num4 != 0);
						this.RefreshTriggerVariables(ptr);
						this.TriggerVariableControl.ForceUnsorted();
					}
				}
			}
		}

		private unsafe void TriggerVariable_MoveUp_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl triggerVariableControl = this.TriggerVariableControl;
			if (triggerVariableControl.SelectedIndex != -1)
			{
				cTrigger* ptr = *(this.SelectedTriggerIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				if (triggerVariableControl.IsInOriginalOrder() && <Module>.ScriptEditor.cTrigger.MoveVariableUp(ptr, triggerVariableControl.SelectedIndex) != null)
				{
					int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num != 0);
					cEditor* editor = this.Editor;
					int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num2 != 0);
					this.RefreshTriggerVariables(ptr);
					triggerVariableControl = this.TriggerVariableControl;
					triggerVariableControl.SelectedIndex--;
				}
			}
		}

		private unsafe void TriggerVariable_MoveDown_Click(object sender, EventArgs e)
		{
			Script_GlobalVariableControl triggerVariableControl = this.TriggerVariableControl;
			if (triggerVariableControl.SelectedIndex != -1)
			{
				cTrigger* ptr = *(this.SelectedTriggerIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
				if (triggerVariableControl.IsInOriginalOrder() && <Module>.ScriptEditor.cTrigger.MoveVariableDown(ptr, triggerVariableControl.SelectedIndex) != null)
				{
					int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
					this.Edit_Undo.Enabled = ((byte)num != 0);
					cEditor* editor = this.Editor;
					int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
					this.Edit_Redo.Enabled = ((byte)num2 != 0);
					this.RefreshTriggerVariables(ptr);
					triggerVariableControl = this.TriggerVariableControl;
					triggerVariableControl.SelectedIndex++;
				}
			}
		}

		private void Script_Close_Click(object sender, EventArgs e)
		{
			this.SaveScript();
			base.Close();
		}

		private void TriggerEventBox_InPlace_SelectionCancel(object sender, EventArgs e)
		{
			sender.Dispose();
			this.GlobalTriggerControl.Focus();
		}

		private unsafe void TriggerEventBox_InPlace_SelectionReady(object sender, EventArgs e)
		{
			cTrigger* ptr = *(this.GlobalTriggerControl.SelectedIndex * 4 + *(int*)(this.Editor + 28 / sizeof(cEditor)));
			int num = *(sender.SelectedIndex * 4 + ref <Module>.ScriptEditor.EventTypeList);
			if (<Module>.?SetTriggerEventType@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@W4eEvent_Type@Script@@@Z(this.Editor, ptr, num) != null)
			{
				int num2 = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num2 != 0);
				cEditor* editor = this.Editor;
				int num3 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num3 != 0);
				this.RefreshTriggers();
				this.RefreshTriggerData(ptr, 0);
				sender.Dispose();
				this.GlobalTriggerControl.Focus();
			}
		}

		private void TriggerNameBox_InPlace_EditingCancel(object sender, EventArgs e)
		{
			sender.Dispose();
			this.GlobalTriggerControl.Focus();
		}

		private unsafe void TriggerNameBox_InPlace_EditingReady(object sender, EventArgs e)
		{
			int arg_14_0 = this.GlobalTriggerControl.SelectedIndex;
			cEditor* editor = this.Editor;
			cTrigger* ptr = *(arg_14_0 * 4 + *(editor + 28));
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, sender.Text);
			bool flag;
			try
			{
				flag = (((<Module>.GBaseString<char>.Compare(ptr + 8, ptr2, false) != 0) ? 1 : 0) != 0);
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
				GBaseString<char> gBaseString<char>2;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, sender.Text);
				bool flag2;
				try
				{
					flag2 = (((<Module>.ScriptEditor.cEditor.RenameTrigger(this.Editor, ptr, ref gBaseString<char>2) == 0) ? 1 : 0) != 0);
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
				if (flag2)
				{
					return;
				}
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor2 = this.Editor;
				int num2 = (*(editor2 + 68) < *(editor2 + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
				this.RefreshTriggers();
				this.RefreshTriggerData(ptr, 0);
			}
			sender.Dispose();
			this.GlobalTriggerControl.Focus();
		}

		private unsafe void Edit_Undo_Click(object sender, EventArgs e)
		{
			if (<Module>.ScriptEditor.cEditor.Undo(this.Editor) != null)
			{
				this.RefreshAll();
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor = this.Editor;
				int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
			}
		}

		private unsafe void Edit_Redo_Click(object sender, EventArgs e)
		{
			if (<Module>.ScriptEditor.cEditor.Redo(this.Editor) != null)
			{
				this.RefreshAll();
				int num = (*(int*)(this.Editor + 68 / sizeof(cEditor)) > 0) ? 1 : 0;
				this.Edit_Undo.Enabled = ((byte)num != 0);
				cEditor* editor = this.Editor;
				int num2 = (*(editor + 68) < *(editor + 60)) ? 1 : 0;
				this.Edit_Redo.Enabled = ((byte)num2 != 0);
			}
		}

		private unsafe cEditor* GetEditor(int index)
		{
			int scriptIndex = this.ScriptIndex;
			cManager* ptr = <Module>.SafeWorld + 5128 / sizeof(GEditorWorld);
			cEditor* result;
			if (scriptIndex >= *(*ptr + 4))
			{
				result = null;
			}
			else if (*(*(ptr + 12) + scriptIndex * 4) == 0 && <Module>.ScriptEditor.cManager.LoadEditor(ptr, scriptIndex) == null)
			{
				result = null;
			}
			else
			{
				result = *(*(ptr + 12) + scriptIndex * 4);
			}
			return result;
		}

		public void EditorsChanged()
		{
			this.RefreshAll();
		}
	}
}
