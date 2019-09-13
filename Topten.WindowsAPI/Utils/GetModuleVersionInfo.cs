using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public static bool GetModuleVersionInfo(string moduleName, out VS_FIXEDFILEINFO info)
        {
            info = new VS_FIXEDFILEINFO();

            // Get verion info size
            uint dwHandle;
            uint cbVerInfo = GetFileVersionInfoSize(moduleName, out dwHandle);
            if (cbVerInfo == 0)
                return false;

            // Allocate buffer for version info
            var verInfo = new byte[cbVerInfo];
            unsafe
            {
                fixed (byte* pVerInfo = verInfo)
                {
                    // Get version info
                    if (!GetFileVersionInfo(moduleName, dwHandle, cbVerInfo, (IntPtr)pVerInfo))
                        return false;

                    // Find fixed file info
                    IntPtr pInfo;
                    uint cbLen;
                    if (!VerQueryValue((IntPtr)pVerInfo, "\\", out pInfo, out cbLen))
                        return false;

                    // Check correct length
                    if (cbLen < Marshal.SizeOf<VS_FIXEDFILEINFO>())
                        return false;

                    // Return it
                    info = Marshal.PtrToStructure<VS_FIXEDFILEINFO>(pInfo);

                    return true;
                }
            }
        }
    }
}
