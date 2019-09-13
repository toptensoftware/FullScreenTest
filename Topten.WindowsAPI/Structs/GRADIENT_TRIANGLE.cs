using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct GRADIENT_TRIANGLE
        {
            uint Vertex1;
            uint Vertex2;
            uint Vertex3;
        }
    }

}
