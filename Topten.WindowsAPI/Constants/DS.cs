using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint DS_ABSALIGN = 0x01;
        public const uint DS_SYSMODAL = 0x02;
        public const uint DS_LOCALEDIT = 0x20;
        public const uint DS_SETFONT = 0x40;
        public const uint DS_MODALFRAME = 0x80;
        public const uint DS_NOIDLEMSG = 0x100;
        public const uint DS_SETFOREGROUND = 0x200;
        public const uint DS_3DLOOK = 0x0004;
        public const uint DS_FIXEDSYS = 0x0008;
        public const uint DS_NOFAILCREATE = 0x0010;
        public const uint DS_CONTROL = 0x0400;
        public const uint DS_CENTER = 0x0800;
        public const uint DS_CENTERMOUSE = 0x1000;
        public const uint DS_CONTEXTHELP = 0x2000;
        public const uint DS_SHELLFONT = (DS_SETFONT | DS_FIXEDSYS);
    }
}
