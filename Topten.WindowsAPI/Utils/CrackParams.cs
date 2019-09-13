using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public static int GetPointerId(IntPtr wParam)
        {
            return (int)(wParam.ToInt64() & 0x0000FFFF);
        }

        public static uint GetPointerFlags(IntPtr wParam)
        {
            return (uint)((wParam.ToInt64() >> 16) & 0x0000FFFF);
        }

        public static POINT PointFromLParam(IntPtr lParam)
        {
            uint lp = (uint)lParam.ToInt64();
            return new POINT((int)(short)(lp & 0xFFFF), (int)(short)(lp >> 16));
        }

        public static int WheelDeltaFromWParam(IntPtr wParam)
        {
            return ((short)((wParam.ToInt64() & 0xFFFFFFFF) >> 16));
        }
    }
}
