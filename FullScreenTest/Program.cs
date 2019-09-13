using System;
using static Topten.WindowsAPI.WinApi;

namespace FullScreenTest
{

    class Program
    {
        static void Main(string[] args)
        {
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
