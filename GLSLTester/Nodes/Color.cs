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
        Controls.Editors.ColorEditor editor;

        string defaultName;
        int number;
        Guid guid;

        public string NodeName { get; set; }
        public System.Drawing.Color ColorValue { get; set; }

        public Color()
        {
            CreateEditorControl();

            defaultName = "colorUniform";
            AutoSetNodeName(number = 0);

            guid = Guid.NewGuid();

            ColorValue = System.Drawing.Color.White;
        }

        public Color(System.Xml.XmlElement element)
        {
            CreateEditorControl();

            defaultName = "colorUniform";
            number = int.Parse(element.GetAttribute("Number"));
            NodeName = element.GetAttribute("NodeName");
            guid = Guid.Parse(element.GetAttribute("Guid"));

            ColorValue = System.Drawing.Color.FromArgb(
                int.Parse(element.GetAttribute("A")),
                int.Parse(element.GetAttribute("R")),
                int.Parse(element.GetAttribute("G")),
                int.Parse(element.GetAttribute("B")));
        }

        public Guid GetGuid() { return guid; }

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

        public void StoreSettings(System.Xml.XmlDocument doc)
        {
            System.Xml.XmlElement element = doc.CreateElement(this.GetType().Name);

            element.SetAttribute("Guid", this.guid.ToString());
            element.SetAttribute("NodeName", this.NodeName.ToString());
            element.SetAttribute("Number", this.number.ToString());

            element.SetAttribute("R", this.ColorValue.R.ToString());
            element.SetAttribute("G", this.ColorValue.G.ToString());
            element.SetAttribute("B", this.ColorValue.B.ToString());
            element.SetAttribute("A", this.ColorValue.A.ToString());

            doc.DocumentElement.AppendChild(element);
        }

        public void Dispose()
        {
            //
        }
    }
}
