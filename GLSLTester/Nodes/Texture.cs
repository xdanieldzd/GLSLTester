using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Nodes
{
    [DisplayOrderAttribute(3), ExecutionOrderAttribute(0)]
    class Texture : INode
    {
        public static int MaxTextureUnits = Aglex.Toolkit.GetInteger(GetPName.MaxTextureUnits);

        string defaultName;
        Controls.Editors.TextureEditor editor;
        int number;

        public string NodeName { get; set; }
        public string TexturePath { get; set; }
        public int TextureUnit { get; set; }

        int oglTextureId;

        public Texture()
        {
            defaultName = "textureMap";
            editor = new Controls.Editors.TextureEditor() { Dock = System.Windows.Forms.DockStyle.Fill };

            AutoSetNodeName(number = 0);

            string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            TexturePath = System.IO.Path.Combine(executablePath, "Data", "Texture.png");
            TextureUnit = 0;

            LoadTexture();
        }

        public void AutoSetNodeName(int number) { this.number = number; NodeName = string.Format("{0}{1}", defaultName, this.number); }
        public string GetNodeTypeName() { return "Texture Map"; }
        public string GetDescription() { return "Texture map (sampler2D) node\nDefine in shader via \"uniform sampler2D <NodeName>;\"\nAccess color ex. via \"vec4 color = texture2D(<NodeName>, <TextureCoordsSource>);\""; }
        public string GetIconKey() { return "InsertPictureHS"; }
        public string GetNodeInstanceName() { return NodeName; }
        public Controls.Editors.IEditorControl GetEditorControl() { return editor; }

        internal void LoadTexture()
        {
            oglTextureId = Shims.GLShims.LoadTexture(TexturePath, TextureUnit);
        }

        public void Execute()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.ActiveTexture(OpenTK.Graphics.OpenGL.TextureUnit.Texture0 + TextureUnit);
            GL.BindTexture(TextureTarget.Texture2D, oglTextureId);
            GL.Uniform1(GL.GetUniformLocation(GLSL.ShaderProgramID, NodeName), TextureUnit);
        }

        public void Dispose()
        {
            if (GL.IsTexture(oglTextureId)) GL.DeleteTexture(oglTextureId);
        }
    }
}
