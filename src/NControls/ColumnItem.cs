using System;

namespace NControls
{
	public class ColumnItem
	{
		public string Name;

		public float MinWidth;

		public ColumnItem(string name, int minwidth)
		{
			this.Name = string.Copy(name);
			this.MinWidth = (float)minwidth;
		}
	}
}
