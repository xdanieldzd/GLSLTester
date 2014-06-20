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
    internal partial class ObjectEditor : UserControl, IEditorControl
    {
        Nodes.Object parentNode;
        List<Nodes.INode> knownNodes;

        List<ObjectTypeEntry> objectTypes;
        ObjectTypeEntry otEntry;

        public ObjectEditor()
        {
            InitializeComponent();

            this.objectTypes = new List<ObjectTypeEntry>();

            var types = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(Objects.IRenderable).IsAssignableFrom(x) && !x.IsInterface)
                .Select(y => new
                {
                    TypeData = y,
                    RequiresPath = (RequiresPathAttribute)Attribute.GetCustomAttribute(y, typeof(RequiresPathAttribute)),
                    Description = (DescriptionAttribute)Attribute.GetCustomAttribute(y, typeof(DescriptionAttribute)),
                    DisplayOrder = (DisplayOrderAttribute)Attribute.GetCustomAttribute(y, typeof(DisplayOrderAttribute))
                })
                .OrderBy(z => z.Description.Description).OrderBy(z => z.DisplayOrder.Order);

            foreach (var type in types)
            {
                objectTypes.Add(new ObjectTypeEntry(type.Description.Description, type.TypeData, (type.RequiresPath == null ? false : type.RequiresPath.Value)));
            }

            this.cmbObjectType.DataSource = objectTypes;
            this.cmbObjectType.DisplayMember = "Name";
            this.cmbObjectType.ValueMember = "Type";
        }

        public void Initialize(Nodes.INode parentNode, List<Nodes.INode> knownNodes)
        {
            this.parentNode = parentNode as Nodes.Object;
            this.knownNodes = knownNodes;

            this.txtObjectName.Text = this.parentNode.NodeName;

            if (this.parentNode.RenderableObject != null)
                this.cmbObjectType.SelectedItem = objectTypes.FirstOrDefault(x => x.Type == this.parentNode.RenderableObject.GetType());
            else
                this.cmbObjectType.SelectedIndex = 0;

            this.chkRotateX.Checked = this.parentNode.AutoRotate[0];
            this.chkRotateY.Checked = this.parentNode.AutoRotate[1];
            this.chkRotateX.Checked = this.parentNode.AutoRotate[2];

            otEntry = (this.cmbObjectType.SelectedItem as ObjectTypeEntry);
            this.lblObjectPath.Enabled = this.txtObjectPath.Enabled = this.btnObjectBrowse.Enabled = otEntry.RequiresPath;
        }

        private void txtObjectName_TextChanged(object sender, EventArgs e)
        {
            this.parentNode.NodeName = (sender as TextBox).Text;
            this.Validate();
        }

        private void cmbObjectType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (sender as ComboBox);

            if (this.parentNode == null || comboBox.SelectedItem == null) return;

            otEntry = (comboBox.SelectedItem as ObjectTypeEntry);
            if (!otEntry.RequiresPath)
            {
                Objects.IRenderable newObject = (Objects.IRenderable)Activator.CreateInstance(otEntry.Type, null);

                if (this.parentNode.RenderableObject != null) this.parentNode.RenderableObject.Dispose();

                this.parentNode.RenderableObject = newObject;
                this.txtObjectPath.Text = string.Empty;
            }
            else
            {
                //TEST TEST TEST!
                this.txtObjectPath.Text = string.Empty;
                //this.txtObjectPath.Text = @"E:\Dokumente und Einstellungen\Daniel\Eigene Dateien\aero_model\aero_test.dae";

                //this.txtObjectPath.Text = @"E:\- 3DS OoT Hacking -\collada\mjin_okarina_model.dae";
                //this.txtObjectPath.Text = @"E:\- 3DS OoT Hacking -\collada\hf\spot00_00.dae";
                //this.txtObjectPath.Text = @"C:\Users\Daniel\Downloads\ColladaMultiTexture\ColladaMultiTexture.dae";
                //this.txtObjectPath.Text = @"C:\Users\Daniel\Downloads\SimpleXNAViewer\SimpleXNAViewer\Content\Models\duck_triangulate.dae";
            }

            this.lblObjectPath.Enabled = this.txtObjectPath.Enabled = this.btnObjectBrowse.Enabled = otEntry.RequiresPath;
        }

        private bool AreEditsValid()
        {
            if (knownNodes == null) return true;

            bool invalidName = (knownNodes.FirstOrDefault(x => x.GetNodeInstanceName() == this.parentNode.NodeName && x.GetHashCode() != this.parentNode.GetHashCode()) != null);
            bool missingPath = (otEntry != null && (otEntry.RequiresPath && (this.txtObjectPath.Text == string.Empty || !System.IO.File.Exists(this.txtObjectPath.Text))));

            if (invalidName)
            {
                this.txtObjectName.ForeColor = Color.Red;
                this.errorProvider.SetIconPadding(this.txtObjectName, -(this.errorProvider.Icon.Width + this.txtObjectName.Bounds.Width - this.txtObjectName.ClientRectangle.Width));
                this.errorProvider.SetError(this.txtObjectName, "The entered node name is already in use.");

                return false;
            }

            if (missingPath)
            {
                this.txtObjectPath.ForeColor = Color.Red;
                this.errorProvider.SetIconPadding(this.txtObjectPath, -(this.errorProvider.Icon.Width + this.txtObjectPath.Bounds.Width - this.txtObjectPath.ClientRectangle.Width));
                this.errorProvider.SetError(this.txtObjectPath, "Either no path given or file not found.");

                return false;
            }

            this.txtObjectName.ForeColor = SystemColors.WindowText;
            this.errorProvider.Clear();

            return true;
        }

        private void ObjectEditor_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AreEditsValid();
        }

        private void txtObjectName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !AreEditsValid();
        }

        private void chkRotateX_CheckedChanged(object sender, EventArgs e)
        {
            this.parentNode.AutoRotate[0] = (sender as CheckBox).Checked;
            if (this.parentNode.AutoRotate[0]) this.parentNode.Rotation[0] = 0.0;
        }

        private void chkRotateY_CheckedChanged(object sender, EventArgs e)
        {
            this.parentNode.AutoRotate[1] = (sender as CheckBox).Checked;
            if (this.parentNode.AutoRotate[1]) this.parentNode.Rotation[1] = 0.0;
        }

        private void chkRotateZ_CheckedChanged(object sender, EventArgs e)
        {
            this.parentNode.AutoRotate[2] = (sender as CheckBox).Checked;
            if (this.parentNode.AutoRotate[2]) this.parentNode.Rotation[2] = 0.0;
        }

        private void txtObjectPath_TextChanged(object sender, EventArgs e)
        {
            this.parentNode.ObjectPath = (sender as TextBox).Text;
            this.Validate();

            if (this.parentNode.ObjectPath == string.Empty) return;

            ObjectTypeEntry otEntry = (this.cmbObjectType.SelectedItem as ObjectTypeEntry);
            if (otEntry.RequiresPath)
            {
                Objects.IRenderable newObject = (Objects.IRenderable)Activator.CreateInstance(otEntry.Type, this.parentNode.ObjectPath);

                if (this.parentNode.RenderableObject != null) this.parentNode.RenderableObject.Dispose();

                this.parentNode.RenderableObject = newObject;
            }
        }

        private void btnObjectBrowse_Click(object sender, EventArgs e)
        {
            if (this.parentNode.ObjectPath != string.Empty && System.IO.File.Exists(this.parentNode.ObjectPath))
            {
                this.ofdObject.InitialDirectory = System.IO.Path.GetDirectoryName(this.parentNode.ObjectPath);
                this.ofdObject.FileName = System.IO.Path.GetFileName(this.parentNode.ObjectPath);
            }

            if (ofdObject.ShowDialog() == DialogResult.OK)
            {
                this.txtObjectPath.Text = this.ofdObject.FileName;
                this.ValidateChildren();
            }
        }

        class ObjectTypeEntry
        {
            public string Name { get; private set; }
            public Type Type { get; private set; }
            public bool RequiresPath { get; private set; }

            public ObjectTypeEntry(string name, Type type, bool requiresPath)
            {
                Name = name;
                Type = type;
                RequiresPath = requiresPath;
            }
        }
    }
}
