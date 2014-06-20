namespace GLSLTester.Controls.Editors
{
    partial class ColorEditor
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
            this.colorEditor1 = new Cyotek.Windows.Forms.ColorEditor();
            this.lblNodeName = new System.Windows.Forms.Label();
            this.txtNodeName = new System.Windows.Forms.TextBox();
            this.pbColorPreview = new System.Windows.Forms.PictureBox();
            this.horizontalSeperator1 = new GLSLTester.Controls.HorizontalSeperator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbColorPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // colorEditor1
            // 
            this.colorEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorEditor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorEditor1.Location = new System.Drawing.Point(3, 39);
            this.colorEditor1.Name = "colorEditor1";
            this.colorEditor1.Size = new System.Drawing.Size(253, 230);
            this.colorEditor1.TabIndex = 3;
            this.colorEditor1.ColorChanged += new System.EventHandler(this.colorEditor1_ColorChanged);
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
            // txtNodeName
            // 
            this.txtNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNodeName.Location = new System.Drawing.Point(76, 3);
            this.txtNodeName.Name = "txtNodeName";
            this.txtNodeName.Size = new System.Drawing.Size(321, 20);
            this.txtNodeName.TabIndex = 1;
            this.txtNodeName.TextChanged += new System.EventHandler(this.txtNodeName_TextChanged);
            this.txtNodeName.Validating += new System.ComponentModel.CancelEventHandler(this.txtNodeName_Validating);
            // 
            // pbColorPreview
            // 
            this.pbColorPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbColorPreview.BackColor = System.Drawing.Color.Black;
            this.pbColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColorPreview.Location = new System.Drawing.Point(262, 39);
            this.pbColorPreview.Name = "pbColorPreview";
            this.pbColorPreview.Size = new System.Drawing.Size(135, 230);
            this.pbColorPreview.TabIndex = 3;
            this.pbColorPreview.TabStop = false;
            this.pbColorPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbColorPreview_Paint);
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ColorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.horizontalSeperator1);
            this.Controls.Add(this.pbColorPreview);
            this.Controls.Add(this.txtNodeName);
            this.Controls.Add(this.lblNodeName);
            this.Controls.Add(this.colorEditor1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ColorEditor";
            this.Size = new System.Drawing.Size(400, 280);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.ColorEditor_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.pbColorPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNodeName;
        public System.Windows.Forms.TextBox txtNodeName;
        private System.Windows.Forms.PictureBox pbColorPreview;
        private HorizontalSeperator horizontalSeperator1;
        private Cyotek.Windows.Forms.ColorEditor colorEditor1;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
