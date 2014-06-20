using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLSLTester.Nodes
{
    internal interface INode : IDisposable
    {
        void AutoSetNodeName(int number);
        string GetNodeTypeName();
        string GetDescription();
        string GetIconKey();
        string GetNodeInstanceName();
        Controls.Editors.IEditorControl GetEditorControl();
        
        void Execute();
    }
}
