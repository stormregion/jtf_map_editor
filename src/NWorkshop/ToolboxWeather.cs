using NControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	public class ToolboxWeather : UserControl
	{
		public unsafe delegate void __Delegate_ValueChanged(GWWeather*);

		private Container components;

		private ColorPicker cpickerAmbient;

		private ColorPicker cpickerSunColor;

		private ColorPicker cpickerFogColor;

		private SliderPanel sliderSunDir;

		private SliderPanel sliderSunElev;

		private SliderPanel sliderFogStart;

		private SliderPanel sliderFogEnd;

		private SliderPanel sliderFogStartVal;

		private SliderPanel sliderFogEndVal;

		private SliderPanel sliderFogSkyBox;

		private SliderPanel sliderDetectionMod;

		private SliderPanel sliderWindDir;

		private SliderPanel sliderWindSpeed;

		private SliderPanel sliderWindRandom;

		private SliderPanel sliderRain;

		private SliderPanel sliderThunder;

		private SliderPanel sliderSnow;

		private SliderPanel sliderClouds;

		private SliderPanel sliderSandstorm;

		private SliderPanel sliderSandstormSize;

		private Toolbar Tools;

		private ListView listWeather;

		private Button SkyboxBtn;

		private Button EnvBtn;

		private Button CloudBtn;

		private Button ResetCloudBtn;

		private Button ResetEnvBtn;

		private Button ResetSkyBtn;

		private ColumnHeader Weathers;

		protected unsafe GEditorWorld* World;

		protected bool ListRefreshing;

		public event ToolboxWeather.__Delegate_ValueChanged ValueChanged
		{
			add
			{
				this.ValueChanged = Delegate.Combine(this.ValueChanged, value);
			}
			remove
			{
				this.ValueChanged = Delegate.Remove(this.ValueChanged, value);
			}
		}

		public unsafe ToolboxWeather()
		{
			this.ValueChanged = null;
			this.World = null;
			this.ListRefreshing = false;
			this.InitializeComponent();
			this.cpickerAmbient = new ColorPicker();
			Point location = new Point(10, 124);
			this.cpickerAmbient.Location = location;
			this.cpickerAmbient.Name = "cpickerAmbient";
			this.cpickerAmbient.TabIndex = 0;
			this.cpickerAmbient.Font = this.Font;
			this.cpickerAmbient.Text = "Ambient";
			this.cpickerAmbient.ValueChanged += new ColorPicker.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.cpickerAmbient);
			this.cpickerSunColor = new ColorPicker();
			Point location2 = new Point(10, 260);
			this.cpickerSunColor.Location = location2;
			this.cpickerSunColor.Name = "cpickerSunColor";
			this.cpickerSunColor.TabIndex = 0;
			this.cpickerSunColor.Font = this.Font;
			this.cpickerSunColor.Text = "Sunlight";
			this.cpickerSunColor.ValueChanged += new ColorPicker.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.cpickerSunColor);
			this.sliderSunDir = new SliderPanel(0, 360, 15);
			Point location3 = new Point(10, 386);
			this.sliderSunDir.Location = location3;
			this.sliderSunDir.Name = "sliderSunDir";
			this.sliderSunDir.TabIndex = 0;
			this.sliderSunDir.Font = this.Font;
			this.sliderSunDir.Text = "Dir";
			this.sliderSunDir.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderSunDir);
			this.sliderSunElev = new SliderPanel(0, 90, 5);
			Point location4 = new Point(10, 414);
			this.sliderSunElev.Location = location4;
			this.sliderSunElev.Name = "sliderSunElev";
			this.sliderSunElev.TabIndex = 0;
			this.sliderSunElev.Font = this.Font;
			this.sliderSunElev.Text = "Elev";
			this.sliderSunElev.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderSunElev);
			this.cpickerFogColor = new ColorPicker();
			Point location5 = new Point(10, 452);
			this.cpickerFogColor.Location = location5;
			this.cpickerFogColor.Name = "cpickerFogColor";
			this.cpickerFogColor.TabIndex = 0;
			this.cpickerFogColor.Font = this.Font;
			this.cpickerFogColor.Text = "Fog";
			this.cpickerFogColor.ValueChanged += new ColorPicker.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.cpickerFogColor);
			this.sliderFogStart = new SliderPanel(0, 1000, 10);
			Point location6 = new Point(10, 578);
			this.sliderFogStart.Location = location6;
			this.sliderFogStart.Name = "sliderFogStart";
			this.sliderFogStart.TabIndex = 0;
			this.sliderFogStart.Font = this.Font;
			this.sliderFogStart.Text = "Start";
			this.sliderFogStart.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderFogStart);
			this.sliderFogEnd = new SliderPanel(0, 1000, 10);
			Point location7 = new Point(10, 606);
			this.sliderFogEnd.Location = location7;
			this.sliderFogEnd.Name = "sliderFogEnd";
			this.sliderFogEnd.TabIndex = 0;
			this.sliderFogEnd.Font = this.Font;
			this.sliderFogEnd.Text = "End";
			this.sliderFogEnd.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderFogEnd);
			this.sliderFogStartVal = new SliderPanel(0, 100, 10);
			Point location8 = new Point(10, 634);
			this.sliderFogStartVal.Location = location8;
			this.sliderFogStartVal.Name = "sliderFogStartVal";
			this.sliderFogStartVal.TabIndex = 0;
			this.sliderFogStartVal.Font = this.Font;
			this.sliderFogStartVal.Text = "StartVal";
			this.sliderFogStartVal.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderFogStartVal);
			this.sliderFogEndVal = new SliderPanel(0, 100, 10);
			Point location9 = new Point(10, 662);
			this.sliderFogEndVal.Location = location9;
			this.sliderFogEndVal.Name = "sliderFogEndVal";
			this.sliderFogEndVal.TabIndex = 0;
			this.sliderFogEndVal.Font = this.Font;
			this.sliderFogEndVal.Text = "EndVal";
			this.sliderFogEndVal.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderFogEndVal);
			this.sliderFogSkyBox = new SliderPanel(0, 100, 10);
			Point location10 = new Point(10, 690);
			this.sliderFogSkyBox.Location = location10;
			this.sliderFogSkyBox.Name = "sliderFogSkyBox";
			this.sliderFogSkyBox.TabIndex = 0;
			this.sliderFogSkyBox.Font = this.Font;
			this.sliderFogSkyBox.Text = "SkyBox";
			this.sliderFogSkyBox.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderFogSkyBox);
			this.sliderDetectionMod = new SliderPanel(1, 100, 5);
			Point location11 = new Point(10, 734);
			this.sliderDetectionMod.Location = location11;
			this.sliderDetectionMod.Name = "sliderDetectionMod";
			this.sliderDetectionMod.TabIndex = 0;
			this.sliderDetectionMod.Font = this.Font;
			this.sliderDetectionMod.Text = "DetectMod";
			this.sliderDetectionMod.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderDetectionMod);
			this.sliderWindDir = new SliderPanel(0, 360, 15);
			Point location12 = new Point(10, 762);
			this.sliderWindDir.Location = location12;
			this.sliderWindDir.Name = "sliderWindDir";
			this.sliderWindDir.TabIndex = 0;
			this.sliderWindDir.Font = this.Font;
			this.sliderWindDir.Text = "Wind Dir";
			this.sliderWindDir.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderWindDir);
			this.sliderWindSpeed = new SliderPanel(0, 60, 5);
			Point location13 = new Point(10, 790);
			this.sliderWindSpeed.Location = location13;
			this.sliderWindSpeed.Name = "sliderWindSpeed";
			this.sliderWindSpeed.TabIndex = 0;
			this.sliderWindSpeed.Font = this.Font;
			this.sliderWindSpeed.Text = "Wind Speed";
			this.sliderWindSpeed.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderWindSpeed);
			this.sliderWindRandom = new SliderPanel(0, 100, 5);
			Point location14 = new Point(10, 818);
			this.sliderWindRandom.Location = location14;
			this.sliderWindRandom.Name = "sliderWindRandom";
			this.sliderWindRandom.TabIndex = 0;
			this.sliderWindRandom.Font = this.Font;
			this.sliderWindRandom.Text = "Wind Random";
			this.sliderWindRandom.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderWindRandom);
			this.sliderRain = new SliderPanel(0, 400, 20);
			Point location15 = new Point(10, 854);
			this.sliderRain.Location = location15;
			this.sliderRain.Name = "sliderRain";
			this.sliderRain.TabIndex = 0;
			this.sliderRain.Font = this.Font;
			this.sliderRain.Text = "Rain";
			this.sliderRain.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderRain);
			this.sliderThunder = new SliderPanel(0, 400, 20);
			Point location16 = new Point(10, 882);
			this.sliderThunder.Location = location16;
			this.sliderThunder.Name = "sliderThunder";
			this.sliderThunder.TabIndex = 0;
			this.sliderThunder.Font = this.Font;
			this.sliderThunder.Text = "Thunder";
			this.sliderThunder.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderThunder);
			this.sliderSnow = new SliderPanel(0, 1200, 20);
			Point location17 = new Point(10, 910);
			this.sliderSnow.Location = location17;
			this.sliderSnow.Name = "sliderSnow";
			this.sliderSnow.TabIndex = 0;
			this.sliderSnow.Font = this.Font;
			this.sliderSnow.Text = "Snow";
			this.sliderSnow.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderSnow);
			this.sliderClouds = new SliderPanel(0, 400, 20);
			Point location18 = new Point(10, 938);
			this.sliderClouds.Location = location18;
			this.sliderClouds.Name = "sliderClouds";
			this.sliderClouds.TabIndex = 0;
			this.sliderClouds.Font = this.Font;
			this.sliderClouds.Text = "Clouds";
			this.sliderClouds.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderClouds);
			this.sliderSandstorm = new SliderPanel(0, 100, 5);
			Point location19 = new Point(10, 966);
			this.sliderSandstorm.Location = location19;
			this.sliderSandstorm.Name = "sliderSandstorm";
			this.sliderSandstorm.TabIndex = 0;
			this.sliderSandstorm.Font = this.Font;
			this.sliderSandstorm.Text = "Sandstorm";
			this.sliderSandstorm.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderSandstorm);
			this.sliderSandstormSize = new SliderPanel(0, 20, 1);
			Point location20 = new Point(10, 994);
			this.sliderSandstormSize.Location = location20;
			this.sliderSandstormSize.Name = "sliderSandstormSize";
			this.sliderSandstormSize.TabIndex = 0;
			this.sliderSandstormSize.Font = this.Font;
			this.sliderSandstormSize.Text = "Sandstorm Size";
			this.sliderSandstormSize.ValueChanged += new SliderPanel.__Delegate_ValueChanged(this.OnValueChanged);
			base.Controls.Add(this.sliderSandstormSize);
			Point location21 = new Point(this.SkyboxBtn.Location.X, 1030);
			this.SkyboxBtn.Location = location21;
			Point location22 = new Point(this.ResetSkyBtn.Location.X, 1030);
			this.ResetSkyBtn.Location = location22;
			Point location23 = new Point(this.EnvBtn.Location.X, 1054);
			this.EnvBtn.Location = location23;
			Point location24 = new Point(this.ResetEnvBtn.Location.X, 1054);
			this.ResetEnvBtn.Location = location24;
			Point location25 = new Point(this.CloudBtn.Location.X, 1078);
			this.CloudBtn.Location = location25;
			Point location26 = new Point(this.ResetCloudBtn.Location.X, 1078);
			this.ResetCloudBtn.Location = location26;
			Toolbar toolbar = new Toolbar((GToolbarItem*)(&<Module>.?items@?1???0ToolboxWeather@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), 24);
			this.Tools = toolbar;
			toolbar.Dock = DockStyle.Top;
			this.Tools.ButtonClick += new Toolbar.__Delegate_ButtonClick(this.tools_ButtonClick);
			Size size = base.Size;
			Size size2 = new Size(base.Size.Width, size.Height);
			this.Tools.Size = size2;
			base.Controls.Add(this.Tools);
			Size size3 = new Size(base.Size.Width, 1106);
			base.Size = size3;
		}

		public unsafe void Refresh(GEditorWorld* world)
		{
			this.World = world;
			this.RefreshList();
			this.RefreshGUI();
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
			this.listWeather = new ListView();
			this.Weathers = new ColumnHeader();
			this.SkyboxBtn = new Button();
			this.EnvBtn = new Button();
			this.CloudBtn = new Button();
			this.ResetCloudBtn = new Button();
			this.ResetEnvBtn = new Button();
			this.ResetSkyBtn = new Button();
			base.SuspendLayout();
			ColumnHeader[] values = new ColumnHeader[]
			{
				this.Weathers
			};
			this.listWeather.Columns.AddRange(values);
			this.listWeather.FullRowSelect = true;
			this.listWeather.GridLines = true;
			this.listWeather.HeaderStyle = ColumnHeaderStyle.None;
			this.listWeather.HideSelection = false;
			this.listWeather.LabelEdit = true;
			this.listWeather.LabelWrap = false;
			Point location = new Point(0, 32);
			this.listWeather.Location = location;
			this.listWeather.MultiSelect = false;
			this.listWeather.Name = "listWeather";
			Size size = new Size(256, 88);
			this.listWeather.Size = size;
			this.listWeather.Sorting = SortOrder.Ascending;
			this.listWeather.TabIndex = 18;
			this.listWeather.View = View.Details;
			this.listWeather.AfterLabelEdit += new LabelEditEventHandler(this.listWeather_AfterLabelEdit);
			this.listWeather.SelectedIndexChanged += new EventHandler(this.listWeather_SelectedIndexChanged);
			this.Weathers.Width = 234;
			Point location2 = new Point(8, 128);
			this.SkyboxBtn.Location = location2;
			this.SkyboxBtn.Name = "SkyboxBtn";
			Size size2 = new Size(120, 23);
			this.SkyboxBtn.Size = size2;
			this.SkyboxBtn.TabIndex = 19;
			this.SkyboxBtn.Text = "Load skybox";
			this.SkyboxBtn.Click += new EventHandler(this.SkyboxBtn_Click);
			Point location3 = new Point(8, 152);
			this.EnvBtn.Location = location3;
			this.EnvBtn.Name = "EnvBtn";
			Size size3 = new Size(120, 23);
			this.EnvBtn.Size = size3;
			this.EnvBtn.TabIndex = 20;
			this.EnvBtn.Text = "Load environment";
			this.EnvBtn.Click += new EventHandler(this.EnvBtn_Click);
			this.EnvBtn.Enabled = false;
			Point location4 = new Point(8, 176);
			this.CloudBtn.Location = location4;
			this.CloudBtn.Name = "CloudBtn";
			Size size4 = new Size(120, 23);
			this.CloudBtn.Size = size4;
			this.CloudBtn.TabIndex = 21;
			this.CloudBtn.Text = "Load cloud";
			this.CloudBtn.Click += new EventHandler(this.CloudBtn_Click);
			Point location5 = new Point(128, 176);
			this.ResetCloudBtn.Location = location5;
			this.ResetCloudBtn.Name = "ResetCloudBtn";
			Size size5 = new Size(120, 23);
			this.ResetCloudBtn.Size = size5;
			this.ResetCloudBtn.TabIndex = 24;
			this.ResetCloudBtn.Text = "Reset cloud";
			this.ResetCloudBtn.Click += new EventHandler(this.ResetCloudBtn_Click);
			Point location6 = new Point(128, 152);
			this.ResetEnvBtn.Location = location6;
			this.ResetEnvBtn.Name = "ResetEnvBtn";
			Size size6 = new Size(120, 23);
			this.ResetEnvBtn.Size = size6;
			this.ResetEnvBtn.TabIndex = 23;
			this.ResetEnvBtn.Text = "Reset environment";
			this.ResetEnvBtn.Click += new EventHandler(this.ResetEnvBtn_Click);
			this.ResetEnvBtn.Enabled = false;
			Point location7 = new Point(128, 128);
			this.ResetSkyBtn.Location = location7;
			this.ResetSkyBtn.Name = "ResetSkyBtn";
			Size size7 = new Size(120, 23);
			this.ResetSkyBtn.Size = size7;
			this.ResetSkyBtn.TabIndex = 22;
			this.ResetSkyBtn.Text = "Reset skybox";
			this.ResetSkyBtn.Click += new EventHandler(this.ResetSkyBtn_Click);
			base.Controls.Add(this.ResetCloudBtn);
			base.Controls.Add(this.ResetEnvBtn);
			base.Controls.Add(this.ResetSkyBtn);
			base.Controls.Add(this.CloudBtn);
			base.Controls.Add(this.EnvBtn);
			base.Controls.Add(this.SkyboxBtn);
			base.Controls.Add(this.listWeather);
			this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			base.Name = "ToolboxWeather";
			Size size8 = new Size(256, 460);
			base.Size = size8;
			base.ResumeLayout(false);
		}

		protected unsafe void RefreshList()
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			this.listWeather.BeginUpdate();
			this.listWeather.Items.Clear();
			int num2 = -1;
			while (true)
			{
				GHeap<GWWeather>* ptr = this.World + 3436 / sizeof(GEditorWorld);
				int num3 = num2 + 1;
				int num4 = *(ptr + 4);
				if (num3 >= num4)
				{
					break;
				}
				int num5 = num3 * 124 + *ptr;
				while (*num5 != 2147483647)
				{
					num3++;
					num5 += 124;
					if (num3 >= num4)
					{
						goto IL_D5;
					}
				}
				num2 = num3;
				if (num3 < 0)
				{
					break;
				}
				ListViewItem listViewItem = new ListViewItem();
				uint num6 = (uint)(*(num3 * 124 + *(int*)(this.World + 3436 / sizeof(GEditorWorld)) + 12));
				sbyte* value;
				if (num6 != 0u)
				{
					value = num6;
				}
				else
				{
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				listViewItem.Text = new string((sbyte*)value);
				listViewItem.Tag = num3;
				this.listWeather.Items.Add(listViewItem);
			}
			IL_D5:
			int num7 = *(int*)(this.World + 3456 / sizeof(GEditorWorld));
			try
			{
				for (int i = 0; i < this.listWeather.Items.Count; i++)
				{
					object tag = this.listWeather.Items[i].Tag;
					int* ptr2;
					if (tag is int)
					{
						ptr2 = ref (int)tag;
					}
					else
					{
						ptr2 = 0;
					}
					if (num7 == *ptr2)
					{
						this.listWeather.Items[i].Selected = true;
					}
				}
				goto IL_19B;
			}
			uint exceptionCode = (uint)Marshal.GetExceptionCode();
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			IL_19B:
			this.listWeather.EndUpdate();
			Size clientSize = this.listWeather.ClientSize;
			this.listWeather.Columns[0].Width = clientSize.Width;
		}

		protected unsafe void RefreshGUI()
		{
			GWWeather* ptr = <Module>.GEditorWorld.GetWeather(this.World, -1);
			this.cpickerAmbient.Hue = *(ptr + 16);
			this.cpickerAmbient.Sat = *(ptr + 20);
			this.cpickerAmbient.Val = *(ptr + 24);
			this.cpickerSunColor.Hue = *(ptr + 28);
			this.cpickerSunColor.Sat = *(ptr + 32);
			this.cpickerSunColor.Val = *(ptr + 36);
			this.sliderSunDir.Value = *(ptr + 40);
			this.sliderSunElev.Value = *(ptr + 44);
			this.cpickerFogColor.Hue = *(ptr + 48);
			this.cpickerFogColor.Sat = *(ptr + 52);
			this.cpickerFogColor.Val = *(ptr + 56);
			this.sliderFogStart.Value = *(ptr + 60);
			this.sliderFogEnd.Value = *(ptr + 64);
			this.sliderFogStartVal.Value = *(ptr + 68);
			this.sliderFogEndVal.Value = *(ptr + 72);
			this.sliderFogSkyBox.Value = *(ptr + 76);
			this.sliderWindDir.Value = *(ptr + 80);
			this.sliderWindSpeed.Value = *(ptr + 84);
			this.sliderWindRandom.Value = *(ptr + 88);
			this.sliderRain.Value = *(ptr + 92);
			this.sliderThunder.Value = *(ptr + 96);
			this.sliderSnow.Value = *(ptr + 100);
			this.sliderClouds.Value = *(ptr + 104);
			this.sliderSandstorm.Value = *(ptr + 108);
			this.sliderSandstormSize.Value = *(ptr + 112);
			this.sliderDetectionMod.Value = *(ptr + 116);
		}

		protected unsafe void OnValueChanged()
		{
			GWWeather gWWeather;
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
				ColorPicker colorPicker = this.cpickerAmbient;
				*(ref gWWeather + 16) = colorPicker.Hue;
				*(ref gWWeather + 20) = colorPicker.Sat;
				*(ref gWWeather + 24) = colorPicker.Val;
				ColorPicker colorPicker2 = this.cpickerSunColor;
				*(ref gWWeather + 28) = colorPicker2.Hue;
				*(ref gWWeather + 32) = colorPicker2.Sat;
				*(ref gWWeather + 36) = colorPicker2.Val;
				*(ref gWWeather + 40) = this.sliderSunDir.Value;
				*(ref gWWeather + 44) = this.sliderSunElev.Value;
				ColorPicker colorPicker3 = this.cpickerFogColor;
				*(ref gWWeather + 48) = colorPicker3.Hue;
				*(ref gWWeather + 52) = colorPicker3.Sat;
				*(ref gWWeather + 56) = colorPicker3.Val;
				*(ref gWWeather + 60) = this.sliderFogStart.Value;
				*(ref gWWeather + 64) = this.sliderFogEnd.Value;
				*(ref gWWeather + 68) = this.sliderFogStartVal.Value;
				*(ref gWWeather + 72) = this.sliderFogEndVal.Value;
				*(ref gWWeather + 76) = this.sliderFogSkyBox.Value;
				*(ref gWWeather + 80) = this.sliderWindDir.Value;
				*(ref gWWeather + 84) = this.sliderWindSpeed.Value;
				*(ref gWWeather + 88) = this.sliderWindRandom.Value;
				*(ref gWWeather + 92) = this.sliderRain.Value;
				*(ref gWWeather + 96) = this.sliderThunder.Value;
				*(ref gWWeather + 100) = this.sliderSnow.Value;
				*(ref gWWeather + 104) = this.sliderClouds.Value;
				*(ref gWWeather + 108) = this.sliderSandstorm.Value;
				*(ref gWWeather + 112) = this.sliderSandstormSize.Value;
				*(ref gWWeather + 116) = this.sliderDetectionMod.Value;
				this.raise_ValueChanged(ref gWWeather);
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

		protected void tools_ButtonClick(int idx, int group)
		{
			switch (idx)
			{
			case 1:
				this.btnNew_Click();
				break;
			case 2:
				this.btnCopy_Click();
				break;
			case 3:
				this.btnDelete_Click();
				break;
			case 4:
				this.btnReset_Click();
				break;
			}
		}

		protected unsafe void btnNew_Click()
		{
			if (this.World != null)
			{
				GWWeather gWWeather;
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
					GBaseString<char> gBaseString<char>;
					GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
					GBaseString<char>* ptr2;
					GEditorWorld* world;
					try
					{
						GBaseString<char> gBaseString<char>2;
						ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						try
						{
							world = this.World;
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
							throw;
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
						throw;
					}
					GBaseString<char> gBaseString<char>3;
					GBaseString<char>* ptr3 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world, &gBaseString<char>3, 5, ptr2, -1, ptr);
					try
					{
						int num = *(int*)(ptr3 + 4 / sizeof(GBaseString<char>));
						if (num != 0)
						{
							*(ref gWWeather + 12) = num;
							*(ref gWWeather + 8) = <Module>.realloc(*(ref gWWeather + 8), (uint)(*(ref gWWeather + 12) + 1));
							cpblk(*(ref gWWeather + 8), *(int*)ptr3, *(ref gWWeather + 12) + 1);
						}
						else
						{
							*(ref gWWeather + 12) = 0;
							if (*(ref gWWeather + 8) != 0)
							{
								<Module>.free(*(ref gWWeather + 8));
								*(ref gWWeather + 8) = 0;
							}
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
					<Module>.GWorld.SetNextWeather(this.World, <Module>.GEditorWorld.AddWeather(this.World, ref gWWeather), 0f);
					this.Refresh(this.World);
					if (this.listWeather.SelectedItems.Count > 0)
					{
						this.listWeather.SelectedItems[0].BeginEdit();
					}
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
		}

		protected unsafe void btnCopy_Click()
		{
			if (this.World != null && this.listWeather.SelectedIndices.Count > 0)
			{
				GWWeather* ptr = <Module>.GEditorWorld.GetWeather(this.World, -1);
				GWWeather gWWeather;
				<Module>.GAWeather.{ctor}(ref gWWeather, ptr);
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
					GWWeather gWWeather2;
					<Module>.GAWeather.{ctor}(ref gWWeather2, ref gWWeather);
					try
					{
						gWWeather2 = ref <Module>.??_7GWWeather@@6B@;
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GAWeather.{dtor}), (void*)(&gWWeather2));
						throw;
					}
					try
					{
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char> gBaseString<char>2;
						GEditorWorld* world;
						try
						{
							if (*(ref gWWeather2 + 12) != 0)
							{
								*(ref gBaseString<char>2 + 4) = *(ref gWWeather2 + 12);
								gBaseString<char>2 = <Module>.malloc((uint)(*(ref gWWeather2 + 12) + 1));
								cpblk(gBaseString<char>2, *(ref gWWeather2 + 8), *(ref gBaseString<char>2 + 4) + 1);
							}
							else
							{
								*(ref gBaseString<char>2 + 4) = 0;
								gBaseString<char>2 = 0;
							}
							try
							{
								world = this.World;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
							throw;
						}
						GBaseString<char> gBaseString<char>3;
						GBaseString<char>* src = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world, &gBaseString<char>3, 5, (GBaseString<char>*)(&gBaseString<char>2), -1, ptr2);
						try
						{
							<Module>.GBaseString<char>.=(ref gWWeather2 + 8, src);
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
						<Module>.GWorld.SetNextWeather(this.World, <Module>.GEditorWorld.AddWeather(this.World, ref gWWeather2), 0f);
						this.Refresh(this.World);
						if (this.listWeather.SelectedItems.Count > 0)
						{
							this.listWeather.SelectedItems[0].BeginEdit();
						}
					}
					catch
					{
						<Module>.___CxxCallUnwindDtor(ldftn(GWWeather.{dtor}), (void*)(&gWWeather2));
						throw;
					}
					if (*(ref gWWeather2 + 8) != 0)
					{
						<Module>.free(*(ref gWWeather2 + 8));
						*(ref gWWeather2 + 8) = 0;
					}
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
		}

		protected unsafe void btnDelete_Click()
		{
			if (this.World != null && this.listWeather.SelectedIndices.Count > 0)
			{
				GEditorWorld* world = this.World;
				int num = *(int*)(world + 3456 / sizeof(GEditorWorld));
				if (<Module>.GEditorWorld.RemoveWeather(world, num) != null)
				{
					world = this.World;
					GEditorWorld* expr_3C = world;
					<Module>.GWorld.SetNextWeather(expr_3C, <Module>.GHeap<GWWeather>.GetNext(expr_3C + 3436 / sizeof(GEditorWorld), -1), 0f);
				}
				this.Refresh(this.World);
			}
		}

		protected unsafe void btnReset_Click()
		{
			if (this.World != null)
			{
				GWWeather gWWeather;
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
					this.raise_ValueChanged(ref gWWeather);
					this.RefreshGUI();
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
		}

		protected unsafe void listWeather_SelectedIndexChanged(object sender, EventArgs e)
		{
			int num = (int)stackalloc byte[<Module>.__CxxQueryExceptionSize()];
			if (this.World != null && this.listWeather.SelectedIndices.Count > 0)
			{
				try
				{
					object tag = this.listWeather.SelectedItems[0].Tag;
					int* ptr;
					if (tag is int)
					{
						ptr = ref (int)tag;
					}
					else
					{
						ptr = 0;
					}
					<Module>.GWorld.SetNextWeather(this.World, *ptr, 0f);
					this.RefreshGUI();
					return;
				}
				uint exceptionCode = (uint)Marshal.GetExceptionCode();
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), null, 0, null));
			}
		}

		private unsafe void listWeather_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (e.Label != null)
			{
				GWWeather* ptr = <Module>.GEditorWorld.GetWeather(this.World, -1);
				GWWeather gWWeather;
				<Module>.GAWeather.{ctor}(ref gWWeather, ptr);
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
					if (e.Label.Length > 0)
					{
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr2 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_00CNPNBAHC@?$AA@));
						GBaseString<char>* ptr3;
						GEditorWorld* world;
						try
						{
							GBaseString<char> gBaseString<char>2;
							ptr3 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, e.Label);
							try
							{
								world = this.World;
							}
							catch
							{
								<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>2));
								throw;
							}
						}
						catch
						{
							<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
							throw;
						}
						GBaseString<char> gBaseString<char>3;
						GBaseString<char>* ptr4 = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world, &gBaseString<char>3, 5, ptr3, -2, ptr2);
						try
						{
							<Module>.GEditorWorld.RenameWeather(this.World, ptr4, -1);
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
						e.CancelEdit = true;
						this.RefreshList();
					}
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
		}

		private unsafe void SkyboxBtn_Click(object sender, EventArgs e)
		{
			NewAssetPicker newAssetPicker = new NewAssetPicker(NewAssetPicker.ObjectType.SkyBoxLoader, 0);
			newAssetPicker.Reset();
			if (newAssetPicker.ShowDialog() == DialogResult.OK)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, newAssetPicker.NewName);
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
					<Module>.GWorld.SetSkyBox(this.World, ptr2);
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
				GBaseString<char> gBaseString<char>2;
				GBaseString<char>* ptr3 = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>2, newAssetPicker.NewName);
				try
				{
					uint num2 = (uint)(*ptr3);
					sbyte* ptr4;
					if (num2 != 0u)
					{
						ptr4 = num2;
					}
					else
					{
						ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
					}
					<Module>.GWorld.SetEnvironmentMap(this.World, ptr4);
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
		}

		private void EnvBtn_Click(object sender, EventArgs e)
		{
		}

		private unsafe void CloudBtn_Click(object sender, EventArgs e)
		{
			NewAssetPicker newAssetPicker = new NewAssetPicker(NewAssetPicker.ObjectType.CloudLoader, 0);
			newAssetPicker.Reset();
			if (newAssetPicker.ShowDialog() == DialogResult.OK)
			{
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, newAssetPicker.NewName);
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
					<Module>.GWorld.SetCloud(this.World, ptr2);
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

		private void ResetSkyBtn_Click(object sender, EventArgs e)
		{
			<Module>.GWorld.SetSkyBox(this.World, null);
			<Module>.GWorld.SetEnvironmentMap(this.World, null);
		}

		private void ResetEnvBtn_Click(object sender, EventArgs e)
		{
		}

		private void ResetCloudBtn_Click(object sender, EventArgs e)
		{
			<Module>.GWorld.SetCloud(this.World, null);
		}

		protected unsafe void raise_ValueChanged(GWWeather* i1)
		{
			ToolboxWeather.__Delegate_ValueChanged valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged(i1);
			}
		}
	}
}
