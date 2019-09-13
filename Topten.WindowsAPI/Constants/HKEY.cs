using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public static UIntPtr HKEY_CLASSES_ROOT = (UIntPtr)0x80000000;
        public static UIntPtr HKEY_CURRENT_USER = (UIntPtr)0x80000001;
        public static UIntPtr HKEY_LOCAL_MACHINE = (UIntPtr)0x80000002;
        public static UIntPtr HKEY_USERS = (UIntPtr)0x80000003;
        public static UIntPtr HKEY_PERFORMANCE_DATA = (UIntPtr)0x80000004;
        public static UIntPtr HKEY_PERFORMANCE_TEXT = (UIntPtr)0x80000050;
        public static UIntPtr HKEY_PERFORMANCE_NLSTEXT = (UIntPtr)0x80000060;
        public static UIntPtr HKEY_CURRENT_CONFIG = (UIntPtr)0x80000005;
        public static UIntPtr HKEY_DYN_DATA = (UIntPtr)0x80000006;
        public static UIntPtr HKEY_CURRENT_USER_LOCAL_SETTINGS = (UIntPtr)0x80000007;
    }
}
