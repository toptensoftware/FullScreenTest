using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint DROPEFFECT_NONE = 0x00000000;
        public const uint DROPEFFECT_COPY = 0x00000001;
        public const uint DROPEFFECT_MOVE = 0x00000002;
        public const uint DROPEFFECT_LINK = 0x00000004;
        public const uint DROPEFFECT_SCROLL = 0x80000000;
    }
}
