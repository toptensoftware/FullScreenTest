using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, uint attr, IntPtr attrData, int attrSize);

        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmGetWindowAttribute(IntPtr hWnd, uint attr, IntPtr attrData, int attrSize);

        public static int DwmSetWindowAttribute<T>(IntPtr hwnd, uint attr, T value) where T : unmanaged
        {
            unsafe
            {
                T* p = &value;
                int retv = DwmSetWindowAttribute(hwnd, attr, (IntPtr)p, sizeof(T));
                return retv;
            }
        }

        public static int DwmGetWindowAttribute<T>(IntPtr hwnd, uint attr, out T value) where T : unmanaged
        {
            unsafe
            {
                T temp;
                T* pTemp = &temp;
                int size = sizeof(T);
                int retv = DwmGetWindowAttribute(hwnd, attr, (IntPtr)pTemp, size);
                value = temp;
                return retv;
            }
        }
    }
}
