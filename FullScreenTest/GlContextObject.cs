using OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullScreenTest
{
    public class GlContextObject : IDisposable
    {
        public GlContextObject()
        {
            _ctx = DeviceContext.GetCurrentContext();
            System.Diagnostics.Debug.Assert(_ctx != IntPtr.Zero);
        }

        ~GlContextObject()
        {
            if (_ctx != IntPtr.Zero)
            {
                if (!string.IsNullOrEmpty(DebugName))
                    throw new InvalidOperationException($"{GetType().Name} '{DebugName}' wasn't disposed");
                else
                    throw new InvalidOperationException($"{GetType().Name} wasn't disposed");
            }
        }

        public string DebugName { get; set; }

        protected IntPtr _ctx;

        public IntPtr Context => _ctx;

        [Conditional("DEBUG")]
        public void CheckCurrent()
        {
            System.Diagnostics.Debug.Assert(DeviceContext.GetCurrentContext() == _ctx);
        }

        public virtual void Dispose()
        {
            if (_ctx != IntPtr.Zero)
            {
                CheckCurrent();
                _ctx = IntPtr.Zero;
            }
        }
    }
}
