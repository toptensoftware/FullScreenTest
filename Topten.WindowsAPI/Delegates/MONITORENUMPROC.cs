using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public delegate bool MONITORENUMPROC(IntPtr hMonitor, IntPtr hdcMonitor, IntPtr prcMonitor, IntPtr dwData);
    }
}
