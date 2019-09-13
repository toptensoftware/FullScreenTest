using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("shcore.dll")]
        public static extern uint GetDpiForMonitor(IntPtr hMonitor, int type, out int dpiX, out int dpiY);
    }
}
