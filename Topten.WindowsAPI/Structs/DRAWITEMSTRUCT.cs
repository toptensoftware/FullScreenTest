using System;
using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct DRAWITEMSTRUCT
        {
            public uint CtlType;
            public uint CtlID;
            public uint itemID;
            public uint itemAction;
            public uint itemState;
            public IntPtr hwndItem;
            public IntPtr hDC;
            public RECT rcItem;
            public IntPtr itemData;
        };
    }

}
