using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL
{
    public partial class DeviceContext
    {
        static IntPtr impl_GetCurrentContext()
        {
            return Win32.wglGetCurrentContext();
        }

        static DeviceContext impl_Create(IntPtr display, IntPtr windowHandle)
        {
            return new DeviceContext(windowHandle);
        }

        public DeviceContext(IntPtr windowHandle)
        {
            _windowHandle = windowHandle;
            _hdc = Win32.GetDC(_windowHandle);
        }

        void impl_Dispose(bool disposing)
        {
            if (_hdc != IntPtr.Zero)
            {
                Win32.ReleaseDC(_windowHandle, _hdc);
                _hdc = IntPtr.Zero;
                _windowHandle = IntPtr.Zero;
            }
        }

        IntPtr _windowHandle;
        IntPtr _hdc;
        Win32.PIXELFORMATDESCRIPTOR _pfd;
        int _pixelFormat;

        void impl_ChoosePixelFormat(DevicePixelFormat pixelFormat)
        {
            // Create pixel format descriptor
            _pfd = new Win32.PIXELFORMATDESCRIPTOR()
            {
                nSize = (ushort)System.Runtime.InteropServices.Marshal.SizeOf(typeof(OpenGL.Win32.PIXELFORMATDESCRIPTOR)),
                nVersion = 1,
                dwFlags = OpenGL.Win32.PFD_DRAW_TO_WINDOW | OpenGL.Win32.PFD_SUPPORT_OPENGL | OpenGL.Win32.PFD_DOUBLEBUFFER,
                iPixelType = OpenGL.Win32.PFD_TYPE_RGBA,
                cColorBits = (byte)pixelFormat.ColorBits,
                cDepthBits = (byte)pixelFormat.DepthBits,
                iLayerType = OpenGL.Win32.PFD_PLANE_MAIN,
            };

            // Choose pixel format
            _pixelFormat = Win32.ChoosePixelFormat(_hdc, ref _pfd);
        }

        IntPtr impl_CreateContext(IntPtr sharedContext)
        {
            // Check pixel format was selected
            if (_pixelFormat == 0)
                throw new InvalidOperationException("Failed to choose a matching pixel format");

            // Set pixel format
            if (!Win32.SetPixelFormat(_hdc, _pixelFormat, ref _pfd))
            {
                throw new InvalidOperationException(string.Format("Failed to set pixel format {0}", Marshal.GetLastWin32Error()));
            }

            // Create context
            var ctx = Win32.wglCreateContext(_hdc);
            if (ctx == IntPtr.Zero)
            {
                throw new InvalidOperationException(string.Format("Failed to create OpenGL context {0}", Marshal.GetLastWin32Error()));
            }

            // Make context active while creating bindings
            Win32.wglMakeCurrent(_hdc, ctx);
            var bindings = new Bindings();
            Win32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);

            // Associate the context and its bindings
            _contextBindings.Add(ctx, bindings);

            // Return the context
            return ctx;
        }

        // Map of the bindings for each context (they should all be the same but we create a separate set for each
        // just in case).
        Dictionary<IntPtr, Bindings> _contextBindings = new Dictionary<IntPtr, Bindings>();

        bool impl_DeleteContext(IntPtr ctx)
        {
            // Find the bindings
            Bindings bindings;
            if (!_contextBindings.TryGetValue(ctx, out bindings))
                throw new InvalidOperationException("Invalid OpenGL context handle");

            // Delete it
            Win32.wglDeleteContext(ctx);

            // Remove the bindings from the map
            _contextBindings.Remove(ctx);

            return true;
        }

        void impl_SwapBuffers()
        {
            Win32.SwapBuffers(_hdc);
        }

        bool impl_MakeCurrent(IntPtr ctx)
        {
            // Redundant?
            if (Win32.wglGetCurrentContext() == ctx)
                return true;

            // Deactivating?
            if (ctx == IntPtr.Zero)
            {
                Win32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                Gl.MakeCurrent(null);
                return true;
            }

            // Get the bindings for the context
            Bindings bindings;
            if (!_contextBindings.TryGetValue(ctx, out bindings))
                throw new InvalidOperationException("Invalid OpenGL context handle");

            // Activate the context
            Win32.wglMakeCurrent(_hdc, ctx);

            // Set the active bindings
            Gl.MakeCurrent(bindings);

            return true;
        }


        public delegate bool del_wglSwapIntervalEXT(int interval);
        public del_wglSwapIntervalEXT wglSwapIntervalEXT;

        bool impl_SwapInterval(int interval)
        {
            if (wglSwapIntervalEXT == null)
            {
                var hOpenGL = Win32.LoadLibrary(Win32.LIBRARY_OPENGL);
                var fn = Win32.wglGetProcAddress("wglSwapIntervalEXT");
                if (fn == IntPtr.Zero)
                    return false;

                wglSwapIntervalEXT = (del_wglSwapIntervalEXT)Marshal.GetDelegateForFunctionPointer(fn, typeof(del_wglSwapIntervalEXT));
            }

            return wglSwapIntervalEXT(interval);
        }

    }
}
