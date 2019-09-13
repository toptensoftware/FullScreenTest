using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint SIF_RANGE = 0x0001;
        public const uint SIF_PAGE = 0x0002;
        public const uint SIF_POS = 0x0004;
        public const uint SIF_DISABLENOSCROLL = 0x0008;
        public const uint SIF_TRACKPOS = 0x0010;
        public const uint SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS);
    }
}
