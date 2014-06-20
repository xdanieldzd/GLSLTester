using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GLSLTester.Controls;
using GLSLTester.Controls.Editors;

namespace GLSLTester.Forms
{
    internal partial class AddNodeForm : Form
    {
        internal Nodes.INode NewNode { get; private set; }

        IEditorControl editorControl;
        List<Nodes.INode> knownNodes;

        internal AddNodeForm(List<Nodes.INode> knownNodes)
        {
            InitializeComponent();

            this.knownNodes = knownNodes;

            var types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(Nodes.INode).IsAssignableFrom(x) && !x.IsInterface)
                .Select(y => new
                {
                    Property = y,
                    Attribute = (DisplayOrderAttribute)Attribute.GetCustomAttribute(y, typeof(DisplayOrderAttribute)),
                    IsNextSeparator = (IsNextSeparatorAttribute)Attribute.GetCustomAttribute(y, typeof(IsNextSeparatorAttribute))
                })
                .OrderBy(z => z.Attribute.Order);

            foreach (var type in types)
            {
                Nodes.INode node = (Nodes.INode)Activator.CreateInstance(Type.GetType(type.Property.FullName));
                if (this.knownNodes != null) node.AutoSetNodeName(this.knownNodes.Count(x => x.GetType() == type.Property));

                tvexNodes.Nodes.Add(new TreeNodeEx(node.GetNodeTypeName()) { Tag = node, ImageKey = node.GetIconKey(), SelectedImageKey = node.GetIconKey() });

                if (type.IsNextSeparator != null && type.IsNextSeparator.Value)
                {
                    tvexNodes.Nodes.Add(new TreeNodeEx() { IsSelectable = false, IsSeparator = true });
                }
            }

            tvexNodes.ImageList = Program.NodeImageList;
            tvexNodes.SelectedNode = tvexNodes.Nodes.Cast<TreeNode>().FirstOrDefault(x => x is TreeNodeEx && (x as TreeNodeEx).IsSelectable);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape) this.DialogResult = DialogResult.Cancel;
            return base.ProcessDialogKey(keyData);
        }

        private void tvexNodes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pnlEditor.Controls.Clear();

            TreeViewEx treeView = (sender as TreeViewEx);

            NewNode = (treeView.SelectedNode = e.Node).Tag as Nodes.INode;

            lblDescriptionText.Text = NewNode.GetDescription();
            gbNode.Text = NewNode.GetNodeTypeName();

            editorControl = NewNode.GetEditorControl();
            if (editorControl != null)
            {
                editorControl.Initialize(NewNode, knownNodes);

                UserControl editorUserControl = (editorControl as UserControl);
                editorUserControl.Dock = DockStyle.Fill;
                editorUserControl.ValidateChildren(ValidationConstraints.Visible);

                pnlEditor.Controls.Add(editorUserControl);
            }
        }

        private void tvexNodes_MouseUp(object sender, MouseEventArgs e)
        {
            TreeViewEx treeView = (sender as TreeViewEx);
            if (treeView.HitTest(e.Location).Node != null) treeView.SelectedNode = treeView.GetNodeAt(e.Location);
        }

        private void AddNodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == System.Windows.Forms.DialogResult.OK) e.Cancel = !this.ValidateChildren(ValidationConstraints.Visible);
        }
    }
}
