using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern int DragQueryFile(IntPtr hDrop, int iFile, [Out] StringBuilder lpszFile, int cch);
    }
}
