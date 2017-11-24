using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace NControls
{
	public class HeaderControl : DoubleBuffControl
	{
		private IMultiColumnControl ColumnControl;

		private int DragIndex;

		private int DragFromX;

		private Brush ColumnHeaderLightBorderBrush;

		private Brush ColumnHeaderDarkBorderBrush;

		private Brush ColumnHeaderMediumBorderBrush;

		private Brush ColumnHeaderBackgroundBrush;

		private Brush ColumnHeaderTextBrush;

		public ArrayList ColumnDatas
		{
			get
			{
				return this.ColumnControl.ColumnDatas;
			}
		}

		public HeaderControl(IMultiColumnControl multicolumncontrol)
		{
			this.DragIndex = -1;
			Color color = Color.FromKnownColor(KnownColor.ControlLightLight);
			this.ColumnHeaderLightBorderBrush = new SolidBrush(color);
			Color color2 = Color.FromKnownColor(KnownColor.ControlDark);
			this.ColumnHeaderMediumBorderBrush = new SolidBrush(color2);
			Color color3 = Color.FromKnownColor(KnownColor.ControlDarkDark);
			this.ColumnHeaderDarkBorderBrush = new SolidBrush(color3);
			Color color4 = Color.FromKnownColor(KnownColor.Control);
			this.ColumnHeaderBackgroundBrush = new SolidBrush(color4);
			Color color5 = Color.FromKnownColor(KnownColor.ControlText);
			this.ColumnHeaderTextBrush = new SolidBrush(color5);
			this.ColumnControl = multicolumncontrol;
			base.Paint += new PaintEventHandler(this.HeaderPaint);
			base.MouseDown += new MouseEventHandler(this.HeaderMouseDown);
			base.MouseUp += new MouseEventHandler(this.HeaderMouseUp);
			base.MouseMove += new MouseEventHandler(this.HeaderMouseMove);
		}

		public void RecalcColumnDatas()
		{
			ColumnData columnData = null;
			if (this.ColumnDatas != null)
			{
				IEnumerator enumerator = this.ColumnDatas.GetEnumerator();
				float num = 0f;
				float num2 = 0f;
				float num3 = (float)base.Width;
				if (enumerator.MoveNext())
				{
					do
					{
						ColumnData columnData2 = enumerator.Current as ColumnData;
						num3 -= columnData2.MinWidth;
						num2 = columnData2.Proportion + num2;
					}
					while (enumerator.MoveNext());
				}
				if (num3 < 0f)
				{
					base.Width = (int)((double)((float)base.Width - num3));
					num3 = 0f;
				}
				enumerator.Reset();
				if (enumerator.MoveNext())
				{
					float num4 = 1f / num2;
					do
					{
						columnData = (enumerator.Current as ColumnData);
						columnData.StartX = num;
						float num5 = columnData.Proportion * num4 * num3 + columnData.MinWidth;
						columnData.Width = num5;
						num = num5 + num;
					}
					while (enumerator.MoveNext());
				}
				float num6 = columnData.Width + columnData.StartX;
				if (num6 > (float)base.Width)
				{
					columnData.Width = (float)base.Width - columnData.StartX;
				}
			}
		}

		public int ChangeColumnStartX(int column_index, int dx)
		{
			IEnumerator enumerator = this.ColumnDatas.GetEnumerator();
			float num = (float)base.Width;
			if (enumerator.MoveNext())
			{
				do
				{
					ColumnData columnData = enumerator.Current as ColumnData;
					num -= columnData.MinWidth;
				}
				while (enumerator.MoveNext());
			}
			if (num <= 0f)
			{
				return 0;
			}
			ColumnData columnData2 = this.ColumnDatas[column_index] as ColumnData;
			float num2 = (float)base.Width - columnData2.StartX;
			float num3 = 0f;
			float num4 = 0f;
			enumerator = this.ColumnDatas.GetRange(column_index, this.ColumnDatas.Count - column_index).GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					ColumnData columnData3 = enumerator.Current as ColumnData;
					num3 = columnData3.MinWidth + num3;
					num4 = columnData3.Proportion + num4;
				}
				while (enumerator.MoveNext());
				if (num4 != 0f)
				{
					goto IL_DE;
				}
			}
			num4 = 1f;
			IL_DE:
			num2 -= num3;
			float num5 = (float)dx;
			float num6 = num2 - num5;
			if (num6 < 0f)
			{
				dx = (int)((double)num2);
				if (column_index > 0)
				{
					ColumnData columnData4 = this.ColumnDatas[column_index - 1] as ColumnData;
					float num7 = columnData4.Width + (float)dx;
					if (num7 >= columnData4.MinWidth)
					{
						columnData4.Width = num7;
						columnData4.Proportion = (num7 - columnData4.MinWidth) / num;
					}
					else
					{
						if (columnData4.Width <= columnData4.MinWidth)
						{
							return 0;
						}
						dx = (int)((double)(columnData4.MinWidth - columnData4.Width));
						float minWidth = columnData4.MinWidth;
						columnData4.Width = minWidth;
						columnData4.Proportion = (minWidth - columnData4.MinWidth) / num;
					}
				}
				float num8 = columnData2.StartX + (float)dx;
				enumerator = this.ColumnDatas.GetRange(column_index, this.ColumnDatas.Count - column_index).GetEnumerator();
				if (enumerator.MoveNext())
				{
					do
					{
						ColumnData columnData5 = enumerator.Current as ColumnData;
						columnData5.StartX = num8;
						float minWidth2 = columnData5.MinWidth;
						columnData5.Width = minWidth2;
						num8 = minWidth2 + num8;
					}
					while (enumerator.MoveNext());
				}
				return dx;
			}
			num2 = num6;
			if (num2 > 0f)
			{
				if (column_index > 0)
				{
					ColumnData columnData6 = this.ColumnDatas[column_index - 1] as ColumnData;
					float num9 = columnData6.Width + num5;
					if (num9 >= columnData6.MinWidth)
					{
						columnData6.Width = num9;
						columnData6.Proportion = (num9 - columnData6.MinWidth) / num;
					}
					else
					{
						if (columnData6.Width <= columnData6.MinWidth)
						{
							return 0;
						}
						num2 = num5 + num2;
						dx = (int)((double)(columnData6.MinWidth - columnData6.Width));
						num5 = (float)dx;
						num2 -= num5;
						float minWidth3 = columnData6.MinWidth;
						columnData6.Width = minWidth3;
						columnData6.Proportion = (minWidth3 - columnData6.MinWidth) / num;
					}
				}
				float num10 = columnData2.StartX + num5;
				enumerator = this.ColumnDatas.GetRange(column_index, this.ColumnDatas.Count - column_index).GetEnumerator();
				if (enumerator.MoveNext())
				{
					float num11 = 1f / num4;
					float num12 = 1f / num;
					do
					{
						ColumnData columnData7 = enumerator.Current as ColumnData;
						columnData7.StartX = num10;
						float num13 = columnData7.Proportion * num11 * num2 + columnData7.MinWidth;
						columnData7.Width = num13;
						columnData7.Proportion = (num13 - columnData7.MinWidth) * num12;
						num10 = columnData7.Width + num10;
					}
					while (enumerator.MoveNext());
				}
				return dx;
			}
			return 0;
		}

		private void HeaderPaint(object sender, PaintEventArgs e)
		{
			IEnumerator enumerator = this.ColumnDatas.GetEnumerator();
			float num = 0f;
			if (enumerator.MoveNext())
			{
				do
				{
					ColumnData columnData = enumerator.Current as ColumnData;
					float num2 = columnData.StartX + columnData.Width - num;
					float width = num2 - 3f;
					float x = num + 1f;
					e.Graphics.FillRectangle(this.ColumnHeaderBackgroundBrush, x, 1f, width, 17f);
					float x2 = num + 2f;
					e.Graphics.DrawString(columnData.Name, this.Font, this.ColumnHeaderTextBrush, x2, 2f);
					e.Graphics.FillRectangle(this.ColumnHeaderLightBorderBrush, num, 0f, num2 - 1f, 1f);
					e.Graphics.FillRectangle(this.ColumnHeaderLightBorderBrush, num, 0f, 1f, 20f);
					e.Graphics.FillRectangle(this.ColumnHeaderDarkBorderBrush, x, 19f, num2 - 2f, 1f);
					float num3 = num2 + num;
					e.Graphics.FillRectangle(this.ColumnHeaderDarkBorderBrush, num3 - 1f, 0f, 1f, 20f);
					e.Graphics.FillRectangle(this.ColumnHeaderMediumBorderBrush, x2, 18f, width, 1f);
					e.Graphics.FillRectangle(this.ColumnHeaderMediumBorderBrush, num3 - 2f, 1f, 1f, 18f);
					num = num3;
				}
				while (enumerator.MoveNext());
			}
		}

		private void HeaderMouseDown(object sender, MouseEventArgs e)
		{
			IEnumerator enumerator = this.ColumnDatas.GetEnumerator();
			this.DragIndex = -1;
			int num = 0;
			if (enumerator.MoveNext())
			{
				do
				{
					float num2 = (float)e.X;
					float num3 = num2 - (enumerator.Current as ColumnData).StartX;
					if ((float)Math.Abs((double)num3) < 5f)
					{
						goto IL_55;
					}
					num++;
				}
				while (enumerator.MoveNext());
				return;
				IL_55:
				this.DragIndex = num;
				this.DragFromX = e.X;
				Cursor.Current = Cursors.SizeWE;
			}
		}

		private void HeaderMouseUp(object sender, MouseEventArgs e)
		{
			this.DragIndex = -1;
		}

		private void HeaderMouseMove(object sender, MouseEventArgs e)
		{
			if (this.DragIndex > 0)
			{
				int dx = e.X - this.DragFromX;
				this.DragFromX = this.ChangeColumnStartX(this.DragIndex, dx) + this.DragFromX;
				this.Refresh();
				this.ColumnControl.ColumnsResized();
			}
			else
			{
				Cursor.Current = Cursors.Default;
				IEnumerator enumerator = this.ColumnDatas.GetEnumerator();
				enumerator.MoveNext();
				if (enumerator.MoveNext())
				{
					do
					{
						float num = (float)e.X;
						float num2 = num - (enumerator.Current as ColumnData).StartX;
						if ((float)Math.Abs((double)num2) < 5f)
						{
							goto IL_9D;
						}
					}
					while (enumerator.MoveNext());
					return;
					IL_9D:
					Cursor.Current = Cursors.SizeWE;
				}
			}
		}
	}
}
