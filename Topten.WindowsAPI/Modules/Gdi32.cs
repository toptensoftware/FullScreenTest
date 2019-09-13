using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("gdi32.dll")]
        public static extern IntPtr GetStockObject(int Object);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateIC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpdvmInit);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap([In] IntPtr hdc, int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, [In] ref BITMAPINFOHEADER pbmi, uint pila, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        [DllImport("gdi32.dll")]
        public static extern int GetObject(IntPtr hgdiobj, int cbBuffer, ref BITMAP bmp);

        [DllImport("gdi32.dll")]
        public static extern int GetObject(IntPtr hgdiobj, int cbBuffer, ref DIBSECTION bmp);

        [DllImport("gdi32.dll")]
        public static extern int GetObject(IntPtr hgdiobj, int cbBuffer, out LOGFONT o);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, PreserveSig = true, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        public static extern int SetBkMode(IntPtr hdc, int iBkMode);

        [DllImport("gdi32.dll")]
        public static extern uint SetTextColor(IntPtr hdc, uint crColor);

        [DllImport("gdi32.dll")]
        public static extern uint SetBkColor(IntPtr hdc, uint crColor);

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        public static extern bool GetTextMetrics(IntPtr hdc, out TEXTMETRIC lptm);

        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);

        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr hdc, int X, int Y, IntPtr lpPoint);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(int PenStyle, int nWidth, uint crColor);

        [DllImport("gdi32.dll")]
        public static extern bool Polygon(IntPtr hdc, POINT[] lpPoints, int nCount);

        [DllImport("gdi32.dll")]
        public static extern bool Rectangle(IntPtr hDC, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("gdi32.dll")]
        public static extern bool FillRgn(IntPtr hDC, IntPtr hrgn, IntPtr hbr);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateSolidBrush(uint crColor);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePatternBrush(IntPtr hbmp);

        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("gdi32.dll", EntryPoint = "CreateFontIndirectW")]
        public static extern IntPtr CreateFontIndirect([In] ref LOGFONT lplf);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr AddFontMemResourceEx(byte[] pbFont, int cbFont, IntPtr pdv, out uint pcFonts);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("gdi32.dll")]
        public static extern bool RectInRegion(IntPtr hRgn, ref RECT rc);

        [DllImport("gdi32.dll")]
        public static extern bool SetRectRgn(IntPtr hrgn, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePolygonRgn(POINT[] lppt, int cPoints, int fnPolyFillMode);

        [DllImport("gdi32.dll")]
        public static extern int CombineRgn(IntPtr hrgnDest, IntPtr hrgnSrc1, IntPtr hrgnSrc2, int fnCombineMode);

        [DllImport("gdi32.dll")]
        public static extern int GetClipRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport("gdi32.dll")]
        public static extern int IntersectClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport("gdi32.dll")]
        public static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport("gdi32.dll", EntryPoint = "GdiAlphaBlend")]
        public static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, BLENDFUNCTION blendFunction);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, [In] IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint dwRop);

        [DllImport("gdi32.dll")]
        public static extern int StretchDIBits(IntPtr hdc, int XDest, int YDest, int nDestWidth, int nDestHeight, int XSrc, int YSrc, int nSrcWidth, int nSrcHeight, IntPtr lpBits, [In] ref BITMAPINFO lpBitsInfo, uint iUsage, uint dwRop);

        [DllImport("gdi32.dll")]
        public static extern int SetDIBitsToDevice(IntPtr hdc, int XDest, int YDest, int nDestWidth, int nDestHeight, int XSrc, int YSrc, int startScan, int scanLines, IntPtr lpBits, [In] ref BITMAPINFO lpBitsInfo, uint iUsage);

        [DllImport("gdi32.dll", EntryPoint = "GdiGradientFill", ExactSpelling = true)]
        public static extern bool GradientFill(IntPtr hdc, IntPtr pVertex, uint dwNumVertex, [In] ref GRADIENT_RECT pMesh,uint dwNumMesh, uint dwMode);

        [DllImport("gdi32.dll", EntryPoint = "GdiGradientFill", ExactSpelling = true)]
        public static extern bool GradientFill(IntPtr hdc, IntPtr pVertex, uint dwNumVertex, [In] ref GRADIENT_TRIANGLE pMesh, uint dwNumMesh, uint dwMode);

        [DllImport("gdi32.dll")]
        public static extern int ChoosePixelFormat(IntPtr hdc, [In] ref PIXELFORMATDESCRIPTOR ppfd);

        [DllImport("gdi32.dll")]
        public static extern bool SetPixelFormat(IntPtr hdc, int iPixelFormat, ref PIXELFORMATDESCRIPTOR ppfd);

        [DllImport("gdi32.dll")]
        public static extern bool SwapBuffers(IntPtr hdc);
    }
}
