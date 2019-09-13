using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint EDGE_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER);
        public const uint EDGE_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER);
        public const uint EDGE_ETCHED = (BDR_SUNKENOUTER | BDR_RAISEDINNER);
        public const uint EDGE_BUMP = (BDR_RAISEDOUTER | BDR_SUNKENINNER);
    }
}
