using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NWorkshop
{
	internal class ShellMessageFilter : IMessageFilter
	{
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe override bool PreFilterMessage(ref Message m)
		{
			GBaseString<char> gBaseString<char> = 0;
			*(ref gBaseString<char> + 4) = 0;
			try
			{
				<Module>.GBaseString<char>.Format(ref gBaseString<char>, (sbyte*)(&<Module>.??_C@_0P@DFNMEEBH@Outer?5HWND?3?5?$CFd?$AA@), m.HWnd.ToInt32());
				<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), 5971, (sbyte*)(&<Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@));
				sbyte* ptr;
				if (gBaseString<char> != null)
				{
					ptr = gBaseString<char>;
				}
				else
				{
					ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB;
				}
				<Module>.GLogger.Log(1, ptr);
				if (m.Msg == 288)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), 5974, (sbyte*)(&<Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@));
					<Module>.GLogger.Log(1, (sbyte*)(&<Module>.??_C@_0P@LIJAPFGP@Outer?5Menuchar?$AA@));
				}
				if (m.Msg == 279)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), 5977, (sbyte*)(&<Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@));
					<Module>.GLogger.Log(1, (sbyte*)(&<Module>.??_C@_0BG@NLDNIMEG@Outer?5Init?5menu?5popup?$AA@));
				}
				if (m.Msg == 43)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), 5980, (sbyte*)(&<Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@));
					<Module>.GLogger.Log(1, (sbyte*)(&<Module>.??_C@_0P@ICCANDCE@Outer?5DrawItem?$AA@));
				}
				if (m.Msg == 44)
				{
					<Module>.GLogger.MarkLine((sbyte*)(&<Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), 5983, (sbyte*)(&<Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@));
					<Module>.GLogger.Log(1, (sbyte*)(&<Module>.??_C@_0O@ONOCNMLD@Outer?5Measure?$AA@));
				}
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
			return false;
		}
	}
}
