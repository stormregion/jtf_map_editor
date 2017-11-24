using System;
using System.ComponentModel;

namespace Script_GlobalVariable_Header
{
	public class Script_GlobalVariableControl_Header : Component
	{
		private string mText;

		private int mWidth;

		public int Width
		{
			get
			{
				return this.mWidth;
			}
			set
			{
				this.mWidth = value;
				if (value < 1)
				{
					this.mWidth = 1;
				}
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

		public Script_GlobalVariableControl_Header()
		{
			this.mText = "";
			this.mWidth = 50;
		}
	}
}
