using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NCurveEditor : UserControl
	{
		public delegate void CurveChangedHandler();

		private int Type;

		private unsafe GPCurveLinearScalar* LinearScalarPrototype;

		private unsafe GCurveLinearScalarEditor* LinearScalarEditor;

		private unsafe GPCurveLinearColor* LinearColorPrototype;

		private unsafe GCurveLinearColorEditor* LinearColorEditor;

		private unsafe GPCurveBezierScalar* BezierScalarPrototype;

		private unsafe GCurveBezierScalarEditor* BezierScalarEditor;

		private int ColorPanelToEditPanel;

		private int HighlightNodeIndex;

		private bool CursorHidden;

		private int DragMode;

		private Point BaseMousePoint;

		private Point PrevMousePoint;

		private RectangleF IViewport;

		private Rectangle EnvelopRectangle;

		private RectangleF EnvelopRectangleF;

		private Rectangle SelectionRectangle;

		private int X0;

		private int X1;

		private int X5;

		private int X10;

		private int Y0;

		private int Y1;

		private int YM1;

		private int Y5;

		private int YM5;

		private int Y10;

		private int YM10;

		private unsafe GArray<GKeyNode>* Nodes;

		private Point ContextMenuPosition;

		private bool ContextMenuBlock;

		private int ContextMenuNodeIndex;

		private bool DisposeLinearScalarPrototype;

		private bool DisposeLinearColorPrototype;

		private bool DisposeBezierScalarPrototype;

		private int KeyMoveMode;

		private bool InvalidColorPanel;

		private ColorPicker ColorPicker;

		private NFloatUpDown TimeUpDown;

		private NFloatUpDown ValueUpDown;

		private NDirect3D EditPanelD3D;

		private NDirect3D ColorPanelD3D;

		private MainMenu mainMenu1;

		private MenuItem menuItem4;

		private MenuItem menuItem7;

		private MenuItem Exit;

		private MenuItem File;

		private MenuItem New;

		private MenuItem Open;

		private MenuItem Save;

		private MenuItem SaveAs;

		private MenuItem Edit;

		private MenuItem Undo;

		private new MenuItem Select;

		private MenuItem All;

		private MenuItem None;

		private MenuItem Invert;

		private ContextMenu EditPanelContextMenu;

		private MenuItem AddKey;

		private MenuItem RemoveKey;

		private MenuItem ClearLoopStart;

		private MenuItem ClearLoopEnd;

		private MenuItem SetAsLoopStart;

		private MenuItem SetAsLoopEnd;

		private MenuItem PeekColor;

		private Panel TimePanel;

		private Panel ValuePanel;

		private MenuItem Redo;

		private NSolidPanel EditPanel;

		private StatusBar StatusBar;

		private NSolidPanel ColorPanel;

		private Panel ParameterPanel;

		private ComboBox TypeSelect;

		private Container components;

		public event NCurveEditor.CurveChangedHandler NotifyUndoStep
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.NotifyUndoStep = Delegate.Combine(this.NotifyUndoStep, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.NotifyUndoStep = Delegate.Remove(this.NotifyUndoStep, value);
			}
		}

		public unsafe NCurveEditor(GPCurveBezierScalar* prototype, GKeyLimit* keylimit)
		{
			this.Type = 2;
			this.HighlightNodeIndex = -1;
			this.DragMode = 0;
			this.NotifyUndoStep = null;
			this.InitializeComponent();
			this.InitializeComponent2(null, null, prototype, keylimit);
		}

		public unsafe NCurveEditor(GPCurveBezierScalar* prototype)
		{
			this.Type = 2;
			this.HighlightNodeIndex = -1;
			this.DragMode = 0;
			this.NotifyUndoStep = null;
			this.InitializeComponent();
			this.InitializeComponent2(null, null, prototype, null);
		}

		public unsafe NCurveEditor(GPCurveLinearColor* prototype)
		{
			this.Type = 1;
			this.HighlightNodeIndex = -1;
			this.DragMode = 0;
			this.NotifyUndoStep = null;
			this.InitializeComponent();
			this.InitializeComponent2(null, prototype, null, null);
		}

		public unsafe NCurveEditor(GPCurveLinearScalar* prototype, GKeyLimit* keylimit)
		{
			this.Type = 0;
			this.HighlightNodeIndex = -1;
			this.DragMode = 0;
			this.NotifyUndoStep = null;
			this.InitializeComponent();
			this.InitializeComponent2(prototype, null, null, keylimit);
		}

		public unsafe NCurveEditor(GPCurveLinearScalar* prototype)
		{
			this.Type = 0;
			this.HighlightNodeIndex = -1;
			this.DragMode = 0;
			this.NotifyUndoStep = null;
			this.InitializeComponent();
			this.InitializeComponent2(prototype, null, null, null);
		}

		public NCurveEditor()
		{
			this.Type = 0;
			this.HighlightNodeIndex = -1;
			this.DragMode = 0;
			this.NotifyUndoStep = null;
			this.InitializeComponent();
			this.InitializeComponent2(null, null, null, null);
		}

		protected unsafe override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
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
			GArray<GKeyNode>* nodes = this.Nodes;
			if (nodes != null)
			{
				GArray<GKeyNode>* ptr = nodes;
				int* arg_42_0 = ref *(int*)(ptr + 4 / sizeof(GArray<GKeyNode>));
				uint num = (uint)(*(int*)ptr);
				if (num != 0u)
				{
					<Module>.free(num);
					*(int*)ptr = 0;
				}
				*arg_42_0 = 0;
				*(int*)(ptr + 8 / sizeof(GArray<GKeyNode>)) = 0;
				<Module>.delete((void*)ptr);
			}
			GCurveLinearScalarEditor* linearScalarEditor = this.LinearScalarEditor;
			if (linearScalarEditor != null)
			{
				GCurveLinearScalarEditor* ptr2 = linearScalarEditor;
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.{dtor}(ptr2);
				<Module>.delete((void*)ptr2);
			}
			if (this.DisposeLinearScalarPrototype)
			{
				GPCurveLinearScalar* linearScalarPrototype = this.LinearScalarPrototype;
				if (linearScalarPrototype != null)
				{
					GPCurveLinearScalar* ptr3 = linearScalarPrototype;
					object arg_90_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, *(*(int*)ptr3));
				}
			}
			if (this.DisposeLinearColorPrototype)
			{
				GPCurveLinearColor* linearColorPrototype = this.LinearColorPrototype;
				if (linearColorPrototype != null)
				{
					GPCurveLinearColor* ptr4 = linearColorPrototype;
					object arg_B2_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, *(*(int*)ptr4));
				}
			}
			if (this.DisposeBezierScalarPrototype)
			{
				GPCurveBezierScalar* bezierScalarPrototype = this.BezierScalarPrototype;
				if (bezierScalarPrototype != null)
				{
					GPCurveBezierScalar* ptr5 = bezierScalarPrototype;
					object arg_D1_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr5, 1, *(*(int*)ptr5));
				}
			}
		}

		private void InitializeComponent()
		{
			this.EditPanelContextMenu = new ContextMenu();
			this.AddKey = new MenuItem();
			this.RemoveKey = new MenuItem();
			this.SetAsLoopStart = new MenuItem();
			this.SetAsLoopEnd = new MenuItem();
			this.ClearLoopStart = new MenuItem();
			this.ClearLoopEnd = new MenuItem();
			this.PeekColor = new MenuItem();
			this.StatusBar = new StatusBar();
			this.ParameterPanel = new Panel();
			this.ValuePanel = new Panel();
			this.TimePanel = new Panel();
			this.TypeSelect = new ComboBox();
			this.mainMenu1 = new MainMenu();
			this.File = new MenuItem();
			this.New = new MenuItem();
			this.Open = new MenuItem();
			this.menuItem4 = new MenuItem();
			this.Save = new MenuItem();
			this.SaveAs = new MenuItem();
			this.menuItem7 = new MenuItem();
			this.Exit = new MenuItem();
			this.Edit = new MenuItem();
			this.Undo = new MenuItem();
			this.Redo = new MenuItem();
			this.Select = new MenuItem();
			this.All = new MenuItem();
			this.None = new MenuItem();
			this.Invert = new MenuItem();
			this.ParameterPanel.SuspendLayout();
			base.SuspendLayout();
			MenuItem[] items = new MenuItem[]
			{
				this.AddKey,
				this.RemoveKey,
				this.SetAsLoopStart,
				this.SetAsLoopEnd,
				this.ClearLoopStart,
				this.ClearLoopEnd,
				this.PeekColor
			};
			this.EditPanelContextMenu.MenuItems.AddRange(items);
			this.EditPanelContextMenu.Popup += new EventHandler(this.EditPanelContextMenu_Popup);
			this.AddKey.Index = 0;
			this.AddKey.Text = "Add key";
			this.AddKey.Click += new EventHandler(this.AddKey_Click);
			this.RemoveKey.Index = 1;
			this.RemoveKey.Text = "Remove key";
			this.RemoveKey.Click += new EventHandler(this.RemoveKey_Click);
			this.SetAsLoopStart.Index = 2;
			this.SetAsLoopStart.Text = "Set as loop start";
			this.SetAsLoopStart.Click += new EventHandler(this.SetAsLoopStart_Click);
			this.SetAsLoopEnd.Index = 3;
			this.SetAsLoopEnd.Text = "Set as loop end";
			this.SetAsLoopEnd.Click += new EventHandler(this.SetAsLoopEnd_Click);
			this.ClearLoopStart.Checked = true;
			this.ClearLoopStart.Index = 4;
			this.ClearLoopStart.Text = "Clear loop start";
			this.ClearLoopStart.Click += new EventHandler(this.ClearLoopStart_Click);
			this.ClearLoopEnd.Checked = true;
			this.ClearLoopEnd.Index = 5;
			this.ClearLoopEnd.Text = "Clear loop end";
			this.ClearLoopEnd.Click += new EventHandler(this.ClearLoopEnd_Click);
			this.PeekColor.Index = 6;
			this.PeekColor.Text = "Peek color";
			this.PeekColor.Click += new EventHandler(this.PeekColor_Click);
			Point location = new Point(0, 457);
			this.StatusBar.Location = location;
			this.StatusBar.Name = "StatusBar";
			Size size = new Size(632, 24);
			this.StatusBar.Size = size;
			this.StatusBar.TabIndex = 1;
			this.ParameterPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
			this.ParameterPanel.Controls.Add(this.ValuePanel);
			this.ParameterPanel.Controls.Add(this.TimePanel);
			this.ParameterPanel.Controls.Add(this.TypeSelect);
			Point location2 = new Point(8, 8);
			this.ParameterPanel.Location = location2;
			this.ParameterPanel.Name = "ParameterPanel";
			Size size2 = new Size(256, 448);
			this.ParameterPanel.Size = size2;
			this.ParameterPanel.TabIndex = 3;
			Color window = SystemColors.Window;
			this.ValuePanel.BackColor = window;
			this.ValuePanel.BorderStyle = BorderStyle.Fixed3D;
			Point location3 = new Point(128, 0);
			this.ValuePanel.Location = location3;
			this.ValuePanel.Name = "ValuePanel";
			Size size3 = new Size(128, 24);
			this.ValuePanel.Size = size3;
			this.ValuePanel.TabIndex = 2;
			Color window2 = SystemColors.Window;
			this.TimePanel.BackColor = window2;
			this.TimePanel.BorderStyle = BorderStyle.Fixed3D;
			Point location4 = new Point(0, 0);
			this.TimePanel.Location = location4;
			this.TimePanel.Name = "TimePanel";
			Size size4 = new Size(128, 24);
			this.TimePanel.Size = size4;
			this.TimePanel.TabIndex = 1;
			this.TypeSelect.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TypeSelect.Enabled = false;
			this.TypeSelect.ImeMode = ImeMode.NoControl;
			object[] items2 = new object[]
			{
				"Linear Scalar",
				"Linear Color",
				"Bezier Scalar"
			};
			this.TypeSelect.Items.AddRange(items2);
			Point location5 = new Point(8, 400);
			this.TypeSelect.Location = location5;
			this.TypeSelect.Name = "TypeSelect";
			Size size5 = new Size(96, 21);
			this.TypeSelect.Size = size5;
			this.TypeSelect.TabIndex = 0;
			this.TypeSelect.Visible = false;
			this.TypeSelect.SelectedIndexChanged += new EventHandler(this.TypeSelect_SelectedIndexChanged);
			MenuItem[] items3 = new MenuItem[]
			{
				this.File,
				this.Edit,
				this.Select
			};
			this.mainMenu1.MenuItems.AddRange(items3);
			this.File.Index = 0;
			MenuItem[] items4 = new MenuItem[]
			{
				this.New,
				this.Open,
				this.menuItem4,
				this.Save,
				this.SaveAs,
				this.menuItem7,
				this.Exit
			};
			this.File.MenuItems.AddRange(items4);
			this.File.Text = "&File";
			this.New.Index = 0;
			this.New.Shortcut = Shortcut.CtrlN;
			this.New.Text = "&New";
			this.Open.Index = 1;
			this.Open.Shortcut = Shortcut.CtrlO;
			this.Open.Text = "&Open...";
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			this.Save.Index = 3;
			this.Save.Shortcut = Shortcut.CtrlS;
			this.Save.Text = "&Save";
			this.SaveAs.Index = 4;
			this.SaveAs.Text = "Save &As...";
			this.menuItem7.Index = 5;
			this.menuItem7.Text = "-";
			this.Exit.Index = 6;
			this.Exit.Shortcut = Shortcut.AltF4;
			this.Exit.Text = "E&xit";
			this.Exit.Click += new EventHandler(this.Exit_Click);
			this.Edit.Index = 1;
			MenuItem[] items5 = new MenuItem[]
			{
				this.Undo,
				this.Redo
			};
			this.Edit.MenuItems.AddRange(items5);
			this.Edit.Text = "&Edit";
			this.Undo.Index = 0;
			this.Undo.Shortcut = Shortcut.CtrlZ;
			this.Undo.Text = "&Undo";
			this.Undo.Click += new EventHandler(this.Undo_Click);
			this.Redo.Index = 1;
			this.Redo.Shortcut = Shortcut.CtrlY;
			this.Redo.Text = "&Redo";
			this.Redo.Click += new EventHandler(this.Redo_Click);
			this.Select.Index = 2;
			MenuItem[] items6 = new MenuItem[]
			{
				this.All,
				this.None,
				this.Invert
			};
			this.Select.MenuItems.AddRange(items6);
			this.Select.Text = "&Select";
			this.All.Index = 0;
			this.All.Shortcut = Shortcut.CtrlA;
			this.All.Text = "&All";
			this.All.Click += new EventHandler(this.All_Click);
			this.None.Index = 1;
			this.None.Shortcut = Shortcut.CtrlShiftA;
			this.None.Text = "&None";
			this.None.Click += new EventHandler(this.None_Click);
			this.Invert.Index = 2;
			this.Invert.Shortcut = Shortcut.CtrlI;
			this.Invert.Text = "&Invert";
			Size clientSize = new Size(632, 481);
			base.ClientSize = clientSize;
			base.Controls.Add(this.StatusBar);
			base.Controls.Add(this.ParameterPanel);
			base.Name = "NCurveEditor";
			this.Text = "CurveEditor";
			base.SizeChanged += new EventHandler(this.NCurveEditor_SizeChanged);
			base.MouseWheel += new MouseEventHandler(this.NCurveEditor_MouseWheel);
			this.ParameterPanel.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public void DisposeD3DX()
		{
			NDirect3D colorPanelD3D = this.ColorPanelD3D;
			if (colorPanelD3D != null)
			{
				colorPanelD3D.DisposeD3DX();
			}
			NDirect3D editPanelD3D = this.EditPanelD3D;
			if (editPanelD3D != null)
			{
				editPanelD3D.DisposeD3DX();
			}
		}

		public new void Update()
		{
			this.RefreshComponent();
		}

		private unsafe void InitializeComponent2(GPCurveLinearScalar* linear_scalar_prototype, GPCurveLinearColor* linear_color_prototype, GPCurveBezierScalar* bezier_scalar_prototype, GKeyLimit* keylimit)
		{
			this.EditPanel = new NSolidPanel();
			this.ColorPanel = new NSolidPanel();
			this.EditPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			Color window = SystemColors.Window;
			this.EditPanel.BackColor = window;
			this.EditPanel.BorderStyle = BorderStyle.Fixed3D;
			this.EditPanel.ContextMenu = this.EditPanelContextMenu;
			Point location = new Point(272, 8);
			this.EditPanel.Location = location;
			this.EditPanel.Name = "EditPanel";
			Size size = new Size(352, 408);
			this.EditPanel.Size = size;
			this.EditPanel.TabIndex = 0;
			this.EditPanel.Resize += new EventHandler(this.EditPanel_Resize);
			this.EditPanel.MouseUp += new MouseEventHandler(this.EditPanel_MouseUp);
			this.EditPanel.Paint += new PaintEventHandler(this.EditPanel_Paint);
			this.EditPanel.KeyDown += new KeyEventHandler(this.EditPanel_KeyDown);
			this.EditPanel.MouseMove += new MouseEventHandler(this.EditPanel_MouseMove);
			this.EditPanel.MouseLeave += new EventHandler(this.EditPanel_MouseLeave);
			this.EditPanel.MouseDown += new MouseEventHandler(this.EditPanel_MouseDown);
			this.ColorPanel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			Color window2 = SystemColors.Window;
			this.ColorPanel.BackColor = window2;
			this.ColorPanel.BorderStyle = BorderStyle.Fixed3D;
			Point location2 = new Point(272, 424);
			this.ColorPanel.Location = location2;
			this.ColorPanel.Name = "ColorPanel";
			Size size2 = new Size(352, 32);
			this.ColorPanel.Size = size2;
			this.ColorPanel.TabIndex = 2;
			this.ColorPanel.Resize += new EventHandler(this.ColorPanel_Resize);
			this.ColorPanel.Paint += new PaintEventHandler(this.ColorPanel_Paint);
			this.ColorPanel.MouseMove += new MouseEventHandler(this.ColorPanel_MouseMove);
			this.ColorPanel.MouseDown += new MouseEventHandler(this.ColorPanel_MouseDown);
			base.Controls.Add(this.EditPanel);
			base.Controls.Add(this.ColorPanel);
			Application.Idle += new EventHandler(this.NCurveEditor_Idle);
			Size clientSize = this.TimePanel.ClientSize;
			this.TimePanel.Height = this.TimePanel.Height + (16 - clientSize.Height);
			this.TimeUpDown = new NFloatUpDown();
			Point location3 = new Point(0, 0);
			this.TimeUpDown.Location = location3;
			Size size3 = new Size(this.TimePanel.ClientSize.Width, 16);
			this.TimeUpDown.Size = size3;
			this.TimeUpDown.BorderStyle = BorderStyle.None;
			this.TimeUpDown.Increment = 0.10000000149011612;
			this.TimeUpDown.Minimum = 0.0;
			if (keylimit != null)
			{
				this.TimeUpDown.Maximum = (double)(*(float*)keylimit);
			}
			else
			{
				this.TimeUpDown.Maximum = 3.4028234663852886E+38;
			}
			this.TimeUpDown.Validated += new EventHandler(this.TimeUpDown_Validated);
			this.TimePanel.Controls.Add(this.TimeUpDown);
			this.TimePanel.Enabled = false;
			Size clientSize2 = this.ValuePanel.ClientSize;
			this.ValuePanel.Height = this.ValuePanel.Height + (16 - clientSize2.Height);
			this.ValueUpDown = new NFloatUpDown();
			Point location4 = new Point(0, 0);
			this.ValueUpDown.Location = location4;
			Size size4 = new Size(this.ValuePanel.ClientSize.Width, 16);
			this.ValueUpDown.Size = size4;
			this.ValueUpDown.BorderStyle = BorderStyle.None;
			this.ValueUpDown.Increment = 0.10000000149011612;
			if (keylimit != null)
			{
				this.ValueUpDown.Minimum = (double)(*(float*)(keylimit + 4 / sizeof(GKeyLimit)));
				this.ValueUpDown.Maximum = (double)(*(float*)(keylimit + 8 / sizeof(GKeyLimit)));
			}
			else if (linear_color_prototype != null)
			{
				this.ValueUpDown.Minimum = 0.0;
				this.ValueUpDown.Maximum = 1.0;
			}
			else
			{
				this.ValueUpDown.Minimum = -3.4028234663852886E+38;
				this.ValueUpDown.Maximum = 3.4028234663852886E+38;
			}
			this.ValueUpDown.Validated += new EventHandler(this.ValueUpDown_Validated);
			this.ValuePanel.Controls.Add(this.ValueUpDown);
			this.ValuePanel.Enabled = false;
			this.ColorPicker = new ColorPicker();
			Point location5 = new Point(0, 32);
			this.ColorPicker.Location = location5;
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.TabIndex = 0;
			this.ColorPicker.Font = this.Font;
			this.ColorPicker.Text = "";
			this.ColorPicker.ValueChanged += new ColorPicker.__Delegate_ValueChanged(this.ColorPicker_ValueChanged);
			this.ParameterPanel.Controls.Add(this.ColorPicker);
			this.EditPanelD3D = new NDirect3D(this.EditPanel);
			this.ColorPanelD3D = new NDirect3D(this.ColorPanel);
			if (linear_scalar_prototype != null)
			{
				this.LinearScalarPrototype = linear_scalar_prototype;
			}
			else
			{
				GPCurveLinearScalar* ptr = <Module>.@new(24u);
				GPCurveLinearScalar* linearScalarPrototype;
				try
				{
					if (ptr != null)
					{
						linearScalarPrototype = <Module>.GPCurveLinearScalar.{ctor}(ptr);
					}
					else
					{
						linearScalarPrototype = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr);
					throw;
				}
				this.LinearScalarPrototype = linearScalarPrototype;
				this.DisposeLinearScalarPrototype = true;
			}
			if (keylimit != null)
			{
				GCurveLinearScalarEditor* ptr2 = <Module>.@new(140u);
				GCurveLinearScalarEditor* linearScalarEditor;
				try
				{
					if (ptr2 != null)
					{
						linearScalarEditor = <Module>.GCurveLinearScalarEditor.{ctor}(ptr2, this.LinearScalarPrototype, keylimit);
					}
					else
					{
						linearScalarEditor = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr2);
					throw;
				}
				this.LinearScalarEditor = linearScalarEditor;
			}
			else
			{
				GCurveLinearScalarEditor* ptr3 = <Module>.@new(140u);
				GCurveLinearScalarEditor* linearScalarEditor2;
				try
				{
					if (ptr3 != null)
					{
						linearScalarEditor2 = <Module>.GCurveLinearScalarEditor.{ctor}(ptr3, this.LinearScalarPrototype);
					}
					else
					{
						linearScalarEditor2 = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr3);
					throw;
				}
				this.LinearScalarEditor = linearScalarEditor2;
			}
			if (linear_color_prototype != null)
			{
				this.LinearColorPrototype = linear_color_prototype;
			}
			else
			{
				GPCurveLinearColor* ptr4 = <Module>.@new(24u);
				GPCurveLinearColor* linearColorPrototype;
				try
				{
					if (ptr4 != null)
					{
						linearColorPrototype = <Module>.GPCurveLinearColor.{ctor}(ptr4);
					}
					else
					{
						linearColorPrototype = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr4);
					throw;
				}
				this.LinearColorPrototype = linearColorPrototype;
				this.DisposeLinearColorPrototype = true;
			}
			GCurveLinearColorEditor* ptr5 = <Module>.@new(164u);
			GCurveLinearColorEditor* linearColorEditor;
			try
			{
				if (ptr5 != null)
				{
					GPCurveLinearColor* linearColorPrototype2 = this.LinearColorPrototype;
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.{ctor}(ptr5, linearColorPrototype2);
					try
					{
						*(int*)ptr5 = ref <Module>.??_7GCurveLinearColorEditor@@6B@;
						*(float*)(ptr5 + 144 / sizeof(GCurveLinearColorEditor)) = 3.40282347E+38f;
						*(float*)(ptr5 + 152 / sizeof(GCurveLinearColorEditor)) = 1f;
						*(float*)(ptr5 + 148 / sizeof(GCurveLinearColorEditor)) = 0f;
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.{dtor}), (void*)ptr5);
						throw;
					}
					linearColorEditor = ptr5;
				}
				else
				{
					linearColorEditor = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr5);
				throw;
			}
			this.LinearColorEditor = linearColorEditor;
			if (bezier_scalar_prototype != null)
			{
				this.BezierScalarPrototype = bezier_scalar_prototype;
			}
			else
			{
				GPCurveBezierScalar* ptr6 = <Module>.@new(36u);
				GPCurveBezierScalar* bezierScalarPrototype;
				try
				{
					if (ptr6 != null)
					{
						bezierScalarPrototype = <Module>.GPCurveBezierScalar.{ctor}(ptr6);
					}
					else
					{
						bezierScalarPrototype = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr6);
					throw;
				}
				this.BezierScalarPrototype = bezierScalarPrototype;
				this.DisposeBezierScalarPrototype = true;
			}
			if (keylimit != null)
			{
				GCurveBezierScalarEditor* ptr7 = <Module>.@new(140u);
				GCurveBezierScalarEditor* bezierScalarEditor;
				try
				{
					if (ptr7 != null)
					{
						GPCurveBezierScalar* bezierScalarPrototype2 = this.BezierScalarPrototype;
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.{ctor}(ptr7, bezierScalarPrototype2);
						try
						{
							*(int*)ptr7 = ref <Module>.??_7?$GCurveScalarEditor@VGCurveBezierScalar@@VGPCurveBezierScalar@@VGPCurveScalarKey@@@@6B@;
							cpblk(ptr7 + 120 / sizeof(GCurveBezierScalarEditor), keylimit, 12);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.{dtor}), (void*)ptr7);
							throw;
						}
						try
						{
							*(int*)ptr7 = ref <Module>.??_7GCurveBezierScalarEditor@@6B@;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GCurveScalarEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.{dtor}), (void*)ptr7);
							throw;
						}
						bezierScalarEditor = ptr7;
					}
					else
					{
						bezierScalarEditor = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr7);
					throw;
				}
				this.BezierScalarEditor = bezierScalarEditor;
			}
			else
			{
				GCurveBezierScalarEditor* ptr8 = <Module>.@new(140u);
				GCurveBezierScalarEditor* bezierScalarEditor2;
				try
				{
					if (ptr8 != null)
					{
						bezierScalarEditor2 = <Module>.GCurveBezierScalarEditor.{ctor}(ptr8, this.BezierScalarPrototype);
					}
					else
					{
						bezierScalarEditor2 = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr8);
					throw;
				}
				this.BezierScalarEditor = bezierScalarEditor2;
			}
			GArray<GKeyNode>* ptr9 = <Module>.@new(12u);
			GArray<GKeyNode>* nodes;
			try
			{
				if (ptr9 != null)
				{
					*(int*)ptr9 = 0;
					*(int*)(ptr9 + 4 / sizeof(GArray<GKeyNode>)) = 0;
					*(int*)(ptr9 + 8 / sizeof(GArray<GKeyNode>)) = 0;
					nodes = ptr9;
				}
				else
				{
					nodes = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr9);
				throw;
			}
			this.Nodes = nodes;
			this.GetDesignerComponentParameters();
			this.TypeSelect.SelectedIndex = this.Type;
			this.CenterViewport();
			this.RefreshComponent();
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						*(byte*)(this.BezierScalarEditor + 136 / sizeof(GCurveBezierScalarEditor)) = 0;
					}
				}
				else
				{
					*(byte*)(this.LinearColorEditor + 160 / sizeof(GCurveLinearColorEditor)) = 0;
				}
			}
			else
			{
				*(byte*)(this.LinearScalarEditor + 136 / sizeof(GCurveLinearScalarEditor)) = 0;
			}
		}

		private void InvalidatePanels()
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type != 2)
					{
						return;
					}
				}
				else
				{
					this.InvalidColorPanel = true;
				}
			}
			this.EditPanel.Invalidate();
		}

		private void ShowCursor()
		{
			if (this.CursorHidden)
			{
				Cursor.Show();
				this.CursorHidden = false;
			}
		}

		private void HideCursor()
		{
			if (!this.CursorHidden)
			{
				Cursor.Hide();
				this.CursorHidden = true;
			}
		}

		private unsafe GArray<int>* GetSelectedIndices()
		{
			int type = this.Type;
			if (type == 0)
			{
				return this.LinearScalarEditor + 84 / sizeof(GCurveLinearScalarEditor);
			}
			if (type == 1)
			{
				return this.LinearColorEditor + 108 / sizeof(GCurveLinearColorEditor);
			}
			if (type != 2)
			{
				return this.LinearScalarEditor + 84 / sizeof(GCurveLinearScalarEditor);
			}
			return this.BezierScalarEditor + 84 / sizeof(GCurveBezierScalarEditor);
		}

		private unsafe int GetNumberOfSelectedIndices()
		{
			int type = this.Type;
			if (type == 0)
			{
				return *(int*)(this.LinearScalarEditor + 88 / sizeof(GCurveLinearScalarEditor));
			}
			if (type == 1)
			{
				return *(int*)(this.LinearColorEditor + 112 / sizeof(GCurveLinearColorEditor));
			}
			if (type != 2)
			{
				return 0;
			}
			return *(int*)(this.BezierScalarEditor + 88 / sizeof(GCurveBezierScalarEditor));
		}

		private unsafe int GetNumberOfKeys()
		{
			int type = this.Type;
			if (type == 0)
			{
				return *(*(int*)(this.LinearScalarEditor + 20 / sizeof(GCurveLinearScalarEditor)) + 16);
			}
			if (type == 1)
			{
				return *(*(int*)(this.LinearColorEditor + 32 / sizeof(GCurveLinearColorEditor)) + 16);
			}
			if (type != 2)
			{
				return 0;
			}
			return *(*(int*)(this.BezierScalarEditor + 20 / sizeof(GCurveBezierScalarEditor)) + 16);
		}

		private unsafe float GetHorizontalKeyValue(int index)
		{
			if (index >= this.GetNumberOfKeys())
			{
				index = 0;
			}
			int type = this.Type;
			if (type == 0)
			{
				return *(index * 8 + *(*(int*)(this.LinearScalarEditor + 20 / sizeof(GCurveLinearScalarEditor)) + 12));
			}
			if (type == 1)
			{
				return *(index * 20 + *(*(int*)(this.LinearColorEditor + 32 / sizeof(GCurveLinearColorEditor)) + 12));
			}
			if (type != 2)
			{
				return 0f;
			}
			return *(index * 8 + *(*(int*)(this.BezierScalarEditor + 20 / sizeof(GCurveBezierScalarEditor)) + 12));
		}

		private unsafe float GetVerticalKeyValue(int index)
		{
			if (index >= this.GetNumberOfKeys())
			{
				index = 0;
			}
			int type = this.Type;
			if (type == 0)
			{
				return *(index * 8 + *(*(int*)(this.LinearScalarEditor + 20 / sizeof(GCurveLinearScalarEditor)) + 12) + 4);
			}
			if (type == 1)
			{
				return *(index * 20 + *(*(int*)(this.LinearColorEditor + 32 / sizeof(GCurveLinearColorEditor)) + 12) + 16);
			}
			if (type != 2)
			{
				return 0f;
			}
			return *(index * 8 + *(*(int*)(this.BezierScalarEditor + 20 / sizeof(GCurveBezierScalarEditor)) + 12) + 4);
		}

		private unsafe void ClearSelection()
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>* bezierScalarEditor = this.BezierScalarEditor;
						<Module>.GArray<int>.Clear(bezierScalarEditor + 84, 0);
						*(bezierScalarEditor + 132) = -1;
					}
				}
				else
				{
					GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>* linearColorEditor = this.LinearColorEditor;
					<Module>.GArray<int>.Clear(linearColorEditor + 108, 0);
					*(linearColorEditor + 156) = -1;
				}
			}
			else
			{
				GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>* linearScalarEditor = this.LinearScalarEditor;
				<Module>.GArray<int>.Clear(linearScalarEditor + 84, 0);
				*(linearScalarEditor + 132) = -1;
			}
		}

		private void AddIndexToSelection(int index)
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.AddIndexToSelection(this.BezierScalarEditor, index);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.AddIndexToSelection(this.LinearColorEditor, index);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.AddIndexToSelection(this.LinearScalarEditor, index);
			}
		}

		private void InvertSelection(int index)
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.InvertSelection(this.BezierScalarEditor, index);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.InvertSelection(this.LinearColorEditor, index);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.InvertSelection(this.LinearScalarEditor, index);
			}
		}

		private void SelectToIndex(int index)
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SelectToIndex(this.BezierScalarEditor, index);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.SelectToIndex(this.LinearColorEditor, index);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SelectToIndex(this.LinearScalarEditor, index);
			}
		}

		private unsafe int GetLoopStart()
		{
			int type = this.Type;
			if (type == 0)
			{
				return *(*(int*)(this.LinearScalarEditor + 20 / sizeof(GCurveLinearScalarEditor)) + 4);
			}
			if (type == 1)
			{
				return *(*(int*)(this.LinearColorEditor + 32 / sizeof(GCurveLinearColorEditor)) + 4);
			}
			if (type != 2)
			{
				return -1;
			}
			return *(*(int*)(this.BezierScalarEditor + 20 / sizeof(GCurveBezierScalarEditor)) + 4);
		}

		private unsafe int GetLoopEnd()
		{
			int type = this.Type;
			if (type == 0)
			{
				return *(*(int*)(this.LinearScalarEditor + 20 / sizeof(GCurveLinearScalarEditor)) + 8);
			}
			if (type == 1)
			{
				return *(*(int*)(this.LinearColorEditor + 32 / sizeof(GCurveLinearColorEditor)) + 8);
			}
			if (type != 2)
			{
				return -1;
			}
			return *(*(int*)(this.BezierScalarEditor + 20 / sizeof(GCurveBezierScalarEditor)) + 8);
		}

		private void SetLoopStart(int index, [MarshalAs(UnmanagedType.U1)] bool modifycurrent)
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SetLoopStart(this.BezierScalarEditor, index, modifycurrent);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.SetLoopStart(this.LinearColorEditor, index, modifycurrent);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SetLoopStart(this.LinearScalarEditor, index, modifycurrent);
			}
			this.raise_NotifyUndoStep();
		}

		private void SetLoopEnd(int index, [MarshalAs(UnmanagedType.U1)] bool modifycurrent)
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SetLoopEnd(this.BezierScalarEditor, index, modifycurrent);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.SetLoopEnd(this.LinearColorEditor, index, modifycurrent);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SetLoopEnd(this.LinearScalarEditor, index, modifycurrent);
			}
			this.raise_NotifyUndoStep();
		}

		private unsafe int GetMovedIndex()
		{
			int type = this.Type;
			if (type == 0)
			{
				return *(int*)(this.LinearScalarEditor + 68 / sizeof(GCurveLinearScalarEditor));
			}
			if (type == 1)
			{
				return *(int*)(this.LinearColorEditor + 92 / sizeof(GCurveLinearColorEditor));
			}
			if (type != 2)
			{
				return -1;
			}
			return *(int*)(this.BezierScalarEditor + 68 / sizeof(GCurveBezierScalarEditor));
		}

		private void BeginMove(int baseindex)
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.BeginMove(this.BezierScalarEditor, baseindex);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.BeginMove(this.LinearColorEditor, baseindex);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.BeginMove(this.LinearScalarEditor, baseindex);
			}
		}

		private void EndMove()
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.EndMove(this.BezierScalarEditor);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.EndMove(this.LinearColorEditor);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.EndMove(this.LinearScalarEditor);
			}
			this.raise_NotifyUndoStep();
		}

		private void CancelMove()
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.CancelMove(this.BezierScalarEditor);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.CancelMove(this.LinearColorEditor);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.CancelMove(this.LinearScalarEditor);
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private unsafe bool IsInLimits(GKeyNode* node)
		{
			GPCurveScalarKey gPCurveScalarKey = 0f;
			*(ref gPCurveScalarKey + 4) = 0f;
			GPCurveColorKey gPCurveColorKey = 0f;
			*(ref gPCurveColorKey + 16) = 1f;
			int type = this.Type;
			if (type == 0)
			{
				this.ConvertNodeToScalarKey(node, ref gPCurveScalarKey);
				GCurveScalarEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>* linearScalarEditor = this.LinearScalarEditor;
				byte result;
				if (gPCurveScalarKey >= 0f && gPCurveScalarKey <= *(linearScalarEditor + 120) && *(ref gPCurveScalarKey + 4) >= *(linearScalarEditor + 124) && *(ref gPCurveScalarKey + 4) <= *(linearScalarEditor + 128))
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
				return result != 0;
			}
			if (type == 1)
			{
				this.ConvertNodeToColorKey(node, ref gPCurveColorKey);
				GCurveLinearColorEditor* linearColorEditor = this.LinearColorEditor;
				byte result2;
				if (gPCurveColorKey >= 0f && gPCurveColorKey <= *(linearColorEditor + 144) && *(ref gPCurveColorKey + 16) >= *(linearColorEditor + 148) && *(ref gPCurveColorKey + 16) <= *(linearColorEditor + 152))
				{
					result2 = 1;
				}
				else
				{
					result2 = 0;
				}
				return result2 != 0;
			}
			if (type != 2)
			{
				return false;
			}
			this.ConvertNodeToScalarKey(node, ref gPCurveScalarKey);
			return <Module>.GCurveScalarEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.IsInLimits(this.BezierScalarEditor, ref gPCurveScalarKey) != null;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private bool IsMouseOverControl(Control c)
		{
			Point position = Cursor.Position;
			Point point = this.EditPanel.PointToClient(position);
			return c.Size.Width >= point.X && c.Size.Height >= point.Y && 0 <= point.X && 0 <= point.Y;
		}

		private void GetDesignerComponentParameters()
		{
			Size size = this.EditPanel.Size;
			Point location = this.ColorPanel.Location;
			Point location2 = this.EditPanel.Location;
			int num = location.Y - location2.Y;
			this.ColorPanelToEditPanel = num - size.Height;
		}

		private unsafe void GenerateNodes()
		{
			int num = -2147483648;
			int num2 = 2147483647;
			int num3 = -2147483648;
			int num4 = 2147483647;
			float num5 = -3.40282347E+38f;
			float num6 = 3.40282347E+38f;
			float num7 = -3.40282347E+38f;
			float num8 = 3.40282347E+38f;
			Size size = this.EditPanel.Size;
			float num9 = (float)size.Width;
			float num10 = num9 / this.IViewport.Width;
			float num11 = (float)size.Height;
			float num12 = num11 / this.IViewport.Height;
			GArray<GKeyNode>* nodes = this.Nodes;
			if (*(int*)(nodes + 4 / sizeof(GArray<GKeyNode>)) != this.GetNumberOfKeys())
			{
				<Module>.GArray<GKeyNode>.Resize(nodes, this.GetNumberOfKeys());
			}
			int num13 = 0;
			if (0 < this.GetNumberOfKeys())
			{
				do
				{
					float horizontalKeyValue = this.GetHorizontalKeyValue(num13);
					float verticalKeyValue = this.GetVerticalKeyValue(num13);
					*(*(int*)this.Nodes + num13 * 8) = (int)((double)((horizontalKeyValue - this.IViewport.X) * num10));
					int* arg_105_0 = *(int*)this.Nodes + num13 * 8;
					float num14 = this.IViewport.Height + verticalKeyValue;
					int num15 = (int)((double)((num14 - this.IViewport.Y) * num12));
					*(arg_105_0 + 4) = size.Height - num15;
					if (horizontalKeyValue > num5)
					{
						num5 = horizontalKeyValue;
					}
					if (verticalKeyValue > num7)
					{
						num7 = verticalKeyValue;
					}
					if (horizontalKeyValue < num6)
					{
						num6 = horizontalKeyValue;
					}
					if (verticalKeyValue < num8)
					{
						num8 = verticalKeyValue;
					}
					int num16 = num13 * 8 + *(int*)this.Nodes;
					int num17 = *num16;
					if (num17 > num)
					{
						num = num17;
					}
					int num18 = *(num16 + 4);
					if (num18 > num3)
					{
						num3 = num18;
					}
					if (num17 < num2)
					{
						num2 = num17;
					}
					if (num18 < num4)
					{
						num4 = num18;
					}
					num13++;
				}
				while (num13 < this.GetNumberOfKeys());
			}
			this.EnvelopRectangleF.X = num6;
			this.EnvelopRectangleF.Y = num8;
			this.EnvelopRectangleF.Width = num5 - num6;
			this.EnvelopRectangleF.Height = num7 - num8;
			this.EnvelopRectangle.X = num2;
			this.EnvelopRectangle.Y = num4;
			this.EnvelopRectangle.Width = num - num2;
			this.EnvelopRectangle.Height = num3 - num4;
			this.X0 = (int)((double)(-(double)(this.IViewport.X * num10)));
			int num19 = (int)((double)((this.IViewport.Height - this.IViewport.Y) * num12));
			this.Y0 = size.Height - num19;
			this.X1 = (int)((double)((1f - this.IViewport.X) * num10));
			float num20 = this.IViewport.Height + 1f;
			int num21 = (int)((double)((num20 - this.IViewport.Y) * num12));
			this.Y1 = size.Height - num21;
			float num22 = this.IViewport.Height - 1f;
			int num23 = (int)((double)((num22 - this.IViewport.Y) * num12));
			this.YM1 = size.Height - num23;
			this.X5 = (int)((double)((5f - this.IViewport.X) * num10));
			float num24 = this.IViewport.Height + 5f;
			int num25 = (int)((double)((num24 - this.IViewport.Y) * num12));
			this.Y5 = size.Height - num25;
			float num26 = this.IViewport.Height - 5f;
			int num27 = (int)((double)((num26 - this.IViewport.Y) * num12));
			this.YM5 = size.Height - num27;
			this.X10 = (int)((double)((10f - this.IViewport.X) * num10));
			float num28 = this.IViewport.Height + 10f;
			int num29 = (int)((double)((num28 - this.IViewport.Y) * num12));
			this.Y10 = size.Height - num29;
			float num30 = this.IViewport.Height - 10f;
			int num31 = (int)((double)((num30 - this.IViewport.Y) * num12));
			this.YM10 = size.Height - num31;
		}

		private void CenterViewport()
		{
			float num = -3.40282347E+38f;
			float num2 = 3.40282347E+38f;
			float num3 = -3.40282347E+38f;
			float num4 = 3.40282347E+38f;
			int num5 = 0;
			int numberOfKeys = this.GetNumberOfKeys();
			if (0 < numberOfKeys)
			{
				do
				{
					if (this.GetHorizontalKeyValue(num5) > num)
					{
						num = this.GetHorizontalKeyValue(num5);
					}
					if (this.GetHorizontalKeyValue(num5) < num2)
					{
						num2 = this.GetHorizontalKeyValue(num5);
					}
					if (this.GetVerticalKeyValue(num5) > num3)
					{
						num3 = this.GetVerticalKeyValue(num5);
					}
					if (this.GetVerticalKeyValue(num5) < num4)
					{
						num4 = this.GetVerticalKeyValue(num5);
					}
					num5++;
				}
				while (num5 < numberOfKeys);
				if (0f <= num3)
				{
					goto IL_89;
				}
			}
			num3 = 0f;
			IL_89:
			if (0f < num4)
			{
				num4 = 0f;
			}
			if (1 == this.Type && 1f > num3)
			{
				num3 = 1f;
			}
			if (num == num2)
			{
				this.IViewport.X = num2 - 0.1f;
				this.IViewport.Width = 1.2f;
			}
			else
			{
				float num6 = num - num2;
				this.IViewport.X = num2 - num6 * 0.1f;
				this.IViewport.Width = num6 * 1.2f;
			}
			if (num3 == num4)
			{
				if (0.1f > num3 && -0.1f < num3)
				{
					this.IViewport.Y = 0.11f;
					this.IViewport.Height = 0.22f;
				}
				else if (0f < num3)
				{
					this.IViewport.Y = num3 * 1.1f;
					this.IViewport.Height = num3 * 1.2f;
				}
				else
				{
					this.IViewport.Y = num3 * -0.1f;
					this.IViewport.Height = num3 * -1.2f;
				}
			}
			else
			{
				float num7 = num3 - num4;
				this.IViewport.Y = num7 * 0.1f + num3;
				this.IViewport.Height = num7 * 1.2f;
			}
		}

		private unsafe void RefreshUpDownControls()
		{
			if (0 == this.GetNumberOfSelectedIndices())
			{
				this.TimeUpDown.Value = 0.0;
				this.ValueUpDown.Value = 0.0;
				this.TimePanel.Enabled = false;
				this.ValuePanel.Enabled = false;
			}
			else if (1 == this.GetNumberOfSelectedIndices())
			{
				GArray<int>* selectedIndices = this.GetSelectedIndices();
				this.TimeUpDown.Value = (double)this.GetHorizontalKeyValue(*(*selectedIndices));
				GArray<int>* selectedIndices2 = this.GetSelectedIndices();
				this.ValueUpDown.Value = (double)this.GetVerticalKeyValue(*(*selectedIndices2));
				this.TimePanel.Enabled = true;
				this.ValuePanel.Enabled = true;
			}
			else
			{
				this.TimeUpDown.Value = 0.0;
				double num = 0.0;
				int num2 = 0;
				int numberOfSelectedIndices = this.GetNumberOfSelectedIndices();
				if (0 < numberOfSelectedIndices)
				{
					do
					{
						GArray<int>* selectedIndices3 = this.GetSelectedIndices();
						num = (double)this.GetVerticalKeyValue(*(num2 * 4 + *selectedIndices3)) + num;
						num2++;
					}
					while (num2 < numberOfSelectedIndices);
				}
				this.ValueUpDown.Value = num / (double)this.GetNumberOfSelectedIndices();
				this.TimePanel.Enabled = false;
				this.ValuePanel.Enabled = true;
			}
		}

		private void RefreshComponent()
		{
			Point point = default(Point);
			Size size = default(Size);
			Point point2 = default(Point);
			Point point3 = default(Point);
			int type = this.Type;
			if (type != 0)
			{
				if (type == 1)
				{
					point3 = this.ColorPanel.Location;
					point2 = this.EditPanel.Location;
					size = this.EditPanel.Size;
					size.Height = point3.Y - point2.Y - this.ColorPanelToEditPanel;
					this.EditPanel.Size = size;
					this.ColorPanel.Visible = true;
					this.ColorPicker.Visible = true;
					goto IL_108;
				}
				if (type != 2)
				{
					goto IL_108;
				}
			}
			point3 = this.ColorPanel.Location;
			point2 = this.EditPanel.Location;
			size = this.ColorPanel.Size;
			int num = size.Height - point2.Y;
			size.Height = point3.Y + num;
			this.EditPanel.Size = size;
			this.ColorPanel.Visible = false;
			this.ColorPicker.Visible = false;
			IL_108:
			this.RefreshUpDownControls();
			this.GenerateNodes();
			this.InvalidatePanels();
		}

		private unsafe void DrawMarkers(NDirect3D D3D)
		{
			GArray<int> gArray<int> = 0;
			*(ref gArray<int> + 4) = 0;
			*(ref gArray<int> + 8) = 0;
			try
			{
				Size arg_1B_0 = this.EditPanel.Size;
				int num = 0;
				GArray<GKeyNode>* nodes = this.Nodes;
				int num2 = *(nodes + 4);
				if (0 < num2)
				{
					do
					{
						if (num == this.HighlightNodeIndex)
						{
							Color controlDark = SystemColors.ControlDark;
							GArray<GKeyNode>* nodes2 = this.Nodes;
							int* arg_55_0 = ref *(int*)nodes2;
							int num3 = num * 8;
							GKeyNode* ptr = *arg_55_0 + num3;
							GArray<GKeyNode>* ptr2 = nodes2;
							D3D.FillRectangle(controlDark, *(num3 + *ptr2) - 2, *(ptr + 4) - 2, 5, 5);
							Color controlDarkDark = SystemColors.ControlDarkDark;
							GArray<GKeyNode>* nodes3 = this.Nodes;
							GArray<GKeyNode>* ptr3 = nodes3;
							GKeyNode* ptr4 = num3 + *ptr3;
							GArray<GKeyNode>* ptr5 = nodes3;
							D3D.DrawRectangle(controlDarkDark, *(*ptr5 + num3) - 3, *(ptr4 + 4) - 3, 6, 6);
						}
						else
						{
							GArray<int>* selectedIndices = this.GetSelectedIndices();
							<Module>.GArray<int>.Resize(ref gArray<int>, *(selectedIndices + 4));
							int num4 = 0;
							if (0 < *(ref gArray<int> + 4))
							{
								do
								{
									*(num4 * 4 + gArray<int>) = *(*selectedIndices + num4 * 4);
									num4++;
								}
								while (num4 < *(ref gArray<int> + 4));
							}
							int num5 = 0;
							if (0 < *(ref gArray<int> + 4))
							{
								do
								{
									if (num == *(num5 * 4 + gArray<int>))
									{
										Color activeCaption = SystemColors.ActiveCaption;
										GArray<GKeyNode>* nodes4 = this.Nodes;
										GArray<GKeyNode>* ptr6 = nodes4;
										GKeyNode* ptr7 = num * 8 + *ptr6;
										GArray<GKeyNode>* ptr8 = nodes4;
										D3D.FillRectangle(activeCaption, *(num * 8 + *ptr8) - 2, *(ptr7 + 4) - 2, 5, 5);
									}
									num5++;
								}
								while (num5 < *(ref gArray<int> + 4));
							}
							Color controlDarkDark2 = SystemColors.ControlDarkDark;
							GArray<GKeyNode>* nodes3 = this.Nodes;
							int* arg_15E_0 = ref *(int*)nodes3;
							int num3 = num * 8;
							GKeyNode* ptr9 = *arg_15E_0 + num3;
							GArray<GKeyNode>* ptr10 = nodes3;
							D3D.DrawRectangle(controlDarkDark2, *(*ptr10 + num3) - 3, *(ptr9 + 4) - 3, 6, 6);
						}
						num++;
						nodes = this.Nodes;
						num2 = *(nodes + 4);
					}
					while (num < num2);
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
				throw;
			}
			if (gArray<int> != null)
			{
				<Module>.free(gArray<int>);
			}
		}

		private unsafe void DrawMarkers(Graphics graphics)
		{
			GArray<int> gArray<int> = 0;
			*(ref gArray<int> + 4) = 0;
			*(ref gArray<int> + 8) = 0;
			try
			{
				int num = 0;
				GArray<GKeyNode>* nodes = this.Nodes;
				GArray<GKeyNode>* ptr = nodes;
				int num2 = *(ptr + 4);
				if (0 < num2)
				{
					do
					{
						if (num == this.HighlightNodeIndex)
						{
							GArray<GKeyNode>* ptr2 = nodes;
							int num3 = num * 8;
							GKeyNode* ptr3 = num3 + *ptr2;
							GKeyNode* ptr4 = *(int*)nodes + num3;
							graphics.FillRectangle(SystemBrushes.ControlDark, *ptr4 - 2, *(ptr3 + 4) - 2, 5, 5);
							GArray<GKeyNode>* nodes2 = this.Nodes;
							GKeyNode* ptr5 = *(int*)nodes2 + num3;
							GKeyNode* ptr6 = *(int*)nodes2 + num3;
							graphics.DrawRectangle(SystemPens.ControlDarkDark, *ptr6 - 3, *(ptr5 + 4) - 3, 6, 6);
						}
						else
						{
							GArray<int>* selectedIndices = this.GetSelectedIndices();
							<Module>.GArray<int>.Resize(ref gArray<int>, *(selectedIndices + 4));
							int num4 = 0;
							if (0 < *(ref gArray<int> + 4))
							{
								do
								{
									*(num4 * 4 + gArray<int>) = *(num4 * 4 + *selectedIndices);
									num4++;
								}
								while (num4 < *(ref gArray<int> + 4));
							}
							int num5 = 0;
							if (0 < *(ref gArray<int> + 4))
							{
								do
								{
									if (num == *(num5 * 4 + gArray<int>))
									{
										nodes = this.Nodes;
										GKeyNode* ptr7 = *(int*)nodes + num * 8;
										GKeyNode* ptr8 = *(int*)nodes + num * 8;
										graphics.FillRectangle(SystemBrushes.ActiveCaption, *ptr8 - 2, *(ptr7 + 4) - 2, 5, 5);
									}
									num5++;
								}
								while (num5 < *(ref gArray<int> + 4));
							}
							GArray<GKeyNode>* nodes2 = this.Nodes;
							GArray<GKeyNode>* ptr9 = nodes2;
							int num3 = num * 8;
							GKeyNode* ptr10 = num3 + *ptr9;
							GArray<GKeyNode>* ptr11 = nodes2;
							GKeyNode* ptr12 = num3 + *ptr11;
							graphics.DrawRectangle(SystemPens.ControlDarkDark, *ptr12 - 3, *(ptr10 + 4) - 3, 6, 6);
						}
						num++;
						nodes = this.Nodes;
						ptr = nodes;
						num2 = *(ptr + 4);
					}
					while (num < num2);
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GArray<int>.{dtor}), (void*)(&gArray<int>));
				throw;
			}
			if (gArray<int> != null)
			{
				<Module>.free(gArray<int>);
			}
		}

		private unsafe void ConvertNodeToScalarKey(GKeyNode* node, GPCurveScalarKey* key)
		{
			Size size = this.EditPanel.Size;
			float num = this.IViewport.Width * (float)(*node);
			float num2 = num / (float)size.Width;
			*key = this.IViewport.X + num2;
			float num3 = this.IViewport.Height * (float)(size.Height - *(node + 4));
			float num4 = num3 / (float)size.Height;
			float num5 = this.IViewport.Y + num4;
			float num6 = num5 - this.IViewport.Height;
			*(key + 4) = num6;
		}

		private unsafe void ConvertNodeToColorKey(GKeyNode* node, GPCurveColorKey* key)
		{
			GColor gColor;
			*(ref gColor + 8) = 0f;
			*(ref gColor + 4) = 0f;
			gColor = 0f;
			*(ref gColor + 12) = 1f;
			Size size = this.EditPanel.Size;
			float num = this.IViewport.Width * (float)(*node);
			float num2 = num / (float)size.Width;
			*key = this.IViewport.X + num2;
			ColorPicker colorPicker = this.ColorPicker;
			<Module>.GColor.FromHSV(ref gColor, colorPicker.Hue, colorPicker.Sat, colorPicker.Val);
			float num3 = this.IViewport.Height * (float)(size.Height - *(node + 4));
			float num4 = num3 / (float)size.Height;
			float num5 = this.IViewport.Y + num4;
			*(ref gColor + 12) = num5 - this.IViewport.Height;
			cpblk(key + 4, ref gColor, 16);
		}

		private unsafe void AddNode(GKeyNode* node)
		{
			GPCurveScalarKey gPCurveScalarKey = 0f;
			*(ref gPCurveScalarKey + 4) = 0f;
			GPCurveColorKey gPCurveColorKey = 0f;
			*(ref gPCurveColorKey + 12) = 0f;
			*(ref gPCurveColorKey + 8) = 0f;
			*(ref gPCurveColorKey + 4) = 0f;
			*(ref gPCurveColorKey + 16) = 1f;
			if (this.IsInLimits(node))
			{
				int type = this.Type;
				int num;
				if (type != 0)
				{
					if (type != 1)
					{
						if (type != 2)
						{
							return;
						}
						this.ConvertNodeToScalarKey(node, ref gPCurveScalarKey);
						num = <Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Insert(this.BezierScalarEditor, ref gPCurveScalarKey);
					}
					else
					{
						this.ConvertNodeToColorKey(node, ref gPCurveColorKey);
						num = <Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Insert(this.LinearColorEditor, ref gPCurveColorKey);
					}
				}
				else
				{
					this.ConvertNodeToScalarKey(node, ref gPCurveScalarKey);
					num = <Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Insert(this.LinearScalarEditor, ref gPCurveScalarKey);
				}
				if (-1 != num)
				{
					this.RefreshComponent();
					this.raise_NotifyUndoStep();
				}
			}
		}

		private void RemoveNodes(int index, [MarshalAs(UnmanagedType.U1)] bool removeselection)
		{
			int type = this.Type;
			bool flag;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type != 2)
					{
						return;
					}
					flag = (<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Remove(this.BezierScalarEditor, index, removeselection) != null);
				}
				else
				{
					flag = (<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Remove(this.LinearColorEditor, index, removeselection) != null);
				}
			}
			else
			{
				flag = (<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Remove(this.LinearScalarEditor, index, removeselection) != null);
			}
			if (flag)
			{
				this.HighlightNodeIndex = -1;
				this.RefreshComponent();
				this.raise_NotifyUndoStep();
			}
		}

		private void TimeUpDown_Validated(object sender, EventArgs e)
		{
			float time = (float)this.TimeUpDown.Value;
			bool flag = false;
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						flag = (<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SetTime(this.BezierScalarEditor, time) != null);
					}
				}
				else
				{
					flag = (<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.SetTime(this.LinearColorEditor, time) != null);
				}
			}
			else
			{
				flag = (<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SetTime(this.LinearScalarEditor, time) != null);
			}
			this.RefreshComponent();
			if (flag)
			{
				this.raise_NotifyUndoStep();
			}
		}

		private void ValueUpDown_Validated(object sender, EventArgs e)
		{
			float num = (float)this.ValueUpDown.Value;
			bool flag = false;
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						flag = (<Module>.GCurveScalarEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SetValue(this.BezierScalarEditor, num) != null);
					}
				}
				else
				{
					flag = (<Module>.GCurveLinearColorEditor.SetAlpha(this.LinearColorEditor, num) != null);
				}
			}
			else
			{
				flag = (<Module>.GCurveScalarEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SetValue(this.LinearScalarEditor, num) != null);
			}
			this.RefreshComponent();
			if (flag)
			{
				this.raise_NotifyUndoStep();
			}
		}

		private void NCurveEditor_SizeChanged(object sender, EventArgs e)
		{
			this.RefreshComponent();
		}

		private unsafe void EditPanel_KeyDown(object sender, KeyEventArgs e)
		{
			Point point = default(Point);
			switch (e.KeyCode)
			{
			case Keys.Space:
			case Keys.Insert:
			{
				Point position = Cursor.Position;
				point = this.EditPanel.PointToClient(position);
				GKeyNode x = point.X;
				*(ref x + 4) = point.Y;
				if (this.IsMouseOverControl(this.EditPanel))
				{
					this.AddNode(ref x);
				}
				break;
			}
			case Keys.Home:
				this.CenterViewport();
				this.RefreshComponent();
				break;
			case Keys.Delete:
				this.RemoveNodes(this.HighlightNodeIndex, true);
				break;
			}
		}

		private void NCurveEditor_MouseWheel(object sender, MouseEventArgs e)
		{
			int delta = e.Delta;
			bool flag = false;
			bool flag2 = false;
			if ((<Module>.GetKeyState(37) & 128) != 128 && (<Module>.GetKeyState(39) & 128) != 128 && (<Module>.GetKeyState(16) & 128) != 128)
			{
				if ((<Module>.GetKeyState(38) & 128) == 128 || (<Module>.GetKeyState(40) & 128) == 128 || (<Module>.GetKeyState(17) & 128) == 128)
				{
					flag2 = true;
				}
				else
				{
					flag = true;
					flag2 = true;
				}
			}
			else
			{
				flag = true;
			}
			float num = (float)Math.Pow(0.89999997615814209, (double)((float)delta * 0.008333334f));
			if (flag)
			{
				float width = this.IViewport.Width;
				float num2 = width * num;
				this.IViewport.Width = num2;
				this.IViewport.X = this.IViewport.X - (num2 - width) * 0.5f;
			}
			if (flag2)
			{
				float height = this.IViewport.Height;
				float num3 = height * num;
				this.IViewport.Height = num3;
				this.IViewport.Y = this.IViewport.Y + (num3 - height) * 0.5f;
			}
			this.RefreshComponent();
		}

		private unsafe void EditPanel_Paint(object sender, PaintEventArgs e)
		{
			Size size = this.EditPanel.Size;
			if (null != this.EditPanelD3D)
			{
				Color control = SystemColors.Control;
				this.EditPanelD3D.Clear(control);
				this.EditPanelD3D.BeginScene();
				int type = this.Type;
				int x;
				int x2;
				if (type != 0)
				{
					if (type == 1)
					{
						Color window = SystemColors.Window;
						this.EditPanelD3D.FillRectangle(window, this.EnvelopRectangle);
						if (-1 != this.GetLoopStart() && -1 != this.GetLoopEnd() && this.GetLoopStart() <= this.GetLoopEnd())
						{
							Color lightBlue = Color.LightBlue;
							GKeyNode* ptr = this.GetLoopEnd() * 8 + *(int*)this.Nodes;
							GKeyNode* ptr2 = this.GetLoopStart() * 8 + *(int*)this.Nodes;
							GKeyNode* ptr3 = this.GetLoopStart() * 8 + *(int*)this.Nodes;
							this.EditPanelD3D.FillRectangle(lightBlue, *ptr3, this.EnvelopRectangle.Top, *ptr - *ptr2 + 1, this.EnvelopRectangle.Height);
						}
						Color controlDarkDark = SystemColors.ControlDarkDark;
						this.EditPanelD3D.DrawLine(controlDarkDark, 0, this.Y0, this.EditPanel.Width, this.Y0);
						Color controlDarkDark2 = SystemColors.ControlDarkDark;
						this.EditPanelD3D.DrawLine(controlDarkDark2, 0, this.Y1, this.EditPanel.Width, this.Y1);
						Color controlDarkDark3 = SystemColors.ControlDarkDark;
						x = this.X0;
						this.EditPanelD3D.DrawLine(controlDarkDark3, x, 0, x, this.EditPanel.Height);
						Color controlDarkDark4 = SystemColors.ControlDarkDark;
						x2 = this.X1;
						this.EditPanelD3D.DrawLine(controlDarkDark4, x2, 0, x2, this.EditPanel.Height);
						Color controlDarkDark5 = SystemColors.ControlDarkDark;
						this.EditPanelD3D.DrawLine(controlDarkDark5, 0, this.EnvelopRectangle.Top, this.EditPanel.Width, this.EnvelopRectangle.Top);
						Color controlDarkDark6 = SystemColors.ControlDarkDark;
						this.EditPanelD3D.DrawLine(controlDarkDark6, 0, this.EnvelopRectangle.Bottom, this.EditPanel.Width, this.EnvelopRectangle.Bottom);
						Color controlDarkDark7 = SystemColors.ControlDarkDark;
						this.EditPanelD3D.DrawLine(controlDarkDark7, this.EnvelopRectangle.Left, 0, this.EnvelopRectangle.Left, this.EditPanel.Height);
						Color controlDarkDark8 = SystemColors.ControlDarkDark;
						this.EditPanelD3D.DrawLine(controlDarkDark8, this.EnvelopRectangle.Right, 0, this.EnvelopRectangle.Right, this.EditPanel.Height);
						Color controlDarkDark9 = SystemColors.ControlDarkDark;
						this.EditPanelD3D.TextOutA("0.0", 3, this.Y0 - 12, controlDarkDark9);
						Color controlDarkDark10 = SystemColors.ControlDarkDark;
						this.EditPanelD3D.TextOutA("1.0", 3, this.Y1 - 12, controlDarkDark10);
						Color controlDarkDark11 = SystemColors.ControlDarkDark;
						this.EditPanelD3D.TextOutA("0.0", this.X0 + 3, 3, controlDarkDark11);
						Color controlDarkDark12 = SystemColors.ControlDarkDark;
						this.EditPanelD3D.TextOutA("1.0", this.X1 + 3, 3, controlDarkDark12);
						Color controlDarkDark13 = SystemColors.ControlDarkDark;
						float bottom = this.EnvelopRectangleF.Bottom;
						this.EditPanelD3D.TextOutA(bottom.ToString(), 3, this.EnvelopRectangle.Top - 12, controlDarkDark13);
						Color controlDarkDark14 = SystemColors.ControlDarkDark;
						float top = this.EnvelopRectangleF.Top;
						this.EditPanelD3D.TextOutA(top.ToString(), 3, this.EnvelopRectangle.Bottom - 12, controlDarkDark14);
						Color controlDarkDark15 = SystemColors.ControlDarkDark;
						float left = this.EnvelopRectangleF.Left;
						this.EditPanelD3D.TextOutA(left.ToString(), this.EnvelopRectangle.Left + 3, 3, controlDarkDark15);
						Color controlDarkDark16 = SystemColors.ControlDarkDark;
						float right = this.EnvelopRectangleF.Right;
						this.EditPanelD3D.TextOutA(right.ToString(), this.EnvelopRectangle.Right + 3, 3, controlDarkDark16);
						float num = this.IViewport.Width / (float)size.Width;
						float num2 = this.IViewport.X;
						<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Restart(this.LinearColorEditor, num2);
						GCurveLinearColorEditor* expr_42A = this.LinearColorEditor;
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_42A, *(*(int*)expr_42A + 4));
						GCurveLinearColorEditor* linearColorEditor = this.LinearColorEditor;
						GCurveLinearColorEditor* expr_43E = linearColorEditor;
						float num3 = *(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_43E, *(*(int*)expr_43E + 20)) + 12);
						float num4 = (float)size.Height;
						float num5 = num4 / this.IViewport.Height;
						int num6 = 0;
						if (0 < size.Width)
						{
							do
							{
								float num7 = num2 + num;
								linearColorEditor = this.LinearColorEditor;
								float num8 = *(calli(GColor* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, num, *(*(int*)linearColorEditor + 8)) + 12);
								int num9 = (int)((double)((num3 - (this.IViewport.Y - this.IViewport.Height)) * num5));
								int y = size.Height - num9;
								int num10 = (int)((double)((num8 - (this.IViewport.Y - this.IViewport.Height)) * num5));
								int y2 = size.Height - num10;
								Color controlDarkDark17 = SystemColors.ControlDarkDark;
								int num11 = num6 + 1;
								this.EditPanelD3D.DrawLine(controlDarkDark17, num6, y, num11, y2);
								num2 = num7;
								num3 = num8;
								num6 = num11;
							}
							while (num6 < size.Width);
						}
						this.DrawMarkers(this.EditPanelD3D);
						goto IL_D6C;
					}
					if (type != 2)
					{
						goto IL_D6C;
					}
				}
				Color window2 = SystemColors.Window;
				this.EditPanelD3D.FillRectangle(window2, this.EnvelopRectangle);
				if (-1 != this.GetLoopStart() && -1 != this.GetLoopEnd() && this.GetLoopStart() <= this.GetLoopEnd())
				{
					Color lightBlue2 = Color.LightBlue;
					GKeyNode* ptr4 = this.GetLoopEnd() * 8 + *(int*)this.Nodes;
					GKeyNode* ptr5 = this.GetLoopStart() * 8 + *(int*)this.Nodes;
					GKeyNode* ptr6 = this.GetLoopStart() * 8 + *(int*)this.Nodes;
					this.EditPanelD3D.FillRectangle(lightBlue2, *ptr6, this.EnvelopRectangle.Top, *ptr4 - *ptr5 + 1, this.EnvelopRectangle.Height);
				}
				Color controlDarkDark18 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark18, 0, this.Y0, this.EditPanel.Width, this.Y0);
				Color controlDarkDark19 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark19, 0, this.Y1, this.EditPanel.Width, this.Y1);
				Color controlDarkDark20 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark20, 0, this.YM1, this.EditPanel.Width, this.YM1);
				Color controlDarkDark21 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark21, 0, this.Y5, this.EditPanel.Width, this.Y5);
				Color controlDarkDark22 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark22, 0, this.YM5, this.EditPanel.Width, this.YM5);
				Color controlDarkDark23 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark23, 0, this.Y10, this.EditPanel.Width, this.Y10);
				Color controlDarkDark24 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark24, 0, this.YM10, this.EditPanel.Width, this.YM10);
				Color controlDarkDark25 = SystemColors.ControlDarkDark;
				x = this.X0;
				this.EditPanelD3D.DrawLine(controlDarkDark25, x, 0, x, this.EditPanel.Height);
				Color controlDarkDark26 = SystemColors.ControlDarkDark;
				x2 = this.X1;
				this.EditPanelD3D.DrawLine(controlDarkDark26, x2, 0, x2, this.EditPanel.Height);
				Color controlDarkDark27 = SystemColors.ControlDarkDark;
				int x3 = this.X5;
				this.EditPanelD3D.DrawLine(controlDarkDark27, x3, 0, x3, this.EditPanel.Height);
				Color controlDarkDark28 = SystemColors.ControlDarkDark;
				int x4 = this.X10;
				this.EditPanelD3D.DrawLine(controlDarkDark28, x4, 0, x4, this.EditPanel.Height);
				Color controlDarkDark29 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark29, 0, this.EnvelopRectangle.Top, this.EditPanel.Width, this.EnvelopRectangle.Top);
				Color controlDarkDark30 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark30, 0, this.EnvelopRectangle.Bottom, this.EditPanel.Width, this.EnvelopRectangle.Bottom);
				Color controlDarkDark31 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark31, this.EnvelopRectangle.Left, 0, this.EnvelopRectangle.Left, this.EditPanel.Height);
				Color controlDarkDark32 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.DrawLine(controlDarkDark32, this.EnvelopRectangle.Right, 0, this.EnvelopRectangle.Right, this.EditPanel.Height);
				Color controlDarkDark33 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("0.0", 3, this.Y0 - 12, controlDarkDark33);
				Color controlDarkDark34 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("1.0", 3, this.Y1 - 12, controlDarkDark34);
				Color controlDarkDark35 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("-1.0", 3, this.YM1 - 12, controlDarkDark35);
				Color controlDarkDark36 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("5.0", 3, this.Y5 - 12, controlDarkDark36);
				Color controlDarkDark37 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("-5.0", 3, this.YM5 - 12, controlDarkDark37);
				Color controlDarkDark38 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("10.0", 3, this.Y10 - 12, controlDarkDark38);
				Color controlDarkDark39 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("-10.0", 3, this.YM10 - 12, controlDarkDark39);
				Color controlDarkDark40 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("0.0", this.X0 + 3, 3, controlDarkDark40);
				Color controlDarkDark41 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("1.0", this.X1 + 3, 3, controlDarkDark41);
				Color controlDarkDark42 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("5.0", this.X5 + 3, 3, controlDarkDark42);
				Color controlDarkDark43 = SystemColors.ControlDarkDark;
				this.EditPanelD3D.TextOutA("10.0", this.X10 + 3, 3, controlDarkDark43);
				Color controlDarkDark44 = SystemColors.ControlDarkDark;
				float bottom2 = this.EnvelopRectangleF.Bottom;
				this.EditPanelD3D.TextOutA(bottom2.ToString(), 3, this.EnvelopRectangle.Top - 12, controlDarkDark44);
				Color controlDarkDark45 = SystemColors.ControlDarkDark;
				float top2 = this.EnvelopRectangleF.Top;
				this.EditPanelD3D.TextOutA(top2.ToString(), 3, this.EnvelopRectangle.Bottom - 12, controlDarkDark45);
				Color controlDarkDark46 = SystemColors.ControlDarkDark;
				float left2 = this.EnvelopRectangleF.Left;
				this.EditPanelD3D.TextOutA(left2.ToString(), this.EnvelopRectangle.Left + 3, 3, controlDarkDark46);
				Color controlDarkDark47 = SystemColors.ControlDarkDark;
				float right2 = this.EnvelopRectangleF.Right;
				this.EditPanelD3D.TextOutA(right2.ToString(), this.EnvelopRectangle.Right + 3, 3, controlDarkDark47);
				if (0 == this.Type)
				{
					float num = this.IViewport.Width / (float)size.Width;
					float num2 = this.IViewport.X;
					<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Restart(this.LinearScalarEditor, num2);
					GCurveLinearScalarEditor* expr_B3B = this.LinearScalarEditor;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_B3B, *(*(int*)expr_B3B + 4));
					GCurveLinearScalarEditor* linearScalarEditor = this.LinearScalarEditor;
					GCurveLinearScalarEditor* expr_B4F = linearScalarEditor;
					float num3 = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_B4F, *(*(int*)expr_B4F + 24));
					float num12 = (float)size.Height;
					float num5 = num12 / this.IViewport.Height;
					int num6 = 0;
					if (0 < size.Width)
					{
						do
						{
							float num7 = num2 + num;
							linearScalarEditor = this.LinearScalarEditor;
							float num8 = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearScalarEditor, num, *(*(int*)linearScalarEditor + 8));
							int num13 = (int)((double)((num3 - (this.IViewport.Y - this.IViewport.Height)) * num5));
							int y3 = size.Height - num13;
							int num14 = (int)((double)((num8 - (this.IViewport.Y - this.IViewport.Height)) * num5));
							int y4 = size.Height - num14;
							Color controlDarkDark48 = SystemColors.ControlDarkDark;
							int num15 = num6 + 1;
							this.EditPanelD3D.DrawLine(controlDarkDark48, num6, y3, num15, y4);
							num2 = num7;
							num3 = num8;
							num6 = num15;
						}
						while (num6 < size.Width);
					}
				}
				else
				{
					float num = this.IViewport.Width / (float)size.Width;
					float num2 = this.IViewport.X;
					<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Restart(this.BezierScalarEditor, num2);
					GCurveBezierScalarEditor* bezierScalarEditor = this.BezierScalarEditor;
					GCurveBezierScalarEditor* expr_C6C = bezierScalarEditor;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_C6C, *(*(int*)expr_C6C + 4));
					bezierScalarEditor = this.BezierScalarEditor;
					GCurveBezierScalarEditor* expr_C80 = bezierScalarEditor;
					float num3 = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_C80, *(*(int*)expr_C80 + 24));
					float num16 = (float)size.Height;
					float num5 = num16 / this.IViewport.Height;
					int num6 = 0;
					if (0 < size.Width)
					{
						do
						{
							float num7 = num2 + num;
							bezierScalarEditor = this.BezierScalarEditor;
							float num8 = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), bezierScalarEditor, num, *(*(int*)bezierScalarEditor + 8));
							int num17 = (int)((double)((num3 - (this.IViewport.Y - this.IViewport.Height)) * num5));
							int y5 = size.Height - num17;
							int num18 = (int)((double)((num8 - (this.IViewport.Y - this.IViewport.Height)) * num5));
							int y6 = size.Height - num18;
							Color controlDarkDark49 = SystemColors.ControlDarkDark;
							int num19 = num6 + 1;
							this.EditPanelD3D.DrawLine(controlDarkDark49, num6, y5, num19, y6);
							num2 = num7;
							num3 = num8;
							num6 = num19;
						}
						while (num6 < size.Width);
					}
				}
				this.DrawMarkers(this.EditPanelD3D);
				IL_D6C:
				if (14 == this.DragMode)
				{
					Color controlDarkDark50 = SystemColors.ControlDarkDark;
					this.EditPanelD3D.DrawRectangle(controlDarkDark50, this.SelectionRectangle);
				}
				this.EditPanelD3D.EndScene();
				this.EditPanelD3D.Present();
			}
		}

		private unsafe void ColorPanel_Paint(object sender, PaintEventArgs e)
		{
			Size size = this.ColorPanel.Size;
			NDirect3D colorPanelD3D = this.ColorPanelD3D;
			if (null != colorPanelD3D)
			{
				colorPanelD3D.BeginScene();
				if (this.Type == 1)
				{
					float num = this.IViewport.Width / (float)size.Width;
					float x = this.IViewport.X;
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Restart(this.LinearColorEditor, x);
					GCurveLinearColorEditor* expr_63 = this.LinearColorEditor;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_63, *(*(int*)expr_63 + 4));
					GCurveLinearColorEditor* linearColorEditor = this.LinearColorEditor;
					GCurveLinearColorEditor* expr_75 = linearColorEditor;
					int num2 = calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_75, *(*(int*)expr_75 + 20));
					GColor gColor;
					cpblk(ref gColor, num2, 16);
					int num3 = 0;
					if (0 < size.Width)
					{
						do
						{
							this.ColorPanelD3D.DrawLine(<Module>.GColor..K(ref gColor), num3, 0, num3, 32);
							linearColorEditor = this.LinearColorEditor;
							int num4 = calli(GColor* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, num, *(*(int*)linearColorEditor + 8));
							cpblk(ref gColor, num4, 16);
							num3++;
						}
						while (num3 < size.Width);
					}
				}
				this.ColorPanelD3D.EndScene();
				this.ColorPanelD3D.Present();
			}
		}

		private void TypeSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIndex = this.TypeSelect.SelectedIndex;
			if (selectedIndex != 0)
			{
				if (selectedIndex != 1)
				{
					if (selectedIndex == 2)
					{
						this.Type = 2;
					}
				}
				else
				{
					this.Type = 1;
				}
			}
			else
			{
				this.Type = 0;
			}
			this.RefreshComponent();
		}

		private unsafe void EditPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (!this.Focused)
			{
				this.EditPanel.Focus();
			}
			GPCurveScalarKey gPCurveScalarKey = 0f;
			*(ref gPCurveScalarKey + 4) = 0f;
			GPCurveColorKey gPCurveColorKey = 0f;
			*(ref gPCurveColorKey + 12) = 0f;
			*(ref gPCurveColorKey + 8) = 0f;
			*(ref gPCurveColorKey + 4) = 0f;
			*(ref gPCurveColorKey + 16) = 1f;
			Point p = default(Point);
			Point position = default(Point);
			GKeyNode x = e.X;
			*(ref x + 4) = e.Y;
			Size size = default(Size);
			int type = this.Type;
			if (type != 0)
			{
				if (type == 1)
				{
					this.ConvertNodeToColorKey(ref x, ref gPCurveColorKey);
					goto IL_B2;
				}
				if (type != 2)
				{
					goto IL_B2;
				}
			}
			this.ConvertNodeToScalarKey(ref x, ref gPCurveScalarKey);
			IL_B2:
			if (base.ContainsFocus)
			{
				this.EditPanel.Focus();
			}
			switch (this.DragMode)
			{
			case 0:
			{
				int num = -1;
				int num2 = 0;
				if (0 < *(int*)(this.Nodes + 4 / sizeof(GArray<GKeyNode>)))
				{
					do
					{
						GKeyNode* ptr = *(int*)this.Nodes + num2 * 8;
						if (4 > *ptr - e.X)
						{
							GKeyNode* ptr2 = *(int*)this.Nodes + num2 * 8;
							if (-4 < *ptr2 - e.X)
							{
								GKeyNode* ptr3 = *(int*)this.Nodes + num2 * 8;
								if (4 > *(ptr3 + 4) - e.Y)
								{
									GKeyNode* ptr4 = *(int*)this.Nodes + num2 * 8;
									if (-4 < *(ptr4 + 4) - e.Y)
									{
										goto IL_1BA;
									}
								}
							}
						}
						num2++;
					}
					while (num2 < *(int*)(this.Nodes + 4 / sizeof(GArray<GKeyNode>)));
					goto IL_1BD;
					IL_1BA:
					num = num2;
				}
				IL_1BD:
				if (num != this.HighlightNodeIndex)
				{
					this.HighlightNodeIndex = num;
					this.InvalidatePanels();
				}
				break;
			}
			case 9:
			{
				int type2 = this.Type;
				if (type2 != 0)
				{
					if (type2 != 1)
					{
						if (type2 == 2)
						{
							<Module>.?Move@?$GCurveScalarEditor@VGCurveBezierScalar@@VGPCurveBezierScalar@@VGPCurveScalarKey@@@@$$FQAEXAAVGPCurveScalarKey@@W4GKeyMoveMode@@@Z(this.BezierScalarEditor, ref gPCurveScalarKey, this.KeyMoveMode);
						}
					}
					else
					{
						<Module>.?Move@GCurveLinearColorEditor@@$$FQAEXAAVGPCurveColorKey@@W4GKeyMoveMode@@@Z(this.LinearColorEditor, ref gPCurveColorKey, this.KeyMoveMode);
					}
				}
				else
				{
					<Module>.?Move@?$GCurveScalarEditor@VGCurveLinearScalar@@VGPCurveLinearScalar@@VGPCurveScalarKey@@@@$$FQAEXAAVGPCurveScalarKey@@W4GKeyMoveMode@@@Z(this.LinearScalarEditor, ref gPCurveScalarKey, this.KeyMoveMode);
				}
				this.HighlightNodeIndex = -1;
				this.GenerateNodes();
				this.RefreshUpDownControls();
				position = Cursor.Position;
				int movedIndex = this.GetMovedIndex();
				p.X = *(movedIndex * 8 + *(int*)this.Nodes);
				int movedIndex2 = this.GetMovedIndex();
				p.Y = *(movedIndex2 * 8 + *(int*)this.Nodes + 4);
				p = this.EditPanel.PointToScreen(p);
				if (5 < position.X - p.X || -5 > position.X - p.X)
				{
					position.X = p.X;
					Cursor.Position = position;
				}
				if (5 < position.Y - p.Y || -5 > position.Y - p.Y)
				{
					position.Y = p.Y;
					Cursor.Position = position;
				}
				this.InvalidatePanels();
				break;
			}
			case 14:
				if (e.X < this.BaseMousePoint.X)
				{
					this.SelectionRectangle.X = e.X;
					this.SelectionRectangle.Width = this.BaseMousePoint.X - e.X;
				}
				else
				{
					this.SelectionRectangle.X = this.BaseMousePoint.X;
					this.SelectionRectangle.Width = e.X - this.BaseMousePoint.X;
				}
				if (e.Y < this.BaseMousePoint.Y)
				{
					this.SelectionRectangle.Y = e.Y;
					this.SelectionRectangle.Height = this.BaseMousePoint.Y - e.Y;
				}
				else
				{
					this.SelectionRectangle.Y = this.BaseMousePoint.Y;
					this.SelectionRectangle.Height = e.Y - this.BaseMousePoint.Y;
				}
				this.InvalidatePanels();
				break;
			case 19:
			{
				position = Cursor.Position;
				float num3 = (float)(position.X - this.BaseMousePoint.X);
				float num4 = (float)(position.Y - this.BaseMousePoint.Y);
				if (num3 != 0f || num4 != 0f)
				{
					Cursor.Position = this.BaseMousePoint;
				}
				size = this.EditPanel.Size;
				num3 = this.IViewport.Width / (float)size.Width * num3;
				num4 = this.IViewport.Height / (float)size.Height * num4;
				this.IViewport.X = this.IViewport.X - num3;
				this.IViewport.Y = this.IViewport.Y + num4;
				this.RefreshComponent();
				break;
			}
			}
			Point position2 = Cursor.Position;
			this.PrevMousePoint = position2;
			int type3 = this.Type;
			if (type3 != 0)
			{
				if (type3 != 1)
				{
					if (type3 == 2)
					{
						GCurveBezierScalarEditor* bezierScalarEditor = this.BezierScalarEditor;
						float num5 = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), bezierScalarEditor, gPCurveScalarKey, *(*(int*)bezierScalarEditor + 16));
						float num6 = *(ref gPCurveScalarKey + 4);
						float num7 = gPCurveScalarKey;
						this.StatusBar.Text = "Coordinates: (" + num7.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + ", " + num6.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + "), Value: " + num5.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@)));
					}
				}
				else
				{
					GCurveLinearColorEditor* linearColorEditor = this.LinearColorEditor;
					float num8 = *(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, gPCurveColorKey, *(*(int*)linearColorEditor + 12)) + 8);
					GCurveLinearColorEditor* linearColorEditor2 = this.LinearColorEditor;
					float num9 = *(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor2, gPCurveColorKey, *(*(int*)linearColorEditor2 + 12)) + 4);
					GCurveLinearColorEditor* linearColorEditor3 = this.LinearColorEditor;
					float num10 = *calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor3, gPCurveColorKey, *(*(int*)linearColorEditor3 + 12));
					GCurveLinearColorEditor* linearColorEditor4 = this.LinearColorEditor;
					float num11 = *(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor4, gPCurveColorKey, *(*(int*)linearColorEditor4 + 12)) + 12);
					float num12 = *(ref gPCurveColorKey + 16);
					float num13 = gPCurveColorKey;
					this.StatusBar.Text = "Coordinates: (" + num13.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + ", " + num12.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + "), Alpha: " + num11.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + ", Red: " + num10.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + ", Green: " + num9.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + ", Blue: " + num8.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@)));
				}
			}
			else
			{
				GCurveLinearScalarEditor* linearScalarEditor = this.LinearScalarEditor;
				float num14 = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearScalarEditor, gPCurveScalarKey, *(*(int*)linearScalarEditor + 16));
				float num15 = *(ref gPCurveScalarKey + 4);
				float num16 = gPCurveScalarKey;
				this.StatusBar.Text = "Coordinates: (" + num16.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + ", " + num15.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + "), Value: " + num14.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@)));
			}
		}

		private unsafe void ColorPanel_MouseMove(object sender, MouseEventArgs e)
		{
			GPCurveScalarKey gPCurveScalarKey = 0f;
			*(ref gPCurveScalarKey + 4) = 0f;
			GKeyNode x = e.X;
			*(ref x + 4) = e.Y;
			this.ConvertNodeToScalarKey(ref x, ref gPCurveScalarKey);
			GCurveLinearColorEditor* linearColorEditor = this.LinearColorEditor;
			float num = *(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, gPCurveScalarKey, *(*(int*)linearColorEditor + 12)) + 8);
			GCurveLinearColorEditor* linearColorEditor2 = this.LinearColorEditor;
			float num2 = *(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor2, gPCurveScalarKey, *(*(int*)linearColorEditor2 + 12)) + 4);
			GCurveLinearColorEditor* linearColorEditor3 = this.LinearColorEditor;
			float num3 = *calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor3, gPCurveScalarKey, *(*(int*)linearColorEditor3 + 12));
			float num4 = gPCurveScalarKey;
			this.StatusBar.Text = "Time: " + num4.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + ", Red: " + num3.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + ", Green: " + num2.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@))) + ", Blue: " + num.ToString(new string((sbyte*)(&<Module>.??_C@_02IBAANIJI@G3?$AA@)));
		}

		private unsafe void ColorPicker_ValueChanged()
		{
			GColor gColor;
			*(ref gColor + 8) = 0f;
			*(ref gColor + 4) = 0f;
			gColor = 0f;
			*(ref gColor + 12) = 1f;
			ColorPicker colorPicker = this.ColorPicker;
			<Module>.GColor.FromHSV(ref gColor, colorPicker.Hue, colorPicker.Sat, colorPicker.Val);
			<Module>.GCurveLinearColorEditor.SetColor(this.LinearColorEditor, ref gColor);
			this.InvalidColorPanel = true;
			this.raise_NotifyUndoStep();
		}

		private void EditPanel_MouseLeave(object sender, EventArgs e)
		{
			this.HighlightNodeIndex = -1;
			this.StatusBar.Text = null;
		}

		private void EditPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (MouseButtons.Left == e.Button)
			{
				if (-1 != this.HighlightNodeIndex)
				{
					if (Control.ModifierKeys == Keys.ControlKey)
					{
						this.InvertSelection(this.HighlightNodeIndex);
					}
					else if (Control.ModifierKeys == Keys.ShiftKey)
					{
						this.SelectToIndex(this.HighlightNodeIndex);
					}
					else
					{
						if ((<Module>.GetKeyState(37) & 128) != 128 && (<Module>.GetKeyState(39) & 128) != 128)
						{
							if ((<Module>.GetKeyState(38) & 128) != 128 && (<Module>.GetKeyState(40) & 128) != 128)
							{
								this.KeyMoveMode = 0;
							}
							else
							{
								this.KeyMoveMode = 1;
							}
						}
						else
						{
							this.KeyMoveMode = 2;
						}
						Point position = Cursor.Position;
						this.BaseMousePoint = position;
						this.BeginMove(this.HighlightNodeIndex);
						this.HideCursor();
						this.DragMode = 9;
					}
					this.RefreshComponent();
				}
				else
				{
					Point position2 = Cursor.Position;
					this.BaseMousePoint = position2;
					Point baseMousePoint = this.EditPanel.PointToClient(this.BaseMousePoint);
					this.BaseMousePoint = baseMousePoint;
					this.DragMode = 14;
				}
			}
			else if (MouseButtons.Right == e.Button)
			{
				int dragMode = this.DragMode;
				if (9 == dragMode)
				{
					Cursor.Position = this.BaseMousePoint;
					this.DragMode = 0;
					this.CancelMove();
					this.ShowCursor();
					this.GenerateNodes();
					this.InvalidatePanels();
					this.ContextMenuBlock = true;
				}
				else if (14 == dragMode)
				{
					this.DragMode = 0;
					this.InvalidatePanels();
					this.ContextMenuBlock = true;
				}
			}
			else if (MouseButtons.Middle == e.Button)
			{
				Point position3 = Cursor.Position;
				this.BaseMousePoint = position3;
				this.HideCursor();
				this.DragMode = 19;
			}
		}

		private unsafe void EditPanel_MouseUp(object sender, MouseEventArgs e)
		{
			if (MouseButtons.Left == e.Button)
			{
				int dragMode = this.DragMode;
				if (9 == dragMode)
				{
					this.DragMode = 0;
					Point point = default(Point);
					int movedIndex = this.GetMovedIndex();
					point.X = *(movedIndex * 8 + *(int*)this.Nodes);
					int movedIndex2 = this.GetMovedIndex();
					point.Y = *(movedIndex2 * 8 + *(int*)this.Nodes + 4);
					point = this.EditPanel.PointToScreen(point);
					Cursor.Position = point;
					this.EndMove();
					this.ShowCursor();
				}
				else if (14 == dragMode)
				{
					if (Control.ModifierKeys != Keys.ShiftKey)
					{
						this.ClearSelection();
						int num = 0;
						if (0 < *(int*)(this.Nodes + 4 / sizeof(GArray<GKeyNode>)))
						{
							do
							{
								if (*(*(int*)this.Nodes + num * 8) > this.SelectionRectangle.Left && *(*(int*)this.Nodes + num * 8) < this.SelectionRectangle.Right && *(*(int*)this.Nodes + num * 8 + 4) > this.SelectionRectangle.Top && *(*(int*)this.Nodes + num * 8 + 4) < this.SelectionRectangle.Bottom)
								{
									this.InvertSelection(num);
								}
								num++;
							}
							while (num < *(int*)(this.Nodes + 4 / sizeof(GArray<GKeyNode>)));
						}
					}
					else
					{
						int num2 = 0;
						if (0 < *(int*)(this.Nodes + 4 / sizeof(GArray<GKeyNode>)))
						{
							do
							{
								if (*(*(int*)this.Nodes + num2 * 8) > this.SelectionRectangle.Left && *(*(int*)this.Nodes + num2 * 8) < this.SelectionRectangle.Right && *(*(int*)this.Nodes + num2 * 8 + 4) > this.SelectionRectangle.Top && *(*(int*)this.Nodes + num2 * 8 + 4) < this.SelectionRectangle.Bottom)
								{
									this.AddIndexToSelection(num2);
								}
								num2++;
							}
							while (num2 < *(int*)(this.Nodes + 4 / sizeof(GArray<GKeyNode>)));
						}
					}
					this.DragMode = 0;
					this.RefreshComponent();
				}
			}
			else if (MouseButtons.Middle == e.Button && 19 == this.DragMode)
			{
				Cursor.Position = this.BaseMousePoint;
				this.ShowCursor();
				this.DragMode = 0;
			}
		}

		private unsafe void ColorPanel_MouseDown(object sender, MouseEventArgs e)
		{
			GPCurveScalarKey gPCurveScalarKey = 0f;
			*(ref gPCurveScalarKey + 4) = 0f;
			GKeyNode x = e.X;
			*(ref x + 4) = e.Y;
			this.ConvertNodeToScalarKey(ref x, ref gPCurveScalarKey);
			GCurveLinearColorEditor* linearColorEditor = this.LinearColorEditor;
			int hue;
			int sat;
			int val;
			<Module>.GColor.ToHSV(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, gPCurveScalarKey, *(*(int*)linearColorEditor + 12)), ref hue, ref sat, ref val);
			this.ColorPicker.Hue = hue;
			this.ColorPicker.Sat = sat;
			this.ColorPicker.Val = val;
		}

		private void Exit_Click(object sender, EventArgs e)
		{
		}

		private void All_Click(object sender, EventArgs e)
		{
			this.ClearSelection();
			int num = this.GetNumberOfKeys() - 1;
			if (num >= 0)
			{
				do
				{
					this.AddIndexToSelection(num);
					num--;
				}
				while (num >= 0);
			}
			this.RefreshComponent();
		}

		private void None_Click(object sender, EventArgs e)
		{
			this.ClearSelection();
			this.RefreshComponent();
		}

		private void Undo_Click(object sender, EventArgs e)
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Undo(this.BezierScalarEditor);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Undo(this.LinearColorEditor);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Undo(this.LinearScalarEditor);
			}
			this.RefreshComponent();
		}

		private void Redo_Click(object sender, EventArgs e)
		{
			int type = this.Type;
			if (type != 0)
			{
				if (type != 1)
				{
					if (type == 2)
					{
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Redo(this.BezierScalarEditor);
					}
				}
				else
				{
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Redo(this.LinearColorEditor);
				}
			}
			else
			{
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Redo(this.LinearScalarEditor);
			}
			this.RefreshComponent();
		}

		private unsafe void EditPanelContextMenu_Popup(object sender, EventArgs e)
		{
			Point position = Cursor.Position;
			Point contextMenuPosition = this.EditPanel.PointToClient(position);
			this.ContextMenuPosition = contextMenuPosition;
			GKeyNode x = this.ContextMenuPosition.X;
			*(ref x + 4) = this.ContextMenuPosition.Y;
			this.EditPanelContextMenu.MenuItems.Clear();
			if (!this.ContextMenuBlock)
			{
				int highlightNodeIndex = this.HighlightNodeIndex;
				this.ContextMenuNodeIndex = highlightNodeIndex;
				if (-1 != highlightNodeIndex)
				{
					if (1 == this.Type)
					{
						this.EditPanelContextMenu.MenuItems.Add(this.PeekColor);
					}
					if (this.HighlightNodeIndex != 0)
					{
						this.EditPanelContextMenu.MenuItems.Add(this.RemoveKey);
					}
					if (this.GetLoopStart() == this.HighlightNodeIndex)
					{
						this.EditPanelContextMenu.MenuItems.Add(this.ClearLoopStart);
					}
					else
					{
						this.EditPanelContextMenu.MenuItems.Add(this.SetAsLoopStart);
					}
					if (this.GetLoopEnd() == this.HighlightNodeIndex)
					{
						this.EditPanelContextMenu.MenuItems.Add(this.ClearLoopEnd);
					}
					else
					{
						this.EditPanelContextMenu.MenuItems.Add(this.SetAsLoopEnd);
					}
				}
				else if (this.IsInLimits(ref x))
				{
					this.EditPanelContextMenu.MenuItems.Add(this.AddKey);
				}
			}
			this.ContextMenuBlock = false;
		}

		private unsafe void AddKey_Click(object sender, EventArgs e)
		{
			GKeyNode x = this.ContextMenuPosition.X;
			*(ref x + 4) = this.ContextMenuPosition.Y;
			this.AddNode(ref x);
		}

		private unsafe void PeekColor_Click(object sender, EventArgs e)
		{
			int hue;
			int sat;
			int val;
			<Module>.GColor.ToHSV(this.ContextMenuNodeIndex * 20 + *(*(int*)(this.LinearColorEditor + 32 / sizeof(GCurveLinearColorEditor)) + 12) + 4, ref hue, ref sat, ref val);
			this.ColorPicker.Hue = hue;
			this.ColorPicker.Sat = sat;
			this.ColorPicker.Val = val;
		}

		private void RemoveKey_Click(object sender, EventArgs e)
		{
			this.RemoveNodes(this.ContextMenuNodeIndex, false);
		}

		private void SetAsLoopStart_Click(object sender, EventArgs e)
		{
			if (-1 != this.GetLoopEnd() && this.GetVerticalKeyValue(this.GetLoopEnd()) != this.GetVerticalKeyValue(this.ContextMenuNodeIndex))
			{
				DialogResult dialogResult = new NCopyKeyDialog("Copy loop end value to this key", "Copy value of this key to loop end").ShowDialog();
				if (DialogResult.Yes == dialogResult)
				{
					this.SetLoopStart(this.ContextMenuNodeIndex, true);
				}
				else if (DialogResult.No == dialogResult)
				{
					this.SetLoopStart(this.ContextMenuNodeIndex, false);
				}
				this.GenerateNodes();
			}
			else
			{
				this.SetLoopStart(this.ContextMenuNodeIndex, false);
			}
			this.InvalidatePanels();
		}

		private void SetAsLoopEnd_Click(object sender, EventArgs e)
		{
			if (-1 != this.GetLoopStart() && this.GetVerticalKeyValue(this.GetLoopStart()) != this.GetVerticalKeyValue(this.ContextMenuNodeIndex))
			{
				DialogResult dialogResult = new NCopyKeyDialog("Copy loop start value to this key", "Copy value of this key to loop start").ShowDialog();
				if (DialogResult.Yes == dialogResult)
				{
					this.SetLoopEnd(this.ContextMenuNodeIndex, true);
				}
				else if (DialogResult.No == dialogResult)
				{
					this.SetLoopEnd(this.ContextMenuNodeIndex, false);
				}
				this.GenerateNodes();
			}
			else
			{
				this.SetLoopEnd(this.ContextMenuNodeIndex, false);
			}
			this.InvalidatePanels();
		}

		private void ClearLoopStart_Click(object sender, EventArgs e)
		{
			this.SetLoopStart(-1, false);
		}

		private void ClearLoopEnd_Click(object sender, EventArgs e)
		{
			this.SetLoopEnd(-1, false);
		}

		private void EditPanel_Resize(object sender, EventArgs e)
		{
			Size clientSize = this.EditPanel.ClientSize;
			if (null != this.EditPanelD3D && 4 <= clientSize.Width && 4 <= clientSize.Height)
			{
				this.EditPanelD3D.Resize(clientSize.Width, clientSize.Height);
			}
		}

		private void ColorPanel_Resize(object sender, EventArgs e)
		{
			Size clientSize = this.ColorPanel.ClientSize;
			if (null != this.ColorPanelD3D && 4 <= clientSize.Width && 4 <= clientSize.Height)
			{
				this.ColorPanelD3D.Resize(clientSize.Width, clientSize.Height);
			}
		}

		private void NCurveEditor_Closed(object sender, EventArgs e)
		{
			this.DisposeD3DX();
		}

		private void NCurveEditor_Idle(object sender, EventArgs e)
		{
			if (1 == this.Type && this.InvalidColorPanel)
			{
				this.ColorPanel.Invalidate();
				this.InvalidColorPanel = false;
			}
		}

		protected void raise_NotifyUndoStep()
		{
			NCurveEditor.CurveChangedHandler notifyUndoStep = this.NotifyUndoStep;
			if (notifyUndoStep != null)
			{
				notifyUndoStep();
			}
		}
	}
}
