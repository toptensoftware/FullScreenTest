using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("winmm.dll")]
        public static extern uint timeBeginPeriod(uint uPeriod);
    }
}
