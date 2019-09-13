using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint TOUCH_MASK_NONE = 0x00000000;
        public const uint TOUCH_MASK_CONTACTAREA = 0x00000001;
        public const uint TOUCH_MASK_ORIENTATION = 0x00000002;
        public const uint TOUCH_MASK_PRESSURE = 0x00000004;
    }
}
