using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("opengl32.dll")]
        public static extern IntPtr glGetString(uint name);

        [DllImport("opengl32.dll", SetLastError = true)]
        public static extern int wglMakeCurrent(IntPtr hdc, IntPtr hrc);

        [DllImport("opengl32.dll", SetLastError = true)]
        public static extern int wglDeleteContext(IntPtr hdc);

        [DllImport("opengl32.dll", SetLastError = true)]
        public static extern IntPtr wglCreateContext(IntPtr hdc);

        [DllImport("opengl32.dll", SetLastError = true)]
        public static extern IntPtr wglGetCurrentDC();

        [DllImport("opengl32.dll", SetLastError = true)]
        public static extern IntPtr wglGetCurrentContext();

        [DllImport("opengl32.dll")]
        public static extern IntPtr wglGetProcAddress([In, MarshalAs(UnmanagedType.LPStr)] string name);

    }
}
