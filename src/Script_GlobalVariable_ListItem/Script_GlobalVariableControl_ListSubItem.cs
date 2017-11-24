using System;
using System.ComponentModel;

namespace Script_GlobalVariable_ListItem
{
	public class Script_GlobalVariableControl_ListSubItem : Component
	{
		private string mText;

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

		public Script_GlobalVariableControl_ListSubItem()
		{
			this.mText = "";
		}
	}
}
