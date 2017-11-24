using NControls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxCameraViewport : Form
	{
		protected ArrayList ToolWindows;

		protected unsafe bool* CamViewPortExist;

		protected int IRenderTargetIdx;

		protected unsafe GIRenderTarget* IRenderTarget;

		protected unsafe GIViewport* IViewport;

		protected unsafe GPoint3* CameraPosition;

		protected float CameraDirection;

		protected float CameraElevation;

		protected float CameraFOV;

		protected float CameraRoll;

		protected bool ValidCamera;

		protected bool NeedToRender;

		protected unsafe GBaseString<char>* FormCaption;

		protected int PrevWidth;

		protected int PrevHeight;

		private NSolidPanel panCameraViewport;

		private Container components;

		public unsafe ToolboxCameraViewport(ArrayList toolwindows, bool* camviewportexist)
		{
			GPoint3* ptr = <Module>.@new(12u);
			GPoint3* cameraPosition;
			try
			{
				if (ptr != null)
				{
					*(float*)(ptr + 8 / sizeof(GPoint3)) = 0f;
					*(float*)(ptr + 4 / sizeof(GPoint3)) = 0f;
					*(float*)ptr = 0f;
					cameraPosition = ptr;
				}
				else
				{
					cameraPosition = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr);
				throw;
			}
			this.CameraPosition = cameraPosition;
			this.CameraDirection = 0f;
			this.CameraElevation = 0f;
			this.CameraFOV = 0f;
			this.CameraRoll = 0f;
			this.ValidCamera = false;
			this.NeedToRender = true;
			GBaseString<char>* ptr2 = <Module>.@new(8u);
			GBaseString<char>* formCaption;
			try
			{
				if (ptr2 != null)
				{
					*(int*)ptr2 = 0;
					*(int*)(ptr2 + 4 / sizeof(GBaseString<char>)) = 0;
					formCaption = ptr2;
				}
				else
				{
					formCaption = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr2);
				throw;
			}
			this.FormCaption = formCaption;
			this.PrevWidth = 0;
			this.PrevHeight = 0;
			this.ToolWindows = toolwindows;
			this.CamViewPortExist = camviewportexist;
			this.InitializeComponent();
			NSolidPanel nSolidPanel = new NSolidPanel();
			this.panCameraViewport = nSolidPanel;
			nSolidPanel.Dock = DockStyle.Fill;
			Point location = new Point(0, 0);
			this.panCameraViewport.Location = location;
			this.panCameraViewport.Name = "panCameraViewport";
			Size size = new Size(400, 300);
			this.panCameraViewport.Size = size;
			this.panCameraViewport.TabIndex = 0;
			this.panCameraViewport.SizeChanged += new EventHandler(this.panCameraViewport_SizeChanged);
			this.panCameraViewport.Paint += new PaintEventHandler(this.panCameraViewport_Paint);
			base.Controls.Add(this.panCameraViewport);
			this.IRenderTargetIdx = -1;
			this.IRenderTarget = null;
			this.IViewport = null;
			Size size2 = new Size(593, 335);
			this.panCameraViewport.Size = size2;
			Size clientSize = new Size(593, 335);
			base.ClientSize = clientSize;
			Point location2 = new Point(677, 607);
			base.Location = location2;
		}

		public void Destroy()
		{
			this.Dispose(true);
		}

		public new void Paint()
		{
			this.panCameraViewport_Paint(null, null);
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public bool GetFocus()
		{
			return base.ContainsFocus;
		}

		public unsafe void SetCamera(GPoint3* pos, float dir, float elev, float fov, float roll, [MarshalAs(UnmanagedType.U1)] bool ForceRefresh)
		{
			this.ValidCamera = true;
			GPoint3* cameraPosition = this.CameraPosition;
			GPoint3* ptr = cameraPosition;
			int num;
			if (*pos == *ptr && *(pos + 4) == *(ptr + 4) && *(pos + 8) == *(ptr + 8))
			{
				num = 1;
			}
			else
			{
				num = 0;
			}
			if ((byte)num != 0 && dir == this.CameraDirection && elev == this.CameraElevation && fov == this.CameraFOV && roll == this.CameraRoll)
			{
				this.NeedToRender = false;
			}
			else
			{
				this.NeedToRender = true;
				cpblk(cameraPosition, pos, 12);
				this.CameraDirection = dir;
				this.CameraElevation = elev;
				this.CameraFOV = fov;
				this.CameraRoll = roll;
			}
			if (ForceRefresh)
			{
				this.NeedToRender = true;
			}
		}

		public unsafe void SetCaption(GBaseString<char>* caption)
		{
			<Module>.GBaseString<char>.=(this.FormCaption, caption);
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			this.Deinitialize();
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

		protected unsafe void Deinitialize()
		{
			bool* camViewPortExist = this.CamViewPortExist;
			if (camViewPortExist != null)
			{
				*camViewPortExist = false;
			}
			ArrayList toolWindows = this.ToolWindows;
			if (toolWindows != null)
			{
				toolWindows.Remove(this);
			}
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, this.IRenderTargetIdx, *(*(int*)<Module>.IEngine + 104));
			this.IRenderTargetIdx = -1;
			this.IRenderTarget = null;
			this.IViewport = null;
		}

		private void InitializeComponent()
		{
			ResourceManager resourceManager = new ResourceManager(typeof(ToolboxCameraViewport));
			base.SuspendLayout();
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(400, 300);
			base.ClientSize = clientSize;
			base.Icon = (Icon)resourceManager.GetObject("$this.Icon");
			Point location = new Point(870, 642);
			base.Location = location;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ToolboxCameraViewport";
			base.StartPosition = FormStartPosition.Manual;
			this.Text = "CameraPreview";
			base.TopMost = true;
			base.Resize += new EventHandler(this.ToolboxCameraViewport_Resize);
			base.SizeChanged += new EventHandler(this.ToolboxCameraViewport_SizeChanged);
			base.Load += new EventHandler(this.ToolboxCameraViewport_Load);
			base.Closed += new EventHandler(this.ToolboxCameraViewport_Closed);
			base.ResumeLayout(false);
		}

		private void OnIdle(object sender, EventArgs e)
		{
			if (base.ContainsFocus)
			{
				this.panCameraViewport.Invalidate(false);
			}
		}

		private void ToolboxCameraViewport_Closed(object sender, EventArgs e)
		{
		}

		private unsafe void ToolboxCameraViewport_Load(object sender, EventArgs e)
		{
			HWND__* ptr = (HWND__*)this.panCameraViewport.Handle.ToPointer();
			int num = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,HWND__*,System.Int32), <Module>.IEngine, ptr, 4, *(*(int*)<Module>.IEngine + 100));
			this.IRenderTargetIdx = num;
			int num2 = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, num, *(*(int*)<Module>.IEngine + 96));
			this.IRenderTarget = num2;
			this.IViewport = calli(GIViewport* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), num2, 0, *(*num2 + 32));
			Application.Idle += new EventHandler(this.OnIdle);
		}

		private unsafe void panCameraViewport_Paint(object sender, PaintEventArgs e)
		{
			if (this.IRenderTarget != null)
			{
				GIViewport* iViewport = this.IViewport;
				if (iViewport != null && this.ValidCamera && this.NeedToRender)
				{
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single,System.Single), iViewport, this.CameraPosition, this.CameraDirection, this.CameraElevation, this.CameraRoll, *(*(int*)iViewport + 12));
					GIViewport* iViewport2 = this.IViewport;
					float num;
					float num2;
					float num3;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), iViewport2, ref num, ref num2, ref num3, *(*(int*)iViewport2 + 44));
					GIViewport* iViewport3 = this.IViewport;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single), iViewport3, this.CameraFOV, num2, num3, *(*(int*)iViewport3 + 40));
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), <Module>.Scene, 0L, *(*(int*)<Module>.Scene + 32));
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, 0, *(*(int*)<Module>.Scene + 304));
					GIRenderTarget* iRenderTarget = this.IRenderTarget;
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GIScene*,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iRenderTarget, <Module>.Scene, 8256, *(*(int*)iRenderTarget + 36));
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, 1, *(*(int*)<Module>.Scene + 304));
					GBaseString<char> gBaseString<char>;
					<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, 20f.ToString());
					try
					{
						GBaseString<char> gBaseString<char>2;
						<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, 1.76666665f.ToString());
						try
						{
							GBaseString<char> gBaseString<char>3;
							GBaseString<char>* ptr = <Module>.+(&gBaseString<char>3, (sbyte*)(&<Module>.??_C@_0BA@HNGHCCF@CameraPreview?5?$FL?$AA@), this.FormCaption);
							try
							{
								GBaseString<char> gBaseString<char>4;
								GBaseString<char>* ptr2 = <Module>.GBaseString<char>.+(ptr, &gBaseString<char>4, (sbyte*)(&<Module>.??_C@_0N@DMCNAIPA@?$FN?5?5aspect?5?3?5?$AA@));
								try
								{
									GBaseString<char> gBaseString<char>5;
									GBaseString<char>* ptr3 = <Module>.GBaseString<char>.+(ptr2, &gBaseString<char>5, ref gBaseString<char>2);
									try
									{
										GBaseString<char> gBaseString<char>6;
										GBaseString<char>* ptr4 = <Module>.GBaseString<char>.+(ptr3, &gBaseString<char>6, (sbyte*)(&<Module>.??_C@_0P@IEAIKAGH@?5?5ServerFPS?5?3?5?$AA@));
										try
										{
											GBaseString<char> gBaseString<char>7;
											GBaseString<char>* ptr5 = <Module>.GBaseString<char>.+(ptr4, &gBaseString<char>7, ref gBaseString<char>);
											try
											{
												uint num4 = (uint)(*(int*)ptr5);
												sbyte* value;
												if (num4 != 0u)
												{
													value = num4;
												}
												else
												{
													value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
												}
												this.Text = new string((sbyte*)value);
											}
											catch
											{
												<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>7));
												throw;
											}
											if (gBaseString<char>7 != null)
											{
												<Module>.free(gBaseString<char>7);
												gBaseString<char>7 = 0;
											}
										}
										catch
										{
											<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
											throw;
										}
										if (gBaseString<char>6 != null)
										{
											<Module>.free(gBaseString<char>6);
											gBaseString<char>6 = 0;
										}
									}
									catch
									{
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>5));
										throw;
									}
									if (gBaseString<char>5 != null)
									{
										<Module>.free(gBaseString<char>5);
										gBaseString<char>5 = 0;
									}
								}
								catch
								{
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
									throw;
								}
								if (gBaseString<char>4 != null)
								{
									<Module>.free(gBaseString<char>4);
									gBaseString<char>4 = 0;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
								throw;
							}
							if (gBaseString<char>3 != null)
							{
								<Module>.free(gBaseString<char>3);
								gBaseString<char>3 = 0;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
							throw;
						}
						if (gBaseString<char>2 != null)
						{
							<Module>.free(gBaseString<char>2);
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
						throw;
					}
					if (gBaseString<char> != null)
					{
						<Module>.free(gBaseString<char>);
					}
				}
			}
		}

		private unsafe void panCameraViewport_SizeChanged(object sender, EventArgs e)
		{
			if (this.IRenderTarget != null)
			{
				this.NeedToRender = true;
				Size clientSize = this.panCameraViewport.ClientSize;
				Size clientSize2 = this.panCameraViewport.ClientSize;
				int num = *(int*)this.IRenderTarget + 12;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), this.IRenderTarget, clientSize2.Width, clientSize.Height, *num);
				if (this.panCameraViewport.ClientSize.Width != 0 && this.panCameraViewport.ClientSize.Height != 0)
				{
					base.Invalidate();
				}
			}
		}

		private void ToolboxCameraViewport_Resize(object sender, EventArgs e)
		{
		}

		private void ToolboxCameraViewport_SizeChanged(object sender, EventArgs e)
		{
			int num = base.ClientSize.Height;
			int num2 = base.ClientSize.Width;
			if (base.ClientSize.Height != this.PrevHeight)
			{
				num2 = (int)((double)((float)base.ClientSize.Height * 1.76666665f));
			}
			else if (base.ClientSize.Width != this.PrevWidth)
			{
				num = (int)((double)((float)base.ClientSize.Width * 0.5660377f));
			}
			if (num2 != 0 && num != 0)
			{
				Size size = new Size(num2, num);
				this.panCameraViewport.Size = size;
				Size clientSize = new Size(num2, num);
				base.ClientSize = clientSize;
			}
			this.PrevHeight = num;
			this.PrevWidth = num2;
		}
	}
}
