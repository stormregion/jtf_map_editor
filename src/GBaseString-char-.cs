using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[DebugInfoInPDB, MiscellaneousBits(64), NativeCppClass]
[StructLayout(LayoutKind.Sequential, Size = 8)]
internal struct GBaseString<char>
{
	public unsafe static void <MarshalCopy>(GBaseString<char>* ptr, GBaseString<char>* ptr2)
	{
		int num = *(int*)(ptr2 + 4 / sizeof(GBaseString<char>));
		if (num != 0)
		{
			*(int*)(ptr + 4 / sizeof(GBaseString<char>)) = num;
			void* ptr3 = <Module>.malloc((uint)(num + 1));
			*(int*)ptr = ptr3;
			cpblk(ptr3, *(int*)ptr2, *(int*)(ptr + 4 / sizeof(GBaseString<char>)) + 1);
		}
		else
		{
			*(int*)(ptr + 4 / sizeof(GBaseString<char>)) = 0;
			*(int*)ptr = 0;
		}
	}

	public unsafe static void <MarshalDestroy>(GBaseString<char>* ptr)
	{
		uint num = (uint)(*(int*)ptr);
		if (num != 0u)
		{
			<Module>.free(num);
			*(int*)ptr = 0;
		}
	}
}
