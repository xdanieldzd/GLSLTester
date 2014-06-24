using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using GLSLTester.Controls.Editors;

namespace GLSLTester.Nodes
{
    public interface INode : IDisposable
    {
        Guid GetGuid();

        void AutoSetNodeName(int number);
        string GetNodeTypeName();
        string GetDescription();
        string GetIconKey();
        string GetNodeInstanceName();

        void CreateEditorControl();
        IEditorControl GetEditorControl();

        void Execute();

        void StoreSettings(XmlDocument doc);
    }
}
