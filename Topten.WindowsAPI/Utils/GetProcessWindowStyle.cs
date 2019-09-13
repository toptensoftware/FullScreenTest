using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public static ProcessWindowStyle GetProcessWindowStyle()
        {
            STARTUPINFO si;
            si.cb = Marshal.SizeOf<STARTUPINFO>();
            GetStartupInfo(out si);

            if ((si.dwFlags & STARTF_USESHOWWINDOW) == 0)
                return ProcessWindowStyle.Normal;

            switch (si.wShowWindow)
            {
                case SW_HIDE: return ProcessWindowStyle.Hidden;
                case SW_SHOWNORMAL: return ProcessWindowStyle.Normal;
                case SW_MINIMIZE:
                case SW_FORCEMINIMIZE:
                case SW_SHOWMINNOACTIVE:
                case SW_SHOWMINIMIZED: return ProcessWindowStyle.Minimized;
                case SW_SHOWMAXIMIZED: return ProcessWindowStyle.Maximized;
                default: return ProcessWindowStyle.Normal;
            }
        }
    }
}
