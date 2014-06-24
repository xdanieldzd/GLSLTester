using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GLSLTester
{
    public class NodeList : List<Nodes.INode>
    {
        Workspace workspace;

        public NodeList(Workspace workspace)
            : base()
        {
            this.workspace = workspace;
        }

        public new void Add(Nodes.INode node)
        {
            base.Add(node);
            this.workspace.RecreateWorkspaceRoot();
            this.workspace.UpdateShaders();
        }

        public new void Remove(Nodes.INode node)
        {
            node.Dispose();
            base.Remove(node);
            this.workspace.RecreateWorkspaceRoot();
            this.workspace.UpdateShaders();
        }

        public void Replace(Nodes.INode oldNode, Nodes.INode newNode)
        {
            base[base.IndexOf(oldNode)] = newNode;
            this.workspace.RecreateWorkspaceRoot();
            this.workspace.UpdateShaders();
        }
    }

    public class Workspace : IDisposable
    {
        public NodeList KnownNodes { get; private set; }
        public TreeNode WorkspaceRoot { get; private set; }

        TreeView treeView;

        public Workspace(TreeView treeView) : this(treeView, string.Empty) { }

        public Workspace(TreeView treeView, string path)
        {
            this.treeView = treeView;
            this.treeView.Nodes.Clear();

            KnownNodes = new NodeList(this);
            WorkspaceRoot = new TreeNode("Workspace Root") { ImageKey = "Web", SelectedImageKey = "Web" };

            this.treeView.Nodes.Add(WorkspaceRoot);

            if (path != string.Empty && System.IO.File.Exists(path))
            {
                XmlDocument document = new XmlDocument();
                document.Load(path);

                foreach (XmlElement element in document.DocumentElement.ChildNodes)
                {
                    Type type = Type.GetType("GLSLTester.Nodes." + element.Name);
                    if (type != null)
                    {
                        Nodes.INode loadedNode = (Nodes.INode)Activator.CreateInstance(type, new object[] { element });
                        if (loadedNode != null) KnownNodes.Add(loadedNode);
                    }
                }

                foreach (Nodes.INode node in KnownNodes) node.GetEditorControl().Initialize(node, KnownNodes);

                UpdateShaders();
            }
        }

        public void Dispose()
        {
            foreach (Nodes.INode node in KnownNodes) node.Dispose();
        }

        public void CreateDefault()
        {
            List<Nodes.INode> defaultNodes = new List<Nodes.INode>();
            defaultNodes.Add(new Nodes.VertexShader());
            defaultNodes.Add(new Nodes.FragmentShader());
            defaultNodes.Add(new Nodes.Object());
            defaultNodes.Add(new Nodes.Texture());

            KnownNodes.AddRange(defaultNodes);

            RecreateWorkspaceRoot();
        }

        public void ExecuteNodes()
        {
            foreach (var node in KnownNodes.Select(x => new
            {
                Property = x,
                Attribute = (ExecutionOrderAttribute)Attribute.GetCustomAttribute(x.GetType(), typeof(ExecutionOrderAttribute))
            }).OrderBy(y => y.Attribute.Order))
            {
                node.Property.Execute();
            }
        }

        internal void UpdateShaders()
        {
            Nodes.VertexShader vertexShaderNode = (KnownNodes.FirstOrDefault(x => x is Nodes.VertexShader) as Nodes.VertexShader);
            Nodes.FragmentShader fragmentShaderNode = (KnownNodes.FirstOrDefault(x => x is Nodes.FragmentShader) as Nodes.FragmentShader);

            if (vertexShaderNode != null) GLSL.CompileShader(vertexShaderNode.ShaderType, vertexShaderNode.ShaderString);
            if (fragmentShaderNode != null) GLSL.CompileShader(fragmentShaderNode.ShaderType, fragmentShaderNode.ShaderString);
        }

        internal void RecreateWorkspaceRoot()
        {
            WorkspaceRoot.Nodes.Clear();

            foreach (Nodes.INode node in KnownNodes)
            {
                WorkspaceRoot.Nodes.Add(new TreeNode()
                {
                    Text = (node.GetNodeInstanceName() != string.Empty ? string.Format("{0} [{1}]", node.GetNodeTypeName(), node.GetNodeInstanceName()) : node.GetNodeTypeName()),
                    Tag = node,
                    ImageKey = node.GetIconKey(),
                    SelectedImageKey = node.GetIconKey()
                });
            }

            WorkspaceRoot.Expand();
        }

        public void Save(string path)
        {
            XmlDocument document = new XmlDocument();

            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = document.DocumentElement;
            document.InsertBefore(declaration, root);

            XmlElement main = document.CreateElement("Workspace");
            document.AppendChild(main);

            foreach (Nodes.INode node in KnownNodes) node.StoreSettings(document);

            document.Save(path);
        }
    }
}
