using System;
using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PIXELFORMATDESCRIPTOR
        {
            public UInt16 nSize;
            public UInt16 nVersion;
            public UInt32 dwFlags;
            public Byte iPixelType;
            public Byte cColorBits;
            public Byte cRedBits;
            public Byte cRedShift;
            public Byte cGreenBits;
            public Byte cGreenShift;
            public Byte cBlueBits;
            public Byte cBlueShift;
            public Byte cAlphaBits;
            public Byte cAlphaShift;
            public Byte cAccumBits;
            public Byte cAccumRedBits;
            public Byte cAccumGreenBits;
            public Byte cAccumBlueBits;
            public Byte cAccumAlphaBits;
            public Byte cDepthBits;
            public Byte cStencilBits;
            public Byte cAuxBuffers;
            public SByte iLayerType;
            public Byte bReserved;
            public UInt32 dwLayerMask;
            public UInt32 dwVisibleMask;
            public UInt32 dwDamageMask;
        }
    }

}
