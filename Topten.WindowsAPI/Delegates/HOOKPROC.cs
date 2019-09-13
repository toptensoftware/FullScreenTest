using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public delegate IntPtr HOOKPROC(int code, IntPtr wParam, IntPtr lParam);
    }
}
