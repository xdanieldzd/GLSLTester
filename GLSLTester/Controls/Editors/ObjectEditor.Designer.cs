namespace GLSLTester.Controls.Editors
{
    partial class ObjectEditor
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtObjectName = new System.Windows.Forms.TextBox();
            this.lblNodeName = new System.Windows.Forms.Label();
            this.cmbObjectType = new System.Windows.Forms.ComboBox();
            this.lblObjectType = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblAutoRotate = new System.Windows.Forms.Label();
            this.chkRotateX = new System.Windows.Forms.CheckBox();
            this.chkRotateY = new System.Windows.Forms.CheckBox();
            this.chkRotateZ = new System.Windows.Forms.CheckBox();
            this.btnObjectBrowse = new System.Windows.Forms.Button();
            this.txtObjectPath = new System.Windows.Forms.TextBox();
            this.lblObjectPath = new System.Windows.Forms.Label();
            this.ofdObject = new System.Windows.Forms.OpenFileDialog();
            this.horizontalSeperator1 = new GLSLTester.Controls.HorizontalSeperator();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtObjectName
            // 
            this.txtObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjectName.Location = new System.Drawing.Point(76, 3);
            this.txtObjectName.Name = "txtObjectName";
            this.txtObjectName.Size = new System.Drawing.Size(321, 20);
            this.txtObjectName.TabIndex = 1;
            this.txtObjectName.TextChanged += new System.EventHandler(this.txtObjectName_TextChanged);
            this.txtObjectName.Validating += new System.ComponentModel.CancelEventHandler(this.txtObjectName_Validating);
            // 
            // lblNodeName
            // 
            this.lblNodeName.AutoSize = true;
            this.lblNodeName.Location = new System.Drawing.Point(3, 6);
            this.lblNodeName.Name = "lblNodeName";
            this.lblNodeName.Size = new System.Drawing.Size(67, 13);
            this.lblNodeName.TabIndex = 0;
            this.lblNodeName.Text = "Node Name:";
            // 
            // cmbObjectType
            // 
            this.cmbObjectType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObjectType.FormattingEnabled = true;
            this.cmbObjectType.Location = new System.Drawing.Point(76, 39);
            this.cmbObjectType.Name = "cmbObjectType";
            this.cmbObjectType.Size = new System.Drawing.Size(321, 21);
            this.cmbObjectType.TabIndex = 4;
            this.cmbObjectType.SelectionChangeCommitted += new System.EventHandler(this.cmbObjectType_SelectionChangeCommitted);
            // 
            // lblObjectType
            // 
            this.lblObjectType.AutoSize = true;
            this.lblObjectType.Location = new System.Drawing.Point(3, 42);
            this.lblObjectType.Name = "lblObjectType";
            this.lblObjectType.Size = new System.Drawing.Size(68, 13);
            this.lblObjectType.TabIndex = 3;
            this.lblObjectType.Text = "Object Type:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblAutoRotate
            // 
            this.lblAutoRotate.AutoSize = true;
            this.lblAutoRotate.Location = new System.Drawing.Point(3, 70);
            this.lblAutoRotate.Name = "lblAutoRotate";
            this.lblAutoRotate.Size = new System.Drawing.Size(67, 13);
            this.lblAutoRotate.TabIndex = 5;
            this.lblAutoRotate.Text = "Auto-Rotate:";
            // 
            // chkRotateX
            // 
            this.chkRotateX.AutoSize = true;
            this.chkRotateX.Location = new System.Drawing.Point(76, 69);
            this.chkRotateX.Margin = new System.Windows.Forms.Padding(3, 6, 20, 3);
            this.chkRotateX.Name = "chkRotateX";
            this.chkRotateX.Size = new System.Drawing.Size(54, 17);
            this.chkRotateX.TabIndex = 6;
            this.chkRotateX.Text = "X-axis";
            this.chkRotateX.UseVisualStyleBackColor = true;
            this.chkRotateX.CheckedChanged += new System.EventHandler(this.chkRotateX_CheckedChanged);
            // 
            // chkRotateY
            // 
            this.chkRotateY.AutoSize = true;
            this.chkRotateY.Location = new System.Drawing.Point(153, 69);
            this.chkRotateY.Margin = new System.Windows.Forms.Padding(3, 6, 20, 3);
            this.chkRotateY.Name = "chkRotateY";
            this.chkRotateY.Size = new System.Drawing.Size(54, 17);
            this.chkRotateY.TabIndex = 7;
            this.chkRotateY.Text = "Y-axis";
            this.chkRotateY.UseVisualStyleBackColor = true;
            this.chkRotateY.CheckedChanged += new System.EventHandler(this.chkRotateY_CheckedChanged);
            // 
            // chkRotateZ
            // 
            this.chkRotateZ.AutoSize = true;
            this.chkRotateZ.Location = new System.Drawing.Point(230, 69);
            this.chkRotateZ.Margin = new System.Windows.Forms.Padding(3, 6, 20, 3);
            this.chkRotateZ.Name = "chkRotateZ";
            this.chkRotateZ.Size = new System.Drawing.Size(54, 17);
            this.chkRotateZ.TabIndex = 8;
            this.chkRotateZ.Text = "Z-axis";
            this.chkRotateZ.UseVisualStyleBackColor = true;
            this.chkRotateZ.CheckedChanged += new System.EventHandler(this.chkRotateZ_CheckedChanged);
            // 
            // btnObjectBrowse
            // 
            this.btnObjectBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjectBrowse.CausesValidation = false;
            this.btnObjectBrowse.Location = new System.Drawing.Point(361, 92);
            this.btnObjectBrowse.Name = "btnObjectBrowse";
            this.btnObjectBrowse.Size = new System.Drawing.Size(36, 20);
            this.btnObjectBrowse.TabIndex = 11;
            this.btnObjectBrowse.Text = "...";
            this.btnObjectBrowse.UseVisualStyleBackColor = true;
            this.btnObjectBrowse.Click += new System.EventHandler(this.btnObjectBrowse_Click);
            // 
            // txtObjectPath
            // 
            this.txtObjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObjectPath.Location = new System.Drawing.Point(76, 92);
            this.txtObjectPath.Name = "txtObjectPath";
            this.txtObjectPath.ReadOnly = true;
            this.txtObjectPath.Size = new System.Drawing.Size(279, 20);
            this.txtObjectPath.TabIndex = 10;
            this.txtObjectPath.TextChanged += new System.EventHandler(this.txtObjectPath_TextChanged);
            // 
            // lblObjectPath
            // 
            this.lblObjectPath.AutoSize = true;
            this.lblObjectPath.Location = new System.Drawing.Point(3, 95);
            this.lblObjectPath.Name = "lblObjectPath";
            this.lblObjectPath.Size = new System.Drawing.Size(66, 13);
            this.lblObjectPath.TabIndex = 9;
            this.lblObjectPath.Text = "Object Path:";
            // 
            // horizontalSeperator1
            // 
            this.horizontalSeperator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalSeperator1.Location = new System.Drawing.Point(6, 29);
            this.horizontalSeperator1.Name = "horizontalSeperator1";
            this.horizontalSeperator1.Size = new System.Drawing.Size(391, 4);
            this.horizontalSeperator1.TabIndex = 2;
            this.horizontalSeperator1.Text = "horizontalSeperator1";
            // 
            // ObjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnObjectBrowse);
            this.Controls.Add(this.txtObjectPath);
            this.Controls.Add(this.lblObjectPath);
            this.Controls.Add(this.chkRotateZ);
            this.Controls.Add(this.chkRotateY);
            this.Controls.Add(this.chkRotateX);
            this.Controls.Add(this.lblAutoRotate);
            this.Controls.Add(this.lblObjectType);
            this.Controls.Add(this.cmbObjectType);
            this.Controls.Add(this.horizontalSeperator1);
            this.Controls.Add(this.txtObjectName);
            this.Controls.Add(this.lblNodeName);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ObjectEditor";
            this.Size = new System.Drawing.Size(400, 125);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.ObjectEditor_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HorizontalSeperator horizontalSeperator1;
        public System.Windows.Forms.TextBox txtObjectName;
        private System.Windows.Forms.Label lblNodeName;
        private System.Windows.Forms.ComboBox cmbObjectType;
        private System.Windows.Forms.Label lblObjectType;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblAutoRotate;
        private System.Windows.Forms.CheckBox chkRotateX;
        private System.Windows.Forms.CheckBox chkRotateZ;
        private System.Windows.Forms.CheckBox chkRotateY;
        private System.Windows.Forms.Button btnObjectBrowse;
        public System.Windows.Forms.TextBox txtObjectPath;
        private System.Windows.Forms.Label lblObjectPath;
        private System.Windows.Forms.OpenFileDialog ofdObject;
    }
}
