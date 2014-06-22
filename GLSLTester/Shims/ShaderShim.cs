using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLSLTester.Shims
{
    [Serializable()]
    class ShaderShim
    {
        public OpenTK.Graphics.OpenGL.ShaderType ShaderType { get; set; }
        public Dictionary<string, string> DefaultShaderStrings { get; set; }
        public string ShaderString { get; set; }

        public ShaderShim()
        {
            ShaderType = 0;
            DefaultShaderStrings = new Dictionary<string, string>();
            ShaderString = string.Empty;
        }
    }
}
