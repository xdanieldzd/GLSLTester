using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace GLSLTester.Rendering
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Vertex
    {
        public Vector3 Position;
        public Vector2 TexCoord;
        public Color4 Color;
        public Vector3 Normal;

        public static readonly int Stride = Marshal.SizeOf(default(Vertex));

        public static readonly int PositionOffset = Marshal.OffsetOf(typeof(Vertex), "Position").ToInt32();
        public static readonly int TexCoordOffset = Marshal.OffsetOf(typeof(Vertex), "TexCoord").ToInt32();
        public static readonly int ColorOffset = Marshal.OffsetOf(typeof(Vertex), "Color").ToInt32();
        public static readonly int NormalOffset = Marshal.OffsetOf(typeof(Vertex), "Normal").ToInt32();

        public Vertex(Vector3 position, Vector2 texCoord, Color4 color, Vector3 normal)
        {
            this.Position = position;
            this.TexCoord = texCoord;
            this.Color = color;
            this.Normal = normal;
        }
    }

    internal class VertexBufferException : Exception
    {
        public VertexBufferException() : base() { }
        public VertexBufferException(string message) : base(message) { }
        public VertexBufferException(string message, Exception innerException) : base(message, innerException) { }
        public VertexBufferException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /*int size; GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out size);*/

    internal class VertexBuffer : IDisposable
    {
        internal enum RenderMode { Simple, TwoPassOutline };

        int vertexBufferId, indexBufferId, indexCount;
        PrimitiveType primitiveType;
        RenderPassManager renderPassManager;

        public VertexBuffer()
        {
            vertexBufferId = GL.GenBuffer();
            indexBufferId = GL.GenBuffer();

            primitiveType = PrimitiveType.Triangles;

            renderPassManager = new RenderPassManager(16);
            renderPassManager.SetRenderPass(0, RenderPass.Default);
        }

        public void Dispose()
        {
            if (GL.IsBuffer(vertexBufferId)) GL.DeleteBuffer(vertexBufferId);
            if (GL.IsBuffer(indexBufferId)) GL.DeleteBuffer(indexBufferId);
        }

        private void BindBuffers()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferId);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBufferId);
        }

        private void ReleaseBuffers()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void SetPrimitiveType(PrimitiveType type)
        {
            primitiveType = type;
        }

        public void SetRenderPass(int number, RenderPass info)
        {
            if (renderPassManager == null) throw new VertexBufferException("RenderPassManager is null");

            renderPassManager.SetRenderPass(number, info);
        }

        public void SetVertexData(Vertex[] data)
        {
            if (data == null) throw new VertexBufferException("Vertex data is null");

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(data.Length * Vertex.Stride), data, BufferUsageHint.StaticDraw);
        }

        public void SetIndexData(uint[] data)
        {
            if (data == null) throw new VertexBufferException("Index data is null");

            indexCount = data.Length;

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBufferId);
            GL.BufferData(BufferTarget.ElementArrayBuffer, new IntPtr(data.Length * sizeof(uint)), data, BufferUsageHint.StaticDraw);
        }

        public void Render()
        {
            BindBuffers();

            GL.EnableVertexAttribArray(Rendering.Consts.PositionAttributeIndex);
            GL.EnableVertexAttribArray(Rendering.Consts.TexCoordAttributeIndex);
            GL.EnableVertexAttribArray(Rendering.Consts.ColorAttributeIndex);
            GL.EnableVertexAttribArray(Rendering.Consts.NormalAttributeIndex);

            GL.VertexAttribPointer(Rendering.Consts.PositionAttributeIndex, 3, VertexAttribPointerType.Float, false, Vertex.Stride, Vertex.PositionOffset);
            GL.VertexAttribPointer(Rendering.Consts.TexCoordAttributeIndex, 2, VertexAttribPointerType.Float, false, Vertex.Stride, Vertex.TexCoordOffset);
            GL.VertexAttribPointer(Rendering.Consts.ColorAttributeIndex, 4, VertexAttribPointerType.Float, false, Vertex.Stride, Vertex.ColorOffset);
            GL.VertexAttribPointer(Rendering.Consts.NormalAttributeIndex, 3, VertexAttribPointerType.Float, false, Vertex.Stride, Vertex.NormalOffset);

            renderPassManager.Perform(new Action(() =>
            {
                GL.Uniform1(GL.GetUniformLocation(GLSL.ShaderProgramID, "passNumber"), renderPassManager.CurrentPass);
                GL.DrawElements(primitiveType, indexCount, DrawElementsType.UnsignedInt, 0);
            }));

            GL.DisableVertexAttribArray(Rendering.Consts.PositionAttributeIndex);
            GL.DisableVertexAttribArray(Rendering.Consts.TexCoordAttributeIndex);
            GL.DisableVertexAttribArray(Rendering.Consts.ColorAttributeIndex);
            GL.DisableVertexAttribArray(Rendering.Consts.NormalAttributeIndex);

            ReleaseBuffers();
        }

        public static void CalculateNormals(ref Vertex[] vertices, uint[] indices, int numFaces)
        {
            /* Surface normals - http://www.opengl.org/wiki/Calculating_a_Surface_Normal#Newell.27s_Method */
            OpenTK.Vector3[] surfaceNormals = new OpenTK.Vector3[numFaces];

            for (int i = 0; i < indices.Length; i += 3)
            {
                OpenTK.Vector3 surfaceNormal = OpenTK.Vector3.Zero;

                for (int v = 0; v < 3; v++)
                {
                    OpenTK.Vector3 currentVertex = vertices[indices[i + v]].Position;
                    OpenTK.Vector3 nextVertex = vertices[indices[i + ((v + 1) % 3)]].Position;

                    surfaceNormal.X += (currentVertex.Y - nextVertex.Y) * (currentVertex.Z + nextVertex.Z);
                    surfaceNormal.Y += (currentVertex.Z - nextVertex.Z) * (currentVertex.X + nextVertex.X);
                    surfaceNormal.Z += (currentVertex.X - nextVertex.X) * (currentVertex.Y + nextVertex.Y);
                }

                surfaceNormal.Normalize();

                surfaceNormals[i / 3] = surfaceNormal;
            }

            /* Vertex normals - https://www.opengl.org/discussion_boards/showthread.php/128451-How-to-calculate-vertex-normals?p=966239&viewfull=1#post966239 */
            int shared = 0;
            OpenTK.Vector3 sum = OpenTK.Vector3.Zero;

            for (int v = 0; v < vertices.Length; v++)
            {
                for (int f = 0; f < indices.Length; f += 3)
                {
                    if (vertices[indices[f]].Position == vertices[v].Position || vertices[indices[f + 1]].Position == vertices[v].Position || vertices[indices[f + 2]].Position == vertices[v].Position)
                    {
                        sum += surfaceNormals[indices[f / 3]];
                        shared++;
                    }
                }

                sum /= (float)shared;
                sum.Normalize();

                vertices[v].Normal = sum;

                sum = OpenTK.Vector3.Zero;
                shared = 0;
            }
        }
    }
}
