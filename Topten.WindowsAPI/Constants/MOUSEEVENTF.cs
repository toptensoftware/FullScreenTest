using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint MOUSEEVENTF_MOVE = 0x00000001;
        public const uint MOUSEEVENTF_LEFTDOWN = 0x00000002;
        public const uint MOUSEEVENTF_LEFTUP = 0x00000004;
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x00000008;
        public const uint MOUSEEVENTF_MIDDLEDOWN = 0x00000020;
        public const uint MOUSEEVENTF_MIDDLEUP = 0x00000040;
        public const uint MOUSEEVENTF_ABSOLUTE = 0x00008000;
        public const uint MOUSEEVENTF_RIGHTUP = 0x00000010;
    }
}
