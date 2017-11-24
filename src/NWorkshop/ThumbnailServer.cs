using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace NWorkshop
{
	public class ThumbnailServer : IDisposable
	{
		public enum ThumbType
		{
			Fluid = 7,
			Tile = 5,
			Locale = 9,
			Effect = 4,
			Sound = 3,
			Model = 0,
			Cloud = 8,
			Map = 10,
			Box = 6,
			Unit = 2,
			Material = 1
		}

		private unsafe GMatrix3* CamRotation;

		private unsafe GPoint3* CamPos;

		private unsafe GIScene* IScene;

		private ThumbnailServer.ThumbType mode;

		private ThumbProgress ProgressDialog;

		private bool disposed;

		private bool forceupdate;

		private unsafe void InitCam(GIModel* model)
		{
			GBox gBox;
			<Module>.GBox.{ctor}(ref gBox);
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GBox* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), model, ref gBox, *(*(int*)model + 356));
			float num = (float)Math.Abs(gBox);
			float num2 = (float)Math.Abs((double)(*(ref gBox + 4)));
			float num3;
			if (num < num2)
			{
				num3 = num2;
			}
			else
			{
				num3 = num;
			}
			num2 = (float)Math.Abs((double)(*(ref gBox + 12)));
			float num4;
			if (num3 < num2)
			{
				num4 = num2;
			}
			else
			{
				num4 = num3;
			}
			num2 = (float)Math.Abs((double)(*(ref gBox + 20)));
			float num5;
			if (num4 < num2)
			{
				num5 = num2;
			}
			else
			{
				num5 = num4;
			}
			num2 = (float)Math.Abs((double)(*(ref gBox + 8)));
			float num6;
			if (num5 < num2)
			{
				num6 = num2;
			}
			else
			{
				num6 = num5;
			}
			num2 = (float)Math.Abs((double)(*(ref gBox + 16)));
			float num7;
			if (num6 < num2)
			{
				num7 = num2;
			}
			else
			{
				num7 = num6;
			}
			float num8 = num7 * 2.13546252f;
			GPoint3* ptr = <Module>.@new(12u);
			GPoint3* ptr2;
			try
			{
				if (ptr != null)
				{
					*(float*)ptr = 0f;
					*(float*)(ptr + 4 / sizeof(GPoint3)) = 0f;
					*(float*)(ptr + 8 / sizeof(GPoint3)) = num8;
					ptr2 = ptr;
				}
				else
				{
					ptr2 = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr);
				throw;
			}
			this.CamPos = ptr2;
			<Module>.GPoint3.*=(ptr2, this.CamRotation);
			float num9 = (*(ref gBox + 8) + *(ref gBox + 12)) * 0.5f;
			GPoint3* camPos = this.CamPos;
			GPoint3* expr_119 = camPos;
			*expr_119 = *expr_119;
			*(camPos + 4) = *(camPos + 4) + num9;
			*(camPos + 8) = *(camPos + 8);
			GPoint3 gPoint = 0f;
			*(ref gPoint + 4) = 0f;
			*(ref gPoint + 8) = num8 * 0.1f;
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), model, ref gPoint, *(*(int*)model + 24));
		}

		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private unsafe void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (!this.disposed)
			{
				GPoint3* camPos = this.CamPos;
				if (camPos != null)
				{
					<Module>.delete((void*)camPos);
					this.CamPos = null;
				}
				GMatrix3* camRotation = this.CamRotation;
				if (camRotation != null)
				{
					<Module>.delete((void*)camRotation);
					this.CamRotation = null;
				}
				GIScene* iScene = this.IScene;
				if (iScene != null)
				{
					GIScene* expr_41 = iScene;
					GIScene* expr_4B = expr_41 + *(*(int*)(expr_41 + 4 / sizeof(GIScene)) + 4) / sizeof(GIScene) + 4 / sizeof(GIScene);
					object arg_55_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_4B, *(*(int*)expr_4B + 4));
					this.IScene = null;
				}
			}
			this.disposed = true;
		}

		public unsafe ThumbnailServer(ThumbnailServer.ThumbType thumbmode)
		{
			this.forceupdate = false;
			this.disposed = false;
			this.mode = thumbmode;
			this.IScene = null;
			this.CamRotation = null;
			this.CamPos = null;
			this.ProgressDialog = new ThumbProgress();
			ThumbnailServer.ThumbType thumbType = this.mode;
			if (thumbType == ThumbnailServer.ThumbType.Model || thumbType == ThumbnailServer.ThumbType.Unit)
			{
				int num = calli(GIScene* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.IEngine, 0, *(*(int*)<Module>.IEngine + 12));
				this.IScene = num;
				GColor gColor = 0.3f;
				*(ref gColor + 4) = 0.3f;
				*(ref gColor + 8) = 0.4f;
				*(ref gColor + 12) = 1f;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), num, ref gColor, *(*num + 68));
				GVector3 gVector = -1f;
				*(ref gVector + 4) = -1f;
				*(ref gVector + 8) = 0f;
				GColor gColor2 = 0.8f;
				*(ref gColor2 + 4) = 0.8f;
				*(ref gColor2 + 8) = 0.9f;
				*(ref gColor2 + 12) = 1f;
				GIScene* iScene = this.IScene;
				object arg_FD_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor,GVector3), iScene, gColor2, gVector, *(*(int*)iScene + 52));
				iScene = this.IScene;
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), iScene, 0.5f, 0.5f, 0.5f, 0f, 0f, 0f, 1f, 1f, *(*(int*)iScene + 76));
				GMatrix3* ptr = <Module>.@new(48u);
				GMatrix3* ptr2;
				try
				{
					if (ptr != null)
					{
						ptr2 = <Module>.GMatrix3.{ctor}(ptr);
					}
					else
					{
						ptr2 = 0;
					}
				}
				catch
				{
					<Module>.delete((void*)ptr);
					throw;
				}
				this.CamRotation = ptr2;
				GMatrix3 gMatrix;
				GMatrix3* ptr3 = <Module>.Matrix3RotationX(&gMatrix, 3.53429174f);
				cpblk(ptr2, ptr3, 48);
				GMatrix3 gMatrix2;
				<Module>.GMatrix3.*=(ptr2, <Module>.Matrix3RotationY(&gMatrix2, -0.7853982f));
			}
		}

		public unsafe Image GetThumbnail(string root, string fullfilename, string hash, [MarshalAs(UnmanagedType.U1)] bool forceupdate)
		{
			Image result = null;
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, "Thumbs" + "/" + root + hash + ".tga");
			GBaseString<char> gBaseString<char>2;
			try
			{
				uint num = (uint)(*ptr);
				sbyte* ptr2;
				if (num != 0u)
				{
					ptr2 = num;
				}
				else
				{
					ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				<Module>.GFileSystem.MakeFullHomePath(ref <Module>.FS, &gBaseString<char>2, ptr2);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			GBaseString<char> gBaseString<char>3;
			GImage* ptr5;
			try
			{
				if (gBaseString<char> != null)
				{
					<Module>.free(gBaseString<char>);
				}
				DirectoryInfo directory = new FileInfo(new string((sbyte*)((gBaseString<char>2 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>2))).Directory;
				<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, fullfilename);
				try
				{
					sbyte* value;
					if (gBaseString<char>3 != null)
					{
						value = gBaseString<char>3;
					}
					else
					{
						value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					this.ProgressDialog.Next(new string((sbyte*)value));
					if (this.mode == ThumbnailServer.ThumbType.Tile)
					{
						GBaseString<char> gBaseString<char>4;
						GBaseString<char>* src = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>4, fullfilename + "_1.mat");
						try
						{
							<Module>.GBaseString<char>.=(ref gBaseString<char>3, src);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
							throw;
						}
						if (gBaseString<char>4 != null)
						{
							<Module>.free(gBaseString<char>4);
						}
					}
					if (!directory.Exists)
					{
						directory.Create();
					}
					sbyte* ptr3;
					if (gBaseString<char>3 != null)
					{
						ptr3 = gBaseString<char>3;
					}
					else
					{
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					GFileAttributes gFileAttributes;
					<Module>.GFileSystem.CheckFile(ref <Module>.FS, ptr3, ref gFileAttributes);
					sbyte* ptr4;
					if (gBaseString<char>2 != null)
					{
						ptr4 = gBaseString<char>2;
					}
					else
					{
						ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					GFileAttributes gFileAttributes2;
					int num3;
					if (<Module>.GFileSystem.CheckFile(ref <Module>.FS, ptr4, ref gFileAttributes2) != null)
					{
						int num2;
						if (gFileAttributes == null && gFileAttributes2 == null && *(ref gFileAttributes + 8) < *(ref gFileAttributes2 + 8) + 20000000L && *(ref gFileAttributes + 8) > *(ref gFileAttributes2 + 8) - 20000000L)
						{
							num2 = 0;
						}
						else
						{
							num2 = 1;
						}
						if ((byte)num2 == 0)
						{
							num3 = 0;
							goto IL_190;
						}
					}
					num3 = 1;
					IL_190:
					int num4;
					if ((byte)num3 == 0 && !forceupdate)
					{
						num4 = 0;
					}
					else
					{
						num4 = 1;
					}
					bool flag = (byte)num4 != 0;
					ptr5 = null;
					if (!flag)
					{
						goto IL_3FA;
					}
					this.ProgressDialog.Show();
					sbyte* value2;
					if (gBaseString<char>3 != null)
					{
						value2 = gBaseString<char>3;
					}
					else
					{
						value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					this.ProgressDialog.Next(new string((sbyte*)value2));
					switch (this.mode)
					{
					case ThumbnailServer.ThumbType.Model:
					case ThumbnailServer.ThumbType.Unit:
					{
						sbyte* ptr6;
						if (gBaseString<char>3 != null)
						{
							ptr6 = gBaseString<char>3;
						}
						else
						{
							ptr6 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						GIScene* iScene = this.IScene;
						GIModel* ptr7 = calli(GIModel* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*,System.Single,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride),System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), iScene, ptr6, *(ref <Module>.Measures + 8), 1, 0, *(*(int*)iScene + 132));
						if (ptr7 != null)
						{
							goto IL_2A5;
						}
						this.ProgressDialog.Finished();
						break;
					}
					case ThumbnailServer.ThumbType.Material:
						goto IL_31F;
					case ThumbnailServer.ThumbType.Sound:
						goto IL_3B0;
					case ThumbnailServer.ThumbType.Effect:
						goto IL_3B0;
					case ThumbnailServer.ThumbType.Tile:
						goto IL_31F;
					default:
						goto IL_3B0;
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
			return result;
			IL_2A5:
			try
			{
				try
				{
					GIModel* ptr7;
					this.InitCam(ptr7);
					GIScene* iScene2 = this.IScene;
					ptr5 = calli(GImage* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single,System.Single,System.Single,System.Single), iScene2, 64, 64, this.CamPos, -0.7853982f, 0.3926991f, 0.7853982f, 1f, 1000f, *(*(int*)iScene2 + 24));
					GIModel* expr_2E8 = ptr7;
					GIModel* expr_2F2 = expr_2E8 + *(*(int*)(expr_2E8 + 4 / sizeof(GIModel)) + 4) / sizeof(GIModel) + 4 / sizeof(GIModel);
					object arg_2FC_0 = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_2F2, *(*(int*)expr_2F2 + 4));
					goto IL_36D;
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
				throw;
			}
			IL_31F:
			try
			{
				try
				{
					sbyte* ptr8;
					if (gBaseString<char>3 != null)
					{
						ptr8 = gBaseString<char>3;
					}
					else
					{
						ptr8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					ptr5 = calli(GImage* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, ptr8, *(*(int*)<Module>.IEngine + 196));
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
				throw;
			}
			IL_36D:
			try
			{
				try
				{
					if (ptr5 != null)
					{
						sbyte* ptr9;
						if (gBaseString<char>2 != null)
						{
							ptr9 = gBaseString<char>2;
						}
						else
						{
							ptr9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						<Module>.GImage.SaveTGA(ptr5, ptr9, null);
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
				throw;
			}
			IL_3B0:
			try
			{
				try
				{
					sbyte* ptr10;
					if (gBaseString<char>2 != null)
					{
						ptr10 = gBaseString<char>2;
					}
					else
					{
						ptr10 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					GFileAttributes gFileAttributes;
					<Module>.GFileSystem.SetFileTime(ref <Module>.FS, ptr10, *(ref gFileAttributes + 8));
					goto IL_46F;
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
				throw;
			}
			IL_3FA:
			try
			{
				try
				{
					GImage* ptr11 = <Module>.@new(36u);
					GImage* ptr12;
					try
					{
						if (ptr11 != null)
						{
							ptr12 = <Module>.GImage.{ctor}(ptr11);
						}
						else
						{
							ptr12 = 0;
						}
					}
					catch
					{
						<Module>.delete((void*)ptr11);
						throw;
					}
					ptr5 = ptr12;
					sbyte* ptr13;
					if (gBaseString<char>2 != null)
					{
						ptr13 = gBaseString<char>2;
					}
					else
					{
						ptr13 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					if (<Module>.GImage.LoadTGA(ptr12, ptr13, null) == null)
					{
						if (ptr12 == null)
						{
							goto IL_4AB;
						}
						<Module>.GImage.{dtor}(ptr12);
						<Module>.delete(ptr12);
						goto IL_4AB;
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
				throw;
			}
			IL_46F:
			try
			{
				try
				{
					if (ptr5 != null)
					{
						IntPtr hbitmap = new IntPtr(<Module>.GImage.CreateHBitmap(ptr5));
						result = Image.FromHbitmap(hbitmap);
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
				throw;
			}
			IL_4AB:
			try
			{
				try
				{
					this.ProgressDialog.Finished();
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
					throw;
				}
				if (gBaseString<char>3 != null)
				{
					<Module>.free(gBaseString<char>3);
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
			return result;
		}

		public void StartThumbnailGeneration(int count)
		{
			this.ProgressDialog.StartThumbnailGeneration(count);
		}

		public void FinishThumbnailGeneration()
		{
			this.ProgressDialog.Hide();
		}
	}
}
