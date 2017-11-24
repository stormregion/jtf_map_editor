using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxTerrain : UserControl, IRearrangeableControl
	{
		public delegate void LayerSet(int layerindx);

		public delegate void ResumePaint();

		public delegate void GUINeedRefreshHandler();

		private ImageList TypeImageList;

		private ListView LayerList;

		private ColumnHeader DummyColumn;

		private ToolTip SelectionTT;

		private Panel ToolPanel;

		private Button DownBtn;

		private Button UpBtn;

		private Button DeleteBtn;

		private Button ReplaceBtn;

		private Button AddBtn;

		private ContextMenu LayerPopupMenu;

		private MenuItem menuItem6;

		private MenuItem menuitemNormal;

		private MenuItem menuitemBlocker;

		private MenuItem menuitemGrass;

		private MenuItem menuitemFord;

		private MenuItem menuitemWalker;

		private MenuItem menuitemInvisible;

		private MenuItem menuitemDustFree;

		private IContainer components;

		private FilePickerControl TerrainPicker;

		private unsafe GEditorWorld* WorldP;

		private string SelectedTile;

		private int CurrentForceCount;

		private int PopupLayerIndx;

		public event ToolboxTerrain.GUINeedRefreshHandler GUINeedRefreshEvent
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.GUINeedRefreshEvent = Delegate.Combine(this.GUINeedRefreshEvent, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.GUINeedRefreshEvent = Delegate.Remove(this.GUINeedRefreshEvent, value);
			}
		}

		public override event ToolRearranged Rearranged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.Rearranged = Delegate.Combine(this.Rearranged, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.Rearranged = Delegate.Remove(this.Rearranged, value);
			}
		}

		public event ToolboxTerrain.ResumePaint ResetToPaint
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.ResetToPaint = Delegate.Combine(this.ResetToPaint, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.ResetToPaint = Delegate.Remove(this.ResetToPaint, value);
			}
		}

		public event ToolboxTerrain.LayerSet LayerSelected
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.LayerSelected = Delegate.Combine(this.LayerSelected, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.LayerSelected = Delegate.Remove(this.LayerSelected, value);
			}
		}

		public unsafe GEditorWorld* World
		{
			set
			{
				this.WorldP = value;
			}
		}

		public unsafe ToolboxTerrain()
		{
			this.LayerSelected = null;
			this.ResetToPaint = null;
			this.Rearranged = null;
			this.GUINeedRefreshEvent = null;
			this.PopupLayerIndx = -1;
			this.InitializeComponent();
			this.TerrainPicker = new FilePickerControl();
			string[] extensions = new string[]
			{
				new string((sbyte*)(&<Module>.??_C@_03BFLBBCNI@mat?$AA@))
			};
			this.TerrainPicker.Text = "Tiles";
			this.TerrainPicker.Root = "Tiles";
			this.TerrainPicker.ThumbRoot = "Tiles";
			this.TerrainPicker.Extensions = extensions;
			this.TerrainPicker.ViewMode = FilePickerControl.Mode.Composite;
			this.TerrainPicker.ThumbMode = ThumbnailServer.ThumbType.Tile;
			Point location = new Point(0, 40);
			this.TerrainPicker.Location = location;
			this.TerrainPicker.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.TerrainPicker.DoubleClickSelection += new FilePickerControl.FilePickedHandler(this.TileDoubleClicked);
			this.TerrainPicker.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.TileSingleClicked);
			base.SuspendLayout();
			this.ToolPanel.Controls.Add(this.TerrainPicker);
			base.ResumeLayout();
			this.LoadInit();
			this.SelectedTile = "";
			this.CurrentForceCount = 0;
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing && this.components != null)
			{
				FilePickerControl terrainPicker = this.TerrainPicker;
				if (terrainPicker != null)
				{
					terrainPicker.Dispose();
				}
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			Container container = new Container();
			this.components = container;
			this.TypeImageList = new ImageList(container);
			this.LayerList = new ListView();
			this.DummyColumn = new ColumnHeader();
			this.ToolPanel = new Panel();
			this.DownBtn = new Button();
			this.UpBtn = new Button();
			this.DeleteBtn = new Button();
			this.ReplaceBtn = new Button();
			this.AddBtn = new Button();
			this.LayerPopupMenu = new ContextMenu();
			this.menuitemNormal = new MenuItem();
			this.menuitemBlocker = new MenuItem();
			this.menuitemGrass = new MenuItem();
			this.menuitemDustFree = new MenuItem();
			this.menuitemFord = new MenuItem();
			this.menuitemWalker = new MenuItem();
			this.menuItem6 = new MenuItem();
			this.menuitemInvisible = new MenuItem();
			this.ToolPanel.SuspendLayout();
			base.SuspendLayout();
			this.TypeImageList.ColorDepth = ColorDepth.Depth24Bit;
			Size imageSize = new Size(16, 16);
			this.TypeImageList.ImageSize = imageSize;
			Color magenta = Color.Magenta;
			this.TypeImageList.TransparentColor = magenta;
			this.LayerList.Alignment = ListViewAlignment.Left;
			this.LayerList.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
			ColumnHeader[] values = new ColumnHeader[]
			{
				this.DummyColumn
			};
			this.LayerList.Columns.AddRange(values);
			this.LayerList.FullRowSelect = true;
			this.LayerList.GridLines = true;
			this.LayerList.HeaderStyle = ColumnHeaderStyle.None;
			this.LayerList.HideSelection = false;
			this.LayerList.LabelWrap = false;
			Point location = new Point(0, 8);
			this.LayerList.Location = location;
			this.LayerList.MultiSelect = false;
			this.LayerList.Name = "LayerList";
			this.LayerList.Scrollable = false;
			Size size = new Size(256, 24);
			this.LayerList.Size = size;
			this.LayerList.SmallImageList = this.TypeImageList;
			this.LayerList.TabIndex = 0;
			this.LayerList.View = View.Details;
			this.LayerList.Click += new EventHandler(this.LayerList_Click);
			this.LayerList.SizeChanged += new EventHandler(this.LayerList_SizeChanged);
			this.LayerList.MouseUp += new MouseEventHandler(this.LayerList_MouseUp);
			this.LayerList.SelectedIndexChanged += new EventHandler(this.LayerList_SelectedIndexChanged);
			this.DummyColumn.Width = 251;
			this.ToolPanel.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.ToolPanel.Controls.Add(this.DownBtn);
			this.ToolPanel.Controls.Add(this.UpBtn);
			this.ToolPanel.Controls.Add(this.DeleteBtn);
			this.ToolPanel.Controls.Add(this.ReplaceBtn);
			this.ToolPanel.Controls.Add(this.AddBtn);
			Point location2 = new Point(0, 32);
			this.ToolPanel.Location = location2;
			this.ToolPanel.Name = "ToolPanel";
			Size size2 = new Size(256, 384);
			this.ToolPanel.Size = size2;
			this.ToolPanel.TabIndex = 6;
			Point location3 = new Point(224, 8);
			this.DownBtn.Location = location3;
			this.DownBtn.Name = "DownBtn";
			Size size3 = new Size(24, 23);
			this.DownBtn.Size = size3;
			this.DownBtn.TabIndex = 10;
			this.DownBtn.Text = "D";
			this.DownBtn.Click += new EventHandler(this.DownBtn_Click);
			Point location4 = new Point(200, 8);
			this.UpBtn.Location = location4;
			this.UpBtn.Name = "UpBtn";
			Size size4 = new Size(24, 23);
			this.UpBtn.Size = size4;
			this.UpBtn.TabIndex = 9;
			this.UpBtn.Text = "U";
			this.UpBtn.Click += new EventHandler(this.UpBtn_Click);
			Point location5 = new Point(120, 8);
			this.DeleteBtn.Location = location5;
			this.DeleteBtn.Name = "DeleteBtn";
			Size size5 = new Size(56, 23);
			this.DeleteBtn.Size = size5;
			this.DeleteBtn.TabIndex = 8;
			this.DeleteBtn.Text = "Delete";
			this.DeleteBtn.Click += new EventHandler(this.DeleteBtn_Click);
			Point location6 = new Point(64, 8);
			this.ReplaceBtn.Location = location6;
			this.ReplaceBtn.Name = "ReplaceBtn";
			Size size6 = new Size(56, 23);
			this.ReplaceBtn.Size = size6;
			this.ReplaceBtn.TabIndex = 7;
			this.ReplaceBtn.Text = "Replace";
			this.ReplaceBtn.Click += new EventHandler(this.ReplaceBtn_Click);
			Point location7 = new Point(8, 8);
			this.AddBtn.Location = location7;
			this.AddBtn.Name = "AddBtn";
			Size size7 = new Size(56, 23);
			this.AddBtn.Size = size7;
			this.AddBtn.TabIndex = 6;
			this.AddBtn.Text = "Add";
			this.AddBtn.Click += new EventHandler(this.AddBtn_Click);
			MenuItem[] items = new MenuItem[]
			{
				this.menuitemNormal,
				this.menuitemBlocker,
				this.menuitemGrass,
				this.menuitemDustFree,
				this.menuitemFord,
				this.menuitemWalker,
				this.menuItem6,
				this.menuitemInvisible
			};
			this.LayerPopupMenu.MenuItems.AddRange(items);
			this.LayerPopupMenu.Popup += new EventHandler(this.ContextMenuPopu);
			this.menuitemNormal.Index = 0;
			this.menuitemNormal.RadioCheck = true;
			this.menuitemNormal.Text = "Normal";
			this.menuitemNormal.Click += new EventHandler(this.menuitemNormal_Click);
			this.menuitemBlocker.Index = 1;
			this.menuitemBlocker.RadioCheck = true;
			this.menuitemBlocker.Text = "Blocker";
			this.menuitemBlocker.Click += new EventHandler(this.menuitemBlocker_Click);
			this.menuitemGrass.Index = 2;
			this.menuitemGrass.RadioCheck = true;
			this.menuitemGrass.Text = "Grass";
			this.menuitemGrass.Click += new EventHandler(this.menuitemGrass_Click);
			this.menuitemDustFree.Index = 3;
			this.menuitemDustFree.RadioCheck = true;
			this.menuitemDustFree.Text = "Dust-free";
			this.menuitemDustFree.Click += new EventHandler(this.menuitemDustFree_Click);
			this.menuitemFord.Index = 4;
			this.menuitemFord.RadioCheck = true;
			this.menuitemFord.Text = "Ford";
			this.menuitemFord.Click += new EventHandler(this.menuitemFord_Click);
			this.menuitemWalker.Index = 5;
			this.menuitemWalker.RadioCheck = true;
			this.menuitemWalker.Text = "Only walker";
			this.menuitemWalker.Click += new EventHandler(this.menuitemWalker_Click);
			this.menuItem6.Index = 6;
			this.menuItem6.Text = "-";
			this.menuitemInvisible.Index = 7;
			this.menuitemInvisible.Text = "Invisible";
			this.menuitemInvisible.Click += new EventHandler(this.menuitemInvisible_Click);
			base.Controls.Add(this.ToolPanel);
			base.Controls.Add(this.LayerList);
			base.Name = "ToolboxTerrain";
			Size size8 = new Size(256, 416);
			base.Size = size8;
			base.Resize += new EventHandler(this.ToolboxTerrain_Resize);
			this.ToolPanel.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void UpdateButtons()
		{
			int selectedLayer = this.GetSelectedLayer();
			if (selectedLayer != 0 && selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) - 1)
			{
				this.UpBtn.Enabled = true;
			}
			else
			{
				this.UpBtn.Enabled = false;
			}
			if (selectedLayer > 1 && selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP))
			{
				this.DownBtn.Enabled = true;
			}
			else
			{
				this.DownBtn.Enabled = false;
			}
			if (selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) && <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) >= 2)
			{
				this.DeleteBtn.Enabled = true;
			}
			else
			{
				this.DeleteBtn.Enabled = false;
			}
			if (selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) && this.SelectedTile.Length != 0)
			{
				this.ReplaceBtn.Enabled = true;
			}
			else
			{
				this.ReplaceBtn.Enabled = false;
			}
			if (<Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) < 20 && this.SelectedTile.Length != 0)
			{
				this.AddBtn.Enabled = true;
			}
			else
			{
				this.AddBtn.Enabled = false;
			}
		}

		private int GetLayerStyle(int indx)
		{
			int num = 0;
			byte @checked = ((<Module>.GEditorWorld.GetTileLayerFlags(this.WorldP, indx) & 31) == 0) ? 1 : 0;
			this.menuitemNormal.Checked = (@checked != 0);
			if (this.menuitemNormal.Checked)
			{
				num = 1;
			}
			this.menuitemBlocker.Checked = ((<Module>.GEditorWorld.GetTileLayerFlags(this.WorldP, indx) & 1) != 0);
			if (this.menuitemBlocker.Checked)
			{
				num = 2;
			}
			byte checked2 = <Module>.GEditorWorld.GetTileLayerFlags(this.WorldP, indx) >> 2 & 1;
			this.menuitemFord.Checked = (checked2 != 0);
			if (this.menuitemFord.Checked)
			{
				num = 3;
			}
			byte checked3 = <Module>.GEditorWorld.GetTileLayerFlags(this.WorldP, indx) >> 1 & 1;
			this.menuitemGrass.Checked = (checked3 != 0);
			if (this.menuitemGrass.Checked)
			{
				num = 4;
			}
			byte checked4 = <Module>.GEditorWorld.GetTileLayerFlags(this.WorldP, indx) >> 4 & 1;
			this.menuitemWalker.Checked = (checked4 != 0);
			if (this.menuitemWalker.Checked)
			{
				num = 5;
			}
			byte checked5 = <Module>.GEditorWorld.GetTileLayerFlags(this.WorldP, indx) >> 3 & 1;
			this.menuitemDustFree.Checked = (checked5 != 0);
			if (this.menuitemDustFree.Checked)
			{
				num = 6;
			}
			byte checked6 = <Module>.GEditorWorld.GetTileLayerFlags(this.WorldP, indx) >> 7 & 1;
			this.menuitemInvisible.Checked = (checked6 != 0);
			if (this.menuitemInvisible.Checked)
			{
				num += 6;
			}
			return num;
		}

		private void SetLayerStyle(int indx)
		{
			int layerStyle = this.GetLayerStyle(indx);
			this.LayerList.Items[this.PopupLayerIndx].ImageIndex = layerStyle;
			this.LayerList.Items[this.PopupLayerIndx].StateImageIndex = layerStyle;
		}

		public unsafe void LoadInit()
		{
			ImageServer imageServer = ImageServer.GetImageServer("Images");
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0L@DBPODKKK@LayerEmpty?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0M@PFFBNMCL@LayerNormal?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0N@LHBDMIPF@LayerBlocker?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_09BNICPIFC@LayerFord?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0L@IJIDFFAH@LayerGrass?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0M@BEOOIFHK@LayerWalker?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0O@JGFPCMMM@LayerDustFree?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0P@NIMJGNGI@LayerNormalInv?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0BA@OJKCICPJ@LayerBlockerInv?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0N@GNNLFMJH@LayerFordInv?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0O@GLACECGK@LayerGrassInv?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0P@IFBAGBAO@LayerWalkerInv?$AA@)), KnownColor.Window));
			this.TypeImageList.Images.Add(imageServer.GetImage(new string((sbyte*)(&<Module>.??_C@_0BB@IHGAGHJE@LayerDustFreeInv?$AA@)), KnownColor.Window));
			ToolTip toolTip = new ToolTip();
			this.SelectionTT = toolTip;
			toolTip.AutoPopDelay = 0;
			this.SelectionTT.InitialDelay = 0;
			this.SelectionTT.ReshowDelay = 0;
			this.SelectionTT.SetToolTip(this.AddBtn, "");
			this.SelectionTT.SetToolTip(this.ReplaceBtn, "");
			this.SelectionTT.ShowAlways = true;
		}

		public unsafe void UpdateLayerList(int selection, int forcecount)
		{
			string text = "";
			if (selection < 0 && this.LayerList.SelectedItems.Count > 0)
			{
				text = this.LayerList.SelectedItems[0].Text;
			}
			this.LayerList.Items.Clear();
			int num = <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP);
			int num2 = 1;
			this.LayerList.SuspendLayout();
			int num3 = 19;
			do
			{
				if (num3 < num)
				{
					ListViewItem listViewItem = new ListViewItem();
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr = <Module>.GEditorWorld.GetTileLayerName(this.WorldP, &gBaseString<char>, num3);
					try
					{
						uint num4 = (uint)(*(int*)ptr);
						sbyte* value;
						if (num4 != 0u)
						{
							value = num4;
						}
						else
						{
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
						}
						listViewItem.Text = new string((sbyte*)value);
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
					int layerStyle = this.GetLayerStyle(num3);
					listViewItem.ImageIndex = layerStyle;
					listViewItem.StateImageIndex = layerStyle;
					if (selection < 0 && text.Length > 0 && string.Compare(listViewItem.Text, text) == 0)
					{
						listViewItem.Selected = true;
					}
					this.LayerList.Items.Add(listViewItem);
				}
				else if (num2 > 0)
				{
					ListViewItem listViewItem2 = new ListViewItem();
					listViewItem2.Text = "New Layer";
					listViewItem2.ImageIndex = 0;
					listViewItem2.StateImageIndex = 0;
					this.LayerList.Items.Add(listViewItem2);
					num2--;
				}
				num3--;
			}
			while (num3 > -1);
			if (selection >= 0)
			{
				this.SelectLayer(selection);
			}
			if (this.LayerList.SelectedItems.Count < 1)
			{
				this.SelectLayer(-1);
			}
			this.UpdateButtons();
			this.LayerList.ResumeLayout();
			this.Rearrange();
			this.raise_LayerSelected(this.GetSelectedLayer());
		}

		public int GetSelectedLayer()
		{
			if (this.LayerList.SelectedIndices.Count > 0)
			{
				int num = -1 - this.LayerList.SelectedIndices[0];
				return this.LayerList.Items.Count + num;
			}
			return 20;
		}

		public void SelectLayer(int layer)
		{
			if (layer < 0)
			{
				this.LayerList.Items[this.LayerList.Items.Count - 1].Selected = true;
			}
			else if (layer > this.LayerList.Items.Count - 1)
			{
				this.LayerList.Items[0].Selected = true;
			}
			else
			{
				this.LayerList.Items[this.LayerList.Items.Count - layer - 1].Selected = true;
			}
		}

		public void UpdateLayerUsage(uint flags)
		{
			int num = <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP);
			this.LayerList.BeginUpdate();
			int num2 = this.LayerList.Items.Count - 1;
			if (num2 >= 0)
			{
				int num3 = -1 - num2;
				do
				{
					if (num2 < num)
					{
						if ((1 << num2 & flags) != null)
						{
							Font font = this.LayerList.Items[this.LayerList.Items.Count + num3].Font;
							this.LayerList.Items[this.LayerList.Items.Count + num3].Font = new Font(font, FontStyle.Bold);
						}
						else
						{
							Font font2 = this.LayerList.Items[this.LayerList.Items.Count + num3].Font;
							this.LayerList.Items[this.LayerList.Items.Count + num3].Font = new Font(font2, FontStyle.Regular);
						}
					}
					num2--;
					num3++;
				}
				while (num2 >= 0);
			}
			this.LayerList.EndUpdate();
		}

		public void Rearrange()
		{
			base.SuspendLayout();
			Rectangle itemRect = this.LayerList.GetItemRect(0);
			int num = this.LayerList.Items.Count - 1;
			int num2 = itemRect.Height * num;
			Size size = base.Size;
			int num3 = num2 + 416;
			Size size2 = new Size(size.Width, num3);
			base.Size = size2;
			Point location = new Point(0, num2 + 40);
			this.ToolPanel.Location = location;
			Size size3 = new Size(base.Size.Width, 400);
			this.ToolPanel.Size = size3;
			Point pt = new Point(base.Size.Width, num2 + 24);
			Size size4 = new Size(pt);
			this.LayerList.Size = size4;
			base.ResumeLayout();
			this.raise_Rearranged(this, num3);
		}

		public void Resume()
		{
			this.raise_LayerSelected(this.GetSelectedLayer());
		}

		private void LayerList_SizeChanged(object sender, EventArgs e)
		{
			Rectangle displayRectangle = this.LayerList.DisplayRectangle;
			this.LayerList.Columns[0].Width = displayRectangle.Width;
		}

		private void TileDoubleClicked(string TileName)
		{
			this.SelectedTile = TileName;
			this.UpdateButtons();
			this.SelectionTT.SetToolTip(this.AddBtn, "Add " + TileName);
			this.SelectionTT.SetToolTip(this.ReplaceBtn, "Replace with " + TileName);
			if (this.GetSelectedLayer() < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP))
			{
				this.ReplaceBtn_Click(this, new EventArgs());
			}
			else
			{
				this.AddBtn_Click(this, new EventArgs());
			}
		}

		private void TileSingleClicked(string TileName)
		{
			this.SelectedTile = TileName;
			this.UpdateButtons();
			this.SelectionTT.SetToolTip(this.AddBtn, "Add " + TileName);
			this.SelectionTT.SetToolTip(this.ReplaceBtn, "Replace with " + TileName);
		}

		private unsafe void AddBtn_Click(object sender, EventArgs e)
		{
			if (<Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) < 20)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.SelectedTile);
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
					this.UpdateLayerList(<Module>.GEditorWorld.AddTileLayer(this.WorldP, ptr2, 0), this.CurrentForceCount);
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
				this.raise_GUINeedRefreshEvent();
			}
		}

		private unsafe void ReplaceBtn_Click(object sender, EventArgs e)
		{
			int selectedLayer = this.GetSelectedLayer();
			if (this.SelectedTile.Length > 0 && selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP))
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, this.SelectedTile);
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
					<Module>.GEditorWorld.SetTileLayer(this.WorldP, selectedLayer, ptr2);
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
				this.UpdateLayerList(selectedLayer, this.CurrentForceCount);
				this.raise_GUINeedRefreshEvent();
			}
		}

		private void DeleteBtn_Click(object sender, EventArgs e)
		{
			int selectedLayer = this.GetSelectedLayer();
			if (selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) && (selectedLayer != 0 || MessageBox.Show("Deleting the bottom layer removes the painting of the next layer!\n\nAre you sure you want to delete the bottom layer?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
			{
				<Module>.GEditorWorld.RemoveTileLayer(this.WorldP, selectedLayer);
				this.UpdateLayerList(-1, this.CurrentForceCount);
				this.raise_GUINeedRefreshEvent();
			}
		}

		private void UpBtn_Click(object sender, EventArgs e)
		{
			int selectedLayer = this.GetSelectedLayer();
			if (selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) - 1)
			{
				this.UpdateLayerList(<Module>.GEditorWorld.MoveTileLayer(this.WorldP, selectedLayer, 1), this.CurrentForceCount);
				this.raise_GUINeedRefreshEvent();
			}
		}

		private void DownBtn_Click(object sender, EventArgs e)
		{
			int selectedLayer = this.GetSelectedLayer();
			if (selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) && selectedLayer > 0)
			{
				this.UpdateLayerList(<Module>.GEditorWorld.MoveTileLayer(this.WorldP, selectedLayer, -1), this.CurrentForceCount);
				this.raise_GUINeedRefreshEvent();
			}
		}

		private void LayerList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.UpdateButtons();
			this.raise_LayerSelected(this.GetSelectedLayer());
		}

		private void LayerList_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ListViewItem itemAt = this.LayerList.GetItemAt(e.X, e.Y);
				if (itemAt != null)
				{
					this.PopupLayerIndx = itemAt.Index;
					Point pos = new Point(e.X, e.Y);
					this.LayerPopupMenu.Show(this.LayerList, pos);
				}
				else
				{
					this.PopupLayerIndx = -1;
				}
			}
		}

		private void ContextMenuPopu(object sender, EventArgs e)
		{
			int num = this.LayerList.Items.Count - this.PopupLayerIndx - 1;
			if (num < <Module>.GEditorWorld.GetNumOfTileLayers(this.WorldP) && num != 0)
			{
				int num2 = 0;
				if (0 < this.LayerPopupMenu.MenuItems.Count)
				{
					do
					{
						this.LayerPopupMenu.MenuItems[num2].Enabled = true;
						num2++;
					}
					while (num2 < this.LayerPopupMenu.MenuItems.Count);
				}
				this.SetLayerStyle(num);
			}
			else
			{
				int num3 = 0;
				if (0 < this.LayerPopupMenu.MenuItems.Count)
				{
					do
					{
						this.LayerPopupMenu.MenuItems[num3].Checked = false;
						this.LayerPopupMenu.MenuItems[num3].Enabled = false;
						num3++;
					}
					while (num3 < this.LayerPopupMenu.MenuItems.Count);
				}
			}
		}

		private void menuitemNormal_Click(object sender, EventArgs e)
		{
			int num = this.LayerList.Items.Count - this.PopupLayerIndx - 1;
			if (this.menuitemInvisible.Checked)
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 128);
			}
			else
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 0);
			}
			this.SetLayerStyle(num);
			this.raise_GUINeedRefreshEvent();
		}

		private void menuitemBlocker_Click(object sender, EventArgs e)
		{
			int num = this.LayerList.Items.Count - this.PopupLayerIndx - 1;
			if (this.menuitemInvisible.Checked)
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 129);
			}
			else
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 1);
			}
			this.SetLayerStyle(num);
			this.raise_GUINeedRefreshEvent();
		}

		private void menuitemGrass_Click(object sender, EventArgs e)
		{
			int num = this.LayerList.Items.Count - this.PopupLayerIndx - 1;
			if (this.menuitemInvisible.Checked)
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 130);
			}
			else
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 2);
			}
			this.SetLayerStyle(num);
			this.raise_GUINeedRefreshEvent();
		}

		private void menuitemDustFree_Click(object sender, EventArgs e)
		{
			int num = this.LayerList.Items.Count - this.PopupLayerIndx - 1;
			if (this.menuitemInvisible.Checked)
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 136);
			}
			else
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 8);
			}
			this.SetLayerStyle(num);
			this.raise_GUINeedRefreshEvent();
		}

		private void menuitemFord_Click(object sender, EventArgs e)
		{
			int num = this.LayerList.Items.Count - this.PopupLayerIndx - 1;
			if (this.menuitemInvisible.Checked)
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 132);
			}
			else
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 4);
			}
			this.SetLayerStyle(num);
			this.raise_GUINeedRefreshEvent();
		}

		private void menuitemWalker_Click(object sender, EventArgs e)
		{
			int num = this.LayerList.Items.Count - this.PopupLayerIndx - 1;
			if (this.menuitemInvisible.Checked)
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 144);
			}
			else
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, 16);
			}
			this.SetLayerStyle(num);
			this.raise_GUINeedRefreshEvent();
		}

		private void menuitemInvisible_Click(object sender, EventArgs e)
		{
			int num = this.LayerList.Items.Count - this.PopupLayerIndx - 1;
			if (this.menuitemInvisible.Checked)
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, <Module>.GEditorWorld.GetTileLayerFlags(this.WorldP, num) & -129);
			}
			else
			{
				<Module>.GEditorWorld.SetTileLayerFlags(this.WorldP, num, <Module>.GEditorWorld.GetTileLayerFlags(this.WorldP, num) | 128);
			}
			this.SetLayerStyle(num);
			this.raise_GUINeedRefreshEvent();
		}

		private void ToolboxTerrain_Resize(object sender, EventArgs e)
		{
		}

		private void LayerList_Click(object sender, EventArgs e)
		{
			this.raise_ResetToPaint();
		}

		protected void raise_LayerSelected(int i1)
		{
			ToolboxTerrain.LayerSet layerSelected = this.LayerSelected;
			if (layerSelected != null)
			{
				layerSelected(i1);
			}
		}

		protected void raise_ResetToPaint()
		{
			ToolboxTerrain.ResumePaint resetToPaint = this.ResetToPaint;
			if (resetToPaint != null)
			{
				resetToPaint();
			}
		}

		protected void raise_Rearranged(object i1, int i2)
		{
			ToolRearranged rearranged = this.Rearranged;
			if (rearranged != null)
			{
				rearranged(i1, i2);
			}
		}

		protected void raise_GUINeedRefreshEvent()
		{
			ToolboxTerrain.GUINeedRefreshHandler gUINeedRefreshEvent = this.GUINeedRefreshEvent;
			if (gUINeedRefreshEvent != null)
			{
				gUINeedRefreshEvent();
			}
		}
	}
}
