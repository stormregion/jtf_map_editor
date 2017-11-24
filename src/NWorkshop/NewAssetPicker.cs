using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class NewAssetPicker : Form
	{
		public enum ObjectType
		{
			CloudLoader = 8,
			EnvMapLoader = 7,
			SkyBoxLoader = 6,
			OptionsEditor = 5,
			MissionVariablesEditor = 4,
			GameVariablesEditor = 3,
			EffectEditor = 2,
			UnitEditor = 1,
			MissingAsset = 0
		}

		private Button AcceptBtn;

		private Button CancelBtn;

		private Container components;

		private FilePickerControl control;

		private string propNewFile;

		public string NewName
		{
			get
			{
				return this.propNewFile;
			}
		}

		public unsafe NewAssetPicker(NewAssetPicker.ObjectType objecttype, int filetype)
		{
			this.InitializeComponent();
			this.AcceptBtn.Enabled = false;
			FilePickerControl filePickerControl = new FilePickerControl();
			this.control = filePickerControl;
			filePickerControl.ViewMode = FilePickerControl.Mode.Composite;
			switch (objecttype)
			{
			case NewAssetPicker.ObjectType.MissingAsset:
				switch (filetype)
				{
				case 0:
				{
					string[] extensions = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BICDMHKB@wav?$AA@))
					};
					this.Text = "Select new sound";
					this.control.Root = "sounds";
					this.control.ThumbRoot = "Sounds";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Sound;
					this.control.Extensions = extensions;
					break;
				}
				case 1:
				{
					string[] extensions2 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BFLBBCNI@mat?$AA@))
					};
					this.Text = "Select new decal";
					this.control.Root = "decals";
					this.control.ThumbRoot = "Decals";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Material;
					this.control.Extensions = extensions2;
					break;
				}
				case 2:
				{
					string[] extensions3 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03MBBDFFBP@4dp?$AA@)),
						new string((sbyte*)(&<Module>.??_C@_02CCENMFAC@4d?$AA@))
					};
					this.Text = "Select new object";
					this.control.Root = "objects";
					this.control.ThumbRoot = "Objects";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Model;
					this.control.Extensions = extensions3;
					break;
				}
				case 3:
				{
					string[] extensions4 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BFLBBCNI@mat?$AA@))
					};
					this.Text = "Select new road";
					this.control.Root = "roads";
					this.control.ThumbRoot = "Roads";
					this.control.ViewMode = FilePickerControl.Mode.Composite;
					this.control.ThumbMode = ThumbnailServer.ThumbType.Tile;
					this.control.Extensions = extensions4;
					break;
				}
				case 4:
				{
					string[] extensions5 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BFLBBCNI@mat?$AA@))
					};
					this.Text = "Select new tile";
					this.control.Root = "tiles";
					this.control.ThumbRoot = "Tiles";
					this.control.ViewMode = FilePickerControl.Mode.Composite;
					this.control.ThumbMode = ThumbnailServer.ThumbType.Tile;
					this.control.Extensions = extensions5;
					break;
				}
				case 5:
				{
					string[] extensions6 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_04NPEDKLDA@unit?$AA@))
					};
					this.Text = "Select new unit";
					this.control.Root = "units";
					this.control.ThumbRoot = "Units";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Unit;
					this.control.Extensions = extensions6;
					break;
				}
				case 6:
				{
					string[] extensions7 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_04NPEDKLDA@unit?$AA@))
					};
					this.Text = "Select new building";
					this.control.Root = "buildings";
					this.control.ThumbRoot = "Buildings";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Unit;
					this.control.Extensions = extensions7;
					break;
				}
				case 7:
				{
					string[] extensions8 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_02KLACGCIB@fx?$AA@))
					};
					this.Text = "Select new effect";
					this.control.Root = "effects";
					this.control.ThumbRoot = "Effects";
					this.control.ViewMode = FilePickerControl.Mode.Composite;
					this.control.ThumbMode = ThumbnailServer.ThumbType.Effect;
					this.control.Extensions = extensions8;
					break;
				}
				}
				break;
			case NewAssetPicker.ObjectType.UnitEditor:
				switch (filetype)
				{
				case 27:
				{
					string[] extensions9 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03MBBDFFBP@4dp?$AA@))
					};
					this.control.Text = "Models";
					this.control.Root = "units_data";
					this.control.ThumbRoot = "units";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Model;
					this.control.Extensions = extensions9;
					break;
				}
				case 28:
				{
					string[] extensions10 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_02KLACGCIB@fx?$AA@))
					};
					this.control.Text = "Effects";
					this.control.Root = "effects";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Effect;
					this.control.Extensions = extensions10;
					break;
				}
				case 29:
				{
					string[] extensions11 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03LJIJAGL@tga?$AA@))
					};
					this.control.Text = "Textures";
					this.control.Root = "units_data";
					this.control.ThumbRoot = "units";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Material;
					this.control.Extensions = extensions11;
					break;
				}
				case 30:
				{
					string[] extensions12 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_04NPEDKLDA@unit?$AA@))
					};
					this.control.Text = "Units";
					this.control.Root = "units";
					this.control.ThumbRoot = "units";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Unit;
					this.control.FilterNonEditableUnits = false;
					this.control.Extensions = extensions12;
					break;
				}
				case 31:
				{
					string[] extensions13 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BICDMHKB@wav?$AA@))
					};
					this.control.Text = "Sound";
					this.control.Root = "sounds";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Sound;
					this.control.Extensions = extensions13;
					break;
				}
				case 33:
				{
					string[] extensions14 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BFLBBCNI@mat?$AA@))
					};
					this.control.Text = "Materials";
					this.control.Root = "units_data";
					this.control.ThumbRoot = "units";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Material;
					this.control.Extensions = extensions14;
					break;
				}
				}
				break;
			case NewAssetPicker.ObjectType.EffectEditor:
				switch (filetype)
				{
				case 27:
				{
					string[] extensions15 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03MBBDFFBP@4dp?$AA@))
					};
					this.control.Text = "Models";
					this.control.Root = "effects_data";
					this.control.ThumbRoot = "effects";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Model;
					this.control.Extensions = extensions15;
					break;
				}
				case 29:
				{
					string[] extensions16 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03LJIJAGL@tga?$AA@))
					};
					this.control.Text = "Textures";
					this.control.Root = "effects_data";
					this.control.ThumbRoot = "effects";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Material;
					this.control.Extensions = extensions16;
					break;
				}
				case 31:
				{
					string[] extensions17 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BICDMHKB@wav?$AA@))
					};
					this.control.Text = "Sound";
					this.control.Root = "sounds";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Sound;
					this.control.Extensions = extensions17;
					break;
				}
				case 33:
				{
					string[] extensions18 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BFLBBCNI@mat?$AA@))
					};
					this.control.Text = "Materials";
					this.control.Root = "decals";
					this.control.ThumbRoot = "effects";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Material;
					this.control.Extensions = extensions18;
					break;
				}
				case 34:
				{
					string[] extensions19 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_08PKKGOGAD@particle?$AA@))
					};
					this.control.Text = "Particles";
					this.control.Root = "effects_data";
					this.control.ThumbRoot = "effects";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Material;
					this.control.Extensions = extensions19;
					break;
				}
				}
				break;
			case NewAssetPicker.ObjectType.GameVariablesEditor:
				if (filetype != 30)
				{
					if (filetype == 36)
					{
						string[] extensions20 = new string[]
						{
							new string((sbyte*)(&<Module>.??_C@_03HBNNNHNM@map?$AA@))
						};
						this.control.Text = "Maps";
						this.control.Root = "maps";
						this.control.ThumbRoot = "map";
						this.control.ThumbMode = ThumbnailServer.ThumbType.Map;
						this.control.Extensions = extensions20;
					}
				}
				else
				{
					string[] extensions21 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_04NPEDKLDA@unit?$AA@))
					};
					this.control.Text = "Units";
					this.control.Root = "units";
					this.control.ThumbRoot = "units";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Unit;
					this.control.FilterNonEditableUnits = false;
					this.control.Extensions = extensions21;
				}
				break;
			case NewAssetPicker.ObjectType.MissionVariablesEditor:
				switch (filetype)
				{
				case 28:
				{
					string[] extensions22 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_02KLACGCIB@fx?$AA@))
					};
					this.control.Text = "Effects";
					this.control.Root = "effects";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Effect;
					this.control.Extensions = extensions22;
					break;
				}
				case 30:
				{
					string[] extensions23 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_04NPEDKLDA@unit?$AA@))
					};
					this.control.Text = "Units";
					this.control.Root = "units";
					this.control.ThumbRoot = "units";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Unit;
					this.control.FilterNonEditableUnits = false;
					this.control.Extensions = extensions23;
					break;
				}
				case 31:
				{
					string[] extensions24 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BICDMHKB@wav?$AA@))
					};
					this.control.Text = "Music";
					this.control.Root = "music";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Sound;
					this.control.Extensions = extensions24;
					break;
				}
				case 32:
				{
					string[] extensions25 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03BICDMHKB@wav?$AA@))
					};
					this.control.Text = "Speech";
					this.control.Root = "sounds/dialog";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Sound;
					this.control.Extensions = extensions25;
					break;
				}
				case 35:
				{
					string[] extensions26 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03KCBANMCB@loc?$AA@))
					};
					this.control.Text = "Locales";
					this.control.Root = "locales";
					this.control.ThumbRoot = "locales";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Locale;
					this.control.Extensions = extensions26;
					break;
				}
				case 36:
				{
					string[] extensions27 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03HBNNNHNM@map?$AA@))
					};
					this.control.Text = "Maps";
					this.control.Root = "maps";
					this.control.ThumbRoot = "map";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Map;
					this.control.Extensions = extensions27;
					break;
				}
				case 37:
				{
					string[] extensions28 = new string[]
					{
						new string((sbyte*)(&<Module>.??_C@_03LJIJAGL@tga?$AA@))
					};
					this.control.Text = "Backgrounds";
					this.control.Root = "menu/backgrounds";
					this.control.ThumbRoot = "backgrounds";
					this.control.ThumbMode = ThumbnailServer.ThumbType.Material;
					this.control.Extensions = extensions28;
					break;
				}
				}
				break;
			case NewAssetPicker.ObjectType.SkyBoxLoader:
			{
				string[] extensions29 = new string[]
				{
					new string((sbyte*)(&<Module>.??_C@_03LJIJAGL@tga?$AA@))
				};
				this.Text = "Select new skybox texture";
				this.control.Root = "skybox";
				this.control.ThumbRoot = "skybox";
				this.control.ThumbMode = ThumbnailServer.ThumbType.Box;
				this.control.Extensions = extensions29;
				break;
			}
			case NewAssetPicker.ObjectType.EnvMapLoader:
			{
				string[] extensions30 = new string[]
				{
					new string((sbyte*)(&<Module>.??_C@_03LJIJAGL@tga?$AA@))
				};
				this.Text = "Select new environment map texture";
				this.control.Root = "envmap";
				this.control.ThumbRoot = "envmap";
				this.control.ThumbMode = ThumbnailServer.ThumbType.Box;
				this.control.Extensions = extensions30;
				break;
			}
			case NewAssetPicker.ObjectType.CloudLoader:
			{
				string[] extensions31 = new string[]
				{
					new string((sbyte*)(&<Module>.??_C@_03LJIJAGL@tga?$AA@))
				};
				this.Text = "Select new cloud texture";
				this.control.Root = "clouds";
				this.control.ThumbRoot = "clouds";
				this.control.ThumbMode = ThumbnailServer.ThumbType.Cloud;
				this.control.Extensions = extensions31;
				break;
			}
			}
			this.control.ViewMode = FilePickerControl.Mode.Treeview;
			this.control.SingleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedSingle);
			this.control.DoubleClickSelection += new FilePickerControl.FilePickedHandler(this.FileSelectedDouble);
			base.Controls.Add(this.control);
		}

		protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.control.Dispose();
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.AcceptBtn = new Button();
			this.CancelBtn = new Button();
			base.SuspendLayout();
			this.AcceptBtn.DialogResult = DialogResult.OK;
			this.AcceptBtn.FlatStyle = FlatStyle.System;
			Point location = new Point(8, 336);
			this.AcceptBtn.Location = location;
			this.AcceptBtn.Name = "AcceptBtn";
			Size size = new Size(104, 23);
			this.AcceptBtn.Size = size;
			this.AcceptBtn.TabIndex = 0;
			this.AcceptBtn.Text = "Select";
			this.CancelBtn.DialogResult = DialogResult.Cancel;
			this.CancelBtn.FlatStyle = FlatStyle.System;
			Point location2 = new Point(144, 336);
			this.CancelBtn.Location = location2;
			this.CancelBtn.Name = "CancelBtn";
			Size size2 = new Size(104, 23);
			this.CancelBtn.Size = size2;
			this.CancelBtn.TabIndex = 1;
			this.CancelBtn.Text = "Cancel";
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			Size clientSize = new Size(256, 368);
			base.ClientSize = clientSize;
			base.Controls.Add(this.CancelBtn);
			base.Controls.Add(this.AcceptBtn);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "NewAssetPicker";
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Select new ";
			base.ResumeLayout(false);
		}

		private void FileSelectedSingle(string FileName)
		{
			this.propNewFile = this.control.Root + "/" + FileName;
			this.AcceptBtn.Enabled = true;
		}

		private void FileSelectedDouble(string FileName)
		{
			this.propNewFile = this.control.Root + "/" + FileName;
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		public void Reset()
		{
			this.propNewFile = "";
			this.AcceptBtn.Enabled = false;
		}
	}
}
