using GRTTI;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NControls
{
	public class PropertyItemDArray : PropertyItemInteger
	{
		protected unsafe override long GetValue()
		{
			return (long)(*(int*)((byte*)this.Var + 4));
		}

		protected unsafe override void SetValue(long ival)
		{
			GArrayHeader* var = (GArrayHeader*)this.Var;
			int num = *(int*)(var + 4 / sizeof(GArrayHeader));
			long num2 = (long)num;
			if (num2 != ival)
			{
				if (num2 < ival)
				{
					if ((long)(*(int*)(var + 8 / sizeof(GArrayHeader))) < ival)
					{
						void* ptr = <Module>.realloc(*(int*)var, (uint)((int)((long)(*(int*)(this.Type + 48 / sizeof(GClass))) * ival)));
						*(int*)var = ptr;
						int num3 = *(int*)(this.Type + 48 / sizeof(GClass));
						int num4 = *(int*)(var + 8 / sizeof(GArrayHeader));
						initblk(num3 * num4 + (byte*)ptr, 0, (int)((ival - (long)num4) * (long)num3));
						*(int*)(var + 8 / sizeof(GArrayHeader)) = (int)ival;
					}
					*(int*)(var + 4 / sizeof(GArrayHeader)) = (int)ival;
				}
				else if (num2 > ival)
				{
					if (*(*(int*)(this.Type + 52 / sizeof(GClass)) + 40) != 0)
					{
						int num5 = num;
						if ((long)num5 < ival)
						{
							do
							{
								GClass* type = this.Type;
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), *(int*)(type + 48 / sizeof(GClass)) * num5 + *(int*)var, *(*(int*)(type + 52 / sizeof(GClass)) + 40));
								num5++;
							}
							while ((long)num5 < ival);
						}
					}
					long num6 = (long)(*(int*)(this.Type + 48 / sizeof(GClass)));
					initblk((int)(num6 * ival) + *(int*)var, 0, (int)(((long)(*(int*)(var + 4 / sizeof(GArrayHeader))) - ival) * num6));
					*(int*)(var + 4 / sizeof(GArrayHeader)) = (int)ival;
				}
				this.Host.RegenerateSubtree(this.Index);
				this.Host.RaiseItemChanged();
				this.Host.InvalidateViewControl();
			}
		}

		public PropertyItemDArray()
		{
			try
			{
				this.LowerBound = 0L;
				this.UpperBound = 255L;
				this.StepValue = 1L;
				this.DefaultValue = 0L;
			}
			catch
			{
				base.{dtor}();
				throw;
			}
		}

		public unsafe override void Refresh()
		{
			this.EditControl.Value = (long)(*(int*)((byte*)this.Var + 4));
			this.EditControl.RaiseValidate();
			this.Host.RegenerateSubtree(this.Index);
			this.Host.RaiseItemChanged();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public override bool IsDefault()
		{
			return false;
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe override bool CanBeExpanded()
		{
			return *(int*)((byte*)this.Var + 4) != 0;
		}

		public unsafe override ArrayList Expand()
		{
			ArrayList arrayList = new ArrayList();
			GArrayHeader* var = (GArrayHeader*)this.Var;
			float default_value = 0f;
			float min_value = -3.40282347E+38f;
			float max_value = 3.40282347E+38f;
			float step_value = 0.5f;
			int num = 0;
			int num2 = *(int*)(var + 4 / sizeof(GArrayHeader));
			if (0 < num2)
			{
				do
				{
					if (num2 > 10)
					{
						GBaseString<char> gBaseString<char>;
						GBaseString<char>* ptr = <Module>.Format(&gBaseString<char>, (sbyte*)(&<Module>.??_C@_04OGKJMPGK@?$CF02d?$AA@), num);
						try
						{
							uint num3 = (uint)(*(int*)ptr);
							sbyte* value;
							if (num3 != 0u)
							{
								value = num3;
							}
							else
							{
								value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							GClass* type = this.Type;
							arrayList.Add(PropertyItem.MakeProperty(new string((sbyte*)value), null, *(int*)(type + 52 / sizeof(GClass)), *(int*)(type + 48 / sizeof(GClass)) * num + *(int*)var, default_value, min_value, max_value, step_value));
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
						GBaseString<char> gBaseString<char>2;
						GBaseString<char>* ptr2 = <Module>.Format(&gBaseString<char>2, (sbyte*)(&<Module>.??_C@_02DPKJAMEF@?$CFd?$AA@), num);
						try
						{
							uint num4 = (uint)(*(int*)ptr2);
							sbyte* value2;
							if (num4 != 0u)
							{
								value2 = num4;
							}
							else
							{
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
							}
							GClass* type = this.Type;
							arrayList.Add(PropertyItem.MakeProperty(new string((sbyte*)value2), null, *(int*)(type + 52 / sizeof(GClass)), *(int*)(type + 48 / sizeof(GClass)) * num + *(int*)var, default_value, min_value, max_value, step_value));
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
					PropertyItem propertyItem = arrayList[num] as PropertyItem;
					MenuItem menuItem = new MenuItem("Insert");
					menuItem.Click += new EventHandler(propertyItem.OnInsert);
					propertyItem.InjectMenu(menuItem);
					MenuItem menuItem2 = new MenuItem("Move Up");
					menuItem2.Click += new EventHandler(propertyItem.OnMoveUp);
					propertyItem.InjectMenu(menuItem2);
					MenuItem menuItem3 = new MenuItem("Move Down");
					menuItem3.Click += new EventHandler(propertyItem.OnMoveDown);
					propertyItem.InjectMenu(menuItem3);
					MenuItem menuItem4 = new MenuItem("Remove");
					menuItem4.Click += new EventHandler(propertyItem.OnRemove);
					propertyItem.InjectMenu(menuItem4);
					propertyItem.ArrayIndex = num;
					propertyItem.Insert += new PropertyItem.ListOpHandler(this.InsertItem);
					propertyItem.Remove += new PropertyItem.ListOpHandler(this.RemoveItem);
					propertyItem.MoveUp += new PropertyItem.ListOpHandler(this.MoveItemUp);
					propertyItem.MoveDown += new PropertyItem.ListOpHandler(this.MoveItemDown);
					num++;
					num2 = *(int*)(var + 4 / sizeof(GArrayHeader));
				}
				while (num < num2);
			}
			return arrayList;
		}

		public override string GetName()
		{
			return this.Name + "[]";
		}

		public unsafe void InsertItem(int itemidx)
		{
			GArrayHeader* var = (GArrayHeader*)this.Var;
			int num = *(int*)(var + 4 / sizeof(GArrayHeader));
			if (itemidx < num && itemidx >= 0)
			{
				int num2 = num + 1;
				if (*(int*)(var + 8 / sizeof(GArrayHeader)) < num2)
				{
					GArrayHeader* expr_29 = var;
					*(int*)expr_29 = <Module>.realloc(*(int*)expr_29, (uint)(*(int*)(this.Type + 48 / sizeof(GClass)) * num2));
					*(int*)(var + 8 / sizeof(GArrayHeader)) = num2;
				}
				uint num3 = (uint)(*(int*)(this.Type + 48 / sizeof(GClass)));
				int num4 = *(int*)var;
				<Module>.memmove((itemidx + 1) * (int)num3 + num4, num3 * (uint)itemidx + (uint)num4, (uint)((*(int*)(var + 4 / sizeof(GArrayHeader)) - itemidx) * (int)num3));
				uint num5 = (uint)(*(int*)(this.Type + 48 / sizeof(GClass)));
				initblk(num5 * (uint)itemidx + (uint)(*(int*)var), 0, num5);
				*(int*)(var + 4 / sizeof(GArrayHeader)) = num2;
				this.EditControl.Value += 1L;
				this.EditControl.RaiseValidate();
				this.Host.RegenerateSubtree(this.Index);
				this.Host.RaiseItemChanged();
				this.Host.InvalidateViewControl();
			}
		}

		public unsafe void RemoveItem(int itemidx)
		{
			GArrayHeader* var = (GArrayHeader*)this.Var;
			if (itemidx < *(int*)(var + 4 / sizeof(GArrayHeader)) && itemidx >= 0)
			{
				GClass* type = this.Type;
				uint num = (uint)(*(*(int*)(type + 52 / sizeof(GClass)) + 40));
				if (num != 0u)
				{
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), *(int*)(type + 48 / sizeof(GClass)) * itemidx + *(int*)var, num);
				}
				int num2 = *(int*)(var + 4 / sizeof(GArrayHeader));
				if (itemidx != num2 - 1)
				{
					int num3 = *(int*)(this.Type + 48 / sizeof(GClass));
					int num4 = *(int*)var;
					<Module>.memmove(num3 * itemidx + num4, (itemidx + 1) * num3 + num4, (uint)((num2 - itemidx - 1) * num3));
				}
				int num5 = *(int*)(this.Type + 48 / sizeof(GClass));
				initblk((*(int*)(var + 4 / sizeof(GArrayHeader)) - 1) * num5 + *(int*)var, 0, num5);
				*(int*)(var + 4 / sizeof(GArrayHeader)) = *(int*)(var + 4 / sizeof(GArrayHeader)) + -1;
				this.EditControl.Value -= 1L;
				this.EditControl.RaiseValidate();
				this.Host.RegenerateSubtree(this.Index);
				this.Host.RaiseItemChanged();
				this.Host.InvalidateViewControl();
			}
		}

		public unsafe void MoveItemUp(int itemidx)
		{
			GArrayHeader* var = (GArrayHeader*)this.Var;
			if (itemidx < *(int*)(var + 4 / sizeof(GArrayHeader)) && itemidx > 0)
			{
				byte* ptr = <Module>.new[]((uint)(*(int*)(this.Type + 48 / sizeof(GClass))));
				uint num = (uint)(*(int*)(this.Type + 48 / sizeof(GClass)));
				cpblk(ptr, num * (uint)itemidx + (uint)(*(int*)var), num);
				uint num2 = (uint)(*(int*)(this.Type + 48 / sizeof(GClass)));
				int num3 = *(int*)var;
				cpblk(num2 * (uint)itemidx + (uint)num3, (itemidx - 1) * (int)num2 + num3, num2);
				uint num4 = (uint)(*(int*)(this.Type + 48 / sizeof(GClass)));
				cpblk((itemidx - 1) * (int)num4 + *(int*)var, ptr, num4);
				<Module>.delete((void*)ptr);
				this.Host.RegenerateSubtree(this.Index);
				this.Host.RaiseItemChanged();
				this.Host.InvalidateViewControl();
			}
		}

		public unsafe void MoveItemDown(int itemidx)
		{
			GArrayHeader* var = (GArrayHeader*)this.Var;
			if (itemidx < *(int*)(var + 4 / sizeof(GArrayHeader)) - 1 && itemidx >= 0)
			{
				byte* ptr = <Module>.new[]((uint)(*(int*)(this.Type + 48 / sizeof(GClass))));
				uint num = (uint)(*(int*)(this.Type + 48 / sizeof(GClass)));
				cpblk(ptr, num * (uint)itemidx + (uint)(*(int*)var), num);
				uint num2 = (uint)(*(int*)(this.Type + 48 / sizeof(GClass)));
				int num3 = *(int*)var;
				cpblk(num2 * (uint)itemidx + (uint)num3, (itemidx + 1) * (int)num2 + num3, num2);
				uint num4 = (uint)(*(int*)(this.Type + 48 / sizeof(GClass)));
				cpblk((itemidx + 1) * (int)num4 + *(int*)var, ptr, num4);
				<Module>.delete((void*)ptr);
				this.Host.RegenerateSubtree(this.Index);
				this.Host.RaiseItemChanged();
				this.Host.InvalidateViewControl();
			}
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
