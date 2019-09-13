using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint dwType;
            public MOUSEKEYBDHARDWAREINPUT mkhi;
        };
    }

}
