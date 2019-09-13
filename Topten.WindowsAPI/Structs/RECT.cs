using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            private int _Left;
            private int _Top;
            private int _Right;
            private int _Bottom;

            public RECT(RECT r)
                : this(r.Left, r.Top, r.Right, r.Bottom)
            {
            }
            public RECT(int Left, int Top, int Right, int Bottom)
            {
                _Left = Left;
                _Top = Top;
                _Right = Right;
                _Bottom = Bottom;
            }
            public RECT(POINT Origin, SIZE size)
            {
                _Left = Origin.X;
                _Top = Origin.Y;
                _Right = _Left + size.Width;
                _Bottom = _Top + size.Height;
            }

            public RECT(POINT Origin, POINT BottomRight)
            {
                _Left = Origin.X;
                _Top = Origin.Y;
                _Right = BottomRight.X;
                _Bottom = BottomRight.Y;
            }

            public int X
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Y
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Left
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Top
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Right
            {
                get { return _Right; }
                set { _Right = value; }
            }
            public int Bottom
            {
                get { return _Bottom; }
                set { _Bottom = value; }
            }
            public int Height
            {
                get { return _Bottom - _Top; }
                set { _Bottom = value + _Top; }
            }
            public int Width
            {
                get { return _Right - _Left; }
                set { _Right = value + _Left; }
            }
            public POINT Location
            {
                get { return new POINT(Left, Top); }
                set
                {
                    _Right = value.X + Width;
                    _Bottom = value.Y + Height;
                    _Left = value.X;
                    _Top = value.Y;
                }
            }
            public POINT BottomRight
            {
                get
                {
                    return new POINT(Right, Bottom);
                }
            }
            public SIZE Size
            {
                get { return new SIZE(Width, Height); }
                set
                {
                    _Right = value.Width + _Left;
                    _Bottom = value.Height + _Top;
                }
            }

            public POINT Center
            {
                get { return new POINT((_Left + _Right) / 2, (_Top + _Bottom) / 2); }
            }

            public bool Contains(RECT other)
            {
                return other.Left >= Left && other.Right <= Right && other.Top >= Top && other.Bottom <= Bottom;
            }

            public bool Intersects(RECT other)
            {
                RECT tmp;
                return IntersectRect(out tmp, ref this, ref other);
            }

            public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
            {
                return Rectangle1.Equals(Rectangle2);
            }
            public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
            {
                return !Rectangle1.Equals(Rectangle2);
            }

            public override string ToString()
            {
                return "{Left: " + _Left + "; " + "Top: " + _Top + "; Width: " + Width+ "; Height: " + Height + "}";
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool Equals(RECT Rectangle)
            {
                return Rectangle.Left == _Left && Rectangle.Top == _Top && Rectangle.Right == _Right && Rectangle.Bottom == _Bottom;
            }

            public override bool Equals(object Object)
            {
                if (Object is RECT)
                {
                    return Equals((RECT)Object);
                }

                return false;
            }

            public static RECT operator +(RECT r, POINT offset)
            {
                return new RECT(r.Location + offset, r.Size);
            }

            public void Offset(int dx, int dy)
            {
                _Left += dx;
                _Right += dx;
                _Top += dy;
                _Bottom += dy;
            }

        }
    }

}
