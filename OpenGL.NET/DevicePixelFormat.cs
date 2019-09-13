using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGL
{
    public class DevicePixelFormat
    {
        public DevicePixelFormat(int colorBits)
        {
            ColorBits = colorBits;
        }

        public int ColorBits = 24;
        public int DepthBits = 32;
    }
}
