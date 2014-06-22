using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Nodes
{
    [DisplayOrderAttribute(4), ExecutionOrderAttribute(0), Serializable()]
    class Color : INode
    {
        [NonSerialized()]
        Controls.Editors.ColorEditor editor;

        string defaultName;
        int number;

        public string NodeName { get; set; }
        public System.Drawing.Color ColorValue { get; set; }

        public Color()
        {
            CreateEditorControl();

            defaultName = "colorUniform";
            AutoSetNodeName(number = 0);

            ColorValue = System.Drawing.Color.White;
        }

        public void AutoSetNodeName(int number) { this.number = number; NodeName = string.Format("{0}{1}", defaultName, this.number); }
        public string GetNodeTypeName() { return "Color Uniform"; }
        public string GetDescription() { return "Color (vec4) uniform node\nDefine in shader via \"uniform vec4 <NodeName>;\""; }
        public string GetIconKey() { return "ColorHS"; }
        public string GetNodeInstanceName() { return NodeName; }

        public void CreateEditorControl() { editor = new Controls.Editors.ColorEditor() { Dock = System.Windows.Forms.DockStyle.Fill }; }
        public Controls.Editors.IEditorControl GetEditorControl() { return editor; }

        public void Execute()
        {
            GL.Uniform4(GL.GetUniformLocation(GLSL.ShaderProgramID, NodeName), ColorValue);
        }

        public void Dispose()
        {
            //
        }
    }
}
