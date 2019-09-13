using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINTER_TOUCH_INFO
        {
            public POINTER_INFO pointerInfo;
            public uint touchFlags;
            public uint touchMask;
            public RECT rcContact;
            public RECT rcContactRaw;
            public uint orientation;
            public uint pressure;
        };
    }

}
