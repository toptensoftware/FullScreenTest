using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const int PBT_APMQUERYSUSPEND = 0x0000;
        public const int PBT_APMQUERYSTANDBY = 0x0001;
        public const int PBT_APMQUERYSUSPENDFAILED = 0x0002;
        public const int PBT_APMQUERYSTANDBYFAILED = 0x0003;
        public const int PBT_APMSUSPEND = 0x0004;
        public const int PBT_APMSTANDBY = 0x0005;
        public const int PBT_APMRESUMECRITICAL = 0x0006;
        public const int PBT_APMRESUMESUSPEND = 0x0007;
        public const int PBT_APMRESUMESTANDBY = 0x0008;
        public const int PBT_APMBATTERYLOW = 0x0009;
        public const int PBT_APMPOWERSTATUSCHANGE = 0x000A;
        public const int PBT_APMOEMEVENT = 0x000B;
        public const int PBT_APMRESUMEAUTOMATIC = 0x0012;
    }
}
