using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL
{
    public class Win32
    {
        public const string LIBRARY_OPENGL = "opengl32.dll";

        [DllImport(LIBRARY_OPENGL)]
        static extern IntPtr glGetString(uint name);

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

        [DllImport("gdi32.dll")]
        public static extern int ChoosePixelFormat(IntPtr hdc, [In] ref PIXELFORMATDESCRIPTOR ppfd);

        [DllImport("gdi32.dll")]
        public static extern bool SetPixelFormat(IntPtr hdc, int iPixelFormat, ref PIXELFORMATDESCRIPTOR ppfd);

        [DllImport("gdi32.dll")]
        public static extern bool SwapBuffers(IntPtr hdc);

        [DllImport(LIBRARY_OPENGL, SetLastError = true)]
        public static extern int wglMakeCurrent(IntPtr hdc, IntPtr hrc);

        [DllImport(LIBRARY_OPENGL, SetLastError = true)]
        public static extern int wglDeleteContext(IntPtr hdc);

        [DllImport(LIBRARY_OPENGL, SetLastError = true)]
        public static extern IntPtr wglCreateContext(IntPtr hdc);

        [DllImport(LIBRARY_OPENGL, SetLastError = true)]
        public static extern IntPtr wglGetCurrentDC();

        [DllImport(LIBRARY_OPENGL, SetLastError = true)]
        public static extern IntPtr wglGetCurrentContext();

        [DllImport(LIBRARY_OPENGL)]
        public static extern IntPtr wglGetProcAddress([In, MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeLibrary(IntPtr hModule);
    }
}
