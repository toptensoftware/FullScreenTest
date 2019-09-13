using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct BITMAPINFO
        {
            public BITMAPINFOHEADER bmiHeader;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1)]
            public uint[] bmiColors;
        }
    }

}
