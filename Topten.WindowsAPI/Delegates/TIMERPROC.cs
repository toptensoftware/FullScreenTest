using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public delegate void TIMERPROC(IntPtr hWnd, uint uMsg, IntPtr nIDEvent, uint dwTime);
    }
}
