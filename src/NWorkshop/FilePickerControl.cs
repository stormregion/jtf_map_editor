using <CppImplementationDetails>;
using NControls;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class FilePickerControl : UserControl
	{
		public delegate void FilePickedHandler(string FileName);

		public delegate void ContextMenuPopupHandler(string FileName);

		public enum Mode
		{
			Composite = 2,
			Treeview = 1,
			Thumbnail = 0
		}

		public enum ItemType
		{
			Fileitem = 2,
			Updiritem = 1,
			Diritem = 0
		}

		private Panel MainPanel;

		private ImageList Thumbnails;

		private ImageList TreeViewIcons;

		private Splitter CmpSplitter;

		private MenuItem menuItemRefreshTN;

		private ContextMenu ThumbContextMenu;

		private ContextMenu TreeContextMenu;

		private IContainer components;

		private int LastCompositeHeight;

		private ListView ThumbList;

		private TreeView DirectoryTree;

		private Toolbar FPTools;

		private string RootP;

		private string Current;

		private string ThumbRootVal;

		private string ThumbRootP;

		private string FileP;

		private string[] ExtensionsP;

		private FilePickerControl.Mode ModeP;

		private ThumbnailServer.ThumbType ThumbTypeP;

		private Hashtable ThumbnailIndices;

		private ThumbnailServer ThumbsSrvr;

		private ToolTip ThumbnailTooltip;

		private ImageServer IconsSrvr;

		private bool initialized;

		private int LastTTIndx;

		private bool RestrictMouseEvents;

		private bool FilterNonEditableUnitsP;

		private static Process MViewer = null;

		public event FilePickerControl.ContextMenuPopupHandler ContextPopup
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.ContextPopup = Delegate.Combine(this.ContextPopup, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.ContextPopup = Delegate.Remove(this.ContextPopup, value);
			}
		}

		public event FilePickerControl.FilePickedHandler DoubleClickSelection
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.DoubleClickSelection = Delegate.Combine(this.DoubleClickSelection, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.DoubleClickSelection = Delegate.Remove(this.DoubleClickSelection, value);
			}
		}

		public event FilePickerControl.FilePickedHandler SingleClickSelection
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.SingleClickSelection = Delegate.Combine(this.SingleClickSelection, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.SingleClickSelection = Delegate.Remove(this.SingleClickSelection, value);
			}
		}

		public bool FilterNonEditableUnits
		{
			[param: MarshalAs(UnmanagedType.U1)]
			set
			{
				this.FilterNonEditableUnitsP = value;
			}
		}

		public Menu AddittionalContextMenu
		{
			set
			{
				this.ThumbContextMenu.MenuItems.Clear();
				this.ThumbContextMenu.MenuItems.Add(this.menuItemRefreshTN);
				this.TreeContextMenu.MenuItems.Clear();
				if (value != null)
				{
					this.ThumbContextMenu.MenuItems.Add("-");
					this.ThumbContextMenu.MergeMenu(value);
					this.TreeContextMenu.MenuItems.Add("-");
					this.TreeContextMenu.MergeMenu(value);
				}
			}
		}

		public ThumbnailServer.ThumbType ThumbMode
		{
			get
			{
				return this.ThumbTypeP;
			}
			set
			{
				this.ThumbTypeP = value;
			}
		}

		public FilePickerControl.Mode ViewMode
		{
			get
			{
				return this.ModeP;
			}
			set
			{
				this.ModeP = value;
				if (this.initialized)
				{
					this.CommonInitLogics();
				}
			}
		}

		public string[] Extensions
		{
			get
			{
				return this.ExtensionsP;
			}
			set
			{
				this.ExtensionsP = value;
			}
		}

		public string File
		{
			get
			{
				return this.FileP;
			}
		}

		public string ThumbRoot
		{
			get
			{
				return this.ThumbRootVal;
			}
			set
			{
				this.ThumbRootVal = value;
				this.ThumbRootP = value;
				if (value.Length > 0)
				{
					this.ThumbRootP += "/";
				}
			}
		}

		public string Root
		{
			get
			{
				return this.RootP;
			}
			set
			{
				this.RootP = value;
			}
		}

		public unsafe FilePickerControl()
		{
			this.SingleClickSelection = null;
			this.DoubleClickSelection = null;
			this.ContextPopup = null;
			this.RootP = "";
			this.Current = "";
			this.FileP = new string((sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
			this.ExtensionsP = null;
			this.ModeP = FilePickerControl.Mode.Thumbnail;
			this.ThumbnailIndices = new Hashtable();
			this.InitializeComponent();
			this.initialized = false;
			this.ThumbsSrvr = null;
			this.ThumbTypeP = ThumbnailServer.ThumbType.Model;
			this.IconsSrvr = ImageServer.GetImageServer("Images");
			this.LastTTIndx = -1;
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0FilePickerControl@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), 24);
			this.FPTools = toolbar;
			toolbar.Dock = DockStyle.Top;
			this.FPTools.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.FPTools_ButtonClick);
			Size size = new Size(base.Size.Width, 32);
			this.FPTools.Size = size;
			base.Controls.Add(this.FPTools);
			this.LastCompositeHeight = this.MainPanel.Size.Height / 2 - 4;
			this.RestrictMouseEvents = false;
			this.FilterNonEditableUnitsP = true;
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing)
			{
				ThumbnailServer thumbsSrvr = this.ThumbsSrvr;
				if (thumbsSrvr != null)
				{
					thumbsSrvr.Dispose();
				}
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
			this.MainPanel = new Panel();
			this.Thumbnails = new ImageList(this.components);
			this.TreeViewIcons = new ImageList(this.components);
			this.ThumbContextMenu = new ContextMenu();
			this.menuItemRefreshTN = new MenuItem();
			this.TreeContextMenu = new ContextMenu();
			base.SuspendLayout();
			this.MainPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			Point location = new Point(0, 32);
			this.MainPanel.Location = location;
			this.MainPanel.Name = "MainPanel";
			Size size = new Size(256, 288);
			this.MainPanel.Size = size;
			this.MainPanel.TabIndex = 3;
			this.Thumbnails.ColorDepth = ColorDepth.Depth32Bit;
			Size imageSize = new Size(64, 64);
			this.Thumbnails.ImageSize = imageSize;
			Color magenta = Color.Magenta;
			this.Thumbnails.TransparentColor = magenta;
			this.TreeViewIcons.ColorDepth = ColorDepth.Depth24Bit;
			Size imageSize2 = new Size(16, 16);
			this.TreeViewIcons.ImageSize = imageSize2;
			Color magenta2 = Color.Magenta;
			this.TreeViewIcons.TransparentColor = magenta2;
			MenuItem[] items = new MenuItem[]
			{
				this.menuItemRefreshTN
			};
			this.ThumbContextMenu.MenuItems.AddRange(items);
			this.ThumbContextMenu.Popup += new EventHandler(this.ContextMenu_Popup);
			this.menuItemRefreshTN.Index = 0;
			this.menuItemRefreshTN.Text = "Refresh thumbnail";
			this.menuItemRefreshTN.Click += new EventHandler(this.menuItemRefreshTN_Click);
			this.TreeContextMenu.Popup += new EventHandler(this.ContextMenu_Popup);
			base.Controls.Add(this.MainPanel);
			base.Name = "FilePickerControl";
			Size size2 = new Size(256, 320);
			base.Size = size2;
			base.Load += new EventHandler(this.OnLoad);
			base.ResumeLayout(false);
		}

		private void InitTreeView()
		{
			TreeView treeView = new TreeView();
			this.DirectoryTree = treeView;
			treeView.BorderStyle = BorderStyle.Fixed3D;
			this.DirectoryTree.PathSeparator = "/";
			this.DirectoryTree.ShowLines = false;
			this.DirectoryTree.ShowPlusMinus = false;
			this.DirectoryTree.ShowRootLines = false;
			this.DirectoryTree.ImageList = this.TreeViewIcons;
			Image image = this.IconsSrvr.GetImage("Folder_16", KnownColor.Window);
			if (image != null)
			{
				this.TreeViewIcons.Images.Add(image);
			}
			Image image2 = this.IconsSrvr.GetImage("Folder_Up_16", KnownColor.Window);
			if (image2 != null)
			{
				this.TreeViewIcons.Images.Add(image2);
			}
			Image image3 = this.IconsSrvr.GetImage("Object_16", KnownColor.Window);
			if (image3 != null)
			{
				this.TreeViewIcons.Images.Add(image3);
			}
			Image image4 = this.IconsSrvr.GetImage("Effect_16", KnownColor.Window);
			if (image4 != null)
			{
				this.TreeViewIcons.Images.Add(image4);
			}
			Image image5 = this.IconsSrvr.GetImage("Material_16", KnownColor.Window);
			if (image5 != null)
			{
				this.TreeViewIcons.Images.Add(image5);
			}
			Image image6 = this.IconsSrvr.GetImage("Sound_16", KnownColor.Window);
			if (image6 != null)
			{
				this.TreeViewIcons.Images.Add(image6);
			}
			Image image7 = this.IconsSrvr.GetImage("Unit_16", KnownColor.Window);
			if (image7 != null)
			{
				this.TreeViewIcons.Images.Add(image7);
			}
			Image image8 = this.IconsSrvr.GetImage("Water_16", KnownColor.Window);
			if (image8 != null)
			{
				this.TreeViewIcons.Images.Add(image8);
			}
			Image image9 = this.IconsSrvr.GetImage("Map_16", KnownColor.Window);
			if (image9 != null)
			{
				this.TreeViewIcons.Images.Add(image9);
			}
			this.DirectoryTree.HideSelection = false;
			this.DirectoryTree.DoubleClick += new EventHandler(this.TreeItem_DblClick);
			this.DirectoryTree.MouseDown += new MouseEventHandler(this.TreeItem_SingleClick);
			this.DirectoryTree.MouseUp += new MouseEventHandler(this.TreeviewMouseUp);
			this.DirectoryTree.BeforeSelect += new TreeViewCancelEventHandler(this.TreeItemSelection);
			this.DirectoryTree.TabIndex = 5;
			this.DirectoryTree.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.DirectoryTree.Name = "TreeBrowser";
		}

		private void InitThumbView()
		{
			ListView listView = new ListView();
			this.ThumbList = listView;
			listView.BorderStyle = BorderStyle.Fixed3D;
			this.ThumbList.View = View.LargeIcon;
			this.ThumbList.Font = new Font("Arial", 0.1f, GraphicsUnit.Pixel);
			this.ThumbList.LargeImageList = this.Thumbnails;
			Image image = this.IconsSrvr.GetImage("Folder_64", KnownColor.Window);
			if (image != null)
			{
				this.Thumbnails.Images.Add(image);
			}
			Image image2 = this.IconsSrvr.GetImage("Folder_Up_64", KnownColor.Window);
			if (image2 != null)
			{
				this.Thumbnails.Images.Add(image2);
			}
			Image image3 = this.IconsSrvr.GetImage("Unknown_64", KnownColor.Window);
			if (image3 != null)
			{
				this.Thumbnails.Images.Add(image3);
			}
			Image image4 = this.IconsSrvr.GetImage("Effect_64", KnownColor.Window);
			if (image4 != null)
			{
				this.Thumbnails.Images.Add(image4);
			}
			Image image5 = this.IconsSrvr.GetImage("Sound_64", KnownColor.Window);
			if (image5 != null)
			{
				this.Thumbnails.Images.Add(image5);
			}
			Image image6 = this.IconsSrvr.GetImage("Water_64", KnownColor.Window);
			if (image6 != null)
			{
				this.Thumbnails.Images.Add(image6);
			}
			Image image7 = this.IconsSrvr.GetImage("Map_64", KnownColor.Window);
			if (image7 != null)
			{
				this.Thumbnails.Images.Add(image7);
			}
			this.ThumbList.HideSelection = false;
			this.ThumbList.LabelWrap = false;
			this.ThumbList.DoubleClick += new EventHandler(this.ListItem_DblClick);
			this.ThumbList.Click += new EventHandler(this.ListItem_SingleClick);
			this.ThumbList.MouseUp += new MouseEventHandler(this.ThumbviewMouseUp);
			this.ThumbList.MouseDown += new MouseEventHandler(this.ThumbviewMouseDown);
			ToolTip toolTip = new ToolTip();
			this.ThumbnailTooltip = toolTip;
			toolTip.AutoPopDelay = 0;
			this.ThumbnailTooltip.InitialDelay = 0;
			this.ThumbnailTooltip.ReshowDelay = 0;
			this.ThumbnailTooltip.SetToolTip(this.ThumbList, "");
			this.ThumbnailTooltip.ShowAlways = true;
			this.ThumbList.MouseMove += new MouseEventHandler(this.MouseMove);
			this.ThumbList.MouseWheel += new MouseEventHandler(this.MouseMove);
			this.ThumbList.TabIndex = 6;
			this.ThumbList.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.ThumbList.Name = "ThumbView";
		}

		private void CommonInitLogics()
		{
			if (this.ModeP != FilePickerControl.Mode.Treeview)
			{
				ThumbnailServer.ThumbType thumbTypeP = this.ThumbTypeP;
				if (thumbTypeP != ThumbnailServer.ThumbType.Effect && thumbTypeP != ThumbnailServer.ThumbType.Sound && thumbTypeP != ThumbnailServer.ThumbType.Box && thumbTypeP != ThumbnailServer.ThumbType.Fluid && thumbTypeP != ThumbnailServer.ThumbType.Cloud)
				{
					this.FPTools.SetItemEnable(5, true);
					goto IL_4B;
				}
			}
			this.FPTools.SetItemEnable(5, false);
			IL_4B:
			base.SuspendLayout();
			this.MainPanel.Controls.Clear();
			FilePickerControl.Mode modeP = this.ModeP;
			if (modeP != FilePickerControl.Mode.Thumbnail)
			{
				if (modeP != FilePickerControl.Mode.Treeview)
				{
					if (modeP == FilePickerControl.Mode.Composite)
					{
						this.FPTools.SetItemEnable(1, false);
						this.FPTools.SetItemPushed(4, true);
						Size size = new Size(this.MainPanel.Size.Width, this.LastCompositeHeight);
						this.DirectoryTree.Size = size;
						this.MainPanel.Controls.Add(this.ThumbList);
						this.MainPanel.Controls.Add(this.CmpSplitter);
						this.MainPanel.Controls.Add(this.DirectoryTree);
						this.DirectoryTree.Dock = DockStyle.Top;
						this.CmpSplitter.Dock = DockStyle.Top;
						this.ThumbList.Dock = DockStyle.Fill;
						this.DirectoryTree.Nodes.Clear();
					}
				}
				else
				{
					this.FPTools.SetItemEnable(1, false);
					this.FPTools.SetItemPushed(3, true);
					Point location = new Point(0, 0);
					this.DirectoryTree.Location = location;
					Size size2 = this.MainPanel.Size;
					this.DirectoryTree.Size = size2;
					this.MainPanel.Controls.Add(this.DirectoryTree);
					this.DirectoryTree.Dock = DockStyle.Fill;
					this.DirectoryTree.Nodes.Clear();
				}
			}
			else
			{
				this.FPTools.SetItemEnable(1, true);
				this.FPTools.SetItemPushed(2, true);
				Point location2 = new Point(0, 0);
				this.ThumbList.Location = location2;
				Size size3 = this.MainPanel.Size;
				this.ThumbList.Size = size3;
				this.MainPanel.Controls.Add(this.ThumbList);
				this.ThumbList.Dock = DockStyle.Fill;
			}
			this.initialized = true;
			this.FillData();
			base.ResumeLayout(false);
		}

		private void FillData()
		{
			FilePickerControl.Mode modeP = this.ModeP;
			if (modeP != FilePickerControl.Mode.Thumbnail)
			{
				if (modeP != FilePickerControl.Mode.Treeview)
				{
					if (modeP == FilePickerControl.Mode.Composite)
					{
						this.FillTreeWData();
						this.FillListWData();
					}
				}
				else
				{
					this.FillTreeWData();
				}
			}
			else
			{
				this.FillListWData();
			}
		}

		private unsafe void FillListWData()
		{
			GBaseString<char> gBaseString<char> = 0;
			*(ref gBaseString<char> + 4) = 0;
			try
			{
				if (this.Current.Length > 0)
				{
					GBaseString<char> gBaseString<char>2;
					GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, this.Root + "/" + this.Current + "/*");
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
				else
				{
					GBaseString<char> gBaseString<char>3;
					GBaseString<char>* ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>3, this.Root + "/*");
					try
					{
						int num3 = *(ptr2 + 4);
						if (num3 != 0)
						{
							*(ref gBaseString<char> + 4) = num3;
							uint num4 = (uint)(*(ref gBaseString<char> + 4) + 1);
							gBaseString<char> = <Module>.realloc(null, num4);
							cpblk(gBaseString<char>, *ptr2, num4);
						}
						else
						{
							*(ref gBaseString<char> + 4) = 0;
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
				GFoundFiles gFoundFiles = 0;
				*(ref gFoundFiles + 4) = 0;
				*(ref gFoundFiles + 8) = 0;
				try
				{
					sbyte* ptr3;
					if (gBaseString<char> != null)
					{
						ptr3 = gBaseString<char>;
					}
					else
					{
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					<Module>.GFileSystem.FindFiles(ref <Module>.FS, ptr3, ref gFoundFiles);
					method _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z = <Module>.__unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z;
					if (0 < *(ref gFoundFiles + 4))
					{
						<Module>.qsort(gFoundFiles, (uint)(*(ref gFoundFiles + 4)), 32u, _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z);
					}
					this.ThumbList.Items.Clear();
					this.ThumbsSrvr.StartThumbnailGeneration(this.CountRelevantFiles(&gFoundFiles));
					int num5 = 0;
					if (0 < *(ref gFoundFiles + 4))
					{
						int num6 = 0;
						do
						{
							uint num7 = (uint)(*(num6 + gFoundFiles + 24));
							string text = new string((sbyte*)((num7 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num7));
							GFoundFile* ptr4 = num6 + gFoundFiles;
							if (0 >= *(ptr4 + 24 + 4))
							{
								goto IL_33C;
							}
							if (*(*(ptr4 + 24)) != 46 || (this.Current.Length > 0 && string.Compare(text, "..", true) == 0))
							{
								ListViewItem listViewItem = null;
								if (*(num6 + gFoundFiles) != 0)
								{
									if (this.ModeP != FilePickerControl.Mode.Composite)
									{
										listViewItem = new ListViewItem("");
										listViewItem.SubItems.Add(text);
										if (string.Compare(text, "..", true) != 0)
										{
											listViewItem.Tag = FilePickerControl.ItemType.Diritem;
											listViewItem.ImageIndex = this.GetThumbnailIndex(listViewItem);
										}
										else
										{
											listViewItem.Tag = FilePickerControl.ItemType.Updiritem;
											listViewItem.ImageIndex = 1;
										}
									}
								}
								else
								{
									string text2 = "";
									string extension = text2;
									string text3 = text2;
									this.SplitFileName(text, ref text3, ref extension);
									if (this.IsFileRelevant(extension) && this.IsFileRelevantByName(text3) && this.IsFileRelevantByPath(this.Current + "/", text, true))
									{
										listViewItem = new ListViewItem("");
										ThumbnailServer.ThumbType thumbTypeP = this.ThumbTypeP;
										if (thumbTypeP != ThumbnailServer.ThumbType.Tile && thumbTypeP != ThumbnailServer.ThumbType.Box)
										{
											listViewItem.SubItems.Add(text);
										}
										else
										{
											listViewItem.SubItems.Add(this.GetNameBase(text3));
										}
										listViewItem.Tag = FilePickerControl.ItemType.Fileitem;
										listViewItem.ImageIndex = this.GetThumbnailIndex(listViewItem);
									}
								}
								if (listViewItem != null)
								{
									this.ThumbList.Items.Add(listViewItem);
								}
							}
							num5++;
							num6 += 32;
						}
						while (num5 < *(ref gFoundFiles + 4));
						goto IL_35B;
						IL_33C:
						<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
						<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), 0);
					}
					IL_35B:
					this.ThumbsSrvr.FinishThumbnailGeneration();
					base.Focus();
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GFoundFiles.{dtor}), (void*)(&gFoundFiles));
					throw;
				}
				int num8 = 0;
				if (0 < *(ref gFoundFiles + 4))
				{
					int num9 = 0;
					do
					{
						<Module>.GFoundFile.__delDtor(num9 + gFoundFiles, 0u);
						num8++;
						num9 += 32;
					}
					while (num8 < *(ref gFoundFiles + 4));
				}
				if (gFoundFiles != null)
				{
					<Module>.free(gFoundFiles);
					gFoundFiles = 0;
				}
				*(ref gFoundFiles + 4) = 0;
				*(ref gFoundFiles + 8) = 0;
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

		private unsafe void FillTreeWData()
		{
			string[] array = this.SplitPath(this.Current);
			string text = this.Root + "/";
			TreeNodeCollection nodes = this.DirectoryTree.Nodes;
			TreeNode treeNode = null;
			TreeNode treeNode2 = null;
			GFoundFiles gFoundFiles = 0;
			*(ref gFoundFiles + 4) = 0;
			*(ref gFoundFiles + 8) = 0;
			try
			{
				int num = 0;
				GBaseString<char> gBaseString<char>;
				if (0 < array.Length + 1)
				{
					do
					{
						if (treeNode != null)
						{
							treeNode2 = treeNode;
						}
						if (nodes.Count == 0)
						{
							<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, text + "*");
							try
							{
								sbyte* ptr;
								if (gBaseString<char> != null)
								{
									ptr = gBaseString<char>;
								}
								else
								{
									ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								<Module>.GFileSystem.FindFiles(ref <Module>.FS, ptr, ref gFoundFiles);
								method _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z = <Module>.__unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z;
								if (0 < *(ref gFoundFiles + 4))
								{
									<Module>.qsort(gFoundFiles, (uint)(*(ref gFoundFiles + 4)), 32u, _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z);
								}
								nodes.Clear();
								int num2 = 0;
								if (0 < *(ref gFoundFiles + 4))
								{
									int num3 = 0;
									while (true)
									{
										uint num4 = (uint)(*(num3 + gFoundFiles + 24));
										string text2 = new string((sbyte*)((num4 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num4));
										int num5 = gFoundFiles + num3;
										GFoundFile* ptr2 = num5;
										if (0 >= *(ptr2 + 24 + 4))
										{
											break;
										}
										if (*(*(ptr2 + 24)) != 46)
										{
											TreeNode treeNode3 = null;
											if (*num5 != 0)
											{
												treeNode3 = new TreeNode(text2);
												treeNode3.Tag = FilePickerControl.ItemType.Diritem;
												if (num < array.Length)
												{
													if (string.Compare(treeNode3.Text, array[num], true) != 0)
													{
														this.CollapseTreeItem(treeNode3);
													}
													else
													{
														treeNode = treeNode3;
													}
												}
											}
											else if (this.ModeP != FilePickerControl.Mode.Composite)
											{
												string text3 = "";
												string extension = text3;
												string text4 = text3;
												this.SplitFileName(text2, ref text4, ref extension);
												if (this.IsFileRelevant(extension) && this.IsFileRelevantByName(text4) && this.IsFileRelevantByPath(text, text2, false))
												{
													ThumbnailServer.ThumbType thumbTypeP = this.ThumbTypeP;
													if (thumbTypeP != ThumbnailServer.ThumbType.Tile && thumbTypeP != ThumbnailServer.ThumbType.Box)
													{
														treeNode3 = new TreeNode(text2);
													}
													else
													{
														treeNode3 = new TreeNode(this.GetNameBase(text4));
													}
													treeNode3.Tag = FilePickerControl.ItemType.Fileitem;
													switch (this.ThumbTypeP)
													{
													case ThumbnailServer.ThumbType.Material:
													case ThumbnailServer.ThumbType.Tile:
														treeNode3.ImageIndex = 4;
														treeNode3.SelectedImageIndex = 4;
														break;
													case ThumbnailServer.ThumbType.Unit:
														treeNode3.ImageIndex = 6;
														treeNode3.SelectedImageIndex = 6;
														break;
													case ThumbnailServer.ThumbType.Sound:
														treeNode3.ImageIndex = 5;
														treeNode3.SelectedImageIndex = 5;
														break;
													case ThumbnailServer.ThumbType.Effect:
														treeNode3.ImageIndex = 3;
														treeNode3.SelectedImageIndex = 3;
														break;
													case ThumbnailServer.ThumbType.Box:
													case ThumbnailServer.ThumbType.Fluid:
													case ThumbnailServer.ThumbType.Cloud:
														treeNode3.ImageIndex = 7;
														treeNode3.SelectedImageIndex = 7;
														break;
													case ThumbnailServer.ThumbType.Locale:
													case ThumbnailServer.ThumbType.Map:
														treeNode3.ImageIndex = 8;
														treeNode3.SelectedImageIndex = 8;
														break;
													default:
														treeNode3.ImageIndex = 2;
														treeNode3.SelectedImageIndex = 2;
														break;
													}
												}
											}
											if (treeNode3 != null)
											{
												nodes.Add(treeNode3);
											}
										}
										num2++;
										num3 += 32;
										if (num2 >= *(ref gFoundFiles + 4))
										{
											goto Block_38;
										}
									}
									goto IL_383;
									Block_38:;
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
						else
						{
							int num6 = 0;
							if (0 < nodes.Count)
							{
								do
								{
									TreeNode treeNode4 = nodes[num6];
									object tag = treeNode4.Tag;
									if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) != FilePickerControl.ItemType.Fileitem && num < array.Length)
									{
										if (string.Compare(treeNode4.Text, array[num], true) != 0)
										{
											this.CollapseTreeItem(treeNode4);
										}
										else
										{
											treeNode = treeNode4;
										}
									}
									num6++;
								}
								while (num6 < nodes.Count);
							}
						}
						if (treeNode != null)
						{
							nodes = treeNode.Nodes;
						}
						if (num < array.Length)
						{
							text = text + array[num] + "/";
						}
						if (treeNode2 != null)
						{
							this.ExpandTreeItem(treeNode2);
						}
						num++;
					}
					while (num < array.Length + 1);
					goto IL_3B3;
					IL_383:
					try
					{
						<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
						<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), 0);
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
						throw;
					}
				}
				IL_3B3:
				try
				{
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
					throw;
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GFoundFiles.{dtor}), (void*)(&gFoundFiles));
				throw;
			}
			int num7 = 0;
			if (0 < *(ref gFoundFiles + 4))
			{
				int num8 = 0;
				do
				{
					<Module>.GFoundFile.__delDtor(num8 + gFoundFiles, 0u);
					num7++;
					num8 += 32;
				}
				while (num7 < *(ref gFoundFiles + 4));
			}
			if (gFoundFiles != null)
			{
				<Module>.free(gFoundFiles);
			}
		}

		private unsafe void ExpandTreeItem(TreeNode item)
		{
			if (item != null)
			{
				object tag = item.Tag;
				if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) != FilePickerControl.ItemType.Fileitem)
				{
					item.Expand();
					item.ImageIndex = 1;
					item.SelectedImageIndex = 1;
				}
			}
		}

		private unsafe void CollapseTreeItem(TreeNode item)
		{
			if (item != null)
			{
				object tag = item.Tag;
				if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) != FilePickerControl.ItemType.Fileitem)
				{
					item.Collapse();
					item.ImageIndex = 0;
					item.SelectedImageIndex = 0;
					int num = 0;
					if (0 < item.Nodes.Count)
					{
						do
						{
							this.CollapseTreeItem(item.Nodes[num]);
							num++;
						}
						while (num < item.Nodes.Count);
					}
				}
			}
		}

		private void UpDir()
		{
			char[] separator = "/".ToCharArray();
			string[] array = this.Current.Split(separator);
			if (array.Length > 1)
			{
				this.Current = array[0];
				int num = 1;
				if (1 < array.Length - 1)
				{
					do
					{
						this.Current = this.Current + "/" + array[num];
						num++;
					}
					while (num < array.Length - 1);
				}
			}
			else
			{
				this.Current = "";
			}
		}

		private void ForceUpdateThumbnails()
		{
			string text = null;
			this.ThumbsSrvr.StartThumbnailGeneration(this.ThumbList.Items.Count);
			int num = 0;
			if (0 < this.ThumbList.Items.Count)
			{
				do
				{
					int num2;
					this.Thumbnails.Images[this.ThumbList.Items[num].ImageIndex] = this.GetThumbnailImage(this.ThumbList.Items[num], ref text, ref num2, true);
					num++;
				}
				while (num < this.ThumbList.Items.Count);
			}
			this.ThumbsSrvr.FinishThumbnailGeneration();
			base.Focus();
		}

		private string GetNameBase(string fullname)
		{
			int num = 0;
			int num2 = fullname.Length - 1;
			if (num2 >= 0)
			{
				do
				{
					num++;
					if (fullname[num2] == '_')
					{
						break;
					}
					num2--;
				}
				while (num2 >= 0);
			}
			return fullname.Remove(fullname.Length - num, num);
		}

		private unsafe void SplitFileName(string filename, string* name, string* extension)
		{
			char[] separator = ".".ToCharArray();
			string[] array = filename.Split(separator);
			int num = array.Length;
			if (num > 1)
			{
				*extension = array[num - 1];
			}
			else
			{
				*extension = "";
			}
			if (array.Length > 0)
			{
				*name = array[0];
			}
			int num2 = 1;
			if (1 < array.Length - 1)
			{
				do
				{
					*name = *name + "." + array[num2];
					num2++;
				}
				while (num2 < array.Length - 1);
			}
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private bool IsFileRelevant(string extension)
		{
			string[] extensionsP = this.ExtensionsP;
			if (extensionsP == null)
			{
				return true;
			}
			int num = 0;
			if (0 < extensionsP.Length)
			{
				while (string.Compare(extensionsP[num], extension, true) != 0)
				{
					num++;
					extensionsP = this.ExtensionsP;
					if (num >= extensionsP.Length)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private bool IsFileRelevantByName(string name)
		{
			ThumbnailServer.ThumbType thumbTypeP = this.ThumbTypeP;
			if (thumbTypeP == ThumbnailServer.ThumbType.Box)
			{
				return ((string.Compare(name.Substring(name.Length - 4, 4), "_top") == 0) ? 1 : 0) != 0;
			}
			return thumbTypeP != ThumbnailServer.ThumbType.Tile || ((string.Compare(name.Substring(name.Length - 2, 2), "_1") == 0) ? 1 : 0) != 0;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		private unsafe bool IsFileRelevantByPath(string parentpath, string filename, [MarshalAs(UnmanagedType.U1)] bool rootneeded)
		{
			if (this.ThumbTypeP == ThumbnailServer.ThumbType.Unit && this.FilterNonEditableUnitsP)
			{
				string text;
				if (parentpath.Length > 1)
				{
					text = parentpath + filename;
				}
				else
				{
					text = filename;
				}
				if (rootneeded)
				{
					text = this.Root + "/" + text;
				}
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, text);
				bool result;
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
					GPUnit* expr_69 = <Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, ptr2, false, true);
					result = (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_69, *(*expr_69 + 92)) != 0);
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
			return true;
		}

		private unsafe int CountRelevantFiles(GFoundFiles* foundfiles)
		{
			int num = 0;
			GBaseString<char> gBaseString<char> = 0;
			*(ref gBaseString<char> + 4) = 0;
			try
			{
				int num2 = 0;
				int num3 = *(int*)(foundfiles + 4 / sizeof(GFoundFiles));
				if (0 < num3)
				{
					int num4 = 0;
					do
					{
						uint num5 = (uint)(*(num4 + *(int*)foundfiles + 24));
						sbyte* value;
						if (num5 != 0u)
						{
							value = num5;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						<Module>.GBaseString<char>.=(ref gBaseString<char>, new string((sbyte*)value));
						GFoundFile* ptr = num4 + *(int*)foundfiles;
						if (0 >= *(ptr + 24 + 4))
						{
							goto IL_13A;
						}
						if ((*(*(ptr + 24)) != 46 || (this.Current.Length > 0 && string.Compare(new string((sbyte*)((gBaseString<char> == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>)), "..", true) == 0)) && *(num4 + *(int*)foundfiles) == 0)
						{
							string text = "";
							string extension = text;
							string name = text;
							sbyte* value2;
							if (gBaseString<char> != null)
							{
								value2 = gBaseString<char>;
							}
							else
							{
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							this.SplitFileName(new string((sbyte*)value2), ref name, ref extension);
							if (this.IsFileRelevant(extension) && this.IsFileRelevantByName(name))
							{
								sbyte* value3;
								if (gBaseString<char> != null)
								{
									value3 = gBaseString<char>;
								}
								else
								{
									value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
								}
								if (this.IsFileRelevantByPath(this.Current + "/", new string((sbyte*)value3), true))
								{
									num++;
								}
							}
						}
						num2++;
						num4 += 32;
						num3 = *(int*)(foundfiles + 4 / sizeof(GFoundFiles));
					}
					while (num2 < num3);
					goto IL_169;
					IL_13A:
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), 315, (sbyte*)(&<Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@));
					<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), 0);
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			IL_169:
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
			}
			return num;
		}

		private int GetThumbnailIndex(ListViewItem lvi)
		{
			string key = null;
			int num;
			Image thumbnailImage = this.GetThumbnailImage(lvi, ref key, ref num, false);
			if (thumbnailImage != null)
			{
				this.Thumbnails.Images.Add(thumbnailImage);
				int num2 = this.Thumbnails.Images.Count - 1;
				this.ThumbnailIndices[key] = num2;
				return num2;
			}
			if (num > -1)
			{
				return num;
			}
			return 2;
		}

		private unsafe Image GetThumbnailImage(ListViewItem lvi, string* hashcode, int* hashindex, [MarshalAs(UnmanagedType.U1)] bool forceupdate)
		{
			*hashindex = -1;
			string text;
			if (this.Current.Length > 0)
			{
				text = this.Current + "/" + lvi.SubItems[1].Text;
			}
			else
			{
				text = string.Concat(lvi.SubItems[1].Text);
			}
			text = this.Root + "/" + text;
			if (this.ThumbTypeP == ThumbnailServer.ThumbType.Unit)
			{
				object tag = lvi.Tag;
				if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) == FilePickerControl.ItemType.Fileitem)
				{
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, text);
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
						uint num2 = (uint)(*(<Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, ptr2, false, true) + 12));
						text = new string((sbyte*)((num2 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num2));
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
			}
			text = text.ToLower();
			GMD5Wrapper gMD5Wrapper;
			<Module>.md5_init((md5_state_s*)(&gMD5Wrapper));
			GBaseString<char> gBaseString<char>2;
			GBaseString<char>* ptr3 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, text);
			try
			{
				uint num3 = (uint)(*ptr3);
				sbyte* ptr4;
				if (num3 != 0u)
				{
					ptr4 = num3;
				}
				else
				{
					ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				int length = text.Length;
				<Module>.md5_append((md5_state_s*)(&gMD5Wrapper), (byte*)ptr4, length);
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
			$ArrayType$$$BY0CB@D $ArrayType$$$BY0CB@D;
			<Module>.GMD5Wrapper.Finish(ref gMD5Wrapper, ref $ArrayType$$$BY0CB@D);
			string text2 = new string((sbyte*)(&$ArrayType$$$BY0CB@D));
			*hashcode = text2;
			object obj = null;
			if (!forceupdate)
			{
				obj = this.ThumbnailIndices[text2];
			}
			if (obj != null)
			{
				int* ptr5;
				if (obj is int)
				{
					ptr5 = ref (int)obj;
				}
				else
				{
					ptr5 = 0;
				}
				*hashindex = *ptr5;
				return null;
			}
			object tag2 = lvi.Tag;
			if (*((!(tag2 is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag2) != FilePickerControl.ItemType.Diritem)
			{
				ThumbnailServer.ThumbType thumbTypeP = this.ThumbTypeP;
				if (thumbTypeP != ThumbnailServer.ThumbType.Sound && thumbTypeP != ThumbnailServer.ThumbType.Effect && thumbTypeP != ThumbnailServer.ThumbType.Box && thumbTypeP != ThumbnailServer.ThumbType.Fluid && thumbTypeP != ThumbnailServer.ThumbType.Cloud && thumbTypeP != ThumbnailServer.ThumbType.Locale && thumbTypeP != ThumbnailServer.ThumbType.Map)
				{
					return this.ThumbsSrvr.GetThumbnail(this.ThumbRootP, text, *hashcode, forceupdate);
				}
			}
			object tag3 = lvi.Tag;
			Image image;
			if (*((!(tag3 is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag3) == FilePickerControl.ItemType.Diritem)
			{
				image = this.Thumbnails.Images[0];
			}
			else
			{
				ThumbnailServer.ThumbType thumbTypeP = this.ThumbTypeP;
				if (thumbTypeP == ThumbnailServer.ThumbType.Effect)
				{
					image = this.Thumbnails.Images[3];
				}
				else if (thumbTypeP == ThumbnailServer.ThumbType.Box)
				{
					image = this.Thumbnails.Images[3];
				}
				else if (thumbTypeP == ThumbnailServer.ThumbType.Fluid)
				{
					image = this.Thumbnails.Images[5];
				}
				else if (thumbTypeP == ThumbnailServer.ThumbType.Cloud)
				{
					image = this.Thumbnails.Images[5];
				}
				else if (thumbTypeP == ThumbnailServer.ThumbType.Locale)
				{
					image = this.Thumbnails.Images[6];
				}
				else if (thumbTypeP == ThumbnailServer.ThumbType.Map)
				{
					image = this.Thumbnails.Images[6];
				}
				else
				{
					image = this.Thumbnails.Images[2];
				}
			}
			if (image == null)
			{
				return null;
			}
			Image image2 = image.Clone();
			Graphics graphics = Graphics.FromImage(image2);
			RectangleF rectangleF = new RectangleF(0f, 20f, 64f, 27f);
			Color darkBlue = Color.DarkBlue;
			SolidBrush brush = new SolidBrush(Color.FromArgb(128, darkBlue));
			graphics.FillRectangle(brush, rectangleF);
			Font font = new Font(new Font(new string((sbyte*)(&<Module>.??_C@_05MPFIAJAP@Arial?$AA@)), 8f), FontStyle.Bold);
			SolidBrush brush2 = new SolidBrush(Color.White);
			graphics.DrawString(lvi.SubItems[1].Text, font, brush2, rectangleF);
			return image2;
		}

		private int GetHotThumb(int x, int y)
		{
			int num = this.ThumbList.Items.Count - 1;
			if (num > -1)
			{
				do
				{
					Rectangle itemRect = this.ThumbList.GetItemRect(num);
					Point pt = new Point(x, y);
					if (itemRect.Contains(pt))
					{
						return num;
					}
					num--;
				}
				while (num > -1);
				return -1;
			}
			return -1;
		}

		private string[] SplitPath(string fullpath)
		{
			char[] separator = "/".ToCharArray();
			return fullpath.Split(separator);
		}

		private unsafe string CutToSize(string name)
		{
			string text = name;
			if (name.Length > 8)
			{
				text = name.Substring(0, 7);
				text += new string((sbyte*)(&<Module>.??_C@_03KHICJKCI@?4?4?4?$AA@));
			}
			return text;
		}

		private unsafe string GetFullThumbViewPath(ListViewItem lvi)
		{
			string text;
			if (this.Current.Length > 0)
			{
				text = this.Current + "/" + lvi.SubItems[1].Text;
			}
			else
			{
				text = string.Concat(lvi.SubItems[1].Text);
			}
			text = this.Root + "/" + text;
			if (this.ThumbTypeP == ThumbnailServer.ThumbType.Unit)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, text);
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
					uint num2 = (uint)(*(<Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, ptr2, false, true) + 12));
					text = new string((sbyte*)((num2 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num2));
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
			text = text.ToLower();
			GBaseString<char> gBaseString<char>2;
			GBaseString<char>* ptr3 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, text);
			GBaseString<char> gBaseString<char>3;
			try
			{
				uint num3 = (uint)(*ptr3);
				sbyte* ptr4;
				if (num3 != 0u)
				{
					ptr4 = num3;
				}
				else
				{
					ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				<Module>.GFileSystem.GetFileFullPath(ref <Module>.FS, &gBaseString<char>3, ptr4);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
				throw;
			}
			string result;
			try
			{
				if (gBaseString<char>2 != null)
				{
					<Module>.free(gBaseString<char>2);
				}
				if (((gBaseString<char>3 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>3) == null)
				{
					goto IL_160;
				}
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
			return result;
			IL_160:
			string result2;
			try
			{
				result2 = null;
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
			return result2;
		}

		private unsafe string GetFullTreeViewPath(TreeNode tn)
		{
			string text = tn.FullPath;
			text = this.Root + "/" + text;
			if (this.ThumbTypeP == ThumbnailServer.ThumbType.Unit)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, text);
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
					uint num2 = (uint)(*(<Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, ptr2, false, true) + 12));
					text = new string((sbyte*)((num2 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num2));
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
			text = text.ToLower();
			GBaseString<char> gBaseString<char>2;
			GBaseString<char>* ptr3 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, text);
			GBaseString<char> gBaseString<char>3;
			try
			{
				uint num3 = (uint)(*ptr3);
				sbyte* ptr4;
				if (num3 != 0u)
				{
					ptr4 = num3;
				}
				else
				{
					ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				<Module>.GFileSystem.GetFileFullPath(ref <Module>.FS, &gBaseString<char>3, ptr4);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
				throw;
			}
			string result;
			try
			{
				if (gBaseString<char>2 != null)
				{
					<Module>.free(gBaseString<char>2);
				}
				if (((gBaseString<char>3 == null) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : gBaseString<char>3) == null)
				{
					goto IL_11E;
				}
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
			return result;
			IL_11E:
			string result2;
			try
			{
				result2 = null;
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
			return result2;
		}

		private unsafe void ViewModel(string path)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			FileInfo fileInfo = new FileInfo(Application.ExecutablePath);
			string fileName = fileInfo.Directory.FullName + "/modelviewer.exe";
			uint exceptionCode;
			if (FilePickerControl.MViewer == null || FilePickerControl.MViewer.HasExited)
			{
				FilePickerControl.MViewer = new Process();
				FilePickerControl.MViewer.StartInfo.FileName = fileName;
				FilePickerControl.MViewer.StartInfo.CreateNoWindow = false;
				FilePickerControl.MViewer.StartInfo.Arguments = "\"" + path + new string((sbyte*)(&<Module>.??_C@_01BJJEKLCA@?$CC?$AA@));
				try
				{
					FilePickerControl.MViewer.Start();
					return;
				}
				exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			}
			try
			{
				StreamWriter streamWriter = new StreamWriter(fileInfo.Directory.FullName + "/$$MVInfo$$.mvi");
				streamWriter.WriteLine(path);
				streamWriter.Close();
				<Module>.PostMessageA((HWND__*)FilePickerControl.MViewer.MainWindowHandle.ToPointer(), 1025u, 0u, 0);
				<Module>.SetForegroundWindow((HWND__*)FilePickerControl.MViewer.MainWindowHandle.ToPointer());
				goto IL_116;
			}
			exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_116:;
		}

		private void OnLoad(object sender, EventArgs e)
		{
			if (!this.initialized)
			{
				this.ThumbsSrvr = new ThumbnailServer(this.ThumbTypeP);
				this.CmpSplitter = new Splitter();
			}
			this.CmpSplitter.MinExtra = 76;
			this.CmpSplitter.MinSize = 76;
			this.InitThumbView();
			this.InitTreeView();
			this.CommonInitLogics();
		}

		private void FPTools_ButtonClick(int idx, int radio_group)
		{
			switch (idx)
			{
			case 1:
				this.UpDir();
				this.FillData();
				break;
			case 2:
			{
				FilePickerControl.Mode modeP = this.ModeP;
				if (modeP != FilePickerControl.Mode.Thumbnail)
				{
					if (modeP == FilePickerControl.Mode.Composite)
					{
						this.LastCompositeHeight = this.DirectoryTree.Size.Height;
					}
					this.ModeP = FilePickerControl.Mode.Thumbnail;
					this.CommonInitLogics();
				}
				break;
			}
			case 3:
			{
				FilePickerControl.Mode modeP2 = this.ModeP;
				if (modeP2 != FilePickerControl.Mode.Treeview)
				{
					if (modeP2 == FilePickerControl.Mode.Composite)
					{
						this.LastCompositeHeight = this.DirectoryTree.Size.Height;
					}
					this.ModeP = FilePickerControl.Mode.Treeview;
					this.CommonInitLogics();
				}
				break;
			}
			case 4:
				if (this.ModeP != FilePickerControl.Mode.Composite)
				{
					this.ModeP = FilePickerControl.Mode.Composite;
					this.CommonInitLogics();
				}
				break;
			case 5:
				this.ForceUpdateThumbnails();
				break;
			}
		}

		private void TreeViewButton_Click(object sender, EventArgs e)
		{
			this.ModeP = FilePickerControl.Mode.Treeview;
			this.CommonInitLogics();
		}

		private void ThumbsButton_Click(object sender, EventArgs e)
		{
			this.ModeP = FilePickerControl.Mode.Thumbnail;
			this.CommonInitLogics();
		}

		private unsafe void ListItem_DblClick(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			if (!this.RestrictMouseEvents)
			{
				try
				{
					if (this.ThumbList.SelectedItems.Count > 0)
					{
						ListViewItem listViewItem = this.ThumbList.SelectedItems[0];
						object tag = listViewItem.Tag;
						if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) == FilePickerControl.ItemType.Updiritem)
						{
							this.UpDir();
						}
						else
						{
							object tag2 = listViewItem.Tag;
							if (*((!(tag2 is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag2) != FilePickerControl.ItemType.Diritem)
							{
								if (this.Current.Length > 0)
								{
									this.FileP = this.Current + "/" + listViewItem.SubItems[1].Text;
								}
								else
								{
									this.FileP = listViewItem.SubItems[1].Text;
								}
								this.raise_DoubleClickSelection(this.FileP);
								return;
							}
							if (this.Current.Length > 0)
							{
								this.Current = this.Current + "/" + listViewItem.SubItems[1].Text;
							}
							else
							{
								this.Current = listViewItem.SubItems[1].Text;
							}
						}
						this.FillData();
					}
					return;
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			}
		}

		private void ThumbviewMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				this.RestrictMouseEvents = true;
			}
		}

		private unsafe void ListItem_SingleClick(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			try
			{
				if (this.ThumbList.SelectedItems.Count > 0)
				{
					ListViewItem listViewItem = this.ThumbList.SelectedItems[0];
					object tag = listViewItem.Tag;
					if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) == FilePickerControl.ItemType.Fileitem)
					{
						if (this.Current.Length > 0)
						{
							this.FileP = this.Current + "/" + listViewItem.SubItems[1].Text;
						}
						else
						{
							this.FileP = listViewItem.SubItems[1].Text;
						}
						if (!this.RestrictMouseEvents)
						{
							this.raise_SingleClickSelection(this.FileP);
						}
					}
				}
				return;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
		}

		private unsafe void TreeItem_DblClick(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			if (!this.RestrictMouseEvents)
			{
				try
				{
					if (this.DirectoryTree.SelectedNode != null)
					{
						object tag = this.DirectoryTree.SelectedNode.Tag;
						if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) == FilePickerControl.ItemType.Fileitem)
						{
							string fullPath = this.DirectoryTree.SelectedNode.FullPath;
							this.FileP = fullPath;
							this.raise_DoubleClickSelection(fullPath);
						}
						else if (this.DirectoryTree.SelectedNode.IsExpanded)
						{
							this.DirectoryTree.SelectedNode.Collapse();
						}
						else
						{
							this.DirectoryTree.SelectedNode.Expand();
						}
					}
					return;
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			}
		}

		private unsafe void TreeItem_SingleClick(object sender, MouseEventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			if (e.Button != MouseButtons.Left)
			{
				this.RestrictMouseEvents = true;
			}
			try
			{
				TreeNode nodeAt = this.DirectoryTree.GetNodeAt(e.X, e.Y);
				this.DirectoryTree.SelectedNode = nodeAt;
				if (nodeAt != null)
				{
					object tag = nodeAt.Tag;
					if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) != FilePickerControl.ItemType.Fileitem)
					{
						if (!this.RestrictMouseEvents)
						{
							this.Current = nodeAt.FullPath;
							if (nodeAt.ImageIndex == 1)
							{
								this.CollapseTreeItem(nodeAt);
								this.UpDir();
								if (this.ModeP == FilePickerControl.Mode.Composite)
								{
									this.FillListWData();
								}
							}
							else
							{
								this.FillData();
							}
						}
					}
					else
					{
						if (nodeAt.Parent != null)
						{
							this.Current = nodeAt.Parent.FullPath;
						}
						else
						{
							this.Current = "";
						}
						string fullPath = nodeAt.FullPath;
						this.FileP = fullPath;
						if (!this.RestrictMouseEvents)
						{
							this.raise_SingleClickSelection(fullPath);
						}
					}
				}
				return;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
		}

		private void TreeItemSelection(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown)
			{
				e.Cancel = true;
			}
		}

		private void UpButton_Click(object sender, EventArgs e)
		{
			this.UpDir();
			this.FillData();
		}

		private new void MouseMove(object sender, MouseEventArgs e)
		{
			FilePickerControl.Mode modeP = this.ModeP;
			if (modeP == FilePickerControl.Mode.Thumbnail || modeP == FilePickerControl.Mode.Composite)
			{
				int hotThumb = this.GetHotThumb(e.X, e.Y);
				if (this.LastTTIndx != hotThumb)
				{
					if (hotThumb > -1)
					{
						ListViewItem listViewItem = this.ThumbList.Items[hotThumb];
						this.ThumbnailTooltip.Active = true;
						this.ThumbnailTooltip.SetToolTip(this.ThumbList, listViewItem.SubItems[1].Text);
					}
					else
					{
						this.ThumbnailTooltip.Active = false;
					}
					this.LastTTIndx = hotThumb;
				}
			}
		}

		private void CompositeButton_Click(object sender, EventArgs e)
		{
			this.ModeP = FilePickerControl.Mode.Composite;
			this.CommonInitLogics();
		}

		private unsafe void TreeviewMouseUp(object sender, MouseEventArgs e)
		{
			TreeNode selectedNode = this.DirectoryTree.SelectedNode;
			if (e.Button == MouseButtons.Right && selectedNode != null)
			{
				object tag = selectedNode.Tag;
				if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) == FilePickerControl.ItemType.Fileitem)
				{
					this.RestrictMouseEvents = true;
					Point pos = new Point(e.X, e.Y);
					this.TreeContextMenu.Show(this.DirectoryTree, pos);
				}
			}
			this.RestrictMouseEvents = false;
		}

		private unsafe void ThumbviewMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && this.ThumbList.SelectedItems.Count > 0)
			{
				object tag = this.ThumbList.SelectedItems[0].Tag;
				if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) == FilePickerControl.ItemType.Fileitem)
				{
					this.RestrictMouseEvents = true;
					Point pos = new Point(e.X, e.Y);
					this.ThumbContextMenu.Show(this.ThumbList, pos);
				}
			}
			this.RestrictMouseEvents = false;
		}

		private void menuItemRefreshTN_Click(object sender, EventArgs e)
		{
			string text = null;
			if (this.ThumbList.SelectedItems.Count > 0)
			{
				ListViewItem listViewItem = this.ThumbList.SelectedItems[0];
				this.ThumbsSrvr.StartThumbnailGeneration(1);
				int num;
				this.Thumbnails.Images[listViewItem.ImageIndex] = this.GetThumbnailImage(listViewItem, ref text, ref num, true);
				this.ThumbsSrvr.FinishThumbnailGeneration();
				base.Focus();
			}
		}

		private unsafe void ContextMenu_Popup(object sender, EventArgs e)
		{
			this.raise_ContextPopup(this.FileP);
			if (this.ModeP == FilePickerControl.Mode.Treeview)
			{
				this.menuItemRefreshTN.Enabled = false;
			}
			else if (this.ThumbList.SelectedItems.Count > 0)
			{
				ListViewItem listViewItem = this.ThumbList.SelectedItems[0];
				ThumbnailServer.ThumbType thumbTypeP = this.ThumbTypeP;
				byte enabled;
				if (thumbTypeP != ThumbnailServer.ThumbType.Sound && thumbTypeP != ThumbnailServer.ThumbType.Effect)
				{
					object tag = listViewItem.Tag;
					if (*((!(tag is FilePickerControl.ItemType)) ? 0 : ref (FilePickerControl.ItemType)tag) == FilePickerControl.ItemType.Fileitem && this.GetFullThumbViewPath(listViewItem) != null)
					{
						enabled = 1;
						goto IL_89;
					}
				}
				enabled = 0;
				IL_89:
				this.menuItemRefreshTN.Enabled = (enabled != 0);
			}
			else
			{
				this.menuItemRefreshTN.Enabled = false;
			}
		}

		private void menuItemViewModel_Click(object sender, EventArgs e)
		{
			if (this.ThumbList.SelectedItems.Count > 0)
			{
				ListViewItem lvi = this.ThumbList.SelectedItems[0];
				this.ViewModel(this.GetFullThumbViewPath(lvi));
			}
		}

		private void menuItemTVViewModel_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.DirectoryTree.SelectedNode;
			if (selectedNode != null)
			{
				this.ViewModel(this.GetFullTreeViewPath(selectedNode));
			}
		}

		protected void raise_SingleClickSelection(string i1)
		{
			FilePickerControl.FilePickedHandler singleClickSelection = this.SingleClickSelection;
			if (singleClickSelection != null)
			{
				singleClickSelection(i1);
			}
		}

		protected void raise_DoubleClickSelection(string i1)
		{
			FilePickerControl.FilePickedHandler doubleClickSelection = this.DoubleClickSelection;
			if (doubleClickSelection != null)
			{
				doubleClickSelection(i1);
			}
		}

		protected void raise_ContextPopup(string i1)
		{
			FilePickerControl.ContextMenuPopupHandler contextPopup = this.ContextPopup;
			if (contextPopup != null)
			{
				contextPopup(i1);
			}
		}
	}
}
