using OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullScreenTest
{
	public class ShaderProgram : GlContextObject
	{
		public ShaderProgram(string vertexShaderSource, string fragmentShaderSource)
		{
			_vertexShader = new Shader(ShaderType.VertexShader, vertexShaderSource);
			_fragmentShader = new Shader(ShaderType.FragmentShader, fragmentShaderSource);
            LinkProgram();
		}

		public int GetUniformLocation(string name)
		{
            CheckCurrent();
            return Gl.GetUniformLocation(Handle, name);
		}
		
		public uint GetAttribLocation(string name)
		{
            CheckCurrent();
            return (uint)Gl.GetAttribLocation(Handle, name);
		}

		Shader _vertexShader;
		Shader _fragmentShader;
		uint _programHandle;
		
		public uint Handle
		{
			get
			{
				return _programHandle;
			}
		}
		
		public void LinkProgram()
		{
			if (_programHandle==0)
			{
				_programHandle = LinkProgramInternal();
			}
		}
		
		uint LinkProgramInternal()
		{
            CheckCurrent();

            // Create shader program.
            var programHandle = Gl.CreateProgram();
			
			// Attach shaders
			Gl.AttachShader(programHandle, _vertexShader.ShaderHandle);
			Gl.AttachShader(programHandle, _fragmentShader.ShaderHandle);

			// Link the program
			Gl.LinkProgram(programHandle);

            // Get the log
            int logLen;
            Gl.GetProgram(programHandle, ProgramProperty.InfoLogLength, out logLen);

            // Anything in the log?
            string log = "n/a";
            if (logLen > 0)
            {
                var infolog = new StringBuilder(logLen + 10);
                int infologLength;
                Gl.GetProgramInfoLog(programHandle, logLen + 10, out infologLength, infolog);

                log = infolog.ToString();

                if (!string.IsNullOrEmpty(log))
                    Console.WriteLine("Program link log:\n{0}", log);
            }

            // Detach shaders now that we've linked the program
            Gl.DetachShader(programHandle, _vertexShader.ShaderHandle);
            Gl.DetachShader(programHandle, _fragmentShader.ShaderHandle);


            int status;
            Gl.GetProgram(programHandle, ProgramProperty.LinkStatus, out status);
			if (status == 0)
			{
				throw new InvalidOperationException(string.Format("Failed to link shader program: {0}", log));
			}
			
			return programHandle;
		}
		
		public void ValidateProgram()
		{
            CheckCurrent();

            Gl.ValidateProgram(_programHandle);

            // Get the log
            int logLen;
            Gl.GetProgram(_programHandle, ProgramProperty.InfoLogLength, out logLen);

            // Anything in the log?
            string log = "n/a";
            if (logLen > 0)
            {
                var infolog = new StringBuilder(logLen + 10);
                int infologLength;
                Gl.GetProgramInfoLog(_programHandle, logLen + 10, out infologLength, infolog);

                log = infolog.ToString();

                Console.WriteLine("Program validate log:\n{0}", log);
            }


            int status;
            Gl.GetProgram(_programHandle, ProgramProperty.LinkStatus, out status);
			if (status == 0)
				throw new InvalidOperationException("Shader program failed to validate - check log for details");
		}
		
		#region IDisposable implementation
		public override void Dispose()
		{
			if (_vertexShader!=null)
			{
				_vertexShader.Dispose();
				_vertexShader = null;
			}
				
			if (_fragmentShader!=null)
			{
				_fragmentShader.Dispose();
				_fragmentShader = null;
			}

            if (_programHandle!=0)
			{
                CheckCurrent();
                Gl.DeleteProgram(_programHandle);
				_programHandle = 0;
			}

            base.Dispose();
		}
        #endregion

        public virtual void UseProgram()
        {
            // Active the program
            CheckCurrent();
            Gl.UseProgram(Handle);
        }
    }
}
