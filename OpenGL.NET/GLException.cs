using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGL
{
    public class GLException : Exception
    {
        public GLException(int code, string message) : base(message)
        {
            GLError = code;
        }

        public int GLError;
    }
}
