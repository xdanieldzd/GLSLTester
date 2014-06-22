using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenTK.Graphics.OpenGL;

using Aglex;

namespace GLSLTester.Objects
{
    [RequiresPath(true), System.ComponentModel.Description("Collada DAE File"), DisplayOrderAttribute(3)]
    class ColladaDae : IRenderable
    {
        COLLADA.Document document;
        Dictionary<string, Texture> textureMaps;

        List<MaterialShim> materialShims;
        List<GeometryShim> geometryShims;

        public ColladaDae(string path)
        {
            document = new COLLADA.Document(path);

            textureMaps = new Dictionary<string, Texture>();
            for (int i = 0; i < document.images.Count; i++)
            {
                string texPath = document.images[i].init_from.Uri.LocalPath;
                textureMaps[document.images[i].name] = new Texture(texPath);
            }

            materialShims = new List<MaterialShim>();
            foreach (COLLADA.Document.Material material in document.materials) materialShims.Add(new MaterialShim(document, material));

            geometryShims = new List<GeometryShim>();
            foreach (COLLADA.Document.Geometry geometry in document.geometries) geometryShims.Add(new GeometryShim(document, geometry));
        }

        public void Dispose()
        {
            foreach (KeyValuePair<string, Texture> texture in textureMaps)
                texture.Value.Dispose();

            foreach (GeometryShim geometry in geometryShims)
                foreach (PrimitiveShim primitive in geometry.Primitives)
                    primitive.VertexBuffer.Dispose();
        }

        public void Render()
        {
            foreach (GeometryShim geometry in geometryShims)
            {
                if (geometry == null) continue;

                foreach (PrimitiveShim primitive in geometry.Primitives)
                {
                    if (primitive == null) continue;

                    MaterialShim material = materialShims.FirstOrDefault(x => primitive.PrimitiveRaw.material.Contains(x.MaterialRaw.id));
                    if (material != null) textureMaps[material.TextureName].Bind();

                    primitive.VertexBuffer.Render(GLSL.ShaderProgramID);
                }
            }
        }

        internal class MaterialShim
        {
            COLLADA.Document document;

            public COLLADA.Document.Material MaterialRaw { get; private set; }

            public string TextureName { get; private set; }

            public MaterialShim(COLLADA.Document document, COLLADA.Document.Material material)
            {
                this.document = document;
                MaterialRaw = material;

                COLLADA.Document.Effect ef = document.effects.FirstOrDefault(x => x.name == MaterialRaw.instanceEffect.Fragment);
                foreach (COLLADA.Document.ProfileCOMMON profile in ef.profiles)
                {
                    if (profile.newParams.Count == 0) continue;

                    COLLADA.Document.Surface surface = (profile.newParams.FirstOrDefault(x => x.Value.param is COLLADA.Document.Surface).Value.param as COLLADA.Document.Surface);
                    COLLADA.Document.Image image = (document.dic[surface.initFrom] as COLLADA.Document.Image);

                    TextureName = image.name;
                }
            }
        }

        internal class GeometryShim
        {
            COLLADA.Document document;

            public COLLADA.Document.Geometry GeometryRaw { get; private set; }
            public PrimitiveShim[] Primitives { get; private set; }

            public GeometryShim(COLLADA.Document document, COLLADA.Document.Geometry geometry)
            {
                this.document = document;
                GeometryRaw = geometry;

                Primitives = new PrimitiveShim[GeometryRaw.mesh.primitives.Count];
                for (int i = 0; i < Primitives.Length; i++) Primitives[i] = new PrimitiveShim(document, GeometryRaw.mesh.primitives[i]);
            }
        }

        internal class PrimitiveShim
        {
            COLLADA.Document document;

            public COLLADA.Document.Primitive PrimitiveRaw { get; private set; }

            bool hasPositions, hasTexCoords, hasColors, hasNormals;

            Vertex[] vertices;
            uint[] indices;
            public Vertex[] Vertices { get { return vertices; } }
            public uint[] Indices { get { return indices; } }

            public VertexBuffer VertexBuffer { get; private set; }

            public PrimitiveShim(COLLADA.Document document, COLLADA.Document.Primitive primitive)
            {
                Parse(document, primitive);
            }

            public void Parse(COLLADA.Document document, COLLADA.Document.Primitive primitive)
            {
                this.document = document;
                PrimitiveRaw = primitive;

                int vertexCount = (PrimitiveRaw.p.Length / PrimitiveRaw.stride);
                vertices = new Vertex[vertexCount];

                foreach (COLLADA.Document.Input input in PrimitiveRaw.Inputs)
                {
                    if (input.source is COLLADA.Document.Vertices && input.semantic == "VERTEX")
                    {
                        ReadConvertArray(input, ((input.source as COLLADA.Document.Vertices).inputs.FirstOrDefault().source) as COLLADA.Document.Source);
                    }
                    else if (input.source is COLLADA.Document.Source)
                    {
                        ReadConvertArray(input, (input.source as COLLADA.Document.Source));
                    }
                }

                if (!hasColors)
                {
                    for (int i = 0; i < vertices.Length; i++) vertices[i].Color = OpenTK.Graphics.Color4.White;
                    hasColors = true;
                }

                indices = new uint[PrimitiveRaw.p.Length / PrimitiveRaw.stride];
                for (uint i = 0; i < indices.Length; i++) indices[i] = i;

                if (!hasNormals) VertexBuffer.CalculateNormals(ref vertices, indices, indices.Length / 3);

                if (VertexBuffer == null)
                {
                    VertexBuffer = new VertexBuffer();
                    VertexBuffer.SetPrimitiveType(PrimitiveType.Triangles);
                    VertexBuffer.SetVertexData(vertices);
                    VertexBuffer.SetIndexData(indices);

                    VertexBuffer.SetRenderPass(0, RenderPass.RenderBackFace);
                    VertexBuffer.SetRenderPass(1, RenderPass.Default);
                }
            }

            private void ReadConvertArray(COLLADA.Document.Input input, COLLADA.Document.Source source)
            {
                switch (source.arrayType)
                {
                    case "float_array":
                        {
                            float[] floats = (source.array as COLLADA.Document.Array<float>).arr;
                            if (floats.Length == 0) break;

                            if (input.semantic == "VERTEX") hasPositions = true;
                            else if (input.semantic == "TEXCOORD") hasTexCoords = true;
                            else if (input.semantic == "COLOR") hasColors = true;
                            else if (input.semantic == "NORMAL") hasNormals = true;

                            if (PrimitiveRaw is COLLADA.Document.Triangle)
                            {
                                for (int i = input.offset, j = 0; i < PrimitiveRaw.p.Length; i += PrimitiveRaw.stride, j++)
                                {
                                    int fidx = (PrimitiveRaw.p[i] * source.accessor.stride);

                                    for (int k = 0; k < source.accessor.stride; k++)
                                    {
                                        if (input.semantic == "VERTEX")
                                        {
                                            if (source.accessor.parameters[k].name == "X") vertices[j].Position.X = floats[fidx + k];
                                            if (source.accessor.parameters[k].name == "Y") vertices[j].Position.Y = floats[fidx + k];
                                            if (source.accessor.parameters[k].name == "Z") vertices[j].Position.Z = floats[fidx + k];
                                        }
                                        else if (input.semantic == "TEXCOORD")
                                        {
                                            if (source.accessor.parameters[k].name == "S") vertices[j].TexCoord.X = floats[fidx + k];
                                            if (source.accessor.parameters[k].name == "T") vertices[j].TexCoord.Y = -floats[fidx + k];
                                        }
                                        else if (input.semantic == "COLOR")
                                        {
                                            if (source.accessor.parameters[k].name == "R") vertices[j].Color.R = floats[fidx + k];
                                            if (source.accessor.parameters[k].name == "G") vertices[j].Color.G = floats[fidx + k];
                                            if (source.accessor.parameters[k].name == "B") vertices[j].Color.B = floats[fidx + k];
                                            if (source.accessor.parameters[k].name == "A") vertices[j].Color.A = floats[fidx + k];
                                        }
                                        else if (input.semantic == "NORMAL")
                                        {
                                            if (source.accessor.parameters[k].name == "X") vertices[j].Normal.X = floats[fidx + k];
                                            if (source.accessor.parameters[k].name == "Y") vertices[j].Normal.Y = floats[fidx + k];
                                            if (source.accessor.parameters[k].name == "Z") vertices[j].Normal.Z = floats[fidx + k];
                                        }
                                    }
                                }
                            }
                            else if (PrimitiveRaw is COLLADA.Document.Polylist)
                            {
                                // \COLLADA for XNA\COLLADAPipeline\COLLADAPipeline\COLLADAConditioner.cs
                                int triangleCount = 0;

                                foreach (int vcount in PrimitiveRaw.vcount) triangleCount += vcount - 2;
                                int[] newP = new int[PrimitiveRaw.stride * triangleCount * 3];
                                int count = 0;
                                int offset = 0;
                                int first = 0;
                                int last = 0;
                                int j, k;

                                foreach (int vcount in PrimitiveRaw.vcount)
                                {
                                    first = offset;
                                    last = first + 1;
                                    for (j = 0; j < vcount - 2; j++)
                                    {
                                        for (k = 0; k < PrimitiveRaw.stride; k++) newP[count++] = PrimitiveRaw.p[k + first * PrimitiveRaw.stride];
                                        for (k = 0; k < PrimitiveRaw.stride; k++) newP[count++] = PrimitiveRaw.p[k + last * PrimitiveRaw.stride];
                                        last += 1;
                                        for (k = 0; k < PrimitiveRaw.stride; k++) newP[count++] = PrimitiveRaw.p[k + last * PrimitiveRaw.stride];
                                    }
                                    offset = last + 1;
                                }

                                Parse(document, new COLLADA.Document.Triangle(document, count / PrimitiveRaw.stride / 3, PrimitiveRaw.Inputs, newP) { material = PrimitiveRaw.material });
                            }
                            break;
                        }

                    default:
                        throw new Exception("unhandled array type");
                }
            }
        }
    }
}
