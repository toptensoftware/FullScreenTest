using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public enum Version
        {
            WindowsXPOrEarlier,
            WindowsVista,
            Windows7,
            Windows8,
            Windows10,
            Windows10Creators,
            Windows10FallCreatorsOrLater,
        }

        static Version? _windowsVersion;

        public static Version WindowsVersion
        {
            get
            {
                if (!_windowsVersion.HasValue)
                {
                    var build = Environment.OSVersion.Version.Build;
                    if (build < 5112)
                        _windowsVersion = Version.WindowsXPOrEarlier;
                    else if (build < 7600)
                        _windowsVersion = Version.WindowsVista;
                    else if (build < 9200)
                        _windowsVersion = Version.Windows7;
                    else if (build < 10240)
                        _windowsVersion = Version.Windows8;
                    else if (build < 15063)
                        _windowsVersion = Version.Windows10;
                    else if (build < 16299)
                        _windowsVersion = Version.Windows10Creators;
                    else
                        _windowsVersion = Version.Windows10FallCreatorsOrLater;
                }

                return _windowsVersion.Value;
            }
        }
    }
}
