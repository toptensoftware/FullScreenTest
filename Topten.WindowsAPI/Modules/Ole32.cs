using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [DllImport("ole32.dll")]
        public static extern int OleSetClipboard(IDataObject pDataObj);

        [DllImport("ole32.dll")]
        public static extern int OleFlushClipboard();

        [DllImport("ole32.dll")]
        public static extern int OleGetClipboard(out IDataObject ppDataObj);

        [DllImport("ole32.dll")]
        public static extern uint RegisterDragDrop(IntPtr hWnd, IDropTarget dropTarget);

        [DllImport("ole32.dll")]
        public static extern uint RevokeDragDrop(IntPtr hWnd);

        [DllImport("ole32.dll")]
        public static extern void ReleaseStgMedium(ref STGMEDIUM medium);
    }
}
