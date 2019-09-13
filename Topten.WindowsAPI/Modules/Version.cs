using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("version.dll")]
        public static extern uint GetFileVersionInfoSize(string filename, out uint dwHandle);

        [DllImport("version.dll")]
        public static extern bool GetFileVersionInfo(string filename, uint dwHandle, uint dwLen, IntPtr buffer);

        [DllImport("version.dll")]
        public static extern bool VerQueryValue(IntPtr pBlock, string subBlock, out IntPtr ptr, out uint len);
    }
}
