using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint TPM_LEFTBUTTON = 0x0000;
        public const uint TPM_RIGHTBUTTON = 0x0002;
        public const uint TPM_LEFTALIGN = 0x0000;
        public const uint TPM_CENTERALIGN = 0x0004;
        public const uint TPM_RIGHTALIGN = 0x0008;
        public const uint TPM_TOPALIGN = 0x0000;
        public const uint TPM_VCENTERALIGN = 0x0010;
        public const uint TPM_BOTTOMALIGN = 0x0020;
        public const uint TPM_HORIZONTAL = 0x0000;
        public const uint TPM_VERTICAL = 0x0040;
        public const uint TPM_NONOTIFY = 0x0080;
        public const uint TPM_RETURNCMD = 0x0100;
        public const uint TPM_RECURSE = 0x0001;
        public const uint TPM_HORPOSANIMATION = 0x0400;
        public const uint TPM_HORNEGANIMATION = 0x0800;
        public const uint TPM_VERPOSANIMATION = 0x1000;
        public const uint TPM_VERNEGANIMATION = 0x2000;
        public const uint TPM_NOANIMATION = 0x4000;
        public const uint TPM_LAYOUTRTL = 0x8000;
        public const uint TPM_WORKAREA = 0x10000;
    }
}
