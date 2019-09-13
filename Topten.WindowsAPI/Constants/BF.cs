using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint BF_LEFT = 0x0001;
        public const uint BF_TOP = 0x0002;
        public const uint BF_RIGHT = 0x0004;
        public const uint BF_BOTTOM = 0x0008;
        public const uint BF_TOPLEFT = (BF_TOP | BF_LEFT);
        public const uint BF_TOPRIGHT = (BF_TOP | BF_RIGHT);
        public const uint BF_BOTTOMLEFT = (BF_BOTTOM | BF_LEFT);
        public const uint BF_BOTTOMRIGHT = (BF_BOTTOM | BF_RIGHT);
        public const uint BF_RECT = (BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM);
        public const uint BF_DIAGONAL = 0x0010;
        public const uint BF_DIAGONAL_ENDTOPRIGHT = (BF_DIAGONAL | BF_TOP | BF_RIGHT);
        public const uint BF_DIAGONAL_ENDTOPLEFT = (BF_DIAGONAL | BF_TOP | BF_LEFT);
        public const uint BF_DIAGONAL_ENDBOTTOMLEFT = (BF_DIAGONAL | BF_BOTTOM | BF_LEFT);
        public const uint BF_DIAGONAL_ENDBOTTOMRIGHT = (BF_DIAGONAL | BF_BOTTOM | BF_RIGHT);
        public const uint BF_MIDDLE = 0x0800;
        public const uint BF_SOFT = 0x1000;
        public const uint BF_ADJUST = 0x2000;
        public const uint BF_FLAT = 0x4000;
        public const uint BF_MONO = 0x8000;
    }
}
