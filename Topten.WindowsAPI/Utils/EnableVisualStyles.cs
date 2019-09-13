using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        class VisualStyles
        { 
            // Static constructor, make sure common controls activation context is created
            static VisualStyles()
            {
                var actctx = new ACTCTX();
                actctx.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(ACTCTX));
                actctx.lpSource = Assembly.GetExecutingAssembly().Location;
                actctx.dwFlags = ACTCTX_RESOURCE_NAME_VALID;
                actctx.lpResourceName = 2;
                hActCtxCommonControls = CreateActCtx(ref actctx);
            }

            class ActiveContext : IDisposable
            {
                public ActiveContext(IntPtr hActCtx)
                {
                    if (hActCtx != IntPtr.Zero)
                        ActivateActCtx(hActCtx, out _cookie);
                }

                public void Dispose()
                {
                    if (_cookie != IntPtr.Zero)
                        DeactivateActCtx(0, _cookie);
                }
                IntPtr _cookie;
            }

            public static IDisposable EnableVisualStyles(bool enable)
            {
                IDisposable ctx = new ActiveContext(enable ? hActCtxCommonControls : IntPtr.Zero);

                if (!Initialized)
                {
                    var init = new INITCOMMONCONTROLSEX();
                    InitCommonControlsEx(ref init);
                    Initialized = true;
                }

                return ctx;
            }

            static IntPtr hActCtxCommonControls;
            static bool Initialized = false;
        }

        public static IDisposable EnableVisualStyles(bool enable = true) => VisualStyles.EnableVisualStyles(enable);
    }
}
