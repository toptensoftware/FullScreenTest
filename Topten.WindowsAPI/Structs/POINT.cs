using System;
using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static POINT operator +(POINT a, POINT b)
            {
                return new POINT(a.X + b.X, a.Y + b.Y);
            }

            public static POINT FromLParam(IntPtr lParam)
            {
                uint lp = (uint)(lParam.ToInt64() & 0xFFFFFFFF);
                return new POINT((int)(short)(lp & 0xFFFF), (int)(short)(lp >> 16));
            }

            public override string ToString()
            {
                return "{X: " + X + "; " + "Y: " + Y + "}";
            }
        }
    }

}
