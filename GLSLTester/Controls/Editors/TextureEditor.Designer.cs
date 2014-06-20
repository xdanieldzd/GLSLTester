namespace GLSLTester.Controls.Editors
{
    partial class TextureEditor
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.lblNodeName = new System.Windows.Forms.Label();
            this.lblTexturePath = new System.Windows.Forms.Label();
            this.txtTexturePath = new System.Windows.Forms.TextBox();
            this.btnTextureBrowse = new System.Windows.Forms.Button();
            this.ofdTexture = new System.Windows.Forms.OpenFileDialog();
            this.nudTextureUnit = new System.Windows.Forms.NumericUpDown();
            this.lblTextureUnit = new System.Windows.Forms.Label();
            this.lblPreview = new System.Windows.Forms.Label();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.horizontalSeperator1 = new GLSLTester.Controls.HorizontalSeperator();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTextureUnit)).BeginInit();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtNodeName
            // 
            this.txtNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNodeName.Location = new System.Drawing.Point(80, 3);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(317, 20);
            this.txtNodeName.TabIndex = 1;
            this.txtNodeName.TextChanged += new System.EventHandler(this.txtNodeName_TextChanged);
            this.txtNodeName.Validating += new System.ComponentModel.CancelEventHandler(this.txtNodeName_Validating);
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
            // lblTexturePath
            // 
            this.lblTexturePath.AutoSize = true;
            this.lblTexturePath.Location = new System.Drawing.Point(3, 36);
            this.lblTexturePath.Name = "lblTexturePath";
            this.lblTexturePath.Size = new System.Drawing.Size(71, 13);
            this.lblTexturePath.TabIndex = 3;
            this.lblTexturePath.Text = "Texture Path:";
            // 
            // txtTexturePath
            // 
            this.txtTexturePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTexturePath.Location = new System.Drawing.Point(80, 33);
            this.txtTexturePath.Name = "txtTexturePath";
            this.txtTexturePath.Size = new System.Drawing.Size(275, 20);
            this.txtTexturePath.TabIndex = 4;
            this.txtTexturePath.TextChanged += new System.EventHandler(this.txtTexturePath_TextChanged);
            this.txtTexturePath.Validating += new System.ComponentModel.CancelEventHandler(this.txtTexturePath_Validating);
            // 
            // btnTextureBrowse
            // 
            this.btnTextureBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTextureBrowse.CausesValidation = false;
            this.btnTextureBrowse.Location = new System.Drawing.Point(361, 33);
            this.btnTextureBrowse.Name = "btnTextureBrowse";
            this.btnTextureBrowse.Size = new System.Drawing.Size(36, 20);
            this.btnTextureBrowse.TabIndex = 5;
            this.btnTextureBrowse.Text = "...";
            this.btnTextureBrowse.UseVisualStyleBackColor = true;
            this.btnTextureBrowse.Click += new System.EventHandler(this.btnTextureBrowse_Click);
            // 
            // nudTextureUnit
            // 
            this.nudTextureUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTextureUnit.Location = new System.Drawing.Point(80, 59);
            this.nudTextureUnit.Name = "nudTextureUnit";
            this.nudTextureUnit.Size = new System.Drawing.Size(317, 20);
            this.nudTextureUnit.TabIndex = 7;
            this.nudTextureUnit.ValueChanged += new System.EventHandler(this.nudTextureUnit_ValueChanged);
            this.nudTextureUnit.Validating += new System.ComponentModel.CancelEventHandler(this.nudTextureUnit_Validating);
            // 
            // lblTextureUnit
            // 
            this.lblTextureUnit.AutoSize = true;
            this.lblTextureUnit.Location = new System.Drawing.Point(3, 61);
            this.lblTextureUnit.Name = "lblTextureUnit";
            this.lblTextureUnit.Size = new System.Drawing.Size(68, 13);
            this.lblTextureUnit.TabIndex = 6;
            this.lblTextureUnit.Text = "Texture Unit:";
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(3, 82);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(48, 13);
            this.lblPreview.TabIndex = 8;
            this.lblPreview.Text = "Preview:";
            // 
            // pnlPreview
            // 
            this.pnlPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPreview.AutoScroll = true;
            this.pnlPreview.Controls.Add(this.pbPreview);
            this.pnlPreview.Location = new System.Drawing.Point(80, 85);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(317, 162);
            this.pnlPreview.TabIndex = 10;
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(75, 75);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPreview.TabIndex = 11;
            this.pbPreview.TabStop = false;
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
            // TextureEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.lblTextureUnit);
            this.Controls.Add(this.nudTextureUnit);
            this.Controls.Add(this.btnTextureBrowse);
            this.Controls.Add(this.txtTexturePath);
            this.Controls.Add(this.lblTexturePath);
            this.Controls.Add(this.horizontalSeperator1);
            this.Controls.Add(this.txtNodeName);
            this.Controls.Add(this.lblNodeName);
            this.Name = "TextureEditor";
            this.Size = new System.Drawing.Size(400, 250);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.TextureEditor_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTextureUnit)).EndInit();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private HorizontalSeperator horizontalSeperator1;
        public System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.Label lblNodeName;
        public System.Windows.Forms.TextBox txtTexturePath;
        private System.Windows.Forms.Label lblTexturePath;
        private System.Windows.Forms.Button btnTextureBrowse;
        private System.Windows.Forms.OpenFileDialog ofdTexture;
        private System.Windows.Forms.NumericUpDown nudTextureUnit;
        private System.Windows.Forms.Label lblTextureUnit;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.PictureBox pbPreview;
    }
}
