using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public static bool IsApiAvailable(string module, string function)
        {
            var lib = LoadLibrary(module);
            if (lib == IntPtr.Zero)
                return false;

            var proc = GetProcAddress(lib, function);
            FreeLibrary(lib);

            return proc != IntPtr.Zero;
        }
    }
}
