using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPointerType(int pointerId, out uint pointerType);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPointerTouchInfo(int pointerId, out POINTER_TOUCH_INFO pointerType);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPointerPenInfo(int pointerId, out POINTER_PEN_INFO pointerType);

        [DllImport("user32.dll")]
        public static extern uint MsgWaitForMultipleObjectsEx(uint nCount, IntPtr[] pHandles, uint dwMilliseconds, uint dwWakeMask, uint dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int hookType, HOOKPROC lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, EntryPoint = "RegisterClipboardFormatW")]
        public static extern uint RegisterClipboardFormat([MarshalAs(UnmanagedType.LPWStr)] string lpszFormat);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetProcessDPIAware();

        [DllImport("user32.dll", EntryPoint = "SetThreadDpiAwarenessContext")]
        public extern static IntPtr _SetThreadDpiAwarenessContext(IntPtr context);
        public static IntPtr SetThreadDpiAwarenessContext(IntPtr context)
        {
            if (IsPerMonitorV2Supported)
                return _SetThreadDpiAwarenessContext(context);
            else
                return IntPtr.Zero;
        }

        public static IntPtr SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT value)
        {
            return SetThreadDpiAwarenessContext(new IntPtr((int)value));
        }

        [DllImport("user32.dll", EntryPoint = "GetThreadDpiAwarenessContext")]
        public extern static IntPtr _GetThreadDpiAwarenessContext();
        public static IntPtr GetThreadDpiAwarenessContext()
        {
            if (IsPerMonitorV2Supported)
                return _GetThreadDpiAwarenessContext();
            else
                return IntPtr.Zero;
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowDpiAwarenessContext")]
        public extern static IntPtr _GetWindowDpiAwarenessContext(IntPtr hWnd);
        public static IntPtr GetWindowDpiAwarenessContext(IntPtr hWnd)
        {
            if (IsPerMonitorV2Supported)
                return _GetWindowDpiAwarenessContext(hWnd);
            else
                return IntPtr.Zero;
        }

        [DllImport("user32.dll", EntryPoint = "GetAwarenessFromDpiAwarenessContext")]
        public extern static DPI_AWARENESS _GetAwarenessFromDpiAwarenessContext(IntPtr value);
        public static DPI_AWARENESS GetAwarenessFromDpiAwarenessContext(IntPtr value)
        {
            if (IsPerMonitorV2Supported)
                return _GetAwarenessFromDpiAwarenessContext(value);
            else
                return DPI_AWARENESS.UNAWARE;
        }

        public static DPI_AWARENESS CurrentThreadDpiAwareness
        {
            get { return GetAwarenessFromDpiAwarenessContext(GetThreadDpiAwarenessContext()); }
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetDpiForSystem();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetDpiForWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool AdjustWindowRectExForDpi(ref RECT lpRect, uint dwStyle, bool bMenu, uint dwExStyle, int dpi);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PhysicalToLogicalPointForPerMonitorDPI(IntPtr hWnd, ref POINT pt);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool LogicalToPhysicalPointForPerMonitorDPI(IntPtr hWnd, ref POINT pt);

        public static POINT PhysicalToLogicalPointForPerMonitorDPI(IntPtr hWnd, POINT pt)
        {
            PhysicalToLogicalPointForPerMonitorDPI(hWnd, ref pt);
            return pt;
        }
        public static POINT LogicalToPhysicalPointForPerMonitorDPI(IntPtr hWnd, POINT pt)
        {
            LogicalToPhysicalPointForPerMonitorDPI(hWnd, ref pt);
            return pt;
        }

        public static RECT PhysicalToLogicalPointForPerMonitorDPI(IntPtr hWnd, RECT rc)
        {
            POINT tl = rc.Location;
            POINT br = rc.BottomRight;
            PhysicalToLogicalPointForPerMonitorDPI(hWnd, ref tl);
            PhysicalToLogicalPointForPerMonitorDPI(hWnd, ref br);
            return new RECT(tl, br);
        }

        public static RECT LogicalToPhysicalPointForPerMonitorDPI(IntPtr hWnd, RECT rc)
        {
            POINT tl = rc.Location;
            POINT br = rc.BottomRight;
            LogicalToPhysicalPointForPerMonitorDPI(hWnd, ref tl);
            LogicalToPhysicalPointForPerMonitorDPI(hWnd, ref br);
            return new RECT(tl, br);
        }

        [DllImport("user32.dll", EntryPoint = "RegisterClassW")]
        public static extern ushort RegisterClass([In] ref WNDCLASS lpWndClass);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        public static string GetClassName(IntPtr hWnd)
        {
            var sb = new StringBuilder(512);
            GetClassName(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        [DllImport("user32.dll")]
        public static extern bool IsWindowUnicode(IntPtr Handle);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "CreateWindowExW")]
        public static extern IntPtr CreateWindowEx(
           uint dwExStyle,
           string lpClassName,
           string lpWindowName,
           uint dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll", EntryPoint = "DefWindowProcW")]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetCapture();

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(bool Lock);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        public static extern IntPtr BeginDeferWindowPos(int nNumWindows);

        [DllImport("user32.dll")]
        public static extern bool EndDeferWindowPos(IntPtr hDWP);

        [DllImport("user32.dll")]
        public static extern IntPtr DeferWindowPos(IntPtr hDWP, IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, String lpString);

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, uint message, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, uint message, IntPtr wParam, [In, Out] ref RECT rc);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);

        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessageW")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint message, IntPtr wParam, ref LVITEM item);

        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessageW")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint message, IntPtr wParam, ref LVCOLUMN column);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PostMessage(IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string lpString);

        [DllImport("user32.dll")]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32")]
        public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, uint message, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr SetTimer(IntPtr hWnd, IntPtr nIDEvent, uint uElapse, TIMERPROC lpTimerFunc);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref uint pvParam, uint fWinIni);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool SystemParametersInfo(uint action, uint intParam, ref NONCLIENTMETRICS metrics, uint update);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref int pvParam, uint fWinIni); // T = any type

        [DllImport("user32.dll", ExactSpelling = true)]
        static extern IntPtr SetTimer(IntPtr hWnd, IntPtr nIDEvent, uint uElapse, IntPtr lpTimerFunc);

        [DllImport("user32.dll", ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool KillTimer(IntPtr hWnd, IntPtr uIDEvent);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, [In] ref RECT lprcUpdate, IntPtr hrgnUpdate, int flags);

        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, [In] IntPtr lprcUpdate, IntPtr hrgnUpdate, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern uint SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
            else
            {
                unsafe
                {
                    return new IntPtr((void*)SetWindowLong(hWnd, nIndex, (uint)dwNewLong.ToInt32()));
                }
            }
        }

        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
            {
                unsafe
                {
                    return new IntPtr((void*)GetWindowLong(hWnd, nIndex));
                }
            }
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtrW", CharSet = CharSet.Unicode)]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtrW", CharSet = CharSet.Unicode)]
        static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "PeekMessageW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage(out MSG msg, IntPtr hWnd, uint wMsgFilterMin,
           uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport("user32.dll", EntryPoint = "GetMessageW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll")]
        public static extern bool WaitMessage();

        [DllImport("user32.dll", EntryPoint = "IsDialogMessageW")]
        public static extern bool IsDialogMessage(IntPtr hDlg, [In] ref MSG lpMsg);

        [DllImport("user32.dll", EntryPoint = "TranslateMessage")]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll")]
        public static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr hkl);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern short VkKeyScan(char ch);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int ToUnicode(uint vk, uint scanCode, byte[] keyState,
            [MarshalAs(UnmanagedType.LPArray)] [Out] char[] chars, int cchBuf, uint flags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr LoadKeyboardLayout(string name, uint flags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetKeyboardLayout(uint threadId);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        public static extern ushort GetAsyncKeyState(int vkKey);

        [DllImport("user32.dll", EntryPoint = "DispatchMessageW")]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        [DllImport("user32.dll", SetLastError = false)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern bool InflateRect(ref RECT lprc, int dx, int dy);

        [DllImport("user32.dll")]
        public static extern bool IntersectRect(out RECT lprcDst, [In] ref RECT lprcSrc1, [In] ref RECT lprcSrc2);

        [DllImport("user32.dll")]
        public static extern bool OffsetRect(ref RECT lprc, int dx, int dy);

        [DllImport("user32.dll")]
        public static extern bool PtInRect([In] ref RECT lprc, POINT pt);

        [DllImport("user32.dll")]
        public static extern bool DrawEdge(IntPtr hdc, ref RECT qrc, uint edge, uint grfFlags);

        [DllImport("user32.dll")]
        public static extern bool IsZoomed(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool AdjustWindowRect(ref RECT lpRect, uint dwStyle, bool bMenu);

        [DllImport("user32.dll")]
        public static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr hCursor);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursor(IntPtr hInstance, IntPtr lpCursorName);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateCursor(IntPtr hInstance, int xHotSpot, int yHotSpot, int width, int height, IntPtr andMask, IntPtr xorMask);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, int options);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, uint flags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("user32.dll")]
        public static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        [DllImport("user32.dll", EntryPoint = "LoadIconW")]
        public static extern IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadImage(IntPtr hinst, IntPtr lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadImage(IntPtr hinst, string lpszName, uint uType, int cxDesired, int cyDesired, uint fuLoad);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern uint GetSysColor(int index);

        [DllImport("user32.dll")]
        public static extern IntPtr GetSysColorBrush(int index);

        [DllImport("user32.dll", EntryPoint = "DrawTextW")]
        public static extern int DrawText(IntPtr hDC, [MarshalAs(UnmanagedType.LPWStr)] string lpString, int nCount, ref RECT lpRect, uint uFormat);

        public static int DrawText(IntPtr hDC, string lpString, ref RECT lpRect, uint uFormat)
        {
            return DrawText(hDC, lpString, lpString == null ? 0 : lpString.Length, ref lpRect, uFormat);
        }


        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(POINT pt);

        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        public static bool ScreenToClient(IntPtr hWnd, ref RECT lpRect)
        {
            POINT tl = lpRect.Location;
            POINT br = lpRect.BottomRight;
            ScreenToClient(hWnd, ref tl);
            ScreenToClient(hWnd, ref br);
            lpRect = new RECT(tl, br);
            return true;
        }

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

        public static bool ClientToScreen(IntPtr hWnd, ref RECT lpRect)
        {
            POINT tl = lpRect.Location;
            POINT br = lpRect.BottomRight;
            ClientToScreen(hWnd, ref tl);
            ClientToScreen(hWnd, ref br);
            lpRect = new RECT(tl, br);
            return true;
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetProp(IntPtr hWnd, string lpString, IntPtr hData);

        [DllImport("user32.dll")]
        public static extern IntPtr GetProp(IntPtr hWnd, string lpString);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowEnabled(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, [In] ref RECT lpRect, bool bErase);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, [In] IntPtr lpRect, bool bErase);

        public static bool InvalidateRect(IntPtr hWnd, bool bErase = false)
        {
            return InvalidateRect(hWnd, IntPtr.Zero, bErase);
        }

        [DllImport("user32.dll")]
        public static extern bool ValidateRect(IntPtr hWnd, [In] IntPtr lpRect);

        [DllImport("user32.dll")]
        public static extern bool ValidateRect(IntPtr hWnd, [In] ref RECT lpRect);

        public static bool ValidateRect(IntPtr hWnd)
        {
            return ValidateRect(hWnd, IntPtr.Zero);
        }

        [DllImport("user32.dll")]
        public static extern IntPtr DialogBoxIndirectParam(IntPtr hInstance, IntPtr lpTemplate, IntPtr hWndParent, WNDPROC lpDialogFunc, IntPtr dwInitParam);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateDialogIndirectParam(IntPtr hInstance, IntPtr lpTemplate, IntPtr hWndParent, WNDPROC lpDialogFunc, IntPtr dwInitParam);

        [DllImport("user32.dll")]
        public static extern int GetDlgCtrlID(IntPtr hwndCtl);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);

        [DllImport("user32.dll")]
        public static extern bool EndDialog(IntPtr hDlg, IntPtr nResult);

        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hwnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        public static extern bool EndPaint(IntPtr hWnd, [In] ref PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        public static extern int FillRect(IntPtr hDC, [In] ref RECT lprc, IntPtr hbr);

        [DllImport("user32.dll")]
        public static extern int GetUpdateRgn(IntPtr hWnd, IntPtr hRgn, bool bErase);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowScrollBar(IntPtr hWnd, int bar, [MarshalAs(UnmanagedType.Bool)] bool bShow);

        [DllImport("user32.dll")]
        public static extern int SetScrollPos(IntPtr hWnd, int bar, int nPos, bool bRedraw);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetScrollPos(IntPtr hWnd, int bar);

        [DllImport("user32.dll")]
        public static extern bool UpdateWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, IntPtr prcScroll, IntPtr prcClip, IntPtr hrgnUpdate, IntPtr prcUpdate, uint flags);

        [DllImport("user32.dll")]
        public static extern int SetScrollInfo(IntPtr hwnd, int bar, [In] ref SCROLLINFO lpsi, bool fRedraw);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int smIndex);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetricsForDpi(int smIndex, int dpi);

        [DllImport("user32.dll")]
        public static extern uint GetDoubleClickTime();

        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromRect([In] ref RECT lprc, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromPoint([In] POINT pt, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(IntPtr hDC, IntPtr prcClip, MONITORENUMPROC callback, IntPtr dwData);

        [DllImport("user32.dll")]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst,
           ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc, uint crKey,
           [In] ref BLENDFUNCTION pblend, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool InsertMenu(IntPtr hmenu, uint position, uint flags, IntPtr item_id, [MarshalAs(UnmanagedType.LPTStr)] string item_text);

        [DllImport("user32.dll")]
        public static extern uint CheckMenuItem(IntPtr hmenu, uint uIDCheckItem, uint uCheck);

        [DllImport("user32.dll")]
        public static extern uint EnableMenuItem(IntPtr hmenu, uint uIDCheckItem, uint uCheck);

        [DllImport("user32.dll")]
        public static extern IntPtr CreatePopupMenu();

        [DllImport("user32.dll")]
        public static extern IntPtr CreateMenu();

        [DllImport("user32.dll")]
        public static extern bool ModifyMenu(IntPtr hMnu, uint uPosition, uint uFlags, IntPtr uIDNewItem, string lpNewItem);

        [DllImport("user32.dll")]
        public static extern bool DestroyMenu(IntPtr hMenu);

        [DllImport("user32.dll")]
        public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool SetMenu(IntPtr hWnd, IntPtr hMenu);

        [DllImport("user32.dll")]
        public static extern bool TrackPopupMenu(IntPtr hmenu, uint fuFlags, int x, int y, int reserved, IntPtr hwnd, IntPtr lprc);

        [DllImport("user32.dll")]
        public static extern bool TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

        [DllImport("user32.dll")]
        public static extern uint TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, [In] ref TPMPARAMS lptpm);

        [DllImport("user32.dll")]
        public static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("user32.dll")]
        public static extern int GetMenuString(IntPtr hMenu, uint uIDItem, [Out] StringBuilder lpString, int nMaxCount, uint uFlag);

        [DllImport("user32.dll")]
        public static extern IntPtr GetSubMenu(IntPtr hMenu, int nPos);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("User32.dll")]
        public static extern uint SendInput(uint numberOfInputs, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] INPUT[] input, int structSize);
    }
}
