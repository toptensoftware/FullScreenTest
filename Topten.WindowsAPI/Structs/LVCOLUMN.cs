using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct LVCOLUMN
        {
            public uint mask;
            public int fmt;
            public int cx;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pszText;
            public int cchTextMax;
            public int iSubItem;
            public int iImage;
            public int iOrder;
        }
    }

}
