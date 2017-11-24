using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class Minimap : UserControl
	{
		private struct UnitPoint
		{
			public PointF position;

			public Color color;
		}

		public delegate void MapNeedsRefreshHandler();

		public delegate void MoveCameraHandler(float dx, float dz);

		public delegate void RotateCameraHandler(float alpha);

		private NSolidPanel MapPanel;

		private Container components;

		private unsafe GIScene* MapScene;

		private unsafe GEditorWorld* propWorld;

		private float LevelWidth;

		private float LevelHeight;

		private new float Margin;

		private Point Camera;

		private Point DragPoint;

		private Point Origo;

		private Image Map;

		private Bitmap Backbuffer;

		private PointF TopLeft;

		private PointF TopRight;

		private PointF BottomLeft;

		private PointF BottomRight;

		private SizeF UsefulSize;

		private PointF[] LeftVPs;

		private PointF[] TopVPs;

		private PointF[] RightVPs;

		private PointF[] BottomVPs;

		private Minimap.UnitPoint[] Units;

		private Toolbar ConfigTools;

		private bool AutoRefresh;

		private bool CameraDrag;

		private bool CameraActive;

		private bool CamRotateActive;

		public event Minimap.RotateCameraHandler CameraRotate
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.CameraRotate = Delegate.Combine(this.CameraRotate, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.CameraRotate = Delegate.Remove(this.CameraRotate, value);
			}
		}

		public event Minimap.MoveCameraHandler CameraMove
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.CameraMove = Delegate.Combine(this.CameraMove, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.CameraMove = Delegate.Remove(this.CameraMove, value);
			}
		}

		public event Minimap.MapNeedsRefreshHandler MapNeedsRefresh
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.MapNeedsRefresh = Delegate.Combine(this.MapNeedsRefresh, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.MapNeedsRefresh = Delegate.Remove(this.MapNeedsRefresh, value);
			}
		}

		public unsafe GEditorWorld* World
		{
			set
			{
				this.propWorld = value;
			}
		}

		public unsafe Minimap()
		{
			this.MapNeedsRefresh = null;
			this.CameraMove = null;
			this.CameraRotate = null;
			this.MapScene = null;
			this.LeftVPs = new PointF[0];
			this.TopVPs = new PointF[0];
			this.RightVPs = new PointF[0];
			this.BottomVPs = new PointF[0];
			this.Units = new Minimap.UnitPoint[0];
			this.InitializeComponent();
			NSolidPanel nSolidPanel = new NSolidPanel();
			this.MapPanel = nSolidPanel;
			nSolidPanel.Anchor = AnchorStyles.Top;
			Point location = new Point(0, 0);
			this.MapPanel.Location = location;
			this.MapPanel.Name = "MapPanel";
			Size size = new Size(256, 256);
			this.MapPanel.Size = size;
			this.MapPanel.TabIndex = 0;
			this.MapPanel.MouseUp += new MouseEventHandler(this.MapPanel_MouseUp);
			this.MapPanel.Paint += new PaintEventHandler(this.MapPanel_Paint);
			this.MapPanel.MouseMove += new MouseEventHandler(this.MapPanel_MouseMove);
			this.MapPanel.MouseDown += new MouseEventHandler(this.MapPanel_MouseDown);
			base.Controls.Add(this.MapPanel);
			Size size2 = this.MapPanel.Size;
			this.Backbuffer = new Bitmap(this.MapPanel.Size.Width, size2.Height, PixelFormat.Format24bppRgb);
			Size size3 = this.MapPanel.Size;
			this.Map = new Bitmap(this.MapPanel.Size.Width, size3.Height, PixelFormat.Format24bppRgb);
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0Minimap@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), 24);
			this.ConfigTools = toolbar;
			toolbar.Dock = DockStyle.Bottom;
			this.ConfigTools.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.ConfigTools_ButtonClick);
			Size size4 = new Size(base.Size.Width, 32);
			this.ConfigTools.Size = size4;
			base.Controls.Add(this.ConfigTools);
			this.AutoRefresh = false;
			this.ConfigTools.SetGroupEnable(1, true);
			this.CameraDrag = false;
			this.CameraActive = false;
			this.CamRotateActive = false;
			this.propWorld = null;
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing)
			{
				Container container = this.components;
				if (container != null)
				{
					container.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			Color control = SystemColors.Control;
			this.BackColor = control;
			base.Name = "Minimap";
			Size size = new Size(256, 288);
			base.Size = size;
			base.ResumeLayout(false);
		}

		private unsafe void InternalMapRefresh()
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			GWWeather gWWeather;
			if (this.MapScene != null && base.Size.Height > 0 && base.Size.Width > 0)
			{
				Graphics graphics = Graphics.FromImage(this.Map);
				<Module>.GAWeather.{ctor}(ref gWWeather);
				try
				{
					gWWeather = ref <Module>.??_7GWWeather@@6B@;
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GAWeather.{dtor}), (void*)(&gWWeather));
					throw;
				}
				try
				{
					int num2 = -1;
					while (true)
					{
						GWorld* ptr = <Module>.World + 3436 / sizeof(GWorld);
						GHeap<GWWeather>* ptr2 = ptr;
						int num3 = num2 + 1;
						int num4 = *(ptr2 + 4);
						if (num3 >= num4)
						{
							break;
						}
						int num5 = num3 * 124 + *ptr2;
						while (*num5 != 2147483647)
						{
							num3++;
							num5 += 124;
							if (num3 >= num4)
							{
								goto IL_F8;
							}
						}
						num2 = num3;
						if (num3 < 0)
						{
							break;
						}
						int num6 = num3 * 124;
						if (<Module>.GBaseString<char>.Compare(*(int*)ptr + num6 + 4 + 8, (sbyte*)(&<Module>.??_C@_07MGKHBAOD@minimap?$AA@), true) == null)
						{
							<Module>.GAWeather.=(ref gWWeather, num6 + *(int*)(<Module>.World + 3436 / sizeof(GWorld)) + 4);
						}
					}
					IL_F8:
					GColor gColor;
					*(ref gColor + 8) = 0f;
					*(ref gColor + 4) = 0f;
					gColor = 0f;
					*(ref gColor + 12) = 1f;
					<Module>.GColor.FromHSV(ref gColor, *(ref gWWeather + 16), *(ref gWWeather + 20), *(ref gWWeather + 24));
					GIScene* mapScene = this.MapScene;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), mapScene, ref gColor, *(*(int*)mapScene + 68));
					<Module>.GColor.FromHSV(ref gColor, *(ref gWWeather + 28), *(ref gWWeather + 32), *(ref gWWeather + 36));
					GIScene* mapScene2 = this.MapScene;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), mapScene2, ref gColor, (float)(*(ref gWWeather + 40)) * 0.0174532924f, (float)(*(ref gWWeather + 44)) * -0.0174532924f, *(*(int*)mapScene2 + 72));
					GIScene* mapScene3 = this.MapScene;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), mapScene3, 0f, 0f, 0f, 1000f, 1000f, 0f, 1f, 1f, *(*(int*)mapScene3 + 76));
					GIScene* mapScene4 = this.MapScene;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single,System.Single,System.Single), mapScene4, 0f, 0f, 0f, 0f, 0f, *(*(int*)mapScene4 + 92));
					int num7 = *(int*)this.MapScene + 16;
					GImage* ptr3 = calli(GImage* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Single,System.Single,System.Single), this.MapScene, (int)((double)this.UsefulSize.Width), (int)((double)this.UsefulSize.Height), 1f, 600f, 60f, *num7);
					<Module>.GWorld.UpdateWeather(<Module>.World);
					Bitmap bitmap = null;
					try
					{
						IntPtr hbitmap = new IntPtr(<Module>.GImage.CreateHBitmap(ptr3));
						bitmap = Image.FromHbitmap(hbitmap);
						goto IL_2D5;
					}
					uint exceptionCode = (uint)Marshal.GetExceptionCode();
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
					IL_2D5:
					Color color = Color.FromArgb(0, 0, 64);
					graphics.Clear(color);
					graphics.DrawImage(bitmap, this.Origo);
					Color color2 = Color.FromArgb(255, 24, 24);
					graphics.DrawRectangle(new Pen(color2, 1f), this.Origo.X, this.Origo.Y, (int)((double)this.UsefulSize.Width) - 1, (int)((double)this.UsefulSize.Height) - 1);
					if (ptr3 != null)
					{
						<Module>.GImage.{dtor}(ptr3);
						<Module>.delete((void*)ptr3);
					}
					bitmap.Dispose();
					graphics.Dispose();
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GWWeather.{dtor}), (void*)(&gWWeather));
					throw;
				}
				if (*(ref gWWeather + 8) != 0)
				{
					<Module>.free(*(ref gWWeather + 8));
				}
			}
			return;
			<Module>.GWWeather.{dtor}(ref gWWeather);
		}

		public unsafe void SetScene(GIScene* scene, int levelwidth, int levelhight)
		{
			float num = (float)levelwidth;
			this.LevelWidth = num;
			float num2 = (float)levelhight;
			this.LevelHeight = num2;
			this.MapScene = scene;
			float num3;
			if (num > num2)
			{
				num3 = (float)this.MapPanel.Size.Width / this.LevelWidth;
			}
			else
			{
				num3 = (float)this.MapPanel.Size.Height / this.LevelHeight;
			}
			this.Origo.X = (int)((double)(((float)this.MapPanel.Size.Width - this.LevelWidth * num3) * 0.5f));
			this.UsefulSize.Width = this.LevelWidth * num3;
			this.Origo.Y = (int)((double)(((float)this.MapPanel.Size.Height - this.LevelHeight * num3) * 0.5f));
			this.UsefulSize.Height = this.LevelHeight * num3;
			this.Margin = num3 * 16f;
		}

		public void RefreshViewport(PointF[] vps)
		{
			float num = this.UsefulSize.Width / this.LevelWidth;
			float num2 = this.UsefulSize.Height / this.LevelHeight;
			PointF pointF = default(PointF);
			PointF pointF2 = default(PointF);
			PointF pointF3 = default(PointF);
			PointF pointF4 = default(PointF);
			int num3 = 1;
			int num4 = 1;
			int num5 = 1;
			int num6 = 1;
			int num7 = 100;
			do
			{
				if (vps[num7 - 100].X >= 0f)
				{
					num3++;
				}
				if (vps[num7 - 50].X >= 0f)
				{
					num4++;
				}
				if (vps[num7].X >= 0f)
				{
					num5++;
				}
				if (vps[num7 + 50].X >= 0f)
				{
					num6++;
				}
				num7++;
			}
			while (num7 - 100 < 50);
			this.LeftVPs = new PointF[num3];
			this.TopVPs = new PointF[num4];
			this.RightVPs = new PointF[num5];
			this.BottomVPs = new PointF[num6];
			int num8 = 0;
			int num9 = 0;
			int num10 = 0;
			int num11 = 0;
			int num12 = 100;
			do
			{
				if (vps[num12 - 100].X >= 0f)
				{
					float num13 = vps[num12 - 100].X * num;
					this.LeftVPs[num8].X = (float)this.Origo.X + num13;
					float num14 = (float)(this.MapPanel.Size.Height - this.Origo.Y);
					this.LeftVPs[num8].Y = num14 - vps[num12 - 100].Y * num2;
					num8++;
				}
				if (vps[num12 - 50].X >= 0f)
				{
					float num15 = vps[num12 - 50].X * num;
					this.TopVPs[num9].X = (float)this.Origo.X + num15;
					float num16 = (float)(this.MapPanel.Size.Height - this.Origo.Y);
					this.TopVPs[num9].Y = num16 - vps[num12 - 50].Y * num2;
					num9++;
				}
				if (vps[num12].X >= 0f)
				{
					float num17 = vps[num12].X * num;
					this.RightVPs[num10].X = (float)this.Origo.X + num17;
					float num18 = (float)(this.MapPanel.Size.Height - this.Origo.Y);
					this.RightVPs[num10].Y = num18 - vps[num12].Y * num2;
					num10++;
				}
				if (vps[num12 + 50].X >= 0f)
				{
					float num19 = vps[num12 + 50].X * num;
					this.BottomVPs[num11].X = (float)this.Origo.X + num19;
					float num20 = (float)(this.MapPanel.Size.Height - this.Origo.Y);
					this.BottomVPs[num11].Y = num20 - vps[num12 + 50].Y * num2;
					num11++;
				}
				num12++;
			}
			while (num12 - 100 < 50);
			if (this.LeftVPs.Length > 1)
			{
				if (vps[50].X > 0f)
				{
					this.LeftVPs[num3 - 1] = this.TopVPs[0];
				}
				else
				{
					PointF[] leftVPs = this.LeftVPs;
					leftVPs[num3 - 1] = leftVPs[num3 - 2];
				}
			}
			if (this.TopVPs.Length > 1)
			{
				if (vps[100].X > 0f)
				{
					this.TopVPs[num4 - 1] = this.RightVPs[0];
				}
				else
				{
					PointF[] topVPs = this.TopVPs;
					topVPs[num4 - 1] = topVPs[num4 - 2];
				}
			}
			if (this.RightVPs.Length > 1)
			{
				if (vps[150].X > 0f)
				{
					this.RightVPs[num5 - 1] = this.BottomVPs[0];
				}
				else
				{
					PointF[] rightVPs = this.RightVPs;
					rightVPs[num5 - 1] = rightVPs[num5 - 2];
				}
			}
			if (this.BottomVPs.Length > 1)
			{
				if (vps[0].X > 0f)
				{
					this.BottomVPs[num6 - 1] = this.LeftVPs[0];
				}
				else
				{
					PointF[] bottomVPs = this.BottomVPs;
					bottomVPs[num6 - 1] = bottomVPs[num6 - 2];
				}
			}
			pointF = this.LeftVPs[num3 - 1];
			pointF2 = this.TopVPs[num4 - 1];
			pointF4 = this.RightVPs[num5 - 1];
			pointF3 = this.BottomVPs[num6 - 1];
			float num21 = pointF4.X + pointF3.X;
			float num22 = pointF2.X + num21;
			this.Camera.X = (int)((double)((pointF.X + num22) * 0.25f));
			float num23 = pointF4.Y + pointF3.Y;
			float num24 = pointF2.Y + num23;
			this.Camera.Y = (int)((double)((pointF.Y + num24) * 0.25f));
			Graphics graphics = Graphics.FromImage(this.Backbuffer);
			Image map = this.Map;
			if (map != null)
			{
				graphics.DrawImage(map, 0, 0);
			}
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			int num25 = 0;
			if (0 < this.Units.Length)
			{
				do
				{
					int num26 = (int)((double)this.Units[num25].position.X);
					int num27 = (int)((double)this.Units[num25].position.Y);
					if (num26 >= 0 && num26 + 1 < this.Backbuffer.Width && num27 >= 0 && num27 + 1 < this.Backbuffer.Height)
					{
						this.Backbuffer.SetPixel(num26, num27, this.Units[num25].color);
						this.Backbuffer.SetPixel(num26 + 1, num27, this.Units[num25].color);
						this.Backbuffer.SetPixel(num26, num27 + 1, this.Units[num25].color);
						this.Backbuffer.SetPixel(num26 + 1, num27 + 1, this.Units[num25].color);
					}
					num25++;
				}
				while (num25 < this.Units.Length);
			}
			if (this.LeftVPs.Length > 1)
			{
				Color color = Color.FromArgb(24, 255, 24);
				graphics.DrawLines(new Pen(color, 1f), this.LeftVPs);
			}
			if (this.TopVPs.Length > 1)
			{
				Color color2 = Color.FromArgb(24, 255, 24);
				graphics.DrawLines(new Pen(color2, 1f), this.TopVPs);
			}
			if (this.RightVPs.Length > 1)
			{
				Color color3 = Color.FromArgb(24, 255, 24);
				graphics.DrawLines(new Pen(color3, 1f), this.RightVPs);
			}
			if (this.BottomVPs.Length > 1)
			{
				Color color4 = Color.FromArgb(24, 255, 24);
				graphics.DrawLines(new Pen(color4, 1f), this.BottomVPs);
			}
			graphics.Dispose();
		}

		public void RefreshMap([MarshalAs(UnmanagedType.U1)] bool force)
		{
			if (this.AutoRefresh || force)
			{
				this.InternalMapRefresh();
			}
		}

		public unsafe void RefreshUnits()
		{
			if (this.propWorld != null)
			{
				int num = 0;
				float num2 = this.UsefulSize.Width / this.LevelWidth;
				float num3 = this.UsefulSize.Height / this.LevelHeight;
				int num4 = -1;
				while (true)
				{
					GEditorWorld* ptr = this.propWorld + 2928 / sizeof(GEditorWorld);
					GHeapDRB<GUnit *>* ptr2 = ptr;
					int num5 = num4 + 1;
					int num6 = *(ptr2 + 4);
					if (num5 >= num6)
					{
						break;
					}
					int num7 = num5 * 8 + *ptr2;
					while (*num7 != 2147483647)
					{
						num5++;
						num7 += 8;
						if (num5 >= num6)
						{
							goto IL_B8;
						}
					}
					num4 = num5;
					if (num5 < 0)
					{
						break;
					}
					GUnit* ptr3 = *(num5 * 8 + *(int*)ptr + 4);
					if (*(byte*)(ptr3 + 940 / sizeof(GUnit)) == 0)
					{
						int expr_A3 = *(int*)(ptr3 + 8 / sizeof(GUnit));
						if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_A3, *(*expr_A3 + 44)))
						{
							num++;
						}
					}
				}
				IL_B8:
				this.Units = new Minimap.UnitPoint[num];
				int num8 = 0;
				int num9 = -1;
				while (true)
				{
					GEditorWorld* ptr = this.propWorld + 2928 / sizeof(GEditorWorld);
					GHeapDRB<GUnit *>* ptr4 = ptr;
					int num10 = num9 + 1;
					int num11 = *(ptr4 + 4);
					if (num10 >= num11)
					{
						break;
					}
					int num12 = num10 * 8 + *ptr4;
					while (*num12 != 2147483647)
					{
						num10++;
						num12 += 8;
						if (num10 >= num11)
						{
							return;
						}
					}
					num9 = num10;
					if (num10 < 0)
					{
						break;
					}
					GUnit* ptr5 = *(num10 * 8 + *(int*)ptr + 4);
					if (*(byte*)(ptr5 + 940 / sizeof(GUnit)) == 0)
					{
						int expr_13A = *(int*)(ptr5 + 8 / sizeof(GUnit));
						if (!calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_13A, *(*expr_13A + 44)))
						{
							this.Units[num8].position.X = (float)this.Origo.X + *(float*)(ptr5 + 528 / sizeof(GUnit)) * num2;
							Size size = this.MapPanel.Size;
							this.Units[num8].position.Y = (float)(size.Height - this.Origo.Y) - *(float*)(ptr5 + 536 / sizeof(GUnit)) * num3;
							Color color = Color.FromArgb(*(int*)(*(int*)(ptr5 + 832 / sizeof(GUnit)) * 160 / sizeof(GEditorWorld) + this.propWorld + 284 / sizeof(GEditorWorld)));
							this.Units[num8].color = color;
							num8++;
						}
					}
				}
			}
		}

		public void DrawMap()
		{
			this.MapPanel.Invalidate();
		}

		private void MapPanel_Paint(object sender, PaintEventArgs e)
		{
			Bitmap backbuffer = this.Backbuffer;
			if (backbuffer != null)
			{
				e.Graphics.DrawImage(backbuffer, 0, 0);
			}
		}

		private void MapPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
			{
				if (e.Button == MouseButtons.Middle && !this.CameraActive)
				{
					this.CamRotateActive = true;
					this.DragPoint.X = e.X;
				}
			}
			else
			{
				this.DragPoint.X = e.X;
				this.DragPoint.Y = e.Y;
				this.CameraActive = true;
				if (e.Button == MouseButtons.Left)
				{
					float num = (float)(e.X - this.Camera.X);
					float num2 = (float)(e.Y - this.Camera.Y);
					float num3 = this.LevelHeight * num2;
					float num4 = this.LevelWidth * num;
					this.raise_CameraMove(num4 / this.UsefulSize.Width, num3 / this.UsefulSize.Height);
				}
			}
		}

		private void MapPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (this.CameraActive)
			{
				this.CameraDrag = true;
				float num = (float)(e.X - this.DragPoint.X);
				float num2 = (float)(e.Y - this.DragPoint.Y);
				float num3 = this.LevelHeight * num2;
				float num4 = this.LevelWidth * num;
				this.raise_CameraMove(num4 / this.UsefulSize.Width, num3 / this.UsefulSize.Height);
				this.DragPoint.X = e.X;
				this.DragPoint.Y = e.Y;
			}
			else if (this.CamRotateActive)
			{
				this.raise_CameraRotate((float)(e.X - this.DragPoint.X) * 0.02f);
				this.DragPoint.X = e.X;
			}
		}

		private void ConfigTools_ButtonClick(int idx, int radio_group)
		{
			if (radio_group == 1)
			{
				this.raise_MapNeedsRefresh();
			}
			else if (radio_group == 2)
			{
				byte b = (!this.AutoRefresh) ? 1 : 0;
				this.AutoRefresh = (b != 0);
				this.ConfigTools.SetItemPushed(idx, b != 0);
				byte enable = (!this.AutoRefresh) ? 1 : 0;
				this.ConfigTools.SetGroupEnable(1, enable != 0);
			}
		}

		private void MapPanel_MouseUp(object sender, MouseEventArgs e)
		{
			if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && this.CameraActive)
			{
				if (!this.CameraDrag)
				{
					float num = (float)(e.X - this.Camera.X);
					float num2 = (float)(e.Y - this.Camera.Y);
					float num3 = this.LevelHeight * num2;
					float num4 = this.LevelWidth * num;
					this.raise_CameraMove(num4 / this.UsefulSize.Width, num3 / this.UsefulSize.Height);
				}
				this.CameraActive = false;
				this.CameraDrag = false;
			}
			else if (e.Button == MouseButtons.Middle)
			{
				this.CamRotateActive = false;
			}
		}

		protected void raise_MapNeedsRefresh()
		{
			Minimap.MapNeedsRefreshHandler mapNeedsRefresh = this.MapNeedsRefresh;
			if (mapNeedsRefresh != null)
			{
				mapNeedsRefresh();
			}
		}

		protected void raise_CameraMove(float i1, float i2)
		{
			Minimap.MoveCameraHandler cameraMove = this.CameraMove;
			if (cameraMove != null)
			{
				cameraMove(i1, i2);
			}
		}

		protected void raise_CameraRotate(float i1)
		{
			Minimap.RotateCameraHandler cameraRotate = this.CameraRotate;
			if (cameraRotate != null)
			{
				cameraRotate(i1);
			}
		}
	}
}
