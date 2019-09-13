using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint PFD_DOUBLEBUFFER = 0x00000001;
        public const uint PFD_STEREO = 0x00000002;
        public const uint PFD_DRAW_TO_WINDOW = 0x00000004;
        public const uint PFD_DRAW_TO_BITMAP = 0x00000008;
        public const uint PFD_SUPPORT_GDI = 0x00000010;
        public const uint PFD_SUPPORT_OPENGL = 0x00000020;
        public const uint PFD_GENERIC_FORMAT = 0x00000040;
        public const uint PFD_NEED_PALETTE = 0x00000080;
        public const uint PFD_NEED_SYSTEM_PALETTE = 0x00000100;
        public const uint PFD_SWAP_EXCHANGE = 0x00000200;
        public const uint PFD_SWAP_COPY = 0x00000400;
        public const uint PFD_SWAP_LAYER_BUFFERS = 0x00000800;
        public const uint PFD_GENERIC_ACCELERATED = 0x00001000;
        public const uint PFD_SUPPORT_DIRECTDRAW = 0x00002000;
        public const uint PFD_DIRECT3D_ACCELERATED = 0x00004000;
        public const uint PFD_SUPPORT_COMPOSITION = 0x00008000;
        public const uint PFD_DEPTH_DONTCARE = 0x20000000;
        public const uint PFD_DOUBLEBUFFER_DONTCARE = 0x40000000;
        public const uint PFD_STEREO_DONTCARE = 0x80000000;
        public const byte PFD_TYPE_RGBA = 0;
        public const byte PFD_TYPE_COLORINDEX = 1;
        public const int PFD_PLANE_MAIN = 0;
        public const int PFD_PLANE_OVERLAY = 1;
        public const int PFD_PLANE_UNDERLAY = -1;
    }
}
