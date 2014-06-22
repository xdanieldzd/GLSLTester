using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GLSLTester.Nodes
{
    public interface INode : IDisposable
    {
        void AutoSetNodeName(int number);
        string GetNodeTypeName();
        string GetDescription();
        string GetIconKey();
        string GetNodeInstanceName();

        void CreateEditorControl();
        Controls.Editors.IEditorControl GetEditorControl();

        void Execute();
    }
}
