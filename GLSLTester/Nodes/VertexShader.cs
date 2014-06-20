using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Nodes
{
    [DisplayOrderAttribute(0), ExecutionOrderAttribute(int.MinValue)]
    class VertexShader : Shims.ShaderShim, INode
    {
        Controls.Editors.ShaderEditor editor;

        public VertexShader()
        {
            editor = new Controls.Editors.ShaderEditor() { Dock = System.Windows.Forms.DockStyle.Fill };

            ShaderType = OpenTK.Graphics.OpenGL.ShaderType.VertexShader;
            ShaderString = (DefaultShaderStrings = GLSL.DefaultVertexShaders)["Default"];

            GLSL.CompileShader(ShaderType, ShaderString);
        }

        public void AutoSetNodeName(int number) { /* Not used */ }
        public string GetNodeTypeName() { return "Vertex Shader"; }
        public string GetDescription() { return "GLSL vertex shader"; }
        public string GetIconKey() { return "EditCodeHS"; }
        public string GetNodeInstanceName() { return string.Empty; }
        public Controls.Editors.IEditorControl GetEditorControl() { return editor; }

        public void Execute()
        {
            GL.UseProgram(GLSL.ShaderProgramID);
        }

        public void Dispose()
        {
            GLSL.DeleteShader(OpenTK.Graphics.OpenGL.ShaderType.VertexShader);
        }
    }
}
