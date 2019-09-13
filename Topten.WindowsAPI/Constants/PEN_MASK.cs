﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint PEN_MASK_NONE = 0x00000000;
        public const uint PEN_MASK_PRESSURE = 0x00000001;
        public const uint PEN_MASK_ROTATION = 0x00000002;
        public const uint PEN_MASK_TILT_X = 0x00000004;
        public const uint PEN_MASK_TILT_Y = 0x00000008;
    }
}
