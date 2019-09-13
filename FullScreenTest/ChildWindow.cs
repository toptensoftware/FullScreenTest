using OpenGL;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Topten.WindowsAPI.WinApi;

namespace FullScreenTest
{
    class ChildWindow
    {
        static ChildWindow()
        {
            var _wndClass = new WNDCLASS();
            _wndClass.style = CS_DBLCLKS;
            _wndClass.lpfnWndProc = DefWindowProc;
            _wndClass.lpszClassName = "ChildWindow";
            _wndClass.hbrBackground = IntPtr.Zero;
            _wndClass.hCursor = LoadCursor(IntPtr.Zero, (IntPtr)IDC_ARROW);
            RegisterClass(ref _wndClass);
        }

        public ChildWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;

            // Create window
            _hWnd = CreateWindowEx(0, "ChildWindow", null, WS_CHILD|WS_VISIBLE, 0, 0, 0, 0, mainWindow.Handle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);

            // Subclass it
            _oldWndProc = GetWindowLongPtr(_hWnd, GWL_WNDPROC);
            _wndProc = WndProc;
            SetWindowLongPtr(_hWnd, GWL_WNDPROC, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(_wndProc));

            // Initialize OpenGL
            InitOpenGL();
        }

        MainWindow _mainWindow;
        IntPtr _hWnd;
        IntPtr _oldWndProc;
        WNDPROC _wndProc;

        DeviceContext _deviceContext;
        IntPtr _ctx;

        void InitOpenGL()
        {
            // Create OpenGL device context
            _deviceContext = DeviceContext.Create(IntPtr.Zero, _hWnd);

            // Choose pixel format
            _deviceContext.ChoosePixelFormat(new DevicePixelFormat(24));

            // Create OpenGL Context
            _ctx = _deviceContext.CreateContext(IntPtr.Zero);

            // Make context current
            _deviceContext.MakeCurrent(_ctx);
        }

        void CloseOpenGL()
        {
            if (_ctx != IntPtr.Zero)
            {
                _deviceContext.MakeCurrent(IntPtr.Zero);
                _deviceContext.DeleteContext(_ctx);
                _ctx = IntPtr.Zero;
            }
            if (_deviceContext != null)
            {
                _deviceContext.Dispose();
                _deviceContext = null;
            }
        }

        IntPtr _contextMenu;

        void OnRender()
        {
            Gl.ClearColor(1, 0, 0, 1);
            Gl.Clear(ClearBufferMask.ColorBufferBit);
            _deviceContext.SwapBuffers();
        }

        public IntPtr Handle => _hWnd;

        private IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WM_DESTROY:
                    CloseOpenGL();
                    if (_contextMenu != IntPtr.Zero)
                    {
                        DestroyMenu(_contextMenu);
                        _contextMenu = IntPtr.Zero;
                    }
                    break;

                case WM_ERASEBKGND:
                    return (IntPtr)1;

                case WM_PAINT:
;                   {
                        if (_ctx != IntPtr.Zero)
                        {
                            OnRender();
                        }
                        else
                        {
                            IntPtr hDC = BeginPaint(hWnd, out var ps);
                            RECT rc;
                            GetClientRect(_hWnd, out rc);
                            FillRect(hDC, ref rc, GetSysColorBrush(COLOR_HIGHLIGHT));
                            EndPaint(hWnd, ref ps);
                        }
                    }
                    break;

                case WM_KEYDOWN:
                    // Shift+F11 = Toggle Full Screen
                    if (wParam.ToInt32() == VK_F11 && GetKeyState(VK_SHIFT) < 0)
                    {
                        _mainWindow.SetFullScreen(!_mainWindow.IsFullScreen);
                    }

                    // Ctrl+G toggle OpenGL 
                    if (wParam.ToInt32() == 'G' && GetKeyState(VK_CONTROL) < 0)
                    {
                        if (_ctx != IntPtr.Zero)
                        {
                            CloseOpenGL();
                        }
                        else
                        {
                            InitOpenGL();
                        }
                        InvalidateRect(_hWnd);
                    }

                    // Ctrl+G toggle OpenGL 
                    if (wParam.ToInt32() == 'M' && GetKeyState(VK_CONTROL) < 0)
                    {
                        MessageBox(Handle, "Hello World", "Full Screen Test", MB_OK | MB_ICONINFORMATION);
                    }
                    break;

                case WM_CONTEXTMENU:
                    var pt = PointFromLParam(lParam);
                    if (pt.X < 0)
                    {
                        pt = new POINT(10, 10);
                        ClientToScreen(Handle, ref pt);
                    }
                    if (_contextMenu == IntPtr.Zero)
                    {
                        _contextMenu = CreatePopupMenu();
                        InsertMenu(_contextMenu, 0, MF_STRING, (IntPtr)101, "Hello World");
                        InsertMenu(_contextMenu, 0, MF_STRING, (IntPtr)102, "Goodbye World");
                    }
                    TrackPopupMenu(_contextMenu, TPM_LEFTALIGN | TPM_RIGHTBUTTON, pt.X, pt.Y, 0, Handle, IntPtr.Zero);
                    return IntPtr.Zero;
            }

            return CallWindowProc(_oldWndProc, hWnd, msg, wParam, lParam);
        }
    }
}
