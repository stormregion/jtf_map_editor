using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

namespace NWorkshop
{
	public class ImageServer
	{
		private ResourceManager ResourceMan;

		private Hashtable Reservoir;

		private Hashtable BkReservoir;

		private static ImageServer Server = null;

		private ImageServer(string resourcepath)
		{
			this.ResourceMan = new ResourceManager(resourcepath, Assembly.GetExecutingAssembly());
			this.Reservoir = new Hashtable();
			this.BkReservoir = new Hashtable();
		}

		public static ImageServer GetImageServer(string resourcepath)
		{
			if (ImageServer.Server == null)
			{
				ImageServer.Server = new ImageServer(resourcepath);
			}
			return ImageServer.Server;
		}

		public unsafe Image GetImage(string ID)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			Image image = null;
			if (this.ResourceMan != null)
			{
				try
				{
					image = (this.Reservoir[ID] as Image);
					if (image == null)
					{
						image = (this.ResourceMan.GetObject(ID, CultureInfo.InvariantCulture) as Image);
						if (image != null)
						{
							this.Reservoir.Add(ID, image);
						}
					}
					return image;
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			}
			return image;
		}

		public unsafe Image GetImage(string ID, KnownColor Background)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			Image image = null;
			string key = ID + Background;
			if (this.ResourceMan != null)
			{
				try
				{
					image = (this.BkReservoir[key] as Image);
					if (image == null)
					{
						Image image2 = this.GetImage(ID);
						if (image2 != null)
						{
							image = new Bitmap(image2.Width, image2.Height, PixelFormat.Format32bppArgb);
							Graphics graphics = Graphics.FromImage(image);
							Color color = Color.FromKnownColor(Background);
							graphics.Clear(color);
							Rectangle rect = new Rectangle(0, 0, image2.Width, image2.Height);
							graphics.DrawImage(image2, rect);
							this.BkReservoir.Add(key, image);
						}
					}
					return image;
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			}
			return image;
		}
	}
}
