﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aglex;

namespace GLSLTester.Objects
{
    [System.ComponentModel.Description("Basic Quad"), DisplayOrderAttribute(1)]
    class Quad : Triangle, IRenderable
    {
        public override Vertex[] VertexData
        {
            get
            {
                return new Vertex[]
                {
                    new Vertex(new OpenTK.Vector3(-50.0f, 50.0f, 0.0f), new OpenTK.Vector2(0.0f, 0.0f), new OpenTK.Graphics.Color4(1.0f, 0.0f, 0.0f, 1.0f), new OpenTK.Vector3(-1.0f, 1.0f, 0.0f)),
                    new Vertex(new OpenTK.Vector3(-50.0f, -50.0f, 0.0f), new OpenTK.Vector2(0.0f, 1.0f), new OpenTK.Graphics.Color4(0.0f, 1.0f, 0.0f, 1.0f), new OpenTK.Vector3(-1.0f, -1.0f, 0.0f)),
                    new Vertex(new OpenTK.Vector3(50.0f, -50.0f, 0.0f), new OpenTK.Vector2(1.0f, 1.0f), new OpenTK.Graphics.Color4(0.0f, 0.0f, 1.0f, 1.0f), new OpenTK.Vector3(1.0f, -1.0f, 0.0f)),
                    new Vertex(new OpenTK.Vector3(50.0f, 50.0f, 0.0f), new OpenTK.Vector2(1.0f, 0.0f), new OpenTK.Graphics.Color4(1.0f, 1.0f, 0.0f, 1.0f), new OpenTK.Vector3(1.0f, 1.0f, 0.0f))
                };
            }
        }

        public override uint[] Indices
        {
            get { return new uint[] { 0, 1, 2, 2, 3, 0 }; }
        }
    }
}
