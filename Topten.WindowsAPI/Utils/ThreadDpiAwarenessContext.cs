using System;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public class ThreadDpiAwarenessContext: IDisposable
        {
            public ThreadDpiAwarenessContext(IntPtr ctx)
            {
                _oldContext = SetThreadDpiAwarenessContext(ctx);
            }

            public ThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT ctx)
            {
                _oldContext = SetThreadDpiAwarenessContext(ctx);
            }

            public void Dispose()
            {
                if (_oldContext != IntPtr.Zero)
                {
                    SetThreadDpiAwarenessContext(_oldContext);
                }
            }

            IntPtr _oldContext;
        }

    }

}
