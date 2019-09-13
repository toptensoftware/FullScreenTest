using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const int KEY_QUERY_VALUE = (0x0001);
        public const int KEY_SET_VALUE = (0x0002);
        public const int KEY_CREATE_SUB_KEY = (0x0004);
        public const int KEY_ENUMERATE_SUB_KEYS = (0x0008);
        public const int KEY_NOTIFY = (0x0010);
        public const int KEY_CREATE_LINK = (0x0020);
        public const int KEY_WOW64_32KEY = (0x0200);
        public const int KEY_WOW64_64KEY = (0x0100);
        public const int KEY_WOW64_RES = (0x0300);
        public const int KEY_READ = ((STANDARD_RIGHTS_READ | KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY) & ~SYNCHRONIZE);
        public const int KEY_WRITE = ((STANDARD_RIGHTS_WRITE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY) & ~SYNCHRONIZE);
        public const int KEY_EXECUTE = ((KEY_READ) & (~SYNCHRONIZE));
        public const int KEY_ALL_ACCESS = ((STANDARD_RIGHTS_ALL | KEY_QUERY_VALUE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY | KEY_CREATE_LINK) & (~SYNCHRONIZE));


        public const int READ_CONTROL = (0x00020000);
        public const int SYNCHRONIZE = (0x00100000);
        public const int STANDARD_RIGHTS_READ = (READ_CONTROL);
        public const int STANDARD_RIGHTS_WRITE = (READ_CONTROL);
        public const int STANDARD_RIGHTS_EXECUTE = (READ_CONTROL);
        public const int STANDARD_RIGHTS_ALL = (0x001F0000);
    }
}
