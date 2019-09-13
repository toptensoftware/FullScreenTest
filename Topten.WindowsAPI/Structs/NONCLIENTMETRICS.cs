using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct NONCLIENTMETRICS
        {
            public int cbSize;
            public int iBorderWidth;
            public int iScrollWidth;
            public int iScrollHeight;
            public int iCaptionWidth;
            public int iCaptionHeight;
            public LOGFONT lfCaptionFont;
            public int iSmCaptionWidth;
            public int iSmCaptionHeight;
            public LOGFONT lfSmCaptionFont;
            public int iMenuWidth;
            public int iMenuHeight;
            public LOGFONT lfMenuFont;
            public LOGFONT lfStatusFont;
            public LOGFONT lfMessageFont;
        }
    }

}
