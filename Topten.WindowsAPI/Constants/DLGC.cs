using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint DLGC_WANTARROWS = 0x0001;
        public const uint DLGC_WANTTAB = 0x0002;
        public const uint DLGC_WANTALLKEYS = 0x0004;
        public const uint DLGC_WANTMESSAGE = 0x0004;
        public const uint DLGC_HASSETSEL = 0x0008; 
        public const uint DLGC_DEFPUSHBUTTON = 0x0010;
        public const uint DLGC_UNDEFPUSHBUTTON = 0x0020;
        public const uint DLGC_RADIOBUTTON = 0x0040;
        public const uint DLGC_WANTCHARS = 0x0080;
        public const uint DLGC_STATIC = 0x0100;
        public const uint DLGC_BUTTON = 0x2000;
    }
}
