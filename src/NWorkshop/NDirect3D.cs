using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NDirect3D
	{
		private Device D3DDevice;

		private PresentParameters[] PresentParams;

		private VertexBuffer VBuffer;

		private CustomVertex.TransformedColored[] LineVertices;

		private CustomVertex.TransformedColored[] RectangleVertices;

		private CustomVertex.TransformedColored[] FilledRectangleVertices;

		private Microsoft.DirectX.Direct3D.Font D3DFont;

		private System.Drawing.Font SysFont;

		private int StartVertexIndex;

		private int EndVertexIndex;

		private int LastOperation;

		private void DeviceResetEvent(object sender, EventArgs e)
		{
			Microsoft.DirectX.Direct3D.Font d3DFont = this.D3DFont;
			if (d3DFont != null)
			{
				d3DFont.OnResetDevice();
			}
			ValueType valueType = default(CustomVertex.TransformedColored);
			this.VBuffer = new VertexBuffer(valueType.GetType(), 4096, this.D3DDevice, Usage.Dynamic, VertexFormats.Diffuse | VertexFormats.Transformed, Pool.Default);
			this.LineVertices = new CustomVertex.TransformedColored[2];
			this.RectangleVertices = new CustomVertex.TransformedColored[8];
			this.FilledRectangleVertices = new CustomVertex.TransformedColored[6];
			this.D3DDevice.VertexFormat = (VertexFormats.Diffuse | VertexFormats.Transformed);
			this.D3DDevice.SetStreamSource(0, this.VBuffer, 0);
			this.EndVertexIndex = 0;
			this.StartVertexIndex = 0;
			this.LastOperation = 0;
		}

		private void DeviceResizeEvent(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
		}

		public NDirect3D(Control control)
		{
			this.PresentParams = new PresentParameters[1];
			this.PresentParams[0] = new PresentParameters();
			this.PresentParams[0].Windowed = true;
			this.PresentParams[0].SwapEffect = SwapEffect.Discard;
			this.D3DDevice = new Device(0, DeviceType.Hardware, control, CreateFlags.SoftwareVertexProcessing, this.PresentParams);
			this.D3DDevice.DeviceReset += new EventHandler(this.DeviceResetEvent);
			this.D3DDevice.DeviceResizing += new CancelEventHandler(this.DeviceResizeEvent);
			System.Drawing.Font font = new System.Drawing.Font("Arial", 8f);
			this.SysFont = font;
			this.D3DFont = new Microsoft.DirectX.Direct3D.Font(this.D3DDevice, font);
			this.D3DDevice.Reset(this.PresentParams);
		}

		public void DisposeD3DX()
		{
			Microsoft.DirectX.Direct3D.Font d3DFont = this.D3DFont;
			if (d3DFont != null)
			{
				d3DFont.Dispose();
			}
		}

		public void Clear(Color color)
		{
			this.D3DDevice.Clear(ClearFlags.Target, color, 1f, 0);
		}

		public void Clear()
		{
			Color blue = Color.Blue;
			this.D3DDevice.Clear(ClearFlags.Target, blue, 1f, 0);
		}

		public void Present()
		{
			this.D3DDevice.Present();
		}

		public void BeginScene()
		{
			this.D3DDevice.BeginScene();
			this.D3DDevice.SetStreamSource(0, this.VBuffer, 0);
		}

		public void EndScene()
		{
			this.Flush(false);
			this.D3DDevice.EndScene();
		}

		public void Reset()
		{
			this.D3DDevice.Reset(this.PresentParams);
		}

		public void Resize(int width, int height)
		{
			this.PresentParams[0].BackBufferWidth = width;
			this.PresentParams[0].BackBufferHeight = height;
			this.D3DDevice.Reset(this.PresentParams);
		}

		public void Flush([MarshalAs(UnmanagedType.U1)] bool restart)
		{
			if (this.StartVertexIndex < this.EndVertexIndex)
			{
				this.D3DDevice.VertexFormat = (VertexFormats.Diffuse | VertexFormats.Transformed);
				int lastOperation = this.LastOperation;
				if (lastOperation != 1)
				{
					if (lastOperation == 2)
					{
						int startVertexIndex = this.StartVertexIndex;
						this.D3DDevice.DrawPrimitives(PrimitiveType.TriangleList, startVertexIndex, (this.EndVertexIndex - startVertexIndex) / 3);
					}
				}
				else
				{
					int startVertexIndex2 = this.StartVertexIndex;
					this.D3DDevice.DrawPrimitives(PrimitiveType.LineList, startVertexIndex2, this.EndVertexIndex - startVertexIndex2 >> 1);
				}
			}
			this.LastOperation = 0;
			if (restart)
			{
				this.EndVertexIndex = 0;
				this.StartVertexIndex = 0;
			}
			else
			{
				this.StartVertexIndex = this.EndVertexIndex;
			}
		}

		public void DrawLine(int color, int x1, int y1, int x2, int y2)
		{
			int lastOperation = this.LastOperation;
			if (1 != lastOperation && 0 != lastOperation)
			{
				this.Flush(false);
			}
			int endVertexIndex = this.EndVertexIndex;
			GraphicsStream arg_13F_0;
			if (4096 >= endVertexIndex + 2)
			{
				uint num = (uint)sizeof(CustomVertex.TransformedColored);
				arg_13F_0 = this.VBuffer.Lock((int)(num * (uint)endVertexIndex), (int)((int)num << 1), LockFlags.NoOverwrite);
			}
			else
			{
				this.Flush(true);
				uint num = (uint)sizeof(CustomVertex.TransformedColored);
				arg_13F_0 = this.VBuffer.Lock(this.EndVertexIndex * (int)num, (int)((int)num << 1), LockFlags.Discard);
			}
			this.LineVertices[1].Z = 0f;
			this.LineVertices[0].Z = 0f;
			this.LineVertices[1].Rhw = 1f;
			this.LineVertices[0].Rhw = 1f;
			this.LineVertices[1].Color = color;
			this.LineVertices[0].Color = color;
			this.LineVertices[0].X = (float)x1;
			this.LineVertices[0].Y = (float)y1;
			this.LineVertices[1].X = (float)x2;
			this.LineVertices[1].Y = (float)y2;
			arg_13F_0.Write(this.LineVertices);
			this.VBuffer.Unlock();
			this.EndVertexIndex += 2;
			this.LastOperation = 1;
		}

		public void DrawLine(Color color, int x1, int y1, int x2, int y2)
		{
			this.DrawLine(color.ToArgb(), x1, y1, x2, y2);
		}

		public void FillRectangle(Color color, RectangleF rect)
		{
			this.FillRectangle(color, rect.X, rect.Y, rect.Width, rect.Height);
		}

		public void FillRectangle(Color color, Rectangle rect)
		{
			this.FillRectangle(color, (float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
		}

		public void FillRectangle(Color color, int x, int y, int width, int height)
		{
			this.FillRectangle(color, (float)x, (float)y, (float)width, (float)height);
		}

		public void FillRectangle(Color color, float x, float y, float width, float height)
		{
			int lastOperation = this.LastOperation;
			if (2 != lastOperation && 0 != lastOperation)
			{
				this.Flush(false);
			}
			int endVertexIndex = this.EndVertexIndex;
			GraphicsStream arg_324_0;
			if (4096 >= endVertexIndex + 6)
			{
				uint num = (uint)sizeof(CustomVertex.TransformedColored);
				arg_324_0 = this.VBuffer.Lock((int)(num * (uint)endVertexIndex), (int)(num * 6u), LockFlags.NoOverwrite);
			}
			else
			{
				this.Flush(true);
				uint num = (uint)sizeof(CustomVertex.TransformedColored);
				arg_324_0 = this.VBuffer.Lock(this.EndVertexIndex * (int)num, (int)(num * 6u), LockFlags.Discard);
			}
			this.FilledRectangleVertices[5].Z = 0f;
			this.FilledRectangleVertices[4].Z = 0f;
			this.FilledRectangleVertices[3].Z = 0f;
			this.FilledRectangleVertices[2].Z = 0f;
			this.FilledRectangleVertices[1].Z = 0f;
			this.FilledRectangleVertices[0].Z = 0f;
			this.FilledRectangleVertices[5].Rhw = 1f;
			this.FilledRectangleVertices[4].Rhw = 1f;
			this.FilledRectangleVertices[3].Rhw = 1f;
			this.FilledRectangleVertices[2].Rhw = 1f;
			this.FilledRectangleVertices[1].Rhw = 1f;
			this.FilledRectangleVertices[0].Rhw = 1f;
			this.FilledRectangleVertices[5].Color = color.ToArgb();
			CustomVertex.TransformedColored[] filledRectangleVertices = this.FilledRectangleVertices;
			filledRectangleVertices[4].Color = filledRectangleVertices[5].Color;
			CustomVertex.TransformedColored[] filledRectangleVertices2 = this.FilledRectangleVertices;
			filledRectangleVertices2[3].Color = filledRectangleVertices2[4].Color;
			CustomVertex.TransformedColored[] filledRectangleVertices3 = this.FilledRectangleVertices;
			filledRectangleVertices3[2].Color = filledRectangleVertices3[3].Color;
			CustomVertex.TransformedColored[] filledRectangleVertices4 = this.FilledRectangleVertices;
			filledRectangleVertices4[1].Color = filledRectangleVertices4[2].Color;
			CustomVertex.TransformedColored[] filledRectangleVertices5 = this.FilledRectangleVertices;
			filledRectangleVertices5[0].Color = filledRectangleVertices5[1].Color;
			float x2 = x + width;
			this.FilledRectangleVertices[0].X = x2;
			this.FilledRectangleVertices[0].Y = y;
			this.FilledRectangleVertices[1].X = x2;
			float y2 = y + height;
			this.FilledRectangleVertices[1].Y = y2;
			this.FilledRectangleVertices[2].X = x;
			this.FilledRectangleVertices[2].Y = y;
			this.FilledRectangleVertices[3].X = x2;
			this.FilledRectangleVertices[3].Y = y2;
			this.FilledRectangleVertices[4].X = x;
			this.FilledRectangleVertices[4].Y = y2;
			this.FilledRectangleVertices[5].X = x;
			this.FilledRectangleVertices[5].Y = y;
			arg_324_0.Write(this.FilledRectangleVertices);
			this.VBuffer.Unlock();
			this.EndVertexIndex += 6;
			this.LastOperation = 2;
		}

		public void DrawRectangle(Color color, RectangleF rect)
		{
			this.DrawRectangle(color, rect.X, rect.Y, rect.Width, rect.Height);
		}

		public void DrawRectangle(Color color, Rectangle rect)
		{
			this.DrawRectangle(color, (float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height);
		}

		public void DrawRectangle(Color color, int x, int y, int width, int height)
		{
			this.DrawRectangle(color, (float)x, (float)y, (float)width, (float)height);
		}

		public void DrawRectangle(Color color, float x, float y, float width, float height)
		{
			int lastOperation = this.LastOperation;
			if (1 != lastOperation && 0 != lastOperation)
			{
				this.Flush(false);
			}
			int endVertexIndex = this.EndVertexIndex;
			GraphicsStream arg_408_0;
			if (4096 >= endVertexIndex + 8)
			{
				uint num = (uint)sizeof(CustomVertex.TransformedColored);
				arg_408_0 = this.VBuffer.Lock((int)(num * (uint)endVertexIndex), (int)((int)num << 3), LockFlags.NoOverwrite);
			}
			else
			{
				this.Flush(true);
				uint num = (uint)sizeof(CustomVertex.TransformedColored);
				arg_408_0 = this.VBuffer.Lock(this.EndVertexIndex * (int)num, (int)((int)num << 3), LockFlags.Discard);
			}
			this.RectangleVertices[7].Z = 0f;
			this.RectangleVertices[6].Z = 0f;
			this.RectangleVertices[5].Z = 0f;
			this.RectangleVertices[4].Z = 0f;
			this.RectangleVertices[3].Z = 0f;
			this.RectangleVertices[2].Z = 0f;
			this.RectangleVertices[1].Z = 0f;
			this.RectangleVertices[0].Z = 0f;
			this.RectangleVertices[7].Rhw = 1f;
			this.RectangleVertices[6].Rhw = 1f;
			this.RectangleVertices[5].Rhw = 1f;
			this.RectangleVertices[4].Rhw = 1f;
			this.RectangleVertices[3].Rhw = 1f;
			this.RectangleVertices[2].Rhw = 1f;
			this.RectangleVertices[1].Rhw = 1f;
			this.RectangleVertices[0].Rhw = 1f;
			this.RectangleVertices[7].Color = color.ToArgb();
			CustomVertex.TransformedColored[] rectangleVertices = this.RectangleVertices;
			rectangleVertices[6].Color = rectangleVertices[7].Color;
			CustomVertex.TransformedColored[] rectangleVertices2 = this.RectangleVertices;
			rectangleVertices2[5].Color = rectangleVertices2[6].Color;
			CustomVertex.TransformedColored[] rectangleVertices3 = this.RectangleVertices;
			rectangleVertices3[4].Color = rectangleVertices3[5].Color;
			CustomVertex.TransformedColored[] rectangleVertices4 = this.RectangleVertices;
			rectangleVertices4[3].Color = rectangleVertices4[4].Color;
			CustomVertex.TransformedColored[] rectangleVertices5 = this.RectangleVertices;
			rectangleVertices5[2].Color = rectangleVertices5[3].Color;
			CustomVertex.TransformedColored[] rectangleVertices6 = this.RectangleVertices;
			rectangleVertices6[1].Color = rectangleVertices6[2].Color;
			CustomVertex.TransformedColored[] rectangleVertices7 = this.RectangleVertices;
			rectangleVertices7[0].Color = rectangleVertices7[1].Color;
			this.RectangleVertices[0].X = x;
			this.RectangleVertices[0].Y = y;
			float x2 = x + width;
			this.RectangleVertices[1].X = x2;
			this.RectangleVertices[1].Y = y;
			this.RectangleVertices[2].X = x2;
			this.RectangleVertices[2].Y = y;
			this.RectangleVertices[3].X = x2;
			float y2 = y + height;
			this.RectangleVertices[3].Y = y2;
			this.RectangleVertices[4].X = x2;
			this.RectangleVertices[4].Y = y2;
			this.RectangleVertices[5].X = x;
			this.RectangleVertices[5].Y = y2;
			this.RectangleVertices[6].X = x;
			this.RectangleVertices[6].Y = y2;
			this.RectangleVertices[7].X = x;
			this.RectangleVertices[7].Y = y;
			arg_408_0.Write(this.RectangleVertices);
			this.VBuffer.Unlock();
			this.EndVertexIndex += 8;
			this.LastOperation = 1;
		}

		public void TextOutA(string @string, int x, int y, Color color)
		{
			this.D3DFont.DrawText(null, @string, x, y, color);
		}
	}
}
