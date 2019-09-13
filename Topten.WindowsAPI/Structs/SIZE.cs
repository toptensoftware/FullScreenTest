using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SIZE
        {
            public int Width;
            public int Height;

            public SIZE(int Width, int Height)
            {
                this.Width = Width;
                this.Height = Height;
            }

            public static SIZE operator +(SIZE a, SIZE b)
            {
                return new SIZE(a.Width + b.Width, a.Height + b.Height);
            }

            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;

                if (!(obj is SIZE))
                    return false;

                return this == (SIZE)obj;
            }

            public override int GetHashCode()
            {
                return Width.GetHashCode() ^ Height.GetHashCode();
            }

            public static bool operator ==(SIZE a, SIZE b)
            {
                return a.Width == b.Width && a.Height == b.Height;
            }

            public static bool operator !=(SIZE a, SIZE b)
            {
                return !(a == b);
            }

            public override string ToString()
            {
                return "{Width: " + Width.ToString() + "; " + "Height: " + Height.ToString();
            }

        }
    }

}
