using <CppImplementationDetails>;
using NWorkshop;
using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class PropertyItemVector : PropertyItemString
	{
		protected NImageButton ColorButton;

		protected unsafe void ColorButton_Click(object sender, EventArgs e)
		{
			ColorPickerDialog colorPickerDialog = new ColorPickerDialog();
			Point location = this.ColorButton.Location;
			colorPickerDialog.Location = location;
			void* var = this.Var;
			colorPickerDialog.SetRGBA(*(float*)var, *(float*)((byte*)var + 4), *(float*)((byte*)var + 8), *(float*)((byte*)var + 12));
			if (colorPickerDialog.ShowDialog() == DialogResult.OK)
			{
				var = this.Var;
				ColorPickerDialog arg_51_0 = colorPickerDialog;
				void* expr_47 = var;
				arg_51_0.GetRGBA(expr_47, (byte*)expr_47 + 4, (byte*)var + 8, (byte*)var + 12);
				this.ComponentChanged();
				this.Host.RegenerateSubtree(this.Index);
				this.Host.InvalidateViewControl();
			}
		}

		protected unsafe override string GetValue()
		{
			switch (*(int*)this.Type)
			{
			case 16:
			case 17:
			{
				void* var = this.Var;
				GBaseString<char> gBaseString<char>;
				GBaseString<char>* ptr = <Module>.Format(&gBaseString<char>, (sbyte*)(&<Module>.??_C@_08EJKDHBBI@?$CI?$CFf?$DL?5?$CFf?$CJ?$AA@), (double)(*(float*)var), (double)(*(float*)((byte*)var + 4)));
				string result;
				try
				{
					uint num = (uint)(*(int*)ptr);
					result = new string((sbyte*)((num == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num));
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
			case 19:
			case 20:
			{
				void* var2 = this.Var;
				GBaseString<char> gBaseString<char>2;
				GBaseString<char>* ptr2 = <Module>.Format(&gBaseString<char>2, (sbyte*)(&<Module>.??_C@_0N@FKJLJAOI@?$CI?$CFf?$DL?5?$CFf?$DL?5?$CFf?$CJ?$AA@), (double)(*(float*)var2), (double)(*(float*)((byte*)var2 + 4)), (double)(*(float*)((byte*)var2 + 8)));
				string result2;
				try
				{
					uint num2 = (uint)(*(int*)ptr2);
					result2 = new string((sbyte*)((num2 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num2));
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
				return result2;
			}
			case 22:
			{
				void* var3 = this.Var;
				GBaseString<char> gBaseString<char>3;
				GBaseString<char>* ptr3 = <Module>.Format(&gBaseString<char>3, (sbyte*)(&<Module>.??_C@_0BB@OHPMMBPN@?$CI?$CFf?$DL?5?$CFf?$DL?5?$CFf?$DL?5?$CFf?$CJ?$AA@), (double)(*(float*)var3), (double)(*(float*)((byte*)var3 + 4)), (double)(*(float*)((byte*)var3 + 8)), (double)(*(float*)((byte*)var3 + 12)));
				string result3;
				try
				{
					uint num3 = (uint)(*(int*)ptr3);
					result3 = new string((sbyte*)((num3 == 0u) ? <Module>.?EmptyString@?$GBaseString@D@@1PBDB : num3));
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
				return result3;
			}
			}
			<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 981, (sbyte*)(&<Module>.??_C@_0CI@BCHGCKCL@NControls?3?3PropertyItemVector?3?3G@));
			<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BI@GEHCFIMB@Unsupported?5vector?5type?$AA@));
			return null;
		}

		protected unsafe override void SetValue(string value)
		{
			GBaseString<char> gBaseString<char>;
			<Module>.GBaseString<char>.{ctor}(ref gBaseString<char>, value);
			GTokenizer gTokenizer;
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
				<Module>.GTokenizer.{ctor}(ref gTokenizer, ptr, value.Length);
				try
				{
					<Module>.GTokenizer.ReadToken(ref gTokenizer);
					if (gTokenizer == 24)
					{
						goto IL_75;
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GTokenizer.{dtor}), (void*)(&gTokenizer));
					throw;
				}
				<Module>.GTokenizer.{dtor}(ref gTokenizer);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
				goto IL_3E6;
			}
			goto IL_3E6;
			IL_75:
			try
			{
				try
				{
					int num = *(int*)this.Type;
					int num2;
					if (num != 16 && num != 17)
					{
						if (num != 19 && num != 20)
						{
							if (num == 22)
							{
								num2 = 4;
								goto IL_BF;
							}
							<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 1002, (sbyte*)(&<Module>.??_C@_0CI@ODFKDJFG@NControls?3?3PropertyItemVector?3?3S@));
							<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BI@GEHCFIMB@Unsupported?5vector?5type?$AA@));
						}
						num2 = 3;
					}
					else
					{
						num2 = 2;
					}
					IL_BF:
					int num3 = 0;
					if (0 >= num2)
					{
						goto IL_200;
					}
					while (true)
					{
						if (num3 != 0)
						{
							<Module>.GTokenizer.ReadToken(ref gTokenizer);
							if (gTokenizer != 3)
							{
								break;
							}
						}
						<Module>.GTokenizer.ReadToken(ref gTokenizer);
						if (gTokenizer == 18)
						{
							<Module>.GTokenizer.ReadToken(ref gTokenizer);
							if (gTokenizer == 15)
							{
								$ArrayType$$$BY03M $ArrayType$$$BY03M;
								*(num3 * 4 + ref $ArrayType$$$BY03M) = (float)(-(float)(*(ref gTokenizer + 16)));
							}
							else
							{
								if (gTokenizer != 16)
								{
									goto Block_36;
								}
								$ArrayType$$$BY03M $ArrayType$$$BY03M;
								*(num3 * 4 + ref $ArrayType$$$BY03M) = (float)(-(float)(*(ref gTokenizer + 24)));
							}
						}
						else if (gTokenizer == 15)
						{
							$ArrayType$$$BY03M $ArrayType$$$BY03M;
							*(num3 * 4 + ref $ArrayType$$$BY03M) = (float)(*(ref gTokenizer + 16));
						}
						else
						{
							if (gTokenizer != 16)
							{
								goto Block_38;
							}
							$ArrayType$$$BY03M $ArrayType$$$BY03M;
							*(num3 * 4 + ref $ArrayType$$$BY03M) = (float)(*(ref gTokenizer + 24));
						}
						num3++;
						if (num3 >= num2)
						{
							goto Block_39;
						}
					}
					goto IL_17A;
					Block_36:
					goto IL_1A6;
					Block_38:
					goto IL_1D3;
					Block_39:
					goto IL_200;
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GTokenizer.{dtor}), (void*)(&gTokenizer));
					throw;
				}
				IL_17A:
				<Module>.GTokenizer.{dtor}(ref gTokenizer);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
				goto IL_3E6;
			}
			goto IL_3E6;
			IL_1A6:
			try
			{
				<Module>.GTokenizer.{dtor}(ref gTokenizer);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
				goto IL_3E6;
			}
			goto IL_3E6;
			IL_1D3:
			try
			{
				<Module>.GTokenizer.{dtor}(ref gTokenizer);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
				goto IL_3E6;
			}
			goto IL_3E6;
			IL_200:
			try
			{
				try
				{
					<Module>.GTokenizer.ReadToken(ref gTokenizer);
					if (gTokenizer == 25)
					{
						goto IL_24D;
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GTokenizer.{dtor}), (void*)(&gTokenizer));
					throw;
				}
				<Module>.GTokenizer.{dtor}(ref gTokenizer);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
				goto IL_3E6;
			}
			goto IL_3E6;
			IL_24D:
			try
			{
				try
				{
					<Module>.GTokenizer.ReadToken(ref gTokenizer);
					if (gTokenizer == null)
					{
						goto IL_298;
					}
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GTokenizer.{dtor}), (void*)(&gTokenizer));
					throw;
				}
				<Module>.GTokenizer.{dtor}(ref gTokenizer);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
				goto IL_3E6;
			}
			goto IL_3E6;
			IL_298:
			try
			{
				try
				{
					switch (*(int*)this.Type)
					{
					case 16:
					case 17:
					{
						$ArrayType$$$BY03M $ArrayType$$$BY03M;
						GVector2 gVector = $ArrayType$$$BY03M;
						*(ref gVector + 4) = *(ref $ArrayType$$$BY03M + 4);
						cpblk(this.Var, ref gVector, 8);
						break;
					}
					case 18:
						goto IL_3A7;
					case 19:
					case 20:
					{
						$ArrayType$$$BY03M $ArrayType$$$BY03M;
						GVector3 gVector2 = $ArrayType$$$BY03M;
						*(ref gVector2 + 4) = *(ref $ArrayType$$$BY03M + 4);
						*(ref gVector2 + 8) = *(ref $ArrayType$$$BY03M + 8);
						cpblk(this.Var, ref gVector2, 12);
						break;
					}
					case 21:
						goto IL_3A7;
					case 22:
					{
						$ArrayType$$$BY03M $ArrayType$$$BY03M;
						GColor gColor = $ArrayType$$$BY03M;
						*(ref gColor + 4) = *(ref $ArrayType$$$BY03M + 4);
						*(ref gColor + 8) = *(ref $ArrayType$$$BY03M + 8);
						*(ref gColor + 12) = *(ref $ArrayType$$$BY03M + 12);
						cpblk(this.Var, ref gColor, 16);
						break;
					}
					default:
						goto IL_3A7;
					}
					this.Host.RegenerateSubtree(this.Index);
					this.Host.RaiseItemChanged();
					this.Host.InvalidateViewControl();
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GTokenizer.{dtor}), (void*)(&gTokenizer));
					throw;
				}
				<Module>.GTokenizer.{dtor}(ref gTokenizer);
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			if (gBaseString<char> != null)
			{
				<Module>.free(gBaseString<char>);
				goto IL_3E6;
			}
			goto IL_3E6;
			IL_3A7:
			try
			{
				try
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 1058, (sbyte*)(&<Module>.??_C@_0CI@ODFKDJFG@NControls?3?3PropertyItemVector?3?3S@));
					<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0BI@GEHCFIMB@Unsupported?5vector?5type?$AA@));
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GTokenizer.{dtor}), (void*)(&gTokenizer));
					throw;
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
			IL_3E6:
			try
			{
				try
				{
				}
				catch
				{
					<Module>.___CxxCallUnwindDtor(ldftn(GTokenizer.{dtor}), (void*)(&gTokenizer));
					throw;
				}
			}
			catch
			{
				<Module>.___CxxCallUnwindDtor(ldftn(GBaseString<char>.{dtor}), (void*)(&gBaseString<char>));
				throw;
			}
		}

		protected void ComponentChanged()
		{
			this.EditControl.Text = this.GetValue();
			if (this.IsDefault())
			{
				this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Bold);
			}
			else
			{
				this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Regular);
			}
			this.Host.RaiseItemChanged();
		}

		public override void Refresh()
		{
			this.EditControl.Text = this.GetValue();
			if (this.IsDefault())
			{
				this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Bold);
			}
			else
			{
				this.EditControl.Font = new Font(this.EditControl.Font, FontStyle.Regular);
			}
			this.Host.RegenerateSubtree(this.Index);
			this.Host.RaiseItemChanged();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public override bool CanBeExpanded()
		{
			return true;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public override bool ShouldBeExpanded()
		{
			return false;
		}

		public unsafe override ArrayList Expand()
		{
			ArrayList arrayList = new ArrayList();
			float default_value = 0.33f;
			float min_value = -3.40282347E+38f;
			float max_value = 3.40282347E+38f;
			float step_value = 0.5f;
			float default_value2 = 0f;
			float min_value2 = 0f;
			float max_value2 = 1f;
			float step_value2 = 0.025f;
			switch (*(int*)this.Type)
			{
			case 16:
			case 17:
				arrayList.Add(PropertyItem.MakeProperty("X", null, &<Module>.?A0x25985e21.PropertyItem_Class_float, this.Var, default_value, min_value, max_value, step_value));
				arrayList.Add(PropertyItem.MakeProperty("Z", null, &<Module>.?A0x25985e21.PropertyItem_Class_float, (void*)((byte*)this.Var + 4), default_value, min_value, max_value, step_value));
				break;
			case 19:
			case 20:
				arrayList.Add(PropertyItem.MakeProperty("X", null, &<Module>.?A0x25985e21.PropertyItem_Class_float, this.Var, default_value, min_value, max_value, step_value));
				arrayList.Add(PropertyItem.MakeProperty("Y", null, &<Module>.?A0x25985e21.PropertyItem_Class_float, (void*)((byte*)this.Var + 4), default_value, min_value, max_value, step_value));
				arrayList.Add(PropertyItem.MakeProperty("Z", null, &<Module>.?A0x25985e21.PropertyItem_Class_float, (void*)((byte*)this.Var + 8), default_value, min_value, max_value, step_value));
				break;
			case 22:
				arrayList.Add(PropertyItem.MakeProperty("Red", (sbyte*)(&<Module>.??_C@_0O@NNKGIGDI@Red?5Component?$AA@), &<Module>.?A0x25985e21.PropertyItem_Class_float, this.Var, default_value2, min_value2, max_value2, step_value2));
				arrayList.Add(PropertyItem.MakeProperty("Green", (sbyte*)(&<Module>.??_C@_0BA@LJNHNHAN@Green?5Component?$AA@), &<Module>.?A0x25985e21.PropertyItem_Class_float, (void*)((byte*)this.Var + 4), default_value2, min_value2, max_value2, step_value2));
				arrayList.Add(PropertyItem.MakeProperty("Blue", (sbyte*)(&<Module>.??_C@_0P@PGFMMNHF@Blue?5Component?$AA@), &<Module>.?A0x25985e21.PropertyItem_Class_float, (void*)((byte*)this.Var + 8), default_value2, min_value2, max_value2, step_value2));
				arrayList.Add(PropertyItem.MakeProperty("Alpha", (sbyte*)(&<Module>.??_C@_0BA@JEPOJENN@Alpha?5Component?$AA@), &<Module>.?A0x25985e21.PropertyItem_Class_float, (void*)((byte*)this.Var + 12), default_value2, min_value2, max_value2, step_value2));
				break;
			}
			IEnumerator enumerator = arrayList.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					(enumerator.Current as PropertyItem).ItemChanged += new PropertyItem.__Delegate_ItemChanged(this.ComponentChanged);
				}
				while (enumerator.MoveNext());
			}
			return arrayList;
		}

		public unsafe override void UpdateControl(Rectangle bounds)
		{
			if (this.ColorButton != null)
			{
				Size sz = new Size(17, 16);
				Size size = bounds.Size;
				Point location = bounds.Location + size - sz;
				this.ColorButton.Location = location;
			}
			else if (*(int*)this.Type == 22)
			{
				this.ColorButton = new NImageButton();
				Size sz2 = new Size(17, 16);
				Size size2 = bounds.Size;
				Point location2 = bounds.Location + size2 - sz2;
				this.ColorButton.Location = location2;
				Size size3 = new Size(16, 16);
				this.ColorButton.Size = size3;
				this.ColorButton.TabIndex = 1;
				this.ColorButton.Image = ImageServer.GetImageServer("Images").GetImage("ColorPicker");
				this.Host.Controls.Add(this.ColorButton);
				this.ColorButton.Click += new EventHandler(this.ColorButton_Click);
			}
			base.UpdateControl(bounds);
		}

		public override void DestroyControl()
		{
			if (this.ColorButton != null)
			{
				this.ColorButton.Click -= new EventHandler(this.ColorButton_Click);
				this.Host.Controls.Remove(this.ColorButton);
				this.ColorButton = null;
			}
			base.DestroyControl();
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
