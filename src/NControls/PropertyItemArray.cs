using GRTTI;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace NControls
{
	public class PropertyItemArray : PropertyItem
	{
		public override void Refresh()
		{
			this.Host.RegenerateSubtree(this.Index);
			this.Host.RaiseItemChanged();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe override bool CanBeExpanded()
		{
			return *(int*)(this.Type + 44 / sizeof(GClass)) != 0;
		}

		public unsafe override ArrayList Expand()
		{
			ArrayList arrayList = new ArrayList();
			float default_value = 0f;
			float min_value = -3.40282347E+38f;
			float max_value = 3.40282347E+38f;
			float step_value = 0.5f;
			int num = 0;
			int num2 = *(int*)(this.Type + 44 / sizeof(GClass));
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
							arrayList.Add(PropertyItem.MakeProperty(new string((sbyte*)value), null, *(int*)(type + 52 / sizeof(GClass)), (void*)(*(int*)(type + 48 / sizeof(GClass)) * num + (byte*)this.Var), default_value, min_value, max_value, step_value));
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
							arrayList.Add(PropertyItem.MakeProperty(new string((sbyte*)value2), null, *(int*)(type + 52 / sizeof(GClass)), (void*)(*(int*)(type + 48 / sizeof(GClass)) * num + (byte*)this.Var), default_value, min_value, max_value, step_value));
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
					num++;
					num2 = *(int*)(this.Type + 44 / sizeof(GClass));
				}
				while (num < num2);
			}
			return arrayList;
		}

		public unsafe override string GetName()
		{
			GBaseString<char> gBaseString<char>;
			GBaseString<char>* ptr = <Module>.Format(&gBaseString<char>, (sbyte*)(&<Module>.??_C@_04KBDJOJNB@?$FL?$CFd?$FN?$AA@), *(int*)(this.Type + 44 / sizeof(GClass)));
			string result;
			try
			{
				uint num = (uint)(*(int*)ptr);
				sbyte* value;
				if (num != 0u)
				{
					value = num;
				}
				else
				{
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				result = this.Name + new string((sbyte*)value);
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

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
