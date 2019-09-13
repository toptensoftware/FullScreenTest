using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint BDR_RAISEDOUTER = 0x0001;
        public const uint BDR_SUNKENOUTER = 0x0002;
        public const uint BDR_RAISEDINNER = 0x0004;
        public const uint BDR_SUNKENINNER = 0x0008;
        public const uint BDR_OUTER = (BDR_RAISEDOUTER | BDR_SUNKENOUTER);
        public const uint BDR_INNER = (BDR_RAISEDINNER | BDR_SUNKENINNER);
        public const uint BDR_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER);
        public const uint BDR_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER);
    }
}
