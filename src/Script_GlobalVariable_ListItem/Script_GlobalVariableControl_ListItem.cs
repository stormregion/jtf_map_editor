using System;
using System.ComponentModel;

namespace Script_GlobalVariable_ListItem
{
	public class Script_GlobalVariableControl_ListItem : Component
	{
		private Script_GlobalVariableControl_ListSubItem[] mSubItems;

		public Script_GlobalVariableControl_ListSubItem[] SubItems
		{
			get
			{
				return this.mSubItems;
			}
			set
			{
				this.mSubItems = value;
			}
		}

		public Script_GlobalVariableControl_ListItem()
		{
			this.mSubItems = new Script_GlobalVariableControl_ListSubItem[0];
		}
	}
}
