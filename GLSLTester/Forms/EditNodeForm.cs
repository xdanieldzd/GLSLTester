using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GLSLTester.Controls.Editors;

namespace GLSLTester.Forms
{
    internal partial class EditNodeForm : Form
    {
        internal Nodes.INode EditNode { get; private set; }

        IEditorControl editorControl;

        internal EditNodeForm(List<Nodes.INode> knownNodes, Nodes.INode editNode)
        {
            InitializeComponent();

            EditNode = editNode;

            lblDescriptionText.Text = EditNode.GetDescription();
            gbNode.Text = EditNode.GetNodeTypeName();

            editorControl = EditNode.GetEditorControl();
            if (editorControl != null)
            {
                editorControl.Initialize(EditNode, knownNodes);

                UserControl editorUserControl = (editorControl as UserControl);
                editorUserControl.Dock = DockStyle.Fill;
                editorUserControl.BringToFront();

                pnlEditor.Controls.Add(editorUserControl);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape) this.DialogResult = DialogResult.Cancel;
            return base.ProcessDialogKey(keyData);
        }

        private void EditNodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == System.Windows.Forms.DialogResult.OK) e.Cancel = !this.ValidateChildren(ValidationConstraints.Visible);
        }
    }
}
