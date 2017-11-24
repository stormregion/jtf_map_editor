using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Script_ActionListTree_Node
{
	public class ActionListTreeControl_Node_TextElement : Component
	{
		private string mText;

		private int mType;

		private Rectangle Area;

		private int mParamIndex;

		public bool Fixed
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return ((this.Type == 3) ? 1 : 0) != 0;
			}
		}

		public bool Parameter
		{
			[return: MarshalAs(UnmanagedType.U1)]
			get
			{
				return ((this.Type == 1) ? 1 : 0) != 0;
			}
		}

		public int Type
		{
			get
			{
				return this.mType;
			}
		}

		public string Text
		{
			get
			{
				return this.mText;
			}
			set
			{
				this.mText = value;
			}
		}

		public int ParameterIndex
		{
			get
			{
				return this.mParamIndex;
			}
		}

		public ActionListTreeControl_Node_TextElement(string text, int type, int paramindex)
		{
			this.mText = text;
			this.mType = type;
			this.mParamIndex = paramindex;
		}

		public unsafe Rectangle* GetArea()
		{
			return ref this.Area;
		}

		public unsafe void SetArea(Rectangle* area)
		{
			this.Area = *area;
		}
	}
}
