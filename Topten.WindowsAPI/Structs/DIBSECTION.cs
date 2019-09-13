using System;
using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DIBSECTION
        {
            public BITMAP dsBm;
            public BITMAPINFOHEADER dsBmih;
            public uint dsBitFields0;
            public uint dsBitFields1;
            public uint dsBitFields2;
            public IntPtr dshSection;
            public uint dsOffset;
        }
    }

}
