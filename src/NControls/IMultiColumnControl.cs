using System;
using System.Collections;

namespace NControls
{
	public interface IMultiColumnControl
	{
		ArrayList ColumnDatas
		{
			get;
		}

		void ColumnsResized();
	}
}
