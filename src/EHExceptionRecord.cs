using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[DebugInfoInPDB, MiscellaneousBits(65), NativeCppClass]
[StructLayout(LayoutKind.Sequential, Size = 32)]
internal struct EHExceptionRecord
{
	[DebugInfoInPDB, MiscellaneousBits(65), CLSCompliant(false), NativeCppClass]
	[StructLayout(LayoutKind.Sequential, Size = 12)]
	public struct EHParameters
	{
	}
}
