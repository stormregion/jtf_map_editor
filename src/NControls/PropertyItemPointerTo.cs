using GRTTI;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace NControls
{
	public class PropertyItemPointerTo : PropertyItemEnum
	{
		protected unsafe override void GetItems()
		{
			this.dropList.Items.Add("Disabled");
			uint num = (uint)(*(*(int*)(this.Type + 52 / sizeof(GClass)) + 16));
			if (num != 0u)
			{
				int num2 = 0;
				if (*num != 0)
				{
					int num3 = (int)num;
					do
					{
						this.dropList.Items.Add(new string(*(*num3 + 4)));
						num2++;
						num3 = num2 * 4 + *(*(int*)(this.Type + 52 / sizeof(GClass)) + 16);
					}
					while (*num3 != 0);
				}
			}
			else
			{
				this.dropList.Items.Add("Enabled");
			}
			void* var = this.Var;
			if (*(int*)var != 0)
			{
				int num4 = *(int*)(this.Type + 52 / sizeof(GClass));
				if (*(num4 + 16) != 0)
				{
					sbyte* ptr = calli(System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), *(int*)var, *(num4 + 20));
					if (<Module>.strncmp(ptr, (sbyte*)(&<Module>.??_C@_07DIBCDNGL@struct?5?$AA@), 7u) == null)
					{
						ptr += 7 / sizeof(sbyte);
					}
					else
					{
						if (<Module>.strncmp(ptr, (sbyte*)(&<Module>.??_C@_06LJBABKPM@class?5?$AA@), 6u) != null)
						{
							<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 1777, (sbyte*)(&<Module>.??_C@_0CL@LBKEDLGC@NControls?3?3PropertyItemPointerTo@));
							<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0CJ@CFPHDAMK@The?5type?5?8?$CFs?8?5is?5not?5a?5struct?5or@), ptr);
							goto IL_1B1;
						}
						ptr += 6 / sizeof(sbyte);
					}
					int num5 = 0;
					num = (uint)(*(*(int*)(this.Type + 52 / sizeof(GClass)) + 16));
					if (*num != 0)
					{
						sbyte b = *(sbyte*)ptr;
						int num6 = (int)num;
						do
						{
							sbyte* ptr2 = ptr;
							int num7 = *(*num6 + 4);
							sbyte b2 = *num7;
							sbyte b3 = b;
							if (b2 >= b3)
							{
								sbyte* ptr3 = num7 - ptr;
								while (b2 <= b3)
								{
									if (b2 == 0)
									{
										goto IL_14E;
									}
									ptr2 += 1 / sizeof(sbyte);
									b2 = *(sbyte*)(ptr3 + ptr2 / sizeof(sbyte));
									b3 = *(sbyte*)ptr2;
									if (b2 < b3)
									{
										break;
									}
								}
							}
							num5++;
							num6 = num5 * 4 + (int)num;
						}
						while (*num6 != 0);
					}
					IL_14E:
					if (*(num5 * 4 + (int)num) == 0)
					{
						<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 1785, (sbyte*)(&<Module>.??_C@_0CL@LBKEDLGC@NControls?3?3PropertyItemPointerTo@));
						<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0CK@DEIACGDP@The?5type?5?8?$CFs?8?5is?5not?5a?5descenden@), ptr, *(*(int*)(this.Type + 52 / sizeof(GClass)) + 4));
					}
					this.dropList.SelectedIndex = num5 + 1;
					return;
				}
				IL_1B1:
				this.dropList.SelectedIndex = 1;
			}
			else
			{
				this.dropList.SelectedIndex = 0;
			}
		}

		protected unsafe override void SelectItem(int index)
		{
			void* var = this.Var;
			void** ptr = var;
			if (index == 0)
			{
				uint num = (uint)(*ptr);
				if (num == 0u)
				{
					return;
				}
				uint num2 = (uint)(*(*(int*)(this.Type + 52 / sizeof(GClass)) + 32));
				if (num2 != 0u)
				{
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), num, num2);
				}
				else
				{
					<Module>.free(num);
				}
				*ptr = 0;
			}
			else
			{
				GClass* type = this.Type;
				int num3 = *(int*)(type + 52 / sizeof(GClass));
				if (*(num3 + 16) != 0)
				{
					GStreamBuffer* ptr2 = null;
					if (*ptr != 0)
					{
						sbyte* ptr3 = calli(System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), *(int*)var, *(num3 + 20));
						if (<Module>.strncmp(ptr3, (sbyte*)(&<Module>.??_C@_07DIBCDNGL@struct?5?$AA@), 7u) == null)
						{
							ptr3 += 7 / sizeof(sbyte);
						}
						else
						{
							if (<Module>.strncmp(ptr3, (sbyte*)(&<Module>.??_C@_06LJBABKPM@class?5?$AA@), 6u) != null)
							{
								<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 1834, (sbyte*)(&<Module>.??_C@_0CN@BMAEKPLO@NControls?3?3PropertyItemPointerTo@));
								<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0CJ@CFPHDAMK@The?5type?5?8?$CFs?8?5is?5not?5a?5struct?5or@), ptr3);
								goto IL_1E5;
							}
							ptr3 += 6 / sizeof(sbyte);
						}
						int num4 = 0;
						uint num5 = (uint)(*(*(int*)(this.Type + 52 / sizeof(GClass)) + 16));
						if (*num5 != 0)
						{
							sbyte b = *(sbyte*)ptr3;
							int num6 = (int)num5;
							do
							{
								sbyte* ptr4 = ptr3;
								int num7 = *(*num6 + 4);
								sbyte b2 = *num7;
								sbyte b3 = b;
								if (b2 >= b3)
								{
									sbyte* ptr5 = num7 - ptr3;
									while (b2 <= b3)
									{
										if (b2 == 0)
										{
											goto IL_114;
										}
										ptr4 += 1 / sizeof(sbyte);
										b2 = *(sbyte*)(ptr5 + ptr4 / sizeof(sbyte));
										b3 = *(sbyte*)ptr4;
										if (b2 < b3)
										{
											break;
										}
									}
								}
								num4++;
								num6 = num4 * 4 + (int)num5;
							}
							while (*num6 != 0);
						}
						IL_114:
						if (*(num4 * 4 + (int)num5) == 0)
						{
							<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 1842, (sbyte*)(&<Module>.??_C@_0CN@BMAEKPLO@NControls?3?3PropertyItemPointerTo@));
							<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0CK@DEIACGDP@The?5type?5?8?$CFs?8?5is?5not?5a?5descenden@), ptr3, *(*(int*)(this.Type + 52 / sizeof(GClass)) + 4));
						}
						if (num4 != index - 1)
						{
							GStreamBuffer* ptr6 = <Module>.@new(36u);
							GStreamBuffer* ptr7;
							try
							{
								if (ptr6 != null)
								{
									ptr7 = <Module>.GStreamBuffer.{ctor}(ptr6);
								}
								else
								{
									ptr7 = 0;
								}
							}
							catch
							{
								<Module>.delete((void*)ptr6);
								throw;
							}
							ptr2 = ptr7;
							<Module>.GRTTI.SaveVariablesAsText(ptr7, *(int*)(this.Type + 52 / sizeof(GClass)), *ptr, this.Host.Measures);
							uint num8 = (uint)(*(*(int*)(this.Type + 52 / sizeof(GClass)) + 32));
							if (num8 != 0u)
							{
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), *ptr, num8);
							}
							else
							{
								<Module>.free(*ptr);
							}
							*ptr = 0;
							goto IL_1EC;
						}
						IL_1E5:
						if (*ptr != 0)
						{
							return;
						}
					}
					IL_1EC:
					int num9 = *(index * 4 + *(*(int*)(this.Type + 52 / sizeof(GClass)) + 16) - 4);
					uint num10 = (uint)(*(num9 + 28));
					if (num10 != 0u)
					{
						*ptr = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvCdecl)(), num10);
					}
					else
					{
						void* ptr8 = <Module>.malloc((uint)(*(num9 + 48)));
						*ptr = ptr8;
						initblk(ptr8, 0, *(*(index * 4 + *(*(int*)(this.Type + 52 / sizeof(GClass)) + 16) - 4) + 48));
					}
					if (ptr2 != null)
					{
						<Module>.GStream.Reset(ptr2);
						<Module>.GRTTI.LoadVariablesAsText((GStream*)ptr2, *(int*)(this.Type + 52 / sizeof(GClass)), *ptr, this.Host.Measures);
						object arg_27A_0 = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, *(*(int*)ptr2));
					}
				}
				else
				{
					if (*ptr != 0)
					{
						return;
					}
					uint num11 = (uint)(*(num3 + 28));
					if (num11 != 0u)
					{
						*ptr = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvCdecl)(), num11);
					}
					else
					{
						void* ptr9 = <Module>.malloc((uint)(*(int*)(type + 48 / sizeof(GClass))));
						*ptr = ptr9;
						initblk(ptr9, 0, *(int*)(this.Type + 48 / sizeof(GClass)));
					}
				}
			}
			this.Host.RegenerateSubtree(this.Index);
			this.Host.RaiseItemChanged();
			this.Host.InvalidateViewControl();
		}

		public unsafe override void Refresh()
		{
			void* ptr = *(int*)this.Var;
			if (ptr != null)
			{
				int num = *(int*)(this.Type + 52 / sizeof(GClass));
				if (*(num + 16) != 0)
				{
					sbyte* ptr2 = calli(System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), ptr, *(num + 20));
					if (<Module>.strncmp(ptr2, (sbyte*)(&<Module>.??_C@_07DIBCDNGL@struct?5?$AA@), 7u) == null)
					{
						ptr2 += 7 / sizeof(sbyte);
					}
					else
					{
						if (<Module>.strncmp(ptr2, (sbyte*)(&<Module>.??_C@_06LJBABKPM@class?5?$AA@), 6u) != null)
						{
							<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 1727, (sbyte*)(&<Module>.??_C@_0CK@EHBDGIII@NControls?3?3PropertyItemPointerTo@));
							<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0CJ@CFPHDAMK@The?5type?5?8?$CFs?8?5is?5not?5a?5struct?5or@), ptr2);
							goto IL_12A;
						}
						ptr2 += 6 / sizeof(sbyte);
					}
					int num2 = 0;
					uint num3 = (uint)(*(*(int*)(this.Type + 52 / sizeof(GClass)) + 16));
					if (*num3 != 0)
					{
						sbyte b = *(sbyte*)ptr2;
						int num4 = (int)num3;
						do
						{
							sbyte* ptr3 = ptr2;
							int num5 = *(*num4 + 4);
							sbyte b2 = *num5;
							sbyte b3 = b;
							if (b2 >= b3)
							{
								sbyte* ptr4 = num5 - ptr2;
								while (b2 <= b3)
								{
									if (b2 == 0)
									{
										goto IL_C6;
									}
									ptr3 += 1 / sizeof(sbyte);
									b2 = *(sbyte*)(ptr4 + ptr3 / sizeof(sbyte));
									b3 = *(sbyte*)ptr3;
									if (b2 < b3)
									{
										break;
									}
								}
							}
							num2++;
							num4 = num2 * 4 + (int)num3;
						}
						while (*num4 != 0);
					}
					IL_C6:
					if (*(num2 * 4 + (int)num3) == 0)
					{
						<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), 1735, (sbyte*)(&<Module>.??_C@_0CK@EHBDGIII@NControls?3?3PropertyItemPointerTo@));
						<Module>.GLogger.Panic((sbyte*)(&<Module>.??_C@_0CK@DEIACGDP@The?5type?5?8?$CFs?8?5is?5not?5a?5descenden@), ptr2, *(*(int*)(this.Type + 52 / sizeof(GClass)) + 4));
					}
					this.dropList.SelectedIndex = num2 + 1;
					goto IL_144;
				}
				IL_12A:
				this.dropList.SelectedIndex = 1;
			}
			else
			{
				this.dropList.SelectedIndex = 0;
			}
			IL_144:
			this.Host.RegenerateSubtree(this.Index);
			this.Host.RaiseItemChanged();
		}

		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe override bool CanBeExpanded()
		{
			return ((*(int*)this.Var != 0) ? 1 : 0) != 0;
		}

		public unsafe override ArrayList Expand()
		{
			ArrayList arrayList = new ArrayList();
			void* ptr = *(int*)this.Var;
			int num = *(int*)(this.Type + 52 / sizeof(GClass));
			uint num2 = (uint)(*(num + 16));
			GMember* ptr2 = *(((num2 == 0u) ? num : (*(this.dropList.SelectedIndex * 4 + (int)num2 - 4))) + 8);
			uint num3 = (uint)(*(int*)ptr2);
			if (num3 != 0u)
			{
				do
				{
					arrayList.Add(PropertyItem.MakeProperty(new string(num3), *(int*)(ptr2 + 12 / sizeof(GMember)), *(int*)(ptr2 + 4 / sizeof(GMember)), (void*)(*(int*)(ptr2 + 8 / sizeof(GMember)) + (byte*)ptr), *(int*)(ptr2 + 16 / sizeof(GMember)), *(int*)(ptr2 + 20 / sizeof(GMember)), *(int*)(ptr2 + 24 / sizeof(GMember)), *(int*)(ptr2 + 28 / sizeof(GMember))));
					ptr2 += 32 / sizeof(GMember);
					num3 = (uint)(*(int*)ptr2);
				}
				while (num3 != 0u);
			}
			return arrayList;
		}

		public override void SetDefault()
		{
			this.dropList.SetSelection(0);
		}

		public new void {dtor}()
		{
			GC.SuppressFinalize(this);
			this.Finalize();
		}
	}
}
