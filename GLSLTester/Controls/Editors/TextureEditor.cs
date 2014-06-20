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
    internal partial class TextureEditor : UserControl, IEditorControl
    {
        Nodes.Texture parentNode;
        List<Nodes.INode> knownNodes;

        public TextureEditor()
        {
            InitializeComponent();
        }

        public void Initialize(Nodes.INode parentNode, List<Nodes.INode> knownNodes)
        {
            this.parentNode = parentNode as Nodes.Texture;
            this.knownNodes = knownNodes;

            this.ofdTexture.SetCommonImageFilter("png");

            this.txtNodeName.Text = this.parentNode.NodeName;

            this.txtTexturePath.Text = this.parentNode.TexturePath;
            if (System.IO.File.Exists(this.txtTexturePath.Text)) this.pbPreview.Image = Bitmap.FromFile(this.txtTexturePath.Text);

            this.nudTextureUnit.Maximum = Nodes.Texture.MaxTextureUnits;

            this.Validate();
        }

        private void txtNodeName_TextChanged(object sender, EventArgs e)
        {
            this.parentNode.NodeName = (sender as TextBox).Text;
            this.Validate();
        }

        private void txtTexturePath_TextChanged(object sender, EventArgs e)
        {
            this.parentNode.TexturePath = (sender as TextBox).Text;
            this.Validate();
        }

        private void btnTextureBrowse_Click(object sender, EventArgs e)
        {
            if (this.parentNode.TexturePath != string.Empty && System.IO.File.Exists(this.parentNode.TexturePath))
            {
                this.ofdTexture.InitialDirectory = System.IO.Path.GetDirectoryName(this.parentNode.TexturePath);
                this.ofdTexture.FileName = System.IO.Path.GetFileName(this.parentNode.TexturePath);
            }

            if (ofdTexture.ShowDialog() == DialogResult.OK)
            {
                this.txtTexturePath.Text = this.ofdTexture.FileName;
                if (System.IO.File.Exists(this.txtTexturePath.Text)) this.pbPreview.Image = Bitmap.FromFile(this.txtTexturePath.Text);
                this.ValidateChildren();
            }
        }

        private void nudTextureUnit_ValueChanged(object sender, EventArgs e)
        {
            this.parentNode.TextureUnit = (int)(sender as NumericUpDown).Value;
            this.Validate();
        }

        private bool AreEditsValid()
        {
            bool result = true;
            bool invalidName = (knownNodes == null ? false : (knownNodes.FirstOrDefault(x => x.GetNodeInstanceName() == this.parentNode.NodeName && x.GetHashCode() != this.parentNode.GetHashCode()) != null));
            bool textureNotFound = !System.IO.File.Exists(this.parentNode.TexturePath);

            this.txtTexturePath.ForeColor = this.txtNodeName.ForeColor = SystemColors.WindowText;
            this.errorProvider.Clear();

            if (invalidName)
            {
                this.txtNodeName.ForeColor = Color.Red;
                this.errorProvider.SetIconPadding(this.txtNodeName, -(this.errorProvider.Icon.Width + this.txtNodeName.Bounds.Width - this.txtNodeName.ClientRectangle.Width));
                this.errorProvider.SetError(this.txtNodeName, "The entered node name is already in use.");

                result = false;
            }

            if (textureNotFound)
            {
                this.txtTexturePath.ForeColor = Color.Red;
                this.errorProvider.SetIconPadding(this.txtTexturePath, -(this.errorProvider.Icon.Width + this.txtTexturePath.Bounds.Width - this.txtTexturePath.ClientRectangle.Width));
                this.errorProvider.SetError(this.txtTexturePath, "The selected texture file does not exist.");

                result = false;
            }

            return result;
        }

        private void TextureEditor_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AreEditsValid();

            if (!e.Cancel)
            {
                this.parentNode.Dispose();
                this.parentNode.LoadTexture();
            }
        }

        private void txtNodeName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AreEditsValid();
        }

        private void txtTexturePath_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AreEditsValid();
        }

        private void nudTextureUnit_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AreEditsValid();
        }
    }
}
