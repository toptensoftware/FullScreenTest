using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("comctl32.dll", EntryPoint = "InitCommonControlsEx", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InitCommonControlsEx(ref INITCOMMONCONTROLSEX iccex);

        [DllImport("comctl32.dll", SetLastError = true)]
        public static extern IntPtr ImageList_Create(int cx, int cy, uint flags, int cInitial, int cGrow);

        [DllImport("comctl32.dll", SetLastError = true)]
        public static extern int ImageList_Add(IntPtr hImageList, IntPtr hBitmap, IntPtr hMask);

        [DllImport("Comctl32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ImageList_Destroy(IntPtr himl);
    }
}
