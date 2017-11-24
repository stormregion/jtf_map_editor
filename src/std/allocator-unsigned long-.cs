using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace std
{
	[DebugInfoInPDB, MiscellaneousBits(64), NativeCppClass]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct allocator<unsigned long>
	{
		[DebugInfoInPDB, MiscellaneousBits(65), CLSCompliant(false), NativeCppClass]
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct rebind<unsigned long>
		{
		}

		[DebugInfoInPDB, MiscellaneousBits(65), CLSCompliant(false), NativeCppClass]
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct rebind<std::_Tree_nod<std::_Tset_traits<unsigned long,std::less<unsigned long>,std::allocator<unsigned long>,0> >::_Node>
		{
		}

		[DebugInfoInPDB, MiscellaneousBits(65), CLSCompliant(false), NativeCppClass]
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct rebind<std::_Tree_nod<std::_Tset_traits<unsigned long,std::less<unsigned long>,std::allocator<unsigned long>,0> >::_Node *>
		{
		}

		[DebugInfoInPDB, MiscellaneousBits(65), CLSCompliant(false), NativeCppClass]
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct rebind<char>
		{
		}

		public unsafe static void <MarshalCopy>(allocator<unsigned long>* ptr, allocator<unsigned long>* ptr2)
		{
		}
	}
}
