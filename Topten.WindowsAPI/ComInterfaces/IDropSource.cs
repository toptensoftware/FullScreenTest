using System;
using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("00000121-0000-0000-C000-000000000046")] // This is the value of IID_IDropTarget from the Platform SDK.
        [ComImport]
        public interface IDropSource
        {
            [PreserveSig]
            int QueryContinueDrag([In, MarshalAs(UnmanagedType.Bool)] bool fEscapePressed, [In] uint keyState);

            [PreserveSig]
            int GiveFeedback([In] uint keyState);
        }

    }

}
