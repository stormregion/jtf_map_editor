using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Script_ActionListTree_Node
{
	public class ActionListTreeControl_Node : Component
	{
		private ActionListTreeControl_Node mParent;

		private ActionListTreeControl_Node mPrev;

		private ActionListTreeControl_Node mNext;

		private string mText;

		private ArrayList TextElements;

		private ArrayList HeaderNodes;

		private ArrayList Nodes;

		private bool mExpanded;

		private bool mHeaderNode;

		private int mActionIndex;

		private int mConditionIndex;

		public ActionListTreeControl_Node Next
		{
			get
			{
				return this.mNext;
			}
		}

		public ActionListTreeControl_Node Prev
		{
			get
			{
				return this.mPrev;
			}
		}

		public ActionListTreeControl_Node Parent
		{
			get
			{
				return this.mParent;
			}
		}

		public int ConditionIndex
		{
			get
			{
				return this.mConditionIndex;
			}
			set
			{
				this.mConditionIndex = value;
			}
		}

		public int ActionIndex
		{
			get
			{
				return this.mActionIndex;
			}
			set
			{
				this.mActionIndex = value;
			}
		}

		public bool Empty
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				int num;
				if (this.GetNumberOfHeaderNodes() == 0 && this.GetNumberOfNodes() == 0)
				{
					num = 1;
				}
				else
				{
					num = 0;
				}
				return (byte)num != 0;
			}
		}

		public bool HeaderNode
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.mHeaderNode;
			}
		}

		public bool Expanded
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return this.mExpanded;
			}
		}

		public string Text
		{
			get
			{
				return this.mText;
			}
		}

		public ActionListTreeControl_Node(string text, [MarshalAs(UnmanagedType.U1)] bool formattedtext)
		{
			this.mText = text;
			this.mParent = null;
			this.mPrev = null;
			this.mNext = null;
			this.TextElements = new ArrayList();
			this.HeaderNodes = new ArrayList();
			this.Nodes = new ArrayList();
			this.mExpanded = false;
			this.mHeaderNode = false;
			this.mActionIndex = 0;
			this.mConditionIndex = 0;
			if (formattedtext)
			{
				this.ParseFormattedText();
			}
		}

		public int GetNumberOfTextElements()
		{
			return this.TextElements.Count;
		}

		public ActionListTreeControl_Node_TextElement GetTextElement(int idx)
		{
			return this.TextElements[idx];
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public bool AddHeaderNode(ActionListTreeControl_Node headernode)
		{
			if (this.HeaderNode)
			{
				return false;
			}
			if (!headernode.Empty)
			{
				return false;
			}
			if (this.HeaderNodes.Count != 0)
			{
				this.GetHeaderNode(this.HeaderNodes.Count - 1).mNext = headernode;
				headernode.mPrev = this.GetHeaderNode(this.HeaderNodes.Count - 1);
			}
			this.HeaderNodes.Add(headernode);
			headernode.mParent = this;
			headernode.mHeaderNode = true;
			return true;
		}

		public int GetNumberOfHeaderNodes()
		{
			return this.HeaderNodes.Count;
		}

		public ActionListTreeControl_Node GetHeaderNode(int idx)
		{
			return this.HeaderNodes[idx];
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public bool AddNode(ActionListTreeControl_Node node)
		{
			if (this.HeaderNode)
			{
				return false;
			}
			if (this.Nodes.Count != 0)
			{
				this.GetNode(this.Nodes.Count - 1).mNext = node;
				node.mPrev = this.GetNode(this.Nodes.Count - 1);
			}
			this.Nodes.Add(node);
			node.mParent = this;
			node.mHeaderNode = false;
			return true;
		}

		public int GetNumberOfNodes()
		{
			return this.Nodes.Count;
		}

		public ActionListTreeControl_Node GetNode(int idx)
		{
			return this.Nodes[idx];
		}

		public void Clear()
		{
			this.HeaderNodes = new ArrayList();
			this.Nodes = new ArrayList();
		}

		public void Expand()
		{
			this.mExpanded = true;
		}

		public void Close()
		{
			this.mExpanded = false;
		}

		public void ToggleExpand()
		{
			int num = (!this.mExpanded) ? 1 : 0;
			this.mExpanded = (num != 0);
		}

		protected void ParseFormattedText()
		{
			int num = 0;
			if (0 < this.Text.Length)
			{
				while (true)
				{
					int num2;
					switch (this.Text[num])
					{
					case '0':
						num2 = 5;
						goto IL_14E;
					case 'f':
						num2 = 3;
						goto IL_14E;
					case 'i':
						num2 = 4;
						goto IL_14E;
					case 'n':
						num2 = 0;
						goto IL_14E;
					case 'p':
						num2 = 1;
						goto IL_14E;
					case 'r':
						num2 = 2;
						goto IL_14E;
					}
					IL_2A5:
					num++;
					if (num >= this.Text.Length)
					{
						break;
					}
					continue;
					IL_14E:
					num++;
					if (num == this.Text.Length || this.Text[num] != ':')
					{
						break;
					}
					num++;
					if (num == this.Text.Length)
					{
						break;
					}
					int num3 = 0;
					if (num2 == 1)
					{
						if (this.Text[num] < '0' || '9' < this.Text[num])
						{
							break;
						}
						if (num < this.Text.Length)
						{
							while ('0' <= this.Text[num] && this.Text[num] <= '9')
							{
								num3 = num3 * 10 + (int)this.Text[num] - 48;
								num++;
								if (num >= this.Text.Length)
								{
									break;
								}
							}
						}
						if (num == this.Text.Length || this.Text[num] != ':')
						{
							break;
						}
						num++;
						if (num == this.Text.Length)
						{
							break;
						}
					}
					int num4 = num;
					if (num >= this.Text.Length)
					{
						break;
					}
					while (this.Text[num] != ',')
					{
						num++;
						if (num >= this.Text.Length)
						{
							break;
						}
					}
					if (num == num4)
					{
						break;
					}
					if (num2 != 5)
					{
						ActionListTreeControl_Node_TextElement value = new ActionListTreeControl_Node_TextElement(this.Text.Substring(num4, num - num4), num2, num3);
						this.TextElements.Add(value);
						goto IL_2A5;
					}
					goto IL_2A5;
				}
			}
		}
	}
}
