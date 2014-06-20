namespace GLSLTester.Forms
{
    partial class AddNodeForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDescriptionLabel = new System.Windows.Forms.Label();
            this.lblDescriptionText = new System.Windows.Forms.Label();
            this.gbNode = new System.Windows.Forms.GroupBox();
            this.horizontalSeperator1 = new GLSLTester.Controls.HorizontalSeperator();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.tvexNodes = new GLSLTester.Controls.TreeViewEx();
            this.gbNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(626, 387);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(707, 387);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblDescriptionLabel
            // 
            this.lblDescriptionLabel.AutoSize = true;
            this.lblDescriptionLabel.Location = new System.Drawing.Point(6, 19);
            this.lblDescriptionLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblDescriptionLabel.Name = "lblDescriptionLabel";
            this.lblDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.lblDescriptionLabel.TabIndex = 0;
            this.lblDescriptionLabel.Text = "Description:";
            // 
            // lblDescriptionText
            // 
            this.lblDescriptionText.AutoSize = true;
            this.lblDescriptionText.Location = new System.Drawing.Point(75, 19);
            this.lblDescriptionText.Margin = new System.Windows.Forms.Padding(3);
            this.lblDescriptionText.Name = "lblDescriptionText";
            this.lblDescriptionText.Size = new System.Drawing.Size(16, 39);
            this.lblDescriptionText.TabIndex = 1;
            this.lblDescriptionText.Text = "---\r\n---\r\n---\r\n";
            // 
            // gbNode
            // 
            this.gbNode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNode.Controls.Add(this.horizontalSeperator1);
            this.gbNode.Controls.Add(this.pnlEditor);
            this.gbNode.Controls.Add(this.lblDescriptionLabel);
            this.gbNode.Controls.Add(this.lblDescriptionText);
            this.gbNode.Location = new System.Drawing.Point(188, 12);
            this.gbNode.Name = "gbNode";
            this.gbNode.Size = new System.Drawing.Size(594, 369);
            this.gbNode.TabIndex = 1;
            this.gbNode.TabStop = false;
            this.gbNode.Text = "---";
            // 
            // horizontalSeperator1
            // 
            this.horizontalSeperator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalSeperator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.horizontalSeperator1.Location = new System.Drawing.Point(9, 64);
            this.horizontalSeperator1.Name = "horizontalSeperator1";
            this.horizontalSeperator1.Size = new System.Drawing.Size(579, 4);
            this.horizontalSeperator1.TabIndex = 2;
            this.horizontalSeperator1.TabStop = false;
            // 
            // pnlEditor
            // 
            this.pnlEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEditor.Location = new System.Drawing.Point(3, 71);
            this.pnlEditor.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(588, 295);
            this.pnlEditor.TabIndex = 3;
            // 
            // tvexNodes
            // 
            this.tvexNodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvexNodes.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.tvexNodes.FullRowSelect = true;
            this.tvexNodes.HideSelection = false;
            this.tvexNodes.Location = new System.Drawing.Point(12, 12);
            this.tvexNodes.Name = "tvexNodes";
            this.tvexNodes.ShowRootLines = false;
            this.tvexNodes.Size = new System.Drawing.Size(170, 369);
            this.tvexNodes.TabIndex = 0;
            this.tvexNodes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvexNodes_AfterSelect);
            this.tvexNodes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvexNodes_MouseUp);
            // 
            // AddNodeForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 422);
            this.Controls.Add(this.gbNode);
            this.Controls.Add(this.tvexNodes);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Node";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddNodeForm_FormClosing);
            this.gbNode.ResumeLayout(false);
            this.gbNode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private Controls.TreeViewEx tvexNodes;
        private System.Windows.Forms.Label lblDescriptionLabel;
        private System.Windows.Forms.Label lblDescriptionText;
        private System.Windows.Forms.GroupBox gbNode;
        private System.Windows.Forms.Panel pnlEditor;
        private Controls.HorizontalSeperator horizontalSeperator1;
    }
}