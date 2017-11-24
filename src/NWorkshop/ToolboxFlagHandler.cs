using System;
using System.Runtime.InteropServices;

namespace NWorkshop
{
	internal delegate void ToolboxFlagHandler(FlagType flag, [MarshalAs(UnmanagedType.U1)] bool value);
}
