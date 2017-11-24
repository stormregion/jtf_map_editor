using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NFileDialog : Form
	{
		private NFilePickerTextBox UnitFilePickerTextBox;

		private Panel panTab;

		private Panel panPreview;

		private Button btnCancel;

		private Button btnOK;

		private Label labRecentPreview;

		private Panel panRecentPreViewport;

		private Label labRecentPreviewUnderConstruction;

		private TabControl tabMode;

		private TabPage tabNew;

		private TabPage tabRecent;

		private Panel panRecent;

		private RadioButton radRecentThumbnails;

		private RadioButton radRecentDetails;

		private Label labRecentLocation;

		private Button btnRecentLocationRoot;

		private Button btnRecentLocationUp;

		private ComboBox cmbRecentLocation;

		private ListView listRecent;

		private Label labRecentFileType;

		private Label labRecentFileName;

		private ComboBox cmbRecentFileName;

		private ComboBox cmbRecentFileType;

		private Splitter splitPreview;

		private ColumnHeader colOpenFileName;

		private ColumnHeader colOpenFileSize;

		private ColumnHeader colOpenFileDate;

		private ImageList imgFileTypeLargeIcons;

		private ImageList imgFileTypeSmallIcons;

		private TabPage tabBrowse;

		private Panel panBrowse;

		private RadioButton radBrowseThumbnails;

		private RadioButton radBrowseDetails;

		private ListView listBrowse;

		private Label labBrowseLocation;

		private Label labBrowseFileType;

		private Label labBrowseFileName;

		private ComboBox cmbBrowseFileName;

		private ComboBox cmbBrowseFileType;

		private Button btnBrowseLocationRoot;

		private Button btnBrowseLocationUp;

		private ComboBox cmbBrowseLocation;

		private ColumnHeader colRecentFileName;

		private GroupBox SizeGroup;

		private TrackBar trkWidth;

		private TextBox tbSize;

		private CheckBox chkSquare;

		private TrackBar trkHeight;

		private TextBox tbInnerSize;

		private GroupBox InheritGroup;

		private Label label1;

		private IContainer components;

		private int propAvailableModes;

		private int propSelectedMode;

		private bool FullBrowse;

		private unsafe GPath* propLocation;

		private unsafe GPath* propCurrentLocation;

		private string propFileName;

		private string propDefaultExtension;

		private int FileType;

		private unsafe GArray<GBaseString<char> >* RecentFiles;

		private ImageServer IconSrvr;

		private bool SquareMap;

		private int MapWidth;

		private int MapHeight;

		private Point ShellMenuPos;

		private bool IsUnitEditorType;

		public string NewUnitFileName
		{
			get
			{
				return this.UnitFilePickerTextBox.Text;
			}
		}

		public int NewHeight
		{
			get
			{
				return this.MapHeight;
			}
		}

		public int NewWidht
		{
			get
			{
				return this.MapWidth;
			}
		}

		public string DefaultExtension
		{
			get
			{
				return this.propDefaultExtension;
			}
			set
			{
				this.propDefaultExtension = value;
				if (value.Length > 0)
				{
					this.cmbBrowseFileType.Text = "*." + value;
				}
				else
				{
					this.cmbBrowseFileType.Text = "*.*";
				}
			}
		}

		public unsafe string FilePath
		{
			get
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.FileName);
				string result;
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
					GPath gPath;
					GPath* ptr3 = <Module>.GPath.{ctor}(ref gPath, ptr2);
					try
					{
						GPath gPath2;
						GPath* ptr4 = <Module>.GPath.{ctor}(ref gPath2, this.Location);
						try
						{
							GPath gPath3;
							GPath* ptr5 = <Module>.GPath.+(ptr4, &gPath3, ptr3);
							try
							{
								GBaseString<char> gBaseString<char>2;
								<Module>.GPath..?AV?$GBaseString@D@@(ptr5, (GBaseString<char>*)(&gBaseString<char>2));
								try
								{
									GBaseString<char> gBaseString<char>3;
									if (*(ref gBaseString<char>2 + 4) != 0)
									{
										*(ref gBaseString<char>3 + 4) = *(ref gBaseString<char>2 + 4);
										uint num2 = (uint)(*(ref gBaseString<char>2 + 4) + 1);
										gBaseString<char>3 = <Module>.malloc(num2);
										cpblk(gBaseString<char>3, gBaseString<char>2, num2);
									}
									else
									{
										*(ref gBaseString<char>3 + 4) = 0;
										gBaseString<char>3 = 0;
									}
									try
									{
										result = new string((sbyte*)((gBaseString<char>3 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>3));
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
									gBaseString<char>2 = 0;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath3));
								throw;
							}
							try
							{
								<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath3 + 12);
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath3));
								throw;
							}
							if (gPath3 != null)
							{
								<Module>.free(gPath3);
								gPath3 = 0;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath2));
							throw;
						}
						try
						{
							<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath2 + 12);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath2));
							throw;
						}
						if (gPath2 != null)
						{
							<Module>.free(gPath2);
							gPath2 = 0;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath));
						throw;
					}
					try
					{
						<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath + 12);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath));
						throw;
					}
					if (gPath != null)
					{
						<Module>.free(gPath);
						gPath = 0;
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
				return result;
			}
			set
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, value);
				GPath gPath;
				try
				{
					GBaseString<char> gBaseString<char>2;
					GBaseString<char>* ptr2 = <Module>.GBaseString<char>.Dirname(ptr, &gBaseString<char>2);
					try
					{
						uint num = (uint)(*(int*)ptr2);
						sbyte* ptr3;
						if (num != 0u)
						{
							ptr3 = num;
						}
						else
						{
							ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						<Module>.GPath.{ctor}(ref gPath, ptr3);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
						throw;
					}
					try
					{
						if (gBaseString<char>2 != null)
						{
							<Module>.free(gBaseString<char>2);
							gBaseString<char>2 = 0;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath));
						throw;
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
					throw;
				}
				try
				{
					if (gBaseString<char> != null)
					{
						<Module>.free(gBaseString<char>);
					}
					this.Location = &gPath;
					GBaseString<char> gBaseString<char>3;
					GBaseString<char>* ptr4 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, value);
					try
					{
						GBaseString<char> gBaseString<char>4;
						GBaseString<char>* ptr5 = <Module>.GBaseString<char>.Basename(ptr4, &gBaseString<char>4);
						try
						{
							uint num2 = (uint)(*(int*)ptr5);
							sbyte* value2;
							if (num2 != 0u)
							{
								value2 = num2;
							}
							else
							{
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							this.FileName = new string((sbyte*)value2);
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
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath));
					throw;
				}
				try
				{
					<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath + 12);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath));
					throw;
				}
				if (gPath != null)
				{
					<Module>.free(gPath);
				}
			}
		}

		public string FileName
		{
			get
			{
				return this.propFileName;
			}
			set
			{
				this.propFileName = value;
				this.cmbBrowseFileName.Text = value;
			}
		}

		private unsafe GPath* CurrentLocation
		{
			get
			{
				return this.propCurrentLocation;
			}
			set
			{
				<Module>.GPath.=(this.propCurrentLocation, value);
				<Module>.GPath.Collapse(this.propCurrentLocation);
				GBaseString<char> gBaseString<char>;
				<Module>.GPath..?AV?$GBaseString@D@@(this.propCurrentLocation, (GBaseString<char>*)(&gBaseString<char>));
				try
				{
					GBaseString<char> gBaseString<char>2;
					if (*(ref gBaseString<char> + 4) != 0)
					{
						*(ref gBaseString<char>2 + 4) = *(ref gBaseString<char> + 4);
						uint num = (uint)(*(ref gBaseString<char> + 4) + 1);
						gBaseString<char>2 = <Module>.malloc(num);
						cpblk(gBaseString<char>2, gBaseString<char>, num);
					}
					else
					{
						*(ref gBaseString<char>2 + 4) = 0;
						gBaseString<char>2 = 0;
					}
					try
					{
						sbyte* value2;
						if (gBaseString<char>2 != null)
						{
							value2 = gBaseString<char>2;
						}
						else
						{
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						this.cmbBrowseLocation.Text = new string((sbyte*)value2);
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
				GBaseString<char> gBaseString<char>3;
				<Module>.GPath..?AV?$GBaseString@D@@(this.propCurrentLocation, (GBaseString<char>*)(&gBaseString<char>3));
				try
				{
					GBaseString<char> gBaseString<char>4;
					if (*(ref gBaseString<char>3 + 4) != 0)
					{
						*(ref gBaseString<char>4 + 4) = *(ref gBaseString<char>3 + 4);
						uint num2 = (uint)(*(ref gBaseString<char>3 + 4) + 1);
						gBaseString<char>4 = <Module>.malloc(num2);
						cpblk(gBaseString<char>4, gBaseString<char>3, num2);
					}
					else
					{
						*(ref gBaseString<char>4 + 4) = 0;
						gBaseString<char>4 = 0;
					}
					try
					{
						sbyte* value3;
						if (gBaseString<char>4 != null)
						{
							value3 = gBaseString<char>4;
						}
						else
						{
							value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						this.cmbRecentLocation.Text = new string((sbyte*)value3);
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
		}

		private new unsafe GPath* Location
		{
			get
			{
				return this.propLocation;
			}
			set
			{
				<Module>.GPath.=(this.propLocation, value);
				<Module>.GPath.Collapse(this.propLocation);
				this.CurrentLocation = value;
			}
		}

		public int SelectedMode
		{
			get
			{
				return this.propSelectedMode;
			}
			set
			{
				if ((this.propAvailableModes & value) != 0)
				{
					this.propSelectedMode = value;
					switch (value)
					{
					case 1:
						this.tabMode.SelectedTab = this.tabNew;
						break;
					case 2:
					case 4:
						this.tabMode.SelectedTab = this.tabBrowse;
						break;
					case 8:
						this.tabMode.SelectedTab = this.tabRecent;
						break;
					}
				}
			}
		}

		public int AvailableModes
		{
			get
			{
				return this.propAvailableModes;
			}
			set
			{
				this.propAvailableModes = 0;
				this.propSelectedMode = 0;
				this.tabMode.SuspendLayout();
				this.tabMode.Controls.Clear();
				if ((value & 4) != 0)
				{
					this.propAvailableModes |= 4;
					this.tabMode.Controls.Add(this.tabBrowse);
					this.tabBrowse.Text = "Save";
				}
				else
				{
					if ((value & 1) != 0)
					{
						this.propAvailableModes |= 1;
						if (this.IsUnitEditorType)
						{
							this.SizeGroup.Hide();
							NFilePickerTextBox nFilePickerTextBox = new NFilePickerTextBox(NewAssetPicker.ObjectType.UnitEditor, 30);
							this.UnitFilePickerTextBox = nFilePickerTextBox;
							nFilePickerTextBox.BorderStyle = BorderStyle.None;
							Point location = new Point(110, 16);
							this.UnitFilePickerTextBox.Location = location;
							Size size = new Size(290, 20);
							this.UnitFilePickerTextBox.Size = size;
							this.InheritGroup.Controls.Add(this.UnitFilePickerTextBox);
							this.tabNew.Controls.Add(this.InheritGroup);
						}
						this.tabMode.Controls.Add(this.tabNew);
					}
					if ((value & 2) != 0)
					{
						this.propAvailableModes |= 2;
						this.tabMode.Controls.Add(this.tabBrowse);
						this.tabBrowse.Text = "Open";
						if ((value & 8) != 0)
						{
							this.propAvailableModes |= 8;
							this.tabMode.Controls.Add(this.tabRecent);
						}
					}
				}
				this.tabMode.ResumeLayout();
			}
		}

		public unsafe NFileDialog(GArray<GBaseString<char> >* recentfiles, [MarshalAs(UnmanagedType.U1)] bool full_browse)
		{
			this.InitializeComponent();
			ImageServer imageServer = ImageServer.GetImageServer("Images");
			this.IconSrvr = imageServer;
			Image image = imageServer.GetImage("Map_16", KnownColor.Window);
			if (image != null)
			{
				this.imgFileTypeSmallIcons.Images.Add(image);
			}
			Image image2 = this.IconSrvr.GetImage("Folder_Up_16", KnownColor.Window);
			if (image2 != null)
			{
				this.imgFileTypeSmallIcons.Images.Add(image2);
			}
			Image image3 = this.IconSrvr.GetImage("Folder_16", KnownColor.Window);
			if (image3 != null)
			{
				this.imgFileTypeSmallIcons.Images.Add(image3);
			}
			Image image4 = this.IconSrvr.GetImage("Map_32", KnownColor.Window);
			if (image4 != null)
			{
				this.imgFileTypeLargeIcons.Images.Add(image4);
			}
			Image image5 = this.IconSrvr.GetImage("Folder_Up_64", KnownColor.Window);
			if (image5 != null)
			{
				this.imgFileTypeLargeIcons.Images.Add(image5);
			}
			Image image6 = this.IconSrvr.GetImage("Folder_64", KnownColor.Window);
			if (image6 != null)
			{
				this.imgFileTypeLargeIcons.Images.Add(image6);
			}
			this.propAvailableModes = 11;
			this.propSelectedMode = 1;
			GPath* ptr = <Module>.@new(24u);
			GPath* ptr2;
			try
			{
				if (ptr != null)
				{
					ptr2 = <Module>.GPath.{ctor}(ptr);
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
			this.propLocation = ptr2;
			GPath* ptr3 = <Module>.@new(24u);
			GPath* ptr4;
			try
			{
				if (ptr3 != null)
				{
					ptr4 = <Module>.GPath.{ctor}(ptr3);
				}
				else
				{
					ptr4 = 0;
				}
			}
			catch
			{
				<Module>.delete((void*)ptr3);
				throw;
			}
			this.propCurrentLocation = ptr4;
			this.RecentFiles = recentfiles;
			this.FullBrowse = full_browse;
			this.labBrowseFileName.Enabled = full_browse;
			this.cmbBrowseFileName.Enabled = this.FullBrowse;
			GPath gPath;
			<Module>.GPath.{ctor}(ref gPath);
			try
			{
				GArray<GBaseString<char> >* recentFiles = this.RecentFiles;
				if (recentFiles != null && *(int*)(recentFiles + 4 / sizeof(GArray<GBaseString<char> >)) != 0)
				{
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr5 = <Module>.GBaseString<char>.Dirname(*(int*)recentFiles, &gBaseString<char>);
					try
					{
						uint num = (uint)(*(int*)ptr5);
						sbyte* ptr6;
						if (num != 0u)
						{
							ptr6 = num;
						}
						else
						{
							ptr6 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						<Module>.GPath.=(ref gPath, ptr6);
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
				else if (this.FullBrowse)
				{
					<Module>.GPath.=(ref gPath, <Module>.GFileSystem.GetHomePath(ref <Module>.FS));
				}
				this.Location = &gPath;
				this.propFileName = "";
				this.propDefaultExtension = "";
				this.FileType = 0;
				this.Update_listBrowse();
				this.SquareMap = true;
				this.trkHeight.Maximum = 60;
				this.trkHeight.Minimum = 6;
				this.trkWidth.Maximum = 60;
				this.trkWidth.Minimum = 6;
				this.MapWidth = 240;
				this.MapHeight = 240;
				this.tbSize.Text = ((float)((float)this.MapWidth * *(ref <Module>.Measures + 4))).ToString() + "x" + ((float)(*(ref <Module>.Measures + 4) * 240f)).ToString();
				this.tbInnerSize.Text = ((float)((float)(this.MapWidth - 32) * *(ref <Module>.Measures + 4))).ToString() + "x" + ((float)((float)(this.MapHeight - 32) * *(ref <Module>.Measures + 4))).ToString();
				this.IsUnitEditorType = false;
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath));
				throw;
			}
			try
			{
				<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath + 12);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath));
				throw;
			}
			if (gPath != null)
			{
				<Module>.free(gPath);
			}
		}

		public unsafe void UpdateRecentFiles()
		{
			GBaseString<char> gBaseString<char>;
			<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.FilePath);
			try
			{
				int num = 0;
				GArray<GBaseString<char> >* recentFiles = this.RecentFiles;
				GArray<GBaseString<char> >* ptr = recentFiles;
				int num2 = *(ptr + 4);
				if (0 < num2)
				{
					do
					{
						GArray<GBaseString<char> >* ptr2 = recentFiles;
						if (((<Module>.GBaseString<char>.Compare(num * 8 + *ptr2, ref gBaseString<char>, false) == 0) ? 1 : 0) != 0)
						{
							goto IL_5A;
						}
						num++;
						recentFiles = this.RecentFiles;
						ptr = recentFiles;
						num2 = *(ptr + 4);
					}
					while (num < num2);
					goto IL_66;
					IL_5A:
					<Module>.GArray<GBaseString<char> >.Remove(this.RecentFiles, num);
				}
				IL_66:
				GArray<GBaseString<char> >* recentFiles2 = this.RecentFiles;
				if (*(int*)(recentFiles2 + 4 / sizeof(GArray<GBaseString<char> >)) > 20)
				{
					int num3 = *(int*)(recentFiles2 + 4 / sizeof(GArray<GBaseString<char> >));
					<Module>.GArray<GBaseString<char> >.Remove(recentFiles2, num3 - 1);
				}
				GBaseString<char>* arg_9A_0 = <Module>.GArray<GBaseString<char> >.Insert(this.RecentFiles, 0);
				GArray<GBaseString<char> >* recentFiles3 = this.RecentFiles;
				GBaseString<char>* ptr3 = arg_9A_0 * 8 + *recentFiles3;
				if (*(ref gBaseString<char> + 4) != 0)
				{
					*(ptr3 + 4) = *(ref gBaseString<char> + 4);
					void* ptr4 = <Module>.realloc(*ptr3, (uint)(*(ref gBaseString<char> + 4) + 1));
					*ptr3 = ptr4;
					cpblk(ptr4, gBaseString<char>, *(ptr3 + 4) + 1);
				}
				else
				{
					*(ptr3 + 4) = 0;
					int num4 = *ptr3;
					if (num4 != 0)
					{
						<Module>.free(num4);
						*ptr3 = 0;
					}
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

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing)
			{
				IContainer container = this.components;
				if (container != null)
				{
					container.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(NFileDialog));
			this.panTab = new Panel();
			this.tabMode = new TabControl();
			this.tabNew = new TabPage();
			this.InheritGroup = new GroupBox();
			this.SizeGroup = new GroupBox();
			this.tbInnerSize = new TextBox();
			this.chkSquare = new CheckBox();
			this.tbSize = new TextBox();
			this.trkHeight = new TrackBar();
			this.trkWidth = new TrackBar();
			this.tabBrowse = new TabPage();
			this.panBrowse = new Panel();
			this.radBrowseThumbnails = new RadioButton();
			this.radBrowseDetails = new RadioButton();
			this.listBrowse = new ListView();
			this.colOpenFileName = new ColumnHeader();
			this.colOpenFileSize = new ColumnHeader();
			this.colOpenFileDate = new ColumnHeader();
			this.imgFileTypeLargeIcons = new ImageList(this.components);
			this.imgFileTypeSmallIcons = new ImageList(this.components);
			this.labBrowseLocation = new Label();
			this.labBrowseFileType = new Label();
			this.labBrowseFileName = new Label();
			this.cmbBrowseFileName = new ComboBox();
			this.cmbBrowseFileType = new ComboBox();
			this.btnBrowseLocationRoot = new Button();
			this.btnBrowseLocationUp = new Button();
			this.cmbBrowseLocation = new ComboBox();
			this.tabRecent = new TabPage();
			this.panRecent = new Panel();
			this.radRecentThumbnails = new RadioButton();
			this.radRecentDetails = new RadioButton();
			this.labRecentLocation = new Label();
			this.btnRecentLocationRoot = new Button();
			this.btnRecentLocationUp = new Button();
			this.cmbRecentLocation = new ComboBox();
			this.listRecent = new ListView();
			this.colRecentFileName = new ColumnHeader();
			this.labRecentFileType = new Label();
			this.labRecentFileName = new Label();
			this.cmbRecentFileName = new ComboBox();
			this.cmbRecentFileType = new ComboBox();
			this.panPreview = new Panel();
			this.panRecentPreViewport = new Panel();
			this.labRecentPreviewUnderConstruction = new Label();
			this.labRecentPreview = new Label();
			this.btnCancel = new Button();
			this.btnOK = new Button();
			this.splitPreview = new Splitter();
			this.label1 = new Label();
			this.panTab.SuspendLayout();
			this.tabMode.SuspendLayout();
			this.tabNew.SuspendLayout();
			this.InheritGroup.SuspendLayout();
			this.SizeGroup.SuspendLayout();
			((ISupportInitialize)this.trkHeight).BeginInit();
			((ISupportInitialize)this.trkWidth).BeginInit();
			this.tabBrowse.SuspendLayout();
			this.panBrowse.SuspendLayout();
			this.tabRecent.SuspendLayout();
			this.panRecent.SuspendLayout();
			this.panPreview.SuspendLayout();
			this.panRecentPreViewport.SuspendLayout();
			base.SuspendLayout();
			this.panTab.Controls.Add(this.tabMode);
			this.panTab.Dock = DockStyle.Fill;
			Point location = new Point(0, 0);
			this.panTab.Location = location;
			this.panTab.Name = "panTab";
			Size size = new Size(429, 413);
			this.panTab.Size = size;
			this.panTab.TabIndex = 3;
			this.tabMode.Alignment = TabAlignment.Bottom;
			this.tabMode.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tabMode.Controls.Add(this.tabNew);
			this.tabMode.Controls.Add(this.tabBrowse);
			this.tabMode.Controls.Add(this.tabRecent);
			Point location2 = new Point(0, 0);
			this.tabMode.Location = location2;
			this.tabMode.Name = "tabMode";
			Point padding = new Point(16, 5);
			this.tabMode.Padding = padding;
			this.tabMode.SelectedIndex = 0;
			Size size2 = new Size(429, 392);
			this.tabMode.Size = size2;
			this.tabMode.TabIndex = 1;
			this.tabMode.SelectedIndexChanged += new EventHandler(this.tabMode_SelectedIndexChanged);
			this.tabNew.Controls.Add(this.SizeGroup);
			Point location3 = new Point(4, 4);
			this.tabNew.Location = location3;
			this.tabNew.Name = "tabNew";
			Size size3 = new Size(421, 366);
			this.tabNew.Size = size3;
			this.tabNew.TabIndex = 0;
			this.tabNew.Text = "New";
			this.InheritGroup.Controls.Add(this.label1);
			Point location4 = new Point(8, 8);
			this.InheritGroup.Location = location4;
			this.InheritGroup.Name = "InheritGroup";
			Size size4 = new Size(408, 44);
			this.InheritGroup.Size = size4;
			this.InheritGroup.TabIndex = 1;
			this.InheritGroup.TabStop = false;
			this.InheritGroup.Text = "Inheritance ";
			this.SizeGroup.Controls.Add(this.tbInnerSize);
			this.SizeGroup.Controls.Add(this.chkSquare);
			this.SizeGroup.Controls.Add(this.tbSize);
			this.SizeGroup.Controls.Add(this.trkHeight);
			this.SizeGroup.Controls.Add(this.trkWidth);
			this.SizeGroup.FlatStyle = FlatStyle.System;
			Point location5 = new Point(8, 12);
			this.SizeGroup.Location = location5;
			this.SizeGroup.Name = "SizeGroup";
			Size size5 = new Size(408, 104);
			this.SizeGroup.Size = size5;
			this.SizeGroup.TabIndex = 0;
			this.SizeGroup.TabStop = false;
			this.SizeGroup.Text = "Map size";
			Point location6 = new Point(256, 76);
			this.tbInnerSize.Location = location6;
			this.tbInnerSize.Name = "tbInnerSize";
			this.tbInnerSize.ReadOnly = true;
			Size size6 = new Size(144, 21);
			this.tbInnerSize.Size = size6;
			this.tbInnerSize.TabIndex = 4;
			this.tbInnerSize.Text = "";
			this.chkSquare.Checked = true;
			this.chkSquare.CheckState = CheckState.Checked;
			this.chkSquare.FlatStyle = FlatStyle.System;
			Point location7 = new Point(256, 20);
			this.chkSquare.Location = location7;
			this.chkSquare.Name = "chkSquare";
			this.chkSquare.RightToLeft = RightToLeft.No;
			Size size7 = new Size(144, 24);
			this.chkSquare.Size = size7;
			this.chkSquare.TabIndex = 3;
			this.chkSquare.Text = "Square map";
			this.chkSquare.CheckedChanged += new EventHandler(this.chkSquare_CheckedChanged);
			Point location8 = new Point(256, 48);
			this.tbSize.Location = location8;
			this.tbSize.Name = "tbSize";
			this.tbSize.ReadOnly = true;
			Size size8 = new Size(144, 21);
			this.tbSize.Size = size8;
			this.tbSize.TabIndex = 2;
			this.tbSize.Text = "";
			Point location9 = new Point(4, 52);
			this.trkHeight.Location = location9;
			this.trkHeight.Maximum = 60;
			this.trkHeight.Minimum = 15;
			this.trkHeight.Name = "trkHeight";
			Size size9 = new Size(248, 34);
			this.trkHeight.Size = size9;
			this.trkHeight.TabIndex = 1;
			this.trkHeight.Value = 15;
			this.trkHeight.Scroll += new EventHandler(this.trkHeight_Scroll);
			Point location10 = new Point(4, 20);
			this.trkWidth.Location = location10;
			this.trkWidth.Maximum = 60;
			this.trkWidth.Minimum = 15;
			this.trkWidth.Name = "trkWidth";
			Size size10 = new Size(248, 34);
			this.trkWidth.Size = size10;
			this.trkWidth.TabIndex = 0;
			this.trkWidth.TickStyle = TickStyle.TopLeft;
			this.trkWidth.Value = 15;
			this.trkWidth.Scroll += new EventHandler(this.trkWidth_Scroll);
			this.tabBrowse.Controls.Add(this.panBrowse);
			Point location11 = new Point(4, 4);
			this.tabBrowse.Location = location11;
			this.tabBrowse.Name = "tabBrowse";
			Size size11 = new Size(421, 366);
			this.tabBrowse.Size = size11;
			this.tabBrowse.TabIndex = 1;
			this.tabBrowse.Text = "Open";
			this.tabBrowse.Visible = false;
			this.panBrowse.Controls.Add(this.radBrowseThumbnails);
			this.panBrowse.Controls.Add(this.radBrowseDetails);
			this.panBrowse.Controls.Add(this.listBrowse);
			this.panBrowse.Controls.Add(this.labBrowseLocation);
			this.panBrowse.Controls.Add(this.labBrowseFileType);
			this.panBrowse.Controls.Add(this.labBrowseFileName);
			this.panBrowse.Controls.Add(this.cmbBrowseFileName);
			this.panBrowse.Controls.Add(this.cmbBrowseFileType);
			this.panBrowse.Controls.Add(this.btnBrowseLocationRoot);
			this.panBrowse.Controls.Add(this.btnBrowseLocationUp);
			this.panBrowse.Controls.Add(this.cmbBrowseLocation);
			this.panBrowse.Dock = DockStyle.Fill;
			Point location12 = new Point(0, 0);
			this.panBrowse.Location = location12;
			this.panBrowse.Name = "panBrowse";
			Size size12 = new Size(421, 366);
			this.panBrowse.Size = size12;
			this.panBrowse.TabIndex = 4;
			this.radBrowseThumbnails.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.radBrowseThumbnails.Appearance = Appearance.Button;
			this.radBrowseThumbnails.FlatStyle = FlatStyle.System;
			Point location13 = new Point(396, 4);
			this.radBrowseThumbnails.Location = location13;
			this.radBrowseThumbnails.Name = "radBrowseThumbnails";
			Size size13 = new Size(24, 21);
			this.radBrowseThumbnails.Size = size13;
			this.radBrowseThumbnails.TabIndex = 12;
			this.radBrowseThumbnails.Text = "T";
			this.radBrowseThumbnails.CheckedChanged += new EventHandler(this.radBrowseThumbnails_CheckedChanged);
			this.radBrowseDetails.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.radBrowseDetails.Appearance = Appearance.Button;
			this.radBrowseDetails.Checked = true;
			this.radBrowseDetails.FlatStyle = FlatStyle.System;
			Point location14 = new Point(368, 4);
			this.radBrowseDetails.Location = location14;
			this.radBrowseDetails.Name = "radBrowseDetails";
			Size size14 = new Size(24, 21);
			this.radBrowseDetails.Size = size14;
			this.radBrowseDetails.TabIndex = 11;
			this.radBrowseDetails.TabStop = true;
			this.radBrowseDetails.Text = "D";
			this.radBrowseDetails.CheckedChanged += new EventHandler(this.radBrowseDetails_CheckedChanged);
			this.listBrowse.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			ColumnHeader[] values = new ColumnHeader[]
			{
				this.colOpenFileName,
				this.colOpenFileSize,
				this.colOpenFileDate
			};
			this.listBrowse.Columns.AddRange(values);
			this.listBrowse.FullRowSelect = true;
			this.listBrowse.HideSelection = false;
			this.listBrowse.LargeImageList = this.imgFileTypeLargeIcons;
			Point location15 = new Point(4, 28);
			this.listBrowse.Location = location15;
			this.listBrowse.MultiSelect = false;
			this.listBrowse.Name = "listBrowse";
			Size size15 = new Size(416, 283);
			this.listBrowse.Size = size15;
			this.listBrowse.SmallImageList = this.imgFileTypeSmallIcons;
			this.listBrowse.TabIndex = 10;
			this.listBrowse.View = View.Details;
			this.listBrowse.Resize += new EventHandler(this.listBrowse_Resize);
			this.listBrowse.ItemActivate += new EventHandler(this.listBrowse_ItemActivate);
			this.listBrowse.MouseUp += new MouseEventHandler(this.listBrowse_MouseUp);
			this.listBrowse.SelectedIndexChanged += new EventHandler(this.listBrowse_SelectedIndexChanged);
			this.colOpenFileName.Text = "Name";
			this.colOpenFileName.Width = 218;
			this.colOpenFileSize.Text = "Size";
			this.colOpenFileSize.TextAlign = HorizontalAlignment.Right;
			this.colOpenFileSize.Width = 77;
			this.colOpenFileDate.Text = "Date";
			this.colOpenFileDate.Width = 120;
			this.imgFileTypeLargeIcons.ColorDepth = ColorDepth.Depth24Bit;
			Size imageSize = new Size(32, 32);
			this.imgFileTypeLargeIcons.ImageSize = imageSize;
			Color magenta = Color.Magenta;
			this.imgFileTypeLargeIcons.TransparentColor = magenta;
			this.imgFileTypeSmallIcons.ColorDepth = ColorDepth.Depth24Bit;
			Size imageSize2 = new Size(16, 16);
			this.imgFileTypeSmallIcons.ImageSize = imageSize2;
			Color magenta2 = Color.Magenta;
			this.imgFileTypeSmallIcons.TransparentColor = magenta2;
			this.labBrowseLocation.Enabled = false;
			Point location16 = new Point(21, 7);
			this.labBrowseLocation.Location = location16;
			this.labBrowseLocation.Name = "labBrowseLocation";
			Size size16 = new Size(50, 16);
			this.labBrowseLocation.Size = size16;
			this.labBrowseLocation.TabIndex = 9;
			this.labBrowseLocation.Text = "Location:";
			this.labBrowseFileType.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.labBrowseFileType.Enabled = false;
			Point location17 = new Point(21, 341);
			this.labBrowseFileType.Location = location17;
			this.labBrowseFileType.Name = "labBrowseFileType";
			Size size17 = new Size(50, 16);
			this.labBrowseFileType.Size = size17;
			this.labBrowseFileType.TabIndex = 8;
			this.labBrowseFileType.Text = "FileType:";
			this.labBrowseFileName.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.labBrowseFileName.Enabled = false;
			Point location18 = new Point(18, 317);
			this.labBrowseFileName.Location = location18;
			this.labBrowseFileName.Name = "labBrowseFileName";
			Size size18 = new Size(54, 16);
			this.labBrowseFileName.Size = size18;
			this.labBrowseFileName.TabIndex = 7;
			this.labBrowseFileName.Text = "FileName:";
			this.cmbBrowseFileName.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.cmbBrowseFileName.DropDownWidth = 320;
			this.cmbBrowseFileName.Enabled = false;
			this.cmbBrowseFileName.ItemHeight = 13;
			Point location19 = new Point(72, 314);
			this.cmbBrowseFileName.Location = location19;
			this.cmbBrowseFileName.Name = "cmbBrowseFileName";
			Size size19 = new Size(348, 21);
			this.cmbBrowseFileName.Size = size19;
			this.cmbBrowseFileName.TabIndex = 6;
			this.cmbBrowseFileName.KeyPress += new KeyPressEventHandler(this.cmbBrowseFileName_KeyPress);
			this.cmbBrowseFileName.TextChanged += new EventHandler(this.cmbBrowseFileName_TextChanged);
			this.cmbBrowseFileType.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.cmbBrowseFileType.DropDownWidth = 320;
			this.cmbBrowseFileType.Enabled = false;
			this.cmbBrowseFileType.ItemHeight = 13;
			Point location20 = new Point(72, 338);
			this.cmbBrowseFileType.Location = location20;
			this.cmbBrowseFileType.Name = "cmbBrowseFileType";
			Size size20 = new Size(348, 21);
			this.cmbBrowseFileType.Size = size20;
			this.cmbBrowseFileType.TabIndex = 5;
			this.cmbBrowseFileType.Text = "All Files (*.*)";
			this.btnBrowseLocationRoot.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.btnBrowseLocationRoot.FlatStyle = FlatStyle.System;
			Point location21 = new Point(336, 4);
			this.btnBrowseLocationRoot.Location = location21;
			this.btnBrowseLocationRoot.Name = "btnBrowseLocationRoot";
			Size size21 = new Size(24, 21);
			this.btnBrowseLocationRoot.Size = size21;
			this.btnBrowseLocationRoot.TabIndex = 3;
			this.btnBrowseLocationRoot.Text = "/";
			this.btnBrowseLocationRoot.Click += new EventHandler(this.btnBrowseLocationRoot_Click);
			this.btnBrowseLocationUp.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.btnBrowseLocationUp.FlatStyle = FlatStyle.System;
			Point location22 = new Point(308, 4);
			this.btnBrowseLocationUp.Location = location22;
			this.btnBrowseLocationUp.Name = "btnBrowseLocationUp";
			Size size22 = new Size(24, 21);
			this.btnBrowseLocationUp.Size = size22;
			this.btnBrowseLocationUp.TabIndex = 2;
			this.btnBrowseLocationUp.Text = "^";
			this.btnBrowseLocationUp.Click += new EventHandler(this.btnBrowseLocationUp_Click);
			this.cmbBrowseLocation.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.cmbBrowseLocation.DropDownWidth = 272;
			this.cmbBrowseLocation.Enabled = false;
			this.cmbBrowseLocation.ItemHeight = 13;
			Point location23 = new Point(72, 4);
			this.cmbBrowseLocation.Location = location23;
			this.cmbBrowseLocation.Name = "cmbBrowseLocation";
			Size size23 = new Size(232, 21);
			this.cmbBrowseLocation.Size = size23;
			this.cmbBrowseLocation.TabIndex = 1;
			this.tabRecent.Controls.Add(this.panRecent);
			Point location24 = new Point(4, 4);
			this.tabRecent.Location = location24;
			this.tabRecent.Name = "tabRecent";
			Size size24 = new Size(421, 366);
			this.tabRecent.Size = size24;
			this.tabRecent.TabIndex = 2;
			this.tabRecent.Text = "Recent";
			this.tabRecent.Visible = false;
			this.panRecent.Controls.Add(this.radRecentThumbnails);
			this.panRecent.Controls.Add(this.radRecentDetails);
			this.panRecent.Controls.Add(this.labRecentLocation);
			this.panRecent.Controls.Add(this.btnRecentLocationRoot);
			this.panRecent.Controls.Add(this.btnRecentLocationUp);
			this.panRecent.Controls.Add(this.cmbRecentLocation);
			this.panRecent.Controls.Add(this.listRecent);
			this.panRecent.Controls.Add(this.labRecentFileType);
			this.panRecent.Controls.Add(this.labRecentFileName);
			this.panRecent.Controls.Add(this.cmbRecentFileName);
			this.panRecent.Controls.Add(this.cmbRecentFileType);
			this.panRecent.Dock = DockStyle.Fill;
			Point location25 = new Point(0, 0);
			this.panRecent.Location = location25;
			this.panRecent.Name = "panRecent";
			Size size25 = new Size(421, 366);
			this.panRecent.Size = size25;
			this.panRecent.TabIndex = 5;
			this.radRecentThumbnails.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.radRecentThumbnails.Appearance = Appearance.Button;
			this.radRecentThumbnails.FlatStyle = FlatStyle.System;
			Point location26 = new Point(396, 4);
			this.radRecentThumbnails.Location = location26;
			this.radRecentThumbnails.Name = "radRecentThumbnails";
			Size size26 = new Size(24, 21);
			this.radRecentThumbnails.Size = size26;
			this.radRecentThumbnails.TabIndex = 18;
			this.radRecentThumbnails.Text = "T";
			this.radRecentThumbnails.CheckedChanged += new EventHandler(this.radRecentThumbnails_CheckedChanged);
			this.radRecentDetails.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.radRecentDetails.Appearance = Appearance.Button;
			this.radRecentDetails.Checked = true;
			this.radRecentDetails.FlatStyle = FlatStyle.System;
			Point location27 = new Point(368, 4);
			this.radRecentDetails.Location = location27;
			this.radRecentDetails.Name = "radRecentDetails";
			Size size27 = new Size(24, 21);
			this.radRecentDetails.Size = size27;
			this.radRecentDetails.TabIndex = 17;
			this.radRecentDetails.TabStop = true;
			this.radRecentDetails.Text = "D";
			this.radRecentDetails.CheckedChanged += new EventHandler(this.radRecentDetails_CheckedChanged);
			this.labRecentLocation.Enabled = false;
			Point location28 = new Point(21, 7);
			this.labRecentLocation.Location = location28;
			this.labRecentLocation.Name = "labRecentLocation";
			Size size28 = new Size(50, 16);
			this.labRecentLocation.Size = size28;
			this.labRecentLocation.TabIndex = 16;
			this.labRecentLocation.Text = "Location:";
			this.btnRecentLocationRoot.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.btnRecentLocationRoot.Enabled = false;
			this.btnRecentLocationRoot.FlatStyle = FlatStyle.System;
			Point location29 = new Point(336, 4);
			this.btnRecentLocationRoot.Location = location29;
			this.btnRecentLocationRoot.Name = "btnRecentLocationRoot";
			Size size29 = new Size(24, 21);
			this.btnRecentLocationRoot.Size = size29;
			this.btnRecentLocationRoot.TabIndex = 15;
			this.btnRecentLocationRoot.Text = "/";
			this.btnRecentLocationUp.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.btnRecentLocationUp.Enabled = false;
			this.btnRecentLocationUp.FlatStyle = FlatStyle.System;
			Point location30 = new Point(308, 4);
			this.btnRecentLocationUp.Location = location30;
			this.btnRecentLocationUp.Name = "btnRecentLocationUp";
			Size size30 = new Size(24, 21);
			this.btnRecentLocationUp.Size = size30;
			this.btnRecentLocationUp.TabIndex = 14;
			this.btnRecentLocationUp.Text = "^";
			this.cmbRecentLocation.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.cmbRecentLocation.DropDownWidth = 272;
			this.cmbRecentLocation.Enabled = false;
			this.cmbRecentLocation.ItemHeight = 13;
			Point location31 = new Point(72, 4);
			this.cmbRecentLocation.Location = location31;
			this.cmbRecentLocation.Name = "cmbRecentLocation";
			Size size31 = new Size(232, 21);
			this.cmbRecentLocation.Size = size31;
			this.cmbRecentLocation.TabIndex = 13;
			this.listRecent.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			ColumnHeader[] values2 = new ColumnHeader[]
			{
				this.colRecentFileName
			};
			this.listRecent.Columns.AddRange(values2);
			this.listRecent.FullRowSelect = true;
			this.listRecent.HideSelection = false;
			this.listRecent.LargeImageList = this.imgFileTypeLargeIcons;
			Point location32 = new Point(4, 28);
			this.listRecent.Location = location32;
			this.listRecent.MultiSelect = false;
			this.listRecent.Name = "listRecent";
			Size size32 = new Size(416, 283);
			this.listRecent.Size = size32;
			this.listRecent.SmallImageList = this.imgFileTypeSmallIcons;
			this.listRecent.TabIndex = 10;
			this.listRecent.View = View.Details;
			this.listRecent.ItemActivate += new EventHandler(this.listRecent_ItemActivate);
			this.listRecent.SelectedIndexChanged += new EventHandler(this.listRecent_SelectedIndexChanged);
			this.colRecentFileName.Text = "Name";
			this.colRecentFileName.Width = 410;
			this.labRecentFileType.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.labRecentFileType.Enabled = false;
			Point location33 = new Point(21, 341);
			this.labRecentFileType.Location = location33;
			this.labRecentFileType.Name = "labRecentFileType";
			Size size33 = new Size(50, 16);
			this.labRecentFileType.Size = size33;
			this.labRecentFileType.TabIndex = 8;
			this.labRecentFileType.Text = "FileType:";
			this.labRecentFileName.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
			this.labRecentFileName.Enabled = false;
			Point location34 = new Point(18, 317);
			this.labRecentFileName.Location = location34;
			this.labRecentFileName.Name = "labRecentFileName";
			Size size34 = new Size(54, 16);
			this.labRecentFileName.Size = size34;
			this.labRecentFileName.TabIndex = 7;
			this.labRecentFileName.Text = "FileName:";
			this.cmbRecentFileName.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.cmbRecentFileName.DropDownWidth = 320;
			this.cmbRecentFileName.Enabled = false;
			this.cmbRecentFileName.ItemHeight = 13;
			Point location35 = new Point(72, 314);
			this.cmbRecentFileName.Location = location35;
			this.cmbRecentFileName.Name = "cmbRecentFileName";
			Size size35 = new Size(348, 21);
			this.cmbRecentFileName.Size = size35;
			this.cmbRecentFileName.TabIndex = 6;
			this.cmbRecentFileName.TextChanged += new EventHandler(this.cmbRecentFileName_TextChanged);
			this.cmbRecentFileType.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.cmbRecentFileType.DropDownWidth = 320;
			this.cmbRecentFileType.Enabled = false;
			this.cmbRecentFileType.ItemHeight = 13;
			Point location36 = new Point(72, 338);
			this.cmbRecentFileType.Location = location36;
			this.cmbRecentFileType.Name = "cmbRecentFileType";
			Size size36 = new Size(348, 21);
			this.cmbRecentFileType.Size = size36;
			this.cmbRecentFileType.TabIndex = 5;
			this.cmbRecentFileType.Text = "All Files (*.*)";
			this.panPreview.Controls.Add(this.panRecentPreViewport);
			this.panPreview.Controls.Add(this.labRecentPreview);
			this.panPreview.Controls.Add(this.btnCancel);
			this.panPreview.Controls.Add(this.btnOK);
			this.panPreview.Dock = DockStyle.Right;
			Point location37 = new Point(432, 0);
			this.panPreview.Location = location37;
			this.panPreview.Name = "panPreview";
			Size size37 = new Size(200, 413);
			this.panPreview.Size = size37;
			this.panPreview.TabIndex = 4;
			this.panRecentPreViewport.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.panRecentPreViewport.BorderStyle = BorderStyle.Fixed3D;
			this.panRecentPreViewport.Controls.Add(this.labRecentPreviewUnderConstruction);
			Point location38 = new Point(0, 32);
			this.panRecentPreViewport.Location = location38;
			this.panRecentPreViewport.Name = "panRecentPreViewport";
			Size size38 = new Size(196, 340);
			this.panRecentPreViewport.Size = size38;
			this.panRecentPreViewport.TabIndex = 12;
			this.labRecentPreviewUnderConstruction.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			this.labRecentPreviewUnderConstruction.Enabled = false;
			Point location39 = new Point(8, 8);
			this.labRecentPreviewUnderConstruction.Location = location39;
			this.labRecentPreviewUnderConstruction.Name = "labRecentPreviewUnderConstruction";
			Size size39 = new Size(179, 16);
			this.labRecentPreviewUnderConstruction.Size = size39;
			this.labRecentPreviewUnderConstruction.TabIndex = 0;
			this.labRecentPreviewUnderConstruction.Text = "Under Construction!";
			this.labRecentPreviewUnderConstruction.TextAlign = ContentAlignment.TopCenter;
			this.labRecentPreview.Enabled = false;
			Point location40 = new Point(8, 12);
			this.labRecentPreview.Location = location40;
			this.labRecentPreview.Name = "labRecentPreview";
			Size size40 = new Size(50, 17);
			this.labRecentPreview.Size = size40;
			this.labRecentPreview.TabIndex = 11;
			this.labRecentPreview.Text = "Preview:";
			this.btnCancel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.btnCancel.DialogResult = DialogResult.Cancel;
			this.btnCancel.FlatStyle = FlatStyle.System;
			Point location41 = new Point(104, 381);
			this.btnCancel.Location = location41;
			this.btnCancel.Name = "btnCancel";
			Size size41 = new Size(80, 24);
			this.btnCancel.Size = size41;
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnOK.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.btnOK.FlatStyle = FlatStyle.System;
			Point location42 = new Point(20, 381);
			this.btnOK.Location = location42;
			this.btnOK.Name = "btnOK";
			Size size42 = new Size(80, 24);
			this.btnOK.Size = size42;
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "Create";
			this.btnOK.Click += new EventHandler(this.btnOK_Click);
			this.splitPreview.Dock = DockStyle.Right;
			Point location43 = new Point(429, 0);
			this.splitPreview.Location = location43;
			this.splitPreview.MinExtra = 400;
			this.splitPreview.MinSize = 200;
			this.splitPreview.Name = "splitPreview";
			Size size43 = new Size(3, 413);
			this.splitPreview.Size = size43;
			this.splitPreview.TabIndex = 5;
			this.splitPreview.TabStop = false;
			Point location44 = new Point(8, 17);
			this.label1.Location = location44;
			this.label1.Name = "label1";
			Size size44 = new Size(96, 15);
			this.label1.Size = size44;
			this.label1.TabIndex = 0;
			this.label1.Text = "Inherit unit from:";
			base.AcceptButton = this.btnOK;
			base.AutoScale = false;
			Size autoScaleBaseSize = new Size(5, 14);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			base.CancelButton = this.btnCancel;
			Size clientSize = new Size(632, 413);
			base.ClientSize = clientSize;
			base.Controls.Add(this.panTab);
			base.Controls.Add(this.splitPreview);
			base.Controls.Add(this.panPreview);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Icon = (Icon)resourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			Size minimumSize = new Size(640, 440);
			this.MinimumSize = minimumSize;
			base.Name = "NFileDialog";
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "New";
			base.Activated += new EventHandler(this.NFileDialog_Activated);
			this.panTab.ResumeLayout(false);
			this.tabMode.ResumeLayout(false);
			this.tabNew.ResumeLayout(false);
			this.InheritGroup.ResumeLayout(false);
			this.SizeGroup.ResumeLayout(false);
			((ISupportInitialize)this.trkHeight).EndInit();
			((ISupportInitialize)this.trkWidth).EndInit();
			this.tabBrowse.ResumeLayout(false);
			this.panBrowse.ResumeLayout(false);
			this.tabRecent.ResumeLayout(false);
			this.panRecent.ResumeLayout(false);
			this.panPreview.ResumeLayout(false);
			this.panRecentPreViewport.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private unsafe void HandleShellMenu()
		{
			GBaseString<char> gBaseString<char> = 0;
			*(ref gBaseString<char> + 4) = 0;
			try
			{
				if (this.listBrowse.SelectedItems.Count > 0)
				{
					GBaseString<char> gBaseString<char>2;
					GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, this.listBrowse.SelectedItems[0].Text);
					try
					{
						int num = *(ptr + 4);
						if (num != 0)
						{
							*(ref gBaseString<char> + 4) = num;
							uint num2 = (uint)(*(ref gBaseString<char> + 4) + 1);
							gBaseString<char> = <Module>.realloc(null, num2);
							cpblk(gBaseString<char>, *ptr, num2);
						}
						else
						{
							*(ref gBaseString<char> + 4) = 0;
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
						gBaseString<char>2 = 0;
					}
				}
				Point point = this.listBrowse.PointToScreen(this.ShellMenuPos);
				IntPtr handle = this.Handle;
				GBaseString<char> gBaseString<char>3;
				GBaseString<char>* ptr2 = <Module>.GPath.GetShellCompatiblePathString(this.propCurrentLocation, &gBaseString<char>3);
				try
				{
					uint num3 = (uint)(*(int*)ptr2);
					sbyte* ptr3;
					if (num3 != 0u)
					{
						ptr3 = num3;
					}
					else
					{
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					<Module>.SHMLoadShellMenu((gBaseString<char> == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>, ptr3, (HWND__*)handle.ToPointer(), point.X, point.Y);
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
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
			}
		}

		public void SetTypeToUnitEditor()
		{
			this.IsUnitEditorType = true;
		}

		private void listBrowse_Resize(object sender, EventArgs e)
		{
			ColumnHeader arg_5B_0 = this.listBrowse.Columns[0];
			ColumnHeader columnHeader = this.listBrowse.Columns[1];
			ColumnHeader columnHeader2 = this.listBrowse.Columns[2];
			Rectangle clientRectangle = this.listBrowse.ClientRectangle;
			int num = -3 - columnHeader.Width - columnHeader2.Width;
			arg_5B_0.Width = clientRectangle.Width + num;
			this.listBrowse.PerformLayout();
		}

		private unsafe void Update_listBrowse()
		{
			uint num = 0u;
			this.listBrowse.SuspendLayout();
			this.listBrowse.Items.Clear();
			GPath gPath;
			<Module>.GPath.{ctor}(ref gPath, this.CurrentLocation);
			try
			{
				if (((<Module>.GBaseString<char>.Compare(ref gPath, (sbyte*)(&<Module>.??_C@_03MKLNKIKF@?1?10?$AA@), false) != 0) ? 1 : 0) != 0)
				{
					GFoundFiles gFoundFiles = 0;
					*(ref gFoundFiles + 4) = 0;
					*(ref gFoundFiles + 8) = 0;
					try
					{
						if (!this.FullBrowse)
						{
							*(ref gPath + 8) = 0;
						}
						GPath gPath2;
						GPath* ptr = <Module>.GPath.{ctor}(ref gPath2, (sbyte*)(&<Module>.??_C@_01NBENCBCI@?$CK?$AA@));
						try
						{
							GPath gPath3;
							GPath* ptr2 = <Module>.GPath.+(ref gPath, &gPath3, ptr);
							try
							{
								GBaseString<char> gBaseString<char>;
								<Module>.GPath..?AV?$GBaseString@D@@(ptr2, (GBaseString<char>*)(&gBaseString<char>));
								try
								{
									GBaseString<char> gBaseString<char>2;
									if (*(ref gBaseString<char> + 4) != 0)
									{
										*(ref gBaseString<char>2 + 4) = *(ref gBaseString<char> + 4);
										uint num2 = (uint)(*(ref gBaseString<char> + 4) + 1);
										gBaseString<char>2 = <Module>.malloc(num2);
										cpblk(gBaseString<char>2, gBaseString<char>, num2);
									}
									else
									{
										*(ref gBaseString<char>2 + 4) = 0;
										gBaseString<char>2 = 0;
									}
									try
									{
										sbyte* ptr3;
										if (gBaseString<char>2 != null)
										{
											ptr3 = gBaseString<char>2;
										}
										else
										{
											ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
										}
										<Module>.GFileSystem.FindFiles(ref <Module>.FS, ptr3, ref gFoundFiles);
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
									gBaseString<char> = 0;
								}
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath3));
								throw;
							}
							try
							{
								<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath3 + 12);
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath3));
								throw;
							}
							if (gPath3 != null)
							{
								<Module>.free(gPath3);
								gPath3 = 0;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath2));
							throw;
						}
						try
						{
							<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath2 + 12);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath2));
							throw;
						}
						if (gPath2 != null)
						{
							<Module>.free(gPath2);
						}
						if (this.propDefaultExtension.Length > 0)
						{
							int num3 = 0;
							if (0 < *(ref gFoundFiles + 4))
							{
								int num4 = 0;
								while (true)
								{
									if (*(num4 + gFoundFiles) != 0)
									{
										goto IL_25C;
									}
									GBaseString<char> gBaseString<char>3;
									GBaseString<char>* ptr4 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, this.propDefaultExtension);
									GBaseString<char> gBaseString<char>4;
									try
									{
										num |= 1u;
										GBaseString<char>* ptr5 = <Module>.GBaseString<char>.GetExtension(num4 + gFoundFiles + 24, &gBaseString<char>4);
										try
										{
											num |= 2u;
											uint num5 = (uint)(*ptr4);
											sbyte* ptr6;
											if (num5 != 0u)
											{
												ptr6 = num5;
											}
											else
											{
												ptr6 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
											}
											uint num6 = (uint)(*(int*)ptr5);
											if (<Module>.stricmp((num6 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num6, ptr6) != null)
											{
												int num7 = 1;
												goto IL_294;
											}
										}
										catch
										{
											if ((num & 2u) != 0u)
											{
												num &= 4294967293u;
												<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
											}
											throw;
										}
									}
									catch
									{
										if ((num & 1u) != 0u)
										{
											num &= 4294967294u;
											<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
										}
										throw;
									}
									goto IL_25C;
									IL_294:
									bool flag;
									try
									{
										try
										{
											int num7;
											flag = ((byte)num7 != 0);
										}
										catch
										{
											if ((num & 2u) != 0u)
											{
												num &= 4294967293u;
												<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
											}
											throw;
										}
										if ((num & 2u) != 0u)
										{
											num &= 4294967293u;
											if (gBaseString<char>4 != null)
											{
												<Module>.free(gBaseString<char>4);
												gBaseString<char>4 = 0;
											}
										}
									}
									catch
									{
										if ((num & 1u) != 0u)
										{
											num &= 4294967294u;
											<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
										}
										throw;
									}
									if ((num & 1u) != 0u)
									{
										num &= 4294967294u;
										if (gBaseString<char>3 != null)
										{
											<Module>.free(gBaseString<char>3);
											gBaseString<char>3 = 0;
										}
									}
									if (flag)
									{
										<Module>.GArray<GFoundFile>.Remove(ref gFoundFiles, num3);
									}
									else
									{
										num3++;
										num4 += 32;
									}
									if (num3 >= *(ref gFoundFiles + 4))
									{
										break;
									}
									continue;
									IL_25C:
									try
									{
										try
										{
											int num7 = 0;
										}
										catch
										{
											if ((num & 2u) != 0u)
											{
												num &= 4294967293u;
												<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>4));
											}
											throw;
										}
									}
									catch
									{
										if ((num & 1u) != 0u)
										{
											num &= 4294967294u;
											<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>3));
										}
										throw;
									}
									goto IL_294;
								}
							}
						}
						method _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z = <Module>.__unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z;
						if (0 < *(ref gFoundFiles + 4))
						{
							<Module>.qsort(gFoundFiles, (uint)(*(ref gFoundFiles + 4)), 32u, _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z);
						}
						if (*(int*)(this.CurrentLocation + 16 / sizeof(GPath)) != 0 || this.FullBrowse)
						{
							ListViewItem listViewItem;
							if (*(int*)(this.CurrentLocation + 16 / sizeof(GPath)) != 0)
							{
								listViewItem = new ListViewItem("..");
							}
							else
							{
								listViewItem = new ListViewItem("//0/");
							}
							listViewItem.SubItems.Add("<DIR>  ");
							listViewItem.ImageIndex = 1;
							listViewItem.SubItems.Add("");
							this.listBrowse.Items.Add(listViewItem);
						}
						int num8 = 0;
						if (0 < *(ref gFoundFiles + 4))
						{
							int num9 = 0;
							do
							{
								GBaseString<char>* ptr7 = gFoundFiles + num9 + 24;
								int num10 = 0;
								if (0 < *(ptr7 + 4))
								{
									do
									{
										int num11 = num10 + *ptr7;
										if (*num11 == 92)
										{
											*num11 = 47;
										}
										num10++;
									}
									while (num10 < *(ptr7 + 4));
								}
								int num12 = gFoundFiles + num9;
								GFoundFile* ptr8 = num12;
								if (0 >= *(ptr8 + 24 + 4))
								{
									goto IL_533;
								}
								if (*(*(ptr8 + 24)) != 46)
								{
									uint num13 = (uint)(*(num12 + 24));
									ListViewItem listViewItem2 = new ListViewItem(new string((sbyte*)((num13 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num13)));
									num12 = gFoundFiles + num9;
									if (*num12 != 0)
									{
										listViewItem2.SubItems.Add("<DIR>  ");
										GFoundFile* ptr9 = num9 + gFoundFiles;
										if (0 >= *(ptr9 + 24 + 4))
										{
											goto IL_514;
										}
										int imageIndex = (*(*(ptr9 + 24)) == 46) ? 1 : 2;
										listViewItem2.ImageIndex = imageIndex;
									}
									else
									{
										long num14 = *(num12 + 16);
										listViewItem2.SubItems.Add(num14.ToString());
										listViewItem2.ImageIndex = 0;
									}
									DateTime dateTime = DateTime.FromFileTime(*(gFoundFiles + num9 + 8));
									listViewItem2.SubItems.Add(dateTime.ToString());
									this.listBrowse.Items.Add(listViewItem2);
								}
								num8++;
								num9 += 32;
							}
							while (num8 < *(ref gFoundFiles + 4));
							goto IL_552;
							IL_514:
							<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
							<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), 0);
							IL_533:
							<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
							<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), 0);
						}
						IL_552:;
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GFoundFiles.{dtor}), (void*)(&gFoundFiles));
						throw;
					}
					int num15 = 0;
					if (0 < *(ref gFoundFiles + 4))
					{
						int num16 = 0;
						do
						{
							<Module>.GFoundFile.__delDtor(num16 + gFoundFiles, 0u);
							num15++;
							num16 += 32;
						}
						while (num15 < *(ref gFoundFiles + 4));
					}
					if (gFoundFiles != null)
					{
						<Module>.free(gFoundFiles);
					}
				}
				else
				{
					sbyte b = 65;
					do
					{
						GBaseString<char> gBaseString<char>5;
						GBaseString<char>* ptr10 = <Module>.Format(&gBaseString<char>5, (sbyte*)(&<Module>.??_C@_04CGJNICGF@?$CFc?3?2?$AA@), b);
						uint driveTypeA;
						try
						{
							uint num17 = (uint)(*(int*)ptr10);
							driveTypeA = <Module>.GetDriveTypeA((num17 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num17);
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
						if (driveTypeA > 1u)
						{
							GBaseString<char> gBaseString<char>6;
							GBaseString<char>* ptr11 = <Module>.Format(&gBaseString<char>6, (sbyte*)(&<Module>.??_C@_04CGJNICGF@?$CFc?3?2?$AA@), b);
							ListViewItem listViewItem3;
							try
							{
								uint num18 = (uint)(*(int*)ptr11);
								listViewItem3 = new ListViewItem(new string((sbyte*)((num18 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num18)));
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
							switch (driveTypeA)
							{
							case 2u:
								listViewItem3.SubItems.Add("<Removable>");
								break;
							case 3u:
								listViewItem3.SubItems.Add("<Fixed>");
								break;
							case 4u:
								listViewItem3.SubItems.Add("<Remote>");
								break;
							case 5u:
								listViewItem3.SubItems.Add("<CD-ROM>");
								break;
							case 6u:
								listViewItem3.SubItems.Add("<Ramdisk>");
								break;
							default:
								listViewItem3.SubItems.Add("<Unknown>");
								break;
							}
							listViewItem3.ImageIndex = 2;
							listViewItem3.SubItems.Add("");
							this.listBrowse.Items.Add(listViewItem3);
						}
						b += 1;
					}
					while (b <= 90);
				}
				this.listBrowse.ResumeLayout();
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath));
				throw;
			}
			try
			{
				<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath + 12);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath));
				throw;
			}
			if (gPath != null)
			{
				<Module>.free(gPath);
			}
		}

		private void listBrowse_Activated(object sender, EventArgs e)
		{
		}

		private unsafe void listRecent_Activated(object sender, EventArgs e)
		{
			this.listRecent.SuspendLayout();
			this.listRecent.Items.Clear();
			int num = 0;
			GArray<GBaseString<char> >* recentFiles = this.RecentFiles;
			if (0 < *(int*)(recentFiles + 4 / sizeof(GArray<GBaseString<char> >)))
			{
				do
				{
					uint num2 = (uint)(*(num * 8 + *(int*)recentFiles));
					ListViewItem listViewItem = new ListViewItem(new string((sbyte*)((num2 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num2)));
					listViewItem.Tag = num;
					listViewItem.ImageIndex = 0;
					this.listRecent.Items.Add(listViewItem);
					num++;
					recentFiles = this.RecentFiles;
				}
				while (num < *(int*)(recentFiles + 4 / sizeof(GArray<GBaseString<char> >)));
			}
			if (this.listRecent.Items.Count != 0)
			{
				this.listRecent.Items[0].Selected = true;
			}
			this.listRecent.ResumeLayout();
		}

		private void NFileDialog_Activated(object sender, EventArgs e)
		{
			int num = this.propSelectedMode;
			if (num == 1)
			{
				this.Text = "New";
				this.btnOK.Text = "Create";
				this.btnOK.Enabled = true;
			}
			else if (num == 2)
			{
				this.Text = "Open";
				this.btnOK.Text = "Open";
				this.cmbBrowseFileName.Text = "";
				this.cmbBrowseFileName_TextChanged(sender, e);
				this.Update_listBrowse();
			}
			else if (num == 4)
			{
				this.Text = "Save As";
				this.btnOK.Text = "Save";
				this.cmbBrowseFileName.Text = "";
				this.cmbBrowseFileName_TextChanged(sender, e);
				this.Update_listBrowse();
			}
			else if (num == 8)
			{
				this.Text = "Open Recent";
				this.btnOK.Text = "Open";
				this.cmbRecentLocation.Text = "";
				this.cmbRecentFileName.Text = "";
				this.cmbRecentFileName_TextChanged(sender, e);
				this.listRecent_Activated(sender, e);
			}
		}

		private void tabMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.tabMode.SelectedTab == this.tabNew)
			{
				this.propSelectedMode = (this.propAvailableModes & 1);
			}
			else if (this.tabMode.SelectedTab == this.tabBrowse)
			{
				this.propSelectedMode = (this.propAvailableModes & 2);
			}
			else if (this.tabMode.SelectedTab == this.tabRecent)
			{
				this.propSelectedMode = (this.propAvailableModes & 8);
			}
			this.NFileDialog_Activated(sender, e);
		}

		private unsafe void btnBrowseLocationRoot_Click(object sender, EventArgs e)
		{
			GPath gPath;
			<Module>.GPath.{ctor}(ref gPath, this.CurrentLocation);
			try
			{
				*(ref gPath + 8) = 1;
				<Module>.GArray<GBaseString<char> >.Clear(ref gPath + 12, 0);
				this.CurrentLocation = &gPath;
				this.cmbBrowseFileName.Text = "";
				this.btnOK.Enabled = false;
				this.Update_listBrowse();
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath));
				throw;
			}
			try
			{
				<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath + 12);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath));
				throw;
			}
			if (gPath != null)
			{
				<Module>.free(gPath);
			}
		}

		private unsafe void btnBrowseLocationUp_Click(object sender, EventArgs e)
		{
			GPath gPath;
			<Module>.GPath.{ctor}(ref gPath, this.CurrentLocation);
			try
			{
				if (*(ref gPath + 16) != 0)
				{
					GPath gPath2;
					GPath* ptr = <Module>.GPath.{ctor}(ref gPath2, (sbyte*)(&<Module>.??_C@_02DJGKEECL@?4?4?$AA@));
					try
					{
						<Module>.GPath.+=(ref gPath, ptr);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath2));
						throw;
					}
					try
					{
						<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath2 + 12);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath2));
						throw;
					}
					if (gPath2 != null)
					{
						<Module>.free(gPath2);
					}
				}
				else if (this.FullBrowse)
				{
					GPath gPath3;
					GPath* ptr2 = <Module>.GPath.{ctor}(ref gPath3, (sbyte*)(&<Module>.??_C@_04LEGKNCKC@?1?10?1?$AA@));
					try
					{
						<Module>.GPath.+=(ref gPath, ptr2);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath3));
						throw;
					}
					try
					{
						<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath3 + 12);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath3));
						throw;
					}
					if (gPath3 != null)
					{
						<Module>.free(gPath3);
					}
				}
				this.CurrentLocation = &gPath;
				this.cmbBrowseFileName.Text = "";
				this.btnOK.Enabled = false;
				this.Update_listBrowse();
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath));
				throw;
			}
			try
			{
				<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath + 12);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath));
				throw;
			}
			if (gPath != null)
			{
				<Module>.free(gPath);
			}
		}

		private void listBrowse_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListView.SelectedListViewItemCollection selectedItems = this.listBrowse.SelectedItems;
			if (selectedItems.Count == 1)
			{
				this.cmbBrowseFileName.Text = selectedItems[0].Text;
			}
		}

		private unsafe void listRecent_SelectedIndexChanged(object sender, EventArgs e)
		{
			uint num = 0u;
			ListView.SelectedListViewItemCollection selectedItems = this.listRecent.SelectedItems;
			if (selectedItems.Count == 1)
			{
				string text = selectedItems[0].Text;
				int num2 = text.LastIndexOf('\\');
				int num3 = text.LastIndexOf('/');
				int num4;
				if (num3 > num2)
				{
					num4 = num3;
				}
				else
				{
					num4 = num2;
				}
				GPath* ptr = <Module>.@new(24u);
				GBaseString<char> gBaseString<char>;
				GPath* currentLocation;
				try
				{
					if (ptr != null)
					{
						GBaseString<char>* ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, text.Substring(0, num4 + 1));
						try
						{
							num = 1u;
							uint num5 = (uint)(*ptr2);
							sbyte* ptr3;
							if (num5 != 0u)
							{
								ptr3 = num5;
							}
							else
							{
								ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							currentLocation = <Module>.GPath.{ctor}(ptr, ptr3);
							goto IL_AB;
						}
						catch
						{
							if ((num & 1u) != 0u)
							{
								num &= 4294967294u;
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
							}
							throw;
						}
					}
					currentLocation = 0;
					IL_AB:;
				}
				catch
				{
					<Module>.delete((void*)ptr);
					throw;
				}
				try
				{
					this.CurrentLocation = currentLocation;
				}
				catch
				{
					if ((num & 1u) != 0u)
					{
						num &= 4294967294u;
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
					}
					throw;
				}
				if ((num & 1u) != 0u)
				{
					num &= 4294967294u;
					if (gBaseString<char> != null)
					{
						<Module>.free(gBaseString<char>);
					}
				}
				this.cmbRecentFileName.Text = text.Substring(num4 + 1);
			}
			else
			{
				this.cmbRecentLocation.Text = "";
				this.cmbRecentFileName.Text = "";
			}
		}

		private unsafe void btnOK_Click(object sender, EventArgs e)
		{
			uint num = 0u;
			int num2 = this.propSelectedMode;
			if (num2 == 1)
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
			}
			else if (num2 != 2 && num2 != 4)
			{
				if (num2 == 8)
				{
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.cmbRecentFileName.Text);
					GPath gPath2;
					try
					{
						uint num3 = (uint)(*ptr);
						sbyte* ptr2;
						if (num3 != 0u)
						{
							ptr2 = num3;
						}
						else
						{
							ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						GPath gPath;
						GPath* ptr3 = <Module>.GPath.{ctor}(ref gPath, ptr2);
						try
						{
							<Module>.GPath.+(this.CurrentLocation, &gPath2, ptr3);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath));
							throw;
						}
						try
						{
							<Module>.GPath.{dtor}(ref gPath);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath2));
							throw;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
						throw;
					}
					try
					{
						if (gBaseString<char> != null)
						{
							<Module>.free(gBaseString<char>);
						}
						<Module>.GPath.MakeFull(ref gPath2);
						GBaseString<char> gBaseString<char>2;
						<Module>.GPath..?AV?$GBaseString@D@@(ref gPath2, (GBaseString<char>*)(&gBaseString<char>2));
						uint num5;
						try
						{
							GBaseString<char> gBaseString<char>3;
							GBaseString<char>* ptr4 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, ref gBaseString<char>2);
							try
							{
								uint num4 = (uint)(*ptr4);
								num5 = <Module>.GetFileAttributesA((num4 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num4);
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
						if (((<Module>.GBaseString<char>.Compare(ref gPath2, (sbyte*)(&<Module>.??_C@_03MKLNKIKF@?1?10?$AA@), false) == 0) ? 1 : 0) != 0)
						{
							num5 = 16u;
						}
						else if (num5 == 4294967295u)
						{
							GBaseString<char> gBaseString<char>4;
							<Module>.GPath..?AV?$GBaseString@D@@(ref gPath2, (GBaseString<char>*)(&gBaseString<char>4));
							string text;
							try
							{
								GBaseString<char> gBaseString<char>5;
								GBaseString<char>* ptr5 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>5, ref gBaseString<char>4);
								try
								{
									uint num6 = (uint)(*ptr5);
									sbyte* value;
									if (num6 != 0u)
									{
										value = num6;
									}
									else
									{
										value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
									}
									text = string.Format("'{0}'\nFile not found.", new string((sbyte*)value));
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
							MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							goto IL_22B;
						}
						if ((num5 & 16u) == 0u)
						{
							this.Location = this.CurrentLocation;
							this.propFileName = this.cmbRecentFileName.Text;
							base.DialogResult = DialogResult.OK;
							base.Close();
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath2));
						throw;
					}
					IL_22B:
					<Module>.GPath.{dtor}(ref gPath2);
				}
			}
			else
			{
				GBaseString<char> gBaseString<char>6;
				GBaseString<char>* ptr6 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>6, this.cmbBrowseFileName.Text);
				GPath gPath4;
				try
				{
					uint num7 = (uint)(*ptr6);
					sbyte* ptr7;
					if (num7 != 0u)
					{
						ptr7 = num7;
					}
					else
					{
						ptr7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					GPath gPath3;
					GPath* ptr8 = <Module>.GPath.{ctor}(ref gPath3, ptr7);
					try
					{
						<Module>.GPath.+(this.CurrentLocation, &gPath4, ptr8);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath3));
						throw;
					}
					try
					{
						try
						{
							<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath3 + 12);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath3));
							throw;
						}
						if (gPath3 != null)
						{
							<Module>.free(gPath3);
							gPath3 = 0;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath4));
						throw;
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>6));
					throw;
				}
				try
				{
					if (gBaseString<char>6 != null)
					{
						<Module>.free(gBaseString<char>6);
					}
					<Module>.GPath.MakeFull(ref gPath4);
					GBaseString<char> gBaseString<char>7;
					<Module>.GPath..?AV?$GBaseString@D@@(ref gPath4, (GBaseString<char>*)(&gBaseString<char>7));
					uint num9;
					try
					{
						GBaseString<char> gBaseString<char>8;
						if (*(ref gBaseString<char>7 + 4) != 0)
						{
							*(ref gBaseString<char>8 + 4) = *(ref gBaseString<char>7 + 4);
							uint num8 = (uint)(*(ref gBaseString<char>7 + 4) + 1);
							gBaseString<char>8 = <Module>.malloc(num8);
							cpblk(gBaseString<char>8, gBaseString<char>7, num8);
						}
						else
						{
							*(ref gBaseString<char>8 + 4) = 0;
							gBaseString<char>8 = 0;
						}
						try
						{
							num9 = <Module>.GetFileAttributesA((gBaseString<char>8 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>8);
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>8));
							throw;
						}
						if (gBaseString<char>8 != null)
						{
							<Module>.free(gBaseString<char>8);
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>7));
						throw;
					}
					if (gBaseString<char>7 != null)
					{
						<Module>.free(gBaseString<char>7);
					}
					if (((<Module>.GBaseString<char>.Compare(ref gPath4, (sbyte*)(&<Module>.??_C@_03MKLNKIKF@?1?10?$AA@), false) == 0) ? 1 : 0) != 0)
					{
						num9 = 16u;
					}
					else if (num9 == 4294967295u)
					{
						if (this.propSelectedMode != 2 && <Module>.GetLastError() == 2)
						{
							this.Location = this.CurrentLocation;
							this.propFileName = this.cmbBrowseFileName.Text;
							GBaseString<char> gBaseString<char>9;
							GBaseString<char> gBaseString<char>10;
							int num10;
							if (this.propDefaultExtension.Length > 0)
							{
								GBaseString<char>* ptr9 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>9, this.propFileName);
								try
								{
									num = 1u;
									GBaseString<char>* ptr10 = <Module>.GBaseString<char>.GetExtension(ptr9, &gBaseString<char>10);
									try
									{
										num = 3u;
										if (((*(int*)(ptr10 + 4 / sizeof(GBaseString<char>)) == 0) ? 1 : 0) != 0)
										{
											if (this.propFileName[this.propFileName.Length - 1] != '.')
											{
												num10 = 1;
												goto IL_4A5;
											}
										}
									}
									catch
									{
										if ((num & 2u) != 0u)
										{
											num &= 4294967293u;
											<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>10));
										}
										throw;
									}
								}
								catch
								{
									if ((num & 1u) != 0u)
									{
										num &= 4294967294u;
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>9));
									}
									throw;
								}
							}
							try
							{
								try
								{
									num10 = 0;
								}
								catch
								{
									if ((num & 2u) != 0u)
									{
										num &= 4294967293u;
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>10));
									}
									throw;
								}
							}
							catch
							{
								if ((num & 1u) != 0u)
								{
									num &= 4294967294u;
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>9));
								}
								throw;
							}
							IL_4A5:
							bool flag;
							try
							{
								try
								{
									flag = ((byte)num10 != 0);
								}
								catch
								{
									if ((num & 2u) != 0u)
									{
										num &= 4294967293u;
										<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>10));
									}
									throw;
								}
								if ((num & 2u) != 0u)
								{
									num &= 4294967293u;
									if (gBaseString<char>10 != null)
									{
										<Module>.free(gBaseString<char>10);
										gBaseString<char>10 = 0;
									}
								}
							}
							catch
							{
								if ((num & 1u) != 0u)
								{
									num &= 4294967294u;
									<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>9));
								}
								throw;
							}
							if ((num & 1u) != 0u)
							{
								num &= 4294967294u;
								if (gBaseString<char>9 != null)
								{
									<Module>.free(gBaseString<char>9);
								}
							}
							if (flag)
							{
								this.propFileName = this.propFileName + "." + this.propDefaultExtension;
							}
							base.DialogResult = DialogResult.OK;
							base.Close();
							goto IL_653;
						}
						GBaseString<char> gBaseString<char>11;
						<Module>.GPath..?AV?$GBaseString@D@@(ref gPath4, (GBaseString<char>*)(&gBaseString<char>11));
						string text2;
						try
						{
							GBaseString<char> gBaseString<char>12;
							if (*(ref gBaseString<char>11 + 4) != 0)
							{
								*(ref gBaseString<char>12 + 4) = *(ref gBaseString<char>11 + 4);
								uint num11 = (uint)(*(ref gBaseString<char>11 + 4) + 1);
								gBaseString<char>12 = <Module>.malloc(num11);
								cpblk(gBaseString<char>12, gBaseString<char>11, num11);
							}
							else
							{
								*(ref gBaseString<char>12 + 4) = 0;
								gBaseString<char>12 = 0;
							}
							try
							{
								sbyte* value2;
								if (gBaseString<char>12 != null)
								{
									value2 = gBaseString<char>12;
								}
								else
								{
									value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								text2 = string.Format("'{0}'\nFile not found.", new string((sbyte*)value2));
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>12));
								throw;
							}
							if (gBaseString<char>12 != null)
							{
								<Module>.free(gBaseString<char>12);
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>11));
							throw;
						}
						if (gBaseString<char>11 != null)
						{
							<Module>.free(gBaseString<char>11);
							gBaseString<char>11 = 0;
						}
						MessageBox.Show(text2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						goto IL_653;
					}
					if ((num9 & 16u) != 0u)
					{
						this.CurrentLocation = &gPath4;
						this.cmbBrowseFileName.Text = "";
						this.Update_listBrowse();
					}
					else
					{
						this.Location = this.CurrentLocation;
						this.propFileName = this.cmbBrowseFileName.Text;
						base.DialogResult = DialogResult.OK;
						base.Close();
					}
					IL_653:;
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GPath.{dtor}), (void*)(&gPath4));
					throw;
				}
				try
				{
					<Module>.GArray<GBaseString<char> >.{dtor}(ref gPath4 + 12);
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gPath4));
					throw;
				}
				if (gPath4 != null)
				{
					<Module>.free(gPath4);
				}
			}
		}

		private void listBrowse_ItemActivate(object sender, EventArgs e)
		{
			this.listBrowse_SelectedIndexChanged(sender, e);
			this.btnOK_Click(sender, e);
		}

		private void listRecent_ItemActivate(object sender, EventArgs e)
		{
			this.listRecent_SelectedIndexChanged(sender, e);
			this.btnOK_Click(sender, e);
		}

		private void radBrowseDetails_CheckedChanged(object sender, EventArgs e)
		{
			this.listBrowse.View = View.Details;
			this.listBrowse.PerformLayout();
			int num = this.propSelectedMode;
			if (num == 2 || num == 4)
			{
				this.radRecentDetails.Checked = true;
				this.radRecentThumbnails.Checked = false;
				this.listRecent.View = View.Details;
				this.listRecent.PerformLayout();
			}
		}

		private void radBrowseThumbnails_CheckedChanged(object sender, EventArgs e)
		{
			this.listBrowse.View = View.LargeIcon;
			this.listBrowse.PerformLayout();
			int num = this.propSelectedMode;
			if (num == 2 || num == 4)
			{
				this.radRecentDetails.Checked = false;
				this.radRecentThumbnails.Checked = true;
				this.listRecent.View = View.LargeIcon;
				this.listRecent.PerformLayout();
			}
		}

		private void cmbBrowseFileName_TextChanged(object sender, EventArgs e)
		{
			byte enabled = (this.cmbBrowseFileName.Text.Length > 0) ? 1 : 0;
			this.btnOK.Enabled = (enabled != 0);
		}

		private void cmbBrowseFileName_KeyPress(object sender, KeyPressEventArgs e)
		{
			this.listBrowse.SelectedItems.Clear();
		}

		private void cmbRecentFileName_TextChanged(object sender, EventArgs e)
		{
			byte enabled = (this.cmbRecentFileName.Text.Length > 0) ? 1 : 0;
			this.btnOK.Enabled = (enabled != 0);
		}

		private void radRecentDetails_CheckedChanged(object sender, EventArgs e)
		{
			this.listRecent.View = View.Details;
			this.listRecent.PerformLayout();
			if (this.propSelectedMode == 8)
			{
				this.radBrowseDetails.Checked = true;
				this.radBrowseThumbnails.Checked = false;
				this.listBrowse.View = View.Details;
				this.listBrowse.PerformLayout();
			}
		}

		private void radRecentThumbnails_CheckedChanged(object sender, EventArgs e)
		{
			this.listRecent.View = View.LargeIcon;
			this.listRecent.PerformLayout();
			if (this.propSelectedMode == 8)
			{
				this.radBrowseDetails.Checked = false;
				this.radBrowseThumbnails.Checked = true;
				this.listBrowse.View = View.LargeIcon;
				this.listBrowse.PerformLayout();
			}
		}

		private unsafe void trkWidth_Scroll(object sender, EventArgs e)
		{
			int num = this.trkWidth.Value * 16;
			this.MapWidth = num;
			if (this.SquareMap)
			{
				this.MapHeight = num;
				this.trkHeight.Value = this.trkWidth.Value;
			}
			this.tbSize.Text = ((float)((float)this.MapWidth * *(ref <Module>.Measures + 4))).ToString() + "x" + ((float)((float)this.MapHeight * *(ref <Module>.Measures + 4))).ToString();
			this.tbInnerSize.Text = ((float)((float)(this.MapWidth - 32) * *(ref <Module>.Measures + 4))).ToString() + "x" + ((float)((float)(this.MapHeight - 32) * *(ref <Module>.Measures + 4))).ToString();
		}

		private unsafe void trkHeight_Scroll(object sender, EventArgs e)
		{
			int num = this.trkHeight.Value * 16;
			this.MapHeight = num;
			if (this.SquareMap)
			{
				this.MapWidth = num;
				this.trkWidth.Value = this.trkHeight.Value;
			}
			this.tbSize.Text = ((float)((float)this.MapWidth * *(ref <Module>.Measures + 4))).ToString() + "x" + ((float)((float)this.MapHeight * *(ref <Module>.Measures + 4))).ToString();
			this.tbInnerSize.Text = ((float)((float)(this.MapWidth - 32) * *(ref <Module>.Measures + 4))).ToString() + "x" + ((float)((float)(this.MapHeight - 32) * *(ref <Module>.Measures + 4))).ToString();
		}

		private unsafe void chkSquare_CheckedChanged(object sender, EventArgs e)
		{
			byte b = (!this.SquareMap) ? 1 : 0;
			this.SquareMap = (b != 0);
			if (b != 0)
			{
				this.MapHeight = this.MapWidth;
				this.trkHeight.Value = this.trkWidth.Value;
			}
			this.tbSize.Text = ((float)((float)this.MapWidth * *(ref <Module>.Measures + 4))).ToString() + "x" + ((float)((float)this.MapHeight * *(ref <Module>.Measures + 4))).ToString();
			this.tbInnerSize.Text = ((float)((float)(this.MapWidth - 32) * *(ref <Module>.Measures + 4))).ToString() + "x" + ((float)((float)(this.MapHeight - 32) * *(ref <Module>.Measures + 4))).ToString();
		}

		private void listBrowse_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				this.ShellMenuPos.X = e.X;
				this.ShellMenuPos.Y = e.Y;
				this.HandleShellMenu();
			}
		}
	}
}
