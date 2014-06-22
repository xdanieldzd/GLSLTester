using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aglex;

namespace GLSLTester.Objects
{
    [System.ComponentModel.Description("Basic Triangle"), DisplayOrderAttribute(0), Serializable()]
    class Triangle : IRenderable
    {
        public virtual Vertex[] VertexData
        {
            get
            {
                return new Vertex[]
                {
                    new Vertex(new OpenTK.Vector3(0.0f, 50.0f, 0.0f), new OpenTK.Vector2(1.0f, 0.0f), new OpenTK.Graphics.Color4(1.0f, 0.0f, 0.0f, 1.0f), new OpenTK.Vector3(0.0f, 1.0f, 0.0f)),
                    new Vertex(new OpenTK.Vector3(-50.0f, -50.0f, 0.0f), new OpenTK.Vector2(0.0f, 1.0f), new OpenTK.Graphics.Color4(0.0f, 1.0f, 0.0f, 1.0f), new OpenTK.Vector3(-1.0f, -1.0f, 0.0f)),
                    new Vertex(new OpenTK.Vector3(50.0f, -50.0f, 0.0f), new OpenTK.Vector2(1.0f, 1.0f), new OpenTK.Graphics.Color4(0.0f, 0.0f, 1.0f, 1.0f), new OpenTK.Vector3(1.0f, -1.0f, 0.0f)),
                };
            }
        }

        public virtual uint[] Indices
        {
            get { return new uint[] { 0, 1, 2 }; }
        }

        [NonSerialized()]
        internal VertexBuffer vertexBuffer;

        public Triangle()
        {
            Initialize();
        }

        internal void Initialize()
        {
            vertexBuffer = new VertexBuffer();
            vertexBuffer.SetPrimitiveType(OpenTK.Graphics.OpenGL.PrimitiveType.Triangles);
            vertexBuffer.SetVertexData(this.VertexData);
            vertexBuffer.SetIndexData(this.Indices);

            vertexBuffer.SetRenderPass(0, Aglex.RenderPass.RenderBackFace);
            vertexBuffer.SetRenderPass(1, Aglex.RenderPass.Default);
        }

        public void Dispose()
        {
            vertexBuffer.Dispose();
        }

        public virtual void Render()
        {
            if (vertexBuffer == null) Initialize();

            vertexBuffer.Render(GLSL.ShaderProgramID);
        }
    }
}
