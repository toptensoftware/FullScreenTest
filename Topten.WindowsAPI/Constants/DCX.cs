using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint DCX_WINDOW = 0x00000001;
        public const uint DCX_CACHE = 0x00000002;
        public const uint DCX_NORESETATTRS = 0x00000004;
        public const uint DCX_CLIPCHILDREN = 0x00000008;
        public const uint DCX_CLIPSIBLINGS = 0x00000010;
        public const uint DCX_PARENTCLIP = 0x00000020;
        public const uint DCX_EXCLUDERGN = 0x00000040;
        public const uint DCX_INTERSECTRGN = 0x00000080;
        public const uint DCX_EXCLUDEUPDATE = 0x00000100;
        public const uint DCX_INTERSECTUPDATE = 0x00000200;
        public const uint DCX_LOCKWINDOWUPDATE = 0x00000400;
        public const uint DCX_VALIDATE = 0x00200000;
    }
}
