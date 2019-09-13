﻿using System.Runtime.InteropServices;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct VS_FIXEDFILEINFO
        {
            public uint dwSignature;            /* e.g. 0xfeef04bd */
            public uint dwStrucVersion;         /* e.g. 0x00000042 = "0.42" */
            public uint dwFileVersionMS;        /* e.g. 0x00030075 = "3.75" */
            public uint dwFileVersionLS;        /* e.g. 0x00000031 = "0.31" */
            public uint dwProductVersionMS;     /* e.g. 0x00030010 = "3.10" */
            public uint dwProductVersionLS;     /* e.g. 0x00000031 = "0.31" */
            public uint dwFileFlagsMask;        /* = 0x3F for version "0.42" */
            public uint dwFileFlags;            /* e.g. VFF_DEBUG | VFF_PRERELEASE */
            public uint dwFileOS;               /* e.g. VOS_DOS_WINDOWS16 */
            public uint dwFileType;             /* e.g. VFT_DRIVER */
            public uint dwFileSubtype;          /* e.g. VFT2_DRV_KEYBOARD */
            public uint dwFileDateMS;           /* e.g. 0 */
            public uint dwFileDateLS;           /* e.g. 0 */
        }
    }

}
