using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GLSLTester.Controls.Editors
{
    internal partial class ColorEditor : UserControl, IEditorControl
    {
        Nodes.Color parentNode;
        Nodes.Color originalNode;
        List<Nodes.INode> knownNodes;

        public ColorEditor()
        {
            InitializeComponent();
        }

        public void Initialize(Nodes.INode parentNode, List<Nodes.INode> knownNodes)
        {
            this.parentNode = parentNode as Nodes.Color;
            this.originalNode = this.parentNode.Clone<Nodes.Color>();
            this.knownNodes = knownNodes;

            this.txtNodeName.Text = this.parentNode.NodeName;
            this.colorEditor1.Color = this.parentNode.ColorValue;
        }

        private void pbColorPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.parentNode.ColorValue);
        }

        private void txtNodeName_TextChanged(object sender, EventArgs e)
        {
            this.parentNode.NodeName = (sender as TextBox).Text;
            this.Validate();
        }

        private void colorEditor1_ColorChanged(object sender, EventArgs e)
        {
            this.parentNode.ColorValue = (sender as Cyotek.Windows.Forms.ColorEditor).Color;
            this.pbColorPreview.Invalidate();
        }

        private bool AreEditsValid()
        {
            if (knownNodes == null) return true;

            bool invalidName = (knownNodes.FirstOrDefault(x => x.GetNodeInstanceName() == this.originalNode.NodeName && x.GetGuid() != this.originalNode.GetGuid()) != null);

            if (invalidName)
            {
                this.txtNodeName.ForeColor = Color.Red;
                this.errorProvider.SetIconPadding(this.txtNodeName, -(this.errorProvider.Icon.Width + this.txtNodeName.Bounds.Width - this.txtNodeName.ClientRectangle.Width));
                this.errorProvider.SetError(this.txtNodeName, "The entered node name is already in use.");

                return false;
            }

            this.txtNodeName.ForeColor = SystemColors.WindowText;
            this.errorProvider.Clear();

            return true;
        }

        private void ColorEditor_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AreEditsValid();
        }

        private void txtNodeName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AreEditsValid();
        }
    }
}
