using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class PasteOptions : Form
	{
		private GroupBox TerrainGroup;

		private GroupBox WaterGroup;

		private GroupBox ObjectGroup;

		private GroupBox StructGroup;

		private GroupBox MiscGroup;

		private CheckBox HeightCheck;

		private CheckBox LayersCheck;

		private CheckBox ColorCheck;

		private CheckBox LakeCheck;

		private CheckBox RiverCheck;

		private CheckBox RoadCheck;

		private CheckBox BuildCheck;

		private CheckBox WireCheck;

		private CheckBox ObjectCheck;

		private CheckBox DecalCheck;

		private CheckBox UnitCheck;

		private CheckBox SoundCheck;

		private CheckBox EffectCheck;

		private Button OKBtn;

		private Button NOBtn;

		private Container components;

		private uint propPasteOptionFlags;

		private bool Lock;

		public uint PasteOptionFlags
		{
			get
			{
				return this.propPasteOptionFlags;
			}
			set
			{
				this.propPasteOptionFlags = value;
				this.Lock = true;
				this.HeightCheck.Checked = ((value & 1) != 0);
				byte @checked = (byte)(this.propPasteOptionFlags >> 1 & 1u);
				this.LayersCheck.Checked = (@checked != 0);
				byte checked2 = (byte)(this.propPasteOptionFlags >> 2 & 1u);
				this.ColorCheck.Checked = (checked2 != 0);
				byte checked3 = (byte)(this.propPasteOptionFlags >> 3 & 1u);
				this.DecalCheck.Checked = (checked3 != 0);
				byte checked4 = (byte)(this.propPasteOptionFlags >> 4 & 1u);
				this.LakeCheck.Checked = (checked4 != 0);
				byte checked5 = (byte)(this.propPasteOptionFlags >> 5 & 1u);
				this.RiverCheck.Checked = (checked5 != 0);
				byte checked6 = (byte)(this.propPasteOptionFlags >> 6 & 1u);
				this.RoadCheck.Checked = (checked6 != 0);
				byte checked7 = (byte)(this.propPasteOptionFlags >> 7 & 1u);
				this.BuildCheck.Checked = (checked7 != 0);
				byte checked8 = (byte)(this.propPasteOptionFlags >> 8 & 1u);
				this.WireCheck.Checked = (checked8 != 0);
				byte checked9 = (byte)(this.propPasteOptionFlags >> 9 & 1u);
				this.ObjectCheck.Checked = (checked9 != 0);
				byte checked10 = (byte)(this.propPasteOptionFlags >> 10 & 1u);
				this.UnitCheck.Checked = (checked10 != 0);
				byte checked11 = (byte)(this.propPasteOptionFlags >> 11 & 1u);
				this.SoundCheck.Checked = (checked11 != 0);
				byte checked12 = (byte)(this.propPasteOptionFlags >> 12 & 1u);
				this.EffectCheck.Checked = (checked12 != 0);
				byte checked13 = (byte)(this.propPasteOptionFlags >> 12 & 1u);
				this.EffectCheck.Checked = (checked13 != 0);
				this.Lock = false;
			}
		}

		public PasteOptions()
		{
			this.InitializeComponent();
			this.Lock = false;
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
			this.TerrainGroup = new GroupBox();
			this.DecalCheck = new CheckBox();
			this.ColorCheck = new CheckBox();
			this.LayersCheck = new CheckBox();
			this.HeightCheck = new CheckBox();
			this.WaterGroup = new GroupBox();
			this.RiverCheck = new CheckBox();
			this.LakeCheck = new CheckBox();
			this.ObjectGroup = new GroupBox();
			this.UnitCheck = new CheckBox();
			this.ObjectCheck = new CheckBox();
			this.StructGroup = new GroupBox();
			this.WireCheck = new CheckBox();
			this.BuildCheck = new CheckBox();
			this.RoadCheck = new CheckBox();
			this.MiscGroup = new GroupBox();
			this.EffectCheck = new CheckBox();
			this.SoundCheck = new CheckBox();
			this.OKBtn = new Button();
			this.NOBtn = new Button();
			this.TerrainGroup.SuspendLayout();
			this.WaterGroup.SuspendLayout();
			this.ObjectGroup.SuspendLayout();
			this.StructGroup.SuspendLayout();
			this.MiscGroup.SuspendLayout();
			base.SuspendLayout();
			this.TerrainGroup.Controls.Add(this.DecalCheck);
			this.TerrainGroup.Controls.Add(this.ColorCheck);
			this.TerrainGroup.Controls.Add(this.LayersCheck);
			this.TerrainGroup.Controls.Add(this.HeightCheck);
			this.TerrainGroup.FlatStyle = FlatStyle.System;
			Point location = new Point(8, 8);
			this.TerrainGroup.Location = location;
			this.TerrainGroup.Name = "TerrainGroup";
			Size size = new Size(112, 120);
			this.TerrainGroup.Size = size;
			this.TerrainGroup.TabIndex = 0;
			this.TerrainGroup.TabStop = false;
			this.TerrainGroup.Text = "Terrain";
			this.DecalCheck.FlatStyle = FlatStyle.System;
			Point location2 = new Point(8, 88);
			this.DecalCheck.Location = location2;
			this.DecalCheck.Name = "DecalCheck";
			Size size2 = new Size(96, 24);
			this.DecalCheck.Size = size2;
			this.DecalCheck.TabIndex = 3;
			this.DecalCheck.Text = "Decals";
			this.DecalCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.ColorCheck.FlatStyle = FlatStyle.System;
			Point location3 = new Point(8, 64);
			this.ColorCheck.Location = location3;
			this.ColorCheck.Name = "ColorCheck";
			Size size3 = new Size(96, 24);
			this.ColorCheck.Size = size3;
			this.ColorCheck.TabIndex = 2;
			this.ColorCheck.Text = "Vertex color";
			this.ColorCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.LayersCheck.FlatStyle = FlatStyle.System;
			Point location4 = new Point(8, 40);
			this.LayersCheck.Location = location4;
			this.LayersCheck.Name = "LayersCheck";
			Size size4 = new Size(96, 24);
			this.LayersCheck.Size = size4;
			this.LayersCheck.TabIndex = 1;
			this.LayersCheck.Text = "Terrain layers";
			this.LayersCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.HeightCheck.FlatStyle = FlatStyle.System;
			Point location5 = new Point(8, 16);
			this.HeightCheck.Location = location5;
			this.HeightCheck.Name = "HeightCheck";
			Size size5 = new Size(96, 24);
			this.HeightCheck.Size = size5;
			this.HeightCheck.TabIndex = 0;
			this.HeightCheck.Text = "Height map";
			this.HeightCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.WaterGroup.Controls.Add(this.RiverCheck);
			this.WaterGroup.Controls.Add(this.LakeCheck);
			this.WaterGroup.FlatStyle = FlatStyle.System;
			Point location6 = new Point(8, 128);
			this.WaterGroup.Location = location6;
			this.WaterGroup.Name = "WaterGroup";
			Size size6 = new Size(112, 72);
			this.WaterGroup.Size = size6;
			this.WaterGroup.TabIndex = 1;
			this.WaterGroup.TabStop = false;
			this.WaterGroup.Text = "Water";
			this.RiverCheck.FlatStyle = FlatStyle.System;
			Point location7 = new Point(8, 40);
			this.RiverCheck.Location = location7;
			this.RiverCheck.Name = "RiverCheck";
			Size size7 = new Size(96, 24);
			this.RiverCheck.Size = size7;
			this.RiverCheck.TabIndex = 1;
			this.RiverCheck.Text = "Rivers";
			this.RiverCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.LakeCheck.FlatStyle = FlatStyle.System;
			Point location8 = new Point(8, 16);
			this.LakeCheck.Location = location8;
			this.LakeCheck.Name = "LakeCheck";
			Size size8 = new Size(96, 24);
			this.LakeCheck.Size = size8;
			this.LakeCheck.TabIndex = 0;
			this.LakeCheck.Text = "Lakes";
			this.LakeCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.ObjectGroup.Controls.Add(this.UnitCheck);
			this.ObjectGroup.Controls.Add(this.ObjectCheck);
			this.ObjectGroup.FlatStyle = FlatStyle.System;
			Point location9 = new Point(8, 296);
			this.ObjectGroup.Location = location9;
			this.ObjectGroup.Name = "ObjectGroup";
			Size size9 = new Size(112, 72);
			this.ObjectGroup.Size = size9;
			this.ObjectGroup.TabIndex = 2;
			this.ObjectGroup.TabStop = false;
			this.ObjectGroup.Text = "Objects";
			this.UnitCheck.FlatStyle = FlatStyle.System;
			Point location10 = new Point(8, 40);
			this.UnitCheck.Location = location10;
			this.UnitCheck.Name = "UnitCheck";
			Size size10 = new Size(96, 24);
			this.UnitCheck.Size = size10;
			this.UnitCheck.TabIndex = 1;
			this.UnitCheck.Text = "Units";
			this.UnitCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.ObjectCheck.FlatStyle = FlatStyle.System;
			Point location11 = new Point(8, 16);
			this.ObjectCheck.Location = location11;
			this.ObjectCheck.Name = "ObjectCheck";
			Size size11 = new Size(96, 24);
			this.ObjectCheck.Size = size11;
			this.ObjectCheck.TabIndex = 0;
			this.ObjectCheck.Text = "Objects";
			this.ObjectCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.StructGroup.Controls.Add(this.WireCheck);
			this.StructGroup.Controls.Add(this.BuildCheck);
			this.StructGroup.Controls.Add(this.RoadCheck);
			this.StructGroup.FlatStyle = FlatStyle.System;
			Point location12 = new Point(8, 200);
			this.StructGroup.Location = location12;
			this.StructGroup.Name = "StructGroup";
			Size size12 = new Size(112, 96);
			this.StructGroup.Size = size12;
			this.StructGroup.TabIndex = 3;
			this.StructGroup.TabStop = false;
			this.StructGroup.Text = "Structures";
			this.WireCheck.FlatStyle = FlatStyle.System;
			Point location13 = new Point(8, 64);
			this.WireCheck.Location = location13;
			this.WireCheck.Name = "WireCheck";
			Size size13 = new Size(96, 24);
			this.WireCheck.Size = size13;
			this.WireCheck.TabIndex = 2;
			this.WireCheck.Text = "Wires";
			this.WireCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.BuildCheck.FlatStyle = FlatStyle.System;
			Point location14 = new Point(8, 40);
			this.BuildCheck.Location = location14;
			this.BuildCheck.Name = "BuildCheck";
			Size size14 = new Size(96, 24);
			this.BuildCheck.Size = size14;
			this.BuildCheck.TabIndex = 1;
			this.BuildCheck.Text = "Buildings";
			this.BuildCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.RoadCheck.FlatStyle = FlatStyle.System;
			Point location15 = new Point(8, 16);
			this.RoadCheck.Location = location15;
			this.RoadCheck.Name = "RoadCheck";
			Size size15 = new Size(96, 24);
			this.RoadCheck.Size = size15;
			this.RoadCheck.TabIndex = 0;
			this.RoadCheck.Text = "Roads";
			this.RoadCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.MiscGroup.Controls.Add(this.EffectCheck);
			this.MiscGroup.Controls.Add(this.SoundCheck);
			this.MiscGroup.FlatStyle = FlatStyle.System;
			Point location16 = new Point(8, 368);
			this.MiscGroup.Location = location16;
			this.MiscGroup.Name = "MiscGroup";
			Size size16 = new Size(112, 72);
			this.MiscGroup.Size = size16;
			this.MiscGroup.TabIndex = 4;
			this.MiscGroup.TabStop = false;
			this.MiscGroup.Text = "Miscellaneous";
			this.EffectCheck.FlatStyle = FlatStyle.System;
			Point location17 = new Point(8, 40);
			this.EffectCheck.Location = location17;
			this.EffectCheck.Name = "EffectCheck";
			Size size17 = new Size(96, 24);
			this.EffectCheck.Size = size17;
			this.EffectCheck.TabIndex = 1;
			this.EffectCheck.Text = "Effects";
			this.EffectCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.SoundCheck.FlatStyle = FlatStyle.System;
			Point location18 = new Point(8, 16);
			this.SoundCheck.Location = location18;
			this.SoundCheck.Name = "SoundCheck";
			Size size18 = new Size(96, 24);
			this.SoundCheck.Size = size18;
			this.SoundCheck.TabIndex = 0;
			this.SoundCheck.Text = "Sounds";
			this.SoundCheck.CheckedChanged += new EventHandler(this.OptionChange);
			this.OKBtn.DialogResult = DialogResult.OK;
			this.OKBtn.FlatStyle = FlatStyle.System;
			Point location19 = new Point(8, 448);
			this.OKBtn.Location = location19;
			this.OKBtn.Name = "OKBtn";
			Size size19 = new Size(56, 23);
			this.OKBtn.Size = size19;
			this.OKBtn.TabIndex = 5;
			this.OKBtn.Text = "GO!";
			this.NOBtn.DialogResult = DialogResult.Cancel;
			this.NOBtn.FlatStyle = FlatStyle.System;
			Point location20 = new Point(64, 448);
			this.NOBtn.Location = location20;
			this.NOBtn.Name = "NOBtn";
			Size size20 = new Size(56, 23);
			this.NOBtn.Size = size20;
			this.NOBtn.TabIndex = 6;
			this.NOBtn.Text = "NO!";
			base.AcceptButton = this.OKBtn;
			Size autoScaleBaseSize = new Size(5, 13);
			this.AutoScaleBaseSize = autoScaleBaseSize;
			base.CancelButton = this.NOBtn;
			Size clientSize = new Size(128, 474);
			base.ClientSize = clientSize;
			base.ControlBox = false;
			base.Controls.Add(this.NOBtn);
			base.Controls.Add(this.OKBtn);
			base.Controls.Add(this.MiscGroup);
			base.Controls.Add(this.StructGroup);
			base.Controls.Add(this.ObjectGroup);
			base.Controls.Add(this.WaterGroup);
			base.Controls.Add(this.TerrainGroup);
			base.Name = "PasteOptions";
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Paste Special";
			this.TerrainGroup.ResumeLayout(false);
			this.WaterGroup.ResumeLayout(false);
			this.ObjectGroup.ResumeLayout(false);
			this.StructGroup.ResumeLayout(false);
			this.MiscGroup.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void OptionChange(object sender, EventArgs e)
		{
			if (!this.Lock)
			{
				this.propPasteOptionFlags = 0u;
				if (this.HeightCheck.Checked)
				{
					this.propPasteOptionFlags |= 1u;
				}
				if (this.LayersCheck.Checked)
				{
					this.propPasteOptionFlags |= 2u;
				}
				if (this.ColorCheck.Checked)
				{
					this.propPasteOptionFlags |= 4u;
				}
				if (this.DecalCheck.Checked)
				{
					this.propPasteOptionFlags |= 8u;
				}
				if (this.LakeCheck.Checked)
				{
					this.propPasteOptionFlags |= 16u;
				}
				if (this.RiverCheck.Checked)
				{
					this.propPasteOptionFlags |= 32u;
				}
				if (this.RoadCheck.Checked)
				{
					this.propPasteOptionFlags |= 64u;
				}
				if (this.BuildCheck.Checked)
				{
					this.propPasteOptionFlags |= 128u;
				}
				if (this.WireCheck.Checked)
				{
					this.propPasteOptionFlags |= 256u;
				}
				if (this.ObjectCheck.Checked)
				{
					this.propPasteOptionFlags |= 512u;
				}
				if (this.UnitCheck.Checked)
				{
					this.propPasteOptionFlags |= 1024u;
				}
				if (this.SoundCheck.Checked)
				{
					this.propPasteOptionFlags |= 2048u;
				}
				if (this.EffectCheck.Checked)
				{
					this.propPasteOptionFlags |= 4096u;
				}
			}
		}
	}
}
