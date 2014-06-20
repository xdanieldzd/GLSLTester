using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Objects
{
    [System.ComponentModel.Description("Basic Triangle"), DisplayOrderAttribute(0)]
    class Triangle : IRenderable
    {
        public virtual Rendering.Vertex[] VertexData
        {
            get
            {
                return new Rendering.Vertex[]
                {
                    new Rendering.Vertex(new OpenTK.Vector3(0.0f, 50.0f, 0.0f), new OpenTK.Vector2(1.0f, 0.0f), new OpenTK.Graphics.Color4(1.0f, 0.0f, 0.0f, 1.0f), new OpenTK.Vector3(0.0f, 1.0f, 0.0f)),
                    new Rendering.Vertex(new OpenTK.Vector3(-50.0f, -50.0f, 0.0f), new OpenTK.Vector2(0.0f, 1.0f), new OpenTK.Graphics.Color4(0.0f, 1.0f, 0.0f, 1.0f), new OpenTK.Vector3(-1.0f, -1.0f, 0.0f)),
                    new Rendering.Vertex(new OpenTK.Vector3(50.0f, -50.0f, 0.0f), new OpenTK.Vector2(1.0f, 1.0f), new OpenTK.Graphics.Color4(0.0f, 0.0f, 1.0f, 1.0f), new OpenTK.Vector3(1.0f, -1.0f, 0.0f)),
                };
            }
        }

        public virtual uint[] Indices
        {
            get { return new uint[] { 0, 1, 2 }; }
        }

        internal Rendering.VertexBuffer vertexBuffer;

        public Triangle()
        {
            vertexBuffer = new Rendering.VertexBuffer();
            vertexBuffer.SetPrimitiveType(PrimitiveType.Triangles);
            vertexBuffer.SetVertexData(this.VertexData);
            vertexBuffer.SetIndexData(this.Indices);

            vertexBuffer.SetRenderPass(0, Rendering.RenderPass.RenderBackFace);
            vertexBuffer.SetRenderPass(1, Rendering.RenderPass.Default);
        }

        public void Dispose()
        {
            vertexBuffer.Dispose();
        }

        public virtual void Render()
        {
            vertexBuffer.Render();
        }
    }
}
