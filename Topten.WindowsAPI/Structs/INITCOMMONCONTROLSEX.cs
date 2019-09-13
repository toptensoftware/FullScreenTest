namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public struct INITCOMMONCONTROLSEX
		{
			private int dwSize;
			public uint dwICC;

			public INITCOMMONCONTROLSEX(uint dwICC=0)
				: this()
			{
				this.dwSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(INITCOMMONCONTROLSEX));
				this.dwICC = dwICC;
			}
		}
    }

}
