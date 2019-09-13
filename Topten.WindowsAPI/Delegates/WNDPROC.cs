using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public delegate IntPtr WNDPROC(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam);
    }
}
