using System;
using System.Runtime.InteropServices;
using static Topten.WindowsAPI.WinApi;

namespace FullScreenTest
{
    class MainWindow
    {
        static MainWindow()
        {
            var _wndClass = new WNDCLASS();
            _wndClass.style = CS_DBLCLKS;
            _wndClass.lpfnWndProc = DefWindowProc;
            _wndClass.lpszClassName = "MainWindow";
            _wndClass.hbrBackground = IntPtr.Zero;
            _wndClass.hCursor = LoadCursor(IntPtr.Zero, (IntPtr)IDC_ARROW);
            RegisterClass(ref _wndClass);
        }

        public MainWindow()
        {
            // Create window
            _hWnd = CreateWindowEx(0, "MainWindow", "Full Screen Test", WS_OVERLAPPEDWINDOW|WS_VISIBLE, 100, 100, 640, 480, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            // Subclass it
            _oldWndProc = GetWindowLongPtr(_hWnd, GWL_WNDPROC);
            _wndProc = WndProc;
            SetWindowLongPtr(_hWnd, GWL_WNDPROC, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(_wndProc));

            // Create the child
            _child = new ChildWindow(this);

            // Position it
            PositionChild();
            SetFocus(_child.Handle);
        }

        public IntPtr Handle => _hWnd;

        IntPtr _hWnd;
        IntPtr _oldWndProc;
        WNDPROC _wndProc;
        ChildWindow _child;

        class PreFullScreenState
        {
            public WINDOWPLACEMENT placement;
            public uint style;
            public uint exStyle;
        }

        PreFullScreenState _preFullScreenState;

        public bool IsFullScreen => _preFullScreenState != null;

        public void SetFullScreen(bool value)
        {
            // Disable transitions while setting placement
            DwmSetWindowAttribute(_hWnd, DWMWA_TRANSITIONSFORCEDISABLED, 1);

            if (value)
            {
                // Save previous state
                WINDOWPLACEMENT wp;
                wp.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                GetWindowPlacement(_hWnd, out wp);

                // Capture state
                _preFullScreenState = new PreFullScreenState()
                {
                    placement = wp,
                    style = GetWindowLong(_hWnd, GWL_STYLE),
                    exStyle = GetWindowLong(_hWnd, GWL_EXSTYLE),
                };

                // Switch mode
                SetWindowLong(_hWnd, GWL_STYLE, _preFullScreenState.style & ~(WS_CAPTION | WS_THICKFRAME));
                SetWindowLong(_hWnd, GWL_EXSTYLE, _preFullScreenState.exStyle & ~(WS_EX_DLGMODALFRAME | WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE | WS_EX_STATICEDGE));

                // Get monitor info
                var hMon = MonitorFromWindow(_hWnd, MONITOR_DEFAULTTONEAREST);
                MONITORINFO mi = new MONITORINFO();
                mi.cbSize = Marshal.SizeOf<MONITORINFO>();
                GetMonitorInfo(hMon, ref mi);

                // Reposition
                SetWindowPos(_hWnd, IntPtr.Zero, mi.rcMonitor.Left, mi.rcMonitor.Top, mi.rcMonitor.Width, mi.rcMonitor.Height, SWP_NOZORDER | SWP_NOACTIVATE);
            }
            else
            {
                // Restore window styles
                SetWindowLong(_hWnd, GWL_STYLE, _preFullScreenState.style | WS_VISIBLE);
                SetWindowLong(_hWnd, GWL_EXSTYLE, _preFullScreenState.exStyle);
                if (_preFullScreenState.placement.showCmd == SW_SHOWMAXIMIZED)
                {
                    ShowWindow(_hWnd, SW_SHOWMAXIMIZED);
                }
                if (_preFullScreenState.placement.showCmd == SW_HIDE)
                    _preFullScreenState.placement.showCmd = SW_NORMAL;
                SetWindowPlacement(_hWnd, ref _preFullScreenState.placement);

                _preFullScreenState = null;
            }

            DwmSetWindowAttribute(_hWnd, DWMWA_TRANSITIONSFORCEDISABLED, 0);
        }


        void PositionChild()
        {
            RECT rc;
            GetClientRect(_hWnd, out rc);
            SetWindowPos(_child.Handle, IntPtr.Zero, 0, 0, rc.Width, rc.Height, SWP_NOZORDER);
        }

        private IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WM_ERASEBKGND:
                    return (IntPtr)1;

                case WM_SETFOCUS:
                    SetFocus(_child.Handle);
                    break;

                case WM_SIZE:
                    PositionChild();
                    break;

                case WM_CLOSE:
                    PostQuitMessage(0);
                    break;
            }

            return CallWindowProc(_oldWndProc, hWnd, msg, wParam, lParam);
        }

    }
}
