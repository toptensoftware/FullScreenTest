using System;
using static Topten.WindowsAPI.WinApi;

namespace FullScreenTest
{

    class Program
    {
        static void Main(string[] args)
        {
            // THIS MAKES A DIFFERENCE
            // When commented out, problem doesn't happen
            SetThreadDpiAwarenessContext(DPI_AWARENESS_CONTEXT.PER_MONITOR_AWARE_V2);

            var mainWindow = new MainWindow();

            MSG msg;
            while (GetMessage(out msg, IntPtr.Zero, 0, 0))
            {
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }
        }
    }
}
