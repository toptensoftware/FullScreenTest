using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        static bool? _IsPerMonitorV2Supported;
        public static bool IsPerMonitorV2Supported
        {
            get
            {
                if (!_IsPerMonitorV2Supported.HasValue)
                {
                    _IsPerMonitorV2Supported = IsApiAvailable("user32.dll", "SetThreadDpiAwarenessContext") && GetKernelBuildNumber() >= 15063;
                }
                return _IsPerMonitorV2Supported.Value;
            }
        }
    }
}
