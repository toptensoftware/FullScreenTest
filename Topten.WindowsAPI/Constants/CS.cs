using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint CS_VREDRAW = 0x00000001;
        public const uint CS_HREDRAW = 0x00000002;
        public const uint CS_DBLCLKS = 0x00000008;
        public const uint CS_OWNDC = 0x00000020;
        public const uint CS_CLASSDC = 0x00000040;
        public const uint CS_PARENTDC = 0x00000080;
        public const uint CS_NOCLOSE = 0x00000200;
        public const uint CS_SAVEBITS = 0x00000800;
        public const uint CS_BYTEALIGNCLIENT = 0x00001000;
        public const uint CS_BYTEALIGNWINDOW = 0x00002000;
        public const uint CS_GLOBALCLASS = 0x00004000;
        public const uint CS_IME = 0x00010000;
        public const uint CS_DROPSHADOW = 0x00020000;
    }
}
