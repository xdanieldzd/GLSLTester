﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLSLTester.Controls.Editors
{
    internal interface IEditorControl
    {
        void Initialize(Nodes.INode parentNode, List<Nodes.INode> knownNodes);
    }
}
