using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester
{
    internal class GLSL
    {
        static int vertexShaderId, fragmentShaderId, shaderProgramId;
        static string lastVertexShaderString, lastFragmentShaderString;

        public static int VertexShaderID { get { return vertexShaderId; } }
        public static int FragmentShaderID { get { return fragmentShaderId; } }
        public static int ShaderProgramID { get { return shaderProgramId; } }

        public static Dictionary<string, string> DefaultVertexShaders { get; private set; }
        public static Dictionary<string, string> DefaultFragmentShaders { get; private set; }

        static GLSL()
        {
            string shaderPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Data");

            DefaultVertexShaders = new Dictionary<string, string>();
            List<string> vertexShaders = Directory.EnumerateFiles(shaderPath, "*.vert").Distinct().ToList();

            foreach (string vertexShader in vertexShaders)
            {
                using (StreamReader reader = File.OpenText(vertexShader))
                {
                    DefaultVertexShaders[Path.GetFileNameWithoutExtension(vertexShader)] = reader.ReadToEnd();
                }
            }

            DefaultFragmentShaders = new Dictionary<string, string>();
            List<string> fragmentShaders = Directory.EnumerateFiles(shaderPath, "*.frag").Distinct().ToList();

            foreach (string fragmentShader in fragmentShaders)
            {
                using (StreamReader reader = File.OpenText(fragmentShader))
                {
                    DefaultFragmentShaders[Path.GetFileNameWithoutExtension(fragmentShader)] = reader.ReadToEnd();
                }
            }

            vertexShaderId = fragmentShaderId = -1;
        }

        public static bool CompileVertexShader(string shaderString)
        {
            return CompileShader(ShaderType.VertexShader, ref vertexShaderId, shaderString);
        }

        public static bool CompileFragmentShader(string shaderString)
        {
            return CompileShader(ShaderType.FragmentShader, ref fragmentShaderId, shaderString);
        }

        public static bool CompileShader(ShaderType type, string shaderString)
        {
            if (type == ShaderType.VertexShader) return CompileShader(type, ref vertexShaderId, shaderString);
            else if (type == ShaderType.FragmentShader) return CompileShader(type, ref fragmentShaderId, shaderString);
            else throw new Exception("Unsupported shader type");
        }

        public static bool CompileShader(ShaderType type, ref int shaderId, string shaderString)
        {
            if (type != ShaderType.VertexShader && type != ShaderType.FragmentShader) throw new Exception("Unsupported shader type");

            int newShaderId = -1, newShaderProgramId = -1;
            string shaderTypeString = (type == ShaderType.VertexShader ? "Vertex shader" : (type == ShaderType.FragmentShader) ? "Fragment shader" : null);

            try
            {
                if (type == ShaderType.VertexShader)
                {
                    Aglex.GLSL.CreateVertexShader(ref newShaderId, shaderString);
                    Aglex.GLSL.CreateProgram(ref newShaderProgramId, fragmentShaderId, newShaderId);
                }
                else if (type == ShaderType.FragmentShader)
                {
                    Aglex.GLSL.CreateFragmentShader(ref newShaderId, shaderString);
                    Aglex.GLSL.CreateProgram(ref newShaderProgramId, newShaderId, vertexShaderId);
                }

                if (GL.IsShader(shaderId)) GL.DeleteShader(shaderId);
                if (GL.IsProgram(shaderProgramId)) GL.DeleteProgram(shaderProgramId);

                shaderId = newShaderId;
                shaderProgramId = newShaderProgramId;

                if (type == ShaderType.VertexShader) lastVertexShaderString = shaderString;
                else if (type == ShaderType.FragmentShader) lastFragmentShaderString = shaderString;

                GL.DetachShader(shaderProgramId, shaderId);

                return true;
            }
            catch (Aglex.AglexException aEx)
            {
                MessageBox.Show(aEx.Message, "Shader Compilation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (GL.IsShader(newShaderId)) GL.DeleteShader(newShaderId);
                if (GL.IsProgram(newShaderProgramId)) GL.DeleteProgram(newShaderProgramId);

                return false;
            }
        }

        public static void DeleteShader(ShaderType type)
        {
            if (type == ShaderType.VertexShader)
            {
                if (GL.IsShader(vertexShaderId))
                {
                    GL.DeleteShader(vertexShaderId);
                    vertexShaderId = -1;
                    lastVertexShaderString = string.Empty;
                    if (lastFragmentShaderString != string.Empty) CompileFragmentShader(lastFragmentShaderString);
                }
            }
            else if (type == ShaderType.FragmentShader)
            {
                if (GL.IsShader(fragmentShaderId))
                {
                    GL.DeleteShader(fragmentShaderId);
                    fragmentShaderId = -1;
                    lastFragmentShaderString = string.Empty;
                    if (lastVertexShaderString != string.Empty) CompileVertexShader(lastVertexShaderString);
                }
            }
            else throw new Exception("Unsupported shader type");
        }
    }
}
