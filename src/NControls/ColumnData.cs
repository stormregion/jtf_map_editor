using System;

namespace NControls
{
	internal class ColumnData : ColumnItem
	{
		public float StartX;

		public float Width;

		public float Proportion;

		public ColumnData(string name, int minwidth) : base(name, minwidth)
		{
		}
	}
}
