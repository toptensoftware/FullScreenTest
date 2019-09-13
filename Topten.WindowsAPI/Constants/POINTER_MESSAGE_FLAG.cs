using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint POINTER_MESSAGE_FLAG_NEW = 0x00000001;
        public const uint POINTER_MESSAGE_FLAG_INRANGE = 0x00000002;
        public const uint POINTER_MESSAGE_FLAG_INCONTACT = 0x00000004;
        public const uint POINTER_MESSAGE_FLAG_FIRSTBUTTON = 0x00000010;
        public const uint POINTER_MESSAGE_FLAG_SECONDBUTTON = 0x00000020;
        public const uint POINTER_MESSAGE_FLAG_THIRDBUTTON = 0x00000040;
        public const uint POINTER_MESSAGE_FLAG_FOURTHBUTTON = 0x00000080;
        public const uint POINTER_MESSAGE_FLAG_FIFTHBUTTON = 0x00000100;
        public const uint POINTER_MESSAGE_FLAG_PRIMARY = 0x00002000;
        public const uint POINTER_MESSAGE_FLAG_CONFIDENCE = 0x00004000;
        public const uint POINTER_MESSAGE_FLAG_CANCELED = 0x00008000;
    }
}
