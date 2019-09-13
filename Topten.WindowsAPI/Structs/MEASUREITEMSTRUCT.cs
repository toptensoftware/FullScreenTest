using System;
using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MEASUREITEMSTRUCT
        {
            public uint CtlType;
            public uint CtlID;
            public uint itemID;
            public uint itemWidth;
            public uint itemHeight;
            public IntPtr itemData;
        };
    }

}
