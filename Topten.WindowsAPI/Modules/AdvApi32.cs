using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int RegOpenKeyEx(UIntPtr hKey, string subKey, int ulOptions, int samDesired, out UIntPtr hkResult);

        // Alternate definition - more correct
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern uint RegQueryValueEx(UIntPtr hKey, string lpValueName, int lpReserved, out int lpType, UIntPtr lpData, ref int lpcbData);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern int RegCloseKey(UIntPtr hKey);
    }
}
