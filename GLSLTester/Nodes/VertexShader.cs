using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Nodes
{
    [DisplayOrderAttribute(0), ExecutionOrderAttribute(int.MinValue), SerializableAttribute()]
    class VertexShader : Shims.ShaderShim, INode
    {
        [NonSerialized()]
        Controls.Editors.ShaderEditor editor;

        Guid guid;

        public VertexShader()
        {
            CreateEditorControl();

            ShaderType = OpenTK.Graphics.OpenGL.ShaderType.VertexShader;
            ShaderString = (DefaultShaderStrings = GLSL.DefaultVertexShaders)["Default"];

            guid = Guid.NewGuid();

            GLSL.CompileShader(ShaderType, ShaderString);
        }

        public VertexShader(System.Xml.XmlElement element)
        {
            CreateEditorControl();

            ShaderType = (OpenTK.Graphics.OpenGL.ShaderType)Enum.Parse(typeof(OpenTK.Graphics.OpenGL.ShaderType), element.GetAttribute("ShaderType"));
            DefaultShaderStrings = GLSL.DefaultVertexShaders;

            string shader = string.Empty;
            string[] shaderSplit = element.InnerText.Split('-');
            foreach (string stringVal in shaderSplit)
            {
                byte val = Convert.ToByte(stringVal, 16);
                shader += (char)val;
            }
            ShaderString = shader;

            guid = Guid.NewGuid();

            GLSL.CompileShader(ShaderType, ShaderString);
        }

        public Guid GetGuid() { return guid; }

        public void AutoSetNodeName(int number) { /* Not used */ }
        public string GetNodeTypeName() { return "Vertex Shader"; }
        public string GetDescription() { return "GLSL vertex shader"; }
        public string GetIconKey() { return "EditCodeHS"; }
        public string GetNodeInstanceName() { return string.Empty; }

        public void CreateEditorControl() { editor = new Controls.Editors.ShaderEditor() { Dock = System.Windows.Forms.DockStyle.Fill }; }
        public Controls.Editors.IEditorControl GetEditorControl() { return editor; }

        public void Execute()
        {
            GL.UseProgram(GLSL.ShaderProgramID);
        }

        public void StoreSettings(System.Xml.XmlDocument doc)
        {
            System.Xml.XmlElement element = doc.CreateElement(this.GetType().Name);

            element.SetAttribute("Guid", this.guid.ToString());
            element.SetAttribute("ShaderType", this.ShaderType.ToString());

            byte[] data = Encoding.UTF8.GetBytes(this.ShaderString);
            element.InnerText = BitConverter.ToString(data);

            doc.DocumentElement.AppendChild(element);
        }

        public void Dispose()
        {
            GLSL.DeleteShader(OpenTK.Graphics.OpenGL.ShaderType.VertexShader);
        }
    }
}
