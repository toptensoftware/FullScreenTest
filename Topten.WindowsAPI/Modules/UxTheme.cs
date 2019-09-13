using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static int IsThemeActive();

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
           int iStateId, ref RECT pRect, ref RECT pClipRect);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId,
           int iStateId, ref RECT pRect, IntPtr pClipRect);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 GetThemeBackgroundContentRect(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pBoundingRect, out RECT pContentRect);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 DrawThemeEdge(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pDestRect, uint egde, uint flags, out RECT pRect);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 DrawThemeEdge(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref RECT pDestRect, uint egde, uint flags, IntPtr pRect);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public extern static Int32 DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, String text, int textLength, UInt32 textFlags, UInt32 textFlags2, ref RECT pRect);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public extern static Int32 GetThemeTextExtent(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, String text, int textLength, UInt32 textFlags, ref RECT boundingRect, out RECT extentRect);

        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr OpenThemeData(IntPtr hWnd, String classList);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 CloseThemeData(IntPtr hTheme);

        [DllImport("uxtheme.dll")]
        public extern static uint GetThemeSysColor(IntPtr hTheme, int iColorId);

        [DllImport("uxtheme.dll")]
        public extern static IntPtr GetThemeSysColorBrush(IntPtr hTheme, int iColorId);

        [DllImport("uxtheme.dll", ExactSpelling = true)]
        public extern static Int32 GetThemeColor(IntPtr hTheme, int iPartId, int iStateId, int iPropId, out uint pColor);
    }
}
