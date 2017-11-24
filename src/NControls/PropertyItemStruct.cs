using GRTTI;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace NControls
{
	public class PropertyItemStruct : PropertyItem
	{
		public override void Refresh()
		{
			this.Host.RegenerateSubtree(this.Index);
			this.Host.RaiseItemChanged();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe override bool CanBeExpanded()
		{
			return *(*(int*)(this.Type + 8 / sizeof(GClass))) != 0;
		}

		public unsafe override ArrayList Expand()
		{
			ArrayList arrayList = new ArrayList();
			GMember* ptr = *(int*)(this.Type + 8 / sizeof(GClass));
			uint num = (uint)(*(int*)ptr);
			if (num != 0u)
			{
				do
				{
					arrayList.Add(PropertyItem.MakeProperty(new string(num), *(int*)(ptr + 12 / sizeof(GMember)), *(int*)(ptr + 4 / sizeof(GMember)), (void*)((byte*)this.Var + *(int*)(ptr + 8 / sizeof(GMember))), *(int*)(ptr + 16 / sizeof(GMember)), *(int*)(ptr + 20 / sizeof(GMember)), *(int*)(ptr + 24 / sizeof(GMember)), *(int*)(ptr + 28 / sizeof(GMember))));
					ptr += 32 / sizeof(GMember);
					num = (uint)(*(int*)ptr);
				}
				while (num != 0u);
			}
			return arrayList;
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
