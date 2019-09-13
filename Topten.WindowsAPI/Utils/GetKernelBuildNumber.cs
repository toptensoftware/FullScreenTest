using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public static uint GetKernelBuildNumber()
        {
            // Get full path of kernel32.dll
            var sb = new StringBuilder(512);
            GetModuleFileName(GetModuleHandle("KERNEL32"), sb, sb.Capacity);

            VS_FIXEDFILEINFO info;
            GetModuleVersionInfo(sb.ToString(), out info);
            return (info.dwProductVersionLS >> 16) & 0xFFFF;
        }
    }
}
