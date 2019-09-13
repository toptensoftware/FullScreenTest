using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL
{
    public partial class DeviceContext : IDisposable
    {
        public static IntPtr GetCurrentContext()
        {
            return impl_GetCurrentContext();
        }

        public static DeviceContext Create(IntPtr display, IntPtr windowHandle)
        {
            return impl_Create(display, windowHandle);
        }

        public virtual void ChoosePixelFormat(DevicePixelFormat pixelFormat)
        {
            impl_ChoosePixelFormat(pixelFormat);
        }

        public virtual IntPtr CreateContext(IntPtr sharedContext)
        {
            return impl_CreateContext(sharedContext);
        }

        public virtual bool DeleteContext(IntPtr ctx)
        {
            return impl_DeleteContext(ctx);
        }

        public virtual void SwapBuffers()
        {
            impl_SwapBuffers();
        }

        public virtual bool MakeCurrent(IntPtr ctx)
        {
            return impl_MakeCurrent(ctx);
        }

        public virtual bool SwapInterval(int interval)
        {
            return impl_SwapInterval(interval);
        }


        #region Dispose
        ~DeviceContext()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool IsDisposed { get; private set; }

        public virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            impl_Dispose(disposing);
            IsDisposed = true;
        }
        #endregion
    }
}
