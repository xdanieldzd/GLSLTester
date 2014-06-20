namespace GLSLTester.Controls.Editors
{
    partial class ShaderEditor
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
            this.btnSetToDefaultShader = new System.Windows.Forms.Button();
            this.fctbShader = new FastColoredTextBoxNS.FastColoredTextBox();
            this.btnOpenShader = new System.Windows.Forms.Button();
            this.btnSaveShader = new System.Windows.Forms.Button();
            this.ofdShaderFile = new System.Windows.Forms.OpenFileDialog();
            this.sfdShaderFile = new System.Windows.Forms.SaveFileDialog();
            this.cmsDefaultShaders = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fctbShader)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetToDefaultShader
            // 
            this.btnSetToDefaultShader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetToDefaultShader.Location = new System.Drawing.Point(222, 174);
            this.btnSetToDefaultShader.Name = "btnSetToDefaultShader";
            this.btnSetToDefaultShader.Size = new System.Drawing.Size(75, 23);
            this.btnSetToDefaultShader.TabIndex = 3;
            this.btnSetToDefaultShader.Text = "&Defaults...";
            this.btnSetToDefaultShader.UseVisualStyleBackColor = true;
            this.btnSetToDefaultShader.Click += new System.EventHandler(this.btnSetToDefaultShader_Click);
            // 
            // fctbShader
            // 
            this.fctbShader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctbShader.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctbShader.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.fctbShader.BackBrush = null;
            this.fctbShader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fctbShader.CharHeight = 15;
            this.fctbShader.CharWidth = 7;
            this.fctbShader.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbShader.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbShader.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.fctbShader.IsReplaceMode = false;
            this.fctbShader.Location = new System.Drawing.Point(3, 3);
            this.fctbShader.Name = "fctbShader";
            this.fctbShader.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbShader.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbShader.ShowFoldingLines = true;
            this.fctbShader.Size = new System.Drawing.Size(294, 165);
            this.fctbShader.TabIndex = 0;
            this.fctbShader.Zoom = 100;
            this.fctbShader.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbShader_TextChanged);
            this.fctbShader.Validating += new System.ComponentModel.CancelEventHandler(this.fctbShader_Validating);
            // 
            // btnOpenShader
            // 
            this.btnOpenShader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenShader.Location = new System.Drawing.Point(3, 174);
            this.btnOpenShader.Name = "btnOpenShader";
            this.btnOpenShader.Size = new System.Drawing.Size(75, 23);
            this.btnOpenShader.TabIndex = 1;
            this.btnOpenShader.Text = "&Open";
            this.btnOpenShader.UseVisualStyleBackColor = true;
            this.btnOpenShader.Click += new System.EventHandler(this.btnOpenShader_Click);
            // 
            // btnSaveShader
            // 
            this.btnSaveShader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveShader.Location = new System.Drawing.Point(84, 174);
            this.btnSaveShader.Name = "btnSaveShader";
            this.btnSaveShader.Size = new System.Drawing.Size(75, 23);
            this.btnSaveShader.TabIndex = 2;
            this.btnSaveShader.Text = "&Save";
            this.btnSaveShader.UseVisualStyleBackColor = true;
            this.btnSaveShader.Click += new System.EventHandler(this.btnSaveShader_Click);
            // 
            // cmsDefaultShaders
            // 
            this.cmsDefaultShaders.Name = "cmsDefaultShaders";
            this.cmsDefaultShaders.Size = new System.Drawing.Size(61, 4);
            // 
            // ShaderEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveShader);
            this.Controls.Add(this.btnOpenShader);
            this.Controls.Add(this.btnSetToDefaultShader);
            this.Controls.Add(this.fctbShader);
            this.Name = "ShaderEditor";
            this.Size = new System.Drawing.Size(300, 200);
            ((System.ComponentModel.ISupportInitialize)(this.fctbShader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetToDefaultShader;
        private FastColoredTextBoxNS.FastColoredTextBox fctbShader;
        private System.Windows.Forms.Button btnOpenShader;
        private System.Windows.Forms.Button btnSaveShader;
        private System.Windows.Forms.OpenFileDialog ofdShaderFile;
        private System.Windows.Forms.SaveFileDialog sfdShaderFile;
        private System.Windows.Forms.ContextMenuStrip cmsDefaultShaders;
    }
}
