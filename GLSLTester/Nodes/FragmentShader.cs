using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Nodes
{
    [DisplayOrderAttribute(1), ExecutionOrderAttribute(int.MinValue), IsNextSeparatorAttribute(true), Serializable()]
    class FragmentShader : Shims.ShaderShim, INode
    {
        Controls.Editors.ShaderEditor editor;

        Guid guid;

        public FragmentShader()
        {
            CreateEditorControl();

            ShaderType = OpenTK.Graphics.OpenGL.ShaderType.FragmentShader;
            ShaderString = (DefaultShaderStrings = GLSL.DefaultFragmentShaders)["Default"];

            guid = Guid.NewGuid();

            //GLSL.CompileShader(ShaderType, ShaderString);
        }

        public FragmentShader(System.Xml.XmlElement element)
        {
            CreateEditorControl();

            ShaderType = (OpenTK.Graphics.OpenGL.ShaderType)Enum.Parse(typeof(OpenTK.Graphics.OpenGL.ShaderType), element.GetAttribute("ShaderType"));
            DefaultShaderStrings = GLSL.DefaultFragmentShaders;

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
        public string GetNodeTypeName() { return "Fragment Shader"; }
        public string GetDescription() { return "GLSL fragment shader"; }
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
            GLSL.DeleteShader(OpenTK.Graphics.OpenGL.ShaderType.FragmentShader);
        }
    }
}
