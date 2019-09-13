using System;
using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
		public struct ACTCTX
		{
			public int cbSize;
			public uint dwFlags;
			public string lpSource;
			public ushort wProcessorArchitecture;
			public ushort wLangId;
			public string lpAssemblyDirectory;
			public UInt16 lpResourceName;
			public string lpApplicationName;
		}
    }

}
