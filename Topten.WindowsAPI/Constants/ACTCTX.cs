using System;
using System.Collections.Generic;
using System.Text;

namespace Topten.WindowsAPI
{
    public static partial class WinApi
    {
        public const uint ACTCTX_PROCESSOR_ARCHITECTURE_VALID = 0x001;
        public const uint ACTCTX_LANGID_VALID = 0x002;
        public const uint ACTCTX_ASSEMBLY_DIRECTORY_VALID = 0x004;
        public const uint ACTCTX_RESOURCE_NAME_VALID = 0x008;
        public const uint ACTCTX_SET_PROCESS_DEFAULT = 0x010;
        public const uint ACTCTX_APPLICATION_NAME_VALID = 0x020;
    }
}
