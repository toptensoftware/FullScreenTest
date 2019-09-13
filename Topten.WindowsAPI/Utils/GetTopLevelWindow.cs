using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public static IntPtr GetTopLevelWindow(IntPtr hWnd)
        {
            while (hWnd != IntPtr.Zero && (GetWindowLong(hWnd, GWL_STYLE) & WS_CHILD) != 0)
            {
                hWnd = GetParent(hWnd);
            }
            return hWnd;
        }
    }
}
