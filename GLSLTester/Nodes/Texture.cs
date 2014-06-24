using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Nodes
{
    [DisplayOrderAttribute(3), ExecutionOrderAttribute(0), Serializable()]
    class Texture : INode
    {
        [NonSerialized()]
        public static int MaxTextureUnits = Aglex.Toolkit.GetInteger(GetPName.MaxTextureUnits);

        [NonSerialized()]
        Controls.Editors.TextureEditor editor;

        string defaultName;
        int number;
        Guid guid;

        public string NodeName { get; set; }
        public string TexturePath { get; set; }
        public int TextureUnit { get; set; }

        [NonSerialized()]
        Aglex.Texture texture;

        public Texture()
        {
            CreateEditorControl();

            defaultName = "textureMap";
            AutoSetNodeName(number = 0);

            guid = Guid.NewGuid();

            string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            TexturePath = System.IO.Path.Combine(executablePath, "Data", "Texture.png");
            TextureUnit = 0;
        }

        public Texture(System.Xml.XmlElement element)
        {
            CreateEditorControl();

            defaultName = "textureMap";
            number = int.Parse(element.GetAttribute("Number"));
            NodeName = element.GetAttribute("NodeName");
            guid = Guid.Parse(element.GetAttribute("Guid"));

            TexturePath = element.GetAttribute("TexturePath");
            TextureUnit = int.Parse(element.GetAttribute("TextureUnit"));
        }

        public Guid GetGuid() { return guid; }

        public void AutoSetNodeName(int number) { this.number = number; NodeName = string.Format("{0}{1}", defaultName, this.number); }
        public string GetNodeTypeName() { return "Texture Map"; }
        public string GetDescription() { return "Texture map (sampler2D) node\nDefine in shader via \"uniform sampler2D <NodeName>;\"\nAccess color ex. via \"vec4 color = texture2D(<NodeName>, <TextureCoordsSource>);\""; }
        public string GetIconKey() { return "InsertPictureHS"; }
        public string GetNodeInstanceName() { return NodeName; }

        public void CreateEditorControl() { editor = new Controls.Editors.TextureEditor() { Dock = System.Windows.Forms.DockStyle.Fill }; }
        public Controls.Editors.IEditorControl GetEditorControl() { return editor; }

        internal void LoadTexture()
        {
            if (texture != null) texture.Dispose();
            texture = new Aglex.Texture(TexturePath);
        }

        public void Execute()
        {
            GL.Enable(EnableCap.Texture2D);

            if (texture == null) LoadTexture();
            texture.Bind(OpenTK.Graphics.OpenGL.TextureUnit.Texture0 + TextureUnit);

            GL.Uniform1(GL.GetUniformLocation(GLSL.ShaderProgramID, NodeName), TextureUnit);
        }

        public void StoreSettings(System.Xml.XmlDocument doc)
        {
            System.Xml.XmlElement element = doc.CreateElement(this.GetType().Name);

            element.SetAttribute("Guid", this.guid.ToString());
            element.SetAttribute("NodeName", this.NodeName.ToString());
            element.SetAttribute("Number", this.number.ToString());

            element.SetAttribute("TexturePath", this.TexturePath);
            element.SetAttribute("TextureUnit", this.TextureUnit.ToString());

            doc.DocumentElement.AppendChild(element);
        }

        public void Dispose()
        {
            if (texture != null) texture.Dispose();
        }
    }
}
