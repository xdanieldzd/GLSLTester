using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLSLTester.Objects
{
    internal interface IRenderable : IDisposable
    {
        void Render();
    }
}
