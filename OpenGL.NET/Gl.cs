using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenGL
{
    public static partial class Gl
    {
        [ThreadStatic]
        static Bindings _bindings;

        internal static void MakeCurrent(Bindings bindings)
        {
            _bindings = bindings;
        }

        public static void ThrowIfError()
        {
            var code = GetError();
            if (code != 0)
            {
                throw new GLException(code, string.Format("OpenGL error: {0}", code));
            }
        }

        public static int GetError()
        {
            return _bindings.glGetError();
        }

        [Conditional("DEBUG")]
        static void CheckCurrent()
        {
            if (_bindings == null)
            {
                throw new InvalidOperationException("No active Gl binding set");
            }
        }

        [Conditional("DEBUG")]
        static void CheckError()
        {
            int error = GetError();
            if (error != 0)
            {
                throw new InvalidOperationException(string.Format("OpenGL error {0}", error));
            }
        }

        public static string GetString(StringName id)
        {
            CheckCurrent();
            var retv = Marshal.PtrToStringAnsi(_bindings.glGetString((uint)id));
            CheckError();
            return retv;
        }

        public static void Flush()
        {
            CheckCurrent();
            _bindings.glFlush();
            CheckError();
        }

        public static void ColorMask(bool red, bool green, bool blue, bool alpha)
        {
            CheckCurrent();
            _bindings.glColorMask(red, green, blue, alpha);
            CheckError();
        }

        public static void ClearColor(float red, float green, float blue, float alpha)
        {
            CheckCurrent();
            _bindings.glClearColor(red, green, blue, alpha);
            CheckError();
        }

        public static void Clear(ClearBufferMask mask)
        {
            CheckCurrent();
            _bindings.glClear((uint)mask);
            CheckError();
        }

        public static void Viewport(int x, int y, int width, int height)
        {
            CheckCurrent();
            _bindings.glViewport(x, y, width, height);
            CheckError();
        }


        public static void Enable(EnableCap cap)
        {
            CheckCurrent();
            _bindings.glEnable((uint)cap);
            CheckError();
        }

        public static void Disable(EnableCap cap)
        {
            CheckCurrent();
            _bindings.glDisable((uint)cap);
            CheckError();
        }

        public static void BlendFunc(BlendingFactor sfactor, BlendingFactor dfactor)
        {
            CheckCurrent();
            _bindings.glBlendFunc((uint)sfactor, (uint)dfactor);
            CheckError();
        }

        public static void DepthFunc(DepthFunction op)
        {
            CheckCurrent();
            _bindings.glDepthFunc((uint)op);
            CheckError();
        }

        public static void DepthRange(double near, double far)
        {
            CheckCurrent();
            _bindings.glDepthRange(near, far);
            CheckError();
        }

        public static void PolygonMode(MaterialFace face, PolygonMode mode)
        {
            CheckCurrent();
            _bindings.glPolygonMode((int)face, (int)mode);
            CheckError();
        }

        public static void CullFace(CullFaceMode face)
        {
            CheckCurrent();
            _bindings.glCullFace((int)face);
            CheckError();
        }

        public static void FrontFace(FrontFaceDirection winding)
        {
            CheckCurrent();
            _bindings.glFrontFace((int)winding);
            CheckError();
        }

        public static void Get(GetPName pname, out int val)
        {
            CheckCurrent();
            _bindings.glGetIntegerv((uint)pname, out val);
            CheckError();
        }

        public static uint CreateShader(ShaderType type)
        {
            CheckCurrent();
            uint retv = _bindings.glCreateShader((uint)type);
            CheckError();
            return retv;
        }

        public static void ShaderSource(uint shader, Int32 count, String[] srcs, IntPtr lengths)
        {
            CheckCurrent();
            _bindings.glShaderSource(shader, count, srcs, lengths);
            CheckError();
        }

        public static void ShaderSource(uint shader, string[] srcs)
        {
            CheckCurrent();
            unsafe
            {
                ShaderSource(shader, srcs.Length, (String[])srcs, IntPtr.Zero);
            }
            CheckError();
        }

        public static void GetShaderInfoLog(uint shader, int bufSize, out int length, StringBuilder infoLog)
        {
            CheckCurrent();
            _bindings.glGetShaderInfoLog(shader, bufSize, out length, infoLog);
            CheckError();
        }

        public static void GetProgramInfoLog(uint shader, int bufSize, out int length, StringBuilder infoLog)
        {
            CheckCurrent();
            _bindings.glGetProgramInfoLog(shader, bufSize, out length, infoLog);
        }

        public static void DeleteShader(uint shader)
        {
            CheckCurrent();
            _bindings.glDeleteShader(shader);
            CheckError();
        }

        public static void GetShader(uint shader, ShaderParameterName pname, out int val)
        {
            CheckCurrent();
            _bindings.glGetShaderiv(shader, (int)pname, out val);
            CheckError();
        }


        public static void GetProgram(uint program, ProgramProperty pname, out int val)
        {
            CheckCurrent();
            _bindings.glGetProgramiv(program, (int)pname, out val);
            CheckError();
        }

        public static void CompileShader(uint shader)
        {
            CheckCurrent();
            _bindings.glCompileShader(shader);
            CheckError();
        }

        public static uint GetUniformBlockIndex(uint program, string name)
        {
            CheckCurrent();
            var retv = _bindings.glGetUniformBlockIndex(program, name);
            CheckError();
            return retv;

        }
        public static void UniformBlockBinding(uint program, uint index, uint binding)
        {
            CheckCurrent();
            _bindings.glUniformBlockBinding(program, index, binding);
            CheckError();

        }

        public static int GetUniformLocation(uint program, string name)
        {
            CheckCurrent();
            var retv = _bindings.glGetUniformLocation(program, name);
            CheckError();
            return retv;
        }

        public static int GetAttribLocation(uint program, string name)
        {
            CheckCurrent();
            int retv = _bindings.glGetAttribLocation(program, name);
            CheckError();
            return retv;
        }

        public static void BindAttribLocation(uint program, uint index, string name)
        {
            CheckCurrent();
            _bindings.glBindAttribLocation(program, index, name);
            CheckError();
        }

        public static uint CreateProgram()
        {
            CheckCurrent();
            var retv = _bindings.glCreateProgram();
            CheckError();
            return retv;
        }

        public static void AttachShader(uint program, uint shader)
        {
            CheckCurrent();
            _bindings.glAttachShader(program, shader);
            CheckError();
        }

        public static void BindFragDataLocation(uint program, uint colorNumber, string name)
        {
            CheckCurrent();
            _bindings.glBindFragDataLocation(program, colorNumber, name);
            CheckError();
        }

        public static void LinkProgram(uint program)
        {
            CheckCurrent();
            _bindings.glLinkProgram(program);
            CheckError();
        }

        public static void Uniform1(int location, int x)
        {
            CheckCurrent();
            _bindings.glUniform1i(location, x);
            CheckError();
        }

        public static void Uniform1(int location, float x)
        {
            CheckCurrent();
            _bindings.glUniform1f(location, x);
            CheckError();
        }

        public static unsafe void Uniform1(int location, int count, float* ptr)
        {
            CheckCurrent();
            _bindings.glUniform1fv(location, count, (IntPtr)ptr);
            CheckError();
        }


        public static unsafe void Uniform2(int location, int count, float* ptr)
        {
            CheckCurrent();
            _bindings.glUniform2fv(location, count, (IntPtr)ptr);
            CheckError();
        }

        public static unsafe void Uniform3(int location, int count, float* ptr)
        {
            CheckCurrent();
            _bindings.glUniform3fv(location, count, (IntPtr)ptr);
            CheckError();
        }


        public static void Uniform1(int location, float[] value)
        {
            unsafe
            {
                fixed (float* p = value)
                {
                    Uniform1(location, value.Length, p);
                }
            }
        }
        public static void Uniform2(int location, float[] value)
        {
            unsafe
            {
                fixed (float* p = value)
                {
                    Uniform2(location, value.Length / 2, p);
                }
            }
        }
        public static void Uniform3(int location, float[] value)
        {
            unsafe
            {
                fixed (float* p = value)
                {
                    Uniform3(location, value.Length / 3, p);
                }
            }
        }


        public static void Uniform3(int location, float x, float y, float p)
        {
            CheckCurrent();
            _bindings.glUniform3f(location, x, y, p);
            CheckError();
        }

        public static void Uniform4(int location, float x, float y, float p, float q)
        {
            CheckCurrent();
            _bindings.glUniform4f(location, x, y, p, q);
            CheckError();
        }

        public static void UniformMatrix4(int location, bool transpose, float[] value)
        {
            CheckCurrent();
            unsafe
            {
                fixed (float* p = value)
                {
                    _bindings.glUniformMatrix4fv(location, 1, transpose, (IntPtr)p);
                }
            }
        }

        public static unsafe void UniformMatrix4(int location, int count, bool transpose, float* p)
        {
            CheckCurrent();
            _bindings.glUniformMatrix4fv(location, count, transpose, (IntPtr)p);
        }


        public static void UseProgram(uint program)
        {
            CheckCurrent();
            _bindings.glUseProgram(program);
            CheckError();
        }


        public static void DrawArrays(PrimitiveType mode, int first, int count)
        {
            CheckCurrent();
            _bindings.glDrawArrays((int)mode, first, count);
            CheckError();
        }

        public static void DrawArraysInstanced(PrimitiveType mode, int first, int count, int instancecount)
        {
            CheckCurrent();
            _bindings.glDrawArraysInstanced((int)mode, first, count, instancecount);
            CheckError();
        }

        public static void EnableVertexAttribArray(uint index)
        {
            CheckCurrent();
            _bindings.glEnableVertexAttribArray(index);
            CheckError();
        }

        public static void DisableVertexAttribArray(uint index)
        {
            CheckCurrent();
            _bindings.glDisableVertexAttribArray(index);
            CheckError();
        }


        public static void VertexAttribDivisor(uint indx, uint divisor)
        {
            CheckCurrent();
            _bindings.glVertexAttribDivisor(indx, divisor);
            CheckError();
        }

        public static void VertexAttribPointer(uint indx, int size, VertexAttribType type, bool normalized, int stride, IntPtr ptr)
        {
            CheckCurrent();
            _bindings.glVertexAttribPointer(indx, size, (int)type, normalized, stride, ptr);
            CheckError();
        }

        public static void VertexAttribPointer(uint indx, int size, VertexAttribType type, bool normalized, Type structType, string memberName)
        {
            CheckCurrent();
            _bindings.glVertexAttribPointer(indx, size, (int)type, normalized, Marshal.SizeOf(structType), (IntPtr)Marshal.OffsetOf(structType, memberName));
            CheckError();
        }

        public static void VertexAttribIPointer(uint indx, int size, VertexAttribType type, int stride, IntPtr ptr)
        {
            CheckCurrent();
            _bindings.glVertexAttribIPointer(indx, size, (int)type, stride, ptr);
            CheckError();
        }


        public static void DetachShader(uint program, uint shader)
        {
            CheckCurrent();
            _bindings.glDetachShader(program, shader);
            CheckError();
        }

        public static void ValidateProgram(uint program)
        {
            CheckCurrent();
            _bindings.glValidateProgram(program);
            CheckError();
        }

        public static void DeleteProgram(uint program)
        {
            CheckCurrent();
            _bindings.glDeleteProgram(program);
            CheckError();
        }

        public static void GenTextures(int count, UInt32[] Textures)
        {
            CheckCurrent();
            _bindings.glGenTextures(count, Textures);
            CheckError();
        }

        public static uint GenTexture()
        {
            var bufs = new uint[1];
            GenTextures(1, bufs);
            return bufs[0];
        }

        public static void DeleteTextures(params uint[] Textures)
        {
            CheckCurrent();
            unsafe
            {
                fixed (uint* p = Textures)
                {
                    _bindings.glDeleteTextures(Textures.Length, (IntPtr)p);
                }
            }
            CheckError();
        }

        public static void GenBuffers(int count, UInt32[] buffers)
        {
            CheckCurrent();
            _bindings.glGenBuffers(count, buffers);
            CheckError();
        }

        public static uint GenBuffer()
        {
            var bufs = new uint[1];
            GenBuffers(1, bufs);
            return bufs[0];
        }

        public static void DeleteBuffers(params uint[] buffers)
        {
            CheckCurrent();
            unsafe
            {
                fixed (uint* p = buffers)
                {
                    _bindings.glDeleteBuffers(buffers.Length, (IntPtr)p);
                }
            }
            CheckError();
        }

        public static void BindBufferRange(BufferTarget target, uint index, uint buffer, IntPtr offset, uint size)
        {
            CheckCurrent();
            _bindings.glBindBufferRange((int)target, index, buffer, offset, size);
            CheckError();
        }


        public static void BindBuffer(BufferTarget index, uint buffer)
        {
            CheckCurrent();
            _bindings.glBindBuffer((int)index, buffer);
            CheckError();
        }

        public static void BufferData(BufferTarget target, uint size, IntPtr data, BufferUsage usage)
        {
            CheckCurrent();
            _bindings.glBufferData((int)target, size, data, (int)usage);
            CheckError();
        }

        public static void BufferSubData(BufferTarget target, IntPtr offset, uint size, IntPtr data)
        {
            CheckCurrent();
            _bindings.glBufferSubData((int)target, offset, size, data);
            CheckError();
        }

        public static void GenVertexArrays(int count, UInt32[] VertexArrays)
        {
            CheckCurrent();
            _bindings.glGenVertexArrays(count, VertexArrays);
            CheckError();
        }

        public static uint GenVertexArray()
        {
            var bufs = new uint[1];
            GenVertexArrays(1, bufs);
            return bufs[0];
        }

        public static void DeleteVertexArrays(params uint[] VertexArrays)
        {
            CheckCurrent();
            unsafe
            {
                fixed (uint* p = VertexArrays)
                {
                    _bindings.glDeleteVertexArrays(VertexArrays.Length, (IntPtr)p);
                }
            }
            CheckError();
        }

        public static void BindVertexArray(uint VertexArray)
        {
            CheckCurrent();
            _bindings.glBindVertexArray(VertexArray);
            CheckError();
        }


        public static void GenFramebuffers(int count, UInt32[] Framebuffers)
        {
            //CheckCurrent();
            _bindings.glGenFramebuffers(count, Framebuffers);
        }

        public static uint GenFramebuffer()
        {
            var bufs = new uint[1];
            GenFramebuffers(1, bufs);
            return bufs[0];
        }

        public static void DeleteFramebuffers(params uint[] Framebuffers)
        {
            CheckCurrent();
            unsafe
            {
                fixed (uint* p = Framebuffers)
                {
                    _bindings.glDeleteFramebuffers(Framebuffers.Length, (IntPtr)p);
                }
            }
            CheckError();
        }

        public static void ReadBuffer(ReadBufferMode mode)
        {
            CheckCurrent();
            _bindings.glReadBuffer((int)mode);
            CheckError();
        }
        public static void DrawBuffer(ReadBufferMode mode)
        {
            CheckCurrent();
            _bindings.glDrawBuffer((int)mode);
            CheckError();
        }

        public static void BindFramebuffer(FramebufferTarget target, uint Framebuffer)
        {
            CheckCurrent();
            _bindings.glBindFramebuffer((int)target, Framebuffer);
            CheckError();
        }

        public static void StencilOp(StencilOp sfail, StencilOp dpfail, StencilOp dppass)
        {
            CheckCurrent();
            _bindings.glStencilOp((int)sfail, (int)dpfail, (int)dppass);
            CheckError();
        }

        public static void StencilFunc(StencilFunction func, int value, uint mask)
        {
            CheckCurrent();
            _bindings.glStencilFunc((int)func, (IntPtr)value, mask);
            CheckError();
        }

        public static void DepthMask(bool flag)
        {
            CheckCurrent();
            _bindings.glDepthMask(flag);
            CheckError();
        }

        public static void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, ClearBufferMask mask, BlitFramebufferFilter filter)
        {
            CheckCurrent();
            _bindings.glBlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, (uint)mask, (int)filter);
            CheckError();
        }

        public static void FramebufferTexture(FramebufferTarget target, FramebufferAttachment attachment, uint texture, int level)
        {
            CheckCurrent();
            _bindings.glFramebufferTexture((int)target, (int)attachment, texture, level);
            CheckError();
        }

        public static void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget textarget, uint texture, int level)
        {
            CheckCurrent();
            _bindings.glFramebufferTexture2D((int)target, (int)attachment, (int)textarget, texture, level);
            CheckError();
        }

        public static FramebufferStatus CheckFramebufferStatus(FramebufferTarget target)
        {
            CheckCurrent();
            var retv = (FramebufferStatus)_bindings.glCheckFramebufferStatus((int)target);
            CheckError();
            return retv;
        }

        public static void PixelStore(PixelStoreParameter pname, int param)
        {
            CheckCurrent();
            _bindings.glPixelStorei((uint)pname, param);
            CheckError();
        }

        public static void BindTexture(TextureTarget target, uint texture)
        {
            CheckCurrent();
            _bindings.glBindTexture((uint)target, texture);
            CheckError();
        }

        public static void TexParameter(TextureTarget target, TextureParameterName pname, int param)
        {
            CheckCurrent();
            _bindings.glTexParameteri((uint)target, (uint)pname, param);
            CheckError();
        }

        public static void TexImage2D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels)
        {
            CheckCurrent();
            _bindings.glTexImage2D((uint)target, level, (int)internalformat, (IntPtr)width, (IntPtr)height, border, (int)format, (int)type, pixels);
            CheckError();
        }

        public static void TexSubImage2D(TextureTarget target, int level, int xoffset, int yoffset, int width, int height, PixelFormat format, PixelType type, IntPtr pixels)
        {
            CheckCurrent();
            _bindings.glTexSubImage2D((uint)target, level, xoffset, yoffset, (IntPtr)width, (IntPtr)height, (int)format, (int)type, pixels);
            CheckError();
        }

        public static void GenerateMipmap(TextureTarget target)
        {
            CheckCurrent();
            _bindings.glGenerateMipmap((int)target);
            CheckError();
        }

        public static void TexImage2DMultisample(TextureTarget target, int samples, InternalFormat internalformat, int width, int height, bool fixedsamplelocations)
        {
            CheckCurrent();
            _bindings.glTexImage2DMultisample((int)target, samples, (int)internalformat, (IntPtr)width, (IntPtr)height, fixedsamplelocations);
            CheckError();
        }

        public static void TexImage3D(TextureTarget target, int level, InternalFormat internalformat, int width, int height, int depth, int border, PixelFormat format, PixelType type, IntPtr pixels)
        {
            CheckCurrent();
            _bindings.glTexImage3D((uint)target, level, (int)internalformat, (IntPtr)width, (IntPtr)height, (IntPtr)depth, border, (int)format, (int)type, pixels);
            CheckError();
        }

        public static void TexSubImage3D(TextureTarget target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, PixelFormat format, PixelType type, IntPtr pixels)
        {
            CheckCurrent();
            _bindings.glTexSubImage3D((uint)target, level, xoffset, yoffset, zoffset, (IntPtr)width, (IntPtr)height, (IntPtr)depth, (int)format, (int)type, pixels);
            CheckError();
        }

        public static void ReadPixels(int x, int y, int width, int height, PixelFormat format, PixelType type, IntPtr pixels)
        {
            CheckCurrent();
            _bindings.glReadPixels(x, y, width, height, (int)format, (int)type, pixels);
            CheckError();
        }

        public static void GetTexImage(TextureTarget target, int level, PixelFormat format, PixelType type, IntPtr pixels)
        {
            CheckCurrent();
            _bindings.glGetTexImage((uint)target, level, (int)format, (int)type, pixels);
            CheckError();
        }

        public static void GetTexLevelParameter(TextureTarget target, int level, GetTextureParameter pname, out int val)
        {
            CheckCurrent();
            _bindings.glGetTexLevelParameteriv((uint)target, level, (int)pname, out val);
            CheckError();
        }

        public static void ActiveTexture(TextureUnit texture)
        {
            CheckCurrent();
            _bindings.glActiveTexture((int)texture);
            CheckError();
        }


        public static int GenRenderbuffers(int count, UInt32[] buffers)
        {
            CheckCurrent();
            int retv = _bindings.glGenRenderbuffers(count, buffers);
            CheckError();
            return retv;
        }

        public static uint GenRenderbuffer()
        {
            var bufs = new uint[1];
            GenRenderbuffers(1, bufs);
            return bufs[0];
        }

        public static void DeleteRenderbuffers(params uint[] renderbuffers)
        {
            CheckCurrent();
            unsafe
            {
                fixed (uint* p = renderbuffers)
                {
                    _bindings.glDeleteRenderbuffers(renderbuffers.Length, (IntPtr)p);
                }
            }
            CheckError();
        }


        public static int BindRenderbuffer(int target, uint renderbuffer)
        {
            CheckCurrent();
            int retv = _bindings.glBindRenderbuffer(target, renderbuffer);
            CheckError();
            return retv;
        }

        public static void RenderbufferStorage(int target, int internalformat, int width, int height)
        {
            CheckCurrent();
            _bindings.glRenderbufferStorage(target, internalformat, width, height);
            CheckError();
        }


        public static void FramebufferRenderbuffer(int target, int attachment, int renderbuffertarget, uint renderbuffer)
        {
            CheckCurrent();
            _bindings.glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);
            CheckError();
        }


        public static void DrawBuffers(params int[] bufs)
        {
            CheckCurrent();
            unsafe
            {
                fixed (int* p = bufs)
                {
                    _bindings.glDrawBuffers(bufs.Length, (IntPtr)p);
                }
            }
            CheckError();
        }


    }

}
