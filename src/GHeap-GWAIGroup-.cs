using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[DebugInfoInPDB, MiscellaneousBits(64), NativeCppClass]
[StructLayout(LayoutKind.Sequential, Size = 20)]
internal struct GHeap<GWAIGroup>
{
	[DebugInfoInPDB, MiscellaneousBits(65), NativeCppClass, UnsafeValueType]
	[StructLayout(LayoutKind.Sequential, Size = 392)]
	internal struct GAtom
	{
	}
}
