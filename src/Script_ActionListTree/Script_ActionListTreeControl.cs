using Script_ActionListTree_Node;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;

namespace Script_ActionListTree
{
	public class Script_ActionListTreeControl : UserControl
	{
		public enum eEditingType
		{
			EDITING_MAX = 2,
			EDITING_ListSelection = 1,
			EDITING_Number = 0
		}

		private ActionListTreeControl_Node mRootNode;

		private ActionListTreeControl_Node mFirstDisplayNode;

		private ActionListTreeControl_Node mSelectedNode;

		private ActionListTreeControl_Node mSelectedNode_End;

		private ActionListTreeControl_Node mMouseTargetNode;

		private ActionListTreeControl_Node_TextElement mMouseTargetTextElement;

		private int mRowHeight;

		private int mDepthTab;

		private int mFrameSize;

		private int mSpaceWidth;

		private int mMaxRows;

		private int mSelectedRow;

		private int mSelectedBeginExtended;

		private int mSelectedEndExtended;

		private bool MouseLeftHeld;

		private System.Timers.Timer ScrollTimer;

		private Script_ActionListTreeControl.eEditingType mEditingType;

		private string mEditedText;

		private string[] mEditingStringList;

		private int mEditingList_X;

		private int mEditingList_Y;

		private int mEditingList_Y_Up;

		private int mEditingList_Width;

		private int mEditingList_MaxDisplayed;

		private int mEditingList_FirstDisplayed;

		private int mEditingList_Selected;

		private Container components;

		public event EventHandler ListSelectingFinished
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.ListSelectingFinished = Delegate.Combine(this.ListSelectingFinished, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.ListSelectingFinished = Delegate.Remove(this.ListSelectingFinished, value);
			}
		}

		public event EventHandler TextEditingFinished
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.TextEditingFinished = Delegate.Combine(this.TextEditingFinished, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.TextEditingFinished = Delegate.Remove(this.TextEditingFinished, value);
			}
		}

		public event EventHandler TextEditingRequest
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.TextEditingRequest = Delegate.Combine(this.TextEditingRequest, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.TextEditingRequest = Delegate.Remove(this.TextEditingRequest, value);
			}
		}

		public event EventHandler MouseTargetOnDrop
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.MouseTargetOnDrop = Delegate.Combine(this.MouseTargetOnDrop, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.MouseTargetOnDrop = Delegate.Remove(this.MouseTargetOnDrop, value);
			}
		}

		public event EventHandler MouseTargetDoubleClicked
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.MouseTargetDoubleClicked = Delegate.Combine(this.MouseTargetDoubleClicked, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.MouseTargetDoubleClicked = Delegate.Remove(this.MouseTargetDoubleClicked, value);
			}
		}

		public event EventHandler MouseTargetChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.MouseTargetChanged = Delegate.Combine(this.MouseTargetChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.MouseTargetChanged = Delegate.Remove(this.MouseTargetChanged, value);
			}
		}

		public event EventHandler ExpandChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.ExpandChanged = Delegate.Combine(this.ExpandChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.ExpandChanged = Delegate.Remove(this.ExpandChanged, value);
			}
		}

		public event EventHandler SelectionChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.SelectionChanged = Delegate.Combine(this.SelectionChanged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.SelectionChanged = Delegate.Remove(this.SelectionChanged, value);
			}
		}

		public int ListSelection_Selected
		{
			get
			{
				return this.mEditingList_Selected;
			}
		}

		public string EditedText
		{
			get
			{
				return this.mEditedText;
			}
		}

		public Script_ActionListTreeControl.eEditingType EditingType
		{
			get
			{
				return this.mEditingType;
			}
		}

		public bool Editing
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return ((this.mEditingType != Script_ActionListTreeControl.eEditingType.EDITING_MAX) ? 1 : 0) != 0;
			}
		}

		public ActionListTreeControl_Node_TextElement MouseTargetTextElement
		{
			get
			{
				return this.mMouseTargetTextElement;
			}
		}

		public ActionListTreeControl_Node MouseTargetNode
		{
			get
			{
				return this.mMouseTargetNode;
			}
		}

		public ActionListTreeControl_Node SelectedNode_End
		{
			get
			{
				return this.mSelectedNode_End;
			}
		}

		public ActionListTreeControl_Node SelectedNode
		{
			get
			{
				return this.mSelectedNode;
			}
		}

		public ActionListTreeControl_Node RootNode
		{
			get
			{
				return this.mRootNode;
			}
		}

		public Script_ActionListTreeControl()
		{
			this.SelectionChanged = null;
			this.ExpandChanged = null;
			this.MouseTargetChanged = null;
			this.MouseTargetDoubleClicked = null;
			this.MouseTargetOnDrop = null;
			this.TextEditingRequest = null;
			this.TextEditingFinished = null;
			this.ListSelectingFinished = null;
			this.InitializeComponent();
			ActionListTreeControl_Node actionListTreeControl_Node = new ActionListTreeControl_Node("<*ROOT*>", false);
			this.mRootNode = actionListTreeControl_Node;
			actionListTreeControl_Node.Expand();
			ActionListTreeControl_Node actionListTreeControl_Node2 = this.mRootNode;
			this.mFirstDisplayNode = actionListTreeControl_Node2;
			this.mSelectedNode = actionListTreeControl_Node2;
			this.mSelectedNode_End = actionListTreeControl_Node2;
			this.mFrameSize = 2;
			this.mSpaceWidth = 3;
			this.mRowHeight = 16;
			this.mDepthTab = 16;
			this.mMaxRows = 0;
			this.mSelectedRow = 0;
			this.mMouseTargetNode = null;
			this.mMouseTargetTextElement = null;
			this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX;
			this.MouseLeftHeld = false;
			this.ScrollTimer = null;
			this.AllowDrop = true;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.UpdateStyles();
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
			this.AllowDrop = true;
			Color window = SystemColors.Window;
			this.BackColor = window;
			base.Name = "Script_ActionListTreeControl";
			Size size = new Size(228, 176);
			base.Size = size;
			base.SizeChanged += new EventHandler(this.Script_ActionListTreeControl_Update);
			base.Enter += new EventHandler(this.Script_ActionListTreeControl_Update);
			base.MouseUp += new MouseEventHandler(this.Script_ActionListTreeControl_MouseUp);
			base.Paint += new PaintEventHandler(this.Script_ActionListTreeControl_Paint);
			base.DragDrop += new DragEventHandler(this.Script_ActionListTreeControl_DragDrop);
			base.KeyDown += new KeyEventHandler(this.Script_ActionListTreeControl_KeyDown);
			base.Leave += new EventHandler(this.Script_ActionListTreeControl_Update);
			base.DragOver += new DragEventHandler(this.Script_ActionListTreeControl_DragOver);
			base.MouseMove += new MouseEventHandler(this.Script_ActionListTreeControl_MouseMove);
			base.MouseWheel += new MouseEventHandler(this.Script_ActionListTreeControl_MouseWheel);
			base.MouseDown += new MouseEventHandler(this.Script_ActionListTreeControl_MouseDown);
		}

		public void StartTextEditing(string s)
		{
			this.mEditedText = s;
			this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_Number;
			base.Capture = true;
			base.Invalidate();
		}

		public void StartListSelecting(string[] stringlist)
		{
			this.mEditingStringList = stringlist;
			this.mEditingList_MaxDisplayed = 10;
			this.mEditingList_FirstDisplayed = 0;
			this.mEditingList_Selected = 0;
			this.mEditingList_Width = 0;
			this.mEditedText = stringlist[0];
			int num = stringlist.Length;
			if (num < 10)
			{
				this.mEditingList_MaxDisplayed = num;
			}
			this.mEditingList_X = this.mMouseTargetTextElement.GetArea().X;
			this.mEditingList_Y_Up = this.mMouseTargetTextElement.GetArea().Y;
			this.mEditingList_Y = this.mMouseTargetTextElement.GetArea().Bottom;
			this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_ListSelection;
			base.Capture = true;
			base.Invalidate();
		}

		public void StopListSelecting()
		{
			this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX;
			this.mEditingStringList = null;
			base.Capture = false;
			base.Invalidate();
		}

		public void Dirty([MarshalAs(UnmanagedType.U1)] bool reset)
		{
			base.Invalidate();
			if (base.Capture)
			{
				base.Capture = false;
			}
			this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX;
			if (reset)
			{
				ActionListTreeControl_Node treeNext = this.GetTreeNext(this.mRootNode);
				this.mSelectedNode = treeNext;
				this.mSelectedNode_End = treeNext;
				this.mFirstDisplayNode = treeNext;
				this.mMouseTargetNode = null;
				this.mMouseTargetTextElement = null;
				this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX;
				this.raise_SelectionChanged(this, new EventArgs());
				this.raise_MouseTargetChanged(this, new EventArgs());
			}
		}

		public ActionListTreeControl_Node GetTreePrev(ActionListTreeControl_Node node)
		{
			if (node == null)
			{
				return null;
			}
			if (node.Prev != null)
			{
				if (node.Prev.Expanded && node.Prev.GetNumberOfNodes() != 0)
				{
					node = node.Prev;
					if (node.Expanded)
					{
						while (node.GetNumberOfNodes() != 0)
						{
							ActionListTreeControl_Node expr_43 = node;
							node = expr_43.GetNode(expr_43.GetNumberOfNodes() - 1);
							if (!node.Expanded)
							{
								break;
							}
						}
					}
					if (node.GetNumberOfHeaderNodes() != 0)
					{
						ActionListTreeControl_Node expr_63 = node;
						return expr_63.GetHeaderNode(expr_63.GetNumberOfHeaderNodes() - 1);
					}
					return node;
				}
				else
				{
					if (node.Prev.GetNumberOfHeaderNodes() != 0)
					{
						return node.Prev.GetHeaderNode(node.Prev.GetNumberOfHeaderNodes() - 1);
					}
					return node.Prev;
				}
			}
			else
			{
				if (!node.HeaderNode && node.Parent.GetNumberOfHeaderNodes() != 0)
				{
					return node.Parent.GetHeaderNode(node.Parent.GetNumberOfHeaderNodes() - 1);
				}
				if (node.Parent != null && node.Parent != this.mRootNode)
				{
					return node.Parent;
				}
				return null;
			}
		}

		public ActionListTreeControl_Node GetTreeNext(ActionListTreeControl_Node node, int steps)
		{
			if (node == this.mRootNode)
			{
				node = this.GetTreeNext(node);
			}
			if (node != null)
			{
				while (steps != 0)
				{
					node = this.GetTreeNext(node);
					steps--;
					if (node == null)
					{
						break;
					}
				}
			}
			return node;
		}

		public ActionListTreeControl_Node GetTreeNext(ActionListTreeControl_Node node)
		{
			if (node == null)
			{
				return null;
			}
			bool flag = true;
			while (true)
			{
				if (flag)
				{
					if (node.GetNumberOfHeaderNodes() != 0)
					{
						break;
					}
					if (node.Expanded && node.GetNumberOfNodes() != 0)
					{
						goto IL_68;
					}
				}
				if (node.Next != null)
				{
					goto IL_70;
				}
				if (node.Parent == null)
				{
					goto IL_84;
				}
				if (node.HeaderNode && node.Parent.Expanded && node.Parent.GetNumberOfNodes() != 0)
				{
					goto IL_77;
				}
				flag = false;
				node = node.Parent;
			}
			return node.GetHeaderNode(0);
			IL_68:
			return node.GetNode(0);
			IL_70:
			return node.Next;
			IL_77:
			return node.Parent.GetNode(0);
			IL_84:
			return null;
		}

		public ActionListTreeControl_Node GetTreeNext_OpenNoHeader(ActionListTreeControl_Node node)
		{
			if (node != null && !node.HeaderNode)
			{
				bool flag = true;
				while (!flag || node.GetNumberOfNodes() == 0)
				{
					if (node.Next != null)
					{
						return node.Next;
					}
					if (node.Parent == null)
					{
						return null;
					}
					flag = false;
					node = node.Parent;
				}
				return node.GetNode(0);
			}
			return null;
		}

		public unsafe void GetSelectionInfos(int* firstdisplayed, int* selrow)
		{
			ActionListTreeControl_Node treeNext = this.GetTreeNext(this.mRootNode);
			*firstdisplayed = 0;
			*selrow = 0;
			if (treeNext != null)
			{
				while (treeNext != this.mSelectedNode)
				{
					if (treeNext == this.mFirstDisplayNode)
					{
						*firstdisplayed = *selrow;
					}
					(*selrow)++;
					treeNext = this.GetTreeNext(treeNext);
					if (treeNext == null)
					{
						break;
					}
				}
			}
			if (treeNext == this.mFirstDisplayNode)
			{
				*firstdisplayed = *selrow;
			}
		}

		public void SetSelectionInfos(int firstdisplayed, int selrow)
		{
			ActionListTreeControl_Node actionListTreeControl_Node = this.GetTreeNext(this.mRootNode);
			if (firstdisplayed > selrow)
			{
				firstdisplayed = selrow;
			}
			int num = this.mMaxRows;
			if (num + firstdisplayed < selrow)
			{
				firstdisplayed = selrow - num + 1;
			}
			this.mFirstDisplayNode = this.mRootNode;
			int num2 = 0;
			if (0 < selrow)
			{
				while (actionListTreeControl_Node != null)
				{
					if (num2 == firstdisplayed)
					{
						this.mFirstDisplayNode = actionListTreeControl_Node;
					}
					ActionListTreeControl_Node treeNext = this.GetTreeNext(actionListTreeControl_Node);
					if (treeNext == null)
					{
						break;
					}
					actionListTreeControl_Node = treeNext;
					num2++;
					if (num2 >= selrow)
					{
						break;
					}
				}
			}
			if (num2 == firstdisplayed)
			{
				this.mFirstDisplayNode = actionListTreeControl_Node;
			}
			this.mSelectedNode = actionListTreeControl_Node;
			this.mSelectedNode_End = actionListTreeControl_Node;
			this.mSelectedBeginExtended = actionListTreeControl_Node.ActionIndex;
			this.mSelectedEndExtended = actionListTreeControl_Node.ActionIndex;
			this.mSelectedRow = num2 - firstdisplayed;
			this.mMouseTargetNode = null;
			this.mMouseTargetTextElement = null;
			this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX;
			if (base.Capture)
			{
				base.Capture = false;
			}
			this.raise_SelectionChanged(this, new EventArgs());
			this.raise_MouseTargetChanged(this, new EventArgs());
			base.Invalidate();
		}

		public void SetSelectionExtendedInfos(int selbeginext, int selendext)
		{
			this.mSelectedBeginExtended = selbeginext;
			this.mSelectedEndExtended = selendext;
			base.Invalidate();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		protected override bool IsInputKey(Keys key)
		{
			return key >= Keys.Left && key <= Keys.Down;
		}

		private unsafe void Script_ActionListTreeControl_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = e.Graphics;
			Rectangle clientRectangle = base.ClientRectangle;
			int num = -this.mFrameSize;
			int expr_1C = num;
			clientRectangle.Inflate(expr_1C, expr_1C);
			int num2 = clientRectangle.Width;
			clientRectangle.Width = num2 - 1;
			num2 = clientRectangle.Height;
			clientRectangle.Height = num2 - 1;
			Font font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
			Font font2 = new Font("Arial", 8f, FontStyle.Underline, GraphicsUnit.Point, 0);
			Pen controlDark = SystemPens.ControlDark;
			Pen controlDarkDark = SystemPens.ControlDarkDark;
			Pen controlLight = SystemPens.ControlLight;
			Pen controlLightLight = SystemPens.ControlLightLight;
			Pen controlLight2 = SystemPens.ControlLight;
			Pen pen = new Pen(Color.FromKnownColor(KnownColor.LightGreen));
			Pen controlDark2 = SystemPens.ControlDark;
			Brush brush;
			Brush brush2;
			if (this.Focused)
			{
				brush = SystemBrushes.Highlight;
				new SolidBrush(Color.FromKnownColor(KnownColor.MediumBlue));
				Brush arg_CB_0 = SystemBrushes.HighlightText;
				if (this.mMouseTargetNode == this.mSelectedNode)
				{
					brush2 = new SolidBrush(Color.FromKnownColor(KnownColor.DarkGray));
				}
				else
				{
					brush2 = new SolidBrush(Color.FromKnownColor(KnownColor.LightGray));
				}
			}
			else
			{
				brush = new SolidBrush(Color.FromKnownColor(KnownColor.Gray));
				new SolidBrush(Color.FromKnownColor(KnownColor.LightGray));
				Brush arg_11A_0 = SystemBrushes.ControlText;
				brush2 = new SolidBrush(Color.FromKnownColor(KnownColor.Blue));
			}
			Brush brush3 = new SolidBrush(Color.FromKnownColor(KnownColor.Green));
			Brush brush4 = new SolidBrush(Color.FromKnownColor(KnownColor.LightGreen));
			Brush controlText = SystemBrushes.ControlText;
			Brush highlightText = SystemBrushes.HighlightText;
			Brush[] array = new Brush[10];
			array[0] = SystemBrushes.ControlText;
			Color color = Color.FromKnownColor(KnownColor.Blue);
			array[2] = new SolidBrush(color);
			Color color2 = Color.FromKnownColor(KnownColor.OrangeRed);
			array[1] = new SolidBrush(color2);
			Color color3 = Color.FromKnownColor(KnownColor.DarkGray);
			array[3] = new SolidBrush(color3);
			Color color4 = Color.FromKnownColor(KnownColor.Red);
			array[4] = new SolidBrush(color4);
			array[5] = SystemBrushes.HighlightText;
			Color color5 = Color.FromKnownColor(KnownColor.LightBlue);
			array[7] = new SolidBrush(color5);
			Color color6 = Color.FromKnownColor(KnownColor.Yellow);
			array[6] = new SolidBrush(color6);
			Color color7 = Color.FromKnownColor(KnownColor.Gray);
			array[8] = new SolidBrush(color7);
			Color color8 = Color.FromKnownColor(KnownColor.Red);
			array[9] = new SolidBrush(color8);
			int num3 = clientRectangle.Left + 14;
			int num4 = clientRectangle.Top;
			int i = (this.mRowHeight - font.Height) / 2 + num4;
			ActionListTreeControl_Node actionListTreeControl_Node = this.mFirstDisplayNode;
			ActionListTreeControl_Node actionListTreeControl_Node2 = actionListTreeControl_Node;
			if (actionListTreeControl_Node2 != null)
			{
				while (actionListTreeControl_Node2.Parent != null)
				{
					actionListTreeControl_Node2 = actionListTreeControl_Node2.Parent;
					num3 = this.mDepthTab + num3;
					if (actionListTreeControl_Node2 == null)
					{
						break;
					}
				}
			}
			actionListTreeControl_Node2 = actionListTreeControl_Node;
			if (actionListTreeControl_Node2 != null)
			{
				while (i < clientRectangle.Bottom)
				{
					ActionListTreeControl_Node actionListTreeControl_Node3 = this.mSelectedNode;
					ActionListTreeControl_Node actionListTreeControl_Node4 = this.mSelectedNode_End;
					bool flag;
					int num5;
					if (actionListTreeControl_Node3 == actionListTreeControl_Node4)
					{
						flag = (((actionListTreeControl_Node3 == actionListTreeControl_Node2) ? 1 : 0) != 0);
					}
					else
					{
						if (actionListTreeControl_Node3.ActionIndex <= actionListTreeControl_Node2.ActionIndex && actionListTreeControl_Node2.ActionIndex <= actionListTreeControl_Node4.ActionIndex)
						{
							num5 = 1;
						}
						else
						{
							num5 = 0;
						}
						flag = ((byte)num5 != 0);
						if (actionListTreeControl_Node4.ActionIndex <= actionListTreeControl_Node2.ActionIndex && actionListTreeControl_Node2.ActionIndex <= actionListTreeControl_Node3.ActionIndex)
						{
							num5 = 1;
						}
						else
						{
							num5 = 0;
						}
						flag = (((flag ? 1 : 0) | (byte)num5) != 0);
					}
					if (this.mSelectedBeginExtended <= actionListTreeControl_Node2.ActionIndex && actionListTreeControl_Node2.ActionIndex <= this.mSelectedEndExtended)
					{
						num5 = 1;
					}
					else
					{
						num5 = 0;
					}
					bool flag2 = (byte)num5 != 0;
					if (actionListTreeControl_Node2 != this.mRootNode)
					{
						int num6 = this.mDepthTab;
						num5 = num3 - num6 - 4;
						int num9;
						if (!actionListTreeControl_Node2.HeaderNode)
						{
							if (actionListTreeControl_Node2.GetNumberOfNodes() != 0)
							{
								num6 = this.mRowHeight;
								int num7 = this.mDepthTab;
								graphics.DrawRectangle(controlDark2, num7 / 4 + num5, num6 / 4 + num4, num7 / 2, num6 / 2);
								int num8 = num4 + this.mRowHeight / 2;
								num7 = this.mDepthTab;
								graphics.DrawLine(controlDark2, num5 + num7 / 4 + 2, num8, num5 + num7 * 3 / 4 - 2, num8);
								if (!actionListTreeControl_Node2.Expanded)
								{
									num6 = this.mRowHeight;
									num8 = num5 + this.mDepthTab / 2;
									graphics.DrawLine(controlDark2, num8, num4 + num6 / 4 + 2, num8, num4 + num6 * 3 / 4 - 2);
								}
								num8 = num5 + this.mDepthTab / 2;
								graphics.DrawLine(controlLight2, num8, num4, num8, this.mRowHeight / 4 + num4);
								num8 = num4 + this.mRowHeight / 2;
								num7 = this.mDepthTab;
								graphics.DrawLine(controlLight2, num7 * 3 / 4 + num5, num8, num7 + num5, num8);
								if (actionListTreeControl_Node2.Next != null)
								{
									num7 = this.mRowHeight;
									num8 = num5 + this.mDepthTab / 2;
									graphics.DrawLine(controlLight2, num8, num7 * 3 / 4 + num4, num8, num7 + num4);
								}
							}
							else if (actionListTreeControl_Node2.Next != null)
							{
								int num8 = num5 + this.mDepthTab / 2;
								graphics.DrawLine(controlLight2, num8, num4, num8, this.mRowHeight + num4);
								num8 = num4 + this.mRowHeight / 2;
								int num7 = this.mDepthTab;
								graphics.DrawLine(controlLight2, num7 / 2 + num5, num8, num7 + num5, num8);
							}
							else
							{
								int num8 = num5 + this.mDepthTab / 2;
								graphics.DrawLine(controlLight2, num8, num4, num8, this.mRowHeight / 2 + num4);
								num8 = num4 + this.mRowHeight / 2;
								int num7 = this.mDepthTab;
								graphics.DrawLine(controlLight2, num7 / 2 + num5, num8, num7 + num5, num8);
							}
						}
						else
						{
							if (actionListTreeControl_Node2.Next != null)
							{
								int num8 = num5 + num6 * 3 / 2;
								graphics.DrawLine(pen, num8, num4, num8, this.mRowHeight + num4);
								num8 = num4 + this.mRowHeight / 2;
								int num7 = this.mDepthTab;
								graphics.DrawLine(pen, num7 * 3 / 2 + num5, num8, num7 * 2 + num5, num8);
							}
							else
							{
								int num8 = num5 + num6 * 3 / 2;
								graphics.DrawLine(pen, num8, num4, num8, this.mRowHeight / 2 + num4);
								num8 = num4 + this.mRowHeight / 2;
								int num7 = this.mDepthTab;
								graphics.DrawLine(pen, num7 * 3 / 2 + num5, num8, num7 * 2 + num5, num8);
							}
							if (actionListTreeControl_Node2.Parent.Expanded && actionListTreeControl_Node2.Parent.GetNumberOfNodes() != 0)
							{
								num9 = num5 + this.mDepthTab / 2;
								graphics.DrawLine(controlLight2, num9, num4, num9, this.mRowHeight + num4);
							}
						}
						ActionListTreeControl_Node parent = actionListTreeControl_Node2.Parent;
						int num10 = this.mDepthTab;
						num5 -= num10;
						if (parent != this.mRootNode)
						{
							do
							{
								if (parent.Next != null)
								{
									num9 = num5 + num10 / 2;
									graphics.DrawLine(controlLight2, num9, num4, num9, this.mRowHeight + num4);
								}
								parent = parent.Parent;
								num10 = this.mDepthTab;
								num5 -= num10;
							}
							while (parent != this.mRootNode);
						}
						num9 = ((!actionListTreeControl_Node2.HeaderNode) ? 0 : this.mDepthTab) + num3;
						if (actionListTreeControl_Node2.GetNumberOfTextElements() != 0)
						{
							int num11;
							if (flag && !this.Editing)
							{
								graphics.FillRectangle(brush, num9 - 2, num4, clientRectangle.Width + clientRectangle.Left + (2 - num9), this.mRowHeight);
								num11 = 5;
							}
							else
							{
								num11 = 0;
							}
							if (flag2 && !this.Editing)
							{
								graphics.FillRectangle(brush, this.mDepthTab + num5 - 10, num4, 7, this.mRowHeight);
							}
							int num12 = 0;
							if (0 < actionListTreeControl_Node2.GetNumberOfTextElements())
							{
								do
								{
									ActionListTreeControl_Node_TextElement textElement = actionListTreeControl_Node2.GetTextElement(num12);
									SizeF sizeF = graphics.MeasureString(textElement.Text, font, 0, null);
									Size size = new Size((int)((double)sizeF.Width) + 4, (int)((double)sizeF.Height) + 4);
									Point location = new Point(num9 - 2, i - 2);
									Rectangle rectangle = new Rectangle(location, size);
									textElement.SetArea(ref rectangle);
									if (this.mMouseTargetTextElement == textElement)
									{
										if (this.Editing)
										{
											sizeF = graphics.MeasureString(this.mEditedText, font, 0, null);
											Size size2 = new Size((int)((double)sizeF.Width) + 4, (int)((double)sizeF.Height) + 4);
											Point location2 = new Point(num9 - 2, i - 2);
											Rectangle rect = new Rectangle(location2, size2);
											textElement.SetArea(ref rect);
											graphics.DrawRectangle(controlDark2, rect);
											Point p = new Point(num9, i);
											PointF point = p;
											graphics.DrawString(this.mEditedText, font, array[textElement.Type + num11], point);
										}
										else
										{
											graphics.FillRectangle(brush2, *textElement.GetArea());
											Point p2 = new Point(num9, i);
											PointF point2 = p2;
											graphics.DrawString(textElement.Text, font2, array[textElement.Type + num11], point2);
										}
									}
									else
									{
										Point p3 = new Point(num9, i);
										PointF point3 = p3;
										graphics.DrawString(textElement.Text, font, array[textElement.Type + num11], point3);
									}
									num9 = (int)((double)sizeF.Width) + this.mSpaceWidth + num9;
									num12++;
								}
								while (num12 < actionListTreeControl_Node2.GetNumberOfTextElements());
							}
						}
						else if (actionListTreeControl_Node2.HeaderNode)
						{
							if (flag)
							{
								num10 = this.mDepthTab;
								graphics.FillRectangle(brush2, num3 + num10 - 2, num4, clientRectangle.Width + clientRectangle.Left + (2 - num10 - num3), this.mRowHeight);
								Point p4 = new Point(this.mDepthTab + num3, i);
								PointF point4 = p4;
								graphics.DrawString(actionListTreeControl_Node2.Text, font, brush4, point4);
							}
							else
							{
								Point p5 = new Point(this.mDepthTab + num3, i);
								PointF point5 = p5;
								graphics.DrawString(actionListTreeControl_Node2.Text, font, brush3, point5);
							}
						}
						else if (flag)
						{
							graphics.FillRectangle(brush, num3 - 2, num4, clientRectangle.Width + clientRectangle.Left + (2 - num3), this.mRowHeight);
							Point p6 = new Point(num3, i);
							PointF point6 = p6;
							graphics.DrawString(actionListTreeControl_Node2.Text, font, highlightText, point6);
						}
						else
						{
							Point p7 = new Point(num3, i);
							PointF point7 = p7;
							graphics.DrawString(actionListTreeControl_Node2.Text, font, controlText, point7);
						}
						int num13 = this.mRowHeight;
						i = num13 + i;
						num4 = num13 + num4;
					}
					bool flag3 = true;
					while (true)
					{
						if (flag3)
						{
							if (actionListTreeControl_Node2.GetNumberOfHeaderNodes() != 0)
							{
								goto IL_A3D;
							}
							if (actionListTreeControl_Node2.Expanded && actionListTreeControl_Node2.GetNumberOfNodes() != 0)
							{
								goto IL_A52;
							}
						}
						if (actionListTreeControl_Node2.Next != null)
						{
							goto IL_A67;
						}
						if (actionListTreeControl_Node2.Parent == null)
						{
							goto IL_A7F;
						}
						flag3 = false;
						if (actionListTreeControl_Node2.HeaderNode && actionListTreeControl_Node2.Parent.Expanded && actionListTreeControl_Node2.Parent.GetNumberOfNodes() != 0)
						{
							goto IL_A70;
						}
						actionListTreeControl_Node2 = actionListTreeControl_Node2.Parent;
						num3 -= this.mDepthTab;
					}
					IL_A81:
					if (actionListTreeControl_Node2 == null)
					{
						break;
					}
					continue;
					IL_A3D:
					actionListTreeControl_Node2 = actionListTreeControl_Node2.GetHeaderNode(0);
					num3 = this.mDepthTab + num3;
					goto IL_A81;
					IL_A52:
					actionListTreeControl_Node2 = actionListTreeControl_Node2.GetNode(0);
					num3 = this.mDepthTab + num3;
					goto IL_A81;
					IL_A67:
					actionListTreeControl_Node2 = actionListTreeControl_Node2.Next;
					goto IL_A81;
					IL_A70:
					actionListTreeControl_Node2 = actionListTreeControl_Node2.Parent.GetNode(0);
					goto IL_A81;
					IL_A7F:
					actionListTreeControl_Node2 = null;
					goto IL_A81;
				}
			}
			int num14 = this.mFrameSize;
			int expr_A93 = num14;
			clientRectangle.Inflate(expr_A93, expr_A93);
			graphics.DrawLine(controlDark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Right, clientRectangle.Top);
			graphics.DrawLine(controlDarkDark, clientRectangle.Left, clientRectangle.Top + 1, clientRectangle.Right - 1, clientRectangle.Top + 1);
			graphics.DrawLine(controlDark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Left, clientRectangle.Bottom);
			graphics.DrawLine(controlDarkDark, clientRectangle.Left + 1, clientRectangle.Top, clientRectangle.Left + 1, clientRectangle.Bottom - 1);
			graphics.DrawLine(controlLightLight, clientRectangle.Left + 1, clientRectangle.Bottom, clientRectangle.Right - 1, clientRectangle.Bottom);
			graphics.DrawLine(controlLight, clientRectangle.Left + 2, clientRectangle.Bottom - 1, clientRectangle.Right - 1, clientRectangle.Bottom - 1);
			graphics.DrawLine(controlLightLight, clientRectangle.Right, clientRectangle.Top + 1, clientRectangle.Right, clientRectangle.Bottom);
			graphics.DrawLine(controlLight, clientRectangle.Right - 1, clientRectangle.Top + 2, clientRectangle.Right - 1, clientRectangle.Bottom);
			if (this.mEditingType == Script_ActionListTreeControl.eEditingType.EDITING_ListSelection)
			{
				int num15;
				if (this.mEditingList_Width == 0)
				{
					num15 = 0;
					if (0 < this.mEditingStringList.Length)
					{
						do
						{
							int num16 = (int)((double)graphics.MeasureString(this.mEditingStringList[num15], font, 0, null).Width);
							if (num16 > this.mEditingList_Width)
							{
								this.mEditingList_Width = num16;
							}
							num15++;
						}
						while (num15 < this.mEditingStringList.Length);
					}
					this.mEditingList_Width += 6;
					if (this.mFrameSize * 2 + this.mEditingList_X + this.mEditingList_Width >= clientRectangle.Width)
					{
						this.mEditingList_X = clientRectangle.Width - (this.mFrameSize << 1) - this.mEditingList_Width;
					}
					if (this.mEditingList_X < 0)
					{
						this.mEditingList_X = 0;
					}
					num15 = this.mEditingList_MaxDisplayed * this.mRowHeight;
					num14 = this.mFrameSize;
					if (num14 * 2 + this.mEditingList_Y + num15 >= clientRectangle.Height)
					{
						this.mEditingList_Y = this.mEditingList_Y_Up - (num14 << 1) - num15;
					}
					if (this.mEditingList_Y < 0)
					{
						this.mEditingList_Y = 0;
					}
				}
				clientRectangle.X = clientRectangle.X + this.mEditingList_X + this.mFrameSize;
				clientRectangle.Y = clientRectangle.Y + this.mEditingList_Y + this.mFrameSize;
				clientRectangle.Width = this.mEditingList_Width;
				clientRectangle.Height = this.mEditingList_MaxDisplayed * this.mRowHeight;
				graphics.FillRectangle(SystemBrushes.ControlLight, clientRectangle);
				num15 = clientRectangle.Y;
				int num17 = 0;
				if (0 < this.mEditingList_MaxDisplayed)
				{
					do
					{
						int num18 = num17 + this.mEditingList_FirstDisplayed;
						if (num18 >= this.mEditingStringList.Length)
						{
							break;
						}
						int num19 = num18;
						Brush brush5;
						if (num19 == this.mEditingList_Selected)
						{
							graphics.FillRectangle(brush, clientRectangle.X, num15, clientRectangle.Width, this.mRowHeight);
							brush5 = highlightText;
						}
						else
						{
							brush5 = controlText;
						}
						Point p8 = new Point(clientRectangle.X + 2, (this.mRowHeight - font.Height) / 2 + num15);
						PointF point8 = p8;
						graphics.DrawString(this.mEditingStringList[num19], font, brush5, point8);
						num17++;
						num15 = this.mRowHeight + num15;
					}
					while (num17 < this.mEditingList_MaxDisplayed);
				}
				num14 = this.mFrameSize;
				int expr_E24 = num14;
				clientRectangle.Inflate(expr_E24, expr_E24);
				graphics.DrawLine(controlDark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Right, clientRectangle.Top);
				graphics.DrawLine(controlDarkDark, clientRectangle.Left, clientRectangle.Top + 1, clientRectangle.Right - 1, clientRectangle.Top + 1);
				graphics.DrawLine(controlDark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Left, clientRectangle.Bottom);
				graphics.DrawLine(controlDarkDark, clientRectangle.Left + 1, clientRectangle.Top, clientRectangle.Left + 1, clientRectangle.Bottom - 1);
				graphics.DrawLine(controlLightLight, clientRectangle.Left + 1, clientRectangle.Bottom, clientRectangle.Right - 1, clientRectangle.Bottom);
				graphics.DrawLine(controlLight, clientRectangle.Left + 2, clientRectangle.Bottom - 1, clientRectangle.Right - 1, clientRectangle.Bottom - 1);
				graphics.DrawLine(controlLightLight, clientRectangle.Right, clientRectangle.Top + 1, clientRectangle.Right, clientRectangle.Bottom);
				graphics.DrawLine(controlLight, clientRectangle.Right - 1, clientRectangle.Top + 2, clientRectangle.Right - 1, clientRectangle.Bottom);
			}
		}

		private void Script_ActionListTreeControl_KeyDown(object sender, KeyEventArgs e)
		{
			char c = '\0';
			switch (e.KeyCode)
			{
			case Keys.Back:
				if (this.mEditingType == Script_ActionListTreeControl.eEditingType.EDITING_Number)
				{
					string text = this.mEditedText.Substring(0, this.mEditedText.Length - 1);
					this.mEditedText = text;
					if (text.Length == 0 || this.mEditedText.CompareTo("-") == 0)
					{
						this.mEditedText = "0";
					}
					base.Invalidate();
				}
				break;
			case Keys.Return:
				if (this.Editing)
				{
					Script_ActionListTreeControl.eEditingType eEditingType = this.mEditingType;
					if (eEditingType == Script_ActionListTreeControl.eEditingType.EDITING_ListSelection)
					{
						base.Capture = false;
						this.raise_ListSelectingFinished(this, new EventArgs());
						this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX;
						base.Invalidate();
					}
					else if (eEditingType == Script_ActionListTreeControl.eEditingType.EDITING_Number)
					{
						base.Capture = false;
						this.raise_TextEditingFinished(this, new EventArgs());
						this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX;
						base.Invalidate();
					}
				}
				else
				{
					ActionListTreeControl_Node actionListTreeControl_Node = this.mSelectedNode;
					if (actionListTreeControl_Node != null && actionListTreeControl_Node.GetNumberOfNodes() != 0)
					{
						this.mSelectedNode.ToggleExpand();
						base.Invalidate();
					}
				}
				e.Handled = true;
				break;
			case Keys.Escape:
				if (this.Editing)
				{
					this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX;
					base.Capture = false;
					e.Handled = true;
					base.Invalidate();
				}
				break;
			case Keys.Up:
				if (this.mEditingType == Script_ActionListTreeControl.eEditingType.EDITING_ListSelection)
				{
					int num = this.mEditingList_Selected;
					if (num > 0)
					{
						int num2 = num - 1;
						this.mEditingList_Selected = num2;
						if (this.mEditingList_FirstDisplayed > num2)
						{
							this.mEditingList_FirstDisplayed = num2;
						}
						this.mEditedText = this.mEditingStringList[num2];
						base.Invalidate();
					}
					e.Handled = true;
				}
				else if (!this.Editing)
				{
					ActionListTreeControl_Node treePrev = this.GetTreePrev(this.mSelectedNode);
					if (treePrev != null)
					{
						if (this.mFirstDisplayNode == this.mSelectedNode)
						{
							this.mFirstDisplayNode = treePrev;
						}
						else
						{
							this.mSelectedRow--;
						}
						this.mSelectedNode = treePrev;
						this.mSelectedNode_End = treePrev;
						this.mSelectedBeginExtended = treePrev.ActionIndex;
						this.mSelectedEndExtended = treePrev.ActionIndex;
						this.raise_SelectionChanged(this, new EventArgs());
						base.Invalidate();
					}
					e.Handled = true;
				}
				break;
			case Keys.Down:
				if (this.mEditingType == Script_ActionListTreeControl.eEditingType.EDITING_ListSelection)
				{
					string[] array = this.mEditingStringList;
					int num3 = this.mEditingList_Selected + 1;
					if (num3 < array.Length)
					{
						this.mEditingList_Selected = num3;
						int num4 = this.mEditingList_MaxDisplayed;
						if (this.mEditingList_FirstDisplayed + num4 <= num3)
						{
							this.mEditingList_FirstDisplayed = num3 - num4 + 1;
						}
						this.mEditedText = array[num3];
						base.Invalidate();
					}
					e.Handled = true;
				}
				else if (!this.Editing)
				{
					ActionListTreeControl_Node treeNext = this.GetTreeNext(this.mSelectedNode);
					if (treeNext != null)
					{
						this.mSelectedNode = treeNext;
						this.mSelectedNode_End = treeNext;
						this.mSelectedBeginExtended = treeNext.ActionIndex;
						this.mSelectedEndExtended = treeNext.ActionIndex;
						int num5 = this.mSelectedRow + 1;
						if (num5 == this.mMaxRows)
						{
							this.mFirstDisplayNode = this.GetTreeNext(this.mFirstDisplayNode);
						}
						else
						{
							this.mSelectedRow = num5;
						}
						this.raise_SelectionChanged(this, new EventArgs());
						base.Invalidate();
					}
					e.Handled = true;
				}
				break;
			case Keys.D0:
				c = '0';
				break;
			case Keys.D1:
				c = '1';
				break;
			case Keys.D2:
				c = '2';
				break;
			case Keys.D3:
				c = '3';
				break;
			case Keys.D4:
				c = '4';
				break;
			case Keys.D5:
				c = '5';
				break;
			case Keys.D6:
				c = '6';
				break;
			case Keys.D7:
				c = '7';
				break;
			case Keys.D8:
				c = '8';
				break;
			case Keys.D9:
				c = '9';
				break;
			case Keys.NumPad0:
				c = '0';
				break;
			case Keys.NumPad1:
				c = '1';
				break;
			case Keys.NumPad2:
				c = '2';
				break;
			case Keys.NumPad3:
				c = '3';
				break;
			case Keys.NumPad4:
				c = '4';
				break;
			case Keys.NumPad5:
				c = '5';
				break;
			case Keys.NumPad6:
				c = '6';
				break;
			case Keys.NumPad7:
				c = '7';
				break;
			case Keys.NumPad8:
				c = '8';
				break;
			case Keys.NumPad9:
				c = '9';
				break;
			case Keys.OemMinus:
				if (this.mEditingType == Script_ActionListTreeControl.eEditingType.EDITING_Number)
				{
					if (this.mEditedText[0] == '-')
					{
						this.mEditedText = this.mEditedText.Substring(1, this.mEditedText.Length - 1);
					}
					else
					{
						this.mEditedText = "-" + this.mEditedText;
					}
					base.Invalidate();
				}
				break;
			}
			if (this.mEditingType == Script_ActionListTreeControl.eEditingType.EDITING_Number && c != '\0')
			{
				e.Handled = true;
				if (this.mEditedText.Length < 8)
				{
					if (string.Compare(this.mEditedText, "0", false) == 0)
					{
						this.mEditedText = string.Empty;
					}
					this.mEditedText += string.Format("{0}", c);
					base.Invalidate();
				}
			}
		}

		private void Script_ActionListTreeControl_Update(object sender, EventArgs e)
		{
			this.mMaxRows = (base.ClientRectangle.Height - (this.mFrameSize << 1)) / this.mRowHeight;
			base.Invalidate();
		}

		private void Script_ActionListTreeControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (this.mEditingType == Script_ActionListTreeControl.eEditingType.EDITING_ListSelection)
				{
					Rectangle clientRectangle = base.ClientRectangle;
					clientRectangle.X = clientRectangle.X + this.mFrameSize + this.mEditingList_X;
					clientRectangle.Y = clientRectangle.Y + this.mEditingList_Y + this.mFrameSize;
					clientRectangle.Width = this.mEditingList_Width;
					clientRectangle.Height = this.mRowHeight * this.mEditingList_MaxDisplayed;
					int x = e.X;
					int y = e.Y;
					if (clientRectangle.Contains(x, y))
					{
						this.mEditingList_Selected = (y - clientRectangle.Y) / this.mRowHeight + this.mEditingList_FirstDisplayed;
						this.raise_ListSelectingFinished(this, new EventArgs());
						if (base.Capture)
						{
							base.Capture = false;
						}
						this.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX;
						base.Invalidate();
					}
				}
				else if (!this.Editing && this.mSelectedNode != null)
				{
					Rectangle clientRectangle2 = base.ClientRectangle;
					int num = -this.mFrameSize;
					int expr_113 = num;
					clientRectangle2.Inflate(expr_113, expr_113);
					int x2 = e.X;
					int y2 = e.Y;
					if (clientRectangle2.Contains(x2, y2))
					{
						int num2 = (y2 - clientRectangle2.Y) / this.mRowHeight;
						ActionListTreeControl_Node treeNext = this.GetTreeNext(this.mFirstDisplayNode, num2);
						if (treeNext != null)
						{
							int num3;
							if (this.mSelectedNode == treeNext && this.mSelectedNode_End == treeNext)
							{
								num3 = 1;
							}
							else
							{
								num3 = 0;
							}
							bool flag = (byte)num3 != 0;
							this.mSelectedNode = treeNext;
							this.mSelectedNode_End = treeNext;
							this.MouseLeftHeld = true;
							int num4 = this.mMaxRows;
							if (num2 == num4)
							{
								this.mSelectedRow = num4 - 1;
								this.mFirstDisplayNode = this.GetTreeNext(this.mFirstDisplayNode);
							}
							else
							{
								this.mSelectedRow = num2;
							}
							if (e.Clicks == 2 && this.mMouseTargetTextElement == null)
							{
								this.mSelectedNode.ToggleExpand();
								this.raise_ExpandChanged(this, new EventArgs());
							}
							if (!flag)
							{
								this.mSelectedBeginExtended = treeNext.ActionIndex;
								this.mSelectedEndExtended = treeNext.ActionIndex;
								this.raise_SelectionChanged(this, new EventArgs());
							}
							if (e.Clicks == 2 && this.mMouseTargetTextElement != null)
							{
								this.raise_TextEditingRequest(this, new EventArgs());
							}
							this.ScrollTimer = new System.Timers.Timer();
							this.ScrollTimer.Elapsed += new ElapsedEventHandler(this.Script_ActionListTreeControl_OnTimed);
							this.ScrollTimer.AutoReset = false;
							this.ScrollTimer.Interval = 100.0;
							this.ScrollTimer.Enabled = true;
							base.Invalidate();
						}
					}
				}
			}
		}

		private void Script_ActionListTreeControl_MouseMove(object sender, MouseEventArgs e)
		{
			this.UpdateMouseTarget(e.X, e.Y);
			if (this.MouseLeftHeld)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				int num = -this.mFrameSize;
				int expr_32 = num;
				clientRectangle.Inflate(expr_32, expr_32);
				int x = e.X;
				int y = e.Y;
				if (clientRectangle.Contains(x, y))
				{
					int num2 = (y - clientRectangle.Y) / this.mRowHeight;
					ActionListTreeControl_Node treeNext = this.GetTreeNext(this.mFirstDisplayNode, num2);
					if (treeNext != null)
					{
						bool flag = ((this.mSelectedNode == treeNext) ? 1 : 0) != 0;
						this.mSelectedNode = treeNext;
						int num3 = this.mMaxRows;
						if (num2 == num3)
						{
							this.mSelectedRow = num3 - 1;
							this.mFirstDisplayNode = this.GetTreeNext(this.mFirstDisplayNode);
						}
						else
						{
							this.mSelectedRow = num2;
						}
						if (!flag)
						{
							this.mSelectedBeginExtended = treeNext.ActionIndex;
							this.mSelectedEndExtended = treeNext.ActionIndex;
							this.raise_SelectionChanged(this, new EventArgs());
						}
						base.Invalidate();
					}
				}
			}
			else if (this.mEditingType == Script_ActionListTreeControl.eEditingType.EDITING_ListSelection)
			{
				Rectangle clientRectangle2 = base.ClientRectangle;
				clientRectangle2.X = clientRectangle2.X + this.mEditingList_X + this.mFrameSize;
				clientRectangle2.Y = clientRectangle2.Y + this.mEditingList_Y + this.mFrameSize;
				clientRectangle2.Width = this.mEditingList_Width;
				clientRectangle2.Height = this.mEditingList_MaxDisplayed * this.mRowHeight;
				int x2 = e.X;
				int y2 = e.Y;
				if (clientRectangle2.Contains(x2, y2))
				{
					int num4 = this.mEditingList_FirstDisplayed + (y2 - clientRectangle2.Y) / this.mRowHeight;
					this.mEditingList_Selected = num4;
					this.mEditedText = this.mEditingStringList[num4];
					base.Invalidate();
				}
			}
		}

		private void Script_ActionListTreeControl_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.MouseLeftHeld)
			{
				this.MouseLeftHeld = false;
				this.ScrollTimer.Stop();
				this.ScrollTimer = null;
				base.Invalidate();
			}
		}

		private void Script_ActionListTreeControl_MouseWheel(object sender, MouseEventArgs e)
		{
			if (this.mSelectedNode != null && !this.MouseLeftHeld)
			{
				int num = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
				if (num != 0)
				{
					if (this.mEditingType == Script_ActionListTreeControl.eEditingType.EDITING_ListSelection)
					{
						if (num > 0)
						{
							int num2 = this.mEditingList_Selected;
							if (num > num2)
							{
								this.mEditingList_Selected = 0;
							}
							else
							{
								this.mEditingList_Selected = num2 - num;
							}
							int num3 = this.mEditingList_Selected;
							if (this.mEditingList_FirstDisplayed > num3)
							{
								this.mEditingList_FirstDisplayed = num3;
							}
						}
						else
						{
							int num4 = this.mEditingStringList.Length - 1;
							this.mEditingList_Selected = num4;
							int num5 = this.mEditingList_MaxDisplayed;
							if (this.mEditingList_FirstDisplayed + num5 <= num4)
							{
								this.mEditingList_FirstDisplayed = num4 - num5 + 1;
							}
						}
						this.mEditedText = this.mEditingStringList[this.mEditingList_Selected];
						base.Invalidate();
					}
					else if (!this.Editing)
					{
						if (num > 0)
						{
							ActionListTreeControl_Node actionListTreeControl_Node = this.mSelectedNode;
							int num6 = this.mSelectedRow;
							ActionListTreeControl_Node actionListTreeControl_Node2 = this.mFirstDisplayNode;
							do
							{
								num--;
								ActionListTreeControl_Node treePrev = this.GetTreePrev(actionListTreeControl_Node);
								if (treePrev == null || treePrev == this.mRootNode)
								{
									break;
								}
								if (actionListTreeControl_Node2 == actionListTreeControl_Node)
								{
									actionListTreeControl_Node2 = treePrev;
								}
								else
								{
									num6--;
								}
								actionListTreeControl_Node = treePrev;
							}
							while (num != 0);
							if (actionListTreeControl_Node != this.mSelectedNode)
							{
								this.mFirstDisplayNode = actionListTreeControl_Node2;
								this.mSelectedRow = num6;
								this.mSelectedNode = actionListTreeControl_Node;
								this.mSelectedNode_End = actionListTreeControl_Node;
								this.mSelectedBeginExtended = actionListTreeControl_Node.ActionIndex;
								this.mSelectedEndExtended = actionListTreeControl_Node.ActionIndex;
								this.raise_SelectionChanged(this, new EventArgs());
								base.Invalidate();
							}
						}
						else
						{
							num = -num;
							ActionListTreeControl_Node actionListTreeControl_Node3 = this.mSelectedNode;
							int num7 = this.mSelectedRow;
							ActionListTreeControl_Node treeNext = this.mFirstDisplayNode;
							if (num != 0)
							{
								int num8 = num7 + 1;
								do
								{
									num--;
									ActionListTreeControl_Node treeNext2 = this.GetTreeNext(actionListTreeControl_Node3);
									if (treeNext2 == null)
									{
										break;
									}
									if (num8 == this.mMaxRows)
									{
										treeNext = this.GetTreeNext(treeNext);
									}
									else
									{
										num7++;
										num8++;
									}
									actionListTreeControl_Node3 = treeNext2;
								}
								while (num != 0);
							}
							if (actionListTreeControl_Node3 != this.mSelectedNode)
							{
								this.mFirstDisplayNode = treeNext;
								this.mSelectedRow = num7;
								this.mSelectedNode = actionListTreeControl_Node3;
								this.mSelectedNode_End = actionListTreeControl_Node3;
								this.mSelectedBeginExtended = actionListTreeControl_Node3.ActionIndex;
								this.mSelectedEndExtended = actionListTreeControl_Node3.ActionIndex;
								this.raise_SelectionChanged(this, new EventArgs());
								base.Invalidate();
							}
						}
					}
				}
			}
		}

		private void Script_ActionListTreeControl_DragOver(object sender, DragEventArgs e)
		{
			Point p = new Point(e.X, e.Y);
			Point point = base.PointToClient(p);
			this.UpdateMouseTarget(point.X, point.Y);
		}

		private void Script_ActionListTreeControl_DragDrop(object sender, DragEventArgs e)
		{
			if (this.mMouseTargetNode != null && this.mMouseTargetTextElement != null)
			{
				this.raise_MouseTargetOnDrop(this, new EventArgs());
			}
		}

		private void Script_ActionListTreeControl_OnTimed(object sender, ElapsedEventArgs e)
		{
			if (this.MouseLeftHeld)
			{
				Point mousePosition = Control.MousePosition;
				Point point = base.PointToClient(mousePosition);
				if (point.Y < 0)
				{
					ActionListTreeControl_Node treePrev = this.GetTreePrev(this.mSelectedNode);
					if (treePrev != null)
					{
						if (this.mFirstDisplayNode == this.mSelectedNode)
						{
							this.mFirstDisplayNode = treePrev;
						}
						else
						{
							this.mSelectedRow--;
						}
						this.mSelectedNode = treePrev;
						this.raise_SelectionChanged(this, new EventArgs());
						base.Invalidate();
					}
				}
				else
				{
					Rectangle clientRectangle = base.ClientRectangle;
					if (point.Y >= clientRectangle.Height)
					{
						ActionListTreeControl_Node treeNext = this.GetTreeNext(this.mSelectedNode);
						if (treeNext != null)
						{
							this.mSelectedNode = treeNext;
							int num = this.mSelectedRow + 1;
							if (num == this.mMaxRows)
							{
								this.mFirstDisplayNode = this.GetTreeNext(this.mFirstDisplayNode);
							}
							else
							{
								this.mSelectedRow = num;
							}
							this.raise_SelectionChanged(this, new EventArgs());
							base.Invalidate();
						}
					}
				}
				this.ScrollTimer.Start();
			}
		}

		private void UpdateMouseTarget(int x, int y)
		{
			if (this.mSelectedNode != null && !this.Editing)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				int num = -this.mFrameSize;
				int expr_2B = num;
				clientRectangle.Inflate(expr_2B, expr_2B);
				if (clientRectangle.Contains(x, y))
				{
					int steps = (y - clientRectangle.Y) / this.mRowHeight;
					ActionListTreeControl_Node actionListTreeControl_Node = this.GetTreeNext(this.mFirstDisplayNode, steps);
					if (actionListTreeControl_Node == null)
					{
						if (this.mMouseTargetNode != null)
						{
							this.mMouseTargetNode = null;
							this.mMouseTargetTextElement = null;
							this.raise_MouseTargetChanged(this, new EventArgs());
						}
					}
					else
					{
						ActionListTreeControl_Node_TextElement actionListTreeControl_Node_TextElement = null;
						int num2 = 0;
						if (0 < actionListTreeControl_Node.GetNumberOfTextElements())
						{
							ActionListTreeControl_Node_TextElement textElement;
							do
							{
								textElement = actionListTreeControl_Node.GetTextElement(num2);
								if (textElement.Type == 1 && textElement.GetArea().Contains(x, y))
								{
									goto IL_C9;
								}
								num2++;
							}
							while (num2 < actionListTreeControl_Node.GetNumberOfTextElements());
							goto IL_CB;
							IL_C9:
							actionListTreeControl_Node_TextElement = textElement;
						}
						IL_CB:
						if (actionListTreeControl_Node_TextElement == null)
						{
							actionListTreeControl_Node = null;
						}
						if (this.mMouseTargetNode != actionListTreeControl_Node || this.mMouseTargetTextElement != actionListTreeControl_Node_TextElement)
						{
							this.mMouseTargetNode = actionListTreeControl_Node;
							this.mMouseTargetTextElement = actionListTreeControl_Node_TextElement;
							this.raise_MouseTargetChanged(this, new EventArgs());
							base.Invalidate();
						}
					}
				}
			}
		}

		protected void raise_SelectionChanged(object i1, EventArgs i2)
		{
			EventHandler selectionChanged = this.SelectionChanged;
			if (selectionChanged != null)
			{
				selectionChanged(i1, i2);
			}
		}

		protected void raise_ExpandChanged(object i1, EventArgs i2)
		{
			EventHandler expandChanged = this.ExpandChanged;
			if (expandChanged != null)
			{
				expandChanged(i1, i2);
			}
		}

		protected void raise_MouseTargetChanged(object i1, EventArgs i2)
		{
			EventHandler mouseTargetChanged = this.MouseTargetChanged;
			if (mouseTargetChanged != null)
			{
				mouseTargetChanged(i1, i2);
			}
		}

		protected void raise_MouseTargetDoubleClicked(object i1, EventArgs i2)
		{
			EventHandler mouseTargetDoubleClicked = this.MouseTargetDoubleClicked;
			if (mouseTargetDoubleClicked != null)
			{
				mouseTargetDoubleClicked(i1, i2);
			}
		}

		protected void raise_MouseTargetOnDrop(object i1, EventArgs i2)
		{
			EventHandler mouseTargetOnDrop = this.MouseTargetOnDrop;
			if (mouseTargetOnDrop != null)
			{
				mouseTargetOnDrop(i1, i2);
			}
		}

		protected void raise_TextEditingRequest(object i1, EventArgs i2)
		{
			EventHandler textEditingRequest = this.TextEditingRequest;
			if (textEditingRequest != null)
			{
				textEditingRequest(i1, i2);
			}
		}

		protected void raise_TextEditingFinished(object i1, EventArgs i2)
		{
			EventHandler textEditingFinished = this.TextEditingFinished;
			if (textEditingFinished != null)
			{
				textEditingFinished(i1, i2);
			}
		}

		protected void raise_ListSelectingFinished(object i1, EventArgs i2)
		{
			EventHandler listSelectingFinished = this.ListSelectingFinished;
			if (listSelectingFinished != null)
			{
				listSelectingFinished(i1, i2);
			}
		}
	}
}
