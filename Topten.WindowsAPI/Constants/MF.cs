using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint MF_BYCOMMAND = 0x00000000;
        public const uint MF_BYPOSITION = 0x00000400;
        public const uint MF_SEPARATOR = 0x00000800;
        public const uint MF_ENABLED = 0x00000000;
        public const uint MF_GRAYED = 0x00000001;
        public const uint MF_DISABLED = 0x00000002;
        public const uint MF_UNCHECKED = 0x00000000;
        public const uint MF_CHECKED = 0x00000008;
        public const uint MF_USECHECKBITMAPS = 0x00000200;
        public const uint MF_STRING = 0x00000000;
        public const uint MF_BITMAP = 0x00000004;
        public const uint MF_OWNERDRAW = 0x00000100;
        public const uint MF_POPUP = 0x00000010;
        public const uint MF_MENUBARBREAK = 0x00000020;
        public const uint MF_MENUBREAK = 0x00000040;
        public const uint MF_UNHILITE = 0x00000000;
        public const uint MF_HILITE = 0x00000080;
    }
}
