using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint POINTER_FLAG_NONE = 0x00000000;
        public const uint POINTER_FLAG_NEW = 0x00000001;
        public const uint POINTER_FLAG_INRANGE = 0x00000002;
        public const uint POINTER_FLAG_INCONTACT = 0x00000004;
        public const uint POINTER_FLAG_FIRSTBUTTON = 0x00000010;
        public const uint POINTER_FLAG_SECONDBUTTON = 0x00000020;
        public const uint POINTER_FLAG_THIRDBUTTON = 0x00000040;
        public const uint POINTER_FLAG_OTHERBUTTON = 0x00000080;
        public const uint POINTER_FLAG_PRIMARY = 0x00000100;
        public const uint POINTER_FLAG_CONFIDENCE = 0x00000200;
        public const uint POINTER_FLAG_CANCELLED = 0x00000400;
        public const uint POINTER_FLAG_DOWN = 0x00010000;
        public const uint POINTER_FLAG_UPDATE = 0x00020000;
        public const uint POINTER_FLAG_UP = 0x00040000;
        public const uint POINTER_FLAG_WHEEL = 0x00080000;
        public const uint POINTER_FLAG_HWHEEL = 0x00100000;
    }
}
