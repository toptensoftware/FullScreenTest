using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL
{
    public partial class Bindings
    {
        void impl_Bindings()
        {
            var hOpenGL = Win32.LoadLibrary(Win32.LIBRARY_OPENGL);

            foreach (var f in typeof(Bindings).GetFields().Where(x => !x.IsLiteral))
            {
                var fn = Win32.wglGetProcAddress(f.Name);
                if (fn == IntPtr.Zero)
                {
                    fn = Win32.GetProcAddress(hOpenGL, f.Name);
                    if (fn == IntPtr.Zero)
                    {
                        throw new InvalidOperationException(string.Format("OpenGL function {0} not found", f.Name));
                    }
                }

                f.SetValue(this, Marshal.GetDelegateForFunctionPointer(fn, f.FieldType));
            }
        }
    }
}
