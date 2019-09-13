using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public static void GradientFill(IntPtr hDC, ref RECT rect, uint colorA, uint colorB, bool vertical)
        {
            var vertices = new TRIVERTEX[2];

            vertices[0].x = rect.Left;
            vertices[0].y = rect.Top;
            vertices[0].Red = (ushort)((colorA & 0xFF) << 8);
            vertices[0].Green = (ushort)(((colorA >> 8) & 0xFF) << 8);
            vertices[0].Blue = (ushort)(((colorA >> 16) & 0xFF) << 8);

            vertices[1].x = rect.Right;
            vertices[1].y = rect.Bottom;
            vertices[1].Red = (ushort)((colorB & 0xFF) << 8);
            vertices[1].Green = (ushort)(((colorB >> 8) & 0xFF) << 8);
            vertices[1].Blue = (ushort)(((colorB >> 16) & 0xFF) << 8);


            GRADIENT_RECT r;
            r.UpperLeft = 0;
            r.LowerRight = 1;

            GCHandle pinnedArray = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            GradientFill(hDC, pinnedArray.AddrOfPinnedObject(), 2, ref r, 1, vertical ? GRADIENT_FILL_RECT_V : GRADIENT_FILL_RECT_H);
            pinnedArray.Free();
        }
    }
}
