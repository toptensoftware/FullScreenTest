using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00000122-0000-0000-C000-000000000046")] // This is the value of IID_IDropTarget from the Platform SDK.
        [ComImport]
        public interface IDropTarget
        {
            void DragEnter([In] IDataObject dataObject, [In] uint keyState, [In] POINT pt, [In, Out] ref uint effect);
            void DragOver([In] uint keyState, [In] POINT pt, [In, Out] ref uint effect);
            void DragLeave();
            void Drop([In] IDataObject dataObject, [In] uint keyState, [In] POINT pt, [In, Out] ref uint effect);
        }

    }

}
