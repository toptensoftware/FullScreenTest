using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullScreenTest
{
	internal class Shader : GlContextObject
	{
		public Shader(ShaderType type, string source)
		{
            var shaderLanguageVersion = Gl.GetString(StringName.ShadingLanguageVersion);

            if (Environment.OSVersion.Platform == PlatformID.MacOSX)
                source = string.Format("#version {0}\n{1}", shaderLanguageVersion.Replace(".", ""), source);

			_type = type;
			_source = source;

            // Compile
            _shaderHandle = Gl.CreateShader(type);
            Gl.ShaderSource(_shaderHandle, new string[] { _source });
            Gl.CompileShader(_shaderHandle);


            // Get the log
            int logLen;
            Gl.GetShader(_shaderHandle, ShaderParameterName.InfoLogLength, out logLen);

            // Anything in the log?
            string log = "n/a";
            if (logLen > 0)
            {
                var infolog = new StringBuilder(logLen + 10);
                int infologLength;
                Gl.GetShaderInfoLog(_shaderHandle, logLen + 10, out infologLength, infolog);

                log = infolog.ToString();

                if (!string.IsNullOrEmpty(log))
                    Console.WriteLine("Shader compile log:\n{0}", log);
            }

            // Success?
            int status;
            Gl.GetShader(_shaderHandle, ShaderParameterName.CompileStatus, out status);
            if (status != 0)        // Returns GL_TRUE if successful
                return;

            // Delete it
            Gl.DeleteShader(_shaderHandle);
            _shaderHandle = 0;

            throw new InvalidOperationException(string.Format("Compilation of shader failed - {0}", log));
        }

        public override void Dispose()
        {
            if (_shaderHandle != 0)
            {
                CheckCurrent();
                Gl.DeleteShader(_shaderHandle);
                _shaderHandle = 0;
            }
            base.Dispose();
        }

        ShaderType _type;
		string _source;
		uint _shaderHandle;	
		
		public uint ShaderHandle
		{
			get
			{
                System.Diagnostics.Debug.Assert(_shaderHandle != 0);
				return _shaderHandle;
			}
		}
		
    }
}
