using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[DebugInfoInPDB, MiscellaneousBits(64), NativeCppClass]
[StructLayout(LayoutKind.Sequential, Size = 20)]
internal struct GHeap<GWUnit>
{
	[DebugInfoInPDB, MiscellaneousBits(65), NativeCppClass]
	[StructLayout(LayoutKind.Sequential, Size = 124)]
	internal struct GAtom
	{
	}
}
