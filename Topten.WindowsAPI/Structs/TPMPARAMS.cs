using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct TPMPARAMS
        {
            public uint size;
            public RECT rcExclude;
        }
    }

}
